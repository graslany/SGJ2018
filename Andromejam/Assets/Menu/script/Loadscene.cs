using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loadscene : MonoBehaviour
{
    public void Start()
    {
        GetComponent<Button>().onClick.AddListener(GoToJouer);
    }
    public void GoToJouer()
    {
        SceneManager.LoadScene("Platformer/Animation test/Animation test");
    }
}