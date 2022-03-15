using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFightingScript : MonoBehaviour
{
    public bool EnemyTargerStart = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TargettingStarted()
    {
      EnemyTargerStart = true;  
    }
}
