using System;

namespace Ex03
{
    public class Car : Vehicle
    {
        // Constants
        private const eFuelType k_FuelType = eFuelType.Octan98;
        private const float k_TankCapacity = 45.0F;
        private const float k_MaxChargeTime = 3.2F;
        private const float k_MaxAirPressure = 32.0F;
        private const int k_WheelsAmount = 4;

        // Attributes
        private eCarColor m_Color;
        private eDoorsAmount m_DoorsAmount;

        // Properties
        public eCarColor Color
        {
            get
            {
                return m_Color;
            }
            set
            {
                m_Color = value;
            }
        }
        public eDoorsAmount DoorsAmount
        {
            get
            {
                return m_DoorsAmount;
            }
            set
            {
                m_DoorsAmount = value;
            }
        }

        // Methods
        public Car(string i_LicenseNumber) : base(i_LicenseNumber, k_WheelsAmount)
        {
        }

        public override void SetEnergySource(eEnergySource i_EnergySourceType, float i_EnergyLeftPercent)
        {
            if (m_EnergySource is Battery)
            {
                m_EnergySource.MaxEnergySourceAmount = k_MaxChargeTime;
                m_EnergySource.CurrentEnergySourceAmount = CalculateCurrentEnergySourceAmount(k_MaxChargeTime);
            }
            else
            {
                Fuel fuel = m_EnergySource as Fuel;

                m_EnergySource.MaxEnergySourceAmount = k_TankCapacity;
                m_EnergySource.CurrentEnergySourceAmount = CalculateCurrentEnergySourceAmount(k_TankCapacity);
                fuel.FuelType = k_FuelType;
            }
        }

        public override string ToString()
        {
            return String.Format(
@"{0}
Color                               {1}
Number of doors                     {2}", base.ToString(), m_Color.ToString(), m_DoorsAmount.ToString());
        }
    }
}