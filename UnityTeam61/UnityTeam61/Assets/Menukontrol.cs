using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menukontrol : MonoBehaviour
{
    public static bool gameIsPaused;
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public GameObject panel;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }

        }
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        panel.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        panel.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }


}
