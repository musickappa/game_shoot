using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tamaboss : MonoBehaviour
{
    public float speed;
    public float descount = 0;
    public Vector3 v;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //ここでおかしくなっている球が動かない理由 
        this.gameObject.GetComponent<Rigidbody2D>().velocity = v;
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
        if (other.gameObject.layer == 8 || other.gameObject.layer == 24 || other.gameObject.layer == 10)
        {

            //  Debug.Log("kannryou");
            Destroy(this.gameObject);


        }
    }
}
