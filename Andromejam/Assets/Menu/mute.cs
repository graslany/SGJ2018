using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mute : MonoBehaviour
{

    private bool ismuted = false;
    private float Volume;
    private Sprite mutedImage;
    private Sprite unmutedImage;

    private void Start()
    {
        mutedImage = Resources.Load<Sprite>("sound-off");
        unmutedImage = Resources.Load<Sprite>("sound");
        GetComponent<Button>().onClick.AddListener(Mute);
    }

    void Mute()
    {
        if (ismuted)
        {
            GetComponent<Button>().image.sprite = unmutedImage;
            AudioListener.volume = Volume;
            ismuted = false;
        }
        else
        {
            GetComponent<Button>().image.sprite = mutedImage;
            Volume = AudioListener.volume;
            AudioListener.volume = 0;
            ismuted = true;
        }
    }
}
