using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noise : MonoBehaviour {

    [Tooltip("The object around which ")]
    public GameObject Target;

    [Tooltip("Niveau alpha de la texture")]
    public Vector2 PossibleGap;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Target == null) return;
        Vector2 position = Target.transform.position;

        float x = Random.Range(position.x - PossibleGap.x, position.x + PossibleGap.x);
        float y = Random.Range(position.y - PossibleGap.y, position.y + PossibleGap.y);

        transform.position = new Vector3(x, y, 0);
	}
}
