namespace BackPropNN
{
    public interface INeuralNet
    {
        INeuralLayer HiddenLayer { get; set; }
        double LearningRate { get; set; }
        INeuralLayer OutputLayer { get; set; }
        INeuralLayer PerceptionLayer { get; set; }
        void ApplyLearning();
        void InitializeLearning();
        void Pulse();

    }
}