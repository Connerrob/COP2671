using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, Interfaces.IAction, Interfaces.IMovementDriver
{
    // players speed
    [SerializeField] float speed = 14.0f;

    // max range for player movement on the X axis
    private float xRange = 24.0f;

    // max range for player movement on the Z axis
    private float zRange = 12f;
    void Update()
    {
        ContainPlayer();
        Vector3 input = GetInput();
        Move(input);
    }

    public void PerformAction()
    {
   
    }
    // IMovementDriver method
    public void Move(Vector2 input)
    {
        // Translate player based on horizontal input
        Vector3 movement = new Vector3(input.x, 0f, input.y);
        transform.Translate(movement * speed * Time.deltaTime);
    }

    // Get player input for movement
    private Vector2 GetInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        return new Vector2(horizontalInput, verticalInput);
    }

    // if statements to keep player in bounds
    void ContainPlayer()
    {
        // if statement to keep player in bounds
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }
    }
}
