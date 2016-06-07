// Generated from: {"ApiVersion":"16.1.101.0"}
/* Options:
Date: 2016-06-06 17:45:21
Version: 4.054
Tip: To override a DTO option, remove "//" prefix before updating
BaseUrl: http://doug-vm2012r2/AQUARIUS/Processor

GlobalNamespace: Aquarius.Client.Processor
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
using Aquarius.Client.Processor;


namespace Aquarius.Client.Processor
{

    [Route("/codetable/grades", "GET")]
    public class GetGradesRequest
        : IReturn<IList<Grade>>
    {
    }

    [Route("/codetable/qualifiers", "GET")]
    public class GetQualifiersRequest
        : IReturn<IList<Qualifier>>
    {
    }

    public class Grade
    {
        public ObjectId Identifier { get; set; }
        public int GradeCode { get; set; }
        public string Color { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
    }

    public class Qualifier
    {
        public string PublicIdentifier { get; set; }
        public string QualifierCode { get; set; }
        public string DisplayName { get; set; }
        public string SystemCode { get; set; }
    }

    public class RelativeTimeRange
    {
        public RelativeTimeRangeType Type { get; set; }
        public RelativeTimeUnitType Unit { get; set; }
        public string Value { get; set; }
        public string SecondaryValue { get; set; }
    }

    public enum RelativeTimeRangeType
    {
        Unknown,
        LatestComplete,
        MostRecent,
        WaterYear,
        Year,
        Month,
        Day,
        DateRange,
        EntireRecord,
    }

    public enum RelativeTimeUnitType
    {
        Unknown,
        None,
        WaterYears,
        Years,
        Months,
        Days,
    }

    [Route("/convert/relativetimerange", "POST")]
    public class ConvertRelativeTimeRequest
        : IReturn<Interval>
    {
        public RelativeTimeRange RelativeTime { get; set; }
        public Offset UtcOffset { get; set; }
    }

    public class ExtendedAttributeFieldDefinition
    {
        public string ColumnIdentifier { get; set; }
        public string DisplayName { get; set; }
        public ExtendedAttributeFieldType FieldType { get; set; }
        public bool CanBeEmpty { get; set; }
        public bool IsReadOnly { get; set; }
        public short? NumericPrecision { get; set; }
        public short? NumericScale { get; set; }
        public int? ColumnSize { get; set; }
        public IReadOnlyList<string> ValueOptions { get; set; }
    }

    public enum ExtendedAttributeFieldType
    {
        Boolean,
        DateTime,
        Number,
        String,
        StringOption,
    }

    public class ExtendedAttributeFieldValue
    {
        public string ColumnIdentifier { get; set; }
        public string Value { get; set; }
    }

    public class Location
    {
        public long Id { get; set; }
        public long LocationFolderId { get; set; }
        public DateTime LastModified { get; set; }
        public string LocationName { get; set; }
        public string Description { get; set; }
        public string Identifier { get; set; }
        public long? LocationTypeId { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public int? Srid { get; set; }
        public string ElevationUnits { get; set; }
        public double? Elevation { get; set; }
        public double UtcOffsetHours { get; set; }
        public string ExternalUserDataProvider { get; set; }
        public bool IsExternal { get; set; }
        public bool IsReadOnly { get; set; }
        public bool CanAssignUserRoles { get; set; }
        public IList<ExtendedAttributeFieldValue> ExtendedAttributeValues { get; set; }
    }

    public class LocationType
    {
        public long Id { get; set; }
        public string LocationTypeName { get; set; }
        public string Description { get; set; }
        public IList<ExtendedAttributeFieldDefinition> ExtendedAttributeFields { get; set; }
    }

    [Route("/location", "POST")]
    public class CreateLocationRequest
        : UpdateLocationRequestBase, IReturn<long>
    {
    }

    [Route("/location/identifier/{LocationIdentifier}", "DELETE")]
    public class DeleteLocationByIdentifierRequest
        : IReturn<ResponseStatus>
    {
        public string LocationIdentifier { get; set; }
    }

    [Route("/location/id/{LocationId}", "DELETE")]
    public class DeleteLocationByIdRequest
        : IReturn<ResponseStatus>
    {
        public long LocationId { get; set; }
    }

    [Route("/locationtypes", "GET")]
    public class GetAllLocationTypesRequest
        : IReturn<IList<LocationType>>
    {
    }

    [Route("/location/identifier/{LocationIdentifier}", "GET")]
    public class GetLocationByIdentifierRequest
        : IReturn<Location>
    {
        public string LocationIdentifier { get; set; }
    }

    [Route("/location/{LocationId}", "GET")]
    public class GetLocationByIdRequest
        : IReturn<Location>
    {
        public long LocationId { get; set; }
    }

    [Route("/location/{LocationId}/extendedattributes", "PUT")]
    public class UpdateLocationExtendedAttributesRequest
        : IReturnVoid
    {
        public long LocationId { get; set; }
        public IList<ExtendedAttributeFieldValue> ExtendedAttributeValues { get; set; }
    }

    [Route("/location/{LocationId}", "PUT")]
    public class UpdateLocationRequest
        : UpdateLocationRequestBase, IReturnVoid
    {
        public long LocationId { get; set; }
    }

    public class UpdateLocationRequestBase
    {
        public long LocationFolderId { get; set; }
        public string LocationName { get; set; }
        public string Description { get; set; }
        public string Identifier { get; set; }
        public long? LocationTypeId { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public int? Srid { get; set; }
        public string ElevationUnits { get; set; }
        public double? Elevation { get; set; }
        public double UtcOffsetHours { get; set; }
        public IList<ExtendedAttributeFieldValue> ExtendedAttributeValues { get; set; }
    }

    public class FormulaValidationError
    {
        public int? Line { get; set; }
        public int? Column { get; set; }
        public string CompilerErrorCode { get; set; }
        public string CompilerErrorText { get; set; }
    }

    public class LogicalWorkUnit
    {
        public long? WorkUnitId { get; set; }
        public string Status { get; set; }
        public int EventCount { get; set; }
        public DateTime QueuedTime { get; set; }
        public DateTime? WorkStartTime { get; set; }
        public DateTime? WorkEndTime { get; set; }
        public string ExceptionMessage { get; set; }
        public string NodeMachineName { get; set; }
        public long? TimeSeriesId { get; set; }
        public string TimeSeriesIdentifier { get; set; }
        public long? LocationId { get; set; }
        public string LocationIdentifier { get; set; }
    }

    public class ProcessingPlanEntry
        : TimeSeriesProcessingPlanEntry
    {
        public long ProcessingPlanEntryId { get; set; }
        public long TimeSeriesId { get; set; }
    }

    public class TimeInterval
    {
        public DateTimeOffset? StartTime { get; set; }
        public DateTimeOffset? EndTime { get; set; }
    }

    public class TimeSeriesProcessingPlanEntry
    {
        public TimeSeriesProcessingPlanEntry()
        {
            InputTimeSeries = new Dictionary<string, long>{};
            InputRatingModels = new Dictionary<string, long>{};
            ProcessorSettings = new Dictionary<string, string>{};
        }

        public string ProcessorType { get; set; }
        public string Description { get; set; }
        public TimeInterval Interval { get; set; }
        public Dictionary<string, long> InputTimeSeries { get; set; }
        public Dictionary<string, long> InputRatingModels { get; set; }
        public Dictionary<string, string> ProcessorSettings { get; set; }
    }

    [Route("/admin/workunit/{WorkUnitId}/cancel", "PUT")]
    public class CancelWorkUnitRequest
        : IReturnVoid
    {
        public long WorkUnitId { get; set; }
    }

    [Route("/validateformula", "POST")]
    public class FormulaValidationRequest
        : IReturn<FormulaValidationResponse>
    {
        public string Formula { get; set; }
        public int InputCount { get; set; }
    }

    [Route("/admin/timeseries/{TimeSeriesId}/logicalworkunits/failed", "GET")]
    public class GetFailedLogicalWorkUnitsForTimeSeriesRequest
        : IReturn<IList<LogicalWorkUnit>>
    {
        public long TimeSeriesId { get; set; }
    }

    [Route("/admin/logicalworkunits/failed", "GET")]
    public class GetFailedLogicalWorkUnitsRequest
        : IReturn<IList<LogicalWorkUnit>>
    {
    }

    [Route("/admin/logicalworkunits", "GET")]
    public class GetLogicalWorkUnitRequest
        : IReturn<IList<LogicalWorkUnit>>
    {
    }

    [Route("/admin/timeseries/{TimeSeriesId}/logicalworkunits", "GET")]
    public class GetLogicalWorkUnitsForTimeSeriesRequest
        : IReturn<IList<LogicalWorkUnit>>
    {
        public long TimeSeriesId { get; set; }
    }

    [Route("/timeseries/{TimeSeriesId}/processingplanentries", "GET")]
    public class GetProcessingPlanEntriesForTimeSeriesRequest
        : IReturn<List<ProcessingPlanEntry>>
    {
        public long TimeSeriesId { get; set; }
    }

    [Route("/timeseries/{TimeSeriesId}/references/processingplanentries", "GET")]
    public class GetProcessingPlanEntryReferencesToTimeSeriesRequest
        : IReturn<List<ProcessingPlanEntry>>
    {
        public long TimeSeriesId { get; set; }
    }

    [Route("/admin/workunit/{WorkUnitId}/restart", "PUT")]
    public class RestartWorkUnitRequest
        : IReturnVoid
    {
        public long WorkUnitId { get; set; }
    }

    [Route("/timeseries/{TimeSeriesId}/processingplan", "PUT")]
    public class UpdateTimeSeriesProcessingPlanRequest
        : List<TimeSeriesProcessingPlanEntry>, IReturn<IList<TimeSeriesProcessingPlanEntry>>
    {
    }

    public class FormulaValidationResponse
    {
        public FormulaValidationResponse()
        {
            FormulaValidationErrors = new List<FormulaValidationError>{};
        }

        public bool IsValid { get; set; }
        public List<FormulaValidationError> FormulaValidationErrors { get; set; }
    }

    public class PortInfo
    {
        public string Units { get; set; }
        public string UnitsSymbol { get; set; }
        public string ParameterType { get; set; }
        public string ParameterDisplayId { get; set; }
    }

    public class RatingModelInfo
    {
        public long RatingModelId { get; set; }
        public long LocationId { get; set; }
        public string LocationIdentifier { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBy { get; set; }
        public string Identifier { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
        public PortInfo InputInfo { get; set; }
        public PortInfo OutputInfo { get; set; }
        public TimeSpan UtcOffset { get; set; }
        public string DefaultInputIds { get; set; }
        public string Status { get; set; }
        public long? TemplateId { get; set; }
        public bool Publish { get; set; }
    }

    [Route("/location/{LocationId}/ratingmodel", "POST")]
    public class CreateRatingModelRequest
        : IReturn<RatingModelInfo>
    {
        public long LocationId { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
        public string InputUnits { get; set; }
        public string InputParameterType { get; set; }
        public string OutputUnits { get; set; }
        public string OutputParameterType { get; set; }
        public TimeSpan UtcOffset { get; set; }
        public string DefaultInputIds { get; set; }
        public string Status { get; set; }
        public long? TemplateId { get; set; }
        public bool Publish { get; set; }
    }

    [Route("/ratingmodel/{RatingModelId}", "DELETE")]
    public class DeleteRatingModelRequest
        : IReturn<ResponseStatus>
    {
        public long RatingModelId { get; set; }
    }

    [Route("/ratingmodel/{RatingModelId}/info", "GET")]
    public class GetRatingModelInfoRequest
        : IReturn<RatingModelInfo>
    {
        public long RatingModelId { get; set; }
    }

    [Route("/ratingmodel/{RatingModelId}", "PUT")]
    public class UpdateRatingModelRequest
        : IReturnVoid
    {
        public long RatingModelId { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
        public bool Publish { get; set; }
    }

    public enum ParameterType
    {
        Unknown,
        TimeSeriesIdentifier,
        RatingModelIdentifier,
        LocationIdentifier,
        Integer,
        Double,
        Boolean,
        String,
        Instant,
        Duration,
        PickList,
    }

    public class ReportDefinition
        : ReportDefinitionInfo
    {
        public ReportDefinition()
        {
            Parameters = new List<ReportParameterDescription>{};
        }

        public RelativeTimeRange DefaultTimeRange { get; set; }
        public List<ReportParameterDescription> Parameters { get; set; }
    }

    public class ReportDefinitionInfo
    {
        public Guid ReportDefinitionIdentifier { get; set; }
        public string Name { get; set; }
        public string LocalizedLabel { get; set; }
        public string LocalizedDescription { get; set; }
        public ReportType ReportType { get; set; }
    }

    public class ReportJob
        : ReportDefinitionInfo
    {
        public ReportJob()
        {
            Parameters = new List<ReportJobParameter>{};
        }

        public long Id { get; set; }
        public ReportJobStatusType Status { get; set; }
        public string ErrorMessage { get; set; }
        public string AttachmentId { get; set; }
        public List<ReportJobParameter> Parameters { get; set; }
        public bool IsTransient { get; set; }
    }

    public class ReportJobParameter
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public enum ReportJobStatusType
    {
        Unknown,
        Pending,
        Completed,
        Failed,
    }

    public class ReportJobWithUser
        : ReportJob
    {
        public DateTime JobQueuedTimeUtc { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserLoginName { get; set; }
    }

    public enum ReportOutputType
    {
        Unknown,
        Pdf,
        Xml,
    }

    public class ReportParameterDescription
    {
        public ParameterType Type { get; set; }
        public string Name { get; set; }
        public string LocalizedLabel { get; set; }
        public string LocalizedDescription { get; set; }
        public int SortingOrder { get; set; }
        public bool Required { get; set; }
        public string DefaultValue { get; set; }
        public string UiGroupName { get; set; }
        public IDictionary<string, string> ValidationOptions { get; set; }
        public IDictionary<string, string> PickListOptions { get; set; }
    }

    public enum ReportType
    {
        Unknown,
        DataPlot,
        EventAnalysis,
        IntensityAnalysis,
        Tabular,
        DailyMeanByYear,
        HourlyMeanByMonth,
        HourlyMeanByWeek,
        MonthlyMeanByDecade,
    }

    [Route("/reporting/list", "GET")]
    public class GetAvailableReportsRequest
        : IReturn<List<ReportDefinitionInfo>>
    {
    }

    [Route("/reporting/details/{ReportDefinitionIdentifier}", "GET")]
    public class GetReportDefinitionRequest
        : IReturn<ReportDefinition>
    {
        public Guid ReportDefinitionIdentifier { get; set; }
    }

    [Route("/reporting/job/{ReportJobId}", "GET")]
    public class GetReportJobRequest
        : IReturn<ReportJobStatusType>
    {
        public long ReportJobId { get; set; }
    }

    [Route("/reporting/jobs", "GET")]
    public class GetReportJobsRequest
        : IReturn<SearchResultsBase<ReportJobWithUser>>
    {
        public RelativeTimeRangeType JobQueuedTimeRangeType { get; set; }
        public RelativeTimeUnitType JobQueuedTimeRangeUnit { get; set; }
        public string JobQueuedTimeRangeValue { get; set; }
        public string JobQueuedTimeRangeSecondaryValue { get; set; }
        public Offset UtcOffset { get; set; }
        public int MaxResults { get; set; }
        public long? UserId { get; set; }
    }

    [Route("/reporting/job/status/{ReportJobId}", "GET")]
    public class GetReportJobStatusRequest
        : IReturn<ReportJobStatusType>
    {
        public long ReportJobId { get; set; }
    }

    [Route("/reporting/run/{ReportDefinitionIdentifier}", "POST")]
    public class RunReportRequest
        : IReturn<long>
    {
        public Guid ReportDefinitionIdentifier { get; set; }
        public RelativeTimeRange RequestedTimeRange { get; set; }
        public Offset UtcOffset { get; set; }
        public IDictionary<string, ReportJobParameter> Parameters { get; set; }
        public ReportOutputType OutputType { get; set; }
        public string RequestingUserLocale { get; set; }
        public bool IsTransient { get; set; }
    }

    public enum AppendStatusCode
    {
        Pending,
        Completed,
        Failed,
    }

    public class ApprovalSnapshot
    {
        public Interval ApprovedInterval { get; set; }
        public IReadOnlyList<TimeSeriesPoint> ApprovedPoints { get; set; }
    }

    public enum ContentType
    {
        Unknown,
        Default,
        Raw,
        Corrected,
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
        Usgs,
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
        RecessionCurve,
        AdjustableTrim,
        ThresholdTrim,
        FlagTrim,
        SingleGap,
        SinglePoint,
        Deviation,
        Amplification,
        ThresholdSuppression,
    }

    public class DataCorrectionChartAxis
    {
        public DataCorrectionChartAxis()
        {
            TimeSeriesOnAxis = new List<TimeSeriesOnChartAxis>{};
        }

        public long ChartAxisId { get; set; }
        [Required]
        public DataCorrectionAxisType AxisType { get; set; }

        [Required]
        public string AxisLabel { get; set; }

        [Required]
        public ScaleType ScaleType { get; set; }

        [Required]
        public AxisPosition AxisPosition { get; set; }

        [Required]
        public ScaleMethod ScaleMethod { get; set; }

        [Required]
        public double Minimum { get; set; }

        [Required]
        public double Maximum { get; set; }

        [Required]
        public double LogarithmCycles { get; set; }

        [Required]
        public List<TimeSeriesOnChartAxis> TimeSeriesOnAxis { get; set; }
    }

    public enum InterpolationType
    {
        InstantaneousValues = 1,
        PrecedingConstant = 2,
        PrecedingTotals = 5,
        InstantaneousTotals = 6,
        DiscreteValues = 7,
        SucceedingConstant = 8,
    }

    public class ProcessingPlanStatus
    {
        public bool HasPendingWork { get; set; }
        public bool HasRunningWork { get; set; }
        public bool HasFailedWork { get; set; }
    }

    public class TimeSeriesAppendStatus
    {
        [ApiMember(Description="Internal ID of the time series")]
        public long TimeSeriesId { get; set; }

        public AppendStatusCode AppendStatus { get; set; }
        [ApiMember(Description="When AppendStatus=Completed: Version of the time series containing the appended points")]
        public long AppendedVersion { get; set; }

        [ApiMember(Description="When AppendStatus=Completed: Number of points successfully appended")]
        public int NumberOfPointsAppended { get; set; }

        [ApiMember(Description="When AppendStatus=Completed: Number of points successfully deleted")]
        public int NumberOfPointsDeleted { get; set; }
    }

    public class TimeSeriesAttributes
    {
        public string Label { get; set; }
        public string Comment { get; set; }
        public string Description { get; set; }
        public bool Publish { get; set; }
        public IList<ExtendedAttributeFieldValue> ExtendedAttributeValues { get; set; }
    }

    public class TimeSeriesDetails
        : TimeSeriesInfo
    {
        public IList<TimeSeriesProcessingPlanEntry> ProcessingPlan { get; set; }
    }

    public class TimeSeriesInfo
        : TimeSeriesAttributes
    {
        public long TimeSeriesId { get; set; }
        public TimeSeriesVersion RawVersion { get; set; }
        public TimeSeriesVersion CorrectedVersion { get; set; }
        public long LocationId { get; set; }
        public string LocationIdentifier { get; set; }
        public long? SubLocationId { get; set; }
        public string SubLocationIdentifier { get; set; }
        public TimeSeriesType TimeSeriesType { get; set; }
        public string Identifier { get; set; }
        public string ParameterName { get; set; }
        public string ParameterId { get; set; }
        public string UnitId { get; set; }
        public Offset UtcOffset { get; set; }
        public string ComputationIdentifier { get; set; }
        public string ComputationDisplayName { get; set; }
        public string ComputationPeriodIdentifier { get; set; }
        public string ComputationPeriodDisplayName { get; set; }
        public Guid UniqueId { get; set; }
    }

    public class TimeSeriesOnChartAxis
    {
        [Required]
        public long TimeSeriesId { get; set; }

        [Required]
        public PointType PointType { get; set; }
    }

    public class TimeSeriesPoint
    {
        [ApiMember(Description="ISO 8601 timestamp", IsRequired=true)]
        public Instant Time { get; set; }

        [ApiMember(Description="The value of the point. Null or empty to represent a NaN")]
        public double? Value { get; set; }
    }

    public enum TimeSeriesType
    {
        Unknown,
        ProcessorBasic,
        ProcessorDerived,
        External,
    }

    public class TimeSeriesVersion
    {
        public long DataVersion { get; set; }
    }

    public class CorrectionMetadata
        : CorrectionMetadataWithoutPoints
    {
        public IList<TimeSeriesPoint> Points { get; set; }
    }

    public class CorrectionMetadataWithoutPoints
        : MetadataBase
    {
        public CorrectionType CorrectionType { get; set; }
        public CorrectionProcessingOrder ProcessingOrder { get; set; }
        public long StackPosition { get; set; }
        public string Comments { get; set; }
        public IDictionary<string, string> Parameters { get; set; }
    }

    public class GapToleranceMetadata
        : StackResolvingMetadataBase
    {
        public Duration Tolerance { get; set; }
    }

    public class GradeMetadata
        : StackResolvingMetadataBase
    {
        public int GradeCode { get; set; }
    }

    public class InterpolationTypeMetadata
        : StackResolvingMetadataBase
    {
        public InterpolationType InterpolationType { get; set; }
    }

    public class MetadataBase
    {
        public Interval TimeRange { get; set; }
        public string AppliedByUserName { get; set; }
        public Instant CreateTime { get; set; }
    }

    public class MethodMetadata
        : StackResolvingMetadataBase
    {
        public string MethodCode { get; set; }
    }

    public class NoteMetadata
        : OverlappingMetadataBase
    {
        public string NoteText { get; set; }
    }

    public class OverlappingMetadataBase
        : MetadataBase
    {
    }

    public class QualifierMetadata
        : OverlappingMetadataBase
    {
        public string QualifierCode { get; set; }
    }

    public class RawPointAppendUserResolvedMetadata
        : StackResolvingResolvedMetadataBase
    {
        public string AppendUserName { get; set; }
    }

    public class StackResolvingMetadataBase
        : MetadataBase
    {
        public long StackPosition { get; set; }
        public string Comments { get; set; }
    }

    public class StackResolvingResolvedMetadataBase
    {
        public Interval TimeRange { get; set; }
    }

    [Route("/timeseries/{TimeSeriesId}/append", "POST")]
    public class AppendToTimeSeriesRequest
        : IReturn<AppendToTimeSeriesResponse>
    {
        public AppendToTimeSeriesRequest()
        {
            CsvData = new byte[]{};
        }

        public long TimeSeriesId { get; set; }
        public byte[] CsvData { get; set; }
    }

    [Route("/timeseries/{TimeSeriesId}/metadata/corrected", "POST")]
    public class CreateCorrectedChangeSetRequest
        : IReturn<TimeSeriesInfo>
    {
        public long TimeSeriesId { get; set; }
        public string CreatedByUser { get; set; }
        public long AsOfRawVersion { get; set; }
        public long AsOfCorrectedVersion { get; set; }
        public IList<GapToleranceMetadata> GapToleranceCreations { get; set; }
        public IList<GapToleranceMetadata> GapToleranceDeletions { get; set; }
        public IList<GradeMetadata> GradeCreations { get; set; }
        public IList<GradeMetadata> GradeDeletions { get; set; }
        public IList<MethodMetadata> MethodCreations { get; set; }
        public IList<MethodMetadata> MethodDeletions { get; set; }
        public IList<InterpolationTypeMetadata> InterpolationTypeCreations { get; set; }
        public IList<InterpolationTypeMetadata> InterpolationTypeDeletions { get; set; }
        public IList<NoteMetadata> NoteCreations { get; set; }
        public IList<NoteMetadata> NoteDeletions { get; set; }
        public IList<QualifierMetadata> QualifierCreations { get; set; }
        public IList<QualifierMetadata> QualifierDeletions { get; set; }
        public IList<CorrectionMetadata> CorrectionCreations { get; set; }
        public IList<CorrectionMetadataWithoutPoints> CorrectionDeletions { get; set; }
    }

    [Route("/timeseries/{TargetTimeSeriesId}/session", "POST")]
    public class CreateDataCorrectionSessionRequest
        : IReturn<DataCorrectionSession>
    {
        public CreateDataCorrectionSessionRequest()
        {
            ChartAxes = new List<DataCorrectionChartAxis>{};
        }

        [Required]
        public string SessionName { get; set; }

        public string Description { get; set; }
        public long TargetTimeSeriesId { get; set; }
        [Required]
        public List<DataCorrectionChartAxis> ChartAxes { get; set; }
    }

    [Route("/location/{LocationId}/timeseries/processorbasic", "POST")]
    public class CreateProcessorBasicTimeSeriesRequest
        : IReturn<TimeSeriesInfo>
    {
        public long LocationId { get; set; }
        public long? SubLocationId { get; set; }
        public string Label { get; set; }
        public string ParameterId { get; set; }
        public string UnitId { get; set; }
        public Offset UtcOffset { get; set; }
        public string MethodCode { get; set; }
        public string Comment { get; set; }
        public string Description { get; set; }
        public bool Publish { get; set; }
        public string ComputationIdentifier { get; set; }
        public string ComputationPeriodIdentifier { get; set; }
        public InterpolationType InterpolationType { get; set; }
        public Duration GapTolerance { get; set; }
        public IList<ExtendedAttributeFieldValue> ExtendedAttributeValues { get; set; }
    }

    [Route("/location/{LocationId}/timeseries/processorderived", "POST")]
    public class CreateProcessorDerivedTimeSeriesRequest
        : IReturn<TimeSeriesInfo>
    {
        public long LocationId { get; set; }
        public long? SubLocationId { get; set; }
        public string Label { get; set; }
        public string ParameterId { get; set; }
        public string UnitId { get; set; }
        public Offset UtcOffset { get; set; }
        public string Comment { get; set; }
        public string Description { get; set; }
        public bool Publish { get; set; }
        public string ComputationIdentifier { get; set; }
        public string ComputationPeriodIdentifier { get; set; }
        public InterpolationType InterpolationType { get; set; }
        public IList<TimeSeriesProcessingPlanEntry> ProcessingPlan { get; set; }
        public IList<ExtendedAttributeFieldValue> ExtendedAttributeValues { get; set; }
    }

    [Route("/timeseries/{TimeSeriesId}/appendversion/{AppendVersion}")]
    public class DeleteAppendRequest
        : IReturn<DeleteAppendResponse>
    {
        public long TimeSeriesId { get; set; }
        public long AppendVersion { get; set; }
    }

    [Route("/timeseries/{TargetTimeSeriesId}/session/{SessionGuid}", "DELETE")]
    public class DeleteDataCorrectionSessionRequest
    {
        public long TargetTimeSeriesId { get; set; }
        public Guid SessionGuid { get; set; }
    }

    [Route("/timeseries/{TimeSeriesId}", "DELETE")]
    public class DeleteTimeSeriesRequest
        : IReturnVoid
    {
        public long TimeSeriesId { get; set; }
    }

    [Route("/timeseries/{TargetTimeSeriesId}/sessions", "GET")]
    public class GetAllDataCorrectionSessionsForTimeSeriesRequest
        : IReturn<IReadOnlyCollection<DataCorrectionSession>>
    {
        public long TargetTimeSeriesId { get; set; }
    }

    [Route("/timeseries/{TimeSeriesId}/metadata/correction/corrected/getpoints", "POST")]
    public class GetCorrectionPointsRequest
        : IReturn<IList<IList>>
    {
        public long TimeSeriesId { get; set; }
        public long AsOfVersion { get; set; }
        public IList<CorrectionMetadataWithoutPoints> ForCorrections { get; set; }
    }

    [Route("/timeseries/{TargetTimeSeriesId}/session/{SessionGuid}", "GET")]
    public class GetDataCorrectionSessionRequest
        : IReturn<DataCorrectionSession>
    {
        public long TargetTimeSeriesId { get; set; }
        public Guid SessionGuid { get; set; }
    }

    [Route("/migration/processor/outputinterpolationtype", "POST")]
    public class GetOutputInterpolationType
        : IReturn<InterpolationType>
    {
        public IList<TimeSeriesProcessingPlanEntry> ProcessingPlans { get; set; }
    }

    [Route("/timeseries/{TimeSeriesId}/points/raw/appenduser", "GET")]
    public class GetRawPointAppendUserResolvedMetadataRequest
        : IReturn<IList<RawPointAppendUserResolvedMetadata>>
    {
        public long TimeSeriesId { get; set; }
        public long AsOfVersion { get; set; }
        public Interval TimeRange { get; set; }
    }

    [Route("/timeseries/{TimeSeriesId}/metadata/{MetadataType}/resolved/corrected", "GET")]
    public class GetResolvedCorrectedMetadataRequest
        : IReturn<Object>
    {
        public long TimeSeriesId { get; set; }
        public string MetadataType { get; set; }
        public long AsOfRawVersion { get; set; }
        public long AsOfCorrectedVersion { get; set; }
    }

    [Route("/timeseries/{TimeSeriesId}/metadata/{MetadataType}/resolved/raw", "GET")]
    public class GetResolvedRawMetadataRequest
        : IReturn<Object>
    {
        public long TimeSeriesId { get; set; }
        public string MetadataType { get; set; }
        public long AsOfVersion { get; set; }
    }

    [Route("/timeseries/{TimeSeriesId}/append/{AppendRequestIdentifier}", "GET")]
    public class GetTimeSeriesAppendStatusRequest
        : IReturn<TimeSeriesAppendStatus>
    {
        public long TimeSeriesId { get; set; }
        public string AppendRequestIdentifier { get; set; }
    }

    [Route("/timeseries/{TimeSeriesId}/approvals/snapshots", "GET")]
    public class GetTimeSeriesApprovalSnapshotsRequest
        : IReturn<IList<ApprovalSnapshot>>
    {
        public long TimeSeriesId { get; set; }
        public long AsOfCorrectedVersion { get; set; }
    }

    [Route("/migration/timeseries", "GET")]
    public class GetTimeSeriesByMigrationIdentifierRequest
        : IReturn<TimeSeriesInfo>
    {
        public string Identifier { get; set; }
    }

    [Route("/timeseries/{TimeSeriesId}/points/corrected", "GET")]
    public class GetTimeSeriesCorrectedPointsRequest
        : IReturn<IList<TimeSeriesPoint>>
    {
        public long TimeSeriesId { get; set; }
        public long AsOfRawVersion { get; set; }
        public long AsOfCorrectedVersion { get; set; }
        public DateTimeOffset? QueryFrom { get; set; }
        public DateTimeOffset? QueryTo { get; set; }
    }

    [Route("/timeseries/extendedattributes/schema", "GET")]
    public class GetTimeSeriesExtendedAttributeSchemaRequest
        : IReturn<IList<ExtendedAttributeFieldDefinition>>
    {
    }

    [Route("/location/{LocationId}/timeseries", "GET")]
    public class GetTimeSeriesForLocationRequest
        : IReturn<List<TimeSeriesInfo>>
    {
        public long LocationId { get; set; }
    }

    [Route("/timeseries/{TimeSeriesId}/processingplan/status", "GET")]
    public class GetTimeSeriesProcessingPlanStatus
        : IReturn<ProcessingPlanStatus>
    {
        public long TimeSeriesId { get; set; }
    }

    [Route("/timeseries/{TimeSeriesId}/points/raw", "GET")]
    public class GetTimeSeriesRawPointsRequest
        : IReturn<IList<TimeSeriesPoint>>
    {
        public long TimeSeriesId { get; set; }
        public long AsOfRawVersion { get; set; }
    }

    [Route("/timeseries/{TimeSeriesId}", "GET")]
    public class GetTimeSeriesRequest
        : IReturn<TimeSeriesDetails>
    {
        public long TimeSeriesId { get; set; }
    }

    [Route("/timeseries/{TimeSeriesId}/metadata/{MetadataType}/{ContentType}", "GET")]
    public class GetUnresolvedMetadataRequest
        : IReturn<Object>
    {
        public long TimeSeriesId { get; set; }
        public string MetadataType { get; set; }
        public string ContentType { get; set; }
        public long AsOfVersion { get; set; }
    }

    [Route("/timeseries/{TimeSeriesId}/overwrite", "POST")]
    public class OverwriteAppendToTimeSeriesRequest
        : IReturn<AppendToTimeSeriesResponse>
    {
        public OverwriteAppendToTimeSeriesRequest()
        {
            CsvData = new byte[]{};
        }

        public long TimeSeriesId { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
        public byte[] CsvData { get; set; }
    }

    [Route("/migration/timeseries/{TimeSeriesId}/metadata/{ContentType}", "POST")]
    public class SaveInitialMetadataRequest
        : IReturnVoid
    {
        public long TimeSeriesId { get; set; }
        public ContentType ContentType { get; set; }
        public string CreatedByUser { get; set; }
        public IList<GapToleranceMetadata> GapTolerances { get; set; }
        public IList<GradeMetadata> Grades { get; set; }
        public IList<MethodMetadata> Methods { get; set; }
        public IList<InterpolationTypeMetadata> InterpolationTypes { get; set; }
        public IList<NoteMetadata> Notes { get; set; }
        public IList<QualifierMetadata> Qualifiers { get; set; }
        public IList<CorrectionMetadata> Corrections { get; set; }
    }

    [Route("/migration/timeseries/{TimeSeriesId}/points", "POST")]
    public class SetRawPointsRequest
        : IReturnVoid
    {
        public long TimeSeriesId { get; set; }
        public string CreatedByUser { get; set; }
        public IList<TimeSeriesPoint> Points { get; set; }
    }

    [Route("/timeseries/{TimeSeriesId}/metadata/default/gaptolerance", "POST")]
    public class SetTimeSeriesDefaultGapToleranceMetadataRequest
        : IReturnVoid
    {
        public long TimeSeriesId { get; set; }
        public Duration GapTolerance { get; set; }
        public DateTimeOffset StartTime { get; set; }
    }

    [Route("/timeseries/{TimeSeriesId}/metadata/default/method", "POST")]
    public class SetTimeSeriesDefaultMethodMetadataRequest
        : IReturnVoid
    {
        public long TimeSeriesId { get; set; }
        public string MethodCode { get; set; }
        public DateTimeOffset StartTime { get; set; }
    }

    [Route("/timeseries/{TargetTimeSeriesId}/session/{SessionGuid}", "PUT")]
    public class UpdateDataCorrectionSessionRequest
        : IReturn<DataCorrectionSession>
    {
        public UpdateDataCorrectionSessionRequest()
        {
            ChartAxes = new List<DataCorrectionChartAxis>{};
        }

        [Required]
        public string SessionName { get; set; }

        public string Description { get; set; }
        public long TargetTimeSeriesId { get; set; }
        public Guid SessionGuid { get; set; }
        [Required]
        public List<DataCorrectionChartAxis> ChartAxes { get; set; }
    }

    [Route("/timeseries/{TimeSeriesId}", "PUT")]
    public class UpdateTimeSeriesAttributesRequest
        : IReturn<TimeSeriesInfo>
    {
        public long TimeSeriesId { get; set; }
        public TimeSeriesVersion RowVersion { get; set; }
        public long? SubLocationId { get; set; }
        public string Label { get; set; }
        public string Comment { get; set; }
        public string Description { get; set; }
        public bool Publish { get; set; }
        public IList<ExtendedAttributeFieldValue> ExtendedAttributeValues { get; set; }
    }

    public class AppendToTimeSeriesResponse
    {
        public ResponseStatus ResponseStatus { get; set; }
        public string AppendRequestIdentifier { get; set; }
    }

    public class DeleteAppendResponse
    {
        public ResponseStatus ResponseStatus { get; set; }
        public long DeletedPointsCount { get; set; }
    }

    public class Interval
        : ValueType
    {
    }

    public enum AxisPosition
    {
        Left,
        Right,
        Both,
    }

    public enum DataCorrectionAxisType
    {
        Target,
        Surrogate,
    }

    public class DataCorrectionChartAxis
    {
        public DataCorrectionChartAxis()
        {
            TimeSeriesOnAxis = new List<TimeSeriesOnChartAxis>{};
        }

        public ObjectId ChartAxisId { get; set; }
        public DataCorrectionAxisType AxisType { get; set; }
        public string AxisLabel { get; set; }
        public ScaleType ScaleType { get; set; }
        public AxisPosition AxisPosition { get; set; }
        public ScaleMethod ScaleMethod { get; set; }
        public double Minimum { get; set; }
        public double Maximum { get; set; }
        public double LogarithmCycles { get; set; }
        public List<TimeSeriesOnChartAxis> TimeSeriesOnAxis { get; set; }
    }

    public class DataCorrectionSession
        : DataCorrectionSessionBase
    {
        public Instant CreatedAtTimeUTC { get; set; }
        public Guid SessionGuid { get; set; }
    }

    public class DataCorrectionSessionBase
    {
        public DataCorrectionSessionBase()
        {
            ChartAxes = new List<DataCorrectionChartAxis>{};
        }

        public string SessionName { get; set; }
        public string Description { get; set; }
        public ObjectId TargetTimeSeriesId { get; set; }
        public ObjectId CreatedByUserId { get; set; }
        public List<DataCorrectionChartAxis> ChartAxes { get; set; }
    }

    public enum PointType
    {
        Raw,
        Corrected,
    }

    public enum ScaleMethod
    {
        AutoScale,
        AutoScaleToCorrected,
        AutoScaleToTarget,
        ManualScale,
        LogScaleCyclesFromMinimum,
        LogScaleCyclesFromMaximum,
    }

    public enum ScaleType
    {
        Linear,
        LinearInverted,
        Logarithmic,
    }

    public class TimeSeriesOnChartAxis
    {
        public ObjectId TimeSeriesId { get; set; }
        public PointType PointType { get; set; }
    }

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

    public class SearchResultsBase<T>
    {
        public SearchResultsBase()
        {
            Results = new List<T>{};
        }

        public List<T> Results { get; set; }
        public bool LimitExceeded { get; set; }
    }
}

