using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_reward : MonoBehaviour
{
    private int goldAmount;

    // Start is called before the first frame update
    void Start()
    {
        goldAmount = Random.Range(1, 25);
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
