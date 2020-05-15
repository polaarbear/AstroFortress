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
    private GameControls gameControls;
    [SerializeField] private Rigidbody2D shipBody = null;

    private float rotationFactor = 0f;

    private bool thrustersReady = true;
    private bool thrustersEngaged = false;
    private float thrusterInterval = .125f;
    private float thrusterCooldown = 0f;
    private float thrusterPower = 1f;
    private float boosterPower = 250f;

    private void Awake()
    {
        gameControls = new GameControls();
        gameControls.InGameControls.ToggleThruster.performed += toggleThruster => thrustersEngaged = !thrustersEngaged;
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
        CheckRotation(deltaTime);
        CheckThrusters(deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void CheckRotation(float deltaTime)
    {
        rotationFactor = gameControls.InGameControls.RotateShip.ReadValue<float>();
        if (Mathf.Abs(rotationFactor) > 0.2f)
            shipBody.AddTorque(rotationFactor * boosterPower * Time.deltaTime);
    }

    private void CheckThrusters(float deltaTime)
    {
        if (thrustersEngaged)
        {
            if (thrustersReady)
            {
                thrustersReady = false;
                shipBody.velocity += GetThrustVector() * thrusterPower;
            }
            else
            {
                thrusterCooldown += deltaTime;
                if (thrusterCooldown >= thrusterInterval)
                {
                    thrustersReady = true;
                    thrusterCooldown = 0f;
                }
            }
        }
    }

    private Vector2 GetThrustVector()
    {
        float thrustY = Mathf.Tan(transform.rotation.z * Mathf.Deg2Rad);
        float thrustX = 1f;
        return transform.TransformDirection(new Vector2(thrustX, thrustY)).normalized;
    }
}