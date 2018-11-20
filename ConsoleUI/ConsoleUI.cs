using System;
using System.Collections.Generic;

namespace Ex03
{
    internal class ConsoleUI
    {
        private readonly Garage garage = new Garage();

        public void GarageManager()
        {
            const int v_InsertVehicle = 1;
            const int v_ShowLicenseNumberList = 2;
            const int v_ChangeVehicleStatus = 3;
            const int v_InflateWheels = 4;
            const int v_Refuel = 5;
            const int v_Charge = 6;
            const int v_PrintVehicleInfo = 7;
            const int v_Exit = 8;

            bool isGarageProgramRunning = true;
            int userInput;

            printMenu();
            while (isGarageProgramRunning == true)
            {
                try
                {
                    userInput = int.Parse(Console.ReadLine());

                    switch (userInput)
                    {
                        case v_InsertVehicle:
                            insertVehicle();
                            break;
                        case v_ShowLicenseNumberList:
                            showLicenseNumberList();
                            break;
                        case v_ChangeVehicleStatus:
                            changeVehicleStatus();
                            break;
                        case v_InflateWheels:
                            inflateWheels();
                            break;
                        case v_Refuel:
                            refuelVehicle();
                            break;
                        case v_Charge:
                            chargeVehicleBattery();
                            break;
                        case v_PrintVehicleInfo:
                            printVehicleInfo();
                            break;
                        case v_Exit:
                            isGarageProgramRunning = false;
                            break;
                        default:
                            Console.WriteLine("Invalid choice number, try again:");
                            break;
                    }
                }
                catch (FormatException exception)
                {
                    Console.WriteLine("{0}", exception.Message);
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine("{0}", exception.Message);
                }
                catch (ValueOutOfRangeException exception)
                {
                    Console.WriteLine("{0}", exception.Message);
                }
                catch (NullReferenceException exception)
                {
                    Console.WriteLine("{0}", exception.Message);
                }

                if (isGarageProgramRunning == true)
                {
                    Console.WriteLine();
                    printMenu();
                    Console.WriteLine("Enter your next choice");
                }
            }
        }

        private void printMenu()
        {
            Console.WriteLine(String.Format(
@"Garage options:
1. Insert a new car to the garage
2. Show license number list
3. Change vehicle status
4. Blow up tires to the maximum
5. Refuel fuel-powered vehicles
6. Charge an electric vehicle
7. Show vehicle info by license number
8. Exit"));
        }

        private void insertVehicle()
        {
            Vehicle vehicleToInsert = null;
            string licenseNumber = readLicenseNumber();

            if (garage.isVehicleExists(licenseNumber) == true)
            {
                Console.WriteLine("The vehicle is already exists, vehicle status changed to repair");
                garage.ChangeVehicleStatus(licenseNumber, eVehicleStatus.Repair);
            }
            else
            {
                // build new
                eEnergySource energySourceType;
                eVehicleType vehicleType = readVehicleType();

                switch (vehicleType)
                {
                    case eVehicleType.Car:
                        vehicleToInsert = VehicleObjectFactory.CreateCar(licenseNumber);
                        break;
                    case eVehicleType.Motorbike:
                        vehicleToInsert = VehicleObjectFactory.CreateMotorbike(licenseNumber);
                        break;
                    case eVehicleType.Truck:
                        vehicleToInsert = VehicleObjectFactory.CreateTruck(licenseNumber);
                        break;
                }

                if (vehicleType == eVehicleType.Car || vehicleType == eVehicleType.Motorbike)
                {
                    energySourceType = readEnergySourceType();
                }
                else // truck
                {
                    energySourceType = eEnergySource.Fuel;
                }

                vehicleToInsert.AddEnergySource(energySourceType); 
                float energyLeftPercent = readEnergyLeftPercent();
                vehicleToInsert.EnergyLeftPercent = energyLeftPercent;
                vehicleToInsert.SetEnergySource(energySourceType, energyLeftPercent);

                setOwnerName(vehicleToInsert);
                setOwnerPhone(vehicleToInsert);
                setModelName(vehicleToInsert);
                setWheels(vehicleToInsert);

                if (vehicleType == eVehicleType.Motorbike)
                {
                    setLicenseType(vehicleToInsert);
                    setEngineCapacity(vehicleToInsert);
                }
                else if (vehicleType == eVehicleType.Car)
                {
                    setCarColor(vehicleToInsert);
                    setDoorsAmount(vehicleToInsert);
                }
                else if (vehicleType == eVehicleType.Truck)
                {
                    setTrunkType(vehicleToInsert);
                    setTrunkCapacity(vehicleToInsert);
                }

                garage.AddVehicle(vehicleToInsert);
                Console.WriteLine("The vehicle added successfully to the garage!");
            }
        }

        private void setWheels(Vehicle i_Vehicle)
        {
            string wheelManufacturerName = readWheelsManufacturerName();
            float wheelsCurrentAirPressure = readWheelsCurrentAirPressure();
            float wheelsMaxAirPressure = readWheelsMaxAirPressure();
            i_Vehicle.AddWheelsToVehicle(wheelManufacturerName, wheelsCurrentAirPressure, wheelsMaxAirPressure);
        }

        private string readLicenseNumber()
        {
            Console.WriteLine("Enter license number:");
            return Console.ReadLine();
        }

        private eVehicleType readVehicleType()
        {
            Console.WriteLine(String.Format(
@"Choose which type of vehicle you want to insert:
1. Motorbike
2. Car
3. Truck"));

            return ParseEnum<eVehicleType>(Console.ReadLine());
        }

        private void setModelName(Vehicle i_Vehicle)
        {
            Console.WriteLine("Enter model name:");
            i_Vehicle.ModelName = Console.ReadLine();
        }


        // get wheels methods
        private string readWheelsManufacturerName()
        {
            Console.WriteLine("Enter wheels manufacturer:");
            return Console.ReadLine();
        }

        private float readWheelsCurrentAirPressure()
        {
            Console.WriteLine("Enter wheels current air pressure:");
            return float.Parse(Console.ReadLine());
        }

        private float readWheelsMaxAirPressure()
        {
            Console.WriteLine("Enter wheels max air pressure:");
            return float.Parse(Console.ReadLine());
        }

        // owner methods
        private void setOwnerName(Vehicle i_Vehicle)
        {
            Console.WriteLine("Enter owner name:");
            i_Vehicle.VehicleOwner.Name = Console.ReadLine();
        }

        private void setOwnerPhone(Vehicle i_Vehicle)
        {
            Console.WriteLine("Enter owner phone:");
            i_Vehicle.VehicleOwner.PhoneNumber = Console.ReadLine();
        }

        // set motorbike methods
        private void setLicenseType(Vehicle i_Vehicle)
        {
            Motorbike motorbike = i_Vehicle as Motorbike;
            Console.WriteLine(String.Format(
@"Enter license type:
1. A
2. A1
3. B1
4. B2"));

            motorbike.LicenseType = ParseEnum<eLicenseType>(Console.ReadLine());
        }

        private void setEngineCapacity(Vehicle i_Vehicle)
        {
            Motorbike motorbike = i_Vehicle as Motorbike;
            Console.WriteLine("Enter engine capacity:");
            motorbike.EngineCapacity = int.Parse(Console.ReadLine());
        }

        // set car methods
        private void setCarColor(Vehicle i_Vehicle)
        {
            Car car = i_Vehicle as Car;
            Console.WriteLine(String.Format(
@"Enter car color:
1. Gray
2. Blue
3. White
4. Black"));
            car.Color = ParseEnum<eCarColor>(Console.ReadLine());
        }

        private void setDoorsAmount(Vehicle i_Vehicle)
        {
            Car car = i_Vehicle as Car;
            Console.WriteLine("Enter doors amount (2/3/4/5):");

            car.DoorsAmount = ParseEnum<eDoorsAmount>(Console.ReadLine());
        }

        // set truck methods
        private void setTrunkType(Vehicle i_Vehicle)
        {
            Truck truck = i_Vehicle as Truck;

            Console.WriteLine(String.Format(
@"The trunk cooled?
1. Yes
2. No"));
            int trunkTypeInput = int.Parse(Console.ReadLine());
            truck.IsTrunkCooled = (trunkTypeInput == 1) ? (true) : (false);
        }

        private void setTrunkCapacity(Vehicle i_Vehicle)
        {
            Truck truck = i_Vehicle as Truck;

            Console.WriteLine("Enter trunk capacity:");
            truck.TrunkCapacity = float.Parse(Console.ReadLine());
        }

        private float readEnergyLeftPercent()
        {
            Console.WriteLine("Enter energy left percent:");
            string leftPercentsStr = Console.ReadLine();

            if (leftPercentsStr[leftPercentsStr.Length - 1] == '%')
            {
                float leftPercentsFloat = float.Parse(leftPercentsStr.Substring(0, leftPercentsStr.Length - 1));
                if (leftPercentsFloat >= 0.0F && leftPercentsFloat <= 100.0F)
                {
                    return leftPercentsFloat;
                }
                else
                {
                    throw new ValueOutOfRangeException(0.0F, 100.0F);
                }
            }

            throw new FormatException("Percent value must end with %");
        }

        private eEnergySource readEnergySourceType()
        {
            Console.WriteLine(String.Format(
@"Choose energy source type:
1. Fuel-powered
2. Electric"));

            return ParseEnum<eEnergySource>(Console.ReadLine());
        }

        private void showLicenseNumberList()
        {
            List<string> vehicleList;

            Console.WriteLine(String.Format(
@"Filter list by:
1. Repair
2. Fixed
3. Paid
4. None"));
            string filterByString = Console.ReadLine();

            eVehicleFilter filterByEnum = ParseEnum<eVehicleFilter>(filterByString);
            vehicleList = garage.GetVehicleList(filterByEnum);

            foreach (string licenseNumber in vehicleList)
            {
                Console.WriteLine(licenseNumber);
            }

            if (vehicleList.Count == 0)
            {
                Console.WriteLine("There is no vehicle in this status");
            }
        }

        private void inflateWheels()
        {
            string licenseNumber = readLicenseNumber();
            garage.InflateVehicleWheels(licenseNumber);
        }

        private void changeVehicleStatus()
        {
            string licenseNumber = readLicenseNumber();

            Console.WriteLine(String.Format(
@"Enter the new vehicle status:
1. Repair
2. Fixed
3. Paid"));
            eVehicleStatus newStatus = ParseEnum<eVehicleStatus>(Console.ReadLine());
            garage.ChangeVehicleStatus(licenseNumber, newStatus);
        }

        private void refuelVehicle()
        {
            string licenseNumber = readLicenseNumber();

            Console.WriteLine(String.Format(
@"Enter fuel type:
1. Soler
2. Octan95
3. Octan96
4. Octan98"));
            eFuelType fuelType = ParseEnum<eFuelType>(Console.ReadLine());
            Console.WriteLine("Enter amount of fuel to add:");
            float fuelAmount = float.Parse(Console.ReadLine());
            garage.RefuelVehicle(licenseNumber, fuelType, fuelAmount);
        }

        private void chargeVehicleBattery()
        {
            string licenseNumber = readLicenseNumber();
            Console.WriteLine("Enter amount of hours to add:");
            float chargeHoursAmount = float.Parse(Console.ReadLine());
            garage.ChargeVehicleBattery(licenseNumber, chargeHoursAmount);
        }

        private void printVehicleInfo()
        {
            string licenseNumber = readLicenseNumber();

            Console.WriteLine(String.Format(@"
The details about {0} vehicle:
{1}", licenseNumber, garage.ToStringVehicle(licenseNumber)));
        }

        // Enum Util
        private T ParseEnum<T>(string i_String)
        {
            if (Enum.IsDefined(typeof(T), i_String)) // Parse string to enum
            {
                return (T)Enum.Parse(typeof(T), i_String, true);
            }
            else if (Enum.IsDefined(typeof(T), int.Parse(i_String))) // Parse int to enum
            {
                return (T)Enum.ToObject(typeof(T), int.Parse(i_String));
            }
            else
            {
                throw new FormatException();
            }
        }
    }
}