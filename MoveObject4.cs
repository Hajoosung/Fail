using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MoveObject4 : MonoBehaviour
{

    public float speed = 3.0f;
    public float rotspeed = 80.0f;

    public GameObject bullet;
    public float bulletspeed = 80.0f;


    private Rigidbody rigidbody;
    private GameBehavior gameManager;


    private float hInput;
    private float vInput;
    private CapsuleCollider playereCollider;
    private Animator playerAnim;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        playereCollider = GetComponent<CapsuleCollider>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
        playerAnim = GameObject.Find("TT_ww1_demo_british_A").GetComponent<Animator>();
        playerAnim.SetBool("Run", true);
        playerAnim.SetBool("Shoot", true);


    }



    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        hInput = h * rotspeed;
        vInput = v * speed;

       
        if(Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Instantiate(bullet, transform.position + transform.forward, transform.rotation) as GameObject;
            Rigidbody rbBullet = newBullet.GetComponent<Rigidbody>();
            rbBullet.velocity = transform.forward * bulletspeed;

            playerAnim.SetBool("Shoot", true);


        }
        else
        {
            playerAnim.SetBool("Shoot", false);
        }
    }

        void FixedUpdate()
    {
        hInput = hInput * Time.fixedDeltaTime;
        vInput = vInput * Time.fixedDeltaTime;

        Vector3 rotation = Vector3.up * hInput;
        Quaternion angleRot = Quaternion.Euler(rotation);


        rigidbody.MovePosition(transform.position + transform.forward * vInput);
        rigidbody.MoveRotation(rigidbody.rotation * angleRot);

        if (vInput > 0.01f || vInput < -0.01f )
        {
            playerAnim.SetBool("Run", true);

        }
        else
        {
            playerAnim.SetBool("Run", false);
        }


    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            gameManager.HP -= 1; // gameManager.HP = gameManager.HP - 1;
        }

        
        if (collision.gameObject.name == "Farmer" )
        {
            SceneManager.LoadScene("SampleScene");
        }
        
    }
}






