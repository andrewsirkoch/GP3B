using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    private int timer;
    private bool pauseOpen = false;
    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pauseOpen == false)
        {
            pauseMenu.SetActive(true);
            pauseOpen = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pauseOpen == true)
        {
            pauseMenu.SetActive(false);
            pauseOpen = false;
        }

        timer += 1;
        if (timer >= 200) Player_Info.ended = false;
    }

    public void Button_LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void closePause()
    {
        pauseMenu.SetActive(false);
        pauseOpen = false;
    }

    public void Control(bool condition)
    {
        GameObject.Find("Player").GetComponent<Player_Info>().Control(condition);
    }
}
