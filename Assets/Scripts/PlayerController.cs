using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundry
{
    public float xmin, xmax, zmin, zmax;
}

public class PlayerController : MonoBehaviour {

    public float speed;
    public float tilt;
    public Boundry boundry;
    private Rigidbody rb;
    internal int playerControllerId;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate = 0.5F;
    private float nextFire = 0.0F;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }

    private void FixedUpdate()
    {

    float movehoriz = Input.GetAxis("Horizontal");
    float movevert = Input.GetAxis("Vertical");

    Vector3 movement = new Vector3(movehoriz, 0.0f, movevert);
    rb.velocity = movement* speed;

        rb.position = new Vector3
        (
        Mathf.Clamp(rb.position.x, boundry.xmin, boundry.xmax),
        0.0f,
        Mathf.Clamp(rb.position.z, boundry.zmin, boundry.zmax)
        );

        rb.rotation = Quaternion.Euler(0, 0, rb.velocity.x * (-tilt));
    }
}
