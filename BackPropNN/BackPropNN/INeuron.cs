namespace BackPropNN
{
    public interface INeuron : INeuronReceptor, INeuronSignal
    {
        NeuralFactor Bias { get; set; }
        double BiasWeight { get; set; }
        double Error { get; set; }
        double LastError { get; set; }

        void ApplyLearning(INeuralLayer layer);
        void InitializeLearning();
        void Pulse(INeuralLayer layer);

    }
}