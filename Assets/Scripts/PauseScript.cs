using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
  // This script is added to Canvas in FightingScene. Its purpose is to allow player to pause the game by pressing "Esc".
    public bool gameIsPaused = false; // Variable that shows if game is or isn't paused.
    public GameObject pauseMenu; //This is a panel that displays when game is paused.



    void Start() {
    pauseMenu.gameObject.SetActive(false); //At start we want the menu panel to be invisible.
    Time.timeScale = 1f;     
    }
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.Escape)) //I believe it is selfexplationary. When game is paused and we press Esc, we want it to unpause. When game isn't paused and we press Esc, we want it to unpause.
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

    public void Resume() //Method for Resume button.
    {
        pauseMenu.gameObject.SetActive(false);
        gameIsPaused = false;
        Time.timeScale = 1f; 
    }

    public void Restart() //Method for Restart button.
    {
        SceneManager.LoadScene("FightScene");
        Time.timeScale = 1f;         
    }

    public void Exit()
    {
        SceneManager.LoadScene("Menu"); //Method for Exit button.
    }
}
