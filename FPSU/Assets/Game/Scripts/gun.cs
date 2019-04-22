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
    public GameObject bala;

    private GameObject manager;
    private GameObject Player;
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
                        if (Input.GetMouseButtonDown(0))
                        {
                            GameObject gun = GameObject.Find("Bala");
                            GameObject balas= Instantiate(bala,gun.transform.position, Quaternion.identity);
                            balas.AddComponent<Rigidbody>();
                            balas.GetComponent<Rigidbody>().AddForce(transform.forward*1500.0f);
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
            crosshair.color = Color.green;
        }

        pointsText.text = "Points: " + manager.GetComponent<Manager>().points;
    }
}
