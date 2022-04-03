using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalingPunchSpace : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      StartCoroutine (punchingTimer());  
    }

  
  void OnTriggerEnter2D(Collider2D other) {
      if(other.gameObject.CompareTag("Enemy"))
      {
          Debug.Log("Punched");
          other.gameObject.GetComponent<EnemyFightingScript>().GetPunched();
          
      }   
  }

    IEnumerator punchingTimer()
    {
       
       yield return new WaitForSeconds(0.2f);
       
       Destroy(gameObject);
        
    }


}
