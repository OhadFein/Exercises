using System;
using System.Collections.Generic;

namespace Ex03
{
    public class Garage
    {
        // Attributes
        private readonly Dictionary<string, Vehicle> m_Vehicles = new Dictionary<string, Vehicle>();

        // Methods
      
        public void AddVehicle(Vehicle i_Vehicle)
        {
            m_Vehicles.Add(i_Vehicle.LicenseNumber,i_Vehicle);
        }

        public List<string> GetVehicleList(eVehicleFilter i_FilterType)
        {
            List<string> vehicleList = new List<string>();

            foreach (KeyValuePair<string, Vehicle> keyValuePairVehicle in m_Vehicles)
            {
                if ((int)keyValuePairVehicle.Value.VehicleStatus == (int)i_FilterType || i_FilterType == eVehicleFilter.None)
                {
                    vehicleList.Add(keyValuePairVehicle.Key);
                }
            }

            return vehicleList;
        }

        public void ChangeVehicleStatus(string i_LicenseNumber, eVehicleStatus i_NewStatus)
        {
            Vehicle vehicleToChangeStatus = getVehicle(i_LicenseNumber);

            vehicleToChangeStatus.VehicleStatus = i_NewStatus;
        }

        public void InflateVehicleWheels(string i_LicenseNumber)
        {
            Vehicle vehicleToBlowUpWheels = getVehicle(i_LicenseNumber);
            vehicleToBlowUpWheels.InflateVehicleWheels();
        }

        public void RefuelVehicle(string i_LicenseNumber, eFuelType i_FuelType, float i_FuelAmount)
        {
            Vehicle vehicleToRefuel = getVehicle(i_LicenseNumber);

            vehicleToRefuel.Refuel(i_FuelType, i_FuelAmount);
        }

        public void ChargeVehicleBattery(string i_LicenseNumber, float i_ChargeHoursAmount)
        {
            Vehicle vehicleToCharge = getVehicle(i_LicenseNumber);

            vehicleToCharge.Charge(i_ChargeHoursAmount);
        }

        public bool isVehicleExists(string i_LicenseNumber)
        {
            return m_Vehicles.ContainsKey(i_LicenseNumber);
        }

        private Vehicle getVehicle(string i_LicenseNumber)
        {
            Vehicle vehicle;
            bool isVehicleExists = false;

            isVehicleExists = m_Vehicles.TryGetValue(i_LicenseNumber, out vehicle);

            if (isVehicleExists == false)
            {
                throw new ArgumentException("The vehicle isn't exists in garage");
            }

            return vehicle;
        }

        public string ToStringVehicle(string i_LicenseNumber)
        {
            Vehicle vehicleToString = getVehicle(i_LicenseNumber);
            string vehicleString = vehicleToString.ToString();

            return vehicleString;
        }
    }
}