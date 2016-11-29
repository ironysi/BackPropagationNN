using System;
using System.Data;

namespace BackPropNN
{
    public class NeuralFactor
    {
        private double m_weight;
        private double m_delta;
        private double m_lastDelta;


        public double Weight
        {
            get { return m_weight; }
            set { m_weight = value; }
        }

        public double Delta
        {
            get { return m_delta; }
            set { m_delta = value; }
        }
        public double H_Vector { get; set; }
        public double Last_H_Vector { get; set; }

        public NeuralFactor(double weight)
        {
            m_weight = weight;
            m_delta = 0;
        }

        public void ApplyDelta()
        {
            m_weight += m_delta;
            m_delta = 0;
        }

        public void ResetWeightChange()
        {
            throw new NotImplementedException();
        }
        public void ApplyWeightChange()
        {
            throw new NotImplementedException();
        }
    }
}