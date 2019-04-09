using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_SwivelShot : MonoBehaviour
{
    public bool readyToShoot = false;
    public Texture2D cursor;

    private bool startTimer;
    private int timer;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("swivelShots", 2);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0) && readyToShoot == true)
        {
            startTimer = true;
        }
        if (startTimer == true)
        {
            timer += 1;
            if (timer % 10 == 1) FireSwivelShot();
            else if (timer % 20 == 1) FireSwivelShot();
            else if (timer % 30 == 1) FireSwivelShot();
            else if (timer > 30)
            {
                timer = 0;
                PlayerPrefs.SetInt("swivelShots", PlayerPrefs.GetInt("swivelShots") - 1);
                startTimer = false;
            }
        }
    }

    public void EnableSwivelShot()
    {
        if (PlayerPrefs.GetInt("swivelShots") > 0)
        {
            Cursor.SetCursor(cursor, new Vector2(-10, -10), CursorMode.Auto);
            readyToShoot = true;
        }
        else
        {
            //nothing
        }
    }

    public void DisableSwivelShot()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        readyToShoot = false;
    }

    public void FireSwivelShot()
    {
        GameObject.Find("CannonFire").GetComponent<Cannon_PickSound>().playSound();

        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float distance = Mathf.Sqrt(Mathf.Pow(transform.position.x - mousePos.x, 2) + Mathf.Pow(transform.position.y - mousePos.y, 2));
        Vector3 direction = (transform.position - mousePos).normalized;

        PlayerPrefs.SetInt("timesShot", PlayerPrefs.GetInt("timesShot") + 1);
        

        // Center Cannon

        GameObject Cannon;
        Cannon = Instantiate(Resources.Load("cannonball"), transform, false) as GameObject;
        Cannon.transform.position = Vector2.MoveTowards(transform.position, mousePos, 6);
        Cannon_DestroyParticle cannonSmoke = Cannon.GetComponentInChildren<Cannon_DestroyParticle>();
        cannonSmoke.gameObject.transform.localPosition = new Vector3(cannonSmoke.transform.localPosition.x, cannonSmoke.transform.localPosition.y + 5, 1);
        
        Cannon.transform.rotation = Quaternion.LookRotation(-Vector3.forward, new Vector3(direction.x, direction.y, 0));
        cannonSmoke.gameObject.transform.localEulerAngles = new Vector3(cannonSmoke.transform.localEulerAngles.x + 90, cannonSmoke.transform.localEulerAngles.y, cannonSmoke.transform.localEulerAngles.z + 90);
        Cannon.GetComponent<Rigidbody2D>().AddForce(-direction.normalized * 1500);

        readyToShoot = false;
        DisableSwivelShot();
    }
}
