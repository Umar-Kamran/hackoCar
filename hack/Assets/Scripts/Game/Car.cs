using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float speed;
    private float deltaSpeed;
    public float speedMultiplier;
    public float maxSpeed;
    public float accelMultiplier;
    private Rigidbody2D rb;

    private Transform tranfs;
    private float turnAngleDelta;
    public float turnMultiplier;
    private CarDistances cardist;

    // Start is called before the first frame update
    void Start()
    {
        cardist = GetComponent<CarDistances>();
        tranfs = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        speed += deltaSpeed * accelMultiplier;
        speed = Mathf.Clamp(speed, 0, maxSpeed);
        rb.transform.Translate(new Vector3(speed * speedMultiplier, 0, 0));


        tranfs.Rotate(new Vector3(0, 0, turnAngleDelta * turnMultiplier * (1/(speed+1))));
        turnAngleDelta = 0;
        deltaSpeed = -0.15f * accelMultiplier;
    }

    public void accelerate(float deltaSpeed)
    {
        this.deltaSpeed = deltaSpeed;
    }

    public void turn(float rotation)
    {
        turnAngleDelta = rotation; 
    }

    public float getSpeed() { return speed; }
    
    public double[] getDists()
    {
        
        return cardist.distances();
    }
}
