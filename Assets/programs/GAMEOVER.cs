using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GAMEOVER : MonoBehaviour {
    public GameObject player;
    public GameObject obj;
    public AudioClip gameover;
    public float descount;
    void Start()
    {
        //Destroy(this.gameObject);
        this.GetComponent<AudioSource>().PlayOneShot(gameover);
    }




    public Text gameOver;
    bool gameOverFlag;

    void Update()
    {

        
            //Instantiate(obj, this.transform.position, Quaternion.identity);
        
            if (gameOverFlag && Input.GetMouseButtonDown(0))
            {
                Application.LoadLevel("title");
            }
        

    }
    public void ButtonPush()
    {
 //       gameOver.SendMessage("Lose");
        gameOverFlag = true;
    }


}