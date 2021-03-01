using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mover : MonoBehaviour {

    private Rigidbody rb;
    public float speed;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }
}
