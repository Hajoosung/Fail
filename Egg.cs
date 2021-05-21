using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour



{

    private GameBehavior gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {

            Destroy(gameObject);



            gameManager.Score = gameManager.Score + 1;




        }

    }
}