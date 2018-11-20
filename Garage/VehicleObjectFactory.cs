namespace Ex03
{
    public static class VehicleObjectFactory
    {
        // Methods
        public static Vehicle CreateMotorbike(string i_LicenseNumber)
        {
            return new Motorbike(i_LicenseNumber);
        }

        public static Vehicle CreateCar(string i_LicenseNumber)
        {
            return new Car(i_LicenseNumber);
        }

        public static Vehicle CreateTruck(string i_LicenseNumber)
        {
            return new Truck(i_LicenseNumber);
        }
    }
}