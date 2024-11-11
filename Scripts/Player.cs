using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
  
    //Variables del tamano de la pantalla
    private float horizontalScreenSize = 10f;
    private float verticalScreenSize = 6.20f;
    private float speed;
    public int lives;

    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        speed = 6f;
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shooting();
    }

    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * speed);
       
        // Esto es para definir los bordes horizontales donde puede ir el avion
        if (transform.position.x > horizontalScreenSize || transform.position.x <= -horizontalScreenSize)
        {
            // Esto es para que cuando llegue al borde, el eje x se multiplique por -1 para que aparesca por el otro lado
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }
        if (transform.position.y > verticalScreenSize || transform.position.y < -verticalScreenSize)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y * -1, 0);
        }
    }

    void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }

    public void LoseALife()
    {
        lives--;

        //Same process we made in the Enemy Script, line 34
        GameObject.Find("GameManager").GetComponent<GameManager>().LivesLeft(lives);

        //lives -= 1;
        //lives = lives - 1;
        if (lives == 0)
        {
            Destroy(this.gameObject);
        }
    }
}