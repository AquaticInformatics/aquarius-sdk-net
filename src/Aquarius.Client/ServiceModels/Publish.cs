/* Options:
Date: 2016-12-14 10:01:26
Version: 4.50
Tip: To override a DTO option, remove "//" prefix before updating
BaseUrl: http://autoserver12/AQUARIUS/Publish/v2

GlobalNamespace: Aquarius.Client.ServiceModels.Publish
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
//IncludeTypes: 
//ExcludeTypes: 
//AddNamespaces: 
//AddDefaultXmlNamespace: http://schemas.servicestack.net/types
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ServiceStack;
using ServiceStack.DataAnnotations;
using NodaTime;
using Aquarius.Client.ServiceModels.Publish;


namespace Aquarius.Client.ServiceModels.Publish
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
        [ApiMember(DataType="integer", Description="RSA key size in bits")]
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
        [ApiMember(DataType="integer", Description="Approval level")]
        public int ApprovalLevel { get; set; }

        ///<summary>
        ///Date applied utc
        ///</summary>
        [ApiMember(DataType="DateTime", Description="Date applied utc")]
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
        [ApiMember(DataType="CorrectionType", Description="Type")]
        public CorrectionType Type { get; set; }

        ///<summary>
        ///Start time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Start time")]
        public DateTimeOffset StartTime { get; set; }

        ///<summary>
        ///End time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="End time")]
        public DateTimeOffset EndTime { get; set; }

        ///<summary>
        ///Applied time utc
        ///</summary>
        [ApiMember(DataType="DateTime", Description="Applied time utc")]
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
        : TimeRange
    {
        ///<summary>
        ///Type
        ///</summary>
        [ApiMember(DataType="CorrectionType", Description="Type")]
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
        [ApiMember(DataType="DateTime", Description="Date applied utc")]
        public DateTime DateAppliedUtc { get; set; }

        ///<summary>
        ///User
        ///</summary>
        [ApiMember(Description="User")]
        public string User { get; set; }

        ///<summary>
        ///Operation type
        ///</summary>
        [ApiMember(DataType="MetadataChangeOperationType", Description="Operation type")]
        public MetadataChangeOperationType OperationType { get; set; }

        ///<summary>
        ///Stack position
        ///</summary>
        [ApiMember(DataType="integer", Description="Stack position")]
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
        [ApiMember(DataType="double", Description="Numeric")]
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
        [ApiMember(DataType="DateTimeOffset", Description="Timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        ///<summary>
        ///Value
        ///</summary>
        [ApiMember(DataType="double", Description="Value")]
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
        [ApiMember(DataType="RatingCurveType", Description="Type")]
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
        [ApiMember(DataType="Array<PeriodOfApplicability>", Description="Periods of applicability")]
        public List<PeriodOfApplicability> PeriodsOfApplicability { get; set; }

        ///<summary>
        ///Shifts
        ///</summary>
        [ApiMember(DataType="Array<RatingShift>", Description="Shifts")]
        public List<RatingShift> Shifts { get; set; }

        ///<summary>
        ///Offsets
        ///</summary>
        [ApiMember(DataType="Array<OffsetPoint>", Description="Offsets")]
        public List<OffsetPoint> Offsets { get; set; }

        ///<summary>
        ///Is blended
        ///</summary>
        [ApiMember(DataType="boolean", Description="Is blended")]
        public bool IsBlended { get; set; }

        ///<summary>
        ///Base rating table
        ///</summary>
        [ApiMember(DataType="Array<RatingPoint>", Description="Base rating table")]
        public List<RatingPoint> BaseRatingTable { get; set; }

        ///<summary>
        ///Adjusted rating table
        ///</summary>
        [ApiMember(DataType="Array<RatingPoint>", Description="Adjusted rating table")]
        public List<RatingPoint> AdjustedRatingTable { get; set; }
    }

    public class ExtendedAttribute
    {
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
        [ApiMember(DataType="DateTimeOffset", Description="Start time")]
        public DateTimeOffset? StartTime { get; set; }

        ///<summary>
        ///End time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="End time")]
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
        [ApiMember(DataType="DateTimeOffset", Description="Last modified")]
        public DateTimeOffset LastModified { get; set; }
    }

    public class GapTolerance
        : TimeRange
    {
        ///<summary>
        ///Tolerance in minutes
        ///</summary>
        [ApiMember(DataType="double", Description="Tolerance in minutes")]
        public double? ToleranceInMinutes { get; set; }
    }

    public class GapToleranceOperation
        : GapTolerance
    {
        ///<summary>
        ///Operation type
        ///</summary>
        [ApiMember(DataType="MetadataChangeOperationType", Description="Operation type")]
        public MetadataChangeOperationType OperationType { get; set; }

        ///<summary>
        ///Date applied utc
        ///</summary>
        [ApiMember(DataType="DateTime", Description="Date applied utc")]
        public DateTime DateAppliedUtc { get; set; }

        ///<summary>
        ///User
        ///</summary>
        [ApiMember(Description="User")]
        public string User { get; set; }

        ///<summary>
        ///Stack position
        ///</summary>
        [ApiMember(DataType="integer", Description="Stack position")]
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
        : Grade
    {
        ///<summary>
        ///Date applied utc
        ///</summary>
        [ApiMember(DataType="DateTime", Description="Date applied utc")]
        public DateTime DateAppliedUtc { get; set; }

        ///<summary>
        ///User
        ///</summary>
        [ApiMember(Description="User")]
        public string User { get; set; }

        ///<summary>
        ///Operation type
        ///</summary>
        [ApiMember(DataType="MetadataChangeOperationType", Description="Operation type")]
        public MetadataChangeOperationType OperationType { get; set; }

        ///<summary>
        ///Stack position
        ///</summary>
        [ApiMember(DataType="integer", Description="Stack position")]
        public int StackPosition { get; set; }

        ///<summary>
        ///Comments
        ///</summary>
        [ApiMember(Description="Comments")]
        public string Comments { get; set; }
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
        : InterpolationType
    {
        ///<summary>
        ///Date applied utc
        ///</summary>
        [ApiMember(DataType="DateTime", Description="Date applied utc")]
        public DateTime DateAppliedUtc { get; set; }

        ///<summary>
        ///User
        ///</summary>
        [ApiMember(Description="User")]
        public string User { get; set; }

        ///<summary>
        ///Operation type
        ///</summary>
        [ApiMember(DataType="MetadataChangeOperationType", Description="Operation type")]
        public MetadataChangeOperationType OperationType { get; set; }

        ///<summary>
        ///Stack position
        ///</summary>
        [ApiMember(DataType="integer", Description="Stack position")]
        public int StackPosition { get; set; }

        ///<summary>
        ///Comments
        ///</summary>
        [ApiMember(Description="Comments")]
        public string Comments { get; set; }
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
        [ApiMember(DataType="Array<LocationDatumPeriod>", Description="Datum periods")]
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
        [ApiMember(DataType="double", Description="Offset to standard")]
        public double OffsetToStandard { get; set; }

        ///<summary>
        ///Measurement direction
        ///</summary>
        [ApiMember(DataType="MeasurementDirection", Description="Measurement direction")]
        public MeasurementDirection MeasurementDirection { get; set; }

        ///<summary>
        ///Comments
        ///</summary>
        [ApiMember(Description="Comments")]
        public string Comments { get; set; }

        ///<summary>
        ///Applied time utc
        ///</summary>
        [ApiMember(DataType="Instant", Description="Applied time utc")]
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
        ///Primary folder
        ///</summary>
        [ApiMember(Description="Primary folder")]
        public string PrimaryFolder { get; set; }

        ///<summary>
        ///Secondary folders
        ///</summary>
        [ApiMember(DataType="Array<string>", Description="Secondary folders")]
        public List<string> SecondaryFolders { get; set; }

        ///<summary>
        ///Last modified
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Last modified")]
        public DateTimeOffset LastModified { get; set; }
    }

    public class LocationMonitoringMethod
    {
        ///<summary>
        ///Name
        ///</summary>
        [ApiMember(Description="Name")]
        public string Name { get; set; }

        ///<summary>
        ///Method
        ///</summary>
        [ApiMember(Description="Method")]
        public string Method { get; set; }

        ///<summary>
        ///Parameter
        ///</summary>
        [ApiMember(Description="Parameter")]
        public string Parameter { get; set; }

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
        [ApiMember(DataType="Array<ReferenceStandardOffset>", Description="Reference standard offsets")]
        public List<ReferenceStandardOffset> ReferenceStandardOffsets { get; set; }
    }

    public class LocationRemark
    {
        ///<summary>
        ///Create time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Create time")]
        public DateTimeOffset? CreateTime { get; set; }

        ///<summary>
        ///From time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="From time")]
        public DateTimeOffset? FromTime { get; set; }

        ///<summary>
        ///To time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="To time")]
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
        TopDown,
        BottomUp,
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
        [ApiMember(DataType="DateTimeOffset", Description="Applied time")]
        public DateTimeOffset AppliedTime { get; set; }

        ///<summary>
        ///Applied by user
        ///</summary>
        [ApiMember(Description="Applied by user")]
        public string AppliedByUser { get; set; }

        ///<summary>
        ///Content type
        ///</summary>
        [ApiMember(DataType="MetadataChangeContentType", Description="Content type")]
        public MetadataChangeContentType ContentType { get; set; }

        ///<summary>
        ///Gap tolerance operations
        ///</summary>
        [ApiMember(DataType="Array<GapToleranceOperation>", Description="Gap tolerance operations")]
        public IList<GapToleranceOperation> GapToleranceOperations { get; set; }

        ///<summary>
        ///Grade operations
        ///</summary>
        [ApiMember(DataType="Array<GradeOperation>", Description="Grade operations")]
        public IList<GradeOperation> GradeOperations { get; set; }

        ///<summary>
        ///Interpolation type operations
        ///</summary>
        [ApiMember(DataType="Array<InterpolationTypeOperation>", Description="Interpolation type operations")]
        public IList<InterpolationTypeOperation> InterpolationTypeOperations { get; set; }

        ///<summary>
        ///Method operations
        ///</summary>
        [ApiMember(DataType="Array<MethodOperation>", Description="Method operations")]
        public IList<MethodOperation> MethodOperations { get; set; }

        ///<summary>
        ///Note operations
        ///</summary>
        [ApiMember(DataType="Array<NoteOperation>", Description="Note operations")]
        public IList<NoteOperation> NoteOperations { get; set; }

        ///<summary>
        ///Qualifier operations
        ///</summary>
        [ApiMember(DataType="Array<QualifierOperation>", Description="Qualifier operations")]
        public IList<QualifierOperation> QualifierOperations { get; set; }

        ///<summary>
        ///Correction operations
        ///</summary>
        [ApiMember(DataType="Array<CorrectionOperation>", Description="Correction operations")]
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
        : Method
    {
        ///<summary>
        ///Date applied utc
        ///</summary>
        [ApiMember(DataType="DateTime", Description="Date applied utc")]
        public DateTime DateAppliedUtc { get; set; }

        ///<summary>
        ///User
        ///</summary>
        [ApiMember(Description="User")]
        public string User { get; set; }

        ///<summary>
        ///Operation type
        ///</summary>
        [ApiMember(DataType="MetadataChangeOperationType", Description="Operation type")]
        public MetadataChangeOperationType OperationType { get; set; }

        ///<summary>
        ///Stack position
        ///</summary>
        [ApiMember(DataType="integer", Description="Stack position")]
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
        : Note
    {
        ///<summary>
        ///Date applied utc
        ///</summary>
        [ApiMember(DataType="DateTime", Description="Date applied utc")]
        public DateTime DateAppliedUtc { get; set; }

        ///<summary>
        ///User
        ///</summary>
        [ApiMember(Description="User")]
        public string User { get; set; }

        ///<summary>
        ///Operation type
        ///</summary>
        [ApiMember(DataType="MetadataChangeOperationType", Description="Operation type")]
        public MetadataChangeOperationType OperationType { get; set; }
    }

    public class OffsetPoint
    {
        ///<summary>
        ///Input value
        ///</summary>
        [ApiMember(DataType="double", Description="Input value")]
        public double? InputValue { get; set; }

        ///<summary>
        ///Offset
        ///</summary>
        [ApiMember(DataType="double", Description="Offset")]
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
        [ApiMember(DataType="DateTimeOffset", Description="Start time")]
        public DateTimeOffset StartTime { get; set; }

        ///<summary>
        ///End time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="End time")]
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
        [ApiMember(DataType="Array<string>", Description="Input time series unique ids")]
        public List<Guid> InputTimeSeriesUniqueIds { get; set; }

        ///<summary>
        ///Output time series unique id
        ///</summary>
        [ApiMember(DataType="string", Description="Output time series unique id")]
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
        [ApiMember(DataType="DateTime", Description="Date applied")]
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
        : TimeRange
    {
        ///<summary>
        ///Identifier
        ///</summary>
        [ApiMember(Description="Identifier")]
        public string Identifier { get; set; }

        ///<summary>
        ///Operation type
        ///</summary>
        [ApiMember(DataType="MetadataChangeOperationType", Description="Operation type")]
        public MetadataChangeOperationType OperationType { get; set; }

        ///<summary>
        ///Date applied utc
        ///</summary>
        [ApiMember(DataType="DateTime", Description="Date applied utc")]
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
        [ApiMember(DataType="RatingCurveType", Description="Type")]
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
        [ApiMember(DataType="Array<PeriodOfApplicability>", Description="Periods of applicability")]
        public List<PeriodOfApplicability> PeriodsOfApplicability { get; set; }

        ///<summary>
        ///Shifts
        ///</summary>
        [ApiMember(DataType="Array<RatingShift>", Description="Shifts")]
        public List<RatingShift> Shifts { get; set; }

        ///<summary>
        ///Base rating table
        ///</summary>
        [ApiMember(DataType="Array<RatingPoint>", Description="Base rating table")]
        public List<RatingPoint> BaseRatingTable { get; set; }

        ///<summary>
        ///Offsets
        ///</summary>
        [ApiMember(DataType="Array<OffsetPoint>", Description="Offsets")]
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
        [ApiMember(DataType="DateTimeOffset", Description="Last modified")]
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
        [ApiMember(DataType="double", Description="Input value")]
        public double? InputValue { get; set; }

        ///<summary>
        ///Output value
        ///</summary>
        [ApiMember(DataType="double", Description="Output value")]
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
        [ApiMember(DataType="Array<RatingShiftPoint>", Description="Shift points")]
        public List<RatingShiftPoint> ShiftPoints { get; set; }
    }

    public class RatingShiftPoint
    {
        ///<summary>
        ///Input value
        ///</summary>
        [ApiMember(DataType="double", Description="Input value")]
        public double InputValue { get; set; }

        ///<summary>
        ///Shift
        ///</summary>
        [ApiMember(DataType="double", Description="Shift")]
        public double Shift { get; set; }
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
        [ApiMember(DataType="double", Description="Offset to reference standard")]
        public double OffsetToReferenceStandard { get; set; }
    }

    public class StagePoint
    {
        ///<summary>
        ///Input value
        ///</summary>
        [ApiMember(DataType="double", Description="Input value")]
        public double InputValue { get; set; }

        ///<summary>
        ///Correction
        ///</summary>
        [ApiMember(DataType="double", Description="Correction")]
        public double Correction { get; set; }

        ///<summary>
        ///Corrected value
        ///</summary>
        [ApiMember(DataType="double", Description="Corrected value")]
        public double CorrectedValue { get; set; }
    }

    public class StatisticalDateTimeOffset
    {
        ///<summary>
        ///Date time offset
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Date time offset")]
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

    public class TimeRange
    {
        ///<summary>
        ///Start time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Start time")]
        public DateTimeOffset StartTime { get; set; }

        ///<summary>
        ///End time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="End time")]
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
        [ApiMember(DataType="string", Description="Unique id")]
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
        ///Unit
        ///</summary>
        [ApiMember(Description="Unit")]
        public string Unit { get; set; }

        ///<summary>
        ///Utc offset
        ///</summary>
        [ApiMember(DataType="double", Description="Utc offset")]
        public double UtcOffset { get; set; }

        ///<summary>
        ///Utc offset iso duration
        ///</summary>
        [ApiMember(DataType="Offset", Description="Utc offset iso duration")]
        public Offset UtcOffsetIsoDuration { get; set; }

        ///<summary>
        ///Last modified
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Last modified")]
        public DateTimeOffset LastModified { get; set; }

        ///<summary>
        ///Raw start time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Raw start time")]
        public DateTimeOffset? RawStartTime { get; set; }

        ///<summary>
        ///Raw end time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Raw end time")]
        public DateTimeOffset? RawEndTime { get; set; }

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
        [ApiMember(DataType="Array<ExtendedAttribute>", Description="Extended attributes")]
        public IList<ExtendedAttribute> ExtendedAttributes { get; set; }

        ///<summary>
        ///Thresholds
        ///</summary>
        [ApiMember(DataType="Array<TimeSeriesThreshold>", Description="Thresholds")]
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
        [ApiMember(DataType="integer", Description="Severity")]
        public int Severity { get; set; }

        ///<summary>
        ///Type
        ///</summary>
        [ApiMember(DataType="ThresholdType", Description="Type")]
        public ThresholdType Type { get; set; }

        ///<summary>
        ///Display color
        ///</summary>
        [ApiMember(Description="Display color")]
        public string DisplayColor { get; set; }

        ///<summary>
        ///Periods
        ///</summary>
        [ApiMember(DataType="Array<TimeSeriesThresholdPeriod>", Description="Periods")]
        public List<TimeSeriesThresholdPeriod> Periods { get; set; }
    }

    public class TimeSeriesThresholdPeriod
    {
        ///<summary>
        ///Start time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Start time")]
        public DateTimeOffset StartTime { get; set; }

        ///<summary>
        ///End time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="End time")]
        public DateTimeOffset EndTime { get; set; }

        ///<summary>
        ///Applied time
        ///</summary>
        [ApiMember(DataType="DateTime", Description="Applied time")]
        public DateTime AppliedTime { get; set; }

        ///<summary>
        ///Reference value
        ///</summary>
        [ApiMember(DataType="double", Description="Reference value")]
        public double ReferenceValue { get; set; }

        ///<summary>
        ///Secondary reference value
        ///</summary>
        [ApiMember(DataType="double", Description="Secondary reference value")]
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
        [ApiMember(DataType="string", Description="Unique id")]
        public Guid UniqueId { get; set; }

        ///<summary>
        ///First point changed
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="First point changed")]
        public DateTimeOffset? FirstPointChanged { get; set; }

        ///<summary>
        ///Has attribute change
        ///</summary>
        [ApiMember(DataType="boolean", Description="Has attribute change")]
        public bool? HasAttributeChange { get; set; }
    }

    public class UnitMetadata
    {
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
        [ApiMember(DataType="integer", Description="Number of transects")]
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
        [ApiMember(DataType="double", Description="Adjustment amount")]
        public double? AdjustmentAmount { get; set; }

        ///<summary>
        ///Adjustment type
        ///</summary>
        [ApiMember(DataType="AdjustmentType", Description="Adjustment type")]
        public AdjustmentType AdjustmentType { get; set; }

        ///<summary>
        ///Reason for adjustment
        ///</summary>
        [ApiMember(DataType="ReasonForAdjustmentType", Description="Reason for adjustment")]
        public ReasonForAdjustmentType ReasonForAdjustment { get; set; }
    }

    public class Attachment
    {
        ///<summary>
        ///Attachment type
        ///</summary>
        [ApiMember(DataType="AttachmentType", Description="Attachment type")]
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
        ///Date created
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Date created")]
        public DateTimeOffset DateCreated { get; set; }

        ///<summary>
        ///Date uploaded
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Date uploaded")]
        public DateTimeOffset DateUploaded { get; set; }

        ///<summary>
        ///Date last accessed
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Date last accessed")]
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
        [ApiMember(DataType="double", Description="Gps latitude")]
        public double? GpsLatitude { get; set; }

        ///<summary>
        ///Gps longitude
        ///</summary>
        [ApiMember(DataType="double", Description="Gps longitude")]
        public double? GpsLongitude { get; set; }

        ///<summary>
        ///Url
        ///</summary>
        [ApiMember(Description="Url")]
        public string Url { get; set; }
    }

    public class CalibrationCheck
    {
        ///<summary>
        ///Parameter
        ///</summary>
        [ApiMember(Description="Parameter")]
        public string Parameter { get; set; }

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
        [ApiMember(DataType="CalibrationCheckType", Description="Calibration check type")]
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
        [ApiMember(DataType="DateTimeOffset", Description="Time")]
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
        [ApiMember(DataType="ControlCleanedType", Description="Control cleaned")]
        public ControlCleanedType ControlCleaned { get; set; }

        ///<summary>
        ///Control condition
        ///</summary>
        [ApiMember(DataType="ControlConditionType", Description="Control condition")]
        public ControlConditionType ControlCondition { get; set; }

        ///<summary>
        ///Date cleaned
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Date cleaned")]
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
        [ApiMember(DataType="Array<VolumetricDischargeActivity>", Description="Volumetric discharge activities")]
        public List<VolumetricDischargeActivity> VolumetricDischargeActivities { get; set; }

        ///<summary>
        ///Engineered structure discharge activities
        ///</summary>
        [ApiMember(DataType="Array<EngineeredStructureDischargeActivity>", Description="Engineered structure discharge activities")]
        public List<EngineeredStructureDischargeActivity> EngineeredStructureDischargeActivities { get; set; }

        ///<summary>
        ///Point velocity discharge activities
        ///</summary>
        [ApiMember(DataType="Array<PointVelocityDischargeActivity>", Description="Point velocity discharge activities")]
        public List<PointVelocityDischargeActivity> PointVelocityDischargeActivities { get; set; }

        ///<summary>
        ///Other method discharge activities
        ///</summary>
        [ApiMember(DataType="Array<OtherMethodDischargeActivity>", Description="Other method discharge activities")]
        public List<OtherMethodDischargeActivity> OtherMethodDischargeActivities { get; set; }

        ///<summary>
        ///Adcp discharge activities
        ///</summary>
        [ApiMember(DataType="Array<AdcpDischargeActivity>", Description="Adcp discharge activities")]
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
        [ApiMember(DataType="DateTimeOffset", Description="Start time")]
        public DateTimeOffset? StartTime { get; set; }

        ///<summary>
        ///End time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="End time")]
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
        [ApiMember(DataType="HorizontalFlowType", Description="Horizontal flow")]
        public HorizontalFlowType HorizontalFlow { get; set; }

        ///<summary>
        ///Channel stability
        ///</summary>
        [ApiMember(DataType="ChannelStabilityType", Description="Channel stability")]
        public ChannelStabilityType ChannelStability { get; set; }

        ///<summary>
        ///Channel material
        ///</summary>
        [ApiMember(DataType="ChannelMaterialType", Description="Channel material")]
        public ChannelMaterialType ChannelMaterial { get; set; }

        ///<summary>
        ///Channel evenness
        ///</summary>
        [ApiMember(DataType="ChannelEvennessType", Description="Channel evenness")]
        public ChannelEvennessType ChannelEvenness { get; set; }

        ///<summary>
        ///Vertical velocity distribution
        ///</summary>
        [ApiMember(DataType="VerticalVelocityDistributionType", Description="Vertical velocity distribution")]
        public VerticalVelocityDistributionType VerticalVelocityDistribution { get; set; }

        ///<summary>
        ///Velocity variation
        ///</summary>
        [ApiMember(DataType="VelocityVariationType", Description="Velocity variation")]
        public VelocityVariationType VelocityVariation { get; set; }

        ///<summary>
        ///Measurement location to gage
        ///</summary>
        [ApiMember(DataType="MeasurementLocationToGageType", Description="Measurement location to gage")]
        public MeasurementLocationToGageType MeasurementLocationToGage { get; set; }

        ///<summary>
        ///Meter suspension
        ///</summary>
        [ApiMember(DataType="MeterSuspensionType", Description="Meter suspension")]
        public MeterSuspensionType MeterSuspension { get; set; }

        ///<summary>
        ///Deployment method
        ///</summary>
        [ApiMember(DataType="DeploymentMethodType", Description="Deployment method")]
        public DeploymentMethodType DeploymentMethod { get; set; }

        ///<summary>
        ///Current meter
        ///</summary>
        [ApiMember(DataType="CurrentMeterType", Description="Current meter")]
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
        [ApiMember(DataType="DateTimeOffset", Description="Measurement start time")]
        public DateTimeOffset? MeasurementStartTime { get; set; }

        ///<summary>
        ///Measurement end time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Measurement end time")]
        public DateTimeOffset? MeasurementEndTime { get; set; }

        ///<summary>
        ///Measurement time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Measurement time")]
        public DateTimeOffset MeasurementTime { get; set; }

        ///<summary>
        ///Party
        ///</summary>
        [ApiMember(Description="Party")]
        public string Party { get; set; }

        ///<summary>
        ///Base flow
        ///</summary>
        [ApiMember(DataType="BaseFlowType", Description="Base flow")]
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
        [ApiMember(DataType="DischargeMeasurementReasonType", Description="Discharge measurement reason")]
        public DischargeMeasurementReasonType DischargeMeasurementReason { get; set; }

        ///<summary>
        ///Comments
        ///</summary>
        [ApiMember(Description="Comments")]
        public string Comments { get; set; }

        ///<summary>
        ///Gage height calculation
        ///</summary>
        [ApiMember(DataType="GageHeightCalculationType", Description="Gage height calculation")]
        public GageHeightCalculationType GageHeightCalculation { get; set; }

        ///<summary>
        ///Gage height readings
        ///</summary>
        [ApiMember(DataType="Array<GageHeightReading>", Description="Gage height readings")]
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
        ///Measurement grade
        ///</summary>
        [ApiMember(DataType="MeasurementGradeType", Description="Measurement grade")]
        public MeasurementGradeType MeasurementGrade { get; set; }

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

    public class FieldVisitApproval
    {
        ///<summary>
        ///Approval level
        ///</summary>
        [ApiMember(DataType="long integer", Description="Approval level")]
        public long ApprovalLevel { get; set; }

        ///<summary>
        ///Level description
        ///</summary>
        [ApiMember(Description="Level description")]
        public string LevelDescription { get; set; }
    }

    public class GageHeightAtZeroFlowActivity
    {
        ///<summary>
        ///Observed date
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Observed date")]
        public DateTimeOffset? ObservedDate { get; set; }

        ///<summary>
        ///Applicable since
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Applicable since")]
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
        [ApiMember(DataType="DateTimeOffset", Description="Reading time")]
        public DateTimeOffset? ReadingTime { get; set; }

        ///<summary>
        ///Gage height
        ///</summary>
        [ApiMember(DataType="DoubleWithDisplay", Description="Gage height")]
        public DoubleWithDisplay GageHeight { get; set; }
    }

    public class Inspection
    {
        ///<summary>
        ///Inspection type
        ///</summary>
        [ApiMember(DataType="InspectionType", Description="Inspection type")]
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
        [ApiMember(DataType="DateTimeOffset", Description="Time")]
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
        [ApiMember(DataType="Array<Reading>", Description="Readings")]
        public List<Reading> Readings { get; set; }

        ///<summary>
        ///Calibration checks
        ///</summary>
        [ApiMember(DataType="Array<CalibrationCheck>", Description="Calibration checks")]
        public List<CalibrationCheck> CalibrationChecks { get; set; }

        ///<summary>
        ///Inspections
        ///</summary>
        [ApiMember(DataType="Array<Inspection>", Description="Inspections")]
        public List<Inspection> Inspections { get; set; }

        ///<summary>
        ///Is valid
        ///</summary>
        [ApiMember(DataType="boolean", Description="Is valid")]
        public bool IsValid { get; set; }
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
        [ApiMember(DataType="integer", Description="Number of panels")]
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
        [ApiMember(DataType="DischargeMethodType", Description="Discharge method")]
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
        ///Start point
        ///</summary>
        [ApiMember(DataType="StartPointType", Description="Start point")]
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
        ///Parameter
        ///</summary>
        [ApiMember(Description="Parameter")]
        public string Parameter { get; set; }

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
        [ApiMember(DataType="ReadingType", Description="Reading type")]
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
        [ApiMember(DataType="DateTimeOffset", Description="Time")]
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
        [ApiMember(DataType="DateTimeOffset", Description="Expiration date")]
        public DateTimeOffset? ExpirationDate { get; set; }
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
        [ApiMember(DataType="Array<VolumetricDischargeReading>", Description="Volumetric discharge readings")]
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
        [ApiMember(DataType="DateTimeOffset", Description="First used date")]
        public DateTimeOffset FirstUsedDate { get; set; }

        ///<summary>
        ///Equations
        ///</summary>
        [ApiMember(DataType="Array<ActiveMeterCalibrationEquation>", Description="Equations")]
        public List<ActiveMeterCalibrationEquation> Equations { get; set; }
    }

    public class ActiveMeterCalibrationEquation
    {
        ///<summary>
        ///Range start
        ///</summary>
        [ApiMember(DataType="double", Description="Range start")]
        public double? RangeStart { get; set; }

        ///<summary>
        ///Range end
        ///</summary>
        [ApiMember(DataType="double", Description="Range end")]
        public double? RangeEnd { get; set; }

        ///<summary>
        ///Slope
        ///</summary>
        [ApiMember(DataType="double", Description="Slope")]
        public double Slope { get; set; }

        ///<summary>
        ///Intercept
        ///</summary>
        [ApiMember(DataType="double", Description="Intercept")]
        public double Intercept { get; set; }

        ///<summary>
        ///Intercept unit
        ///</summary>
        [ApiMember(Description="Intercept unit")]
        public string InterceptUnit { get; set; }
    }

    public class ActiveMeterDetails
    {
        public ActiveMeterDetails()
        {
            MeterCalibrations = new List<ActiveMeterCalibration>{};
        }

        ///<summary>
        ///Meter type
        ///</summary>
        [ApiMember(DataType="MeterType", Description="Meter type")]
        public MeterType? MeterType { get; set; }

        ///<summary>
        ///Serial number
        ///</summary>
        [ApiMember(Description="Serial number")]
        public string SerialNumber { get; set; }

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
        [ApiMember(DataType="Array<ActiveMeterCalibration>", Description="Meter calibrations")]
        public List<ActiveMeterCalibration> MeterCalibrations { get; set; }
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
        [ApiMember(DataType="string", Description="The unique ID of the time series", IsRequired=true)]
        public Guid TimeSeriesUniqueId { get; set; }

        ///<summary>
        ///Filter results to items with a StartTime at or after the QueryFrom time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Filter results to items with a StartTime at or after the QueryFrom time")]
        public DateTimeOffset? QueryFrom { get; set; }

        ///<summary>
        ///Filter results to items with an EndTime at or before the QueryTo time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Filter results to items with an EndTime at or before the QueryTo time")]
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
        [ApiMember(DataType="DateTimeOffset", Description="Filter results to items with a ProcessorPeriod.StartTime at or after the QueryFrom time")]
        public DateTimeOffset? QueryFrom { get; set; }

        ///<summary>
        ///Filter results to items with a ProcessorPeriod.EndTime at or before the QueryTo time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Filter results to items with a ProcessorPeriod.EndTime at or before the QueryTo time")]
        public DateTimeOffset? QueryTo { get; set; }
    }

    [Route("/GetDownchainProcessorListByTimeSeries", "GET")]
    public class DownchainProcessorListByTimeSeriesServiceRequest
        : IReturn<ProcessorListServiceResponse>
    {
        ///<summary>
        ///Unique ID of the time series
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the time series", IsRequired=true)]
        public Guid TimeSeriesUniqueId { get; set; }

        ///<summary>
        ///Filter results to items with a ProcessorPeriod.StartTime at or after the QueryFrom time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Filter results to items with a ProcessorPeriod.StartTime at or after the QueryFrom time")]
        public DateTimeOffset? QueryFrom { get; set; }

        ///<summary>
        ///Filter results to items with a ProcessorPeriod.EndTime at or before the QueryTo time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Filter results to items with a ProcessorPeriod.EndTime at or before the QueryTo time")]
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
        [ApiMember(DataType="double", Description="Table step size increment. Defaults to 0.01")]
        public double? StepSize { get; set; }

        ///<summary>
        ///Forces the response time values to a specific UTC offset. Defaults to the location UTC offset
        ///</summary>
        [ApiMember(DataType="double", Description="Forces the response time values to a specific UTC offset. Defaults to the location UTC offset")]
        public double? UtcOffset { get; set; }

        ///<summary>
        ///Table start value. Required for equation-based ratings. Defaults to minimum table value for table-based ratings
        ///</summary>
        [ApiMember(DataType="double", Description="Table start value. Required for equation-based ratings. Defaults to minimum table value for table-based ratings")]
        public double? StartValue { get; set; }

        ///<summary>
        ///Table end value. Required for equation-based ratings. Defaults to maximum table value for table-based ratings
        ///</summary>
        [ApiMember(DataType="double", Description="Table end value. Required for equation-based ratings. Defaults to maximum table value for table-based ratings")]
        public double? EndValue { get; set; }

        ///<summary>
        ///Effective time of the calculation. Defaults to the current time if not specified
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Effective time of the calculation. Defaults to the current time if not specified")]
        public DateTimeOffset? EffectiveTime { get; set; }
    }

    [Route("/GetExpandedStageTable", "GET")]
    public class ExpandedStageTableServiceRequest
        : IReturn<ExpandedStageTableServiceResponse>
    {
        ///<summary>
        ///The unique ID of the time series
        ///</summary>
        [ApiMember(DataType="string", Description="The unique ID of the time series", IsRequired=true)]
        public Guid TimeSeriesUniqueId { get; set; }

        ///<summary>
        ///Table step size increment. Defaults to 0.01
        ///</summary>
        [ApiMember(DataType="double", Description="Table step size increment. Defaults to 0.01")]
        public double? StepSize { get; set; }

        ///<summary>
        ///Forces the response time values to a specific UTC offset. Defaults to the time series UTC offset
        ///</summary>
        [ApiMember(DataType="double", Description="Forces the response time values to a specific UTC offset. Defaults to the time series UTC offset")]
        public double? UtcOffset { get; set; }

        ///<summary>
        ///Table starting value
        ///</summary>
        [ApiMember(DataType="double", Description="Table starting value", IsRequired=true)]
        public double? StartValue { get; set; }

        ///<summary>
        ///Table ending value
        ///</summary>
        [ApiMember(DataType="double", Description="Table ending value", IsRequired=true)]
        public double? EndValue { get; set; }
    }

    [Route("/GetFieldVisitData", "GET")]
    public class FieldVisitDataServiceRequest
        : IReturn<FieldVisitDataServiceResponse>
    {
        ///<summary>
        ///Field visit identifier
        ///</summary>
        [ApiMember(Description="Field visit identifier", IsRequired=true)]
        public string FieldVisitIdentifier { get; set; }

        ///<summary>
        ///If set, only report the specific activity type: One of DischargeSummary, DischargeVolumetric, DischargeEngineeredStructure, DischargePointVelocity, DischargeAdcp, GageHeightAtZeroFlow, ControlCondition, DischargeOtherMethod, or Inspection
        ///</summary>
        [ApiMember(Description="If set, only report the specific activity type: One of DischargeSummary, DischargeVolumetric, DischargeEngineeredStructure, DischargePointVelocity, DischargeAdcp, GageHeightAtZeroFlow, ControlCondition, DischargeOtherMethod, or Inspection")]
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
        [ApiMember(DataType="DateTimeOffset", Description="Filter results to items with a StartTime at or after the QueryFrom time")]
        public DateTimeOffset? QueryFrom { get; set; }

        ///<summary>
        ///Filter results to items with an EndTime at or before the QueryTo time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Filter results to items with an EndTime at or before the QueryTo time")]
        public DateTimeOffset? QueryTo { get; set; }

        ///<summary>
        ///True if the results should include invalid field visits which require operator attention.
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if the results should include invalid field visits which require operator attention.")]
        public bool? IncludeInvalidFieldVisits { get; set; }

        ///<summary>
        ///Filter results to items modified at or after the ChangesSinceToken time
        ///</summary>
        [ApiMember(DataType="DateTime", Description="Filter results to items modified at or after the ChangesSinceToken time")]
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

    [Route("/GetGradeList", "GET")]
    public class GradeListServiceRequest
        : IReturn<GradeListServiceResponse>
    {
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
        ///Filter results to items matching the given extended attribute values
        ///</summary>
        [ApiMember(DataType="Array<ExtendedAttributeFilter>", Description="Filter results to items matching the given extended attribute values")]
        public List<ExtendedAttributeFilter> ExtendedFilters { get; set; }

        ///<summary>
        ///Filter results to items modified at or after the ChangesSinceToken time
        ///</summary>
        [ApiMember(DataType="DateTime", Description="Filter results to items modified at or after the ChangesSinceToken time")]
        public DateTime? ChangesSinceToken { get; set; }
    }

    [Route("/GetMetadataChangeTransactionList", "GET")]
    public class MetadataChangeTransactionListServiceRequest
        : IReturn<MetadataChangeTransactionListServiceResponse>
    {
        ///<summary>
        ///The unique ID of the time series
        ///</summary>
        [ApiMember(DataType="string", Description="The unique ID of the time series", IsRequired=true)]
        public Guid TimeSeriesUniqueId { get; set; }

        ///<summary>
        ///Filter results to items with a StartTime at or after the QueryFrom time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Filter results to items with a StartTime at or after the QueryFrom time")]
        public DateTimeOffset? QueryFrom { get; set; }

        ///<summary>
        ///Filter results to items with an EndTime at or before the QueryTo time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Filter results to items with an EndTime at or before the QueryTo time")]
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
        [ApiMember(DataType="double", Description="Forces the response time values to a specific UTC offset. Defaults to the location UTC offset")]
        public double? UtcOffset { get; set; }

        ///<summary>
        ///Filter results to curves with a Period.StartTime at or after the QueryFrom time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Filter results to curves with a Period.StartTime at or after the QueryFrom time")]
        public DateTimeOffset? QueryFrom { get; set; }

        ///<summary>
        ///Filter results to curves with a Period.EndTime at or before the QueryTo time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Filter results to curves with a Period.EndTime at or before the QueryTo time")]
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
        [ApiMember(DataType="DateTime", Description="Filter results to items modified at or after the ChangesSinceToken time")]
        public DateTime? ChangesSinceToken { get; set; }
    }

    [Route("/GetRatingModelEffectiveShifts", "GET")]
    public class RatingModelEffectiveShiftsServiceRequest
        : IReturn<RatingModelEffectiveShiftsServiceResponse>
    {
        ///<summary>
        ///Unique ID of the input time series
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the input time series", IsRequired=true)]
        public Guid TimeSeriesUniqueId { get; set; }

        ///<summary>
        ///Rating model identifier
        ///</summary>
        [ApiMember(Description="Rating model identifier", IsRequired=true)]
        public string RatingModelIdentifier { get; set; }

        ///<summary>
        ///Read the input time series starting at the QueryFrom time. Defaults to beginning of record
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Read the input time series starting at the QueryFrom time. Defaults to beginning of record")]
        public DateTimeOffset? QueryFrom { get; set; }

        ///<summary>
        ///Read the input time series ending at the QueryTo time. Defaults to the end of record.
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Read the input time series ending at the QueryTo time. Defaults to the end of record.")]
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
        [ApiMember(DataType="Array<double>", Description="Output values", IsRequired=true)]
        public List<double> OutputValues { get; set; }

        ///<summary>
        ///Effective time of the calculation. Defaults to the current time if not specified
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Effective time of the calculation. Defaults to the current time if not specified")]
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
        [ApiMember(Description="Rating model identifier")]
        public string RatingModelIdentifier { get; set; }

        ///<summary>
        ///Input values
        ///</summary>
        [ApiMember(DataType="Array<double>", Description="Input values")]
        public List<double> InputValues { get; set; }

        ///<summary>
        ///Effective time of the calculation. Defaults to the current time if not specified
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Effective time of the calculation. Defaults to the current time if not specified")]
        public DateTimeOffset? EffectiveTime { get; set; }

        ///<summary>
        ///Set to false to disable rating curve shifts, otherwise true
        ///</summary>
        [ApiMember(DataType="boolean", Description="Set to false to disable rating curve shifts, otherwise true")]
        public bool? ApplyShifts { get; set; }
    }

    [Route("/GetSensorsAndGauges", "GET")]
    public class SensorsAndGaugesServiceRequest
        : IReturn<SensorsAndGaugesServiceResponse>
    {
        ///<summary>
        ///Location identifier
        ///</summary>
        [ApiMember(Description="Location identifier", IsRequired=true)]
        public string LocationIdentifier { get; set; }
    }

    [Route("/GetApprovalsTransactionList", "GET")]
    public class TimeSeriesApprovalsTransactionListServiceRequest
        : IReturn<TimeSeriesApprovalsTransactionListServiceResponse>
    {
        ///<summary>
        ///The unique ID of the time series
        ///</summary>
        [ApiMember(DataType="string", Description="The unique ID of the time series", IsRequired=true)]
        public Guid TimeSeriesUniqueId { get; set; }

        ///<summary>
        ///Filter results to items with a StartTime at or after the QueryFrom time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Filter results to items with a StartTime at or after the QueryFrom time")]
        public DateTimeOffset? QueryFrom { get; set; }

        ///<summary>
        ///Filter results to items with an EndTime at or before the QueryTo time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Filter results to items with an EndTime at or before the QueryTo time")]
        public DateTimeOffset? QueryTo { get; set; }
    }

    [Route("/GetTimeSeriesCorrectedData", "GET")]
    public class TimeSeriesDataCorrectedServiceRequest
        : IReturn<TimeSeriesDataServiceResponse>
    {
        ///<summary>
        ///The unique ID of the time series
        ///</summary>
        [ApiMember(DataType="string", Description="The unique ID of the time series", IsRequired=true)]
        public Guid TimeSeriesUniqueId { get; set; }

        ///<summary>
        ///Filter results to items at or after the QueryFrom time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Filter results to items at or after the QueryFrom time")]
        public DateTimeOffset? QueryFrom { get; set; }

        ///<summary>
        ///Filter results to items at or before the QueryTo time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Filter results to items at or before the QueryTo time")]
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
        [ApiMember(DataType="double", Description="Forces the response time values to a specific UTC offset. Defaults to the time series UTC offset")]
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
        [ApiMember(DataType="string", Description="The unique ID of the time series", IsRequired=true)]
        public Guid TimeSeriesUniqueId { get; set; }

        ///<summary>
        ///Filter results to items at or after the QueryFrom time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Filter results to items at or after the QueryFrom time")]
        public DateTimeOffset? QueryFrom { get; set; }

        ///<summary>
        ///Filter results to items at or before the QueryTo time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Filter results to items at or before the QueryTo time")]
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
        [ApiMember(DataType="double", Description="Forces the response time values to a specific UTC offset. Defaults to the time series UTC offset")]
        public double? UtcOffset { get; set; }

        ///<summary>
        ///True if data values should have rounding rules applied
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if data values should have rounding rules applied")]
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

        ///<summary>
        ///A collection of time series unique IDs to query. Limited to roughly 60 items per request.
        ///</summary>
        [ApiMember(DataType="Array<string>", Description="A collection of time series unique IDs to query. Limited to roughly 60 items per request.")]
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
        [ApiMember(DataType="Array<ExtendedAttributeFilter>", Description="Filter results to items matching the given extended attribute values")]
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
        [ApiMember(DataType="DateTime", Description="Filter results to items modified at or after the ChangesSinceToken time")]
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
        [ApiMember(DataType="Array<ExtendedAttributeFilter>", Description="Filter results to items matching the given extended attribute values")]
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
        ///<summary>
        ///Unique ID of the time series
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the time series", IsRequired=true)]
        public Guid TimeSeriesUniqueId { get; set; }

        ///<summary>
        ///Filter results to items with a ProcessorPeriod.StartTime at or after the QueryFrom time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Filter results to items with a ProcessorPeriod.StartTime at or after the QueryFrom time")]
        public DateTimeOffset? QueryFrom { get; set; }

        ///<summary>
        ///Filter results to items with a ProcessorPeriod.EndTime at or before the QueryTo time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Filter results to items with a ProcessorPeriod.EndTime at or before the QueryTo time")]
        public DateTimeOffset? QueryTo { get; set; }
    }

    public class ActiveMetersAndCalibrationsServiceResponse
    {
        public ActiveMetersAndCalibrationsServiceResponse()
        {
            ActiveMeterDetails = new List<ActiveMeterDetails> { };
        }

        ///<summary>
        ///Response version
        ///</summary>
        [ApiMember(DataType = "integer", Description = "Response version")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(DataType = "DateTimeOffset", Description = "Response time")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Active meter details
        ///</summary>
        [ApiMember(DataType = "Array<ActiveMeterDetails>", Description = "Active meter details")]
        public List<ActiveMeterDetails> ActiveMeterDetails { get; set; }
    }

    public class ApprovalListServiceResponse
    {
        public ApprovalListServiceResponse()
        {
            Approvals = new List<ApprovalMetadata>{};
        }

        ///<summary>
        ///Response version
        ///</summary>
        [ApiMember(DataType="integer", Description="Response version")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Response time")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Approvals
        ///</summary>
        [ApiMember(DataType="Array<ApprovalMetadata>", Description="Approvals")]
        public List<ApprovalMetadata> Approvals { get; set; }
    }

    public class CorrectionListServiceResponse
    {
        public CorrectionListServiceResponse()
        {
            Corrections = new List<Correction>{};
        }

        ///<summary>
        ///Response version
        ///</summary>
        [ApiMember(DataType="integer", Description="Response version")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Response time")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Corrections
        ///</summary>
        [ApiMember(DataType="Array<Correction>", Description="Corrections")]
        public List<Correction> Corrections { get; set; }
    }

    public class EffectiveRatingCurveServiceResponse
    {
        ///<summary>
        ///Response version
        ///</summary>
        [ApiMember(DataType="integer", Description="Response version")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Response time")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Expanded rating curve
        ///</summary>
        [ApiMember(DataType="ExpandedRatingCurve", Description="Expanded rating curve")]
        public ExpandedRatingCurve ExpandedRatingCurve { get; set; }
    }

    public class ExpandedStageTableServiceResponse
    {
        public ExpandedStageTableServiceResponse()
        {
            ExpandedStageTable = new List<StagePoint>{};
            Corrections = new List<Correction>{};
        }

        ///<summary>
        ///Response version
        ///</summary>
        [ApiMember(DataType="integer", Description="Response version")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Response time")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Expanded stage table
        ///</summary>
        [ApiMember(DataType="Array<StagePoint>", Description="Expanded stage table")]
        public List<StagePoint> ExpandedStageTable { get; set; }

        ///<summary>
        ///Corrections
        ///</summary>
        [ApiMember(DataType="Array<Correction>", Description="Corrections")]
        public List<Correction> Corrections { get; set; }
    }

    public class FieldVisitDataServiceResponse
    {
        public FieldVisitDataServiceResponse()
        {
            Attachments = new List<Attachment>{};
            DischargeActivities = new List<DischargeActivity>{};
        }

        ///<summary>
        ///Response version
        ///</summary>
        [ApiMember(DataType="integer", Description="Response version")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Response time")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Attachments
        ///</summary>
        [ApiMember(DataType="Array<Attachment>", Description="Attachments")]
        public List<Attachment> Attachments { get; set; }

        ///<summary>
        ///Discharge activities
        ///</summary>
        [ApiMember(DataType="Array<DischargeActivity>", Description="Discharge activities")]
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
        ///Approval
        ///</summary>
        [ApiMember(DataType="FieldVisitApproval", Description="Approval")]
        public FieldVisitApproval Approval { get; set; }
    }

    public class FieldVisitDescriptionListServiceResponse
    {
        public FieldVisitDescriptionListServiceResponse()
        {
            FieldVisitDescriptions = new List<FieldVisitDescription>{};
        }

        ///<summary>
        ///Response version
        ///</summary>
        [ApiMember(DataType="integer", Description="Response version")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Response time")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Field visit descriptions
        ///</summary>
        [ApiMember(DataType="Array<FieldVisitDescription>", Description="Field visit descriptions")]
        public List<FieldVisitDescription> FieldVisitDescriptions { get; set; }

        ///<summary>
        ///Next token
        ///</summary>
        [ApiMember(DataType="DateTime", Description="Next token")]
        public DateTime? NextToken { get; set; }
    }

    public class GradeListServiceResponse
    {
        public GradeListServiceResponse()
        {
            Grades = new List<GradeMetadata>{};
        }

        ///<summary>
        ///Response version
        ///</summary>
        [ApiMember(DataType="integer", Description="Response version")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Response time")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Grades
        ///</summary>
        [ApiMember(DataType="Array<GradeMetadata>", Description="Grades")]
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

        ///<summary>
        ///Response version
        ///</summary>
        [ApiMember(DataType="integer", Description="Response version")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Response time")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

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
        ///Location type
        ///</summary>
        [ApiMember(Description="Location type")]
        public string LocationType { get; set; }

        ///<summary>
        ///Latitude
        ///</summary>
        [ApiMember(DataType="double", Description="Latitude")]
        public double Latitude { get; set; }

        ///<summary>
        ///Longitude
        ///</summary>
        [ApiMember(DataType="double", Description="Longitude")]
        public double Longitude { get; set; }

        ///<summary>
        ///Srid
        ///</summary>
        [ApiMember(DataType="double", Description="Srid")]
        public double Srid { get; set; }

        ///<summary>
        ///Elevation units
        ///</summary>
        [ApiMember(Description="Elevation units")]
        public string ElevationUnits { get; set; }

        ///<summary>
        ///Elevation
        ///</summary>
        [ApiMember(DataType="double", Description="Elevation")]
        public double Elevation { get; set; }

        ///<summary>
        ///Utc offset
        ///</summary>
        [ApiMember(DataType="double", Description="Utc offset")]
        public double UtcOffset { get; set; }

        ///<summary>
        ///Extended attributes
        ///</summary>
        [ApiMember(DataType="Array<ExtendedAttribute>", Description="Extended attributes")]
        public List<ExtendedAttribute> ExtendedAttributes { get; set; }

        ///<summary>
        ///Location remarks
        ///</summary>
        [ApiMember(DataType="Array<LocationRemark>", Description="Location remarks")]
        public List<LocationRemark> LocationRemarks { get; set; }

        ///<summary>
        ///Attachments
        ///</summary>
        [ApiMember(DataType="Array<Attachment>", Description="Attachments")]
        public List<Attachment> Attachments { get; set; }

        ///<summary>
        ///Location datum
        ///</summary>
        [ApiMember(DataType="LocationDatum", Description="Location datum")]
        public LocationDatum LocationDatum { get; set; }
    }

    public class LocationDescriptionListServiceResponse
    {
        public LocationDescriptionListServiceResponse()
        {
            LocationDescriptions = new List<LocationDescription>{};
        }

        ///<summary>
        ///Response version
        ///</summary>
        [ApiMember(DataType="integer", Description="Response version")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Response time")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Location descriptions
        ///</summary>
        [ApiMember(DataType="Array<LocationDescription>", Description="Location descriptions")]
        public List<LocationDescription> LocationDescriptions { get; set; }

        ///<summary>
        ///Next token
        ///</summary>
        [ApiMember(DataType="DateTime", Description="Next token")]
        public DateTime? NextToken { get; set; }
    }

    public class MetadataChangeTransactionListServiceResponse
    {
        ///<summary>
        ///Response version
        ///</summary>
        [ApiMember(DataType="integer", Description="Response version")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Response time")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Metadata change transactions
        ///</summary>
        [ApiMember(DataType="Array<MetadataChangeTransaction>", Description="Metadata change transactions")]
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
        [ApiMember(DataType="integer", Description="Response version")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(DataType="DateTime", Description="Response time")]
        public DateTime ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Monitoring methods
        ///</summary>
        [ApiMember(DataType="Array<MonitoringMethod>", Description="Monitoring methods")]
        public List<MonitoringMethod> MonitoringMethods { get; set; }
    }

    public class ParameterListServiceResponse
    {
        public ParameterListServiceResponse()
        {
            Parameters = new List<ParameterMetadata>{};
        }

        ///<summary>
        ///Response version
        ///</summary>
        [ApiMember(DataType="integer", Description="Response version")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Response time")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Parameters
        ///</summary>
        [ApiMember(DataType="Array<ParameterMetadata>", Description="Parameters")]
        public List<ParameterMetadata> Parameters { get; set; }
    }

    public class ProcessorListServiceResponse
    {
        public ProcessorListServiceResponse()
        {
            Processors = new List<Processor>{};
        }

        ///<summary>
        ///Response version
        ///</summary>
        [ApiMember(DataType="integer", Description="Response version")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Response time")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Processors
        ///</summary>
        [ApiMember(DataType="Array<Processor>", Description="Processors")]
        public List<Processor> Processors { get; set; }
    }

    public class QualifierListServiceResponse
    {
        public QualifierListServiceResponse()
        {
            Qualifiers = new List<QualifierMetadata>{};
        }

        ///<summary>
        ///Response version
        ///</summary>
        [ApiMember(DataType="integer", Description="Response version")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Response time")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Qualifiers
        ///</summary>
        [ApiMember(DataType="Array<QualifierMetadata>", Description="Qualifiers")]
        public List<QualifierMetadata> Qualifiers { get; set; }
    }

    public class RatingCurveListServiceResponse
    {
        ///<summary>
        ///Response version
        ///</summary>
        [ApiMember(DataType="integer", Description="Response version")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Response time")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Rating curves
        ///</summary>
        [ApiMember(DataType="Array<RatingCurve>", Description="Rating curves")]
        public IList<RatingCurve> RatingCurves { get; set; }

        ///<summary>
        ///Approvals
        ///</summary>
        [ApiMember(DataType="Array<Approval>", Description="Approvals")]
        public IList<Approval> Approvals { get; set; }
    }

    public class RatingModelDescriptionListServiceResponse
    {
        ///<summary>
        ///Response version
        ///</summary>
        [ApiMember(DataType="integer", Description="Response version")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Response time")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Rating model descriptions
        ///</summary>
        [ApiMember(DataType="Array<RatingModelDescription>", Description="Rating model descriptions")]
        public IList<RatingModelDescription> RatingModelDescriptions { get; set; }

        ///<summary>
        ///Next token
        ///</summary>
        [ApiMember(DataType="DateTime", Description="Next token")]
        public DateTime? NextToken { get; set; }
    }

    public class RatingModelEffectiveShiftsServiceResponse
    {
        public RatingModelEffectiveShiftsServiceResponse()
        {
            EffectiveShifts = new List<EffectiveShift>{};
        }

        ///<summary>
        ///Response version
        ///</summary>
        [ApiMember(DataType="integer", Description="Response version")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Response time")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Effective shifts
        ///</summary>
        [ApiMember(DataType="Array<EffectiveShift>", Description="Effective shifts")]
        public List<EffectiveShift> EffectiveShifts { get; set; }
    }

    public class RatingModelInputValuesServiceResponse
    {
        public RatingModelInputValuesServiceResponse()
        {
            InputValues = new List<Nullable<Double>>{};
        }

        ///<summary>
        ///Response version
        ///</summary>
        [ApiMember(DataType="integer", Description="Response version")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Response time")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Input values
        ///</summary>
        [ApiMember(DataType="double", Description="Input values")]
        public List<Nullable<Double>> InputValues { get; set; }
    }

    public class RatingModelOutputValuesServiceResponse
    {
        public RatingModelOutputValuesServiceResponse()
        {
            OutputValues = new List<Nullable<Double>>{};
        }

        ///<summary>
        ///Response version
        ///</summary>
        [ApiMember(DataType="integer", Description="Response version")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Response time")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Output values
        ///</summary>
        [ApiMember(DataType="double", Description="Output values")]
        public List<Nullable<Double>> OutputValues { get; set; }
    }

    public class SensorsAndGaugesServiceResponse
    {
        public SensorsAndGaugesServiceResponse()
        {
            MonitoringMethods = new List<LocationMonitoringMethod>{};
        }

        ///<summary>
        ///Response version
        ///</summary>
        [ApiMember(DataType="integer", Description="Response version")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Response time")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Monitoring methods
        ///</summary>
        [ApiMember(DataType="Array<LocationMonitoringMethod>", Description="Monitoring methods")]
        public List<LocationMonitoringMethod> MonitoringMethods { get; set; }
    }

    public class TimeSeriesApprovalsTransactionListServiceResponse
    {
        ///<summary>
        ///Response version
        ///</summary>
        [ApiMember(DataType="integer", Description="Response version")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Response time")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Approvals transactions
        ///</summary>
        [ApiMember(DataType="Array<ApprovalsTransaction>", Description="Approvals transactions")]
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

        ///<summary>
        ///Response version
        ///</summary>
        [ApiMember(DataType="integer", Description="Response version")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Response time")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Unique id
        ///</summary>
        [ApiMember(DataType="string", Description="Unique id")]
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
        [ApiMember(DataType="long integer", Description="Num points")]
        public long? NumPoints { get; set; }

        ///<summary>
        ///Unit
        ///</summary>
        [ApiMember(Description="Unit")]
        public string Unit { get; set; }

        ///<summary>
        ///Approvals
        ///</summary>
        [ApiMember(DataType="Array<Approval>", Description="Approvals")]
        public List<Approval> Approvals { get; set; }

        ///<summary>
        ///Qualifiers
        ///</summary>
        [ApiMember(DataType="Array<Qualifier>", Description="Qualifiers")]
        public List<Qualifier> Qualifiers { get; set; }

        ///<summary>
        ///Methods
        ///</summary>
        [ApiMember(DataType="Array<Method>", Description="Methods")]
        public List<Method> Methods { get; set; }

        ///<summary>
        ///Grades
        ///</summary>
        [ApiMember(DataType="Array<Grade>", Description="Grades")]
        public List<Grade> Grades { get; set; }

        ///<summary>
        ///Gap tolerances
        ///</summary>
        [ApiMember(DataType="Array<GapTolerance>", Description="Gap tolerances")]
        public List<GapTolerance> GapTolerances { get; set; }

        ///<summary>
        ///Interpolation types
        ///</summary>
        [ApiMember(DataType="Array<InterpolationType>", Description="Interpolation types")]
        public List<InterpolationType> InterpolationTypes { get; set; }

        ///<summary>
        ///Notes
        ///</summary>
        [ApiMember(DataType="Array<Note>", Description="Notes")]
        public List<Note> Notes { get; set; }

        ///<summary>
        ///Time range
        ///</summary>
        [ApiMember(DataType="StatisticalTimeRange", Description="Time range")]
        public StatisticalTimeRange TimeRange { get; set; }

        ///<summary>
        ///Points
        ///</summary>
        [ApiMember(DataType="Array<TimeSeriesPoint>", Description="Points")]
        public List<TimeSeriesPoint> Points { get; set; }
    }

    public class TimeSeriesDescriptionListByUniqueIdServiceResponse
    {
        public TimeSeriesDescriptionListByUniqueIdServiceResponse()
        {
            TimeSeriesDescriptions = new List<TimeSeriesDescription>{};
        }

        ///<summary>
        ///Response version
        ///</summary>
        [ApiMember(DataType="integer", Description="Response version")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Response time")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Time series descriptions
        ///</summary>
        [ApiMember(DataType="Array<TimeSeriesDescription>", Description="Time series descriptions")]
        public List<TimeSeriesDescription> TimeSeriesDescriptions { get; set; }
    }

    public class TimeSeriesDescriptionListServiceResponse
    {
        public TimeSeriesDescriptionListServiceResponse()
        {
            TimeSeriesDescriptions = new List<TimeSeriesDescription>{};
        }

        ///<summary>
        ///Response version
        ///</summary>
        [ApiMember(DataType="integer", Description="Response version")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Response time")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Time series descriptions
        ///</summary>
        [ApiMember(DataType="Array<TimeSeriesDescription>", Description="Time series descriptions")]
        public List<TimeSeriesDescription> TimeSeriesDescriptions { get; set; }
    }

    public class TimeSeriesUniqueIdListServiceResponse
    {
        public TimeSeriesUniqueIdListServiceResponse()
        {
            TimeSeriesUniqueIds = new List<TimeSeriesUniqueIds>{};
        }

        ///<summary>
        ///Response version
        ///</summary>
        [ApiMember(DataType="integer", Description="Response version")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Response time")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Token expired
        ///</summary>
        [ApiMember(DataType="boolean", Description="Token expired")]
        public bool? TokenExpired { get; set; }

        ///<summary>
        ///Next token
        ///</summary>
        [ApiMember(DataType="DateTime", Description="Next token")]
        public DateTime? NextToken { get; set; }

        ///<summary>
        ///Time series unique ids
        ///</summary>
        [ApiMember(DataType="Array<TimeSeriesUniqueIds>", Description="Time series unique ids")]
        public List<TimeSeriesUniqueIds> TimeSeriesUniqueIds { get; set; }
    }

    public class UnitListServiceResponse
    {
        public UnitListServiceResponse()
        {
            Units = new List<UnitMetadata>{};
        }

        ///<summary>
        ///Response version
        ///</summary>
        [ApiMember(DataType="integer", Description="Response version")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Response time")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Units
        ///</summary>
        [ApiMember(DataType="Array<UnitMetadata>", Description="Units")]
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

namespace Aquarius.Client.ServiceModels.Publish
{
    public static class Current
    {
        public static readonly AquariusServerVersion Version = AquariusServerVersion.Create("16.3.115.0");
    }
}
