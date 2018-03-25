using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrival : MonoBehaviour {

    [Tooltip("Text to display when finished")]
    public GameObject FinalText;

    [Tooltip("Button to use to go to the menu")]
    public GameObject MenuButton;

    public string WinningText;

	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (FinalText != null)
            FinalText.GetComponent<ProgressiveText>().ShowText(WinningText, 1, () =>
            {
                MenuButton.GetComponentInChildren<ProgressiveText>().ShowText("> Menu", 0.2f);
            });

    }
}
