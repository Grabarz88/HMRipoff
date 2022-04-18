using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //This script is added to Camera. It defines it's movement.
    public Transform target;
    Vector3 offset = new Vector3(0f,0f,-10); //This wll define the position of camera. As i want camera to follow player, without being it's child.
    Vector2 mousePosition; 


    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        this.target = player.transform; //This will copy Player's positional variables.
    }

    void Update() {
    {
        if(Time.timeScale == 1f) //This makes sure that camera doesn't move, if game is paused. Pausing is in PauseScript
        {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 tilt = new Vector3(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y, 0f); //Calculating mouse position, regarding Player's position on map.
        tilt = tilt/3;
        transform.position = target.position + offset + tilt; //Doing all of above will make camera move slightly in the direction in which mouse is pointed. It is some form of looking around for Player.
        }
    }
    }

}
