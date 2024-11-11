using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemyOne;
    public GameObject cloud;
    public GameObject Coin;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;

    private int score;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player, transform.position, Quaternion.identity);
        InvokeRepeating("CreateEnemyOne", 1f, 3f);
        CreateSky();
        score = 0;
        scoreText.text = "Score: " + score;


        // We just call the LivesLeft function I create using EarnScore Function as a base
        LivesLeft(3);
        // We Create the Coin using Invoke, as we previously made withe the EnemyOne
        InvokeRepeating("SpawnCoin", 2f, 4f);

    }


    // Update is called once per frame
    void Update()
    {

    }

    void CreateEnemyOne()
    {
        Instantiate(enemyOne, new Vector3(Random.Range(-9f, 9f), 7.5f, 0), Quaternion.Euler(0, 0, 180));
    }

    void CreateSky()
    {
        for (int i = 0; i < 30; i++)
        {
            Instantiate(cloud, transform.position, Quaternion.identity);
        }
    }

    public void EarnScore(int newScore)
    {
        score = score + newScore;
        scoreText.text = "Score: " + score;
    }


    
    // We repeat the EarnScore process function we create above
    public void LivesLeft(int lives)
    {
        livesText.text = "Lives: " + lives;
    }
    void SpawnCoin()
    {
        // Here we set the limits of the coin. It can only appear in the follong random x, random y, 0 z.
        // Same process as line 44
        GameObject newCoin = Instantiate(Coin, new Vector3(Random.Range(-10f, 10f), Random.Range(-4.08f, 6f), 0), Quaternion.identity);

        //This just destroys the coin after 3 seconds
        Destroy(newCoin, 3f); 
    }
}
