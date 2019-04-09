using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_flash : MonoBehaviour
{
    public float speed;
    private bool startFlash = false;
    private bool started = false;
    private bool goingUp = false;
    private bool goingDown = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Image image = gameObject.GetComponent<Image>();
        Text text = gameObject.GetComponentInChildren<Text>();

        if (startFlash == true && started == false)
        {
            started = true;
            
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
            text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
            image.enabled = true;
            text.enabled = true;
            goingUp = true;
        }
        if (started == true && goingUp == true)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a + speed);
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + speed);
            if (text.color.a >= 0.95f)
            {
                goingUp = false;
                goingDown = true;
            }
        }
        if (started == true && goingDown == true)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - speed);
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - speed);
            if (text.color.a <= 0.05f)
            {
                started = false;
                startFlash = false;
                goingDown = false;
                text.enabled = false;
                image.enabled = false;
            }
        }
    }

    public void StartFlash()
    {
        startFlash = true;
    }
}
