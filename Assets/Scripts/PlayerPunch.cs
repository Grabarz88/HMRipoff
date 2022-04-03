using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPunch : MonoBehaviour
{
    public Animator torso_animator;
    public bool nextHand;
    // public bool punchNow; 
    public bool punchcooldown = false;
    Rigidbody2D rb;
    [SerializeField] GameObject punchMakingObject;
    Vector2 mousePosition;
    Vector2 punchSpot;
 
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
            torso_animator.SetBool("PunchNow", true); //punchNow is used to activate animation of punching. But maybe it would be more optimal to use punchcooldown instead?
            StartCoroutine (punchingAnimation());
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 punchDir = new Vector3(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y, 0f);
            punchDir = punchDir.normalized;
            punchSpot = transform.position + punchDir*24;
            Instantiate(punchMakingObject, punchSpot, Quaternion.identity);
            
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
