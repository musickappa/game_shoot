using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tigertama : MonoBehaviour
{
    public GameObject player;
    public Vector3 v;
    private float descount = 0;
    private float nextTime;
    public float interval = 1.0f;   // 点滅周期

    //private int descount =  0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<Rigidbody2D>().velocity = v;
        //範囲外で消滅
        if (this.gameObject.transform.position.y < -10)
        {
            Destroy(this.gameObject);
        }


    }


    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.layer);
        //layerの名前
        if (other.gameObject.layer == 10)
        {


            Debug.Log("shokyo");
            Destroy(this.gameObject);


        }
        else if (other.gameObject.layer == 9)
        {





            Debug.Log("shokyo");
            Destroy(this.gameObject);


            //GUI.TextField(new Rect(10, 10, 100, 100), "GameOver");


        }
        else if (other.gameObject.layer == 22)
        {





            Debug.Log("shokyo");
            Destroy(this.gameObject);


            //GUI.TextField(new Rect(10, 10, 100, 100), "GameOver");


        }

    }


}
