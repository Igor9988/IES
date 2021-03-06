//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FTN {
    using System;
    using FTN;
    
    
    /// A SwitchingOperation is used to define individual switch operations for an OutageSchedule. This OutageSchedule may be associated with another item of Substation such as a Transformer, Line, or Generator; or with the Switch itself as a PowerSystemResource. A Switch may be referenced by many OutageSchedules.
    public class SwitchingOperation : IdentifiedObject {
        
        /// The switch position that shall result from this SwitchingOperation.
        private SwitchState? cim_newState;
        
        private const bool isNewStateMandatory = false;
        
        private const string _newStatePrefix = "cim";
        
        /// Time of operation in same units as OutageSchedule.xAxixUnits.
        private System.DateTime? cim_operationTime;
        
        private const bool isOperationTimeMandatory = false;
        
        private const string _operationTimePrefix = "cim";
        
        /// An OutageSchedule may operate many switches.
        private OutageSchedule cim_OutageSchedule;
        
        private const bool isOutageScheduleMandatory = false;
        
        private const string _OutageSchedulePrefix = "cim";
        
        public virtual SwitchState NewState {
            get {
                return this.cim_newState.GetValueOrDefault();
            }
            set {
                this.cim_newState = value;
            }
        }
        
        public virtual bool NewStateHasValue {
            get {
                return this.cim_newState != null;
            }
        }
        
        public static bool IsNewStateMandatory {
            get {
                return isNewStateMandatory;
            }
        }
        
        public static string NewStatePrefix {
            get {
                return _newStatePrefix;
            }
        }
        
        public virtual System.DateTime OperationTime {
            get {
                return this.cim_operationTime.GetValueOrDefault();
            }
            set {
                this.cim_operationTime = value;
            }
        }
        
        public virtual bool OperationTimeHasValue {
            get {
                return this.cim_operationTime != null;
            }
        }
        
        public static bool IsOperationTimeMandatory {
            get {
                return isOperationTimeMandatory;
            }
        }
        
        public static string OperationTimePrefix {
            get {
                return _operationTimePrefix;
            }
        }
        
        public virtual OutageSchedule OutageSchedule {
            get {
                return this.cim_OutageSchedule;
            }
            set {
                this.cim_OutageSchedule = value;
            }
        }
        
        public virtual bool OutageScheduleHasValue {
            get {
                return this.cim_OutageSchedule != null;
            }
        }
        
        public static bool IsOutageScheduleMandatory {
            get {
                return isOutageScheduleMandatory;
            }
        }
        
        public static string OutageSchedulePrefix {
            get {
                return _OutageSchedulePrefix;
            }
        }
    }
}
