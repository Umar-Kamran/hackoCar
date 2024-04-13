using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeuralNetwork : MonoBehaviour
{
    public class NeuralNetwork : MonoBehaviour
    {
        private List<Layer> layers = new List<Layer>();

        public NeuralNetwork(params int[] neuronCounts)
        {
            for (int i = 0; i < neuronCounts.Length - 1; i++)
            {
                layers.Add(new Layer(neuronCounts[i], neuronCounts[i + 1]));
            }
        }

        public double[] FeedForward(double[] inputs)
        {
            double[] outputs = inputs;
            foreach (Layer layer in layers)
            {
                outputs = layer.CalculateOutput(outputs);
            }
            return outputs;
        }

        public void Mutate(double amount)
        {
            System.Random rnd = new System.Random();
            foreach (Layer layer in layers)
            {
                for (int i = 0; i < layer.weights.GetLength(0); i++)
                {
                    for (int j = 0; j < layer.weights.GetLength(1); j++)
                    {
                        layer.weights[i, j] = Mathf.Lerp((float)layer.weights[i, j], (float)(rnd.NextDouble() * 2 - 1), (float)amount);
                    }
                }
                for (int i = 0; i < layer.biases.Length; i++)
                {
                    layer.biases[i] = Mathf.Lerp((float)layer.biases[i], (float)(rnd.NextDouble() * 2 - 1), (float)amount);
                }
            }
        }
    }
}
