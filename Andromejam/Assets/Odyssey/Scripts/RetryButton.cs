using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RetryButton : MonoBehaviour {

    public GameObject DataHolder;

	// Use this for initialization
	void Start () {
        GetComponent<Button>().onClick.AddListener(ResetGame);
	}
	
	public void ResetGame()
    {
        DataHolder.GetComponent<OdysseyData>().Reset();
    }

}
