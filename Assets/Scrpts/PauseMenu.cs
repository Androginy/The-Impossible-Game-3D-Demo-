using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] static bool gameIsPaused = false;
    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] AudioSource music;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused) 
            {
                Cursor.visible = true;
                Resume();
            }else
            {
                Cursor.visible = true;
                Pause();
            }    
        }
    }
    public void Resume()
    {
        Cursor.visible = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        music.Play();
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        music.Pause();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
