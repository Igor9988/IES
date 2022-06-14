using FTN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel
{
	public class OutageSchedule : IrregularIntervalSchedule
	{
		private List<long> switchingoperations = new List<long>();

		public List<long> Switchingoperations { get => switchingoperations; set => switchingoperations = value; }
		public OutageSchedule(long globalId) : base(globalId)
		{

		}
        #region IAccess
        public override bool HasProperty(ModelCode prop)
        {
            switch (prop)
            {
                case ModelCode.OUTAGESCHEDULE_SWITCHINGOPEARTIONS:
                    return true;
                default:
                    return base.HasProperty(prop);
            }
        }

        public override void GetProperty(Property property)
        {
            switch (property.Id)
            {

                case ModelCode.OUTAGESCHEDULE_SWITCHINGOPEARTIONS:
                    property.SetValue(switchingoperations);
                    break;
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
        #endregion IAccess

        public override bool Equals(object obj)
		{
			if (base.Equals(obj))
			{
				OutageSchedule x = (OutageSchedule)obj;
				return (CompareHelper.CompareLists(x.switchingoperations, this.switchingoperations, true));
			}
			else
			{
				return false;
			}
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
        public override bool IsReferenced
        {
            get
            {
                return switchingoperations.Count != 0 || base.IsReferenced;
            }
        }



        public override void AddReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.SWITCHINGOPERATION_OUTAGESCHEDULE:
                    switchingoperations.Add(globalId);
                    break;

                default:
                    base.AddReference(referenceId, globalId);
                    break;
            }
        }

        public override void RemoveReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.SWITCHINGOPERATION_OUTAGESCHEDULE:

                    if (switchingoperations.Contains(globalId))
                    {
                        switchingoperations.Remove(globalId);
                    }
                    else
                    {
                        CommonTrace.WriteTrace(CommonTrace.TraceWarning, "Entity (GID = 0x{0:x16}) doesn't contain reference 0x{1:x16}.", this.GlobalId, globalId);
                    }

                    break;

                default:
                    base.RemoveReference(referenceId, globalId);
                    break;
            }
        }
    }
}
