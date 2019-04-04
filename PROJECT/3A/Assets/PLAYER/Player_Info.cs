using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Info : MonoBehaviour
{
    ////////////////////////
    /// 
    /// A class containing player information.
    /// Health, Treasure, and Upgrades are all examples of information
    /// that will be stored within this file.
    /// 
    ////////////////////////
    
    [Range(0,100)]
    public int health = 100;

    public static bool ended = false;

    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        // --------------------------------------O
        // ----- PLAYER PREFS INITIALIZATION >>> |
        // --------------------------------------O

        if (!PlayerPrefs.HasKey("treasure")) PlayerPrefs.SetInt("treasure", 0);
        if (!PlayerPrefs.HasKey("cannonLevel")) PlayerPrefs.SetInt("cannonLevel", 0);
        if (!PlayerPrefs.HasKey("sailLevel")) PlayerPrefs.SetInt("sailLevel", 0);
        if (!PlayerPrefs.HasKey("hullLevel")) PlayerPrefs.SetInt("hullLevel", 0);
        if (!PlayerPrefs.HasKey("crewLevel")) PlayerPrefs.SetInt("crewLevel", 0);
        if (!PlayerPrefs.HasKey("repairKits")) PlayerPrefs.SetInt("repairKits", 0);
        if (!PlayerPrefs.HasKey("difficulty")) PlayerPrefs.SetInt("difficulty", 1);
        if (!PlayerPrefs.HasKey("shipColor_R")) PlayerPrefs.SetFloat("shipColor_R", 0.47f); // Default Red Value
        if (!PlayerPrefs.HasKey("shipColor_G")) PlayerPrefs.SetFloat("shipColor_G", 0.36f); // Default Green Value
        if (!PlayerPrefs.HasKey("shipColor_B")) PlayerPrefs.SetFloat("shipColor_B", 0.22f); // Default Blue Value
        if (!PlayerPrefs.HasKey("volume_music")) PlayerPrefs.SetFloat("volume_music", 1f);
        if (!PlayerPrefs.HasKey("volume_sfx")) PlayerPrefs.SetFloat("volume_sfx", 1f);
        if (!PlayerPrefs.HasKey("volume_amb")) PlayerPrefs.SetFloat("volume_amb", 1f);

        // STATS

        if (!PlayerPrefs.HasKey("timesShot")) PlayerPrefs.SetInt("timesShot", 0); //
                                                                                  // For Accuracy Stat
        if (!PlayerPrefs.HasKey("timesHit")) PlayerPrefs.SetInt("timesHit", 0); ////

        if (!PlayerPrefs.HasKey("enemiesKilled")) PlayerPrefs.SetInt("enemiesKilled", 0);
        if (!PlayerPrefs.HasKey("treasureObtained")) PlayerPrefs.SetInt("treasureObtained", 0);
    }

    public void Update()
    {
        if (health > 0 && Enemy_Info.enemyNumber > 0)
        {
            Player_Info.ended = false;
        }
        if (health <= 0 && Player_Info.ended == false)
        {
            Player_Info.ended = true;
            Control(false);
            health = 100;
            SceneManager.LoadScene(3);
        }

    }
    public void Control(bool condition)
    {
        gameObject.GetComponent<Player_Behaviour>().enabled = condition;
        gameObject.GetComponentInChildren<Player_Shooting>().enabled = condition;
        gameObject.GetComponentInChildren<Player_RotateCamera>().enabled = condition;
        foreach (CapsuleCollider2D collider in gameObject.GetComponentsInChildren<CapsuleCollider2D>())
        {
            collider.enabled = condition;
        }
        if (condition == true)
        {
            gameObject.transform.position = new Vector3(0, 0, 0);
        }

    }
}
