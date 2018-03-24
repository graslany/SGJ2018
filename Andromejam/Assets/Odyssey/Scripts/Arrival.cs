using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrival : MonoBehaviour {

    [Tooltip("Text to display when finished")]
    public GameObject FinalText;

	// Use this for initialization
	void Start () {
		
	}
	
    void OnTriggerEnter2D(Collider2D other)
    {
        GetComponent<ParticleSystem>().Play();

    }
}

    void OnTriggerEnter2D(Collider2D other)
    {
        GetComponent<ParticleSystem>().Play();
        if(FinalText != null)
            FinalText.GetComponent<ProgressiveText>().Run();
