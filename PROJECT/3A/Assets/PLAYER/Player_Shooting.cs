using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shooting : MonoBehaviour
{
    private float playerLevelModifier;

    [HideInInspector]
    public int leftTimer = 0;
    [HideInInspector]
    public int rightTimer = 0;
    public int cannonFireInterval;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    public void Update()
    {
        if (PlayerPrefs.GetInt("crewLevel") == 0)
        {
            cannonFireInterval = 155;
        }
        else if (PlayerPrefs.GetInt("crewLevel") == 1)
        {
            cannonFireInterval = 120;
        }
        else if (PlayerPrefs.GetInt("crewLevel") == 2)
        {
            cannonFireInterval = 80;
        }

        leftTimer += 1;
        rightTimer += 1;


        if (Input.GetKey(KeyCode.E) && rightTimer >= cannonFireInterval)
        {
            fireCannons("right", PlayerPrefs.GetInt("cannonLevel"));
            
            rightTimer = 0;
        }
        if (Input.GetKey(KeyCode.Q) && leftTimer >= cannonFireInterval)
        {
            fireCannons("left", PlayerPrefs.GetInt("cannonLevel"));
            leftTimer = 0;
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
                SpawnCannon(-3.2f, -0.87f, 0, "left", 750f);
            }
            else if (cannonLevel == 1)
            {
                SpawnCannon(-3.2f, 1.78f, 0, "left", 750f);
                SpawnCannon(-3.2f, -1.78f, 0, "left", 750f);
            }
            else if (cannonLevel == 2)
            {
                SpawnCannon(-3.2f, 1.2f, 0, "left", 750f);
                SpawnCannon(-3.2f, -0.87f, 0, "left", 750f);
                SpawnCannon(-3.2f, -3.2f, 0, "left", 750f);
            }
            else if (cannonLevel == 3)
            {
                SpawnCannon(-3.2f, 3.56f, 0, "left", 750f);
                SpawnCannon(-3.2f, 1.78f, 0, "left", 750f);
                SpawnCannon(-3.2f, -1.78f, 0, "left", 750f);
                SpawnCannon(-3.2f, -3.56f, 0, "left", 750f);
            }

        }
        else if (direction == "right") // Make Speed Negative for Right
        {
            if (cannonLevel == 0)
            {
                SpawnCannon(3.2f, -0.87f, 0, "right", -750f);
            }
            else if (cannonLevel == 1)
            {
                SpawnCannon(3.2f, 1.13f, 0, "right", -750f);
                SpawnCannon(3.2f, -2.87f, 0, "right", -750f);
            }
            else if (cannonLevel == 2)
            {
                SpawnCannon(3.2f, 1.2f, 0, "right", -750f);
                SpawnCannon(3.2f, -0.87f, 0, "right", -750f);
                SpawnCannon(3.2f, -3.2f, 0, "right", -750f);
            }
            else if (cannonLevel == 3)
            {
                SpawnCannon(3.2f, 3.56f, 0, "right", -750f);
                SpawnCannon(3.2f, 1.78f, 0, "right", -750f);
                SpawnCannon(3.2f, -1.78f, 0, "right", -750f);
                SpawnCannon(3.2f, -3.56f, 0, "right", -750f);
            }
        }
    }
    void SpawnCannon(float xOffset, float yOffset, float zOffset, string direction, float speed)
    {
        PlayerPrefs.SetInt("timesShot", PlayerPrefs.GetInt("timesShot") + 1);

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
