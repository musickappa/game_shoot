using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class teki2 : MonoBehaviour
{
    public GameObject tekitama;
    public float speed;
    private float count;
    private float Timecount;
    private float oldSeconds;
    private float Seconds;
    private Text timerText;
    public float MaxCount;
    public AudioClip sound2;
    public AudioClip explosionSE;
    float time;
    //private float descount = 0;
    private GameObject temp;
    // Use this for initialization
    void Start()
    {
        this.gameObject.transform.position = new Vector3(0, 4, 0);
        //this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.left * speed;

        oldSeconds = 0f;
        Seconds = 0f;
        timerText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;
        if (time > 3)
        {
            this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.left * speed;


            //範囲移動--------------------------------------------------------
            if (this.gameObject.transform.position.x > 9.48)
            {
                this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.left * speed;
            }
            else if (this.gameObject.transform.position.x < -9.48)
            {
                this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.right * speed;
            }



            if (this.gameObject.transform.position.y > 7 || this.gameObject.transform.position.x > Mathf.Abs(12))
            {
                // オーディオを再生
                AudioSource.PlayClipAtPoint(explosionSE, transform.position);
                // ミサイルオブジェクトを破棄
                Destroy(gameObject);
                // Instantiate(this.gameObject);
                // Instantiate(this.gameObject);

            }

            /*if (this.gameObject.transform.position.y > 7 || this.gameObject.transform.position.x > Mathf.Abs(12))
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(sound2);
            }*/
            //-----------------------------------------------------------------

            //Timecount += Time.deltaTime;
            //敵から出力


            count += Time.deltaTime;

            if (MaxCount < count)
            {
                temp = Instantiate(tekitama, gameObject.transform.position, Quaternion.identity);
                temp.GetComponent<tekitama>().v = new Vector3(UnityEngine.Random.Range(-10, 10), -4, 0);
                count = 0;
            }


        }
    }


}