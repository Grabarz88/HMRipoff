using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuManagerScript : MonoBehaviour
{
   
    public void LoadGame()
    {
        SceneManager.LoadScene("FightScene");
    }


    public void OpenManual()
    {
        SceneManager.LoadScene("Manual");
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
