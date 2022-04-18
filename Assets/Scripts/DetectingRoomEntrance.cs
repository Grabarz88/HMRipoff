using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectingRoomEntrance : MonoBehaviour
{
//This script is added to Room_Entrance_Detector object. As there is only one way to enter Enemy's building, when PLayer get's there, he triggers Collider.
//This collider will signal Enemy to get up and start fighting.
    public Animator detective_animator; //Animator of Enemy's object.
    public GameObject enemy;
    
    private void Start() {
    detective_animator.SetBool("StandingUp", false); //StandingUp is animator's variable, that will be changed for true, when Player enters room.
    //This will trigger Enemy's standing up animation.
    enemy = GameObject.FindGameObjectWithTag("Enemy"); //Naturally, we need to signal Enemy's game object, that Player entered room. But first we need to find Enemy object.
    }
    
  
    private void OnTriggerEnter2D(Collider2D other) {
       
        if(other.gameObject.CompareTag("Player")){ //We want the Collider to trigger only if it is Player, that enters it.
        detective_animator.SetBool("StandingUp", true); //Standig up animation of Enemy begins, when Enemy enters room.
        
        enemy.GetComponent<EnemyFightingScript>().TargettingStarted(); //To make sure that enemy will first stand up ant then start fight, Enemy doesn't have target until this method is triggered.
        }
    }


}
