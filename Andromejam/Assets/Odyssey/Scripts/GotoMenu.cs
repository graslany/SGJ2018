using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GotoMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Button>().onClick.AddListener(ApplyAction);
	}

    void ApplyAction()
    {
        SceneManager.LoadScene("re");
    }

}
