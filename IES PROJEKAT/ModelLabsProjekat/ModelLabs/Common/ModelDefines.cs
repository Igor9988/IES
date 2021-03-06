using System;
using System.Collections.Generic;
using System.Text;

namespace FTN.Common
{
	
	public enum DMSType : short
	{		
		MASK_TYPE							= unchecked((short)0xFFFF),

		/*BASEVOLTAGE							= 0x0001,
		LOCATION							= 0x0002,
		POWERTR								= 0x0003,
		POWERTRWINDING						= 0x0004,
		WINDINGTEST							= 0x0005,*/

		DISCONNECTOR = 0x0001,
		IRREGULARTIMEPOINT = 0x0002,
		OUTAGESCHEDULE = 0x0003,
		REGULARINTERVALSCHEDULE = 0x0004,
		REGULARTIMEPOINT = 0x0005,
		SWITCHINGOPERATION = 0x0006,
	}

    [Flags]
	public enum ModelCode : long
	{
		/*IDOBJ								= 0x1000000000000000,
		IDOBJ_GID							= 0x1000000000000104,
		IDOBJ_DESCRIPTION					= 0x1000000000000207,
		IDOBJ_MRID							= 0x1000000000000307,
		IDOBJ_NAME							= 0x1000000000000407,	

		PSR									= 0x1100000000000000,
		PSR_CUSTOMTYPE						= 0x1100000000000107,
		PSR_LOCATION						= 0x1100000000000209,

		BASEVOLTAGE							= 0x1200000000010000,
		BASEVOLTAGE_NOMINALVOLTAGE			= 0x1200000000010105,
		BASEVOLTAGE_CONDEQS					= 0x1200000000010219,

		LOCATION							= 0x1300000000020000,
		LOCATION_CORPORATECODE				= 0x1300000000020107,
		LOCATION_CATEGORY					= 0x1300000000020207,
		LOCATION_PSRS						= 0x1300000000020319,

		WINDINGTEST							= 0x1400000000050000,
		WINDINGTEST_LEAKIMPDN				= 0x1400000000050105,
		WINDINGTEST_LOADLOSS				= 0x1400000000050205,
		WINDINGTEST_NOLOADLOSS				= 0x1400000000050305,
		WINDINGTEST_PHASESHIFT				= 0x1400000000050405,
		WINDINGTEST_LEAKIMPDN0PERCENT		= 0x1400000000050505,
		WINDINGTEST_LEAKIMPDNMINPERCENT		= 0x1400000000050605,
		WINDINGTEST_LEAKIMPDNMAXPERCENT		= 0x1400000000050705,
		WINDINGTEST_POWERTRWINDING			= 0x1400000000050809,

		EQUIPMENT							= 0x1110000000000000,
		EQUIPMENT_ISUNDERGROUND				= 0x1110000000000101,
		EQUIPMENT_ISPRIVATE					= 0x1110000000000201,		

		CONDEQ								= 0x1111000000000000,
		CONDEQ_PHASES						= 0x111100000000010a,
		CONDEQ_RATEDVOLTAGE					= 0x1111000000000205,
		CONDEQ_BASVOLTAGE					= 0x1111000000000309,

		POWERTR								= 0x1112000000030000,
		POWERTR_FUNC						= 0x111200000003010a,
		POWERTR_AUTO						= 0x1112000000030201,
		POWERTR_WINDINGS					= 0x1112000000030319,

		POWERTRWINDING						= 0x1111100000040000,
		POWERTRWINDING_CONNTYPE				= 0x111110000004010a,
		POWERTRWINDING_GROUNDED				= 0x1111100000040201,
		POWERTRWINDING_RATEDS				= 0x1111100000040305,
		POWERTRWINDING_RATEDU				= 0x1111100000040405,
		POWERTRWINDING_WINDTYPE				= 0x111110000004050a,
		POWERTRWINDING_PHASETOGRNDVOLTAGE	= 0x1111100000040605,
		POWERTRWINDING_PHASETOPHASEVOLTAGE	= 0x1111100000040705,
		POWERTRWINDING_POWERTRW				= 0x1111100000040809,
		POWERTRWINDING_TESTS				= 0x1111100000040919,*/

		IDOBJ = 0x1000000000000000,
		IDOBJ_GID = 0x1000000000000104,
		IDOBJ_ALIASNAME = 0x1000000000000207,
		IDOBJ_MRID = 0x1000000000000307,
		IDOBJ_NAME = 0x1000000000000407,

		BASICINTERVALSCHEDULE = 0x1100000000000000,
		BASICINTERVALSCHEDULE_STARTTIME = 0x1100000000000108,
		BASICINTERVALSCHEDULE_VALUE1MULTIPLIER = 0x110000000000020a,
		BASICINTERVALSCHEDULE_VALUE1UNIT = 0x110000000000030a,
		BASICINTERVALSCHEDULE_VALUE2MULTIPLIER = 0x11000000000040a,
		BASICINTERVALSCHEDULE_VALUE2UNIT = 0x110000000000050a,


		REGULARTIMEPOINT = 0x1200000000050000,
		REGULARTIMEPOINT_SEQUENCENUMBER = 0x1200000000050104,
		REGULARTIMEPOINT_VALUE1 = 0x1200000000050205,
		REGULARTIMEPOINT_VALUE2 = 0x1200000000050305,
		REGULARTIMEPOINT_INTERVALSCHEDULE = 0x1200000000050409,


		IRREGULARTIMEPOINT = 0x1300000000020000,
		IRREGULARTIMEPOINT_TIME = 0x130000000002010a,
		IRREGULARTIMEPOINT_VALUE1 = 0x1300000000020205,
		IRREGULARTIMEPOINT_VALUE2 = 0x1300000000020305,
		IRREGULARTIMEPOINT_INTERVALSCHEDULE = 0x1300000000020409,

		SWITCHINGOPERATION  = 0x1400000000060000,
		SWITCHINGOPERATION_NEWSTATE  = 0x1400000000060104,
		SWITCHINGOPERATION_OPERATIONTIME  = 0x1400000000060208,
		SWITCHINGOPERATION_OUTAGESCHEDULE  = 0x1400000000060309,
		SWITCHINGOPERATION_SWITCHES  = 0x1400000000060419,


		
		POWERSYSTEMRESOURCE = 0x1500000000000000,
		EQUIPMENT = 0x1510000000000000,
		CONDUCTINGEQUIPMENT = 0x1511000000000000,

		SWITCH = 0x1511100000000000,
		SWITCH_SWITCHINGOPERATION = 0x1511100000000119,

		DISCONNECTOR = 0x1511110000010000,

		IRREGULARINTERVALSCHEDULE = 0x1110000000000000,
		IRREGULARINTERVALSCHEDULE_TIMEPOINTS = 0x1110000000000119,

		OUTAGESCHEDULE = 0x1111000000030000,
		OUTAGESCHEDULE_SWITCHINGOPEARTIONS = 0x1111000000030119,

		REGULARINTERVALSCHEDULE = 0x1120000000040000,
		REGULARINTERVALSCHEDULE_ENDTIME = 0x1120000000040108,
		REGULARINTERVALSCHEDULE_TIMESTEP = 0x1120000000040209,
		REGULARINTERVALSCHEDULE_TIMEPOINTS = 0x1120000000040319



	}

    [Flags]
	public enum ModelCodeMask : long
	{
		MASK_TYPE			 = 0x00000000ffff0000,
		MASK_ATTRIBUTE_INDEX = 0x000000000000ff00,
		MASK_ATTRIBUTE_TYPE	 = 0x00000000000000ff,

		MASK_INHERITANCE_ONLY = unchecked((long)0xffffffff00000000),
		MASK_FIRSTNBL		  = unchecked((long)0xf000000000000000),
		MASK_DELFROMNBL8	  = unchecked((long)0xfffffff000000000),		
	}																		
}


