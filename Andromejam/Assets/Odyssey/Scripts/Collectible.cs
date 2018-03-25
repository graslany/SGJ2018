using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour {

    private bool collectAnimation = false;

    private CollectorCounter[] counters;

    private Vector2 originTransform;

    public void Reset()
    {
        transform.rotation.Set(0, 0, 0, 0);
        transform.localScale = originTransform;
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spaceship")
            CollidedWithSpaceship();
    }

    // Use this for initialization
    void Start()
    {
        counters = FindObjectsOfType<CollectorCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!collectAnimation) return;
        transform.Rotate(Vector3.forward * 50 * Time.deltaTime);
        transform.localScale -= Vector3.one * Time.deltaTime;

        if(transform.localScale.x <= 0)
        {
            gameObject.SetActive(false);
        }
        
    }

    private void CollidedWithSpaceship()
    {
        Destroy(GetComponent<Rigidbody2D>());
        Destroy(GetComponent<BoxCollider2D>());
        GetComponent<ParticleSystem>().Stop();
        collectAnimation = true;
        foreach(CollectorCounter cc in counters)
            cc.Increment();
    }
}

