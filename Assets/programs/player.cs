using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;




public class player : MonoBehaviour
{
    //移動範囲宣言
    void Clamp()
    {
        player_pos = transform.position; //プレイヤーの位置を取得
        Debug.Log("player");

        player_pos.x = Mathf.Clamp(player_pos.x, -9, 9); //x位置が常に範囲内か監視
        player_pos.y = Mathf.Clamp(player_pos.y, -5, 5); //x位置が常に範囲内か監視
        transform.position = new Vector2(player_pos.x, player_pos.y); //範囲内であれば常にその位置がそのまま入る
    }


    public float speed;
    public GameObject tama1;
    public GameObject tekitama;
    public GameObject GAMEOVER;
    public GameObject mutekitama;
    private GameObject temp;
    private GameObject SPtemp;
    public GameObject life;
    public GameObject zandan;
    public GameObject SPtama;

    //public Slider slider;

    private GameObject SP1;
    private GameObject SP2;
    private GameObject SP3;
    private GameObject SP4;
    private GameObject SP5;
    private GameObject SP6;
    private GameObject SP7;
    private GameObject SP8;
    private GameObject SP9;
    private GameObject SP10;



    //public GameObject player;
    private Vector2 player_pos;
    private float counter;
    public float MaxCount;
    public int descount = 0;
    public float totaldes = 0;
    private float zandansu = 0;
    private int SP;
    //------音---------//
    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip explosionSE;
    //-----------------//
    //-----------------//
    private float nextTime;
    public float interval = 1.0f;   // 点滅周期

    //-----------------//
    //-----------------//
    private float Timecount;
    //public GameObject GAMEOVER;
    //-----------------//
    //-----------------//
    Text text;
    public LIFEBAR lifebar;
    public zandanbar Zandanbar;
    public Text LIFEBAR;
    public Text zandanbar;
    //private StageManager stageManager;
    // Use this for initialization
    void Start () {
        this.gameObject.transform.position = new Vector3(0, 0, 0);
        
        gameObject.GetComponent<AudioSource>().PlayOneShot(sound1);

        text = GetComponentInChildren<Text>();

        StartCoroutine("Blink");
        //Instantiate(life, new Vector3(-3, 5, 0), Quaternion.identity);
        //Instantiate(zandan, new Vector3(-3, 4, 0), Quaternion.identity);

        //slider.maxValue = 3;
        
        lifebar.GetComponent<LIFEBAR>().ldescount++;
        //LIFEBAR.text = "×" + descount ;
        //zandanbar.text = "×" + zandansu;



        /*AudioSource[] audioSources = GetComponents<AudioSource>();
        sound1 = audioSources[0];
        sound2 = audioSources[1];*/


        //--------点滅-------//
        nextTime = Time.time;

	}
    void OnTriggerEnter2D(Collider2D other)
    {
        //descount = 3;
        Debug.Log(other.gameObject.layer);
        //layerの名前
        if (other.gameObject.layer == 8 || other.gameObject.layer == 14 || other.gameObject.layer == 19 || other.gameObject.layer == 20)
        {
            
            //descount--;
            descount++;
            //totaldes = 0;
            
            //gameObject.GetComponent<AudioSource>().PlayOneShot(sound2);
            if (descount == 3)
            {
                // オーディオを再生
                AudioSource.PlayClipAtPoint(explosionSE, transform.position);
                // ミサイルオブジェクトを破棄
                Application.LoadLevel("GAMEOVER");
                //Destroy(gameObject);
                text.text = "GAMEOVER";
                
                //Instantiate(GAMEOVER.gameObject);
                //Application.LoadLevel("GAMEOVER");
                //Instantiate(text);
            }
            //totaldes = descount;
         
            if (lifebar.GetComponent<LIFEBAR>().ldescount > 0)
            {
                lifebar.GetComponent<LIFEBAR>().ldescount--;
            }
            else
            {
                lifebar.GetComponent<LIFEBAR>().ldescount = 0;
            }

        }
        else if (other.gameObject.layer == 17|| other.gameObject.layer == 18)
        {
            descount--;
            lifebar.GetComponent<LIFEBAR>().ldescount++;
            totaldes++;
            if(descount <= 0)
            {
                descount = 0;
            }

            if(totaldes == 5)
            {
                SP++;
                totaldes = 0;
                zandansu++;
                Zandanbar.GetComponent<zandanbar>().zandansu++;
            }
        }

        /*void OnGUI()
        {
            GUI.TextField(new Rect(10, 10, 100, 100), "Nowplaying");

        }*/

    }
    // Update is called once per frame
    void Update()
    {
        /*if (Time.time > nextTime)
        {
            this.gameObject.GetComponent().enabled = !this.gameObject.enabled;

            nextTime += interval;
        }*/
        Timecount += Time.deltaTime;
        if (Timecount > 3)
        {
            //---------------------------------------------------------------------------------------//
            if (Input.GetKey(KeyCode.UpArrow))
            {
                this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.up * speed;
                //Debug.Log(1 + "テスト" + stringValue1);
            }



            else if (Input.GetKey(KeyCode.DownArrow))
            {
                this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.down * speed;
            }



            else if (Input.GetKey(KeyCode.RightArrow))
            {
                this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.right * speed;
            }


            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.left * speed;
            }
            else
            {
                this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            }
            Clamp();
            //---------------------------------------------------------------------------------------//
            //------------------------------------------------------------------//
            /* int count = GameObject.FindGameObjectsWithTag("text").Length;
             scoreLabel.text = count.ToString();*/
            //------------------------------------------------------------------//

            /*/---------------------------範囲移動-----------------------------------//
            if (this.gameObject.transform.position.x > 9.48)
            {
                this.gameObject.transform.position.x = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y,0);
            }
            else if (this.gameObject.transform.position.x < -9.48)
            {

            }
            //----------------------------------------------------------------------/*/
            if (Input.GetKey(KeyCode.Space))
            {
                counter += Time.deltaTime;


                if (MaxCount < counter)
                {
                    //Instantiate(tama1, gameObject.transform.position + Vector3.up * 0.7f, Quaternion.identity);
                    temp = Instantiate(tama1, gameObject.transform.position + Vector3.up * 0.9f, Quaternion.identity);
                    temp.GetComponent<tama1>().v = new Vector3(0, 4, 0);
                    gameObject.GetComponent<AudioSource>().PlayOneShot(sound2);
                    counter = 0;

                }

            }


            if (Input.GetKeyUp(KeyCode.B) && SP>=1)
            {
                //counter += Time.deltaTime;

                temp = Instantiate(SPtama, gameObject.transform.position + Vector3.up * 0.9f, Quaternion.identity);
                temp.GetComponent<SPtama>().v = new Vector3(-1, 0, 0);
                SP--;
                Zandanbar.GetComponent<zandanbar>().zandansu--;
                zandansu--;
                //zandanbar.text = "×" + zandansu;
                if (SP <= 0 || zandansu <= 0)
                {
                    SP = 0;
                    zandansu = 0;
                }

            }
            else if (Input.GetKeyUp(KeyCode.N) && SP >= 1)
            {
                //counter += Time.deltaTime;

                temp = Instantiate(SPtama, gameObject.transform.position + Vector3.up * 0.9f, Quaternion.identity);
                temp.GetComponent<SPtama>().v = new Vector3(1, 0, 0);
                SP--;
                Zandanbar.GetComponent<zandanbar>().zandansu--;
                zandansu--;
                if (SP <= 0 || zandansu <= 0)
                {
                    SP = 0;
                    zandansu = 0;
                }
            }
            else if (Input.GetKeyUp(KeyCode.H) && SP >= 1)
            {
                //counter += Time.deltaTime;

                temp = Instantiate(SPtama, gameObject.transform.position + Vector3.up * 0.9f, Quaternion.identity);
                temp.GetComponent<SPtama>().v = new Vector3(0, 1, 0);
                SP--;
                Zandanbar.GetComponent<zandanbar>().zandansu--;
                zandansu--;
                if (SP <= 0 || zandansu <= 0)
                {
                    SP = 0;
                    zandansu = 0;
                }
            }

            /*else if (Input.GetKeyUp(KeyCode.X))
            {
                int r = 5;
                //Instantiate(tama1, gameObject.transform.position + Vector3.up * 0.7f, Quaternion.identity);
                SP1 = Instantiate(tama1, gameObject.transform.position + new Vector3(r * cos(0), r * sin(0), 0) * 0.7f, Quaternion.identity);
                SP2 = Instantiate(tama1, gameObject.transform.position + new Vector3(r * cos(30), r * sin(30), 0) * 0.7f, Quaternion.identity);
                SP3 = Instantiate(tama1, gameObject.transform.position + new Vector3(r * cos(60), r * sin(60), 0) * 0.7f, Quaternion.identity);
                SP4 = Instantiate(tama1, gameObject.transform.position + new Vector3(r * cos(90), r * sin(90), 0) * 0.7f, Quaternion.identity);
                SP5 = Instantiate(tama1, gameObject.transform.position + new Vector3(r * cos(120), r * sin(120), 0) * 0.7f, Quaternion.identity);
                SP6 = Instantiate(tama1, gameObject.transform.position + new Vector3(r * cos(150), r * sin(150), 0) * 0.7f, Quaternion.identity);
                SP7 = Instantiate(tama1, gameObject.transform.position + new Vector3(r * cos(15), r * sin(15), 0) * 0.7f, Quaternion.identity);
                SP8 = Instantiate(tama1, gameObject.transform.position + new Vector3(r * cos(45), r * sin(45), 0) * 0.7f, Quaternion.identity);
                SP9 = Instantiate(tama1, gameObject.transform.position + new Vector3(r * cos(135), r * sin(135), 0) * 0.7f, Quaternion.identity);
                SP10 = Instantiate(tama1, gameObject.transform.position + new Vector3(r * cos(165), r * sin(165), 0) * 0.7f, Quaternion.identity);

                SP1.GetComponent<tama1>().v = new Vector3(1, 1, 0);
                SP2.GetComponent<tama1>().v = new Vector3(5, 1, 0);
                SP3.GetComponent<tama1>().v = new Vector3(10, 1, 0);
                SP4.GetComponent<tama1>().v = new Vector3(15 ,1, 0);
                SP5.GetComponent<tama1>().v = new Vector3(20,1, 0);
                SP6.GetComponent<tama1>().v = new Vector3(-1,1, 0);
                SP7.GetComponent<tama1>().v = new Vector3(-5, 1, 0);
                SP8.GetComponent<tama1>().v = new Vector3(-10, 1, 0);
                SP9.GetComponent<tama1>().v = new Vector3(-15, 1, 0);
                SP10.GetComponent<tama1>().v = new Vector3(-20, 1, 0);
                //gameObject.GetComponent<AudioSource>().PlayOneShot(sound2);
                //counter += Time.deltaTime;


                if (counter>3)
                {

                    //counter = 0;
                    Destroy(mutekitama.gameObject);
                }

            }
            /*if (Input.GetKey(KeyCode.Space))
            {
                Debug.Log("MUSIC");



            }*/



        }
    }

    private int sin(int v)
    {
        throw new NotImplementedException();
    }

    private int sin()
    {
        throw new NotImplementedException();
    }

    private int cos(int v)
    {
        throw new NotImplementedException();
    }
}

