using FTN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel
{
    public class SwitchingOperation : IdentifiedObject
    {
        public SwitchingOperation(long globalId) : base(globalId)
        {

        }
        private SwitchState newState;
        private DateTime operationTime;
        private long outageSchedule;
        private List<long> switches = new List<long>();

        public SwitchState NewState { get => newState; set => newState = value; }
        public DateTime OperationTime { get => operationTime; set => operationTime = value; }
        public long OutageSchedule { get => outageSchedule; set => outageSchedule = value; }
        public List<long> Switches { get => switches; set => switches = value; }
        #region IAccess
        public override bool HasProperty(ModelCode prop)
        {
            switch (prop)
            {
                case ModelCode.SWITCHINGOPERATION_NEWSTATE:
                case ModelCode.SWITCHINGOPERATION_OPERATIONTIME:
                case ModelCode.SWITCHINGOPERATION_OUTAGESCHEDULE:
                case ModelCode.SWITCHINGOPERATION_SWITCHES:
                    return true;
                default:
                    return base.HasProperty(prop);
            }
        }

        public override void GetProperty(Property property)
        {
            switch (property.Id)
            {

                case ModelCode.SWITCHINGOPERATION_NEWSTATE:
                    property.SetValue((short)newState);
                    break;
                case ModelCode.SWITCHINGOPERATION_OPERATIONTIME:
                    property.SetValue(operationTime);
                    break;
                case ModelCode.SWITCHINGOPERATION_OUTAGESCHEDULE:
                    property.SetValue(outageSchedule);
                    break;
                case ModelCode.SWITCHINGOPERATION_SWITCHES:
                    property.SetValue(switches);
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
                case ModelCode.SWITCHINGOPERATION_NEWSTATE:
                    newState = (SwitchState)property.AsEnum();
                    break;
                case ModelCode.SWITCHINGOPERATION_OPERATIONTIME:
                    operationTime = property.AsDateTime();
                    break;
                case ModelCode.SWITCHINGOPERATION_OUTAGESCHEDULE:
                    outageSchedule = property.AsReference();
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
                SwitchingOperation x = (SwitchingOperation)obj;
                return (x.outageSchedule == this.outageSchedule && x.newState == this.newState && x.operationTime == this.operationTime && CompareHelper.CompareLists(x.switches, this.switches));
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
                return switches.Count != 0 || base.IsReferenced;
            }
        }



        public override void AddReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.SWITCH_SWITCHINGOPERATION:
                    switches.Add(globalId);
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
                case ModelCode.SWITCH_SWITCHINGOPERATION:

                    if (switches.Contains(globalId))
                    {
                        switches.Remove(globalId);
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
