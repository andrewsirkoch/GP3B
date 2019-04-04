using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon_Ball : MonoBehaviour
{
    private bool hitWater = false;
    // Start is called before the first frame update
    void Start()
    {
        transform.parent = null;
        Invoke("DestroySelfWater", Random.Range(1.8f,2.2f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DestroySelfWater()
    {
        hitWater = true;
        foreach(Transform child in transform)
        {
            if (child.gameObject.name == "cannonTrail")
            {
                child.parent = null;
            }
        }
        Destroy(gameObject);
    }
    void DestroySelfShip()
    { }

    private void OnDestroy()
    {
        if (hitWater == true)
        {
            Instantiate(Resources.Load("cannonPlunge"), transform.position, transform.rotation);
            GameObject.Find("CannonSplash").GetComponent<Cannon_PickSound>().playSound();
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            PlayerPrefs.SetInt("timesHit", PlayerPrefs.GetInt("timesHit") + 1);

            GameObject.Find("CannonHit").GetComponent<Cannon_PickSound>().playSound();
            foreach (Transform child in transform)
            {
                child.parent = null;
            }

            collision.gameObject.GetComponentInParent<Enemy_Info>().health -= 10;
            
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            GameObject.Find("CannonHit").GetComponent<Cannon_PickSound>().playSound();
            foreach (Transform child in transform)
            {
                child.parent = null;
            }
            if (collision.gameObject.GetComponentInParent<Player_Info>().health != 0)
            {
                collision.gameObject.GetComponentInParent<Player_Info>().health -= 10 / (PlayerPrefs.GetInt("hullLevel") + 1);
            }
            

            Destroy(this.gameObject);
        }
    }
}
