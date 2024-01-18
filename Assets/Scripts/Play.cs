using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
    private Button button;
    public GameObject titlescreen;
    private Spawnmange spawnscript;
    public Button Jumpbutton;
    // Start is called before the first frame update
    void Start()
    {
        button=GetComponent<Button>();
        spawnscript=GameObject.Find("Spawnmanager").GetComponent<Spawnmange>();
        button.onClick.AddListener(play);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void play(){
        spawnscript.StartGame();
        titlescreen.SetActive(false);
        Jumpbutton.gameObject.SetActive(true);
    }
}
