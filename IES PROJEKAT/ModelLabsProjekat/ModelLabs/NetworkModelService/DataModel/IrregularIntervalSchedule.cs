using FTN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel
{
    public class IrregularIntervalSchedule : BasicIntervalSchedule
    {

        private List<long> timepoints = new List<long>();

        public List<long> Timepoints { get => timepoints; set => timepoints = value; }

        public IrregularIntervalSchedule(long globalId) : base(globalId)
        {

        }
        #region IAccess
        public override bool HasProperty(ModelCode prop)
        {
            switch (prop)
            {
                case ModelCode.IRREGULARINTERVALSCHEDULE_TIMEPOINTS:
                    return true;
                default:
                    return base.HasProperty(prop);
            }
        }

        public override void GetProperty(Property property)
        {
            switch (property.Id)
            {

                case ModelCode.IRREGULARINTERVALSCHEDULE_TIMEPOINTS:
                    property.SetValue(timepoints);
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
                IrregularIntervalSchedule x = (IrregularIntervalSchedule)obj;
                return (CompareHelper.CompareLists(x.timepoints, this.timepoints, true));
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
                return timepoints.Count != 0 || base.IsReferenced;
            }
        }



        public override void AddReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.IRREGULARTIMEPOINT_INTERVALSCHEDULE:
                    timepoints.Add(globalId);
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
                case ModelCode.IRREGULARTIMEPOINT_INTERVALSCHEDULE:

                    if (timepoints.Contains(globalId))
                    {
                        timepoints.Remove(globalId);
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
