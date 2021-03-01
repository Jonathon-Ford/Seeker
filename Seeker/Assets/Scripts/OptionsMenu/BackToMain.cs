using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMain : MonoBehaviour
{
    public void GoToMain()
    {
        Debug.Log("in gotomain function");
        SceneManager.LoadScene("MainMenu");
    }
}
