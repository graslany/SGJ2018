using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour {

    private bool collectAnimation = false;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Spaceship")
            CollidedWithSpaceship();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!collectAnimation) return;
        transform.Rotate(Vector3.forward * 50 * Time.deltaTime);
        transform.localScale -= Vector3.one * Time.deltaTime;

        if(transform.localScale.x <= 0)
        {
            Destroy(gameObject);
        }
        
    }

    private void CollidedWithSpaceship()
    {
        Destroy(GetComponent<Rigidbody2D>());
        Destroy(GetComponent<BoxCollider2D>());
        GetComponent<ParticleSystem>().Stop();
        collectAnimation = true;
    }
}