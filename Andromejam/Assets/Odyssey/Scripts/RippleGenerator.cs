using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RippleGenerator : MonoBehaviour {

    public float rippleGenerateTime = 0.2f;

    public float rippleGrowingSpeed = 0.2f;

    public GameObject rippleEffect;

    private float nextRipple;

	// Use this for initialization
	void Start () {
        nextRipple = rippleGenerateTime;
	}
	
	// Update is called once per frame
	void Update () {
        if (rippleEffect == null) return;

        nextRipple -= Time.deltaTime;

        if(nextRipple <= 0)
        {
            var rip = Instantiate(rippleEffect);
            rip.GetComponent<SpriteRenderer>().enabled = GetComponent<SpriteRenderer>().enabled;
            rip.GetComponent<Transform>().position = transform.position;
            rip.AddComponent<RippleGrower>().growingSpeed = rippleGrowingSpeed;
            rip.tag = tag;
            nextRipple = rippleGenerateTime;
        }
		
	}
}
