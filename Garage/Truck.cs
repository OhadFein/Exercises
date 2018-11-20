using System;

namespace Ex03
{
    public class Truck : Vehicle
    {
        // Constants
        private const eFuelType k_FuelType = eFuelType.Soler;
        private const float k_TankCapacity = 115.0F;
        private const float k_MaxAirPressure = 28;
        private const int k_WheelsAmount = 12;

        // Attributes
        private bool m_IsTrunkCooled;
        private float m_TrunkCapacity;

        // Properties
        public bool IsTrunkCooled
        {
            get
            {
                return m_IsTrunkCooled;
            }
            set
            {
                m_IsTrunkCooled = value;
            }
        }

        public float TrunkCapacity
        {
            get
            {
                return m_TrunkCapacity;
            }
            set
            {
                m_TrunkCapacity = value;
            }
        }

        // Methods
        public Truck(string i_LicenseNumber) : base(i_LicenseNumber, k_WheelsAmount)
        {
        }

        public override void SetEnergySource(eEnergySource i_EnergySourceType, float i_EnergyLeftPercent)
        {
            Fuel fuel = m_EnergySource as Fuel;

            m_EnergySource.CurrentEnergySourceAmount = CalculateCurrentEnergySourceAmount(k_TankCapacity);
            m_EnergySource.MaxEnergySourceAmount = k_TankCapacity;
            fuel.FuelType = k_FuelType;
        }

        public float getTankCapacity()
        {
            return k_TankCapacity;
        }


        public override string ToString()
        {
            return String.Format(
@"{0}
Is truck cooled                     {1}
Trunk capacity                      {2}", base.ToString(), m_IsTrunkCooled.ToString(), m_TrunkCapacity.ToString());
        }
    }
}
