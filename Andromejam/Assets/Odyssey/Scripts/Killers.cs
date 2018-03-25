using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killers : MonoBehaviour {

    //Todo : replace with more compelx structure to give information at death
    public string[] KillerTags;

    public string DefaultDeathMessage = "Tu es mort";
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach(string kt in KillerTags)
        {
            if (collision.gameObject.CompareTag(kt))
            {
                Destroy(gameObject);
                DeathMessage dm = collision.gameObject.GetComponent<DeathMessage>();
                string msg = dm == null ? DefaultDeathMessage : dm.message;

                FindObjectOfType<ProgressiveText>().ShowText(msg, 1);
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