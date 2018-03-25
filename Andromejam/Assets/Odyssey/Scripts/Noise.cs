using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noise : MonoBehaviour {

    [Tooltip("The object around which ")]
    public GameObject Target;

    [Tooltip("Niveau alpha de la texture")]
    public Vector2 PossibleGap;

    private Vector2 lastPosition;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if(Target != null)
        {
            lastPosition = Target.transform.position;
        }

        float x = Random.Range(lastPosition.x - PossibleGap.x, lastPosition.x + PossibleGap.x);
        float y = Random.Range(lastPosition.y - PossibleGap.y, lastPosition.y + PossibleGap.y);

        transform.position = new Vector3(x, y, 0);
	}
}
