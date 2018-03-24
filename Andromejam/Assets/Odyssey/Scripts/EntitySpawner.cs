using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour {

    public GameObject ToSpawn;

    public float SpawnRadius;

    public int NumberOf;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < NumberOf; ++i)
        {
            Debug.Log("Spawning one");
            float xPos = Random.Range(-SpawnRadius, SpawnRadius);
            float yPos = Random.Range(-SpawnRadius, SpawnRadius);

            var nwObj = Instantiate(ToSpawn, new Vector3(xPos, yPos, 0), Quaternion.identity);
            foreach(Behaviour c in nwObj.GetComponents<Behaviour>())
            {
                c.enabled = true;
            }
            nwObj.GetComponent<SpriteRenderer>().enabled = true;
        }

	}
}
