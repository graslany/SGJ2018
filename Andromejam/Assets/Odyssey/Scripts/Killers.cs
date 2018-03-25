using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killers : MonoBehaviour {

    //Todo : replace with more compelx structure to give information at death
    public string[] KillerTags;

    public GameObject GameOverText;

    public GameObject RetryButton;

    public GameObject MenuButton;

    public string DefaultDeathMessage = "Tu es mort";
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach(string kt in KillerTags)
        {
            if (collision.gameObject.CompareTag(kt))
            {
                gameObject.SetActive(false);
                DeathMessage dm = collision.gameObject.GetComponent<DeathMessage>();
                string msg = dm == null ? DefaultDeathMessage : dm.message;

                GameOverText.GetComponent<ProgressiveText>().ShowText(msg, 1, () => {
                        RetryButton.GetComponentInChildren<ProgressiveText>().ShowText("> Rejouer", 0.5f, () =>
                        {
                            MenuButton.GetComponentInChildren<ProgressiveText>().ShowText("> Menu", 0.5f);
                        });
                });


                return;
            }
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}