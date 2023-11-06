using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float objectBound = -25;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy the game object if it's out of bounds
        if (transform.position.z < objectBound)
        {
            Destroy(gameObject);
        }
    }
}
