using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_reward : MonoBehaviour
{
    private int goldAmount;
    public bool bossReward = false;
    public bool superBossReward = false;

    // Start is called before the first frame update
    void Start()
    {
        if (bossReward == false && superBossReward == false)
        {
            goldAmount = Random.Range(25, 50);
        }
        else if (bossReward == true)
        {
            goldAmount = Random.Range(75, 105);
        }
        else if (superBossReward == true)
        {
            goldAmount = Random.Range(200, 300);
        }

        PlayerPrefs.SetInt("treasure", PlayerPrefs.GetInt("treasure") + goldAmount);
        PlayerPrefs.SetInt("treasureObtained", PlayerPrefs.GetInt("treasureObtained") + goldAmount);
        GetComponentInChildren<Text>().text = goldAmount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Image image in gameObject.GetComponentsInChildren<Image>())
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - 0.0075f);
            if (image.color.a <= 0.05f)
            {
                        Destroy(this.gameObject);
            }
        }
        foreach (Text text in gameObject.GetComponentsInChildren<Text>())
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - 0.0075f);
        }
    }
}
