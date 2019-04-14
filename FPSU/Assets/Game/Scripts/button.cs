using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button : MonoBehaviour
{
    private GameObject pointsNum;

    void Start()
    {
        pointsNum = GameObject.Find("GameManager");
    }

    public void OnClick()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Retry()
    {
        pointsNum.GetComponent<Manager>().points = 0;
        pointsNum.GetComponent<Manager>().traps = 0;
        SceneManager.LoadScene("GameScene");
    }

    public void GoToMenu()
    {
        pointsNum.GetComponent<Manager>().points = 0;
        pointsNum.GetComponent<Manager>().traps = 0;
        SceneManager.LoadScene("IntroScene");
    }

    public void Close()
    {
        Application.Quit();
    }
}
