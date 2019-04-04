using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_DisplayRepair : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        GetComponentInChildren<Text>().text = PlayerPrefs.GetInt("repairKits").ToString();
    }
}
