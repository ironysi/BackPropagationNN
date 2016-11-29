using System;

namespace BackPropNN
{
    public class NeuralNet : INeuralNet
    {
        private INeuralLayer m_hiddenLayer;
        private INeuralLayer m_inputLayer;
        private INeuralLayer m_outputLayer;
        private double m_learningRate;
        public INeuralLayer HiddenLayer { get; set; }
        public double LearningRate { get; set; }
        public INeuralLayer OutputLayer { get; set; }
        public INeuralLayer PerceptionLayer { get; set; }
        public NeuralNet()
        {

        }
        public void ApplyLearning()
        {
            lock (this)
            {
                m_hiddenLayer.ApplyLearning(this);
                m_outputLayer.ApplyLearning(this);
            }
        }

        public void InitializeLearning()
        {
            throw new System.NotImplementedException();
        }

        public void Pulse()
        {
            lock (this)
            {
                m_hiddenLayer.Pulse(this);
                m_outputLayer.Pulse(this);
            }
        }

        private void BackPropagation(double[] desiredResults)
        {
            // calculate output error values
            for (int i = 0; i < m_outputLayer.Count; i++)
            {
                double actualResult = m_outputLayer[i].Output;
                m_outputLayer[i].Error = (desiredResults[i] - actualResult) * actualResult * (1 - actualResult);
            }

            // calculate hidden layer error values
            foreach (INeuron node in m_hiddenLayer)
            {
                double error = 0;

                foreach (INeuron outputNodeNeuron in m_outputLayer)
                {
                    error += outputNodeNeuron.Error * outputNodeNeuron.Input[node].Weight * node.Output * (1.0 - node.Output);
                }
                node.Error = error;
            }

            //Adjust hidden layer weight change
            for (int i = 0; i < m_hiddenLayer.Count; i++)
            {
                INeuron node = m_inputLayer[i];

                foreach (INeuron outputNeuron in m_outputLayer)
                {
                    INeuron outputNode = outputNeuron;
                    outputNode.Input[node].Weight += m_learningRate * outputNeuron.Error * node.Output;
                    outputNode.Bias.Delta += m_learningRate * outputNeuron.Error * outputNode.Bias.Weight;
                }
            }

            for (int i = 0; i < m_inputLayer.Count; i++)
            {
                INeuron inputNode = m_inputLayer[i];

                for (int j = 0; j < m_hiddenLayer.Count; j++)
                {
                    INeuron hiddenNode = m_hiddenLayer[j];

                    hiddenNode.Input[inputNode].Weight += m_learningRate * hiddenNode.Error * inputNode.Output;
                    hiddenNode.Bias.Delta += m_learningRate * hiddenNode.Error * inputNode.Bias.Weight;
                    ;
                }
            }

        }

        void BackpropagationTrainingSession()
        {

        }

        void CalculateAndAppendTransformation()
        {

        }

        void CalculateErrors()
        {

        }

        public void Initialize(int seed, int inputNeuronCount, int hiddenNeuronCount, int outputNeuronCount)
        {
            int i, layerCount;
            Random rnd;
            INeuralLayer layer;

            rnd = new Random(seed);
            m_inputLayer = new NeuralLayer();
            m_outputLayer = new NeuralLayer();
            m_hiddenLayer = new NeuralLayer();

            for (i = 0; i < inputNeuronCount; i++)
            {
                m_inputLayer.Add(new Neuron());
            }
            for (i = 0; i < outputNeuronCount; i++)
            {
                m_outputLayer.Add(new Neuron());
            }
            for (i = 0; i < hiddenNeuronCount; i++)
            {
                m_hiddenLayer.Add(new Neuron());
            }

            // input layer to hidden layer
            foreach (INeuron hiddenNeuron in m_hiddenLayer)
            {
                foreach (INeuron inputNeuron in m_inputLayer)
                {
                    hiddenNeuron.Input.Add(inputNeuron, new NeuralFactor(rnd.NextDouble()));
                }
            }
            // output neuron to hidden layer
            foreach (INeuron outputNeuron in m_outputLayer)
            {
                foreach (INeuron hiddenNeuron in m_hiddenLayer)
                {
                    outputNeuron.Input.Add(hiddenNeuron, new NeuralFactor(rnd.NextDouble()));
                }
            }
        }

        void PreparePerceptionLayerForPulse()
        {

        }

        double SigmoidDerivative()
        {
            return 0.0;
        }

        public void Train(double[] input, double[] desiredResult)
        {
            // initialize data
            for (int i = 0; i < m_inputLayer.Count; i++)
            {
                Neuron n = m_inputLayer[i] as Neuron;

                if (n != null)
                    n.Output = input[i];
            }

            Pulse();
            BackPropagation(desiredResult);
        }

        public void Train(double[][] inputs, double[][] desiredOutputs)
        {
            for (int i = 0; i < inputs.Length; i++)
            {
                Train(inputs[i], desiredOutputs[i]);
            }
        }
    }
}