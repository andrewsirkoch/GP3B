using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_UpdateColor : MonoBehaviour
{
    public Image image_R;
    // Start is called before the first frame update
    void Start()
    {
        image_R.GetComponent<Image>().color = new Color(PlayerPrefs.GetFloat("shipColor_R"), PlayerPrefs.GetFloat("shipColor_G"), PlayerPrefs.GetFloat("shipColor_B"), 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        image_R.GetComponent<Image>().color = new Color(PlayerPrefs.GetFloat("shipColor_R"), PlayerPrefs.GetFloat("shipColor_G"), PlayerPrefs.GetFloat("shipColor_B"), 1.0f);
    }
}
