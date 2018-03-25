using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killers : MonoBehaviour {

    //Todo : replace with more compelx structure to give information at death
    public string[] KillerTags;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach(string kt in KillerTags)
        {
            if (collision.gameObject.CompareTag(kt))
            {
                Destroy(gameObject);
                return;
            }
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}