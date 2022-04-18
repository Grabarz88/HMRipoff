using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartingScript : MonoBehaviour
{
    public bool isAlive;
    public GameObject restartText;
    
    
    public void Update() {
        if(Input.GetButtonDown("R"))
                {
                    SceneManager.LoadScene("FightScene");
                }
        if(isAlive == true)
                {
                    restartText.gameObject.SetActive(false);
                } 
        else if (isAlive == false) {
                {
                    restartText.gameObject.SetActive(true);
                }
        }             
    }
    
    
    public void setReadyToRestart(bool alive){
        isAlive = alive;

    }
}
