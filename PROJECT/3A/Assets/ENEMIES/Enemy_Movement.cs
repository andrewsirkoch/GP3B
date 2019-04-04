using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    public bool forward;
    public bool turnLeft;
    public bool turnRight;
    [HideInInspector]
    public float maxSpeed = 0.1f;
    [HideInInspector]
    public float speed = 0.001f;
    [HideInInspector]
    public float forwardSpeed = 0.0000000000001f;
    private float startingSpeed = 0.0000000000001f;
    [Space]
    public float maxRotateSpeed = 0.3f;
    [HideInInspector]
    public float rotateSpeed = 0.01f;
    [HideInInspector]
    public float rotationSpeed = 0.01f;
    [HideInInspector]
    public float startingRotationSpeed = 0.01f;
    private bool wakeOn = false;
    private bool particlesStarted = false;

    [Space]
    public GameObject WakeLeft;
    public GameObject WakeRight;
    public GameObject Trail;

    private void Start()
    {
        maxRotateSpeed = Random.Range(0.05f, 0.6f);
        maxRotateSpeed = Random.Range(0.05f, 0.6f);
        int decision = Random.Range(0, 2);
        
        if (decision == 0)
        {
            turnLeft = true;
        }
        else if (decision == 1)
        {
            turnRight = true;
        }
        
    }
    // Start is called before the first frame update
    void FixedUpdate()
    {
        //////////////[]
        ///
        /// MOVEMENT
        /// 
        //////////////[]
        
        if (forward == true)
        {
            if (particlesStarted == false)
            {
                Trail.GetComponent<ParticleSystem>().Play();
                particlesStarted = true;
            }

            transform.position += transform.right * forwardSpeed;
            if (forwardSpeed + speed <= maxSpeed) forwardSpeed += speed;
            if (forwardSpeed + speed >= 0.1f && wakeOn == false)
            {
                WakeLeft.GetComponent<ParticleSystem>().Play();
                WakeRight.GetComponent<ParticleSystem>().Play();
                wakeOn = true;
            }
        }
        else if (forward == false)
        {
            transform.position += transform.right * forwardSpeed;

            if (forwardSpeed <= startingSpeed)
            {
                particlesStarted = false;
                wakeOn = false;
                forwardSpeed = startingSpeed;
            }
            if (forwardSpeed != startingSpeed)
            {
                forwardSpeed -= speed;
            }

        }

        //////////////[]
        ///
        /// ROTATION
        /// 
        //////////////[]

        if ((turnRight || turnLeft) && rotationSpeed + rotateSpeed < maxRotateSpeed && forwardSpeed > startingSpeed) // Increase rotation speed until max rotation speed met
        {
            rotationSpeed += rotateSpeed;
        }
        if (forwardSpeed > startingSpeed && turnRight) // Rotate Right if key held & moving fast enough
        {
            transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z - rotationSpeed);
        }
        if (forwardSpeed > startingSpeed && turnLeft) // Rotate Left if key held & moving fast enough
        {
            transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z + rotationSpeed);
        }
        else if (!turnLeft && !turnRight) // Set rotation back to beginning when not holding either keys
        {
            rotationSpeed = startingRotationSpeed;
        }
        if (turnLeft && forwardSpeed == startingSpeed) // Rotate slowly when not moving
        {
            transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z + 0.1f);
        }
        if (turnRight && forwardSpeed == startingSpeed) // Rotate slowly when not moving
        {
            transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z - 0.1f);
        }
    }
}