using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OdysseyData : MonoBehaviour {

    private List<GameObject> cards;

    public GameObject SpaceShip;

    public GameObject[] texts;

    public void Awake()
    {
        cards = new List<GameObject>();
    }

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

        //reposition spaceship at start
        SpaceShip.transform.position = new Vector3(0, 0, 0);
        SpaceShip.SetActive(true);

        foreach(GameObject go in texts)
        {
            go.GetComponentInChildren<ProgressiveText>().Clear();
        }
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
