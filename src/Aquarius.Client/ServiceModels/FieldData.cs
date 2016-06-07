// Generated from: {"ApiVersion":"16.1.101.0"}
/* Options:
Date: 2016-06-06 17:45:21
Version: 4.054
Tip: To override a DTO option, remove "//" prefix before updating
BaseUrl: http://doug-vm2012r2/AQUARIUS/apps/v1

GlobalNamespace: Aquarius.Client.ServiceModels.FieldData
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


namespace Aquarius.Client.ServiceModels.FieldData
{

    public enum ActivityType
    {
        Unknown,
        GageZeroFlow,
        Discharge,
        ControlCondition,
        Inspection,
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
        Volumetric,
        PointVelocity,
        Flume,
        Adcp,
        OtherMethod,
    }

    public enum FlowDirectionType
    {
        Unknown,
        Normal,
        Reversed,
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
        Other,
    }

    public enum MeasurementCondition
    {
        Unknown,
        OpenWater,
        IceCovered,
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
        Handline,
        RigidBoatMount,
        TetheredBoat,
        IceSurfaceMount,
    }

    public enum MeterType
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

    public enum PointVelocityMethodType
    {
        Unknown,
        MidSection,
        MeanSection,
    }

    public enum PointVelocityObservationType
    {
        Unknown,
        OneAtPointFive,
        OneAtPointSix,
        OneAtPointTwoAndPointEight,
        OneAtPointTwoPointSixAndPointEight,
        FivePoint,
        SixPoint,
        ElevenPoint,
        Surface,
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
        UltrasonicMeter,
    }

    public enum VelocityVariationType
    {
        Unknown,
        Unspecified,
        Steady,
        Pulsating,
    }

    public enum VerticalType
    {
        Unknown,
        MidRiver,
        StartEdgeNoWaterBefore,
        EndEdgeNoWaterAfter,
    }

    public enum VerticalVelocityDistributionType
    {
        Unknown,
        Unspecified,
        Uniform,
        Standard,
        NonStandard,
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

    public enum ApprovalPropagation
    {
        Unknown,
        AllRelatedDatasets,
        MinimumRequiredDatasets,
    }

    public enum AttachmentFilterType
    {
        Unknown,
        Visuals,
        NonVisuals,
        GeneratedReports,
        LoggerFiles,
    }

    public enum ConditionType
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

    public enum ContentType
    {
        Points,
        Statistics,
        CorrectionHistory,
        MetadataGlossary,
    }

    public enum ControlCleanedType
    {
        Unknown,
        Unspecified,
        ControlCleaned,
        ControlNotCleaned,
    }

    public enum DatasetEra
    {
        Standard,
        Legacy,
        All,
    }

    public enum DatasetType
    {
        Unknown,
        DiscreteTimeSeries,
        ExternalTimeSeries,
        ProcessorBasic,
        ProcessorDerived,
        RatingCurve,
    }

    public enum DragAndDropAppendJobStatus
    {
        Unknown,
        Rejected,
        Uploaded,
        Parsing,
        Complete,
    }

    public enum EngineeredStructureType
    {
        Unknown,
        Flume,
        Weir,
        Other,
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

    public enum LogLevel
    {
        Debug,
        Info,
        Warning,
        Error,
        Fatal,
    }

    public enum MetadataType
    {
        Raw,
        Corrected,
    }

    public enum ProcessingStatus
    {
        Pending,
        Completed,
        Failed,
    }

    public enum ReadingCategory
    {
        None,
        All,
        StandardQa,
        ExtremeValues,
        Discharge,
        FinalReadings,
    }

    public enum ThresholdSuppressionOption
    {
        Unknown,
        On,
        Off,
        Editable,
    }

    public enum ThresholdType
    {
        Unknown,
        ThresholdAbove,
        ThresholdBelow,
        None,
    }

    public enum TimeSeriesReadingEnum // TODO: Manual edit required here: "TimeSeriesReadingType" => "TimeSeriesReadingEnum" to avoid conflict of non-enum type with same name
    {
        Unknown = 1,
        Routine = 2,
        ResetBefore = 3,
        ResetAfter = 4,
        CleaningBefore = 5,
        CleaningAfter = 6,
        AfterCalibration = 7,
        ReferencePrimary = 8,
        Reference = 9,
        MeanGageHeight = 10,
        ExtremeMin = 11,
        ExtremeMax = 12,
        Discharge = 13,
        MeanIndexVelocity = 14,
    }

    public enum ViewModeType
    {
        Unknown,
        StandardView,
        DataDescriptorView,
    }

    public interface IDischargeSubActivity
    {
    }

    [Route("/activities/{Id}", "DELETE")]
    public class DeleteActivity
        : IReturnVoid
    {
        public long Id { get; set; }
    }

    [Route("/activities/{Id}", "GET")]
    public class GetActivity
        : IReturn<Activity>
    {
        public long Id { get; set; }
    }

    [Route("/activities/previous", "GET")]
    public class GetPreviousActivity
        : IReturn<DateTime?>
    {
        public long LocationId { get; set; }
        public string Type { get; set; }
        public DateTime? Date { get; set; }
    }

    [Route("/activities", "PUT")]
    public class PutActivity
        : IReturnVoid
    {
        public Activity Activity { get; set; }
    }

    [Route("/adcpdischarges/{Id}", "DELETE")]
    public class DeleteAdcpDischarge
        : IReturnVoid
    {
        public long Id { get; set; }
    }

    [Route("/adcpdischarges/{Id}", "GET")]
    public class GetAdcpDischarge
        : IReturn<AdcpDischarge>
    {
        public long Id { get; set; }
    }

    [Route("/adcpdischarges", "POST")]
    public class PostAdcpDischarge
        : IReturn<AdcpDischarge>
    {
        public AdcpDischarge AdcpDischarge { get; set; }
        public DischargeChannelMeasurement ChannelMeasurement { get; set; }
        public long VisitId { get; set; }
    }

    [Route("/adcpdischarges", "PUT")]
    public class PutAdcpDischarge
        : IReturn<AdcpDischarge>
    {
        public AdcpDischarge AdcpDischarge { get; set; }
        public DischargeChannelMeasurement ChannelMeasurement { get; set; }
    }

    [Route("/locations/{Id}/attachments", "DELETE")]
    public class DeleteAllLocationAttachments
        : IReturn<int>
    {
        public long Id { get; set; }
    }

    [Route("/attachments/{Id}", "DELETE")]
    public class DeleteAttachment
        : IReturn<Attachment>
    {
        public string Id { get; set; }
    }

    [Route("/locations/{Id}/trash", "DELETE")]
    public class DeleteLocationTrash
        : IReturnVoid
    {
        public long Id { get; set; }
        public AttachmentFilterType Filter { get; set; }
    }

    [Route("/attachments/trash/{Id}", "DELETE")]
    public class DeleteTrashedAttachment
        : IReturnVoid
    {
        public string Id { get; set; }
    }

    [Route("/visits/{Id}/trash", "DELETE")]
    public class DeleteVisitTrash
        : IReturnVoid
    {
        public long Id { get; set; }
        public AttachmentFilterType Filter { get; set; }
    }

    [Route("/attachments/{Id}", "GET")]
    public class GetAttachment
        : IReturn<Attachment>
    {
        public string Id { get; set; }
    }

    [Route("/attachments/{Id}/download", "GET")]
    public class GetAttachmentDownload
    {
        public string Id { get; set; }
        public bool AsAttachment { get; set; }
    }

    [Route("/locations/{Id}/attachments", "GET")]
    public class GetLocationAttachments
        : IReturn<List<Attachment>>
    {
        public long Id { get; set; }
        public AttachmentFilterType Filter { get; set; }
    }

    [Route("/locations/{Id}/trash", "GET")]
    public class GetLocationTrash
        : IReturn<List<Attachment>>
    {
        public long Id { get; set; }
        public AttachmentFilterType Filter { get; set; }
    }

    [Route("/locations/{Id}/visitattachments", "GET")]
    public class GetLocationVisitAttachments
        : IReturn<List<Attachment>>
    {
        public long Id { get; set; }
        public AttachmentFilterType Filter { get; set; }
    }

    [Route("/visits/{Id}/attachments", "GET")]
    public class GetVisitAttachments
        : IReturn<List<Attachment>>
    {
        public long Id { get; set; }
        public AttachmentFilterType Filter { get; set; }
    }

    [Route("/visits/{Id}/trash", "GET")]
    public class GetVisitTrash
        : IReturn<List<Attachment>>
    {
        public long Id { get; set; }
        public AttachmentFilterType Filter { get; set; }
    }

    public class PostAttachmentBase
        : PostFineUploaderBase
    {
        public DateTime? LastModifiedDate { get; set; }
        public bool DisableParsing { get; set; }
        public AttachmentType? ForcedAttachmentType { get; set; }
        public AttachmentCategory? ForcedAttachmentCategory { get; set; }
    }

    [Route("/locations/{LocationId}/attachments/upload", "POST")]
    public class PostLocationAttachment
        : PostAttachmentBase, IReturn<string>
    {
        public long LocationId { get; set; }
    }

    [Route("/locations/{LocationId}/loggerfiles/upload", "POST")]
    public class PostLocationLoggerFile
        : IReturn<Attachment>
    {
        public long LocationId { get; set; }
    }

    [Route("/visits/{VisitId}/attachments/upload", "POST")]
    public class PostVisitAttachment
        : PostAttachmentBase, IReturn<string>
    {
        public long VisitId { get; set; }
    }

    [Route("/attachments", "PUT")]
    public class PutAttachment
        : IReturn<Attachment>
    {
        public Attachment Attachment { get; set; }
    }

    [Route("/attachments/trash/{Id}", "PUT")]
    public class PutTrashedAttachment
        : IReturn<Attachment>
    {
        public string Id { get; set; }
    }

    [Route("/visits/{Id}/autocorrections", "POST")]
    public class PostAutomaticCorrection
        : IReturn<AppliedCorrection>
    {
        public PostAutomaticCorrection()
        {
            EquationMarkup = new List<string>{};
        }

        public long Id { get; set; }
        public long TimeSeriesId { get; set; }
        public long? SubLocationId { get; set; }
        public string ParameterId { get; set; }
        public string MethodCode { get; set; }
        public string Comment { get; set; }
        public List<string> EquationMarkup { get; set; }
        public ThreePointCorrection FoulingCorrection { get; set; }
        public ThreePointCorrection CalibrationCorrection { get; set; }
    }

    [Route("/channelmeasurements/{Id}", "DELETE")]
    public class DeleteChannelMeasurement
        : IReturnVoid
    {
        public long Id { get; set; }
    }

    [Route("/channelmeasurements/{Id}", "GET")]
    public class GetChannelMeasurement
        : IReturn<DischargeChannelMeasurement>
    {
        public long Id { get; set; }
    }

    [Route("/discharges/{Id}/channelmeasurements", "GET")]
    public class GetDischargeChannelMeasurements
        : IReturn<List<DischargeChannelMeasurement>>
    {
        public long Id { get; set; }
    }

    [Route("/channelmeasurements", "POST")]
    public class PostChannelMeasurement
        : IReturn<DischargeChannelMeasurement>
    {
        public DischargeChannelMeasurement ChannelMeasurement { get; set; }
        public long VisitId { get; set; }
    }

    [Route("/channelmeasurements", "PUT")]
    public class PutChannelMeasurement
        : IReturnVoid
    {
        public DischargeChannelMeasurement ChannelMeasurement { get; set; }
        public bool ValidateDischargeSubActivity { get; set; }
    }

    [Route("/channels/{Id}", "DELETE")]
    public class DeleteChannel
        : IReturnVoid
    {
        public long Id { get; set; }
    }

    [Route("/channels/{Id}", "GET")]
    public class GetChannel
        : IReturn<Channel>
    {
        public long Id { get; set; }
    }

    [Route("/locations/{Id}/channels", "GET")]
    public class GetLocationChannels
        : IReturn<List<Channel>>
    {
        public long Id { get; set; }
    }

    [Route("/channels", "POST")]
    public class PostChannel
        : IReturn<Channel>
    {
        public Channel Channel { get; set; }
    }

    [Route("/channels", "PUT")]
    public class PutChannel
        : IReturnVoid
    {
        public Channel Channel { get; set; }
    }

    [Route("/client/installer", "GET")]
    public class GetClientInstaller
    {
    }

    [Route("/logs/client", "POST")]
    public class PostClientLogMessage
        : IReturnVoid
    {
        public string Message { get; set; }
        public LogLevel Level { get; set; }
    }

    [Route("/computation/periods", "GET")]
    public class GetAllComputationPeriods
        : IReturn<List<ComputationPeriod>>
    {
    }

    [Route("/computation/types", "GET")]
    public class GetAllComputationTypes
        : IReturn<List<ComputationType>>
    {
    }

    [Route("/computation/processable/periods", "GET")]
    public class GetProcessableComputationPeriods
        : IReturn<List<ProcessableComputationPeriod>>
    {
    }

    [Route("/computation/processable/types", "GET")]
    public class GetProcessableComputationTypes
        : IReturn<List<ProcessableComputationType>>
    {
    }

    [Route("/config/fielddata", "GET")]
    public class GetFieldDataConfiguration
        : IReturn<FieldDataConfiguration>
    {
    }

    [Route("/config/locationmanager", "GET")]
    public class GetLocationManagerConfiguration
        : IReturn<LocationManagerConfiguration>
    {
    }

    [Route("/config/reporting", "GET")]
    public class GetReportingConfiguration
        : IReturn<ReportingConfiguration>
    {
    }

    [Route("/config/springboard", "GET")]
    public class GetSpringboardConfiguration
        : IReturn<SpringboardConfiguration>
    {
    }

    [Route("/controlconditions/{Id}", "DELETE")]
    public class DeleteControlCondition
        : IReturnVoid
    {
        public long Id { get; set; }
    }

    [Route("/controlconditions/{id}", "GET")]
    public class GetControlCondition
        : IReturn<ControlConditionActivity>
    {
        public long Id { get; set; }
    }

    [Route("/controlconditions", "POST")]
    public class PostControlCondition
        : IReturn<ControlConditionActivity>
    {
        public ControlConditionActivity ControlCondition { get; set; }
        public long VisitId { get; set; }
    }

    [Route("/controlconditions/", "PUT")]
    public class PutControlCondition
        : IReturnVoid
    {
        public ControlConditionActivity ControlCondition { get; set; }
    }

    public enum DatasetFilter
    {
        None,
        TimeSeries,
        RatingCurve,
    }

    [Route("/datasets/thresholds/{Id}", "DELETE")]
    public class DeleteTimeSeriesThresholdById
        : IReturnVoid
    {
        public long Id { get; set; }
    }

    [Route("/approvaljobs/{Id}", "GET")]
    public class GetApprovalJob
        : IReturn<DatasetApprovalSaveResult>
    {
        public long Id { get; set; }
    }

    [Route("/datasets/{Id}", "GET")]
    public class GetDataset
        : IReturn<Dataset>
    {
        public long Id { get; set; }
    }

    [Route("/datasets/{Id}/approvals", "GET")]
    public class GetDatasetApprovals
        : TimeRangeDatasetRequestBase, IReturn<List<ApprovalRange>>
    {
    }

    [Route("/dataset/{Id}/extendedattributes", "GET")]
    public class GetDatasetExtendedAttributes
        : IReturn<List<DatasetExtendedAttribute>>
    {
        public long Id { get; set; }
    }

    [Route("/datasets", "GET")]
    public class GetDatasets
        : GetDatasetsBase, IReturn<List<Dataset>>
    {
    }

    public class GetDatasetsBase
    {
        [DataMember(Name="filter")]
        public DatasetFilter Filter { get; set; }
    }

    [Route("/datasetviews/{ViewMode}/datasets", "GET")]
    public class GetDatasetsByViewMode
        : IReturn<List<Dataset>>
    {
        public GetDatasetsByViewMode()
        {
            LocationIds = new List<long>{};
        }

        public ViewModeType ViewMode { get; set; }
        [DataMember(Name="locationids")]
        public List<long> LocationIds { get; set; }
    }

    [Route("/locations/{Id}/datasets", "GET")]
    public class GetLocationDatasets
        : GetDatasetsBase, IReturn<List<Dataset>>
    {
        public long Id { get; set; }
    }

    [Route("/ratingmodels/{Id}", "GET")]
    public class GetRatingCurveDataset
        : IReturn<Dataset>
    {
        public long Id { get; set; }
    }

    [Route("/datasets/{Id}/readings")]
    public class GetReadingsByTimeSeriesId
        : IReturn<IList<TimeSeriesReading>>
    {
        public long Id { get; set; }
        public ReadingCategory ReadingCategory { get; set; }
    }

    [Route("/datasets/{Id}/readings/types")]
    public class GetReadingTypesByTimeSeriesId
        : IReturn<IList<TimeSeriesReadingType>>
    {
        public long Id { get; set; }
    }

    [Route("/datasets/{Id}/relateddatasets", "GET")]
    public class GetRelatedDatasets
        : TimeRangeDatasetRequestBase, IReturn<List<RelatedDataset>>
    {
        public long TargetApprovalLevelId { get; set; }
    }

    public class GetSearchDatasetsBase
        : GetSearchResultsBase
    {
        [DataMember(Name="LocationId")]
        public long? LocationId { get; set; }

        [DataMember(Name="DatasetEra")]
        public DatasetEra DatasetEra { get; set; }
    }

    [Route("/ratingmodels/search", "GET")]
    [DataContract]
    public class GetSearchRatingModels
        : GetSearchDatasetsBase, IReturn<SearchResultsBase<Dataset>>
    {
    }

    [Route("/datasets/search", "GET")]
    [DataContract]
    public class GetSearchTimeSeries
        : GetSearchDatasetsBase, IReturn<SearchResultsBase<Dataset>>
    {
    }

    [Route("/timeseries/search", "GET")]
    [DataContract]
    public class GetSearchTimeSeriesInfo
        : GetSearchDatasetsBase, IReturn<SearchResultsBase<Dataset>>
    {
    }

    [Route("/datasets/{Id}/thresholds", "GET")]
    public class GetThresholdsByTimeSeriesId
        : IReturn<List<TimeSeriesThreshold>>
    {
        public long Id { get; set; }
    }

    [Route("/datasets/thresholds/{Id}", "GET")]
    public class GetTimeSeriesThresholdById
        : IReturn<TimeSeriesThreshold>
    {
        public long Id { get; set; }
    }

    [Route("/datasets/thresholds", "GET")]
    public class GetTimeSeriesThresholdsByLocationIds
        : IReturn<List<DatasetWithThresholds>>
    {
        public GetTimeSeriesThresholdsByLocationIds()
        {
            LocationIds = new List<long>{};
        }

        [DataMember(Name="locationids")]
        public List<long> LocationIds { get; set; }
    }

    [Route("/datasets/{Id}/approval", "POST")]
    public class PostDatasetApproval
        : TimeRangeDatasetRequestBase, IReturn<DatasetApprovalSaveResult>
    {
        public string Comment { get; set; }
        public ApprovalPropagation ApprovalPropagation { get; set; }
        public long ApprovalLevelId { get; set; }
    }

    [Route("/datasets/thresholds", "POST")]
    public class PostTimeSeriesThreshold
        : IReturn<TimeSeriesThreshold>
    {
        public TimeSeriesThreshold TimeSeriesThreshold { get; set; }
    }

    [Route("/datasets/thresholds", "PUT")]
    public class PutTimeSeriesThreshold
        : IReturnVoid
    {
        public TimeSeriesThreshold TimeSeriesThreshold { get; set; }
    }

    public class TimeRangeDatasetRequestBase
    {
        public long Id { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }

    [Route("/datasets/thresholds/referencevaluecodes", "GET")]
    public class GetThresholdReferenceValuesCodes
        : IReturn<List<ThresholdReferenceValueCode>>
    {
    }

    [Route("/datasetviews/viewmodepicklist", "GET")]
    public class GetDatasetViewModePickList
        : IReturn<DatasetViewModePickList>
    {
    }

    [Route("/discharges/{Id}", "DELETE")]
    public class DeleteDischarge
        : IReturnVoid
    {
        public long Id { get; set; }
    }

    [Route("/discharges/{Id}", "GET")]
    public class GetDischarge
        : IReturn<DischargeActivity>
    {
        public long Id { get; set; }
    }

    [Route("/discharges", "POST")]
    public class PostDischarge
        : IReturn<DischargeActivity>
    {
        public DischargeActivity Discharge { get; set; }
        public long VisitId { get; set; }
        public string MeasurementId { get; set; }
    }

    [Route("/discharges", "PUT")]
    public class PutDischarge
        : IReturn<DischargeActivity>
    {
        public DischargeActivity Discharge { get; set; }
        public string MeasurementId { get; set; }
        public bool ValidateDischargeSubActivity { get; set; }
    }

    [Route("/export/timeseries/{TimeSeriesId}/{MetadataType}/{ContentType}/", "GET")]
    public class GetExportedTimeSeries
        : IReturn<IList<ExportedPoint>>
    {
        public long TimeSeriesId { get; set; }
        public MetadataType MetadataType { get; set; }
        public ContentType ContentType { get; set; }
        public Instant QueryFrom { get; set; }
        public Instant QueryTo { get; set; }
    }

    [Route("/fielddata/upload", "POST")]
    public class PostFieldDataUpload
        : PostFineUploaderBase, IReturn<string>
    {
        public long VisitId { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }

    public class PostFineUploaderBase
    {
        public string QqUuid { get; set; }
        public string QqFilename { get; set; }
        public long QqTotalFilesize { get; set; }
    }

    [Route("/flumedischarges/{Id}", "DELETE")]
    public class DeleteFlumeDischarge
        : IReturnVoid
    {
        public long Id { get; set; }
    }

    [Route("/flumedischarges/{Id}", "GET")]
    public class GetFlumeDischarge
        : IReturn<FlumeDischarge>
    {
        public long Id { get; set; }
    }

    [Route("/flumedischarges", "POST")]
    public class PostFlumeDischarge
        : IReturn<FlumeDischarge>
    {
        public FlumeDischarge FlumeDischarge { get; set; }
        public DischargeChannelMeasurement ChannelMeasurement { get; set; }
        public long VisitId { get; set; }
    }

    [Route("/flumedischarges", "PUT")]
    public class PutFlumeDischarge
        : IReturn<FlumeDischarge>
    {
        public FlumeDischarge FlumeDischarge { get; set; }
        public DischargeChannelMeasurement ChannelMeasurement { get; set; }
    }

    [Route("/zeroflows/{Id}", "DELETE")]
    public class DeleteGageZeroFlow
        : IReturnVoid
    {
        public long Id { get; set; }
    }

    [Route("/zeroflows/{Id}", "GET")]
    public class GetGageZeroFlow
        : IReturn<GageZeroFlowActivity>
    {
        public long Id { get; set; }
    }

    [Route("/zeroflows", "POST")]
    public class PostGageZeroFlow
        : IReturn<GageZeroFlowActivity>
    {
        public GageZeroFlowActivity GageZeroFlow { get; set; }
        public long VisitId { get; set; }
    }

    [Route("/zeroflows", "PUT")]
    public class PutGageZeroFlow
        : IReturnVoid
    {
        public GageZeroFlowActivity GageZeroFlow { get; set; }
    }

    [Route("/help/{Topic}", "GET")]
    public class GetHelpTopic
        : IReturn<HelpTopic>
    {
        public string Topic { get; set; }
    }

    [Route("/hotfolderjobs/{Id}", "GET")]
    public class GetDragAndDropAppendJob
        : IReturn<DragAndDropAppendJob>
    {
        public long Id { get; set; }
    }

    [Route("/hotfolders/{Id}", "GET")]
    public class GetHotFolder
        : IReturn<HotFolder>
    {
        public long Id { get; set; }
    }

    [Route("/hotfolders", "GET")]
    public class GetHotFolders
        : IReturn<List<HotFolder>>
    {
        public GetHotFolders()
        {
            LocationIds = new List<long>{};
        }

        [DataMember(Name="ids")]
        public List<long> LocationIds { get; set; }
    }

    [Route("/locations/{Id}/hotfolder", "GET")]
    public class GetLocationHotFolder
        : IReturn<HotFolder>
    {
        public long Id { get; set; }
    }

    [Route("/hotfolders/{Id}/upload", "POST")]
    public class PostHotFolderFile
        : PostFineUploaderBase, IReturn<string>
    {
        public long Id { get; set; }
    }

    [Route("/visits/{VisitId}/inspections", "GET")]
    public class GetVisitInspection
        : IReturn<VisitInspection>
    {
        public long VisitId { get; set; }
    }

    [Route("/visits/{VisitId}/inspections", "PUT")]
    public class PutVisitInspection
        : IReturn<VisitInspection>
    {
        public long VisitId { get; set; }
        public VisitInspection VisitInspection { get; set; }
    }

    [Route("/locationfolders/{id}/roles", "DELETE")]
    public class DeleteLocationFolderRole
        : IReturnVoid
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
    }

    [Route("/locationfolders", "GET")]
    public class GetAllLocationFolders
        : IReturn<LocationFolder>
    {
    }

    [Route("/locationfolders/{id}/effectiveroles", "GET")]
    public class GetEffectiveLocationFolderRoles
        : IReturn<IList<LocationFolderRole>>
    {
        public long Id { get; set; }
    }

    [Route("/locationfolders/root/primary", "GET")]
    public class GetRootPrimaryLocationFolder
        : IReturn<LocationFolder>
    {
    }

    [Route("/locationfolders/{id}/roles", "PUT")]
    public class PutLocationFolderRole
        : IReturn<LocationFolderRole>
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public long? RoleId { get; set; }
    }

    [Route("/locations/{id}/roles", "DELETE")]
    public class DeleteLocationRole
        : IReturnVoid
    {
        public long Id { get; set; }
        public long UserId { get; set; }
    }

    [Route("/locations/{id}/effectiveroles", "GET")]
    public class GetEffectiveLocationRoles
        : IReturn<IList<LocationRole>>
    {
        public long Id { get; set; }
    }

    [Route("/locations/{Id}", "GET")]
    public class GetLocation
        : IReturn<Location>
    {
        public long Id { get; set; }
    }

    [Route("/locations/{Id}/approvallevels", "GET")]
    public class GetLocationApprovalLevels
        : IReturn<ResolvedLocationRole>
    {
        public long Id { get; set; }
    }

    [Route("/locations/{Id}/extendedattributes", "GET")]
    public class GetLocationExtendedAttributes
        : IReturn<LocationWithExtendedAttributes>
    {
        public long Id { get; set; }
    }

    [Route("/locations", "GET")]
    public class GetLocations
        : IReturn<LocationQueryResult>
    {
        public GetLocations()
        {
            LocationIds = new List<long>{};
        }

        [DataMember(Name="ids")]
        public List<long> LocationIds { get; set; }
    }

    [Route("/locations/datasets", "GET")]
    [DataContract]
    public class GetLocationsFromDatasets
        : IReturn<List<Location>>
    {
        public GetLocationsFromDatasets()
        {
            DatasetIdentifiers = new List<string>{};
        }

        [DataMember(Name="ids")]
        public List<string> DatasetIdentifiers { get; set; }

        [DataMember(Name="filter")]
        public DatasetFilter Filter { get; set; }
    }

    [Route("/locations/visits", "GET")]
    [DataContract]
    public class GetLocationVisitsSummary
        : IReturn<List<LocationVisitsSummary>>
    {
        public GetLocationVisitsSummary()
        {
            LocationIds = new List<long>{};
        }

        [DataMember(Name="ids")]
        public List<long> LocationIds { get; set; }
    }

    [Route("/locations/{LocationId}/resolvedLocationRole", "GET")]
    public class GetResolvedLocationRole
        : IReturn<ResolvedLocationRole>
    {
        public long LocationId { get; set; }
    }

    [Route("/locations/search", "GET")]
    [DataContract]
    public class GetSearchLocations
        : GetSearchResultsBase, IReturn<SearchResultsBase<Location>>
    {
    }

    [Route("/locations/{id}/roles", "PUT")]
    public class PutLocationRole
        : IReturn<LocationRole>
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public long? RoleId { get; set; }
    }

    [Route("/meters/search", "GET")]
    public class GetSearchMeters
        : GetSearchResultsBase, IReturn<SearchResultsBase<MeterSearchResult>>
    {
    }

    [Route("/meters", "POST")]
    public class PostMeter
        : IReturn<MeterWithCalibration>
    {
        public MeterWithCalibration Meter { get; set; }
    }

    [Route("/meters", "PUT")]
    public class PutMeter
        : IReturn<MeterWithCalibration>
    {
        public MeterWithCalibration Meter { get; set; }
    }

    [Route("/locations/monitoringmethods/{Id}", "DELETE")]
    public class DeleteLocationMonitoringMethod
        : IReturnVoid
    {
        public long Id { get; set; }
    }

    [Route("/monitoringmethods", "GET")]
    public class GetAllMonitoringMethods
        : IReturn<List<MonitoringMethod>>
    {
    }

    [Route("/locations/monitoringmethods/{Id}", "GET")]
    public class GetLocationMonitoringMethod
        : IReturn<LocationMonitoringMethod>
    {
        public long Id { get; set; }
    }

    [Route("/monitorprogramview/locationmethods/{Id}", "GET")]
    public class GetLocationMonitoringMethodForDisplay
        : IReturn<LocationMonitoringMethodForDisplay>
    {
        public long Id { get; set; }
    }

    [Route("/locations/monitoringmethods", "GET")]
    public class GetLocationMonitoringMethodsByLocations
        : IReturn<List<LocationMonitoringMethod>>
    {
        public GetLocationMonitoringMethodsByLocations()
        {
            LocationIds = new List<long>{};
        }

        [DataMember(Name="locationids")]
        public List<long> LocationIds { get; set; }
    }

    [Route("/parameters/{Id}/monitoringmethods", "GET")]
    public class GetMonitoringMethodsByParameterId
        : IReturn<List<MonitoringMethod>>
    {
        public string Id { get; set; }
    }

    [Route("/locations/monitoringmethods", "POST")]
    public class PostLocationMonitoringMethod
        : IReturn<LocationMonitoringMethod>
    {
        public LocationMonitoringMethod LocationMonitoringMethod { get; set; }
    }

    [Route("/locations/monitoringmethods", "PUT")]
    public class PutLocationMonitoringMethod
        : IReturnVoid
    {
        public LocationMonitoringMethod LocationMonitoringMethod { get; set; }
    }

    [Route("/monitorprogramview/locationmethods", "GET")]
    public class SearchLocationMonitoringMethodForDisplay
        : IReturn<List<LocationMonitoringMethodForDisplay>>
    {
        public SearchLocationMonitoringMethodForDisplay()
        {
            LocationIds = new List<long>{};
        }

        [DataMember(Name="locationids")]
        public List<long> LocationIds { get; set; }
    }

    [Route("/parameters/convert", "GET")]
    public class GetConvertedValue
        : IReturn<ConvertedValue>
    {
        public string SourceUnitId { get; set; }
        public double SourceValue { get; set; }
        public string DestinationUnitId { get; set; }
    }

    [Route("/parameters/form", "GET")]
    public class GetFormParameters
        : IReturn<FormParameters>
    {
        public ActivityType ActivityType { get; set; }
        public DischargeMethodType DischargeMethodType { get; set; }
    }

    [Route("/parameter/{Id}", "GET")]
    public class GetParameter
        : IReturn<Parameter>
    {
        public string Id { get; set; }
        public string DestinationUnitId { get; set; }
    }

    [Route("/parameters/sanity", "GET")]
    public class GetParametersSanityReport
        : IReturn<SanityReport>
    {
    }

    [Route("/parameters/search", "GET")]
    public class GetSearchParameters
        : GetSearchResultsBase, IReturn<SearchResultsBase<Parameter>>
    {
    }

    [Route("/picklists/interpolationtype", "GET")]
    public class GetInterpolationTypePicklist
        : IReturn<InterpolationTypePicklist>
    {
    }

    [Route("/picklists/suspensioncodes", "GET")]
    public class GetSuspensionCodePicklist
        : IReturn<Picklist>
    {
        public string DischargeMethodCode { get; set; }
        public DeploymentMethodType DeploymentMethodCode { get; set; }
    }

    [Route("/picklists/timeseriesthreshold", "GET")]
    public class GetTimeSeriesThresholdPicklist
        : IReturn<TimeSeriesThresholdPicklist>
    {
    }

    [Route("/picklists/velocityanddeploymentcodes", "GET")]
    public class GetVelocityAndDeploymentCodePicklists
        : IReturn<IList<Picklist>>
    {
        public string DischargeMethodCode { get; set; }
    }

    [Route("/pointvelocitydischarges/{Id}", "DELETE")]
    public class DeletePointVelocityDischarge
        : IReturnVoid
    {
        public long Id { get; set; }
    }

    [Route("/pointvelocitydischarges/{Id}", "GET")]
    public class GetPointVelocityDischarge
        : IReturn<PointVelocityDischarge>
    {
        public long Id { get; set; }
    }

    [Route("/pointvelocitydischarges", "POST")]
    public class PostPointVelocityDischarge
        : IReturn<PointVelocityDischarge>
    {
        public PointVelocityDischarge PointVelocityDischarge { get; set; }
        public DischargeChannelMeasurement ChannelMeasurement { get; set; }
        public long VisitId { get; set; }
    }

    [Route("/pointvelocitydischarges", "PUT")]
    public class PutPointVelocityDischarge
        : IReturn<PointVelocityDischarge>
    {
        public PointVelocityDischarge PointVelocityDischarge { get; set; }
        public DischargeChannelMeasurement ChannelMeasurement { get; set; }
    }

    [Route("/locations/{Id}/ratingmodels", "GET")]
    public class GetLocationRatingModels
        : IReturn<List<Dataset>>
    {
        public long Id { get; set; }
    }

    [Route("/ratingmodels/{Id}/shiftanalysis", "GET")]
    public class GetShiftAnalysis
        : IReturn<ShiftAnalysis>
    {
        public long Id { get; set; }
        public DateTime Time { get; set; }
        public double StageValue { get; set; }
        public string StageUnitId { get; set; }
        public double DischargeValue { get; set; }
        public string DischargeUnitId { get; set; }
    }

    [Route("/report", "GET")]
    public class GetReport
        : IReturn<string>
    {
        public string Api { get; set; }
    }

    [Route("/roles", "GET")]
    public class GetAllRoles
        : IReturn<IList<Role>>
    {
    }

    [Route("/rounding", "GET")]
    public class GetRoundedValue
        : IReturn<RoundedValue>
    {
        public string RoundingSpecification { get; set; }
        public double Value { get; set; }
    }

    [DataContract]
    public class GetSearchResultsBase
    {
        [DataMember(Name="q")]
        public string SearchText { get; set; }

        [DataMember(Name="n")]
        public int MaxResults { get; set; }

        [DataMember(Name="h")]
        public bool HideTruncatedResults { get; set; }
    }

    [Route("/sublocations/{Id}", "DELETE")]
    public class DeleteSubLocation
        : IReturnVoid
    {
        public long Id { get; set; }
    }

    [Route("/sublocations/{Id}", "GET")]
    public class GetSubLocation
        : IReturn<SubLocation>
    {
        public long Id { get; set; }
    }

    [Route("/sublocations", "GET")]
    public class GetSubLocations
        : IReturn<List<SubLocation>>
    {
        public GetSubLocations()
        {
            LocationIds = new List<long>{};
        }

        [DataMember(Name="locationids")]
        public List<long> LocationIds { get; set; }
    }

    [Route("/sublocations", "POST")]
    public class PostSubLocation
        : IReturn<SubLocation>
    {
        public SubLocation SubLocation { get; set; }
    }

    [Route("/sublocations", "PUT")]
    public class PutSubLocation
        : IReturnVoid
    {
        public SubLocation SubLocation { get; set; }
    }

    [Route("/units/{Id*}", "GET")]
    public class GetUnitById
        : IReturn<Unit>
    {
        public string Id { get; set; }
    }

    [Route("/unitgroup/{Id}", "GET")]
    public class GetUnitGroupById
        : IReturn<UnitGroup>
    {
        public string Id { get; set; }
    }

    [Route("/users/search", "GET")]
    public class GetSearchUsers
        : GetSearchResultsBase, IReturn<SearchResultsBase<User>>
    {
    }

    [Route("/version", "GET")]
    public class GetVersion
        : IReturn<Version>
    {
    }

    [Route("/visits/{Id}", "DELETE")]
    public class DeleteVisit
        : IReturnVoid
    {
        public long Id { get; set; }
    }

    [Route("/locations/{Id}/visits", "GET")]
    public class GetLocationVisits
        : IReturn<List<Visit>>
    {
        public long Id { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }

    [Route("/visits/{Id}", "GET")]
    public class GetVisit
        : IReturn<Visit>
    {
        public long Id { get; set; }
    }

    [Route("/visits/{Id}/details", "GET")]
    public class GetVisitInfo
        : IReturn<VisitInfo>
    {
        public long Id { get; set; }
    }

    [Route("/visits/{Id}/AutomaticCorrections", "GET")]
    public class GetVisitWithCorrections
        : IReturn<VisitWithCorrections>
    {
        public long Id { get; set; }
    }

    [Route("/visits", "POST")]
    public class PostVisit
        : IReturn<Visit>
    {
        public Visit Visit { get; set; }
    }

    [Route("/visits", "PUT")]
    public class PutVisit
        : IReturnVoid
    {
        public Visit Visit { get; set; }
    }

    [Route("/visits/{Id}/approvallevel", "PUT")]
    public class PutVisitApprovalLevel
        : IReturnVoid
    {
        public long Id { get; set; }
        public long ApprovalLevelId { get; set; }
    }

    [Route("/volumetricdischarges/{Id}", "DELETE")]
    public class DeleteVolumetricDischarge
        : IReturnVoid
    {
        public long Id { get; set; }
    }

    [Route("/volumetricdischarges/{Id}", "GET")]
    public class GetVolumetricDischarge
        : IReturn<VolumetricDischarge>
    {
        public long Id { get; set; }
    }

    [Route("/volumetricdischarges", "POST")]
    public class PostVolumetricDischarge
        : IReturn<VolumetricDischarge>
    {
        public VolumetricDischarge VolumetricDischarge { get; set; }
        public DischargeChannelMeasurement ChannelMeasurement { get; set; }
        public long VisitId { get; set; }
    }

    [Route("/volumetricdischarges", "PUT")]
    public class PutVolumetricDischarge
        : IReturn<VolumetricDischarge>
    {
        public VolumetricDischarge VolumetricDischarge { get; set; }
        public DischargeChannelMeasurement ChannelMeasurement { get; set; }
    }

    public class Activity
    {
        public long Id { get; set; }
        public long VisitId { get; set; }
        public string MeasurementId { get; set; }
        public string Type { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Party { get; set; }
        [Ignore]
        public bool IsImported { get; set; }

        public bool IsInvalid { get; set; }
    }

    public class AdcpDischarge
    {
        public long Id { get; set; }
        public bool IsInvalid { get; set; }
        public int? NumberOfTransects { get; set; }
        public double? MagneticVariation { get; set; }
        public double? TransducerDepth { get; set; }
        public double? DischargeCoefficientVariation { get; set; }
        public double? PercentOfDischargeMeasured { get; set; }
        public double? TopEstimateExponent { get; set; }
        public double? BottomEstimateExponent { get; set; }
        public double? Width { get; set; }
        public double? Area { get; set; }
        public double? VelocityAverage { get; set; }
        public string TransducerDepthUnitId { get; set; }
        public string WidthUnitId { get; set; }
        public string VelocityAverageUnitId { get; set; }
        public string AreaUnitId { get; set; }
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
        public AttachmentType? NodeDetailsAttachmentType { get; set; }
        public string NodeDetailsSoftwareVersion { get; set; }
    }

    public class CalibrationCheck
    {
        public long Id { get; set; }
        public long ActivityId { get; set; }
        public long? SubLocationId { get; set; }
        public string ParameterId { get; set; }
        public string UnitId { get; set; }
        public string Method { get; set; }
        public string Comments { get; set; }
        public string LotNumber { get; set; }
        public string StandardCode { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public string NodeDetails { get; set; }
        public AttachmentType? NodeDetailsAttachmentType { get; set; }
        public string NodeDetailsSoftwareVersion { get; set; }
        public CalibrationCheckType CalibrationCheckType { get; set; }
        public DateTime? Time { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public double Standard { get; set; }
        public double Value { get; set; }
        public double Temperature { get; set; }
        [Ignore]
        public double ValueConvertedToParameterDefault { get; set; }

        public double? PercentDifferenceFromStandard { get; set; }
        public double? MagnitudeDifferenceFromStandard { get; set; }
        public bool IsInvalid { get; set; }
    }

    public class ControlConditionActivity
    {
        public long Id { get; set; }
        public string Party { get; set; }
        public string Control { get; set; }
        public ConditionType Condition { get; set; }
        public ControlCleanedType ControlCleaned { get; set; }
        public string FlowOverControl { get; set; }
        public DateTime? DateCleaned { get; set; }
        public double? DistanceToGage { get; set; }
        public string DistanceToGageUnitId { get; set; }
        public string Comments { get; set; }
        public bool IsInvalid { get; set; }
    }

    public class DischargeActivity
    {
        public DischargeActivity()
        {
            Readings = new List<GageHeightReading>{};
            RatingModels = new List<Dataset>{};
            Activities = new List<DischargeSubActivity>{};
        }

        public long Id { get; set; }
        public DateTime MeasurementStartTime { get; set; }
        public DateTime MeasurementEndTime { get; set; }
        public DateTime MeasurementTime { get; set; }
        public string Party { get; set; }
        public BaseFlowType BaseFlow { get; set; }
        public bool ShowInRatingDevelopment { get; set; }
        public bool ShowInDataCorrection { get; set; }
        public bool PreventAutomaticPublishing { get; set; }
        public AdjustmentType Adjustment { get; set; }
        public double Amount { get; set; }
        public ReasonForAdjustmentType ReasonForAdjustment { get; set; }
        public DischargeMeasurementReasonType DischargeMeasurementReason { get; set; }
        public double Discharge { get; set; }
        [Ignore]
        public List<GageHeightReading> Readings { get; set; }

        public GageHeightCalculationType GageHeightCalculation { get; set; }
        public double? MeanGageHeight { get; set; }
        public double? DifferenceDuringVisit { get; set; }
        public double? Duration { get; set; }
        public double? MeanIndexVelocity { get; set; }
        public double? AlternateRatingDischarge { get; set; }
        public MeasurementGradeType MeasurementGrade { get; set; }
        public string Reviewer { get; set; }
        public string Comments { get; set; }
        [Ignore]
        public string MeasurementId { get; set; }

        public string DischargeUnitId { get; set; }
        public string GageHeightUnitId { get; set; }
        public string VelocityUnitId { get; set; }
        public string DischargeMethod { get; set; }
        public string GageHeightMethod { get; set; }
        public long? RatingModelId { get; set; }
        [Ignore]
        public List<Dataset> RatingModels { get; set; }

        [Ignore]
        public ShiftAnalysis ShiftAnalysis { get; set; }

        public bool IsInvalid { get; set; }
        [Ignore]
        public List<DischargeSubActivity> Activities { get; set; }
    }

    public class DischargeChannelMeasurement
    {
        public long Id { get; set; }
        public long DischargeActivityId { get; set; }
        public long ChannelId { get; set; }
        public DischargeMethodType Method { get; set; }
        public string MonitoringMethodCode { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Discharge { get; set; }
        public string UnitId { get; set; }
        public string Comments { get; set; }
        public string Party { get; set; }
        public double? DistanceToGage { get; set; }
        public string DistanceToGageUnitId { get; set; }
        public DeploymentMethodType DeploymentMethod { get; set; }
        public VelocityMethodType VelocityMethod { get; set; }
        public HorizontalFlowType HorizontalFlow { get; set; }
        public ChannelStabilityType ChannelStability { get; set; }
        public ChannelMaterialType ChannelMaterial { get; set; }
        public ChannelEvennessType ChannelEvenness { get; set; }
        public VerticalVelocityDistributionType VerticalVelocityDistribution { get; set; }
        public VelocityVariationType VelocityVariation { get; set; }
        public MeasurementLocationToGageType MeasurementLocationToGage { get; set; }
        public MeterSuspensionType MeterSuspension { get; set; }
        public bool IsInvalid { get; set; }
        public bool IsImported { get; set; }
        [Ignore]
        public double? ConvertedDischargeValue { get; set; }
    }

    public class DischargeSubActivity
    {
        public DischargeMethodType Type { get; set; }
        public IDischargeSubActivity Activity { get; set; }
        public DischargeChannelMeasurement ChannelMeasurement { get; set; }
    }

    public class FlumeDischarge
    {
        public FlumeDischarge()
        {
            Readings = new List<FlumeHeadReading>{};
        }

        public long Id { get; set; }
        public EngineeredStructureType StructureType { get; set; }
        public string EquationForSelectedStructure { get; set; }
        public double? MeanHead { get; set; }
        public string HeadUnitId { get; set; }
        public bool IsInvalid { get; set; }
        [Ignore]
        public List<FlumeHeadReading> Readings { get; set; }
    }

    public class FlumeHeadReading
    {
        public long Id { get; set; }
        public long FlumeDischargeId { get; set; }
        public DateTime ReadingTime { get; set; }
        public double Head { get; set; }
        public bool IsUsedInMean { get; set; }
        public bool IsInvalid { get; set; }
    }

    public class GageHeightReading
    {
        public long Id { get; set; }
        public long DischargeActivityId { get; set; }
        public bool IsUsed { get; set; }
        public DateTime? ReadingTime { get; set; }
        public double GageHeight { get; set; }
    }

    public class GageZeroFlowActivity
    {
        public long Id { get; set; }
        public DateTime? ObservedDate { get; set; }
        public DateTime? ApplicableSince { get; set; }
        public double? GageHeight { get; set; }
        public bool IsObserved { get; set; }
        public double? Stage { get; set; }
        public double? Depth { get; set; }
        public double? DepthCertainty { get; set; }
        public string UnitId { get; set; }
        public string Comments { get; set; }
        public string Party { get; set; }
        public bool IsInvalid { get; set; }
    }

    public class Inspection
    {
        public long Id { get; set; }
        public long ActivityId { get; set; }
        public long? SubLocationId { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public string Comments { get; set; }
        public DateTime? Time { get; set; }
        public InspectionType InspectionType { get; set; }
    }

    public class PointVelocityDischarge
    {
        public PointVelocityDischarge()
        {
            Verticals = new List<Vertical>{};
        }

        public long Id { get; set; }
        public double? DistanceToMeter { get; set; }
        public double? MeanObservationDuration { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public string MeterEquation { get; set; }
        public PointVelocityMethodType DischargeMethod { get; set; }
        public string SuspensionWeight { get; set; }
        public StartPointType StartPoint { get; set; }
        public string VelocityObservationMethod { get; set; }
        public bool SuspensionCoefficientUsed { get; set; }
        public bool MethodCoefficientUsed { get; set; }
        public bool HorizontalCoefficientUsed { get; set; }
        public bool? MeterInspectedBefore { get; set; }
        public bool? MeterInspectedAfter { get; set; }
        public int NumberOfPanels { get; set; }
        public double? Width { get; set; }
        public double? Area { get; set; }
        public double? VelocityAverage { get; set; }
        public bool OnlyTotals { get; set; }
        public bool AscendingSegmentDisplayOrder { get; set; }
        public string TaglinePointUnitId { get; set; }
        public double? MaximumSegmentDischarge { get; set; }
        public double? Uncertainty { get; set; }
        public MeasurementCondition? MeasurementConditions { get; set; }
        public string FirmwareVersion { get; set; }
        public string SoftwareVersion { get; set; }
        public string NodeDetails { get; set; }
        public AttachmentType? NodeDetailsAttachmentType { get; set; }
        public string NodeDetailsSoftwareVersion { get; set; }
        public long? MeterCalibrationId { get; set; }
        [Ignore]
        public MeterWithCalibration Meter { get; set; }

        [Ignore]
        public List<Vertical> Verticals { get; set; }

        public string WidthUnitId { get; set; }
        public string AreaUnitId { get; set; }
        public string VelocityAverageUnitId { get; set; }
        public string DistanceToMeterUnitId { get; set; }
        public bool IsInvalid { get; set; }
    }

    public class Reading
    {
        public long Id { get; set; }
        public long ActivityId { get; set; }
        public long? SubLocationId { get; set; }
        public string ParameterId { get; set; }
        public string UnitId { get; set; }
        public string Method { get; set; }
        public string ReadingSource { get; set; }
        public string Comments { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public string NodeDetails { get; set; }
        public AttachmentType? NodeDetailsAttachmentType { get; set; }
        public string NodeDetailsSoftwareVersion { get; set; }
        public ReadingType ReadingType { get; set; }
        public DateTime? Time { get; set; }
        public double Value { get; set; }
        public double? Uncertainty { get; set; }
        public bool IsInvalid { get; set; }
        public bool ShouldPublish { get; set; }
        [Ignore]
        public double ValueConvertedToParameterDefault { get; set; }
    }

    public class VisitInspection
    {
        public VisitInspection()
        {
            Readings = new List<Reading>{};
            Calibrations = new List<CalibrationCheck>{};
            Inspections = new List<Inspection>{};
            Parameters = new List<Parameter>{};
            SubLocations = new List<SubLocation>{};
        }

        public long ActivityId { get; set; }
        public string Party { get; set; }
        [Ignore]
        public List<Reading> Readings { get; set; }

        [Ignore]
        public List<CalibrationCheck> Calibrations { get; set; }

        [Ignore]
        public List<Inspection> Inspections { get; set; }

        [Ignore]
        public List<Parameter> Parameters { get; set; }

        [Ignore]
        public List<SubLocation> SubLocations { get; set; }

        public bool IsInvalid { get; set; }
    }

    public class VolumetricDischarge
    {
        public VolumetricDischarge()
        {
            Readings = new List<VolumetricDischargeReading>{};
        }

        public long Id { get; set; }
        [Ignore]
        public List<VolumetricDischargeReading> Readings { get; set; }

        public bool IsInvalid { get; set; }
        public bool IsObserved { get; set; }
        public string MeasurementContainerUnit { get; set; }
        public double? MeasurementContainerVolume { get; set; }
    }

    public class VolumetricDischargeReading
    {
        public long Id { get; set; }
        public long VolumetricDischargeId { get; set; }
        public bool IsUsed { get; set; }
        public string Name { get; set; }
        public double? DurationSeconds { get; set; }
        public double? StartingVolume { get; set; }
        public double? EndingVolume { get; set; }
        public double? Discharge { get; set; }
        public double? VolumeChange { get; set; }
        public bool IsInvalid { get; set; }
    }

    public class IceCoveredData
    {
        public double? IceThickness { get; set; }
        public double WaterSurfaceToBottomOfSlush { get; set; }
        public double WaterSurfaceToBottomOfIce { get; set; }
        public string IceAssemblyType { get; set; }
        public double? AboveFooting { get; set; }
        public double? BelowFooting { get; set; }
        public double? UnderIceCoefficient { get; set; }
    }

    public class OpenWaterData
    {
        public string SuspensionWeight { get; set; }
        public double? DistanceToMeter { get; set; }
        public double DryLineAngle { get; set; }
        public double? SurfaceCoefficient { get; set; }
        public double? DistanceToWaterSurface { get; set; }
        public double? DryLineCorrection { get; set; }
        public double? WetLineCorrection { get; set; }
    }

    public class Segment
    {
        public double Width { get; set; }
        public double Area { get; set; }
        public double Velocity { get; set; }
        public double Discharge { get; set; }
        public bool IsDischargeEstimated { get; set; }
        public double TotalDischargePortion { get; set; }
    }

    public class VelocityDepthObservation
    {
        public long VelocityObservationId { get; set; }
        public double Depth { get; set; }
        public int? RevolutionCount { get; set; }
        public double? ObservationInterval { get; set; }
        public double Velocity { get; set; }
        public bool IsVelocityEstimated { get; set; }
        public double DepthMultiplier { get; set; }
        public double Weighting { get; set; }
    }

    public class VelocityObservation
    {
        public VelocityObservation()
        {
            Observations = new List<VelocityDepthObservation>{};
        }

        public MeterWithCalibration Meter { get; set; }
        public PointVelocityObservationType? VelocityObservationMethod { get; set; }
        public DeploymentMethodType? DeploymentMethod { get; set; }
        public List<VelocityDepthObservation> Observations { get; set; }
        public double MeanVelocity { get; set; }
    }

    public class Vertical
    {
        public long Id { get; set; }
        public long PointVelocityId { get; set; }
        public Segment Segment { get; set; }
        public IceCoveredData IceCoveredData { get; set; }
        public OpenWaterData OpenWaterData { get; set; }
        public VelocityObservation VelocityObservation { get; set; }
        public int SequenceNumber { get; set; }
        public VerticalType VerticalType { get; set; }
        public MeasurementCondition MeasurementCondition { get; set; }
        public FlowDirectionType FlowDirection { get; set; }
        public double TaglinePosition { get; set; }
        public double SoundedDepth { get; set; }
        public bool IsSoundedDepthEstimated { get; set; }
        public DateTime? MeasurementTime { get; set; }
        public double ObliqueFlowCorrection { get; set; }
        public string Comments { get; set; }
        public double EffectiveDepth { get; set; }
    }

    public class ApprovalLevel
    {
        public long Id { get; set; }
        public long Level { get; set; }
        public string Name { get; set; }
        public string HexColor { get; set; }
    }

    public class ApprovalRange
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ApprovalLevel Approval { get; set; }
        public string Comments { get; set; }
        public User User { get; set; }
        public DateTime AppliedTime { get; set; }
        public bool IsLocked { get; set; }
    }

    public class ApprovalTransition
    {
        public long FromApprovalLevelId { get; set; }
        public long ToApprovalLevelId { get; set; }
    }

    public class Attachment
    {
        public string Id { get; set; }
        [Ignore]
        public long VisitId { get; set; }

        public AttachmentType AttachmentType { get; set; }
        public AttachmentCategory AttachmentCategory { get; set; }
        public string UploadedMimeType { get; set; }
        public string UploadedFilename { get; set; }
        public DateTime UploadedTime { get; set; }
        public DateTime LastModifiedTime { get; set; }
        public DateTime? LastAccessedUtc { get; set; }
        public long FileSize { get; set; }
        public long UploadedByUserId { get; set; }
        public string Comments { get; set; }
        public double? GpsLatitude { get; set; }
        public double? GpsLongitude { get; set; }
        public bool IsImported { get; set; }
        public bool IsTrashed { get; set; }
        [Ignore]
        public string Url { get; set; }

        [Ignore]
        public string UserDisplayName { get; set; }
    }

    public class AppliedCorrection
    {
        public Instant TimeUtc { get; set; }
        public User User { get; set; }
        public string Comments { get; set; }
    }

    public class AutomaticCorrection
    {
        public AutomaticCorrection()
        {
            TimeSeriesList = new List<Dataset>{};
            EquationMarkup = new List<string>{};
        }

        public CorrectionParameter Parameter { get; set; }
        public MonitoringMethod Method { get; set; }
        public SubLocation SubLocation { get; set; }
        public string Status { get; set; }
        public List<Dataset> TimeSeriesList { get; set; }
        public Unit Unit { get; set; }
        public List<string> EquationMarkup { get; set; }
        public ThreePointCorrection FoulingCorrection { get; set; }
        public ThreePointCorrection CalibrationCorrection { get; set; }
        public AppliedCorrection AppliedCorrection { get; set; }
    }

    public class CorrectionParameter
    {
        public string Id { get; set; }
        public string DisplayId { get; set; }
        public string DisplayName { get; set; }
        public string UnitGroupId { get; set; }
        public string DefaultUnitId { get; set; }
        public string DefaultRoundingSpec { get; set; }
    }

    public class CorrectionPoint
    {
        public double InputValue { get; set; }
        public double CorrectionValue { get; set; }
        public string UnitId { get; set; }
    }

    public class ThreePointCorrection
    {
        public ThreePointCorrection()
        {
            StartPoints = new List<CorrectionPoint>{};
            EndPoints = new List<CorrectionPoint>{};
        }

        public Instant CorrectionStartTimeUtc { get; set; }
        public Instant CorrectionEndTimeUtc { get; set; }
        public long StartVisitId { get; set; }
        public List<CorrectionPoint> StartPoints { get; set; }
        public List<CorrectionPoint> EndPoints { get; set; }
    }

    public class Channel
    {
        public long Id { get; set; }
        public long LocationId { get; set; }
        public string Name { get; set; }
    }

    public class ExtendedAttribute
    {
        public long ParentId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public Object Value { get; set; }
        public string Type { get; set; }
    }

    public class ComputationPeriod
    {
        public long Id { get; set; }
        public string PublicIdentifier { get; set; }
        public string DisplayName { get; set; }
        public string FormalName { get; set; }
    }

    public class ComputationType
    {
        public long Id { get; set; }
        public string PublicIdentifier { get; set; }
        public string DisplayName { get; set; }
        public string FormalName { get; set; }
    }

    public class ProcessableComputationPeriod
    {
        public string PublicIdentifier { get; set; }
        public string DisplayName { get; set; }
        public string SystemCode { get; set; }
    }

    public class ProcessableComputationType
    {
        public string PublicIdentifier { get; set; }
        public string DisplayName { get; set; }
        public string SystemCode { get; set; }
    }

    public class FieldDataConfiguration
    {
        public string DefaultRoundingSpecification { get; set; }
        public string DefaultPercentageSpecification { get; set; }
        public long DefaultApprovalLevelIdForNewVisits { get; set; }
        public long ApprovalLockingLevel { get; set; }
        public bool CanLaunchRdt { get; set; }
    }

    public class LocationManagerConfiguration
    {
        public string DefaultGeoDatum { get; set; }
        public int? DefaultGeoDatumSrid { get; set; }
    }

    public class ReportingConfiguration
    {
        public int WaterYearDefaultMonth { get; set; }
        public int GeneratedReportsViewMaxResult { get; set; }
    }

    public class SpringboardConfiguration
    {
        public bool IsFieldDataEnabled { get; set; }
        public int DefaultApprovalViewMonths { get; set; }
        public ApprovalPropagation DefaultApprovalPropagation { get; set; }
        public string DefaultBasicTimeSeriesComputationType { get; set; }
        public string DefaultBasicTimeSeriesPeriod { get; set; }
        public bool CanLaunchRdt { get; set; }
        public string DefaultRoundingSpecification { get; set; }
    }

    public class ApprovalRejection
    {
        public long DatasetId { get; set; }
        public string Reason { get; set; }
    }

    public class Dataset
    {
        public Dataset()
        {
            RelatedDatasets = new List<Dataset>{};
            CommonExtendedAttributes = new List<ExtendedAttribute>{};
        }

        public long Id { get; set; }
        public long LocationId { get; set; }
        public string Identifier { get; set; }
        public string FullIdentifier { get; set; }
        public string LocationIdentifier { get; set; }
        public string LocationName { get; set; }
        public string SubLocationIdentifier { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public DatasetType Type { get; set; }
        public string ParameterId { get; set; }
        public string ParameterName { get; set; }
        public string UnitId { get; set; }
        public string UnitDisplayName { get; set; }
        public DateTime LastModified { get; set; }
        public bool Publish { get; set; }
        public long UtcOffsetMinutes { get; set; }
        public bool IsActive { get; set; }
        public string ComputationDisplayName { get; set; }
        public string ComputationPeriodDisplayName { get; set; }
        public List<Dataset> RelatedDatasets { get; set; }
        public string TimeSeriesIconType { get; set; }
        public List<ExtendedAttribute> CommonExtendedAttributes { get; set; }
    }

    public class DatasetApprovalSaveResult
    {
        public DatasetApprovalSaveResult()
        {
            RelatedDatasets = new List<RelatedDataset>{};
            Rejections = new List<ApprovalRejection>{};
        }

        public long Id { get; set; }
        public bool Complete { get; set; }
        public bool Success { get; set; }
        public List<RelatedDataset> RelatedDatasets { get; set; }
        public List<ApprovalRejection> Rejections { get; set; }
    }

    public class DatasetExtendedAttribute
    {
        public long DatasetId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public Object Value { get; set; }
        public string Type { get; set; }
    }

    public class DatasetWithThresholds
    {
        public DatasetWithThresholds()
        {
            Thresholds = new List<TimeSeriesThreshold>{};
        }

        public Dataset Dataset { get; set; }
        public List<TimeSeriesThreshold> Thresholds { get; set; }
    }

    public class RelatedDataset
    {
        public RelatedDataset()
        {
            AffectedApprovals = new List<ApprovalRange>{};
        }

        public int Order { get; set; }
        public Dataset Dataset { get; set; }
        public bool IsMinimumRequired { get; set; }
        public bool IsApprovalChangeRequired { get; set; }
        public List<ApprovalRange> AffectedApprovals { get; set; }
    }

    public class TimeseriesAppendResult
    {
        public string TimeSeriesIdentifier { get; set; }
        public bool Success { get; set; }
        public ProcessingStatus Status { get; set; }
        public string Error { get; set; }
        public int PointsAppended { get; set; }
    }

    public class TimeSeriesReading
    {
        public long ApprovalLevel { get; set; }
        public string ApprovalDisplayName { get; set; }
        public string ControlCondition { get; set; }
        public string LinkToVisit { get; set; }
        public string LocationIdentifier { get; set; }
        public string LocationName { get; set; }
        public string Manufacturer { get; set; }
        public string Method { get; set; }
        public string MethodDisplayName { get; set; }
        public string Model { get; set; }
        public TimeSeriesReadingEnum ReadingType { get; set; }  // TODO: Manual edit required here
        public string SerialNumber { get; set; }
        public string SubLocation { get; set; }
        public Instant Time { get; set; }
        public string UnitId { get; set; }
        public double Value { get; set; }
        public Instant VisitStartDate { get; set; }
    }

    public class TimeSeriesReadingType
    {
        public TimeSeriesReadingType ReadingType { get; set; }
        public string DisplayName { get; set; }
        public string HexColor { get; set; }
    }

    public class ThresholdReferenceValueCode
    {
        public long Id { get; set; }
        public string ReferenceValueCode { get; set; }
        public int Severity { get; set; }
        public string Description { get; set; }
        public ThresholdType ThresholdType { get; set; }
        public ThresholdSuppressionOption ThresholdSuppressionOption { get; set; }
    }

    public class TimeSeriesThreshold
    {
        public TimeSeriesThreshold()
        {
            Periods = new List<TimeSeriesThresholdPeriod>{};
        }

        public long Id { get; set; }
        public long TimeSeriesId { get; set; }
        public ThresholdReferenceValueCode ReferenceValueCode { get; set; }
        public string ThresholdName { get; set; }
        public ThresholdType ThresholdType { get; set; }
        public string HexColor { get; set; }
        public List<TimeSeriesThresholdPeriod> Periods { get; set; }
    }

    public class TimeSeriesThresholdPeriod
    {
        public long Id { get; set; }
        public long TimeSeriesThresholdId { get; set; }
        public DateTime StartTimeUtc { get; set; }
        public DateTime EndTimeUtc { get; set; }
        public DateTime AppliedTimeUtc { get; set; }
        public double ReferenceValue { get; set; }
        public double? SecondaryReferenceValue { get; set; }
        public bool ShouldSuppress { get; set; }
    }

    public class DatasetViewModePickList
    {
        public IList<PicklistItem> ViewModes { get; set; }
    }

    public class ExportedPoint
    {
        public Instant Timestamp { get; set; }
        public double? Value { get; set; }
        public string ApprovalLevel { get; set; }
        public string Grade { get; set; }
        public string GapTolerance { get; set; }
        public string Method { get; set; }
        public string InterpolationType { get; set; }
        public IList<string> Qualifiers { get; set; }
    }

    public class HelpTopic
    {
        public string Topic { get; set; }
        public string RelativeURL { get; set; }
    }

    public class DragAndDropAppendJob
    {
        public DragAndDropAppendJob()
        {
            Results = new List<TimeseriesAppendResult>{};
        }

        [Ignore]
        public bool success { get; set; }

        public string error { get; set; }
        public long Id { get; set; }
        public long HotFolderParserId { get; set; }
        public string UploadedFilename { get; set; }
        public DragAndDropAppendJobStatus Status { get; set; }
        public DateTime LastModified { get; set; }
        public List<TimeseriesAppendResult> Results { get; set; }
    }

    public class HotFolder
    {
        public HotFolder()
        {
            Parsers = new List<HotFolderParser>{};
        }

        public long Id { get; set; }
        public long LocationId { get; set; }
        public string Name { get; set; }
        public string FolderPath { get; set; }
        [Ignore]
        public List<HotFolderParser> Parsers { get; set; }
    }

    public class HotFolderParser
    {
        public HotFolderParser()
        {
            Identifiers = new List<string>{};
        }

        public long Id { get; set; }
        public long HotFolderId { get; set; }
        public string FileMask { get; set; }
        public List<string> Identifiers { get; set; }
    }

    public class LocationFolder
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsUserAdmin { get; set; }
        public bool CanUserCreateLocations { get; set; }
        public int LocationCount { get; set; }
        public IList<LocationFolder> Folders { get; set; }
    }

    public class LocationFolderRole
    {
        public long? FolderId { get; set; }
        public long? RoleId { get; set; }
        public long UserLocationFolderRoleId { get; set; }
        public string FolderName { get; set; }
        public User User { get; set; }
    }

    public class Location
    {
        public Location()
        {
            Datasets = new List<Dataset>{};
            SubLocations = new List<SubLocation>{};
            LocationTypes = new List<LocationType>{};
        }

        public long Id { get; set; }
        public long LocationFolderId { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserData { get; set; }
        [Ignore]
        public string Source { get; set; }

        public string ElevationUnits { get; set; }
        public double UTCOffset { get; set; }
        public double? Elevation { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public long? LocationTypeId { get; set; }
        [Ignore]
        public List<Dataset> Datasets { get; set; }

        [Ignore]
        public List<SubLocation> SubLocations { get; set; }

        [Ignore]
        public HotFolder HotFolder { get; set; }

        [Ignore]
        public ResolvedLocationRole LocationRole { get; set; }

        [Ignore]
        public List<LocationType> LocationTypes { get; set; }
    }

    public class LocationQueryResult
    {
        public LocationQueryResult()
        {
            Locations = new List<Location>{};
            LocationIdsNotFound = new List<long>{};
        }

        public List<Location> Locations { get; set; }
        public List<long> LocationIdsNotFound { get; set; }
    }

    public class LocationRole
    {
        public long? LocationId { get; set; }
        public long? RoleId { get; set; }
        public long UserRoleUniqueId { get; set; }
        public User User { get; set; }
        public bool IsRoleInheritedFromLocationFolder { get; set; }
        public long? LocationFolderId { get; set; }
        public string LocationFolderName { get; set; }
    }

    public class LocationType
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }

    public class LocationWithExtendedAttributes
    {
        public long LocationId { get; set; }
        public ICollection<ExtendedAttribute> ExtendedAttributes { get; set; }
    }

    public class ResolvedLocationRole
    {
        public ResolvedLocationRole()
        {
            ApprovalLevels = new List<ApprovalLevel>{};
            AllowedTransitions = new List<ApprovalTransition>{};
        }

        public string Name { get; set; }
        public bool IsLocationVisible { get; set; }
        public bool CanEditLocationDetails { get; set; }
        public bool CanAssignUserRoles { get; set; }
        public bool CanReadData { get; set; }
        public bool CanAddData { get; set; }
        public bool CanEditData { get; set; }
        public bool CanAddOrRemoveLocations { get; set; }
        public List<ApprovalLevel> ApprovalLevels { get; set; }
        public List<ApprovalTransition> AllowedTransitions { get; set; }
    }

    public class CalibrationRecord
    {
        public MeterCalibration Calibration { get; set; }
        public DeploymentMethodType DeploymentMethod { get; set; }
        public Instant MeasurementDate { get; set; }
    }

    public class Meter
    {
        public MeterIdentifier Id { get; set; }
        public MeterType? Type { get; set; }
        public string Configuration { get; set; }
        public string SoftwareVersion { get; set; }
        public string FirmwareVersion { get; set; }
    }

    public class MeterCalibration
    {
        public MeterCalibration()
        {
            Equations = new List<MeterCalibrationEquation>{};
        }

        public long Id { get; set; }
        public DateTime? CalibratedOn { get; set; }
        public DateTime? RecalibrateBefore { get; set; }
        public List<MeterCalibrationEquation> Equations { get; set; }
    }

    public class MeterCalibrationEquation
    {
        public long Id { get; set; }
        public long MeterCalibrationId { get; set; }
        public double? RangeStart { get; set; }
        public double? RangeEnd { get; set; }
        public double Slope { get; set; }
        public double Intercept { get; set; }
        public string InterceptUnitId { get; set; }
    }

    public class MeterIdentifier
    {
        public string SerialNumber { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
    }

    public class MeterSearchResult
    {
        public Meter Meter { get; set; }
        public IList<CalibrationRecord> Records { get; set; }
    }

    public class MeterWithCalibration
        : Meter
    {
        public MeterCalibration MeterCalibration { get; set; }
    }

    public class LocationMonitoringMethod
    {
        public long Id { get; set; }
        public long LocationId { get; set; }
        public long? SubLocationId { get; set; }
        public string ParameterId { get; set; }
        public string MethodCode { get; set; }
        public string Comments { get; set; }
        public string Name { get; set; }
    }

    public class LocationMonitoringMethodForDisplay
        : LocationMonitoringMethod
    {
        public string LocationIdentifier { get; set; }
        public string LocationName { get; set; }
        public string SubLocationIdentifier { get; set; }
        public string ParameterName { get; set; }
        public string MethodDisplayName { get; set; }
    }

    public class MonitoringMethod
    {
        public string MethodCode { get; set; }
        public string ParameterId { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string RoundingSpecification { get; set; }
    }

    public class ConvertedValue
    {
        public string SourceUnitId { get; set; }
        public double SourceValue { get; set; }
        public string DestinationUnitId { get; set; }
        public double DestinationValue { get; set; }
        public string UnitGroup { get; set; }
    }

    public class FormParameters
    {
        public FormParameters()
        {
            Parameters = new List<Parameter>{};
            Picklists = new List<Picklist>{};
            MonitoringMethods = new List<MonitoringMethod>{};
        }

        public List<Parameter> Parameters { get; set; }
        public List<Picklist> Picklists { get; set; }
        public List<MonitoringMethod> MonitoringMethods { get; set; }
    }

    public class Parameter
    {
        public Parameter()
        {
            MonitoringMethods = new List<MonitoringMethod>{};
        }

        public string Id { get; set; }
        public string DisplayId { get; set; }
        public string Name { get; set; }
        public string DefaultRoundingSpecification { get; set; }
        public UnitGroup UnitGroup { get; set; }
        public Unit DefaultUnit { get; set; }
        public InterpolationType DefaultInterpolationType { get; set; }
        public double? DefaultUnitMinValue { get; set; }
        public double? DefaultUnitMaxValue { get; set; }
        [Ignore]
        public double? ConvertedUnitMin { get; set; }

        [Ignore]
        public double? ConvertedUnitMax { get; set; }

        [Ignore]
        public List<MonitoringMethod> MonitoringMethods { get; set; }
    }

    public class SanityReport
    {
        public SanityReport()
        {
            FormSummary = new Dictionary<string, string>{};
        }

        public bool Sane { get; set; }
        public Dictionary<string, string> FormSummary { get; set; }
        public FormParameters Missing { get; set; }
        public FormParameters Found { get; set; }
    }

    public class Unit
    {
        public string UnitId { get; set; }
        public string UnitGroupId { get; set; }
        public string Name { get; set; }
        public double BaseMultiplier { get; set; }
        public double BaseOffset { get; set; }
    }

    public class UnitGroup
    {
        public UnitGroup()
        {
            Units = new List<Unit>{};
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string BaseUnitId { get; set; }
        public List<Unit> Units { get; set; }
    }

    public class InterpolationTypePicklist
    {
        public InterpolationTypePicklist()
        {
            InterpolationTypes = new List<PicklistItem>{};
        }

        public List<PicklistItem> InterpolationTypes { get; set; }
    }

    public class Picklist
    {
        public Picklist()
        {
            Items = new List<PicklistItem>{};
        }

        public string Id { get; set; }
        public List<PicklistItem> Items { get; set; }
    }

    public class PicklistItem
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public int DisplayOrder { get; set; }
    }

    public class TimeSeriesThresholdPicklist
    {
        public TimeSeriesThresholdPicklist()
        {
            ThresholdTypes = new List<PicklistItem>{};
        }

        public List<PicklistItem> ThresholdTypes { get; set; }
    }

    public class ShiftAnalysis
    {
        public long Id { get; set; }
        public long DischargeActivityId { get; set; }
        public DateTime MeasurementTime { get; set; }
        public double MeasuredStage { get; set; }
        public double MeasuredDischarge { get; set; }
        public string StageUnitId { get; set; }
        public string DischargeUnitId { get; set; }
        public string EffectiveRatingCurveId { get; set; }
        public double? EffectiveStageShift { get; set; }
        public double PredictedDischarge { get; set; }
        public double? IndicatedStageShift { get; set; }
        public double UnshiftedRatingError { get; set; }
        public double ShiftedRatingError { get; set; }
        public double UnshiftedRatingErrorPercentage { get; set; }
        public double ShiftedRatingErrorPercentage { get; set; }
    }

    public class Role
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }

    public class RoundedValue
    {
        public double Value { get; set; }
        public string Display { get; set; }
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

    public class SubLocation
    {
        public long Id { get; set; }
        public long LocationId { get; set; }
        public string Identifier { get; set; }
        public string Description { get; set; }
    }

    public class User
    {
        public long Id { get; set; }
        public string LoginName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }

    public class Version
    {
        public string ApiVersion { get; set; }
    }

    public class LocationVisitsSummary
    {
        public Visit Visit { get; set; }
        public long LocationId { get; set; }
        public string LocationIdentifier { get; set; }
        public string LocationUTCOffset { get; set; }
    }

    public class SummarizedActivity
    {
        public long Id { get; set; }
        public ActivityType Type { get; set; }
        public bool IsInvalid { get; set; }
    }

    public class SummarizedDischarge
        : SummarizedActivity
    {
        public SummarizedDischarge()
        {
            Channels = new List<SummarizedDischargeChannel>{};
        }

        public string MeasurementId { get; set; }
        public List<SummarizedDischargeChannel> Channels { get; set; }
    }

    public class SummarizedDischargeChannel
    {
        public long Id { get; set; }
        public DischargeMethodType Type { get; set; }
        public string ChannelName { get; set; }
        public bool IsInvalid { get; set; }
        public bool IsImported { get; set; }
    }

    public class SummarizedInspection
        : SummarizedActivity
    {
        public bool HasWaterQuality { get; set; }
        public bool HasWaterQualityCleaning { get; set; }
        public bool HasWaterQualityCalibration { get; set; }
        public bool HasOtherSignificantReadings { get; set; }
    }

    public class Visit
    {
        public long Id { get; set; }
        public long LocationId { get; set; }
        public long? ApprovalLevelId { get; set; }
        public string Party { get; set; }
        public string WeatherDescription { get; set; }
        public string Comments { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsInvalid { get; set; }
        [Ignore]
        public bool IsLocked { get; set; }

        public int? VisitSummaryVersion { get; set; }
        public VisitSummary VisitSummary { get; set; }
        [Ignore]
        public VisitDetails VisitDetails { get; set; }
    }

    public class VisitDetails
    {
        public long VisitId { get; set; }
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

    public class VisitInfo
    {
        public VisitInfo()
        {
            Discharges = new List<DischargeActivity>{};
            Attachments = new List<Attachment>{};
        }

        public Visit Visit { get; set; }
        public GageZeroFlowActivity GageZeroFlow { get; set; }
        public ControlConditionActivity ControlCondition { get; set; }
        public VisitInspection Inspection { get; set; }
        public List<DischargeActivity> Discharges { get; set; }
        public List<Attachment> Attachments { get; set; }
        public Location Location { get; set; }
    }

    public class VisitSummary
    {
        public VisitSummary()
        {
            Activities = new List<SummarizedActivity>{};
            Discharges = new List<SummarizedDischarge>{};
        }

        public bool IsAnythingInvalid { get; set; }
        public int ImageCount { get; set; }
        public int AttachmentCount { get; set; }
        public bool IsVisitInvalid { get; set; }
        public List<SummarizedActivity> Activities { get; set; }
        public List<SummarizedDischarge> Discharges { get; set; }
        public SummarizedInspection Inspection { get; set; }
    }

    public class VisitWithCorrections
    {
        public Visit Visit { get; set; }
        [Ignore]
        public IList<AutomaticCorrection> AutomaticCorrections { get; set; }
    }
}

