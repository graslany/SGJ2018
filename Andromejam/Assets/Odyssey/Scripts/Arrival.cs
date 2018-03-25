using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrival : MonoBehaviour {

    [Tooltip("Text to display when finished")]
    public GameObject FinalText;

    [Tooltip("Button to use to go to the menu")]
    public GameObject MenuButton;


    public string WinningText;

    private bool IsNetActive = false;

    private bool IsInCloud = false;

	// Use this for initialization
	void Start () {
		
	}

    public void SetNetActive(bool active)
    {
        IsNetActive = active;
        if (IsNetActive)
        {
            CheckForWin();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Spaceship"))
        {
            IsInCloud = true;
            CheckForWin();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Spaceship"))
        {
            IsInCloud = false;
        }
    }

    private void CheckForWin()
    {
        if (Won())
        {
            FinalText.GetComponent<ProgressiveText>().ShowText(WinningText, 1, () =>
            {
                MenuButton.GetComponentInChildren<ProgressiveText>().ShowText("> Menu", 0.2f);
            });
        }

    }

    private bool Won()
    {
        return GetComponent<SpriteRenderer>().enabled &&
            IsNetActive &&
            IsInCloud;
    }
}
