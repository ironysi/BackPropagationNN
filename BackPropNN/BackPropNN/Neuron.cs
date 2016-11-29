using System;
using System.Collections.Generic;

namespace BackPropNN
{
    public class Neuron : INeuron
    {
        private double m_output;
        private readonly Dictionary<INeuronSignal, NeuralFactor> m_input = new Dictionary<INeuronSignal, NeuralFactor>();
        private NeuralFactor m_bias;


        public Neuron(double bias)
        {
            m_bias = new NeuralFactor(bias);
        }
        public Dictionary<INeuronSignal, NeuralFactor> Input
        {
            get { return m_input; }
        }

        public double Output
        {
            get { return m_output; }
            set { m_output = value; }
        }

        public NeuralFactor Bias
        {
            get { return m_bias; }
            set { m_bias = value; }
        }

        public double BiasWeight { get; set; }
        public double Error { get; set; }
        public double LastError { get; set; }

        private static double Sigmoid(double value)
        {
            return 1 / (1 + Math.Exp(-value));
        }

        public void ApplyLearning(INeuralLayer layer)
        {
            
        }

        public void InitializeLearning()
        {
            throw new System.NotImplementedException();
        }

        public void Pulse(INeuralLayer layer)
        {
            lock(this)
            {
                m_output = 0;

                foreach (KeyValuePair<INeuronSignal,NeuralFactor> input in m_input)
                {
                    m_output += input.Key.Output*input.Value.Weight;
                }

                m_output += m_bias.Weight*BiasWeight;

                m_output = Sigmoid(m_output);
            }
        }
    }
}