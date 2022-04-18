using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    Vector3 offset = new Vector3(0f,0f,-10);
    Vector2 mousePosition; 


    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        this.target = player.transform;
    }

    void Update() {
    {
        if(Time.timeScale == 1f)
        {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 tilt = new Vector3(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y, 0f);
        tilt = tilt/3;
        transform.position = target.position + offset + tilt;
        }
    }
    }

}
