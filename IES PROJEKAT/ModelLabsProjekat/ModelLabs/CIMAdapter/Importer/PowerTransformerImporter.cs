using System;
using System.Collections.Generic;
using CIM.Model;
using FTN.Common;
using FTN.ESI.SIMES.CIM.CIMAdapter.Manager;

namespace FTN.ESI.SIMES.CIM.CIMAdapter.Importer
{
	/// <summary>
	/// PowerTransformerImporter
	/// </summary>
	public class PowerTransformerImporter
	{
		/// <summary> Singleton </summary>
		private static PowerTransformerImporter ptImporter = null;
		private static object singletoneLock = new object();

		private ConcreteModel concreteModel;
		private Delta delta;
		private ImportHelper importHelper;
		private TransformAndLoadReport report;


		#region Properties
		public static PowerTransformerImporter Instance
		{
			get
			{
				if (ptImporter == null)
				{
					lock (singletoneLock)
					{
						if (ptImporter == null)
						{
							ptImporter = new PowerTransformerImporter();
							ptImporter.Reset();
						}
					}
				}
				return ptImporter;
			}
		}

		public Delta NMSDelta
		{
			get 
			{
				return delta;
			}
		}
		#endregion Properties


		public void Reset()
		{
			concreteModel = null;
			delta = new Delta();
			importHelper = new ImportHelper();
			report = null;
		}

		public TransformAndLoadReport CreateNMSDelta(ConcreteModel cimConcreteModel)
		{
			LogManager.Log("Importing PowerTransformer Elements...", LogLevel.Info);
			report = new TransformAndLoadReport();
			concreteModel = cimConcreteModel;
			delta.ClearDeltaOperations();

			if ((concreteModel != null) && (concreteModel.ModelMap != null))
			{
				try
				{
					// convert into DMS elements
					ConvertModelAndPopulateDelta();
				}
				catch (Exception ex)
				{
					string message = string.Format("{0} - ERROR in data import - {1}", DateTime.Now, ex.Message);
					LogManager.Log(message);
					report.Report.AppendLine(ex.Message);
					report.Success = false;
				}
			}
			LogManager.Log("Importing PowerTransformer Elements - END.", LogLevel.Info);
			return report;
		}

		/// <summary>
		/// Method performs conversion of network elements from CIM based concrete model into DMS model.
		/// </summary>
		private void ConvertModelAndPopulateDelta()
		{
			LogManager.Log("Loading elements and creating delta...", LogLevel.Info);

			//// import all concrete model types (DMSType enum)
			/*ImportBaseVoltages();
			ImportLocations();
			ImportPowerTransformers();
			ImportTransformerWindings();
			ImportWindingTests();*/


			LogManager.Log("Loading elements and creating delta completed.", LogLevel.Info);
		}

		#region Import
		private void ImportDisconnector()
		{
			SortedDictionary<string, object> cimDisconnectors = concreteModel.GetAllObjectsOfType("FTN.Disconnector");
			if (cimDisconnectors != null)
			{
				foreach (KeyValuePair<string, object> cimDisconnectorPair in cimDisconnectors)
				{
					FTN.Disconnector cimDisconnector = cimDisconnectorPair.Value as FTN.Disconnector;

					ResourceDescription rd = CreateDisconnectorResourceDescription(cimDisconnector);
					if (rd != null)
					{
						delta.AddDeltaOperation(DeltaOpType.Insert, rd, true);
						report.Report.Append("Disconnector ID = ").Append(cimDisconnector.ID).Append(" SUCCESSFULLY converted to GID = ").AppendLine(rd.Id.ToString());
					}
					else
					{
						report.Report.Append("Disconnector ID = ").Append(cimDisconnector.ID).AppendLine(" FAILED to be converted");
					}
				}
				report.Report.AppendLine();
			}
		}


		private ResourceDescription CreateDisconnectorResourceDescription(FTN.Disconnector cimDisconnector)
		{
			ResourceDescription rd = null;
			if (cimDisconnector != null)
			{
				long gid = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.DISCONNECTOR, importHelper.CheckOutIndexForDMSType(DMSType.DISCONNECTOR));
				rd = new ResourceDescription(gid);
				importHelper.DefineIDMapping(cimDisconnector.ID, gid);

				////populate ResourceDescription
				PowerTransformerConverter.PopulateDisconnectorProperties(cimDisconnector, rd, importHelper, report);
			}
			return rd;
		}
		private void ImportIrregularTimePoint()
		{
			SortedDictionary<string, object> cimIrregularTimepoints = concreteModel.GetAllObjectsOfType("FTN.IrregularTimePoint");
			if (cimIrregularTimepoints != null)
			{
				foreach (KeyValuePair<string, object> cimcimIrregularTimepointPair in cimIrregularTimepoints)
				{
					FTN.IrregularTimePoint cimIrregularTimePoint = cimcimIrregularTimepointPair.Value as FTN.IrregularTimePoint;

					ResourceDescription rd = CreateIrregularTimePointResourceDescription(cimIrregularTimePoint);
					if (rd != null)
					{
						delta.AddDeltaOperation(DeltaOpType.Insert, rd, true);
						report.Report.Append("IrregularTimePoint ID = ").Append(cimIrregularTimePoint.ID).Append(" SUCCESSFULLY converted to GID = ").AppendLine(rd.Id.ToString());
					}
					else
					{
						report.Report.Append("IrregularTimePoint ID = ").Append(cimIrregularTimePoint.ID).AppendLine(" FAILED to be converted");
					}
				}
				report.Report.AppendLine();
			}
		}


		private ResourceDescription CreateIrregularTimePointResourceDescription(FTN.IrregularTimePoint cimIrregularTimePoint)
		{
			ResourceDescription rd = null;
			if (cimIrregularTimePoint != null)
			{
				long gid = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.IRREGULARTIMEPOINT, importHelper.CheckOutIndexForDMSType(DMSType.IRREGULARTIMEPOINT));
				rd = new ResourceDescription(gid);
				importHelper.DefineIDMapping(cimIrregularTimePoint.ID, gid);

				////populate ResourceDescription
				PowerTransformerConverter.PopulateIrregularTimePointProperties(cimIrregularTimePoint , rd, importHelper, report);
			}
			return rd;
		}
		private void ImportOutageSchedule()
		{
			SortedDictionary<string, object> cimOutageSchedules = concreteModel.GetAllObjectsOfType("FTN.OutageSchedule");
			if (cimOutageSchedules != null)
			{
				foreach (KeyValuePair<string, object> cimOutageSchedulePair in cimOutageSchedules)
				{
					FTN.OutageSchedule cimOutageSchedule = cimOutageSchedulePair.Value as FTN.OutageSchedule;

					ResourceDescription rd = CreateOutageScheduleResourceDescription(cimOutageSchedule);
					if (rd != null)
					{
						delta.AddDeltaOperation(DeltaOpType.Insert, rd, true);
						report.Report.Append("OutageSchedule ID = ").Append(cimOutageSchedule.ID).Append(" SUCCESSFULLY converted to GID = ").AppendLine(rd.Id.ToString());
					}
					else
					{
						report.Report.Append("OutageSchedule ID = ").Append(cimOutageSchedule.ID).AppendLine(" FAILED to be converted");
					}
				}
				report.Report.AppendLine();
			}
		}


		private ResourceDescription CreateOutageScheduleResourceDescription(FTN.OutageSchedule cimOutageSchedule)
		{
			ResourceDescription rd = null;
			if (cimOutageSchedule != null)
			{
				long gid = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.OUTAGESCHEDULE, importHelper.CheckOutIndexForDMSType(DMSType.OUTAGESCHEDULE));
				rd = new ResourceDescription(gid);
				importHelper.DefineIDMapping(cimOutageSchedule.ID, gid);

				////populate ResourceDescription
				PowerTransformerConverter.PopulateOutageScheduleProperties(cimOutageSchedule, rd, importHelper, report);
			}
			return rd;
		}
		private void ImportRegularTimePoint()
		{
			SortedDictionary<string, object> cimRegularTimepoints = concreteModel.GetAllObjectsOfType("FTN.RegularTimePoint");
			if (cimRegularTimepoints != null)
			{
				foreach (KeyValuePair<string, object> cimcimRegularTimepointPair in cimRegularTimepoints)
				{
					FTN.RegularTimePoint cimRegularTimePoint = cimcimRegularTimepointPair.Value as FTN.RegularTimePoint;

					ResourceDescription rd = CreateRegularTimePointResourceDescription(cimRegularTimePoint);
					if (rd != null)
					{
						delta.AddDeltaOperation(DeltaOpType.Insert, rd, true);
						report.Report.Append("RegularTimePoint ID = ").Append(cimRegularTimePoint.ID).Append(" SUCCESSFULLY converted to GID = ").AppendLine(rd.Id.ToString());
					}
					else
					{
						report.Report.Append("RegularTimePoint ID = ").Append(cimRegularTimePoint.ID).AppendLine(" FAILED to be converted");
					}
				}
				report.Report.AppendLine();
			}
		}


		private ResourceDescription CreateRegularTimePointResourceDescription(FTN.RegularTimePoint cimRegularTimePoint)
		{
			ResourceDescription rd = null;
			if (cimRegularTimePoint != null)
			{
				long gid = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.REGULARTIMEPOINT, importHelper.CheckOutIndexForDMSType(DMSType.REGULARTIMEPOINT));
				rd = new ResourceDescription(gid);
				importHelper.DefineIDMapping(cimRegularTimePoint.ID, gid);

				////populate ResourceDescription
				PowerTransformerConverter.PopulateRegularTimePointProperties(cimRegularTimePoint, rd, importHelper, report);
			}
			return rd;
		}
		private void ImportRegularIntervalSchedule()
		{
			SortedDictionary<string, object> cimRegularIntervalSchedules = concreteModel.GetAllObjectsOfType("FTN.RegularIntervalSchedule");
			if (cimRegularIntervalSchedules != null)
			{
				foreach (KeyValuePair<string, object> cimRegularIntervalSchedulePair in cimRegularIntervalSchedules)
				{
					FTN.RegularIntervalSchedule cimRegularIntervalSchedule = cimRegularIntervalSchedulePair.Value as FTN.RegularIntervalSchedule;

					ResourceDescription rd = CreateRegularIntervalScheduleResourceDescription(cimRegularIntervalSchedule);
					if (rd != null)
					{
						delta.AddDeltaOperation(DeltaOpType.Insert, rd, true);
						report.Report.Append("RegularIntervalSchedule ID = ").Append(cimRegularIntervalSchedule.ID).Append(" SUCCESSFULLY converted to GID = ").AppendLine(rd.Id.ToString());
					}
					else
					{
						report.Report.Append("RegularIntervalSchedule ID = ").Append(cimRegularIntervalSchedule.ID).AppendLine(" FAILED to be converted");
					}
				}
				report.Report.AppendLine();
			}
		}


		private ResourceDescription CreateRegularIntervalScheduleResourceDescription(FTN.RegularIntervalSchedule cimRegularIntervalSchedule)
		{
			ResourceDescription rd = null;
			if (cimRegularIntervalSchedule != null)
			{
				long gid = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.REGULARINTERVALSCHEDULE, importHelper.CheckOutIndexForDMSType(DMSType.REGULARINTERVALSCHEDULE));
				rd = new ResourceDescription(gid);
				importHelper.DefineIDMapping(cimRegularIntervalSchedule.ID, gid);

				////populate ResourceDescription
				PowerTransformerConverter.PopulateRegularIntervalScheduleProperties(cimRegularIntervalSchedule, rd, importHelper, report);
			}
			return rd;
		}
		/*private void ImportBaseVoltages()
		{
			SortedDictionary<string, object> cimBaseVoltages = concreteModel.GetAllObjectsOfType("FTN.BaseVoltage");
			if (cimBaseVoltages != null)
			{
				foreach (KeyValuePair<string, object> cimBaseVoltagePair in cimBaseVoltages)
				{
					FTN.BaseVoltage cimBaseVoltage = cimBaseVoltagePair.Value as FTN.BaseVoltage;

					ResourceDescription rd = CreateBaseVoltageResourceDescription(cimBaseVoltage);
					if (rd != null)
					{
						delta.AddDeltaOperation(DeltaOpType.Insert, rd, true);
						report.Report.Append("BaseVoltage ID = ").Append(cimBaseVoltage.ID).Append(" SUCCESSFULLY converted to GID = ").AppendLine(rd.Id.ToString());
					}
					else
					{
						report.Report.Append("BaseVoltage ID = ").Append(cimBaseVoltage.ID).AppendLine(" FAILED to be converted");
					}
				}
				report.Report.AppendLine();
			}
		}

		private ResourceDescription CreateBaseVoltageResourceDescription(FTN.BaseVoltage cimBaseVoltage)
		{
			ResourceDescription rd = null;
			if (cimBaseVoltage != null)
			{
				long gid = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.BASEVOLTAGE, importHelper.CheckOutIndexForDMSType(DMSType.BASEVOLTAGE));
				rd = new ResourceDescription(gid);
				importHelper.DefineIDMapping(cimBaseVoltage.ID, gid);

				////populate ResourceDescription
				PowerTransformerConverter.PopulateBaseVoltageProperties(cimBaseVoltage, rd);
			}
			return rd;
		}
		
		private void ImportLocations()
		{
			SortedDictionary<string, object> cimLocations = concreteModel.GetAllObjectsOfType("FTN.Location");
			if (cimLocations != null)
			{
				foreach (KeyValuePair<string, object> cimLocationPair in cimLocations)
				{
					FTN.Location cimLocation = cimLocationPair.Value as FTN.Location;

					ResourceDescription rd = CreateLocationResourceDescription(cimLocation);
					if (rd != null)
					{
						delta.AddDeltaOperation(DeltaOpType.Insert, rd, true);
						report.Report.Append("Location ID = ").Append(cimLocation.ID).Append(" SUCCESSFULLY converted to GID = ").AppendLine(rd.Id.ToString());
					}
					else
					{
						report.Report.Append("Location ID = ").Append(cimLocation.ID).AppendLine(" FAILED to be converted");
					}
				}
				report.Report.AppendLine();
			}
		}

		private ResourceDescription CreateLocationResourceDescription(FTN.Location cimLocation)
		{
			ResourceDescription rd = null;
			if (cimLocation != null)
			{
				long gid = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.LOCATION, importHelper.CheckOutIndexForDMSType(DMSType.LOCATION));
				rd = new ResourceDescription(gid);
				importHelper.DefineIDMapping(cimLocation.ID, gid);

				////populate ResourceDescription
				PowerTransformerConverter.PopulateLocationProperties(cimLocation, rd);
			}
			return rd;
		}

		private void ImportPowerTransformers()
		{
			SortedDictionary<string, object> cimPowerTransformers = concreteModel.GetAllObjectsOfType("FTN.PowerTransformer");
			if (cimPowerTransformers != null)
			{
				foreach (KeyValuePair<string, object> cimPowerTransformerPair in cimPowerTransformers)
				{
					FTN.PowerTransformer cimPowerTransformer = cimPowerTransformerPair.Value as FTN.PowerTransformer;

					ResourceDescription rd = CreatePowerTransformerResourceDescription(cimPowerTransformer);
					if (rd != null)
					{
						delta.AddDeltaOperation(DeltaOpType.Insert, rd, true);
						report.Report.Append("PowerTransformer ID = ").Append(cimPowerTransformer.ID).Append(" SUCCESSFULLY converted to GID = ").AppendLine(rd.Id.ToString());
					}
					else
					{
						report.Report.Append("PowerTransformer ID = ").Append(cimPowerTransformer.ID).AppendLine(" FAILED to be converted");
					}
				}
				report.Report.AppendLine();
			}
		}

		private ResourceDescription CreatePowerTransformerResourceDescription(FTN.PowerTransformer cimPowerTransformer)
		{
			ResourceDescription rd = null;
			if (cimPowerTransformer != null)
			{
				long gid = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.POWERTR, importHelper.CheckOutIndexForDMSType(DMSType.POWERTR));
				rd = new ResourceDescription(gid);
				importHelper.DefineIDMapping(cimPowerTransformer.ID, gid);

				////populate ResourceDescription
				PowerTransformerConverter.PopulatePowerTransformerProperties(cimPowerTransformer, rd, importHelper, report);
			}
			return rd;
		}

		private void ImportTransformerWindings()
		{
			SortedDictionary<string, object> cimTransformerWindings = concreteModel.GetAllObjectsOfType("FTN.TransformerWinding");
			if (cimTransformerWindings != null)
			{
				foreach (KeyValuePair<string, object> cimTransformerWindingPair in cimTransformerWindings)
				{
					FTN.TransformerWinding cimTransformerWinding = cimTransformerWindingPair.Value as FTN.TransformerWinding;

					ResourceDescription rd = CreateTransformerWindingResourceDescription(cimTransformerWinding);
					if (rd != null)
					{
						delta.AddDeltaOperation(DeltaOpType.Insert, rd, true);
						report.Report.Append("TransformerWinding ID = ").Append(cimTransformerWinding.ID).Append(" SUCCESSFULLY converted to GID = ").AppendLine(rd.Id.ToString());
					}
					else
					{
						report.Report.Append("TransformerWinding ID = ").Append(cimTransformerWinding.ID).AppendLine(" FAILED to be converted");
					}
				}
				report.Report.AppendLine();
			}
		}

		private ResourceDescription CreateTransformerWindingResourceDescription(FTN.TransformerWinding cimTransformerWinding)
		{
			ResourceDescription rd = null;
			if (cimTransformerWinding != null)
			{
				long gid = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.POWERTRWINDING, importHelper.CheckOutIndexForDMSType(DMSType.POWERTRWINDING));
				rd = new ResourceDescription(gid);
				importHelper.DefineIDMapping(cimTransformerWinding.ID, gid);

				////populate ResourceDescription
				PowerTransformerConverter.PopulateTransformerWindingProperties(cimTransformerWinding, rd, importHelper, report);
			}
			return rd;
		}

		private void ImportWindingTests()
		{
			SortedDictionary<string, object> cimWindingTests = concreteModel.GetAllObjectsOfType("FTN.WindingTest");
			if (cimWindingTests != null)
			{
				foreach (KeyValuePair<string, object> cimWindingTestPair in cimWindingTests)
				{
					FTN.WindingTest cimWindingTest = cimWindingTestPair.Value as FTN.WindingTest;

					ResourceDescription rd = CreateWindingTestResourceDescription(cimWindingTest);
					if (rd != null)
					{
						delta.AddDeltaOperation(DeltaOpType.Insert, rd, true);
						report.Report.Append("WindingTest ID = ").Append(cimWindingTest.ID).Append(" SUCCESSFULLY converted to GID = ").AppendLine(rd.Id.ToString());
					}
					else
					{
						report.Report.Append("WindingTest ID = ").Append(cimWindingTest.ID).AppendLine(" FAILED to be converted");
					}
				}
				report.Report.AppendLine();
			}
		}

		private ResourceDescription CreateWindingTestResourceDescription(FTN.WindingTest cimWindingTest)
		{
			ResourceDescription rd = null;
			if (cimWindingTest != null)
			{
				long gid = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.WINDINGTEST, importHelper.CheckOutIndexForDMSType(DMSType.WINDINGTEST));
				rd = new ResourceDescription(gid);
				importHelper.DefineIDMapping(cimWindingTest.ID, gid);

				////populate ResourceDescription
				PowerTransformerConverter.PopulateWindingTestProperties(cimWindingTest, rd, importHelper, report);
			}
			return rd;
		}*/
		#endregion Import
	}
}

