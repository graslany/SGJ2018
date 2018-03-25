using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilterAffector : MonoBehaviour {

    public string[] TagToFilter;

    public KeyCode binding;

    public Sprite EnabledSprite;

    public Sprite DisabledSprite;

    public bool Enabled = true;

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
        Enabled = !Enabled;
        UpdateTargets();
        Sprite nwSprite = Enabled ? EnabledSprite : DisabledSprite;
        GetComponent<Button>().image.sprite = nwSprite;
    }

    private void UpdateTargets()
    {
        foreach (string tag in TagToFilter)
        {
            foreach (GameObject o in GameObject.FindGameObjectsWithTag(tag))
            {
                var renderer = o.GetComponent<SpriteRenderer>();
                renderer.enabled = Enabled;
            }
        }
    }

    public void DisableFilter()
    {
        Enabled = false;
        UpdateTargets();
        GetComponent<Button>().image.sprite = DisabledSprite;
    }
}
