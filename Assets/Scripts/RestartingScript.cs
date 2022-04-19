using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartingScript : MonoBehaviour
{
    // This script is added to player's object. It get's information if Player is alive from PlayerMovement.
    // If Player is dead, this will show small caption "R to Restart"
    public bool isAlive;
    public GameObject restartText; //"R to Restart" object.
    
    
    public void Update() {
        if(Input.GetButtonDown("R"))
                {
                    SceneManager.LoadScene("FightScene"); //Player can restart the level even if he isn't dead.
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
    
    
    public void setReadyToRestart(bool alive){ //When Player dies, PlayerMovement signals it via this method.
        isAlive = alive;

    }
}
