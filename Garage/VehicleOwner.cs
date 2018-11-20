namespace Ex03
{
    public class VehicleOwner
    {
        // Attributes
        private string m_Name;
        private string m_PhoneNumber;

        // Properties
        public string Name
        {
            get
            {
                return m_Name;
            }
            set
            {
                m_Name = value;
            }
        }
        public string PhoneNumber
        {
            get
            {
                return m_PhoneNumber;
            }
            set
            {
                m_PhoneNumber = value;
            }
        }
    }
}
