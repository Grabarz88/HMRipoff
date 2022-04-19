using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //This script is added to Player's object. It is responsible for Players movement.
Rigidbody2D rb;
public Animator torso_animator; // This is animator of Player's object.
public Animator legs_animator; // This is animator of Player's legs object
public bool isAlive = true; // This variable changes if Player will get punched and killed.
Vector2 mousePosition;  
Vector2 moveDir; // This vector is Player's movement direction.
float timer = 0.0f; // This timer is used to ensure dodging works correctly.
float dirX, dirY; 
float moveSpeed = 200f;
float dodgeSpeed = 600f;

private enum State {
    // 3 states that the player can be in. 
    Normal, 
    Dodging,
    Killed,
}
private State state;
 
void Start()
            {
            rb = GetComponent<Rigidbody2D>();
            state = State.Normal;
            }
            
void Update() 
            {  
            
            if(Time.timeScale == 1f)
            {
            dirX = Input.GetAxisRaw("Horizontal");
            dirY = Input.GetAxisRaw("Vertical");
            gameObject.GetComponent<RestartingScript>().setReadyToRestart(isAlive); //RestartingScript will show small note on how to restart the level. 
            //We don't want to see this when Player is Alive.
            
            if((Input.GetButtonDown("Jump")) && (state != State.Killed))
            {
                state = State.Dodging;
            }
            
            switch (state)
            {
                case State.Normal:
                rb.velocity = moveSpeed * new Vector2(dirX, dirY).normalized; // Adding velocity to Player's object.
                torso_animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y)); //If velocity in all directions is 0, Player will play animation of standing still.
                mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                float angle = Mathf.Atan2(mousePosition.y - transform.position.y, mousePosition.x - transform.position.x) * Mathf.Rad2Deg;
                angle = angle - 90;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                break;

                case State.Dodging:
                if (timer == 0) //This ensures that player isn't currently in dodge state.
                {
                    torso_animator.SetBool("DodgeNow", true);
                    legs_animator.SetBool("DodgeNow", true);
                    moveDir = new Vector2(dirX, dirY).normalized; //moveDir takes the direction, that player is currently moving into.
                }
                
                rb.velocity = dodgeSpeed * moveDir; //Dodging velocity.
                timer = timer + Time.deltaTime; //Timer moves while dodging.

                angle = Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg; 
                angle = angle - 90;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); //We want dodge animation to diplay in only one direction. 

                if (timer >= 0.5f) //Dodge last half a second.
                {
                    timer = 0; //Timer needs to be reset to allow for next dodge.
                    torso_animator.SetBool("DodgeNow", false);
                    legs_animator.SetBool("DodgeNow", false);
                    state = State.Normal;}
                break;

                case State.Killed:
                isAlive = false;
                rb.velocity = Vector2.zero;
                rb.bodyType = RigidbodyType2D.Static;
                gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1; //We want Enemy to stand over Player, when killed.
                torso_animator.SetBool("Punched", true);
                legs_animator.SetBool("Punched", true);
                break;
            }
            }
            }





public Vector2 getMirroredMovement() //This method is used by EnemyFightingScript.
            {
            Vector2 movementVector = (rb.velocity) * (-1);
            return movementVector;
            
            }



public void OnTriggerEnter2D(Collider2D other) //This method activates, when Player touches Enemy's damage dealing object. 
            {
            if((other.gameObject.GetComponent<DealDamageToPlayer>()) && (state != State.Dodging))
            {
                state = State.Killed;
            }
            }
}
