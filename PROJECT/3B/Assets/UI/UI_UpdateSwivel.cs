using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_UpdateSwivel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool hovering = false;
    public bool shotDisabled = false;
    public bool buttonEnabled = false;
    private GameObject player;
    private Player_SwivelShot swivelShot;
    private Toggle toggle;

    private void Start()
    {
        player = GameObject.Find("Player");
        swivelShot = player.GetComponent<Player_SwivelShot>();
        toggle = gameObject.GetComponent<Toggle>();
    }
    // Start is called before the first frame update
    void Update()
    {
        if (buttonEnabled == false && toggle.isOn == true)
        {
            buttonEnabled = true;
            swivelShot.EnableSwivelShot();
        }
        if (buttonEnabled == true && toggle.isOn == false)
        {
            buttonEnabled = false;
            swivelShot.DisableSwivelShot();
        }
        if (swivelShot.readyToShoot == false && toggle.isOn == true && shotDisabled == false)
        {
            toggle.isOn = false;
            buttonEnabled = false;
        }
        if (toggle.isOn == false)
        {
            swivelShot.DisableSwivelShot();
        }
        GetComponentInChildren<Text>().text = PlayerPrefs.GetInt("swivelShots").ToString();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hovering = true;
        if (shotDisabled == false && swivelShot.readyToShoot == true)
        {
            swivelShot.DisableSwivelShot();
            shotDisabled = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hovering = false;
        if (shotDisabled == true && toggle.interactable == true)
        {
            swivelShot.EnableSwivelShot();
            shotDisabled = false;
        }
    }
}
