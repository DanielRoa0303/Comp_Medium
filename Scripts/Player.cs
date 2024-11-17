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
    private int shooting;
    private bool hasShield;

    public GameManager gameManager;

    public GameObject bullet;
    public GameObject explosion;
    public GameObject thruster;
    public GameObject shield;

    // Start is called before the first frame update
    void Start()
    {
        speed = 6f;
        lives = 3;
        shooting = 1;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        hasShield = false;
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


            switch (shooting)
            {
                case 1:
                    Instantiate(bullet, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                    break;
                case 2:
                    Instantiate(bullet, transform.position + new Vector3(-0.5f, 1, 0), Quaternion.identity);
                    Instantiate(bullet, transform.position + new Vector3(0.5f, 1, 0), Quaternion.identity);
                    break;
                case 3:
                    Instantiate(bullet, transform.position + new Vector3(-0.5f, 1, 0), Quaternion.Euler(0,0,30f));
                    Instantiate(bullet, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                    Instantiate(bullet, transform.position + new Vector3(0.5f, 1, 0), Quaternion.Euler(0, 0, -30f));
                    break;
            }
        }
    }

    public void LoseALife()
    { if (hasShield == false)
        {
            lives--;
        } else if(hasShield == true)
        {
            //lose the shield
            hasShield = false;
            shield.gameObject.SetActive(false);
            gameManager.PlayPowerDown();


        }


        //Same process we made in the Enemy Script, line 34
        GameObject.Find("GameManager").GetComponent<GameManager>().LivesLeft(lives);

        //lives -= 1;
        //lives = lives - 1;
        if (lives == 0)
        {
            gameManager.GameOver();
            Instantiate(explosion,transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
    IEnumerator SpeedPowerDown()
    {
        yield return new WaitForSeconds(3f);
        speed = 6f;
        thruster.gameObject.SetActive(false);
        gameManager.UpdatePowerupTextt("");
        gameManager.PlayPowerDown();
    }

    IEnumerator ShootingPowerDown()
    {
        yield return new WaitForSeconds(4f);
        shooting = 1;
        gameManager.UpdatePowerupTextt("");
        gameManager.PlayPowerDown();
    }

    IEnumerator ShieldPowerDown()
    {
        yield return new WaitForSeconds(4f);
        hasShield = false;
        shield.gameObject.SetActive(false);
        gameManager.UpdatePowerupTextt("");
        gameManager.PlayPowerDown();
    }


    private void OnTriggerEnter2D(Collider2D whatIHit)
    {
        if (whatIHit.tag == "Powerup")
        {
            gameManager.PlayPowerUp();
            int powerupType=Random.Range(1,5);
            switch(powerupType)
            {
                case 1:
                    //speed powerup
                    speed = 9f;
                    gameManager.UpdatePowerupTextt("Picked up Speed!");
                    thruster.gameObject.SetActive(true);
                    StartCoroutine(SpeedPowerDown());
                    break;
                case 2:
                    //double shot
                    shooting = 2;
                    gameManager.UpdatePowerupTextt("Picked up Double Shot!");
                    StartCoroutine (ShootingPowerDown());
                    break;
                case 3:
                    //triple shot
                    shooting = 3;
                    gameManager.UpdatePowerupTextt("Picked up Triple Shoot!");
                    StartCoroutine(ShootingPowerDown());
                    break;
                    //shield
                case 4:
                    gameManager.UpdatePowerupTextt("Picked up Shield!");
                    shield.gameObject.SetActive(true);
                    hasShield = true;
                    StartCoroutine(ShieldPowerDown());

                    break;
            }
            Destroy(whatIHit.gameObject);

        }
    }
} 