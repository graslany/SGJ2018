using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cred : MonoBehaviour
{
    public void Start()
    {
        Debug.Log("Start");
        GetComponent<Button>().onClick.AddListener(GoToCred);
    }
    public void GoToCred()
    {
        Debug.Log("Lo");
        SceneManager.LoadScene("Credits");
    }
}