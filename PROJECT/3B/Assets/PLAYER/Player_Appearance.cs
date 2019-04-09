using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Appearance : MonoBehaviour
{
    private bool waitForMenuClose = false;

    // Start is called before the first frame update
    void Start()
    {
        UpdateAppearance();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player_MenuListener.storeOpen == true)
        {
            waitForMenuClose = true;
        }
        if (waitForMenuClose == true)
        {
            if(Player_MenuListener.storeOpen == false)
            {
                UpdateAppearance();
                waitForMenuClose = false;
            }
        }
    }

    public void UpdateAppearance()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(PlayerPrefs.GetFloat("shipColor_R"), PlayerPrefs.GetFloat("shipColor_G"), PlayerPrefs.GetFloat("shipColor_B"), 1.0f);
    }
}
