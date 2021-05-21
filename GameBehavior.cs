using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{
    public string labelText = "닭을 잡아 계란후라이 10개를 모아주세요. 다만 닭에 닿지 않게 주의하세요!";

    public bool showWindow = false;
    public bool showLoseWindow = false;
    public bool showScoreWindow = false;

    public GameObject Farmer;
    public GameObject ParticleSystem;
    public GameObject Exit;
    public GameObject Exit2;






    private int playerHP = 3;

    public int HP
    {
        get { return playerHP; }
        set
        {
            playerHP = value;
            Debug.LogFormat("HP: {0}", playerHP);

            if (playerHP <= 0)
            {
                labelText = "                                                으앙 쥬금";
                showLoseWindow = true;

            }
        }
    }

    private int _Score = 0;

    public int Score
    {
        get { return _Score; }
        set
        {
            _Score = value;

            if (_Score >= 10)
            {
                labelText = "                       농장 주인을 피해 탈출구를 찾아 가세요!";

                Farmer.SetActive(true);
                ParticleSystem.SetActive(true);
                Exit.SetActive(true);
                Exit2.SetActive(true);

            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        Farmer.SetActive(false);
        ParticleSystem.SetActive(false);
        Exit.SetActive(false);
        Exit2.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25), "체력 : " + playerHP);
        GUI.Box(new Rect(20, 50, 150, 25), "계란후라이 : " + _Score);
        GUI.Label(new Rect(Screen.width / 2 - 220, Screen.height - 80, 500, 50), labelText);

        
        if (showLoseWindow)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "힘내서 다시 도전!"))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
       
    }
}