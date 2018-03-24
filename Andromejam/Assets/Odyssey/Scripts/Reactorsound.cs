using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reactorsound : MonoBehaviour {
    private AudioSource source;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 Velocity = GetComponent<Rigidbody2D>().velocity;
        if (Velocity.magnitude != 0)
        {

        }
	}
}
