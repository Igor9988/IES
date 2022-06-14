using FTN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel
{
    public class RegularIntervalSchedule : IdentifiedObject
    {
        private List<long> timepoints = new List<long>();
        private DateTime endTime;
        private float timeStep;
        public RegularIntervalSchedule(long globalId) : base(globalId)
        {

        }

        public List<long> Timepoints { get => timepoints; set => timepoints = value; }
        public DateTime EndTime { get => endTime; set => endTime = value; }
        public float TimeStep { get => timeStep; set => timeStep = value; }

        #region IAccess
        public override bool HasProperty(ModelCode prop)
        {
            switch (prop)
            {
                case ModelCode.REGULARINTERVALSCHEDULE_ENDTIME:
                case ModelCode.REGULARINTERVALSCHEDULE_TIMESTEP:
                case ModelCode.REGULARINTERVALSCHEDULE_TIMEPOINTS:
                return true;
                default:
                    return base.HasProperty(prop);
            }
        }

        public override void GetProperty(Property property)
        {
            switch (property.Id)
            {

                case ModelCode.REGULARINTERVALSCHEDULE_ENDTIME:
                    property.SetValue(endTime);
                    break;
                case ModelCode.REGULARINTERVALSCHEDULE_TIMESTEP:
                    property.SetValue(timeStep);
                    break;
                case ModelCode.REGULARINTERVALSCHEDULE_TIMEPOINTS:
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
                case ModelCode.REGULARINTERVALSCHEDULE_ENDTIME:
                    endTime = property.AsDateTime();
                    break;
                case ModelCode.REGULARINTERVALSCHEDULE_TIMESTEP:
                    timeStep = property.AsFloat();
                    break;

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
                RegularIntervalSchedule x = (RegularIntervalSchedule)obj;
                return (CompareHelper.CompareLists(x.timepoints, this.timepoints, true) && x.endTime == this.endTime && x.timeStep == this.timeStep);
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
                case ModelCode.REGULARTIMEPOINT_INTERVALSCHEDULE:
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
                case ModelCode.REGULARTIMEPOINT_INTERVALSCHEDULE:

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
