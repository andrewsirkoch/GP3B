using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_UpdateMoney : MonoBehaviour
{
    private Text text;
    private Image image;

    public Sprite coins1;
    public Sprite coins2;
    public Sprite coins3;
    public Sprite coins4;
    public Sprite coins5;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<Text>();
        image = GetComponentInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = PlayerPrefs.GetInt("treasure").ToString();
        if (PlayerPrefs.GetInt("treasure") <= 33) image.sprite = coins1;
        else if (PlayerPrefs.GetInt("treasure") > 33 && PlayerPrefs.GetInt("treasure") <= 66 ) image.sprite = coins2;
        else if (PlayerPrefs.GetInt("treasure") > 66 && PlayerPrefs.GetInt("treasure") <= 99) image.sprite = coins3;
        else if (PlayerPrefs.GetInt("treasure") > 99 && PlayerPrefs.GetInt("treasure") <= 150) image.sprite = coins4;
        else if (PlayerPrefs.GetInt("treasure") >= 150) image.sprite = coins5;

    }
}
