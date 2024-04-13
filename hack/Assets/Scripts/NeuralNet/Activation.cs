using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Activation 
{
    public static double Activate(double input)
    {
        return System.Math.Tanh(input);
    }
}