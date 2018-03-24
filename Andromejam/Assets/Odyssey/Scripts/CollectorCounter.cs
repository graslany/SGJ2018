using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectorCounter : MonoBehaviour {

    [Tooltip("Format du texte utiliser ")]
    public string ScoreFormat;

    [Tooltip("Valeur totale")]
    public int TotalValue;

    [Tooltip("Valeur de démarage du compteur")]
    public int startingValue;

    private int currentValue;

    private Text target;

    private void Start()
    {
        target = GetComponent<Text>();
        currentValue = startingValue;
        UpdateText();
    }

    public void Increment()
    {
        currentValue++;
        UpdateText();
    }

    public void Decrement()
    {
        currentValue--;
        UpdateText();
    }

    private void UpdateText()
    {
        string txt = ScoreFormat.Replace("${Total}", "" + TotalValue)
                                .Replace("${Current}", "" + currentValue);
        target.text = txt;
    }

}
