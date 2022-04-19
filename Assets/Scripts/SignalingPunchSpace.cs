using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalingPunchSpace : MonoBehaviour
{
   //This script is added to Circle object, which is spawned when Player is punching. It states how big the space in which Enemy will get punched is.  
    void Start()
    {
      StartCoroutine (punchingTimer());  // Object will dissapear after a few miliseconds.
    }

  
  void OnTriggerEnter2D(Collider2D other) {
      if(other.gameObject.CompareTag("Enemy"))
      {
          other.gameObject.GetComponent<EnemyFightingScript>().GetPunched(); //Signaling to Enemy that he got punched is made bby this method.
          
      }   
  }

    IEnumerator punchingTimer()
    {
       
       yield return new WaitForSeconds(0.2f);
       
       Destroy(gameObject);
        
    }


}
