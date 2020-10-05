using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem;
using System.Threading;
using UnityEngine.SocialPlatforms;

public class PlayerShip : MonoBehaviour
{
    [SerializeField] private Rigidbody2D shipBody = null;
    [SerializeField] private Thruster mainThruster = null;
    [SerializeField] private Thruster[] sideThrusters = new Thruster[2];
    private List<LaserCannon> laserCannons = null;

    private float rotationFactor = 0f;

    private bool mainThrusterReady = true;
    private bool mainThrusterEngaged = false;
    private float thrusterInterval = .1f;
    private float thrusterCooldown = 0f;
    private float thrusterPower = 4f;
    private float boosterPower = 250f;

    private void Awake()
    {
        name = "PlayerShip";
        mainThruster.Toggle(false);
        foreach (Thruster sideThrust in sideThrusters)
            sideThrust.Toggle(false);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float deltaTime = Time.deltaTime;
        CheckThrusters(deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    public void AttachCannons(List<LaserCannon> cannons)
    {
        laserCannons = cannons;
        switch(cannons.Count)
        {
            case 1:
                laserCannons[0].transform.Translate(new Vector3(.25f, 0f, 0f));
                break;
            case 2:
                laserCannons[0].transform.Translate(new Vector3(0f, -0.25f, 0f));
                laserCannons[1].transform.Translate(new Vector3(0f, 0.25f, 0f));
                break;
            case 3:
                laserCannons[0].transform.Translate(new Vector3(.25f, 0f, 0f));
                laserCannons[1].transform.Translate(new Vector3(0f, -0.25f, 0f));
                laserCannons[2].transform.Translate(new Vector3(0f, 0.25f, 0f));
                break;
        }
    }

    public void CheckRotation(float deltaTime, float rotationFactor)
    {
        if (Mathf.Abs(rotationFactor) > 0.2f)
        {
            transform.Rotate(new Vector3(0f, 0f, rotationFactor * boosterPower * deltaTime));
        }
    }

    private void CheckThrusters(float deltaTime)
    {
        if (mainThrusterEngaged)
        {
            if (mainThrusterReady)
            {
                mainThrusterReady = false;
                shipBody.velocity += GetFacingVector() * thrusterPower;
            }
            else
            {
                thrusterCooldown += deltaTime;
                if (thrusterCooldown >= thrusterInterval)
                {
                    mainThrusterReady = true;
                    thrusterCooldown = 0f;
                }
            }
            mainThruster.Toggle(true);
        }
        else
        {
            mainThruster.Toggle(false);
        }

        if (rotationFactor > .2f)
        {
            sideThrusters[0].Toggle(false);
            sideThrusters[1].Toggle(true);
        }
        else if (rotationFactor < -.2f)
        {
            sideThrusters[0].Toggle(true);
            sideThrusters[1].Toggle(false);
        }
        else
        {
            sideThrusters[0].Toggle(false);
            sideThrusters[1].Toggle(false);
        }
    }

    private Vector2 GetFacingVector()
    {
        float thrustY = Mathf.Tan(transform.rotation.z * Mathf.Deg2Rad);
        float thrustX = 1f;
        return transform.TransformDirection(new Vector2(thrustX, thrustY)).normalized;
    }

    public void ToggleThrusters()
    {
        mainThrusterEngaged = !mainThrusterEngaged;
    }

    public void FireLasers(List<Laser> firedLasers)
    {
        for(int laser = 0; laser < firedLasers.Count; laser++)
        {
            Laser thisLaser = firedLasers[laser];
            thisLaser.transform.position = laserCannons[laser].transform.position;
            thisLaser.transform.rotation = transform.rotation;            
        }
    }
}