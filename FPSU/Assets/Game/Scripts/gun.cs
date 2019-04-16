using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gun : MonoBehaviour
{
    public LayerMask rayCastLayer;
    public float rayDistance;
    public Image crosshair;
    public Text pointsText;

    private GameObject manager;
    private GameObject Player;
    private int trapPoints;
    private int ghostPoints;
    // Start is called before the first frame update
    void Start()
    {
        trapPoints = 100;
        ghostPoints = 200;
        manager = GameObject.Find("GameManager");
        pointsText.text = "Points: " + manager.GetComponent<Manager>().points;
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, Vector3.left * 20, Color.red);

        if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance, rayCastLayer))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.yellow);

            string layerHitted = LayerMask.LayerToName(hit.transform.gameObject.layer);

            if (Player.GetComponent<Player>().Gun==global::Player.GunEquipped.TrapGun)
            {
                switch (layerHitted)
                {
                    case "trampas":
                        crosshair.color = Color.red;
                        if (Input.GetMouseButton(0))
                        {
                            hit.transform.gameObject.SetActive(false);
                            manager.GetComponent<Manager>().points += trapPoints;
                            manager.GetComponent<Manager>().traps++;
                        }
                        break;
                }
            }
            else if(Player.GetComponent<Player>().Gun == global::Player.GunEquipped.GhostGun)
            {
                switch (layerHitted)
                {
                    case "fantasmas":
                        crosshair.color = Color.red;
                        if (Input.GetMouseButton(0))
                        {
                            hit.transform.gameObject.SetActive(false);
                            manager.GetComponent<Manager>().points += ghostPoints;
                            manager.GetComponent<Manager>().ghosts++;
                        }
                        break;
                }
            }
            
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.white);
            crosshair.color = Color.green;
        }

        pointsText.text = "Points: " + manager.GetComponent<Manager>().points;
    }
}
