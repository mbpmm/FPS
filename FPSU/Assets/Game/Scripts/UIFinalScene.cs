﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIFinalScene : MonoBehaviour
{
    public Text points;
    public Text trapsDestroyed;
    public Text ghostKilled;
    private GameObject pointsNum;

    // Start is called before the first frame update
    void Start()
    {
        pointsNum = GameObject.Find("GameManager");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        points.text = "Points: " + pointsNum.GetComponent<Manager>().points;
        trapsDestroyed.text = "Traps Destroyed: " + pointsNum.GetComponent<Manager>().traps;
        ghostKilled.text = "Ghost killed: " + pointsNum.GetComponent<Manager>().ghosts;
    }
}
