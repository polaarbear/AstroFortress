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
    [SerializeField] private GameObject[] shipTrackers = new GameObject[2];
    private Transform noseTransform;
    private Transform tailTransform;

    private GameControls gameControls;

    private float rotationFactor = 0f;
    private float rotationSpeed = 100f;

    private Vector3 velocity = Vector3.zero;
    private float maxVelocity = 40f;

    private bool thrustersReady = true;
    private bool thrustersEngaged = false;
    private float thrusterInterval = 0.1f;
    private float thrusterCooldown = 0f;
    private float thrusterPower = 1f;

    private void Awake()
    {
        noseTransform = shipTrackers[0].transform;
        tailTransform = shipTrackers[1].transform;
        gameControls = new GameControls();
        gameControls.InGameControls.ToggleThruster.performed += ctx => thrustersEngaged = !thrustersEngaged;
        gameControls.InGameControls.RotateShip.performed += ctx => rotationFactor = ctx.ReadValue<float>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        gameControls.InGameControls.Enable();
    }

    private void OnDisable()
    {
        gameControls.InGameControls.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaTime = Time.deltaTime;
        MoveShip(deltaTime);

        if(thrustersEngaged)
            Debug.Log(thrustersEngaged);
    }

    private void MoveShip(float deltaTime)
    {
        
        if (Mathf.Abs(rotationFactor) > 0.1f)
            transform.Rotate(new Vector3(0f, 0f, rotationFactor * rotationSpeed) * deltaTime);
        
        if(!thrustersReady)
        {
            thrusterCooldown += deltaTime;
            if(thrusterCooldown >= thrusterInterval)
            {
                thrustersReady = true;
                thrusterCooldown = 0f;
            }
        }
        else if(thrustersReady && thrustersEngaged)
        {
            thrustersReady = false;
            velocity += GetThrustVelocity() * thrusterPower;
            if (velocity.magnitude > maxVelocity)
                velocity = velocity.normalized * maxVelocity;
        }
        transform.Translate(velocity * deltaTime, Space.World);
    }

    private Vector3 GetThrustVelocity()
    {
        float thrustY = Mathf.Tan(transform.rotation.z * Mathf.Deg2Rad);
        float thrustX = 1f;
        return transform.TransformDirection(new Vector3(thrustX, thrustY, 0f));
    }
}