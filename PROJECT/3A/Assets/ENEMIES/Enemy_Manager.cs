using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy_Manager : MonoBehaviour
{
    private int timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i <= PlayerPrefs.GetInt("difficulty") * 2; i++)
        {
            GameObject enemy;
            enemy = Instantiate(Resources.Load("Enemy"), new Vector3(Random.Range(-200, 200), Random.Range(-200, 200), 0), transform.rotation) as GameObject;
            enemy.transform.Rotate(0, 0, Random.Range(0.0f, 360.0f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1;
        if (timer >= 200)
        {
            if (Enemy_Info.enemyNumber == 0 && Player_Info.ended == false)
            {
                Player_Info.ended = true;
                PlayerPrefs.SetInt("treasure", PlayerPrefs.GetInt("treasure") + 50);
                PlayerPrefs.SetInt("treasureObtained", PlayerPrefs.GetInt("treasureObtained") + 50);
                PlayerPrefs.SetInt("difficulty", PlayerPrefs.GetInt("difficulty") + 1);
                GameObject.Find("Player").GetComponent<Player_Info>().health = 100;
                SceneManager.LoadScene(3);
            }
        }
        
    }
}
