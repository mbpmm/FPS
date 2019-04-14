using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public int points;
    public int traps;

    private static Manager instance;

    public static Manager Get()
    {
        return instance;
    }

    private void Awake()
    {
        points = 0;
        traps = 0;
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
