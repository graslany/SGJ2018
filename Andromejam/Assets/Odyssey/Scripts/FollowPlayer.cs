using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    [Tooltip("Là où le joueur peut bouger, sans avoir à bouger la caméra")]
    public Rect FreeSpace;

    [Tooltip("Object à suivre")]
    public GameObject ToFollow;

    private Vector2 currentVelocity;


	// Use this for initialization
	void Start () {
        currentVelocity = new Vector2(0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 position = ToFollow.transform.position;
        if (!FreeSpace.Contains(position))
        {
            transform.position = Vector2.SmoothDamp(transform.position, position, ref currentVelocity, 10.0f, 10.0f, Time.deltaTime);
            FreeSpace.position = transform.position;//update the rectangle's position
        }
        else
        {
            currentVelocity.Set(0, 0);
        }
	}
}
