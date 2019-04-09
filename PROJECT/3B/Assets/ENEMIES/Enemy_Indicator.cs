using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Indicator : MonoBehaviour
{
    GameObject player;
    SpriteRenderer image;
    SpriteRenderer boat;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponentInChildren<SpriteRenderer>();
        boat = GetComponentInParent<SpriteRenderer>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distance = Mathf.Sqrt(Mathf.Pow(transform.position.x - player.transform.position.x, 2) + Mathf.Pow(transform.position.y - player.transform.position.y, 2));
        Vector3 direction = (player.transform.position - transform.position).normalized;

        if (boat.isVisible)
        {
            image.enabled = false;
        }
        else
        {
            EnableIndicator();
        }
        

        Debug.DrawRay(transform.position, direction * distance, Color.green, 0.01f, true);
    }
    void EnableIndicator()
    {
        image.enabled = true;
        if (distance <= 80)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1.0f);
        }
        else if (distance > 80 && distance < 300)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, (distance * -(1f/275f)) + (71f/55f));
        }
        else if (distance >= 300)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0.2f);
        }

        image.gameObject.transform.rotation = Quaternion.LookRotation(-Vector3.forward, (player.transform.position - transform.position).normalized);
        image.gameObject.transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Mathf.Abs(distance) - 30);
    }
}
