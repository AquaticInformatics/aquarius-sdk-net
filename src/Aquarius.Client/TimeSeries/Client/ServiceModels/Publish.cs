/* Options:
Date: 2026-10-08 04:39:19
Version: 10.04
Tip: To override a DTO option, remove "//" prefix before updating
BaseUrl: https://develop-1.dev.aquariusdev.net/AQUARIUS/Publish/v2

GlobalNamespace: Aquarius.TimeSeries.Client.ServiceModels.Publish
MakePartial: False
MakeVirtual: False
//MakeInternal: False
//MakeDataContractsExtensible: False
AddNullableAnnotations: False
//AddReturnMarker: True
//AddDescriptionAsComments: True
//AddDataContractAttributes: False
//AddIndexesToDataMembers: False
//AddGeneratedCodeAttributes: False
//AddResponseStatus: False
//AddImplicitVersion: 
InitializeCollections: False
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

    public enum AccuracyType
    {
        Unspecified,
        Percentage,
        Unit,
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
        ///DEPRECATED: External locations are no longer supported; value always returns false.
        ///</summary>
        [ApiMember(DataType="boolean", Description="DEPRECATED: External locations are no longer supported; value always returns false.")]
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

        ///<summary>
        ///Sensor accuracy type. Valid values are: 'Unspecified'; 'Percentage'; or 'Unit'
        ///</summary>
        [ApiMember(Description="Sensor accuracy type. Valid values are: 'Unspecified'; 'Percentage'; or 'Unit'")]
        public AccuracyType? AccuracyType { get; set; }

        ///<summary>
        ///Numeric representation of a Sensor's accuracy (+/-)
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric representation of a Sensor's accuracy (+/-)", Format="double")]
        public double? AccuracyValue { get; set; }
    }

    public class LocationNote
    {
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

        ///<summary>
        ///User who created this note
        ///</summary>
        [ApiMember(Description="User who created this note")]
        public string CreatedByUser { get; set; }
    }

    public class LocationReferenceStandard
    {
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
        ///Sensor operations
        ///</summary>
        [ApiMember(DataType="array", Description="Sensor operations")]
        public IList<SensorOperation> SensorOperations { get; set; }

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

        ///<summary>
        ///Grade Ranges
        ///</summary>
        [ApiMember(DataType="array", Description="Grade Ranges")]
        public List<RatingGrade> GradeRanges { get; set; }
    }

    public enum RatingCurveType
    {
        LinearTable,
        LogarithmicTable,
        StandardEquation,
        DescriptiveEquation,
        IsoStandardEquation,
        LinearRegressionModel,
    }

    public class RatingGrade
    {
        ///<summary>
        ///Output upper bound
        ///</summary>
        [ApiMember(DataType="number", Description="Output upper bound", Format="double")]
        public double? OutputUpperBound { get; set; }

        ///<summary>
        ///Grade code
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code", Format="int32")]
        public int GradeCode { get; set; }
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

    public class Sensor
        : TimeRange
    {
        ///<summary>
        ///Unique ID of the sensor
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the sensor", Format="guid")]
        public Guid UniqueId { get; set; }
    }

    public class SensorOperation
        : Sensor, IStackPositionMetadataOperation
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
        ///Numeric value of output time series 1
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 1", Format="double")]
        public double? NumericValue1 { get; set; }

        ///<summary>
        ///Display value of output time series 1
        ///</summary>
        [ApiMember(Description="Display value of output time series 1")]
        public string DisplayValue1 { get; set; }

        ///<summary>
        ///Grade code of output time series 1
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 1", Format="int64")]
        public long? GradeCode1 { get; set; }

        ///<summary>
        ///Grade name of output time series 1
        ///</summary>
        [ApiMember(Description="Grade name of output time series 1")]
        public string GradeName1 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 1
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 1")]
        public string Qualifiers1 { get; set; }

        ///<summary>
        ///Method of output time series 1
        ///</summary>
        [ApiMember(Description="Method of output time series 1")]
        public string Method1 { get; set; }

        ///<summary>
        ///Approval level of output time series 1
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 1", Format="int64")]
        public long? ApprovalLevel1 { get; set; }

        ///<summary>
        ///Approval name of output time series 1
        ///</summary>
        [ApiMember(Description="Approval name of output time series 1")]
        public string ApprovalName1 { get; set; }

        ///<summary>
        ///Numeric value of output time series 2
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 2", Format="double")]
        public double? NumericValue2 { get; set; }

        ///<summary>
        ///Display value of output time series 2
        ///</summary>
        [ApiMember(Description="Display value of output time series 2")]
        public string DisplayValue2 { get; set; }

        ///<summary>
        ///Grade code of output time series 2
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 2", Format="int64")]
        public long? GradeCode2 { get; set; }

        ///<summary>
        ///Grade name of output time series 2
        ///</summary>
        [ApiMember(Description="Grade name of output time series 2")]
        public string GradeName2 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 2
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 2")]
        public string Qualifiers2 { get; set; }

        ///<summary>
        ///Method of output time series 2
        ///</summary>
        [ApiMember(Description="Method of output time series 2")]
        public string Method2 { get; set; }

        ///<summary>
        ///Approval level of output time series 2
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 2", Format="int64")]
        public long? ApprovalLevel2 { get; set; }

        ///<summary>
        ///Approval name of output time series 2
        ///</summary>
        [ApiMember(Description="Approval name of output time series 2")]
        public string ApprovalName2 { get; set; }

        ///<summary>
        ///Numeric value of output time series 3
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 3", Format="double")]
        public double? NumericValue3 { get; set; }

        ///<summary>
        ///Display value of output time series 3
        ///</summary>
        [ApiMember(Description="Display value of output time series 3")]
        public string DisplayValue3 { get; set; }

        ///<summary>
        ///Grade code of output time series 3
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 3", Format="int64")]
        public long? GradeCode3 { get; set; }

        ///<summary>
        ///Grade name of output time series 3
        ///</summary>
        [ApiMember(Description="Grade name of output time series 3")]
        public string GradeName3 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 3
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 3")]
        public string Qualifiers3 { get; set; }

        ///<summary>
        ///Method of output time series 3
        ///</summary>
        [ApiMember(Description="Method of output time series 3")]
        public string Method3 { get; set; }

        ///<summary>
        ///Approval level of output time series 3
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 3", Format="int64")]
        public long? ApprovalLevel3 { get; set; }

        ///<summary>
        ///Approval name of output time series 3
        ///</summary>
        [ApiMember(Description="Approval name of output time series 3")]
        public string ApprovalName3 { get; set; }

        ///<summary>
        ///Numeric value of output time series 4
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 4", Format="double")]
        public double? NumericValue4 { get; set; }

        ///<summary>
        ///Display value of output time series 4
        ///</summary>
        [ApiMember(Description="Display value of output time series 4")]
        public string DisplayValue4 { get; set; }

        ///<summary>
        ///Grade code of output time series 4
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 4", Format="int64")]
        public long? GradeCode4 { get; set; }

        ///<summary>
        ///Grade name of output time series 4
        ///</summary>
        [ApiMember(Description="Grade name of output time series 4")]
        public string GradeName4 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 4
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 4")]
        public string Qualifiers4 { get; set; }

        ///<summary>
        ///Method of output time series 4
        ///</summary>
        [ApiMember(Description="Method of output time series 4")]
        public string Method4 { get; set; }

        ///<summary>
        ///Approval level of output time series 4
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 4", Format="int64")]
        public long? ApprovalLevel4 { get; set; }

        ///<summary>
        ///Approval name of output time series 4
        ///</summary>
        [ApiMember(Description="Approval name of output time series 4")]
        public string ApprovalName4 { get; set; }

        ///<summary>
        ///Numeric value of output time series 5
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 5", Format="double")]
        public double? NumericValue5 { get; set; }

        ///<summary>
        ///Display value of output time series 5
        ///</summary>
        [ApiMember(Description="Display value of output time series 5")]
        public string DisplayValue5 { get; set; }

        ///<summary>
        ///Grade code of output time series 5
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 5", Format="int64")]
        public long? GradeCode5 { get; set; }

        ///<summary>
        ///Grade name of output time series 5
        ///</summary>
        [ApiMember(Description="Grade name of output time series 5")]
        public string GradeName5 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 5
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 5")]
        public string Qualifiers5 { get; set; }

        ///<summary>
        ///Method of output time series 5
        ///</summary>
        [ApiMember(Description="Method of output time series 5")]
        public string Method5 { get; set; }

        ///<summary>
        ///Approval level of output time series 5
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 5", Format="int64")]
        public long? ApprovalLevel5 { get; set; }

        ///<summary>
        ///Approval name of output time series 5
        ///</summary>
        [ApiMember(Description="Approval name of output time series 5")]
        public string ApprovalName5 { get; set; }

        ///<summary>
        ///Numeric value of output time series 6
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 6", Format="double")]
        public double? NumericValue6 { get; set; }

        ///<summary>
        ///Display value of output time series 6
        ///</summary>
        [ApiMember(Description="Display value of output time series 6")]
        public string DisplayValue6 { get; set; }

        ///<summary>
        ///Grade code of output time series 6
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 6", Format="int64")]
        public long? GradeCode6 { get; set; }

        ///<summary>
        ///Grade name of output time series 6
        ///</summary>
        [ApiMember(Description="Grade name of output time series 6")]
        public string GradeName6 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 6
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 6")]
        public string Qualifiers6 { get; set; }

        ///<summary>
        ///Method of output time series 6
        ///</summary>
        [ApiMember(Description="Method of output time series 6")]
        public string Method6 { get; set; }

        ///<summary>
        ///Approval level of output time series 6
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 6", Format="int64")]
        public long? ApprovalLevel6 { get; set; }

        ///<summary>
        ///Approval name of output time series 6
        ///</summary>
        [ApiMember(Description="Approval name of output time series 6")]
        public string ApprovalName6 { get; set; }

        ///<summary>
        ///Numeric value of output time series 7
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 7", Format="double")]
        public double? NumericValue7 { get; set; }

        ///<summary>
        ///Display value of output time series 7
        ///</summary>
        [ApiMember(Description="Display value of output time series 7")]
        public string DisplayValue7 { get; set; }

        ///<summary>
        ///Grade code of output time series 7
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 7", Format="int64")]
        public long? GradeCode7 { get; set; }

        ///<summary>
        ///Grade name of output time series 7
        ///</summary>
        [ApiMember(Description="Grade name of output time series 7")]
        public string GradeName7 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 7
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 7")]
        public string Qualifiers7 { get; set; }

        ///<summary>
        ///Method of output time series 7
        ///</summary>
        [ApiMember(Description="Method of output time series 7")]
        public string Method7 { get; set; }

        ///<summary>
        ///Approval level of output time series 7
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 7", Format="int64")]
        public long? ApprovalLevel7 { get; set; }

        ///<summary>
        ///Approval name of output time series 7
        ///</summary>
        [ApiMember(Description="Approval name of output time series 7")]
        public string ApprovalName7 { get; set; }

        ///<summary>
        ///Numeric value of output time series 8
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 8", Format="double")]
        public double? NumericValue8 { get; set; }

        ///<summary>
        ///Display value of output time series 8
        ///</summary>
        [ApiMember(Description="Display value of output time series 8")]
        public string DisplayValue8 { get; set; }

        ///<summary>
        ///Grade code of output time series 8
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 8", Format="int64")]
        public long? GradeCode8 { get; set; }

        ///<summary>
        ///Grade name of output time series 8
        ///</summary>
        [ApiMember(Description="Grade name of output time series 8")]
        public string GradeName8 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 8
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 8")]
        public string Qualifiers8 { get; set; }

        ///<summary>
        ///Method of output time series 8
        ///</summary>
        [ApiMember(Description="Method of output time series 8")]
        public string Method8 { get; set; }

        ///<summary>
        ///Approval level of output time series 8
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 8", Format="int64")]
        public long? ApprovalLevel8 { get; set; }

        ///<summary>
        ///Approval name of output time series 8
        ///</summary>
        [ApiMember(Description="Approval name of output time series 8")]
        public string ApprovalName8 { get; set; }

        ///<summary>
        ///Numeric value of output time series 9
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 9", Format="double")]
        public double? NumericValue9 { get; set; }

        ///<summary>
        ///Display value of output time series 9
        ///</summary>
        [ApiMember(Description="Display value of output time series 9")]
        public string DisplayValue9 { get; set; }

        ///<summary>
        ///Grade code of output time series 9
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 9", Format="int64")]
        public long? GradeCode9 { get; set; }

        ///<summary>
        ///Grade name of output time series 9
        ///</summary>
        [ApiMember(Description="Grade name of output time series 9")]
        public string GradeName9 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 9
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 9")]
        public string Qualifiers9 { get; set; }

        ///<summary>
        ///Method of output time series 9
        ///</summary>
        [ApiMember(Description="Method of output time series 9")]
        public string Method9 { get; set; }

        ///<summary>
        ///Approval level of output time series 9
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 9", Format="int64")]
        public long? ApprovalLevel9 { get; set; }

        ///<summary>
        ///Approval name of output time series 9
        ///</summary>
        [ApiMember(Description="Approval name of output time series 9")]
        public string ApprovalName9 { get; set; }

        ///<summary>
        ///Numeric value of output time series 10
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 10", Format="double")]
        public double? NumericValue10 { get; set; }

        ///<summary>
        ///Display value of output time series 10
        ///</summary>
        [ApiMember(Description="Display value of output time series 10")]
        public string DisplayValue10 { get; set; }

        ///<summary>
        ///Grade code of output time series 10
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 10", Format="int64")]
        public long? GradeCode10 { get; set; }

        ///<summary>
        ///Grade name of output time series 10
        ///</summary>
        [ApiMember(Description="Grade name of output time series 10")]
        public string GradeName10 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 10
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 10")]
        public string Qualifiers10 { get; set; }

        ///<summary>
        ///Method of output time series 10
        ///</summary>
        [ApiMember(Description="Method of output time series 10")]
        public string Method10 { get; set; }

        ///<summary>
        ///Approval level of output time series 10
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 10", Format="int64")]
        public long? ApprovalLevel10 { get; set; }

        ///<summary>
        ///Approval name of output time series 10
        ///</summary>
        [ApiMember(Description="Approval name of output time series 10")]
        public string ApprovalName10 { get; set; }

        ///<summary>
        ///Numeric value of output time series 11
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 11", Format="double")]
        public double? NumericValue11 { get; set; }

        ///<summary>
        ///Display value of output time series 11
        ///</summary>
        [ApiMember(Description="Display value of output time series 11")]
        public string DisplayValue11 { get; set; }

        ///<summary>
        ///Grade code of output time series 11
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 11", Format="int64")]
        public long? GradeCode11 { get; set; }

        ///<summary>
        ///Grade name of output time series 11
        ///</summary>
        [ApiMember(Description="Grade name of output time series 11")]
        public string GradeName11 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 11
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 11")]
        public string Qualifiers11 { get; set; }

        ///<summary>
        ///Method of output time series 11
        ///</summary>
        [ApiMember(Description="Method of output time series 11")]
        public string Method11 { get; set; }

        ///<summary>
        ///Approval level of output time series 11
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 11", Format="int64")]
        public long? ApprovalLevel11 { get; set; }

        ///<summary>
        ///Approval name of output time series 11
        ///</summary>
        [ApiMember(Description="Approval name of output time series 11")]
        public string ApprovalName11 { get; set; }

        ///<summary>
        ///Numeric value of output time series 12
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 12", Format="double")]
        public double? NumericValue12 { get; set; }

        ///<summary>
        ///Display value of output time series 12
        ///</summary>
        [ApiMember(Description="Display value of output time series 12")]
        public string DisplayValue12 { get; set; }

        ///<summary>
        ///Grade code of output time series 12
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 12", Format="int64")]
        public long? GradeCode12 { get; set; }

        ///<summary>
        ///Grade name of output time series 12
        ///</summary>
        [ApiMember(Description="Grade name of output time series 12")]
        public string GradeName12 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 12
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 12")]
        public string Qualifiers12 { get; set; }

        ///<summary>
        ///Method of output time series 12
        ///</summary>
        [ApiMember(Description="Method of output time series 12")]
        public string Method12 { get; set; }

        ///<summary>
        ///Approval level of output time series 12
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 12", Format="int64")]
        public long? ApprovalLevel12 { get; set; }

        ///<summary>
        ///Approval name of output time series 12
        ///</summary>
        [ApiMember(Description="Approval name of output time series 12")]
        public string ApprovalName12 { get; set; }

        ///<summary>
        ///Numeric value of output time series 13
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 13", Format="double")]
        public double? NumericValue13 { get; set; }

        ///<summary>
        ///Display value of output time series 13
        ///</summary>
        [ApiMember(Description="Display value of output time series 13")]
        public string DisplayValue13 { get; set; }

        ///<summary>
        ///Grade code of output time series 13
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 13", Format="int64")]
        public long? GradeCode13 { get; set; }

        ///<summary>
        ///Grade name of output time series 13
        ///</summary>
        [ApiMember(Description="Grade name of output time series 13")]
        public string GradeName13 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 13
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 13")]
        public string Qualifiers13 { get; set; }

        ///<summary>
        ///Method of output time series 13
        ///</summary>
        [ApiMember(Description="Method of output time series 13")]
        public string Method13 { get; set; }

        ///<summary>
        ///Approval level of output time series 13
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 13", Format="int64")]
        public long? ApprovalLevel13 { get; set; }

        ///<summary>
        ///Approval name of output time series 13
        ///</summary>
        [ApiMember(Description="Approval name of output time series 13")]
        public string ApprovalName13 { get; set; }

        ///<summary>
        ///Numeric value of output time series 14
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 14", Format="double")]
        public double? NumericValue14 { get; set; }

        ///<summary>
        ///Display value of output time series 14
        ///</summary>
        [ApiMember(Description="Display value of output time series 14")]
        public string DisplayValue14 { get; set; }

        ///<summary>
        ///Grade code of output time series 14
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 14", Format="int64")]
        public long? GradeCode14 { get; set; }

        ///<summary>
        ///Grade name of output time series 14
        ///</summary>
        [ApiMember(Description="Grade name of output time series 14")]
        public string GradeName14 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 14
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 14")]
        public string Qualifiers14 { get; set; }

        ///<summary>
        ///Method of output time series 14
        ///</summary>
        [ApiMember(Description="Method of output time series 14")]
        public string Method14 { get; set; }

        ///<summary>
        ///Approval level of output time series 14
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 14", Format="int64")]
        public long? ApprovalLevel14 { get; set; }

        ///<summary>
        ///Approval name of output time series 14
        ///</summary>
        [ApiMember(Description="Approval name of output time series 14")]
        public string ApprovalName14 { get; set; }

        ///<summary>
        ///Numeric value of output time series 15
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 15", Format="double")]
        public double? NumericValue15 { get; set; }

        ///<summary>
        ///Display value of output time series 15
        ///</summary>
        [ApiMember(Description="Display value of output time series 15")]
        public string DisplayValue15 { get; set; }

        ///<summary>
        ///Grade code of output time series 15
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 15", Format="int64")]
        public long? GradeCode15 { get; set; }

        ///<summary>
        ///Grade name of output time series 15
        ///</summary>
        [ApiMember(Description="Grade name of output time series 15")]
        public string GradeName15 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 15
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 15")]
        public string Qualifiers15 { get; set; }

        ///<summary>
        ///Method of output time series 15
        ///</summary>
        [ApiMember(Description="Method of output time series 15")]
        public string Method15 { get; set; }

        ///<summary>
        ///Approval level of output time series 15
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 15", Format="int64")]
        public long? ApprovalLevel15 { get; set; }

        ///<summary>
        ///Approval name of output time series 15
        ///</summary>
        [ApiMember(Description="Approval name of output time series 15")]
        public string ApprovalName15 { get; set; }

        ///<summary>
        ///Numeric value of output time series 16
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 16", Format="double")]
        public double? NumericValue16 { get; set; }

        ///<summary>
        ///Display value of output time series 16
        ///</summary>
        [ApiMember(Description="Display value of output time series 16")]
        public string DisplayValue16 { get; set; }

        ///<summary>
        ///Grade code of output time series 16
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 16", Format="int64")]
        public long? GradeCode16 { get; set; }

        ///<summary>
        ///Grade name of output time series 16
        ///</summary>
        [ApiMember(Description="Grade name of output time series 16")]
        public string GradeName16 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 16
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 16")]
        public string Qualifiers16 { get; set; }

        ///<summary>
        ///Method of output time series 16
        ///</summary>
        [ApiMember(Description="Method of output time series 16")]
        public string Method16 { get; set; }

        ///<summary>
        ///Approval level of output time series 16
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 16", Format="int64")]
        public long? ApprovalLevel16 { get; set; }

        ///<summary>
        ///Approval name of output time series 16
        ///</summary>
        [ApiMember(Description="Approval name of output time series 16")]
        public string ApprovalName16 { get; set; }

        ///<summary>
        ///Numeric value of output time series 17
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 17", Format="double")]
        public double? NumericValue17 { get; set; }

        ///<summary>
        ///Display value of output time series 17
        ///</summary>
        [ApiMember(Description="Display value of output time series 17")]
        public string DisplayValue17 { get; set; }

        ///<summary>
        ///Grade code of output time series 17
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 17", Format="int64")]
        public long? GradeCode17 { get; set; }

        ///<summary>
        ///Grade name of output time series 17
        ///</summary>
        [ApiMember(Description="Grade name of output time series 17")]
        public string GradeName17 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 17
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 17")]
        public string Qualifiers17 { get; set; }

        ///<summary>
        ///Method of output time series 17
        ///</summary>
        [ApiMember(Description="Method of output time series 17")]
        public string Method17 { get; set; }

        ///<summary>
        ///Approval level of output time series 17
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 17", Format="int64")]
        public long? ApprovalLevel17 { get; set; }

        ///<summary>
        ///Approval name of output time series 17
        ///</summary>
        [ApiMember(Description="Approval name of output time series 17")]
        public string ApprovalName17 { get; set; }

        ///<summary>
        ///Numeric value of output time series 18
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 18", Format="double")]
        public double? NumericValue18 { get; set; }

        ///<summary>
        ///Display value of output time series 18
        ///</summary>
        [ApiMember(Description="Display value of output time series 18")]
        public string DisplayValue18 { get; set; }

        ///<summary>
        ///Grade code of output time series 18
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 18", Format="int64")]
        public long? GradeCode18 { get; set; }

        ///<summary>
        ///Grade name of output time series 18
        ///</summary>
        [ApiMember(Description="Grade name of output time series 18")]
        public string GradeName18 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 18
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 18")]
        public string Qualifiers18 { get; set; }

        ///<summary>
        ///Method of output time series 18
        ///</summary>
        [ApiMember(Description="Method of output time series 18")]
        public string Method18 { get; set; }

        ///<summary>
        ///Approval level of output time series 18
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 18", Format="int64")]
        public long? ApprovalLevel18 { get; set; }

        ///<summary>
        ///Approval name of output time series 18
        ///</summary>
        [ApiMember(Description="Approval name of output time series 18")]
        public string ApprovalName18 { get; set; }

        ///<summary>
        ///Numeric value of output time series 19
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 19", Format="double")]
        public double? NumericValue19 { get; set; }

        ///<summary>
        ///Display value of output time series 19
        ///</summary>
        [ApiMember(Description="Display value of output time series 19")]
        public string DisplayValue19 { get; set; }

        ///<summary>
        ///Grade code of output time series 19
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 19", Format="int64")]
        public long? GradeCode19 { get; set; }

        ///<summary>
        ///Grade name of output time series 19
        ///</summary>
        [ApiMember(Description="Grade name of output time series 19")]
        public string GradeName19 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 19
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 19")]
        public string Qualifiers19 { get; set; }

        ///<summary>
        ///Method of output time series 19
        ///</summary>
        [ApiMember(Description="Method of output time series 19")]
        public string Method19 { get; set; }

        ///<summary>
        ///Approval level of output time series 19
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 19", Format="int64")]
        public long? ApprovalLevel19 { get; set; }

        ///<summary>
        ///Approval name of output time series 19
        ///</summary>
        [ApiMember(Description="Approval name of output time series 19")]
        public string ApprovalName19 { get; set; }

        ///<summary>
        ///Numeric value of output time series 20
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 20", Format="double")]
        public double? NumericValue20 { get; set; }

        ///<summary>
        ///Display value of output time series 20
        ///</summary>
        [ApiMember(Description="Display value of output time series 20")]
        public string DisplayValue20 { get; set; }

        ///<summary>
        ///Grade code of output time series 20
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 20", Format="int64")]
        public long? GradeCode20 { get; set; }

        ///<summary>
        ///Grade name of output time series 20
        ///</summary>
        [ApiMember(Description="Grade name of output time series 20")]
        public string GradeName20 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 20
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 20")]
        public string Qualifiers20 { get; set; }

        ///<summary>
        ///Method of output time series 20
        ///</summary>
        [ApiMember(Description="Method of output time series 20")]
        public string Method20 { get; set; }

        ///<summary>
        ///Approval level of output time series 20
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 20", Format="int64")]
        public long? ApprovalLevel20 { get; set; }

        ///<summary>
        ///Approval name of output time series 20
        ///</summary>
        [ApiMember(Description="Approval name of output time series 20")]
        public string ApprovalName20 { get; set; }

        ///<summary>
        ///Numeric value of output time series 21
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 21", Format="double")]
        public double? NumericValue21 { get; set; }

        ///<summary>
        ///Display value of output time series 21
        ///</summary>
        [ApiMember(Description="Display value of output time series 21")]
        public string DisplayValue21 { get; set; }

        ///<summary>
        ///Grade code of output time series 21
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 21", Format="int64")]
        public long? GradeCode21 { get; set; }

        ///<summary>
        ///Grade name of output time series 21
        ///</summary>
        [ApiMember(Description="Grade name of output time series 21")]
        public string GradeName21 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 21
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 21")]
        public string Qualifiers21 { get; set; }

        ///<summary>
        ///Method of output time series 21
        ///</summary>
        [ApiMember(Description="Method of output time series 21")]
        public string Method21 { get; set; }

        ///<summary>
        ///Approval level of output time series 21
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 21", Format="int64")]
        public long? ApprovalLevel21 { get; set; }

        ///<summary>
        ///Approval name of output time series 21
        ///</summary>
        [ApiMember(Description="Approval name of output time series 21")]
        public string ApprovalName21 { get; set; }

        ///<summary>
        ///Numeric value of output time series 22
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 22", Format="double")]
        public double? NumericValue22 { get; set; }

        ///<summary>
        ///Display value of output time series 22
        ///</summary>
        [ApiMember(Description="Display value of output time series 22")]
        public string DisplayValue22 { get; set; }

        ///<summary>
        ///Grade code of output time series 22
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 22", Format="int64")]
        public long? GradeCode22 { get; set; }

        ///<summary>
        ///Grade name of output time series 22
        ///</summary>
        [ApiMember(Description="Grade name of output time series 22")]
        public string GradeName22 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 22
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 22")]
        public string Qualifiers22 { get; set; }

        ///<summary>
        ///Method of output time series 22
        ///</summary>
        [ApiMember(Description="Method of output time series 22")]
        public string Method22 { get; set; }

        ///<summary>
        ///Approval level of output time series 22
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 22", Format="int64")]
        public long? ApprovalLevel22 { get; set; }

        ///<summary>
        ///Approval name of output time series 22
        ///</summary>
        [ApiMember(Description="Approval name of output time series 22")]
        public string ApprovalName22 { get; set; }

        ///<summary>
        ///Numeric value of output time series 23
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 23", Format="double")]
        public double? NumericValue23 { get; set; }

        ///<summary>
        ///Display value of output time series 23
        ///</summary>
        [ApiMember(Description="Display value of output time series 23")]
        public string DisplayValue23 { get; set; }

        ///<summary>
        ///Grade code of output time series 23
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 23", Format="int64")]
        public long? GradeCode23 { get; set; }

        ///<summary>
        ///Grade name of output time series 23
        ///</summary>
        [ApiMember(Description="Grade name of output time series 23")]
        public string GradeName23 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 23
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 23")]
        public string Qualifiers23 { get; set; }

        ///<summary>
        ///Method of output time series 23
        ///</summary>
        [ApiMember(Description="Method of output time series 23")]
        public string Method23 { get; set; }

        ///<summary>
        ///Approval level of output time series 23
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 23", Format="int64")]
        public long? ApprovalLevel23 { get; set; }

        ///<summary>
        ///Approval name of output time series 23
        ///</summary>
        [ApiMember(Description="Approval name of output time series 23")]
        public string ApprovalName23 { get; set; }

        ///<summary>
        ///Numeric value of output time series 24
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 24", Format="double")]
        public double? NumericValue24 { get; set; }

        ///<summary>
        ///Display value of output time series 24
        ///</summary>
        [ApiMember(Description="Display value of output time series 24")]
        public string DisplayValue24 { get; set; }

        ///<summary>
        ///Grade code of output time series 24
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 24", Format="int64")]
        public long? GradeCode24 { get; set; }

        ///<summary>
        ///Grade name of output time series 24
        ///</summary>
        [ApiMember(Description="Grade name of output time series 24")]
        public string GradeName24 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 24
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 24")]
        public string Qualifiers24 { get; set; }

        ///<summary>
        ///Method of output time series 24
        ///</summary>
        [ApiMember(Description="Method of output time series 24")]
        public string Method24 { get; set; }

        ///<summary>
        ///Approval level of output time series 24
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 24", Format="int64")]
        public long? ApprovalLevel24 { get; set; }

        ///<summary>
        ///Approval name of output time series 24
        ///</summary>
        [ApiMember(Description="Approval name of output time series 24")]
        public string ApprovalName24 { get; set; }

        ///<summary>
        ///Numeric value of output time series 25
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 25", Format="double")]
        public double? NumericValue25 { get; set; }

        ///<summary>
        ///Display value of output time series 25
        ///</summary>
        [ApiMember(Description="Display value of output time series 25")]
        public string DisplayValue25 { get; set; }

        ///<summary>
        ///Grade code of output time series 25
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 25", Format="int64")]
        public long? GradeCode25 { get; set; }

        ///<summary>
        ///Grade name of output time series 25
        ///</summary>
        [ApiMember(Description="Grade name of output time series 25")]
        public string GradeName25 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 25
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 25")]
        public string Qualifiers25 { get; set; }

        ///<summary>
        ///Method of output time series 25
        ///</summary>
        [ApiMember(Description="Method of output time series 25")]
        public string Method25 { get; set; }

        ///<summary>
        ///Approval level of output time series 25
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 25", Format="int64")]
        public long? ApprovalLevel25 { get; set; }

        ///<summary>
        ///Approval name of output time series 25
        ///</summary>
        [ApiMember(Description="Approval name of output time series 25")]
        public string ApprovalName25 { get; set; }

        ///<summary>
        ///Numeric value of output time series 26
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 26", Format="double")]
        public double? NumericValue26 { get; set; }

        ///<summary>
        ///Display value of output time series 26
        ///</summary>
        [ApiMember(Description="Display value of output time series 26")]
        public string DisplayValue26 { get; set; }

        ///<summary>
        ///Grade code of output time series 26
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 26", Format="int64")]
        public long? GradeCode26 { get; set; }

        ///<summary>
        ///Grade name of output time series 26
        ///</summary>
        [ApiMember(Description="Grade name of output time series 26")]
        public string GradeName26 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 26
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 26")]
        public string Qualifiers26 { get; set; }

        ///<summary>
        ///Method of output time series 26
        ///</summary>
        [ApiMember(Description="Method of output time series 26")]
        public string Method26 { get; set; }

        ///<summary>
        ///Approval level of output time series 26
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 26", Format="int64")]
        public long? ApprovalLevel26 { get; set; }

        ///<summary>
        ///Approval name of output time series 26
        ///</summary>
        [ApiMember(Description="Approval name of output time series 26")]
        public string ApprovalName26 { get; set; }

        ///<summary>
        ///Numeric value of output time series 27
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 27", Format="double")]
        public double? NumericValue27 { get; set; }

        ///<summary>
        ///Display value of output time series 27
        ///</summary>
        [ApiMember(Description="Display value of output time series 27")]
        public string DisplayValue27 { get; set; }

        ///<summary>
        ///Grade code of output time series 27
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 27", Format="int64")]
        public long? GradeCode27 { get; set; }

        ///<summary>
        ///Grade name of output time series 27
        ///</summary>
        [ApiMember(Description="Grade name of output time series 27")]
        public string GradeName27 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 27
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 27")]
        public string Qualifiers27 { get; set; }

        ///<summary>
        ///Method of output time series 27
        ///</summary>
        [ApiMember(Description="Method of output time series 27")]
        public string Method27 { get; set; }

        ///<summary>
        ///Approval level of output time series 27
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 27", Format="int64")]
        public long? ApprovalLevel27 { get; set; }

        ///<summary>
        ///Approval name of output time series 27
        ///</summary>
        [ApiMember(Description="Approval name of output time series 27")]
        public string ApprovalName27 { get; set; }

        ///<summary>
        ///Numeric value of output time series 28
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 28", Format="double")]
        public double? NumericValue28 { get; set; }

        ///<summary>
        ///Display value of output time series 28
        ///</summary>
        [ApiMember(Description="Display value of output time series 28")]
        public string DisplayValue28 { get; set; }

        ///<summary>
        ///Grade code of output time series 28
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 28", Format="int64")]
        public long? GradeCode28 { get; set; }

        ///<summary>
        ///Grade name of output time series 28
        ///</summary>
        [ApiMember(Description="Grade name of output time series 28")]
        public string GradeName28 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 28
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 28")]
        public string Qualifiers28 { get; set; }

        ///<summary>
        ///Method of output time series 28
        ///</summary>
        [ApiMember(Description="Method of output time series 28")]
        public string Method28 { get; set; }

        ///<summary>
        ///Approval level of output time series 28
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 28", Format="int64")]
        public long? ApprovalLevel28 { get; set; }

        ///<summary>
        ///Approval name of output time series 28
        ///</summary>
        [ApiMember(Description="Approval name of output time series 28")]
        public string ApprovalName28 { get; set; }

        ///<summary>
        ///Numeric value of output time series 29
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 29", Format="double")]
        public double? NumericValue29 { get; set; }

        ///<summary>
        ///Display value of output time series 29
        ///</summary>
        [ApiMember(Description="Display value of output time series 29")]
        public string DisplayValue29 { get; set; }

        ///<summary>
        ///Grade code of output time series 29
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 29", Format="int64")]
        public long? GradeCode29 { get; set; }

        ///<summary>
        ///Grade name of output time series 29
        ///</summary>
        [ApiMember(Description="Grade name of output time series 29")]
        public string GradeName29 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 29
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 29")]
        public string Qualifiers29 { get; set; }

        ///<summary>
        ///Method of output time series 29
        ///</summary>
        [ApiMember(Description="Method of output time series 29")]
        public string Method29 { get; set; }

        ///<summary>
        ///Approval level of output time series 29
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 29", Format="int64")]
        public long? ApprovalLevel29 { get; set; }

        ///<summary>
        ///Approval name of output time series 29
        ///</summary>
        [ApiMember(Description="Approval name of output time series 29")]
        public string ApprovalName29 { get; set; }

        ///<summary>
        ///Numeric value of output time series 30
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 30", Format="double")]
        public double? NumericValue30 { get; set; }

        ///<summary>
        ///Display value of output time series 30
        ///</summary>
        [ApiMember(Description="Display value of output time series 30")]
        public string DisplayValue30 { get; set; }

        ///<summary>
        ///Grade code of output time series 30
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 30", Format="int64")]
        public long? GradeCode30 { get; set; }

        ///<summary>
        ///Grade name of output time series 30
        ///</summary>
        [ApiMember(Description="Grade name of output time series 30")]
        public string GradeName30 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 30
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 30")]
        public string Qualifiers30 { get; set; }

        ///<summary>
        ///Method of output time series 30
        ///</summary>
        [ApiMember(Description="Method of output time series 30")]
        public string Method30 { get; set; }

        ///<summary>
        ///Approval level of output time series 30
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 30", Format="int64")]
        public long? ApprovalLevel30 { get; set; }

        ///<summary>
        ///Approval name of output time series 30
        ///</summary>
        [ApiMember(Description="Approval name of output time series 30")]
        public string ApprovalName30 { get; set; }

        ///<summary>
        ///Numeric value of output time series 31
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 31", Format="double")]
        public double? NumericValue31 { get; set; }

        ///<summary>
        ///Display value of output time series 31
        ///</summary>
        [ApiMember(Description="Display value of output time series 31")]
        public string DisplayValue31 { get; set; }

        ///<summary>
        ///Grade code of output time series 31
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 31", Format="int64")]
        public long? GradeCode31 { get; set; }

        ///<summary>
        ///Grade name of output time series 31
        ///</summary>
        [ApiMember(Description="Grade name of output time series 31")]
        public string GradeName31 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 31
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 31")]
        public string Qualifiers31 { get; set; }

        ///<summary>
        ///Method of output time series 31
        ///</summary>
        [ApiMember(Description="Method of output time series 31")]
        public string Method31 { get; set; }

        ///<summary>
        ///Approval level of output time series 31
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 31", Format="int64")]
        public long? ApprovalLevel31 { get; set; }

        ///<summary>
        ///Approval name of output time series 31
        ///</summary>
        [ApiMember(Description="Approval name of output time series 31")]
        public string ApprovalName31 { get; set; }

        ///<summary>
        ///Numeric value of output time series 32
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 32", Format="double")]
        public double? NumericValue32 { get; set; }

        ///<summary>
        ///Display value of output time series 32
        ///</summary>
        [ApiMember(Description="Display value of output time series 32")]
        public string DisplayValue32 { get; set; }

        ///<summary>
        ///Grade code of output time series 32
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 32", Format="int64")]
        public long? GradeCode32 { get; set; }

        ///<summary>
        ///Grade name of output time series 32
        ///</summary>
        [ApiMember(Description="Grade name of output time series 32")]
        public string GradeName32 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 32
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 32")]
        public string Qualifiers32 { get; set; }

        ///<summary>
        ///Method of output time series 32
        ///</summary>
        [ApiMember(Description="Method of output time series 32")]
        public string Method32 { get; set; }

        ///<summary>
        ///Approval level of output time series 32
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 32", Format="int64")]
        public long? ApprovalLevel32 { get; set; }

        ///<summary>
        ///Approval name of output time series 32
        ///</summary>
        [ApiMember(Description="Approval name of output time series 32")]
        public string ApprovalName32 { get; set; }

        ///<summary>
        ///Numeric value of output time series 33
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 33", Format="double")]
        public double? NumericValue33 { get; set; }

        ///<summary>
        ///Display value of output time series 33
        ///</summary>
        [ApiMember(Description="Display value of output time series 33")]
        public string DisplayValue33 { get; set; }

        ///<summary>
        ///Grade code of output time series 33
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 33", Format="int64")]
        public long? GradeCode33 { get; set; }

        ///<summary>
        ///Grade name of output time series 33
        ///</summary>
        [ApiMember(Description="Grade name of output time series 33")]
        public string GradeName33 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 33
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 33")]
        public string Qualifiers33 { get; set; }

        ///<summary>
        ///Method of output time series 33
        ///</summary>
        [ApiMember(Description="Method of output time series 33")]
        public string Method33 { get; set; }

        ///<summary>
        ///Approval level of output time series 33
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 33", Format="int64")]
        public long? ApprovalLevel33 { get; set; }

        ///<summary>
        ///Approval name of output time series 33
        ///</summary>
        [ApiMember(Description="Approval name of output time series 33")]
        public string ApprovalName33 { get; set; }

        ///<summary>
        ///Numeric value of output time series 34
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 34", Format="double")]
        public double? NumericValue34 { get; set; }

        ///<summary>
        ///Display value of output time series 34
        ///</summary>
        [ApiMember(Description="Display value of output time series 34")]
        public string DisplayValue34 { get; set; }

        ///<summary>
        ///Grade code of output time series 34
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 34", Format="int64")]
        public long? GradeCode34 { get; set; }

        ///<summary>
        ///Grade name of output time series 34
        ///</summary>
        [ApiMember(Description="Grade name of output time series 34")]
        public string GradeName34 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 34
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 34")]
        public string Qualifiers34 { get; set; }

        ///<summary>
        ///Method of output time series 34
        ///</summary>
        [ApiMember(Description="Method of output time series 34")]
        public string Method34 { get; set; }

        ///<summary>
        ///Approval level of output time series 34
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 34", Format="int64")]
        public long? ApprovalLevel34 { get; set; }

        ///<summary>
        ///Approval name of output time series 34
        ///</summary>
        [ApiMember(Description="Approval name of output time series 34")]
        public string ApprovalName34 { get; set; }

        ///<summary>
        ///Numeric value of output time series 35
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 35", Format="double")]
        public double? NumericValue35 { get; set; }

        ///<summary>
        ///Display value of output time series 35
        ///</summary>
        [ApiMember(Description="Display value of output time series 35")]
        public string DisplayValue35 { get; set; }

        ///<summary>
        ///Grade code of output time series 35
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 35", Format="int64")]
        public long? GradeCode35 { get; set; }

        ///<summary>
        ///Grade name of output time series 35
        ///</summary>
        [ApiMember(Description="Grade name of output time series 35")]
        public string GradeName35 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 35
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 35")]
        public string Qualifiers35 { get; set; }

        ///<summary>
        ///Method of output time series 35
        ///</summary>
        [ApiMember(Description="Method of output time series 35")]
        public string Method35 { get; set; }

        ///<summary>
        ///Approval level of output time series 35
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 35", Format="int64")]
        public long? ApprovalLevel35 { get; set; }

        ///<summary>
        ///Approval name of output time series 35
        ///</summary>
        [ApiMember(Description="Approval name of output time series 35")]
        public string ApprovalName35 { get; set; }

        ///<summary>
        ///Numeric value of output time series 36
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 36", Format="double")]
        public double? NumericValue36 { get; set; }

        ///<summary>
        ///Display value of output time series 36
        ///</summary>
        [ApiMember(Description="Display value of output time series 36")]
        public string DisplayValue36 { get; set; }

        ///<summary>
        ///Grade code of output time series 36
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 36", Format="int64")]
        public long? GradeCode36 { get; set; }

        ///<summary>
        ///Grade name of output time series 36
        ///</summary>
        [ApiMember(Description="Grade name of output time series 36")]
        public string GradeName36 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 36
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 36")]
        public string Qualifiers36 { get; set; }

        ///<summary>
        ///Method of output time series 36
        ///</summary>
        [ApiMember(Description="Method of output time series 36")]
        public string Method36 { get; set; }

        ///<summary>
        ///Approval level of output time series 36
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 36", Format="int64")]
        public long? ApprovalLevel36 { get; set; }

        ///<summary>
        ///Approval name of output time series 36
        ///</summary>
        [ApiMember(Description="Approval name of output time series 36")]
        public string ApprovalName36 { get; set; }

        ///<summary>
        ///Numeric value of output time series 37
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 37", Format="double")]
        public double? NumericValue37 { get; set; }

        ///<summary>
        ///Display value of output time series 37
        ///</summary>
        [ApiMember(Description="Display value of output time series 37")]
        public string DisplayValue37 { get; set; }

        ///<summary>
        ///Grade code of output time series 37
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 37", Format="int64")]
        public long? GradeCode37 { get; set; }

        ///<summary>
        ///Grade name of output time series 37
        ///</summary>
        [ApiMember(Description="Grade name of output time series 37")]
        public string GradeName37 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 37
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 37")]
        public string Qualifiers37 { get; set; }

        ///<summary>
        ///Method of output time series 37
        ///</summary>
        [ApiMember(Description="Method of output time series 37")]
        public string Method37 { get; set; }

        ///<summary>
        ///Approval level of output time series 37
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 37", Format="int64")]
        public long? ApprovalLevel37 { get; set; }

        ///<summary>
        ///Approval name of output time series 37
        ///</summary>
        [ApiMember(Description="Approval name of output time series 37")]
        public string ApprovalName37 { get; set; }

        ///<summary>
        ///Numeric value of output time series 38
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 38", Format="double")]
        public double? NumericValue38 { get; set; }

        ///<summary>
        ///Display value of output time series 38
        ///</summary>
        [ApiMember(Description="Display value of output time series 38")]
        public string DisplayValue38 { get; set; }

        ///<summary>
        ///Grade code of output time series 38
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 38", Format="int64")]
        public long? GradeCode38 { get; set; }

        ///<summary>
        ///Grade name of output time series 38
        ///</summary>
        [ApiMember(Description="Grade name of output time series 38")]
        public string GradeName38 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 38
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 38")]
        public string Qualifiers38 { get; set; }

        ///<summary>
        ///Method of output time series 38
        ///</summary>
        [ApiMember(Description="Method of output time series 38")]
        public string Method38 { get; set; }

        ///<summary>
        ///Approval level of output time series 38
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 38", Format="int64")]
        public long? ApprovalLevel38 { get; set; }

        ///<summary>
        ///Approval name of output time series 38
        ///</summary>
        [ApiMember(Description="Approval name of output time series 38")]
        public string ApprovalName38 { get; set; }

        ///<summary>
        ///Numeric value of output time series 39
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 39", Format="double")]
        public double? NumericValue39 { get; set; }

        ///<summary>
        ///Display value of output time series 39
        ///</summary>
        [ApiMember(Description="Display value of output time series 39")]
        public string DisplayValue39 { get; set; }

        ///<summary>
        ///Grade code of output time series 39
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 39", Format="int64")]
        public long? GradeCode39 { get; set; }

        ///<summary>
        ///Grade name of output time series 39
        ///</summary>
        [ApiMember(Description="Grade name of output time series 39")]
        public string GradeName39 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 39
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 39")]
        public string Qualifiers39 { get; set; }

        ///<summary>
        ///Method of output time series 39
        ///</summary>
        [ApiMember(Description="Method of output time series 39")]
        public string Method39 { get; set; }

        ///<summary>
        ///Approval level of output time series 39
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 39", Format="int64")]
        public long? ApprovalLevel39 { get; set; }

        ///<summary>
        ///Approval name of output time series 39
        ///</summary>
        [ApiMember(Description="Approval name of output time series 39")]
        public string ApprovalName39 { get; set; }

        ///<summary>
        ///Numeric value of output time series 40
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 40", Format="double")]
        public double? NumericValue40 { get; set; }

        ///<summary>
        ///Display value of output time series 40
        ///</summary>
        [ApiMember(Description="Display value of output time series 40")]
        public string DisplayValue40 { get; set; }

        ///<summary>
        ///Grade code of output time series 40
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 40", Format="int64")]
        public long? GradeCode40 { get; set; }

        ///<summary>
        ///Grade name of output time series 40
        ///</summary>
        [ApiMember(Description="Grade name of output time series 40")]
        public string GradeName40 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 40
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 40")]
        public string Qualifiers40 { get; set; }

        ///<summary>
        ///Method of output time series 40
        ///</summary>
        [ApiMember(Description="Method of output time series 40")]
        public string Method40 { get; set; }

        ///<summary>
        ///Approval level of output time series 40
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 40", Format="int64")]
        public long? ApprovalLevel40 { get; set; }

        ///<summary>
        ///Approval name of output time series 40
        ///</summary>
        [ApiMember(Description="Approval name of output time series 40")]
        public string ApprovalName40 { get; set; }

        ///<summary>
        ///Numeric value of output time series 41
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 41", Format="double")]
        public double? NumericValue41 { get; set; }

        ///<summary>
        ///Display value of output time series 41
        ///</summary>
        [ApiMember(Description="Display value of output time series 41")]
        public string DisplayValue41 { get; set; }

        ///<summary>
        ///Grade code of output time series 41
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 41", Format="int64")]
        public long? GradeCode41 { get; set; }

        ///<summary>
        ///Grade name of output time series 41
        ///</summary>
        [ApiMember(Description="Grade name of output time series 41")]
        public string GradeName41 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 41
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 41")]
        public string Qualifiers41 { get; set; }

        ///<summary>
        ///Method of output time series 41
        ///</summary>
        [ApiMember(Description="Method of output time series 41")]
        public string Method41 { get; set; }

        ///<summary>
        ///Approval level of output time series 41
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 41", Format="int64")]
        public long? ApprovalLevel41 { get; set; }

        ///<summary>
        ///Approval name of output time series 41
        ///</summary>
        [ApiMember(Description="Approval name of output time series 41")]
        public string ApprovalName41 { get; set; }

        ///<summary>
        ///Numeric value of output time series 42
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 42", Format="double")]
        public double? NumericValue42 { get; set; }

        ///<summary>
        ///Display value of output time series 42
        ///</summary>
        [ApiMember(Description="Display value of output time series 42")]
        public string DisplayValue42 { get; set; }

        ///<summary>
        ///Grade code of output time series 42
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 42", Format="int64")]
        public long? GradeCode42 { get; set; }

        ///<summary>
        ///Grade name of output time series 42
        ///</summary>
        [ApiMember(Description="Grade name of output time series 42")]
        public string GradeName42 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 42
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 42")]
        public string Qualifiers42 { get; set; }

        ///<summary>
        ///Method of output time series 42
        ///</summary>
        [ApiMember(Description="Method of output time series 42")]
        public string Method42 { get; set; }

        ///<summary>
        ///Approval level of output time series 42
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 42", Format="int64")]
        public long? ApprovalLevel42 { get; set; }

        ///<summary>
        ///Approval name of output time series 42
        ///</summary>
        [ApiMember(Description="Approval name of output time series 42")]
        public string ApprovalName42 { get; set; }

        ///<summary>
        ///Numeric value of output time series 43
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 43", Format="double")]
        public double? NumericValue43 { get; set; }

        ///<summary>
        ///Display value of output time series 43
        ///</summary>
        [ApiMember(Description="Display value of output time series 43")]
        public string DisplayValue43 { get; set; }

        ///<summary>
        ///Grade code of output time series 43
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 43", Format="int64")]
        public long? GradeCode43 { get; set; }

        ///<summary>
        ///Grade name of output time series 43
        ///</summary>
        [ApiMember(Description="Grade name of output time series 43")]
        public string GradeName43 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 43
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 43")]
        public string Qualifiers43 { get; set; }

        ///<summary>
        ///Method of output time series 43
        ///</summary>
        [ApiMember(Description="Method of output time series 43")]
        public string Method43 { get; set; }

        ///<summary>
        ///Approval level of output time series 43
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 43", Format="int64")]
        public long? ApprovalLevel43 { get; set; }

        ///<summary>
        ///Approval name of output time series 43
        ///</summary>
        [ApiMember(Description="Approval name of output time series 43")]
        public string ApprovalName43 { get; set; }

        ///<summary>
        ///Numeric value of output time series 44
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 44", Format="double")]
        public double? NumericValue44 { get; set; }

        ///<summary>
        ///Display value of output time series 44
        ///</summary>
        [ApiMember(Description="Display value of output time series 44")]
        public string DisplayValue44 { get; set; }

        ///<summary>
        ///Grade code of output time series 44
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 44", Format="int64")]
        public long? GradeCode44 { get; set; }

        ///<summary>
        ///Grade name of output time series 44
        ///</summary>
        [ApiMember(Description="Grade name of output time series 44")]
        public string GradeName44 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 44
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 44")]
        public string Qualifiers44 { get; set; }

        ///<summary>
        ///Method of output time series 44
        ///</summary>
        [ApiMember(Description="Method of output time series 44")]
        public string Method44 { get; set; }

        ///<summary>
        ///Approval level of output time series 44
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 44", Format="int64")]
        public long? ApprovalLevel44 { get; set; }

        ///<summary>
        ///Approval name of output time series 44
        ///</summary>
        [ApiMember(Description="Approval name of output time series 44")]
        public string ApprovalName44 { get; set; }

        ///<summary>
        ///Numeric value of output time series 45
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 45", Format="double")]
        public double? NumericValue45 { get; set; }

        ///<summary>
        ///Display value of output time series 45
        ///</summary>
        [ApiMember(Description="Display value of output time series 45")]
        public string DisplayValue45 { get; set; }

        ///<summary>
        ///Grade code of output time series 45
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 45", Format="int64")]
        public long? GradeCode45 { get; set; }

        ///<summary>
        ///Grade name of output time series 45
        ///</summary>
        [ApiMember(Description="Grade name of output time series 45")]
        public string GradeName45 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 45
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 45")]
        public string Qualifiers45 { get; set; }

        ///<summary>
        ///Method of output time series 45
        ///</summary>
        [ApiMember(Description="Method of output time series 45")]
        public string Method45 { get; set; }

        ///<summary>
        ///Approval level of output time series 45
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 45", Format="int64")]
        public long? ApprovalLevel45 { get; set; }

        ///<summary>
        ///Approval name of output time series 45
        ///</summary>
        [ApiMember(Description="Approval name of output time series 45")]
        public string ApprovalName45 { get; set; }

        ///<summary>
        ///Numeric value of output time series 46
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 46", Format="double")]
        public double? NumericValue46 { get; set; }

        ///<summary>
        ///Display value of output time series 46
        ///</summary>
        [ApiMember(Description="Display value of output time series 46")]
        public string DisplayValue46 { get; set; }

        ///<summary>
        ///Grade code of output time series 46
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 46", Format="int64")]
        public long? GradeCode46 { get; set; }

        ///<summary>
        ///Grade name of output time series 46
        ///</summary>
        [ApiMember(Description="Grade name of output time series 46")]
        public string GradeName46 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 46
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 46")]
        public string Qualifiers46 { get; set; }

        ///<summary>
        ///Method of output time series 46
        ///</summary>
        [ApiMember(Description="Method of output time series 46")]
        public string Method46 { get; set; }

        ///<summary>
        ///Approval level of output time series 46
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 46", Format="int64")]
        public long? ApprovalLevel46 { get; set; }

        ///<summary>
        ///Approval name of output time series 46
        ///</summary>
        [ApiMember(Description="Approval name of output time series 46")]
        public string ApprovalName46 { get; set; }

        ///<summary>
        ///Numeric value of output time series 47
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 47", Format="double")]
        public double? NumericValue47 { get; set; }

        ///<summary>
        ///Display value of output time series 47
        ///</summary>
        [ApiMember(Description="Display value of output time series 47")]
        public string DisplayValue47 { get; set; }

        ///<summary>
        ///Grade code of output time series 47
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 47", Format="int64")]
        public long? GradeCode47 { get; set; }

        ///<summary>
        ///Grade name of output time series 47
        ///</summary>
        [ApiMember(Description="Grade name of output time series 47")]
        public string GradeName47 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 47
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 47")]
        public string Qualifiers47 { get; set; }

        ///<summary>
        ///Method of output time series 47
        ///</summary>
        [ApiMember(Description="Method of output time series 47")]
        public string Method47 { get; set; }

        ///<summary>
        ///Approval level of output time series 47
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 47", Format="int64")]
        public long? ApprovalLevel47 { get; set; }

        ///<summary>
        ///Approval name of output time series 47
        ///</summary>
        [ApiMember(Description="Approval name of output time series 47")]
        public string ApprovalName47 { get; set; }

        ///<summary>
        ///Numeric value of output time series 48
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 48", Format="double")]
        public double? NumericValue48 { get; set; }

        ///<summary>
        ///Display value of output time series 48
        ///</summary>
        [ApiMember(Description="Display value of output time series 48")]
        public string DisplayValue48 { get; set; }

        ///<summary>
        ///Grade code of output time series 48
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 48", Format="int64")]
        public long? GradeCode48 { get; set; }

        ///<summary>
        ///Grade name of output time series 48
        ///</summary>
        [ApiMember(Description="Grade name of output time series 48")]
        public string GradeName48 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 48
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 48")]
        public string Qualifiers48 { get; set; }

        ///<summary>
        ///Method of output time series 48
        ///</summary>
        [ApiMember(Description="Method of output time series 48")]
        public string Method48 { get; set; }

        ///<summary>
        ///Approval level of output time series 48
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 48", Format="int64")]
        public long? ApprovalLevel48 { get; set; }

        ///<summary>
        ///Approval name of output time series 48
        ///</summary>
        [ApiMember(Description="Approval name of output time series 48")]
        public string ApprovalName48 { get; set; }

        ///<summary>
        ///Numeric value of output time series 49
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 49", Format="double")]
        public double? NumericValue49 { get; set; }

        ///<summary>
        ///Display value of output time series 49
        ///</summary>
        [ApiMember(Description="Display value of output time series 49")]
        public string DisplayValue49 { get; set; }

        ///<summary>
        ///Grade code of output time series 49
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 49", Format="int64")]
        public long? GradeCode49 { get; set; }

        ///<summary>
        ///Grade name of output time series 49
        ///</summary>
        [ApiMember(Description="Grade name of output time series 49")]
        public string GradeName49 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 49
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 49")]
        public string Qualifiers49 { get; set; }

        ///<summary>
        ///Method of output time series 49
        ///</summary>
        [ApiMember(Description="Method of output time series 49")]
        public string Method49 { get; set; }

        ///<summary>
        ///Approval level of output time series 49
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 49", Format="int64")]
        public long? ApprovalLevel49 { get; set; }

        ///<summary>
        ///Approval name of output time series 49
        ///</summary>
        [ApiMember(Description="Approval name of output time series 49")]
        public string ApprovalName49 { get; set; }

        ///<summary>
        ///Numeric value of output time series 50
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 50", Format="double")]
        public double? NumericValue50 { get; set; }

        ///<summary>
        ///Display value of output time series 50
        ///</summary>
        [ApiMember(Description="Display value of output time series 50")]
        public string DisplayValue50 { get; set; }

        ///<summary>
        ///Grade code of output time series 50
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 50", Format="int64")]
        public long? GradeCode50 { get; set; }

        ///<summary>
        ///Grade name of output time series 50
        ///</summary>
        [ApiMember(Description="Grade name of output time series 50")]
        public string GradeName50 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 50
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 50")]
        public string Qualifiers50 { get; set; }

        ///<summary>
        ///Method of output time series 50
        ///</summary>
        [ApiMember(Description="Method of output time series 50")]
        public string Method50 { get; set; }

        ///<summary>
        ///Approval level of output time series 50
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 50", Format="int64")]
        public long? ApprovalLevel50 { get; set; }

        ///<summary>
        ///Approval name of output time series 50
        ///</summary>
        [ApiMember(Description="Approval name of output time series 50")]
        public string ApprovalName50 { get; set; }

        ///<summary>
        ///Numeric value of output time series 51
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 51", Format="double")]
        public double? NumericValue51 { get; set; }

        ///<summary>
        ///Display value of output time series 51
        ///</summary>
        [ApiMember(Description="Display value of output time series 51")]
        public string DisplayValue51 { get; set; }

        ///<summary>
        ///Grade code of output time series 51
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 51", Format="int64")]
        public long? GradeCode51 { get; set; }

        ///<summary>
        ///Grade name of output time series 51
        ///</summary>
        [ApiMember(Description="Grade name of output time series 51")]
        public string GradeName51 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 51
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 51")]
        public string Qualifiers51 { get; set; }

        ///<summary>
        ///Method of output time series 51
        ///</summary>
        [ApiMember(Description="Method of output time series 51")]
        public string Method51 { get; set; }

        ///<summary>
        ///Approval level of output time series 51
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 51", Format="int64")]
        public long? ApprovalLevel51 { get; set; }

        ///<summary>
        ///Approval name of output time series 51
        ///</summary>
        [ApiMember(Description="Approval name of output time series 51")]
        public string ApprovalName51 { get; set; }

        ///<summary>
        ///Numeric value of output time series 52
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 52", Format="double")]
        public double? NumericValue52 { get; set; }

        ///<summary>
        ///Display value of output time series 52
        ///</summary>
        [ApiMember(Description="Display value of output time series 52")]
        public string DisplayValue52 { get; set; }

        ///<summary>
        ///Grade code of output time series 52
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 52", Format="int64")]
        public long? GradeCode52 { get; set; }

        ///<summary>
        ///Grade name of output time series 52
        ///</summary>
        [ApiMember(Description="Grade name of output time series 52")]
        public string GradeName52 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 52
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 52")]
        public string Qualifiers52 { get; set; }

        ///<summary>
        ///Method of output time series 52
        ///</summary>
        [ApiMember(Description="Method of output time series 52")]
        public string Method52 { get; set; }

        ///<summary>
        ///Approval level of output time series 52
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 52", Format="int64")]
        public long? ApprovalLevel52 { get; set; }

        ///<summary>
        ///Approval name of output time series 52
        ///</summary>
        [ApiMember(Description="Approval name of output time series 52")]
        public string ApprovalName52 { get; set; }

        ///<summary>
        ///Numeric value of output time series 53
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 53", Format="double")]
        public double? NumericValue53 { get; set; }

        ///<summary>
        ///Display value of output time series 53
        ///</summary>
        [ApiMember(Description="Display value of output time series 53")]
        public string DisplayValue53 { get; set; }

        ///<summary>
        ///Grade code of output time series 53
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 53", Format="int64")]
        public long? GradeCode53 { get; set; }

        ///<summary>
        ///Grade name of output time series 53
        ///</summary>
        [ApiMember(Description="Grade name of output time series 53")]
        public string GradeName53 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 53
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 53")]
        public string Qualifiers53 { get; set; }

        ///<summary>
        ///Method of output time series 53
        ///</summary>
        [ApiMember(Description="Method of output time series 53")]
        public string Method53 { get; set; }

        ///<summary>
        ///Approval level of output time series 53
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 53", Format="int64")]
        public long? ApprovalLevel53 { get; set; }

        ///<summary>
        ///Approval name of output time series 53
        ///</summary>
        [ApiMember(Description="Approval name of output time series 53")]
        public string ApprovalName53 { get; set; }

        ///<summary>
        ///Numeric value of output time series 54
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 54", Format="double")]
        public double? NumericValue54 { get; set; }

        ///<summary>
        ///Display value of output time series 54
        ///</summary>
        [ApiMember(Description="Display value of output time series 54")]
        public string DisplayValue54 { get; set; }

        ///<summary>
        ///Grade code of output time series 54
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 54", Format="int64")]
        public long? GradeCode54 { get; set; }

        ///<summary>
        ///Grade name of output time series 54
        ///</summary>
        [ApiMember(Description="Grade name of output time series 54")]
        public string GradeName54 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 54
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 54")]
        public string Qualifiers54 { get; set; }

        ///<summary>
        ///Method of output time series 54
        ///</summary>
        [ApiMember(Description="Method of output time series 54")]
        public string Method54 { get; set; }

        ///<summary>
        ///Approval level of output time series 54
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 54", Format="int64")]
        public long? ApprovalLevel54 { get; set; }

        ///<summary>
        ///Approval name of output time series 54
        ///</summary>
        [ApiMember(Description="Approval name of output time series 54")]
        public string ApprovalName54 { get; set; }

        ///<summary>
        ///Numeric value of output time series 55
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 55", Format="double")]
        public double? NumericValue55 { get; set; }

        ///<summary>
        ///Display value of output time series 55
        ///</summary>
        [ApiMember(Description="Display value of output time series 55")]
        public string DisplayValue55 { get; set; }

        ///<summary>
        ///Grade code of output time series 55
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 55", Format="int64")]
        public long? GradeCode55 { get; set; }

        ///<summary>
        ///Grade name of output time series 55
        ///</summary>
        [ApiMember(Description="Grade name of output time series 55")]
        public string GradeName55 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 55
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 55")]
        public string Qualifiers55 { get; set; }

        ///<summary>
        ///Method of output time series 55
        ///</summary>
        [ApiMember(Description="Method of output time series 55")]
        public string Method55 { get; set; }

        ///<summary>
        ///Approval level of output time series 55
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 55", Format="int64")]
        public long? ApprovalLevel55 { get; set; }

        ///<summary>
        ///Approval name of output time series 55
        ///</summary>
        [ApiMember(Description="Approval name of output time series 55")]
        public string ApprovalName55 { get; set; }

        ///<summary>
        ///Numeric value of output time series 56
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 56", Format="double")]
        public double? NumericValue56 { get; set; }

        ///<summary>
        ///Display value of output time series 56
        ///</summary>
        [ApiMember(Description="Display value of output time series 56")]
        public string DisplayValue56 { get; set; }

        ///<summary>
        ///Grade code of output time series 56
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 56", Format="int64")]
        public long? GradeCode56 { get; set; }

        ///<summary>
        ///Grade name of output time series 56
        ///</summary>
        [ApiMember(Description="Grade name of output time series 56")]
        public string GradeName56 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 56
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 56")]
        public string Qualifiers56 { get; set; }

        ///<summary>
        ///Method of output time series 56
        ///</summary>
        [ApiMember(Description="Method of output time series 56")]
        public string Method56 { get; set; }

        ///<summary>
        ///Approval level of output time series 56
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 56", Format="int64")]
        public long? ApprovalLevel56 { get; set; }

        ///<summary>
        ///Approval name of output time series 56
        ///</summary>
        [ApiMember(Description="Approval name of output time series 56")]
        public string ApprovalName56 { get; set; }

        ///<summary>
        ///Numeric value of output time series 57
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 57", Format="double")]
        public double? NumericValue57 { get; set; }

        ///<summary>
        ///Display value of output time series 57
        ///</summary>
        [ApiMember(Description="Display value of output time series 57")]
        public string DisplayValue57 { get; set; }

        ///<summary>
        ///Grade code of output time series 57
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 57", Format="int64")]
        public long? GradeCode57 { get; set; }

        ///<summary>
        ///Grade name of output time series 57
        ///</summary>
        [ApiMember(Description="Grade name of output time series 57")]
        public string GradeName57 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 57
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 57")]
        public string Qualifiers57 { get; set; }

        ///<summary>
        ///Method of output time series 57
        ///</summary>
        [ApiMember(Description="Method of output time series 57")]
        public string Method57 { get; set; }

        ///<summary>
        ///Approval level of output time series 57
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 57", Format="int64")]
        public long? ApprovalLevel57 { get; set; }

        ///<summary>
        ///Approval name of output time series 57
        ///</summary>
        [ApiMember(Description="Approval name of output time series 57")]
        public string ApprovalName57 { get; set; }

        ///<summary>
        ///Numeric value of output time series 58
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 58", Format="double")]
        public double? NumericValue58 { get; set; }

        ///<summary>
        ///Display value of output time series 58
        ///</summary>
        [ApiMember(Description="Display value of output time series 58")]
        public string DisplayValue58 { get; set; }

        ///<summary>
        ///Grade code of output time series 58
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 58", Format="int64")]
        public long? GradeCode58 { get; set; }

        ///<summary>
        ///Grade name of output time series 58
        ///</summary>
        [ApiMember(Description="Grade name of output time series 58")]
        public string GradeName58 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 58
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 58")]
        public string Qualifiers58 { get; set; }

        ///<summary>
        ///Method of output time series 58
        ///</summary>
        [ApiMember(Description="Method of output time series 58")]
        public string Method58 { get; set; }

        ///<summary>
        ///Approval level of output time series 58
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 58", Format="int64")]
        public long? ApprovalLevel58 { get; set; }

        ///<summary>
        ///Approval name of output time series 58
        ///</summary>
        [ApiMember(Description="Approval name of output time series 58")]
        public string ApprovalName58 { get; set; }

        ///<summary>
        ///Numeric value of output time series 59
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 59", Format="double")]
        public double? NumericValue59 { get; set; }

        ///<summary>
        ///Display value of output time series 59
        ///</summary>
        [ApiMember(Description="Display value of output time series 59")]
        public string DisplayValue59 { get; set; }

        ///<summary>
        ///Grade code of output time series 59
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 59", Format="int64")]
        public long? GradeCode59 { get; set; }

        ///<summary>
        ///Grade name of output time series 59
        ///</summary>
        [ApiMember(Description="Grade name of output time series 59")]
        public string GradeName59 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 59
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 59")]
        public string Qualifiers59 { get; set; }

        ///<summary>
        ///Method of output time series 59
        ///</summary>
        [ApiMember(Description="Method of output time series 59")]
        public string Method59 { get; set; }

        ///<summary>
        ///Approval level of output time series 59
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 59", Format="int64")]
        public long? ApprovalLevel59 { get; set; }

        ///<summary>
        ///Approval name of output time series 59
        ///</summary>
        [ApiMember(Description="Approval name of output time series 59")]
        public string ApprovalName59 { get; set; }

        ///<summary>
        ///Numeric value of output time series 60
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 60", Format="double")]
        public double? NumericValue60 { get; set; }

        ///<summary>
        ///Display value of output time series 60
        ///</summary>
        [ApiMember(Description="Display value of output time series 60")]
        public string DisplayValue60 { get; set; }

        ///<summary>
        ///Grade code of output time series 60
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 60", Format="int64")]
        public long? GradeCode60 { get; set; }

        ///<summary>
        ///Grade name of output time series 60
        ///</summary>
        [ApiMember(Description="Grade name of output time series 60")]
        public string GradeName60 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 60
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 60")]
        public string Qualifiers60 { get; set; }

        ///<summary>
        ///Method of output time series 60
        ///</summary>
        [ApiMember(Description="Method of output time series 60")]
        public string Method60 { get; set; }

        ///<summary>
        ///Approval level of output time series 60
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 60", Format="int64")]
        public long? ApprovalLevel60 { get; set; }

        ///<summary>
        ///Approval name of output time series 60
        ///</summary>
        [ApiMember(Description="Approval name of output time series 60")]
        public string ApprovalName60 { get; set; }

        ///<summary>
        ///Numeric value of output time series 61
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 61", Format="double")]
        public double? NumericValue61 { get; set; }

        ///<summary>
        ///Display value of output time series 61
        ///</summary>
        [ApiMember(Description="Display value of output time series 61")]
        public string DisplayValue61 { get; set; }

        ///<summary>
        ///Grade code of output time series 61
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 61", Format="int64")]
        public long? GradeCode61 { get; set; }

        ///<summary>
        ///Grade name of output time series 61
        ///</summary>
        [ApiMember(Description="Grade name of output time series 61")]
        public string GradeName61 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 61
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 61")]
        public string Qualifiers61 { get; set; }

        ///<summary>
        ///Method of output time series 61
        ///</summary>
        [ApiMember(Description="Method of output time series 61")]
        public string Method61 { get; set; }

        ///<summary>
        ///Approval level of output time series 61
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 61", Format="int64")]
        public long? ApprovalLevel61 { get; set; }

        ///<summary>
        ///Approval name of output time series 61
        ///</summary>
        [ApiMember(Description="Approval name of output time series 61")]
        public string ApprovalName61 { get; set; }

        ///<summary>
        ///Numeric value of output time series 62
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 62", Format="double")]
        public double? NumericValue62 { get; set; }

        ///<summary>
        ///Display value of output time series 62
        ///</summary>
        [ApiMember(Description="Display value of output time series 62")]
        public string DisplayValue62 { get; set; }

        ///<summary>
        ///Grade code of output time series 62
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 62", Format="int64")]
        public long? GradeCode62 { get; set; }

        ///<summary>
        ///Grade name of output time series 62
        ///</summary>
        [ApiMember(Description="Grade name of output time series 62")]
        public string GradeName62 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 62
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 62")]
        public string Qualifiers62 { get; set; }

        ///<summary>
        ///Method of output time series 62
        ///</summary>
        [ApiMember(Description="Method of output time series 62")]
        public string Method62 { get; set; }

        ///<summary>
        ///Approval level of output time series 62
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 62", Format="int64")]
        public long? ApprovalLevel62 { get; set; }

        ///<summary>
        ///Approval name of output time series 62
        ///</summary>
        [ApiMember(Description="Approval name of output time series 62")]
        public string ApprovalName62 { get; set; }

        ///<summary>
        ///Numeric value of output time series 63
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 63", Format="double")]
        public double? NumericValue63 { get; set; }

        ///<summary>
        ///Display value of output time series 63
        ///</summary>
        [ApiMember(Description="Display value of output time series 63")]
        public string DisplayValue63 { get; set; }

        ///<summary>
        ///Grade code of output time series 63
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 63", Format="int64")]
        public long? GradeCode63 { get; set; }

        ///<summary>
        ///Grade name of output time series 63
        ///</summary>
        [ApiMember(Description="Grade name of output time series 63")]
        public string GradeName63 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 63
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 63")]
        public string Qualifiers63 { get; set; }

        ///<summary>
        ///Method of output time series 63
        ///</summary>
        [ApiMember(Description="Method of output time series 63")]
        public string Method63 { get; set; }

        ///<summary>
        ///Approval level of output time series 63
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 63", Format="int64")]
        public long? ApprovalLevel63 { get; set; }

        ///<summary>
        ///Approval name of output time series 63
        ///</summary>
        [ApiMember(Description="Approval name of output time series 63")]
        public string ApprovalName63 { get; set; }

        ///<summary>
        ///Numeric value of output time series 64
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 64", Format="double")]
        public double? NumericValue64 { get; set; }

        ///<summary>
        ///Display value of output time series 64
        ///</summary>
        [ApiMember(Description="Display value of output time series 64")]
        public string DisplayValue64 { get; set; }

        ///<summary>
        ///Grade code of output time series 64
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 64", Format="int64")]
        public long? GradeCode64 { get; set; }

        ///<summary>
        ///Grade name of output time series 64
        ///</summary>
        [ApiMember(Description="Grade name of output time series 64")]
        public string GradeName64 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 64
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 64")]
        public string Qualifiers64 { get; set; }

        ///<summary>
        ///Method of output time series 64
        ///</summary>
        [ApiMember(Description="Method of output time series 64")]
        public string Method64 { get; set; }

        ///<summary>
        ///Approval level of output time series 64
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 64", Format="int64")]
        public long? ApprovalLevel64 { get; set; }

        ///<summary>
        ///Approval name of output time series 64
        ///</summary>
        [ApiMember(Description="Approval name of output time series 64")]
        public string ApprovalName64 { get; set; }

        ///<summary>
        ///Numeric value of output time series 65
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 65", Format="double")]
        public double? NumericValue65 { get; set; }

        ///<summary>
        ///Display value of output time series 65
        ///</summary>
        [ApiMember(Description="Display value of output time series 65")]
        public string DisplayValue65 { get; set; }

        ///<summary>
        ///Grade code of output time series 65
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 65", Format="int64")]
        public long? GradeCode65 { get; set; }

        ///<summary>
        ///Grade name of output time series 65
        ///</summary>
        [ApiMember(Description="Grade name of output time series 65")]
        public string GradeName65 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 65
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 65")]
        public string Qualifiers65 { get; set; }

        ///<summary>
        ///Method of output time series 65
        ///</summary>
        [ApiMember(Description="Method of output time series 65")]
        public string Method65 { get; set; }

        ///<summary>
        ///Approval level of output time series 65
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 65", Format="int64")]
        public long? ApprovalLevel65 { get; set; }

        ///<summary>
        ///Approval name of output time series 65
        ///</summary>
        [ApiMember(Description="Approval name of output time series 65")]
        public string ApprovalName65 { get; set; }

        ///<summary>
        ///Numeric value of output time series 66
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 66", Format="double")]
        public double? NumericValue66 { get; set; }

        ///<summary>
        ///Display value of output time series 66
        ///</summary>
        [ApiMember(Description="Display value of output time series 66")]
        public string DisplayValue66 { get; set; }

        ///<summary>
        ///Grade code of output time series 66
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 66", Format="int64")]
        public long? GradeCode66 { get; set; }

        ///<summary>
        ///Grade name of output time series 66
        ///</summary>
        [ApiMember(Description="Grade name of output time series 66")]
        public string GradeName66 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 66
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 66")]
        public string Qualifiers66 { get; set; }

        ///<summary>
        ///Method of output time series 66
        ///</summary>
        [ApiMember(Description="Method of output time series 66")]
        public string Method66 { get; set; }

        ///<summary>
        ///Approval level of output time series 66
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 66", Format="int64")]
        public long? ApprovalLevel66 { get; set; }

        ///<summary>
        ///Approval name of output time series 66
        ///</summary>
        [ApiMember(Description="Approval name of output time series 66")]
        public string ApprovalName66 { get; set; }

        ///<summary>
        ///Numeric value of output time series 67
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 67", Format="double")]
        public double? NumericValue67 { get; set; }

        ///<summary>
        ///Display value of output time series 67
        ///</summary>
        [ApiMember(Description="Display value of output time series 67")]
        public string DisplayValue67 { get; set; }

        ///<summary>
        ///Grade code of output time series 67
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 67", Format="int64")]
        public long? GradeCode67 { get; set; }

        ///<summary>
        ///Grade name of output time series 67
        ///</summary>
        [ApiMember(Description="Grade name of output time series 67")]
        public string GradeName67 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 67
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 67")]
        public string Qualifiers67 { get; set; }

        ///<summary>
        ///Method of output time series 67
        ///</summary>
        [ApiMember(Description="Method of output time series 67")]
        public string Method67 { get; set; }

        ///<summary>
        ///Approval level of output time series 67
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 67", Format="int64")]
        public long? ApprovalLevel67 { get; set; }

        ///<summary>
        ///Approval name of output time series 67
        ///</summary>
        [ApiMember(Description="Approval name of output time series 67")]
        public string ApprovalName67 { get; set; }

        ///<summary>
        ///Numeric value of output time series 68
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 68", Format="double")]
        public double? NumericValue68 { get; set; }

        ///<summary>
        ///Display value of output time series 68
        ///</summary>
        [ApiMember(Description="Display value of output time series 68")]
        public string DisplayValue68 { get; set; }

        ///<summary>
        ///Grade code of output time series 68
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 68", Format="int64")]
        public long? GradeCode68 { get; set; }

        ///<summary>
        ///Grade name of output time series 68
        ///</summary>
        [ApiMember(Description="Grade name of output time series 68")]
        public string GradeName68 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 68
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 68")]
        public string Qualifiers68 { get; set; }

        ///<summary>
        ///Method of output time series 68
        ///</summary>
        [ApiMember(Description="Method of output time series 68")]
        public string Method68 { get; set; }

        ///<summary>
        ///Approval level of output time series 68
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 68", Format="int64")]
        public long? ApprovalLevel68 { get; set; }

        ///<summary>
        ///Approval name of output time series 68
        ///</summary>
        [ApiMember(Description="Approval name of output time series 68")]
        public string ApprovalName68 { get; set; }

        ///<summary>
        ///Numeric value of output time series 69
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 69", Format="double")]
        public double? NumericValue69 { get; set; }

        ///<summary>
        ///Display value of output time series 69
        ///</summary>
        [ApiMember(Description="Display value of output time series 69")]
        public string DisplayValue69 { get; set; }

        ///<summary>
        ///Grade code of output time series 69
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 69", Format="int64")]
        public long? GradeCode69 { get; set; }

        ///<summary>
        ///Grade name of output time series 69
        ///</summary>
        [ApiMember(Description="Grade name of output time series 69")]
        public string GradeName69 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 69
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 69")]
        public string Qualifiers69 { get; set; }

        ///<summary>
        ///Method of output time series 69
        ///</summary>
        [ApiMember(Description="Method of output time series 69")]
        public string Method69 { get; set; }

        ///<summary>
        ///Approval level of output time series 69
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 69", Format="int64")]
        public long? ApprovalLevel69 { get; set; }

        ///<summary>
        ///Approval name of output time series 69
        ///</summary>
        [ApiMember(Description="Approval name of output time series 69")]
        public string ApprovalName69 { get; set; }

        ///<summary>
        ///Numeric value of output time series 70
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 70", Format="double")]
        public double? NumericValue70 { get; set; }

        ///<summary>
        ///Display value of output time series 70
        ///</summary>
        [ApiMember(Description="Display value of output time series 70")]
        public string DisplayValue70 { get; set; }

        ///<summary>
        ///Grade code of output time series 70
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 70", Format="int64")]
        public long? GradeCode70 { get; set; }

        ///<summary>
        ///Grade name of output time series 70
        ///</summary>
        [ApiMember(Description="Grade name of output time series 70")]
        public string GradeName70 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 70
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 70")]
        public string Qualifiers70 { get; set; }

        ///<summary>
        ///Method of output time series 70
        ///</summary>
        [ApiMember(Description="Method of output time series 70")]
        public string Method70 { get; set; }

        ///<summary>
        ///Approval level of output time series 70
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 70", Format="int64")]
        public long? ApprovalLevel70 { get; set; }

        ///<summary>
        ///Approval name of output time series 70
        ///</summary>
        [ApiMember(Description="Approval name of output time series 70")]
        public string ApprovalName70 { get; set; }

        ///<summary>
        ///Numeric value of output time series 71
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 71", Format="double")]
        public double? NumericValue71 { get; set; }

        ///<summary>
        ///Display value of output time series 71
        ///</summary>
        [ApiMember(Description="Display value of output time series 71")]
        public string DisplayValue71 { get; set; }

        ///<summary>
        ///Grade code of output time series 71
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 71", Format="int64")]
        public long? GradeCode71 { get; set; }

        ///<summary>
        ///Grade name of output time series 71
        ///</summary>
        [ApiMember(Description="Grade name of output time series 71")]
        public string GradeName71 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 71
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 71")]
        public string Qualifiers71 { get; set; }

        ///<summary>
        ///Method of output time series 71
        ///</summary>
        [ApiMember(Description="Method of output time series 71")]
        public string Method71 { get; set; }

        ///<summary>
        ///Approval level of output time series 71
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 71", Format="int64")]
        public long? ApprovalLevel71 { get; set; }

        ///<summary>
        ///Approval name of output time series 71
        ///</summary>
        [ApiMember(Description="Approval name of output time series 71")]
        public string ApprovalName71 { get; set; }

        ///<summary>
        ///Numeric value of output time series 72
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 72", Format="double")]
        public double? NumericValue72 { get; set; }

        ///<summary>
        ///Display value of output time series 72
        ///</summary>
        [ApiMember(Description="Display value of output time series 72")]
        public string DisplayValue72 { get; set; }

        ///<summary>
        ///Grade code of output time series 72
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 72", Format="int64")]
        public long? GradeCode72 { get; set; }

        ///<summary>
        ///Grade name of output time series 72
        ///</summary>
        [ApiMember(Description="Grade name of output time series 72")]
        public string GradeName72 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 72
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 72")]
        public string Qualifiers72 { get; set; }

        ///<summary>
        ///Method of output time series 72
        ///</summary>
        [ApiMember(Description="Method of output time series 72")]
        public string Method72 { get; set; }

        ///<summary>
        ///Approval level of output time series 72
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 72", Format="int64")]
        public long? ApprovalLevel72 { get; set; }

        ///<summary>
        ///Approval name of output time series 72
        ///</summary>
        [ApiMember(Description="Approval name of output time series 72")]
        public string ApprovalName72 { get; set; }

        ///<summary>
        ///Numeric value of output time series 73
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 73", Format="double")]
        public double? NumericValue73 { get; set; }

        ///<summary>
        ///Display value of output time series 73
        ///</summary>
        [ApiMember(Description="Display value of output time series 73")]
        public string DisplayValue73 { get; set; }

        ///<summary>
        ///Grade code of output time series 73
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 73", Format="int64")]
        public long? GradeCode73 { get; set; }

        ///<summary>
        ///Grade name of output time series 73
        ///</summary>
        [ApiMember(Description="Grade name of output time series 73")]
        public string GradeName73 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 73
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 73")]
        public string Qualifiers73 { get; set; }

        ///<summary>
        ///Method of output time series 73
        ///</summary>
        [ApiMember(Description="Method of output time series 73")]
        public string Method73 { get; set; }

        ///<summary>
        ///Approval level of output time series 73
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 73", Format="int64")]
        public long? ApprovalLevel73 { get; set; }

        ///<summary>
        ///Approval name of output time series 73
        ///</summary>
        [ApiMember(Description="Approval name of output time series 73")]
        public string ApprovalName73 { get; set; }

        ///<summary>
        ///Numeric value of output time series 74
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 74", Format="double")]
        public double? NumericValue74 { get; set; }

        ///<summary>
        ///Display value of output time series 74
        ///</summary>
        [ApiMember(Description="Display value of output time series 74")]
        public string DisplayValue74 { get; set; }

        ///<summary>
        ///Grade code of output time series 74
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 74", Format="int64")]
        public long? GradeCode74 { get; set; }

        ///<summary>
        ///Grade name of output time series 74
        ///</summary>
        [ApiMember(Description="Grade name of output time series 74")]
        public string GradeName74 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 74
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 74")]
        public string Qualifiers74 { get; set; }

        ///<summary>
        ///Method of output time series 74
        ///</summary>
        [ApiMember(Description="Method of output time series 74")]
        public string Method74 { get; set; }

        ///<summary>
        ///Approval level of output time series 74
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 74", Format="int64")]
        public long? ApprovalLevel74 { get; set; }

        ///<summary>
        ///Approval name of output time series 74
        ///</summary>
        [ApiMember(Description="Approval name of output time series 74")]
        public string ApprovalName74 { get; set; }

        ///<summary>
        ///Numeric value of output time series 75
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 75", Format="double")]
        public double? NumericValue75 { get; set; }

        ///<summary>
        ///Display value of output time series 75
        ///</summary>
        [ApiMember(Description="Display value of output time series 75")]
        public string DisplayValue75 { get; set; }

        ///<summary>
        ///Grade code of output time series 75
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 75", Format="int64")]
        public long? GradeCode75 { get; set; }

        ///<summary>
        ///Grade name of output time series 75
        ///</summary>
        [ApiMember(Description="Grade name of output time series 75")]
        public string GradeName75 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 75
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 75")]
        public string Qualifiers75 { get; set; }

        ///<summary>
        ///Method of output time series 75
        ///</summary>
        [ApiMember(Description="Method of output time series 75")]
        public string Method75 { get; set; }

        ///<summary>
        ///Approval level of output time series 75
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 75", Format="int64")]
        public long? ApprovalLevel75 { get; set; }

        ///<summary>
        ///Approval name of output time series 75
        ///</summary>
        [ApiMember(Description="Approval name of output time series 75")]
        public string ApprovalName75 { get; set; }

        ///<summary>
        ///Numeric value of output time series 76
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 76", Format="double")]
        public double? NumericValue76 { get; set; }

        ///<summary>
        ///Display value of output time series 76
        ///</summary>
        [ApiMember(Description="Display value of output time series 76")]
        public string DisplayValue76 { get; set; }

        ///<summary>
        ///Grade code of output time series 76
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 76", Format="int64")]
        public long? GradeCode76 { get; set; }

        ///<summary>
        ///Grade name of output time series 76
        ///</summary>
        [ApiMember(Description="Grade name of output time series 76")]
        public string GradeName76 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 76
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 76")]
        public string Qualifiers76 { get; set; }

        ///<summary>
        ///Method of output time series 76
        ///</summary>
        [ApiMember(Description="Method of output time series 76")]
        public string Method76 { get; set; }

        ///<summary>
        ///Approval level of output time series 76
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 76", Format="int64")]
        public long? ApprovalLevel76 { get; set; }

        ///<summary>
        ///Approval name of output time series 76
        ///</summary>
        [ApiMember(Description="Approval name of output time series 76")]
        public string ApprovalName76 { get; set; }

        ///<summary>
        ///Numeric value of output time series 77
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 77", Format="double")]
        public double? NumericValue77 { get; set; }

        ///<summary>
        ///Display value of output time series 77
        ///</summary>
        [ApiMember(Description="Display value of output time series 77")]
        public string DisplayValue77 { get; set; }

        ///<summary>
        ///Grade code of output time series 77
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 77", Format="int64")]
        public long? GradeCode77 { get; set; }

        ///<summary>
        ///Grade name of output time series 77
        ///</summary>
        [ApiMember(Description="Grade name of output time series 77")]
        public string GradeName77 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 77
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 77")]
        public string Qualifiers77 { get; set; }

        ///<summary>
        ///Method of output time series 77
        ///</summary>
        [ApiMember(Description="Method of output time series 77")]
        public string Method77 { get; set; }

        ///<summary>
        ///Approval level of output time series 77
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 77", Format="int64")]
        public long? ApprovalLevel77 { get; set; }

        ///<summary>
        ///Approval name of output time series 77
        ///</summary>
        [ApiMember(Description="Approval name of output time series 77")]
        public string ApprovalName77 { get; set; }

        ///<summary>
        ///Numeric value of output time series 78
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 78", Format="double")]
        public double? NumericValue78 { get; set; }

        ///<summary>
        ///Display value of output time series 78
        ///</summary>
        [ApiMember(Description="Display value of output time series 78")]
        public string DisplayValue78 { get; set; }

        ///<summary>
        ///Grade code of output time series 78
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 78", Format="int64")]
        public long? GradeCode78 { get; set; }

        ///<summary>
        ///Grade name of output time series 78
        ///</summary>
        [ApiMember(Description="Grade name of output time series 78")]
        public string GradeName78 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 78
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 78")]
        public string Qualifiers78 { get; set; }

        ///<summary>
        ///Method of output time series 78
        ///</summary>
        [ApiMember(Description="Method of output time series 78")]
        public string Method78 { get; set; }

        ///<summary>
        ///Approval level of output time series 78
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 78", Format="int64")]
        public long? ApprovalLevel78 { get; set; }

        ///<summary>
        ///Approval name of output time series 78
        ///</summary>
        [ApiMember(Description="Approval name of output time series 78")]
        public string ApprovalName78 { get; set; }

        ///<summary>
        ///Numeric value of output time series 79
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 79", Format="double")]
        public double? NumericValue79 { get; set; }

        ///<summary>
        ///Display value of output time series 79
        ///</summary>
        [ApiMember(Description="Display value of output time series 79")]
        public string DisplayValue79 { get; set; }

        ///<summary>
        ///Grade code of output time series 79
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 79", Format="int64")]
        public long? GradeCode79 { get; set; }

        ///<summary>
        ///Grade name of output time series 79
        ///</summary>
        [ApiMember(Description="Grade name of output time series 79")]
        public string GradeName79 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 79
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 79")]
        public string Qualifiers79 { get; set; }

        ///<summary>
        ///Method of output time series 79
        ///</summary>
        [ApiMember(Description="Method of output time series 79")]
        public string Method79 { get; set; }

        ///<summary>
        ///Approval level of output time series 79
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 79", Format="int64")]
        public long? ApprovalLevel79 { get; set; }

        ///<summary>
        ///Approval name of output time series 79
        ///</summary>
        [ApiMember(Description="Approval name of output time series 79")]
        public string ApprovalName79 { get; set; }

        ///<summary>
        ///Numeric value of output time series 80
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 80", Format="double")]
        public double? NumericValue80 { get; set; }

        ///<summary>
        ///Display value of output time series 80
        ///</summary>
        [ApiMember(Description="Display value of output time series 80")]
        public string DisplayValue80 { get; set; }

        ///<summary>
        ///Grade code of output time series 80
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 80", Format="int64")]
        public long? GradeCode80 { get; set; }

        ///<summary>
        ///Grade name of output time series 80
        ///</summary>
        [ApiMember(Description="Grade name of output time series 80")]
        public string GradeName80 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 80
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 80")]
        public string Qualifiers80 { get; set; }

        ///<summary>
        ///Method of output time series 80
        ///</summary>
        [ApiMember(Description="Method of output time series 80")]
        public string Method80 { get; set; }

        ///<summary>
        ///Approval level of output time series 80
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 80", Format="int64")]
        public long? ApprovalLevel80 { get; set; }

        ///<summary>
        ///Approval name of output time series 80
        ///</summary>
        [ApiMember(Description="Approval name of output time series 80")]
        public string ApprovalName80 { get; set; }

        ///<summary>
        ///Numeric value of output time series 81
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 81", Format="double")]
        public double? NumericValue81 { get; set; }

        ///<summary>
        ///Display value of output time series 81
        ///</summary>
        [ApiMember(Description="Display value of output time series 81")]
        public string DisplayValue81 { get; set; }

        ///<summary>
        ///Grade code of output time series 81
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 81", Format="int64")]
        public long? GradeCode81 { get; set; }

        ///<summary>
        ///Grade name of output time series 81
        ///</summary>
        [ApiMember(Description="Grade name of output time series 81")]
        public string GradeName81 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 81
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 81")]
        public string Qualifiers81 { get; set; }

        ///<summary>
        ///Method of output time series 81
        ///</summary>
        [ApiMember(Description="Method of output time series 81")]
        public string Method81 { get; set; }

        ///<summary>
        ///Approval level of output time series 81
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 81", Format="int64")]
        public long? ApprovalLevel81 { get; set; }

        ///<summary>
        ///Approval name of output time series 81
        ///</summary>
        [ApiMember(Description="Approval name of output time series 81")]
        public string ApprovalName81 { get; set; }

        ///<summary>
        ///Numeric value of output time series 82
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 82", Format="double")]
        public double? NumericValue82 { get; set; }

        ///<summary>
        ///Display value of output time series 82
        ///</summary>
        [ApiMember(Description="Display value of output time series 82")]
        public string DisplayValue82 { get; set; }

        ///<summary>
        ///Grade code of output time series 82
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 82", Format="int64")]
        public long? GradeCode82 { get; set; }

        ///<summary>
        ///Grade name of output time series 82
        ///</summary>
        [ApiMember(Description="Grade name of output time series 82")]
        public string GradeName82 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 82
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 82")]
        public string Qualifiers82 { get; set; }

        ///<summary>
        ///Method of output time series 82
        ///</summary>
        [ApiMember(Description="Method of output time series 82")]
        public string Method82 { get; set; }

        ///<summary>
        ///Approval level of output time series 82
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 82", Format="int64")]
        public long? ApprovalLevel82 { get; set; }

        ///<summary>
        ///Approval name of output time series 82
        ///</summary>
        [ApiMember(Description="Approval name of output time series 82")]
        public string ApprovalName82 { get; set; }

        ///<summary>
        ///Numeric value of output time series 83
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 83", Format="double")]
        public double? NumericValue83 { get; set; }

        ///<summary>
        ///Display value of output time series 83
        ///</summary>
        [ApiMember(Description="Display value of output time series 83")]
        public string DisplayValue83 { get; set; }

        ///<summary>
        ///Grade code of output time series 83
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 83", Format="int64")]
        public long? GradeCode83 { get; set; }

        ///<summary>
        ///Grade name of output time series 83
        ///</summary>
        [ApiMember(Description="Grade name of output time series 83")]
        public string GradeName83 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 83
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 83")]
        public string Qualifiers83 { get; set; }

        ///<summary>
        ///Method of output time series 83
        ///</summary>
        [ApiMember(Description="Method of output time series 83")]
        public string Method83 { get; set; }

        ///<summary>
        ///Approval level of output time series 83
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 83", Format="int64")]
        public long? ApprovalLevel83 { get; set; }

        ///<summary>
        ///Approval name of output time series 83
        ///</summary>
        [ApiMember(Description="Approval name of output time series 83")]
        public string ApprovalName83 { get; set; }

        ///<summary>
        ///Numeric value of output time series 84
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 84", Format="double")]
        public double? NumericValue84 { get; set; }

        ///<summary>
        ///Display value of output time series 84
        ///</summary>
        [ApiMember(Description="Display value of output time series 84")]
        public string DisplayValue84 { get; set; }

        ///<summary>
        ///Grade code of output time series 84
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 84", Format="int64")]
        public long? GradeCode84 { get; set; }

        ///<summary>
        ///Grade name of output time series 84
        ///</summary>
        [ApiMember(Description="Grade name of output time series 84")]
        public string GradeName84 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 84
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 84")]
        public string Qualifiers84 { get; set; }

        ///<summary>
        ///Method of output time series 84
        ///</summary>
        [ApiMember(Description="Method of output time series 84")]
        public string Method84 { get; set; }

        ///<summary>
        ///Approval level of output time series 84
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 84", Format="int64")]
        public long? ApprovalLevel84 { get; set; }

        ///<summary>
        ///Approval name of output time series 84
        ///</summary>
        [ApiMember(Description="Approval name of output time series 84")]
        public string ApprovalName84 { get; set; }

        ///<summary>
        ///Numeric value of output time series 85
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 85", Format="double")]
        public double? NumericValue85 { get; set; }

        ///<summary>
        ///Display value of output time series 85
        ///</summary>
        [ApiMember(Description="Display value of output time series 85")]
        public string DisplayValue85 { get; set; }

        ///<summary>
        ///Grade code of output time series 85
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 85", Format="int64")]
        public long? GradeCode85 { get; set; }

        ///<summary>
        ///Grade name of output time series 85
        ///</summary>
        [ApiMember(Description="Grade name of output time series 85")]
        public string GradeName85 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 85
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 85")]
        public string Qualifiers85 { get; set; }

        ///<summary>
        ///Method of output time series 85
        ///</summary>
        [ApiMember(Description="Method of output time series 85")]
        public string Method85 { get; set; }

        ///<summary>
        ///Approval level of output time series 85
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 85", Format="int64")]
        public long? ApprovalLevel85 { get; set; }

        ///<summary>
        ///Approval name of output time series 85
        ///</summary>
        [ApiMember(Description="Approval name of output time series 85")]
        public string ApprovalName85 { get; set; }

        ///<summary>
        ///Numeric value of output time series 86
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 86", Format="double")]
        public double? NumericValue86 { get; set; }

        ///<summary>
        ///Display value of output time series 86
        ///</summary>
        [ApiMember(Description="Display value of output time series 86")]
        public string DisplayValue86 { get; set; }

        ///<summary>
        ///Grade code of output time series 86
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 86", Format="int64")]
        public long? GradeCode86 { get; set; }

        ///<summary>
        ///Grade name of output time series 86
        ///</summary>
        [ApiMember(Description="Grade name of output time series 86")]
        public string GradeName86 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 86
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 86")]
        public string Qualifiers86 { get; set; }

        ///<summary>
        ///Method of output time series 86
        ///</summary>
        [ApiMember(Description="Method of output time series 86")]
        public string Method86 { get; set; }

        ///<summary>
        ///Approval level of output time series 86
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 86", Format="int64")]
        public long? ApprovalLevel86 { get; set; }

        ///<summary>
        ///Approval name of output time series 86
        ///</summary>
        [ApiMember(Description="Approval name of output time series 86")]
        public string ApprovalName86 { get; set; }

        ///<summary>
        ///Numeric value of output time series 87
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 87", Format="double")]
        public double? NumericValue87 { get; set; }

        ///<summary>
        ///Display value of output time series 87
        ///</summary>
        [ApiMember(Description="Display value of output time series 87")]
        public string DisplayValue87 { get; set; }

        ///<summary>
        ///Grade code of output time series 87
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 87", Format="int64")]
        public long? GradeCode87 { get; set; }

        ///<summary>
        ///Grade name of output time series 87
        ///</summary>
        [ApiMember(Description="Grade name of output time series 87")]
        public string GradeName87 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 87
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 87")]
        public string Qualifiers87 { get; set; }

        ///<summary>
        ///Method of output time series 87
        ///</summary>
        [ApiMember(Description="Method of output time series 87")]
        public string Method87 { get; set; }

        ///<summary>
        ///Approval level of output time series 87
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 87", Format="int64")]
        public long? ApprovalLevel87 { get; set; }

        ///<summary>
        ///Approval name of output time series 87
        ///</summary>
        [ApiMember(Description="Approval name of output time series 87")]
        public string ApprovalName87 { get; set; }

        ///<summary>
        ///Numeric value of output time series 88
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 88", Format="double")]
        public double? NumericValue88 { get; set; }

        ///<summary>
        ///Display value of output time series 88
        ///</summary>
        [ApiMember(Description="Display value of output time series 88")]
        public string DisplayValue88 { get; set; }

        ///<summary>
        ///Grade code of output time series 88
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 88", Format="int64")]
        public long? GradeCode88 { get; set; }

        ///<summary>
        ///Grade name of output time series 88
        ///</summary>
        [ApiMember(Description="Grade name of output time series 88")]
        public string GradeName88 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 88
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 88")]
        public string Qualifiers88 { get; set; }

        ///<summary>
        ///Method of output time series 88
        ///</summary>
        [ApiMember(Description="Method of output time series 88")]
        public string Method88 { get; set; }

        ///<summary>
        ///Approval level of output time series 88
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 88", Format="int64")]
        public long? ApprovalLevel88 { get; set; }

        ///<summary>
        ///Approval name of output time series 88
        ///</summary>
        [ApiMember(Description="Approval name of output time series 88")]
        public string ApprovalName88 { get; set; }

        ///<summary>
        ///Numeric value of output time series 89
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 89", Format="double")]
        public double? NumericValue89 { get; set; }

        ///<summary>
        ///Display value of output time series 89
        ///</summary>
        [ApiMember(Description="Display value of output time series 89")]
        public string DisplayValue89 { get; set; }

        ///<summary>
        ///Grade code of output time series 89
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 89", Format="int64")]
        public long? GradeCode89 { get; set; }

        ///<summary>
        ///Grade name of output time series 89
        ///</summary>
        [ApiMember(Description="Grade name of output time series 89")]
        public string GradeName89 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 89
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 89")]
        public string Qualifiers89 { get; set; }

        ///<summary>
        ///Method of output time series 89
        ///</summary>
        [ApiMember(Description="Method of output time series 89")]
        public string Method89 { get; set; }

        ///<summary>
        ///Approval level of output time series 89
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 89", Format="int64")]
        public long? ApprovalLevel89 { get; set; }

        ///<summary>
        ///Approval name of output time series 89
        ///</summary>
        [ApiMember(Description="Approval name of output time series 89")]
        public string ApprovalName89 { get; set; }

        ///<summary>
        ///Numeric value of output time series 90
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 90", Format="double")]
        public double? NumericValue90 { get; set; }

        ///<summary>
        ///Display value of output time series 90
        ///</summary>
        [ApiMember(Description="Display value of output time series 90")]
        public string DisplayValue90 { get; set; }

        ///<summary>
        ///Grade code of output time series 90
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 90", Format="int64")]
        public long? GradeCode90 { get; set; }

        ///<summary>
        ///Grade name of output time series 90
        ///</summary>
        [ApiMember(Description="Grade name of output time series 90")]
        public string GradeName90 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 90
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 90")]
        public string Qualifiers90 { get; set; }

        ///<summary>
        ///Method of output time series 90
        ///</summary>
        [ApiMember(Description="Method of output time series 90")]
        public string Method90 { get; set; }

        ///<summary>
        ///Approval level of output time series 90
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 90", Format="int64")]
        public long? ApprovalLevel90 { get; set; }

        ///<summary>
        ///Approval name of output time series 90
        ///</summary>
        [ApiMember(Description="Approval name of output time series 90")]
        public string ApprovalName90 { get; set; }

        ///<summary>
        ///Numeric value of output time series 91
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 91", Format="double")]
        public double? NumericValue91 { get; set; }

        ///<summary>
        ///Display value of output time series 91
        ///</summary>
        [ApiMember(Description="Display value of output time series 91")]
        public string DisplayValue91 { get; set; }

        ///<summary>
        ///Grade code of output time series 91
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 91", Format="int64")]
        public long? GradeCode91 { get; set; }

        ///<summary>
        ///Grade name of output time series 91
        ///</summary>
        [ApiMember(Description="Grade name of output time series 91")]
        public string GradeName91 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 91
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 91")]
        public string Qualifiers91 { get; set; }

        ///<summary>
        ///Method of output time series 91
        ///</summary>
        [ApiMember(Description="Method of output time series 91")]
        public string Method91 { get; set; }

        ///<summary>
        ///Approval level of output time series 91
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 91", Format="int64")]
        public long? ApprovalLevel91 { get; set; }

        ///<summary>
        ///Approval name of output time series 91
        ///</summary>
        [ApiMember(Description="Approval name of output time series 91")]
        public string ApprovalName91 { get; set; }

        ///<summary>
        ///Numeric value of output time series 92
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 92", Format="double")]
        public double? NumericValue92 { get; set; }

        ///<summary>
        ///Display value of output time series 92
        ///</summary>
        [ApiMember(Description="Display value of output time series 92")]
        public string DisplayValue92 { get; set; }

        ///<summary>
        ///Grade code of output time series 92
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 92", Format="int64")]
        public long? GradeCode92 { get; set; }

        ///<summary>
        ///Grade name of output time series 92
        ///</summary>
        [ApiMember(Description="Grade name of output time series 92")]
        public string GradeName92 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 92
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 92")]
        public string Qualifiers92 { get; set; }

        ///<summary>
        ///Method of output time series 92
        ///</summary>
        [ApiMember(Description="Method of output time series 92")]
        public string Method92 { get; set; }

        ///<summary>
        ///Approval level of output time series 92
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 92", Format="int64")]
        public long? ApprovalLevel92 { get; set; }

        ///<summary>
        ///Approval name of output time series 92
        ///</summary>
        [ApiMember(Description="Approval name of output time series 92")]
        public string ApprovalName92 { get; set; }

        ///<summary>
        ///Numeric value of output time series 93
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 93", Format="double")]
        public double? NumericValue93 { get; set; }

        ///<summary>
        ///Display value of output time series 93
        ///</summary>
        [ApiMember(Description="Display value of output time series 93")]
        public string DisplayValue93 { get; set; }

        ///<summary>
        ///Grade code of output time series 93
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 93", Format="int64")]
        public long? GradeCode93 { get; set; }

        ///<summary>
        ///Grade name of output time series 93
        ///</summary>
        [ApiMember(Description="Grade name of output time series 93")]
        public string GradeName93 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 93
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 93")]
        public string Qualifiers93 { get; set; }

        ///<summary>
        ///Method of output time series 93
        ///</summary>
        [ApiMember(Description="Method of output time series 93")]
        public string Method93 { get; set; }

        ///<summary>
        ///Approval level of output time series 93
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 93", Format="int64")]
        public long? ApprovalLevel93 { get; set; }

        ///<summary>
        ///Approval name of output time series 93
        ///</summary>
        [ApiMember(Description="Approval name of output time series 93")]
        public string ApprovalName93 { get; set; }

        ///<summary>
        ///Numeric value of output time series 94
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 94", Format="double")]
        public double? NumericValue94 { get; set; }

        ///<summary>
        ///Display value of output time series 94
        ///</summary>
        [ApiMember(Description="Display value of output time series 94")]
        public string DisplayValue94 { get; set; }

        ///<summary>
        ///Grade code of output time series 94
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 94", Format="int64")]
        public long? GradeCode94 { get; set; }

        ///<summary>
        ///Grade name of output time series 94
        ///</summary>
        [ApiMember(Description="Grade name of output time series 94")]
        public string GradeName94 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 94
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 94")]
        public string Qualifiers94 { get; set; }

        ///<summary>
        ///Method of output time series 94
        ///</summary>
        [ApiMember(Description="Method of output time series 94")]
        public string Method94 { get; set; }

        ///<summary>
        ///Approval level of output time series 94
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 94", Format="int64")]
        public long? ApprovalLevel94 { get; set; }

        ///<summary>
        ///Approval name of output time series 94
        ///</summary>
        [ApiMember(Description="Approval name of output time series 94")]
        public string ApprovalName94 { get; set; }

        ///<summary>
        ///Numeric value of output time series 95
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 95", Format="double")]
        public double? NumericValue95 { get; set; }

        ///<summary>
        ///Display value of output time series 95
        ///</summary>
        [ApiMember(Description="Display value of output time series 95")]
        public string DisplayValue95 { get; set; }

        ///<summary>
        ///Grade code of output time series 95
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 95", Format="int64")]
        public long? GradeCode95 { get; set; }

        ///<summary>
        ///Grade name of output time series 95
        ///</summary>
        [ApiMember(Description="Grade name of output time series 95")]
        public string GradeName95 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 95
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 95")]
        public string Qualifiers95 { get; set; }

        ///<summary>
        ///Method of output time series 95
        ///</summary>
        [ApiMember(Description="Method of output time series 95")]
        public string Method95 { get; set; }

        ///<summary>
        ///Approval level of output time series 95
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 95", Format="int64")]
        public long? ApprovalLevel95 { get; set; }

        ///<summary>
        ///Approval name of output time series 95
        ///</summary>
        [ApiMember(Description="Approval name of output time series 95")]
        public string ApprovalName95 { get; set; }

        ///<summary>
        ///Numeric value of output time series 96
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 96", Format="double")]
        public double? NumericValue96 { get; set; }

        ///<summary>
        ///Display value of output time series 96
        ///</summary>
        [ApiMember(Description="Display value of output time series 96")]
        public string DisplayValue96 { get; set; }

        ///<summary>
        ///Grade code of output time series 96
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 96", Format="int64")]
        public long? GradeCode96 { get; set; }

        ///<summary>
        ///Grade name of output time series 96
        ///</summary>
        [ApiMember(Description="Grade name of output time series 96")]
        public string GradeName96 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 96
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 96")]
        public string Qualifiers96 { get; set; }

        ///<summary>
        ///Method of output time series 96
        ///</summary>
        [ApiMember(Description="Method of output time series 96")]
        public string Method96 { get; set; }

        ///<summary>
        ///Approval level of output time series 96
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 96", Format="int64")]
        public long? ApprovalLevel96 { get; set; }

        ///<summary>
        ///Approval name of output time series 96
        ///</summary>
        [ApiMember(Description="Approval name of output time series 96")]
        public string ApprovalName96 { get; set; }

        ///<summary>
        ///Numeric value of output time series 97
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 97", Format="double")]
        public double? NumericValue97 { get; set; }

        ///<summary>
        ///Display value of output time series 97
        ///</summary>
        [ApiMember(Description="Display value of output time series 97")]
        public string DisplayValue97 { get; set; }

        ///<summary>
        ///Grade code of output time series 97
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 97", Format="int64")]
        public long? GradeCode97 { get; set; }

        ///<summary>
        ///Grade name of output time series 97
        ///</summary>
        [ApiMember(Description="Grade name of output time series 97")]
        public string GradeName97 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 97
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 97")]
        public string Qualifiers97 { get; set; }

        ///<summary>
        ///Method of output time series 97
        ///</summary>
        [ApiMember(Description="Method of output time series 97")]
        public string Method97 { get; set; }

        ///<summary>
        ///Approval level of output time series 97
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 97", Format="int64")]
        public long? ApprovalLevel97 { get; set; }

        ///<summary>
        ///Approval name of output time series 97
        ///</summary>
        [ApiMember(Description="Approval name of output time series 97")]
        public string ApprovalName97 { get; set; }

        ///<summary>
        ///Numeric value of output time series 98
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 98", Format="double")]
        public double? NumericValue98 { get; set; }

        ///<summary>
        ///Display value of output time series 98
        ///</summary>
        [ApiMember(Description="Display value of output time series 98")]
        public string DisplayValue98 { get; set; }

        ///<summary>
        ///Grade code of output time series 98
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 98", Format="int64")]
        public long? GradeCode98 { get; set; }

        ///<summary>
        ///Grade name of output time series 98
        ///</summary>
        [ApiMember(Description="Grade name of output time series 98")]
        public string GradeName98 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 98
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 98")]
        public string Qualifiers98 { get; set; }

        ///<summary>
        ///Method of output time series 98
        ///</summary>
        [ApiMember(Description="Method of output time series 98")]
        public string Method98 { get; set; }

        ///<summary>
        ///Approval level of output time series 98
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 98", Format="int64")]
        public long? ApprovalLevel98 { get; set; }

        ///<summary>
        ///Approval name of output time series 98
        ///</summary>
        [ApiMember(Description="Approval name of output time series 98")]
        public string ApprovalName98 { get; set; }

        ///<summary>
        ///Numeric value of output time series 99
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 99", Format="double")]
        public double? NumericValue99 { get; set; }

        ///<summary>
        ///Display value of output time series 99
        ///</summary>
        [ApiMember(Description="Display value of output time series 99")]
        public string DisplayValue99 { get; set; }

        ///<summary>
        ///Grade code of output time series 99
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 99", Format="int64")]
        public long? GradeCode99 { get; set; }

        ///<summary>
        ///Grade name of output time series 99
        ///</summary>
        [ApiMember(Description="Grade name of output time series 99")]
        public string GradeName99 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 99
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 99")]
        public string Qualifiers99 { get; set; }

        ///<summary>
        ///Method of output time series 99
        ///</summary>
        [ApiMember(Description="Method of output time series 99")]
        public string Method99 { get; set; }

        ///<summary>
        ///Approval level of output time series 99
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 99", Format="int64")]
        public long? ApprovalLevel99 { get; set; }

        ///<summary>
        ///Approval name of output time series 99
        ///</summary>
        [ApiMember(Description="Approval name of output time series 99")]
        public string ApprovalName99 { get; set; }

        ///<summary>
        ///Numeric value of output time series 100
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 100", Format="double")]
        public double? NumericValue100 { get; set; }

        ///<summary>
        ///Display value of output time series 100
        ///</summary>
        [ApiMember(Description="Display value of output time series 100")]
        public string DisplayValue100 { get; set; }

        ///<summary>
        ///Grade code of output time series 100
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 100", Format="int64")]
        public long? GradeCode100 { get; set; }

        ///<summary>
        ///Grade name of output time series 100
        ///</summary>
        [ApiMember(Description="Grade name of output time series 100")]
        public string GradeName100 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 100
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 100")]
        public string Qualifiers100 { get; set; }

        ///<summary>
        ///Method of output time series 100
        ///</summary>
        [ApiMember(Description="Method of output time series 100")]
        public string Method100 { get; set; }

        ///<summary>
        ///Approval level of output time series 100
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 100", Format="int64")]
        public long? ApprovalLevel100 { get; set; }

        ///<summary>
        ///Approval name of output time series 100
        ///</summary>
        [ApiMember(Description="Approval name of output time series 100")]
        public string ApprovalName100 { get; set; }

        ///<summary>
        ///Numeric value of output time series 101
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 101", Format="double")]
        public double? NumericValue101 { get; set; }

        ///<summary>
        ///Display value of output time series 101
        ///</summary>
        [ApiMember(Description="Display value of output time series 101")]
        public string DisplayValue101 { get; set; }

        ///<summary>
        ///Grade code of output time series 101
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 101", Format="int64")]
        public long? GradeCode101 { get; set; }

        ///<summary>
        ///Grade name of output time series 101
        ///</summary>
        [ApiMember(Description="Grade name of output time series 101")]
        public string GradeName101 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 101
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 101")]
        public string Qualifiers101 { get; set; }

        ///<summary>
        ///Method of output time series 101
        ///</summary>
        [ApiMember(Description="Method of output time series 101")]
        public string Method101 { get; set; }

        ///<summary>
        ///Approval level of output time series 101
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 101", Format="int64")]
        public long? ApprovalLevel101 { get; set; }

        ///<summary>
        ///Approval name of output time series 101
        ///</summary>
        [ApiMember(Description="Approval name of output time series 101")]
        public string ApprovalName101 { get; set; }

        ///<summary>
        ///Numeric value of output time series 102
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 102", Format="double")]
        public double? NumericValue102 { get; set; }

        ///<summary>
        ///Display value of output time series 102
        ///</summary>
        [ApiMember(Description="Display value of output time series 102")]
        public string DisplayValue102 { get; set; }

        ///<summary>
        ///Grade code of output time series 102
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 102", Format="int64")]
        public long? GradeCode102 { get; set; }

        ///<summary>
        ///Grade name of output time series 102
        ///</summary>
        [ApiMember(Description="Grade name of output time series 102")]
        public string GradeName102 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 102
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 102")]
        public string Qualifiers102 { get; set; }

        ///<summary>
        ///Method of output time series 102
        ///</summary>
        [ApiMember(Description="Method of output time series 102")]
        public string Method102 { get; set; }

        ///<summary>
        ///Approval level of output time series 102
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 102", Format="int64")]
        public long? ApprovalLevel102 { get; set; }

        ///<summary>
        ///Approval name of output time series 102
        ///</summary>
        [ApiMember(Description="Approval name of output time series 102")]
        public string ApprovalName102 { get; set; }

        ///<summary>
        ///Numeric value of output time series 103
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 103", Format="double")]
        public double? NumericValue103 { get; set; }

        ///<summary>
        ///Display value of output time series 103
        ///</summary>
        [ApiMember(Description="Display value of output time series 103")]
        public string DisplayValue103 { get; set; }

        ///<summary>
        ///Grade code of output time series 103
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 103", Format="int64")]
        public long? GradeCode103 { get; set; }

        ///<summary>
        ///Grade name of output time series 103
        ///</summary>
        [ApiMember(Description="Grade name of output time series 103")]
        public string GradeName103 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 103
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 103")]
        public string Qualifiers103 { get; set; }

        ///<summary>
        ///Method of output time series 103
        ///</summary>
        [ApiMember(Description="Method of output time series 103")]
        public string Method103 { get; set; }

        ///<summary>
        ///Approval level of output time series 103
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 103", Format="int64")]
        public long? ApprovalLevel103 { get; set; }

        ///<summary>
        ///Approval name of output time series 103
        ///</summary>
        [ApiMember(Description="Approval name of output time series 103")]
        public string ApprovalName103 { get; set; }

        ///<summary>
        ///Numeric value of output time series 104
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 104", Format="double")]
        public double? NumericValue104 { get; set; }

        ///<summary>
        ///Display value of output time series 104
        ///</summary>
        [ApiMember(Description="Display value of output time series 104")]
        public string DisplayValue104 { get; set; }

        ///<summary>
        ///Grade code of output time series 104
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 104", Format="int64")]
        public long? GradeCode104 { get; set; }

        ///<summary>
        ///Grade name of output time series 104
        ///</summary>
        [ApiMember(Description="Grade name of output time series 104")]
        public string GradeName104 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 104
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 104")]
        public string Qualifiers104 { get; set; }

        ///<summary>
        ///Method of output time series 104
        ///</summary>
        [ApiMember(Description="Method of output time series 104")]
        public string Method104 { get; set; }

        ///<summary>
        ///Approval level of output time series 104
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 104", Format="int64")]
        public long? ApprovalLevel104 { get; set; }

        ///<summary>
        ///Approval name of output time series 104
        ///</summary>
        [ApiMember(Description="Approval name of output time series 104")]
        public string ApprovalName104 { get; set; }

        ///<summary>
        ///Numeric value of output time series 105
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 105", Format="double")]
        public double? NumericValue105 { get; set; }

        ///<summary>
        ///Display value of output time series 105
        ///</summary>
        [ApiMember(Description="Display value of output time series 105")]
        public string DisplayValue105 { get; set; }

        ///<summary>
        ///Grade code of output time series 105
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 105", Format="int64")]
        public long? GradeCode105 { get; set; }

        ///<summary>
        ///Grade name of output time series 105
        ///</summary>
        [ApiMember(Description="Grade name of output time series 105")]
        public string GradeName105 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 105
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 105")]
        public string Qualifiers105 { get; set; }

        ///<summary>
        ///Method of output time series 105
        ///</summary>
        [ApiMember(Description="Method of output time series 105")]
        public string Method105 { get; set; }

        ///<summary>
        ///Approval level of output time series 105
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 105", Format="int64")]
        public long? ApprovalLevel105 { get; set; }

        ///<summary>
        ///Approval name of output time series 105
        ///</summary>
        [ApiMember(Description="Approval name of output time series 105")]
        public string ApprovalName105 { get; set; }

        ///<summary>
        ///Numeric value of output time series 106
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 106", Format="double")]
        public double? NumericValue106 { get; set; }

        ///<summary>
        ///Display value of output time series 106
        ///</summary>
        [ApiMember(Description="Display value of output time series 106")]
        public string DisplayValue106 { get; set; }

        ///<summary>
        ///Grade code of output time series 106
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 106", Format="int64")]
        public long? GradeCode106 { get; set; }

        ///<summary>
        ///Grade name of output time series 106
        ///</summary>
        [ApiMember(Description="Grade name of output time series 106")]
        public string GradeName106 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 106
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 106")]
        public string Qualifiers106 { get; set; }

        ///<summary>
        ///Method of output time series 106
        ///</summary>
        [ApiMember(Description="Method of output time series 106")]
        public string Method106 { get; set; }

        ///<summary>
        ///Approval level of output time series 106
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 106", Format="int64")]
        public long? ApprovalLevel106 { get; set; }

        ///<summary>
        ///Approval name of output time series 106
        ///</summary>
        [ApiMember(Description="Approval name of output time series 106")]
        public string ApprovalName106 { get; set; }

        ///<summary>
        ///Numeric value of output time series 107
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 107", Format="double")]
        public double? NumericValue107 { get; set; }

        ///<summary>
        ///Display value of output time series 107
        ///</summary>
        [ApiMember(Description="Display value of output time series 107")]
        public string DisplayValue107 { get; set; }

        ///<summary>
        ///Grade code of output time series 107
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 107", Format="int64")]
        public long? GradeCode107 { get; set; }

        ///<summary>
        ///Grade name of output time series 107
        ///</summary>
        [ApiMember(Description="Grade name of output time series 107")]
        public string GradeName107 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 107
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 107")]
        public string Qualifiers107 { get; set; }

        ///<summary>
        ///Method of output time series 107
        ///</summary>
        [ApiMember(Description="Method of output time series 107")]
        public string Method107 { get; set; }

        ///<summary>
        ///Approval level of output time series 107
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 107", Format="int64")]
        public long? ApprovalLevel107 { get; set; }

        ///<summary>
        ///Approval name of output time series 107
        ///</summary>
        [ApiMember(Description="Approval name of output time series 107")]
        public string ApprovalName107 { get; set; }

        ///<summary>
        ///Numeric value of output time series 108
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 108", Format="double")]
        public double? NumericValue108 { get; set; }

        ///<summary>
        ///Display value of output time series 108
        ///</summary>
        [ApiMember(Description="Display value of output time series 108")]
        public string DisplayValue108 { get; set; }

        ///<summary>
        ///Grade code of output time series 108
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 108", Format="int64")]
        public long? GradeCode108 { get; set; }

        ///<summary>
        ///Grade name of output time series 108
        ///</summary>
        [ApiMember(Description="Grade name of output time series 108")]
        public string GradeName108 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 108
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 108")]
        public string Qualifiers108 { get; set; }

        ///<summary>
        ///Method of output time series 108
        ///</summary>
        [ApiMember(Description="Method of output time series 108")]
        public string Method108 { get; set; }

        ///<summary>
        ///Approval level of output time series 108
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 108", Format="int64")]
        public long? ApprovalLevel108 { get; set; }

        ///<summary>
        ///Approval name of output time series 108
        ///</summary>
        [ApiMember(Description="Approval name of output time series 108")]
        public string ApprovalName108 { get; set; }

        ///<summary>
        ///Numeric value of output time series 109
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 109", Format="double")]
        public double? NumericValue109 { get; set; }

        ///<summary>
        ///Display value of output time series 109
        ///</summary>
        [ApiMember(Description="Display value of output time series 109")]
        public string DisplayValue109 { get; set; }

        ///<summary>
        ///Grade code of output time series 109
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 109", Format="int64")]
        public long? GradeCode109 { get; set; }

        ///<summary>
        ///Grade name of output time series 109
        ///</summary>
        [ApiMember(Description="Grade name of output time series 109")]
        public string GradeName109 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 109
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 109")]
        public string Qualifiers109 { get; set; }

        ///<summary>
        ///Method of output time series 109
        ///</summary>
        [ApiMember(Description="Method of output time series 109")]
        public string Method109 { get; set; }

        ///<summary>
        ///Approval level of output time series 109
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 109", Format="int64")]
        public long? ApprovalLevel109 { get; set; }

        ///<summary>
        ///Approval name of output time series 109
        ///</summary>
        [ApiMember(Description="Approval name of output time series 109")]
        public string ApprovalName109 { get; set; }

        ///<summary>
        ///Numeric value of output time series 110
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 110", Format="double")]
        public double? NumericValue110 { get; set; }

        ///<summary>
        ///Display value of output time series 110
        ///</summary>
        [ApiMember(Description="Display value of output time series 110")]
        public string DisplayValue110 { get; set; }

        ///<summary>
        ///Grade code of output time series 110
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 110", Format="int64")]
        public long? GradeCode110 { get; set; }

        ///<summary>
        ///Grade name of output time series 110
        ///</summary>
        [ApiMember(Description="Grade name of output time series 110")]
        public string GradeName110 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 110
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 110")]
        public string Qualifiers110 { get; set; }

        ///<summary>
        ///Method of output time series 110
        ///</summary>
        [ApiMember(Description="Method of output time series 110")]
        public string Method110 { get; set; }

        ///<summary>
        ///Approval level of output time series 110
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 110", Format="int64")]
        public long? ApprovalLevel110 { get; set; }

        ///<summary>
        ///Approval name of output time series 110
        ///</summary>
        [ApiMember(Description="Approval name of output time series 110")]
        public string ApprovalName110 { get; set; }

        ///<summary>
        ///Numeric value of output time series 111
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 111", Format="double")]
        public double? NumericValue111 { get; set; }

        ///<summary>
        ///Display value of output time series 111
        ///</summary>
        [ApiMember(Description="Display value of output time series 111")]
        public string DisplayValue111 { get; set; }

        ///<summary>
        ///Grade code of output time series 111
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 111", Format="int64")]
        public long? GradeCode111 { get; set; }

        ///<summary>
        ///Grade name of output time series 111
        ///</summary>
        [ApiMember(Description="Grade name of output time series 111")]
        public string GradeName111 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 111
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 111")]
        public string Qualifiers111 { get; set; }

        ///<summary>
        ///Method of output time series 111
        ///</summary>
        [ApiMember(Description="Method of output time series 111")]
        public string Method111 { get; set; }

        ///<summary>
        ///Approval level of output time series 111
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 111", Format="int64")]
        public long? ApprovalLevel111 { get; set; }

        ///<summary>
        ///Approval name of output time series 111
        ///</summary>
        [ApiMember(Description="Approval name of output time series 111")]
        public string ApprovalName111 { get; set; }

        ///<summary>
        ///Numeric value of output time series 112
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 112", Format="double")]
        public double? NumericValue112 { get; set; }

        ///<summary>
        ///Display value of output time series 112
        ///</summary>
        [ApiMember(Description="Display value of output time series 112")]
        public string DisplayValue112 { get; set; }

        ///<summary>
        ///Grade code of output time series 112
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 112", Format="int64")]
        public long? GradeCode112 { get; set; }

        ///<summary>
        ///Grade name of output time series 112
        ///</summary>
        [ApiMember(Description="Grade name of output time series 112")]
        public string GradeName112 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 112
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 112")]
        public string Qualifiers112 { get; set; }

        ///<summary>
        ///Method of output time series 112
        ///</summary>
        [ApiMember(Description="Method of output time series 112")]
        public string Method112 { get; set; }

        ///<summary>
        ///Approval level of output time series 112
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 112", Format="int64")]
        public long? ApprovalLevel112 { get; set; }

        ///<summary>
        ///Approval name of output time series 112
        ///</summary>
        [ApiMember(Description="Approval name of output time series 112")]
        public string ApprovalName112 { get; set; }

        ///<summary>
        ///Numeric value of output time series 113
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 113", Format="double")]
        public double? NumericValue113 { get; set; }

        ///<summary>
        ///Display value of output time series 113
        ///</summary>
        [ApiMember(Description="Display value of output time series 113")]
        public string DisplayValue113 { get; set; }

        ///<summary>
        ///Grade code of output time series 113
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 113", Format="int64")]
        public long? GradeCode113 { get; set; }

        ///<summary>
        ///Grade name of output time series 113
        ///</summary>
        [ApiMember(Description="Grade name of output time series 113")]
        public string GradeName113 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 113
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 113")]
        public string Qualifiers113 { get; set; }

        ///<summary>
        ///Method of output time series 113
        ///</summary>
        [ApiMember(Description="Method of output time series 113")]
        public string Method113 { get; set; }

        ///<summary>
        ///Approval level of output time series 113
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 113", Format="int64")]
        public long? ApprovalLevel113 { get; set; }

        ///<summary>
        ///Approval name of output time series 113
        ///</summary>
        [ApiMember(Description="Approval name of output time series 113")]
        public string ApprovalName113 { get; set; }

        ///<summary>
        ///Numeric value of output time series 114
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 114", Format="double")]
        public double? NumericValue114 { get; set; }

        ///<summary>
        ///Display value of output time series 114
        ///</summary>
        [ApiMember(Description="Display value of output time series 114")]
        public string DisplayValue114 { get; set; }

        ///<summary>
        ///Grade code of output time series 114
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 114", Format="int64")]
        public long? GradeCode114 { get; set; }

        ///<summary>
        ///Grade name of output time series 114
        ///</summary>
        [ApiMember(Description="Grade name of output time series 114")]
        public string GradeName114 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 114
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 114")]
        public string Qualifiers114 { get; set; }

        ///<summary>
        ///Method of output time series 114
        ///</summary>
        [ApiMember(Description="Method of output time series 114")]
        public string Method114 { get; set; }

        ///<summary>
        ///Approval level of output time series 114
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 114", Format="int64")]
        public long? ApprovalLevel114 { get; set; }

        ///<summary>
        ///Approval name of output time series 114
        ///</summary>
        [ApiMember(Description="Approval name of output time series 114")]
        public string ApprovalName114 { get; set; }

        ///<summary>
        ///Numeric value of output time series 115
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 115", Format="double")]
        public double? NumericValue115 { get; set; }

        ///<summary>
        ///Display value of output time series 115
        ///</summary>
        [ApiMember(Description="Display value of output time series 115")]
        public string DisplayValue115 { get; set; }

        ///<summary>
        ///Grade code of output time series 115
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 115", Format="int64")]
        public long? GradeCode115 { get; set; }

        ///<summary>
        ///Grade name of output time series 115
        ///</summary>
        [ApiMember(Description="Grade name of output time series 115")]
        public string GradeName115 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 115
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 115")]
        public string Qualifiers115 { get; set; }

        ///<summary>
        ///Method of output time series 115
        ///</summary>
        [ApiMember(Description="Method of output time series 115")]
        public string Method115 { get; set; }

        ///<summary>
        ///Approval level of output time series 115
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 115", Format="int64")]
        public long? ApprovalLevel115 { get; set; }

        ///<summary>
        ///Approval name of output time series 115
        ///</summary>
        [ApiMember(Description="Approval name of output time series 115")]
        public string ApprovalName115 { get; set; }

        ///<summary>
        ///Numeric value of output time series 116
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 116", Format="double")]
        public double? NumericValue116 { get; set; }

        ///<summary>
        ///Display value of output time series 116
        ///</summary>
        [ApiMember(Description="Display value of output time series 116")]
        public string DisplayValue116 { get; set; }

        ///<summary>
        ///Grade code of output time series 116
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 116", Format="int64")]
        public long? GradeCode116 { get; set; }

        ///<summary>
        ///Grade name of output time series 116
        ///</summary>
        [ApiMember(Description="Grade name of output time series 116")]
        public string GradeName116 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 116
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 116")]
        public string Qualifiers116 { get; set; }

        ///<summary>
        ///Method of output time series 116
        ///</summary>
        [ApiMember(Description="Method of output time series 116")]
        public string Method116 { get; set; }

        ///<summary>
        ///Approval level of output time series 116
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 116", Format="int64")]
        public long? ApprovalLevel116 { get; set; }

        ///<summary>
        ///Approval name of output time series 116
        ///</summary>
        [ApiMember(Description="Approval name of output time series 116")]
        public string ApprovalName116 { get; set; }

        ///<summary>
        ///Numeric value of output time series 117
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 117", Format="double")]
        public double? NumericValue117 { get; set; }

        ///<summary>
        ///Display value of output time series 117
        ///</summary>
        [ApiMember(Description="Display value of output time series 117")]
        public string DisplayValue117 { get; set; }

        ///<summary>
        ///Grade code of output time series 117
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 117", Format="int64")]
        public long? GradeCode117 { get; set; }

        ///<summary>
        ///Grade name of output time series 117
        ///</summary>
        [ApiMember(Description="Grade name of output time series 117")]
        public string GradeName117 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 117
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 117")]
        public string Qualifiers117 { get; set; }

        ///<summary>
        ///Method of output time series 117
        ///</summary>
        [ApiMember(Description="Method of output time series 117")]
        public string Method117 { get; set; }

        ///<summary>
        ///Approval level of output time series 117
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 117", Format="int64")]
        public long? ApprovalLevel117 { get; set; }

        ///<summary>
        ///Approval name of output time series 117
        ///</summary>
        [ApiMember(Description="Approval name of output time series 117")]
        public string ApprovalName117 { get; set; }

        ///<summary>
        ///Numeric value of output time series 118
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 118", Format="double")]
        public double? NumericValue118 { get; set; }

        ///<summary>
        ///Display value of output time series 118
        ///</summary>
        [ApiMember(Description="Display value of output time series 118")]
        public string DisplayValue118 { get; set; }

        ///<summary>
        ///Grade code of output time series 118
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 118", Format="int64")]
        public long? GradeCode118 { get; set; }

        ///<summary>
        ///Grade name of output time series 118
        ///</summary>
        [ApiMember(Description="Grade name of output time series 118")]
        public string GradeName118 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 118
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 118")]
        public string Qualifiers118 { get; set; }

        ///<summary>
        ///Method of output time series 118
        ///</summary>
        [ApiMember(Description="Method of output time series 118")]
        public string Method118 { get; set; }

        ///<summary>
        ///Approval level of output time series 118
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 118", Format="int64")]
        public long? ApprovalLevel118 { get; set; }

        ///<summary>
        ///Approval name of output time series 118
        ///</summary>
        [ApiMember(Description="Approval name of output time series 118")]
        public string ApprovalName118 { get; set; }

        ///<summary>
        ///Numeric value of output time series 119
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 119", Format="double")]
        public double? NumericValue119 { get; set; }

        ///<summary>
        ///Display value of output time series 119
        ///</summary>
        [ApiMember(Description="Display value of output time series 119")]
        public string DisplayValue119 { get; set; }

        ///<summary>
        ///Grade code of output time series 119
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 119", Format="int64")]
        public long? GradeCode119 { get; set; }

        ///<summary>
        ///Grade name of output time series 119
        ///</summary>
        [ApiMember(Description="Grade name of output time series 119")]
        public string GradeName119 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 119
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 119")]
        public string Qualifiers119 { get; set; }

        ///<summary>
        ///Method of output time series 119
        ///</summary>
        [ApiMember(Description="Method of output time series 119")]
        public string Method119 { get; set; }

        ///<summary>
        ///Approval level of output time series 119
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 119", Format="int64")]
        public long? ApprovalLevel119 { get; set; }

        ///<summary>
        ///Approval name of output time series 119
        ///</summary>
        [ApiMember(Description="Approval name of output time series 119")]
        public string ApprovalName119 { get; set; }

        ///<summary>
        ///Numeric value of output time series 120
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 120", Format="double")]
        public double? NumericValue120 { get; set; }

        ///<summary>
        ///Display value of output time series 120
        ///</summary>
        [ApiMember(Description="Display value of output time series 120")]
        public string DisplayValue120 { get; set; }

        ///<summary>
        ///Grade code of output time series 120
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 120", Format="int64")]
        public long? GradeCode120 { get; set; }

        ///<summary>
        ///Grade name of output time series 120
        ///</summary>
        [ApiMember(Description="Grade name of output time series 120")]
        public string GradeName120 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 120
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 120")]
        public string Qualifiers120 { get; set; }

        ///<summary>
        ///Method of output time series 120
        ///</summary>
        [ApiMember(Description="Method of output time series 120")]
        public string Method120 { get; set; }

        ///<summary>
        ///Approval level of output time series 120
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 120", Format="int64")]
        public long? ApprovalLevel120 { get; set; }

        ///<summary>
        ///Approval name of output time series 120
        ///</summary>
        [ApiMember(Description="Approval name of output time series 120")]
        public string ApprovalName120 { get; set; }

        ///<summary>
        ///Numeric value of output time series 121
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 121", Format="double")]
        public double? NumericValue121 { get; set; }

        ///<summary>
        ///Display value of output time series 121
        ///</summary>
        [ApiMember(Description="Display value of output time series 121")]
        public string DisplayValue121 { get; set; }

        ///<summary>
        ///Grade code of output time series 121
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 121", Format="int64")]
        public long? GradeCode121 { get; set; }

        ///<summary>
        ///Grade name of output time series 121
        ///</summary>
        [ApiMember(Description="Grade name of output time series 121")]
        public string GradeName121 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 121
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 121")]
        public string Qualifiers121 { get; set; }

        ///<summary>
        ///Method of output time series 121
        ///</summary>
        [ApiMember(Description="Method of output time series 121")]
        public string Method121 { get; set; }

        ///<summary>
        ///Approval level of output time series 121
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 121", Format="int64")]
        public long? ApprovalLevel121 { get; set; }

        ///<summary>
        ///Approval name of output time series 121
        ///</summary>
        [ApiMember(Description="Approval name of output time series 121")]
        public string ApprovalName121 { get; set; }

        ///<summary>
        ///Numeric value of output time series 122
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 122", Format="double")]
        public double? NumericValue122 { get; set; }

        ///<summary>
        ///Display value of output time series 122
        ///</summary>
        [ApiMember(Description="Display value of output time series 122")]
        public string DisplayValue122 { get; set; }

        ///<summary>
        ///Grade code of output time series 122
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 122", Format="int64")]
        public long? GradeCode122 { get; set; }

        ///<summary>
        ///Grade name of output time series 122
        ///</summary>
        [ApiMember(Description="Grade name of output time series 122")]
        public string GradeName122 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 122
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 122")]
        public string Qualifiers122 { get; set; }

        ///<summary>
        ///Method of output time series 122
        ///</summary>
        [ApiMember(Description="Method of output time series 122")]
        public string Method122 { get; set; }

        ///<summary>
        ///Approval level of output time series 122
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 122", Format="int64")]
        public long? ApprovalLevel122 { get; set; }

        ///<summary>
        ///Approval name of output time series 122
        ///</summary>
        [ApiMember(Description="Approval name of output time series 122")]
        public string ApprovalName122 { get; set; }

        ///<summary>
        ///Numeric value of output time series 123
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 123", Format="double")]
        public double? NumericValue123 { get; set; }

        ///<summary>
        ///Display value of output time series 123
        ///</summary>
        [ApiMember(Description="Display value of output time series 123")]
        public string DisplayValue123 { get; set; }

        ///<summary>
        ///Grade code of output time series 123
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 123", Format="int64")]
        public long? GradeCode123 { get; set; }

        ///<summary>
        ///Grade name of output time series 123
        ///</summary>
        [ApiMember(Description="Grade name of output time series 123")]
        public string GradeName123 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 123
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 123")]
        public string Qualifiers123 { get; set; }

        ///<summary>
        ///Method of output time series 123
        ///</summary>
        [ApiMember(Description="Method of output time series 123")]
        public string Method123 { get; set; }

        ///<summary>
        ///Approval level of output time series 123
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 123", Format="int64")]
        public long? ApprovalLevel123 { get; set; }

        ///<summary>
        ///Approval name of output time series 123
        ///</summary>
        [ApiMember(Description="Approval name of output time series 123")]
        public string ApprovalName123 { get; set; }

        ///<summary>
        ///Numeric value of output time series 124
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 124", Format="double")]
        public double? NumericValue124 { get; set; }

        ///<summary>
        ///Display value of output time series 124
        ///</summary>
        [ApiMember(Description="Display value of output time series 124")]
        public string DisplayValue124 { get; set; }

        ///<summary>
        ///Grade code of output time series 124
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 124", Format="int64")]
        public long? GradeCode124 { get; set; }

        ///<summary>
        ///Grade name of output time series 124
        ///</summary>
        [ApiMember(Description="Grade name of output time series 124")]
        public string GradeName124 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 124
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 124")]
        public string Qualifiers124 { get; set; }

        ///<summary>
        ///Method of output time series 124
        ///</summary>
        [ApiMember(Description="Method of output time series 124")]
        public string Method124 { get; set; }

        ///<summary>
        ///Approval level of output time series 124
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 124", Format="int64")]
        public long? ApprovalLevel124 { get; set; }

        ///<summary>
        ///Approval name of output time series 124
        ///</summary>
        [ApiMember(Description="Approval name of output time series 124")]
        public string ApprovalName124 { get; set; }

        ///<summary>
        ///Numeric value of output time series 125
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 125", Format="double")]
        public double? NumericValue125 { get; set; }

        ///<summary>
        ///Display value of output time series 125
        ///</summary>
        [ApiMember(Description="Display value of output time series 125")]
        public string DisplayValue125 { get; set; }

        ///<summary>
        ///Grade code of output time series 125
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 125", Format="int64")]
        public long? GradeCode125 { get; set; }

        ///<summary>
        ///Grade name of output time series 125
        ///</summary>
        [ApiMember(Description="Grade name of output time series 125")]
        public string GradeName125 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 125
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 125")]
        public string Qualifiers125 { get; set; }

        ///<summary>
        ///Method of output time series 125
        ///</summary>
        [ApiMember(Description="Method of output time series 125")]
        public string Method125 { get; set; }

        ///<summary>
        ///Approval level of output time series 125
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 125", Format="int64")]
        public long? ApprovalLevel125 { get; set; }

        ///<summary>
        ///Approval name of output time series 125
        ///</summary>
        [ApiMember(Description="Approval name of output time series 125")]
        public string ApprovalName125 { get; set; }

        ///<summary>
        ///Numeric value of output time series 126
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 126", Format="double")]
        public double? NumericValue126 { get; set; }

        ///<summary>
        ///Display value of output time series 126
        ///</summary>
        [ApiMember(Description="Display value of output time series 126")]
        public string DisplayValue126 { get; set; }

        ///<summary>
        ///Grade code of output time series 126
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 126", Format="int64")]
        public long? GradeCode126 { get; set; }

        ///<summary>
        ///Grade name of output time series 126
        ///</summary>
        [ApiMember(Description="Grade name of output time series 126")]
        public string GradeName126 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 126
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 126")]
        public string Qualifiers126 { get; set; }

        ///<summary>
        ///Method of output time series 126
        ///</summary>
        [ApiMember(Description="Method of output time series 126")]
        public string Method126 { get; set; }

        ///<summary>
        ///Approval level of output time series 126
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 126", Format="int64")]
        public long? ApprovalLevel126 { get; set; }

        ///<summary>
        ///Approval name of output time series 126
        ///</summary>
        [ApiMember(Description="Approval name of output time series 126")]
        public string ApprovalName126 { get; set; }

        ///<summary>
        ///Numeric value of output time series 127
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 127", Format="double")]
        public double? NumericValue127 { get; set; }

        ///<summary>
        ///Display value of output time series 127
        ///</summary>
        [ApiMember(Description="Display value of output time series 127")]
        public string DisplayValue127 { get; set; }

        ///<summary>
        ///Grade code of output time series 127
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 127", Format="int64")]
        public long? GradeCode127 { get; set; }

        ///<summary>
        ///Grade name of output time series 127
        ///</summary>
        [ApiMember(Description="Grade name of output time series 127")]
        public string GradeName127 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 127
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 127")]
        public string Qualifiers127 { get; set; }

        ///<summary>
        ///Method of output time series 127
        ///</summary>
        [ApiMember(Description="Method of output time series 127")]
        public string Method127 { get; set; }

        ///<summary>
        ///Approval level of output time series 127
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 127", Format="int64")]
        public long? ApprovalLevel127 { get; set; }

        ///<summary>
        ///Approval name of output time series 127
        ///</summary>
        [ApiMember(Description="Approval name of output time series 127")]
        public string ApprovalName127 { get; set; }

        ///<summary>
        ///Numeric value of output time series 128
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 128", Format="double")]
        public double? NumericValue128 { get; set; }

        ///<summary>
        ///Display value of output time series 128
        ///</summary>
        [ApiMember(Description="Display value of output time series 128")]
        public string DisplayValue128 { get; set; }

        ///<summary>
        ///Grade code of output time series 128
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 128", Format="int64")]
        public long? GradeCode128 { get; set; }

        ///<summary>
        ///Grade name of output time series 128
        ///</summary>
        [ApiMember(Description="Grade name of output time series 128")]
        public string GradeName128 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 128
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 128")]
        public string Qualifiers128 { get; set; }

        ///<summary>
        ///Method of output time series 128
        ///</summary>
        [ApiMember(Description="Method of output time series 128")]
        public string Method128 { get; set; }

        ///<summary>
        ///Approval level of output time series 128
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 128", Format="int64")]
        public long? ApprovalLevel128 { get; set; }

        ///<summary>
        ///Approval name of output time series 128
        ///</summary>
        [ApiMember(Description="Approval name of output time series 128")]
        public string ApprovalName128 { get; set; }

        ///<summary>
        ///Numeric value of output time series 129
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 129", Format="double")]
        public double? NumericValue129 { get; set; }

        ///<summary>
        ///Display value of output time series 129
        ///</summary>
        [ApiMember(Description="Display value of output time series 129")]
        public string DisplayValue129 { get; set; }

        ///<summary>
        ///Grade code of output time series 129
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 129", Format="int64")]
        public long? GradeCode129 { get; set; }

        ///<summary>
        ///Grade name of output time series 129
        ///</summary>
        [ApiMember(Description="Grade name of output time series 129")]
        public string GradeName129 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 129
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 129")]
        public string Qualifiers129 { get; set; }

        ///<summary>
        ///Method of output time series 129
        ///</summary>
        [ApiMember(Description="Method of output time series 129")]
        public string Method129 { get; set; }

        ///<summary>
        ///Approval level of output time series 129
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 129", Format="int64")]
        public long? ApprovalLevel129 { get; set; }

        ///<summary>
        ///Approval name of output time series 129
        ///</summary>
        [ApiMember(Description="Approval name of output time series 129")]
        public string ApprovalName129 { get; set; }

        ///<summary>
        ///Numeric value of output time series 130
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 130", Format="double")]
        public double? NumericValue130 { get; set; }

        ///<summary>
        ///Display value of output time series 130
        ///</summary>
        [ApiMember(Description="Display value of output time series 130")]
        public string DisplayValue130 { get; set; }

        ///<summary>
        ///Grade code of output time series 130
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 130", Format="int64")]
        public long? GradeCode130 { get; set; }

        ///<summary>
        ///Grade name of output time series 130
        ///</summary>
        [ApiMember(Description="Grade name of output time series 130")]
        public string GradeName130 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 130
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 130")]
        public string Qualifiers130 { get; set; }

        ///<summary>
        ///Method of output time series 130
        ///</summary>
        [ApiMember(Description="Method of output time series 130")]
        public string Method130 { get; set; }

        ///<summary>
        ///Approval level of output time series 130
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 130", Format="int64")]
        public long? ApprovalLevel130 { get; set; }

        ///<summary>
        ///Approval name of output time series 130
        ///</summary>
        [ApiMember(Description="Approval name of output time series 130")]
        public string ApprovalName130 { get; set; }

        ///<summary>
        ///Numeric value of output time series 131
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 131", Format="double")]
        public double? NumericValue131 { get; set; }

        ///<summary>
        ///Display value of output time series 131
        ///</summary>
        [ApiMember(Description="Display value of output time series 131")]
        public string DisplayValue131 { get; set; }

        ///<summary>
        ///Grade code of output time series 131
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 131", Format="int64")]
        public long? GradeCode131 { get; set; }

        ///<summary>
        ///Grade name of output time series 131
        ///</summary>
        [ApiMember(Description="Grade name of output time series 131")]
        public string GradeName131 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 131
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 131")]
        public string Qualifiers131 { get; set; }

        ///<summary>
        ///Method of output time series 131
        ///</summary>
        [ApiMember(Description="Method of output time series 131")]
        public string Method131 { get; set; }

        ///<summary>
        ///Approval level of output time series 131
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 131", Format="int64")]
        public long? ApprovalLevel131 { get; set; }

        ///<summary>
        ///Approval name of output time series 131
        ///</summary>
        [ApiMember(Description="Approval name of output time series 131")]
        public string ApprovalName131 { get; set; }

        ///<summary>
        ///Numeric value of output time series 132
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 132", Format="double")]
        public double? NumericValue132 { get; set; }

        ///<summary>
        ///Display value of output time series 132
        ///</summary>
        [ApiMember(Description="Display value of output time series 132")]
        public string DisplayValue132 { get; set; }

        ///<summary>
        ///Grade code of output time series 132
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 132", Format="int64")]
        public long? GradeCode132 { get; set; }

        ///<summary>
        ///Grade name of output time series 132
        ///</summary>
        [ApiMember(Description="Grade name of output time series 132")]
        public string GradeName132 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 132
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 132")]
        public string Qualifiers132 { get; set; }

        ///<summary>
        ///Method of output time series 132
        ///</summary>
        [ApiMember(Description="Method of output time series 132")]
        public string Method132 { get; set; }

        ///<summary>
        ///Approval level of output time series 132
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 132", Format="int64")]
        public long? ApprovalLevel132 { get; set; }

        ///<summary>
        ///Approval name of output time series 132
        ///</summary>
        [ApiMember(Description="Approval name of output time series 132")]
        public string ApprovalName132 { get; set; }

        ///<summary>
        ///Numeric value of output time series 133
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 133", Format="double")]
        public double? NumericValue133 { get; set; }

        ///<summary>
        ///Display value of output time series 133
        ///</summary>
        [ApiMember(Description="Display value of output time series 133")]
        public string DisplayValue133 { get; set; }

        ///<summary>
        ///Grade code of output time series 133
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 133", Format="int64")]
        public long? GradeCode133 { get; set; }

        ///<summary>
        ///Grade name of output time series 133
        ///</summary>
        [ApiMember(Description="Grade name of output time series 133")]
        public string GradeName133 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 133
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 133")]
        public string Qualifiers133 { get; set; }

        ///<summary>
        ///Method of output time series 133
        ///</summary>
        [ApiMember(Description="Method of output time series 133")]
        public string Method133 { get; set; }

        ///<summary>
        ///Approval level of output time series 133
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 133", Format="int64")]
        public long? ApprovalLevel133 { get; set; }

        ///<summary>
        ///Approval name of output time series 133
        ///</summary>
        [ApiMember(Description="Approval name of output time series 133")]
        public string ApprovalName133 { get; set; }

        ///<summary>
        ///Numeric value of output time series 134
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 134", Format="double")]
        public double? NumericValue134 { get; set; }

        ///<summary>
        ///Display value of output time series 134
        ///</summary>
        [ApiMember(Description="Display value of output time series 134")]
        public string DisplayValue134 { get; set; }

        ///<summary>
        ///Grade code of output time series 134
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 134", Format="int64")]
        public long? GradeCode134 { get; set; }

        ///<summary>
        ///Grade name of output time series 134
        ///</summary>
        [ApiMember(Description="Grade name of output time series 134")]
        public string GradeName134 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 134
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 134")]
        public string Qualifiers134 { get; set; }

        ///<summary>
        ///Method of output time series 134
        ///</summary>
        [ApiMember(Description="Method of output time series 134")]
        public string Method134 { get; set; }

        ///<summary>
        ///Approval level of output time series 134
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 134", Format="int64")]
        public long? ApprovalLevel134 { get; set; }

        ///<summary>
        ///Approval name of output time series 134
        ///</summary>
        [ApiMember(Description="Approval name of output time series 134")]
        public string ApprovalName134 { get; set; }

        ///<summary>
        ///Numeric value of output time series 135
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 135", Format="double")]
        public double? NumericValue135 { get; set; }

        ///<summary>
        ///Display value of output time series 135
        ///</summary>
        [ApiMember(Description="Display value of output time series 135")]
        public string DisplayValue135 { get; set; }

        ///<summary>
        ///Grade code of output time series 135
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 135", Format="int64")]
        public long? GradeCode135 { get; set; }

        ///<summary>
        ///Grade name of output time series 135
        ///</summary>
        [ApiMember(Description="Grade name of output time series 135")]
        public string GradeName135 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 135
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 135")]
        public string Qualifiers135 { get; set; }

        ///<summary>
        ///Method of output time series 135
        ///</summary>
        [ApiMember(Description="Method of output time series 135")]
        public string Method135 { get; set; }

        ///<summary>
        ///Approval level of output time series 135
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 135", Format="int64")]
        public long? ApprovalLevel135 { get; set; }

        ///<summary>
        ///Approval name of output time series 135
        ///</summary>
        [ApiMember(Description="Approval name of output time series 135")]
        public string ApprovalName135 { get; set; }

        ///<summary>
        ///Numeric value of output time series 136
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 136", Format="double")]
        public double? NumericValue136 { get; set; }

        ///<summary>
        ///Display value of output time series 136
        ///</summary>
        [ApiMember(Description="Display value of output time series 136")]
        public string DisplayValue136 { get; set; }

        ///<summary>
        ///Grade code of output time series 136
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 136", Format="int64")]
        public long? GradeCode136 { get; set; }

        ///<summary>
        ///Grade name of output time series 136
        ///</summary>
        [ApiMember(Description="Grade name of output time series 136")]
        public string GradeName136 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 136
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 136")]
        public string Qualifiers136 { get; set; }

        ///<summary>
        ///Method of output time series 136
        ///</summary>
        [ApiMember(Description="Method of output time series 136")]
        public string Method136 { get; set; }

        ///<summary>
        ///Approval level of output time series 136
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 136", Format="int64")]
        public long? ApprovalLevel136 { get; set; }

        ///<summary>
        ///Approval name of output time series 136
        ///</summary>
        [ApiMember(Description="Approval name of output time series 136")]
        public string ApprovalName136 { get; set; }

        ///<summary>
        ///Numeric value of output time series 137
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 137", Format="double")]
        public double? NumericValue137 { get; set; }

        ///<summary>
        ///Display value of output time series 137
        ///</summary>
        [ApiMember(Description="Display value of output time series 137")]
        public string DisplayValue137 { get; set; }

        ///<summary>
        ///Grade code of output time series 137
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 137", Format="int64")]
        public long? GradeCode137 { get; set; }

        ///<summary>
        ///Grade name of output time series 137
        ///</summary>
        [ApiMember(Description="Grade name of output time series 137")]
        public string GradeName137 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 137
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 137")]
        public string Qualifiers137 { get; set; }

        ///<summary>
        ///Method of output time series 137
        ///</summary>
        [ApiMember(Description="Method of output time series 137")]
        public string Method137 { get; set; }

        ///<summary>
        ///Approval level of output time series 137
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 137", Format="int64")]
        public long? ApprovalLevel137 { get; set; }

        ///<summary>
        ///Approval name of output time series 137
        ///</summary>
        [ApiMember(Description="Approval name of output time series 137")]
        public string ApprovalName137 { get; set; }

        ///<summary>
        ///Numeric value of output time series 138
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 138", Format="double")]
        public double? NumericValue138 { get; set; }

        ///<summary>
        ///Display value of output time series 138
        ///</summary>
        [ApiMember(Description="Display value of output time series 138")]
        public string DisplayValue138 { get; set; }

        ///<summary>
        ///Grade code of output time series 138
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 138", Format="int64")]
        public long? GradeCode138 { get; set; }

        ///<summary>
        ///Grade name of output time series 138
        ///</summary>
        [ApiMember(Description="Grade name of output time series 138")]
        public string GradeName138 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 138
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 138")]
        public string Qualifiers138 { get; set; }

        ///<summary>
        ///Method of output time series 138
        ///</summary>
        [ApiMember(Description="Method of output time series 138")]
        public string Method138 { get; set; }

        ///<summary>
        ///Approval level of output time series 138
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 138", Format="int64")]
        public long? ApprovalLevel138 { get; set; }

        ///<summary>
        ///Approval name of output time series 138
        ///</summary>
        [ApiMember(Description="Approval name of output time series 138")]
        public string ApprovalName138 { get; set; }

        ///<summary>
        ///Numeric value of output time series 139
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 139", Format="double")]
        public double? NumericValue139 { get; set; }

        ///<summary>
        ///Display value of output time series 139
        ///</summary>
        [ApiMember(Description="Display value of output time series 139")]
        public string DisplayValue139 { get; set; }

        ///<summary>
        ///Grade code of output time series 139
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 139", Format="int64")]
        public long? GradeCode139 { get; set; }

        ///<summary>
        ///Grade name of output time series 139
        ///</summary>
        [ApiMember(Description="Grade name of output time series 139")]
        public string GradeName139 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 139
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 139")]
        public string Qualifiers139 { get; set; }

        ///<summary>
        ///Method of output time series 139
        ///</summary>
        [ApiMember(Description="Method of output time series 139")]
        public string Method139 { get; set; }

        ///<summary>
        ///Approval level of output time series 139
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 139", Format="int64")]
        public long? ApprovalLevel139 { get; set; }

        ///<summary>
        ///Approval name of output time series 139
        ///</summary>
        [ApiMember(Description="Approval name of output time series 139")]
        public string ApprovalName139 { get; set; }

        ///<summary>
        ///Numeric value of output time series 140
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 140", Format="double")]
        public double? NumericValue140 { get; set; }

        ///<summary>
        ///Display value of output time series 140
        ///</summary>
        [ApiMember(Description="Display value of output time series 140")]
        public string DisplayValue140 { get; set; }

        ///<summary>
        ///Grade code of output time series 140
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 140", Format="int64")]
        public long? GradeCode140 { get; set; }

        ///<summary>
        ///Grade name of output time series 140
        ///</summary>
        [ApiMember(Description="Grade name of output time series 140")]
        public string GradeName140 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 140
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 140")]
        public string Qualifiers140 { get; set; }

        ///<summary>
        ///Method of output time series 140
        ///</summary>
        [ApiMember(Description="Method of output time series 140")]
        public string Method140 { get; set; }

        ///<summary>
        ///Approval level of output time series 140
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 140", Format="int64")]
        public long? ApprovalLevel140 { get; set; }

        ///<summary>
        ///Approval name of output time series 140
        ///</summary>
        [ApiMember(Description="Approval name of output time series 140")]
        public string ApprovalName140 { get; set; }

        ///<summary>
        ///Numeric value of output time series 141
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 141", Format="double")]
        public double? NumericValue141 { get; set; }

        ///<summary>
        ///Display value of output time series 141
        ///</summary>
        [ApiMember(Description="Display value of output time series 141")]
        public string DisplayValue141 { get; set; }

        ///<summary>
        ///Grade code of output time series 141
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 141", Format="int64")]
        public long? GradeCode141 { get; set; }

        ///<summary>
        ///Grade name of output time series 141
        ///</summary>
        [ApiMember(Description="Grade name of output time series 141")]
        public string GradeName141 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 141
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 141")]
        public string Qualifiers141 { get; set; }

        ///<summary>
        ///Method of output time series 141
        ///</summary>
        [ApiMember(Description="Method of output time series 141")]
        public string Method141 { get; set; }

        ///<summary>
        ///Approval level of output time series 141
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 141", Format="int64")]
        public long? ApprovalLevel141 { get; set; }

        ///<summary>
        ///Approval name of output time series 141
        ///</summary>
        [ApiMember(Description="Approval name of output time series 141")]
        public string ApprovalName141 { get; set; }

        ///<summary>
        ///Numeric value of output time series 142
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 142", Format="double")]
        public double? NumericValue142 { get; set; }

        ///<summary>
        ///Display value of output time series 142
        ///</summary>
        [ApiMember(Description="Display value of output time series 142")]
        public string DisplayValue142 { get; set; }

        ///<summary>
        ///Grade code of output time series 142
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 142", Format="int64")]
        public long? GradeCode142 { get; set; }

        ///<summary>
        ///Grade name of output time series 142
        ///</summary>
        [ApiMember(Description="Grade name of output time series 142")]
        public string GradeName142 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 142
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 142")]
        public string Qualifiers142 { get; set; }

        ///<summary>
        ///Method of output time series 142
        ///</summary>
        [ApiMember(Description="Method of output time series 142")]
        public string Method142 { get; set; }

        ///<summary>
        ///Approval level of output time series 142
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 142", Format="int64")]
        public long? ApprovalLevel142 { get; set; }

        ///<summary>
        ///Approval name of output time series 142
        ///</summary>
        [ApiMember(Description="Approval name of output time series 142")]
        public string ApprovalName142 { get; set; }

        ///<summary>
        ///Numeric value of output time series 143
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 143", Format="double")]
        public double? NumericValue143 { get; set; }

        ///<summary>
        ///Display value of output time series 143
        ///</summary>
        [ApiMember(Description="Display value of output time series 143")]
        public string DisplayValue143 { get; set; }

        ///<summary>
        ///Grade code of output time series 143
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 143", Format="int64")]
        public long? GradeCode143 { get; set; }

        ///<summary>
        ///Grade name of output time series 143
        ///</summary>
        [ApiMember(Description="Grade name of output time series 143")]
        public string GradeName143 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 143
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 143")]
        public string Qualifiers143 { get; set; }

        ///<summary>
        ///Method of output time series 143
        ///</summary>
        [ApiMember(Description="Method of output time series 143")]
        public string Method143 { get; set; }

        ///<summary>
        ///Approval level of output time series 143
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 143", Format="int64")]
        public long? ApprovalLevel143 { get; set; }

        ///<summary>
        ///Approval name of output time series 143
        ///</summary>
        [ApiMember(Description="Approval name of output time series 143")]
        public string ApprovalName143 { get; set; }

        ///<summary>
        ///Numeric value of output time series 144
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 144", Format="double")]
        public double? NumericValue144 { get; set; }

        ///<summary>
        ///Display value of output time series 144
        ///</summary>
        [ApiMember(Description="Display value of output time series 144")]
        public string DisplayValue144 { get; set; }

        ///<summary>
        ///Grade code of output time series 144
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 144", Format="int64")]
        public long? GradeCode144 { get; set; }

        ///<summary>
        ///Grade name of output time series 144
        ///</summary>
        [ApiMember(Description="Grade name of output time series 144")]
        public string GradeName144 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 144
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 144")]
        public string Qualifiers144 { get; set; }

        ///<summary>
        ///Method of output time series 144
        ///</summary>
        [ApiMember(Description="Method of output time series 144")]
        public string Method144 { get; set; }

        ///<summary>
        ///Approval level of output time series 144
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 144", Format="int64")]
        public long? ApprovalLevel144 { get; set; }

        ///<summary>
        ///Approval name of output time series 144
        ///</summary>
        [ApiMember(Description="Approval name of output time series 144")]
        public string ApprovalName144 { get; set; }

        ///<summary>
        ///Numeric value of output time series 145
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 145", Format="double")]
        public double? NumericValue145 { get; set; }

        ///<summary>
        ///Display value of output time series 145
        ///</summary>
        [ApiMember(Description="Display value of output time series 145")]
        public string DisplayValue145 { get; set; }

        ///<summary>
        ///Grade code of output time series 145
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 145", Format="int64")]
        public long? GradeCode145 { get; set; }

        ///<summary>
        ///Grade name of output time series 145
        ///</summary>
        [ApiMember(Description="Grade name of output time series 145")]
        public string GradeName145 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 145
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 145")]
        public string Qualifiers145 { get; set; }

        ///<summary>
        ///Method of output time series 145
        ///</summary>
        [ApiMember(Description="Method of output time series 145")]
        public string Method145 { get; set; }

        ///<summary>
        ///Approval level of output time series 145
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 145", Format="int64")]
        public long? ApprovalLevel145 { get; set; }

        ///<summary>
        ///Approval name of output time series 145
        ///</summary>
        [ApiMember(Description="Approval name of output time series 145")]
        public string ApprovalName145 { get; set; }

        ///<summary>
        ///Numeric value of output time series 146
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 146", Format="double")]
        public double? NumericValue146 { get; set; }

        ///<summary>
        ///Display value of output time series 146
        ///</summary>
        [ApiMember(Description="Display value of output time series 146")]
        public string DisplayValue146 { get; set; }

        ///<summary>
        ///Grade code of output time series 146
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 146", Format="int64")]
        public long? GradeCode146 { get; set; }

        ///<summary>
        ///Grade name of output time series 146
        ///</summary>
        [ApiMember(Description="Grade name of output time series 146")]
        public string GradeName146 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 146
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 146")]
        public string Qualifiers146 { get; set; }

        ///<summary>
        ///Method of output time series 146
        ///</summary>
        [ApiMember(Description="Method of output time series 146")]
        public string Method146 { get; set; }

        ///<summary>
        ///Approval level of output time series 146
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 146", Format="int64")]
        public long? ApprovalLevel146 { get; set; }

        ///<summary>
        ///Approval name of output time series 146
        ///</summary>
        [ApiMember(Description="Approval name of output time series 146")]
        public string ApprovalName146 { get; set; }

        ///<summary>
        ///Numeric value of output time series 147
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 147", Format="double")]
        public double? NumericValue147 { get; set; }

        ///<summary>
        ///Display value of output time series 147
        ///</summary>
        [ApiMember(Description="Display value of output time series 147")]
        public string DisplayValue147 { get; set; }

        ///<summary>
        ///Grade code of output time series 147
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 147", Format="int64")]
        public long? GradeCode147 { get; set; }

        ///<summary>
        ///Grade name of output time series 147
        ///</summary>
        [ApiMember(Description="Grade name of output time series 147")]
        public string GradeName147 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 147
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 147")]
        public string Qualifiers147 { get; set; }

        ///<summary>
        ///Method of output time series 147
        ///</summary>
        [ApiMember(Description="Method of output time series 147")]
        public string Method147 { get; set; }

        ///<summary>
        ///Approval level of output time series 147
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 147", Format="int64")]
        public long? ApprovalLevel147 { get; set; }

        ///<summary>
        ///Approval name of output time series 147
        ///</summary>
        [ApiMember(Description="Approval name of output time series 147")]
        public string ApprovalName147 { get; set; }

        ///<summary>
        ///Numeric value of output time series 148
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 148", Format="double")]
        public double? NumericValue148 { get; set; }

        ///<summary>
        ///Display value of output time series 148
        ///</summary>
        [ApiMember(Description="Display value of output time series 148")]
        public string DisplayValue148 { get; set; }

        ///<summary>
        ///Grade code of output time series 148
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 148", Format="int64")]
        public long? GradeCode148 { get; set; }

        ///<summary>
        ///Grade name of output time series 148
        ///</summary>
        [ApiMember(Description="Grade name of output time series 148")]
        public string GradeName148 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 148
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 148")]
        public string Qualifiers148 { get; set; }

        ///<summary>
        ///Method of output time series 148
        ///</summary>
        [ApiMember(Description="Method of output time series 148")]
        public string Method148 { get; set; }

        ///<summary>
        ///Approval level of output time series 148
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 148", Format="int64")]
        public long? ApprovalLevel148 { get; set; }

        ///<summary>
        ///Approval name of output time series 148
        ///</summary>
        [ApiMember(Description="Approval name of output time series 148")]
        public string ApprovalName148 { get; set; }

        ///<summary>
        ///Numeric value of output time series 149
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 149", Format="double")]
        public double? NumericValue149 { get; set; }

        ///<summary>
        ///Display value of output time series 149
        ///</summary>
        [ApiMember(Description="Display value of output time series 149")]
        public string DisplayValue149 { get; set; }

        ///<summary>
        ///Grade code of output time series 149
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 149", Format="int64")]
        public long? GradeCode149 { get; set; }

        ///<summary>
        ///Grade name of output time series 149
        ///</summary>
        [ApiMember(Description="Grade name of output time series 149")]
        public string GradeName149 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 149
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 149")]
        public string Qualifiers149 { get; set; }

        ///<summary>
        ///Method of output time series 149
        ///</summary>
        [ApiMember(Description="Method of output time series 149")]
        public string Method149 { get; set; }

        ///<summary>
        ///Approval level of output time series 149
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 149", Format="int64")]
        public long? ApprovalLevel149 { get; set; }

        ///<summary>
        ///Approval name of output time series 149
        ///</summary>
        [ApiMember(Description="Approval name of output time series 149")]
        public string ApprovalName149 { get; set; }

        ///<summary>
        ///Numeric value of output time series 150
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 150", Format="double")]
        public double? NumericValue150 { get; set; }

        ///<summary>
        ///Display value of output time series 150
        ///</summary>
        [ApiMember(Description="Display value of output time series 150")]
        public string DisplayValue150 { get; set; }

        ///<summary>
        ///Grade code of output time series 150
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 150", Format="int64")]
        public long? GradeCode150 { get; set; }

        ///<summary>
        ///Grade name of output time series 150
        ///</summary>
        [ApiMember(Description="Grade name of output time series 150")]
        public string GradeName150 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 150
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 150")]
        public string Qualifiers150 { get; set; }

        ///<summary>
        ///Method of output time series 150
        ///</summary>
        [ApiMember(Description="Method of output time series 150")]
        public string Method150 { get; set; }

        ///<summary>
        ///Approval level of output time series 150
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 150", Format="int64")]
        public long? ApprovalLevel150 { get; set; }

        ///<summary>
        ///Approval name of output time series 150
        ///</summary>
        [ApiMember(Description="Approval name of output time series 150")]
        public string ApprovalName150 { get; set; }

        ///<summary>
        ///Numeric value of output time series 151
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 151", Format="double")]
        public double? NumericValue151 { get; set; }

        ///<summary>
        ///Display value of output time series 151
        ///</summary>
        [ApiMember(Description="Display value of output time series 151")]
        public string DisplayValue151 { get; set; }

        ///<summary>
        ///Grade code of output time series 151
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 151", Format="int64")]
        public long? GradeCode151 { get; set; }

        ///<summary>
        ///Grade name of output time series 151
        ///</summary>
        [ApiMember(Description="Grade name of output time series 151")]
        public string GradeName151 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 151
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 151")]
        public string Qualifiers151 { get; set; }

        ///<summary>
        ///Method of output time series 151
        ///</summary>
        [ApiMember(Description="Method of output time series 151")]
        public string Method151 { get; set; }

        ///<summary>
        ///Approval level of output time series 151
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 151", Format="int64")]
        public long? ApprovalLevel151 { get; set; }

        ///<summary>
        ///Approval name of output time series 151
        ///</summary>
        [ApiMember(Description="Approval name of output time series 151")]
        public string ApprovalName151 { get; set; }

        ///<summary>
        ///Numeric value of output time series 152
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 152", Format="double")]
        public double? NumericValue152 { get; set; }

        ///<summary>
        ///Display value of output time series 152
        ///</summary>
        [ApiMember(Description="Display value of output time series 152")]
        public string DisplayValue152 { get; set; }

        ///<summary>
        ///Grade code of output time series 152
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 152", Format="int64")]
        public long? GradeCode152 { get; set; }

        ///<summary>
        ///Grade name of output time series 152
        ///</summary>
        [ApiMember(Description="Grade name of output time series 152")]
        public string GradeName152 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 152
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 152")]
        public string Qualifiers152 { get; set; }

        ///<summary>
        ///Method of output time series 152
        ///</summary>
        [ApiMember(Description="Method of output time series 152")]
        public string Method152 { get; set; }

        ///<summary>
        ///Approval level of output time series 152
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 152", Format="int64")]
        public long? ApprovalLevel152 { get; set; }

        ///<summary>
        ///Approval name of output time series 152
        ///</summary>
        [ApiMember(Description="Approval name of output time series 152")]
        public string ApprovalName152 { get; set; }

        ///<summary>
        ///Numeric value of output time series 153
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 153", Format="double")]
        public double? NumericValue153 { get; set; }

        ///<summary>
        ///Display value of output time series 153
        ///</summary>
        [ApiMember(Description="Display value of output time series 153")]
        public string DisplayValue153 { get; set; }

        ///<summary>
        ///Grade code of output time series 153
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 153", Format="int64")]
        public long? GradeCode153 { get; set; }

        ///<summary>
        ///Grade name of output time series 153
        ///</summary>
        [ApiMember(Description="Grade name of output time series 153")]
        public string GradeName153 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 153
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 153")]
        public string Qualifiers153 { get; set; }

        ///<summary>
        ///Method of output time series 153
        ///</summary>
        [ApiMember(Description="Method of output time series 153")]
        public string Method153 { get; set; }

        ///<summary>
        ///Approval level of output time series 153
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 153", Format="int64")]
        public long? ApprovalLevel153 { get; set; }

        ///<summary>
        ///Approval name of output time series 153
        ///</summary>
        [ApiMember(Description="Approval name of output time series 153")]
        public string ApprovalName153 { get; set; }

        ///<summary>
        ///Numeric value of output time series 154
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 154", Format="double")]
        public double? NumericValue154 { get; set; }

        ///<summary>
        ///Display value of output time series 154
        ///</summary>
        [ApiMember(Description="Display value of output time series 154")]
        public string DisplayValue154 { get; set; }

        ///<summary>
        ///Grade code of output time series 154
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 154", Format="int64")]
        public long? GradeCode154 { get; set; }

        ///<summary>
        ///Grade name of output time series 154
        ///</summary>
        [ApiMember(Description="Grade name of output time series 154")]
        public string GradeName154 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 154
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 154")]
        public string Qualifiers154 { get; set; }

        ///<summary>
        ///Method of output time series 154
        ///</summary>
        [ApiMember(Description="Method of output time series 154")]
        public string Method154 { get; set; }

        ///<summary>
        ///Approval level of output time series 154
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 154", Format="int64")]
        public long? ApprovalLevel154 { get; set; }

        ///<summary>
        ///Approval name of output time series 154
        ///</summary>
        [ApiMember(Description="Approval name of output time series 154")]
        public string ApprovalName154 { get; set; }

        ///<summary>
        ///Numeric value of output time series 155
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 155", Format="double")]
        public double? NumericValue155 { get; set; }

        ///<summary>
        ///Display value of output time series 155
        ///</summary>
        [ApiMember(Description="Display value of output time series 155")]
        public string DisplayValue155 { get; set; }

        ///<summary>
        ///Grade code of output time series 155
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 155", Format="int64")]
        public long? GradeCode155 { get; set; }

        ///<summary>
        ///Grade name of output time series 155
        ///</summary>
        [ApiMember(Description="Grade name of output time series 155")]
        public string GradeName155 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 155
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 155")]
        public string Qualifiers155 { get; set; }

        ///<summary>
        ///Method of output time series 155
        ///</summary>
        [ApiMember(Description="Method of output time series 155")]
        public string Method155 { get; set; }

        ///<summary>
        ///Approval level of output time series 155
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 155", Format="int64")]
        public long? ApprovalLevel155 { get; set; }

        ///<summary>
        ///Approval name of output time series 155
        ///</summary>
        [ApiMember(Description="Approval name of output time series 155")]
        public string ApprovalName155 { get; set; }

        ///<summary>
        ///Numeric value of output time series 156
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 156", Format="double")]
        public double? NumericValue156 { get; set; }

        ///<summary>
        ///Display value of output time series 156
        ///</summary>
        [ApiMember(Description="Display value of output time series 156")]
        public string DisplayValue156 { get; set; }

        ///<summary>
        ///Grade code of output time series 156
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 156", Format="int64")]
        public long? GradeCode156 { get; set; }

        ///<summary>
        ///Grade name of output time series 156
        ///</summary>
        [ApiMember(Description="Grade name of output time series 156")]
        public string GradeName156 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 156
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 156")]
        public string Qualifiers156 { get; set; }

        ///<summary>
        ///Method of output time series 156
        ///</summary>
        [ApiMember(Description="Method of output time series 156")]
        public string Method156 { get; set; }

        ///<summary>
        ///Approval level of output time series 156
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 156", Format="int64")]
        public long? ApprovalLevel156 { get; set; }

        ///<summary>
        ///Approval name of output time series 156
        ///</summary>
        [ApiMember(Description="Approval name of output time series 156")]
        public string ApprovalName156 { get; set; }

        ///<summary>
        ///Numeric value of output time series 157
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 157", Format="double")]
        public double? NumericValue157 { get; set; }

        ///<summary>
        ///Display value of output time series 157
        ///</summary>
        [ApiMember(Description="Display value of output time series 157")]
        public string DisplayValue157 { get; set; }

        ///<summary>
        ///Grade code of output time series 157
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 157", Format="int64")]
        public long? GradeCode157 { get; set; }

        ///<summary>
        ///Grade name of output time series 157
        ///</summary>
        [ApiMember(Description="Grade name of output time series 157")]
        public string GradeName157 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 157
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 157")]
        public string Qualifiers157 { get; set; }

        ///<summary>
        ///Method of output time series 157
        ///</summary>
        [ApiMember(Description="Method of output time series 157")]
        public string Method157 { get; set; }

        ///<summary>
        ///Approval level of output time series 157
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 157", Format="int64")]
        public long? ApprovalLevel157 { get; set; }

        ///<summary>
        ///Approval name of output time series 157
        ///</summary>
        [ApiMember(Description="Approval name of output time series 157")]
        public string ApprovalName157 { get; set; }

        ///<summary>
        ///Numeric value of output time series 158
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 158", Format="double")]
        public double? NumericValue158 { get; set; }

        ///<summary>
        ///Display value of output time series 158
        ///</summary>
        [ApiMember(Description="Display value of output time series 158")]
        public string DisplayValue158 { get; set; }

        ///<summary>
        ///Grade code of output time series 158
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 158", Format="int64")]
        public long? GradeCode158 { get; set; }

        ///<summary>
        ///Grade name of output time series 158
        ///</summary>
        [ApiMember(Description="Grade name of output time series 158")]
        public string GradeName158 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 158
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 158")]
        public string Qualifiers158 { get; set; }

        ///<summary>
        ///Method of output time series 158
        ///</summary>
        [ApiMember(Description="Method of output time series 158")]
        public string Method158 { get; set; }

        ///<summary>
        ///Approval level of output time series 158
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 158", Format="int64")]
        public long? ApprovalLevel158 { get; set; }

        ///<summary>
        ///Approval name of output time series 158
        ///</summary>
        [ApiMember(Description="Approval name of output time series 158")]
        public string ApprovalName158 { get; set; }

        ///<summary>
        ///Numeric value of output time series 159
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 159", Format="double")]
        public double? NumericValue159 { get; set; }

        ///<summary>
        ///Display value of output time series 159
        ///</summary>
        [ApiMember(Description="Display value of output time series 159")]
        public string DisplayValue159 { get; set; }

        ///<summary>
        ///Grade code of output time series 159
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 159", Format="int64")]
        public long? GradeCode159 { get; set; }

        ///<summary>
        ///Grade name of output time series 159
        ///</summary>
        [ApiMember(Description="Grade name of output time series 159")]
        public string GradeName159 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 159
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 159")]
        public string Qualifiers159 { get; set; }

        ///<summary>
        ///Method of output time series 159
        ///</summary>
        [ApiMember(Description="Method of output time series 159")]
        public string Method159 { get; set; }

        ///<summary>
        ///Approval level of output time series 159
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 159", Format="int64")]
        public long? ApprovalLevel159 { get; set; }

        ///<summary>
        ///Approval name of output time series 159
        ///</summary>
        [ApiMember(Description="Approval name of output time series 159")]
        public string ApprovalName159 { get; set; }

        ///<summary>
        ///Numeric value of output time series 160
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 160", Format="double")]
        public double? NumericValue160 { get; set; }

        ///<summary>
        ///Display value of output time series 160
        ///</summary>
        [ApiMember(Description="Display value of output time series 160")]
        public string DisplayValue160 { get; set; }

        ///<summary>
        ///Grade code of output time series 160
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 160", Format="int64")]
        public long? GradeCode160 { get; set; }

        ///<summary>
        ///Grade name of output time series 160
        ///</summary>
        [ApiMember(Description="Grade name of output time series 160")]
        public string GradeName160 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 160
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 160")]
        public string Qualifiers160 { get; set; }

        ///<summary>
        ///Method of output time series 160
        ///</summary>
        [ApiMember(Description="Method of output time series 160")]
        public string Method160 { get; set; }

        ///<summary>
        ///Approval level of output time series 160
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 160", Format="int64")]
        public long? ApprovalLevel160 { get; set; }

        ///<summary>
        ///Approval name of output time series 160
        ///</summary>
        [ApiMember(Description="Approval name of output time series 160")]
        public string ApprovalName160 { get; set; }

        ///<summary>
        ///Numeric value of output time series 161
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 161", Format="double")]
        public double? NumericValue161 { get; set; }

        ///<summary>
        ///Display value of output time series 161
        ///</summary>
        [ApiMember(Description="Display value of output time series 161")]
        public string DisplayValue161 { get; set; }

        ///<summary>
        ///Grade code of output time series 161
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 161", Format="int64")]
        public long? GradeCode161 { get; set; }

        ///<summary>
        ///Grade name of output time series 161
        ///</summary>
        [ApiMember(Description="Grade name of output time series 161")]
        public string GradeName161 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 161
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 161")]
        public string Qualifiers161 { get; set; }

        ///<summary>
        ///Method of output time series 161
        ///</summary>
        [ApiMember(Description="Method of output time series 161")]
        public string Method161 { get; set; }

        ///<summary>
        ///Approval level of output time series 161
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 161", Format="int64")]
        public long? ApprovalLevel161 { get; set; }

        ///<summary>
        ///Approval name of output time series 161
        ///</summary>
        [ApiMember(Description="Approval name of output time series 161")]
        public string ApprovalName161 { get; set; }

        ///<summary>
        ///Numeric value of output time series 162
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 162", Format="double")]
        public double? NumericValue162 { get; set; }

        ///<summary>
        ///Display value of output time series 162
        ///</summary>
        [ApiMember(Description="Display value of output time series 162")]
        public string DisplayValue162 { get; set; }

        ///<summary>
        ///Grade code of output time series 162
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 162", Format="int64")]
        public long? GradeCode162 { get; set; }

        ///<summary>
        ///Grade name of output time series 162
        ///</summary>
        [ApiMember(Description="Grade name of output time series 162")]
        public string GradeName162 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 162
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 162")]
        public string Qualifiers162 { get; set; }

        ///<summary>
        ///Method of output time series 162
        ///</summary>
        [ApiMember(Description="Method of output time series 162")]
        public string Method162 { get; set; }

        ///<summary>
        ///Approval level of output time series 162
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 162", Format="int64")]
        public long? ApprovalLevel162 { get; set; }

        ///<summary>
        ///Approval name of output time series 162
        ///</summary>
        [ApiMember(Description="Approval name of output time series 162")]
        public string ApprovalName162 { get; set; }

        ///<summary>
        ///Numeric value of output time series 163
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 163", Format="double")]
        public double? NumericValue163 { get; set; }

        ///<summary>
        ///Display value of output time series 163
        ///</summary>
        [ApiMember(Description="Display value of output time series 163")]
        public string DisplayValue163 { get; set; }

        ///<summary>
        ///Grade code of output time series 163
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 163", Format="int64")]
        public long? GradeCode163 { get; set; }

        ///<summary>
        ///Grade name of output time series 163
        ///</summary>
        [ApiMember(Description="Grade name of output time series 163")]
        public string GradeName163 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 163
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 163")]
        public string Qualifiers163 { get; set; }

        ///<summary>
        ///Method of output time series 163
        ///</summary>
        [ApiMember(Description="Method of output time series 163")]
        public string Method163 { get; set; }

        ///<summary>
        ///Approval level of output time series 163
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 163", Format="int64")]
        public long? ApprovalLevel163 { get; set; }

        ///<summary>
        ///Approval name of output time series 163
        ///</summary>
        [ApiMember(Description="Approval name of output time series 163")]
        public string ApprovalName163 { get; set; }

        ///<summary>
        ///Numeric value of output time series 164
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 164", Format="double")]
        public double? NumericValue164 { get; set; }

        ///<summary>
        ///Display value of output time series 164
        ///</summary>
        [ApiMember(Description="Display value of output time series 164")]
        public string DisplayValue164 { get; set; }

        ///<summary>
        ///Grade code of output time series 164
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 164", Format="int64")]
        public long? GradeCode164 { get; set; }

        ///<summary>
        ///Grade name of output time series 164
        ///</summary>
        [ApiMember(Description="Grade name of output time series 164")]
        public string GradeName164 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 164
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 164")]
        public string Qualifiers164 { get; set; }

        ///<summary>
        ///Method of output time series 164
        ///</summary>
        [ApiMember(Description="Method of output time series 164")]
        public string Method164 { get; set; }

        ///<summary>
        ///Approval level of output time series 164
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 164", Format="int64")]
        public long? ApprovalLevel164 { get; set; }

        ///<summary>
        ///Approval name of output time series 164
        ///</summary>
        [ApiMember(Description="Approval name of output time series 164")]
        public string ApprovalName164 { get; set; }

        ///<summary>
        ///Numeric value of output time series 165
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 165", Format="double")]
        public double? NumericValue165 { get; set; }

        ///<summary>
        ///Display value of output time series 165
        ///</summary>
        [ApiMember(Description="Display value of output time series 165")]
        public string DisplayValue165 { get; set; }

        ///<summary>
        ///Grade code of output time series 165
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 165", Format="int64")]
        public long? GradeCode165 { get; set; }

        ///<summary>
        ///Grade name of output time series 165
        ///</summary>
        [ApiMember(Description="Grade name of output time series 165")]
        public string GradeName165 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 165
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 165")]
        public string Qualifiers165 { get; set; }

        ///<summary>
        ///Method of output time series 165
        ///</summary>
        [ApiMember(Description="Method of output time series 165")]
        public string Method165 { get; set; }

        ///<summary>
        ///Approval level of output time series 165
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 165", Format="int64")]
        public long? ApprovalLevel165 { get; set; }

        ///<summary>
        ///Approval name of output time series 165
        ///</summary>
        [ApiMember(Description="Approval name of output time series 165")]
        public string ApprovalName165 { get; set; }

        ///<summary>
        ///Numeric value of output time series 166
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 166", Format="double")]
        public double? NumericValue166 { get; set; }

        ///<summary>
        ///Display value of output time series 166
        ///</summary>
        [ApiMember(Description="Display value of output time series 166")]
        public string DisplayValue166 { get; set; }

        ///<summary>
        ///Grade code of output time series 166
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 166", Format="int64")]
        public long? GradeCode166 { get; set; }

        ///<summary>
        ///Grade name of output time series 166
        ///</summary>
        [ApiMember(Description="Grade name of output time series 166")]
        public string GradeName166 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 166
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 166")]
        public string Qualifiers166 { get; set; }

        ///<summary>
        ///Method of output time series 166
        ///</summary>
        [ApiMember(Description="Method of output time series 166")]
        public string Method166 { get; set; }

        ///<summary>
        ///Approval level of output time series 166
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 166", Format="int64")]
        public long? ApprovalLevel166 { get; set; }

        ///<summary>
        ///Approval name of output time series 166
        ///</summary>
        [ApiMember(Description="Approval name of output time series 166")]
        public string ApprovalName166 { get; set; }

        ///<summary>
        ///Numeric value of output time series 167
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 167", Format="double")]
        public double? NumericValue167 { get; set; }

        ///<summary>
        ///Display value of output time series 167
        ///</summary>
        [ApiMember(Description="Display value of output time series 167")]
        public string DisplayValue167 { get; set; }

        ///<summary>
        ///Grade code of output time series 167
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 167", Format="int64")]
        public long? GradeCode167 { get; set; }

        ///<summary>
        ///Grade name of output time series 167
        ///</summary>
        [ApiMember(Description="Grade name of output time series 167")]
        public string GradeName167 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 167
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 167")]
        public string Qualifiers167 { get; set; }

        ///<summary>
        ///Method of output time series 167
        ///</summary>
        [ApiMember(Description="Method of output time series 167")]
        public string Method167 { get; set; }

        ///<summary>
        ///Approval level of output time series 167
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 167", Format="int64")]
        public long? ApprovalLevel167 { get; set; }

        ///<summary>
        ///Approval name of output time series 167
        ///</summary>
        [ApiMember(Description="Approval name of output time series 167")]
        public string ApprovalName167 { get; set; }

        ///<summary>
        ///Numeric value of output time series 168
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 168", Format="double")]
        public double? NumericValue168 { get; set; }

        ///<summary>
        ///Display value of output time series 168
        ///</summary>
        [ApiMember(Description="Display value of output time series 168")]
        public string DisplayValue168 { get; set; }

        ///<summary>
        ///Grade code of output time series 168
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 168", Format="int64")]
        public long? GradeCode168 { get; set; }

        ///<summary>
        ///Grade name of output time series 168
        ///</summary>
        [ApiMember(Description="Grade name of output time series 168")]
        public string GradeName168 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 168
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 168")]
        public string Qualifiers168 { get; set; }

        ///<summary>
        ///Method of output time series 168
        ///</summary>
        [ApiMember(Description="Method of output time series 168")]
        public string Method168 { get; set; }

        ///<summary>
        ///Approval level of output time series 168
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 168", Format="int64")]
        public long? ApprovalLevel168 { get; set; }

        ///<summary>
        ///Approval name of output time series 168
        ///</summary>
        [ApiMember(Description="Approval name of output time series 168")]
        public string ApprovalName168 { get; set; }

        ///<summary>
        ///Numeric value of output time series 169
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 169", Format="double")]
        public double? NumericValue169 { get; set; }

        ///<summary>
        ///Display value of output time series 169
        ///</summary>
        [ApiMember(Description="Display value of output time series 169")]
        public string DisplayValue169 { get; set; }

        ///<summary>
        ///Grade code of output time series 169
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 169", Format="int64")]
        public long? GradeCode169 { get; set; }

        ///<summary>
        ///Grade name of output time series 169
        ///</summary>
        [ApiMember(Description="Grade name of output time series 169")]
        public string GradeName169 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 169
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 169")]
        public string Qualifiers169 { get; set; }

        ///<summary>
        ///Method of output time series 169
        ///</summary>
        [ApiMember(Description="Method of output time series 169")]
        public string Method169 { get; set; }

        ///<summary>
        ///Approval level of output time series 169
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 169", Format="int64")]
        public long? ApprovalLevel169 { get; set; }

        ///<summary>
        ///Approval name of output time series 169
        ///</summary>
        [ApiMember(Description="Approval name of output time series 169")]
        public string ApprovalName169 { get; set; }

        ///<summary>
        ///Numeric value of output time series 170
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 170", Format="double")]
        public double? NumericValue170 { get; set; }

        ///<summary>
        ///Display value of output time series 170
        ///</summary>
        [ApiMember(Description="Display value of output time series 170")]
        public string DisplayValue170 { get; set; }

        ///<summary>
        ///Grade code of output time series 170
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 170", Format="int64")]
        public long? GradeCode170 { get; set; }

        ///<summary>
        ///Grade name of output time series 170
        ///</summary>
        [ApiMember(Description="Grade name of output time series 170")]
        public string GradeName170 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 170
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 170")]
        public string Qualifiers170 { get; set; }

        ///<summary>
        ///Method of output time series 170
        ///</summary>
        [ApiMember(Description="Method of output time series 170")]
        public string Method170 { get; set; }

        ///<summary>
        ///Approval level of output time series 170
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 170", Format="int64")]
        public long? ApprovalLevel170 { get; set; }

        ///<summary>
        ///Approval name of output time series 170
        ///</summary>
        [ApiMember(Description="Approval name of output time series 170")]
        public string ApprovalName170 { get; set; }

        ///<summary>
        ///Numeric value of output time series 171
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 171", Format="double")]
        public double? NumericValue171 { get; set; }

        ///<summary>
        ///Display value of output time series 171
        ///</summary>
        [ApiMember(Description="Display value of output time series 171")]
        public string DisplayValue171 { get; set; }

        ///<summary>
        ///Grade code of output time series 171
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 171", Format="int64")]
        public long? GradeCode171 { get; set; }

        ///<summary>
        ///Grade name of output time series 171
        ///</summary>
        [ApiMember(Description="Grade name of output time series 171")]
        public string GradeName171 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 171
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 171")]
        public string Qualifiers171 { get; set; }

        ///<summary>
        ///Method of output time series 171
        ///</summary>
        [ApiMember(Description="Method of output time series 171")]
        public string Method171 { get; set; }

        ///<summary>
        ///Approval level of output time series 171
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 171", Format="int64")]
        public long? ApprovalLevel171 { get; set; }

        ///<summary>
        ///Approval name of output time series 171
        ///</summary>
        [ApiMember(Description="Approval name of output time series 171")]
        public string ApprovalName171 { get; set; }

        ///<summary>
        ///Numeric value of output time series 172
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 172", Format="double")]
        public double? NumericValue172 { get; set; }

        ///<summary>
        ///Display value of output time series 172
        ///</summary>
        [ApiMember(Description="Display value of output time series 172")]
        public string DisplayValue172 { get; set; }

        ///<summary>
        ///Grade code of output time series 172
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 172", Format="int64")]
        public long? GradeCode172 { get; set; }

        ///<summary>
        ///Grade name of output time series 172
        ///</summary>
        [ApiMember(Description="Grade name of output time series 172")]
        public string GradeName172 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 172
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 172")]
        public string Qualifiers172 { get; set; }

        ///<summary>
        ///Method of output time series 172
        ///</summary>
        [ApiMember(Description="Method of output time series 172")]
        public string Method172 { get; set; }

        ///<summary>
        ///Approval level of output time series 172
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 172", Format="int64")]
        public long? ApprovalLevel172 { get; set; }

        ///<summary>
        ///Approval name of output time series 172
        ///</summary>
        [ApiMember(Description="Approval name of output time series 172")]
        public string ApprovalName172 { get; set; }

        ///<summary>
        ///Numeric value of output time series 173
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 173", Format="double")]
        public double? NumericValue173 { get; set; }

        ///<summary>
        ///Display value of output time series 173
        ///</summary>
        [ApiMember(Description="Display value of output time series 173")]
        public string DisplayValue173 { get; set; }

        ///<summary>
        ///Grade code of output time series 173
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 173", Format="int64")]
        public long? GradeCode173 { get; set; }

        ///<summary>
        ///Grade name of output time series 173
        ///</summary>
        [ApiMember(Description="Grade name of output time series 173")]
        public string GradeName173 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 173
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 173")]
        public string Qualifiers173 { get; set; }

        ///<summary>
        ///Method of output time series 173
        ///</summary>
        [ApiMember(Description="Method of output time series 173")]
        public string Method173 { get; set; }

        ///<summary>
        ///Approval level of output time series 173
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 173", Format="int64")]
        public long? ApprovalLevel173 { get; set; }

        ///<summary>
        ///Approval name of output time series 173
        ///</summary>
        [ApiMember(Description="Approval name of output time series 173")]
        public string ApprovalName173 { get; set; }

        ///<summary>
        ///Numeric value of output time series 174
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 174", Format="double")]
        public double? NumericValue174 { get; set; }

        ///<summary>
        ///Display value of output time series 174
        ///</summary>
        [ApiMember(Description="Display value of output time series 174")]
        public string DisplayValue174 { get; set; }

        ///<summary>
        ///Grade code of output time series 174
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 174", Format="int64")]
        public long? GradeCode174 { get; set; }

        ///<summary>
        ///Grade name of output time series 174
        ///</summary>
        [ApiMember(Description="Grade name of output time series 174")]
        public string GradeName174 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 174
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 174")]
        public string Qualifiers174 { get; set; }

        ///<summary>
        ///Method of output time series 174
        ///</summary>
        [ApiMember(Description="Method of output time series 174")]
        public string Method174 { get; set; }

        ///<summary>
        ///Approval level of output time series 174
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 174", Format="int64")]
        public long? ApprovalLevel174 { get; set; }

        ///<summary>
        ///Approval name of output time series 174
        ///</summary>
        [ApiMember(Description="Approval name of output time series 174")]
        public string ApprovalName174 { get; set; }

        ///<summary>
        ///Numeric value of output time series 175
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 175", Format="double")]
        public double? NumericValue175 { get; set; }

        ///<summary>
        ///Display value of output time series 175
        ///</summary>
        [ApiMember(Description="Display value of output time series 175")]
        public string DisplayValue175 { get; set; }

        ///<summary>
        ///Grade code of output time series 175
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 175", Format="int64")]
        public long? GradeCode175 { get; set; }

        ///<summary>
        ///Grade name of output time series 175
        ///</summary>
        [ApiMember(Description="Grade name of output time series 175")]
        public string GradeName175 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 175
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 175")]
        public string Qualifiers175 { get; set; }

        ///<summary>
        ///Method of output time series 175
        ///</summary>
        [ApiMember(Description="Method of output time series 175")]
        public string Method175 { get; set; }

        ///<summary>
        ///Approval level of output time series 175
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 175", Format="int64")]
        public long? ApprovalLevel175 { get; set; }

        ///<summary>
        ///Approval name of output time series 175
        ///</summary>
        [ApiMember(Description="Approval name of output time series 175")]
        public string ApprovalName175 { get; set; }

        ///<summary>
        ///Numeric value of output time series 176
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 176", Format="double")]
        public double? NumericValue176 { get; set; }

        ///<summary>
        ///Display value of output time series 176
        ///</summary>
        [ApiMember(Description="Display value of output time series 176")]
        public string DisplayValue176 { get; set; }

        ///<summary>
        ///Grade code of output time series 176
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 176", Format="int64")]
        public long? GradeCode176 { get; set; }

        ///<summary>
        ///Grade name of output time series 176
        ///</summary>
        [ApiMember(Description="Grade name of output time series 176")]
        public string GradeName176 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 176
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 176")]
        public string Qualifiers176 { get; set; }

        ///<summary>
        ///Method of output time series 176
        ///</summary>
        [ApiMember(Description="Method of output time series 176")]
        public string Method176 { get; set; }

        ///<summary>
        ///Approval level of output time series 176
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 176", Format="int64")]
        public long? ApprovalLevel176 { get; set; }

        ///<summary>
        ///Approval name of output time series 176
        ///</summary>
        [ApiMember(Description="Approval name of output time series 176")]
        public string ApprovalName176 { get; set; }

        ///<summary>
        ///Numeric value of output time series 177
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 177", Format="double")]
        public double? NumericValue177 { get; set; }

        ///<summary>
        ///Display value of output time series 177
        ///</summary>
        [ApiMember(Description="Display value of output time series 177")]
        public string DisplayValue177 { get; set; }

        ///<summary>
        ///Grade code of output time series 177
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 177", Format="int64")]
        public long? GradeCode177 { get; set; }

        ///<summary>
        ///Grade name of output time series 177
        ///</summary>
        [ApiMember(Description="Grade name of output time series 177")]
        public string GradeName177 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 177
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 177")]
        public string Qualifiers177 { get; set; }

        ///<summary>
        ///Method of output time series 177
        ///</summary>
        [ApiMember(Description="Method of output time series 177")]
        public string Method177 { get; set; }

        ///<summary>
        ///Approval level of output time series 177
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 177", Format="int64")]
        public long? ApprovalLevel177 { get; set; }

        ///<summary>
        ///Approval name of output time series 177
        ///</summary>
        [ApiMember(Description="Approval name of output time series 177")]
        public string ApprovalName177 { get; set; }

        ///<summary>
        ///Numeric value of output time series 178
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 178", Format="double")]
        public double? NumericValue178 { get; set; }

        ///<summary>
        ///Display value of output time series 178
        ///</summary>
        [ApiMember(Description="Display value of output time series 178")]
        public string DisplayValue178 { get; set; }

        ///<summary>
        ///Grade code of output time series 178
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 178", Format="int64")]
        public long? GradeCode178 { get; set; }

        ///<summary>
        ///Grade name of output time series 178
        ///</summary>
        [ApiMember(Description="Grade name of output time series 178")]
        public string GradeName178 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 178
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 178")]
        public string Qualifiers178 { get; set; }

        ///<summary>
        ///Method of output time series 178
        ///</summary>
        [ApiMember(Description="Method of output time series 178")]
        public string Method178 { get; set; }

        ///<summary>
        ///Approval level of output time series 178
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 178", Format="int64")]
        public long? ApprovalLevel178 { get; set; }

        ///<summary>
        ///Approval name of output time series 178
        ///</summary>
        [ApiMember(Description="Approval name of output time series 178")]
        public string ApprovalName178 { get; set; }

        ///<summary>
        ///Numeric value of output time series 179
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 179", Format="double")]
        public double? NumericValue179 { get; set; }

        ///<summary>
        ///Display value of output time series 179
        ///</summary>
        [ApiMember(Description="Display value of output time series 179")]
        public string DisplayValue179 { get; set; }

        ///<summary>
        ///Grade code of output time series 179
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 179", Format="int64")]
        public long? GradeCode179 { get; set; }

        ///<summary>
        ///Grade name of output time series 179
        ///</summary>
        [ApiMember(Description="Grade name of output time series 179")]
        public string GradeName179 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 179
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 179")]
        public string Qualifiers179 { get; set; }

        ///<summary>
        ///Method of output time series 179
        ///</summary>
        [ApiMember(Description="Method of output time series 179")]
        public string Method179 { get; set; }

        ///<summary>
        ///Approval level of output time series 179
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 179", Format="int64")]
        public long? ApprovalLevel179 { get; set; }

        ///<summary>
        ///Approval name of output time series 179
        ///</summary>
        [ApiMember(Description="Approval name of output time series 179")]
        public string ApprovalName179 { get; set; }

        ///<summary>
        ///Numeric value of output time series 180
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 180", Format="double")]
        public double? NumericValue180 { get; set; }

        ///<summary>
        ///Display value of output time series 180
        ///</summary>
        [ApiMember(Description="Display value of output time series 180")]
        public string DisplayValue180 { get; set; }

        ///<summary>
        ///Grade code of output time series 180
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 180", Format="int64")]
        public long? GradeCode180 { get; set; }

        ///<summary>
        ///Grade name of output time series 180
        ///</summary>
        [ApiMember(Description="Grade name of output time series 180")]
        public string GradeName180 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 180
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 180")]
        public string Qualifiers180 { get; set; }

        ///<summary>
        ///Method of output time series 180
        ///</summary>
        [ApiMember(Description="Method of output time series 180")]
        public string Method180 { get; set; }

        ///<summary>
        ///Approval level of output time series 180
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 180", Format="int64")]
        public long? ApprovalLevel180 { get; set; }

        ///<summary>
        ///Approval name of output time series 180
        ///</summary>
        [ApiMember(Description="Approval name of output time series 180")]
        public string ApprovalName180 { get; set; }

        ///<summary>
        ///Numeric value of output time series 181
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 181", Format="double")]
        public double? NumericValue181 { get; set; }

        ///<summary>
        ///Display value of output time series 181
        ///</summary>
        [ApiMember(Description="Display value of output time series 181")]
        public string DisplayValue181 { get; set; }

        ///<summary>
        ///Grade code of output time series 181
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 181", Format="int64")]
        public long? GradeCode181 { get; set; }

        ///<summary>
        ///Grade name of output time series 181
        ///</summary>
        [ApiMember(Description="Grade name of output time series 181")]
        public string GradeName181 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 181
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 181")]
        public string Qualifiers181 { get; set; }

        ///<summary>
        ///Method of output time series 181
        ///</summary>
        [ApiMember(Description="Method of output time series 181")]
        public string Method181 { get; set; }

        ///<summary>
        ///Approval level of output time series 181
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 181", Format="int64")]
        public long? ApprovalLevel181 { get; set; }

        ///<summary>
        ///Approval name of output time series 181
        ///</summary>
        [ApiMember(Description="Approval name of output time series 181")]
        public string ApprovalName181 { get; set; }

        ///<summary>
        ///Numeric value of output time series 182
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 182", Format="double")]
        public double? NumericValue182 { get; set; }

        ///<summary>
        ///Display value of output time series 182
        ///</summary>
        [ApiMember(Description="Display value of output time series 182")]
        public string DisplayValue182 { get; set; }

        ///<summary>
        ///Grade code of output time series 182
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 182", Format="int64")]
        public long? GradeCode182 { get; set; }

        ///<summary>
        ///Grade name of output time series 182
        ///</summary>
        [ApiMember(Description="Grade name of output time series 182")]
        public string GradeName182 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 182
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 182")]
        public string Qualifiers182 { get; set; }

        ///<summary>
        ///Method of output time series 182
        ///</summary>
        [ApiMember(Description="Method of output time series 182")]
        public string Method182 { get; set; }

        ///<summary>
        ///Approval level of output time series 182
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 182", Format="int64")]
        public long? ApprovalLevel182 { get; set; }

        ///<summary>
        ///Approval name of output time series 182
        ///</summary>
        [ApiMember(Description="Approval name of output time series 182")]
        public string ApprovalName182 { get; set; }

        ///<summary>
        ///Numeric value of output time series 183
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 183", Format="double")]
        public double? NumericValue183 { get; set; }

        ///<summary>
        ///Display value of output time series 183
        ///</summary>
        [ApiMember(Description="Display value of output time series 183")]
        public string DisplayValue183 { get; set; }

        ///<summary>
        ///Grade code of output time series 183
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 183", Format="int64")]
        public long? GradeCode183 { get; set; }

        ///<summary>
        ///Grade name of output time series 183
        ///</summary>
        [ApiMember(Description="Grade name of output time series 183")]
        public string GradeName183 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 183
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 183")]
        public string Qualifiers183 { get; set; }

        ///<summary>
        ///Method of output time series 183
        ///</summary>
        [ApiMember(Description="Method of output time series 183")]
        public string Method183 { get; set; }

        ///<summary>
        ///Approval level of output time series 183
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 183", Format="int64")]
        public long? ApprovalLevel183 { get; set; }

        ///<summary>
        ///Approval name of output time series 183
        ///</summary>
        [ApiMember(Description="Approval name of output time series 183")]
        public string ApprovalName183 { get; set; }

        ///<summary>
        ///Numeric value of output time series 184
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 184", Format="double")]
        public double? NumericValue184 { get; set; }

        ///<summary>
        ///Display value of output time series 184
        ///</summary>
        [ApiMember(Description="Display value of output time series 184")]
        public string DisplayValue184 { get; set; }

        ///<summary>
        ///Grade code of output time series 184
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 184", Format="int64")]
        public long? GradeCode184 { get; set; }

        ///<summary>
        ///Grade name of output time series 184
        ///</summary>
        [ApiMember(Description="Grade name of output time series 184")]
        public string GradeName184 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 184
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 184")]
        public string Qualifiers184 { get; set; }

        ///<summary>
        ///Method of output time series 184
        ///</summary>
        [ApiMember(Description="Method of output time series 184")]
        public string Method184 { get; set; }

        ///<summary>
        ///Approval level of output time series 184
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 184", Format="int64")]
        public long? ApprovalLevel184 { get; set; }

        ///<summary>
        ///Approval name of output time series 184
        ///</summary>
        [ApiMember(Description="Approval name of output time series 184")]
        public string ApprovalName184 { get; set; }

        ///<summary>
        ///Numeric value of output time series 185
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 185", Format="double")]
        public double? NumericValue185 { get; set; }

        ///<summary>
        ///Display value of output time series 185
        ///</summary>
        [ApiMember(Description="Display value of output time series 185")]
        public string DisplayValue185 { get; set; }

        ///<summary>
        ///Grade code of output time series 185
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 185", Format="int64")]
        public long? GradeCode185 { get; set; }

        ///<summary>
        ///Grade name of output time series 185
        ///</summary>
        [ApiMember(Description="Grade name of output time series 185")]
        public string GradeName185 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 185
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 185")]
        public string Qualifiers185 { get; set; }

        ///<summary>
        ///Method of output time series 185
        ///</summary>
        [ApiMember(Description="Method of output time series 185")]
        public string Method185 { get; set; }

        ///<summary>
        ///Approval level of output time series 185
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 185", Format="int64")]
        public long? ApprovalLevel185 { get; set; }

        ///<summary>
        ///Approval name of output time series 185
        ///</summary>
        [ApiMember(Description="Approval name of output time series 185")]
        public string ApprovalName185 { get; set; }

        ///<summary>
        ///Numeric value of output time series 186
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 186", Format="double")]
        public double? NumericValue186 { get; set; }

        ///<summary>
        ///Display value of output time series 186
        ///</summary>
        [ApiMember(Description="Display value of output time series 186")]
        public string DisplayValue186 { get; set; }

        ///<summary>
        ///Grade code of output time series 186
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 186", Format="int64")]
        public long? GradeCode186 { get; set; }

        ///<summary>
        ///Grade name of output time series 186
        ///</summary>
        [ApiMember(Description="Grade name of output time series 186")]
        public string GradeName186 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 186
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 186")]
        public string Qualifiers186 { get; set; }

        ///<summary>
        ///Method of output time series 186
        ///</summary>
        [ApiMember(Description="Method of output time series 186")]
        public string Method186 { get; set; }

        ///<summary>
        ///Approval level of output time series 186
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 186", Format="int64")]
        public long? ApprovalLevel186 { get; set; }

        ///<summary>
        ///Approval name of output time series 186
        ///</summary>
        [ApiMember(Description="Approval name of output time series 186")]
        public string ApprovalName186 { get; set; }

        ///<summary>
        ///Numeric value of output time series 187
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 187", Format="double")]
        public double? NumericValue187 { get; set; }

        ///<summary>
        ///Display value of output time series 187
        ///</summary>
        [ApiMember(Description="Display value of output time series 187")]
        public string DisplayValue187 { get; set; }

        ///<summary>
        ///Grade code of output time series 187
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 187", Format="int64")]
        public long? GradeCode187 { get; set; }

        ///<summary>
        ///Grade name of output time series 187
        ///</summary>
        [ApiMember(Description="Grade name of output time series 187")]
        public string GradeName187 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 187
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 187")]
        public string Qualifiers187 { get; set; }

        ///<summary>
        ///Method of output time series 187
        ///</summary>
        [ApiMember(Description="Method of output time series 187")]
        public string Method187 { get; set; }

        ///<summary>
        ///Approval level of output time series 187
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 187", Format="int64")]
        public long? ApprovalLevel187 { get; set; }

        ///<summary>
        ///Approval name of output time series 187
        ///</summary>
        [ApiMember(Description="Approval name of output time series 187")]
        public string ApprovalName187 { get; set; }

        ///<summary>
        ///Numeric value of output time series 188
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 188", Format="double")]
        public double? NumericValue188 { get; set; }

        ///<summary>
        ///Display value of output time series 188
        ///</summary>
        [ApiMember(Description="Display value of output time series 188")]
        public string DisplayValue188 { get; set; }

        ///<summary>
        ///Grade code of output time series 188
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 188", Format="int64")]
        public long? GradeCode188 { get; set; }

        ///<summary>
        ///Grade name of output time series 188
        ///</summary>
        [ApiMember(Description="Grade name of output time series 188")]
        public string GradeName188 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 188
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 188")]
        public string Qualifiers188 { get; set; }

        ///<summary>
        ///Method of output time series 188
        ///</summary>
        [ApiMember(Description="Method of output time series 188")]
        public string Method188 { get; set; }

        ///<summary>
        ///Approval level of output time series 188
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 188", Format="int64")]
        public long? ApprovalLevel188 { get; set; }

        ///<summary>
        ///Approval name of output time series 188
        ///</summary>
        [ApiMember(Description="Approval name of output time series 188")]
        public string ApprovalName188 { get; set; }

        ///<summary>
        ///Numeric value of output time series 189
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 189", Format="double")]
        public double? NumericValue189 { get; set; }

        ///<summary>
        ///Display value of output time series 189
        ///</summary>
        [ApiMember(Description="Display value of output time series 189")]
        public string DisplayValue189 { get; set; }

        ///<summary>
        ///Grade code of output time series 189
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 189", Format="int64")]
        public long? GradeCode189 { get; set; }

        ///<summary>
        ///Grade name of output time series 189
        ///</summary>
        [ApiMember(Description="Grade name of output time series 189")]
        public string GradeName189 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 189
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 189")]
        public string Qualifiers189 { get; set; }

        ///<summary>
        ///Method of output time series 189
        ///</summary>
        [ApiMember(Description="Method of output time series 189")]
        public string Method189 { get; set; }

        ///<summary>
        ///Approval level of output time series 189
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 189", Format="int64")]
        public long? ApprovalLevel189 { get; set; }

        ///<summary>
        ///Approval name of output time series 189
        ///</summary>
        [ApiMember(Description="Approval name of output time series 189")]
        public string ApprovalName189 { get; set; }

        ///<summary>
        ///Numeric value of output time series 190
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 190", Format="double")]
        public double? NumericValue190 { get; set; }

        ///<summary>
        ///Display value of output time series 190
        ///</summary>
        [ApiMember(Description="Display value of output time series 190")]
        public string DisplayValue190 { get; set; }

        ///<summary>
        ///Grade code of output time series 190
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 190", Format="int64")]
        public long? GradeCode190 { get; set; }

        ///<summary>
        ///Grade name of output time series 190
        ///</summary>
        [ApiMember(Description="Grade name of output time series 190")]
        public string GradeName190 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 190
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 190")]
        public string Qualifiers190 { get; set; }

        ///<summary>
        ///Method of output time series 190
        ///</summary>
        [ApiMember(Description="Method of output time series 190")]
        public string Method190 { get; set; }

        ///<summary>
        ///Approval level of output time series 190
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 190", Format="int64")]
        public long? ApprovalLevel190 { get; set; }

        ///<summary>
        ///Approval name of output time series 190
        ///</summary>
        [ApiMember(Description="Approval name of output time series 190")]
        public string ApprovalName190 { get; set; }

        ///<summary>
        ///Numeric value of output time series 191
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 191", Format="double")]
        public double? NumericValue191 { get; set; }

        ///<summary>
        ///Display value of output time series 191
        ///</summary>
        [ApiMember(Description="Display value of output time series 191")]
        public string DisplayValue191 { get; set; }

        ///<summary>
        ///Grade code of output time series 191
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 191", Format="int64")]
        public long? GradeCode191 { get; set; }

        ///<summary>
        ///Grade name of output time series 191
        ///</summary>
        [ApiMember(Description="Grade name of output time series 191")]
        public string GradeName191 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 191
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 191")]
        public string Qualifiers191 { get; set; }

        ///<summary>
        ///Method of output time series 191
        ///</summary>
        [ApiMember(Description="Method of output time series 191")]
        public string Method191 { get; set; }

        ///<summary>
        ///Approval level of output time series 191
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 191", Format="int64")]
        public long? ApprovalLevel191 { get; set; }

        ///<summary>
        ///Approval name of output time series 191
        ///</summary>
        [ApiMember(Description="Approval name of output time series 191")]
        public string ApprovalName191 { get; set; }

        ///<summary>
        ///Numeric value of output time series 192
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 192", Format="double")]
        public double? NumericValue192 { get; set; }

        ///<summary>
        ///Display value of output time series 192
        ///</summary>
        [ApiMember(Description="Display value of output time series 192")]
        public string DisplayValue192 { get; set; }

        ///<summary>
        ///Grade code of output time series 192
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 192", Format="int64")]
        public long? GradeCode192 { get; set; }

        ///<summary>
        ///Grade name of output time series 192
        ///</summary>
        [ApiMember(Description="Grade name of output time series 192")]
        public string GradeName192 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 192
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 192")]
        public string Qualifiers192 { get; set; }

        ///<summary>
        ///Method of output time series 192
        ///</summary>
        [ApiMember(Description="Method of output time series 192")]
        public string Method192 { get; set; }

        ///<summary>
        ///Approval level of output time series 192
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 192", Format="int64")]
        public long? ApprovalLevel192 { get; set; }

        ///<summary>
        ///Approval name of output time series 192
        ///</summary>
        [ApiMember(Description="Approval name of output time series 192")]
        public string ApprovalName192 { get; set; }

        ///<summary>
        ///Numeric value of output time series 193
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 193", Format="double")]
        public double? NumericValue193 { get; set; }

        ///<summary>
        ///Display value of output time series 193
        ///</summary>
        [ApiMember(Description="Display value of output time series 193")]
        public string DisplayValue193 { get; set; }

        ///<summary>
        ///Grade code of output time series 193
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 193", Format="int64")]
        public long? GradeCode193 { get; set; }

        ///<summary>
        ///Grade name of output time series 193
        ///</summary>
        [ApiMember(Description="Grade name of output time series 193")]
        public string GradeName193 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 193
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 193")]
        public string Qualifiers193 { get; set; }

        ///<summary>
        ///Method of output time series 193
        ///</summary>
        [ApiMember(Description="Method of output time series 193")]
        public string Method193 { get; set; }

        ///<summary>
        ///Approval level of output time series 193
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 193", Format="int64")]
        public long? ApprovalLevel193 { get; set; }

        ///<summary>
        ///Approval name of output time series 193
        ///</summary>
        [ApiMember(Description="Approval name of output time series 193")]
        public string ApprovalName193 { get; set; }

        ///<summary>
        ///Numeric value of output time series 194
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 194", Format="double")]
        public double? NumericValue194 { get; set; }

        ///<summary>
        ///Display value of output time series 194
        ///</summary>
        [ApiMember(Description="Display value of output time series 194")]
        public string DisplayValue194 { get; set; }

        ///<summary>
        ///Grade code of output time series 194
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 194", Format="int64")]
        public long? GradeCode194 { get; set; }

        ///<summary>
        ///Grade name of output time series 194
        ///</summary>
        [ApiMember(Description="Grade name of output time series 194")]
        public string GradeName194 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 194
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 194")]
        public string Qualifiers194 { get; set; }

        ///<summary>
        ///Method of output time series 194
        ///</summary>
        [ApiMember(Description="Method of output time series 194")]
        public string Method194 { get; set; }

        ///<summary>
        ///Approval level of output time series 194
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 194", Format="int64")]
        public long? ApprovalLevel194 { get; set; }

        ///<summary>
        ///Approval name of output time series 194
        ///</summary>
        [ApiMember(Description="Approval name of output time series 194")]
        public string ApprovalName194 { get; set; }

        ///<summary>
        ///Numeric value of output time series 195
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 195", Format="double")]
        public double? NumericValue195 { get; set; }

        ///<summary>
        ///Display value of output time series 195
        ///</summary>
        [ApiMember(Description="Display value of output time series 195")]
        public string DisplayValue195 { get; set; }

        ///<summary>
        ///Grade code of output time series 195
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 195", Format="int64")]
        public long? GradeCode195 { get; set; }

        ///<summary>
        ///Grade name of output time series 195
        ///</summary>
        [ApiMember(Description="Grade name of output time series 195")]
        public string GradeName195 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 195
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 195")]
        public string Qualifiers195 { get; set; }

        ///<summary>
        ///Method of output time series 195
        ///</summary>
        [ApiMember(Description="Method of output time series 195")]
        public string Method195 { get; set; }

        ///<summary>
        ///Approval level of output time series 195
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 195", Format="int64")]
        public long? ApprovalLevel195 { get; set; }

        ///<summary>
        ///Approval name of output time series 195
        ///</summary>
        [ApiMember(Description="Approval name of output time series 195")]
        public string ApprovalName195 { get; set; }

        ///<summary>
        ///Numeric value of output time series 196
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 196", Format="double")]
        public double? NumericValue196 { get; set; }

        ///<summary>
        ///Display value of output time series 196
        ///</summary>
        [ApiMember(Description="Display value of output time series 196")]
        public string DisplayValue196 { get; set; }

        ///<summary>
        ///Grade code of output time series 196
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 196", Format="int64")]
        public long? GradeCode196 { get; set; }

        ///<summary>
        ///Grade name of output time series 196
        ///</summary>
        [ApiMember(Description="Grade name of output time series 196")]
        public string GradeName196 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 196
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 196")]
        public string Qualifiers196 { get; set; }

        ///<summary>
        ///Method of output time series 196
        ///</summary>
        [ApiMember(Description="Method of output time series 196")]
        public string Method196 { get; set; }

        ///<summary>
        ///Approval level of output time series 196
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 196", Format="int64")]
        public long? ApprovalLevel196 { get; set; }

        ///<summary>
        ///Approval name of output time series 196
        ///</summary>
        [ApiMember(Description="Approval name of output time series 196")]
        public string ApprovalName196 { get; set; }

        ///<summary>
        ///Numeric value of output time series 197
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 197", Format="double")]
        public double? NumericValue197 { get; set; }

        ///<summary>
        ///Display value of output time series 197
        ///</summary>
        [ApiMember(Description="Display value of output time series 197")]
        public string DisplayValue197 { get; set; }

        ///<summary>
        ///Grade code of output time series 197
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 197", Format="int64")]
        public long? GradeCode197 { get; set; }

        ///<summary>
        ///Grade name of output time series 197
        ///</summary>
        [ApiMember(Description="Grade name of output time series 197")]
        public string GradeName197 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 197
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 197")]
        public string Qualifiers197 { get; set; }

        ///<summary>
        ///Method of output time series 197
        ///</summary>
        [ApiMember(Description="Method of output time series 197")]
        public string Method197 { get; set; }

        ///<summary>
        ///Approval level of output time series 197
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 197", Format="int64")]
        public long? ApprovalLevel197 { get; set; }

        ///<summary>
        ///Approval name of output time series 197
        ///</summary>
        [ApiMember(Description="Approval name of output time series 197")]
        public string ApprovalName197 { get; set; }

        ///<summary>
        ///Numeric value of output time series 198
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 198", Format="double")]
        public double? NumericValue198 { get; set; }

        ///<summary>
        ///Display value of output time series 198
        ///</summary>
        [ApiMember(Description="Display value of output time series 198")]
        public string DisplayValue198 { get; set; }

        ///<summary>
        ///Grade code of output time series 198
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 198", Format="int64")]
        public long? GradeCode198 { get; set; }

        ///<summary>
        ///Grade name of output time series 198
        ///</summary>
        [ApiMember(Description="Grade name of output time series 198")]
        public string GradeName198 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 198
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 198")]
        public string Qualifiers198 { get; set; }

        ///<summary>
        ///Method of output time series 198
        ///</summary>
        [ApiMember(Description="Method of output time series 198")]
        public string Method198 { get; set; }

        ///<summary>
        ///Approval level of output time series 198
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 198", Format="int64")]
        public long? ApprovalLevel198 { get; set; }

        ///<summary>
        ///Approval name of output time series 198
        ///</summary>
        [ApiMember(Description="Approval name of output time series 198")]
        public string ApprovalName198 { get; set; }

        ///<summary>
        ///Numeric value of output time series 199
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 199", Format="double")]
        public double? NumericValue199 { get; set; }

        ///<summary>
        ///Display value of output time series 199
        ///</summary>
        [ApiMember(Description="Display value of output time series 199")]
        public string DisplayValue199 { get; set; }

        ///<summary>
        ///Grade code of output time series 199
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 199", Format="int64")]
        public long? GradeCode199 { get; set; }

        ///<summary>
        ///Grade name of output time series 199
        ///</summary>
        [ApiMember(Description="Grade name of output time series 199")]
        public string GradeName199 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 199
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 199")]
        public string Qualifiers199 { get; set; }

        ///<summary>
        ///Method of output time series 199
        ///</summary>
        [ApiMember(Description="Method of output time series 199")]
        public string Method199 { get; set; }

        ///<summary>
        ///Approval level of output time series 199
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 199", Format="int64")]
        public long? ApprovalLevel199 { get; set; }

        ///<summary>
        ///Approval name of output time series 199
        ///</summary>
        [ApiMember(Description="Approval name of output time series 199")]
        public string ApprovalName199 { get; set; }

        ///<summary>
        ///Numeric value of output time series 200
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 200", Format="double")]
        public double? NumericValue200 { get; set; }

        ///<summary>
        ///Display value of output time series 200
        ///</summary>
        [ApiMember(Description="Display value of output time series 200")]
        public string DisplayValue200 { get; set; }

        ///<summary>
        ///Grade code of output time series 200
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 200", Format="int64")]
        public long? GradeCode200 { get; set; }

        ///<summary>
        ///Grade name of output time series 200
        ///</summary>
        [ApiMember(Description="Grade name of output time series 200")]
        public string GradeName200 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 200
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 200")]
        public string Qualifiers200 { get; set; }

        ///<summary>
        ///Method of output time series 200
        ///</summary>
        [ApiMember(Description="Method of output time series 200")]
        public string Method200 { get; set; }

        ///<summary>
        ///Approval level of output time series 200
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 200", Format="int64")]
        public long? ApprovalLevel200 { get; set; }

        ///<summary>
        ///Approval name of output time series 200
        ///</summary>
        [ApiMember(Description="Approval name of output time series 200")]
        public string ApprovalName200 { get; set; }

        ///<summary>
        ///Numeric value of output time series 201
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 201", Format="double")]
        public double? NumericValue201 { get; set; }

        ///<summary>
        ///Display value of output time series 201
        ///</summary>
        [ApiMember(Description="Display value of output time series 201")]
        public string DisplayValue201 { get; set; }

        ///<summary>
        ///Grade code of output time series 201
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 201", Format="int64")]
        public long? GradeCode201 { get; set; }

        ///<summary>
        ///Grade name of output time series 201
        ///</summary>
        [ApiMember(Description="Grade name of output time series 201")]
        public string GradeName201 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 201
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 201")]
        public string Qualifiers201 { get; set; }

        ///<summary>
        ///Method of output time series 201
        ///</summary>
        [ApiMember(Description="Method of output time series 201")]
        public string Method201 { get; set; }

        ///<summary>
        ///Approval level of output time series 201
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 201", Format="int64")]
        public long? ApprovalLevel201 { get; set; }

        ///<summary>
        ///Approval name of output time series 201
        ///</summary>
        [ApiMember(Description="Approval name of output time series 201")]
        public string ApprovalName201 { get; set; }

        ///<summary>
        ///Numeric value of output time series 202
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 202", Format="double")]
        public double? NumericValue202 { get; set; }

        ///<summary>
        ///Display value of output time series 202
        ///</summary>
        [ApiMember(Description="Display value of output time series 202")]
        public string DisplayValue202 { get; set; }

        ///<summary>
        ///Grade code of output time series 202
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 202", Format="int64")]
        public long? GradeCode202 { get; set; }

        ///<summary>
        ///Grade name of output time series 202
        ///</summary>
        [ApiMember(Description="Grade name of output time series 202")]
        public string GradeName202 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 202
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 202")]
        public string Qualifiers202 { get; set; }

        ///<summary>
        ///Method of output time series 202
        ///</summary>
        [ApiMember(Description="Method of output time series 202")]
        public string Method202 { get; set; }

        ///<summary>
        ///Approval level of output time series 202
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 202", Format="int64")]
        public long? ApprovalLevel202 { get; set; }

        ///<summary>
        ///Approval name of output time series 202
        ///</summary>
        [ApiMember(Description="Approval name of output time series 202")]
        public string ApprovalName202 { get; set; }

        ///<summary>
        ///Numeric value of output time series 203
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 203", Format="double")]
        public double? NumericValue203 { get; set; }

        ///<summary>
        ///Display value of output time series 203
        ///</summary>
        [ApiMember(Description="Display value of output time series 203")]
        public string DisplayValue203 { get; set; }

        ///<summary>
        ///Grade code of output time series 203
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 203", Format="int64")]
        public long? GradeCode203 { get; set; }

        ///<summary>
        ///Grade name of output time series 203
        ///</summary>
        [ApiMember(Description="Grade name of output time series 203")]
        public string GradeName203 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 203
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 203")]
        public string Qualifiers203 { get; set; }

        ///<summary>
        ///Method of output time series 203
        ///</summary>
        [ApiMember(Description="Method of output time series 203")]
        public string Method203 { get; set; }

        ///<summary>
        ///Approval level of output time series 203
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 203", Format="int64")]
        public long? ApprovalLevel203 { get; set; }

        ///<summary>
        ///Approval name of output time series 203
        ///</summary>
        [ApiMember(Description="Approval name of output time series 203")]
        public string ApprovalName203 { get; set; }

        ///<summary>
        ///Numeric value of output time series 204
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 204", Format="double")]
        public double? NumericValue204 { get; set; }

        ///<summary>
        ///Display value of output time series 204
        ///</summary>
        [ApiMember(Description="Display value of output time series 204")]
        public string DisplayValue204 { get; set; }

        ///<summary>
        ///Grade code of output time series 204
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 204", Format="int64")]
        public long? GradeCode204 { get; set; }

        ///<summary>
        ///Grade name of output time series 204
        ///</summary>
        [ApiMember(Description="Grade name of output time series 204")]
        public string GradeName204 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 204
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 204")]
        public string Qualifiers204 { get; set; }

        ///<summary>
        ///Method of output time series 204
        ///</summary>
        [ApiMember(Description="Method of output time series 204")]
        public string Method204 { get; set; }

        ///<summary>
        ///Approval level of output time series 204
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 204", Format="int64")]
        public long? ApprovalLevel204 { get; set; }

        ///<summary>
        ///Approval name of output time series 204
        ///</summary>
        [ApiMember(Description="Approval name of output time series 204")]
        public string ApprovalName204 { get; set; }

        ///<summary>
        ///Numeric value of output time series 205
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 205", Format="double")]
        public double? NumericValue205 { get; set; }

        ///<summary>
        ///Display value of output time series 205
        ///</summary>
        [ApiMember(Description="Display value of output time series 205")]
        public string DisplayValue205 { get; set; }

        ///<summary>
        ///Grade code of output time series 205
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 205", Format="int64")]
        public long? GradeCode205 { get; set; }

        ///<summary>
        ///Grade name of output time series 205
        ///</summary>
        [ApiMember(Description="Grade name of output time series 205")]
        public string GradeName205 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 205
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 205")]
        public string Qualifiers205 { get; set; }

        ///<summary>
        ///Method of output time series 205
        ///</summary>
        [ApiMember(Description="Method of output time series 205")]
        public string Method205 { get; set; }

        ///<summary>
        ///Approval level of output time series 205
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 205", Format="int64")]
        public long? ApprovalLevel205 { get; set; }

        ///<summary>
        ///Approval name of output time series 205
        ///</summary>
        [ApiMember(Description="Approval name of output time series 205")]
        public string ApprovalName205 { get; set; }

        ///<summary>
        ///Numeric value of output time series 206
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 206", Format="double")]
        public double? NumericValue206 { get; set; }

        ///<summary>
        ///Display value of output time series 206
        ///</summary>
        [ApiMember(Description="Display value of output time series 206")]
        public string DisplayValue206 { get; set; }

        ///<summary>
        ///Grade code of output time series 206
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 206", Format="int64")]
        public long? GradeCode206 { get; set; }

        ///<summary>
        ///Grade name of output time series 206
        ///</summary>
        [ApiMember(Description="Grade name of output time series 206")]
        public string GradeName206 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 206
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 206")]
        public string Qualifiers206 { get; set; }

        ///<summary>
        ///Method of output time series 206
        ///</summary>
        [ApiMember(Description="Method of output time series 206")]
        public string Method206 { get; set; }

        ///<summary>
        ///Approval level of output time series 206
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 206", Format="int64")]
        public long? ApprovalLevel206 { get; set; }

        ///<summary>
        ///Approval name of output time series 206
        ///</summary>
        [ApiMember(Description="Approval name of output time series 206")]
        public string ApprovalName206 { get; set; }

        ///<summary>
        ///Numeric value of output time series 207
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 207", Format="double")]
        public double? NumericValue207 { get; set; }

        ///<summary>
        ///Display value of output time series 207
        ///</summary>
        [ApiMember(Description="Display value of output time series 207")]
        public string DisplayValue207 { get; set; }

        ///<summary>
        ///Grade code of output time series 207
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 207", Format="int64")]
        public long? GradeCode207 { get; set; }

        ///<summary>
        ///Grade name of output time series 207
        ///</summary>
        [ApiMember(Description="Grade name of output time series 207")]
        public string GradeName207 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 207
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 207")]
        public string Qualifiers207 { get; set; }

        ///<summary>
        ///Method of output time series 207
        ///</summary>
        [ApiMember(Description="Method of output time series 207")]
        public string Method207 { get; set; }

        ///<summary>
        ///Approval level of output time series 207
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 207", Format="int64")]
        public long? ApprovalLevel207 { get; set; }

        ///<summary>
        ///Approval name of output time series 207
        ///</summary>
        [ApiMember(Description="Approval name of output time series 207")]
        public string ApprovalName207 { get; set; }

        ///<summary>
        ///Numeric value of output time series 208
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 208", Format="double")]
        public double? NumericValue208 { get; set; }

        ///<summary>
        ///Display value of output time series 208
        ///</summary>
        [ApiMember(Description="Display value of output time series 208")]
        public string DisplayValue208 { get; set; }

        ///<summary>
        ///Grade code of output time series 208
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 208", Format="int64")]
        public long? GradeCode208 { get; set; }

        ///<summary>
        ///Grade name of output time series 208
        ///</summary>
        [ApiMember(Description="Grade name of output time series 208")]
        public string GradeName208 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 208
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 208")]
        public string Qualifiers208 { get; set; }

        ///<summary>
        ///Method of output time series 208
        ///</summary>
        [ApiMember(Description="Method of output time series 208")]
        public string Method208 { get; set; }

        ///<summary>
        ///Approval level of output time series 208
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 208", Format="int64")]
        public long? ApprovalLevel208 { get; set; }

        ///<summary>
        ///Approval name of output time series 208
        ///</summary>
        [ApiMember(Description="Approval name of output time series 208")]
        public string ApprovalName208 { get; set; }

        ///<summary>
        ///Numeric value of output time series 209
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 209", Format="double")]
        public double? NumericValue209 { get; set; }

        ///<summary>
        ///Display value of output time series 209
        ///</summary>
        [ApiMember(Description="Display value of output time series 209")]
        public string DisplayValue209 { get; set; }

        ///<summary>
        ///Grade code of output time series 209
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 209", Format="int64")]
        public long? GradeCode209 { get; set; }

        ///<summary>
        ///Grade name of output time series 209
        ///</summary>
        [ApiMember(Description="Grade name of output time series 209")]
        public string GradeName209 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 209
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 209")]
        public string Qualifiers209 { get; set; }

        ///<summary>
        ///Method of output time series 209
        ///</summary>
        [ApiMember(Description="Method of output time series 209")]
        public string Method209 { get; set; }

        ///<summary>
        ///Approval level of output time series 209
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 209", Format="int64")]
        public long? ApprovalLevel209 { get; set; }

        ///<summary>
        ///Approval name of output time series 209
        ///</summary>
        [ApiMember(Description="Approval name of output time series 209")]
        public string ApprovalName209 { get; set; }

        ///<summary>
        ///Numeric value of output time series 210
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 210", Format="double")]
        public double? NumericValue210 { get; set; }

        ///<summary>
        ///Display value of output time series 210
        ///</summary>
        [ApiMember(Description="Display value of output time series 210")]
        public string DisplayValue210 { get; set; }

        ///<summary>
        ///Grade code of output time series 210
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 210", Format="int64")]
        public long? GradeCode210 { get; set; }

        ///<summary>
        ///Grade name of output time series 210
        ///</summary>
        [ApiMember(Description="Grade name of output time series 210")]
        public string GradeName210 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 210
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 210")]
        public string Qualifiers210 { get; set; }

        ///<summary>
        ///Method of output time series 210
        ///</summary>
        [ApiMember(Description="Method of output time series 210")]
        public string Method210 { get; set; }

        ///<summary>
        ///Approval level of output time series 210
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 210", Format="int64")]
        public long? ApprovalLevel210 { get; set; }

        ///<summary>
        ///Approval name of output time series 210
        ///</summary>
        [ApiMember(Description="Approval name of output time series 210")]
        public string ApprovalName210 { get; set; }

        ///<summary>
        ///Numeric value of output time series 211
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 211", Format="double")]
        public double? NumericValue211 { get; set; }

        ///<summary>
        ///Display value of output time series 211
        ///</summary>
        [ApiMember(Description="Display value of output time series 211")]
        public string DisplayValue211 { get; set; }

        ///<summary>
        ///Grade code of output time series 211
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 211", Format="int64")]
        public long? GradeCode211 { get; set; }

        ///<summary>
        ///Grade name of output time series 211
        ///</summary>
        [ApiMember(Description="Grade name of output time series 211")]
        public string GradeName211 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 211
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 211")]
        public string Qualifiers211 { get; set; }

        ///<summary>
        ///Method of output time series 211
        ///</summary>
        [ApiMember(Description="Method of output time series 211")]
        public string Method211 { get; set; }

        ///<summary>
        ///Approval level of output time series 211
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 211", Format="int64")]
        public long? ApprovalLevel211 { get; set; }

        ///<summary>
        ///Approval name of output time series 211
        ///</summary>
        [ApiMember(Description="Approval name of output time series 211")]
        public string ApprovalName211 { get; set; }

        ///<summary>
        ///Numeric value of output time series 212
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 212", Format="double")]
        public double? NumericValue212 { get; set; }

        ///<summary>
        ///Display value of output time series 212
        ///</summary>
        [ApiMember(Description="Display value of output time series 212")]
        public string DisplayValue212 { get; set; }

        ///<summary>
        ///Grade code of output time series 212
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 212", Format="int64")]
        public long? GradeCode212 { get; set; }

        ///<summary>
        ///Grade name of output time series 212
        ///</summary>
        [ApiMember(Description="Grade name of output time series 212")]
        public string GradeName212 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 212
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 212")]
        public string Qualifiers212 { get; set; }

        ///<summary>
        ///Method of output time series 212
        ///</summary>
        [ApiMember(Description="Method of output time series 212")]
        public string Method212 { get; set; }

        ///<summary>
        ///Approval level of output time series 212
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 212", Format="int64")]
        public long? ApprovalLevel212 { get; set; }

        ///<summary>
        ///Approval name of output time series 212
        ///</summary>
        [ApiMember(Description="Approval name of output time series 212")]
        public string ApprovalName212 { get; set; }

        ///<summary>
        ///Numeric value of output time series 213
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 213", Format="double")]
        public double? NumericValue213 { get; set; }

        ///<summary>
        ///Display value of output time series 213
        ///</summary>
        [ApiMember(Description="Display value of output time series 213")]
        public string DisplayValue213 { get; set; }

        ///<summary>
        ///Grade code of output time series 213
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 213", Format="int64")]
        public long? GradeCode213 { get; set; }

        ///<summary>
        ///Grade name of output time series 213
        ///</summary>
        [ApiMember(Description="Grade name of output time series 213")]
        public string GradeName213 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 213
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 213")]
        public string Qualifiers213 { get; set; }

        ///<summary>
        ///Method of output time series 213
        ///</summary>
        [ApiMember(Description="Method of output time series 213")]
        public string Method213 { get; set; }

        ///<summary>
        ///Approval level of output time series 213
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 213", Format="int64")]
        public long? ApprovalLevel213 { get; set; }

        ///<summary>
        ///Approval name of output time series 213
        ///</summary>
        [ApiMember(Description="Approval name of output time series 213")]
        public string ApprovalName213 { get; set; }

        ///<summary>
        ///Numeric value of output time series 214
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 214", Format="double")]
        public double? NumericValue214 { get; set; }

        ///<summary>
        ///Display value of output time series 214
        ///</summary>
        [ApiMember(Description="Display value of output time series 214")]
        public string DisplayValue214 { get; set; }

        ///<summary>
        ///Grade code of output time series 214
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 214", Format="int64")]
        public long? GradeCode214 { get; set; }

        ///<summary>
        ///Grade name of output time series 214
        ///</summary>
        [ApiMember(Description="Grade name of output time series 214")]
        public string GradeName214 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 214
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 214")]
        public string Qualifiers214 { get; set; }

        ///<summary>
        ///Method of output time series 214
        ///</summary>
        [ApiMember(Description="Method of output time series 214")]
        public string Method214 { get; set; }

        ///<summary>
        ///Approval level of output time series 214
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 214", Format="int64")]
        public long? ApprovalLevel214 { get; set; }

        ///<summary>
        ///Approval name of output time series 214
        ///</summary>
        [ApiMember(Description="Approval name of output time series 214")]
        public string ApprovalName214 { get; set; }

        ///<summary>
        ///Numeric value of output time series 215
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 215", Format="double")]
        public double? NumericValue215 { get; set; }

        ///<summary>
        ///Display value of output time series 215
        ///</summary>
        [ApiMember(Description="Display value of output time series 215")]
        public string DisplayValue215 { get; set; }

        ///<summary>
        ///Grade code of output time series 215
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 215", Format="int64")]
        public long? GradeCode215 { get; set; }

        ///<summary>
        ///Grade name of output time series 215
        ///</summary>
        [ApiMember(Description="Grade name of output time series 215")]
        public string GradeName215 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 215
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 215")]
        public string Qualifiers215 { get; set; }

        ///<summary>
        ///Method of output time series 215
        ///</summary>
        [ApiMember(Description="Method of output time series 215")]
        public string Method215 { get; set; }

        ///<summary>
        ///Approval level of output time series 215
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 215", Format="int64")]
        public long? ApprovalLevel215 { get; set; }

        ///<summary>
        ///Approval name of output time series 215
        ///</summary>
        [ApiMember(Description="Approval name of output time series 215")]
        public string ApprovalName215 { get; set; }

        ///<summary>
        ///Numeric value of output time series 216
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 216", Format="double")]
        public double? NumericValue216 { get; set; }

        ///<summary>
        ///Display value of output time series 216
        ///</summary>
        [ApiMember(Description="Display value of output time series 216")]
        public string DisplayValue216 { get; set; }

        ///<summary>
        ///Grade code of output time series 216
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 216", Format="int64")]
        public long? GradeCode216 { get; set; }

        ///<summary>
        ///Grade name of output time series 216
        ///</summary>
        [ApiMember(Description="Grade name of output time series 216")]
        public string GradeName216 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 216
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 216")]
        public string Qualifiers216 { get; set; }

        ///<summary>
        ///Method of output time series 216
        ///</summary>
        [ApiMember(Description="Method of output time series 216")]
        public string Method216 { get; set; }

        ///<summary>
        ///Approval level of output time series 216
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 216", Format="int64")]
        public long? ApprovalLevel216 { get; set; }

        ///<summary>
        ///Approval name of output time series 216
        ///</summary>
        [ApiMember(Description="Approval name of output time series 216")]
        public string ApprovalName216 { get; set; }

        ///<summary>
        ///Numeric value of output time series 217
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 217", Format="double")]
        public double? NumericValue217 { get; set; }

        ///<summary>
        ///Display value of output time series 217
        ///</summary>
        [ApiMember(Description="Display value of output time series 217")]
        public string DisplayValue217 { get; set; }

        ///<summary>
        ///Grade code of output time series 217
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 217", Format="int64")]
        public long? GradeCode217 { get; set; }

        ///<summary>
        ///Grade name of output time series 217
        ///</summary>
        [ApiMember(Description="Grade name of output time series 217")]
        public string GradeName217 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 217
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 217")]
        public string Qualifiers217 { get; set; }

        ///<summary>
        ///Method of output time series 217
        ///</summary>
        [ApiMember(Description="Method of output time series 217")]
        public string Method217 { get; set; }

        ///<summary>
        ///Approval level of output time series 217
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 217", Format="int64")]
        public long? ApprovalLevel217 { get; set; }

        ///<summary>
        ///Approval name of output time series 217
        ///</summary>
        [ApiMember(Description="Approval name of output time series 217")]
        public string ApprovalName217 { get; set; }

        ///<summary>
        ///Numeric value of output time series 218
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 218", Format="double")]
        public double? NumericValue218 { get; set; }

        ///<summary>
        ///Display value of output time series 218
        ///</summary>
        [ApiMember(Description="Display value of output time series 218")]
        public string DisplayValue218 { get; set; }

        ///<summary>
        ///Grade code of output time series 218
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 218", Format="int64")]
        public long? GradeCode218 { get; set; }

        ///<summary>
        ///Grade name of output time series 218
        ///</summary>
        [ApiMember(Description="Grade name of output time series 218")]
        public string GradeName218 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 218
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 218")]
        public string Qualifiers218 { get; set; }

        ///<summary>
        ///Method of output time series 218
        ///</summary>
        [ApiMember(Description="Method of output time series 218")]
        public string Method218 { get; set; }

        ///<summary>
        ///Approval level of output time series 218
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 218", Format="int64")]
        public long? ApprovalLevel218 { get; set; }

        ///<summary>
        ///Approval name of output time series 218
        ///</summary>
        [ApiMember(Description="Approval name of output time series 218")]
        public string ApprovalName218 { get; set; }

        ///<summary>
        ///Numeric value of output time series 219
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 219", Format="double")]
        public double? NumericValue219 { get; set; }

        ///<summary>
        ///Display value of output time series 219
        ///</summary>
        [ApiMember(Description="Display value of output time series 219")]
        public string DisplayValue219 { get; set; }

        ///<summary>
        ///Grade code of output time series 219
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 219", Format="int64")]
        public long? GradeCode219 { get; set; }

        ///<summary>
        ///Grade name of output time series 219
        ///</summary>
        [ApiMember(Description="Grade name of output time series 219")]
        public string GradeName219 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 219
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 219")]
        public string Qualifiers219 { get; set; }

        ///<summary>
        ///Method of output time series 219
        ///</summary>
        [ApiMember(Description="Method of output time series 219")]
        public string Method219 { get; set; }

        ///<summary>
        ///Approval level of output time series 219
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 219", Format="int64")]
        public long? ApprovalLevel219 { get; set; }

        ///<summary>
        ///Approval name of output time series 219
        ///</summary>
        [ApiMember(Description="Approval name of output time series 219")]
        public string ApprovalName219 { get; set; }

        ///<summary>
        ///Numeric value of output time series 220
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 220", Format="double")]
        public double? NumericValue220 { get; set; }

        ///<summary>
        ///Display value of output time series 220
        ///</summary>
        [ApiMember(Description="Display value of output time series 220")]
        public string DisplayValue220 { get; set; }

        ///<summary>
        ///Grade code of output time series 220
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 220", Format="int64")]
        public long? GradeCode220 { get; set; }

        ///<summary>
        ///Grade name of output time series 220
        ///</summary>
        [ApiMember(Description="Grade name of output time series 220")]
        public string GradeName220 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 220
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 220")]
        public string Qualifiers220 { get; set; }

        ///<summary>
        ///Method of output time series 220
        ///</summary>
        [ApiMember(Description="Method of output time series 220")]
        public string Method220 { get; set; }

        ///<summary>
        ///Approval level of output time series 220
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 220", Format="int64")]
        public long? ApprovalLevel220 { get; set; }

        ///<summary>
        ///Approval name of output time series 220
        ///</summary>
        [ApiMember(Description="Approval name of output time series 220")]
        public string ApprovalName220 { get; set; }

        ///<summary>
        ///Numeric value of output time series 221
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 221", Format="double")]
        public double? NumericValue221 { get; set; }

        ///<summary>
        ///Display value of output time series 221
        ///</summary>
        [ApiMember(Description="Display value of output time series 221")]
        public string DisplayValue221 { get; set; }

        ///<summary>
        ///Grade code of output time series 221
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 221", Format="int64")]
        public long? GradeCode221 { get; set; }

        ///<summary>
        ///Grade name of output time series 221
        ///</summary>
        [ApiMember(Description="Grade name of output time series 221")]
        public string GradeName221 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 221
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 221")]
        public string Qualifiers221 { get; set; }

        ///<summary>
        ///Method of output time series 221
        ///</summary>
        [ApiMember(Description="Method of output time series 221")]
        public string Method221 { get; set; }

        ///<summary>
        ///Approval level of output time series 221
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 221", Format="int64")]
        public long? ApprovalLevel221 { get; set; }

        ///<summary>
        ///Approval name of output time series 221
        ///</summary>
        [ApiMember(Description="Approval name of output time series 221")]
        public string ApprovalName221 { get; set; }

        ///<summary>
        ///Numeric value of output time series 222
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 222", Format="double")]
        public double? NumericValue222 { get; set; }

        ///<summary>
        ///Display value of output time series 222
        ///</summary>
        [ApiMember(Description="Display value of output time series 222")]
        public string DisplayValue222 { get; set; }

        ///<summary>
        ///Grade code of output time series 222
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 222", Format="int64")]
        public long? GradeCode222 { get; set; }

        ///<summary>
        ///Grade name of output time series 222
        ///</summary>
        [ApiMember(Description="Grade name of output time series 222")]
        public string GradeName222 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 222
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 222")]
        public string Qualifiers222 { get; set; }

        ///<summary>
        ///Method of output time series 222
        ///</summary>
        [ApiMember(Description="Method of output time series 222")]
        public string Method222 { get; set; }

        ///<summary>
        ///Approval level of output time series 222
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 222", Format="int64")]
        public long? ApprovalLevel222 { get; set; }

        ///<summary>
        ///Approval name of output time series 222
        ///</summary>
        [ApiMember(Description="Approval name of output time series 222")]
        public string ApprovalName222 { get; set; }

        ///<summary>
        ///Numeric value of output time series 223
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 223", Format="double")]
        public double? NumericValue223 { get; set; }

        ///<summary>
        ///Display value of output time series 223
        ///</summary>
        [ApiMember(Description="Display value of output time series 223")]
        public string DisplayValue223 { get; set; }

        ///<summary>
        ///Grade code of output time series 223
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 223", Format="int64")]
        public long? GradeCode223 { get; set; }

        ///<summary>
        ///Grade name of output time series 223
        ///</summary>
        [ApiMember(Description="Grade name of output time series 223")]
        public string GradeName223 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 223
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 223")]
        public string Qualifiers223 { get; set; }

        ///<summary>
        ///Method of output time series 223
        ///</summary>
        [ApiMember(Description="Method of output time series 223")]
        public string Method223 { get; set; }

        ///<summary>
        ///Approval level of output time series 223
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 223", Format="int64")]
        public long? ApprovalLevel223 { get; set; }

        ///<summary>
        ///Approval name of output time series 223
        ///</summary>
        [ApiMember(Description="Approval name of output time series 223")]
        public string ApprovalName223 { get; set; }

        ///<summary>
        ///Numeric value of output time series 224
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 224", Format="double")]
        public double? NumericValue224 { get; set; }

        ///<summary>
        ///Display value of output time series 224
        ///</summary>
        [ApiMember(Description="Display value of output time series 224")]
        public string DisplayValue224 { get; set; }

        ///<summary>
        ///Grade code of output time series 224
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 224", Format="int64")]
        public long? GradeCode224 { get; set; }

        ///<summary>
        ///Grade name of output time series 224
        ///</summary>
        [ApiMember(Description="Grade name of output time series 224")]
        public string GradeName224 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 224
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 224")]
        public string Qualifiers224 { get; set; }

        ///<summary>
        ///Method of output time series 224
        ///</summary>
        [ApiMember(Description="Method of output time series 224")]
        public string Method224 { get; set; }

        ///<summary>
        ///Approval level of output time series 224
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 224", Format="int64")]
        public long? ApprovalLevel224 { get; set; }

        ///<summary>
        ///Approval name of output time series 224
        ///</summary>
        [ApiMember(Description="Approval name of output time series 224")]
        public string ApprovalName224 { get; set; }

        ///<summary>
        ///Numeric value of output time series 225
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 225", Format="double")]
        public double? NumericValue225 { get; set; }

        ///<summary>
        ///Display value of output time series 225
        ///</summary>
        [ApiMember(Description="Display value of output time series 225")]
        public string DisplayValue225 { get; set; }

        ///<summary>
        ///Grade code of output time series 225
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 225", Format="int64")]
        public long? GradeCode225 { get; set; }

        ///<summary>
        ///Grade name of output time series 225
        ///</summary>
        [ApiMember(Description="Grade name of output time series 225")]
        public string GradeName225 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 225
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 225")]
        public string Qualifiers225 { get; set; }

        ///<summary>
        ///Method of output time series 225
        ///</summary>
        [ApiMember(Description="Method of output time series 225")]
        public string Method225 { get; set; }

        ///<summary>
        ///Approval level of output time series 225
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 225", Format="int64")]
        public long? ApprovalLevel225 { get; set; }

        ///<summary>
        ///Approval name of output time series 225
        ///</summary>
        [ApiMember(Description="Approval name of output time series 225")]
        public string ApprovalName225 { get; set; }

        ///<summary>
        ///Numeric value of output time series 226
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 226", Format="double")]
        public double? NumericValue226 { get; set; }

        ///<summary>
        ///Display value of output time series 226
        ///</summary>
        [ApiMember(Description="Display value of output time series 226")]
        public string DisplayValue226 { get; set; }

        ///<summary>
        ///Grade code of output time series 226
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 226", Format="int64")]
        public long? GradeCode226 { get; set; }

        ///<summary>
        ///Grade name of output time series 226
        ///</summary>
        [ApiMember(Description="Grade name of output time series 226")]
        public string GradeName226 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 226
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 226")]
        public string Qualifiers226 { get; set; }

        ///<summary>
        ///Method of output time series 226
        ///</summary>
        [ApiMember(Description="Method of output time series 226")]
        public string Method226 { get; set; }

        ///<summary>
        ///Approval level of output time series 226
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 226", Format="int64")]
        public long? ApprovalLevel226 { get; set; }

        ///<summary>
        ///Approval name of output time series 226
        ///</summary>
        [ApiMember(Description="Approval name of output time series 226")]
        public string ApprovalName226 { get; set; }

        ///<summary>
        ///Numeric value of output time series 227
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 227", Format="double")]
        public double? NumericValue227 { get; set; }

        ///<summary>
        ///Display value of output time series 227
        ///</summary>
        [ApiMember(Description="Display value of output time series 227")]
        public string DisplayValue227 { get; set; }

        ///<summary>
        ///Grade code of output time series 227
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 227", Format="int64")]
        public long? GradeCode227 { get; set; }

        ///<summary>
        ///Grade name of output time series 227
        ///</summary>
        [ApiMember(Description="Grade name of output time series 227")]
        public string GradeName227 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 227
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 227")]
        public string Qualifiers227 { get; set; }

        ///<summary>
        ///Method of output time series 227
        ///</summary>
        [ApiMember(Description="Method of output time series 227")]
        public string Method227 { get; set; }

        ///<summary>
        ///Approval level of output time series 227
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 227", Format="int64")]
        public long? ApprovalLevel227 { get; set; }

        ///<summary>
        ///Approval name of output time series 227
        ///</summary>
        [ApiMember(Description="Approval name of output time series 227")]
        public string ApprovalName227 { get; set; }

        ///<summary>
        ///Numeric value of output time series 228
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 228", Format="double")]
        public double? NumericValue228 { get; set; }

        ///<summary>
        ///Display value of output time series 228
        ///</summary>
        [ApiMember(Description="Display value of output time series 228")]
        public string DisplayValue228 { get; set; }

        ///<summary>
        ///Grade code of output time series 228
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 228", Format="int64")]
        public long? GradeCode228 { get; set; }

        ///<summary>
        ///Grade name of output time series 228
        ///</summary>
        [ApiMember(Description="Grade name of output time series 228")]
        public string GradeName228 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 228
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 228")]
        public string Qualifiers228 { get; set; }

        ///<summary>
        ///Method of output time series 228
        ///</summary>
        [ApiMember(Description="Method of output time series 228")]
        public string Method228 { get; set; }

        ///<summary>
        ///Approval level of output time series 228
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 228", Format="int64")]
        public long? ApprovalLevel228 { get; set; }

        ///<summary>
        ///Approval name of output time series 228
        ///</summary>
        [ApiMember(Description="Approval name of output time series 228")]
        public string ApprovalName228 { get; set; }

        ///<summary>
        ///Numeric value of output time series 229
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 229", Format="double")]
        public double? NumericValue229 { get; set; }

        ///<summary>
        ///Display value of output time series 229
        ///</summary>
        [ApiMember(Description="Display value of output time series 229")]
        public string DisplayValue229 { get; set; }

        ///<summary>
        ///Grade code of output time series 229
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 229", Format="int64")]
        public long? GradeCode229 { get; set; }

        ///<summary>
        ///Grade name of output time series 229
        ///</summary>
        [ApiMember(Description="Grade name of output time series 229")]
        public string GradeName229 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 229
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 229")]
        public string Qualifiers229 { get; set; }

        ///<summary>
        ///Method of output time series 229
        ///</summary>
        [ApiMember(Description="Method of output time series 229")]
        public string Method229 { get; set; }

        ///<summary>
        ///Approval level of output time series 229
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 229", Format="int64")]
        public long? ApprovalLevel229 { get; set; }

        ///<summary>
        ///Approval name of output time series 229
        ///</summary>
        [ApiMember(Description="Approval name of output time series 229")]
        public string ApprovalName229 { get; set; }

        ///<summary>
        ///Numeric value of output time series 230
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 230", Format="double")]
        public double? NumericValue230 { get; set; }

        ///<summary>
        ///Display value of output time series 230
        ///</summary>
        [ApiMember(Description="Display value of output time series 230")]
        public string DisplayValue230 { get; set; }

        ///<summary>
        ///Grade code of output time series 230
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 230", Format="int64")]
        public long? GradeCode230 { get; set; }

        ///<summary>
        ///Grade name of output time series 230
        ///</summary>
        [ApiMember(Description="Grade name of output time series 230")]
        public string GradeName230 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 230
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 230")]
        public string Qualifiers230 { get; set; }

        ///<summary>
        ///Method of output time series 230
        ///</summary>
        [ApiMember(Description="Method of output time series 230")]
        public string Method230 { get; set; }

        ///<summary>
        ///Approval level of output time series 230
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 230", Format="int64")]
        public long? ApprovalLevel230 { get; set; }

        ///<summary>
        ///Approval name of output time series 230
        ///</summary>
        [ApiMember(Description="Approval name of output time series 230")]
        public string ApprovalName230 { get; set; }

        ///<summary>
        ///Numeric value of output time series 231
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 231", Format="double")]
        public double? NumericValue231 { get; set; }

        ///<summary>
        ///Display value of output time series 231
        ///</summary>
        [ApiMember(Description="Display value of output time series 231")]
        public string DisplayValue231 { get; set; }

        ///<summary>
        ///Grade code of output time series 231
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 231", Format="int64")]
        public long? GradeCode231 { get; set; }

        ///<summary>
        ///Grade name of output time series 231
        ///</summary>
        [ApiMember(Description="Grade name of output time series 231")]
        public string GradeName231 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 231
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 231")]
        public string Qualifiers231 { get; set; }

        ///<summary>
        ///Method of output time series 231
        ///</summary>
        [ApiMember(Description="Method of output time series 231")]
        public string Method231 { get; set; }

        ///<summary>
        ///Approval level of output time series 231
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 231", Format="int64")]
        public long? ApprovalLevel231 { get; set; }

        ///<summary>
        ///Approval name of output time series 231
        ///</summary>
        [ApiMember(Description="Approval name of output time series 231")]
        public string ApprovalName231 { get; set; }

        ///<summary>
        ///Numeric value of output time series 232
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 232", Format="double")]
        public double? NumericValue232 { get; set; }

        ///<summary>
        ///Display value of output time series 232
        ///</summary>
        [ApiMember(Description="Display value of output time series 232")]
        public string DisplayValue232 { get; set; }

        ///<summary>
        ///Grade code of output time series 232
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 232", Format="int64")]
        public long? GradeCode232 { get; set; }

        ///<summary>
        ///Grade name of output time series 232
        ///</summary>
        [ApiMember(Description="Grade name of output time series 232")]
        public string GradeName232 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 232
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 232")]
        public string Qualifiers232 { get; set; }

        ///<summary>
        ///Method of output time series 232
        ///</summary>
        [ApiMember(Description="Method of output time series 232")]
        public string Method232 { get; set; }

        ///<summary>
        ///Approval level of output time series 232
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 232", Format="int64")]
        public long? ApprovalLevel232 { get; set; }

        ///<summary>
        ///Approval name of output time series 232
        ///</summary>
        [ApiMember(Description="Approval name of output time series 232")]
        public string ApprovalName232 { get; set; }

        ///<summary>
        ///Numeric value of output time series 233
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 233", Format="double")]
        public double? NumericValue233 { get; set; }

        ///<summary>
        ///Display value of output time series 233
        ///</summary>
        [ApiMember(Description="Display value of output time series 233")]
        public string DisplayValue233 { get; set; }

        ///<summary>
        ///Grade code of output time series 233
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 233", Format="int64")]
        public long? GradeCode233 { get; set; }

        ///<summary>
        ///Grade name of output time series 233
        ///</summary>
        [ApiMember(Description="Grade name of output time series 233")]
        public string GradeName233 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 233
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 233")]
        public string Qualifiers233 { get; set; }

        ///<summary>
        ///Method of output time series 233
        ///</summary>
        [ApiMember(Description="Method of output time series 233")]
        public string Method233 { get; set; }

        ///<summary>
        ///Approval level of output time series 233
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 233", Format="int64")]
        public long? ApprovalLevel233 { get; set; }

        ///<summary>
        ///Approval name of output time series 233
        ///</summary>
        [ApiMember(Description="Approval name of output time series 233")]
        public string ApprovalName233 { get; set; }

        ///<summary>
        ///Numeric value of output time series 234
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 234", Format="double")]
        public double? NumericValue234 { get; set; }

        ///<summary>
        ///Display value of output time series 234
        ///</summary>
        [ApiMember(Description="Display value of output time series 234")]
        public string DisplayValue234 { get; set; }

        ///<summary>
        ///Grade code of output time series 234
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 234", Format="int64")]
        public long? GradeCode234 { get; set; }

        ///<summary>
        ///Grade name of output time series 234
        ///</summary>
        [ApiMember(Description="Grade name of output time series 234")]
        public string GradeName234 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 234
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 234")]
        public string Qualifiers234 { get; set; }

        ///<summary>
        ///Method of output time series 234
        ///</summary>
        [ApiMember(Description="Method of output time series 234")]
        public string Method234 { get; set; }

        ///<summary>
        ///Approval level of output time series 234
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 234", Format="int64")]
        public long? ApprovalLevel234 { get; set; }

        ///<summary>
        ///Approval name of output time series 234
        ///</summary>
        [ApiMember(Description="Approval name of output time series 234")]
        public string ApprovalName234 { get; set; }

        ///<summary>
        ///Numeric value of output time series 235
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 235", Format="double")]
        public double? NumericValue235 { get; set; }

        ///<summary>
        ///Display value of output time series 235
        ///</summary>
        [ApiMember(Description="Display value of output time series 235")]
        public string DisplayValue235 { get; set; }

        ///<summary>
        ///Grade code of output time series 235
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 235", Format="int64")]
        public long? GradeCode235 { get; set; }

        ///<summary>
        ///Grade name of output time series 235
        ///</summary>
        [ApiMember(Description="Grade name of output time series 235")]
        public string GradeName235 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 235
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 235")]
        public string Qualifiers235 { get; set; }

        ///<summary>
        ///Method of output time series 235
        ///</summary>
        [ApiMember(Description="Method of output time series 235")]
        public string Method235 { get; set; }

        ///<summary>
        ///Approval level of output time series 235
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 235", Format="int64")]
        public long? ApprovalLevel235 { get; set; }

        ///<summary>
        ///Approval name of output time series 235
        ///</summary>
        [ApiMember(Description="Approval name of output time series 235")]
        public string ApprovalName235 { get; set; }

        ///<summary>
        ///Numeric value of output time series 236
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 236", Format="double")]
        public double? NumericValue236 { get; set; }

        ///<summary>
        ///Display value of output time series 236
        ///</summary>
        [ApiMember(Description="Display value of output time series 236")]
        public string DisplayValue236 { get; set; }

        ///<summary>
        ///Grade code of output time series 236
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 236", Format="int64")]
        public long? GradeCode236 { get; set; }

        ///<summary>
        ///Grade name of output time series 236
        ///</summary>
        [ApiMember(Description="Grade name of output time series 236")]
        public string GradeName236 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 236
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 236")]
        public string Qualifiers236 { get; set; }

        ///<summary>
        ///Method of output time series 236
        ///</summary>
        [ApiMember(Description="Method of output time series 236")]
        public string Method236 { get; set; }

        ///<summary>
        ///Approval level of output time series 236
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 236", Format="int64")]
        public long? ApprovalLevel236 { get; set; }

        ///<summary>
        ///Approval name of output time series 236
        ///</summary>
        [ApiMember(Description="Approval name of output time series 236")]
        public string ApprovalName236 { get; set; }

        ///<summary>
        ///Numeric value of output time series 237
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 237", Format="double")]
        public double? NumericValue237 { get; set; }

        ///<summary>
        ///Display value of output time series 237
        ///</summary>
        [ApiMember(Description="Display value of output time series 237")]
        public string DisplayValue237 { get; set; }

        ///<summary>
        ///Grade code of output time series 237
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 237", Format="int64")]
        public long? GradeCode237 { get; set; }

        ///<summary>
        ///Grade name of output time series 237
        ///</summary>
        [ApiMember(Description="Grade name of output time series 237")]
        public string GradeName237 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 237
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 237")]
        public string Qualifiers237 { get; set; }

        ///<summary>
        ///Method of output time series 237
        ///</summary>
        [ApiMember(Description="Method of output time series 237")]
        public string Method237 { get; set; }

        ///<summary>
        ///Approval level of output time series 237
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 237", Format="int64")]
        public long? ApprovalLevel237 { get; set; }

        ///<summary>
        ///Approval name of output time series 237
        ///</summary>
        [ApiMember(Description="Approval name of output time series 237")]
        public string ApprovalName237 { get; set; }

        ///<summary>
        ///Numeric value of output time series 238
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 238", Format="double")]
        public double? NumericValue238 { get; set; }

        ///<summary>
        ///Display value of output time series 238
        ///</summary>
        [ApiMember(Description="Display value of output time series 238")]
        public string DisplayValue238 { get; set; }

        ///<summary>
        ///Grade code of output time series 238
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 238", Format="int64")]
        public long? GradeCode238 { get; set; }

        ///<summary>
        ///Grade name of output time series 238
        ///</summary>
        [ApiMember(Description="Grade name of output time series 238")]
        public string GradeName238 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 238
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 238")]
        public string Qualifiers238 { get; set; }

        ///<summary>
        ///Method of output time series 238
        ///</summary>
        [ApiMember(Description="Method of output time series 238")]
        public string Method238 { get; set; }

        ///<summary>
        ///Approval level of output time series 238
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 238", Format="int64")]
        public long? ApprovalLevel238 { get; set; }

        ///<summary>
        ///Approval name of output time series 238
        ///</summary>
        [ApiMember(Description="Approval name of output time series 238")]
        public string ApprovalName238 { get; set; }

        ///<summary>
        ///Numeric value of output time series 239
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 239", Format="double")]
        public double? NumericValue239 { get; set; }

        ///<summary>
        ///Display value of output time series 239
        ///</summary>
        [ApiMember(Description="Display value of output time series 239")]
        public string DisplayValue239 { get; set; }

        ///<summary>
        ///Grade code of output time series 239
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 239", Format="int64")]
        public long? GradeCode239 { get; set; }

        ///<summary>
        ///Grade name of output time series 239
        ///</summary>
        [ApiMember(Description="Grade name of output time series 239")]
        public string GradeName239 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 239
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 239")]
        public string Qualifiers239 { get; set; }

        ///<summary>
        ///Method of output time series 239
        ///</summary>
        [ApiMember(Description="Method of output time series 239")]
        public string Method239 { get; set; }

        ///<summary>
        ///Approval level of output time series 239
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 239", Format="int64")]
        public long? ApprovalLevel239 { get; set; }

        ///<summary>
        ///Approval name of output time series 239
        ///</summary>
        [ApiMember(Description="Approval name of output time series 239")]
        public string ApprovalName239 { get; set; }

        ///<summary>
        ///Numeric value of output time series 240
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 240", Format="double")]
        public double? NumericValue240 { get; set; }

        ///<summary>
        ///Display value of output time series 240
        ///</summary>
        [ApiMember(Description="Display value of output time series 240")]
        public string DisplayValue240 { get; set; }

        ///<summary>
        ///Grade code of output time series 240
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 240", Format="int64")]
        public long? GradeCode240 { get; set; }

        ///<summary>
        ///Grade name of output time series 240
        ///</summary>
        [ApiMember(Description="Grade name of output time series 240")]
        public string GradeName240 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 240
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 240")]
        public string Qualifiers240 { get; set; }

        ///<summary>
        ///Method of output time series 240
        ///</summary>
        [ApiMember(Description="Method of output time series 240")]
        public string Method240 { get; set; }

        ///<summary>
        ///Approval level of output time series 240
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 240", Format="int64")]
        public long? ApprovalLevel240 { get; set; }

        ///<summary>
        ///Approval name of output time series 240
        ///</summary>
        [ApiMember(Description="Approval name of output time series 240")]
        public string ApprovalName240 { get; set; }

        ///<summary>
        ///Numeric value of output time series 241
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 241", Format="double")]
        public double? NumericValue241 { get; set; }

        ///<summary>
        ///Display value of output time series 241
        ///</summary>
        [ApiMember(Description="Display value of output time series 241")]
        public string DisplayValue241 { get; set; }

        ///<summary>
        ///Grade code of output time series 241
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 241", Format="int64")]
        public long? GradeCode241 { get; set; }

        ///<summary>
        ///Grade name of output time series 241
        ///</summary>
        [ApiMember(Description="Grade name of output time series 241")]
        public string GradeName241 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 241
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 241")]
        public string Qualifiers241 { get; set; }

        ///<summary>
        ///Method of output time series 241
        ///</summary>
        [ApiMember(Description="Method of output time series 241")]
        public string Method241 { get; set; }

        ///<summary>
        ///Approval level of output time series 241
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 241", Format="int64")]
        public long? ApprovalLevel241 { get; set; }

        ///<summary>
        ///Approval name of output time series 241
        ///</summary>
        [ApiMember(Description="Approval name of output time series 241")]
        public string ApprovalName241 { get; set; }

        ///<summary>
        ///Numeric value of output time series 242
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 242", Format="double")]
        public double? NumericValue242 { get; set; }

        ///<summary>
        ///Display value of output time series 242
        ///</summary>
        [ApiMember(Description="Display value of output time series 242")]
        public string DisplayValue242 { get; set; }

        ///<summary>
        ///Grade code of output time series 242
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 242", Format="int64")]
        public long? GradeCode242 { get; set; }

        ///<summary>
        ///Grade name of output time series 242
        ///</summary>
        [ApiMember(Description="Grade name of output time series 242")]
        public string GradeName242 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 242
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 242")]
        public string Qualifiers242 { get; set; }

        ///<summary>
        ///Method of output time series 242
        ///</summary>
        [ApiMember(Description="Method of output time series 242")]
        public string Method242 { get; set; }

        ///<summary>
        ///Approval level of output time series 242
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 242", Format="int64")]
        public long? ApprovalLevel242 { get; set; }

        ///<summary>
        ///Approval name of output time series 242
        ///</summary>
        [ApiMember(Description="Approval name of output time series 242")]
        public string ApprovalName242 { get; set; }

        ///<summary>
        ///Numeric value of output time series 243
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 243", Format="double")]
        public double? NumericValue243 { get; set; }

        ///<summary>
        ///Display value of output time series 243
        ///</summary>
        [ApiMember(Description="Display value of output time series 243")]
        public string DisplayValue243 { get; set; }

        ///<summary>
        ///Grade code of output time series 243
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 243", Format="int64")]
        public long? GradeCode243 { get; set; }

        ///<summary>
        ///Grade name of output time series 243
        ///</summary>
        [ApiMember(Description="Grade name of output time series 243")]
        public string GradeName243 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 243
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 243")]
        public string Qualifiers243 { get; set; }

        ///<summary>
        ///Method of output time series 243
        ///</summary>
        [ApiMember(Description="Method of output time series 243")]
        public string Method243 { get; set; }

        ///<summary>
        ///Approval level of output time series 243
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 243", Format="int64")]
        public long? ApprovalLevel243 { get; set; }

        ///<summary>
        ///Approval name of output time series 243
        ///</summary>
        [ApiMember(Description="Approval name of output time series 243")]
        public string ApprovalName243 { get; set; }

        ///<summary>
        ///Numeric value of output time series 244
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 244", Format="double")]
        public double? NumericValue244 { get; set; }

        ///<summary>
        ///Display value of output time series 244
        ///</summary>
        [ApiMember(Description="Display value of output time series 244")]
        public string DisplayValue244 { get; set; }

        ///<summary>
        ///Grade code of output time series 244
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 244", Format="int64")]
        public long? GradeCode244 { get; set; }

        ///<summary>
        ///Grade name of output time series 244
        ///</summary>
        [ApiMember(Description="Grade name of output time series 244")]
        public string GradeName244 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 244
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 244")]
        public string Qualifiers244 { get; set; }

        ///<summary>
        ///Method of output time series 244
        ///</summary>
        [ApiMember(Description="Method of output time series 244")]
        public string Method244 { get; set; }

        ///<summary>
        ///Approval level of output time series 244
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 244", Format="int64")]
        public long? ApprovalLevel244 { get; set; }

        ///<summary>
        ///Approval name of output time series 244
        ///</summary>
        [ApiMember(Description="Approval name of output time series 244")]
        public string ApprovalName244 { get; set; }

        ///<summary>
        ///Numeric value of output time series 245
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 245", Format="double")]
        public double? NumericValue245 { get; set; }

        ///<summary>
        ///Display value of output time series 245
        ///</summary>
        [ApiMember(Description="Display value of output time series 245")]
        public string DisplayValue245 { get; set; }

        ///<summary>
        ///Grade code of output time series 245
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 245", Format="int64")]
        public long? GradeCode245 { get; set; }

        ///<summary>
        ///Grade name of output time series 245
        ///</summary>
        [ApiMember(Description="Grade name of output time series 245")]
        public string GradeName245 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 245
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 245")]
        public string Qualifiers245 { get; set; }

        ///<summary>
        ///Method of output time series 245
        ///</summary>
        [ApiMember(Description="Method of output time series 245")]
        public string Method245 { get; set; }

        ///<summary>
        ///Approval level of output time series 245
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 245", Format="int64")]
        public long? ApprovalLevel245 { get; set; }

        ///<summary>
        ///Approval name of output time series 245
        ///</summary>
        [ApiMember(Description="Approval name of output time series 245")]
        public string ApprovalName245 { get; set; }

        ///<summary>
        ///Numeric value of output time series 246
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 246", Format="double")]
        public double? NumericValue246 { get; set; }

        ///<summary>
        ///Display value of output time series 246
        ///</summary>
        [ApiMember(Description="Display value of output time series 246")]
        public string DisplayValue246 { get; set; }

        ///<summary>
        ///Grade code of output time series 246
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 246", Format="int64")]
        public long? GradeCode246 { get; set; }

        ///<summary>
        ///Grade name of output time series 246
        ///</summary>
        [ApiMember(Description="Grade name of output time series 246")]
        public string GradeName246 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 246
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 246")]
        public string Qualifiers246 { get; set; }

        ///<summary>
        ///Method of output time series 246
        ///</summary>
        [ApiMember(Description="Method of output time series 246")]
        public string Method246 { get; set; }

        ///<summary>
        ///Approval level of output time series 246
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 246", Format="int64")]
        public long? ApprovalLevel246 { get; set; }

        ///<summary>
        ///Approval name of output time series 246
        ///</summary>
        [ApiMember(Description="Approval name of output time series 246")]
        public string ApprovalName246 { get; set; }

        ///<summary>
        ///Numeric value of output time series 247
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 247", Format="double")]
        public double? NumericValue247 { get; set; }

        ///<summary>
        ///Display value of output time series 247
        ///</summary>
        [ApiMember(Description="Display value of output time series 247")]
        public string DisplayValue247 { get; set; }

        ///<summary>
        ///Grade code of output time series 247
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 247", Format="int64")]
        public long? GradeCode247 { get; set; }

        ///<summary>
        ///Grade name of output time series 247
        ///</summary>
        [ApiMember(Description="Grade name of output time series 247")]
        public string GradeName247 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 247
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 247")]
        public string Qualifiers247 { get; set; }

        ///<summary>
        ///Method of output time series 247
        ///</summary>
        [ApiMember(Description="Method of output time series 247")]
        public string Method247 { get; set; }

        ///<summary>
        ///Approval level of output time series 247
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 247", Format="int64")]
        public long? ApprovalLevel247 { get; set; }

        ///<summary>
        ///Approval name of output time series 247
        ///</summary>
        [ApiMember(Description="Approval name of output time series 247")]
        public string ApprovalName247 { get; set; }

        ///<summary>
        ///Numeric value of output time series 248
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 248", Format="double")]
        public double? NumericValue248 { get; set; }

        ///<summary>
        ///Display value of output time series 248
        ///</summary>
        [ApiMember(Description="Display value of output time series 248")]
        public string DisplayValue248 { get; set; }

        ///<summary>
        ///Grade code of output time series 248
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 248", Format="int64")]
        public long? GradeCode248 { get; set; }

        ///<summary>
        ///Grade name of output time series 248
        ///</summary>
        [ApiMember(Description="Grade name of output time series 248")]
        public string GradeName248 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 248
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 248")]
        public string Qualifiers248 { get; set; }

        ///<summary>
        ///Method of output time series 248
        ///</summary>
        [ApiMember(Description="Method of output time series 248")]
        public string Method248 { get; set; }

        ///<summary>
        ///Approval level of output time series 248
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 248", Format="int64")]
        public long? ApprovalLevel248 { get; set; }

        ///<summary>
        ///Approval name of output time series 248
        ///</summary>
        [ApiMember(Description="Approval name of output time series 248")]
        public string ApprovalName248 { get; set; }

        ///<summary>
        ///Numeric value of output time series 249
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 249", Format="double")]
        public double? NumericValue249 { get; set; }

        ///<summary>
        ///Display value of output time series 249
        ///</summary>
        [ApiMember(Description="Display value of output time series 249")]
        public string DisplayValue249 { get; set; }

        ///<summary>
        ///Grade code of output time series 249
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 249", Format="int64")]
        public long? GradeCode249 { get; set; }

        ///<summary>
        ///Grade name of output time series 249
        ///</summary>
        [ApiMember(Description="Grade name of output time series 249")]
        public string GradeName249 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 249
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 249")]
        public string Qualifiers249 { get; set; }

        ///<summary>
        ///Method of output time series 249
        ///</summary>
        [ApiMember(Description="Method of output time series 249")]
        public string Method249 { get; set; }

        ///<summary>
        ///Approval level of output time series 249
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 249", Format="int64")]
        public long? ApprovalLevel249 { get; set; }

        ///<summary>
        ///Approval name of output time series 249
        ///</summary>
        [ApiMember(Description="Approval name of output time series 249")]
        public string ApprovalName249 { get; set; }

        ///<summary>
        ///Numeric value of output time series 250
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 250", Format="double")]
        public double? NumericValue250 { get; set; }

        ///<summary>
        ///Display value of output time series 250
        ///</summary>
        [ApiMember(Description="Display value of output time series 250")]
        public string DisplayValue250 { get; set; }

        ///<summary>
        ///Grade code of output time series 250
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 250", Format="int64")]
        public long? GradeCode250 { get; set; }

        ///<summary>
        ///Grade name of output time series 250
        ///</summary>
        [ApiMember(Description="Grade name of output time series 250")]
        public string GradeName250 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 250
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 250")]
        public string Qualifiers250 { get; set; }

        ///<summary>
        ///Method of output time series 250
        ///</summary>
        [ApiMember(Description="Method of output time series 250")]
        public string Method250 { get; set; }

        ///<summary>
        ///Approval level of output time series 250
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 250", Format="int64")]
        public long? ApprovalLevel250 { get; set; }

        ///<summary>
        ///Approval name of output time series 250
        ///</summary>
        [ApiMember(Description="Approval name of output time series 250")]
        public string ApprovalName250 { get; set; }

        ///<summary>
        ///Numeric value of output time series 251
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 251", Format="double")]
        public double? NumericValue251 { get; set; }

        ///<summary>
        ///Display value of output time series 251
        ///</summary>
        [ApiMember(Description="Display value of output time series 251")]
        public string DisplayValue251 { get; set; }

        ///<summary>
        ///Grade code of output time series 251
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 251", Format="int64")]
        public long? GradeCode251 { get; set; }

        ///<summary>
        ///Grade name of output time series 251
        ///</summary>
        [ApiMember(Description="Grade name of output time series 251")]
        public string GradeName251 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 251
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 251")]
        public string Qualifiers251 { get; set; }

        ///<summary>
        ///Method of output time series 251
        ///</summary>
        [ApiMember(Description="Method of output time series 251")]
        public string Method251 { get; set; }

        ///<summary>
        ///Approval level of output time series 251
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 251", Format="int64")]
        public long? ApprovalLevel251 { get; set; }

        ///<summary>
        ///Approval name of output time series 251
        ///</summary>
        [ApiMember(Description="Approval name of output time series 251")]
        public string ApprovalName251 { get; set; }

        ///<summary>
        ///Numeric value of output time series 252
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 252", Format="double")]
        public double? NumericValue252 { get; set; }

        ///<summary>
        ///Display value of output time series 252
        ///</summary>
        [ApiMember(Description="Display value of output time series 252")]
        public string DisplayValue252 { get; set; }

        ///<summary>
        ///Grade code of output time series 252
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 252", Format="int64")]
        public long? GradeCode252 { get; set; }

        ///<summary>
        ///Grade name of output time series 252
        ///</summary>
        [ApiMember(Description="Grade name of output time series 252")]
        public string GradeName252 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 252
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 252")]
        public string Qualifiers252 { get; set; }

        ///<summary>
        ///Method of output time series 252
        ///</summary>
        [ApiMember(Description="Method of output time series 252")]
        public string Method252 { get; set; }

        ///<summary>
        ///Approval level of output time series 252
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 252", Format="int64")]
        public long? ApprovalLevel252 { get; set; }

        ///<summary>
        ///Approval name of output time series 252
        ///</summary>
        [ApiMember(Description="Approval name of output time series 252")]
        public string ApprovalName252 { get; set; }

        ///<summary>
        ///Numeric value of output time series 253
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 253", Format="double")]
        public double? NumericValue253 { get; set; }

        ///<summary>
        ///Display value of output time series 253
        ///</summary>
        [ApiMember(Description="Display value of output time series 253")]
        public string DisplayValue253 { get; set; }

        ///<summary>
        ///Grade code of output time series 253
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 253", Format="int64")]
        public long? GradeCode253 { get; set; }

        ///<summary>
        ///Grade name of output time series 253
        ///</summary>
        [ApiMember(Description="Grade name of output time series 253")]
        public string GradeName253 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 253
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 253")]
        public string Qualifiers253 { get; set; }

        ///<summary>
        ///Method of output time series 253
        ///</summary>
        [ApiMember(Description="Method of output time series 253")]
        public string Method253 { get; set; }

        ///<summary>
        ///Approval level of output time series 253
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 253", Format="int64")]
        public long? ApprovalLevel253 { get; set; }

        ///<summary>
        ///Approval name of output time series 253
        ///</summary>
        [ApiMember(Description="Approval name of output time series 253")]
        public string ApprovalName253 { get; set; }

        ///<summary>
        ///Numeric value of output time series 254
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 254", Format="double")]
        public double? NumericValue254 { get; set; }

        ///<summary>
        ///Display value of output time series 254
        ///</summary>
        [ApiMember(Description="Display value of output time series 254")]
        public string DisplayValue254 { get; set; }

        ///<summary>
        ///Grade code of output time series 254
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 254", Format="int64")]
        public long? GradeCode254 { get; set; }

        ///<summary>
        ///Grade name of output time series 254
        ///</summary>
        [ApiMember(Description="Grade name of output time series 254")]
        public string GradeName254 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 254
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 254")]
        public string Qualifiers254 { get; set; }

        ///<summary>
        ///Method of output time series 254
        ///</summary>
        [ApiMember(Description="Method of output time series 254")]
        public string Method254 { get; set; }

        ///<summary>
        ///Approval level of output time series 254
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 254", Format="int64")]
        public long? ApprovalLevel254 { get; set; }

        ///<summary>
        ///Approval name of output time series 254
        ///</summary>
        [ApiMember(Description="Approval name of output time series 254")]
        public string ApprovalName254 { get; set; }

        ///<summary>
        ///Numeric value of output time series 255
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 255", Format="double")]
        public double? NumericValue255 { get; set; }

        ///<summary>
        ///Display value of output time series 255
        ///</summary>
        [ApiMember(Description="Display value of output time series 255")]
        public string DisplayValue255 { get; set; }

        ///<summary>
        ///Grade code of output time series 255
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 255", Format="int64")]
        public long? GradeCode255 { get; set; }

        ///<summary>
        ///Grade name of output time series 255
        ///</summary>
        [ApiMember(Description="Grade name of output time series 255")]
        public string GradeName255 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 255
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 255")]
        public string Qualifiers255 { get; set; }

        ///<summary>
        ///Method of output time series 255
        ///</summary>
        [ApiMember(Description="Method of output time series 255")]
        public string Method255 { get; set; }

        ///<summary>
        ///Approval level of output time series 255
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 255", Format="int64")]
        public long? ApprovalLevel255 { get; set; }

        ///<summary>
        ///Approval name of output time series 255
        ///</summary>
        [ApiMember(Description="Approval name of output time series 255")]
        public string ApprovalName255 { get; set; }

        ///<summary>
        ///Numeric value of output time series 256
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 256", Format="double")]
        public double? NumericValue256 { get; set; }

        ///<summary>
        ///Display value of output time series 256
        ///</summary>
        [ApiMember(Description="Display value of output time series 256")]
        public string DisplayValue256 { get; set; }

        ///<summary>
        ///Grade code of output time series 256
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 256", Format="int64")]
        public long? GradeCode256 { get; set; }

        ///<summary>
        ///Grade name of output time series 256
        ///</summary>
        [ApiMember(Description="Grade name of output time series 256")]
        public string GradeName256 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 256
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 256")]
        public string Qualifiers256 { get; set; }

        ///<summary>
        ///Method of output time series 256
        ///</summary>
        [ApiMember(Description="Method of output time series 256")]
        public string Method256 { get; set; }

        ///<summary>
        ///Approval level of output time series 256
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 256", Format="int64")]
        public long? ApprovalLevel256 { get; set; }

        ///<summary>
        ///Approval name of output time series 256
        ///</summary>
        [ApiMember(Description="Approval name of output time series 256")]
        public string ApprovalName256 { get; set; }

        ///<summary>
        ///Numeric value of output time series 257
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 257", Format="double")]
        public double? NumericValue257 { get; set; }

        ///<summary>
        ///Display value of output time series 257
        ///</summary>
        [ApiMember(Description="Display value of output time series 257")]
        public string DisplayValue257 { get; set; }

        ///<summary>
        ///Grade code of output time series 257
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 257", Format="int64")]
        public long? GradeCode257 { get; set; }

        ///<summary>
        ///Grade name of output time series 257
        ///</summary>
        [ApiMember(Description="Grade name of output time series 257")]
        public string GradeName257 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 257
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 257")]
        public string Qualifiers257 { get; set; }

        ///<summary>
        ///Method of output time series 257
        ///</summary>
        [ApiMember(Description="Method of output time series 257")]
        public string Method257 { get; set; }

        ///<summary>
        ///Approval level of output time series 257
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 257", Format="int64")]
        public long? ApprovalLevel257 { get; set; }

        ///<summary>
        ///Approval name of output time series 257
        ///</summary>
        [ApiMember(Description="Approval name of output time series 257")]
        public string ApprovalName257 { get; set; }

        ///<summary>
        ///Numeric value of output time series 258
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 258", Format="double")]
        public double? NumericValue258 { get; set; }

        ///<summary>
        ///Display value of output time series 258
        ///</summary>
        [ApiMember(Description="Display value of output time series 258")]
        public string DisplayValue258 { get; set; }

        ///<summary>
        ///Grade code of output time series 258
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 258", Format="int64")]
        public long? GradeCode258 { get; set; }

        ///<summary>
        ///Grade name of output time series 258
        ///</summary>
        [ApiMember(Description="Grade name of output time series 258")]
        public string GradeName258 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 258
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 258")]
        public string Qualifiers258 { get; set; }

        ///<summary>
        ///Method of output time series 258
        ///</summary>
        [ApiMember(Description="Method of output time series 258")]
        public string Method258 { get; set; }

        ///<summary>
        ///Approval level of output time series 258
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 258", Format="int64")]
        public long? ApprovalLevel258 { get; set; }

        ///<summary>
        ///Approval name of output time series 258
        ///</summary>
        [ApiMember(Description="Approval name of output time series 258")]
        public string ApprovalName258 { get; set; }

        ///<summary>
        ///Numeric value of output time series 259
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 259", Format="double")]
        public double? NumericValue259 { get; set; }

        ///<summary>
        ///Display value of output time series 259
        ///</summary>
        [ApiMember(Description="Display value of output time series 259")]
        public string DisplayValue259 { get; set; }

        ///<summary>
        ///Grade code of output time series 259
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 259", Format="int64")]
        public long? GradeCode259 { get; set; }

        ///<summary>
        ///Grade name of output time series 259
        ///</summary>
        [ApiMember(Description="Grade name of output time series 259")]
        public string GradeName259 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 259
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 259")]
        public string Qualifiers259 { get; set; }

        ///<summary>
        ///Method of output time series 259
        ///</summary>
        [ApiMember(Description="Method of output time series 259")]
        public string Method259 { get; set; }

        ///<summary>
        ///Approval level of output time series 259
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 259", Format="int64")]
        public long? ApprovalLevel259 { get; set; }

        ///<summary>
        ///Approval name of output time series 259
        ///</summary>
        [ApiMember(Description="Approval name of output time series 259")]
        public string ApprovalName259 { get; set; }

        ///<summary>
        ///Numeric value of output time series 260
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 260", Format="double")]
        public double? NumericValue260 { get; set; }

        ///<summary>
        ///Display value of output time series 260
        ///</summary>
        [ApiMember(Description="Display value of output time series 260")]
        public string DisplayValue260 { get; set; }

        ///<summary>
        ///Grade code of output time series 260
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 260", Format="int64")]
        public long? GradeCode260 { get; set; }

        ///<summary>
        ///Grade name of output time series 260
        ///</summary>
        [ApiMember(Description="Grade name of output time series 260")]
        public string GradeName260 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 260
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 260")]
        public string Qualifiers260 { get; set; }

        ///<summary>
        ///Method of output time series 260
        ///</summary>
        [ApiMember(Description="Method of output time series 260")]
        public string Method260 { get; set; }

        ///<summary>
        ///Approval level of output time series 260
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 260", Format="int64")]
        public long? ApprovalLevel260 { get; set; }

        ///<summary>
        ///Approval name of output time series 260
        ///</summary>
        [ApiMember(Description="Approval name of output time series 260")]
        public string ApprovalName260 { get; set; }

        ///<summary>
        ///Numeric value of output time series 261
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 261", Format="double")]
        public double? NumericValue261 { get; set; }

        ///<summary>
        ///Display value of output time series 261
        ///</summary>
        [ApiMember(Description="Display value of output time series 261")]
        public string DisplayValue261 { get; set; }

        ///<summary>
        ///Grade code of output time series 261
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 261", Format="int64")]
        public long? GradeCode261 { get; set; }

        ///<summary>
        ///Grade name of output time series 261
        ///</summary>
        [ApiMember(Description="Grade name of output time series 261")]
        public string GradeName261 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 261
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 261")]
        public string Qualifiers261 { get; set; }

        ///<summary>
        ///Method of output time series 261
        ///</summary>
        [ApiMember(Description="Method of output time series 261")]
        public string Method261 { get; set; }

        ///<summary>
        ///Approval level of output time series 261
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 261", Format="int64")]
        public long? ApprovalLevel261 { get; set; }

        ///<summary>
        ///Approval name of output time series 261
        ///</summary>
        [ApiMember(Description="Approval name of output time series 261")]
        public string ApprovalName261 { get; set; }

        ///<summary>
        ///Numeric value of output time series 262
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 262", Format="double")]
        public double? NumericValue262 { get; set; }

        ///<summary>
        ///Display value of output time series 262
        ///</summary>
        [ApiMember(Description="Display value of output time series 262")]
        public string DisplayValue262 { get; set; }

        ///<summary>
        ///Grade code of output time series 262
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 262", Format="int64")]
        public long? GradeCode262 { get; set; }

        ///<summary>
        ///Grade name of output time series 262
        ///</summary>
        [ApiMember(Description="Grade name of output time series 262")]
        public string GradeName262 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 262
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 262")]
        public string Qualifiers262 { get; set; }

        ///<summary>
        ///Method of output time series 262
        ///</summary>
        [ApiMember(Description="Method of output time series 262")]
        public string Method262 { get; set; }

        ///<summary>
        ///Approval level of output time series 262
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 262", Format="int64")]
        public long? ApprovalLevel262 { get; set; }

        ///<summary>
        ///Approval name of output time series 262
        ///</summary>
        [ApiMember(Description="Approval name of output time series 262")]
        public string ApprovalName262 { get; set; }

        ///<summary>
        ///Numeric value of output time series 263
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 263", Format="double")]
        public double? NumericValue263 { get; set; }

        ///<summary>
        ///Display value of output time series 263
        ///</summary>
        [ApiMember(Description="Display value of output time series 263")]
        public string DisplayValue263 { get; set; }

        ///<summary>
        ///Grade code of output time series 263
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 263", Format="int64")]
        public long? GradeCode263 { get; set; }

        ///<summary>
        ///Grade name of output time series 263
        ///</summary>
        [ApiMember(Description="Grade name of output time series 263")]
        public string GradeName263 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 263
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 263")]
        public string Qualifiers263 { get; set; }

        ///<summary>
        ///Method of output time series 263
        ///</summary>
        [ApiMember(Description="Method of output time series 263")]
        public string Method263 { get; set; }

        ///<summary>
        ///Approval level of output time series 263
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 263", Format="int64")]
        public long? ApprovalLevel263 { get; set; }

        ///<summary>
        ///Approval name of output time series 263
        ///</summary>
        [ApiMember(Description="Approval name of output time series 263")]
        public string ApprovalName263 { get; set; }

        ///<summary>
        ///Numeric value of output time series 264
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 264", Format="double")]
        public double? NumericValue264 { get; set; }

        ///<summary>
        ///Display value of output time series 264
        ///</summary>
        [ApiMember(Description="Display value of output time series 264")]
        public string DisplayValue264 { get; set; }

        ///<summary>
        ///Grade code of output time series 264
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 264", Format="int64")]
        public long? GradeCode264 { get; set; }

        ///<summary>
        ///Grade name of output time series 264
        ///</summary>
        [ApiMember(Description="Grade name of output time series 264")]
        public string GradeName264 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 264
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 264")]
        public string Qualifiers264 { get; set; }

        ///<summary>
        ///Method of output time series 264
        ///</summary>
        [ApiMember(Description="Method of output time series 264")]
        public string Method264 { get; set; }

        ///<summary>
        ///Approval level of output time series 264
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 264", Format="int64")]
        public long? ApprovalLevel264 { get; set; }

        ///<summary>
        ///Approval name of output time series 264
        ///</summary>
        [ApiMember(Description="Approval name of output time series 264")]
        public string ApprovalName264 { get; set; }

        ///<summary>
        ///Numeric value of output time series 265
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 265", Format="double")]
        public double? NumericValue265 { get; set; }

        ///<summary>
        ///Display value of output time series 265
        ///</summary>
        [ApiMember(Description="Display value of output time series 265")]
        public string DisplayValue265 { get; set; }

        ///<summary>
        ///Grade code of output time series 265
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 265", Format="int64")]
        public long? GradeCode265 { get; set; }

        ///<summary>
        ///Grade name of output time series 265
        ///</summary>
        [ApiMember(Description="Grade name of output time series 265")]
        public string GradeName265 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 265
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 265")]
        public string Qualifiers265 { get; set; }

        ///<summary>
        ///Method of output time series 265
        ///</summary>
        [ApiMember(Description="Method of output time series 265")]
        public string Method265 { get; set; }

        ///<summary>
        ///Approval level of output time series 265
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 265", Format="int64")]
        public long? ApprovalLevel265 { get; set; }

        ///<summary>
        ///Approval name of output time series 265
        ///</summary>
        [ApiMember(Description="Approval name of output time series 265")]
        public string ApprovalName265 { get; set; }

        ///<summary>
        ///Numeric value of output time series 266
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 266", Format="double")]
        public double? NumericValue266 { get; set; }

        ///<summary>
        ///Display value of output time series 266
        ///</summary>
        [ApiMember(Description="Display value of output time series 266")]
        public string DisplayValue266 { get; set; }

        ///<summary>
        ///Grade code of output time series 266
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 266", Format="int64")]
        public long? GradeCode266 { get; set; }

        ///<summary>
        ///Grade name of output time series 266
        ///</summary>
        [ApiMember(Description="Grade name of output time series 266")]
        public string GradeName266 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 266
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 266")]
        public string Qualifiers266 { get; set; }

        ///<summary>
        ///Method of output time series 266
        ///</summary>
        [ApiMember(Description="Method of output time series 266")]
        public string Method266 { get; set; }

        ///<summary>
        ///Approval level of output time series 266
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 266", Format="int64")]
        public long? ApprovalLevel266 { get; set; }

        ///<summary>
        ///Approval name of output time series 266
        ///</summary>
        [ApiMember(Description="Approval name of output time series 266")]
        public string ApprovalName266 { get; set; }

        ///<summary>
        ///Numeric value of output time series 267
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 267", Format="double")]
        public double? NumericValue267 { get; set; }

        ///<summary>
        ///Display value of output time series 267
        ///</summary>
        [ApiMember(Description="Display value of output time series 267")]
        public string DisplayValue267 { get; set; }

        ///<summary>
        ///Grade code of output time series 267
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 267", Format="int64")]
        public long? GradeCode267 { get; set; }

        ///<summary>
        ///Grade name of output time series 267
        ///</summary>
        [ApiMember(Description="Grade name of output time series 267")]
        public string GradeName267 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 267
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 267")]
        public string Qualifiers267 { get; set; }

        ///<summary>
        ///Method of output time series 267
        ///</summary>
        [ApiMember(Description="Method of output time series 267")]
        public string Method267 { get; set; }

        ///<summary>
        ///Approval level of output time series 267
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 267", Format="int64")]
        public long? ApprovalLevel267 { get; set; }

        ///<summary>
        ///Approval name of output time series 267
        ///</summary>
        [ApiMember(Description="Approval name of output time series 267")]
        public string ApprovalName267 { get; set; }

        ///<summary>
        ///Numeric value of output time series 268
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 268", Format="double")]
        public double? NumericValue268 { get; set; }

        ///<summary>
        ///Display value of output time series 268
        ///</summary>
        [ApiMember(Description="Display value of output time series 268")]
        public string DisplayValue268 { get; set; }

        ///<summary>
        ///Grade code of output time series 268
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 268", Format="int64")]
        public long? GradeCode268 { get; set; }

        ///<summary>
        ///Grade name of output time series 268
        ///</summary>
        [ApiMember(Description="Grade name of output time series 268")]
        public string GradeName268 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 268
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 268")]
        public string Qualifiers268 { get; set; }

        ///<summary>
        ///Method of output time series 268
        ///</summary>
        [ApiMember(Description="Method of output time series 268")]
        public string Method268 { get; set; }

        ///<summary>
        ///Approval level of output time series 268
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 268", Format="int64")]
        public long? ApprovalLevel268 { get; set; }

        ///<summary>
        ///Approval name of output time series 268
        ///</summary>
        [ApiMember(Description="Approval name of output time series 268")]
        public string ApprovalName268 { get; set; }

        ///<summary>
        ///Numeric value of output time series 269
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 269", Format="double")]
        public double? NumericValue269 { get; set; }

        ///<summary>
        ///Display value of output time series 269
        ///</summary>
        [ApiMember(Description="Display value of output time series 269")]
        public string DisplayValue269 { get; set; }

        ///<summary>
        ///Grade code of output time series 269
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 269", Format="int64")]
        public long? GradeCode269 { get; set; }

        ///<summary>
        ///Grade name of output time series 269
        ///</summary>
        [ApiMember(Description="Grade name of output time series 269")]
        public string GradeName269 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 269
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 269")]
        public string Qualifiers269 { get; set; }

        ///<summary>
        ///Method of output time series 269
        ///</summary>
        [ApiMember(Description="Method of output time series 269")]
        public string Method269 { get; set; }

        ///<summary>
        ///Approval level of output time series 269
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 269", Format="int64")]
        public long? ApprovalLevel269 { get; set; }

        ///<summary>
        ///Approval name of output time series 269
        ///</summary>
        [ApiMember(Description="Approval name of output time series 269")]
        public string ApprovalName269 { get; set; }

        ///<summary>
        ///Numeric value of output time series 270
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 270", Format="double")]
        public double? NumericValue270 { get; set; }

        ///<summary>
        ///Display value of output time series 270
        ///</summary>
        [ApiMember(Description="Display value of output time series 270")]
        public string DisplayValue270 { get; set; }

        ///<summary>
        ///Grade code of output time series 270
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 270", Format="int64")]
        public long? GradeCode270 { get; set; }

        ///<summary>
        ///Grade name of output time series 270
        ///</summary>
        [ApiMember(Description="Grade name of output time series 270")]
        public string GradeName270 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 270
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 270")]
        public string Qualifiers270 { get; set; }

        ///<summary>
        ///Method of output time series 270
        ///</summary>
        [ApiMember(Description="Method of output time series 270")]
        public string Method270 { get; set; }

        ///<summary>
        ///Approval level of output time series 270
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 270", Format="int64")]
        public long? ApprovalLevel270 { get; set; }

        ///<summary>
        ///Approval name of output time series 270
        ///</summary>
        [ApiMember(Description="Approval name of output time series 270")]
        public string ApprovalName270 { get; set; }

        ///<summary>
        ///Numeric value of output time series 271
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 271", Format="double")]
        public double? NumericValue271 { get; set; }

        ///<summary>
        ///Display value of output time series 271
        ///</summary>
        [ApiMember(Description="Display value of output time series 271")]
        public string DisplayValue271 { get; set; }

        ///<summary>
        ///Grade code of output time series 271
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 271", Format="int64")]
        public long? GradeCode271 { get; set; }

        ///<summary>
        ///Grade name of output time series 271
        ///</summary>
        [ApiMember(Description="Grade name of output time series 271")]
        public string GradeName271 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 271
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 271")]
        public string Qualifiers271 { get; set; }

        ///<summary>
        ///Method of output time series 271
        ///</summary>
        [ApiMember(Description="Method of output time series 271")]
        public string Method271 { get; set; }

        ///<summary>
        ///Approval level of output time series 271
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 271", Format="int64")]
        public long? ApprovalLevel271 { get; set; }

        ///<summary>
        ///Approval name of output time series 271
        ///</summary>
        [ApiMember(Description="Approval name of output time series 271")]
        public string ApprovalName271 { get; set; }

        ///<summary>
        ///Numeric value of output time series 272
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 272", Format="double")]
        public double? NumericValue272 { get; set; }

        ///<summary>
        ///Display value of output time series 272
        ///</summary>
        [ApiMember(Description="Display value of output time series 272")]
        public string DisplayValue272 { get; set; }

        ///<summary>
        ///Grade code of output time series 272
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 272", Format="int64")]
        public long? GradeCode272 { get; set; }

        ///<summary>
        ///Grade name of output time series 272
        ///</summary>
        [ApiMember(Description="Grade name of output time series 272")]
        public string GradeName272 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 272
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 272")]
        public string Qualifiers272 { get; set; }

        ///<summary>
        ///Method of output time series 272
        ///</summary>
        [ApiMember(Description="Method of output time series 272")]
        public string Method272 { get; set; }

        ///<summary>
        ///Approval level of output time series 272
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 272", Format="int64")]
        public long? ApprovalLevel272 { get; set; }

        ///<summary>
        ///Approval name of output time series 272
        ///</summary>
        [ApiMember(Description="Approval name of output time series 272")]
        public string ApprovalName272 { get; set; }

        ///<summary>
        ///Numeric value of output time series 273
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 273", Format="double")]
        public double? NumericValue273 { get; set; }

        ///<summary>
        ///Display value of output time series 273
        ///</summary>
        [ApiMember(Description="Display value of output time series 273")]
        public string DisplayValue273 { get; set; }

        ///<summary>
        ///Grade code of output time series 273
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 273", Format="int64")]
        public long? GradeCode273 { get; set; }

        ///<summary>
        ///Grade name of output time series 273
        ///</summary>
        [ApiMember(Description="Grade name of output time series 273")]
        public string GradeName273 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 273
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 273")]
        public string Qualifiers273 { get; set; }

        ///<summary>
        ///Method of output time series 273
        ///</summary>
        [ApiMember(Description="Method of output time series 273")]
        public string Method273 { get; set; }

        ///<summary>
        ///Approval level of output time series 273
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 273", Format="int64")]
        public long? ApprovalLevel273 { get; set; }

        ///<summary>
        ///Approval name of output time series 273
        ///</summary>
        [ApiMember(Description="Approval name of output time series 273")]
        public string ApprovalName273 { get; set; }

        ///<summary>
        ///Numeric value of output time series 274
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 274", Format="double")]
        public double? NumericValue274 { get; set; }

        ///<summary>
        ///Display value of output time series 274
        ///</summary>
        [ApiMember(Description="Display value of output time series 274")]
        public string DisplayValue274 { get; set; }

        ///<summary>
        ///Grade code of output time series 274
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 274", Format="int64")]
        public long? GradeCode274 { get; set; }

        ///<summary>
        ///Grade name of output time series 274
        ///</summary>
        [ApiMember(Description="Grade name of output time series 274")]
        public string GradeName274 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 274
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 274")]
        public string Qualifiers274 { get; set; }

        ///<summary>
        ///Method of output time series 274
        ///</summary>
        [ApiMember(Description="Method of output time series 274")]
        public string Method274 { get; set; }

        ///<summary>
        ///Approval level of output time series 274
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 274", Format="int64")]
        public long? ApprovalLevel274 { get; set; }

        ///<summary>
        ///Approval name of output time series 274
        ///</summary>
        [ApiMember(Description="Approval name of output time series 274")]
        public string ApprovalName274 { get; set; }

        ///<summary>
        ///Numeric value of output time series 275
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 275", Format="double")]
        public double? NumericValue275 { get; set; }

        ///<summary>
        ///Display value of output time series 275
        ///</summary>
        [ApiMember(Description="Display value of output time series 275")]
        public string DisplayValue275 { get; set; }

        ///<summary>
        ///Grade code of output time series 275
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 275", Format="int64")]
        public long? GradeCode275 { get; set; }

        ///<summary>
        ///Grade name of output time series 275
        ///</summary>
        [ApiMember(Description="Grade name of output time series 275")]
        public string GradeName275 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 275
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 275")]
        public string Qualifiers275 { get; set; }

        ///<summary>
        ///Method of output time series 275
        ///</summary>
        [ApiMember(Description="Method of output time series 275")]
        public string Method275 { get; set; }

        ///<summary>
        ///Approval level of output time series 275
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 275", Format="int64")]
        public long? ApprovalLevel275 { get; set; }

        ///<summary>
        ///Approval name of output time series 275
        ///</summary>
        [ApiMember(Description="Approval name of output time series 275")]
        public string ApprovalName275 { get; set; }

        ///<summary>
        ///Numeric value of output time series 276
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 276", Format="double")]
        public double? NumericValue276 { get; set; }

        ///<summary>
        ///Display value of output time series 276
        ///</summary>
        [ApiMember(Description="Display value of output time series 276")]
        public string DisplayValue276 { get; set; }

        ///<summary>
        ///Grade code of output time series 276
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 276", Format="int64")]
        public long? GradeCode276 { get; set; }

        ///<summary>
        ///Grade name of output time series 276
        ///</summary>
        [ApiMember(Description="Grade name of output time series 276")]
        public string GradeName276 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 276
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 276")]
        public string Qualifiers276 { get; set; }

        ///<summary>
        ///Method of output time series 276
        ///</summary>
        [ApiMember(Description="Method of output time series 276")]
        public string Method276 { get; set; }

        ///<summary>
        ///Approval level of output time series 276
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 276", Format="int64")]
        public long? ApprovalLevel276 { get; set; }

        ///<summary>
        ///Approval name of output time series 276
        ///</summary>
        [ApiMember(Description="Approval name of output time series 276")]
        public string ApprovalName276 { get; set; }

        ///<summary>
        ///Numeric value of output time series 277
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 277", Format="double")]
        public double? NumericValue277 { get; set; }

        ///<summary>
        ///Display value of output time series 277
        ///</summary>
        [ApiMember(Description="Display value of output time series 277")]
        public string DisplayValue277 { get; set; }

        ///<summary>
        ///Grade code of output time series 277
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 277", Format="int64")]
        public long? GradeCode277 { get; set; }

        ///<summary>
        ///Grade name of output time series 277
        ///</summary>
        [ApiMember(Description="Grade name of output time series 277")]
        public string GradeName277 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 277
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 277")]
        public string Qualifiers277 { get; set; }

        ///<summary>
        ///Method of output time series 277
        ///</summary>
        [ApiMember(Description="Method of output time series 277")]
        public string Method277 { get; set; }

        ///<summary>
        ///Approval level of output time series 277
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 277", Format="int64")]
        public long? ApprovalLevel277 { get; set; }

        ///<summary>
        ///Approval name of output time series 277
        ///</summary>
        [ApiMember(Description="Approval name of output time series 277")]
        public string ApprovalName277 { get; set; }

        ///<summary>
        ///Numeric value of output time series 278
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 278", Format="double")]
        public double? NumericValue278 { get; set; }

        ///<summary>
        ///Display value of output time series 278
        ///</summary>
        [ApiMember(Description="Display value of output time series 278")]
        public string DisplayValue278 { get; set; }

        ///<summary>
        ///Grade code of output time series 278
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 278", Format="int64")]
        public long? GradeCode278 { get; set; }

        ///<summary>
        ///Grade name of output time series 278
        ///</summary>
        [ApiMember(Description="Grade name of output time series 278")]
        public string GradeName278 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 278
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 278")]
        public string Qualifiers278 { get; set; }

        ///<summary>
        ///Method of output time series 278
        ///</summary>
        [ApiMember(Description="Method of output time series 278")]
        public string Method278 { get; set; }

        ///<summary>
        ///Approval level of output time series 278
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 278", Format="int64")]
        public long? ApprovalLevel278 { get; set; }

        ///<summary>
        ///Approval name of output time series 278
        ///</summary>
        [ApiMember(Description="Approval name of output time series 278")]
        public string ApprovalName278 { get; set; }

        ///<summary>
        ///Numeric value of output time series 279
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 279", Format="double")]
        public double? NumericValue279 { get; set; }

        ///<summary>
        ///Display value of output time series 279
        ///</summary>
        [ApiMember(Description="Display value of output time series 279")]
        public string DisplayValue279 { get; set; }

        ///<summary>
        ///Grade code of output time series 279
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 279", Format="int64")]
        public long? GradeCode279 { get; set; }

        ///<summary>
        ///Grade name of output time series 279
        ///</summary>
        [ApiMember(Description="Grade name of output time series 279")]
        public string GradeName279 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 279
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 279")]
        public string Qualifiers279 { get; set; }

        ///<summary>
        ///Method of output time series 279
        ///</summary>
        [ApiMember(Description="Method of output time series 279")]
        public string Method279 { get; set; }

        ///<summary>
        ///Approval level of output time series 279
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 279", Format="int64")]
        public long? ApprovalLevel279 { get; set; }

        ///<summary>
        ///Approval name of output time series 279
        ///</summary>
        [ApiMember(Description="Approval name of output time series 279")]
        public string ApprovalName279 { get; set; }

        ///<summary>
        ///Numeric value of output time series 280
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 280", Format="double")]
        public double? NumericValue280 { get; set; }

        ///<summary>
        ///Display value of output time series 280
        ///</summary>
        [ApiMember(Description="Display value of output time series 280")]
        public string DisplayValue280 { get; set; }

        ///<summary>
        ///Grade code of output time series 280
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 280", Format="int64")]
        public long? GradeCode280 { get; set; }

        ///<summary>
        ///Grade name of output time series 280
        ///</summary>
        [ApiMember(Description="Grade name of output time series 280")]
        public string GradeName280 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 280
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 280")]
        public string Qualifiers280 { get; set; }

        ///<summary>
        ///Method of output time series 280
        ///</summary>
        [ApiMember(Description="Method of output time series 280")]
        public string Method280 { get; set; }

        ///<summary>
        ///Approval level of output time series 280
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 280", Format="int64")]
        public long? ApprovalLevel280 { get; set; }

        ///<summary>
        ///Approval name of output time series 280
        ///</summary>
        [ApiMember(Description="Approval name of output time series 280")]
        public string ApprovalName280 { get; set; }

        ///<summary>
        ///Numeric value of output time series 281
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 281", Format="double")]
        public double? NumericValue281 { get; set; }

        ///<summary>
        ///Display value of output time series 281
        ///</summary>
        [ApiMember(Description="Display value of output time series 281")]
        public string DisplayValue281 { get; set; }

        ///<summary>
        ///Grade code of output time series 281
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 281", Format="int64")]
        public long? GradeCode281 { get; set; }

        ///<summary>
        ///Grade name of output time series 281
        ///</summary>
        [ApiMember(Description="Grade name of output time series 281")]
        public string GradeName281 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 281
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 281")]
        public string Qualifiers281 { get; set; }

        ///<summary>
        ///Method of output time series 281
        ///</summary>
        [ApiMember(Description="Method of output time series 281")]
        public string Method281 { get; set; }

        ///<summary>
        ///Approval level of output time series 281
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 281", Format="int64")]
        public long? ApprovalLevel281 { get; set; }

        ///<summary>
        ///Approval name of output time series 281
        ///</summary>
        [ApiMember(Description="Approval name of output time series 281")]
        public string ApprovalName281 { get; set; }

        ///<summary>
        ///Numeric value of output time series 282
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 282", Format="double")]
        public double? NumericValue282 { get; set; }

        ///<summary>
        ///Display value of output time series 282
        ///</summary>
        [ApiMember(Description="Display value of output time series 282")]
        public string DisplayValue282 { get; set; }

        ///<summary>
        ///Grade code of output time series 282
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 282", Format="int64")]
        public long? GradeCode282 { get; set; }

        ///<summary>
        ///Grade name of output time series 282
        ///</summary>
        [ApiMember(Description="Grade name of output time series 282")]
        public string GradeName282 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 282
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 282")]
        public string Qualifiers282 { get; set; }

        ///<summary>
        ///Method of output time series 282
        ///</summary>
        [ApiMember(Description="Method of output time series 282")]
        public string Method282 { get; set; }

        ///<summary>
        ///Approval level of output time series 282
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 282", Format="int64")]
        public long? ApprovalLevel282 { get; set; }

        ///<summary>
        ///Approval name of output time series 282
        ///</summary>
        [ApiMember(Description="Approval name of output time series 282")]
        public string ApprovalName282 { get; set; }

        ///<summary>
        ///Numeric value of output time series 283
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 283", Format="double")]
        public double? NumericValue283 { get; set; }

        ///<summary>
        ///Display value of output time series 283
        ///</summary>
        [ApiMember(Description="Display value of output time series 283")]
        public string DisplayValue283 { get; set; }

        ///<summary>
        ///Grade code of output time series 283
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 283", Format="int64")]
        public long? GradeCode283 { get; set; }

        ///<summary>
        ///Grade name of output time series 283
        ///</summary>
        [ApiMember(Description="Grade name of output time series 283")]
        public string GradeName283 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 283
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 283")]
        public string Qualifiers283 { get; set; }

        ///<summary>
        ///Method of output time series 283
        ///</summary>
        [ApiMember(Description="Method of output time series 283")]
        public string Method283 { get; set; }

        ///<summary>
        ///Approval level of output time series 283
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 283", Format="int64")]
        public long? ApprovalLevel283 { get; set; }

        ///<summary>
        ///Approval name of output time series 283
        ///</summary>
        [ApiMember(Description="Approval name of output time series 283")]
        public string ApprovalName283 { get; set; }

        ///<summary>
        ///Numeric value of output time series 284
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 284", Format="double")]
        public double? NumericValue284 { get; set; }

        ///<summary>
        ///Display value of output time series 284
        ///</summary>
        [ApiMember(Description="Display value of output time series 284")]
        public string DisplayValue284 { get; set; }

        ///<summary>
        ///Grade code of output time series 284
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 284", Format="int64")]
        public long? GradeCode284 { get; set; }

        ///<summary>
        ///Grade name of output time series 284
        ///</summary>
        [ApiMember(Description="Grade name of output time series 284")]
        public string GradeName284 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 284
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 284")]
        public string Qualifiers284 { get; set; }

        ///<summary>
        ///Method of output time series 284
        ///</summary>
        [ApiMember(Description="Method of output time series 284")]
        public string Method284 { get; set; }

        ///<summary>
        ///Approval level of output time series 284
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 284", Format="int64")]
        public long? ApprovalLevel284 { get; set; }

        ///<summary>
        ///Approval name of output time series 284
        ///</summary>
        [ApiMember(Description="Approval name of output time series 284")]
        public string ApprovalName284 { get; set; }

        ///<summary>
        ///Numeric value of output time series 285
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 285", Format="double")]
        public double? NumericValue285 { get; set; }

        ///<summary>
        ///Display value of output time series 285
        ///</summary>
        [ApiMember(Description="Display value of output time series 285")]
        public string DisplayValue285 { get; set; }

        ///<summary>
        ///Grade code of output time series 285
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 285", Format="int64")]
        public long? GradeCode285 { get; set; }

        ///<summary>
        ///Grade name of output time series 285
        ///</summary>
        [ApiMember(Description="Grade name of output time series 285")]
        public string GradeName285 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 285
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 285")]
        public string Qualifiers285 { get; set; }

        ///<summary>
        ///Method of output time series 285
        ///</summary>
        [ApiMember(Description="Method of output time series 285")]
        public string Method285 { get; set; }

        ///<summary>
        ///Approval level of output time series 285
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 285", Format="int64")]
        public long? ApprovalLevel285 { get; set; }

        ///<summary>
        ///Approval name of output time series 285
        ///</summary>
        [ApiMember(Description="Approval name of output time series 285")]
        public string ApprovalName285 { get; set; }

        ///<summary>
        ///Numeric value of output time series 286
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 286", Format="double")]
        public double? NumericValue286 { get; set; }

        ///<summary>
        ///Display value of output time series 286
        ///</summary>
        [ApiMember(Description="Display value of output time series 286")]
        public string DisplayValue286 { get; set; }

        ///<summary>
        ///Grade code of output time series 286
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 286", Format="int64")]
        public long? GradeCode286 { get; set; }

        ///<summary>
        ///Grade name of output time series 286
        ///</summary>
        [ApiMember(Description="Grade name of output time series 286")]
        public string GradeName286 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 286
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 286")]
        public string Qualifiers286 { get; set; }

        ///<summary>
        ///Method of output time series 286
        ///</summary>
        [ApiMember(Description="Method of output time series 286")]
        public string Method286 { get; set; }

        ///<summary>
        ///Approval level of output time series 286
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 286", Format="int64")]
        public long? ApprovalLevel286 { get; set; }

        ///<summary>
        ///Approval name of output time series 286
        ///</summary>
        [ApiMember(Description="Approval name of output time series 286")]
        public string ApprovalName286 { get; set; }

        ///<summary>
        ///Numeric value of output time series 287
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 287", Format="double")]
        public double? NumericValue287 { get; set; }

        ///<summary>
        ///Display value of output time series 287
        ///</summary>
        [ApiMember(Description="Display value of output time series 287")]
        public string DisplayValue287 { get; set; }

        ///<summary>
        ///Grade code of output time series 287
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 287", Format="int64")]
        public long? GradeCode287 { get; set; }

        ///<summary>
        ///Grade name of output time series 287
        ///</summary>
        [ApiMember(Description="Grade name of output time series 287")]
        public string GradeName287 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 287
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 287")]
        public string Qualifiers287 { get; set; }

        ///<summary>
        ///Method of output time series 287
        ///</summary>
        [ApiMember(Description="Method of output time series 287")]
        public string Method287 { get; set; }

        ///<summary>
        ///Approval level of output time series 287
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 287", Format="int64")]
        public long? ApprovalLevel287 { get; set; }

        ///<summary>
        ///Approval name of output time series 287
        ///</summary>
        [ApiMember(Description="Approval name of output time series 287")]
        public string ApprovalName287 { get; set; }

        ///<summary>
        ///Numeric value of output time series 288
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 288", Format="double")]
        public double? NumericValue288 { get; set; }

        ///<summary>
        ///Display value of output time series 288
        ///</summary>
        [ApiMember(Description="Display value of output time series 288")]
        public string DisplayValue288 { get; set; }

        ///<summary>
        ///Grade code of output time series 288
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 288", Format="int64")]
        public long? GradeCode288 { get; set; }

        ///<summary>
        ///Grade name of output time series 288
        ///</summary>
        [ApiMember(Description="Grade name of output time series 288")]
        public string GradeName288 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 288
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 288")]
        public string Qualifiers288 { get; set; }

        ///<summary>
        ///Method of output time series 288
        ///</summary>
        [ApiMember(Description="Method of output time series 288")]
        public string Method288 { get; set; }

        ///<summary>
        ///Approval level of output time series 288
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 288", Format="int64")]
        public long? ApprovalLevel288 { get; set; }

        ///<summary>
        ///Approval name of output time series 288
        ///</summary>
        [ApiMember(Description="Approval name of output time series 288")]
        public string ApprovalName288 { get; set; }

        ///<summary>
        ///Numeric value of output time series 289
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 289", Format="double")]
        public double? NumericValue289 { get; set; }

        ///<summary>
        ///Display value of output time series 289
        ///</summary>
        [ApiMember(Description="Display value of output time series 289")]
        public string DisplayValue289 { get; set; }

        ///<summary>
        ///Grade code of output time series 289
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 289", Format="int64")]
        public long? GradeCode289 { get; set; }

        ///<summary>
        ///Grade name of output time series 289
        ///</summary>
        [ApiMember(Description="Grade name of output time series 289")]
        public string GradeName289 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 289
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 289")]
        public string Qualifiers289 { get; set; }

        ///<summary>
        ///Method of output time series 289
        ///</summary>
        [ApiMember(Description="Method of output time series 289")]
        public string Method289 { get; set; }

        ///<summary>
        ///Approval level of output time series 289
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 289", Format="int64")]
        public long? ApprovalLevel289 { get; set; }

        ///<summary>
        ///Approval name of output time series 289
        ///</summary>
        [ApiMember(Description="Approval name of output time series 289")]
        public string ApprovalName289 { get; set; }

        ///<summary>
        ///Numeric value of output time series 290
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 290", Format="double")]
        public double? NumericValue290 { get; set; }

        ///<summary>
        ///Display value of output time series 290
        ///</summary>
        [ApiMember(Description="Display value of output time series 290")]
        public string DisplayValue290 { get; set; }

        ///<summary>
        ///Grade code of output time series 290
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 290", Format="int64")]
        public long? GradeCode290 { get; set; }

        ///<summary>
        ///Grade name of output time series 290
        ///</summary>
        [ApiMember(Description="Grade name of output time series 290")]
        public string GradeName290 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 290
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 290")]
        public string Qualifiers290 { get; set; }

        ///<summary>
        ///Method of output time series 290
        ///</summary>
        [ApiMember(Description="Method of output time series 290")]
        public string Method290 { get; set; }

        ///<summary>
        ///Approval level of output time series 290
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 290", Format="int64")]
        public long? ApprovalLevel290 { get; set; }

        ///<summary>
        ///Approval name of output time series 290
        ///</summary>
        [ApiMember(Description="Approval name of output time series 290")]
        public string ApprovalName290 { get; set; }

        ///<summary>
        ///Numeric value of output time series 291
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 291", Format="double")]
        public double? NumericValue291 { get; set; }

        ///<summary>
        ///Display value of output time series 291
        ///</summary>
        [ApiMember(Description="Display value of output time series 291")]
        public string DisplayValue291 { get; set; }

        ///<summary>
        ///Grade code of output time series 291
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 291", Format="int64")]
        public long? GradeCode291 { get; set; }

        ///<summary>
        ///Grade name of output time series 291
        ///</summary>
        [ApiMember(Description="Grade name of output time series 291")]
        public string GradeName291 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 291
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 291")]
        public string Qualifiers291 { get; set; }

        ///<summary>
        ///Method of output time series 291
        ///</summary>
        [ApiMember(Description="Method of output time series 291")]
        public string Method291 { get; set; }

        ///<summary>
        ///Approval level of output time series 291
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 291", Format="int64")]
        public long? ApprovalLevel291 { get; set; }

        ///<summary>
        ///Approval name of output time series 291
        ///</summary>
        [ApiMember(Description="Approval name of output time series 291")]
        public string ApprovalName291 { get; set; }

        ///<summary>
        ///Numeric value of output time series 292
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 292", Format="double")]
        public double? NumericValue292 { get; set; }

        ///<summary>
        ///Display value of output time series 292
        ///</summary>
        [ApiMember(Description="Display value of output time series 292")]
        public string DisplayValue292 { get; set; }

        ///<summary>
        ///Grade code of output time series 292
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 292", Format="int64")]
        public long? GradeCode292 { get; set; }

        ///<summary>
        ///Grade name of output time series 292
        ///</summary>
        [ApiMember(Description="Grade name of output time series 292")]
        public string GradeName292 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 292
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 292")]
        public string Qualifiers292 { get; set; }

        ///<summary>
        ///Method of output time series 292
        ///</summary>
        [ApiMember(Description="Method of output time series 292")]
        public string Method292 { get; set; }

        ///<summary>
        ///Approval level of output time series 292
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 292", Format="int64")]
        public long? ApprovalLevel292 { get; set; }

        ///<summary>
        ///Approval name of output time series 292
        ///</summary>
        [ApiMember(Description="Approval name of output time series 292")]
        public string ApprovalName292 { get; set; }

        ///<summary>
        ///Numeric value of output time series 293
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 293", Format="double")]
        public double? NumericValue293 { get; set; }

        ///<summary>
        ///Display value of output time series 293
        ///</summary>
        [ApiMember(Description="Display value of output time series 293")]
        public string DisplayValue293 { get; set; }

        ///<summary>
        ///Grade code of output time series 293
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 293", Format="int64")]
        public long? GradeCode293 { get; set; }

        ///<summary>
        ///Grade name of output time series 293
        ///</summary>
        [ApiMember(Description="Grade name of output time series 293")]
        public string GradeName293 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 293
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 293")]
        public string Qualifiers293 { get; set; }

        ///<summary>
        ///Method of output time series 293
        ///</summary>
        [ApiMember(Description="Method of output time series 293")]
        public string Method293 { get; set; }

        ///<summary>
        ///Approval level of output time series 293
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 293", Format="int64")]
        public long? ApprovalLevel293 { get; set; }

        ///<summary>
        ///Approval name of output time series 293
        ///</summary>
        [ApiMember(Description="Approval name of output time series 293")]
        public string ApprovalName293 { get; set; }

        ///<summary>
        ///Numeric value of output time series 294
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 294", Format="double")]
        public double? NumericValue294 { get; set; }

        ///<summary>
        ///Display value of output time series 294
        ///</summary>
        [ApiMember(Description="Display value of output time series 294")]
        public string DisplayValue294 { get; set; }

        ///<summary>
        ///Grade code of output time series 294
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 294", Format="int64")]
        public long? GradeCode294 { get; set; }

        ///<summary>
        ///Grade name of output time series 294
        ///</summary>
        [ApiMember(Description="Grade name of output time series 294")]
        public string GradeName294 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 294
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 294")]
        public string Qualifiers294 { get; set; }

        ///<summary>
        ///Method of output time series 294
        ///</summary>
        [ApiMember(Description="Method of output time series 294")]
        public string Method294 { get; set; }

        ///<summary>
        ///Approval level of output time series 294
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 294", Format="int64")]
        public long? ApprovalLevel294 { get; set; }

        ///<summary>
        ///Approval name of output time series 294
        ///</summary>
        [ApiMember(Description="Approval name of output time series 294")]
        public string ApprovalName294 { get; set; }

        ///<summary>
        ///Numeric value of output time series 295
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 295", Format="double")]
        public double? NumericValue295 { get; set; }

        ///<summary>
        ///Display value of output time series 295
        ///</summary>
        [ApiMember(Description="Display value of output time series 295")]
        public string DisplayValue295 { get; set; }

        ///<summary>
        ///Grade code of output time series 295
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 295", Format="int64")]
        public long? GradeCode295 { get; set; }

        ///<summary>
        ///Grade name of output time series 295
        ///</summary>
        [ApiMember(Description="Grade name of output time series 295")]
        public string GradeName295 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 295
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 295")]
        public string Qualifiers295 { get; set; }

        ///<summary>
        ///Method of output time series 295
        ///</summary>
        [ApiMember(Description="Method of output time series 295")]
        public string Method295 { get; set; }

        ///<summary>
        ///Approval level of output time series 295
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 295", Format="int64")]
        public long? ApprovalLevel295 { get; set; }

        ///<summary>
        ///Approval name of output time series 295
        ///</summary>
        [ApiMember(Description="Approval name of output time series 295")]
        public string ApprovalName295 { get; set; }

        ///<summary>
        ///Numeric value of output time series 296
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 296", Format="double")]
        public double? NumericValue296 { get; set; }

        ///<summary>
        ///Display value of output time series 296
        ///</summary>
        [ApiMember(Description="Display value of output time series 296")]
        public string DisplayValue296 { get; set; }

        ///<summary>
        ///Grade code of output time series 296
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 296", Format="int64")]
        public long? GradeCode296 { get; set; }

        ///<summary>
        ///Grade name of output time series 296
        ///</summary>
        [ApiMember(Description="Grade name of output time series 296")]
        public string GradeName296 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 296
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 296")]
        public string Qualifiers296 { get; set; }

        ///<summary>
        ///Method of output time series 296
        ///</summary>
        [ApiMember(Description="Method of output time series 296")]
        public string Method296 { get; set; }

        ///<summary>
        ///Approval level of output time series 296
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 296", Format="int64")]
        public long? ApprovalLevel296 { get; set; }

        ///<summary>
        ///Approval name of output time series 296
        ///</summary>
        [ApiMember(Description="Approval name of output time series 296")]
        public string ApprovalName296 { get; set; }

        ///<summary>
        ///Numeric value of output time series 297
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 297", Format="double")]
        public double? NumericValue297 { get; set; }

        ///<summary>
        ///Display value of output time series 297
        ///</summary>
        [ApiMember(Description="Display value of output time series 297")]
        public string DisplayValue297 { get; set; }

        ///<summary>
        ///Grade code of output time series 297
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 297", Format="int64")]
        public long? GradeCode297 { get; set; }

        ///<summary>
        ///Grade name of output time series 297
        ///</summary>
        [ApiMember(Description="Grade name of output time series 297")]
        public string GradeName297 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 297
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 297")]
        public string Qualifiers297 { get; set; }

        ///<summary>
        ///Method of output time series 297
        ///</summary>
        [ApiMember(Description="Method of output time series 297")]
        public string Method297 { get; set; }

        ///<summary>
        ///Approval level of output time series 297
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 297", Format="int64")]
        public long? ApprovalLevel297 { get; set; }

        ///<summary>
        ///Approval name of output time series 297
        ///</summary>
        [ApiMember(Description="Approval name of output time series 297")]
        public string ApprovalName297 { get; set; }

        ///<summary>
        ///Numeric value of output time series 298
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 298", Format="double")]
        public double? NumericValue298 { get; set; }

        ///<summary>
        ///Display value of output time series 298
        ///</summary>
        [ApiMember(Description="Display value of output time series 298")]
        public string DisplayValue298 { get; set; }

        ///<summary>
        ///Grade code of output time series 298
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 298", Format="int64")]
        public long? GradeCode298 { get; set; }

        ///<summary>
        ///Grade name of output time series 298
        ///</summary>
        [ApiMember(Description="Grade name of output time series 298")]
        public string GradeName298 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 298
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 298")]
        public string Qualifiers298 { get; set; }

        ///<summary>
        ///Method of output time series 298
        ///</summary>
        [ApiMember(Description="Method of output time series 298")]
        public string Method298 { get; set; }

        ///<summary>
        ///Approval level of output time series 298
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 298", Format="int64")]
        public long? ApprovalLevel298 { get; set; }

        ///<summary>
        ///Approval name of output time series 298
        ///</summary>
        [ApiMember(Description="Approval name of output time series 298")]
        public string ApprovalName298 { get; set; }

        ///<summary>
        ///Numeric value of output time series 299
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 299", Format="double")]
        public double? NumericValue299 { get; set; }

        ///<summary>
        ///Display value of output time series 299
        ///</summary>
        [ApiMember(Description="Display value of output time series 299")]
        public string DisplayValue299 { get; set; }

        ///<summary>
        ///Grade code of output time series 299
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 299", Format="int64")]
        public long? GradeCode299 { get; set; }

        ///<summary>
        ///Grade name of output time series 299
        ///</summary>
        [ApiMember(Description="Grade name of output time series 299")]
        public string GradeName299 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 299
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 299")]
        public string Qualifiers299 { get; set; }

        ///<summary>
        ///Method of output time series 299
        ///</summary>
        [ApiMember(Description="Method of output time series 299")]
        public string Method299 { get; set; }

        ///<summary>
        ///Approval level of output time series 299
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 299", Format="int64")]
        public long? ApprovalLevel299 { get; set; }

        ///<summary>
        ///Approval name of output time series 299
        ///</summary>
        [ApiMember(Description="Approval name of output time series 299")]
        public string ApprovalName299 { get; set; }

        ///<summary>
        ///Numeric value of output time series 300
        ///</summary>
        [ApiMember(DataType="number", Description="Numeric value of output time series 300", Format="double")]
        public double? NumericValue300 { get; set; }

        ///<summary>
        ///Display value of output time series 300
        ///</summary>
        [ApiMember(Description="Display value of output time series 300")]
        public string DisplayValue300 { get; set; }

        ///<summary>
        ///Grade code of output time series 300
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time series 300", Format="int64")]
        public long? GradeCode300 { get; set; }

        ///<summary>
        ///Grade name of output time series 300
        ///</summary>
        [ApiMember(Description="Grade name of output time series 300")]
        public string GradeName300 { get; set; }

        ///<summary>
        ///Comma-separated list of qualifiers of output time series 300
        ///</summary>
        [ApiMember(Description="Comma-separated list of qualifiers of output time series 300")]
        public string Qualifiers300 { get; set; }

        ///<summary>
        ///Method of output time series 300
        ///</summary>
        [ApiMember(Description="Method of output time series 300")]
        public string Method300 { get; set; }

        ///<summary>
        ///Approval level of output time series 300
        ///</summary>
        [ApiMember(DataType="integer", Description="Approval level of output time series 300", Format="int64")]
        public long? ApprovalLevel300 { get; set; }

        ///<summary>
        ///Approval name of output time series 300
        ///</summary>
        [ApiMember(Description="Approval name of output time series 300")]
        public string ApprovalName300 { get; set; }
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

        ///<summary>
        ///Property Bag
        ///</summary>
        [ApiMember(Description="Property Bag")]
        public string PropertyBag { get; set; }
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
        ///Gage Height Reference Point name at this Visit's Location
        ///</summary>
        [ApiMember(DataType="string", Description="Gage Height Reference Point name at this Visit's Location", Format="guid")]
        public Guid? GageHeightReferencePointUniqueId { get; set; }

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

        ///<summary>
        ///Hydraulic Test Activities
        ///</summary>
        [ApiMember(DataType="array", Description="Hydraulic Test Activities")]
        public List<HydraulicTestActivity> HydraulicTestActivities { get; set; }

        ///<summary>
        ///Well integrity activity
        ///</summary>
        [ApiMember(DataType="WellIntegrityActivity", Description="Well integrity activity")]
        public WellIntegrityActivity WellIntegrityActivity { get; set; }
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

        ///<summary>
        ///Extended attributes
        ///</summary>
        [ApiMember(DataType="array", Description="Extended attributes")]
        public IList<ExtendedAttribute> ExtendedAttributes { get; set; }
    }

    public class FieldVisitReading
    {
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

    public class HydraulicTestActivity
    {
        ///<summary>
        ///The name of the test
        ///</summary>
        [ApiMember(Description="The name of the test", Name="TestName")]
        public string TestName { get; set; }

        ///<summary>
        ///The context or purpose of the test
        ///</summary>
        [ApiMember(Description="The context or purpose of the test", Name="TestContext")]
        public string TestContext { get; set; }

        ///<summary>
        ///The method used for the test
        ///</summary>
        [ApiMember(Description="The method used for the test", Name="TestMethod")]
        public string TestMethod { get; set; }

        ///<summary>
        ///The type of aquifer
        ///</summary>
        [ApiMember(Description="The type of aquifer", Name="AquiferType")]
        public string AquiferType { get; set; }

        ///<summary>
        ///The start time of the test
        ///</summary>
        [ApiMember(DataType="string", Description="The start time of the test", Format="date-time", Name="StartTime")]
        public DateTimeOffset StartTime { get; set; }

        ///<summary>
        ///The end time of the test
        ///</summary>
        [ApiMember(DataType="string", Description="The end time of the test", Format="date-time", Name="EndTime")]
        public DateTimeOffset EndTime { get; set; }

        ///<summary>
        ///Indicates whether the test should be published
        ///</summary>
        [ApiMember(DataType="boolean", Description="Indicates whether the test should be published", Name="Publish")]
        public bool Publish { get; set; }

        ///<summary>
        ///List of related time series unique ids
        ///</summary>
        [ApiMember(DataType="array", Description="List of related time series unique ids", Name="RelatedTimeSeriesUniqueIds")]
        public List<Guid> RelatedTimeSeriesUniqueIds { get; set; }

        ///<summary>
        ///List of related field visit identifiers
        ///</summary>
        [ApiMember(DataType="array", Description="List of related field visit identifiers", Name="RelatedFieldVisitIdentifiers")]
        public List<Guid> RelatedFieldVisitIdentifiers { get; set; }

        ///<summary>
        ///List of hydraulic test results
        ///</summary>
        [ApiMember(DataType="array", Description="List of hydraulic test results", Name="Results")]
        public List<HydraulicTestResult> Results { get; set; }

        ///<summary>
        ///Additional comments or notes
        ///</summary>
        [ApiMember(Description="Additional comments or notes", Name="Comments")]
        public string Comments { get; set; }
    }

    public class HydraulicTestResult
    {
        ///<summary>
        ///Parameter identifier used for the analysis
        ///</summary>
        [ApiMember(Description="Parameter identifier used for the analysis", Name="ParameterId")]
        public string ParameterId { get; set; }

        ///<summary>
        ///Parameter display name used for the analysis
        ///</summary>
        [ApiMember(Description="Parameter display name used for the analysis", Name="Parameter")]
        public string Parameter { get; set; }

        ///<summary>
        ///Identifier for the unit of measurement
        ///</summary>
        [ApiMember(Description="Identifier for the unit of measurement", Name="UnitId")]
        public string UnitId { get; set; }

        ///<summary>
        ///Method used for the analysis
        ///</summary>
        [ApiMember(Description="Method used for the analysis", Name="AnalysisMethod")]
        public string AnalysisMethod { get; set; }

        ///<summary>
        ///Method code used for the analysis
        ///</summary>
        [ApiMember(Description="Method code used for the analysis", Name="AnalysisMethodCode")]
        public string AnalysisMethodCode { get; set; }

        ///<summary>
        ///Measured value of the parameter
        ///</summary>
        [ApiMember(DataType="QuantityWithDisplay", Description="Measured value of the parameter", Name="Value")]
        public QuantityWithDisplay Value { get; set; }
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
        List<HydraulicTestActivity> HydraulicTestActivities { get; set; }
        WellIntegrityActivity WellIntegrityActivity { get; set; }
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

    public class WellAquiferConnection
    {
        ///<summary>
        ///The UTC start date of the aquifer connection
        ///</summary>
        [ApiMember(DataType="string", Description="The UTC start date of the aquifer connection", Format="date-time", Name="StartDateUtc")]
        public DateTimeOffset StartDate { get; set; }

        ///<summary>
        ///Type of connectivity between the well and aquifer
        ///</summary>
        [ApiMember(Description="Type of connectivity between the well and aquifer", Name="WellAquiferConnectivityType")]
        public string WellAquiferConnectivityType { get; set; }

        ///<summary>
        ///Method used to determine the inspection result
        ///</summary>
        [ApiMember(Description="Method used to determine the inspection result", Name="WellInspectionDeterminationMethodType")]
        public string WellInspectionDeterminationMethodType { get; set; }

        ///<summary>
        ///Additional comments or notes
        ///</summary>
        [ApiMember(Description="Additional comments or notes", Name="Comments")]
        public string Comments { get; set; }
    }

    public class WellInspection
    {
        ///<summary>
        ///The start date of the inspection
        ///</summary>
        [ApiMember(DataType="string", Description="The start date of the inspection", Format="date-time", Name="StartDate")]
        public DateTimeOffset StartDate { get; set; }

        ///<summary>
        ///Type of well component inspected
        ///</summary>
        [ApiMember(Description="Type of well component inspected", Name="WellComponentType")]
        public string WellComponentType { get; set; }

        ///<summary>
        ///Condition type of the well component
        ///</summary>
        [ApiMember(Description="Condition type of the well component", Name="WellConditionType")]
        public string WellConditionType { get; set; }

        ///<summary>
        ///Method used for the inspection
        ///</summary>
        [ApiMember(Description="Method used for the inspection", Name="WellInspectionMethodType")]
        public string WellInspectionMethodType { get; set; }

        ///<summary>
        ///Starting distance of the inspection range
        ///</summary>
        [ApiMember(DataType="QuantityWithDisplay", Description="Starting distance of the inspection range", Name="DistanceFrom")]
        public QuantityWithDisplay DistanceFrom { get; set; }

        ///<summary>
        ///Ending distance of the inspection range
        ///</summary>
        [ApiMember(DataType="QuantityWithDisplay", Description="Ending distance of the inspection range", Name="DistanceTo")]
        public QuantityWithDisplay DistanceTo { get; set; }

        ///<summary>
        ///Unit of measurement for distance
        ///</summary>
        [ApiMember(Description="Unit of measurement for distance", Name="DistanceUnitId")]
        public string DistanceUnitId { get; set; }

        ///<summary>
        ///Additional comments or notes
        ///</summary>
        [ApiMember(Description="Additional comments or notes", Name="Comments")]
        public string Comments { get; set; }
    }

    public class WellIntegrityActivity
    {
        ///<summary>
        ///List of aquifer connections associated with the well
        ///</summary>
        [ApiMember(DataType="array", Description="List of aquifer connections associated with the well", Name="WellAquiferConnections")]
        public List<WellAquiferConnection> WellAquiferConnections { get; set; }

        ///<summary>
        ///List of inspections performed on the well
        ///</summary>
        [ApiMember(DataType="array", Description="List of inspections performed on the well", Name="WellInspections")]
        public List<WellInspection> WellInspections { get; set; }

        ///<summary>
        ///List of redevelopment activities for the well
        ///</summary>
        [ApiMember(DataType="array", Description="List of redevelopment activities for the well", Name="WellRedevelopments")]
        public List<WellRedevelopment> WellRedevelopments { get; set; }

        ///<summary>
        ///List of repair activities performed on the well
        ///</summary>
        [ApiMember(DataType="array", Description="List of repair activities performed on the well", Name="WellRepairs")]
        public List<WellRepair> WellRepairs { get; set; }
    }

    public class WellRedevelopment
    {
        ///<summary>
        ///The number of the redevelopment attempt
        ///</summary>
        [ApiMember(DataType="integer", Description="The number of the redevelopment attempt", Format="int32", Name="Attempt")]
        public int Attempt { get; set; }

        ///<summary>
        ///The start date of the redevelopment activity
        ///</summary>
        [ApiMember(DataType="string", Description="The start date of the redevelopment activity", Format="date-time", Name="StartDate")]
        public DateTimeOffset StartDate { get; set; }

        ///<summary>
        ///The end date of the redevelopment activity
        ///</summary>
        [ApiMember(DataType="string", Description="The end date of the redevelopment activity", Format="date-time", Name="EndDate")]
        public DateTimeOffset EndDate { get; set; }

        ///<summary>
        ///Type of redevelopment performed on the well
        ///</summary>
        [ApiMember(Description="Type of redevelopment performed on the well", Name="WellRedevelopmentType")]
        public string WellRedevelopmentType { get; set; }

        ///<summary>
        ///Additional comments or notes about the redevelopment
        ///</summary>
        [ApiMember(Description="Additional comments or notes about the redevelopment", Name="Comments")]
        public string Comments { get; set; }
    }

    public class WellRepair
    {
        ///<summary>
        ///The start date of the repair activity
        ///</summary>
        [ApiMember(DataType="string", Description="The start date of the repair activity", Format="date-time", Name="StartDate")]
        public DateTimeOffset StartDate { get; set; }

        ///<summary>
        ///The end date of the repair activity
        ///</summary>
        [ApiMember(DataType="string", Description="The end date of the repair activity", Format="date-time", Name="EndDate")]
        public DateTimeOffset EndDate { get; set; }

        ///<summary>
        ///Type of repair performed on the well
        ///</summary>
        [ApiMember(Description="Type of repair performed on the well", Name="WellRepairType")]
        public string WellRepairType { get; set; }

        ///<summary>
        ///Additional comments or notes about the repair
        ///</summary>
        [ApiMember(Description="Additional comments or notes about the repair", Name="Comments")]
        public string Comments { get; set; }
    }

    public class ActiveMeterCalibration
    {
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
        HydraulicTest,
        WellIntegrity,
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
        ///<summary>
        ///Location identifier
        ///</summary>
        [ApiMember(Description="Location identifier", IsRequired=true)]
        public string LocationIdentifier { get; set; }

        ///<summary>
        ///If set, only return specified activity types, selected from: Reading, Inspection, CalibrationCheck, DischargeSummary, DischargePointVelocity, DischargeVolumetric, DischargeEngineeredStructure, DischargeAdcp, DischargeOtherMethod, GageHeightAtZeroFlow, ControlCondition, CrossSectionSurvey, LevelSurvey, Attachment, HydraulicTest or WellIntegrity
        ///</summary>
        [ApiMember(AllowMultiple=true, DataType="array", Description="If set, only return specified activity types, selected from: Reading, Inspection, CalibrationCheck, DischargeSummary, DischargePointVelocity, DischargeVolumetric, DischargeEngineeredStructure, DischargeAdcp, DischargeOtherMethod, GageHeightAtZeroFlow, ControlCondition, CrossSectionSurvey, LevelSurvey, Attachment, HydraulicTest or WellIntegrity")]
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

        ///<summary>
        ///Filter results to items matching the given extended attribute values
        ///</summary>
        [ApiMember(DataType="array", Description="Filter results to items matching the given extended attribute values")]
        public List<ExtendedAttributeFilter> ExtendedFilters { get; set; }
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
        ///If set, only report the specific activity type: One of Inspection, DischargeSummary, DischargePointVelocity, DischargeVolumetric, DischargeEngineeredStructure, DischargeAdcp, DischargeOtherMethod, GageHeightAtZeroFlow, ControlCondition, CrossSectionSurvey, LevelSurvey, HydraulicTest or WellIntegrity
        ///</summary>
        [ApiMember(Description="If set, only report the specific activity type: One of Inspection, DischargeSummary, DischargePointVelocity, DischargeVolumetric, DischargeEngineeredStructure, DischargeAdcp, DischargeOtherMethod, GageHeightAtZeroFlow, ControlCondition, CrossSectionSurvey, LevelSurvey, HydraulicTest or WellIntegrity")]
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

        ///<summary>
        ///Filter results to items matching the given extended attribute values
        ///</summary>
        [ApiMember(DataType="array", Description="Filter results to items matching the given extended attribute values")]
        public List<ExtendedAttributeFilter> ExtendedFilters { get; set; }
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

        ///<summary>
        ///True if location notes should be excluded from the results
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if location notes should be excluded from the results")]
        public bool? ExcludeLocationNotes { get; set; }
    }

    [Route("/GetLocationDescriptionList", "GET")]
    public class LocationDescriptionListServiceRequest
        : IReturn<LocationDescriptionListServiceResponse>
    {
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

    [Route("/GetLocationNotes", "GET")]
    public class LocationNotesServiceRequest
        : IReturn<LocationNotesServiceResponse>
    {
        ///<summary>
        ///Location identifier
        ///</summary>
        [ApiMember(Description="Location identifier", IsRequired=true)]
        public string LocationIdentifier { get; set; }

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
        ///<summary>
        ///Current meter details
        ///</summary>
        [ApiMember(DataType="array", Description="Current meter details")]
        public List<ActiveMeterDetails> ActiveMeterDetails { get; set; }
    }

    public class ApprovalListServiceResponse
        : PublishServiceResponse
    {
        ///<summary>
        ///Approvals
        ///</summary>
        [ApiMember(DataType="array", Description="Approvals")]
        public List<ApprovalMetadata> Approvals { get; set; }
    }

    public class CorrectionListServiceResponse
        : PublishServiceResponse
    {
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
        ///<summary>
        ///Field visit descriptions and data
        ///</summary>
        [ApiMember(DataType="array", Description="Field visit descriptions and data")]
        public List<FieldVisit> FieldVisitData { get; set; }
    }

    public class FieldVisitDataServiceResponse
        : PublishServiceResponse, IFieldVisitData
    {
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

        ///<summary>
        ///Hydraulic Test Activities
        ///</summary>
        [ApiMember(DataType="array", Description="Hydraulic Test Activities")]
        public List<HydraulicTestActivity> HydraulicTestActivities { get; set; }

        ///<summary>
        ///Well integrity activity
        ///</summary>
        [ApiMember(DataType="WellIntegrityActivity", Description="Well integrity activity")]
        public WellIntegrityActivity WellIntegrityActivity { get; set; }

        ///<summary>
        ///Extended attributes
        ///</summary>
        [ApiMember(DataType="array", Description="Extended attributes")]
        public IList<ExtendedAttribute> ExtendedAttributes { get; set; }
    }

    public class FieldVisitDescriptionListServiceResponse
        : PublishServiceResponse
    {
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
        ///<summary>
        ///Field visit readings
        ///</summary>
        [ApiMember(DataType="array", Description="Field visit readings")]
        public List<FieldVisitReading> FieldVisitReadings { get; set; }
    }

    public class GradeListServiceResponse
        : PublishServiceResponse
    {
        ///<summary>
        ///Grades
        ///</summary>
        [ApiMember(DataType="array", Description="Grades")]
        public List<GradeMetadata> Grades { get; set; }
    }

    public class LocationDataServiceResponse
        : PublishServiceResponse
    {
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
        ///DEPRECATED: External locations are no longer supported; value always returns false.
        ///</summary>
        [ApiMember(DataType="boolean", Description="DEPRECATED: External locations are no longer supported; value always returns false.")]
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

        ///<summary>
        ///Property Bag
        ///</summary>
        [ApiMember(Description="Property Bag")]
        public string PropertyBag { get; set; }
    }

    public class LocationDescriptionListServiceResponse
        : PublishServiceResponse
    {
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

    public class LocationNotesServiceResponse
        : PublishServiceResponse
    {
        ///<summary>
        ///Location name
        ///</summary>
        [ApiMember(Description="Location name")]
        public string LocationName { get; set; }

        ///<summary>
        ///Location identifier
        ///</summary>
        [ApiMember(Description="Location identifier")]
        public string LocationIdentifier { get; set; }

        ///<summary>
        ///Location unique id
        ///</summary>
        [ApiMember(DataType="string", Description="Location unique id", Format="guid")]
        public Guid LocationUniqueId { get; set; }

        ///<summary>
        ///Location notes
        ///</summary>
        [ApiMember(DataType="array", Description="Location notes")]
        public List<LocationNote> LocationNotes { get; set; }
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
        ///<summary>
        ///Parameters
        ///</summary>
        [ApiMember(DataType="array", Description="Parameters")]
        public List<ParameterMetadata> Parameters { get; set; }
    }

    public class ProcessorListServiceResponse
        : PublishServiceResponse
    {
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
        ///<summary>
        ///Effective shifts
        ///</summary>
        [ApiMember(DataType="array", Description="Effective shifts")]
        public List<EffectiveShift> EffectiveShifts { get; set; }
    }

    public class RatingModelInputValuesServiceResponse
        : PublishServiceResponse
    {
        ///<summary>
        ///Input values
        ///</summary>
        [ApiMember(DataType="array", Description="Input values")]
        public List<Nullable<Double>> InputValues { get; set; }
    }

    public class RatingModelOutputValuesServiceResponse
        : PublishServiceResponse
    {
        ///<summary>
        ///Output values
        ///</summary>
        [ApiMember(DataType="array", Description="Output values")]
        public List<Nullable<Double>> OutputValues { get; set; }
    }

    public class ReportListServiceResponse
        : PublishServiceResponse
    {
        ///<summary>
        ///Reports
        ///</summary>
        [ApiMember(DataType="array", Description="Reports")]
        public List<Report> Reports { get; set; }
    }

    public class RoundServiceResponse
        : PublishServiceResponse
    {
        ///<summary>
        ///Values rounded as requested
        ///</summary>
        [ApiMember(DataType="array", Description="Values rounded as requested")]
        public List<string> Data { get; set; }
    }

    public class SensorsAndGaugesServiceResponse
        : PublishServiceResponse
    {
        ///<summary>
        ///Monitoring methods
        ///</summary>
        [ApiMember(DataType="array", Description="Monitoring methods")]
        public List<LocationMonitoringMethod> MonitoringMethods { get; set; }
    }

    public class TagListServiceResponse
        : PublishServiceResponse
    {
        ///<summary>
        ///Tags
        ///</summary>
        [ApiMember(DataType="array", Description="Tags")]
        public List<TagDefinition> Tags { get; set; }
    }

    public class TimeAlignedDataServiceResponse
        : PublishServiceResponse
    {
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
        ///Sensors
        ///</summary>
        [ApiMember(DataType="array", Description="Sensors")]
        public List<Sensor> Sensors { get; set; }

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
        ///<summary>
        ///Time series descriptions
        ///</summary>
        [ApiMember(DataType="array", Description="Time series descriptions")]
        public List<TimeSeriesDescription> TimeSeriesDescriptions { get; set; }
    }

    public class TimeSeriesDescriptionListServiceResponse
        : PublishServiceResponse
    {
        ///<summary>
        ///Time series descriptions
        ///</summary>
        [ApiMember(DataType="array", Description="Time series descriptions")]
        public List<TimeSeriesDescription> TimeSeriesDescriptions { get; set; }
    }

    public class TimeSeriesUniqueIdListServiceResponse
        : PublishServiceResponse
    {
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
        public static readonly AquariusServerVersion Version = AquariusServerVersion.Create("26.3.69.0");
    }
}
