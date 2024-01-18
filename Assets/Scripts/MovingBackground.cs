using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MovingBackground : MonoBehaviour
{
    private float movespeed = 30;
    private Vector3 Backgroundpos;
    private Playerscript player;
    private Spawnmange spawnscript;
    // Start is called before the first frame update
    void Start()
    {
        Backgroundpos = transform.position;
        player = GameObject.Find("Player").GetComponent<Playerscript>();
        spawnscript=GameObject.Find("Spawnmanager").GetComponent<Spawnmange>();
    
    }

    // Update is called once per frame
    void Update()
    {
        //to move background
        if (!player.gameover&&spawnscript.Playing)
        {
            transform.Translate(Vector3.left * movespeed * Time.deltaTime);
        }
        //to reposition background to orignal position
        if (transform.position.x <= Backgroundpos.x - 40)
        {
            transform.position = Backgroundpos;
        }
    }
}
