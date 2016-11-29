using System.Collections;
using System.Collections.Generic;

namespace BackPropNN
{
    public interface INeuralLayer: IList<INeuron>
    {
        void ApplyLearning(INeuralNet net);
        void InitializeLearning();
        void Pulse(INeuralNet net);
    }
}