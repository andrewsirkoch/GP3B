using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Behaviour : MonoBehaviour
{
    public float maxSpeed;
    public float speed;
    public float forwardSpeed = 0.0000000000001f;
    private float startingSpeed = 0.0000000000001f;
    public float maxRotateSpeed;
    public float rotateSpeed;
    public float rotationSpeed = 0.01f;
    public float startingRotationSpeed = 0.01f;
    private bool holdingDown = false;
    private int timer;
    public bool moving = false;

    public bool wakeOn = false;
    public bool atMaxSpeed;
    public GameObject Particles;
    public GameObject WakeLeft;
    public GameObject WakeRight;

    // Start is called before the first frame update
    void Start()
    {
        Particles = GameObject.Find("BoatParticles");
        WakeLeft = GameObject.Find("BoatWakeLeft");
        WakeRight = GameObject.Find("BoatWakeRight");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            moving = true;
            if (holdingDown == false)
            {
                Particles.GetComponent<ParticleSystem>().Play();
                holdingDown = true;
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
        else if (!Input.GetKey(KeyCode.W))
        {
            holdingDown = false;
            transform.position += transform.right * forwardSpeed;

            if (forwardSpeed <= startingSpeed)
            {
                Particles.GetComponent<ParticleSystem>().Stop();
                WakeLeft.GetComponent<ParticleSystem>().Stop();
                WakeRight.GetComponent<ParticleSystem>().Stop();
                wakeOn = false;
                moving = false;
                forwardSpeed = startingSpeed;
            }
            if (forwardSpeed != startingSpeed)
            {
                forwardSpeed -= speed;
            }

        }

        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)) && rotationSpeed + rotateSpeed < maxRotateSpeed && forwardSpeed > startingSpeed) // Increase rotation speed until max rotation speed met
        {
            rotationSpeed += rotateSpeed;
        }
        if (forwardSpeed > startingSpeed && Input.GetKey(KeyCode.D)) // Rotate Right if key held & moving fast enough
        {
            transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z - rotationSpeed);
        }
        if (forwardSpeed > startingSpeed && Input.GetKey(KeyCode.A)) // Rotate Left if key held & moving fast enough
        {
            transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z + rotationSpeed);
        }
        else if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) // Set rotation back to beginning when not holding either keys
        {
            rotationSpeed = startingRotationSpeed;
        }
        if ((Input.GetKey(KeyCode.A) && forwardSpeed == startingSpeed)) // Rotate slowly when not moving
        {
            transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z + 0.1f);
        }
        if ((Input.GetKey(KeyCode.D) && forwardSpeed == startingSpeed)) // Rotate slowly when not moving
        {
            transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z - 0.1f);
        }

        if (PlayerPrefs.GetInt("sailLevel") == 0)
        {
            maxSpeed = 0.133f;
            maxRotateSpeed = 0.5f;
        }
        else if (PlayerPrefs.GetInt("sailLevel") == 1)
        {
            maxSpeed = 0.144f;
            maxRotateSpeed = 0.6f;
        }
        else if (PlayerPrefs.GetInt("sailLevel") == 2)
        {
            maxSpeed = 0.155f;
            maxRotateSpeed = 0.7f;
        }
        else if (PlayerPrefs.GetInt("sailLevel") == 3)
        {
            maxSpeed = 0.166f;
            maxRotateSpeed = 0.8f;
        }
        else if (PlayerPrefs.GetInt("sailLevel") == 4)
        {
            maxSpeed = 0.177f;
            maxRotateSpeed = 0.9f;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) timer = 0;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            timer += 1;

            if ( timer % 2 == 0)
            {
                GetComponentInParent<Player_Info>().health -= 1;
                collision.gameObject.GetComponentInParent<Enemy_Info>().health -= 1;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy")) timer = 0;
    }
}
