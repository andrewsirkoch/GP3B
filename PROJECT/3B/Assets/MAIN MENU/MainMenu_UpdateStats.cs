using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu_UpdateStats : MonoBehaviour
{
    private float accuracy;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform child in transform)
        {
            if (child.gameObject.name == "treasure")
            {
                child.gameObject.GetComponent<Text>().text = PlayerPrefs.GetInt("treasureObtained").ToString();
            }
            else if (child.gameObject.name == "sunk")
            {
                child.gameObject.GetComponent<Text>().text = PlayerPrefs.GetInt("enemiesKilled").ToString();
            }
            else if (child.gameObject.name == "accuracy")
            {
                if (PlayerPrefs.GetInt("timesShot") == 0)
                {
                    accuracy = 0;
                    child.gameObject.GetComponent<Text>().text = accuracy.ToString() + "%";
                }
                else
                {
                    float timesHit = PlayerPrefs.GetInt("timesHit");
                    float timesShot = PlayerPrefs.GetInt("timesShot");
                    accuracy = 100 * (timesHit / timesShot);
                    int roundedAccuracy = (int) accuracy;
                    child.gameObject.GetComponent<Text>().text = roundedAccuracy.ToString() + "%";
                }
            }
        }

        
    }
}
