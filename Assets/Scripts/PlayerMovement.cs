using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
Rigidbody2D rb;
public Animator torso_animator;
public Animator legs_animator;
public bool isAlive = true;
Vector2 mousePosition;  
Vector2 moveDir;  
float timer = 0.0f;
float dirX, dirY;
float moveSpeed = 200f;
float dodgeSpeed = 600f;

private enum State {
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
            gameObject.GetComponent<RestartingScript>().setReadyToRestart(isAlive);
            
            if((Input.GetButtonDown("Jump")) && (state != State.Killed))
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
                    legs_animator.SetBool("DodgeNow", true);
                    moveDir = new Vector2(dirX, dirY).normalized;
                }
                // transform.rotation = Quaternion.Euler(moveDir.x, moveDir.y, 0);
                rb.velocity = dodgeSpeed * moveDir;
                timer = timer + Time.deltaTime;

                angle = Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg;
                angle = angle - 90;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                if (timer >= 0.5f) 
                {
                    timer = 0;
                    torso_animator.SetBool("DodgeNow", false);
                    legs_animator.SetBool("DodgeNow", false);
                    state = State.Normal;}
                break;

                case State.Killed:
                isAlive = false;
                rb.velocity = Vector2.zero;
                rb.bodyType = RigidbodyType2D.Static;
                gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
                torso_animator.SetBool("Punched", true);
                legs_animator.SetBool("Punched", true);
                break;
            }
            }
            }





public Vector2 getMirroredMovement()
            {
            Vector2 movementVector = (rb.velocity) * (-1);
            return movementVector;
            
            }



public void OnTriggerEnter2D(Collider2D other)
            {
            if((other.gameObject.GetComponent<DealDamageToPlayer>()) && (state != State.Dodging))
            {
                state = State.Killed;
            }
            }
}
