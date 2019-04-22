using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public LayerMask rayCastLayer;
    public float rayDistance;

    private GameObject manager;
    private GameObject Player;
    private GameObject UIMan;
    private int trapPoints;
    private int ghostPoints;
    private int gunDamage;
    // Start is called before the first frame update
    void Start()
    {
        gunDamage = 10;
        trapPoints = 100;
        ghostPoints = 200;
        manager = GameObject.Find("GameManager");
        UIMan = GameObject.Find("Canvas");
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
                        UIMan.GetComponent<UIManager>().crosshair.color = Color.red;
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
                        UIMan.GetComponent<UIManager>().crosshair.color = Color.red;
                        if (Input.GetMouseButtonDown(0))
                        {
                            hit.transform.gameObject.GetComponent<fantasma>().health= hit.transform.gameObject.GetComponent<fantasma>().health-gunDamage;
                            if (hit.transform.gameObject.GetComponent<fantasma>().health==0)
                            {
                                manager.GetComponent<Manager>().points += ghostPoints;
                                manager.GetComponent<Manager>().ghosts++;
                            }
                        }
                        break;
                }
            }
            
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.white);
            UIMan.GetComponent<UIManager>().crosshair.color = Color.green;
        }
    }
}
