using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamageToPlayer : MonoBehaviour
{
   
    void Start()
    {
        Debug.Log("Uderzam");
        StartCoroutine (punchingTimer()); 
    }

  IEnumerator punchingTimer()
    {
       
       yield return new WaitForSeconds(0.2f);
       
       Destroy(gameObject);
        
    }
}
