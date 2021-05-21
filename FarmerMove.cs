using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FarmerMove : MonoBehaviour
{
    public List<Transform> locations;
    public Transform player;

    private NavMeshAgent agent;
    private GameBehavior gameManager;
    private Animator playerAnim;



    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
        gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
        playerAnim = GameObject.Find("TT_demo_male_A").GetComponent<Animator>();
        playerAnim.SetBool("Hit", true);



    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.position);
    }



    private void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "Player")
        {
            playerAnim.SetBool("Hit", true);

        }
        else
        {
            playerAnim.SetBool("Hit", false);

        }
    }
}








