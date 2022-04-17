using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFightingScript : MonoBehaviour
{
    public bool EnemyTargetStart = false;
    public bool IsAlive = true;
    [SerializeField] GameObject punchMakingObject;
    public GameObject target; //target is player in this case
    public GameObject trophy;
    public Vector2 targetDir; //This Vector is pointing at the player
    public Vector2 targetMovementDir; //The enemy will try to mirror player's movement. This Vector will be taken straight from player's object;
    public float velocityInTargetDir;
    public Animator detective_animator;
    public Animator detective_legs_animator;
    
    Rigidbody2D rb;
    
    
    void Start() {
      rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()       
    { 
     if (EnemyTargetStart == true){
       StartCoroutine(FindTaget());
       
     }   

     if ((target) && (IsAlive))
     {
        float angle = Mathf.Atan2(target.transform.position.y - transform.position.y, target.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
        angle = angle - 90;
        
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        targetDir = new Vector2(target.transform.position.x - transform.position.x, target.transform.position.y - transform.position.y);
        targetDir = targetDir.normalized;
        
        
        targetMovementDir = target.gameObject.GetComponent<PlayerMovement>().getMirroredMovement();

        velocityInTargetDir = Vector2.Dot(targetMovementDir, targetDir); 
        
        
        rb.velocity = (targetDir * 100) + ((targetMovementDir-(targetDir * velocityInTargetDir))/2);
      }

      else if (IsAlive == false) {
        {
          gameObject.GetComponent<BoxCollider2D>().enabled = false;
          StartCoroutine(DeathCoroutine());
        }      
       
        
     }  
    }

    public void TargettingStarted()
    {
      EnemyTargetStart = true;  
    }

    public void GetPunched()
    {
      IsAlive = false;
      rb.velocity = Vector2.zero;
      rb.bodyType = RigidbodyType2D.Static;
      transform.position = new Vector2(transform.position.x + (-60)*targetDir.x, transform.position.y + (-60)*targetDir.y);
      detective_animator.SetBool("Punched", true);
      detective_legs_animator.SetBool("Punched", true);
      
    }

    public void Punch()
    {
      if(IsAlive == true){StartCoroutine(PunchCoroutine());}
    }

  IEnumerator FindTaget()
 {
     yield return new WaitForSeconds(2);
     target = GameObject.FindGameObjectWithTag("Player");
 }

  IEnumerator PunchCoroutine()
 {
     yield return new WaitForSeconds(0.07f);
     Instantiate(punchMakingObject, gameObject.transform.position, Quaternion.identity);
 }

  IEnumerator DeathCoroutine()
 {
     yield return new WaitForSeconds(1.0f);
     Instantiate(trophy, new Vector2(-735, 323), Quaternion.identity);
 }

}


