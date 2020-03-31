using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public bool playerOne, playerTwo;
    public float xSpeed;
    public float jumpForce;
    GameControl gameControl;
   

    Rigidbody rb;

    private void Start()
    {
        gameControl = GameObject.Find("GameControl").GetComponent<GameControl>();
        rb = GetComponent<Rigidbody>();
        xSpeed = (xSpeed * Time.deltaTime);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        Movement();
    }

    public void Movement()
    {
        if (playerOne)
        {
            PlayerOneMovement();
        }

        if (playerTwo)
        {
            PlayerTwoMovement();
        }
    }

    public void PlayerOneMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 newPos = rb.position + transform.TransformDirection(0, 0, xSpeed);
            rb.MovePosition(newPos);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 newPos = rb.position + transform.TransformDirection(0, 0, -xSpeed);
            rb.MovePosition(newPos);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 newPos = rb.position + transform.TransformDirection(-xSpeed, 0, 0);
            rb.MovePosition(newPos);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 newPos = rb.position + transform.TransformDirection(xSpeed, 0, 0);
            rb.MovePosition(newPos);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded())
            {
                rb.AddForce(0f, jumpForce, 0f, ForceMode.Impulse);
            }
        }
    }

    public void PlayerTwoMovement()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector3 newPos = rb.position + transform.TransformDirection(0, 0, xSpeed);
            rb.MovePosition(newPos);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector3 newPos = rb.position + transform.TransformDirection(0, 0, -xSpeed);
            rb.MovePosition(newPos);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 newPos = rb.position + transform.TransformDirection(-xSpeed, 0, 0);
            rb.MovePosition(newPos);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 newPos = rb.position + transform.TransformDirection(xSpeed, 0, 0);
            rb.MovePosition(newPos);
        }

        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            if (isGrounded())
            {
                rb.AddForce(0f, jumpForce, 0f, ForceMode.Impulse);
            }
        }

    }

    private bool isGrounded()
    {
        //Fire a RayCast downwards, if it hits somethng it returns
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GreenPad"))
        {
            gameControl.greenPadCount++;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("RedPad"))
        {
            gameControl.redPadCount++;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Restart"))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }

        if (other.CompareTag("GameEnd"))
        {
            SceneManager.LoadScene(1);
        }
    }
}
