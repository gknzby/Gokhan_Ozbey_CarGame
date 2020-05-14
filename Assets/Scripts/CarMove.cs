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

    public void Reset() {
        carRot.x = 0;
        carRot.y = 0;
        carBody.velocity = carRot;
    }

    // Update is called once per frame
    void Update() {
        
        leftButton = Input.GetKey(KeyCode.LeftArrow);
        rightButton = Input.GetKey(KeyCode.RightArrow);
        
        if(playing)
        {
            // rotZ = transform.eulerAngles.z;
            // carRot.x = Mathf.Cos(rotZ * Mathf.PI / 180);
            // carRot.y = Mathf.Sin(rotZ * Mathf.PI / 180);
            
            
            carBody.velocity = transform.right * carSpeed;

            // Quaternion.Lerp(transform.rotation, rotationSpeed);
            
            if(leftButton)
            {
                transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);

                // transform.eulerAngles = new Vector3(0, 0, rotZ + ());
            }
            if(rightButton)
            {
                transform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);

                // transform.eulerAngles = new Vector3(0, 0, rotZ - (rotationSpeed * Time.deltaTime));
            }
        }

    }

    public void ButtonLeftDown()
    {
        if (playing)
            leftButton = true;
    }
    public void ButtonLeftUp()
    {
        leftButton = false;
    }
    public void ButtonRightDown()
    {
        if (playing)
            rightButton = true;
    }
    public void ButtonRightUp()
    {
        rightButton = false;
    }
}
