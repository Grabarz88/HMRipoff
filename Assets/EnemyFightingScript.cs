using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFightingScript : MonoBehaviour
{
    public bool EnemyTargetStart = false;
    public GameObject target; //target is player in this case
    public Vector2 targetDir; //This Vector is pointing at the player
    public Vector2 targetMovementDir; //The enemy will try to mirror player's movement. This Vector will be taken straight from player's object;
    public float velocityInTargetDir;
    
    Rigidbody2D rb;
    
    void Start() {
      rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()       
    { 
     if (EnemyTargetStart == true){
       StartCoroutine(ExecuteAfterTime(2));
       
     }   

     if (target)
     {
        float angle = Mathf.Atan2(target.transform.position.y - transform.position.y, target.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
        angle = angle - 90;
        
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        targetDir = new Vector2(target.transform.position.x - transform.position.x, target.transform.position.y - transform.position.y);
        targetDir = targetDir.normalized;
        
        
        targetMovementDir = target.gameObject.GetComponent<PlayerMovement>().getMirroredMovement();

        velocityInTargetDir = Vector2.Dot(targetMovementDir, targetDir); 
        
        // if(velocityInTargetDir<0f)
        // {
        // rb.velocity = (targetDir * 100) + (targetMovementDir/2) - (targetDir * velocityInTargetDir);
        // Debug.Log("Daleko");
        // }
        // else if(velocityInTargetDir>=0f)
        // {
        // rb.velocity = (targetDir * 100) + (targetMovementDir/2);
        // Debug.Log("Blisko");
        // }

        rb.velocity = (targetDir * 100) + ((targetMovementDir-(targetDir * velocityInTargetDir))/2);
        

       
        
     }  
    }

    public void TargettingStarted()
    {
      EnemyTargetStart = true;  
    }

  IEnumerator ExecuteAfterTime(float time)
 {
     yield return new WaitForSeconds(time);
     target = GameObject.FindGameObjectWithTag("Player");
 }


}
