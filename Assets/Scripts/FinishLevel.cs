using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    // This script is part of Trophy object. Trophy spawns when Enemy is killed. It's only purpose is to display winning scene when touched.
    public void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {SceneManager.LoadScene("WinScene");}
    }

}
