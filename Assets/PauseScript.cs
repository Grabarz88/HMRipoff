using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
  
    public bool gameIsPaused = false;
    public GameObject pauseMenu;



    void Start() {
    pauseMenu.gameObject.SetActive(false);
    Time.timeScale = 1f;     
    }
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.Escape))
      {
          if (gameIsPaused == true) {gameIsPaused = false;}
          else if (gameIsPaused == false) {gameIsPaused = true;}

          if(gameIsPaused == true)
            {
                pauseMenu.gameObject.SetActive(true);
                Time.timeScale = 0f;
            }
           else if(gameIsPaused == false)
           {
               pauseMenu.gameObject.SetActive(false);
               Time.timeScale = 1f;
           }
      }  
    }

    public void Resume()
    {
        pauseMenu.gameObject.SetActive(false);
        gameIsPaused = false;
        Time.timeScale = 1f; 
    }

    public void Restart()
    {
        SceneManager.LoadScene("FightScene");
        Time.timeScale = 1f;         
    }

    public void Exit()
    {
        SceneManager.LoadScene("Menu");
    }
}
