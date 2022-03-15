using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFightingScript : MonoBehaviour
{
    public bool EnemyTargetStart = false;
    public GameObject target;
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
