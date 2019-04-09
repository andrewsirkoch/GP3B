using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_SetToOrigin : MonoBehaviour
{
    public bool gameScene = false;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Player").transform.position = new Vector3(0, 0, 0);
        if (gameScene == true)
        {
            GameObject.Find("Player").GetComponent<Player_Info>().Control(true);
        }
        else
        {
            GameObject.Find("Player").GetComponent<Player_Info>().Control(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateAppearance()
    {
        GameObject.Find("Player").GetComponentInChildren<Player_Appearance>().UpdateAppearance();
    }
}
