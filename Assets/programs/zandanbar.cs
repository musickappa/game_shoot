using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zandanbar : MonoBehaviour
{
    public int zandansu = 0;
    // Use this for initialization
    void Start()
    {
        //this.gameObject.transform.position = new Vector3(0, 0, 0);
        this.GetComponent<Text>().text = "×" + zandansu;
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Text>().text = "×" + zandansu;
        /*
        if (zandansu < 0)
        {
            zandansu = 0;
            this.GetComponent<Text>().text = "×" + zandansu;
        }
        else
        {
            this.GetComponent<Text>().text = "×" + zandansu;
        }
        */
    }
}
