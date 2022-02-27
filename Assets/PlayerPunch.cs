using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPunch : MonoBehaviour
{
    public Animator torso_animator;
    public bool nexthand; 
 
    void Update()
    {
        if(Input.GetButtonDown("Fire1")) {Punch();}       
    }



    void Punch(){
        if (nexthand == false)
        {
            nexthand = true;
            //tutaj wpisać kod, żeby animator sprawdzał którą ręką i jaką akcję ma wykonać
        }
    }
}
