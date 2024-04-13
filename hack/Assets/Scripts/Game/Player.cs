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
        if (Input.GetKeyDown(KeyCode.A))
        {
            car.turn(-1);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            car.turn(1);
        }


        if (Input.GetKeyDown(KeyCode.W))
        {
            car.accelerate(1);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            car.accelerate(-1);
        }
    }
}
