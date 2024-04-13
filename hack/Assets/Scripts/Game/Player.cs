using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Car car;
    // Start is called before the first frame update
    void Start()
    {
        car = GetComponent<Car>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            car.turn(1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            car.turn(-1);
        }


        if (Input.GetKey(KeyCode.W))
        {
            car.accelerate(1);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            car.accelerate(-1);
        }
    }
}
