using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiverMovement : MonoBehaviour
{
    public float moveSpeed = 2f;

    public Rigidbody2D rb;

    void Update()
    {
        //Input
        Input.GetAxisRaw("Horizontal");
        Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate() { 
        //Movement
    }
}
