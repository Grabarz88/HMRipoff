using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFightingScript : MonoBehaviour
{
  //This script is added to Enemy. It is responsible for movement, animating character while punched and punching.
    public bool EnemyTargetStart = false; //This variable is changed by DetectingRoomEntrance script. When it changes to true, Enemy will perform the standing up animation and after that he will set targetting on Player.
    public bool IsAlive = true; //This variable is changed, when Enemy will detect being punched. It was important, to stop all procesess like moving or punching.
    [SerializeField] GameObject punchMakingObject; //This object will be spawned when Enemy gets signal, from Detecting_Range_Entrance script, that Player is close enough to begin the procedure of punching.
    public GameObject target; //Target is Player in this case
    public GameObject trophy; //This object will be spawned after the Enemy is dead. Trophy, when touched, finishes level.
    public Vector2 targetDir; //This Vector is pointing at the player's direction. It is used to determine the Enemy's turning angle.
    public Vector2 targetMovementDir; //The enemy will try to mirror player's movement. This Vector will be taken straight from player's object.
    public float velocityInTargetDir; //This float calculates the speed of enemy.
    public Animator detective_animator; //This animator is responsible for animating Enemy's torso.
    public Animator detective_legs_animator; //This animator is responsible for animating Enemy's legs.

    
    Rigidbody2D rb;
    
    
    void Start() {
      rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()       
    { 
     if (EnemyTargetStart == true){ //This variable is changed by function TargettingStarted.
       StartCoroutine(FindTaget());//This coroutine makes sure the Enemy has time to play it's standing up animation.
       
     }   

     if ((target) && (IsAlive))
     {
        float angle = Mathf.Atan2(target.transform.position.y - transform.position.y, target.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
        angle = angle - 90; //This will be the angle of Enemy's sprite rotation.
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); //Rotation is added to Enemy.
        targetDir = new Vector2(target.transform.position.x - transform.position.x, target.transform.position.y - transform.position.y);
        targetDir = targetDir.normalized; //Here, the Player's direction regardin Enemy's position is calculated and normalized.
        targetMovementDir = target.gameObject.GetComponent<PlayerMovement>().getMirroredMovement(); //This will return Player's movement in mirrored way.
        velocityInTargetDir = Vector2.Dot(targetMovementDir, targetDir); //This calculates how fast Enemy should move, considering that we want him to move towards player at constant speed, and move left and right depending on PLayers movements.
        rb.velocity = (targetDir * 100) + ((targetMovementDir-(targetDir * velocityInTargetDir))/2); //Finally, here the velocity is calculated and added to Enemy.
      
      }

      else if (IsAlive == false) {
        {
          gameObject.GetComponent<BoxCollider2D>().enabled = false; //Obviously. When player dies, we want to be able to walk over him.
          StartCoroutine(DeathCoroutine()); //Coroutine to Instantiate Trophy.
        }      
       
        
     }  
    }

    public void TargettingStarted() // This method is iniciated by DetectingRoomEntrance script.
    {
      EnemyTargetStart = true;  
    }

    public void GetPunched() //This method is iniciated by SiganlingPunchSpace.
    {
      IsAlive = false; //Obviously, Enemy dies when punched.
      rb.velocity = Vector2.zero; //Velocity won't be changed in Update, because of IsAlive safety conditional statement.
      rb.bodyType = RigidbodyType2D.Static; 
      transform.position = new Vector2(transform.position.x + (-60)*targetDir.x, transform.position.y + (-60)*targetDir.y); //Enemy will be slightly pushed backward, when punched and dying.
      detective_animator.SetBool("Punched", true);
      detective_legs_animator.SetBool("Punched", true);
      
    }

    public void Punch()
    {
      if(IsAlive == true){StartCoroutine(PunchCoroutine());} //This method is called by Detecting_Range_Entrance.
    }

  IEnumerator FindTaget()
 {
     yield return new WaitForSeconds(2); //Time required for Enemy to perform his animation.
     target = GameObject.FindGameObjectWithTag("Player"); //When animation is finished. Enemy will aquire target and so, will turn in his direction.
 }

  IEnumerator PunchCoroutine()
 {
     yield return new WaitForSeconds(0.07f); //This time is some form of Enemy "waiting" for Player to get into his real punch range.
     //So the mechanics consider, that Player is running in Enemy's direction and will get hit if he won't stop on time.
     //Then, when Enemy will blow his hit, the Player should continue moving toward Enemy and finally attack him when in close proximity.
     Instantiate(punchMakingObject, gameObject.transform.position, Quaternion.identity);  //Instantiating the object, that if collides with Player, will kill him.
 }

  IEnumerator DeathCoroutine()
 {
     yield return new WaitForSeconds(1.0f); // Time required for Enemy's animation to go throu.
     Instantiate(trophy, new Vector2(-735, 323), Quaternion.identity);
 }

}


