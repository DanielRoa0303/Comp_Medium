using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject player;
    public GameObject enemy;
    public GameObject Enemy2;
// Start is called before the first frame update
void Start()
{
        Instantiate(player, transform.position, Quaternion.identity);
        InvokeRepeating("CreateEnemy", 1f, 3f);
        InvokeRepeating("CreateEnemy2", 2f, 2f);
    }
// Update is called once per frame
void Update()
    {

    }
void CreateEnemy()
    {
         Instantiate(enemy, new Vector3(Random.Range(-9f, 9f), 9f, 0),
         Quaternion.identity);
    }
void CreateEnemy2()
    {
        Instantiate(Enemy2, new Vector3(-15f, Random.Range(1.5f, 6f), 0),
        Quaternion.identity);
    }
}
