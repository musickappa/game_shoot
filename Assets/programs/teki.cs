using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class teki : MonoBehaviour
{
    public GameObject tekitama;
    public Slider slider;
    public float descount;
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
        this.gameObject.transform.position = new Vector3(0, 3, 0);
        this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.left * 3;
        oldSeconds = 0f;
        Seconds = 0f;
        timerText = GetComponentInChildren<Text>();
        slider.maxValue = 10;
        //GameObject.Find("SliderCanvas").transform.LookAt(GameObject.Find("teki"));
    }

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;

        if (time > 3)
        {
            //this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.left * speed;




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
                Application.LoadLevel("BeforeROUND2");
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
                temp.GetComponent<tekitama>().v = new Vector3(UnityEngine.Random.Range(-10, 10), UnityEngine.Random.Range(-10, 2), 0);
                count = 0;
            }


        }
    }




    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.layer);
        //layerの名前
        if (other.gameObject.layer == 10)
        {

            descount++;
            slider.value--;
            //totaldes = 0;

            //gameObject.GetComponent<AudioSource>().PlayOneShot(sound2);
            if (descount == 10)
            {
                Application.LoadLevel("BeforeROUND2");
                // オーディオを再生
                AudioSource.PlayClipAtPoint(explosionSE, transform.position);
                // ミサイルオブジェクトを破棄

                //Destroy(gameObject);
                //text.text = "GAMEOVER";
                Application.LoadLevel("TEST");
                //Instantiate(GAMEOVER.gameObject);
                //Application.LoadLevel("GAMEOVER");
                //Instantiate(text);
            }
            //totaldes = descount;
        }



    }
}