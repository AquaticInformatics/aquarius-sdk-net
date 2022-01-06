/* Options:
Date: 2022-01-06 20:22:47
Version: 5.104
Tip: To override a DTO option, remove "//" prefix before updating
BaseUrl: https://aqts-pg.aquariusdev.net/AQUARIUS/Publish/v2

GlobalNamespace: Aquarius.TimeSeries.Client.ServiceModels.Publish
MakePartial: False
MakeVirtual: False
//MakeInternal: False
//MakeDataContractsExtensible: False
//AddReturnMarker: True
//AddDescriptionAsComments: True
//AddDataContractAttributes: False
//AddIndexesToDataMembers: False
//AddGeneratedCodeAttributes: False
//AddResponseStatus: False
//AddImplicitVersion: 
//InitializeCollections: True
ExportValueTypes: True
//IncludeTypes: 
//ExcludeTypes: 
//AddNamespaces: 
//AddDefaultXmlNamespace: http://schemas.servicestack.net/types
*/

using System;
using System.Collections.Generic;
using ServiceStack;
using ServiceStack.DataAnnotations;
using ServiceStack.Web;
using NodaTime;
using Aquarius.TimeSeries.Client.ServiceModels.Publish;


namespace Aquarius.TimeSeries.Client.ServiceModels.Publish
{

    public enum TagApplicability
    {
        AppliesToLocations,
        AppliesToLocationNotes,
        AppliesToSensorsGauges,
        AppliesToAttachments,
        AppliesToReports,
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
        ///<summary>
        ///Username
        ///</summary>
        [ApiMember(Description="Username")]
        public string Username { get; set; }

        ///<summary>
        ///Encrypted password
        ///</summary>
        [ApiMember(Description="Encrypted password")]
        public string EncryptedPassword { get; set; }

        ///<summary>
        ///Optional locale. Defaults to English
        ///</summary>
        [ApiMember(Description="Optional locale. Defaults to English")]
        public string Locale { get; set; }
    }

    public class PublicKey
    {
        ///<summary>
        ///RSA key size in bits
        ///</summary>
        [ApiMember(DataType="integer", Description="RSA key size in bits", Format="int32")]
        public int KeySize { get; set; }

        ///<summary>
        ///XML blob containing the RSA public key components
        ///</summary>
        [ApiMember(Description="XML blob containing the RSA public key components")]
        public string Xml { get; set; }
    }

    public class Approval
        : TimeRange
    {
        ///<summary>
        ///Approval level
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level", Format="int32")]
        public int ApprovalLevel { get; set; }

        ///<summary>
        ///Date applied utc
        ///</summary>
        [ApiMember(DataType="string", Description="Date applied utc", Format="date-time")]
        public DateTime DateAppliedUtc { get; set; }

        ///<summary>
        ///User
        ///</summary>
        [ApiMember(Description="User")]
        public string User { get; set; }

        ///<summary>
        ///Level description
        ///</summary>
        [ApiMember(Description="Level description")]
        public string LevelDescription { get; set; }

        ///<summary>
        ///Comment
        ///</summary>
        [ApiMember(Description="Comment")]
        public string Comment { get; set; }
    }

    public class ApprovalMetadata
    {
        ///<summary>
        ///Identifier
        ///</summary>
        [ApiMember(Description="Identifier")]
        public string Identifier { get; set; }

        ///<summary>
        ///Display name
        ///</summary>
        [ApiMember(Description="Display name")]
        public string DisplayName { get; set; }

        ///<summary>
        ///Color
        ///</summary>
        [ApiMember(Description="Color")]
        public string Color { get; set; }
    }

    public class ApprovalsTransaction
        : Approval
    {
    }

    public class Correction
    {
        ///<summary>
        ///Type
        ///</summary>
        [ApiMember(DataType="string", Description="Type")]
        public CorrectionType Type { get; set; }

        ///<summary>
        ///Start time
        ///</summary>
        [ApiMember(DataType="string", Description="Start time", Format="date-time")]
        public DateTimeOffset StartTime { get; set; }

        ///<summary>
        ///End time
        ///</summary>
        [ApiMember(DataType="string", Description="End time", Format="date-time")]
        public DateTimeOffset EndTime { get; set; }

        ///<summary>
        ///Applied time utc
        ///</summary>
        [ApiMember(DataType="string", Description="Applied time utc", Format="date-time")]
        public DateTime AppliedTimeUtc { get; set; }

        ///<summary>
        ///Comment
        ///</summary>
        [ApiMember(Description="Comment")]
        public string Comment { get; set; }

        ///<summary>
        ///User
        ///</summary>
        [ApiMember(Description="User")]
        public string User { get; set; }

        public IDictionary<string, Object> Parameters { get; set; }
        ///<summary>
        ///Processing order
        ///</summary>
        [ApiMember(DataType="CorrectionProcessingOrder", Description="Processing order")]
        public CorrectionProcessingOrder ProcessingOrder { get; set; }
    }

    public class CorrectionOperation
        : TimeRange, IStackPositionMetadataOperation
    {
        ///<summary>
        ///Type
        ///</summary>
        [ApiMember(DataType="string", Description="Type")]
        public CorrectionType Type { get; set; }

        public IDictionary<string, Object> Parameters { get; set; }
        ///<summary>
        ///Processing order
        ///</summary>
        [ApiMember(DataType="CorrectionProcessingOrder", Description="Processing order")]
        public CorrectionProcessingOrder ProcessingOrder { get; set; }

        ///<summary>
        ///Date applied utc
        ///</summary>
        [ApiMember(DataType="string", Description="Date applied utc", Format="date-time")]
        public DateTime DateAppliedUtc { get; set; }

        ///<summary>
        ///User
        ///</summary>
        [ApiMember(Description="User")]
        public string User { get; set; }

        ///<summary>
        ///Operation type
        ///</summary>
        [ApiMember(DataType="string", Description="Operation type")]
        public MetadataChangeOperationType OperationType { get; set; }

        ///<summary>
        ///Stack position
        ///</summary>
        [ApiMember(DataType="integer", Description="Stack position", Format="int32")]
        public int StackPosition { get; set; }

        ///<summary>
        ///Comments
        ///</summary>
        [ApiMember(Description="Comments")]
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
        ///<summary>
        ///Numeric
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric", Format="double")]
        public double? Numeric { get; set; }

        ///<summary>
        ///Display
        ///</summary>
        [ApiMember(Description="Display")]
        public string Display { get; set; }
    }

    public class EffectiveShift
    {
        ///<summary>
        ///Timestamp
        ///</summary>
        [ApiMember(DataType="string", Description="Timestamp", Format="date-time")]
        public DateTimeOffset Timestamp { get; set; }

        ///<summary>
        ///Value
        ///</summary>
        [ApiMember(DataType="number", Description="Value", Format="double")]
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

        ///<summary>
        ///Id
        ///</summary>
        [ApiMember(Description="Id")]
        public string Id { get; set; }

        ///<summary>
        ///Type
        ///</summary>
        [ApiMember(DataType="string", Description="Type")]
        public RatingCurveType Type { get; set; }

        ///<summary>
        ///Remarks
        ///</summary>
        [ApiMember(Description="Remarks")]
        public string Remarks { get; set; }

        ///<summary>
        ///Input parameter
        ///</summary>
        [ApiMember(DataType="ParameterWithUnit", Description="Input parameter")]
        public ParameterWithUnit InputParameter { get; set; }

        ///<summary>
        ///Output parameter
        ///</summary>
        [ApiMember(DataType="ParameterWithUnit", Description="Output parameter")]
        public ParameterWithUnit OutputParameter { get; set; }

        ///<summary>
        ///Periods of applicability
        ///</summary>
        [ApiMember(DataType="array", Description="Periods of applicability")]
        public List<PeriodOfApplicability> PeriodsOfApplicability { get; set; }

        ///<summary>
        ///Shifts
        ///</summary>
        [ApiMember(DataType="array", Description="Shifts")]
        public List<RatingShift> Shifts { get; set; }

        ///<summary>
        ///Offsets
        ///</summary>
        [ApiMember(DataType="array", Description="Offsets")]
        public List<OffsetPoint> Offsets { get; set; }

        ///<summary>
        ///Is blended
        ///</summary>
        [ApiMember(DataType="boolean", Description="Is blended")]
        public bool IsBlended { get; set; }

        ///<summary>
        ///Base rating table
        ///</summary>
        [ApiMember(DataType="array", Description="Base rating table")]
        public List<RatingPoint> BaseRatingTable { get; set; }

        ///<summary>
        ///Adjusted rating table
        ///</summary>
        [ApiMember(DataType="array", Description="Adjusted rating table")]
        public List<RatingPoint> AdjustedRatingTable { get; set; }
    }

    public class ExtendedAttribute
    {
        ///<summary>
        ///UniqueId of the extended attribute
        ///</summary>
        [ApiMember(DataType="string", Description="UniqueId of the extended attribute", Format="guid")]
        public Guid? UniqueId { get; set; }

        ///<summary>
        ///Name
        ///</summary>
        [ApiMember(Description="Name")]
        public string Name { get; set; }

        ///<summary>
        ///Type
        ///</summary>
        [ApiMember(Description="Type")]
        public string Type { get; set; }

        ///<summary>
        ///Value
        ///</summary>
        [ApiMember(DataType="object", Description="Value")]
        public Object Value { get; set; }
    }

    public class ExtendedAttributeFilter
    {
        ///<summary>
        ///Filter name
        ///</summary>
        [ApiMember(Description="Filter name")]
        public string FilterName { get; set; }

        ///<summary>
        ///Filter value
        ///</summary>
        [ApiMember(Description="Filter value")]
        public string FilterValue { get; set; }
    }

    public class GapTolerance
        : TimeRange
    {
        ///<summary>
        ///Tolerance in minutes
        ///</summary>
        [ApiMember(DataType="number", Description="Tolerance in minutes", Format="double")]
        public double? ToleranceInMinutes { get; set; }
    }

    public class GapToleranceOperation
        : GapTolerance, IStackPositionMetadataOperation
    {
        ///<summary>
        ///Operation type
        ///</summary>
        [ApiMember(DataType="string", Description="Operation type")]
        public MetadataChangeOperationType OperationType { get; set; }

        ///<summary>
        ///Date applied utc
        ///</summary>
        [ApiMember(DataType="string", Description="Date applied utc", Format="date-time")]
        public DateTime DateAppliedUtc { get; set; }

        ///<summary>
        ///User
        ///</summary>
        [ApiMember(Description="User")]
        public string User { get; set; }

        ///<summary>
        ///Stack position
        ///</summary>
        [ApiMember(DataType="integer", Description="Stack position", Format="int32")]
        public int StackPosition { get; set; }

        ///<summary>
        ///Comments
        ///</summary>
        [ApiMember(Description="Comments")]
        public string Comments { get; set; }
    }

    public class Grade
        : TimeRange
    {
        ///<summary>
        ///Grade code
        ///</summary>
        [ApiMember(Description="Grade code")]
        public string GradeCode { get; set; }
    }

    public class GradeMetadata
    {
        ///<summary>
        ///Identifier
        ///</summary>
        [ApiMember(Description="Identifier")]
        public string Identifier { get; set; }

        ///<summary>
        ///Display name
        ///</summary>
        [ApiMember(Description="Display name")]
        public string DisplayName { get; set; }

        ///<summary>
        ///Description
        ///</summary>
        [ApiMember(Description="Description")]
        public string Description { get; set; }

        ///<summary>
        ///Color
        ///</summary>
        [ApiMember(Description="Color")]
        public string Color { get; set; }
    }

    public class GradeOperation
        : Grade, IStackPositionMetadataOperation
    {
        ///<summary>
        ///Date applied utc
        ///</summary>
        [ApiMember(DataType="string", Description="Date applied utc", Format="date-time")]
        public DateTime DateAppliedUtc { get; set; }

        ///<summary>
        ///User
        ///</summary>
        [ApiMember(Description="User")]
        public string User { get; set; }

        ///<summary>
        ///Operation type
        ///</summary>
        [ApiMember(DataType="string", Description="Operation type")]
        public MetadataChangeOperationType OperationType { get; set; }

        ///<summary>
        ///Stack position
        ///</summary>
        [ApiMember(DataType="integer", Description="Stack position", Format="int32")]
        public int StackPosition { get; set; }

        ///<summary>
        ///Comments
        ///</summary>
        [ApiMember(Description="Comments")]
        public string Comments { get; set; }
    }

    public interface IMetadataChangeOperation
    {
        DateTime DateAppliedUtc { get; set; }
        string User { get; set; }
        MetadataChangeOperationType OperationType { get; set; }
    }

    public class InterpolationType
        : TimeRange
    {
        ///<summary>
        ///Type
        ///</summary>
        [ApiMember(Description="Type")]
        public string Type { get; set; }
    }

    public class InterpolationTypeOperation
        : InterpolationType, IStackPositionMetadataOperation
    {
        ///<summary>
        ///Date applied utc
        ///</summary>
        [ApiMember(DataType="string", Description="Date applied utc", Format="date-time")]
        public DateTime DateAppliedUtc { get; set; }

        ///<summary>
        ///User
        ///</summary>
        [ApiMember(Description="User")]
        public string User { get; set; }

        ///<summary>
        ///Operation type
        ///</summary>
        [ApiMember(DataType="string", Description="Operation type")]
        public MetadataChangeOperationType OperationType { get; set; }

        ///<summary>
        ///Stack position
        ///</summary>
        [ApiMember(DataType="integer", Description="Stack position", Format="int32")]
        public int StackPosition { get; set; }

        ///<summary>
        ///Comments
        ///</summary>
        [ApiMember(Description="Comments")]
        public string Comments { get; set; }
    }

    public interface IStackPositionMetadataOperation
        : IMetadataChangeOperation
    {
        int StackPosition { get; set; }
        string Comments { get; set; }
    }

    public class LocationDatum
    {
        public LocationDatum()
        {
            DatumPeriods = new List<LocationDatumPeriod>{};
        }

        ///<summary>
        ///Reference standard
        ///</summary>
        [ApiMember(DataType="LocationReferenceStandard", Description="Reference standard")]
        public LocationReferenceStandard ReferenceStandard { get; set; }

        ///<summary>
        ///Datum periods
        ///</summary>
        [ApiMember(DataType="array", Description="Datum periods")]
        public List<LocationDatumPeriod> DatumPeriods { get; set; }
    }

    public class LocationDatumPeriod
    {
        ///<summary>
        ///Standard
        ///</summary>
        [ApiMember(Description="Standard")]
        public string Standard { get; set; }

        ///<summary>
        ///Time range
        ///</summary>
        [ApiMember(DataType="TimeRange", Description="Time range")]
        public TimeRange TimeRange { get; set; }

        ///<summary>
        ///Unit identifier
        ///</summary>
        [ApiMember(Description="Unit identifier")]
        public string UnitIdentifier { get; set; }

        ///<summary>
        ///Offset to standard
        ///</summary>
        [ApiMember(DataType="number", Description="Offset to standard", Format="double")]
        public double OffsetToStandard { get; set; }

        ///<summary>
        ///Uncertainty of offset to standard if any
        ///</summary>
        [ApiMember(DataType="number", Description="Uncertainty of offset to standard if any", Format="double")]
        public double? Uncertainty { get; set; }

        ///<summary>
        ///Method used to determine the offset
        ///</summary>
        [ApiMember(Description="Method used to determine the offset")]
        public string Method { get; set; }

        ///<summary>
        ///Direction that positive measurements are taken in relation to the reference point
        ///</summary>
        [ApiMember(DataType="string", Description="Direction that positive measurements are taken in relation to the reference point")]
        public MeasurementDirection MeasurementDirection { get; set; }

        ///<summary>
        ///Comments
        ///</summary>
        [ApiMember(Description="Comments")]
        public string Comments { get; set; }

        ///<summary>
        ///Applied time utc
        ///</summary>
        [ApiMember(DataType="string", Description="Applied time utc", Format="date-time")]
        public Instant AppliedTimeUtc { get; set; }

        ///<summary>
        ///User
        ///</summary>
        [ApiMember(Description="User")]
        public string User { get; set; }
    }

    public class LocationDescription
    {
        public LocationDescription()
        {
            SecondaryFolders = new List<string>{};
            Tags = new List<TagMetadata>{};
        }

        ///<summary>
        ///Name
        ///</summary>
        [ApiMember(Description="Name")]
        public string Name { get; set; }

        ///<summary>
        ///Identifier
        ///</summary>
        [ApiMember(Description="Identifier")]
        public string Identifier { get; set; }

        ///<summary>
        ///Unique id
        ///</summary>
        [ApiMember(DataType="string", Description="Unique id", Format="guid")]
        public Guid UniqueId { get; set; }

        ///<summary>
        ///External locations are created by data connectors.
        ///</summary>
        [ApiMember(DataType="boolean", Description="External locations are created by data connectors.")]
        public bool IsExternalLocation { get; set; }

        ///<summary>
        ///Primary folder
        ///</summary>
        [ApiMember(Description="Primary folder")]
        public string PrimaryFolder { get; set; }

        ///<summary>
        ///Secondary folders
        ///</summary>
        [ApiMember(DataType="array", Description="Secondary folders")]
        public List<string> SecondaryFolders { get; set; }

        ///<summary>
        ///Last modified
        ///</summary>
        [ApiMember(DataType="string", Description="Last modified", Format="date-time")]
        public DateTimeOffset LastModified { get; set; }

        ///<summary>
        ///Publish
        ///</summary>
        [ApiMember(DataType="boolean", Description="Publish")]
        public bool Publish { get; set; }

        ///<summary>
        ///Tags
        ///</summary>
        [ApiMember(DataType="array", Description="Tags")]
        public List<TagMetadata> Tags { get; set; }

        ///<summary>
        ///Utc offset
        ///</summary>
        [ApiMember(DataType="number", Description="Utc offset", Format="double")]
        public double UtcOffset { get; set; }
    }

    public class LocationMonitoringMethod
    {
        public LocationMonitoringMethod()
        {
            Tags = new List<TagMetadata>{};
        }

        ///<summary>
        ///UniqueId
        ///</summary>
        [ApiMember(DataType="string", Description="UniqueId", Format="guid")]
        public Guid UniqueId { get; set; }

        ///<summary>
        ///Location Identifier
        ///</summary>
        [ApiMember(Description="Location Identifier")]
        public string LocationIdentifier { get; set; }

        ///<summary>
        ///Name
        ///</summary>
        [ApiMember(Description="Name")]
        public string Name { get; set; }

        ///<summary>
        ///Method Code
        ///</summary>
        [ApiMember(Description="Method Code")]
        public string MethodCode { get; set; }

        ///<summary>
        ///Method Display Name
        ///</summary>
        [ApiMember(Description="Method Display Name")]
        public string Method { get; set; }

        ///<summary>
        ///Parameter Name
        ///</summary>
        [ApiMember(Description="Parameter Name")]
        public string Parameter { get; set; }

        ///<summary>
        ///Parameter Id
        ///</summary>
        [ApiMember(Description="Parameter Id")]
        public string ParameterId { get; set; }

        ///<summary>
        ///Parameter Unique Id
        ///</summary>
        [ApiMember(DataType="string", Description="Parameter Unique Id", Format="guid")]
        public Guid ParameterUniqueId { get; set; }

        ///<summary>
        ///Unit Id
        ///</summary>
        [ApiMember(Description="Unit Id")]
        public string UnitId { get; set; }

        ///<summary>
        ///Unit Name
        ///</summary>
        [ApiMember(Description="Unit Name")]
        public string UnitName { get; set; }

        ///<summary>
        ///Sub location identifier
        ///</summary>
        [ApiMember(Description="Sub location identifier")]
        public string SubLocationIdentifier { get; set; }

        ///<summary>
        ///Comment
        ///</summary>
        [ApiMember(Description="Comment")]
        public string Comment { get; set; }

        ///<summary>
        ///Manufacturer
        ///</summary>
        [ApiMember(Description="Manufacturer")]
        public string Manufacturer { get; set; }

        ///<summary>
        ///Model
        ///</summary>
        [ApiMember(Description="Model")]
        public string Model { get; set; }

        ///<summary>
        ///Serial Number
        ///</summary>
        [ApiMember(Description="Serial Number")]
        public string SerialNumber { get; set; }

        ///<summary>
        ///Last modified time (UTC)
        ///</summary>
        [ApiMember(DataType="string", Description="Last modified time (UTC)", Format="date-time")]
        public DateTimeOffset LastModifiedUtc { get; set; }

        ///<summary>
        ///Tags
        ///</summary>
        [ApiMember(DataType="array", Description="Tags")]
        public List<TagMetadata> Tags { get; set; }
    }

    public class LocationNote
    {
        public LocationNote()
        {
            Tags = new List<TagMetadata>{};
        }

        ///<summary>
        ///UniqueId
        ///</summary>
        [ApiMember(DataType="string", Description="UniqueId", Format="guid")]
        public Guid UniqueId { get; set; }

        ///<summary>
        ///Create time (UTC)
        ///</summary>
        [ApiMember(DataType="string", Description="Create time (UTC)", Format="date-time")]
        public DateTimeOffset CreateTimeUtc { get; set; }

        ///<summary>
        ///Last modified time (UTC)
        ///</summary>
        [ApiMember(DataType="string", Description="Last modified time (UTC)", Format="date-time")]
        public DateTimeOffset LastModifiedUtc { get; set; }

        ///<summary>
        ///From time (UTC)
        ///</summary>
        [ApiMember(DataType="string", Description="From time (UTC)", Format="date-time")]
        public DateTimeOffset? FromTimeUtc { get; set; }

        ///<summary>
        ///To time (UTC)
        ///</summary>
        [ApiMember(DataType="string", Description="To time (UTC)", Format="date-time")]
        public DateTimeOffset? ToTimeUtc { get; set; }

        ///<summary>
        ///Details
        ///</summary>
        [ApiMember(Description="Details")]
        public string Details { get; set; }

        ///<summary>
        ///Time-series unique id
        ///</summary>
        [ApiMember(DataType="string", Description="Time-series unique id", Format="guid")]
        public Guid? TimeSeriesUniqueId { get; set; }

        ///<summary>
        ///Location note tags
        ///</summary>
        [ApiMember(DataType="array", Description="Location note tags")]
        public List<TagMetadata> Tags { get; set; }

        ///<summary>
        ///User who last modified this note
        ///</summary>
        [ApiMember(Description="User who last modified this note")]
        public string LastModifiedByUser { get; set; }
    }

    public class LocationReferenceStandard
    {
        public LocationReferenceStandard()
        {
            ReferenceStandardOffsets = new List<ReferenceStandardOffset>{};
        }

        ///<summary>
        ///Reference standard
        ///</summary>
        [ApiMember(Description="Reference standard")]
        public string ReferenceStandard { get; set; }

        ///<summary>
        ///Reference standard offsets
        ///</summary>
        [ApiMember(DataType="array", Description="Reference standard offsets")]
        public List<ReferenceStandardOffset> ReferenceStandardOffsets { get; set; }

        ///<summary>
        ///Comments
        ///</summary>
        [ApiMember(Description="Comments")]
        public string Comments { get; set; }

        ///<summary>
        ///Method
        ///</summary>
        [ApiMember(Description="Method")]
        public string Method { get; set; }

        ///<summary>
        ///Uncertainty
        ///</summary>
        [ApiMember(DataType="number", Description="Uncertainty", Format="double")]
        public double? Uncertainty { get; set; }
    }

    public class LocationRemark
    {
        ///<summary>
        ///Create time
        ///</summary>
        [ApiMember(DataType="string", Description="Create time", Format="date-time")]
        public DateTimeOffset? CreateTime { get; set; }

        ///<summary>
        ///From time
        ///</summary>
        [ApiMember(DataType="string", Description="From time", Format="date-time")]
        public DateTimeOffset? FromTime { get; set; }

        ///<summary>
        ///To time
        ///</summary>
        [ApiMember(DataType="string", Description="To time", Format="date-time")]
        public DateTimeOffset? ToTime { get; set; }

        ///<summary>
        ///Type name
        ///</summary>
        [ApiMember(Description="Type name")]
        public string TypeName { get; set; }

        ///<summary>
        ///Description
        ///</summary>
        [ApiMember(Description="Description")]
        public string Description { get; set; }

        ///<summary>
        ///Remark
        ///</summary>
        [ApiMember(Description="Remark")]
        public string Remark { get; set; }
    }

    public enum MeasurementDirection
    {
        Unknown,
        FromTopToBottom,
        FromBottomToTop,
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
        ///<summary>
        ///Applied time
        ///</summary>
        [ApiMember(DataType="string", Description="Applied time", Format="date-time")]
        public DateTimeOffset AppliedTime { get; set; }

        ///<summary>
        ///Applied by user
        ///</summary>
        [ApiMember(Description="Applied by user")]
        public string AppliedByUser { get; set; }

        ///<summary>
        ///Content type
        ///</summary>
        [ApiMember(DataType="string", Description="Content type")]
        public MetadataChangeContentType ContentType { get; set; }

        ///<summary>
        ///Gap tolerance operations
        ///</summary>
        [ApiMember(DataType="array", Description="Gap tolerance operations")]
        public IList<GapToleranceOperation> GapToleranceOperations { get; set; }

        ///<summary>
        ///Grade operations
        ///</summary>
        [ApiMember(DataType="array", Description="Grade operations")]
        public IList<GradeOperation> GradeOperations { get; set; }

        ///<summary>
        ///Interpolation type operations
        ///</summary>
        [ApiMember(DataType="array", Description="Interpolation type operations")]
        public IList<InterpolationTypeOperation> InterpolationTypeOperations { get; set; }

        ///<summary>
        ///Method operations
        ///</summary>
        [ApiMember(DataType="array", Description="Method operations")]
        public IList<MethodOperation> MethodOperations { get; set; }

        ///<summary>
        ///Note operations
        ///</summary>
        [ApiMember(DataType="array", Description="Note operations")]
        public IList<NoteOperation> NoteOperations { get; set; }

        ///<summary>
        ///Qualifier operations
        ///</summary>
        [ApiMember(DataType="array", Description="Qualifier operations")]
        public IList<QualifierOperation> QualifierOperations { get; set; }

        ///<summary>
        ///Correction operations
        ///</summary>
        [ApiMember(DataType="array", Description="Correction operations")]
        public IList<CorrectionOperation> CorrectionOperations { get; set; }
    }

    public class Method
        : TimeRange
    {
        ///<summary>
        ///Method code
        ///</summary>
        [ApiMember(Description="Method code")]
        public string MethodCode { get; set; }
    }

    public class MethodOperation
        : Method, IStackPositionMetadataOperation
    {
        ///<summary>
        ///Date applied utc
        ///</summary>
        [ApiMember(DataType="string", Description="Date applied utc", Format="date-time")]
        public DateTime DateAppliedUtc { get; set; }

        ///<summary>
        ///User
        ///</summary>
        [ApiMember(Description="User")]
        public string User { get; set; }

        ///<summary>
        ///Operation type
        ///</summary>
        [ApiMember(DataType="string", Description="Operation type")]
        public MetadataChangeOperationType OperationType { get; set; }

        ///<summary>
        ///Stack position
        ///</summary>
        [ApiMember(DataType="integer", Description="Stack position", Format="int32")]
        public int StackPosition { get; set; }

        ///<summary>
        ///Comments
        ///</summary>
        [ApiMember(Description="Comments")]
        public string Comments { get; set; }
    }

    public class MonitoringMethod
    {
        ///<summary>
        ///Method code
        ///</summary>
        [ApiMember(Description="Method code")]
        public string MethodCode { get; set; }

        ///<summary>
        ///Display name
        ///</summary>
        [ApiMember(Description="Display name")]
        public string DisplayName { get; set; }

        ///<summary>
        ///Description
        ///</summary>
        [ApiMember(Description="Description")]
        public string Description { get; set; }

        ///<summary>
        ///Parameter
        ///</summary>
        [ApiMember(Description="Parameter")]
        public string Parameter { get; set; }

        ///<summary>
        ///Rounding spec
        ///</summary>
        [ApiMember(Description="Rounding spec")]
        public string RoundingSpec { get; set; }
    }

    public class NameTagDefinition
        : TagDefinition
    {
        ///<summary>
        ///DEPRECATED: renamed to Key
        ///</summary>
        [ApiMember(Description="DEPRECATED: renamed to Key")]
        public string Name { get; set; }
    }

    public class Note
        : TimeRange
    {
        ///<summary>
        ///Note text
        ///</summary>
        [ApiMember(Description="Note text")]
        public string NoteText { get; set; }
    }

    public class NoteOperation
        : Note, IMetadataChangeOperation
    {
        ///<summary>
        ///Date applied utc
        ///</summary>
        [ApiMember(DataType="string", Description="Date applied utc", Format="date-time")]
        public DateTime DateAppliedUtc { get; set; }

        ///<summary>
        ///User
        ///</summary>
        [ApiMember(Description="User")]
        public string User { get; set; }

        ///<summary>
        ///Operation type
        ///</summary>
        [ApiMember(DataType="string", Description="Operation type")]
        public MetadataChangeOperationType OperationType { get; set; }
    }

    public class OffsetPoint
    {
        ///<summary>
        ///Input value
        ///</summary>
        [ApiMember(DataType="number", Description="Input value", Format="double")]
        public double? InputValue { get; set; }

        ///<summary>
        ///Offset
        ///</summary>
        [ApiMember(DataType="number", Description="Offset", Format="double")]
        public double Offset { get; set; }
    }

    public class ParameterMetadata
    {
        ///<summary>
        ///Identifier
        ///</summary>
        [ApiMember(Description="Identifier")]
        public string Identifier { get; set; }

        ///<summary>
        ///Unit group identifier
        ///</summary>
        [ApiMember(Description="Unit group identifier")]
        public string UnitGroupIdentifier { get; set; }

        ///<summary>
        ///Unit identifier
        ///</summary>
        [ApiMember(Description="Unit identifier")]
        public string UnitIdentifier { get; set; }

        ///<summary>
        ///Display name
        ///</summary>
        [ApiMember(Description="Display name")]
        public string DisplayName { get; set; }

        ///<summary>
        ///Interpolation type
        ///</summary>
        [ApiMember(Description="Interpolation type")]
        public string InterpolationType { get; set; }

        ///<summary>
        ///Rounding spec
        ///</summary>
        [ApiMember(Description="Rounding spec")]
        public string RoundingSpec { get; set; }
    }

    public class ParameterWithUnit
    {
        ///<summary>
        ///Parameter name
        ///</summary>
        [ApiMember(Description="Parameter name")]
        public string ParameterName { get; set; }

        ///<summary>
        ///Parameter unit
        ///</summary>
        [ApiMember(Description="Parameter unit")]
        public string ParameterUnit { get; set; }
    }

    public class PeriodOfApplicability
    {
        ///<summary>
        ///Start time
        ///</summary>
        [ApiMember(DataType="string", Description="Start time", Format="date-time")]
        public DateTimeOffset StartTime { get; set; }

        ///<summary>
        ///End time
        ///</summary>
        [ApiMember(DataType="string", Description="End time", Format="date-time")]
        public DateTimeOffset EndTime { get; set; }

        ///<summary>
        ///Remarks
        ///</summary>
        [ApiMember(Description="Remarks")]
        public string Remarks { get; set; }
    }

    public class Processor
    {
        public Processor()
        {
            InputTimeSeriesUniqueIds = new List<Guid>{};
            Settings = new Dictionary<string, string>{};
        }

        ///<summary>
        ///Processor type
        ///</summary>
        [ApiMember(Description="Processor type")]
        public string ProcessorType { get; set; }

        ///<summary>
        ///Input time series unique ids
        ///</summary>
        [ApiMember(DataType="array", Description="Input time series unique ids")]
        public List<Guid> InputTimeSeriesUniqueIds { get; set; }

        ///<summary>
        ///Output time series unique id
        ///</summary>
        [ApiMember(DataType="string", Description="Output time series unique id", Format="guid")]
        public Guid OutputTimeSeriesUniqueId { get; set; }

        ///<summary>
        ///Processor period
        ///</summary>
        [ApiMember(DataType="TimeRange", Description="Processor period")]
        public TimeRange ProcessorPeriod { get; set; }

        ///<summary>
        ///Description
        ///</summary>
        [ApiMember(Description="Description")]
        public string Description { get; set; }

        ///<summary>
        ///Input rating model identifier
        ///</summary>
        [ApiMember(Description="Input rating model identifier")]
        public string InputRatingModelIdentifier { get; set; }

        public Dictionary<string, string> Settings { get; set; }
    }

    public class Qualifier
        : TimeRange
    {
        ///<summary>
        ///Identifier
        ///</summary>
        [ApiMember(Description="Identifier")]
        public string Identifier { get; set; }

        ///<summary>
        ///Date applied
        ///</summary>
        [ApiMember(DataType="string", Description="Date applied", Format="date-time")]
        public DateTime DateApplied { get; set; }

        ///<summary>
        ///User
        ///</summary>
        [ApiMember(Description="User")]
        public string User { get; set; }
    }

    public class QualifierMetadata
    {
        ///<summary>
        ///Identifier
        ///</summary>
        [ApiMember(Description="Identifier")]
        public string Identifier { get; set; }

        ///<summary>
        ///Code
        ///</summary>
        [ApiMember(Description="Code")]
        public string Code { get; set; }

        ///<summary>
        ///Display name
        ///</summary>
        [ApiMember(Description="Display name")]
        public string DisplayName { get; set; }
    }

    public class QualifierOperation
        : TimeRange, IMetadataChangeOperation
    {
        ///<summary>
        ///Identifier
        ///</summary>
        [ApiMember(Description="Identifier")]
        public string Identifier { get; set; }

        ///<summary>
        ///Operation type
        ///</summary>
        [ApiMember(DataType="string", Description="Operation type")]
        public MetadataChangeOperationType OperationType { get; set; }

        ///<summary>
        ///Date applied utc
        ///</summary>
        [ApiMember(DataType="string", Description="Date applied utc", Format="date-time")]
        public DateTime DateAppliedUtc { get; set; }

        ///<summary>
        ///User
        ///</summary>
        [ApiMember(Description="User")]
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

        ///<summary>
        ///Id
        ///</summary>
        [ApiMember(Description="Id")]
        public string Id { get; set; }

        ///<summary>
        ///Type
        ///</summary>
        [ApiMember(DataType="string", Description="Type")]
        public RatingCurveType Type { get; set; }

        ///<summary>
        ///Equation
        ///</summary>
        [ApiMember(Description="Equation")]
        public string Equation { get; set; }

        ///<summary>
        ///Remarks
        ///</summary>
        [ApiMember(Description="Remarks")]
        public string Remarks { get; set; }

        ///<summary>
        ///Input parameter
        ///</summary>
        [ApiMember(DataType="ParameterWithUnit", Description="Input parameter")]
        public ParameterWithUnit InputParameter { get; set; }

        ///<summary>
        ///Output parameter
        ///</summary>
        [ApiMember(DataType="ParameterWithUnit", Description="Output parameter")]
        public ParameterWithUnit OutputParameter { get; set; }

        ///<summary>
        ///Periods of applicability
        ///</summary>
        [ApiMember(DataType="array", Description="Periods of applicability")]
        public List<PeriodOfApplicability> PeriodsOfApplicability { get; set; }

        ///<summary>
        ///Shifts
        ///</summary>
        [ApiMember(DataType="array", Description="Shifts")]
        public List<RatingShift> Shifts { get; set; }

        ///<summary>
        ///Base rating table
        ///</summary>
        [ApiMember(DataType="array", Description="Base rating table")]
        public List<RatingPoint> BaseRatingTable { get; set; }

        ///<summary>
        ///Offsets
        ///</summary>
        [ApiMember(DataType="array", Description="Offsets")]
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
        ///<summary>
        ///Identifier
        ///</summary>
        [ApiMember(Description="Identifier")]
        public string Identifier { get; set; }

        ///<summary>
        ///Label
        ///</summary>
        [ApiMember(Description="Label")]
        public string Label { get; set; }

        ///<summary>
        ///Location identifier
        ///</summary>
        [ApiMember(Description="Location identifier")]
        public string LocationIdentifier { get; set; }

        ///<summary>
        ///Input parameter
        ///</summary>
        [ApiMember(Description="Input parameter")]
        public string InputParameter { get; set; }

        ///<summary>
        ///Input unit
        ///</summary>
        [ApiMember(Description="Input unit")]
        public string InputUnit { get; set; }

        ///<summary>
        ///Output parameter
        ///</summary>
        [ApiMember(Description="Output parameter")]
        public string OutputParameter { get; set; }

        ///<summary>
        ///Output unit
        ///</summary>
        [ApiMember(Description="Output unit")]
        public string OutputUnit { get; set; }

        ///<summary>
        ///Template name
        ///</summary>
        [ApiMember(Description="Template name")]
        public string TemplateName { get; set; }

        ///<summary>
        ///Description
        ///</summary>
        [ApiMember(Description="Description")]
        public string Description { get; set; }

        ///<summary>
        ///Comment
        ///</summary>
        [ApiMember(Description="Comment")]
        public string Comment { get; set; }

        ///<summary>
        ///Last modified
        ///</summary>
        [ApiMember(DataType="string", Description="Last modified", Format="date-time")]
        public DateTimeOffset LastModified { get; set; }

        ///<summary>
        ///Publish
        ///</summary>
        [ApiMember(DataType="boolean", Description="Publish")]
        public bool Publish { get; set; }
    }

    public class RatingPoint
    {
        ///<summary>
        ///Input value
        ///</summary>
        [ApiMember(DataType="number", Description="Input value", Format="double")]
        public double? InputValue { get; set; }

        ///<summary>
        ///Output value
        ///</summary>
        [ApiMember(DataType="number", Description="Output value", Format="double")]
        public double? OutputValue { get; set; }
    }

    public class RatingShift
    {
        public RatingShift()
        {
            ShiftPoints = new List<RatingShiftPoint>{};
        }

        ///<summary>
        ///Period of applicability
        ///</summary>
        [ApiMember(DataType="PeriodOfApplicability", Description="Period of applicability")]
        public PeriodOfApplicability PeriodOfApplicability { get; set; }

        ///<summary>
        ///Shift points
        ///</summary>
        [ApiMember(DataType="array", Description="Shift points")]
        public List<RatingShiftPoint> ShiftPoints { get; set; }
    }

    public class RatingShiftPoint
    {
        ///<summary>
        ///Input value
        ///</summary>
        [ApiMember(DataType="number", Description="Input value", Format="double")]
        public double InputValue { get; set; }

        ///<summary>
        ///Shift
        ///</summary>
        [ApiMember(DataType="number", Description="Shift", Format="double")]
        public double Shift { get; set; }
    }

    public class ReferencePoint
    {
        public ReferencePoint()
        {
            ReferencePointPeriods = new List<ReferencePointPeriod>{};
        }

        ///<summary>
        ///Unique ID of the reference point
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the reference point", Format="guid")]
        public Guid UniqueId { get; set; }

        ///<summary>
        ///Name
        ///</summary>
        [ApiMember(Description="Name")]
        public string Name { get; set; }

        ///<summary>
        ///Description
        ///</summary>
        [ApiMember(Description="Description")]
        public string Description { get; set; }

        ///<summary>
        ///Decommissioned date
        ///</summary>
        [ApiMember(DataType="string", Description="Decommissioned date", Format="date-time")]
        public DateTimeOffset? DecommissionedDate { get; set; }

        ///<summary>
        ///Decommissioned reason
        ///</summary>
        [ApiMember(Description="Decommissioned reason")]
        public string DecommissionedReason { get; set; }

        ///<summary>
        ///Point has been the primary reference point since this date. If no date is provided, the point is treated as a regular point.
        ///</summary>
        [ApiMember(DataType="string", Description="Point has been the primary reference point since this date. If no date is provided, the point is treated as a regular point.", Format="date-time")]
        public DateTimeOffset? PrimarySinceDate { get; set; }

        ///<summary>
        ///Latitude (WGS 84)
        ///</summary>
        [ApiMember(DataType="number", Description="Latitude (WGS 84)", Format="double")]
        public double? Latitude { get; set; }

        ///<summary>
        ///Longitude (WGS 84)
        ///</summary>
        [ApiMember(DataType="number", Description="Longitude (WGS 84)", Format="double")]
        public double? Longitude { get; set; }

        ///<summary>
        ///Periods of applicability
        ///</summary>
        [ApiMember(DataType="array", Description="Periods of applicability")]
        public List<ReferencePointPeriod> ReferencePointPeriods { get; set; }
    }

    public class ReferencePointPeriod
    {
        ///<summary>
        ///Standard Identifier. Empty when the elevation is measured against the local assumed datum.
        ///</summary>
        [ApiMember(Description="Standard Identifier. Empty when the elevation is measured against the local assumed datum.")]
        public string StandardIdentifier { get; set; }

        ///<summary>
        ///True if this period is measured against the location's local assumed datum instead of a standard datum
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if this period is measured against the location's local assumed datum instead of a standard datum")]
        public bool IsMeasuredAgainstLocalAssumedDatum { get; set; }

        ///<summary>
        ///Time this period is valid from
        ///</summary>
        [ApiMember(DataType="string", Description="Time this period is valid from", Format="date-time")]
        public DateTimeOffset ValidFrom { get; set; }

        ///<summary>
        ///Unit identifier
        ///</summary>
        [ApiMember(Description="Unit identifier")]
        public string Unit { get; set; }

        ///<summary>
        ///Elevation of the reference point relative to the standard or local assumed datum
        ///</summary>
        [ApiMember(DataType="number", Description="Elevation of the reference point relative to the standard or local assumed datum", Format="double")]
        public double Elevation { get; set; }

        ///<summary>
        ///Optional uncertainty of elevation
        ///</summary>
        [ApiMember(DataType="number", Description="Optional uncertainty of elevation", Format="double")]
        public double? Uncertainty { get; set; }

        ///<summary>
        ///Optional method used to determine the elevation
        ///</summary>
        [ApiMember(Description="Optional method used to determine the elevation")]
        public string Method { get; set; }

        ///<summary>
        ///Direction of positive elevations in relation to the reference point
        ///</summary>
        [ApiMember(DataType="string", Description="Direction of positive elevations in relation to the reference point")]
        public MeasurementDirection MeasurementDirection { get; set; }

        ///<summary>
        ///Comment
        ///</summary>
        [ApiMember(Description="Comment")]
        public string Comment { get; set; }

        ///<summary>
        ///Applied date
        ///</summary>
        [ApiMember(DataType="string", Description="Applied date", Format="date-time")]
        public DateTimeOffset AppliedTime { get; set; }

        ///<summary>
        ///Applied by user
        ///</summary>
        [ApiMember(Description="Applied by user")]
        public string AppliedByUser { get; set; }
    }

    public class ReferenceStandardOffset
    {
        ///<summary>
        ///Standard
        ///</summary>
        [ApiMember(Description="Standard")]
        public string Standard { get; set; }

        ///<summary>
        ///Offset to reference standard
        ///</summary>
        [ApiMember(DataType="number", Description="Offset to reference standard", Format="double")]
        public double OffsetToReferenceStandard { get; set; }

        ///<summary>
        ///Comments
        ///</summary>
        [ApiMember(Description="Comments")]
        public string Comments { get; set; }

        ///<summary>
        ///Method
        ///</summary>
        [ApiMember(Description="Method")]
        public string Method { get; set; }

        ///<summary>
        ///Uncertainty
        ///</summary>
        [ApiMember(DataType="number", Description="Uncertainty", Format="double")]
        public double? Uncertainty { get; set; }
    }

    public class Report
    {
        public Report()
        {
            SourceTimeSeriesUniqueIds = new List<Guid>{};
            Tags = new List<TagMetadata>{};
        }

        ///<summary>
        ///ReportUniqueId
        ///</summary>
        [ApiMember(DataType="string", Description="ReportUniqueId", Format="guid")]
        public Guid ReportUniqueId { get; set; }

        ///<summary>
        ///Title
        ///</summary>
        [ApiMember(Description="Title")]
        public string Title { get; set; }

        ///<summary>
        ///Description
        ///</summary>
        [ApiMember(Description="Description")]
        public string Description { get; set; }

        ///<summary>
        ///Comments
        ///</summary>
        [ApiMember(Description="Comments")]
        public string Comments { get; set; }

        ///<summary>
        ///Created time (UTC)
        ///</summary>
        [ApiMember(DataType="string", Description="Created time (UTC)", Format="date-time")]
        public DateTime CreatedTime { get; set; }

        ///<summary>
        ///Time range of source data displayed in report (UTC)
        ///</summary>
        [ApiMember(DataType="TimeRange", Description="Time range of source data displayed in report (UTC)")]
        public TimeRange SourceTimeRange { get; set; }

        ///<summary>
        ///Is transient
        ///</summary>
        [ApiMember(DataType="boolean", Description="Is transient")]
        public bool IsTransient { get; set; }

        ///<summary>
        ///Source time-series unique IDs
        ///</summary>
        [ApiMember(DataType="array", Description="Source time-series unique IDs")]
        public List<Guid> SourceTimeSeriesUniqueIds { get; set; }

        ///<summary>
        ///Location unique ID
        ///</summary>
        [ApiMember(DataType="string", Description="Location unique ID", Format="guid")]
        public Guid LocationUniqueId { get; set; }

        ///<summary>
        ///Tags
        ///</summary>
        [ApiMember(DataType="array", Description="Tags")]
        public List<TagMetadata> Tags { get; set; }

        ///<summary>
        ///Report creator's user unique ID
        ///</summary>
        [ApiMember(DataType="string", Description="Report creator's user unique ID", Format="guid")]
        public Guid UserUniqueId { get; set; }

        ///<summary>
        ///Report creator's user name
        ///</summary>
        [ApiMember(Description="Report creator's user name")]
        public string UserName { get; set; }

        ///<summary>
        ///Attachment URL
        ///</summary>
        [ApiMember(Description="Attachment URL")]
        public string Url { get; set; }
    }

    public class StagePoint
    {
        ///<summary>
        ///Input value
        ///</summary>
        [ApiMember(DataType="number", Description="Input value", Format="double")]
        public double InputValue { get; set; }

        ///<summary>
        ///Correction
        ///</summary>
        [ApiMember(DataType="number", Description="Correction", Format="double")]
        public double Correction { get; set; }

        ///<summary>
        ///Corrected value
        ///</summary>
        [ApiMember(DataType="number", Description="Corrected value", Format="double")]
        public double CorrectedValue { get; set; }
    }

    public class StatisticalDateTimeOffset
    {
        ///<summary>
        ///Date time offset
        ///</summary>
        [ApiMember(DataType="string", Description="Date time offset", Format="date-time")]
        public DateTimeOffset DateTimeOffset { get; set; }

        ///<summary>
        ///Represents end of time period
        ///</summary>
        [ApiMember(DataType="boolean", Description="Represents end of time period")]
        public bool RepresentsEndOfTimePeriod { get; set; }
    }

    public class StatisticalTimeRange
    {
        ///<summary>
        ///Start time
        ///</summary>
        [ApiMember(DataType="StatisticalDateTimeOffset", Description="Start time")]
        public StatisticalDateTimeOffset StartTime { get; set; }

        ///<summary>
        ///End time
        ///</summary>
        [ApiMember(DataType="StatisticalDateTimeOffset", Description="End time")]
        public StatisticalDateTimeOffset EndTime { get; set; }
    }

    public class TagDefinition
    {
        public TagDefinition()
        {
            PickListValues = new List<string>{};
        }

        ///<summary>
        ///Key of the tag
        ///</summary>
        [ApiMember(Description="Key of the tag")]
        public string Key { get; set; }

        ///<summary>
        ///UniqueId
        ///</summary>
        [ApiMember(DataType="string", Description="UniqueId", Format="guid")]
        public Guid UniqueId { get; set; }

        ///<summary>
        ///Value type
        ///</summary>
        [ApiMember(DataType="TagValueType", Description="Value type")]
        public TagValueType? ValueType { get; set; }

        ///<summary>
        ///Set of pick-list values if ValueType is PickList
        ///</summary>
        [ApiMember(DataType="array", Description="Set of pick-list values if ValueType is PickList")]
        public List<string> PickListValues { get; set; }

        ///<summary>
        ///True if tag is applicable to Attachments
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if tag is applicable to Attachments")]
        public bool AppliesToAttachments { get; set; }

        ///<summary>
        ///True if tag is applicable to Locations
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if tag is applicable to Locations")]
        public bool AppliesToLocations { get; set; }

        ///<summary>
        ///True if tag is applicable to Location Notes
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if tag is applicable to Location Notes")]
        public bool AppliesToLocationNotes { get; set; }

        ///<summary>
        ///True if tag is applicable to Reports
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if tag is applicable to Reports")]
        public bool AppliesToReports { get; set; }

        ///<summary>
        ///True if tag is applicable to Sensors and Gauges
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if tag is applicable to Sensors and Gauges")]
        public bool AppliesToSensorsGauges { get; set; }
    }

    public class TagMetadata
    {
        ///<summary>
        ///UniqueId of the tag
        ///</summary>
        [ApiMember(DataType="string", Description="UniqueId of the tag", Format="guid")]
        public Guid UniqueId { get; set; }

        ///<summary>
        ///DEPRECATED: renamed to Key
        ///</summary>
        [ApiMember(Description="DEPRECATED: renamed to Key")]
        public string Name { get; set; }

        ///<summary>
        ///Key of the tag
        ///</summary>
        [ApiMember(Description="Key of the tag")]
        public string Key { get; set; }

        ///<summary>
        ///Value of the applied tag, if the tag's ValueType is PickList
        ///</summary>
        [ApiMember(Description="Value of the applied tag, if the tag's ValueType is PickList")]
        public string Value { get; set; }
    }

    public enum TagValueType
    {
        Unknown,
        None,
        PickList,
        String,
        Number,
        Boolean,
    }

    public enum ThresholdType
    {
        Unknown,
        ThresholdAbove,
        ThresholdBelow,
        None,
    }

    public class TimeAlignedPoint
    {
        ///<summary>
        ///Timestamp
        ///</summary>
        [ApiMember(DataType="string", Description="Timestamp", Format="date-time")]
        public DateTimeOffset Timestamp { get; set; }

        ///<summary>
        ///Numeric value of output time-series 1
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time-series 1", Format="double")]
        public double? NumericValue1 { get; set; }

        ///<summary>
        ///Display value of output time-series 1
        ///</summary>
        [ApiMember(Description="Display value of output time-series 1")]
        public string DisplayValue1 { get; set; }

        ///<summary>
        ///Grade code of output time-series 1
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time-series 1", Format="int64")]
        public long? GradeCode1 { get; set; }

        ///<summary>
        ///Grade name of output time-series 1
        ///</summary>
        [ApiMember(Description="Grade name of output time-series 1")]
        public string GradeName1 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time-series 1
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time-series 1")]
        public string Qualifiers1 { get; set; }

        ///<summary>
        ///Method of output time-series 1
        ///</summary>
        [ApiMember(Description="Method of output time-series 1")]
        public string Method1 { get; set; }

        ///<summary>
        ///Approval level of output time-series 1
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time-series 1", Format="int64")]
        public long? ApprovalLevel1 { get; set; }

        ///<summary>
        ///Approval name of output time-series 1
        ///</summary>
        [ApiMember(Description="Approval name of output time-series 1")]
        public string ApprovalName1 { get; set; }

        ///<summary>
        ///Numeric value of output time-series 2
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time-series 2", Format="double")]
        public double? NumericValue2 { get; set; }

        ///<summary>
        ///Display value of output time-series 2
        ///</summary>
        [ApiMember(Description="Display value of output time-series 2")]
        public string DisplayValue2 { get; set; }

        ///<summary>
        ///Grade code of output time-series 2
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time-series 2", Format="int64")]
        public long? GradeCode2 { get; set; }

        ///<summary>
        ///Grade name of output time-series 2
        ///</summary>
        [ApiMember(Description="Grade name of output time-series 2")]
        public string GradeName2 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time-series 2
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time-series 2")]
        public string Qualifiers2 { get; set; }

        ///<summary>
        ///Method of output time-series 2
        ///</summary>
        [ApiMember(Description="Method of output time-series 2")]
        public string Method2 { get; set; }

        ///<summary>
        ///Approval level of output time-series 2
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time-series 2", Format="int64")]
        public long? ApprovalLevel2 { get; set; }

        ///<summary>
        ///Approval name of output time-series 2
        ///</summary>
        [ApiMember(Description="Approval name of output time-series 2")]
        public string ApprovalName2 { get; set; }

        ///<summary>
        ///Numeric value of output time-series 3
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time-series 3", Format="double")]
        public double? NumericValue3 { get; set; }

        ///<summary>
        ///Display value of output time-series 3
        ///</summary>
        [ApiMember(Description="Display value of output time-series 3")]
        public string DisplayValue3 { get; set; }

        ///<summary>
        ///Grade code of output time-series 3
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time-series 3", Format="int64")]
        public long? GradeCode3 { get; set; }

        ///<summary>
        ///Grade name of output time-series 3
        ///</summary>
        [ApiMember(Description="Grade name of output time-series 3")]
        public string GradeName3 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time-series 3
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time-series 3")]
        public string Qualifiers3 { get; set; }

        ///<summary>
        ///Method of output time-series 3
        ///</summary>
        [ApiMember(Description="Method of output time-series 3")]
        public string Method3 { get; set; }

        ///<summary>
        ///Approval level of output time-series 3
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time-series 3", Format="int64")]
        public long? ApprovalLevel3 { get; set; }

        ///<summary>
        ///Approval name of output time-series 3
        ///</summary>
        [ApiMember(Description="Approval name of output time-series 3")]
        public string ApprovalName3 { get; set; }

        ///<summary>
        ///Numeric value of output time-series 4
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time-series 4", Format="double")]
        public double? NumericValue4 { get; set; }

        ///<summary>
        ///Display value of output time-series 4
        ///</summary>
        [ApiMember(Description="Display value of output time-series 4")]
        public string DisplayValue4 { get; set; }

        ///<summary>
        ///Grade code of output time-series 4
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time-series 4", Format="int64")]
        public long? GradeCode4 { get; set; }

        ///<summary>
        ///Grade name of output time-series 4
        ///</summary>
        [ApiMember(Description="Grade name of output time-series 4")]
        public string GradeName4 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time-series 4
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time-series 4")]
        public string Qualifiers4 { get; set; }

        ///<summary>
        ///Method of output time-series 4
        ///</summary>
        [ApiMember(Description="Method of output time-series 4")]
        public string Method4 { get; set; }

        ///<summary>
        ///Approval level of output time-series 4
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time-series 4", Format="int64")]
        public long? ApprovalLevel4 { get; set; }

        ///<summary>
        ///Approval name of output time-series 4
        ///</summary>
        [ApiMember(Description="Approval name of output time-series 4")]
        public string ApprovalName4 { get; set; }

        ///<summary>
        ///Numeric value of output time-series 5
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time-series 5", Format="double")]
        public double? NumericValue5 { get; set; }

        ///<summary>
        ///Display value of output time-series 5
        ///</summary>
        [ApiMember(Description="Display value of output time-series 5")]
        public string DisplayValue5 { get; set; }

        ///<summary>
        ///Grade code of output time-series 5
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time-series 5", Format="int64")]
        public long? GradeCode5 { get; set; }

        ///<summary>
        ///Grade name of output time-series 5
        ///</summary>
        [ApiMember(Description="Grade name of output time-series 5")]
        public string GradeName5 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time-series 5
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time-series 5")]
        public string Qualifiers5 { get; set; }

        ///<summary>
        ///Method of output time-series 5
        ///</summary>
        [ApiMember(Description="Method of output time-series 5")]
        public string Method5 { get; set; }

        ///<summary>
        ///Approval level of output time-series 5
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time-series 5", Format="int64")]
        public long? ApprovalLevel5 { get; set; }

        ///<summary>
        ///Approval name of output time-series 5
        ///</summary>
        [ApiMember(Description="Approval name of output time-series 5")]
        public string ApprovalName5 { get; set; }

        ///<summary>
        ///Numeric value of output time-series 6
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time-series 6", Format="double")]
        public double? NumericValue6 { get; set; }

        ///<summary>
        ///Display value of output time-series 6
        ///</summary>
        [ApiMember(Description="Display value of output time-series 6")]
        public string DisplayValue6 { get; set; }

        ///<summary>
        ///Grade code of output time-series 6
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time-series 6", Format="int64")]
        public long? GradeCode6 { get; set; }

        ///<summary>
        ///Grade name of output time-series 6
        ///</summary>
        [ApiMember(Description="Grade name of output time-series 6")]
        public string GradeName6 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time-series 6
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time-series 6")]
        public string Qualifiers6 { get; set; }

        ///<summary>
        ///Method of output time-series 6
        ///</summary>
        [ApiMember(Description="Method of output time-series 6")]
        public string Method6 { get; set; }

        ///<summary>
        ///Approval level of output time-series 6
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time-series 6", Format="int64")]
        public long? ApprovalLevel6 { get; set; }

        ///<summary>
        ///Approval name of output time-series 6
        ///</summary>
        [ApiMember(Description="Approval name of output time-series 6")]
        public string ApprovalName6 { get; set; }

        ///<summary>
        ///Numeric value of output time-series 7
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time-series 7", Format="double")]
        public double? NumericValue7 { get; set; }

        ///<summary>
        ///Display value of output time-series 7
        ///</summary>
        [ApiMember(Description="Display value of output time-series 7")]
        public string DisplayValue7 { get; set; }

        ///<summary>
        ///Grade code of output time-series 7
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time-series 7", Format="int64")]
        public long? GradeCode7 { get; set; }

        ///<summary>
        ///Grade name of output time-series 7
        ///</summary>
        [ApiMember(Description="Grade name of output time-series 7")]
        public string GradeName7 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time-series 7
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time-series 7")]
        public string Qualifiers7 { get; set; }

        ///<summary>
        ///Method of output time-series 7
        ///</summary>
        [ApiMember(Description="Method of output time-series 7")]
        public string Method7 { get; set; }

        ///<summary>
        ///Approval level of output time-series 7
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time-series 7", Format="int64")]
        public long? ApprovalLevel7 { get; set; }

        ///<summary>
        ///Approval name of output time-series 7
        ///</summary>
        [ApiMember(Description="Approval name of output time-series 7")]
        public string ApprovalName7 { get; set; }

        ///<summary>
        ///Numeric value of output time-series 8
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time-series 8", Format="double")]
        public double? NumericValue8 { get; set; }

        ///<summary>
        ///Display value of output time-series 8
        ///</summary>
        [ApiMember(Description="Display value of output time-series 8")]
        public string DisplayValue8 { get; set; }

        ///<summary>
        ///Grade code of output time-series 8
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time-series 8", Format="int64")]
        public long? GradeCode8 { get; set; }

        ///<summary>
        ///Grade name of output time-series 8
        ///</summary>
        [ApiMember(Description="Grade name of output time-series 8")]
        public string GradeName8 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time-series 8
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time-series 8")]
        public string Qualifiers8 { get; set; }

        ///<summary>
        ///Method of output time-series 8
        ///</summary>
        [ApiMember(Description="Method of output time-series 8")]
        public string Method8 { get; set; }

        ///<summary>
        ///Approval level of output time-series 8
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time-series 8", Format="int64")]
        public long? ApprovalLevel8 { get; set; }

        ///<summary>
        ///Approval name of output time-series 8
        ///</summary>
        [ApiMember(Description="Approval name of output time-series 8")]
        public string ApprovalName8 { get; set; }

        ///<summary>
        ///Numeric value of output time-series 9
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time-series 9", Format="double")]
        public double? NumericValue9 { get; set; }

        ///<summary>
        ///Display value of output time-series 9
        ///</summary>
        [ApiMember(Description="Display value of output time-series 9")]
        public string DisplayValue9 { get; set; }

        ///<summary>
        ///Grade code of output time-series 9
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time-series 9", Format="int64")]
        public long? GradeCode9 { get; set; }

        ///<summary>
        ///Grade name of output time-series 9
        ///</summary>
        [ApiMember(Description="Grade name of output time-series 9")]
        public string GradeName9 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time-series 9
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time-series 9")]
        public string Qualifiers9 { get; set; }

        ///<summary>
        ///Method of output time-series 9
        ///</summary>
        [ApiMember(Description="Method of output time-series 9")]
        public string Method9 { get; set; }

        ///<summary>
        ///Approval level of output time-series 9
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time-series 9", Format="int64")]
        public long? ApprovalLevel9 { get; set; }

        ///<summary>
        ///Approval name of output time-series 9
        ///</summary>
        [ApiMember(Description="Approval name of output time-series 9")]
        public string ApprovalName9 { get; set; }

        ///<summary>
        ///Numeric value of output time-series 10
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time-series 10", Format="double")]
        public double? NumericValue10 { get; set; }

        ///<summary>
        ///Display value of output time-series 10
        ///</summary>
        [ApiMember(Description="Display value of output time-series 10")]
        public string DisplayValue10 { get; set; }

        ///<summary>
        ///Grade code of output time-series 10
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time-series 10", Format="int64")]
        public long? GradeCode10 { get; set; }

        ///<summary>
        ///Grade name of output time-series 10
        ///</summary>
        [ApiMember(Description="Grade name of output time-series 10")]
        public string GradeName10 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time-series 10
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time-series 10")]
        public string Qualifiers10 { get; set; }

        ///<summary>
        ///Method of output time-series 10
        ///</summary>
        [ApiMember(Description="Method of output time-series 10")]
        public string Method10 { get; set; }

        ///<summary>
        ///Approval level of output time-series 10
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time-series 10", Format="int64")]
        public long? ApprovalLevel10 { get; set; }

        ///<summary>
        ///Approval name of output time-series 10
        ///</summary>
        [ApiMember(Description="Approval name of output time-series 10")]
        public string ApprovalName10 { get; set; }
    }

    public class TimeAlignedTimeSeriesInfo
    {
        ///<summary>
        ///Unique id
        ///</summary>
        [ApiMember(DataType="string", Description="Unique id", Format="guid")]
        public Guid UniqueId { get; set; }

        ///<summary>
        ///Identifier
        ///</summary>
        [ApiMember(Description="Identifier")]
        public string Identifier { get; set; }

        ///<summary>
        ///Parameter
        ///</summary>
        [ApiMember(Description="Parameter")]
        public string Parameter { get; set; }

        ///<summary>
        ///Label
        ///</summary>
        [ApiMember(Description="Label")]
        public string Label { get; set; }

        ///<summary>
        ///Unit
        ///</summary>
        [ApiMember(Description="Unit")]
        public string Unit { get; set; }

        ///<summary>
        ///Location identifier
        ///</summary>
        [ApiMember(Description="Location identifier")]
        public string LocationIdentifier { get; set; }

        ///<summary>
        ///Interpolation type
        ///</summary>
        [ApiMember(Description="Interpolation type")]
        public string InterpolationType { get; set; }
    }

    public class TimeRange
    {
        ///<summary>
        ///Start time
        ///</summary>
        [ApiMember(DataType="string", Description="Start time", Format="date-time")]
        public DateTimeOffset StartTime { get; set; }

        ///<summary>
        ///End time
        ///</summary>
        [ApiMember(DataType="string", Description="End time", Format="date-time")]
        public DateTimeOffset EndTime { get; set; }
    }

    public class TimeSeriesDescription
    {
        ///<summary>
        ///Identifier
        ///</summary>
        [ApiMember(Description="Identifier")]
        public string Identifier { get; set; }

        ///<summary>
        ///Unique id
        ///</summary>
        [ApiMember(DataType="string", Description="Unique id", Format="guid")]
        public Guid UniqueId { get; set; }

        ///<summary>
        ///Location identifier
        ///</summary>
        [ApiMember(Description="Location identifier")]
        public string LocationIdentifier { get; set; }

        ///<summary>
        ///Parameter
        ///</summary>
        [ApiMember(Description="Parameter")]
        public string Parameter { get; set; }

        ///<summary>
        ///Parameter Id
        ///</summary>
        [ApiMember(Description="Parameter Id")]
        public string ParameterId { get; set; }

        ///<summary>
        ///Unit
        ///</summary>
        [ApiMember(Description="Unit")]
        public string Unit { get; set; }

        ///<summary>
        ///Utc offset
        ///</summary>
        [ApiMember(DataType="number", Description="Utc offset", Format="double")]
        public double UtcOffset { get; set; }

        ///<summary>
        ///Utc offset iso duration
        ///</summary>
        [ApiMember(DataType="string", Description="Utc offset iso duration", Format="offset from UTC")]
        public Offset UtcOffsetIsoDuration { get; set; }

        ///<summary>
        ///Last modified
        ///</summary>
        [ApiMember(DataType="string", Description="Last modified", Format="date-time")]
        public DateTimeOffset LastModified { get; set; }

        ///<summary>
        ///Raw start time
        ///</summary>
        [ApiMember(DataType="string", Description="Raw start time", Format="date-time")]
        public DateTimeOffset? RawStartTime { get; set; }

        ///<summary>
        ///Raw end time
        ///</summary>
        [ApiMember(DataType="string", Description="Raw end time", Format="date-time")]
        public DateTimeOffset? RawEndTime { get; set; }

        ///<summary>
        ///Corrected start time
        ///</summary>
        [ApiMember(DataType="string", Description="Corrected start time", Format="date-time")]
        public DateTimeOffset? CorrectedStartTime { get; set; }

        ///<summary>
        ///Corrected end time
        ///</summary>
        [ApiMember(DataType="string", Description="Corrected end time", Format="date-time")]
        public DateTimeOffset? CorrectedEndTime { get; set; }

        ///<summary>
        ///Time series type
        ///</summary>
        [ApiMember(Description="Time series type")]
        public string TimeSeriesType { get; set; }

        ///<summary>
        ///Label
        ///</summary>
        [ApiMember(Description="Label")]
        public string Label { get; set; }

        ///<summary>
        ///Comment
        ///</summary>
        [ApiMember(Description="Comment")]
        public string Comment { get; set; }

        ///<summary>
        ///Description
        ///</summary>
        [ApiMember(Description="Description")]
        public string Description { get; set; }

        ///<summary>
        ///Publish
        ///</summary>
        [ApiMember(DataType="boolean", Description="Publish")]
        public bool Publish { get; set; }

        ///<summary>
        ///Computation identifier
        ///</summary>
        [ApiMember(Description="Computation identifier")]
        public string ComputationIdentifier { get; set; }

        ///<summary>
        ///Computation period identifier
        ///</summary>
        [ApiMember(Description="Computation period identifier")]
        public string ComputationPeriodIdentifier { get; set; }

        ///<summary>
        ///Sub location identifier
        ///</summary>
        [ApiMember(Description="Sub location identifier")]
        public string SubLocationIdentifier { get; set; }

        ///<summary>
        ///Extended attributes
        ///</summary>
        [ApiMember(DataType="array", Description="Extended attributes")]
        public IList<ExtendedAttribute> ExtendedAttributes { get; set; }

        ///<summary>
        ///Thresholds
        ///</summary>
        [ApiMember(DataType="array", Description="Thresholds")]
        public IList<TimeSeriesThreshold> Thresholds { get; set; }
    }

    public class TimeSeriesPoint
    {
        ///<summary>
        ///Timestamp
        ///</summary>
        [ApiMember(DataType="StatisticalDateTimeOffset", Description="Timestamp")]
        public StatisticalDateTimeOffset Timestamp { get; set; }

        ///<summary>
        ///Value
        ///</summary>
        [ApiMember(DataType="DoubleWithDisplay", Description="Value")]
        public DoubleWithDisplay Value { get; set; }
    }

    public class TimeSeriesThreshold
    {
        public TimeSeriesThreshold()
        {
            Periods = new List<TimeSeriesThresholdPeriod>{};
        }

        ///<summary>
        ///Name
        ///</summary>
        [ApiMember(Description="Name")]
        public string Name { get; set; }

        ///<summary>
        ///Description
        ///</summary>
        [ApiMember(Description="Description")]
        public string Description { get; set; }

        ///<summary>
        ///Reference code
        ///</summary>
        [ApiMember(Description="Reference code")]
        public string ReferenceCode { get; set; }

        ///<summary>
        ///Severity
        ///</summary>
        [ApiMember(DataType="integer", Description="Severity", Format="int32")]
        public int Severity { get; set; }

        ///<summary>
        ///Type
        ///</summary>
        [ApiMember(DataType="string", Description="Type")]
        public ThresholdType Type { get; set; }

        ///<summary>
        ///Processing order
        ///</summary>
        [ApiMember(DataType="string", Description="Processing order")]
        public CorrectionProcessingOrder ProcessingOrder { get; set; }

        ///<summary>
        ///Display color
        ///</summary>
        [ApiMember(Description="Display color")]
        public string DisplayColor { get; set; }

        ///<summary>
        ///Periods
        ///</summary>
        [ApiMember(DataType="array", Description="Periods")]
        public List<TimeSeriesThresholdPeriod> Periods { get; set; }
    }

    public class TimeSeriesThresholdPeriod
    {
        ///<summary>
        ///Start time
        ///</summary>
        [ApiMember(DataType="string", Description="Start time", Format="date-time")]
        public DateTimeOffset StartTime { get; set; }

        ///<summary>
        ///End time
        ///</summary>
        [ApiMember(DataType="string", Description="End time", Format="date-time")]
        public DateTimeOffset EndTime { get; set; }

        ///<summary>
        ///Applied time
        ///</summary>
        [ApiMember(DataType="string", Description="Applied time", Format="date-time")]
        public DateTime AppliedTime { get; set; }

        ///<summary>
        ///Comments
        ///</summary>
        [ApiMember(Description="Comments")]
        public string Comments { get; set; }

        ///<summary>
        ///Reference value
        ///</summary>
        [ApiMember(DataType="number", Description="Reference value", Format="double")]
        public double ReferenceValue { get; set; }

        ///<summary>
        ///Secondary reference value
        ///</summary>
        [ApiMember(DataType="number", Description="Secondary reference value", Format="double")]
        public double? SecondaryReferenceValue { get; set; }

        ///<summary>
        ///Suppress data
        ///</summary>
        [ApiMember(DataType="boolean", Description="Suppress data")]
        public bool SuppressData { get; set; }
    }

    public class TimeSeriesUniqueIds
    {
        ///<summary>
        ///Unique id
        ///</summary>
        [ApiMember(DataType="string", Description="Unique id", Format="guid")]
        public Guid UniqueId { get; set; }

        ///<summary>
        ///First point changed
        ///</summary>
        [ApiMember(DataType="string", Description="First point changed", Format="date-time")]
        public DateTimeOffset? FirstPointChanged { get; set; }

        ///<summary>
        ///Has attribute change
        ///</summary>
        [ApiMember(DataType="boolean", Description="Has attribute change")]
        public bool? HasAttributeChange { get; set; }

        ///<summary>
        ///Time-series has been deleted
        ///</summary>
        [ApiMember(DataType="boolean", Description="Time-series has been deleted")]
        public bool? IsDeleted { get; set; }

        ///<summary>
        ///Last time attributes on the time-series matched the given filters; null when time-series current attributes matched the given filters
        ///</summary>
        [ApiMember(DataType="string", Description="Last time attributes on the time-series matched the given filters; null when time-series current attributes matched the given filters", Format="date-time")]
        public DateTimeOffset? LastMatchedTime { get; set; }
    }

    public class TrendLineAnalysis
    {
        ///<summary>
        ///Type of regression analysis
        ///</summary>
        [ApiMember(DataType="string", Description="Type of regression analysis")]
        public TrendLineAnalysisType Type { get; set; }

        ///<summary>
        ///Start point of period
        ///</summary>
        [ApiMember(DataType="TimeSeriesPoint", Description="Start point of period")]
        public TimeSeriesPoint StartPoint { get; set; }

        ///<summary>
        ///End point of period
        ///</summary>
        [ApiMember(DataType="TimeSeriesPoint", Description="End point of period")]
        public TimeSeriesPoint EndPoint { get; set; }

        ///<summary>
        ///Actual absolute change, as the difference between the first and last measurement values
        ///</summary>
        [ApiMember(DataType="DoubleWithDisplay", Description="Actual absolute change, as the difference between the first and last measurement values")]
        public DoubleWithDisplay ActualAbsoluteChange { get; set; }

        ///<summary>
        ///Modeled absolute change, as the difference between the first and last trend line values
        ///</summary>
        [ApiMember(DataType="DoubleWithDisplay", Description="Modeled absolute change, as the difference between the first and last trend line values")]
        public DoubleWithDisplay ModeledAbsoluteChange { get; set; }

        ///<summary>
        ///Actual percentage change, as the actual absolute change relative to the first measurement value
        ///</summary>
        [ApiMember(DataType="DoubleWithDisplay", Description="Actual percentage change, as the actual absolute change relative to the first measurement value")]
        public DoubleWithDisplay ActualPercentageChange { get; set; }

        ///<summary>
        ///Modeled percentage change, as the modeled absolute change relative to the first trend line value
        ///</summary>
        [ApiMember(DataType="DoubleWithDisplay", Description="Modeled percentage change, as the modeled absolute change relative to the first trend line value")]
        public DoubleWithDisplay ModeledPercentageChange { get; set; }

        ///<summary>
        ///Minimum value
        ///</summary>
        [ApiMember(DataType="DoubleWithDisplay", Description="Minimum value")]
        public DoubleWithDisplay MinValue { get; set; }

        ///<summary>
        ///Maximum value
        ///</summary>
        [ApiMember(DataType="DoubleWithDisplay", Description="Maximum value")]
        public DoubleWithDisplay MaxValue { get; set; }

        ///<summary>
        ///Lower Quartile (Q1) of residuals
        ///</summary>
        [ApiMember(DataType="DoubleWithDisplay", Description="Lower Quartile (Q1) of residuals")]
        public DoubleWithDisplay LowerQuartileOfResiduals { get; set; }

        ///<summary>
        ///Median (Q2) of residuals
        ///</summary>
        [ApiMember(DataType="DoubleWithDisplay", Description="Median (Q2) of residuals")]
        public DoubleWithDisplay MedianOfResiduals { get; set; }

        ///<summary>
        ///Upper Quartile (Q3) of residuals
        ///</summary>
        [ApiMember(DataType="DoubleWithDisplay", Description="Upper Quartile (Q3) of residuals")]
        public DoubleWithDisplay UpperQuartileOfResiduals { get; set; }

        ///<summary>
        ///Trend line slope measured in data units per year
        ///</summary>
        [ApiMember(DataType="DoubleWithDisplay", Description="Trend line slope measured in data units per year")]
        public DoubleWithDisplay Slope { get; set; }

        ///<summary>
        ///Trend line intercept, as the value of the trend line at the time of QueryFrom
        ///</summary>
        [ApiMember(DataType="DoubleWithDisplay", Description="Trend line intercept, as the value of the trend line at the time of QueryFrom")]
        public DoubleWithDisplay Intercept { get; set; }

        ///<summary>
        ///Standard error in trend line slope
        ///</summary>
        [ApiMember(DataType="DoubleWithDisplay", Description="Standard error in trend line slope")]
        public DoubleWithDisplay SlopeStandardError { get; set; }

        ///<summary>
        ///Standard deviation of results
        ///</summary>
        [ApiMember(DataType="DoubleWithDisplay", Description="Standard deviation of results")]
        public DoubleWithDisplay StandardDeviation { get; set; }

        ///<summary>
        ///Trend line correlation coefficient
        ///</summary>
        [ApiMember(DataType="DoubleWithDisplay", Description="Trend line correlation coefficient")]
        public DoubleWithDisplay CorrelationCoefficient { get; set; }
    }

    public enum TrendLineAnalysisType
    {
        Linear,
    }

    public class UnitMetadata
    {
        ///<summary>
        ///UniqueId
        ///</summary>
        [ApiMember(DataType="string", Description="UniqueId", Format="guid")]
        public Guid UniqueId { get; set; }

        ///<summary>
        ///Identifier
        ///</summary>
        [ApiMember(Description="Identifier")]
        public string Identifier { get; set; }

        ///<summary>
        ///Group identifier
        ///</summary>
        [ApiMember(Description="Group identifier")]
        public string GroupIdentifier { get; set; }

        ///<summary>
        ///Symbol
        ///</summary>
        [ApiMember(Description="Symbol")]
        public string Symbol { get; set; }

        ///<summary>
        ///Display name
        ///</summary>
        [ApiMember(Description="Display name")]
        public string DisplayName { get; set; }

        ///<summary>
        ///Base multiplier
        ///</summary>
        [ApiMember(Description="Base multiplier")]
        public string BaseMultiplier { get; set; }

        ///<summary>
        ///Base offset
        ///</summary>
        [ApiMember(Description="Base offset")]
        public string BaseOffset { get; set; }
    }

    public class AdcpDischargeActivity
    {
        ///<summary>
        ///Discharge channel measurement
        ///</summary>
        [ApiMember(DataType="DischargeChannelMeasurement", Description="Discharge channel measurement")]
        public DischargeChannelMeasurement DischargeChannelMeasurement { get; set; }

        ///<summary>
        ///Is valid
        ///</summary>
        [ApiMember(DataType="boolean", Description="Is valid")]
        public bool IsValid { get; set; }

        ///<summary>
        ///Number of transects
        ///</summary>
        [ApiMember(DataType="integer", Description="Number of transects", Format="int32")]
        public int? NumberOfTransects { get; set; }

        ///<summary>
        ///Magnetic variation
        ///</summary>
        [ApiMember(DataType="DoubleWithDisplay", Description="Magnetic variation")]
        public DoubleWithDisplay MagneticVariation { get; set; }

        ///<summary>
        ///Discharge coefficient variation
        ///</summary>
        [ApiMember(DataType="DoubleWithDisplay", Description="Discharge coefficient variation")]
        public DoubleWithDisplay DischargeCoefficientVariation { get; set; }

        ///<summary>
        ///Percent of discharge measured
        ///</summary>
        [ApiMember(DataType="DoubleWithDisplay", Description="Percent of discharge measured")]
        public DoubleWithDisplay PercentOfDischargeMeasured { get; set; }

        ///<summary>
        ///Top estimate exponent
        ///</summary>
        [ApiMember(DataType="DoubleWithDisplay", Description="Top estimate exponent")]
        public DoubleWithDisplay TopEstimateExponent { get; set; }

        ///<summary>
        ///Bottom estimate exponent
        ///</summary>
        [ApiMember(DataType="DoubleWithDisplay", Description="Bottom estimate exponent")]
        public DoubleWithDisplay BottomEstimateExponent { get; set; }

        ///<summary>
        ///Width
        ///</summary>
        [ApiMember(DataType="QuantityWithDisplay", Description="Width")]
        public QuantityWithDisplay Width { get; set; }

        ///<summary>
        ///Area
        ///</summary>
        [ApiMember(DataType="QuantityWithDisplay", Description="Area")]
        public QuantityWithDisplay Area { get; set; }

        ///<summary>
        ///Velocity average
        ///</summary>
        [ApiMember(DataType="QuantityWithDisplay", Description="Velocity average")]
        public QuantityWithDisplay VelocityAverage { get; set; }

        ///<summary>
        ///Transducer depth
        ///</summary>
        [ApiMember(DataType="QuantityWithDisplay", Description="Transducer depth")]
        public QuantityWithDisplay TransducerDepth { get; set; }

        ///<summary>
        ///Adcp device type
        ///</summary>
        [ApiMember(Description="Adcp device type")]
        public string AdcpDeviceType { get; set; }

        ///<summary>
        ///Manufacturer
        ///</summary>
        [ApiMember(Description="Manufacturer")]
        public string Manufacturer { get; set; }

        ///<summary>
        ///Model
        ///</summary>
        [ApiMember(Description="Model")]
        public string Model { get; set; }

        ///<summary>
        ///Serial number
        ///</summary>
        [ApiMember(Description="Serial number")]
        public string SerialNumber { get; set; }

        ///<summary>
        ///Navigation method
        ///</summary>
        [ApiMember(Description="Navigation method")]
        public string NavigationMethod { get; set; }

        ///<summary>
        ///Firmware version
        ///</summary>
        [ApiMember(Description="Firmware version")]
        public string FirmwareVersion { get; set; }

        ///<summary>
        ///Software version
        ///</summary>
        [ApiMember(Description="Software version")]
        public string SoftwareVersion { get; set; }

        ///<summary>
        ///Top estimate method
        ///</summary>
        [ApiMember(Description="Top estimate method")]
        public string TopEstimateMethod { get; set; }

        ///<summary>
        ///Bottom estimate method
        ///</summary>
        [ApiMember(Description="Bottom estimate method")]
        public string BottomEstimateMethod { get; set; }

        ///<summary>
        ///Depth reference
        ///</summary>
        [ApiMember(Description="Depth reference")]
        public string DepthReference { get; set; }

        ///<summary>
        ///Node details
        ///</summary>
        [ApiMember(Description="Node details")]
        public string NodeDetails { get; set; }
    }

    public class Adjustment
    {
        ///<summary>
        ///Adjustment amount
        ///</summary>
        [ApiMember(DataType="number", Description="Adjustment amount", Format="double")]
        public double? AdjustmentAmount { get; set; }

        ///<summary>
        ///Adjustment type
        ///</summary>
        [ApiMember(DataType="string", Description="Adjustment type")]
        public AdjustmentType AdjustmentType { get; set; }

        ///<summary>
        ///Reason for adjustment
        ///</summary>
        [ApiMember(DataType="string", Description="Reason for adjustment")]
        public ReasonForAdjustmentType ReasonForAdjustment { get; set; }
    }

    public class Attachment
    {
        public Attachment()
        {
            Tags = new List<TagMetadata>{};
        }

        ///<summary>
        ///Attachment type
        ///</summary>
        [ApiMember(DataType="string", Description="Attachment type")]
        public AttachmentType AttachmentType { get; set; }

        ///<summary>
        ///Attachment category
        ///</summary>
        [ApiMember(DataType="AttachmentCategory", Description="Attachment category")]
        public AttachmentCategory AttachmentCategory { get; set; }

        ///<summary>
        ///File name
        ///</summary>
        [ApiMember(Description="File name")]
        public string FileName { get; set; }

        ///<summary>
        ///Unique ID of the attachment
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the attachment", Format="guid")]
        public Guid UniqueId { get; set; }

        ///<summary>
        ///Date created
        ///</summary>
        [ApiMember(DataType="string", Description="Date created", Format="date-time")]
        public DateTimeOffset DateCreated { get; set; }

        ///<summary>
        ///Date uploaded
        ///</summary>
        [ApiMember(DataType="string", Description="Date uploaded", Format="date-time")]
        public DateTimeOffset DateUploaded { get; set; }

        ///<summary>
        ///Date last accessed
        ///</summary>
        [ApiMember(DataType="string", Description="Date last accessed", Format="date-time")]
        public DateTimeOffset? DateLastAccessed { get; set; }

        ///<summary>
        ///Uploaded by user
        ///</summary>
        [ApiMember(Description="Uploaded by user")]
        public string UploadedByUser { get; set; }

        ///<summary>
        ///Comment
        ///</summary>
        [ApiMember(Description="Comment")]
        public string Comment { get; set; }

        ///<summary>
        ///Gps latitude
        ///</summary>
        [ApiMember(DataType="number", Description="Gps latitude", Format="double")]
        public double? GpsLatitude { get; set; }

        ///<summary>
        ///Gps longitude
        ///</summary>
        [ApiMember(DataType="number", Description="Gps longitude", Format="double")]
        public double? GpsLongitude { get; set; }

        ///<summary>
        ///Url
        ///</summary>
        [ApiMember(Description="Url")]
        public string Url { get; set; }

        ///<summary>
        ///Tags
        ///</summary>
        [ApiMember(DataType="array", Description="Tags")]
        public List<TagMetadata> Tags { get; set; }
    }

    public class Calibration
    {
        ///<summary>
        ///Range start
        ///</summary>
        [ApiMember(DataType="number", Description="Range start", Format="double")]
        public double? RangeStart { get; set; }

        ///<summary>
        ///Range end
        ///</summary>
        [ApiMember(DataType="number", Description="Range end", Format="double")]
        public double? RangeEnd { get; set; }

        ///<summary>
        ///Slope
        ///</summary>
        [ApiMember(DataType="number", Description="Slope", Format="double")]
        public double Slope { get; set; }

        ///<summary>
        ///Intercept
        ///</summary>
        [ApiMember(DataType="number", Description="Intercept", Format="double")]
        public double Intercept { get; set; }

        ///<summary>
        ///Intercept unit
        ///</summary>
        [ApiMember(Description="Intercept unit")]
        public string InterceptUnit { get; set; }
    }

    public class CalibrationCheck
    {
        ///<summary>
        ///Parameter Name
        ///</summary>
        [ApiMember(Description="Parameter Name")]
        public string Parameter { get; set; }

        ///<summary>
        ///Parameter Id
        ///</summary>
        [ApiMember(Description="Parameter Id")]
        public string ParameterId { get; set; }

        ///<summary>
        ///Standard
        ///</summary>
        [ApiMember(DataType="DoubleWithDisplay", Description="Standard")]
        public DoubleWithDisplay Standard { get; set; }

        ///<summary>
        ///Standard details
        ///</summary>
        [ApiMember(DataType="StandardDetails", Description="Standard details")]
        public StandardDetails StandardDetails { get; set; }

        ///<summary>
        ///Monitoring method
        ///</summary>
        [ApiMember(Description="Monitoring method")]
        public string MonitoringMethod { get; set; }

        ///<summary>
        ///Value
        ///</summary>
        [ApiMember(DataType="DoubleWithDisplay", Description="Value")]
        public DoubleWithDisplay Value { get; set; }

        ///<summary>
        ///Difference
        ///</summary>
        [ApiMember(DataType="DoubleWithDisplay", Description="Difference")]
        public DoubleWithDisplay Difference { get; set; }

        ///<summary>
        ///Percent difference
        ///</summary>
        [ApiMember(DataType="DoubleWithDisplay", Description="Percent difference")]
        public DoubleWithDisplay PercentDifference { get; set; }

        ///<summary>
        ///Unit
        ///</summary>
        [ApiMember(Description="Unit")]
        public string Unit { get; set; }

        ///<summary>
        ///Calibration check type
        ///</summary>
        [ApiMember(DataType="string", Description="Calibration check type")]
        public CalibrationCheckType CalibrationCheckType { get; set; }

        ///<summary>
        ///Manufacturer
        ///</summary>
        [ApiMember(Description="Manufacturer")]
        public string Manufacturer { get; set; }

        ///<summary>
        ///Model
        ///</summary>
        [ApiMember(Description="Model")]
        public string Model { get; set; }

        ///<summary>
        ///Serial number
        ///</summary>
        [ApiMember(Description="Serial number")]
        public string SerialNumber { get; set; }

        ///<summary>
        ///Time
        ///</summary>
        [ApiMember(DataType="string", Description="Time", Format="date-time")]
        public DateTimeOffset? Time { get; set; }

        ///<summary>
        ///Sub location identifier
        ///</summary>
        [ApiMember(Description="Sub location identifier")]
        public string SubLocationIdentifier { get; set; }

        ///<summary>
        ///Comments
        ///</summary>
        [ApiMember(Description="Comments")]
        public string Comments { get; set; }

        ///<summary>
        ///Node details
        ///</summary>
        [ApiMember(Description="Node details")]
        public string NodeDetails { get; set; }

        ///<summary>
        ///Publish
        ///</summary>
        [ApiMember(DataType="boolean", Description="Publish")]
        public bool Publish { get; set; }

        ///<summary>
        ///Is valid
        ///</summary>
        [ApiMember(DataType="boolean", Description="Is valid")]
        public bool IsValid { get; set; }

        ///<summary>
        ///Sensor unique ID
        ///</summary>
        [ApiMember(DataType="string", Description="Sensor unique ID", Format="guid")]
        public Guid? SensorUniqueId { get; set; }
    }

    public class CompletedWork
    {
        ///<summary>
        ///Collection agency
        ///</summary>
        [ApiMember(Description="Collection agency")]
        public string CollectionAgency { get; set; }

        ///<summary>
        ///Biological sample taken
        ///</summary>
        [ApiMember(DataType="boolean", Description="Biological sample taken")]
        public bool BiologicalSampleTaken { get; set; }

        ///<summary>
        ///Ground water level performed
        ///</summary>
        [ApiMember(DataType="boolean", Description="Ground water level performed")]
        public bool GroundWaterLevelPerformed { get; set; }

        ///<summary>
        ///Levels performed
        ///</summary>
        [ApiMember(DataType="boolean", Description="Levels performed")]
        public bool LevelsPerformed { get; set; }

        ///<summary>
        ///Other sample taken
        ///</summary>
        [ApiMember(DataType="boolean", Description="Other sample taken")]
        public bool OtherSampleTaken { get; set; }

        ///<summary>
        ///Recorder data collected
        ///</summary>
        [ApiMember(DataType="boolean", Description="Recorder data collected")]
        public bool RecorderDataCollected { get; set; }

        ///<summary>
        ///Sediment sample taken
        ///</summary>
        [ApiMember(DataType="boolean", Description="Sediment sample taken")]
        public bool SedimentSampleTaken { get; set; }

        ///<summary>
        ///Safety inspection performed
        ///</summary>
        [ApiMember(DataType="boolean", Description="Safety inspection performed")]
        public bool SafetyInspectionPerformed { get; set; }

        ///<summary>
        ///Water quality sample taken
        ///</summary>
        [ApiMember(DataType="boolean", Description="Water quality sample taken")]
        public bool WaterQualitySampleTaken { get; set; }

        ///<summary>
        ///Water quality cross-section performed
        ///</summary>
        [ApiMember(DataType="boolean", Description="Water quality cross-section performed")]
        public bool WaterQualityCrossSectionPerformed { get; set; }
    }

    public class ControlConditionActivity
    {
        ///<summary>
        ///Control code
        ///</summary>
        [ApiMember(Description="Control code")]
        public string ControlCode { get; set; }

        ///<summary>
        ///Flow over control
        ///</summary>
        [ApiMember(Description="Flow over control")]
        public string FlowOverControl { get; set; }

        ///<summary>
        ///Control cleaned
        ///</summary>
        [ApiMember(DataType="string", Description="Control cleaned")]
        public ControlCleanedType ControlCleaned { get; set; }

        ///<summary>
        ///Control condition
        ///</summary>
        [ApiMember(Description="Control condition")]
        public string ControlCondition { get; set; }

        ///<summary>
        ///Date cleaned
        ///</summary>
        [ApiMember(DataType="string", Description="Date cleaned", Format="date-time")]
        public DateTimeOffset? DateCleaned { get; set; }

        ///<summary>
        ///Distance to gage
        ///</summary>
        [ApiMember(DataType="QuantityWithDisplay", Description="Distance to gage")]
        public QuantityWithDisplay DistanceToGage { get; set; }

        ///<summary>
        ///Comments
        ///</summary>
        [ApiMember(Description="Comments")]
        public string Comments { get; set; }

        ///<summary>
        ///Party
        ///</summary>
        [ApiMember(Description="Party")]
        public string Party { get; set; }

        ///<summary>
        ///Is valid
        ///</summary>
        [ApiMember(DataType="boolean", Description="Is valid")]
        public bool IsValid { get; set; }
    }

    public class CrossSectionPoint
    {
        ///<summary>
        ///Point order
        ///</summary>
        [ApiMember(DataType="integer", Description="Point order", Format="int32")]
        public int PointOrder { get; set; }

        ///<summary>
        ///Distance
        ///</summary>
        [ApiMember(DataType="QuantityWithDisplay", Description="Distance")]
        public QuantityWithDisplay Distance { get; set; }

        ///<summary>
        ///Elevation
        ///</summary>
        [ApiMember(DataType="QuantityWithDisplay", Description="Elevation")]
        public QuantityWithDisplay Elevation { get; set; }

        ///<summary>
        ///Depth
        ///</summary>
        [ApiMember(DataType="QuantityWithDisplay", Description="Depth")]
        public QuantityWithDisplay Depth { get; set; }

        ///<summary>
        ///Comments
        ///</summary>
        [ApiMember(Description="Comments")]
        public string Comments { get; set; }
    }

    public class CrossSectionSurveyActivity
    {
        public CrossSectionSurveyActivity()
        {
            CrossSectionPoints = new List<CrossSectionPoint>{};
        }

        ///<summary>
        ///Start time
        ///</summary>
        [ApiMember(DataType="string", Description="Start time", Format="date-time")]
        public DateTimeOffset StartTime { get; set; }

        ///<summary>
        ///End time
        ///</summary>
        [ApiMember(DataType="string", Description="End time", Format="date-time")]
        public DateTimeOffset EndTime { get; set; }

        ///<summary>
        ///Party
        ///</summary>
        [ApiMember(Description="Party")]
        public string Party { get; set; }

        ///<summary>
        ///Channel
        ///</summary>
        [ApiMember(Description="Channel")]
        public string Channel { get; set; }

        ///<summary>
        ///Relative location
        ///</summary>
        [ApiMember(Description="Relative location")]
        public string RelativeLocation { get; set; }

        ///<summary>
        ///Starting point
        ///</summary>
        [ApiMember(DataType="string", Description="Starting point")]
        public StartPointType StartingPoint { get; set; }

        ///<summary>
        ///Stage
        ///</summary>
        [ApiMember(DataType="QuantityWithDisplay", Description="Stage")]
        public QuantityWithDisplay Stage { get; set; }

        ///<summary>
        ///Comments
        ///</summary>
        [ApiMember(Description="Comments")]
        public string Comments { get; set; }

        ///<summary>
        ///Cross-section points
        ///</summary>
        [ApiMember(DataType="array", Description="Cross-section points")]
        public List<CrossSectionPoint> CrossSectionPoints { get; set; }
    }

    public class CurrentMeter
    {
        ///<summary>
        ///Serial number
        ///</summary>
        [ApiMember(Description="Serial number")]
        public string SerialNumber { get; set; }

        ///<summary>
        ///Model
        ///</summary>
        [ApiMember(Description="Model")]
        public string Model { get; set; }

        ///<summary>
        ///Manufacturer
        ///</summary>
        [ApiMember(Description="Manufacturer")]
        public string Manufacturer { get; set; }
    }

    public class DatumConversionResult
    {
        ///<summary>
        ///True if values are converted to the target reference datum
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if values are converted to the target reference datum")]
        public bool ValuesConverted { get; set; }

        ///<summary>
        ///The reason, if any, that values could not be converted to the target reference datum
        ///</summary>
        [ApiMember(Description="The reason, if any, that values could not be converted to the target reference datum")]
        public string FailureReason { get; set; }

        ///<summary>
        ///Target reference datum
        ///</summary>
        [ApiMember(Description="Target reference datum")]
        public string TargetDatum { get; set; }
    }

    public class DatumConvertedQuantityWithDisplay
        : QuantityWithDisplay
    {
        ///<summary>
        ///Target reference datum
        ///</summary>
        [ApiMember(Description="Target reference datum")]
        public string TargetDatum { get; set; }
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

        ///<summary>
        ///Discharge summary
        ///</summary>
        [ApiMember(DataType="DischargeSummary", Description="Discharge summary")]
        public DischargeSummary DischargeSummary { get; set; }

        ///<summary>
        ///Volumetric discharge activities
        ///</summary>
        [ApiMember(DataType="array", Description="Volumetric discharge activities")]
        public List<VolumetricDischargeActivity> VolumetricDischargeActivities { get; set; }

        ///<summary>
        ///Engineered structure discharge activities
        ///</summary>
        [ApiMember(DataType="array", Description="Engineered structure discharge activities")]
        public List<EngineeredStructureDischargeActivity> EngineeredStructureDischargeActivities { get; set; }

        ///<summary>
        ///Point velocity discharge activities
        ///</summary>
        [ApiMember(DataType="array", Description="Point velocity discharge activities")]
        public List<PointVelocityDischargeActivity> PointVelocityDischargeActivities { get; set; }

        ///<summary>
        ///Other method discharge activities
        ///</summary>
        [ApiMember(DataType="array", Description="Other method discharge activities")]
        public List<OtherMethodDischargeActivity> OtherMethodDischargeActivities { get; set; }

        ///<summary>
        ///Adcp discharge activities
        ///</summary>
        [ApiMember(DataType="array", Description="Adcp discharge activities")]
        public List<AdcpDischargeActivity> AdcpDischargeActivities { get; set; }
    }

    public class DischargeChannelMeasurement
    {
        ///<summary>
        ///Channel
        ///</summary>
        [ApiMember(Description="Channel")]
        public string Channel { get; set; }

        ///<summary>
        ///Start time
        ///</summary>
        [ApiMember(DataType="string", Description="Start time", Format="date-time")]
        public DateTimeOffset? StartTime { get; set; }

        ///<summary>
        ///End time
        ///</summary>
        [ApiMember(DataType="string", Description="End time", Format="date-time")]
        public DateTimeOffset? EndTime { get; set; }

        ///<summary>
        ///Discharge
        ///</summary>
        [ApiMember(DataType="QuantityWithDisplay", Description="Discharge")]
        public QuantityWithDisplay Discharge { get; set; }

        ///<summary>
        ///Comments
        ///</summary>
        [ApiMember(Description="Comments")]
        public string Comments { get; set; }

        ///<summary>
        ///Party
        ///</summary>
        [ApiMember(Description="Party")]
        public string Party { get; set; }

        ///<summary>
        ///Distance to gage
        ///</summary>
        [ApiMember(DataType="QuantityWithDisplay", Description="Distance to gage")]
        public QuantityWithDisplay DistanceToGage { get; set; }

        ///<summary>
        ///Horizontal flow
        ///</summary>
        [ApiMember(DataType="string", Description="Horizontal flow")]
        public HorizontalFlowType HorizontalFlow { get; set; }

        ///<summary>
        ///Channel stability
        ///</summary>
        [ApiMember(DataType="string", Description="Channel stability")]
        public ChannelStabilityType ChannelStability { get; set; }

        ///<summary>
        ///Channel material
        ///</summary>
        [ApiMember(DataType="string", Description="Channel material")]
        public ChannelMaterialType ChannelMaterial { get; set; }

        ///<summary>
        ///Channel evenness
        ///</summary>
        [ApiMember(DataType="string", Description="Channel evenness")]
        public ChannelEvennessType ChannelEvenness { get; set; }

        ///<summary>
        ///Vertical velocity distribution
        ///</summary>
        [ApiMember(DataType="string", Description="Vertical velocity distribution")]
        public VerticalVelocityDistributionType VerticalVelocityDistribution { get; set; }

        ///<summary>
        ///Velocity variation
        ///</summary>
        [ApiMember(DataType="string", Description="Velocity variation")]
        public VelocityVariationType VelocityVariation { get; set; }

        ///<summary>
        ///Measurement location to gage
        ///</summary>
        [ApiMember(DataType="string", Description="Measurement location to gage")]
        public MeasurementLocationToGageType MeasurementLocationToGage { get; set; }

        ///<summary>
        ///Meter suspension
        ///</summary>
        [ApiMember(DataType="string", Description="Meter suspension")]
        public MeterSuspensionType MeterSuspension { get; set; }

        ///<summary>
        ///Deployment method
        ///</summary>
        [ApiMember(DataType="string", Description="Deployment method")]
        public DeploymentMethodType DeploymentMethod { get; set; }

        ///<summary>
        ///Current meter
        ///</summary>
        [ApiMember(DataType="string", Description="Current meter")]
        public CurrentMeterType CurrentMeter { get; set; }

        ///<summary>
        ///Monitoring method
        ///</summary>
        [ApiMember(Description="Monitoring method")]
        public string MonitoringMethod { get; set; }
    }

    public class DischargeSummary
    {
        public DischargeSummary()
        {
            GageHeightReadings = new List<GageHeightReading>{};
        }

        ///<summary>
        ///Measurement start time
        ///</summary>
        [ApiMember(DataType="string", Description="Measurement start time", Format="date-time")]
        public DateTimeOffset? MeasurementStartTime { get; set; }

        ///<summary>
        ///Measurement end time
        ///</summary>
        [ApiMember(DataType="string", Description="Measurement end time", Format="date-time")]
        public DateTimeOffset? MeasurementEndTime { get; set; }

        ///<summary>
        ///Measurement time
        ///</summary>
        [ApiMember(DataType="string", Description="Measurement time", Format="date-time")]
        public DateTimeOffset MeasurementTime { get; set; }

        ///<summary>
        ///Party
        ///</summary>
        [ApiMember(Description="Party")]
        public string Party { get; set; }

        ///<summary>
        ///Base flow
        ///</summary>
        [ApiMember(DataType="string", Description="Base flow")]
        public BaseFlowType BaseFlow { get; set; }

        ///<summary>
        ///Adjustment
        ///</summary>
        [ApiMember(DataType="Adjustment", Description="Adjustment")]
        public Adjustment Adjustment { get; set; }

        ///<summary>
        ///Alternate rating discharge
        ///</summary>
        [ApiMember(DataType="QuantityWithDisplay", Description="Alternate rating discharge")]
        public QuantityWithDisplay AlternateRatingDischarge { get; set; }

        ///<summary>
        ///Discharge
        ///</summary>
        [ApiMember(DataType="QuantityWithDisplay", Description="Discharge")]
        public QuantityWithDisplay Discharge { get; set; }

        ///<summary>
        ///Discharge method
        ///</summary>
        [ApiMember(Description="Discharge method")]
        public string DischargeMethod { get; set; }

        ///<summary>
        ///Mean gage height
        ///</summary>
        [ApiMember(DataType="QuantityWithDisplay", Description="Mean gage height")]
        public QuantityWithDisplay MeanGageHeight { get; set; }

        ///<summary>
        ///Gage height adjustment amount
        ///</summary>
        [ApiMember(DataType="QuantityWithDisplay", Description="Gage height adjustment amount")]
        public QuantityWithDisplay GageHeightAdjustmentAmount { get; set; }

        ///<summary>
        ///True if the mean gage height was converted to the target datum
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if the mean gage height was converted to the target datum")]
        public bool? MeanGageHeightWasDatumConverted { get; set; }

        ///<summary>
        ///Mean gage height method
        ///</summary>
        [ApiMember(Description="Mean gage height method")]
        public string MeanGageHeightMethod { get; set; }

        ///<summary>
        ///Mean index velocity
        ///</summary>
        [ApiMember(DataType="QuantityWithDisplay", Description="Mean index velocity")]
        public QuantityWithDisplay MeanIndexVelocity { get; set; }

        ///<summary>
        ///Discharge measurement reason
        ///</summary>
        [ApiMember(DataType="string", Description="Discharge measurement reason")]
        public DischargeMeasurementReasonType DischargeMeasurementReason { get; set; }

        ///<summary>
        ///Comments
        ///</summary>
        [ApiMember(Description="Comments")]
        public string Comments { get; set; }

        ///<summary>
        ///Gage height comments
        ///</summary>
        [ApiMember(Description="Gage height comments")]
        public string GageHeightComments { get; set; }

        ///<summary>
        ///Gage height calculation
        ///</summary>
        [ApiMember(DataType="string", Description="Gage height calculation")]
        public GageHeightCalculationType GageHeightCalculation { get; set; }

        ///<summary>
        ///Gage height readings
        ///</summary>
        [ApiMember(DataType="array", Description="Gage height readings")]
        public List<GageHeightReading> GageHeightReadings { get; set; }

        ///<summary>
        ///Difference during visit
        ///</summary>
        [ApiMember(DataType="DoubleWithDisplay", Description="Difference during visit")]
        public DoubleWithDisplay DifferenceDuringVisit { get; set; }

        ///<summary>
        ///Duration in hours
        ///</summary>
        [ApiMember(DataType="DoubleWithDisplay", Description="Duration in hours")]
        public DoubleWithDisplay DurationInHours { get; set; }

        ///<summary>
        ///Quality Assurance Comments
        ///</summary>
        [ApiMember(Description="Quality Assurance Comments")]
        public string QualityAssuranceComments { get; set; }

        ///<summary>
        ///Discharge Uncertainty
        ///</summary>
        [ApiMember(DataType="DischargeUncertainty", Description="Discharge Uncertainty")]
        public DischargeUncertainty DischargeUncertainty { get; set; }

        ///<summary>
        ///DEPRECATED: Use DischargeUncertainty.QualitativeUncertainty instead.
        ///</summary>
        [ApiMember(DataType="string", Description="DEPRECATED: Use DischargeUncertainty.QualitativeUncertainty instead.")]
        public MeasurementGradeType MeasurementGrade { get; set; }

        ///<summary>
        ///Grade code
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code", Format="int32")]
        public int? GradeCode { get; set; }

        ///<summary>
        ///Measurement id
        ///</summary>
        [ApiMember(Description="Measurement id")]
        public string MeasurementId { get; set; }

        ///<summary>
        ///Reviewer
        ///</summary>
        [ApiMember(Description="Reviewer")]
        public string Reviewer { get; set; }

        ///<summary>
        ///Is valid
        ///</summary>
        [ApiMember(DataType="boolean", Description="Is valid")]
        public bool IsValid { get; set; }

        ///<summary>
        ///Publish
        ///</summary>
        [ApiMember(DataType="boolean", Description="Publish")]
        public bool Publish { get; set; }
    }

    public class DischargeUncertainty
    {
        ///<summary>
        ///Active Uncertainty Type in use
        ///</summary>
        [ApiMember(DataType="string", Description="Active Uncertainty Type in use")]
        public UncertaintyType ActiveUncertaintyType { get; set; }

        ///<summary>
        ///Quantitative (Type A) Uncertainty
        ///</summary>
        [ApiMember(DataType="DoubleWithDisplay", Description="Quantitative (Type A) Uncertainty")]
        public DoubleWithDisplay QuantitativeUncertainty { get; set; }

        ///<summary>
        ///Qualitative (Type B) Uncertainty
        ///</summary>
        [ApiMember(DataType="string", Description="Qualitative (Type B) Uncertainty")]
        public QualitativeUncertaintyType QualitativeUncertainty { get; set; }
    }

    public class EngineeredStructureDischargeActivity
    {
        ///<summary>
        ///Discharge channel measurement
        ///</summary>
        [ApiMember(DataType="DischargeChannelMeasurement", Description="Discharge channel measurement")]
        public DischargeChannelMeasurement DischargeChannelMeasurement { get; set; }

        ///<summary>
        ///Structure type
        ///</summary>
        [ApiMember(Description="Structure type")]
        public string StructureType { get; set; }

        ///<summary>
        ///Equation for selected structure
        ///</summary>
        [ApiMember(Description="Equation for selected structure")]
        public string EquationForSelectedStructure { get; set; }

        ///<summary>
        ///Mean head
        ///</summary>
        [ApiMember(DataType="QuantityWithDisplay", Description="Mean head")]
        public QuantityWithDisplay MeanHead { get; set; }

        ///<summary>
        ///Is valid
        ///</summary>
        [ApiMember(DataType="boolean", Description="Is valid")]
        public bool IsValid { get; set; }
    }

    public class FieldVisit
        : FieldVisitDescription, IFieldVisitData
    {
        public FieldVisit()
        {
            Attachments = new List<Attachment>{};
            DischargeActivities = new List<DischargeActivity>{};
            CrossSectionSurveyActivity = new List<CrossSectionSurveyActivity>{};
        }

        ///<summary>
        ///Attachments
        ///</summary>
        [ApiMember(DataType="array", Description="Attachments")]
        public List<Attachment> Attachments { get; set; }

        ///<summary>
        ///Discharge activities
        ///</summary>
        [ApiMember(DataType="array", Description="Discharge activities")]
        public List<DischargeActivity> DischargeActivities { get; set; }

        ///<summary>
        ///Gage height at zero flow activity
        ///</summary>
        [ApiMember(DataType="GageHeightAtZeroFlowActivity", Description="Gage height at zero flow activity")]
        public GageHeightAtZeroFlowActivity GageHeightAtZeroFlowActivity { get; set; }

        ///<summary>
        ///Control condition activity
        ///</summary>
        [ApiMember(DataType="ControlConditionActivity", Description="Control condition activity")]
        public ControlConditionActivity ControlConditionActivity { get; set; }

        ///<summary>
        ///Inspection activity
        ///</summary>
        [ApiMember(DataType="InspectionActivity", Description="Inspection activity")]
        public InspectionActivity InspectionActivity { get; set; }

        ///<summary>
        ///Cross-section survey activity
        ///</summary>
        [ApiMember(DataType="array", Description="Cross-section survey activity")]
        public List<CrossSectionSurveyActivity> CrossSectionSurveyActivity { get; set; }

        ///<summary>
        ///Level survey activity
        ///</summary>
        [ApiMember(DataType="LevelSurveyActivity", Description="Level survey activity")]
        public LevelSurveyActivity LevelSurveyActivity { get; set; }

        ///<summary>
        ///Approval
        ///</summary>
        [ApiMember(DataType="FieldVisitApproval", Description="Approval")]
        public FieldVisitApproval Approval { get; set; }

        ///<summary>
        ///Summary results for a requested datum conversion
        ///</summary>
        [ApiMember(DataType="DatumConversionResult", Description="Summary results for a requested datum conversion")]
        public DatumConversionResult DatumConversionResult { get; set; }
    }

    public class FieldVisitApproval
    {
        ///<summary>
        ///Approval level
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level", Format="int64")]
        public long ApprovalLevel { get; set; }

        ///<summary>
        ///Level description
        ///</summary>
        [ApiMember(Description="Level description")]
        public string LevelDescription { get; set; }
    }

    public class FieldVisitDescription
    {
        ///<summary>
        ///Identifier
        ///</summary>
        [ApiMember(Description="Identifier")]
        public string Identifier { get; set; }

        ///<summary>
        ///Location identifier
        ///</summary>
        [ApiMember(Description="Location identifier")]
        public string LocationIdentifier { get; set; }

        ///<summary>
        ///Start time
        ///</summary>
        [ApiMember(DataType="string", Description="Start time", Format="date-time")]
        public DateTimeOffset? StartTime { get; set; }

        ///<summary>
        ///End time
        ///</summary>
        [ApiMember(DataType="string", Description="End time", Format="date-time")]
        public DateTimeOffset? EndTime { get; set; }

        ///<summary>
        ///Party
        ///</summary>
        [ApiMember(Description="Party")]
        public string Party { get; set; }

        ///<summary>
        ///Remarks
        ///</summary>
        [ApiMember(Description="Remarks")]
        public string Remarks { get; set; }

        ///<summary>
        ///Weather
        ///</summary>
        [ApiMember(Description="Weather")]
        public string Weather { get; set; }

        ///<summary>
        ///Is valid
        ///</summary>
        [ApiMember(DataType="boolean", Description="Is valid")]
        public bool IsValid { get; set; }

        ///<summary>
        ///Completed work
        ///</summary>
        [ApiMember(DataType="CompletedWork", Description="Completed work")]
        public CompletedWork CompletedWork { get; set; }

        ///<summary>
        ///Last modified
        ///</summary>
        [ApiMember(DataType="string", Description="Last modified", Format="date-time")]
        public DateTimeOffset LastModified { get; set; }

        ///<summary>
        ///Last time the deleted field visit matched the given filters; set only when request includes ChangesSinceToken
        ///</summary>
        [ApiMember(DataType="string", Description="Last time the deleted field visit matched the given filters; set only when request includes ChangesSinceToken", Format="date-time")]
        public DateTimeOffset? LastMatchedTime { get; set; }
    }

    public class FieldVisitReading
    {
        public FieldVisitReading()
        {
            DatumConvertedValues = new List<DatumConvertedQuantityWithDisplay>{};
            Qualifiers = new List<string>{};
        }

        ///<summary>
        ///Approval
        ///</summary>
        [ApiMember(DataType="FieldVisitApproval", Description="Approval")]
        public FieldVisitApproval Approval { get; set; }

        ///<summary>
        ///Control condition
        ///</summary>
        [ApiMember(Description="Control condition")]
        public string ControlCondition { get; set; }

        ///<summary>
        ///Field visit identifier
        ///</summary>
        [ApiMember(Description="Field visit identifier")]
        public string FieldVisitIdentifier { get; set; }

        ///<summary>
        ///Value
        ///</summary>
        [ApiMember(DataType="QuantityWithDisplay", Description="Value")]
        public QuantityWithDisplay Value { get; set; }

        ///<summary>
        ///Value
        ///</summary>
        [ApiMember(DataType="QuantityWithDisplay", Description="Value")]
        public QuantityWithDisplay AdjustmentAmount { get; set; }

        ///<summary>
        ///Uncertainty
        ///</summary>
        [ApiMember(DataType="Uncertainty", Description="Uncertainty")]
        public Uncertainty Uncertainty { get; set; }

        ///<summary>
        ///Datum converted values where applicable.
        ///</summary>
        [ApiMember(DataType="array", Description="Datum converted values where applicable.")]
        public List<DatumConvertedQuantityWithDisplay> DatumConvertedValues { get; set; }

        ///<summary>
        ///Parameter Name
        ///</summary>
        [ApiMember(Description="Parameter Name")]
        public string Parameter { get; set; }

        ///<summary>
        ///Parameter Id
        ///</summary>
        [ApiMember(Description="Parameter Id")]
        public string ParameterId { get; set; }

        ///<summary>
        ///Monitoring method
        ///</summary>
        [ApiMember(Description="Monitoring method")]
        public string MonitoringMethod { get; set; }

        ///<summary>
        ///Sub location identifier
        ///</summary>
        [ApiMember(Description="Sub location identifier")]
        public string SubLocationIdentifier { get; set; }

        ///<summary>
        ///Manufacturer
        ///</summary>
        [ApiMember(Description="Manufacturer")]
        public string Manufacturer { get; set; }

        ///<summary>
        ///Model
        ///</summary>
        [ApiMember(Description="Model")]
        public string Model { get; set; }

        ///<summary>
        ///Serial number
        ///</summary>
        [ApiMember(Description="Serial number")]
        public string SerialNumber { get; set; }

        ///<summary>
        ///Time
        ///</summary>
        [ApiMember(DataType="string", Description="Time", Format="date-time")]
        public DateTimeOffset Time { get; set; }

        ///<summary>
        ///Comments
        ///</summary>
        [ApiMember(Description="Comments")]
        public string Comments { get; set; }

        ///<summary>
        ///Publish
        ///</summary>
        [ApiMember(DataType="boolean", Description="Publish")]
        public bool Publish { get; set; }

        ///<summary>
        ///Grade code
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code", Format="int32")]
        public int? GradeCode { get; set; }

        ///<summary>
        ///Qualifiers
        ///</summary>
        [ApiMember(DataType="array", Description="Qualifiers")]
        public List<string> Qualifiers { get; set; }

        ///<summary>
        ///Field visit reading type
        ///</summary>
        [ApiMember(DataType="string", Description="Field visit reading type")]
        public FieldVisitReadingType ReadingType { get; set; }

        ///<summary>
        ///Reference point unique ID
        ///</summary>
        [ApiMember(DataType="string", Description="Reference point unique ID", Format="guid")]
        public Guid? ReferencePointUniqueId { get; set; }

        ///<summary>
        ///Indicates if this reading is measured against the local assumed datum of the reading's location
        ///</summary>
        [ApiMember(DataType="boolean", Description="Indicates if this reading is measured against the local assumed datum of the reading's location")]
        public bool UseLocationDatumAsReference { get; set; }
    }

    public class GageHeightAtZeroFlowActivity
    {
        ///<summary>
        ///Observed date
        ///</summary>
        [ApiMember(DataType="string", Description="Observed date", Format="date-time")]
        public DateTimeOffset? ObservedDate { get; set; }

        ///<summary>
        ///Applicable since
        ///</summary>
        [ApiMember(DataType="string", Description="Applicable since", Format="date-time")]
        public DateTimeOffset? ApplicableSince { get; set; }

        ///<summary>
        ///Zero flow height
        ///</summary>
        [ApiMember(DataType="DoubleWithDisplay", Description="Zero flow height")]
        public DoubleWithDisplay ZeroFlowHeight { get; set; }

        ///<summary>
        ///Is observed
        ///</summary>
        [ApiMember(DataType="boolean", Description="Is observed")]
        public bool IsObserved { get; set; }

        ///<summary>
        ///Calculated details
        ///</summary>
        [ApiMember(DataType="GageHeightAtZeroFlowCalculatedDetails", Description="Calculated details")]
        public GageHeightAtZeroFlowCalculatedDetails CalculatedDetails { get; set; }

        ///<summary>
        ///Unit
        ///</summary>
        [ApiMember(Description="Unit")]
        public string Unit { get; set; }

        ///<summary>
        ///Comments
        ///</summary>
        [ApiMember(Description="Comments")]
        public string Comments { get; set; }

        ///<summary>
        ///Party
        ///</summary>
        [ApiMember(Description="Party")]
        public string Party { get; set; }

        ///<summary>
        ///Is valid
        ///</summary>
        [ApiMember(DataType="boolean", Description="Is valid")]
        public bool IsValid { get; set; }
    }

    public class GageHeightAtZeroFlowCalculatedDetails
    {
        ///<summary>
        ///Stage
        ///</summary>
        [ApiMember(DataType="DoubleWithDisplay", Description="Stage")]
        public DoubleWithDisplay Stage { get; set; }

        ///<summary>
        ///Depth
        ///</summary>
        [ApiMember(DataType="DoubleWithDisplay", Description="Depth")]
        public DoubleWithDisplay Depth { get; set; }

        ///<summary>
        ///Depth certainty
        ///</summary>
        [ApiMember(DataType="DoubleWithDisplay", Description="Depth certainty")]
        public DoubleWithDisplay DepthCertainty { get; set; }
    }

    public class GageHeightReading
    {
        ///<summary>
        ///Is used
        ///</summary>
        [ApiMember(DataType="boolean", Description="Is used")]
        public bool IsUsed { get; set; }

        ///<summary>
        ///Reading time
        ///</summary>
        [ApiMember(DataType="string", Description="Reading time", Format="date-time")]
        public DateTimeOffset? ReadingTime { get; set; }

        ///<summary>
        ///Gage height
        ///</summary>
        [ApiMember(DataType="DoubleWithDisplay", Description="Gage height")]
        public DoubleWithDisplay GageHeight { get; set; }
    }

    public class GroundWaterMeasurement
    {
        ///<summary>
        ///Cut
        ///</summary>
        [ApiMember(DataType="DoubleWithDisplay", Description="Cut")]
        public DoubleWithDisplay Cut { get; set; }

        ///<summary>
        ///Hold
        ///</summary>
        [ApiMember(DataType="DoubleWithDisplay", Description="Hold")]
        public DoubleWithDisplay Hold { get; set; }

        ///<summary>
        ///Tape correction
        ///</summary>
        [ApiMember(DataType="DoubleWithDisplay", Description="Tape correction")]
        public DoubleWithDisplay TapeCorrection { get; set; }

        ///<summary>
        ///Water level
        ///</summary>
        [ApiMember(DataType="DoubleWithDisplay", Description="Water level")]
        public DoubleWithDisplay WaterLevel { get; set; }
    }

    public class IceCoveredData
    {
        ///<summary>
        ///Ice thickness
        ///</summary>
        [ApiMember(DataType="QuantityWithDisplay", Description="Ice thickness")]
        public QuantityWithDisplay IceThickness { get; set; }

        ///<summary>
        ///Water surface to bottom of slush
        ///</summary>
        [ApiMember(DataType="QuantityWithDisplay", Description="Water surface to bottom of slush")]
        public QuantityWithDisplay WaterSurfaceToBottomOfSlush { get; set; }

        ///<summary>
        ///Water surface to bottom of ice
        ///</summary>
        [ApiMember(DataType="QuantityWithDisplay", Description="Water surface to bottom of ice")]
        public QuantityWithDisplay WaterSurfaceToBottomOfIce { get; set; }

        ///<summary>
        ///Ice assembly type
        ///</summary>
        [ApiMember(Description="Ice assembly type")]
        public string IceAssemblyType { get; set; }

        ///<summary>
        ///Above footing
        ///</summary>
        [ApiMember(DataType="QuantityWithDisplay", Description="Above footing")]
        public QuantityWithDisplay AboveFooting { get; set; }

        ///<summary>
        ///Below footing
        ///</summary>
        [ApiMember(DataType="QuantityWithDisplay", Description="Below footing")]
        public QuantityWithDisplay BelowFooting { get; set; }

        ///<summary>
        ///Under ice coefficient
        ///</summary>
        [ApiMember(DataType="number", Description="Under ice coefficient", Format="double")]
        public double? UnderIceCoefficient { get; set; }
    }

    public interface IFieldVisitData
    {
        string Identifier { get; set; }
        List<Attachment> Attachments { get; set; }
        List<DischargeActivity> DischargeActivities { get; set; }
        GageHeightAtZeroFlowActivity GageHeightAtZeroFlowActivity { get; set; }
        ControlConditionActivity ControlConditionActivity { get; set; }
        InspectionActivity InspectionActivity { get; set; }
        List<CrossSectionSurveyActivity> CrossSectionSurveyActivity { get; set; }
        LevelSurveyActivity LevelSurveyActivity { get; set; }
        FieldVisitApproval Approval { get; set; }
        DatumConversionResult DatumConversionResult { get; set; }
    }

    public class Inspection
    {
        ///<summary>
        ///Inspection type
        ///</summary>
        [ApiMember(DataType="string", Description="Inspection type")]
        public InspectionType InspectionType { get; set; }

        ///<summary>
        ///Manufacturer
        ///</summary>
        [ApiMember(Description="Manufacturer")]
        public string Manufacturer { get; set; }

        ///<summary>
        ///Model
        ///</summary>
        [ApiMember(Description="Model")]
        public string Model { get; set; }

        ///<summary>
        ///Serial number
        ///</summary>
        [ApiMember(Description="Serial number")]
        public string SerialNumber { get; set; }

        ///<summary>
        ///Time
        ///</summary>
        [ApiMember(DataType="string", Description="Time", Format="date-time")]
        public DateTimeOffset? Time { get; set; }

        ///<summary>
        ///Sub location identifier
        ///</summary>
        [ApiMember(Description="Sub location identifier")]
        public string SubLocationIdentifier { get; set; }

        ///<summary>
        ///Comments
        ///</summary>
        [ApiMember(Description="Comments")]
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

        ///<summary>
        ///Party
        ///</summary>
        [ApiMember(Description="Party")]
        public string Party { get; set; }

        ///<summary>
        ///Readings
        ///</summary>
        [ApiMember(DataType="array", Description="Readings")]
        public List<Reading> Readings { get; set; }

        ///<summary>
        ///Number of readings which could not be converted to the target datum
        ///</summary>
        [ApiMember(DataType="integer", Description="Number of readings which could not be converted to the target datum", Format="int32")]
        public int? NumberOfReadingsNotDatumConverted { get; set; }

        ///<summary>
        ///Calibration checks
        ///</summary>
        [ApiMember(DataType="array", Description="Calibration checks")]
        public List<CalibrationCheck> CalibrationChecks { get; set; }

        ///<summary>
        ///Inspections
        ///</summary>
        [ApiMember(DataType="array", Description="Inspections")]
        public List<Inspection> Inspections { get; set; }

        ///<summary>
        ///Is valid
        ///</summary>
        [ApiMember(DataType="boolean", Description="Is valid")]
        public bool IsValid { get; set; }
    }

    public class LevelSurveyActivity
    {
        public LevelSurveyActivity()
        {
            LevelMeasurements = new List<LevelSurveyMeasurement>{};
        }

        ///<summary>
        ///Party
        ///</summary>
        [ApiMember(Description="Party")]
        public string Party { get; set; }

        ///<summary>
        ///Origin reference point unique ID
        ///</summary>
        [ApiMember(DataType="string", Description="Origin reference point unique ID", Format="guid")]
        public Guid OriginReferencePointUniqueId { get; set; }

        ///<summary>
        ///Measurement method
        ///</summary>
        [ApiMember(Description="Measurement method")]
        public string Method { get; set; }

        ///<summary>
        ///Comments
        ///</summary>
        [ApiMember(Description="Comments")]
        public string Comments { get; set; }

        ///<summary>
        ///Level survey measurements
        ///</summary>
        [ApiMember(DataType="array", Description="Level survey measurements")]
        public List<LevelSurveyMeasurement> LevelMeasurements { get; set; }
    }

    public class LevelSurveyMeasurement
    {
        ///<summary>
        ///Measured reference point unique ID
        ///</summary>
        [ApiMember(DataType="string", Description="Measured reference point unique ID", Format="guid")]
        public Guid ReferencePointUniqueId { get; set; }

        ///<summary>
        ///Measured elevation
        ///</summary>
        [ApiMember(DataType="QuantityWithDisplay", Description="Measured elevation")]
        public QuantityWithDisplay MeasuredElevation { get; set; }

        ///<summary>
        ///Measurement time
        ///</summary>
        [ApiMember(DataType="string", Description="Measurement time", Format="date-time")]
        public DateTimeOffset MeasurementTime { get; set; }

        ///<summary>
        ///Comments
        ///</summary>
        [ApiMember(Description="Comments")]
        public string Comments { get; set; }
    }

    public class OpenWaterData
    {
        ///<summary>
        ///Suspension Weight
        ///</summary>
        [ApiMember(Description="Suspension Weight")]
        public string SuspensionWeight { get; set; }

        ///<summary>
        ///Distance to meter
        ///</summary>
        [ApiMember(DataType="QuantityWithDisplay", Description="Distance to meter")]
        public QuantityWithDisplay DistanceToMeter { get; set; }

        ///<summary>
        ///Dry Line Angle
        ///</summary>
        [ApiMember(DataType="number", Description="Dry Line Angle", Format="double")]
        public double DryLineAngle { get; set; }

        ///<summary>
        ///Surface Coefficient
        ///</summary>
        [ApiMember(DataType="number", Description="Surface Coefficient", Format="double")]
        public double? SurfaceCoefficient { get; set; }

        ///<summary>
        ///Distance to water surface
        ///</summary>
        [ApiMember(DataType="QuantityWithDisplay", Description="Distance to water surface")]
        public QuantityWithDisplay DistanceToWaterSurface { get; set; }

        ///<summary>
        ///Dry Line Correction
        ///</summary>
        [ApiMember(DataType="number", Description="Dry Line Correction", Format="double")]
        public double? DryLineCorrection { get; set; }

        ///<summary>
        ///Wet Line Correction
        ///</summary>
        [ApiMember(DataType="number", Description="Wet Line Correction", Format="double")]
        public double? WetLineCorrection { get; set; }
    }

    public class OtherMethodDischargeActivity
    {
        ///<summary>
        ///Discharge channel measurement
        ///</summary>
        [ApiMember(DataType="DischargeChannelMeasurement", Description="Discharge channel measurement")]
        public DischargeChannelMeasurement DischargeChannelMeasurement { get; set; }

        ///<summary>
        ///Is valid
        ///</summary>
        [ApiMember(DataType="boolean", Description="Is valid")]
        public bool IsValid { get; set; }
    }

    public class PointVelocityDischargeActivity
    {
        public PointVelocityDischargeActivity()
        {
            Verticals = new List<Vertical>{};
        }

        ///<summary>
        ///Discharge channel measurement
        ///</summary>
        [ApiMember(DataType="DischargeChannelMeasurement", Description="Discharge channel measurement")]
        public DischargeChannelMeasurement DischargeChannelMeasurement { get; set; }

        ///<summary>
        ///Distance to meter
        ///</summary>
        [ApiMember(DataType="QuantityWithDisplay", Description="Distance to meter")]
        public QuantityWithDisplay DistanceToMeter { get; set; }

        ///<summary>
        ///Width
        ///</summary>
        [ApiMember(DataType="QuantityWithDisplay", Description="Width")]
        public QuantityWithDisplay Width { get; set; }

        ///<summary>
        ///Area
        ///</summary>
        [ApiMember(DataType="QuantityWithDisplay", Description="Area")]
        public QuantityWithDisplay Area { get; set; }

        ///<summary>
        ///Velocity average
        ///</summary>
        [ApiMember(DataType="QuantityWithDisplay", Description="Velocity average")]
        public QuantityWithDisplay VelocityAverage { get; set; }

        ///<summary>
        ///Mean observation duration in seconds
        ///</summary>
        [ApiMember(DataType="DoubleWithDisplay", Description="Mean observation duration in seconds")]
        public DoubleWithDisplay MeanObservationDurationInSeconds { get; set; }

        ///<summary>
        ///Suspension coefficient used
        ///</summary>
        [ApiMember(DataType="boolean", Description="Suspension coefficient used")]
        public bool SuspensionCoefficientUsed { get; set; }

        ///<summary>
        ///Method coefficient used
        ///</summary>
        [ApiMember(DataType="boolean", Description="Method coefficient used")]
        public bool MethodCoefficientUsed { get; set; }

        ///<summary>
        ///Horizontal coefficient used
        ///</summary>
        [ApiMember(DataType="boolean", Description="Horizontal coefficient used")]
        public bool HorizontalCoefficientUsed { get; set; }

        ///<summary>
        ///Meter inspected before
        ///</summary>
        [ApiMember(DataType="boolean", Description="Meter inspected before")]
        public bool? MeterInspectedBefore { get; set; }

        ///<summary>
        ///Meter inspected after
        ///</summary>
        [ApiMember(DataType="boolean", Description="Meter inspected after")]
        public bool? MeterInspectedAfter { get; set; }

        ///<summary>
        ///Number of panels
        ///</summary>
        [ApiMember(DataType="integer", Description="Number of panels", Format="int32")]
        public int? NumberOfPanels { get; set; }

        ///<summary>
        ///Meter equation
        ///</summary>
        [ApiMember(Description="Meter equation")]
        public string MeterEquation { get; set; }

        ///<summary>
        ///Manufacturer
        ///</summary>
        [ApiMember(Description="Manufacturer")]
        public string Manufacturer { get; set; }

        ///<summary>
        ///Model
        ///</summary>
        [ApiMember(Description="Model")]
        public string Model { get; set; }

        ///<summary>
        ///Serial number
        ///</summary>
        [ApiMember(Description="Serial number")]
        public string SerialNumber { get; set; }

        ///<summary>
        ///Discharge method
        ///</summary>
        [ApiMember(DataType="string", Description="Discharge method")]
        public DischargeMethodType DischargeMethod { get; set; }

        ///<summary>
        ///Suspension weight
        ///</summary>
        [ApiMember(Description="Suspension weight")]
        public string SuspensionWeight { get; set; }

        ///<summary>
        ///Velocity observation method
        ///</summary>
        [ApiMember(Description="Velocity observation method")]
        public string VelocityObservationMethod { get; set; }

        ///<summary>
        ///Firmware version
        ///</summary>
        [ApiMember(Description="Firmware version")]
        public string FirmwareVersion { get; set; }

        ///<summary>
        ///Software version
        ///</summary>
        [ApiMember(Description="Software version")]
        public string SoftwareVersion { get; set; }

        ///<summary>
        ///Starting point
        ///</summary>
        [ApiMember(DataType="string", Description="Starting point")]
        public StartPointType StartPoint { get; set; }

        ///<summary>
        ///Node details
        ///</summary>
        [ApiMember(Description="Node details")]
        public string NodeDetails { get; set; }

        ///<summary>
        ///Is valid
        ///</summary>
        [ApiMember(DataType="boolean", Description="Is valid")]
        public bool IsValid { get; set; }

        ///<summary>
        ///Verticals
        ///</summary>
        [ApiMember(DataType="array", Description="Verticals")]
        public List<Vertical> Verticals { get; set; }
    }

    public class QuantityWithDisplay
        : DoubleWithDisplay
    {
        ///<summary>
        ///Unit
        ///</summary>
        [ApiMember(Description="Unit")]
        public string Unit { get; set; }
    }

    public class Reading
    {
        public Reading()
        {
            ReadingQualifiers = new List<string>{};
        }

        ///<summary>
        ///Parameter Name
        ///</summary>
        [ApiMember(Description="Parameter Name")]
        public string Parameter { get; set; }

        ///<summary>
        ///Parameter Id
        ///</summary>
        [ApiMember(Description="Parameter Id")]
        public string ParameterId { get; set; }

        ///<summary>
        ///Monitoring method
        ///</summary>
        [ApiMember(Description="Monitoring method")]
        public string MonitoringMethod { get; set; }

        ///<summary>
        ///Value
        ///</summary>
        [ApiMember(DataType="DoubleWithDisplay", Description="Value")]
        public DoubleWithDisplay Value { get; set; }

        ///<summary>
        ///AdjustmentAmount
        ///</summary>
        [ApiMember(DataType="DoubleWithDisplay", Description="AdjustmentAmount")]
        public DoubleWithDisplay AdjustmentAmount { get; set; }

        ///<summary>
        ///Unit
        ///</summary>
        [ApiMember(Description="Unit")]
        public string Unit { get; set; }

        ///<summary>
        ///Uncertainty
        ///</summary>
        [ApiMember(DataType="DoubleWithDisplay", Description="Uncertainty")]
        public DoubleWithDisplay Uncertainty { get; set; }

        ///<summary>
        ///Reading type
        ///</summary>
        [ApiMember(DataType="string", Description="Reading type")]
        public ReadingType ReadingType { get; set; }

        ///<summary>
        ///Manufacturer
        ///</summary>
        [ApiMember(Description="Manufacturer")]
        public string Manufacturer { get; set; }

        ///<summary>
        ///Model
        ///</summary>
        [ApiMember(Description="Model")]
        public string Model { get; set; }

        ///<summary>
        ///Serial number
        ///</summary>
        [ApiMember(Description="Serial number")]
        public string SerialNumber { get; set; }

        ///<summary>
        ///Time
        ///</summary>
        [ApiMember(DataType="string", Description="Time", Format="date-time")]
        public DateTimeOffset? Time { get; set; }

        ///<summary>
        ///Sub location identifier
        ///</summary>
        [ApiMember(Description="Sub location identifier")]
        public string SubLocationIdentifier { get; set; }

        ///<summary>
        ///Comments
        ///</summary>
        [ApiMember(Description="Comments")]
        public string Comments { get; set; }

        ///<summary>
        ///Node details
        ///</summary>
        [ApiMember(Description="Node details")]
        public string NodeDetails { get; set; }

        ///<summary>
        ///Publish
        ///</summary>
        [ApiMember(DataType="boolean", Description="Publish")]
        public bool Publish { get; set; }

        ///<summary>
        ///Is valid
        ///</summary>
        [ApiMember(DataType="boolean", Description="Is valid")]
        public bool IsValid { get; set; }

        ///<summary>
        ///Reference point unique ID
        ///</summary>
        [ApiMember(DataType="string", Description="Reference point unique ID", Format="guid")]
        public Guid? ReferencePointUniqueId { get; set; }

        ///<summary>
        ///Indicates if this reading is measured against the local assumed datum of the reading's location
        ///</summary>
        [ApiMember(DataType="boolean", Description="Indicates if this reading is measured against the local assumed datum of the reading's location")]
        public bool UseLocationDatumAsReference { get; set; }

        ///<summary>
        ///Reading Qualifier
        ///</summary>
        [ApiMember(Description="Reading Qualifier")]
        public string ReadingQualifier { get; set; }

        ///<summary>
        ///Reading Qualifiers
        ///</summary>
        [ApiMember(DataType="array", Description="Reading Qualifiers")]
        public List<string> ReadingQualifiers { get; set; }

        ///<summary>
        ///Groundwater measurements
        ///</summary>
        [ApiMember(DataType="GroundWaterMeasurement", Description="Groundwater measurements")]
        public GroundWaterMeasurement GroundWaterMeasurement { get; set; }

        ///<summary>
        ///Sensor unique ID
        ///</summary>
        [ApiMember(DataType="string", Description="Sensor unique ID", Format="guid")]
        public Guid? SensorUniqueId { get; set; }

        ///<summary>
        ///Grade code
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code", Format="int32")]
        public int? GradeCode { get; set; }
    }

    public class StandardDetails
    {
        ///<summary>
        ///Standard code
        ///</summary>
        [ApiMember(Description="Standard code")]
        public string StandardCode { get; set; }

        ///<summary>
        ///Lot number
        ///</summary>
        [ApiMember(Description="Lot number")]
        public string LotNumber { get; set; }

        ///<summary>
        ///Temperature
        ///</summary>
        [ApiMember(DataType="DoubleWithDisplay", Description="Temperature")]
        public DoubleWithDisplay Temperature { get; set; }

        ///<summary>
        ///Expiration date
        ///</summary>
        [ApiMember(DataType="string", Description="Expiration date", Format="date-time")]
        public DateTimeOffset? ExpirationDate { get; set; }
    }

    public class Uncertainty
    {
        ///<summary>
        ///Uncertainty Type in use
        ///</summary>
        [ApiMember(DataType="string", Description="Uncertainty Type in use")]
        public UncertaintyType UncertaintyType { get; set; }

        ///<summary>
        ///Quantitative (Type A) Uncertainty
        ///</summary>
        [ApiMember(DataType="DoubleWithDisplay", Description="Quantitative (Type A) Uncertainty")]
        public DoubleWithDisplay QuantitativeUncertainty { get; set; }

        ///<summary>
        ///Qualitative (Type B) Uncertainty
        ///</summary>
        [ApiMember(DataType="string", Description="Qualitative (Type B) Uncertainty")]
        public QualitativeUncertaintyType? QualitativeUncertainty { get; set; }
    }

    public class VelocityDepthObservation
    {
        ///<summary>
        ///Depth
        ///</summary>
        [ApiMember(DataType="QuantityWithDisplay", Description="Depth")]
        public QuantityWithDisplay Depth { get; set; }

        ///<summary>
        ///Revolution count
        ///</summary>
        [ApiMember(DataType="integer", Description="Revolution count", Format="int32")]
        public int? RevolutionCount { get; set; }

        ///<summary>
        ///Observation interval in seconds
        ///</summary>
        [ApiMember(DataType="DoubleWithDisplay", Description="Observation interval in seconds")]
        public DoubleWithDisplay ObservationIntervalInSeconds { get; set; }

        ///<summary>
        ///Velocity
        ///</summary>
        [ApiMember(DataType="QuantityWithDisplay", Description="Velocity")]
        public QuantityWithDisplay Velocity { get; set; }

        ///<summary>
        ///Is velocity estimated
        ///</summary>
        [ApiMember(DataType="boolean", Description="Is velocity estimated")]
        public bool IsVelocityEstimated { get; set; }

        ///<summary>
        ///Depth multiplier
        ///</summary>
        [ApiMember(DataType="number", Description="Depth multiplier", Format="double")]
        public double DepthMultiplier { get; set; }

        ///<summary>
        ///Weighting
        ///</summary>
        [ApiMember(DataType="number", Description="Weighting", Format="double")]
        public double Weighting { get; set; }
    }

    public class VelocityObservation
    {
        ///<summary>
        ///Deployment Method
        ///</summary>
        [ApiMember(DataType="string", Description="Deployment Method")]
        public DeploymentMethodType? DeploymentMethod { get; set; }

        ///<summary>
        ///Velocity Depth Observations
        ///</summary>
        [ApiMember(DataType="array", Description="Velocity Depth Observations")]
        public IList<VelocityDepthObservation> Observations { get; set; }
    }

    public class Vertical
    {
        public Vertical()
        {
            Calibrations = new List<Calibration>{};
        }

        ///<summary>
        ///Vertical number
        ///</summary>
        [ApiMember(DataType="number", Description="Vertical number", Format="double")]
        public double VerticalNumber { get; set; }

        ///<summary>
        ///Tagline position
        ///</summary>
        [ApiMember(DataType="QuantityWithDisplay", Description="Tagline position")]
        public QuantityWithDisplay TaglinePosition { get; set; }

        ///<summary>
        ///Effective depth
        ///</summary>
        [ApiMember(DataType="QuantityWithDisplay", Description="Effective depth")]
        public QuantityWithDisplay EffectiveDepth { get; set; }

        ///<summary>
        ///Velocity method
        ///</summary>
        [ApiMember(DataType="string", Description="Velocity method")]
        public PointVelocityObservationType? VelocityObservationMethod { get; set; }

        ///<summary>
        ///Mean velocity
        ///</summary>
        [ApiMember(DataType="QuantityWithDisplay", Description="Mean velocity")]
        public QuantityWithDisplay MeanVelocity { get; set; }

        ///<summary>
        ///Segment width
        ///</summary>
        [ApiMember(DataType="QuantityWithDisplay", Description="Segment width")]
        public QuantityWithDisplay SegmentWidth { get; set; }

        ///<summary>
        ///Segment velocity
        ///</summary>
        [ApiMember(DataType="QuantityWithDisplay", Description="Segment velocity")]
        public QuantityWithDisplay SegmentVelocity { get; set; }

        ///<summary>
        ///Segment area
        ///</summary>
        [ApiMember(DataType="QuantityWithDisplay", Description="Segment area")]
        public QuantityWithDisplay SegmentArea { get; set; }

        ///<summary>
        ///Is discharge estimated
        ///</summary>
        [ApiMember(DataType="boolean", Description="Is discharge estimated")]
        public bool IsDischargeEstimated { get; set; }

        ///<summary>
        ///Segment discharge
        ///</summary>
        [ApiMember(DataType="QuantityWithDisplay", Description="Segment discharge")]
        public QuantityWithDisplay SegmentDischarge { get; set; }

        ///<summary>
        ///Percentage of total discharge
        ///</summary>
        [ApiMember(DataType="number", Description="Percentage of total discharge", Format="double")]
        public double PercentageOfTotalDischarge { get; set; }

        ///<summary>
        ///Vertical type
        ///</summary>
        [ApiMember(DataType="string", Description="Vertical type")]
        public VerticalType VerticalType { get; set; }

        ///<summary>
        ///Measurement condition
        ///</summary>
        [ApiMember(DataType="string", Description="Measurement condition")]
        public MeasurementCondition MeasurementCondition { get; set; }

        ///<summary>
        ///Ice covered data
        ///</summary>
        [ApiMember(DataType="string", Description="Ice covered data")]
        public IceCoveredData IceCoveredData { get; set; }

        ///<summary>
        ///Open water data
        ///</summary>
        [ApiMember(DataType="string", Description="Open water data")]
        public OpenWaterData OpenWaterData { get; set; }

        ///<summary>
        ///Flow direction type
        ///</summary>
        [ApiMember(DataType="string", Description="Flow direction type")]
        public FlowDirectionType FlowDirection { get; set; }

        ///<summary>
        ///Measurement time
        ///</summary>
        [ApiMember(DataType="string", Description="Measurement time", Format="date-time")]
        public DateTimeOffset? MeasurementTime { get; set; }

        ///<summary>
        ///Is Sounded Depth estimated
        ///</summary>
        [ApiMember(DataType="boolean", Description="Is Sounded Depth estimated")]
        public bool IsSoundedDepthEstimated { get; set; }

        ///<summary>
        ///Sounded depth
        ///</summary>
        [ApiMember(DataType="QuantityWithDisplay", Description="Sounded depth")]
        public QuantityWithDisplay SoundedDepth { get; set; }

        ///<summary>
        ///Cosine of unique flow
        ///</summary>
        [ApiMember(DataType="number", Description="Cosine of unique flow", Format="double")]
        public double CosineOfUniqueFlow { get; set; }

        ///<summary>
        ///Comments
        ///</summary>
        [ApiMember(Description="Comments")]
        public string Comments { get; set; }

        ///<summary>
        ///Velocity observation
        ///</summary>
        [ApiMember(DataType="string", Description="Velocity observation")]
        public VelocityObservation VelocityObservation { get; set; }

        ///<summary>
        ///Current Meter
        ///</summary>
        [ApiMember(DataType="string", Description="Current Meter")]
        public CurrentMeter CurrentMeter { get; set; }

        ///<summary>
        ///Calibration
        ///</summary>
        [ApiMember(DataType="array", Description="Calibration")]
        public List<Calibration> Calibrations { get; set; }
    }

    public class VolumetricDischargeActivity
    {
        public VolumetricDischargeActivity()
        {
            VolumetricDischargeReadings = new List<VolumetricDischargeReading>{};
        }

        ///<summary>
        ///Discharge channel measurement
        ///</summary>
        [ApiMember(DataType="DischargeChannelMeasurement", Description="Discharge channel measurement")]
        public DischargeChannelMeasurement DischargeChannelMeasurement { get; set; }

        ///<summary>
        ///Volumetric discharge readings
        ///</summary>
        [ApiMember(DataType="array", Description="Volumetric discharge readings")]
        public List<VolumetricDischargeReading> VolumetricDischargeReadings { get; set; }

        ///<summary>
        ///Measurement container volume
        ///</summary>
        [ApiMember(DataType="QuantityWithDisplay", Description="Measurement container volume")]
        public QuantityWithDisplay MeasurementContainerVolume { get; set; }

        ///<summary>
        ///Is observed
        ///</summary>
        [ApiMember(DataType="boolean", Description="Is observed")]
        public bool IsObserved { get; set; }

        ///<summary>
        ///Is valid
        ///</summary>
        [ApiMember(DataType="boolean", Description="Is valid")]
        public bool IsValid { get; set; }
    }

    public class VolumetricDischargeReading
    {
        ///<summary>
        ///Name
        ///</summary>
        [ApiMember(Description="Name")]
        public string Name { get; set; }

        ///<summary>
        ///Duration in seconds
        ///</summary>
        [ApiMember(DataType="DoubleWithDisplay", Description="Duration in seconds")]
        public DoubleWithDisplay DurationInSeconds { get; set; }

        ///<summary>
        ///Starting volume
        ///</summary>
        [ApiMember(DataType="DoubleWithDisplay", Description="Starting volume")]
        public DoubleWithDisplay StartingVolume { get; set; }

        ///<summary>
        ///Ending volume
        ///</summary>
        [ApiMember(DataType="DoubleWithDisplay", Description="Ending volume")]
        public DoubleWithDisplay EndingVolume { get; set; }

        ///<summary>
        ///Discharge
        ///</summary>
        [ApiMember(DataType="DoubleWithDisplay", Description="Discharge")]
        public DoubleWithDisplay Discharge { get; set; }

        ///<summary>
        ///Is used
        ///</summary>
        [ApiMember(DataType="boolean", Description="Is used")]
        public bool IsUsed { get; set; }

        ///<summary>
        ///Volume change
        ///</summary>
        [ApiMember(DataType="DoubleWithDisplay", Description="Volume change")]
        public DoubleWithDisplay VolumeChange { get; set; }
    }

    public class ActiveMeterCalibration
    {
        public ActiveMeterCalibration()
        {
            Equations = new List<ActiveMeterCalibrationEquation>{};
        }

        ///<summary>
        ///Visit date
        ///</summary>
        [ApiMember(DataType="string", Description="Visit date", Format="date-time")]
        public DateTimeOffset FirstUsedDate { get; set; }

        ///<summary>
        ///Equations
        ///</summary>
        [ApiMember(DataType="array", Description="Equations")]
        public List<ActiveMeterCalibrationEquation> Equations { get; set; }
    }

    public class ActiveMeterCalibrationEquation
        : Calibration
    {
    }

    public class ActiveMeterDetails
        : CurrentMeter
    {
        public ActiveMeterDetails()
        {
            MeterCalibrations = new List<ActiveMeterCalibration>{};
        }

        ///<summary>
        ///Meter type
        ///</summary>
        [ApiMember(DataType="string", Description="Meter type")]
        public MeterType? MeterType { get; set; }

        ///<summary>
        ///Configuration
        ///</summary>
        [ApiMember(Description="Configuration")]
        public string Configuration { get; set; }

        ///<summary>
        ///Firmware version
        ///</summary>
        [ApiMember(Description="Firmware version")]
        public string FirmwareVersion { get; set; }

        ///<summary>
        ///Software version
        ///</summary>
        [ApiMember(Description="Software version")]
        public string SoftwareVersion { get; set; }

        ///<summary>
        ///Meter calibrations
        ///</summary>
        [ApiMember(DataType="array", Description="Meter calibrations")]
        public List<ActiveMeterCalibration> MeterCalibrations { get; set; }
    }

    public enum ActivityType
    {
        Reading,
        Inspection,
        CalibrationCheck,
        DischargeSummary,
        DischargePointVelocity,
        DischargeVolumetric,
        DischargeEngineeredStructure,
        DischargeAdcp,
        DischargeOtherMethod,
        GageHeightAtZeroFlow,
        ControlCondition,
        CrossSectionSurvey,
        LevelSurvey,
        Attachment,
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
        Report,
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
        Csv,
        FieldDataPlugin,
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
        MeanSection,
    }

    public enum FieldVisitReadingType
    {
        Unknown,
        RoutineBefore,
        Routine,
        RoutineAfter,
        ResetBefore,
        ResetAfter,
        CleaningBefore,
        CleaningAfter,
        AfterCalibration,
        ReferencePrimary,
        Reference,
        MeanGageHeight,
        ExtremeMin,
        ExtremeMax,
        Discharge,
        MeanIndexVelocity,
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

    public enum QualitativeUncertaintyType
    {
        Unknown,
        Unspecified,
        Excellent,
        Good,
        Fair,
        Poor,
    }

    public enum ReadingType
    {
        Unknown,
        RoutineBefore,
        Routine,
        RoutineAfter,
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

    public enum UncertaintyType
    {
        None,
        Quantitative,
        Qualitative,
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

    [Route("/GetActiveMetersAndCalibrations", "GET")]
    public class ActiveMetersAndCalibrationsServiceRequest
        : IReturn<ActiveMetersAndCalibrationsServiceResponse>
    {
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
        ///<summary>
        ///The unique ID of the time series
        ///</summary>
        [ApiMember(DataType="string", Description="The unique ID of the time series", Format="guid", IsRequired=true)]
        public Guid TimeSeriesUniqueId { get; set; }

        ///<summary>
        ///Filter results to items with a StartTime at or after the QueryFrom time
        ///</summary>
        [ApiMember(DataType="string", Description="Filter results to items with a StartTime at or after the QueryFrom time", Format="date-time")]
        public DateTimeOffset? QueryFrom { get; set; }

        ///<summary>
        ///Filter results to items with an EndTime at or before the QueryTo time
        ///</summary>
        [ApiMember(DataType="string", Description="Filter results to items with an EndTime at or before the QueryTo time", Format="date-time")]
        public DateTimeOffset? QueryTo { get; set; }
    }

    [Route("/GetDownchainProcessorListByRatingModel", "GET")]
    public class DownchainProcessorListByRatingModelServiceRequest
        : IReturn<ProcessorListServiceResponse>
    {
        ///<summary>
        ///Rating model identifier
        ///</summary>
        [ApiMember(Description="Rating model identifier", IsRequired=true)]
        public string RatingModelIdentifier { get; set; }

        ///<summary>
        ///Filter results to items with a ProcessorPeriod.StartTime at or after the QueryFrom time
        ///</summary>
        [ApiMember(DataType="string", Description="Filter results to items with a ProcessorPeriod.StartTime at or after the QueryFrom time", Format="date-time")]
        public DateTimeOffset? QueryFrom { get; set; }

        ///<summary>
        ///Filter results to items with a ProcessorPeriod.EndTime at or before the QueryTo time
        ///</summary>
        [ApiMember(DataType="string", Description="Filter results to items with a ProcessorPeriod.EndTime at or before the QueryTo time", Format="date-time")]
        public DateTimeOffset? QueryTo { get; set; }
    }

    [Route("/GetDownchainProcessorListByTimeSeries", "GET")]
    public class DownchainProcessorListByTimeSeriesServiceRequest
        : IReturn<ProcessorListServiceResponse>
    {
        ///<summary>
        ///Unique ID of the time series
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the time series", Format="guid", IsRequired=true)]
        public Guid TimeSeriesUniqueId { get; set; }

        ///<summary>
        ///Filter results to items with a ProcessorPeriod.StartTime at or after the QueryFrom time
        ///</summary>
        [ApiMember(DataType="string", Description="Filter results to items with a ProcessorPeriod.StartTime at or after the QueryFrom time", Format="date-time")]
        public DateTimeOffset? QueryFrom { get; set; }

        ///<summary>
        ///Filter results to items with a ProcessorPeriod.EndTime at or before the QueryTo time
        ///</summary>
        [ApiMember(DataType="string", Description="Filter results to items with a ProcessorPeriod.EndTime at or before the QueryTo time", Format="date-time")]
        public DateTimeOffset? QueryTo { get; set; }
    }

    [Route("/GetEffectiveRatingCurve", "GET")]
    public class EffectiveRatingCurveServiceRequest
        : IReturn<EffectiveRatingCurveServiceResponse>
    {
        ///<summary>
        ///Rating model identifier
        ///</summary>
        [ApiMember(Description="Rating model identifier", IsRequired=true)]
        public string RatingModelIdentifier { get; set; }

        ///<summary>
        ///Table step size increment. Defaults to 0.01
        ///</summary>
        [ApiMember(DataType="number", Description="Table step size increment. Defaults to 0.01", Format="double")]
        public double? StepSize { get; set; }

        ///<summary>
        ///Forces the response time values to a specific UTC offset. Defaults to the location UTC offset
        ///</summary>
        [ApiMember(DataType="number", Description="Forces the response time values to a specific UTC offset. Defaults to the location UTC offset", Format="double")]
        public double? UtcOffset { get; set; }

        ///<summary>
        ///Table start value. Required for equation-based ratings. Defaults to minimum table value for table-based ratings
        ///</summary>
        [ApiMember(DataType="number", Description="Table start value. Required for equation-based ratings. Defaults to minimum table value for table-based ratings", Format="double")]
        public double? StartValue { get; set; }

        ///<summary>
        ///Table end value. Required for equation-based ratings. Defaults to maximum table value for table-based ratings
        ///</summary>
        [ApiMember(DataType="number", Description="Table end value. Required for equation-based ratings. Defaults to maximum table value for table-based ratings", Format="double")]
        public double? EndValue { get; set; }

        ///<summary>
        ///Effective time of the calculation. Defaults to the current time if not specified
        ///</summary>
        [ApiMember(DataType="string", Description="Effective time of the calculation. Defaults to the current time if not specified", Format="date-time")]
        public DateTimeOffset? EffectiveTime { get; set; }
    }

    [Route("/GetExpandedStageTable", "GET")]
    public class ExpandedStageTableServiceRequest
        : IReturn<ExpandedStageTableServiceResponse>
    {
        ///<summary>
        ///The unique ID of the time series
        ///</summary>
        [ApiMember(DataType="string", Description="The unique ID of the time series", Format="guid", IsRequired=true)]
        public Guid TimeSeriesUniqueId { get; set; }

        ///<summary>
        ///Table step size increment. Defaults to 0.01
        ///</summary>
        [ApiMember(DataType="number", Description="Table step size increment. Defaults to 0.01", Format="double")]
        public double? StepSize { get; set; }

        ///<summary>
        ///Forces the response time values to a specific UTC offset. Defaults to the time series UTC offset
        ///</summary>
        [ApiMember(DataType="number", Description="Forces the response time values to a specific UTC offset. Defaults to the time series UTC offset", Format="double")]
        public double? UtcOffset { get; set; }

        ///<summary>
        ///Table starting value
        ///</summary>
        [ApiMember(DataType="number", Description="Table starting value", Format="double", IsRequired=true)]
        public double? StartValue { get; set; }

        ///<summary>
        ///Table ending value
        ///</summary>
        [ApiMember(DataType="number", Description="Table ending value", Format="double", IsRequired=true)]
        public double? EndValue { get; set; }
    }

    [Route("/GetFieldVisitDataByLocation", "GET")]
    public class FieldVisitDataByLocationServiceRequest
        : IReturn<FieldVisitDataByLocationServiceResponse>, IFieldVisitDataRequest
    {
        public FieldVisitDataByLocationServiceRequest()
        {
            Activities = new List<ActivityType>{};
            Parameters = new List<string>{};
            InspectionTypes = new List<InspectionType>{};
        }

        ///<summary>
        ///Location identifier
        ///</summary>
        [ApiMember(Description="Location identifier", IsRequired=true)]
        public string LocationIdentifier { get; set; }

        ///<summary>
        ///If set, only return specified activity types, selected from: Reading, Inspection, CalibrationCheck, DischargeSummary, DischargePointVelocity, DischargeVolumetric, DischargeEngineeredStructure, DischargeAdcp, DischargeOtherMethod, GageHeightAtZeroFlow, ControlCondition, CrossSectionSurvey, LevelSurvey, Attachment
        ///</summary>
        [ApiMember(AllowMultiple=true, DataType="array", Description="If set, only return specified activity types, selected from: Reading, Inspection, CalibrationCheck, DischargeSummary, DischargePointVelocity, DischargeVolumetric, DischargeEngineeredStructure, DischargeAdcp, DischargeOtherMethod, GageHeightAtZeroFlow, ControlCondition, CrossSectionSurvey, LevelSurvey, Attachment")]
        public List<ActivityType> Activities { get; set; }

        ///<summary>
        ///If set, only return readings and calibrations of the specified parameters
        ///</summary>
        [ApiMember(DataType="array", Description="If set, only return readings and calibrations of the specified parameters")]
        public List<string> Parameters { get; set; }

        ///<summary>
        ///If set, only return inspections of the specified types, selected from: BubbleGage, CrestStageGage, WireWeightGage, MaximumMinimumGage, WaterQuality, FieldMeter, Other
        ///</summary>
        [ApiMember(AllowMultiple=true, DataType="array", Description="If set, only return inspections of the specified types, selected from: BubbleGage, CrestStageGage, WireWeightGage, MaximumMinimumGage, WaterQuality, FieldMeter, Other")]
        public List<InspectionType> InspectionTypes { get; set; }

        ///<summary>
        ///True if node details (raw JSON of each specific activity) should be included
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if node details (raw JSON of each specific activity) should be included")]
        public bool? IncludeNodeDetails { get; set; }

        ///<summary>
        ///True if invalid activities (requiring operator intervention) should be included
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if invalid activities (requiring operator intervention) should be included")]
        public bool? IncludeInvalidActivities { get; set; }

        ///<summary>
        ///True if data values should have rounding rules applied
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if data values should have rounding rules applied")]
        public bool? ApplyRounding { get; set; }

        ///<summary>
        ///True if point velocity discharge activities should include verticals
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if point velocity discharge activities should include verticals")]
        public bool? IncludeVerticals { get; set; }

        ///<summary>
        ///True if cross-section survey activities should include cross-section profile
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if cross-section survey activities should include cross-section profile")]
        public bool? IncludeCrossSectionSurveyProfile { get; set; }

        ///<summary>
        ///True if length reading values should be converted to the Local Assumed Datum
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if length reading values should be converted to the Local Assumed Datum")]
        public bool? ConvertToLocalAssumedDatum { get; set; }

        ///<summary>
        ///If set, length reading values will be converted to the specified Standard Reference Datum
        ///</summary>
        [ApiMember(Description="If set, length reading values will be converted to the specified Standard Reference Datum")]
        public string ConvertToStandardReferenceDatum { get; set; }
    }

    [Route("/GetFieldVisitData", "GET")]
    public class FieldVisitDataServiceRequest
        : IReturn<FieldVisitDataServiceResponse>, IFieldVisitDataRequest
    {
        ///<summary>
        ///Field visit identifier
        ///</summary>
        [ApiMember(Description="Field visit identifier", IsRequired=true)]
        public string FieldVisitIdentifier { get; set; }

        ///<summary>
        ///If set, only report the specific activity type: One of Inspection, DischargeSummary, DischargePointVelocity, DischargeVolumetric, DischargeEngineeredStructure, DischargeAdcp, DischargeOtherMethod, GageHeightAtZeroFlow, ControlCondition, CrossSectionSurvey or LevelSurvey
        ///</summary>
        [ApiMember(Description="If set, only report the specific activity type: One of Inspection, DischargeSummary, DischargePointVelocity, DischargeVolumetric, DischargeEngineeredStructure, DischargeAdcp, DischargeOtherMethod, GageHeightAtZeroFlow, ControlCondition, CrossSectionSurvey or LevelSurvey")]
        public string DiscreteMeasurementActivity { get; set; }

        ///<summary>
        ///True if node details (raw JSON of each specific activity) should be included
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if node details (raw JSON of each specific activity) should be included")]
        public bool? IncludeNodeDetails { get; set; }

        ///<summary>
        ///True if invalid activities (requiring operator intervention) should be included
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if invalid activities (requiring operator intervention) should be included")]
        public bool? IncludeInvalidActivities { get; set; }

        ///<summary>
        ///True if data values should have rounding rules applied
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if data values should have rounding rules applied")]
        public bool? ApplyRounding { get; set; }

        ///<summary>
        ///True if point velocity discharge activities should include verticals
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if point velocity discharge activities should include verticals")]
        public bool? IncludeVerticals { get; set; }

        ///<summary>
        ///True if cross-section survey activities should include cross-section profile
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if cross-section survey activities should include cross-section profile")]
        public bool? IncludeCrossSectionSurveyProfile { get; set; }

        ///<summary>
        ///True if length reading values should be converted to the Local Assumed Datum
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if length reading values should be converted to the Local Assumed Datum")]
        public bool? ConvertToLocalAssumedDatum { get; set; }

        ///<summary>
        ///If set, length reading values will be converted to the specified Standard Reference Datum
        ///</summary>
        [ApiMember(Description="If set, length reading values will be converted to the specified Standard Reference Datum")]
        public string ConvertToStandardReferenceDatum { get; set; }
    }

    [Route("/GetFieldVisitDescriptionList", "GET")]
    public class FieldVisitDescriptionListServiceRequest
        : IReturn<FieldVisitDescriptionListServiceResponse>
    {
        ///<summary>
        ///Filter results to the given location
        ///</summary>
        [ApiMember(Description="Filter results to the given location")]
        public string LocationIdentifier { get; set; }

        ///<summary>
        ///Filter results to items with a StartTime at or after the QueryFrom time
        ///</summary>
        [ApiMember(DataType="string", Description="Filter results to items with a StartTime at or after the QueryFrom time", Format="date-time")]
        public DateTimeOffset? QueryFrom { get; set; }

        ///<summary>
        ///Filter results to items with an EndTime at or before the QueryTo time
        ///</summary>
        [ApiMember(DataType="string", Description="Filter results to items with an EndTime at or before the QueryTo time", Format="date-time")]
        public DateTimeOffset? QueryTo { get; set; }

        ///<summary>
        ///True if the results should include invalid field visits which require operator attention.
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if the results should include invalid field visits which require operator attention.")]
        public bool? IncludeInvalidFieldVisits { get; set; }

        ///<summary>
        ///Filter results to items modified at or after the ChangesSinceToken time
        ///</summary>
        [ApiMember(DataType="string", Description="Filter results to items modified at or after the ChangesSinceToken time", Format="date-time")]
        public DateTime? ChangesSinceToken { get; set; }
    }

    [Route("/GetAuthToken", "GET")]
    public class GetAuthTokenServiceRequest
        : IReturn<string>
    {
        ///<summary>
        ///Username
        ///</summary>
        [ApiMember(Description="Username")]
        public string Username { get; set; }

        ///<summary>
        ///Encrypted password
        ///</summary>
        [ApiMember(Description="Encrypted password")]
        public string EncryptedPassword { get; set; }

        ///<summary>
        ///Locale
        ///</summary>
        [ApiMember(Description="Locale")]
        public string Locale { get; set; }
    }

    [Route("/GetFieldVisitReadingsByLocation", "GET")]
    public class GetFieldVisitReadingsByLocationServiceRequest
        : IReturn<FieldVisitReadingsByLocationServiceResponse>
    {
        public GetFieldVisitReadingsByLocationServiceRequest()
        {
            Parameters = new List<string>{};
        }

        ///<summary>
        ///Location identifier. Must be empty when LocationUniqueId is set.
        ///</summary>
        [ApiMember(Description="Location identifier. Must be empty when LocationUniqueId is set.")]
        public string LocationIdentifier { get; set; }

        ///<summary>
        ///Location unique ID. Must be empty when LocationIdentifier is set.
        ///</summary>
        [ApiMember(DataType="string", Description="Location unique ID. Must be empty when LocationIdentifier is set.", Format="guid")]
        public Guid? LocationUniqueId { get; set; }

        ///<summary>
        ///If set, only return readings of the specified parameters
        ///</summary>
        [ApiMember(DataType="array", Description="If set, only return readings of the specified parameters")]
        public List<string> Parameters { get; set; }

        ///<summary>
        ///Filter results to items matching the Publish value
        ///</summary>
        [ApiMember(DataType="boolean", Description="Filter results to items matching the Publish value")]
        public bool? Publish { get; set; }

        ///<summary>
        ///True if data values should have rounding rules applied
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if data values should have rounding rules applied")]
        public bool? ApplyRounding { get; set; }

        ///<summary>
        ///True if length reading values should be converted to all configured vertical datums in the location
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if length reading values should be converted to all configured vertical datums in the location")]
        public bool? ApplyDatumConversion { get; set; }
    }

    [Route("/GetGradeList", "GET")]
    public class GradeListServiceRequest
        : IReturn<GradeListServiceResponse>
    {
    }

    public interface IFieldVisitDataRequest
    {
        bool? IncludeNodeDetails { get; set; }
        bool? IncludeInvalidActivities { get; set; }
        bool? ApplyRounding { get; set; }
        bool? IncludeVerticals { get; set; }
        bool? IncludeCrossSectionSurveyProfile { get; set; }
        bool? ConvertToLocalAssumedDatum { get; set; }
        string ConvertToStandardReferenceDatum { get; set; }
    }

    [Route("/GetLocationData", "GET")]
    public class LocationDataServiceRequest
        : IReturn<LocationDataServiceResponse>
    {
        ///<summary>
        ///Location identifier
        ///</summary>
        [ApiMember(Description="Location identifier", IsRequired=true)]
        public string LocationIdentifier { get; set; }

        ///<summary>
        ///True if location attachments should be included in the results
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if location attachments should be included in the results")]
        public bool? IncludeLocationAttachments { get; set; }
    }

    [Route("/GetLocationDescriptionList", "GET")]
    public class LocationDescriptionListServiceRequest
        : IReturn<LocationDescriptionListServiceResponse>
    {
        public LocationDescriptionListServiceRequest()
        {
            TagNames = new List<string>{};
            TagKeys = new List<string>{};
            TagValues = new List<string>{};
            ExtendedFilters = new List<ExtendedAttributeFilter>{};
        }

        ///<summary>
        ///Filter results to the given location name (supports *partialname* pattern*)
        ///</summary>
        [ApiMember(Description="Filter results to the given location name (supports *partialname* pattern*)")]
        public string LocationName { get; set; }

        ///<summary>
        ///Filter results to the given location identifier (supports *partialname* pattern)
        ///</summary>
        [ApiMember(Description="Filter results to the given location identifier (supports *partialname* pattern)")]
        public string LocationIdentifier { get; set; }

        ///<summary>
        ///Filter results to the given location folder (supports *partialname* pattern)
        ///</summary>
        [ApiMember(Description="Filter results to the given location folder (supports *partialname* pattern)")]
        public string LocationFolder { get; set; }

        ///<summary>
        ///DEPRECATED: renamed to TagKeys
        ///</summary>
        [ApiMember(DataType="array", Description="DEPRECATED: renamed to TagKeys")]
        public List<string> TagNames { get; set; }

        ///<summary>
        ///Filter results to locations matching all tags by key (supports *partialname* pattern)
        ///</summary>
        [ApiMember(DataType="array", Description="Filter results to locations matching all tags by key (supports *partialname* pattern)")]
        public List<string> TagKeys { get; set; }

        ///<summary>
        ///Filter results to locations matching all tags by value (supports *partialname* pattern)
        ///</summary>
        [ApiMember(DataType="array", Description="Filter results to locations matching all tags by value (supports *partialname* pattern)")]
        public List<string> TagValues { get; set; }

        ///<summary>
        ///Filter results to items matching the given extended attribute values
        ///</summary>
        [ApiMember(DataType="array", Description="Filter results to items matching the given extended attribute values")]
        public List<ExtendedAttributeFilter> ExtendedFilters { get; set; }

        ///<summary>
        ///Filter results to items matching the Publish value
        ///</summary>
        [ApiMember(DataType="boolean", Description="Filter results to items matching the Publish value")]
        public bool? Publish { get; set; }

        ///<summary>
        ///Filter results to items modified at or after the ChangesSinceToken time
        ///</summary>
        [ApiMember(DataType="string", Description="Filter results to items modified at or after the ChangesSinceToken time", Format="date-time")]
        public DateTime? ChangesSinceToken { get; set; }
    }

    [Route("/GetLocationTagList", "GET")]
    public class LocationTagListServiceRequest
        : IReturn<LocationTagListServiceResponse>
    {
    }

    [Route("/GetMetadataChangeTransactionList", "GET")]
    public class MetadataChangeTransactionListServiceRequest
        : IReturn<MetadataChangeTransactionListServiceResponse>
    {
        ///<summary>
        ///The unique ID of the time series
        ///</summary>
        [ApiMember(DataType="string", Description="The unique ID of the time series", Format="guid", IsRequired=true)]
        public Guid TimeSeriesUniqueId { get; set; }

        ///<summary>
        ///Filter results to items with a StartTime at or after the QueryFrom time
        ///</summary>
        [ApiMember(DataType="string", Description="Filter results to items with a StartTime at or after the QueryFrom time", Format="date-time")]
        public DateTimeOffset? QueryFrom { get; set; }

        ///<summary>
        ///Filter results to items with an EndTime at or before the QueryTo time
        ///</summary>
        [ApiMember(DataType="string", Description="Filter results to items with an EndTime at or before the QueryTo time", Format="date-time")]
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
        ///<summary>
        ///Rating model identifier
        ///</summary>
        [ApiMember(Description="Rating model identifier", IsRequired=true)]
        public string RatingModelIdentifier { get; set; }

        ///<summary>
        ///Forces the response time values to a specific UTC offset. Defaults to the location UTC offset
        ///</summary>
        [ApiMember(DataType="number", Description="Forces the response time values to a specific UTC offset. Defaults to the location UTC offset", Format="double")]
        public double? UtcOffset { get; set; }

        ///<summary>
        ///Filter results to curves with a Period.StartTime at or after the QueryFrom time
        ///</summary>
        [ApiMember(DataType="string", Description="Filter results to curves with a Period.StartTime at or after the QueryFrom time", Format="date-time")]
        public DateTimeOffset? QueryFrom { get; set; }

        ///<summary>
        ///Filter results to curves with a Period.EndTime at or before the QueryTo time
        ///</summary>
        [ApiMember(DataType="string", Description="Filter results to curves with a Period.EndTime at or before the QueryTo time", Format="date-time")]
        public DateTimeOffset? QueryTo { get; set; }
    }

    [Route("/GetRatingModelDescriptionList", "GET")]
    public class RatingModelDescriptionListServiceRequest
        : IReturn<RatingModelDescriptionListServiceResponse>
    {
        ///<summary>
        ///Filter results to the given location
        ///</summary>
        [ApiMember(Description="Filter results to the given location")]
        public string LocationIdentifier { get; set; }

        ///<summary>
        ///Filter results to items matching the Publish value
        ///</summary>
        [ApiMember(DataType="boolean", Description="Filter results to items matching the Publish value")]
        public bool? Publish { get; set; }

        ///<summary>
        ///Filter results to items maching the InputParameter identifier
        ///</summary>
        [ApiMember(Description="Filter results to items maching the InputParameter identifier")]
        public string InputParameter { get; set; }

        ///<summary>
        ///Filter results to items maching the OutputParameter identifier
        ///</summary>
        [ApiMember(Description="Filter results to items maching the OutputParameter identifier")]
        public string OutputParameter { get; set; }

        ///<summary>
        ///Filter results to items modified at or after the ChangesSinceToken time
        ///</summary>
        [ApiMember(DataType="string", Description="Filter results to items modified at or after the ChangesSinceToken time", Format="date-time")]
        public DateTime? ChangesSinceToken { get; set; }
    }

    [Route("/GetRatingModelEffectiveShiftsByStageValues", "GET")]
    public class RatingModelEffectiveShiftsByStageValuesServiceRequest
        : IReturn<RatingModelEffectiveShiftsByStageValuesServiceResponse>
    {
        public RatingModelEffectiveShiftsByStageValuesServiceRequest()
        {
            StageValues = new List<double>{};
        }

        ///<summary>
        ///Rating model identifier
        ///</summary>
        [ApiMember(Description="Rating model identifier", IsRequired=true)]
        public string RatingModelIdentifier { get; set; }

        ///<summary>
        ///The time at which the shift is to be applied
        ///</summary>
        [ApiMember(DataType="string", Description="The time at which the shift is to be applied", Format="date-time", IsRequired=true)]
        public DateTimeOffset? MeasurementTime { get; set; }

        ///<summary>
        ///The input stage values to which the shift is to be applied
        ///</summary>
        [ApiMember(DataType="array", Description="The input stage values to which the shift is to be applied", IsRequired=true)]
        public List<double> StageValues { get; set; }
    }

    [Route("/GetRatingModelEffectiveShifts", "GET")]
    public class RatingModelEffectiveShiftsServiceRequest
        : IReturn<RatingModelEffectiveShiftsServiceResponse>
    {
        ///<summary>
        ///Unique ID of the input time series
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the input time series", Format="guid", IsRequired=true)]
        public Guid TimeSeriesUniqueId { get; set; }

        ///<summary>
        ///Rating model identifier
        ///</summary>
        [ApiMember(Description="Rating model identifier", IsRequired=true)]
        public string RatingModelIdentifier { get; set; }

        ///<summary>
        ///Read the input time series starting at the QueryFrom time. Defaults to beginning of record
        ///</summary>
        [ApiMember(DataType="string", Description="Read the input time series starting at the QueryFrom time. Defaults to beginning of record", Format="date-time")]
        public DateTimeOffset? QueryFrom { get; set; }

        ///<summary>
        ///Read the input time series ending at the QueryTo time. Defaults to the end of record.
        ///</summary>
        [ApiMember(DataType="string", Description="Read the input time series ending at the QueryTo time. Defaults to the end of record.", Format="date-time")]
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

        ///<summary>
        ///Rating model identifier
        ///</summary>
        [ApiMember(Description="Rating model identifier", IsRequired=true)]
        public string RatingModelIdentifier { get; set; }

        ///<summary>
        ///Output values
        ///</summary>
        [ApiMember(DataType="array", Description="Output values", IsRequired=true)]
        public List<double> OutputValues { get; set; }

        ///<summary>
        ///Effective time of the calculation. Defaults to the current time if not specified
        ///</summary>
        [ApiMember(DataType="string", Description="Effective time of the calculation. Defaults to the current time if not specified", Format="date-time")]
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

        ///<summary>
        ///Rating model identifier
        ///</summary>
        [ApiMember(Description="Rating model identifier", IsRequired=true)]
        public string RatingModelIdentifier { get; set; }

        ///<summary>
        ///Input values
        ///</summary>
        [ApiMember(DataType="array", Description="Input values", IsRequired=true)]
        public List<double> InputValues { get; set; }

        ///<summary>
        ///Effective time of the calculation. Defaults to the current time if not specified
        ///</summary>
        [ApiMember(DataType="string", Description="Effective time of the calculation. Defaults to the current time if not specified", Format="date-time")]
        public DateTimeOffset? EffectiveTime { get; set; }

        ///<summary>
        ///Set to false to disable rating curve shifts, otherwise true
        ///</summary>
        [ApiMember(DataType="boolean", Description="Set to false to disable rating curve shifts, otherwise true")]
        public bool? ApplyShifts { get; set; }
    }

    [Route("/GetReportList", "GET")]
    public class ReportListServiceRequest
        : IReturn<ReportListServiceResponse>
    {
        public ReportListServiceRequest()
        {
            TimeSeriesUniqueIds = new List<Guid>{};
            ReportUniqueIds = new List<Guid>{};
            TagKeys = new List<string>{};
            TagValues = new List<string>{};
        }

        ///<summary>
        ///Filter results to given location unique ID
        ///</summary>
        [ApiMember(DataType="string", Description="Filter results to given location unique ID", Format="guid")]
        public Guid? LocationUniqueId { get; set; }

        ///<summary>
        ///Filter results to given source time series unique IDs
        ///</summary>
        [ApiMember(DataType="array", Description="Filter results to given source time series unique IDs")]
        public List<Guid> TimeSeriesUniqueIds { get; set; }

        ///<summary>
        ///Filter results to the given user unique ID
        ///</summary>
        [ApiMember(DataType="string", Description="Filter results to the given user unique ID", Format="guid")]
        public Guid? UserUniqueId { get; set; }

        ///<summary>
        ///Filter results to the given report title
        ///</summary>
        [ApiMember(Description="Filter results to the given report title")]
        public string ReportTitle { get; set; }

        ///<summary>
        ///Filter results to given report unique IDs
        ///</summary>
        [ApiMember(DataType="array", Description="Filter results to given report unique IDs")]
        public List<Guid> ReportUniqueIds { get; set; }

        ///<summary>
        ///Filter results to items created at or after the CreatedFrom time
        ///</summary>
        [ApiMember(DataType="string", Description="Filter results to items created at or after the CreatedFrom time", Format="date-time")]
        public DateTimeOffset? CreatedFrom { get; set; }

        ///<summary>
        ///Filter results to items matching all tags by key (supports *partialname* pattern)
        ///</summary>
        [ApiMember(DataType="array", Description="Filter results to items matching all tags by key (supports *partialname* pattern)")]
        public List<string> TagKeys { get; set; }

        ///<summary>
        ///Filter results to items matching all tags by value (supports *partialname* pattern)
        ///</summary>
        [ApiMember(DataType="array", Description="Filter results to items matching all tags by value (supports *partialname* pattern)")]
        public List<string> TagValues { get; set; }

        ///<summary>
        ///Limit the number of results items, after all filtering and ordering
        ///</summary>
        [ApiMember(DataType="integer", Description="Limit the number of results items, after all filtering and ordering", Format="int32")]
        public int? MaxResults { get; set; }
    }

    [Route("/Round/ByParameter", "PUT")]
    public class RoundServiceRequest
        : IReturn<RoundServiceResponse>
    {
        public RoundServiceRequest()
        {
            Data = new List<double>{};
        }

        ///<summary>
        ///The data is for this parameter
        ///</summary>
        [ApiMember(Description="The data is for this parameter", IsRequired=true)]
        public string ParameterDisplayId { get; set; }

        ///<summary>
        ///The data is in this unit. Used to modify rounding spec to maintain precision
        ///</summary>
        [ApiMember(Description="The data is in this unit. Used to modify rounding spec to maintain precision", IsRequired=true)]
        public string UnitId { get; set; }

        ///<summary>
        ///The data was measured using this method. Specify only if known
        ///</summary>
        [ApiMember(Description="The data was measured using this method. Specify only if known")]
        public string MethodCode { get; set; }

        ///<summary>
        ///If specified, return this value for inputs which are NaNs. Otherwise returns EMPTY for NaNs.
        ///</summary>
        [ApiMember(Description="If specified, return this value for inputs which are NaNs. Otherwise returns EMPTY for NaNs.")]
        public string ValueForNaN { get; set; }

        ///<summary>
        ///A list of data values to be rounded and returned as strings
        ///</summary>
        [ApiMember(DataType="array", Description="A list of data values to be rounded and returned as strings", IsRequired=true)]
        public List<double> Data { get; set; }
    }

    [Route("/Round/ToSpec", "PUT")]
    public class RoundServiceSpecRequest
        : IReturn<RoundServiceResponse>
    {
        public RoundServiceSpecRequest()
        {
            Data = new List<double>{};
        }

        ///<summary>
        ///Use this rounding specification to round the data
        ///</summary>
        [ApiMember(Description="Use this rounding specification to round the data", IsRequired=true)]
        public string RoundingSpec { get; set; }

        ///<summary>
        ///If specified, return this value for inputs which are NaNs. Otherwise returns EMPTY for NaNs.
        ///</summary>
        [ApiMember(Description="If specified, return this value for inputs which are NaNs. Otherwise returns EMPTY for NaNs.")]
        public string ValueForNaN { get; set; }

        ///<summary>
        ///A list of data values to be rounded and returned as strings
        ///</summary>
        [ApiMember(DataType="array", Description="A list of data values to be rounded and returned as strings", IsRequired=true)]
        public List<double> Data { get; set; }
    }

    [Route("/GetSensorsAndGauges", "GET,POST")]
    public class SensorsAndGaugesServiceRequest
        : IReturn<SensorsAndGaugesServiceResponse>
    {
        public SensorsAndGaugesServiceRequest()
        {
            LocationUniqueIds = new List<Guid>{};
            TagKeys = new List<string>{};
            TagValues = new List<string>{};
        }

        ///<summary>
        ///Filter results to sensors and gauges for this location
        ///</summary>
        [ApiMember(Description="Filter results to sensors and gauges for this location")]
        public string LocationIdentifier { get; set; }

        ///<summary>
        ///Filter results to sensors and gauges for these locations. Limited to roughly 60 items for a GET request; use POST to avoid this limit.
        ///</summary>
        [ApiMember(DataType="array", Description="Filter results to sensors and gauges for these locations. Limited to roughly 60 items for a GET request; use POST to avoid this limit.")]
        public List<Guid> LocationUniqueIds { get; set; }

        ///<summary>
        ///Filter results to sensors and gauges matching all tags by key (supports *partialname* pattern)
        ///</summary>
        [ApiMember(DataType="array", Description="Filter results to sensors and gauges matching all tags by key (supports *partialname* pattern)")]
        public List<string> TagKeys { get; set; }

        ///<summary>
        ///Filter results to sensors and gauges matching all tags by value (supports *partialname* pattern)
        ///</summary>
        [ApiMember(DataType="array", Description="Filter results to sensors and gauges matching all tags by value (supports *partialname* pattern)")]
        public List<string> TagValues { get; set; }
    }

    [Route("/GetTagList", "GET")]
    public class TagListServiceRequest
        : IReturn<TagListServiceResponse>
    {
        public TagListServiceRequest()
        {
            Applicability = new List<TagApplicability>{};
        }

        ///<summary>
        ///If set, return only tags with specified applicability, selected from: AppliesToLocations, AppliesToLocationNotes, AppliesToSensorsGauges, AppliesToAttachments, AppliesToReports
        ///</summary>
        [ApiMember(AllowMultiple=true, DataType="array", Description="If set, return only tags with specified applicability, selected from: AppliesToLocations, AppliesToLocationNotes, AppliesToSensorsGauges, AppliesToAttachments, AppliesToReports")]
        public List<TagApplicability> Applicability { get; set; }
    }

    [Route("/GetTimeSeriesData", "GET")]
    public class TimeAlignedDataServiceRequest
        : IReturn<TimeAlignedDataServiceResponse>
    {
        public TimeAlignedDataServiceRequest()
        {
            TimeSeriesUniqueIds = new List<Guid>{};
            TimeSeriesOutputUnitIds = new List<string>{};
        }

        ///<summary>
        ///The unique IDs of the time-series to retrieve
        ///</summary>
        [ApiMember(DataType="array", Description="The unique IDs of the time-series to retrieve", IsRequired=true)]
        public List<Guid> TimeSeriesUniqueIds { get; set; }

        ///<summary>
        ///The unit identifiers for points. Defaults to the time-series unit
        ///</summary>
        [ApiMember(DataType="array", Description="The unit identifiers for points. Defaults to the time-series unit")]
        public List<string> TimeSeriesOutputUnitIds { get; set; }

        ///<summary>
        ///Filter results to items at or after the QueryFrom time
        ///</summary>
        [ApiMember(DataType="string", Description="Filter results to items at or after the QueryFrom time", Format="date-time")]
        public DateTimeOffset? QueryFrom { get; set; }

        ///<summary>
        ///Filter results to items at or before the QueryTo time
        ///</summary>
        [ApiMember(DataType="string", Description="Filter results to items at or before the QueryTo time", Format="date-time")]
        public DateTimeOffset? QueryTo { get; set; }

        ///<summary>
        ///Forces the response time values to a specific UTC offset. Defaults to the UTC offset of the first time-series
        ///</summary>
        [ApiMember(DataType="number", Description="Forces the response time values to a specific UTC offset. Defaults to the UTC offset of the first time-series", Format="double")]
        public double? UtcOffset { get; set; }

        ///<summary>
        ///True if data values should have rounding rules applied
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if data values should have rounding rules applied")]
        public bool? ApplyRounding { get; set; }

        ///<summary>
        ///True if the point results should include gap markers
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if the point results should include gap markers")]
        public bool? IncludeGapMarkers { get; set; }
    }

    [Route("/GetApprovalsTransactionList", "GET")]
    public class TimeSeriesApprovalsTransactionListServiceRequest
        : IReturn<TimeSeriesApprovalsTransactionListServiceResponse>
    {
        ///<summary>
        ///The unique ID of the time series
        ///</summary>
        [ApiMember(DataType="string", Description="The unique ID of the time series", Format="guid", IsRequired=true)]
        public Guid TimeSeriesUniqueId { get; set; }

        ///<summary>
        ///Filter results to items with a StartTime at or after the QueryFrom time
        ///</summary>
        [ApiMember(DataType="string", Description="Filter results to items with a StartTime at or after the QueryFrom time", Format="date-time")]
        public DateTimeOffset? QueryFrom { get; set; }

        ///<summary>
        ///Filter results to items with an EndTime at or before the QueryTo time
        ///</summary>
        [ApiMember(DataType="string", Description="Filter results to items with an EndTime at or before the QueryTo time", Format="date-time")]
        public DateTimeOffset? QueryTo { get; set; }
    }

    [Route("/GetTimeSeriesCorrectedData", "GET")]
    public class TimeSeriesDataCorrectedServiceRequest
        : IReturn<TimeSeriesDataServiceResponse>
    {
        ///<summary>
        ///The unique ID of the time series
        ///</summary>
        [ApiMember(DataType="string", Description="The unique ID of the time series", Format="guid", IsRequired=true)]
        public Guid TimeSeriesUniqueId { get; set; }

        ///<summary>
        ///Filter results to items at or after the QueryFrom time
        ///</summary>
        [ApiMember(DataType="string", Description="Filter results to items at or after the QueryFrom time", Format="date-time")]
        public DateTimeOffset? QueryFrom { get; set; }

        ///<summary>
        ///Filter results to items at or before the QueryTo time
        ///</summary>
        [ApiMember(DataType="string", Description="Filter results to items at or before the QueryTo time", Format="date-time")]
        public DateTimeOffset? QueryTo { get; set; }

        ///<summary>
        ///The level of time series detail to report. One of 'All', 'PointsOnly', or 'MetadataOnly'. Defaults to 'All'
        ///</summary>
        [ApiMember(Description="The level of time series detail to report. One of 'All', 'PointsOnly', or 'MetadataOnly'. Defaults to 'All'")]
        public string GetParts { get; set; }

        ///<summary>
        ///The unit identifier for points. Defaults to the time series unit
        ///</summary>
        [ApiMember(Description="The unit identifier for points. Defaults to the time series unit")]
        public string Unit { get; set; }

        ///<summary>
        ///Forces the response time values to a specific UTC offset. Defaults to the time series UTC offset
        ///</summary>
        [ApiMember(DataType="number", Description="Forces the response time values to a specific UTC offset. Defaults to the time series UTC offset", Format="double")]
        public double? UtcOffset { get; set; }

        ///<summary>
        ///True if data values should have rounding rules applied
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if data values should have rounding rules applied")]
        public bool? ApplyRounding { get; set; }

        ///<summary>
        ///Defaults to false. See the API reference guide for details
        ///</summary>
        [ApiMember(DataType="boolean", Description="Defaults to false. See the API reference guide for details")]
        public bool? ReturnFullCoverage { get; set; }

        ///<summary>
        ///True if the point results should include gap markers
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if the point results should include gap markers")]
        public bool? IncludeGapMarkers { get; set; }
    }

    [Route("/GetTimeSeriesRawData", "GET")]
    public class TimeSeriesDataRawServiceRequest
        : IReturn<TimeSeriesDataServiceResponse>
    {
        ///<summary>
        ///The unique ID of the time series
        ///</summary>
        [ApiMember(DataType="string", Description="The unique ID of the time series", Format="guid", IsRequired=true)]
        public Guid TimeSeriesUniqueId { get; set; }

        ///<summary>
        ///Filter results to items at or after the QueryFrom time
        ///</summary>
        [ApiMember(DataType="string", Description="Filter results to items at or after the QueryFrom time", Format="date-time")]
        public DateTimeOffset? QueryFrom { get; set; }

        ///<summary>
        ///Filter results to items at or before the QueryTo time
        ///</summary>
        [ApiMember(DataType="string", Description="Filter results to items at or before the QueryTo time", Format="date-time")]
        public DateTimeOffset? QueryTo { get; set; }

        ///<summary>
        ///Sets the level of time series detail to report. One of 'All', 'PointsOnly', or 'MetadataOnly'. Defaults to 'All'
        ///</summary>
        [ApiMember(Description="Sets the level of time series detail to report. One of 'All', 'PointsOnly', or 'MetadataOnly'. Defaults to 'All'")]
        public string GetParts { get; set; }

        ///<summary>
        ///The unit identifier for points. Defaults to the time series unit
        ///</summary>
        [ApiMember(Description="The unit identifier for points. Defaults to the time series unit")]
        public string Unit { get; set; }

        ///<summary>
        ///Forces the response time values to a specific UTC offset. Defaults to the time series UTC offset
        ///</summary>
        [ApiMember(DataType="number", Description="Forces the response time values to a specific UTC offset. Defaults to the time series UTC offset", Format="double")]
        public double? UtcOffset { get; set; }

        ///<summary>
        ///True if data values should have rounding rules applied
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if data values should have rounding rules applied")]
        public bool? ApplyRounding { get; set; }
    }

    [Route("/GetTimeSeriesDescriptionListByUniqueId", "GET,POST")]
    public class TimeSeriesDescriptionListByUniqueIdServiceRequest
        : IReturn<TimeSeriesDescriptionListByUniqueIdServiceResponse>
    {
        public TimeSeriesDescriptionListByUniqueIdServiceRequest()
        {
            TimeSeriesUniqueIds = new List<Guid>{};
        }

        ///<summary>
        ///A collection of time series unique IDs to query. Limited to roughly 60 items for a GET request; use POST to avoid this limit.
        ///</summary>
        [ApiMember(DataType="array", Description="A collection of time series unique IDs to query. Limited to roughly 60 items for a GET request; use POST to avoid this limit.")]
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

        ///<summary>
        ///Filter results to the given location
        ///</summary>
        [ApiMember(Description="Filter results to the given location")]
        public string LocationIdentifier { get; set; }

        ///<summary>
        ///Filter results to items matching the parameter identifier
        ///</summary>
        [ApiMember(Description="Filter results to items matching the parameter identifier")]
        public string Parameter { get; set; }

        ///<summary>
        ///Filter results to items matching the Publish value
        ///</summary>
        [ApiMember(DataType="boolean", Description="Filter results to items matching the Publish value")]
        public bool? Publish { get; set; }

        ///<summary>
        ///Filter results to items matching the computation identifier
        ///</summary>
        [ApiMember(Description="Filter results to items matching the computation identifier")]
        public string ComputationIdentifier { get; set; }

        ///<summary>
        ///Filter results to items matching the computation period identifier
        ///</summary>
        [ApiMember(Description="Filter results to items matching the computation period identifier")]
        public string ComputationPeriodIdentifier { get; set; }

        ///<summary>
        ///Filter results to items matching the given extended attribute values
        ///</summary>
        [ApiMember(DataType="array", Description="Filter results to items matching the given extended attribute values")]
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

        ///<summary>
        ///Filter results to items modified at or after the ChangesSinceToken time
        ///</summary>
        [ApiMember(DataType="string", Description="Filter results to items modified at or after the ChangesSinceToken time", Format="date-time")]
        public DateTime? ChangesSinceToken { get; set; }

        ///<summary>
        ///Filter results to a specific change event type: 'Data' or 'Attribute'
        ///</summary>
        [ApiMember(Description="Filter results to a specific change event type: 'Data' or 'Attribute'")]
        public string ChangeEventType { get; set; }

        ///<summary>
        ///Filter results to the given location
        ///</summary>
        [ApiMember(Description="Filter results to the given location")]
        public string LocationIdentifier { get; set; }

        ///<summary>
        ///Filter results to items maching the Parameter identifier
        ///</summary>
        [ApiMember(Description="Filter results to items maching the Parameter identifier")]
        public string Parameter { get; set; }

        ///<summary>
        ///Filter results to items matching the Publish value
        ///</summary>
        [ApiMember(DataType="boolean", Description="Filter results to items matching the Publish value")]
        public bool? Publish { get; set; }

        ///<summary>
        ///Filter results to items matching the computation identifier
        ///</summary>
        [ApiMember(Description="Filter results to items matching the computation identifier")]
        public string ComputationIdentifier { get; set; }

        ///<summary>
        ///Filter results to items matching the computation period identifier
        ///</summary>
        [ApiMember(Description="Filter results to items matching the computation period identifier")]
        public string ComputationPeriodIdentifier { get; set; }

        ///<summary>
        ///Filter results to items matching the given extended attribute values
        ///</summary>
        [ApiMember(DataType="array", Description="Filter results to items matching the given extended attribute values")]
        public List<ExtendedAttributeFilter> ExtendedFilters { get; set; }
    }

    [Route("/GetTrendLineAnalysis", "POST")]
    public class TrendLineAnalysisServiceRequest
        : IReturn<TrendLineAnalysisServiceResponse>
    {
        public TrendLineAnalysisServiceRequest()
        {
            Points = new List<TimeSeriesPoint>{};
        }

        ///<summary>
        ///Type of regression analysis
        ///</summary>
        [ApiMember(DataType="string", Description="Type of regression analysis", IsRequired=true)]
        public TrendLineAnalysisType? Type { get; set; }

        ///<summary>
        ///Start Time
        ///</summary>
        [ApiMember(DataType="string", Description="Start Time", Format="date-time", IsRequired=true)]
        public DateTimeOffset? QueryFrom { get; set; }

        ///<summary>
        ///End Time
        ///</summary>
        [ApiMember(DataType="string", Description="End Time", Format="date-time", IsRequired=true)]
        public DateTimeOffset? QueryTo { get; set; }

        ///<summary>
        ///List of data points to perform analysis on. Requires a minimum of three points, and points sorted by timestamp in ascending order. Must not contain any duplicate times.
        ///</summary>
        [ApiMember(DataType="array", Description="List of data points to perform analysis on. Requires a minimum of three points, and points sorted by timestamp in ascending order. Must not contain any duplicate times.", IsRequired=true)]
        public List<TimeSeriesPoint> Points { get; set; }
    }

    [Route("/GetUnitList", "GET")]
    public class UnitListServiceRequest
        : IReturn<UnitListServiceResponse>
    {
        ///<summary>
        ///Filter results to the given Unit Group
        ///</summary>
        [ApiMember(Description="Filter results to the given Unit Group")]
        public string GroupIdentifier { get; set; }
    }

    [Route("/GetUpchainProcessorListByTimeSeries", "GET")]
    public class UpchainProcessorListByTimeSeriesServiceRequest
        : IReturn<ProcessorListServiceResponse>
    {
        ///<summary>
        ///Unique ID of the time series
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the time series", Format="guid", IsRequired=true)]
        public Guid TimeSeriesUniqueId { get; set; }

        ///<summary>
        ///Filter results to items with a ProcessorPeriod.StartTime at or after the QueryFrom time
        ///</summary>
        [ApiMember(DataType="string", Description="Filter results to items with a ProcessorPeriod.StartTime at or after the QueryFrom time", Format="date-time")]
        public DateTimeOffset? QueryFrom { get; set; }

        ///<summary>
        ///Filter results to items with a ProcessorPeriod.EndTime at or before the QueryTo time
        ///</summary>
        [ApiMember(DataType="string", Description="Filter results to items with a ProcessorPeriod.EndTime at or before the QueryTo time", Format="date-time")]
        public DateTimeOffset? QueryTo { get; set; }
    }

    public class ActiveMetersAndCalibrationsServiceResponse
        : PublishServiceResponse
    {
        public ActiveMetersAndCalibrationsServiceResponse()
        {
            ActiveMeterDetails = new List<ActiveMeterDetails>{};
        }

        ///<summary>
        ///Current meter details
        ///</summary>
        [ApiMember(DataType="array", Description="Current meter details")]
        public List<ActiveMeterDetails> ActiveMeterDetails { get; set; }
    }

    public class ApprovalListServiceResponse
        : PublishServiceResponse
    {
        public ApprovalListServiceResponse()
        {
            Approvals = new List<ApprovalMetadata>{};
        }

        ///<summary>
        ///Approvals
        ///</summary>
        [ApiMember(DataType="array", Description="Approvals")]
        public List<ApprovalMetadata> Approvals { get; set; }
    }

    public class CorrectionListServiceResponse
        : PublishServiceResponse
    {
        public CorrectionListServiceResponse()
        {
            Corrections = new List<Correction>{};
        }

        ///<summary>
        ///Corrections
        ///</summary>
        [ApiMember(DataType="array", Description="Corrections")]
        public List<Correction> Corrections { get; set; }
    }

    public class EffectiveRatingCurveServiceResponse
        : PublishServiceResponse
    {
        ///<summary>
        ///Expanded rating curve
        ///</summary>
        [ApiMember(DataType="ExpandedRatingCurve", Description="Expanded rating curve")]
        public ExpandedRatingCurve ExpandedRatingCurve { get; set; }
    }

    public class ExpandedStageTableServiceResponse
        : PublishServiceResponse
    {
        public ExpandedStageTableServiceResponse()
        {
            ExpandedStageTable = new List<StagePoint>{};
            Corrections = new List<Correction>{};
        }

        ///<summary>
        ///Expanded stage table
        ///</summary>
        [ApiMember(DataType="array", Description="Expanded stage table")]
        public List<StagePoint> ExpandedStageTable { get; set; }

        ///<summary>
        ///Corrections
        ///</summary>
        [ApiMember(DataType="array", Description="Corrections")]
        public List<Correction> Corrections { get; set; }
    }

    public class FieldVisitDataByLocationServiceResponse
        : PublishServiceResponse
    {
        public FieldVisitDataByLocationServiceResponse()
        {
            FieldVisitData = new List<FieldVisit>{};
        }

        ///<summary>
        ///Field visit descriptions and data
        ///</summary>
        [ApiMember(DataType="array", Description="Field visit descriptions and data")]
        public List<FieldVisit> FieldVisitData { get; set; }
    }

    public class FieldVisitDataServiceResponse
        : PublishServiceResponse, IFieldVisitData
    {
        public FieldVisitDataServiceResponse()
        {
            Attachments = new List<Attachment>{};
            DischargeActivities = new List<DischargeActivity>{};
            CrossSectionSurveyActivity = new List<CrossSectionSurveyActivity>{};
        }

        ///<summary>
        ///Field visit identifier
        ///</summary>
        [ApiMember(Description="Field visit identifier")]
        public string Identifier { get; set; }

        ///<summary>
        ///Attachments
        ///</summary>
        [ApiMember(DataType="array", Description="Attachments")]
        public List<Attachment> Attachments { get; set; }

        ///<summary>
        ///Discharge activities
        ///</summary>
        [ApiMember(DataType="array", Description="Discharge activities")]
        public List<DischargeActivity> DischargeActivities { get; set; }

        ///<summary>
        ///Gage height at zero flow activity
        ///</summary>
        [ApiMember(DataType="GageHeightAtZeroFlowActivity", Description="Gage height at zero flow activity")]
        public GageHeightAtZeroFlowActivity GageHeightAtZeroFlowActivity { get; set; }

        ///<summary>
        ///Control condition activity
        ///</summary>
        [ApiMember(DataType="ControlConditionActivity", Description="Control condition activity")]
        public ControlConditionActivity ControlConditionActivity { get; set; }

        ///<summary>
        ///Inspection activity
        ///</summary>
        [ApiMember(DataType="InspectionActivity", Description="Inspection activity")]
        public InspectionActivity InspectionActivity { get; set; }

        ///<summary>
        ///Cross-section survey activity
        ///</summary>
        [ApiMember(DataType="array", Description="Cross-section survey activity")]
        public List<CrossSectionSurveyActivity> CrossSectionSurveyActivity { get; set; }

        ///<summary>
        ///Level survey activity
        ///</summary>
        [ApiMember(DataType="LevelSurveyActivity", Description="Level survey activity")]
        public LevelSurveyActivity LevelSurveyActivity { get; set; }

        ///<summary>
        ///Approval
        ///</summary>
        [ApiMember(DataType="FieldVisitApproval", Description="Approval")]
        public FieldVisitApproval Approval { get; set; }

        ///<summary>
        ///Summary results for a requested datum conversion
        ///</summary>
        [ApiMember(DataType="DatumConversionResult", Description="Summary results for a requested datum conversion")]
        public DatumConversionResult DatumConversionResult { get; set; }
    }

    public class FieldVisitDescriptionListServiceResponse
        : PublishServiceResponse
    {
        public FieldVisitDescriptionListServiceResponse()
        {
            FieldVisitDescriptions = new List<FieldVisitDescription>{};
            DeletedFieldVisitDescriptions = new List<FieldVisitDescription>{};
        }

        ///<summary>
        ///Field visit descriptions
        ///</summary>
        [ApiMember(DataType="array", Description="Field visit descriptions")]
        public List<FieldVisitDescription> FieldVisitDescriptions { get; set; }

        ///<summary>
        ///Field visits that have been deleted since the requested ChangesSinceToken
        ///</summary>
        [ApiMember(DataType="array", Description="Field visits that have been deleted since the requested ChangesSinceToken")]
        public List<FieldVisitDescription> DeletedFieldVisitDescriptions { get; set; }

        ///<summary>
        ///Next token
        ///</summary>
        [ApiMember(DataType="string", Description="Next token", Format="date-time")]
        public DateTime? NextToken { get; set; }
    }

    public class FieldVisitReadingsByLocationServiceResponse
        : PublishServiceResponse
    {
        public FieldVisitReadingsByLocationServiceResponse()
        {
            FieldVisitReadings = new List<FieldVisitReading>{};
        }

        ///<summary>
        ///Field visit readings
        ///</summary>
        [ApiMember(DataType="array", Description="Field visit readings")]
        public List<FieldVisitReading> FieldVisitReadings { get; set; }
    }

    public class GradeListServiceResponse
        : PublishServiceResponse
    {
        public GradeListServiceResponse()
        {
            Grades = new List<GradeMetadata>{};
        }

        ///<summary>
        ///Grades
        ///</summary>
        [ApiMember(DataType="array", Description="Grades")]
        public List<GradeMetadata> Grades { get; set; }
    }

    public class LocationDataServiceResponse
        : PublishServiceResponse
    {
        public LocationDataServiceResponse()
        {
            Tags = new List<TagMetadata>{};
            ExtendedAttributes = new List<ExtendedAttribute>{};
            LocationRemarks = new List<LocationRemark>{};
            LocationNotes = new List<LocationNote>{};
            Attachments = new List<Attachment>{};
            ReferencePoints = new List<ReferencePoint>{};
        }

        ///<summary>
        ///Location name
        ///</summary>
        [ApiMember(Description="Location name")]
        public string LocationName { get; set; }

        ///<summary>
        ///Description
        ///</summary>
        [ApiMember(Description="Description")]
        public string Description { get; set; }

        ///<summary>
        ///Identifier
        ///</summary>
        [ApiMember(Description="Identifier")]
        public string Identifier { get; set; }

        ///<summary>
        ///Unique id
        ///</summary>
        [ApiMember(DataType="string", Description="Unique id", Format="guid")]
        public Guid UniqueId { get; set; }

        ///<summary>
        ///Location type
        ///</summary>
        [ApiMember(Description="Location type")]
        public string LocationType { get; set; }

        ///<summary>
        ///External locations are created by data connectors.
        ///</summary>
        [ApiMember(DataType="boolean", Description="External locations are created by data connectors.")]
        public bool IsExternalLocation { get; set; }

        ///<summary>
        ///Latitude
        ///</summary>
        [ApiMember(DataType="number", Description="Latitude", Format="double")]
        public double Latitude { get; set; }

        ///<summary>
        ///Longitude
        ///</summary>
        [ApiMember(DataType="number", Description="Longitude", Format="double")]
        public double Longitude { get; set; }

        ///<summary>
        ///Srid
        ///</summary>
        [ApiMember(DataType="number", Description="Srid", Format="double")]
        public double Srid { get; set; }

        ///<summary>
        ///Elevation units
        ///</summary>
        [ApiMember(Description="Elevation units")]
        public string ElevationUnits { get; set; }

        ///<summary>
        ///Elevation
        ///</summary>
        [ApiMember(DataType="number", Description="Elevation", Format="double")]
        public double Elevation { get; set; }

        ///<summary>
        ///Utc offset
        ///</summary>
        [ApiMember(DataType="number", Description="Utc offset", Format="double")]
        public double UtcOffset { get; set; }

        ///<summary>
        ///Tags
        ///</summary>
        [ApiMember(DataType="array", Description="Tags")]
        public List<TagMetadata> Tags { get; set; }

        ///<summary>
        ///Extended attributes
        ///</summary>
        [ApiMember(DataType="array", Description="Extended attributes")]
        public List<ExtendedAttribute> ExtendedAttributes { get; set; }

        ///<summary>
        ///Location remarks
        ///</summary>
        [ApiMember(DataType="array", Description="Location remarks")]
        public List<LocationRemark> LocationRemarks { get; set; }

        ///<summary>
        ///Location notes
        ///</summary>
        [ApiMember(DataType="array", Description="Location notes")]
        public List<LocationNote> LocationNotes { get; set; }

        ///<summary>
        ///Attachments
        ///</summary>
        [ApiMember(DataType="array", Description="Attachments")]
        public List<Attachment> Attachments { get; set; }

        ///<summary>
        ///Location datum
        ///</summary>
        [ApiMember(DataType="LocationDatum", Description="Location datum")]
        public LocationDatum LocationDatum { get; set; }

        ///<summary>
        ///Reference points
        ///</summary>
        [ApiMember(DataType="array", Description="Reference points")]
        public List<ReferencePoint> ReferencePoints { get; set; }
    }

    public class LocationDescriptionListServiceResponse
        : PublishServiceResponse
    {
        public LocationDescriptionListServiceResponse()
        {
            LocationDescriptions = new List<LocationDescription>{};
        }

        ///<summary>
        ///Location descriptions
        ///</summary>
        [ApiMember(DataType="array", Description="Location descriptions")]
        public List<LocationDescription> LocationDescriptions { get; set; }

        ///<summary>
        ///Next token
        ///</summary>
        [ApiMember(DataType="string", Description="Next token", Format="date-time")]
        public DateTime? NextToken { get; set; }
    }

    public class LocationTagListServiceResponse
    {
        public LocationTagListServiceResponse()
        {
            Tags = new List<NameTagDefinition>{};
        }

        ///<summary>
        ///Response version
        ///</summary>
        [ApiMember(DataType="integer", Description="Response version", Format="int32")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(DataType="string", Description="Response time", Format="date-time")]
        public DateTime ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Tags
        ///</summary>
        [ApiMember(DataType="array", Description="Tags")]
        public List<NameTagDefinition> Tags { get; set; }
    }

    public class MetadataChangeTransactionListServiceResponse
        : PublishServiceResponse
    {
        ///<summary>
        ///Metadata change transactions
        ///</summary>
        [ApiMember(DataType="array", Description="Metadata change transactions")]
        public IList<MetadataChangeTransaction> MetadataChangeTransactions { get; set; }
    }

    public class MonitoringMethodListServiceResponse
    {
        public MonitoringMethodListServiceResponse()
        {
            MonitoringMethods = new List<MonitoringMethod>{};
        }

        ///<summary>
        ///Response version
        ///</summary>
        [ApiMember(DataType="integer", Description="Response version", Format="int32")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(DataType="string", Description="Response time", Format="date-time")]
        public DateTime ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Monitoring methods
        ///</summary>
        [ApiMember(DataType="array", Description="Monitoring methods")]
        public List<MonitoringMethod> MonitoringMethods { get; set; }
    }

    public class ParameterListServiceResponse
        : PublishServiceResponse
    {
        public ParameterListServiceResponse()
        {
            Parameters = new List<ParameterMetadata>{};
        }

        ///<summary>
        ///Parameters
        ///</summary>
        [ApiMember(DataType="array", Description="Parameters")]
        public List<ParameterMetadata> Parameters { get; set; }
    }

    public class ProcessorListServiceResponse
        : PublishServiceResponse
    {
        public ProcessorListServiceResponse()
        {
            Processors = new List<Processor>{};
        }

        ///<summary>
        ///Processors
        ///</summary>
        [ApiMember(DataType="array", Description="Processors")]
        public List<Processor> Processors { get; set; }
    }

    public class PublishServiceResponse
    {
        ///<summary>
        ///Response version
        ///</summary>
        [ApiMember(DataType="integer", Description="Response version", Format="int32")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(DataType="string", Description="Response time", Format="date-time")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }
    }

    public class QualifierListServiceResponse
        : PublishServiceResponse
    {
        public QualifierListServiceResponse()
        {
            Qualifiers = new List<QualifierMetadata>{};
        }

        ///<summary>
        ///Qualifiers
        ///</summary>
        [ApiMember(DataType="array", Description="Qualifiers")]
        public List<QualifierMetadata> Qualifiers { get; set; }
    }

    public class RatingCurveListServiceResponse
        : PublishServiceResponse
    {
        ///<summary>
        ///Rating curves
        ///</summary>
        [ApiMember(DataType="array", Description="Rating curves")]
        public IList<RatingCurve> RatingCurves { get; set; }

        ///<summary>
        ///Approvals
        ///</summary>
        [ApiMember(DataType="array", Description="Approvals")]
        public IList<Approval> Approvals { get; set; }
    }

    public class RatingModelDescriptionListServiceResponse
        : PublishServiceResponse
    {
        ///<summary>
        ///Rating model descriptions
        ///</summary>
        [ApiMember(DataType="array", Description="Rating model descriptions")]
        public IList<RatingModelDescription> RatingModelDescriptions { get; set; }

        ///<summary>
        ///Next token
        ///</summary>
        [ApiMember(DataType="string", Description="Next token", Format="date-time")]
        public DateTime? NextToken { get; set; }
    }

    public class RatingModelEffectiveShiftsByStageValuesServiceResponse
        : PublishServiceResponse
    {
        public RatingModelEffectiveShiftsByStageValuesServiceResponse()
        {
            EffectiveShiftValues = new List<Nullable<Double>>{};
        }

        ///<summary>
        ///Timestamp
        ///</summary>
        [ApiMember(DataType="string", Description="Timestamp", Format="date-time")]
        public DateTimeOffset? Timestamp { get; set; }

        ///<summary>
        ///Effective shift values
        ///</summary>
        [ApiMember(DataType="array", Description="Effective shift values")]
        public List<Nullable<Double>> EffectiveShiftValues { get; set; }
    }

    public class RatingModelEffectiveShiftsServiceResponse
        : PublishServiceResponse
    {
        public RatingModelEffectiveShiftsServiceResponse()
        {
            EffectiveShifts = new List<EffectiveShift>{};
        }

        ///<summary>
        ///Effective shifts
        ///</summary>
        [ApiMember(DataType="array", Description="Effective shifts")]
        public List<EffectiveShift> EffectiveShifts { get; set; }
    }

    public class RatingModelInputValuesServiceResponse
        : PublishServiceResponse
    {
        public RatingModelInputValuesServiceResponse()
        {
            InputValues = new List<Nullable<Double>>{};
        }

        ///<summary>
        ///Input values
        ///</summary>
        [ApiMember(DataType="array", Description="Input values")]
        public List<Nullable<Double>> InputValues { get; set; }
    }

    public class RatingModelOutputValuesServiceResponse
        : PublishServiceResponse
    {
        public RatingModelOutputValuesServiceResponse()
        {
            OutputValues = new List<Nullable<Double>>{};
        }

        ///<summary>
        ///Output values
        ///</summary>
        [ApiMember(DataType="array", Description="Output values")]
        public List<Nullable<Double>> OutputValues { get; set; }
    }

    public class ReportListServiceResponse
        : PublishServiceResponse
    {
        public ReportListServiceResponse()
        {
            Reports = new List<Report>{};
        }

        ///<summary>
        ///Reports
        ///</summary>
        [ApiMember(DataType="array", Description="Reports")]
        public List<Report> Reports { get; set; }
    }

    public class RoundServiceResponse
        : PublishServiceResponse
    {
        public RoundServiceResponse()
        {
            Data = new List<string>{};
        }

        ///<summary>
        ///Values rounded as requested
        ///</summary>
        [ApiMember(DataType="array", Description="Values rounded as requested")]
        public List<string> Data { get; set; }
    }

    public class SensorsAndGaugesServiceResponse
        : PublishServiceResponse
    {
        public SensorsAndGaugesServiceResponse()
        {
            MonitoringMethods = new List<LocationMonitoringMethod>{};
        }

        ///<summary>
        ///Monitoring methods
        ///</summary>
        [ApiMember(DataType="array", Description="Monitoring methods")]
        public List<LocationMonitoringMethod> MonitoringMethods { get; set; }
    }

    public class TagListServiceResponse
        : PublishServiceResponse
    {
        public TagListServiceResponse()
        {
            Tags = new List<TagDefinition>{};
        }

        ///<summary>
        ///Tags
        ///</summary>
        [ApiMember(DataType="array", Description="Tags")]
        public List<TagDefinition> Tags { get; set; }
    }

    public class TimeAlignedDataServiceResponse
        : PublishServiceResponse
    {
        public TimeAlignedDataServiceResponse()
        {
            TimeSeries = new List<TimeAlignedTimeSeriesInfo>{};
            Points = new List<TimeAlignedPoint>{};
        }

        ///<summary>
        ///Summary info of the retrieved time-series
        ///</summary>
        [ApiMember(DataType="array", Description="Summary info of the retrieved time-series")]
        public List<TimeAlignedTimeSeriesInfo> TimeSeries { get; set; }

        ///<summary>
        ///Time range
        ///</summary>
        [ApiMember(DataType="TimeRange", Description="Time range")]
        public TimeRange TimeRange { get; set; }

        ///<summary>
        ///Number of points
        ///</summary>
        [ApiMember(DataType="integer", Description="Number of points", Format="int32")]
        public int NumPoints { get; set; }

        ///<summary>
        ///Points
        ///</summary>
        [ApiMember(DataType="array", Description="Points")]
        public List<TimeAlignedPoint> Points { get; set; }
    }

    public class TimeSeriesApprovalsTransactionListServiceResponse
        : PublishServiceResponse
    {
        ///<summary>
        ///Approvals transactions
        ///</summary>
        [ApiMember(DataType="array", Description="Approvals transactions")]
        public IList<ApprovalsTransaction> ApprovalsTransactions { get; set; }
    }

    public class TimeSeriesDataServiceResponse
        : PublishServiceResponse
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

        ///<summary>
        ///Unique id
        ///</summary>
        [ApiMember(DataType="string", Description="Unique id", Format="guid")]
        public Guid UniqueId { get; set; }

        ///<summary>
        ///Parameter
        ///</summary>
        [ApiMember(Description="Parameter")]
        public string Parameter { get; set; }

        ///<summary>
        ///Label
        ///</summary>
        [ApiMember(Description="Label")]
        public string Label { get; set; }

        ///<summary>
        ///Location identifier
        ///</summary>
        [ApiMember(Description="Location identifier")]
        public string LocationIdentifier { get; set; }

        ///<summary>
        ///Num points
        ///</summary>
        [ApiMember(DataType="integer", Description="Num points", Format="int64")]
        public long? NumPoints { get; set; }

        ///<summary>
        ///Unit
        ///</summary>
        [ApiMember(Description="Unit")]
        public string Unit { get; set; }

        ///<summary>
        ///Approvals
        ///</summary>
        [ApiMember(DataType="array", Description="Approvals")]
        public List<Approval> Approvals { get; set; }

        ///<summary>
        ///Qualifiers
        ///</summary>
        [ApiMember(DataType="array", Description="Qualifiers")]
        public List<Qualifier> Qualifiers { get; set; }

        ///<summary>
        ///Methods
        ///</summary>
        [ApiMember(DataType="array", Description="Methods")]
        public List<Method> Methods { get; set; }

        ///<summary>
        ///Grades
        ///</summary>
        [ApiMember(DataType="array", Description="Grades")]
        public List<Grade> Grades { get; set; }

        ///<summary>
        ///Gap tolerances
        ///</summary>
        [ApiMember(DataType="array", Description="Gap tolerances")]
        public List<GapTolerance> GapTolerances { get; set; }

        ///<summary>
        ///Interpolation types
        ///</summary>
        [ApiMember(DataType="array", Description="Interpolation types")]
        public List<InterpolationType> InterpolationTypes { get; set; }

        ///<summary>
        ///Notes
        ///</summary>
        [ApiMember(DataType="array", Description="Notes")]
        public List<Note> Notes { get; set; }

        ///<summary>
        ///Time range
        ///</summary>
        [ApiMember(DataType="StatisticalTimeRange", Description="Time range")]
        public StatisticalTimeRange TimeRange { get; set; }

        ///<summary>
        ///Points
        ///</summary>
        [ApiMember(DataType="array", Description="Points")]
        public List<TimeSeriesPoint> Points { get; set; }
    }

    public class TimeSeriesDescriptionListByUniqueIdServiceResponse
        : PublishServiceResponse
    {
        public TimeSeriesDescriptionListByUniqueIdServiceResponse()
        {
            TimeSeriesDescriptions = new List<TimeSeriesDescription>{};
        }

        ///<summary>
        ///Time series descriptions
        ///</summary>
        [ApiMember(DataType="array", Description="Time series descriptions")]
        public List<TimeSeriesDescription> TimeSeriesDescriptions { get; set; }
    }

    public class TimeSeriesDescriptionListServiceResponse
        : PublishServiceResponse
    {
        public TimeSeriesDescriptionListServiceResponse()
        {
            TimeSeriesDescriptions = new List<TimeSeriesDescription>{};
        }

        ///<summary>
        ///Time series descriptions
        ///</summary>
        [ApiMember(DataType="array", Description="Time series descriptions")]
        public List<TimeSeriesDescription> TimeSeriesDescriptions { get; set; }
    }

    public class TimeSeriesUniqueIdListServiceResponse
        : PublishServiceResponse
    {
        public TimeSeriesUniqueIdListServiceResponse()
        {
            TimeSeriesUniqueIds = new List<TimeSeriesUniqueIds>{};
        }

        ///<summary>
        ///Token expired
        ///</summary>
        [ApiMember(DataType="boolean", Description="Token expired")]
        public bool? TokenExpired { get; set; }

        ///<summary>
        ///Next token
        ///</summary>
        [ApiMember(DataType="string", Description="Next token", Format="date-time")]
        public DateTime? NextToken { get; set; }

        ///<summary>
        ///Time series unique ids
        ///</summary>
        [ApiMember(DataType="array", Description="Time series unique ids")]
        public List<TimeSeriesUniqueIds> TimeSeriesUniqueIds { get; set; }
    }

    public class TrendLineAnalysisServiceResponse
        : PublishServiceResponse
    {
        ///<summary>
        ///Trend line analysis
        ///</summary>
        [ApiMember(DataType="TrendLineAnalysis", Description="Trend line analysis")]
        public TrendLineAnalysis TrendLineAnalysis { get; set; }
    }

    public class UnitListServiceResponse
        : PublishServiceResponse
    {
        public UnitListServiceResponse()
        {
            Units = new List<UnitMetadata>{};
        }

        ///<summary>
        ///Units
        ///</summary>
        [ApiMember(DataType="array", Description="Units")]
        public List<UnitMetadata> Units { get; set; }
    }
}

namespace Aquarius.TimeSeries.Client.ServiceModels.Publish
{
    public static class Current
    {
        public static readonly AquariusServerVersion Version = AquariusServerVersion.Create("21.4.62.0");
    }
}
