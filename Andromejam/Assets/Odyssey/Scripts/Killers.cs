using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killers : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision on");
        if (collision.gameObject.CompareTag("Blackhole") || 
            collision.gameObject.CompareTag("NeutronStar"))
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}