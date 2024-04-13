using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layer : MonoBehaviour
{
       
    /*
    public Layer(int inpNum, int outNum)
    {
        this.inpNum = inpNum;
        this.outNum = outNum;
        weights = new double[inpNum, outNum];
        biases = new double[inpNum, outNum];

    }

    public double[] calculateOutput(double[] inputs)
    {
        double[] outputs = new double[outNum];
        for (int i = 0; i < outNum; i++)
        {
            double curOut = 0;
            for (int j = 0; j < inpNum; j++)
            {
                curOut += inputs[j] * weights[i, j] + biases[i, j];
            }
            outputs[i]= Activation.Activate(curOut);
        }
        return outputs;
    }

    private void randomiseWeights()
    {
        System.Random rnd = new System.Random();
        for (int i = 0; i < inpNum; i++)
        {
            for (int j = 0; j < outNum; j++)
            {
                weights[i, j] = rnd.NextDouble() - 0.5;
            }
        }
    }
    */

        private int inpNum;
        private int outNum;
        private double[,] weights;
        private double[] biases;

        public Layer(int inpNum, int outNum)
        {
            this.inpNum = inpNum;
            this.outNum = outNum;
            weights = new double[inpNum, outNum];
            biases = new double[outNum];
            RandomiseWeights();
        }

        public double[] CalculateOutput(double[] inputs)
        {
            double[] outputs = new double[outNum];
            for (int i = 0; i < outNum; i++)
            {
                double sum = 0;
                for (int j = 0; j < inpNum; j++)
                {
                    sum += inputs[j] * weights[j, i];
                }
                sum += biases[i];
                outputs[i] = Activation.Activate(sum);
            }
            return outputs;
        }

        private void RandomiseWeights()
        {
            System.Random rnd = new System.Random();
            for (int i = 0; i < inpNum; i++)
            {
                for (int j = 0; j < outNum; j++)
                {
                    weights[i, j] = rnd.NextDouble() * 2- 1;
                }
            }
            for (int i = 0; i < outNum; i++)
            {
                biases[i] = rnd.NextDouble() * 2 - 1;
            }
        }
}
