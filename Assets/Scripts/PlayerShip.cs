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
    private float rotationSpeed = 120f;

    private Vector3 velocity = Vector3.zero;
    private float maxVelocity = 25f;
    private float velocityDecayRate = 0.998750f;

    private bool thrustersReady = true;
    private bool thrustersEngaged = false;
    private float thrusterInterval = 0.1f;
    private float thrusterCooldown = 0f;
    private float thrusterPower = 1f;

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
        transform.Translate(velocity * deltaTime, Space.World);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BounceBack();
    }

    private void CheckRotation(float deltaTime)
    {
        rotationFactor = gameControls.InGameControls.RotateShip.ReadValue<float>();
        if (Mathf.Abs(rotationFactor) > 0.2f)
            transform.Rotate(new Vector3(0f, 0f, rotationFactor * rotationSpeed) * deltaTime);    
    }

    private void CheckThrusters(float deltaTime)
    {
        if (thrustersEngaged)
        {
            if (thrustersReady)
            {
                thrustersReady = false;
                velocity += GetThrustVector() * thrusterPower;
                if (velocity.magnitude > maxVelocity)
                    velocity = velocity.normalized * maxVelocity;
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
        else
        {
            if (velocity.magnitude > 0.25f)
                velocity = (velocity.magnitude * velocityDecayRate) * velocity.normalized;
            else
                velocity = Vector3.zero;
        }
    }

    private Vector3 GetThrustVector()
    {
        float thrustY = Mathf.Tan(transform.rotation.z * Mathf.Deg2Rad);
        float thrustX = 1f;
        return transform.TransformDirection(new Vector3(thrustX, thrustY, 0f)).normalized;
    }

    private void BounceBack()
    {
        transform.Translate(-velocity.normalized * .1f);
        velocity *= -0.33f;        
    }
}