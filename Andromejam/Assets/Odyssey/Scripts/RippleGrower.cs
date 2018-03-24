using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RippleGrower : MonoBehaviour {

    public float growingSpeed;

    public float maxSize;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.localScale += (Vector3.one * growingSpeed);

        if(transform.localScale.magnitude > maxSize)
        {
            Destroy(gameObject);
        }
        else
        {
            float magn = (maxSize - transform.localScale.magnitude) / maxSize;
            var color = GetComponent<SpriteRenderer>().color;
            color.a = magn;
            GetComponent<SpriteRenderer>().color = color;
        }
	}
}
