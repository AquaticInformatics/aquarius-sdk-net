// Generated from: {"ApiVersion":"16.1.101.0"}
/* Options:
Date: 2016-06-06 17:45:19
Version: 4.054
Tip: To override a DTO option, remove "//" prefix before updating
BaseUrl: http://doug-vm2012r2/AQUARIUS/Publish/v2

GlobalNamespace: Aquarius.Client.Publish
MakePartial: False
MakeVirtual: False
//MakeDataContractsExtensible: False
//AddReturnMarker: True
//AddDescriptionAsComments: True
//AddDataContractAttributes: False
//AddIndexesToDataMembers: False
//AddGeneratedCodeAttributes: False
//AddResponseStatus: False
//AddImplicitVersion: 
//InitializeCollections: True
//IncludeTypes: 
//ExcludeTypes: 
//AddDefaultXmlNamespace: http://schemas.servicestack.net/types
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ServiceStack;
using ServiceStack.DataAnnotations;
using NodaTime;
using Aquarius.Client.Publish;


namespace Aquarius.Client.Publish
{

    [Route("/session", "DELETE")]
    public class DeleteSession
        : IReturnVoid
    {
    }

    [Route("/session/keepalive", "GET")]
    public class GetKeepAlive
        : IReturnVoid
    {
    }

    [Route("/session/publickey", "GET")]
    public class GetPublicKey
        : IReturn<PublicKey>
    {
    }

    [Route("/session", "POST")]
    public class PostSession
        : IReturn<string>
    {
        public string Username { get; set; }
        public string EncryptedPassword { get; set; }
        public string Locale { get; set; }
    }

    public class PublicKey
    {
        public int KeySize { get; set; }
        public string Xml { get; set; }
    }

    public class Approval
        : TimeRange
    {
        public int ApprovalLevel { get; set; }
        public DateTime DateAppliedUtc { get; set; }
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
        public CorrectionType Type { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
        public DateTime AppliedTimeUtc { get; set; }
        public string Comment { get; set; }
        public string User { get; set; }
        public IDictionary<string, Object> Parameters { get; set; }
        public CorrectionProcessingOrder ProcessingOrder { get; set; }
    }

    public class CorrectionOperation
        : TimeRange
    {
        public CorrectionType Type { get; set; }
        public IDictionary<string, Object> Parameters { get; set; }
        public CorrectionProcessingOrder ProcessingOrder { get; set; }
        public DateTime DateAppliedUtc { get; set; }
        public string User { get; set; }
        public MetadataChangeOperationType OperationType { get; set; }
        public int StackPosition { get; set; }
        public string Comments { get; set; }
    }

    public enum CorrectionProcessingOrder
    {
        PreProcessing,
        Normal,
        PostProcessing,
        Suppression,
    }

    public enum CorrectionType
    {
        Offset,
        USGSMultiPoint,
        RevertToRaw,
        DeleteRegion,
        CopyPaste,
        FillGaps,
        PersistenceGapFill,
        Drift,
        Percent,
        ReplaceWithGap,
        ClockDrift,
        Resample,
        Recession,
        AdjustableTrim,
        ThresholdTrim,
        ThresholdSuppression,
        FlagTrim,
        SingleGap,
        Amplification,
        SinglePoint,
        Deviation,
    }

    public class DoubleWithDisplay
    {
        public double? Numeric { get; set; }
        public string Display { get; set; }
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
        public bool IsValid { get; set; }
        public CompletedWork CompletedWork { get; set; }
        public DateTimeOffset LastModified { get; set; }
    }

    public class GapTolerance
        : TimeRange
    {
        public double? ToleranceInMinutes { get; set; }
    }

    public class GapToleranceOperation
        : GapTolerance
    {
        public MetadataChangeOperationType OperationType { get; set; }
        public DateTime DateAppliedUtc { get; set; }
        public string User { get; set; }
        public int StackPosition { get; set; }
        public string Comments { get; set; }
    }

    public class Grade
        : TimeRange
    {
        public string GradeCode { get; set; }
    }

    public class GradeMetadata
    {
        public string Identifier { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
    }

    public class GradeOperation
        : Grade
    {
        public DateTime DateAppliedUtc { get; set; }
        public string User { get; set; }
        public MetadataChangeOperationType OperationType { get; set; }
        public int StackPosition { get; set; }
        public string Comments { get; set; }
    }

    public class InterpolationType
        : TimeRange
    {
        public string Type { get; set; }
    }

    public class InterpolationTypeOperation
        : InterpolationType
    {
        public DateTime DateAppliedUtc { get; set; }
        public string User { get; set; }
        public MetadataChangeOperationType OperationType { get; set; }
        public int StackPosition { get; set; }
        public string Comments { get; set; }
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

    public class LocationMonitoringMethod
    {
        public string Name { get; set; }
        public string Method { get; set; }
        public string Parameter { get; set; }
        public string SubLocationIdentifier { get; set; }
        public string Comment { get; set; }
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

    public enum MetadataChangeContentType
    {
        Default,
        Corrected,
    }

    public enum MetadataChangeOperationType
    {
        Creation,
        Deletion,
    }

    public class MetadataChangeTransaction
    {
        public DateTimeOffset AppliedTime { get; set; }
        public string AppliedByUser { get; set; }
        public MetadataChangeContentType ContentType { get; set; }
        public IList<GapToleranceOperation> GapToleranceOperations { get; set; }
        public IList<GradeOperation> GradeOperations { get; set; }
        public IList<InterpolationTypeOperation> InterpolationTypeOperations { get; set; }
        public IList<MethodOperation> MethodOperations { get; set; }
        public IList<NoteOperation> NoteOperations { get; set; }
        public IList<QualifierOperation> QualifierOperations { get; set; }
        public IList<CorrectionOperation> CorrectionOperations { get; set; }
    }

    public class Method
        : TimeRange
    {
        public string MethodCode { get; set; }
    }

    public class MethodOperation
        : Method
    {
        public DateTime DateAppliedUtc { get; set; }
        public string User { get; set; }
        public MetadataChangeOperationType OperationType { get; set; }
        public int StackPosition { get; set; }
        public string Comments { get; set; }
    }

    public class MonitoringMethod
    {
        public string MethodCode { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string Parameter { get; set; }
        public string RoundingSpec { get; set; }
    }

    public class Note
        : TimeRange
    {
        public string NoteText { get; set; }
    }

    public class NoteOperation
        : Note
    {
        public DateTime DateAppliedUtc { get; set; }
        public string User { get; set; }
        public MetadataChangeOperationType OperationType { get; set; }
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
        public string RoundingSpec { get; set; }
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
        public string Remarks { get; set; }
    }

    public class Processor
    {
        public Processor()
        {
            InputTimeSeriesUniqueIds = new List<Guid>{};
            Settings = new Dictionary<string, string>{};
        }

        public string ProcessorType { get; set; }
        public List<Guid> InputTimeSeriesUniqueIds { get; set; }
        public Guid OutputTimeSeriesUniqueId { get; set; }
        public TimeRange ProcessorPeriod { get; set; }
        public string Description { get; set; }
        public string InputRatingModelIdentifier { get; set; }
        public Dictionary<string, string> Settings { get; set; }
    }

    public class Qualifier
        : TimeRange
    {
        public string Identifier { get; set; }
        public DateTime DateApplied { get; set; }
        public string User { get; set; }
    }

    public class QualifierMetadata
    {
        public string Identifier { get; set; }
        public string Code { get; set; }
        public string DisplayName { get; set; }
    }

    public class QualifierOperation
        : TimeRange
    {
        public string Identifier { get; set; }
        public MetadataChangeOperationType OperationType { get; set; }
        public DateTime DateAppliedUtc { get; set; }
        public string User { get; set; }
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
        public string Remarks { get; set; }
        public ParameterWithUnit InputParameter { get; set; }
        public ParameterWithUnit OutputParameter { get; set; }
        public List<PeriodOfApplicability> PeriodsOfApplicability { get; set; }
        public List<RatingShift> Shifts { get; set; }
        public List<RatingPoint> BaseRatingTable { get; set; }
        public List<OffsetPoint> Offsets { get; set; }
    }

    public enum RatingCurveType
    {
        LinearTable,
        LogarithmicTable,
        StandardEquation,
        DescriptiveEquation,
        LinearRegressionModel,
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
        public string Description { get; set; }
        public string Comment { get; set; }
        public DateTimeOffset LastModified { get; set; }
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

    public class StatisticalDateTimeOffset
    {
        public DateTimeOffset DateTimeOffset { get; set; }
        public bool RepresentsEndOfTimePeriod { get; set; }
    }

    public class StatisticalTimeRange
    {
        public StatisticalDateTimeOffset StartTime { get; set; }
        public StatisticalDateTimeOffset EndTime { get; set; }
    }

    public class TimeRange
    {
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
    }

    public class TimeSeriesDescription
    {
        public string Identifier { get; set; }
        public Guid UniqueId { get; set; }
        public string LocationIdentifier { get; set; }
        public string Parameter { get; set; }
        public string Unit { get; set; }
        public double UtcOffset { get; set; }
        public Offset UtcOffsetIsoDuration { get; set; }
        public DateTimeOffset LastModified { get; set; }
        public DateTimeOffset? RawStartTime { get; set; }
        public DateTimeOffset? RawEndTime { get; set; }
        public string TimeSeriesType { get; set; }
        public string Label { get; set; }
        public string Comment { get; set; }
        public string Description { get; set; }
        public bool Publish { get; set; }
        public string ComputationIdentifier { get; set; }
        public string ComputationPeriodIdentifier { get; set; }
        public string SubLocationIdentifier { get; set; }
        public IList<ExtendedAttribute> ExtendedAttributes { get; set; }
        public IList<TimeSeriesThreshold> Thresholds { get; set; }
    }

    public class TimeSeriesPoint
    {
        public StatisticalDateTimeOffset Timestamp { get; set; }
        public DoubleWithDisplay Value { get; set; }
    }

    public class TimeSeriesThreshold
    {
        public TimeSeriesThreshold()
        {
            Periods = new List<TimeSeriesThresholdPeriod>{};
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string ReferenceCode { get; set; }
        public int Severity { get; set; }
        public ThresholdType Type { get; set; }
        public string DisplayColor { get; set; }
        public List<TimeSeriesThresholdPeriod> Periods { get; set; }
    }

    public class TimeSeriesThresholdPeriod
    {
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
        public DateTime AppliedTime { get; set; }
        public double ReferenceValue { get; set; }
        public double? SecondaryReferenceValue { get; set; }
        public bool SuppressData { get; set; }
    }

    public class TimeSeriesUniqueIds
    {
        public Guid UniqueId { get; set; }
        public DateTimeOffset? FirstPointChanged { get; set; }
        public bool? HasAttributeChange { get; set; }
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

    public class AdcpDischargeActivity
    {
        public DischargeChannelMeasurement DischargeChannelMeasurement { get; set; }
        public bool IsValid { get; set; }
        public int? NumberOfTransects { get; set; }
        public DoubleWithDisplay MagneticVariation { get; set; }
        public DoubleWithDisplay DischargeCoefficientVariation { get; set; }
        public DoubleWithDisplay PercentOfDischargeMeasured { get; set; }
        public DoubleWithDisplay TopEstimateExponent { get; set; }
        public DoubleWithDisplay BottomEstimateExponent { get; set; }
        public QuantityWithDisplay Width { get; set; }
        public QuantityWithDisplay Area { get; set; }
        public QuantityWithDisplay VelocityAverage { get; set; }
        public QuantityWithDisplay TransducerDepth { get; set; }
        public string AdcpDeviceType { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public string NavigationMethod { get; set; }
        public string FirmwareVersion { get; set; }
        public string SoftwareVersion { get; set; }
        public string TopEstimateMethod { get; set; }
        public string BottomEstimateMethod { get; set; }
        public string DepthReference { get; set; }
        public string NodeDetails { get; set; }
    }

    public class Adjustment
    {
        public double? AdjustmentAmount { get; set; }
        public AdjustmentType AdjustmentType { get; set; }
        public ReasonForAdjustmentType ReasonForAdjustment { get; set; }
    }

    public class Attachment
    {
        public AttachmentType AttachmentType { get; set; }
        public AttachmentCategory AttachmentCategory { get; set; }
        public string FileName { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset DateUploaded { get; set; }
        public DateTimeOffset? DateLastAccessed { get; set; }
        public string UploadedByUser { get; set; }
        public string Comment { get; set; }
        public double? GpsLatitude { get; set; }
        public double? GpsLongitude { get; set; }
        public string Url { get; set; }
    }

    public class CalibrationCheck
    {
        public string Parameter { get; set; }
        public DoubleWithDisplay Standard { get; set; }
        public StandardDetails StandardDetails { get; set; }
        public string MonitoringMethod { get; set; }
        public DoubleWithDisplay Value { get; set; }
        public DoubleWithDisplay Difference { get; set; }
        public DoubleWithDisplay PercentDifference { get; set; }
        public string Unit { get; set; }
        public CalibrationCheckType CalibrationCheckType { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public DateTimeOffset? Time { get; set; }
        public string SubLocationIdentifier { get; set; }
        public string Comments { get; set; }
        public string NodeDetails { get; set; }
        public bool IsValid { get; set; }
    }

    public class CompletedWork
    {
        public string CollectionAgency { get; set; }
        public bool BiologicalSampleTaken { get; set; }
        public bool GroundWaterLevelPerformed { get; set; }
        public bool LevelsPerformed { get; set; }
        public bool OtherSampleTaken { get; set; }
        public bool RecorderDataCollected { get; set; }
        public bool SedimentSampleTaken { get; set; }
        public bool SafetyInspectionPerformed { get; set; }
        public bool WaterQualitySampleTaken { get; set; }
    }

    public class ControlConditionActivity
    {
        public string ControlCode { get; set; }
        public string FlowOverControl { get; set; }
        public ControlCleanedType ControlCleaned { get; set; }
        public ControlConditionType ControlCondition { get; set; }
        public DateTimeOffset? DateCleaned { get; set; }
        public QuantityWithDisplay DistanceToGage { get; set; }
        public string Comments { get; set; }
        public string Party { get; set; }
        public bool IsValid { get; set; }
    }

    public class DischargeActivity
    {
        public DischargeActivity()
        {
            VolumetricDischargeActivities = new List<VolumetricDischargeActivity>{};
            EngineeredStructureDischargeActivities = new List<EngineeredStructureDischargeActivity>{};
            PointVelocityDischargeActivities = new List<PointVelocityDischargeActivity>{};
            OtherMethodDischargeActivities = new List<OtherMethodDischargeActivity>{};
            AdcpDischargeActivities = new List<AdcpDischargeActivity>{};
        }

        public DischargeSummary DischargeSummary { get; set; }
        public List<VolumetricDischargeActivity> VolumetricDischargeActivities { get; set; }
        public List<EngineeredStructureDischargeActivity> EngineeredStructureDischargeActivities { get; set; }
        public List<PointVelocityDischargeActivity> PointVelocityDischargeActivities { get; set; }
        public List<OtherMethodDischargeActivity> OtherMethodDischargeActivities { get; set; }
        public List<AdcpDischargeActivity> AdcpDischargeActivities { get; set; }
    }

    public class DischargeChannelMeasurement
    {
        public string Channel { get; set; }
        public DateTimeOffset? StartTime { get; set; }
        public DateTimeOffset? EndTime { get; set; }
        public QuantityWithDisplay Discharge { get; set; }
        public string Comments { get; set; }
        public string Party { get; set; }
        public QuantityWithDisplay DistanceToGage { get; set; }
        public HorizontalFlowType HorizontalFlow { get; set; }
        public ChannelStabilityType ChannelStability { get; set; }
        public ChannelMaterialType ChannelMaterial { get; set; }
        public ChannelEvennessType ChannelEvenness { get; set; }
        public VerticalVelocityDistributionType VerticalVelocityDistribution { get; set; }
        public VelocityVariationType VelocityVariation { get; set; }
        public MeasurementLocationToGageType MeasurementLocationToGage { get; set; }
        public MeterSuspensionType MeterSuspension { get; set; }
        public DeploymentMethodType DeploymentMethod { get; set; }
        public CurrentMeterType CurrentMeter { get; set; }
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
        public DateTimeOffset MeasurementTime { get; set; }
        public string Party { get; set; }
        public BaseFlowType BaseFlow { get; set; }
        public Adjustment Adjustment { get; set; }
        public QuantityWithDisplay AlternateRatingDischarge { get; set; }
        public QuantityWithDisplay Discharge { get; set; }
        public string DischargeMethod { get; set; }
        public QuantityWithDisplay MeanGageHeight { get; set; }
        public string MeanGageHeightMethod { get; set; }
        public QuantityWithDisplay MeanIndexVelocity { get; set; }
        public DischargeMeasurementReasonType DischargeMeasurementReason { get; set; }
        public string Comments { get; set; }
        public GageHeightCalculationType GageHeightCalculation { get; set; }
        public List<GageHeightReading> GageHeightReadings { get; set; }
        public DoubleWithDisplay DifferenceDuringVisit { get; set; }
        public DoubleWithDisplay DurationInHours { get; set; }
        public MeasurementGradeType MeasurementGrade { get; set; }
        public string MeasurementId { get; set; }
        public string Reviewer { get; set; }
        public bool IsValid { get; set; }
        public bool Publish { get; set; }
    }

    public class EngineeredStructureDischargeActivity
    {
        public DischargeChannelMeasurement DischargeChannelMeasurement { get; set; }
        public string StructureType { get; set; }
        public string EquationForSelectedStructure { get; set; }
        public QuantityWithDisplay MeanHead { get; set; }
        public bool IsValid { get; set; }
    }

    public class FieldVisitApproval
    {
        public long ApprovalLevel { get; set; }
        public string LevelDescription { get; set; }
    }

    public class GageHeightAtZeroFlowActivity
    {
        public DateTimeOffset? ObservedDate { get; set; }
        public DateTimeOffset? ApplicableSince { get; set; }
        public DoubleWithDisplay ZeroFlowHeight { get; set; }
        public bool IsObserved { get; set; }
        public GageHeightAtZeroFlowCalculatedDetails CalculatedDetails { get; set; }
        public string Unit { get; set; }
        public string Comments { get; set; }
        public string Party { get; set; }
        public bool IsValid { get; set; }
    }

    public class GageHeightAtZeroFlowCalculatedDetails
    {
        public DoubleWithDisplay Stage { get; set; }
        public DoubleWithDisplay Depth { get; set; }
        public DoubleWithDisplay DepthCertainty { get; set; }
    }

    public class GageHeightReading
    {
        public bool IsUsed { get; set; }
        public DateTimeOffset? ReadingTime { get; set; }
        public DoubleWithDisplay GageHeight { get; set; }
    }

    public class Inspection
    {
        public InspectionType InspectionType { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public DateTimeOffset? Time { get; set; }
        public string SubLocationIdentifier { get; set; }
        public string Comments { get; set; }
    }

    public class InspectionActivity
    {
        public InspectionActivity()
        {
            Readings = new List<Reading>{};
            CalibrationChecks = new List<CalibrationCheck>{};
            Inspections = new List<Inspection>{};
        }

        public string Party { get; set; }
        public List<Reading> Readings { get; set; }
        public List<CalibrationCheck> CalibrationChecks { get; set; }
        public List<Inspection> Inspections { get; set; }
        public bool IsValid { get; set; }
    }

    public class OtherMethodDischargeActivity
    {
        public DischargeChannelMeasurement DischargeChannelMeasurement { get; set; }
        public bool IsValid { get; set; }
    }

    public class PointVelocityDischargeActivity
    {
        public DischargeChannelMeasurement DischargeChannelMeasurement { get; set; }
        public QuantityWithDisplay DistanceToMeter { get; set; }
        public QuantityWithDisplay Width { get; set; }
        public QuantityWithDisplay Area { get; set; }
        public QuantityWithDisplay VelocityAverage { get; set; }
        public DoubleWithDisplay MeanObservationDurationInSeconds { get; set; }
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
        public string SuspensionWeight { get; set; }
        public string VelocityObservationMethod { get; set; }
        public string FirmwareVersion { get; set; }
        public string SoftwareVersion { get; set; }
        public StartPointType StartPoint { get; set; }
        public string NodeDetails { get; set; }
        public bool IsValid { get; set; }
    }

    public class QuantityWithDisplay
        : DoubleWithDisplay
    {
        public string Unit { get; set; }
    }

    public class Reading
    {
        public string Parameter { get; set; }
        public string MonitoringMethod { get; set; }
        public DoubleWithDisplay Value { get; set; }
        public string Unit { get; set; }
        public DoubleWithDisplay Uncertainty { get; set; }
        public ReadingType ReadingType { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public DateTimeOffset? Time { get; set; }
        public string SubLocationIdentifier { get; set; }
        public string Comments { get; set; }
        public string NodeDetails { get; set; }
        public bool Publish { get; set; }
        public bool IsValid { get; set; }
    }

    public class StandardDetails
    {
        public string StandardCode { get; set; }
        public string LotNumber { get; set; }
        public DoubleWithDisplay Temperature { get; set; }
        public DateTimeOffset? ExpirationDate { get; set; }
    }

    public class VolumetricDischargeActivity
    {
        public VolumetricDischargeActivity()
        {
            VolumetricDischargeReadings = new List<VolumetricDischargeReading>{};
        }

        public DischargeChannelMeasurement DischargeChannelMeasurement { get; set; }
        public List<VolumetricDischargeReading> VolumetricDischargeReadings { get; set; }
        public QuantityWithDisplay MeasurementContainerVolume { get; set; }
        public bool IsObserved { get; set; }
        public bool IsValid { get; set; }
    }

    public class VolumetricDischargeReading
    {
        public string Name { get; set; }
        public DoubleWithDisplay DurationInSeconds { get; set; }
        public DoubleWithDisplay StartingVolume { get; set; }
        public DoubleWithDisplay EndingVolume { get; set; }
        public DoubleWithDisplay Discharge { get; set; }
        public bool IsUsed { get; set; }
        public DoubleWithDisplay VolumeChange { get; set; }
    }

    public enum AdjustmentType
    {
        Unknown,
        Percentage,
        Amount,
    }

    public enum AttachmentCategory
    {
        Unknown,
        None,
        LocationPhoto,
        Notes,
        Site,
        Channel,
        Measurement,
        CrossSection,
        Inspection,
        InventoryControl,
        LevelSurvey,
    }

    public enum AttachmentType
    {
        Unknown,
        Binary,
        Swami,
        Image,
        Video,
        Audio,
        Pdf,
        Xml,
        Text,
        Zip,
        HistoricalSwami,
        AquaCalc,
        FlowTracker,
        HFC,
        ScotLogger,
        SonTek,
        WinRiver,
        LoggerFile,
        GeneratedReport,
    }

    public enum BaseFlowType
    {
        Unknown,
        Unspecified,
        BaseFlow,
        NonBaseFlow,
    }

    public enum CalibrationCheckType
    {
        Unknown,
        PreCalibration,
        Calibration,
        PostCalibration,
        CheckbarAsFound,
        CheckbarAsChanged,
    }

    public enum ChannelEvennessType
    {
        Unknown,
        Unspecified,
        Even,
        Uneven,
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
        BedrockLedgeArtificial,
    }

    public enum ChannelStabilityType
    {
        Unknown,
        Unspecified,
        Soft,
        Firm,
    }

    public enum ControlCleanedType
    {
        Unknown,
        Unspecified,
        ControlCleaned,
        ControlNotCleaned,
    }

    public enum ControlConditionType
    {
        Unknown,
        Unspecifed,
        Clear,
        FillControlChanged,
        ScourControlChanged,
        DebrisLight,
        DebrisModerate,
        DebrisHeavy,
        VegetationLight,
        VegetationModerate,
        VegetationHeavy,
        IceAnchor,
        IceCover,
        IceShore,
        Submerged,
        NoFlow,
    }

    public enum CurrentMeterType
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
        UltrasonicMeter,
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
        BridgeCrane,
    }

    public enum DischargeMeasurementReasonType
    {
        Unknown,
        Routine,
        Check,
    }

    public enum DischargeMethodType
    {
        Unknown,
        MidSection,
    }

    public enum GageHeightCalculationType
    {
        Unknown,
        ManuallyCalculated,
        SimpleAverage,
    }

    public enum HorizontalFlowType
    {
        Unknown,
        Unspecified,
        Even,
        Uneven,
    }

    public enum InspectionType
    {
        Unknown,
        BubbleGage,
        CrestStageGage,
        WireWeightGage,
        MaximumMinimumGage,
        WaterQuality,
        FieldMeter,
    }

    public enum MeasurementGradeType
    {
        Unknown,
        Unspecified,
        Excellent,
        Good,
        Fair,
        Poor,
    }

    public enum MeasurementLocationToGageType
    {
        Unknown,
        Unspecified,
        AtTheGage,
        Upstream,
        Downstream,
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
        IceSurfaceMount,
    }

    public enum ReadingType
    {
        Unknown,
        Routine,
        ResetBefore,
        ResetAfter,
        CleaningBefore,
        CleaningAfter,
        AfterCalibration,
        ReferencePrimary,
        Reference,
        ExtremeMin,
        ExtremeMax,
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
        AdjustedForOtherFactors,
    }

    public enum StartPointType
    {
        Unknown,
        Unspecified,
        LeftEdgeOfWater,
        RightEdgeOfWater,
    }

    public enum VelocityVariationType
    {
        Unknown,
        Unspecified,
        Steady,
        Pulsating,
    }

    public enum VerticalVelocityDistributionType
    {
        Unknown,
        Unspecified,
        Uniform,
        Standard,
        NonStandard,
    }

    [Route("/GetApprovalList", "GET")]
    public class ApprovalListServiceRequest
        : IReturn<ApprovalListServiceResponse>
    {
    }

    [Route("/GetCorrectionList", "GET")]
    public class CorrectionListServiceRequest
        : IReturn<CorrectionListServiceResponse>
    {
        public Guid TimeSeriesUniqueId { get; set; }
        public DateTimeOffset? QueryFrom { get; set; }
        public DateTimeOffset? QueryTo { get; set; }
    }

    [Route("/GetDownchainProcessorListByRatingModel", "GET")]
    public class DownchainProcessorListByRatingModelServiceRequest
        : IReturn<ProcessorListServiceResponse>
    {
        public string RatingModelIdentifier { get; set; }
        public DateTimeOffset? QueryFrom { get; set; }
        public DateTimeOffset? QueryTo { get; set; }
    }

    [Route("/GetDownchainProcessorListByTimeSeries", "GET")]
    public class DownchainProcessorListByTimeSeriesServiceRequest
        : IReturn<ProcessorListServiceResponse>
    {
        public Guid TimeSeriesUniqueId { get; set; }
        public DateTimeOffset? QueryFrom { get; set; }
        public DateTimeOffset? QueryTo { get; set; }
    }

    [Route("/GetEffectiveRatingCurve", "GET")]
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

    [Route("/GetExpandedStageTable", "GET")]
    public class ExpandedStageTableServiceRequest
        : IReturn<ExpandedStageTableServiceResponse>
    {
        public Guid TimeSeriesUniqueId { get; set; }
        public double? StepSize { get; set; }
        public double? UtcOffset { get; set; }
        public double? StartValue { get; set; }
        public double? EndValue { get; set; }
    }

    [Route("/GetFieldVisitData", "GET")]
    public class FieldVisitDataServiceRequest
        : IReturn<FieldVisitDataServiceResponse>
    {
        public string FieldVisitIdentifier { get; set; }
        public string DiscreteMeasurementActivity { get; set; }
        public bool? IncludeNodeDetails { get; set; }
        public bool? IncludeInvalidActivities { get; set; }
        public bool? ApplyRounding { get; set; }
    }

    [Route("/GetFieldVisitDescriptionList", "GET")]
    public class FieldVisitDescriptionListServiceRequest
        : IReturn<FieldVisitDescriptionListServiceResponse>
    {
        public string LocationIdentifier { get; set; }
        public DateTimeOffset? QueryFrom { get; set; }
        public DateTimeOffset? QueryTo { get; set; }
        public bool? IncludeInvalidFieldVisits { get; set; }
        public DateTime? ChangesSinceToken { get; set; }
    }

    [Route("/GetAuthToken", "GET")]
    public class GetAuthTokenServiceRequest
        : IReturn<string>
    {
        public string Username { get; set; }
        public string EncryptedPassword { get; set; }
        public string Locale { get; set; }
    }

    [Route("/GetGradeList", "GET")]
    public class GradeListServiceRequest
        : IReturn<GradeListServiceResponse>
    {
    }

    [Route("/GetLocationData", "GET")]
    public class LocationDataServiceRequest
        : IReturn<LocationDataServiceResponse>
    {
        public string LocationIdentifier { get; set; }
        public bool? IncludeLocationAttachments { get; set; }
    }

    [Route("/GetLocationDescriptionList", "GET")]
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
        public DateTime? ChangesSinceToken { get; set; }
    }

    [Route("/GetMetadataChangeTransactionList", "GET")]
    public class MetadataChangeTransactionListServiceRequest
        : IReturn<MetadataChangeTransactionListServiceResponse>
    {
        public Guid TimeSeriesUniqueId { get; set; }
        public DateTimeOffset? QueryFrom { get; set; }
        public DateTimeOffset? QueryTo { get; set; }
    }

    [Route("/GetMonitoringMethodList", "GET")]
    public class MonitoringMethodListServiceRequest
        : IReturn<MonitoringMethodListServiceResponse>
    {
    }

    [Route("/GetParameterList", "GET")]
    public class ParameterListServiceRequest
        : IReturn<ParameterListServiceResponse>
    {
    }

    [Route("/GetQualifierList", "GET")]
    public class QualifierListServiceRequest
        : IReturn<QualifierListServiceResponse>
    {
    }

    [Route("/GetRatingCurveList", "GET")]
    public class RatingCurveListServiceRequest
        : IReturn<RatingCurveListServiceResponse>
    {
        public string RatingModelIdentifier { get; set; }
        public double? UtcOffset { get; set; }
        public DateTimeOffset? QueryFrom { get; set; }
        public DateTimeOffset? QueryTo { get; set; }
    }

    [Route("/GetRatingModelDescriptionList", "GET")]
    public class RatingModelDescriptionListServiceRequest
        : IReturn<RatingModelDescriptionListServiceResponse>
    {
        public string LocationIdentifier { get; set; }
        public bool? Publish { get; set; }
        public string InputParameter { get; set; }
        public string OutputParameter { get; set; }
        public DateTime? ChangesSinceToken { get; set; }
    }

    [Route("/GetRatingModelEffectiveShifts", "GET")]
    public class RatingModelEffectiveShiftsServiceRequest
        : IReturn<RatingModelEffectiveShiftsServiceResponse>
    {
        public Guid TimeSeriesUniqueId { get; set; }
        public string RatingModelIdentifier { get; set; }
        public DateTimeOffset? QueryFrom { get; set; }
        public DateTimeOffset? QueryTo { get; set; }
    }

    [Route("/GetRatingModelInputValues", "GET")]
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

    [Route("/GetRatingModelOutputValues", "GET")]
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

    [Route("/GetSensorsAndGauges", "GET")]
    public class SensorsAndGaugesServiceRequest
        : IReturn<SensorsAndGaugesServiceResponse>
    {
        public string LocationIdentifier { get; set; }
    }

    [Route("/GetApprovalsTransactionList", "GET")]
    public class TimeSeriesApprovalsTransactionListServiceRequest
        : IReturn<TimeSeriesApprovalsTransactionListServiceResponse>
    {
        public Guid TimeSeriesUniqueId { get; set; }
        public DateTimeOffset? QueryFrom { get; set; }
        public DateTimeOffset? QueryTo { get; set; }
    }

    [Route("/GetTimeSeriesCorrectedData", "GET")]
    public class TimeSeriesDataCorrectedServiceRequest
        : IReturn<TimeSeriesDataServiceResponse>
    {
        public Guid TimeSeriesUniqueId { get; set; }
        public DateTimeOffset? QueryFrom { get; set; }
        public DateTimeOffset? QueryTo { get; set; }
        public string GetParts { get; set; }
        public string Unit { get; set; }
        public double? UtcOffset { get; set; }
        public bool? ApplyRounding { get; set; }
        public bool? ReturnFullCoverage { get; set; }
        public bool? IncludeGapMarkers { get; set; }
    }

    [Route("/GetTimeSeriesRawData", "GET")]
    public class TimeSeriesDataRawServiceRequest
        : IReturn<TimeSeriesDataServiceResponse>
    {
        public Guid TimeSeriesUniqueId { get; set; }
        public DateTimeOffset? QueryFrom { get; set; }
        public DateTimeOffset? QueryTo { get; set; }
        public string GetParts { get; set; }
        public string Unit { get; set; }
        public double? UtcOffset { get; set; }
        public bool? ApplyRounding { get; set; }
    }

    [Route("/GetTimeSeriesDescriptionListByUniqueId", "GET")]
    public class TimeSeriesDescriptionListByUniqueIdServiceRequest
        : IReturn<TimeSeriesDescriptionListByUniqueIdServiceResponse>
    {
        public TimeSeriesDescriptionListByUniqueIdServiceRequest()
        {
            TimeSeriesUniqueIds = new List<Guid>{};
        }

        public List<Guid> TimeSeriesUniqueIds { get; set; }
    }

    [Route("/GetTimeSeriesDescriptionList", "GET")]
    public class TimeSeriesDescriptionServiceRequest
        : IReturn<TimeSeriesDescriptionListServiceResponse>
    {
        public TimeSeriesDescriptionServiceRequest()
        {
            ExtendedFilters = new List<ExtendedAttributeFilter>{};
        }

        public string LocationIdentifier { get; set; }
        public string Parameter { get; set; }
        public bool? Publish { get; set; }
        public string ComputationIdentifier { get; set; }
        public string ComputationPeriodIdentifier { get; set; }
        public List<ExtendedAttributeFilter> ExtendedFilters { get; set; }
    }

    [Route("/GetTimeSeriesUniqueIdList", "GET")]
    public class TimeSeriesUniqueIdListServiceRequest
        : IReturn<TimeSeriesUniqueIdListServiceResponse>
    {
        public TimeSeriesUniqueIdListServiceRequest()
        {
            ExtendedFilters = new List<ExtendedAttributeFilter>{};
        }

        public DateTime? ChangesSinceToken { get; set; }
        public string ChangeEventType { get; set; }
        public string LocationIdentifier { get; set; }
        public string Parameter { get; set; }
        public bool? Publish { get; set; }
        public string ComputationIdentifier { get; set; }
        public string ComputationPeriodIdentifier { get; set; }
        public List<ExtendedAttributeFilter> ExtendedFilters { get; set; }
    }

    [Route("/GetUnitList", "GET")]
    public class UnitListServiceRequest
        : IReturn<UnitListServiceResponse>
    {
    }

    [Route("/GetUpchainProcessorListByTimeSeries", "GET")]
    public class UpchainProcessorListByTimeSeriesServiceRequest
        : IReturn<ProcessorListServiceResponse>
    {
        public Guid TimeSeriesUniqueId { get; set; }
        public DateTimeOffset? QueryFrom { get; set; }
        public DateTimeOffset? QueryTo { get; set; }
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
            Attachments = new List<Attachment>{};
            DischargeActivities = new List<DischargeActivity>{};
        }

        public int ResponseVersion { get; set; }
        public DateTimeOffset ResponseTime { get; set; }
        public string Summary { get; set; }
        public List<Attachment> Attachments { get; set; }
        public List<DischargeActivity> DischargeActivities { get; set; }
        public GageHeightAtZeroFlowActivity GageHeightAtZeroFlowActivity { get; set; }
        public ControlConditionActivity ControlConditionActivity { get; set; }
        public InspectionActivity InspectionActivity { get; set; }
        public FieldVisitApproval Approval { get; set; }
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
        public DateTime? NextToken { get; set; }
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
            Attachments = new List<Attachment>{};
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
        public List<ExtendedAttribute> ExtendedAttributes { get; set; }
        public List<LocationRemark> LocationRemarks { get; set; }
        public List<Attachment> Attachments { get; set; }
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
        public DateTime? NextToken { get; set; }
    }

    public class MetadataChangeTransactionListServiceResponse
    {
        public int ResponseVersion { get; set; }
        public DateTimeOffset ResponseTime { get; set; }
        public string Summary { get; set; }
        public IList<MetadataChangeTransaction> MetadataChangeTransactions { get; set; }
    }

    public class MonitoringMethodListServiceResponse
    {
        public MonitoringMethodListServiceResponse()
        {
            MonitoringMethods = new List<MonitoringMethod>{};
        }

        public int ResponseVersion { get; set; }
        public DateTime ResponseTime { get; set; }
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

    public class ProcessorListServiceResponse
    {
        public ProcessorListServiceResponse()
        {
            Processors = new List<Processor>{};
        }

        public int ResponseVersion { get; set; }
        public DateTimeOffset ResponseTime { get; set; }
        public string Summary { get; set; }
        public List<Processor> Processors { get; set; }
    }

    public class QualifierListServiceResponse
    {
        public QualifierListServiceResponse()
        {
            Qualifiers = new List<QualifierMetadata>{};
        }

        public int ResponseVersion { get; set; }
        public DateTimeOffset ResponseTime { get; set; }
        public string Summary { get; set; }
        public List<QualifierMetadata> Qualifiers { get; set; }
    }

    public class RatingCurveListServiceResponse
    {
        public int ResponseVersion { get; set; }
        public DateTimeOffset ResponseTime { get; set; }
        public string Summary { get; set; }
        public IList<RatingCurve> RatingCurves { get; set; }
        public IList<Approval> Approvals { get; set; }
    }

    public class RatingModelDescriptionListServiceResponse
    {
        public int ResponseVersion { get; set; }
        public DateTimeOffset ResponseTime { get; set; }
        public string Summary { get; set; }
        public IList<RatingModelDescription> RatingModelDescriptions { get; set; }
        public DateTime? NextToken { get; set; }
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
            InputValues = new List<Nullable<Double>>{};
        }

        public int ResponseVersion { get; set; }
        public DateTimeOffset ResponseTime { get; set; }
        public string Summary { get; set; }
        public List<Nullable<Double>> InputValues { get; set; }
    }

    public class RatingModelOutputValuesServiceResponse
    {
        public RatingModelOutputValuesServiceResponse()
        {
            OutputValues = new List<Nullable<Double>>{};
        }

        public int ResponseVersion { get; set; }
        public DateTimeOffset ResponseTime { get; set; }
        public string Summary { get; set; }
        public List<Nullable<Double>> OutputValues { get; set; }
    }

    public class SensorsAndGaugesServiceResponse
    {
        public SensorsAndGaugesServiceResponse()
        {
            MonitoringMethods = new List<LocationMonitoringMethod>{};
        }

        public int ResponseVersion { get; set; }
        public DateTimeOffset ResponseTime { get; set; }
        public string Summary { get; set; }
        public List<LocationMonitoringMethod> MonitoringMethods { get; set; }
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
        public TimeSeriesDataServiceResponse()
        {
            Approvals = new List<Approval>{};
            Qualifiers = new List<Qualifier>{};
            Methods = new List<Method>{};
            Grades = new List<Grade>{};
            GapTolerances = new List<GapTolerance>{};
            InterpolationTypes = new List<InterpolationType>{};
            Notes = new List<Note>{};
            Points = new List<TimeSeriesPoint>{};
        }

        public int ResponseVersion { get; set; }
        public DateTimeOffset ResponseTime { get; set; }
        public string Summary { get; set; }
        public Guid UniqueId { get; set; }
        public string Parameter { get; set; }
        public string Label { get; set; }
        public string LocationIdentifier { get; set; }
        public long? NumPoints { get; set; }
        public string Unit { get; set; }
        public List<Approval> Approvals { get; set; }
        public List<Qualifier> Qualifiers { get; set; }
        public List<Method> Methods { get; set; }
        public List<Grade> Grades { get; set; }
        public List<GapTolerance> GapTolerances { get; set; }
        public List<InterpolationType> InterpolationTypes { get; set; }
        public List<Note> Notes { get; set; }
        public StatisticalTimeRange TimeRange { get; set; }
        public List<TimeSeriesPoint> Points { get; set; }
    }

    public class TimeSeriesDescriptionListByUniqueIdServiceResponse
    {
        public TimeSeriesDescriptionListByUniqueIdServiceResponse()
        {
            TimeSeriesDescriptions = new List<TimeSeriesDescription>{};
        }

        public int ResponseVersion { get; set; }
        public DateTimeOffset ResponseTime { get; set; }
        public string Summary { get; set; }
        public List<TimeSeriesDescription> TimeSeriesDescriptions { get; set; }
    }

    public class TimeSeriesDescriptionListServiceResponse
    {
        public TimeSeriesDescriptionListServiceResponse()
        {
            TimeSeriesDescriptions = new List<TimeSeriesDescription>{};
        }

        public int ResponseVersion { get; set; }
        public DateTimeOffset ResponseTime { get; set; }
        public string Summary { get; set; }
        public List<TimeSeriesDescription> TimeSeriesDescriptions { get; set; }
    }

    public class TimeSeriesUniqueIdListServiceResponse
    {
        public TimeSeriesUniqueIdListServiceResponse()
        {
            TimeSeriesUniqueIds = new List<TimeSeriesUniqueIds>{};
        }

        public int ResponseVersion { get; set; }
        public DateTimeOffset ResponseTime { get; set; }
        public string Summary { get; set; }
        public bool? TokenExpired { get; set; }
        public DateTime? NextToken { get; set; }
        public List<TimeSeriesUniqueIds> TimeSeriesUniqueIds { get; set; }
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

    public enum ThresholdType
    {
        Unknown,
        ThresholdAbove,
        ThresholdBelow,
        None,
    }
}

