using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tekiright : MonoBehaviour
{
    public GameObject tigertama;
    public GameObject heal;
    public Slider slider;
    private float descount;
    public float speed;
    private float count;
    private float hcount;
    private float Timecount;
    private float oldSeconds;
    private float Seconds;
    private Text timerText;
    public float MaxCount;
    public float HEALcount;
    public AudioClip sound2;
    public AudioClip explosionSE;
    float time;
    //private float descount = 0;
    private GameObject temp;
    private GameObject htemp;
    // Use this for initialization
    void Start()
    {
        this.gameObject.transform.position = new Vector3(7, 0, 0);
        //this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.left * speed;

        oldSeconds = 0f;
        Seconds = 0f;
        timerText = GetComponentInChildren<Text>();
        //this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.up * speed;
        slider.maxValue = 30;
    }

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;




        //範囲移動--------------------------------------------------------
        /*if (this.gameObject.transform.position.y > 5)
        {
            this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.down * speed;
        }
        else if (this.gameObject.transform.position.y < -5)
        {
            this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.up * speed;
        }*/



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
        if (time > 3)
        {
            count += Time.deltaTime;
            hcount += Time.deltaTime;


            if (MaxCount < count)
            {
                temp = Instantiate(tigertama, gameObject.transform.position, Quaternion.identity);
                temp.GetComponent<tigertama>().v = new Vector3(UnityEngine.Random.Range(-10, -1), UnityEngine.Random.Range(-6, 6), 0);
                count = 0;
            }

            if (HEALcount < hcount)
            {
                htemp = Instantiate(heal, gameObject.transform.position, Quaternion.identity);
                htemp.GetComponent<heal>().v = new Vector3(UnityEngine.Random.Range(-10, -1), UnityEngine.Random.Range(-6, 6), 0);
                hcount = 0;
            }
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.layer);
        //layerの名前
        if (other.gameObject.layer == 17)
        {

            descount++;
            slider.value = slider.maxValue - descount;
            //totaldes = 0;

            //gameObject.GetComponent<AudioSource>().PlayOneShot(sound2);
            if (descount == slider.maxValue)
            {
                Application.LoadLevel("BeforeROUND3ryuu");
                // オーディオを再生
                AudioSource.PlayClipAtPoint(explosionSE, transform.position);
                // ミサイルオブジェクトを破棄
                Application.LoadLevel("GAMEOVER");
                //Destroy(gameObject);
                //text.text = "GAMEOVER";
                Application.LoadLevel("TEST");
                //Instantiate(GAMEOVER.gameObject);
                //Application.LoadLevel("GAMEOVER");
                //Instantiate(text);
            }
            //totaldes = descount;


        }
        else if(other.gameObject.layer == 23)
        {
            descount = descount+5;
            slider.value = slider.maxValue - descount;
            //totaldes = 0;

            //gameObject.GetComponent<AudioSource>().PlayOneShot(sound2);
            if (descount > slider.maxValue)
            {
                Application.LoadLevel("BeforeROUND3ryuu");
                // オーディオを再生
                AudioSource.PlayClipAtPoint(explosionSE, transform.position);
                // ミサイルオブジェクトを破棄
                Application.LoadLevel("GAMEOVER");
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