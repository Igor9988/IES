using FTN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel
{
    public class IrregularTimePoint : IdentifiedObject
    {
        public IrregularTimePoint(long globalId) : base(globalId)
        {

        }
       
        private long intervalSchedule;
        private float time;
        private float value1;
        private float value2;

        public long IntervalSchedule { get => intervalSchedule; set => intervalSchedule = value; }
        public float Time { get => time; set => time = value; }
        public float Value1 { get => value1; set => value1 = value; }
        public float Value2 { get => value2; set => value2 = value; }

        #region IAccess
        public override bool HasProperty(ModelCode prop)
        {
            switch (prop)
            {
                case ModelCode.IRREGULARTIMEPOINT_TIME:
                case ModelCode.IRREGULARTIMEPOINT_VALUE1:
                case ModelCode.IRREGULARTIMEPOINT_VALUE2:
                case ModelCode.IRREGULARTIMEPOINT_INTERVALSCHEDULE:
                    return true;
                default:
                    return base.HasProperty(prop);
            }
        }

        public override void GetProperty(Property property)
        {
            switch (property.Id)
            {

                case ModelCode.IRREGULARTIMEPOINT_TIME:
                    property.SetValue(time);
                    break;
                case ModelCode.IRREGULARTIMEPOINT_VALUE1:
                    property.SetValue(value1);
                    break;
                case ModelCode.IRREGULARTIMEPOINT_VALUE2:
                    property.SetValue(value2);
                    break;
                case ModelCode.IRREGULARTIMEPOINT_INTERVALSCHEDULE:
                    property.SetValue(intervalSchedule);
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
                case ModelCode.IRREGULARTIMEPOINT_TIME:
                    time = property.AsFloat();
                    break;
                case ModelCode.IRREGULARTIMEPOINT_VALUE1:
                    value1 = property.AsFloat();
                    break;
                case ModelCode.IRREGULARTIMEPOINT_VALUE2:
                    value2 = property.AsFloat();
                    break;
                case ModelCode.IRREGULARTIMEPOINT_INTERVALSCHEDULE:
                    intervalSchedule = property.AsReference();
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
                IrregularTimePoint x = (IrregularTimePoint)obj;
                return (x.intervalSchedule == this.intervalSchedule && x.time == this.time && x.value1 == this.value1 && x.value2 == this.value2);
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
    }
}
