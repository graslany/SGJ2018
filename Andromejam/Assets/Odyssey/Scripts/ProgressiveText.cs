using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressiveText : MonoBehaviour {


    [Tooltip("Text final à afficher")]
    public string TargetText;

    [Tooltip("Temps pour afficher tout le texte")]
    public float DisplayTime;

    [Tooltip("Do I start when awaked ?")]
    public bool StartOnAwake = true;

    private string currentText = "";
    private float timePerChar;

    private float nextCharTimer;

    private Text text;

    private bool running;

	// Use this for initialization
	void Start () {
        timePerChar = DisplayTime / TargetText.Length;
        nextCharTimer = timePerChar;
        text = GetComponent<Text>();
	}

    void Awake()
    {
        running = StartOnAwake;
    }
	
	// Update is called once per frame
	void Update () {
        if (!running) return;

        nextCharTimer -= Time.deltaTime;
        if(nextCharTimer <= 0)
        {
            nextCharTimer = timePerChar;
            currentText += TargetText[currentText.Length];
            text.text = currentText;
            running = currentText.Length != TargetText.Length;
        }
	}

    public void Run()
    {
        running = true;
    }
}
