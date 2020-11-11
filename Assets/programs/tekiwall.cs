using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class tekiwall : MonoBehaviour {
    public Slider slider;
    private float descount;
    // Use this for initialization
    void Start () {
        //this.gameObject.transform.position = new Vector3(-7, 0, 0);
        slider.maxValue = 10;
	}
	
	// Update is called once per frame
	void Update () {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.layer);
        //layerの名前
        if (other.gameObject.layer == 15)
        {
            descount++;
            if (descount == 10)
            {
                Debug.Log("shokyo");
                Destroy(this.gameObject);
            }

        }
        /*else if (other.gameObject.layer == 9)
        {





            Debug.Log("shokyo");
            Destroy(this.gameObject);


            //GUI.TextField(new Rect(10, 10, 100, 100), "GameOver");


        }*/
    }
}
