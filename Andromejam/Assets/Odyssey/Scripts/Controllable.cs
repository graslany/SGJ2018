using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controllable : MonoBehaviour {

    [Tooltip("Vitesse de rotation")]
    public float rotationSpeed;

    [Tooltip("Vitesse du vaisseau")]
    public float thrust;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        Rigidbody2D body = GetComponent<Rigidbody2D>();

        body.rotation -= Input.GetAxis("Horizontal") * rotationSpeed * body.velocity.magnitude;

        if (Input.GetKey("up"))
        {
            body.AddRelativeForce(Vector2.up * thrust);
        }


    }
}
