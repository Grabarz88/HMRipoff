using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPunch : MonoBehaviour
{
    // This script is added to Player's object. It is responsible for deciting where and when spawn punch making object and when the punching animation should be executed. 
    public Animator torso_animator;
    public bool nextHand; //This variable decides, which hand should the Player punch with.
    //Note: Player punches with both hands alternately.
    
    public bool punchcooldown = false; //When punch is on, we need to wait till it's over to be able to punch again.
    Rigidbody2D rb;
    [SerializeField] GameObject punchMakingObject; //This object spawns while punching. It exists only for few miliseconds and if it kollides with Enemy. It will kill him.
    Vector2 mousePosition; // We need mouse position to determine where punchMakingObject will be placed.
    Vector2 punchSpot; // This will be the place, where punchMakingObject will be spawned.
 
    void Update()
    {
        if(Input.GetButtonDown("Fire1")) {Punch();}   
    }



    void Punch(){
        if (punchcooldown == false)
        {
            if (nextHand == true) {nextHand = false;} 
            else if (nextHand == false) {nextHand = true;} //Switching hands while punching.
            torso_animator.SetBool("NextHand", nextHand); //Signalling which hand's animation should be played next.
            torso_animator.SetBool("PunchNow", true); //Signalling that one of punching animations shall be played.
            StartCoroutine (punchingAnimation()); //Ensuring punch cooldown.
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
            Vector3 punchDir = new Vector3(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y, 0f); //Checking what direction Player is facing, and as so, what direction from Player the punch making object should be placed.
            punchDir = punchDir.normalized;
            punchSpot = transform.position + punchDir*24; //Selecting spawn object of punch making object.
            Instantiate(punchMakingObject, punchSpot, Quaternion.identity); //Instantiating punch making object.
            
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
