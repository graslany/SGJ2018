﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilterAffector : MonoBehaviour {

    public string TagToFilter;

    public KeyCode binding;

	// Use this for initialization
	void Start () {
        GetComponent<Button>().onClick.AddListener(ApplyFilter);
	}

    void Update()
    {
        if (binding == KeyCode.None) return;

        if (Input.GetKeyDown(binding))
        {
            ApplyFilter();
        }
    }

    void ApplyFilter()
    {
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag(TagToFilter);
        
        foreach(GameObject o in allObjects)
        {
            var renderer = o.GetComponent<SpriteRenderer>();
            renderer.enabled = !renderer.enabled;
        }
    }
}
