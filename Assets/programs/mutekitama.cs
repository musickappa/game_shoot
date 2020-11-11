using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mutekitama : MonoBehaviour {
    public float speedmuteki;
    public float descount = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0) * speedmuteki;
        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(1, 1, 0) * speedmuteki;
        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(-1, 1, 0) * speedmuteki;
        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(2, 1, 0) * speedmuteki;
        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(-2, 1, 0) * speedmuteki;
        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(3, 1, 0) * speedmuteki;
        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(-3, 1, 0) * speedmuteki;
        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(4, 1, 0) * speedmuteki;
        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(-4, 1, 0) * speedmuteki;
        //範囲外で消滅
        if (this.gameObject.transform.position.y > 7)
        {
            Destroy(this.gameObject);
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.layer);
        //layerの名前
        if (other.gameObject.layer == 8)
        {

            //  Debug.Log("kannryou");
            Destroy(this.gameObject);


        }
    }
}
