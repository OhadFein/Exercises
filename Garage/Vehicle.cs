using System;
using System.Text;
using System.Collections.Generic;

namespace Ex03
{
    abstract public class Vehicle
    {
        // Attributes
        private readonly string m_LicenseNumber;
        private string m_ModelName;
        private float m_EnergyLeftPercent;
        private float m_MaxAirPressure;
        private readonly List<Wheel> m_Wheels = new List<Wheel>();
        protected EnergySource m_EnergySource;
        private eVehicleStatus m_VehicleStatus;
        private readonly VehicleOwner m_VehicleOwner = new VehicleOwner();
        private int m_WheelsAmount;

        // Properties
        public string LicenseNumber
        {
            get
            {
                return m_LicenseNumber;
            }
        }
        public EnergySource EnergySource
        {
            set
            {
                m_EnergySource = value;
            }
        }
        public VehicleOwner VehicleOwner
        {
            get
            {
                return m_VehicleOwner;
            }
        }
        public eVehicleStatus VehicleStatus
        {
            get
            {
                return m_VehicleStatus;
            }
            set
            {
                m_VehicleStatus = value;
            }
        }
        public float MaxAirPressure
        {
            get
            {
                return m_MaxAirPressure;
            }
            set
            {
                m_MaxAirPressure = value;
            }
        }
        public float EnergyLeftPercent
        {
            get
            {
                return m_EnergyLeftPercent;
            }
            set
            {
                m_EnergyLeftPercent = value;
            }
        }
        public string ModelName
        {
            get
            {
                return m_ModelName;
            }
            set
            {
                m_ModelName = value;
            }
        }
        public int WheelsAmount
        {
            get
            {
                return m_WheelsAmount;
            }
        }

        // Methods
        protected Vehicle(string i_LicenseNumber, int i_WheelsAmount)
        {
            m_LicenseNumber = i_LicenseNumber;
            m_VehicleStatus = eVehicleStatus.Repair;
            m_WheelsAmount = i_WheelsAmount;
        }

        public void AddEnergySource(eEnergySource i_EnergySource)
        {
            switch (i_EnergySource)
            {
                case eEnergySource.Fuel:
                    EnergySource = new Fuel();
                    break;
                case eEnergySource.Electric:
                    EnergySource = new Battery();
                    break;
            }
        }

        public abstract void SetEnergySource(eEnergySource i_EnergySourceType, float i_EnergyLeftPercent);

        public void AddWheelsToVehicle(string i_WheelManufacturerName, float i_WheelCurrentAirPressure, float i_WheelMaxAirPressure)
        {
            for (int wheelNum = 0; wheelNum < m_WheelsAmount; wheelNum++)
            {
                addWheel(i_WheelManufacturerName, i_WheelCurrentAirPressure, i_WheelMaxAirPressure);
            }
        }

        private void addWheel(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            Wheel WheelToAdd = new Wheel(i_ManufacturerName, i_CurrentAirPressure, i_MaxAirPressure);
            m_Wheels.Add(WheelToAdd);
        }

        public void InflateVehicleWheels()
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.inflateWheelToMax();
            }
        }

        internal void Refuel(eFuelType i_FuelType, float i_FuelAmount)
        {
            try
            {
                Fuel fuelEngine = m_EnergySource as Fuel;
                fuelEngine.Refuel(i_FuelType, i_FuelAmount);
                calculateEnergySourcePercent();
            }
            catch (InvalidCastException)
            {
                throw new ArgumentException("Vehicle isn't using fuel engine");
            }
        }

        internal void Charge(float i_HoursAmount)
        {
            try
            {
                Battery fuelEngine = m_EnergySource as Battery;
                fuelEngine.Charge(i_HoursAmount);
                calculateEnergySourcePercent();
            }
            catch (InvalidCastException)
            {
                throw new ArgumentException("Vehicle isn't using battery");
            }
        }

        private void calculateEnergySourcePercent()
        {
            m_EnergyLeftPercent = (m_EnergySource.CurrentEnergySourceAmount * m_EnergySource.MaxEnergySourceAmount / 100);
        }

        protected float CalculateCurrentEnergySourceAmount(float i_MaxCapacity)
        {
            return (i_MaxCapacity * m_EnergyLeftPercent / 100);
        }

        private string wheelsToString()
        {
            StringBuilder wheelsString = new StringBuilder();
            int tireNumber = 1;

            foreach (Wheel wheel in m_Wheels)
            {
                wheelsString.Append(String.Format(
@"
Tire No. {0}
{1}", tireNumber, wheel.ToString()));

                tireNumber++;
            }

            return wheelsString.ToString();
        }

        public override int GetHashCode()
        {
            return m_LicenseNumber.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format(
@"Model Name                          {0}
LicenseNumber                       {1}
Owner Name                          {2}
Condition                           {3}
{4}{5}", m_ModelName, m_LicenseNumber, m_VehicleOwner.Name, m_VehicleStatus.ToString(), m_EnergySource.ToString(), wheelsToString());
        }
    }
}
