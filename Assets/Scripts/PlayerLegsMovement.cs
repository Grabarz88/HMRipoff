using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLegsMovement : MonoBehaviour
{
 
 public Animator legs_animator;
 
 Rigidbody2D rb;    
 float dirX, dirY;
 float moveSpeed = 40f;
 
 void Start()
            {
            rb = GetComponent<Rigidbody2D>();
            }
            
 void Update() 
            {  
            dirX = Input.GetAxisRaw("Horizontal");
            dirY = Input.GetAxisRaw("Vertical");
            rb.velocity = moveSpeed * new Vector2(dirX, dirY).normalized;

            
            legs_animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y));
            
            Vector2 moveDirection = rb.velocity;
            if (moveDirection != Vector2.zero)
                {
                float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
                angle = angle - 90;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                }
            
            }
}
