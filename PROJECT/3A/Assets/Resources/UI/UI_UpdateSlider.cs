using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_UpdateSlider : MonoBehaviour
{
    private GameObject redSlider;
    private GameObject blueSlider;
    private GameObject greenSlider;

    // Start is called before the first frame update
    void Start()
    {
        redSlider = GameObject.Find("RedSlider");
        greenSlider = GameObject.Find("GreenSlider");
        blueSlider = GameObject.Find("BlueSlider");

        redSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("shipColor_R");
        blueSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("shipColor_B");
        greenSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("shipColor_G");

    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("shipColor_R", redSlider.GetComponent<Slider>().value);
        PlayerPrefs.SetFloat("shipColor_G", greenSlider.GetComponent<Slider>().value);
        PlayerPrefs.SetFloat("shipColor_B", blueSlider.GetComponent<Slider>().value);
    }
}
