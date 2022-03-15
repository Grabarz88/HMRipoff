using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectingRoomEntrance : MonoBehaviour
{

    public Animator detective_animator;
    public GameObject enemy;
    
    private void Start() {
    detective_animator.SetBool("StandingUp", false);
    enemy = GameObject.FindGameObjectWithTag("Enemy");
    }
    
  
    private void OnTriggerEnter2D(Collider2D other) {
       
        if(other.gameObject.CompareTag("Player")){  
        detective_animator.SetBool("StandingUp", true);
        
        enemy.GetComponent<EnemyFightingScript>().TargettingStarted();
        }
    }


}
