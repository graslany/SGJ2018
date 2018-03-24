using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuitOnClick : MonoBehaviour
{
    public void Start()
    {
        GetComponent<Button>().onClick.AddListener(Quit);
    }
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }

}