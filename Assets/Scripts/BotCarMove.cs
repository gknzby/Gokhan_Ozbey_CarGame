using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotCarMove : MonoBehaviour
{
    public List<Vector2> locations;
    public List<float> rotations;
    public bool playing = false;
    int i = 0;
    float playTime = 0;
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playTime += Time.deltaTime;
        if(locations.Count != 0 && playing && playTime > 0.05)
        {   
            transform.position = locations[i];
            transform.eulerAngles = new Vector3(0, 0, rotations[i]);
            i++;
            playTime = 0;
        }
        if(!playing)
        {
            i = 0;
        }
    }
}
