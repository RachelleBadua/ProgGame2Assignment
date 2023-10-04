using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void OnGameStart()
    {
        GameManager.Instance.ResetTotalScore();
        SceneManager.LoadScene("Level1");
    }

    public void OnGameExit()
    {
        Application.Quit();
    }
}
