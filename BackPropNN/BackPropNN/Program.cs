using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackPropNN
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
        }

        private void Run()
        {
            NeuralNet net = new NeuralNet();
            net.Initialize(1, 2, 2, 1);

            double[][] inputs = new double[4][];
            inputs[0] = new double[] { 0, 0 };
            inputs[1] = new double[] { 0, 1 };
            inputs[2] = new double[] { 1, 0 };
            inputs[3] = new double[] { 1, 1 };

            double[][] outputs = new double[4][];
            outputs[0] = new double[] { 0 };
            outputs[1] = new double[] { 1 };
            outputs[2] = new double[] { 1 };
            outputs[3] = new double[] { 0 };

            net.Train(inputs, outputs);
            net.ApplyLearning();

        }
    }
}
