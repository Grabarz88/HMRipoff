using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
Rigidbody2D rb;
public Animator torso_animator;
Vector2 mousePosition;  
Vector2 moveDir;  
float timer = 0.0f;
float dirX, dirY;
float moveSpeed = 200f;
float dodgeSpeed = 600f;
bool collided = false;

private enum State {
    Normal,
    Dodging,
}
private State state;
 
void Start()
            {
            rb = GetComponent<Rigidbody2D>();
            state = State.Normal;
            }
            
void Update() 
            {  
            dirX = Input.GetAxisRaw("Horizontal");
            dirY = Input.GetAxisRaw("Vertical");
            
            
            if(Input.GetButtonDown("Jump"))
            {
                state = State.Dodging;
            }
            
            switch (state)
            {
                case State.Normal:
                rb.velocity = moveSpeed * new Vector2(dirX, dirY).normalized;
                torso_animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y));
                mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                float angle = Mathf.Atan2(mousePosition.y - transform.position.y, mousePosition.x - transform.position.x) * Mathf.Rad2Deg;
                angle = angle - 90;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                break;

                case State.Dodging:
                if (timer == 0)
                {
                    torso_animator.SetBool("DodgeNow", true);
                    moveDir = new Vector2(dirX, dirY).normalized;
                }
                
                if (collided == false){
                rb.velocity = dodgeSpeed * moveDir;
                timer = timer + Time.deltaTime;
                }
                else
                {
                rb.velocity = Vector2.zero;
                }


                if (timer >= 0.5f) 
                {
                    Debug.Log(timer); 
                    timer = 0;
                    torso_animator.SetBool("DodgeNow", false);
                    state = State.Normal;}
                break;
            
            }
            }


void OnCollisionEnter2D(Collision2D other)
    {
    switch (state)
    {
    case State.Dodging:
    Debug.Log("kolizja");

    if ((timer >= 0.0f) && (timer > 0.5f)) 
        {
           collided = true;
        }    



    // rb.isKinematic = false;
    // rb.velocity = Vector2.zero;
    // rb.angularVelocity = 0; 
    // rb.isKinematic = true;
    break;
    }
    }


public Vector2 getMirroredMovement()
            {
            Vector2 movementVector = (rb.velocity) * (-1);
            return movementVector;
            
            }
}
