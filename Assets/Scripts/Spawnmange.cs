
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnmange : MonoBehaviour
{
    private Vector3 spawnpos;
    private Playerscript player;
    public GameObject dog;
    public bool Playing=false;

    // Start is called before the first frame update
    public void StartGame()
    {
        player = GameObject.Find("Player").GetComponent<Playerscript>();
        //spawn dog
        spawnpos = new Vector3(30, -0.6f, 0);
        Playing=true;
        player.Score.gameObject.SetActive(true);
        StartCoroutine(Spawn());

    }
    IEnumerator Spawn()
    {
        while (!player.gameover)
        {
            yield return new WaitForSeconds(Random.Range(2, 4));
            Instantiate(dog, spawnpos, dog.transform.rotation);
        }
    }
}
