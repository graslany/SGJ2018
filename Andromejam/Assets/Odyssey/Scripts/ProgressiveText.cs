using System.Collections;
using System.Collections.Generic;
using System;
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

    private Action onFinished;

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

    public void Clear()
    {
        currentText = "";
        text.text = currentText;

        Button btn = GetComponentInParent<Button>();
        if(btn != null)
        {
            btn.interactable = false;
        }
    }

    public void ShowText(string text, float apearDuration, Action finishCallback = null)
    {
        TargetText = text;
        currentText = "";
        timePerChar = apearDuration / text.Length;
        nextCharTimer = timePerChar;
        onFinished = finishCallback;
        running = true;

        Button btn = GetComponentInParent<Button>();
        if(btn != null)
        {
            btn.interactable = true;
        }
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

            if (!running && onFinished != null)
            {
                onFinished();
            }
        }
	}

    public void Run()
    {
        running = true;
    }
}
