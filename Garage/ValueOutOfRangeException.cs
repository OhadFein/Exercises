using System;

namespace Ex03
{
    public class ValueOutOfRangeException : Exception
    {
        // Attributes
        private float m_MinValue;
        private float m_MaxValue;

        // Properties
        public float MinValue
        {
            get { return m_MinValue; }
        }
        public float MaxValue
        {
            get { return m_MaxValue; }
        }

        // Methods
        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue)
            : base (String.Format("Value range must be between {0} to {1}", i_MinValue, i_MaxValue))
        {
            m_MinValue = i_MinValue;
            m_MaxValue = i_MaxValue;
        } 
    }
}
