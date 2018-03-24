using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gotothis : MonoBehaviour
{
    public void Start()
    {
        GetComponent<Button>().onClick.AddListener(GoToJouer);
    }
    public void GoToJouer()
    {
        SceneManager.LoadScene("Cards Menu");
    }
}