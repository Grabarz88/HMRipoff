using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLegsMovement : MonoBehaviour
{
// This script is added to Enemy's legs object, which is child object to Enemy itself.
  public Animator legs_animator; 
 GameObject enemyTorso; //Enemy itself.
 Rigidbody2D rb;    

 
 void Start()
            {
            enemyTorso = GameObject.FindGameObjectWithTag("Enemy"); // Defining what is Enemy's object.
            rb = enemyTorso.GetComponent<Rigidbody2D>(); // Enemy's rigidbody will be necessary to get movement direction.
            }
            
 void Update() 
            {  
            
            
            legs_animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y)); // In case of Enemy making any movement at all, his legs will make the walking animation.
            
            Vector2 moveDirection = rb.velocity; //We don't need the exact velocity's value. We just need to know which direction is it pointed.
            if (moveDirection != Vector2.zero)
                {
                float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg; //We need to calculate the angle, that Enemy's legs will be turned.
                angle = angle - 90; 
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); //Rotation is added based on previous calculations.
                }
            
            }

}
