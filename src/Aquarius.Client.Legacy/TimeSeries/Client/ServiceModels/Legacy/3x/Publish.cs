/* Options:
Version: 1
BaseUrl: http://aiapp1

ServerVersion: 1
MakePartial: False
MakeVirtual: False
MakeDataContractsExtensible: False
AddReturnMarker: True
AddDescriptionAsComments: True
AddDataContractAttributes: False
AddDataAnnotationAttributes: False
AddIndexesToDataMembers: False
AddResponseStatus: False
AddImplicitVersion: 
InitializeCollections: True
AddDefaultXmlNamespace: http://schemas.servicestack.net/types
*/

using System;
using System.Collections.Generic;
using ServiceStack;


namespace Aquarius.TimeSeries.Client.ServiceModels.Legacy.Publish3x
{
    public enum AtomType
    {
        TimeSeries_Basic,
        TimeSeries_Field_Visit,
        TimeSeries_Composite,
        TimeSeries_Rating_Curve_Derived,
        TimeSeries_Calculated_Derived,
        TimeSeries_External,
        TimeSeries_Statistical_Derived,
        TimeSeries_ProcessorBasic,
        TimeSeries_ProcessorDerived
    }

    public enum CorrectionType
    {
        Generic,
        Offset,
        USGSMultiPoint,
        RevertToRaw,
        DeleteRegion,
        CopyPaste,
        FillGaps,
        Drift,
        Percent,
        ReplaceWithGap,
        ClockDrift,
        Resample,
        Recession,
        AdjustableTrim,
        ThresholdTrim,
        FlagTrim,
        SingleGap,
        MultiPointDrift,
        Amplification,
        SinglePoint,
        MovingAverage
    }

    public enum AdjustmentType
    {
        Unknown,
        Percentage,
        Amount
    }

    public enum ReasonForAdjustmentType
    {
        Unknown,
        Unspecified,
        Measured,
        AdjustedForStorage,
        AdjustedForOtherFlows,
        MainChannelFlowOnly,
        AdjustedForTidalEffect,
        AdjustedForOtherFactors
    }

    public enum ControlCleanedType
    {
        Unknown,
        Unspecified,
        ControlCleaned,
        ControlNotCleaned,
    }

    public enum HorizontalFlowType
    {
        Unknown,
        Unspecified,
        Even,
        Uneven
    }

    public enum ChannelStabilityType
    {
        Unknown,
        Unspecified,
        Soft,
        Firm
    }

    public enum ChannelMaterialType
    {
        Unknown,
        Unspecified,
        SiltMud,
        Sand,
        Gravel,
        Cobbles,
        CobblesBoulders,
        BedrockLedgeArtificial
    }

    public enum ChannelEvennessType
    {
        Unknown,
        Unspecified,
        Even,
        Uneven
    }

    public enum VerticalVelocityDistributionType
    {
        Unknown,
        Unspecified,
        Uniform,
        Standard,
        NonStandard
    }

    public enum MeasurementLocationToGageType
    {
        Unknown,
        Unspecified,
        AtTheGage,
        Upstream,
        Downstream
    }

    public enum BaseFlowType
    {
        Unknown,
        Unspecified,
        BaseFlow,
        NonBaseFlow
    }

    public enum DeploymentMethodType
    {
        Unknown,
        Unspecified,
        Wading,
        BridgeUpstreamSide,
        BridgeDownstreamSide,
        Cableway,
        Ice,
        MannedMovingBoat,
        StationaryBoat,
        RemoteControlledBoat,
        Other,
        Boat,
        BridgeCrane
    }

    public enum DischargeMeasurementReasonType
    {
        Unknown,
        Routine,
        Check
    }

    public enum GageHeightCalculationType
    {
        Unknown,
        ManuallyCalculated,
        SimpleAverage,
    }

    public enum MeasurementGradeType
    {
        Unknown,
        Unspecified,
        Excellent,
        Good,
        Fair,
        Poor
    }

    public enum DischargeMethodType
    {
        Unknown,
        MidSection
    }

    public enum MeterSuspensionType
    {
        Unknown,
        Unspecified,
        TopSettingWadingRod,
        RoundRod,
        PackReel,
        AReel,
        BReel,
        EReel,
        HandLine,
        RigidBoatMount,
        TetheredBoat,
        IceSurfaceMount
    }

    public enum StartPointType
    {
        Unknown,
        Unspecified,
        LeftEdgeOfWater,
        RightEdgeOfWater
    }




    public enum RatingCurveType
    {
        LinearTable,
        LogarithmicTable,
        StandardEquation,
        DescriptiveEquation,
        LinearRegressionModel
    }

    public enum VelocityDistributionType
    {
        Unknown,
        Unspecified,
        Steady,
        Pulsating
    }

    public enum VelocityMethodType
    {
        Unknown,
        Unspecified,
        SidewaysLookingAdvm,
        UpwardLookingAdvm,
        Estimated,
        Adcp,
        Adv,
        ElectromagneticVelocityMeter,
        IceVaneMeter,
        PolymerCupAaMeter,
        PolymerCupPygmyMeter,
        OpticalCurrent,
        HorizontalShaft,
        PriceAa,
        Pygmy,
        Radar,
        TimeOfTravel,
        Nwis48TransferredVelocity,
        UltrasonicMeter
    }

    public enum FormatterDetailLevel
    {
        All,
        PointsOnly,
        ApprovalsOnly,
    }


    public class Approval
        : TimeRange
    {
        public int ApprovalLevel { get; set; }
        public DateTimeOffset DateApplied { get; set; }
        public string User { get; set; }
        public string LevelDescription { get; set; }
        public string Comment { get; set; }
    }

    public class ApprovalMetadata
    {
        public string Identifier { get; set; }
        public string DisplayName { get; set; }
        public string Color { get; set; }
    }

    public class ApprovalsTransaction
        : Approval
    {
    }

    public class Correction
    {
        public Correction()
        {
            Parameters = new Dictionary<string, string>{};
        }

        public CorrectionType Type { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
        public DateTimeOffset AppliedTime { get; set; }
        public string Comment { get; set; }
        public string User { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
    }

    public class EffectiveShift
    {
        public DateTimeOffset Timestamp { get; set; }
        public double? Value { get; set; }
    }

    public class ExpandedRatingCurve
    {
        public ExpandedRatingCurve()
        {
            PeriodsOfApplicability = new List<PeriodOfApplicability>{};
            Shifts = new List<RatingShift>{};
            Offsets = new List<OffsetPoint>{};
            BaseRatingTable = new List<RatingPoint>{};
            AdjustedRatingTable = new List<RatingPoint>{};
        }

        public string Id { get; set; }
        public RatingCurveType Type { get; set; }
        public int Approval { get; set; }
        public string Remarks { get; set; }
        public ParameterWithUnit InputParameter { get; set; }
        public ParameterWithUnit OutputParameter { get; set; }
        public List<PeriodOfApplicability> PeriodsOfApplicability { get; set; }
        public List<RatingShift> Shifts { get; set; }
        public List<OffsetPoint> Offsets { get; set; }
        public bool IsBlended { get; set; }
        public List<RatingPoint> BaseRatingTable { get; set; }
        public List<RatingPoint> AdjustedRatingTable { get; set; }
    }

    public class ExtendedAttribute
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public Object Value { get; set; }
    }

    public class ExtendedAttributeFilter
    {
        public string FilterName { get; set; }
        public string FilterValue { get; set; }
    }

    public class FieldVisitDescription
    {
        public string Identifier { get; set; }
        public string LocationIdentifier { get; set; }
        public DateTimeOffset? StartTime { get; set; }
        public DateTimeOffset? EndTime { get; set; }
        public string Party { get; set; }
        public string Remarks { get; set; }
        public string Weather { get; set; }
    }

    public class GradeMetadata
    {
        public string Identifier { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
    }

    public class LocationDescription
    {
        public LocationDescription()
        {
            SecondaryFolders = new List<string>{};
        }

        public string Name { get; set; }
        public string Identifier { get; set; }
        public string PrimaryFolder { get; set; }
        public List<string> SecondaryFolders { get; set; }
        public DateTimeOffset LastModified { get; set; }
    }

    public class LocationRemark
    {
        public DateTimeOffset? CreateTime { get; set; }
        public DateTimeOffset? FromTime { get; set; }
        public DateTimeOffset? ToTime { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
        public string Remark { get; set; }
    }

    public class MonitoringMethod
    {
        public string Method { get; set; }
        public string Parameter { get; set; }
        public string SubLocationIdentifier { get; set; }
        public string Comment { get; set; }
    }

    public class OffsetPoint
    {
        public double? InputValue { get; set; }
        public double Offset { get; set; }
    }

    public class ParameterMetadata
    {
        public string Identifier { get; set; }
        public string UnitGroupIdentifier { get; set; }
        public string UnitIdentifier { get; set; }
        public string DisplayName { get; set; }
        public string InterpolationType { get; set; }
    }

    public class ParameterWithUnit
    {
        public string ParameterName { get; set; }
        public string ParameterUnit { get; set; }
    }

    public class PeriodOfApplicability
    {
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
        public int Approval { get; set; }
        public string Remarks { get; set; }
    }

    public class RatingCurve
    {
        public RatingCurve()
        {
            PeriodsOfApplicability = new List<PeriodOfApplicability>{};
            Shifts = new List<RatingShift>{};
            BaseRatingTable = new List<RatingPoint>{};
            Offsets = new List<OffsetPoint>{};
        }

        public string Id { get; set; }
        public RatingCurveType Type { get; set; }
        public string Equation { get; set; }
        public int Approval { get; set; }
        public string Remarks { get; set; }
        public ParameterWithUnit InputParameter { get; set; }
        public ParameterWithUnit OutputParameter { get; set; }
        public List<PeriodOfApplicability> PeriodsOfApplicability { get; set; }
        public List<RatingShift> Shifts { get; set; }
        public List<RatingPoint> BaseRatingTable { get; set; }
        public List<OffsetPoint> Offsets { get; set; }
    }

    public class RatingModelDescription
    {
        public string Identifier { get; set; }
        public string Label { get; set; }
        public string LocationIdentifier { get; set; }
        public string InputParameter { get; set; }
        public string InputUnit { get; set; }
        public string OutputParameter { get; set; }
        public string OutputUnit { get; set; }
        public string TemplateName { get; set; }
        public DateTimeOffset LastModifiedTime { get; set; }
        public bool Publish { get; set; }
    }

    public class RatingPoint
    {
        public double? InputValue { get; set; }
        public double? OutputValue { get; set; }
    }

    public class RatingShift
    {
        public RatingShift()
        {
            ShiftPoints = new List<RatingShiftPoint>{};
        }

        public PeriodOfApplicability PeriodOfApplicability { get; set; }
        public List<RatingShiftPoint> ShiftPoints { get; set; }
    }

    public class RatingShiftPoint
    {
        public double InputValue { get; set; }
        public double Shift { get; set; }
    }

    public class StagePoint
    {
        public double InputValue { get; set; }
        public double Correction { get; set; }
        public double CorrectedValue { get; set; }
    }

    public class TimeRange
    {
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
    }

    public class TimeSeriesDescription
    {
        public string Identifier { get; set; }
        public string LocationIdentifier { get; set; }
        public string Parameter { get; set; }
        public string Unit { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
        public long NumPoints { get; set; }
        public DateTimeOffset LastModified { get; set; }
        public AtomType TimeSeriesType { get; set; }
        public string Label { get; set; }
        public string Comment { get; set; }
        public string Description { get; set; }
        public bool Publish { get; set; }
        public string ComputationIdentifier { get; set; }
        public string ComputationPeriodIdentifier { get; set; }
        public string SubLocationIdentifier { get; set; }
        public IList<ExtendedAttribute> ExtendedAttributes { get; set; }
    }

    public class TimeSeriesPoint
    {
        public DateTimeOffset Timestamp { get; set; }
        public int Interpolation { get; set; }
        public int? Grade { get; set; }
        public int? Approval { get; set; }
        public double? Value { get; set; }
    }

    public class UnitMetadata
    {
        public string Identifier { get; set; }
        public string GroupIdentifier { get; set; }
        public string Symbol { get; set; }
        public string DisplayName { get; set; }
        public string BaseMultiplier { get; set; }
        public string BaseOffset { get; set; }
    }

    public class Adjustment
    {
        public double? AdjustmentAmount { get; set; }
        public AdjustmentType AdjustmentType { get; set; }
        public ReasonForAdjustmentType ReasonForAdjustment { get; set; }
    }

    public class ControlConditionActivity
    {
        public string ControlCode { get; set; }
        public string FlowOverControl { get; set; }
        public ControlCleanedType ControlCleaned { get; set; }
        public string ControlCondition { get; set; }
        public DateTimeOffset? DateCleaned { get; set; }
        public UnitWithValue DistanceToGage { get; set; }
        public string Comments { get; set; }
        public string Party { get; set; }
    }

    public class DischargeActivity
    {
        public DischargeActivity()
        {
            VolumetricDischargeActivities = new List<VolumetricDischargeActivity>{};
            EngineeredStructureDischargeActivities = new List<EngineeredStructureDischargeActivity>{};
            PointVelocityDischargeActivities = new List<PointVelocityDischargeActivity>{};
        }

        public DischargeSummary DischargeSummary { get; set; }
        public List<VolumetricDischargeActivity> VolumetricDischargeActivities { get; set; }
        public List<EngineeredStructureDischargeActivity> EngineeredStructureDischargeActivities { get; set; }
        public List<PointVelocityDischargeActivity> PointVelocityDischargeActivities { get; set; }
    }

    public class DischargeChannelMeasurement
    {
        public string Channel { get; set; }
        public DateTimeOffset? StartTime { get; set; }
        public DateTimeOffset? EndTime { get; set; }
        public UnitWithValue Discharge { get; set; }
        public string Comments { get; set; }
        public string Party { get; set; }
        public UnitWithValue DistanceToGage { get; set; }
        public HorizontalFlowType HorizontalFlow { get; set; }
        public ChannelStabilityType ChannelStability { get; set; }
        public ChannelMaterialType ChannelMaterial { get; set; }
        public ChannelEvennessType ChannelEvenness { get; set; }
        public VerticalVelocityDistributionType VerticalVelocityDistribution { get; set; }
        public VelocityDistributionType VerticalVelocity { get; set; }
        public MeasurementLocationToGageType MeasurementLocationToGage { get; set; }
        public DeploymentMethodType DeploymentMethod { get; set; }
        public VelocityMethodType VelocityMethod { get; set; }
        public string MonitoringMethod { get; set; }
    }

    public class DischargeSummary
    {
        public DischargeSummary()
        {
            GageHeightReadings = new List<GageHeightReading>{};
        }

        public DateTimeOffset? MeasurementStartTime { get; set; }
        public DateTimeOffset? MeasurementEndTime { get; set; }
        public string Party { get; set; }
        public BaseFlowType BaseFlow { get; set; }
        public Adjustment Adjustment { get; set; }
        public UnitWithValue Discharge { get; set; }
        public UnitWithValue MeanGageHeight { get; set; }
        public DischargeMeasurementReasonType DischargeMeasurementReason { get; set; }
        public string Comments { get; set; }
        public GageHeightCalculationType GageHeightCalculation { get; set; }
        public List<GageHeightReading> GageHeightReadings { get; set; }
        public double? DifferenceDuringVisit { get; set; }
        public double? DurationInHours { get; set; }
        public MeasurementGradeType MeasurementGrade { get; set; }
        public string Reviewer { get; set; }
    }

    public class EngineeredStructureDischargeActivity
    {
        public DischargeChannelMeasurement DischargeChannelMeasurement { get; set; }
        public string StructureType { get; set; }
        public string EquationForSelectedStructure { get; set; }
        public UnitWithValue MeanHead { get; set; }
    }

    public class GageHeightAtZeroFlowActivity
    {
        public DateTimeOffset? ObservedDate { get; set; }
        public DateTimeOffset? ApplicableSince { get; set; }
        public double? ZeroFlowHeight { get; set; }
        public bool IsObserved { get; set; }
        public GageHeightAtZeroFlowCalculatedDetails CalculatedDetails { get; set; }
        public string Unit { get; set; }
        public string Comments { get; set; }
        public string Party { get; set; }
    }

    public class GageHeightAtZeroFlowCalculatedDetails
    {
        public double Stage { get; set; }
        public double Depth { get; set; }
        public double DepthCertainty { get; set; }
    }

    public class GageHeightReading
    {
        public bool IsUsed { get; set; }
        public DateTimeOffset? ReadingTime { get; set; }
        public double? GageHeight { get; set; }
    }

    public class MeasurementContainer
    {
        public string Name { get; set; }
        public UnitWithValue Volume { get; set; }
    }

    public class PointVelocityDischargeActivity
    {
        public DischargeChannelMeasurement DischargeChannelMeasurement { get; set; }
        public UnitWithValue DistanceToMeter { get; set; }
        public UnitWithValue Width { get; set; }
        public UnitWithValue Area { get; set; }
        public UnitWithValue VelocityAverage { get; set; }
        public double? MeanObservationDurationInSeconds { get; set; }
        public bool SuspensionCoefficientUsed { get; set; }
        public bool MethodCoefficientUsed { get; set; }
        public bool HorizontalCoefficientUsed { get; set; }
        public bool? MeterInspectedBefore { get; set; }
        public bool? MeterInspectedAfter { get; set; }
        public int? NumberOfPanels { get; set; }
        public string MeterEquation { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public DischargeMethodType DischargeMethod { get; set; }
        public MeterSuspensionType MeterSuspension { get; set; }
        public string SuspensionWeight { get; set; }
        public string VelocityObservationMethod { get; set; }
        public StartPointType StartPoint { get; set; }
        public string NodeDetails { get; set; }
    }

    public class UnitWithValue
    {
        public string Unit { get; set; }
        public double? Value { get; set; }
    }

    public class VolumetricDischargeActivity
    {
        public VolumetricDischargeActivity()
        {
            VolumetricDischargeReadings = new List<VolumetricDischargeReading>{};
        }

        public DischargeChannelMeasurement DischargeChannelMeasurement { get; set; }
        public List<VolumetricDischargeReading> VolumetricDischargeReadings { get; set; }
        public MeasurementContainer MeasurementContainer { get; set; }
        public bool IsObserved { get; set; }
    }

    public class VolumetricDischargeReading
    {
        public string Name { get; set; }
        public double? DurationInSeconds { get; set; }
        public double? StartingVolume { get; set; }
        public double? EndingVolume { get; set; }
        public double? Discharge { get; set; }
        public bool IsUsed { get; set; }
        public double? VolumeChange { get; set; }
    }

    public class ApprovalListServiceRequest
        : IReturn<ApprovalListServiceResponse>
    {
    }

    public class CorrectionListServiceRequest
        : IReturn<CorrectionListServiceResponse>
    {
        public string TimeSeriesIdentifier { get; set; }
        public DateTimeOffset? QueryFrom { get; set; }
        public DateTimeOffset? QueryTo { get; set; }
    }

    public class EffectiveRatingCurveServiceRequest
        : IReturn<EffectiveRatingCurveServiceResponse>
    {
        public string RatingModelIdentifier { get; set; }
        public double? StepSize { get; set; }
        public double? UtcOffset { get; set; }
        public double? StartValue { get; set; }
        public double? EndValue { get; set; }
        public DateTimeOffset? EffectiveTime { get; set; }
        public string InputUnit { get; set; }
        public string OutputUnit { get; set; }
    }

    public class ExpandedStageTableServiceRequest
        : IReturn<ExpandedStageTableServiceResponse>
    {
        public string TimeSeriesIdentifier { get; set; }
        public double? StepSize { get; set; }
        public double? UtcOffset { get; set; }
        public double? StartValue { get; set; }
        public double? EndValue { get; set; }
    }

    public class FieldVisitDataServiceRequest
        : IReturn<FieldVisitDataServiceResponse>
    {
        public string FieldVisitIdentifier { get; set; }
        public string DiscreteMeasurementActivity { get; set; }
        public bool? IncludeNodeDetails { get; set; }
    }

    public class FieldVisitDescriptionListServiceRequest
        : IReturn<FieldVisitDescriptionListServiceResponse>
    {
        public string LocationIdentifier { get; set; }
        public DateTimeOffset? QueryFrom { get; set; }
        public DateTimeOffset? QueryTo { get; set; }
    }

    public class GetAuthTokenServiceRequest
        : IReturn<string>
    {
        public string Username { get; set; }
        public string EncryptedPassword { get; set; }
        public string Locale { get; set; }
    }

    public class GradeListServiceRequest
        : IReturn<GradeListServiceResponse>
    {
    }

    public class LocationDataServiceRequest
        : IReturn<LocationDataServiceResponse>
    {
        public string LocationIdentifier { get; set; }
    }

    public class LocationDescriptionListServiceRequest
        : IReturn<LocationDescriptionListServiceResponse>
    {
        public LocationDescriptionListServiceRequest()
        {
            ExtendedFilters = new List<ExtendedAttributeFilter>{};
        }

        public string LocationName { get; set; }
        public string LocationIdentifier { get; set; }
        public string LocationFolder { get; set; }
        public List<ExtendedAttributeFilter> ExtendedFilters { get; set; }
    }

    public class MonitoringMethodsServiceRequest
        : IReturn<MonitoringMethodsServiceResponse>
    {
        public string LocationIdentifier { get; set; }
    }

    public class ParameterListServiceRequest
        : IReturn<ParameterListServiceResponse>
    {
    }

    public class RatingCurveListServiceRequest
        : IReturn<RatingCurveListServiceResponse>
    {
        public string RatingModelIdentifier { get; set; }
        public double? UtcOffset { get; set; }
        public DateTimeOffset? QueryFrom { get; set; }
        public DateTimeOffset? QueryTo { get; set; }
    }

    public class RatingModelDescriptionListServiceRequest
        : IReturn<RatingModelDescriptionListServiceResponse>
    {
        public string LocationIdentifier { get; set; }
        public bool? Publish { get; set; }
        public string InputParameter { get; set; }
        public string OutputParameter { get; set; }
    }

    public class RatingModelEffectiveShiftsServiceRequest
        : IReturn<RatingModelEffectiveShiftsServiceResponse>
    {
        public string TimeSeriesIdentifier { get; set; }
        public string RatingModelIdentifier { get; set; }
        public DateTimeOffset? QueryFrom { get; set; }
        public DateTimeOffset? QueryTo { get; set; }
    }

    public class RatingModelInputValuesServiceRequest
        : IReturn<RatingModelInputValuesServiceResponse>
    {
        public RatingModelInputValuesServiceRequest()
        {
            OutputValues = new List<double>{};
        }

        public string RatingModelIdentifier { get; set; }
        public List<double> OutputValues { get; set; }
        public DateTimeOffset? EffectiveTime { get; set; }
    }

    public class RatingModelOutputValuesServiceRequest
        : IReturn<RatingModelOutputValuesServiceResponse>
    {
        public RatingModelOutputValuesServiceRequest()
        {
            InputValues = new List<double>{};
        }

        public string RatingModelIdentifier { get; set; }
        public List<double> InputValues { get; set; }
        public DateTimeOffset? EffectiveTime { get; set; }
        public bool? ApplyShifts { get; set; }
    }

    public class TimeSeriesApprovalsTransactionListServiceRequest
        : IReturn<TimeSeriesApprovalsTransactionListServiceResponse>
    {
        public string TimeSeriesIdentifier { get; set; }
        public DateTimeOffset? QueryFrom { get; set; }
        public DateTimeOffset? QueryTo { get; set; }
    }

    public class TimeSeriesDataCorrectedServiceRequest
        : IReturn<TimeSeriesDataServiceResponse>
    {
        public string TimeSeriesIdentifier { get; set; }
        public string View { get; set; }
        public DateTimeOffset? QueryFrom { get; set; }
        public DateTimeOffset? QueryTo { get; set; }
        public DateTimeOffset? ChangesSince { get; set; }
        public FormatterDetailLevel? GetParts { get; set; }
        public string Unit { get; set; }
        public double? UtcOffset { get; set; }
    }

    public class TimeSeriesDataRawServiceRequest
        : IReturn<TimeSeriesDataServiceResponse>
    {
        public string TimeSeriesIdentifier { get; set; }
        public DateTimeOffset? QueryFrom { get; set; }
        public DateTimeOffset? QueryTo { get; set; }
        public DateTimeOffset? ChangesSince { get; set; }
        public FormatterDetailLevel? GetParts { get; set; }
        public string Unit { get; set; }
        public double? UtcOffset { get; set; }
    }

    public class TimeSeriesDescriptionServiceRequest
        : IReturn<TimeSeriesDescriptionListServiceResponse>
    {
        public TimeSeriesDescriptionServiceRequest()
        {
            ExtendedFilters = new List<ExtendedAttributeFilter>{};
        }

        public string LocationIdentifier { get; set; }
        public DateTimeOffset? ChangesSince { get; set; }
        public string Parameter { get; set; }
        public bool? Publish { get; set; }
        public string ComputationIdentifier { get; set; }
        public string ComputationPeriodIdentifier { get; set; }
        public List<ExtendedAttributeFilter> ExtendedFilters { get; set; }
    }

    public class UnitListServiceRequest
        : IReturn<UnitListServiceResponse>
    {
    }

    public class ApprovalListServiceResponse
    {
        public ApprovalListServiceResponse()
        {
            Approvals = new List<ApprovalMetadata>{};
        }

        public int ResponseVersion { get; set; }
        public DateTimeOffset ResponseTime { get; set; }
        public string Summary { get; set; }
        public List<ApprovalMetadata> Approvals { get; set; }
    }

    public class CorrectionListServiceResponse
    {
        public CorrectionListServiceResponse()
        {
            Corrections = new List<Correction>{};
        }

        public int ResponseVersion { get; set; }
        public DateTimeOffset ResponseTime { get; set; }
        public string Summary { get; set; }
        public List<Correction> Corrections { get; set; }
    }

    public class EffectiveRatingCurveServiceResponse
    {
        public int ResponseVersion { get; set; }
        public DateTimeOffset ResponseTime { get; set; }
        public string Summary { get; set; }
        public ExpandedRatingCurve ExpandedRatingCurve { get; set; }
    }

    public class ExpandedStageTableServiceResponse
    {
        public ExpandedStageTableServiceResponse()
        {
            ExpandedStageTable = new List<StagePoint>{};
            Corrections = new List<Correction>{};
        }

        public int ResponseVersion { get; set; }
        public DateTimeOffset ResponseTime { get; set; }
        public string Summary { get; set; }
        public List<StagePoint> ExpandedStageTable { get; set; }
        public List<Correction> Corrections { get; set; }
    }

    public class FieldVisitDataServiceResponse
    {
        public FieldVisitDataServiceResponse()
        {
            DischargeActivities = new List<DischargeActivity>{};
        }

        public int ResponseVersion { get; set; }
        public DateTimeOffset ResponseTime { get; set; }
        public string Summary { get; set; }
        public List<DischargeActivity> DischargeActivities { get; set; }
        public GageHeightAtZeroFlowActivity GageHeightAtZeroFlowActivity { get; set; }
        public ControlConditionActivity ControlConditionActivity { get; set; }
    }

    public class FieldVisitDescriptionListServiceResponse
    {
        public FieldVisitDescriptionListServiceResponse()
        {
            FieldVisitDescriptions = new List<FieldVisitDescription>{};
        }

        public int ResponseVersion { get; set; }
        public DateTimeOffset ResponseTime { get; set; }
        public string Summary { get; set; }
        public List<FieldVisitDescription> FieldVisitDescriptions { get; set; }
    }

    public class GradeListServiceResponse
    {
        public GradeListServiceResponse()
        {
            Grades = new List<GradeMetadata>{};
        }

        public int ResponseVersion { get; set; }
        public DateTimeOffset ResponseTime { get; set; }
        public string Summary { get; set; }
        public List<GradeMetadata> Grades { get; set; }
    }

    public class LocationDataServiceResponse
    {
        public LocationDataServiceResponse()
        {
            ExtendedAttributes = new List<ExtendedAttribute>{};
            LocationRemarks = new List<LocationRemark>{};
        }

        public int ResponseVersion { get; set; }
        public DateTimeOffset ResponseTime { get; set; }
        public string Summary { get; set; }
        public string LocationName { get; set; }
        public string Description { get; set; }
        public string Identifier { get; set; }
        public string LocationType { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Srid { get; set; }
        public string ElevationUnits { get; set; }
        public double Elevation { get; set; }
        public double UtcOffset { get; set; }
        public string HotFolderPath { get; set; }
        public List<ExtendedAttribute> ExtendedAttributes { get; set; }
        public List<LocationRemark> LocationRemarks { get; set; }
    }

    public class LocationDescriptionListServiceResponse
    {
        public LocationDescriptionListServiceResponse()
        {
            LocationDescriptions = new List<LocationDescription>{};
        }

        public int ResponseVersion { get; set; }
        public DateTimeOffset ResponseTime { get; set; }
        public string Summary { get; set; }
        public List<LocationDescription> LocationDescriptions { get; set; }
    }

    public class MonitoringMethodsServiceResponse
    {
        public MonitoringMethodsServiceResponse()
        {
            MonitoringMethods = new List<MonitoringMethod>{};
        }

        public int ResponseVersion { get; set; }
        public DateTimeOffset ResponseTime { get; set; }
        public string Summary { get; set; }
        public List<MonitoringMethod> MonitoringMethods { get; set; }
    }

    public class ParameterListServiceResponse
    {
        public ParameterListServiceResponse()
        {
            Parameters = new List<ParameterMetadata>{};
        }

        public int ResponseVersion { get; set; }
        public DateTimeOffset ResponseTime { get; set; }
        public string Summary { get; set; }
        public List<ParameterMetadata> Parameters { get; set; }
    }

    public class RatingCurveListServiceResponse
    {
        public int ResponseVersion { get; set; }
        public DateTimeOffset ResponseTime { get; set; }
        public string Summary { get; set; }
        public IList<RatingCurve> RatingCurves { get; set; }
    }

    public class RatingModelDescriptionListServiceResponse
    {
        public int ResponseVersion { get; set; }
        public DateTimeOffset ResponseTime { get; set; }
        public string Summary { get; set; }
        public IList<RatingModelDescription> RatingModelDescriptions { get; set; }
    }

    public class RatingModelEffectiveShiftsServiceResponse
    {
        public RatingModelEffectiveShiftsServiceResponse()
        {
            EffectiveShifts = new List<EffectiveShift>{};
        }

        public int ResponseVersion { get; set; }
        public DateTimeOffset ResponseTime { get; set; }
        public string Summary { get; set; }
        public List<EffectiveShift> EffectiveShifts { get; set; }
    }

    public class RatingModelInputValuesServiceResponse
    {
        public RatingModelInputValuesServiceResponse()
        {
            InputValues = new List<double?>{};
        }

        public int ResponseVersion { get; set; }
        public DateTimeOffset ResponseTime { get; set; }
        public string Summary { get; set; }
        public List<double?> InputValues { get; set; }
    }

    public class RatingModelOutputValuesServiceResponse
    {
        public RatingModelOutputValuesServiceResponse()
        {
            OutputValues = new List<double?>{};
        }

        public int ResponseVersion { get; set; }
        public DateTimeOffset ResponseTime { get; set; }
        public string Summary { get; set; }
        public List<double?> OutputValues { get; set; }
    }

    public class TimeSeriesApprovalsTransactionListServiceResponse
    {
        public int ResponseVersion { get; set; }
        public DateTimeOffset ResponseTime { get; set; }
        public string Summary { get; set; }
        public IList<ApprovalsTransaction> ApprovalsTransactions { get; set; }
    }

    public class TimeSeriesDataServiceResponse
    {
        public int ResponseVersion { get; set; }
        public DateTimeOffset ResponseTime { get; set; }
        public string Summary { get; set; }
        public string Identifier { get; set; }
        public string Parameter { get; set; }
        public string Label { get; set; }
        public string LocationIdentifier { get; set; }
        public long NumPoints { get; set; }
        public string Unit { get; set; }
        public IList<Approval> Approvals { get; set; }
        public TimeRange TimeRange { get; set; }
        public IList<TimeSeriesPoint> Points { get; set; }
    }

    public class TimeSeriesDescriptionListServiceResponse
    {
        public int ResponseVersion { get; set; }
        public DateTimeOffset ResponseTime { get; set; }
        public string Summary { get; set; }
        public IList<TimeSeriesDescription> TimeSeriesDescriptions { get; set; }
    }

    public class UnitListServiceResponse
    {
        public UnitListServiceResponse()
        {
            Units = new List<UnitMetadata>{};
        }

        public int ResponseVersion { get; set; }
        public DateTimeOffset ResponseTime { get; set; }
        public string Summary { get; set; }
        public List<UnitMetadata> Units { get; set; }
    }

    public static class First
    {
        public static readonly AquariusServerVersion Version = AquariusServerVersion.Create("14");
    }
}
