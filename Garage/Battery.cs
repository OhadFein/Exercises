using System;

namespace Ex03
{
    public class Battery : EnergySource
    {
        // Methods

        internal void Charge(float i_HoursAmount)
        {
            if (base.CurrentEnergySourceAmount + i_HoursAmount > base.MaxEnergySourceAmount || i_HoursAmount < 0.0F)
            {
                throw new ValueOutOfRangeException(0.0F, base.MaxEnergySourceAmount - base.CurrentEnergySourceAmount);
            }

            base.CurrentEnergySourceAmount += i_HoursAmount;
        }

        public override string ToString()
        {
            return String.Format(
@"Energy Source                       {0}
{1}", this.GetType().Name, base.ToString());
        }
    }
}
