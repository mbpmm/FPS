using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image crosshair;
    public Text pointsText;
    public Slider healthBar;

    private GameObject player;
    private GameObject manager;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        manager= GameObject.Find("GameManager");
        pointsText.text = "Points: " + manager.GetComponent<Manager>().points;
    }

    // Update is called once per frame
    void Update()
    {

        healthBar.value = player.GetComponent<Player>().health;
        if (healthBar.value == 0)
        {
            healthBar.fillRect.gameObject.SetActive(false);
        }

        pointsText.text = "Points: " + manager.GetComponent<Manager>().points;
    }
}
