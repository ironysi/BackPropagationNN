using System.Collections;
using System.Collections.Generic;

namespace BackPropNN
{
    public class NeuralLayer : INeuralLayer
    {
        private List<INeuron> m_neurons = new List<INeuron>();
        public IEnumerator<INeuron> GetEnumerator()
        {
            return m_neurons.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) m_neurons).GetEnumerator();
        }

        public void Add(INeuron item)
        {
            m_neurons.Add(item);
        }

        public void Clear()
        {
            m_neurons.Clear();
        }

        public bool Contains(INeuron item)
        {
            return m_neurons.Contains(item);
        }

        public void CopyTo(INeuron[] array, int arrayIndex)
        {
            m_neurons.CopyTo(array, arrayIndex);
        }

        public bool Remove(INeuron item)
        {
            return m_neurons.Remove(item);
        }

        public int Count
        {
            get { return m_neurons.Count; }
        }

        public bool IsReadOnly
        {
            get { return ((ICollection<INeuron>) m_neurons).IsReadOnly; }
        }

        public int IndexOf(INeuron item)
        {
            return m_neurons.IndexOf(item);
        }

        public void Insert(int index, INeuron item)
        {
            m_neurons.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            m_neurons.RemoveAt(index);
        }

        public INeuron this[int index]
        {
            get { return m_neurons[index]; }
            set { m_neurons[index] = value; }
        }

        public void ApplyLearning(INeuralNet net)
        {
            foreach (INeuron neuron in m_neurons)
            {
                neuron.ApplyLearning(this);
            }
        }

        public void InitializeLearning()
        {
            throw new System.NotImplementedException();
        }

        public void Pulse(INeuralNet net)
        {
            foreach (INeuron neuron in m_neurons)
            {
                neuron.Pulse(this);
            }
        }


    }

}
