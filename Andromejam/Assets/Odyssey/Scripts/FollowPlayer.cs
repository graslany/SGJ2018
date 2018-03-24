using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    [Tooltip("Object à suivre")]
    public GameObject ToFollow;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if(ToFollow != null)
        {
            Vector3 playerPos = ToFollow.transform.position;
            playerPos.z = transform.position.z;
            transform.position = playerPos;
        }
	}
}
