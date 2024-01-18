using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dogleft : MonoBehaviour
{
    private float speed = 30;
    private Playerscript player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Playerscript>();
    }

    // Update is called once per frame
    void Update()
    {
        //to make player move left
        if (!player.gameover)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        //to destroy out of screen dog
        if(transform.position.x<-10){
            Destroy(gameObject);
            player.Scorecard+=5;
            player.Score.text="Score:"+player.Scorecard;
        }
    }
}
