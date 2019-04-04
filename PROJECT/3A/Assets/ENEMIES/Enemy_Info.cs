using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Info : MonoBehaviour
{
    
    
    public int maxHealth;
    [HideInInspector]
    public float health;
    private Camera cam;
    private GameObject hud;
    private bool rewardSpawned = false;
    public static int enemyNumber = 0;
    private bool statInc = false;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        cam = GameObject.Find("Player_Camera").GetComponent<Camera>();
        hud = GameObject.Find("HUD");
        enemyNumber += 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            GetComponentInChildren<Enemy_Shooting>().enabled = false;
            GetComponentInChildren<Enemy_ShootingRight>().enabled = false;
            if (rewardSpawned == false)
            {
                GameObject goldReward;
                goldReward = Instantiate(Resources.Load("UI/reward"), cam.WorldToScreenPoint(transform.position), hud.transform.rotation) as GameObject;
                goldReward.transform.SetParent(hud.transform);

                rewardSpawned = true;
            }
            
            foreach (CapsuleCollider2D collider in GetComponentsInChildren<CapsuleCollider2D>())
            {
                collider.enabled = false;
            }

            foreach (ParticleSystem particles in GetComponentsInChildren<ParticleSystem>())
            {
                particles.Stop();
            }
            
            foreach (SpriteRenderer sprite in gameObject.GetComponentsInChildren<SpriteRenderer>())
            {
                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, sprite.color.a - 0.0075f);
                if (sprite.color.a <= 0.05f)
                {
                    if (statInc == false)
                    {
                        statInc = true;
                        PlayerPrefs.SetInt("enemiesKilled", PlayerPrefs.GetInt("enemiesKilled") + 1);
                    }
                    Destroy(this.gameObject);
                }
            }
        }
    }
    private void OnDestroy()
    {
        enemyNumber -= 1;
    }
}
