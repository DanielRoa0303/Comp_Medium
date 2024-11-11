using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Here Im trying to replicate what we make in the Enemy Script, but with small modifications
            GameObject.Find("GameManager").GetComponent<GameManager>().EarnScore(1);

            // Destroy the coin
            Destroy(this.gameObject); 
        }
    }
}
