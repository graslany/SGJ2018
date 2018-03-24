using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderVerificator : MonoBehaviour {

    [Tooltip("Bords du monde")]
    public Rect MovingZone;

    [Tooltip("L'objet qui doit rester dans les bords")]
    public GameObject ToVerify;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (MovingZone == null || ToVerify == null || MovingZone.Contains(ToVerify.transform.position)) return;

        Debug.Log("Is outside");
        float objX = ToVerify.transform.position.y;
        float objY = ToVerify.transform.position.y;

        float objZ = ToVerify.transform.position.z;

        if(objX  <= MovingZone.xMin)
        {
            ToVerify.transform.position.Set(MovingZone.xMax, objY, objZ);
        }else if(objX >= MovingZone.xMax)
        {
            ToVerify.transform.position.Set(MovingZone.xMin, objY, objZ);
        }

        if(objY <= MovingZone.yMin)
        {
            ToVerify.transform.position.Set(objX, MovingZone.yMax, objZ);
        }
        else if(objY >= MovingZone.yMax)
        {
            ToVerify.transform.position.Set(objX, MovingZone.yMin, objZ);
        }
	}
}
