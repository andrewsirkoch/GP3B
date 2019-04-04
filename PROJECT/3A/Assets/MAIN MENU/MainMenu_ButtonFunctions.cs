using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu_ButtonFunctions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Toggle[] allToggles = GetComponentsInChildren<Toggle>();
        foreach (Toggle toggle in allToggles)
        {
            print(toggle.isOn);
        }
    }

    public void New()
    {
        Toggle[] allToggles = GetComponentsInChildren<Toggle>();
        foreach (Toggle toggle in allToggles)
        {
            if (toggle.gameObject.name == "newToggle")
            {
                if (toggle.isOn)
                {
                    PlayerPrefs.SetInt("cannonLevel", 2);
                    PlayerPrefs.SetInt("sailLevel", 2);
                    PlayerPrefs.SetInt("hullLevel", 2);
                    PlayerPrefs.SetInt("crewLevel", 2);
                    PlayerPrefs.SetInt("treasure", 0);
                    PlayerPrefs.SetInt("repairKits", 20);
                    PlayerPrefs.SetInt("difficulty", 20);
                }
                else
                {
                    PlayerPrefs.SetInt("cannonLevel", 0);
                    PlayerPrefs.SetInt("sailLevel", 0);
                    PlayerPrefs.SetInt("hullLevel", 0);
                    PlayerPrefs.SetInt("crewLevel", 0);
                    PlayerPrefs.SetInt("treasure", 0);
                    PlayerPrefs.SetInt("repairKits", 2);
                    PlayerPrefs.SetInt("difficulty", 1);
                }
            }
        }

        GameObject.Find("Player").GetComponent<Player_Info>().Control(true);

        SceneManager.LoadScene(2);
    }

    public void Continue()
    {
        GameObject.Find("Player").GetComponent<Player_Info>().Control(true);

        SceneManager.LoadScene(2);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(1);
    }
    
}
