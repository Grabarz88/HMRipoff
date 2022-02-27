using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
Rigidbody2D rb;
public Animator torso_animator;
Vector2 mousePosition;    
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

            torso_animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y));

            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
            angle = angle - 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                
            
            }
}
