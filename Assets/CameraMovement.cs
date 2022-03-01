using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    Vector3 offset = new Vector3(0f,0f,-10);

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        this.target = player.transform;
    }

    void Update() {
    {
        transform.position = target.position + offset;
    }
    }

}
