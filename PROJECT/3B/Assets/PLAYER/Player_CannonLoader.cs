using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_CannonLoader : MonoBehaviour
{
    public bool leftLoader;
    public bool rightLoader;

    public GameObject leftBG;
    public GameObject rightBG;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(rightLoader)
        {
            if (gameObject.GetComponentInParent<Player_Shooting>().rightTimer < gameObject.GetComponentInParent<Player_Shooting>().cannonFireInterval)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
                rightBG.GetComponent<SpriteRenderer>().enabled = true;
                if (transform.localScale.x <= 2)
                {
                    transform.localScale = new Vector3(gameObject.GetComponentInParent<Player_Shooting>().rightTimer * (2f / gameObject.GetComponentInParent<Player_Shooting>().cannonFireInterval), transform.localScale.y, transform.localScale.z);
                }

            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                rightBG.GetComponent<SpriteRenderer>().enabled = false;
            }
        }

        if (leftLoader)
        {
            if (gameObject.GetComponentInParent<Player_Shooting>().leftTimer < gameObject.GetComponentInParent<Player_Shooting>().cannonFireInterval)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
                leftBG.GetComponent<SpriteRenderer>().enabled = true;
                if (transform.localScale.x <= 2)
                {
                    transform.localScale = new Vector3(gameObject.GetComponentInParent<Player_Shooting>().leftTimer * (2f / gameObject.GetComponentInParent<Player_Shooting>().cannonFireInterval), transform.localScale.y, transform.localScale.z);
                }

            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                leftBG.GetComponent<SpriteRenderer>().enabled = false;
            }
        }

    }
}
