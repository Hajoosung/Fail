using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChickenDestroy : MonoBehaviour
{
    public GameObject target;
    public Transform spawnPost;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "bullet(Clone)")
        {
            Destroy(gameObject);
            Instantiate(target, spawnPost.position, spawnPost.rotation);

            
        }

    }
}