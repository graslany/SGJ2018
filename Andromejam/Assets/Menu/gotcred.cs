using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gotcred : MonoBehaviour
{
    public void Start()
    {
        GetComponent<Button>().onClick.AddListener(GoToCred);
    }
    public void GoToCred()
    {
        SceneManager.LoadScene("Credits2");
    }
}