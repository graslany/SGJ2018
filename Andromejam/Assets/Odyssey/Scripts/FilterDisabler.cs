using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilterDisabler : MonoBehaviour {

    private FilterAffector[] FilterAffectors;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Spaceship")) return;

        foreach(FilterAffector fa in FilterAffectors)
        {
            fa.DisableFilter();
            fa.GetComponent<Button>().interactable = false;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Spaceship")) return;

        foreach(FilterAffector fa in FilterAffectors)
        {
            fa.GetComponent<Button>().interactable = true;
        }
    }


    // Use this for initialization
    void Start () {
        FilterAffectors = FindObjectsOfType<FilterAffector>();
	}
}
