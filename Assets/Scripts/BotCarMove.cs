using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotCarMove : MonoBehaviour
{
    public List<Vector2> locations;
    public List<Quaternion> rotations;
    public bool playing = false;
    int i = 1;
    float playTime = 0f;
    void Start()
    {
    }

    // Update is called once per frame
    // void FixedUpdate()
    // {
    //     playTime += Time.deltaTime;
    //     if(locations.Count != 0 && playing && playTime > 0.05f)
    //     {   
    //         transform.position = locations[i];
    //         transform.eulerAngles = new Vector3(0, 0, rotations[i]);
    //         i++;
    //         playTime -= .05f;
    //     }
    //     if(!playing)
    //     {
    //         i = 0;
    //     }
    // }

    private void Update() {
        if (!playing) {
            i = 0;
            return;
        }
        if (i >= locations.Count - 1) {
            return;
        }

        playTime += Time.deltaTime;
        if (playTime > .05f) {
            playTime -= .05f;
            i++;
        }

        transform.position = Vector3.Lerp(locations[i], locations[i+1], playTime / .05f);
        transform.rotation = Quaternion.Lerp(rotations[i], rotations[i+1], playTime / .05f);
    }
}
