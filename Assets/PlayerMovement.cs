using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
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
            }
}
