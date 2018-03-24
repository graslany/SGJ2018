using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotationcollectible : MonoBehaviour {

    //Update is called every frame
    void Update()
    {
        //Rotate thet transform of the game object this is attached to by 45 degrees, taking into account the time elapsed since last frame.
        GetComponent<Rigidbody2D>().rotation += 45 * Time.deltaTime;
    }
}