using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackhole_death : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision on");
        if (collision.gameObject.tag == "Blackhole")
        {
            Destroy(this.gameObject);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}