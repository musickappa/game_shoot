using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enablelight : MonoBehaviour
{
    private Light player;


    void Start()
    {
        //player = GetComponent();
    }


    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            player.enabled = !player.enabled;
        }
    }
}
