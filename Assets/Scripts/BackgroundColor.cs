using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColor : MonoBehaviour
{
    [SerializeField] private int hour;
    
    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        hour = System.DateTime.Now.Hour;
        Color color = Color.white;

        if (hour >= 6 && hour < 12)
        {
            color = Color.yellow;
        }
        else if (hour >= 12 && hour < 18)
        {
            color = Color.blue;
        }
        else if (hour >= 18 && hour < 21)
        {
            color = Color.red;
        }
        else
        {
            color = Color.black;
        }

        cam.backgroundColor = color;
    }
}
