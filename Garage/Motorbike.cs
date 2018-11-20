using System;

namespace Ex03
{
    public class Motorbike : Vehicle
    {
        // Constants
        private const eFuelType k_FuelType = eFuelType.Octan96;
        private const float k_TankCapacity = 6.0F;
        private const float k_MaxChargeTime = 1.8F;
        private const float k_MaxAirPressure = 30.0F;
        private const int k_WheelsAmount = 2;

        // Attributes
        private eLicenseType m_LicenseType;
        private int m_EngineCapacity;

        // Properties
        public eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }
            set
            {
                m_LicenseType = value;
            }
        }
        public int EngineCapacity
        {
            get
            {
                return m_EngineCapacity;
            }
            set
            {
                m_EngineCapacity = value;
            }
        }

        // Methods
        public Motorbike(string i_LicenseNumber) : base(i_LicenseNumber, k_WheelsAmount)
        {
        }

        public float getTankCapacity()
        {
            return k_TankCapacity;
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
License type                        {1}
Engine capacity                     {2}", base.ToString(), m_LicenseType.ToString(), m_EngineCapacity.ToString());
        }
    }
}
