using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetActivator : MonoBehaviour {

    public GameObject ArrivalContainer;

    public float ActiveTime;

    private float currentTime = 0;

    private Arrival arrivalComponent;

	// Use this for initialization
	void Start () {
        GetComponent<Button>().onClick.AddListener(ActivateNet);
        arrivalComponent = ArrivalContainer.GetComponent<Arrival>();
	}
	

    void ActivateNet()
    {
        arrivalComponent.SetNetActive(true);
        GetComponent<Button>().interactable = false;
        currentTime = ActiveTime;
    }


    private void Update()
    {
        if(currentTime > 0)
        {
            currentTime -= Time.deltaTime;

            if(currentTime <= 0)
            {
                arrivalComponent.SetNetActive(false);
                GetComponent<Button>().interactable = true;
                currentTime = 0;
            }
        }
    }
}
