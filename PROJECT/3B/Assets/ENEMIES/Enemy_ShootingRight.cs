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

        if (gameObject.GetComponent<Enemy_Shooting>().boss == true)
        {
            cannonLevel = 5;
        }
        else if (gameObject.GetComponent<Enemy_Shooting>().superBoss == true)
        {
            cannonLevel = 6;
        }

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
            gameObject.GetComponent<Enemy_Shooting>().fireCannons("right", cannonLevel);
            timer = 0;
        }

        playerLevelModifier = ((PlayerPrefs.GetInt("cannonLevel") + 1) * 0.25f) + 1;
    }
}
