using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPunch : MonoBehaviour
{
    public Animator torso_animator;
    public bool nextHand;
    // public bool punchNow; 
    public bool punchcooldown = false;
 
    void Update()
    {
        if(Input.GetButtonDown("Fire1")) {Punch();}       
    }



    void Punch(){
        if (punchcooldown == false)
        {
            if (nextHand == true) {nextHand = false;}
            else if (nextHand == false) {nextHand = true;}
            torso_animator.SetBool("NextHand", nextHand);
            torso_animator.SetBool("PunchNow", true);
            StartCoroutine (punchingAnimation());
            //punchNow is used to activate animation of punching. But maybe it would be more optimal to use punchcooldown instead?
        }
    }


    IEnumerator punchingAnimation()
    {
       punchcooldown = true;
       yield return new WaitForSeconds(0.2f);
       torso_animator.SetBool("PunchNow", false);
       punchcooldown = false;  
    }
}
