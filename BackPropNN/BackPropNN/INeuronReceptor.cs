using System.Collections.Generic;

namespace BackPropNN
{
    public interface INeuronReceptor
    {
        Dictionary<INeuronSignal, NeuralFactor> Input { get; }
    }
}