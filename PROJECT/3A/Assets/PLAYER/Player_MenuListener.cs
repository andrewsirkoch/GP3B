using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_MenuListener : MonoBehaviour
{
    private Object shipStore;
    public GameObject restartButton;
    private GameObject player;
    public static bool storeOpen = false;

    // Start is called before the first frame update
    void Awake()
    {
        shipStore = Resources.Load("UI/Canvas_ShipStore");
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab) && storeOpen == true)
        {
            Destroy(GameObject.Find("Canvas_ShipStore(Clone)"));
            storeOpen = false;
        }

        else if (Input.GetKeyUp(KeyCode.Tab) && storeOpen == false)
        {
            Instantiate(shipStore);
            storeOpen = true;
        }
        
        if (player.GetComponent<Player_Info>().health <= 0)
        {
            restartButton.SetActive(true);
        }
        else if (player.GetComponent<Player_Info>().health > 0)
        {
            restartButton.SetActive(false);
        }


    }
}
