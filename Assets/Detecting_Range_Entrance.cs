using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detecting_Range_Entrance : MonoBehaviour
{
public bool inRange = false;
public Animator detective_animator;



    
 

    private void OnTriggerEnter2D(Collider2D other) 
    {   
    if(other.gameObject.CompareTag("Player")){  
    detective_animator.SetBool("Punching", true);
    StartCoroutine (punchingAnimation()); 
    gameObject.GetComponent<EnemyFightingScript>().Punch();

    }


    IEnumerator punchingAnimation()
    {
       yield return new WaitForSeconds(0.2f);
       detective_animator.SetBool("Punching", false); 
    }








    }




}
