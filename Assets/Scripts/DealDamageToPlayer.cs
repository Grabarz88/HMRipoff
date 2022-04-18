using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamageToPlayer : MonoBehaviour
{
   //This script is added to the invisible game object, that is spawn when Enemy is punching. 
   //This object exist for very short time and if Player will detect collision with an object containing DealDamageToPlayer scritp, he will start getting punched methods.
    void Start()
    {
        StartCoroutine (punchingTimer()); //Object is spawned by instantiate method from EnemyFightingScript. 
        //As so, the coroutine defines how long will it last, before dissapearing.
    }

  IEnumerator punchingTimer()
    {
       
       yield return new WaitForSeconds(0.2f);
       
       Destroy(gameObject);
        
    }
}
