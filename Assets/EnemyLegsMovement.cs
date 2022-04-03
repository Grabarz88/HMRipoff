using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLegsMovement : MonoBehaviour
{
  public Animator legs_animator;
 GameObject enemyTorso;
 Rigidbody2D rb;    

 
 void Start()
            {
            enemyTorso = GameObject.FindGameObjectWithTag("Enemy");
            rb = enemyTorso.GetComponent<Rigidbody2D>();
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
