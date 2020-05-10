using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CarMove : MonoBehaviour
{
    public float carSpeed = 1.5f;
    public float rotationSpeed = 3;    
    public bool playing = false;

    Vector3 carRot;
    Rigidbody2D carBody;

    float rotZ;
    bool leftButton = false;
    bool rightButton = false;


    void Start()
    {
        carBody = GetComponent<Rigidbody2D>();
        carRot = new Vector3(0, 0, 0);


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(playing)
        {
            rotZ = transform.eulerAngles.z;
            carRot.x = Mathf.Cos(rotZ * Mathf.PI / 180);
            carRot.y = Mathf.Sin(rotZ * Mathf.PI / 180);
            carBody.velocity = carRot * carSpeed;
            if(leftButton)
            {
                transform.eulerAngles = new Vector3(0, 0, rotZ + rotationSpeed);
            }
            if(rightButton)
            {
                transform.eulerAngles = new Vector3(0, 0, rotZ - rotationSpeed);
            }
        }
        else
        {
            carRot.x = 0;
            carRot.y = 0;
            carBody.velocity = carRot;
        }
    }

    public void ButtonLeft()
    {
        leftButton = !leftButton;
    }
    public void ButtonRight()
    {
        rightButton = !rightButton;
    }
}
