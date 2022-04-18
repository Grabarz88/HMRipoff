using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detecting_Range_Entrance : MonoBehaviour
{
//This script is added to Enemy's child object, called PunchRangeDetector. 
//It has CircleCollider2D set as trigger and with a collision border set to be slightly bigger than Enemmy's.
//Methodology here assumes, that Player will enter this Collider's border, and activate signal to Enemy, that he needs to punch in next few milisecounds.
//All of this tries to simulate some sort of Enemy's reaction time.
//Because Enemy tries to calculate when to throw a punch, to place a hit on enemy that will be in range at this time.
public bool inRange = false; //This variable turns true, when enemy enters Collider.
GameObject enemy; //Obviously, this will be Enemy's object.
public Animator detective_animator; //When detecting, that Player is withing range, the Enemy will have to perform punching animation.

    private void OnTriggerEnter2D(Collider2D other) 
    {   
    if(other.gameObject.CompareTag("Player")){
    detective_animator.SetBool("Punching", true); //This triggers Emnemy's punching animation
    StartCoroutine (punchingAnimation()); //This coroutine creates cooldown for Enemy's punch animation.
    //We don't want him to waggle his arm like some sort of maniac, when players enters and quits range at fast pace.
    enemy = GameObject.FindGameObjectWithTag("Enemy");
    enemy.GetComponent<EnemyFightingScript>().Punch(); //Punching itself is performed by EnemyFighitngScript. This is where the "Enemy_Punch_Object".
    }

    IEnumerator punchingAnimation()
    {
       yield return new WaitForSeconds(0.2f);
       detective_animator.SetBool("Punching", false);//After coroutine ends, Enemy is ready to get his range detecting object triggered again.
    }
    }
}
