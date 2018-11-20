using System;

namespace Ex03
{
    internal class Wheel
    {
        // Attributes
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private readonly float m_MaxAirPressure;

        // Methods
        internal Wheel(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            m_ManufacturerName = i_ManufacturerName;
            m_CurrentAirPressure = i_CurrentAirPressure;
            m_MaxAirPressure = i_MaxAirPressure;
        }

        internal void InflateWheel(float i_AirPressure)
        {
            if (m_CurrentAirPressure + i_AirPressure > m_MaxAirPressure || i_AirPressure < 0.0F)
            {
                throw new ValueOutOfRangeException(0.0F, m_MaxAirPressure - m_CurrentAirPressure);
            }

            m_CurrentAirPressure += i_AirPressure;
        }

        internal void inflateWheelToMax()
        {
            InflateWheel(m_MaxAirPressure - m_CurrentAirPressure);
        }

        public override string ToString()
        {
            return String.Format(
@"ManufacturerName                    {0}
CurrentAirPressure                  {1}
MaxAirPressure                      {2}", m_ManufacturerName, m_CurrentAirPressure, m_MaxAirPressure);
        }
    }
}
