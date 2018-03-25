using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Device : MonoBehaviour {
    private bool collectAnimation = false;

    public GameObject CollectibleCounter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlatformerPlayerController player = collision.GetComponentInChildren<PlatformerPlayerController>();
        if (player == null)
        {
            player = collision.GetComponentInParent<PlatformerPlayerController>();
        }

        if (player != null)
        {
            CollidedWithplayer();
        }
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!collectAnimation) return;
        transform.Rotate(Vector3.forward * 50 * Time.deltaTime);
        transform.localScale -= Vector3.one * Time.deltaTime;

        if (transform.localScale.x <= 0)
        {
            Destroy(gameObject);
        }

    }

    private void CollidedWithplayer()
    {
        Destroy(GetComponent<Rigidbody2D>());
        Destroy(GetComponent<BoxCollider2D>());
        collectAnimation = true;
    }
}
