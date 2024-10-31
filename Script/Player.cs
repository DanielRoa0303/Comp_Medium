using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    // private variables will only change on the script
    public float speed;
    private float horizontalInput;
    private float verticalInput;
    public GameObject Bullet; 



    // Start is called before the first frame update
    void Start()
    {
        speed = 7.0f;  
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
        if (transform.position.x >= 10f || transform.position.x <= -10f)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }
        if (transform.position.y > 1f)
        {
            transform.position = new Vector3(transform.position.x, 1f, 0);
        }
        else if (transform.position.y < -4.05f)
        {
            transform.position = new Vector3(transform.position.x, -4.05f, 0);
        }
    }

    void Shooting()
    {
        //if a press SPACE I create a Bullet
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Bullet, transform.position + new Vector3(0,1,0), Quaternion.identity);
        }
    } 
    }
