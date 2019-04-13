using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScene : MonoBehaviour
{
    public GameObject player;
    public Text points;
    public Text traps;
    void Awake()
    {
        player = GameObject.Find("Player");
        gun script = player.GetComponent<gun>();
        points.text = script.pointsText.text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
