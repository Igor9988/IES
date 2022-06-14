using FTN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel
{
    public class PowerSystemResource : IdentifiedObject
    {
		public PowerSystemResource(long globalId) : base(globalId)
		{
		}

        #region IAccess implementation

        public override bool HasProperty(ModelCode property)
        {
            return base.HasProperty(property);
        }

        public override void GetProperty(Property property)
        {
            switch (property.Id)
            {
                default:
                    base.GetProperty(property);
                    break;
            }
        }

        public override void SetProperty(Property property)
        {
            switch (property.Id)
            {
                default:
                    base.SetProperty(property);
                    break;
            }
        }

        #endregion IAccess implementation

        public override bool Equals(object obj)//proverava da li su ovi sto dolaze sa klijentske isti i proverava se nad klasa
		{
			return base.Equals(obj);

		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

	}
}
