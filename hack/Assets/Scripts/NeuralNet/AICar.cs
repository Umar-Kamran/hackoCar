using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICar : MonoBehaviour
{
    private float score;
    private NeuralNetwork nn;
    private Car car;

    private int[] neuronShape =
    {
        6,
        4,
        2
    };
    private void Start()
    {
        car = GetComponent<Car>();
        nn = new NeuralNetwork(neuronShape);
    }

    private void FixedUpdate()
    {
        double[] dists = car.getDists();
        double speed = car.getSpeed();
        List<double> temp = new List<double>();
        temp.Add(speed);
        foreach (var item in dists)
        {
            temp.Add(item);
        }
        double[] feedback = nn.FeedForward(temp.ToArray());
        car.turn((float)feedback[0]);
        car.accelerate((float)feedback[1]);
    }

}
