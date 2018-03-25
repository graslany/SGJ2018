using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OdysseyData : MonoBehaviour {

    private List<GameObject> cards;


    public void DeclareCard(GameObject card)
    {
        cards.Add(card);
    }

    public void Reset()
    {
        foreach (GameObject go in cards)
            go.GetComponent<Collectible>().Reset();

        foreach (CollectorCounter cc in FindObjectsOfType<CollectorCounter>())
        {
            cc.Reset();
        }
    }

    // Use this for initialization
    void Start () {
        cards = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
