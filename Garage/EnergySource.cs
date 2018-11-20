using System;

namespace Ex03
{
    abstract public class EnergySource
    {
        // Attributes
        private float m_CurrentEnergySourceAmount;
        private float m_MaxEnergySourceAmount;

        // Properties
        public float CurrentEnergySourceAmount
        {
            get
            {
                return m_CurrentEnergySourceAmount;
            }
            set
            {
                m_CurrentEnergySourceAmount = value;
            }
        }
        public float MaxEnergySourceAmount
        {
            get
            {
                return m_MaxEnergySourceAmount;
            }
            set
            {
                m_MaxEnergySourceAmount = value;
            }
        }

        // Methods

        public override string ToString()
        {
            return String.Format(
@"Current Energy Source Amount        {0}
Max Energy Source Amount            {1}", m_CurrentEnergySourceAmount, m_MaxEnergySourceAmount);
        }
    }
}
