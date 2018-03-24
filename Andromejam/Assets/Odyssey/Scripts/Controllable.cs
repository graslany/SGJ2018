using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controllable : MonoBehaviour {

    [Tooltip("Vitesse de rotation")]
    public float rotationSpeed = 0.5f;

    [Tooltip("Vitesse du vaisseau")]
    public float thrust = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        Rigidbody2D body = GetComponent<Rigidbody2D>();
        body.rotation -= Input.GetAxis("Horizontal") * rotationSpeed;

        if (Input.GetKey("up"))
        {
            body.AddRelativeForce(Vector2.up * thrust);
            GetComponent<Animator>().SetBool("IsBoosting", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("IsBoosting", false);
        }
    }
}
