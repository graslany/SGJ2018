using UnityEngine;
using System.Collections;

public class Crashsound : MonoBehaviour
{

    public AudioClip crashSoft;

    private AudioSource source;
    private float lowPitchRange = .75F;
    private float highPitchRange = 1.5F;
    private float velToVol = .2F;
    private float velocityClipSplit = 10F;


    void Awake()
    {

        source = GetComponent<AudioSource>();
    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("Sound play");
        source.pitch = Random.Range(lowPitchRange, highPitchRange);
        float hitVol = coll.relativeVelocity.magnitude * velToVol;
        source.PlayOneShot(crashSoft, hitVol);
    }

}