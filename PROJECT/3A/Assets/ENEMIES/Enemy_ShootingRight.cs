using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_ShootingRight : MonoBehaviour
{
    [HideInInspector]
    public int cannonFireInterval;
    private int timer = 0;
    public static bool drawRays = true;
    [HideInInspector]
    public float cannonOffsetX;
    private int cannonLevel;

    private float playerLevelModifier;
    /// <summary>
    /// This file exists because I had trouble checking for two rays in one update function. 
    /// It seemed the one ray would trump the other ray and not let it check anything.
    /// </summary>

    // Update is called once per frame

    public void Start()
    {
        cannonOffsetX = gameObject.GetComponent<Enemy_Shooting>().cannonOffsetX;
        cannonFireInterval = gameObject.GetComponent<Enemy_Shooting>().cannonFireInterval;
        cannonLevel = gameObject.GetComponent<Enemy_Shooting>().cannonLevel;

    }
    void FixedUpdate()
    {
        timer += 1;
        if (drawRays == true)
        {
            Debug.DrawRay(transform.position, transform.up * -30, Color.green, 0.01f, true);
        }
        RaycastHit2D rightHit = Physics2D.Raycast(transform.position, transform.up * -1, 40);

        if (rightHit.collider != null && rightHit.collider.gameObject.CompareTag("Player") && timer >= cannonFireInterval)
        {
            fireCannons("right", cannonLevel);
            timer = 0;
        }

        playerLevelModifier = ((PlayerPrefs.GetInt("cannonLevel") + 1) * 0.25f) + 1;
    }

    void fireCannons(string direction, int cannonLevel)
    {
        GameObject.Find("CannonFire").GetComponent<Cannon_PickSound>().playSound();
        if (direction == "left")
        {
            if (cannonLevel == 0)
            {
                SpawnCannon(-cannonOffsetX, -0.87f, 0, "left", 750f);
            }
            else if (cannonLevel == 1)
            {
                SpawnCannon(-cannonOffsetX, 1.78f, 0, "left", 750f);
                SpawnCannon(-cannonOffsetX, -1.78f, 0, "left", 750f);
            }
            else if (cannonLevel == 2)
            {
                SpawnCannon(-cannonOffsetX, 1.2f, 0, "left", 750f);
                SpawnCannon(-cannonOffsetX, -0.87f, 0, "left", 750f);
                SpawnCannon(-cannonOffsetX, -3.2f, 0, "left", 750f);
            }
        }
        else if (direction == "right") // Make Speed Negative for Right
        {
            if (cannonLevel == 0)
            {
                SpawnCannon(cannonOffsetX, -0.87f, 0, "right", -750f);
            }
            else if (cannonLevel == 1)
            {
                SpawnCannon(cannonOffsetX, 1.13f, 0, "right", -750f);
                SpawnCannon(cannonOffsetX, -2.87f, 0, "right", -750f);
            }
            else if (cannonLevel == 2)
            {
                SpawnCannon(cannonOffsetX, 1.2f, 0, "right", -750f);
                SpawnCannon(cannonOffsetX, -0.87f, 0, "right", -750f);
                SpawnCannon(cannonOffsetX, -3.2f, 0, "right", -750f);
            }
        }
    }
    void SpawnCannon(float xOffset, float yOffset, float zOffset, string direction, float speed)
    {
        GameObject Cannon;
        Cannon = Instantiate(Resources.Load("cannonball"), transform, false) as GameObject;

        Cannon.transform.position = Cannon.transform.TransformPoint(new Vector3(transform.localPosition.x + xOffset, transform.localPosition.y + yOffset, transform.localPosition.z + zOffset));
        if (direction == "left")
        {
            Cannon.transform.localEulerAngles = new Vector3(0, 0, 90);
        }
        Cannon.GetComponent<Rigidbody2D>().AddForce(transform.up * (speed * playerLevelModifier));
    }
}
