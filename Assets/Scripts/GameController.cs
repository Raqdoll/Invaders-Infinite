using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public float speed = 1;
    public float SpeedupTimerS;
    public float speedModifier;
    public float spawnLenghtS;
    private int enemySelect = 0;
    public Text countText;
    public Text theEnd;
    public Text endScore;
    public Text restart;
    public Text slowdown;
    public Text trippleS;
    private int score;
    public bool gameOver;
    public Renderer gameOv;
    public AudioSource nyan;
    public float startPitch;
    public float musicIncrease;
    private int slow;
    public int slowCounter;
    public int trippleShots;
    

    public static GameController Instance = null;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
        
    }


    void Start()
    {
        gameOver = false;
        StartCoroutine(SpeedUp());
        StartCoroutine(Spawn());
        score = 0;
        slow = 0;
        trippleShots = 0;
        countText.text = "Score: " + score;
        trippleS.text = "Tripple shots: " + trippleShots + "\n (Space to use)";
        slowdown.text = "Enemy bullets hit: "+ slow + " / " + slowCounter;
        theEnd.text = "";
        endScore.text = "";
        restart.text = "";
        gameOv.enabled = false;
        nyan = GetComponent<AudioSource>();
        nyan.pitch = startPitch;
        StartCoroutine(Music());

    }

    void Update()
    {
        if (slow >= slowCounter)
        {
            speed = speed / speedModifier;
            nyan.pitch -= musicIncrease;
            trippleShots += 1;
            trippleS.text = "Tripple shots: " + trippleShots + "\n (Space to use)";
            slow = 0;
            slowdown.text = "Enemy bullets hit: " + slow + " / " + slowCounter;
        }
    }

    public void AddScore(int x)
    {
        score += x;
        countText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOver = true;
        theEnd.text = "Game Over!";
        endScore.text = "Score: " +score;
        restart.text = "Press 'R' to restart";
        countText.text = "";
        gameOv.enabled = true;
        nyan.Stop();

    }
    public void SlowDown()
    {
        slow += 1;
        slowdown.text = "Enemy bullets hit: " + slow + " / " + slowCounter;
    }



    void SpawnWaves()
    {
        
        if (enemySelect == 0)
        {
            for (int i = 0; i < 8; i++)
            {
                Instantiate(enemy1, new Vector3(-i * 10f + 55f, 115f, 0f), Quaternion.identity);
                enemySelect = 1;
            }
        }else if(enemySelect == 1)
        {
            for (int i = 0; i < 8; i++)
            {
                Instantiate(enemy2, new Vector3(-i * 10f + 55f, 115f, 0f), Quaternion.identity);
                enemySelect = 2;
            }
        }
        else if (enemySelect == 2)
        {
            for (int i = 0; i < 8; i++)
            {
                Instantiate(enemy3, new Vector3(-i * 10f + 55f, 115f, 0f), Quaternion.identity);
                enemySelect = 0;
            }
        }
    }


    IEnumerator SpeedUp()
    {
        while(gameOver == false)
        {

            speed = speed * speedModifier;
            yield return new WaitForSeconds(SpeedupTimerS);
     
        }
    }

    IEnumerator Spawn()
    {
        while (gameOver == false)
        {
            
            SpawnWaves();
            yield return new WaitForSeconds(spawnLenghtS / speed);
            enemySelect++;
            if(enemySelect == 3)
            {
                enemySelect = 0;
            }
        }
    }
    IEnumerator Music()
    {
        
        while (gameOver == false)
        {
            yield return new WaitForSeconds(SpeedupTimerS*2);
            nyan.pitch += musicIncrease;
        }
    }





}
