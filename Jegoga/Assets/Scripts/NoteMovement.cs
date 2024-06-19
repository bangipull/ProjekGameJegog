using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMovement : MonoBehaviour
{
    Rigidbody rb;
    public float speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();      
    }

    private void Start()
    {
        rb.velocity = new Vector3(0, -speed, 0);
    }
}
