using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EntitySpawner : MonoBehaviour {

    public GameObject ToSpawn;

    public float SpawnRadius;

    public int NumberOf;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < NumberOf; ++i)
        {
            float xPos = UnityEngine.Random.Range(-SpawnRadius, SpawnRadius);
            float yPos = UnityEngine.Random.Range(-SpawnRadius, SpawnRadius);

            var nwObj = Instantiate(ToSpawn, new Vector3(xPos, yPos, 0), Quaternion.identity);

            if(ToSpawn.GetComponent<Collectible>() != null)
            {
                GetComponent<OdysseyData>().DeclareCard(nwObj);
            }
        }
	}


}
