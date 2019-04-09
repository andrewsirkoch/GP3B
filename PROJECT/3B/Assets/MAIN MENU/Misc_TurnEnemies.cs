using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Misc_TurnEnemies : MonoBehaviour
{
    private int timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Enemy_Movement controller in gameObject.GetComponentsInChildren<Enemy_Movement>())
        {
            controller.maxRotateSpeed = 0.2f;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += 1;
        if (timer >= 100)
        {
            foreach (Enemy_Movement controller in gameObject.GetComponentsInChildren<Enemy_Movement>())
            {
                controller.maxRotateSpeed = 0.2f;
                if (controller.gameObject.name == "left")
                {
                    controller.turnRight = false;
                }
                else if (controller.gameObject.name == "right")
                {
                    controller.turnLeft = false;
                }
            }
        }
        if ( timer >= 200 )
        {
            SceneManager.LoadScene(1);
        }
        
    }
}
