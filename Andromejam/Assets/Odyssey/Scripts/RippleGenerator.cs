using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RippleGenerator : MonoBehaviour {

    public float rippleGenerateTime = 0.2f;

    public float rippleGrowingSpeed = 0.2f;

    public float maxRippleSize;

    public GameObject rippleEffect;

    private float nextRipple;

    private SpriteRenderer mRenderer;

	// Use this for initialization
	void Start () {
        nextRipple = rippleGenerateTime;
        mRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (rippleEffect == null) return;

        nextRipple -= Time.deltaTime;

        if(nextRipple <= 0)
        {
            var rip = Instantiate(rippleEffect);

            var renderer = rip.GetComponent<SpriteRenderer>();
            renderer.enabled = mRenderer.enabled;
            renderer.sortingLayerName = mRenderer.sortingLayerName;

            rip.GetComponent<Transform>().position = transform.position;
            var grower = rip.AddComponent<RippleGrower>();
            grower.growingSpeed = rippleGrowingSpeed;
            grower.maxSize = maxRippleSize;
            rip.tag = tag;
            nextRipple = rippleGenerateTime;
        }
		
	}
}
