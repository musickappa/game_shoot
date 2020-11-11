using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LIFEBAR : MonoBehaviour
{
    public int ldescount = 3;
    // Use this for initialization
    void Start()
    {
        //this.gameObject.transform.position = new Vector3(0, 0, 0);
        this.GetComponent<Text>().text = "×" + ldescount;
    }

    // Update is called once per frame
    void Update()
    {
        if (ldescount > 3)
        {
            ldescount = 3;
            this.GetComponent<Text>().text = "×" + ldescount;
        }
        else
        {
            this.GetComponent<Text>().text = "×" + ldescount;
        }

    }
}
