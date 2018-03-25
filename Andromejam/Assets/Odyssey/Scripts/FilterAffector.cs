using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilterAffector : MonoBehaviour {

    public string[] TagToFilter;

    public KeyCode binding;

	// Use this for initialization
	void Start () {
        GetComponent<Button>().onClick.AddListener(ToggleFilter);
	}

    void Update()
    {
        if (binding == KeyCode.None) return;

        if (Input.GetKeyDown(binding))
        {
            ToggleFilter();
        }
    }

    void ToggleFilter()
    {
        foreach(string tag in TagToFilter)
        {
            foreach (GameObject o in GameObject.FindGameObjectsWithTag(tag))
            {
                var renderer = o.GetComponent<SpriteRenderer>();
                renderer.enabled = !renderer.enabled;
            }
        }
    }

    public void DisableFilter()
    {
        foreach (string tag in TagToFilter)
        {
            foreach (GameObject o in GameObject.FindGameObjectsWithTag(tag))
            {
                var renderer = o.GetComponent<SpriteRenderer>();
                renderer.enabled = false;
            }
        }
    }
}
