using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_RepairKits : MonoBehaviour
{
    private int timer;
    public int healAmount;
    private bool soundStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.R))
        {
            if (gameObject.GetComponentInParent<Player_Behaviour>().moving == false && PlayerPrefs.GetInt("repairKits") >= 1 && GetComponentInParent<Player_Info>().health < 100)
            {
                timer += 1;
                if (soundStarted == false)
                {
                    GameObject.Find("Repair").GetComponent<AudioSource>().Play();
                    soundStarted = true;
                }
                GameObject.Find("repairBar").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("repairBarBG").GetComponent<SpriteRenderer>().enabled = true;
                if (GameObject.Find("repairBar").transform.localScale.x <= 2)
                {
                    float modifier = 1;
                    if (PlayerPrefs.GetInt("crewLevel") == 0) modifier = 300f;
                    else if (PlayerPrefs.GetInt("crewLevel") == 1) modifier = 250f;
                    else if (PlayerPrefs.GetInt("crewLevel") == 2) modifier = 200f;
                    GameObject.Find("repairBar").transform.localScale = new Vector3(timer * (2f / modifier), transform.localScale.y, transform.localScale.z);
                }
                else
                {
                    GameObject.Find("repairBar").GetComponent<SpriteRenderer>().enabled = false;
                    GameObject.Find("repairBarBG").GetComponent<SpriteRenderer>().enabled = false;
                    GameObject.Find("repairBar").transform.localScale = new Vector3(0f, transform.localScale.y, transform.localScale.z);
                    timer = 0;

                    HealPlayer();
                    PlayerPrefs.SetInt("repairKits", PlayerPrefs.GetInt("repairKits") - 1);

                   
                }
            }
        }
        if (!Input.GetKey(KeyCode.R))
        {
            if (soundStarted == true)
            {
                GameObject.Find("Repair").GetComponent<AudioSource>().Stop();
                soundStarted = false;
            }
            GameObject.Find("repairBar").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("repairBarBG").GetComponent<SpriteRenderer>().enabled = false;
            timer = 0;
        }
        if (gameObject.GetComponentInParent<Player_Behaviour>().moving == true)
        {
            if (soundStarted == true)
            {
                GameObject.Find("Repair").GetComponent<AudioSource>().Stop();
                soundStarted = false;
            }
            GameObject.Find("repairBar").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("repairBarBG").GetComponent<SpriteRenderer>().enabled = false;
            timer = 0;
        }
    }

    void HealPlayer()
    {
        if (GetComponentInParent<Player_Info>().health + healAmount > 100)
        {
            GetComponentInParent<Player_Info>().health = 100;
        }
        else
        {
            GetComponentInParent<Player_Info>().health += healAmount;
        }
        
    }
}
