using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_HealthBar : MonoBehaviour
{
    public GameObject backGround;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponentInParent<Enemy_Info>().health < gameObject.GetComponentInParent<Enemy_Info>().maxHealth)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            backGround.GetComponent<SpriteRenderer>().enabled = true;
            if (transform.localScale.x >= 0 && gameObject.GetComponentInParent<Enemy_Info>().health * (2f / gameObject.GetComponentInParent<Enemy_Info>().maxHealth) >= 0.0f)
            {
                transform.localScale = new Vector3(gameObject.GetComponentInParent<Enemy_Info>().health * (2f / gameObject.GetComponentInParent<Enemy_Info>().maxHealth), transform.localScale.y, transform.localScale.z);
            }
            
        }
    }
}
