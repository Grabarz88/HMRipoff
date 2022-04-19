using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLegsMovement : MonoBehaviour
{
 // This script is added to Legs object which is child to Player's object. 
 // Methodology is preety similar to EnemyLegsMovement. Check there for more info.
 public Animator legs_animator;
 GameObject playerTorso;
 Rigidbody2D rb;    
 
 void Start()
            {
            playerTorso = GameObject.FindGameObjectWithTag("Player");
            rb = playerTorso.GetComponent<Rigidbody2D>();
            }
            
 void Update() 
            {  
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
