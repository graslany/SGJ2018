﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cred : MonoBehaviour
{
    public void Start()
    {
        GetComponent<Button>().onClick.AddListener(GoToCred);
    }
    public void GoToCred()
    {
        SceneManager.LoadScene("Credits");
    }
}