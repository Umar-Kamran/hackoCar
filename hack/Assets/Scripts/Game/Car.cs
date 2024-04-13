using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float speed;
    private float deltaSpeed;
    public float speedMultiplier;
    public float maxSpeed;
    private Rigidbody2D rb;

    private Transform tranfs;
    private float turnAngleDelta;
    public float turnMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        tranfs = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        speed += deltaSpeed;
        speed = Mathf.Clamp(speed, 0, maxSpeed);
        rb.transform.Translate(new Vector3(speed * speedMultiplier, 0, 0));
        deltaSpeed = 0;

        tranfs.Rotate(new Vector3(0, 0, turnAngleDelta * turnMultiplier));
        turnAngleDelta = 0;
    }

    public void accelerate(float deltaSpeed)
    {
        this.deltaSpeed = deltaSpeed;
    }

    public void turn(float rotation)
    {
        turnAngleDelta = rotation; 
    }

}
