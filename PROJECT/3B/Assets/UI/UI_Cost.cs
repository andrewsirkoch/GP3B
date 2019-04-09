using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Cost : MonoBehaviour
{
    public static int cost = 0;
    public GameObject purchaseButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Text>().text = cost.ToString();
        if (cost > 0)
        {
            purchaseButton.SetActive(true);
        }
        else
        {
            purchaseButton.SetActive(false);
        }
    }
}
