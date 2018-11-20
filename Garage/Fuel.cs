using System;

namespace Ex03
{
    public class Fuel : EnergySource
    {
        // Attributes
        private eFuelType m_FuelType;

        // Properties
        public eFuelType FuelType
        {
            get
            {
                return m_FuelType;
            }
            set
            {
                m_FuelType = value;
            }
        }

        // Methods

        // $G$ DSN-999 (-5) Code duplication, Refuel and Charge functions  
        // their mutual part should be in the base class
        internal void Refuel(eFuelType i_FuelType, float i_FuelAmount)
        {
            if (m_FuelType != i_FuelType)
            {
                throw new ArgumentException("Invalid fuel type");
            }
            else if (base.CurrentEnergySourceAmount + i_FuelAmount > base.MaxEnergySourceAmount || i_FuelAmount < 0.0F)
            {
                throw new ValueOutOfRangeException(0.0F, base.MaxEnergySourceAmount - base.CurrentEnergySourceAmount);
            }

            base.CurrentEnergySourceAmount += i_FuelAmount;
        }

        public override string ToString()
        {
            return String.Format(
@"Energy Source                       {0}
{1}
Fuel Type                           {2}", this.GetType().Name, base.ToString(), m_FuelType.ToString());
        }
    }
}