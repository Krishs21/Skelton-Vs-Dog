using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Playerscript : MonoBehaviour
{
    private Vector3 Playerpos;
    private float xpos;
    private float gravitymodifier = 3;
    private float jumpforce = 400;
    private bool onground = true;
    public bool gameover = false;
    private Rigidbody playerrb;
    private Animator playeranim;
    private Animator doganim;
    public GameObject dog;
    public TextMeshProUGUI gameovertext;
    public Button Restart;
    private Spawnmange spawnscript;
    public AudioClip Bark;
    public int Scorecard=0;
    public TextMeshProUGUI Score;
    private AudioSource Cameraman;
    public Button jumpbutton;
    // Start is called before the first frame update
    void Start()
    {
        xpos = transform.position.x;
        playerrb = GetComponent<Rigidbody>();
        Physics.gravity *= gravitymodifier;
        playeranim = GetComponent<Animator>();
        doganim = dog.GetComponent<Animator>();
        spawnscript = GameObject.Find("Spawnmanager").GetComponent<Spawnmange>();
        Cameraman=GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnscript.Playing&&!gameover)
        {
            playeranim.SetFloat("Vertical", 0.2f);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        //to check player is on ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            onground = true;
        }
        //to check collision with dog
        if (collision.gameObject.CompareTag("Dog"))
        {
            gameover = true;
            gameovertext.gameObject.SetActive(true);
            Restart.gameObject.SetActive(true);
            doganim.SetBool("Gameover", true);
            playeranim.SetFloat("Vertical", 0);
            playeranim.SetTrigger("knockdown");
            Cameraman.Stop();
            Cameraman.PlayOneShot(Bark,1.0f);
            jumpbutton.gameObject.SetActive(false);
        }
    }
    //to quit game
    public void quit()
    {
        Application.Quit();
    }
    public void jump(){
        //to make player jump
            if (!gameover&&onground)
            {
                playerrb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
                onground = false;
                playeranim.SetTrigger("jump");
            }
    }
}
