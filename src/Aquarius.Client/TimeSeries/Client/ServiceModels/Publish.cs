/* Options:
Date: 2017-05-10 11:48:34
Version: 4.56
Tip: To override a DTO option, remove "//" prefix before updating
BaseUrl: http://autoserver1/AQUARIUS/Publish/v2

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
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ServiceStack;
using ServiceStack.DataAnnotations;
using NodaTime;
using Aquarius.TimeSeries.Client.ServiceModels.Publish;


namespace Aquarius.TimeSeries.Client.ServiceModels.Publish
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
        [ApiMember(Description="RSA key size in bits", DataType="integer")]
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
        [ApiMember(Description="Approval level", DataType="integer")]
        public int ApprovalLevel { get; set; }

        ///<summary>
        ///Date applied utc
        ///</summary>
        [ApiMember(Description="Date applied utc", DataType="DateTime")]
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
        [ApiMember(Description="Type", DataType="CorrectionType")]
        public CorrectionType Type { get; set; }

        ///<summary>
        ///Start time
        ///</summary>
        [ApiMember(Description="Start time", DataType="DateTimeOffset")]
        public DateTimeOffset StartTime { get; set; }

        ///<summary>
        ///End time
        ///</summary>
        [ApiMember(Description="End time", DataType="DateTimeOffset")]
        public DateTimeOffset EndTime { get; set; }

        ///<summary>
        ///Applied time utc
        ///</summary>
        [ApiMember(Description="Applied time utc", DataType="DateTime")]
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
        [ApiMember(Description="Processing order", DataType="CorrectionProcessingOrder")]
        public CorrectionProcessingOrder ProcessingOrder { get; set; }
    }

    public class CorrectionOperation
        : TimeRange
    {
        ///<summary>
        ///Type
        ///</summary>
        [ApiMember(Description="Type", DataType="CorrectionType")]
        public CorrectionType Type { get; set; }

        public IDictionary<string, Object> Parameters { get; set; }
        ///<summary>
        ///Processing order
        ///</summary>
        [ApiMember(Description="Processing order", DataType="CorrectionProcessingOrder")]
        public CorrectionProcessingOrder ProcessingOrder { get; set; }

        ///<summary>
        ///Date applied utc
        ///</summary>
        [ApiMember(Description="Date applied utc", DataType="DateTime")]
        public DateTime DateAppliedUtc { get; set; }

        ///<summary>
        ///User
        ///</summary>
        [ApiMember(Description="User")]
        public string User { get; set; }

        ///<summary>
        ///Operation type
        ///</summary>
        [ApiMember(Description="Operation type", DataType="MetadataChangeOperationType")]
        public MetadataChangeOperationType OperationType { get; set; }

        ///<summary>
        ///Stack position
        ///</summary>
        [ApiMember(Description="Stack position", DataType="integer")]
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
        [ApiMember(Description="Numeric", DataType="double")]
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
        [ApiMember(Description="Timestamp", DataType="DateTimeOffset")]
        public DateTimeOffset Timestamp { get; set; }

        ///<summary>
        ///Value
        ///</summary>
        [ApiMember(Description="Value", DataType="double")]
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
        [ApiMember(Description="Type", DataType="RatingCurveType")]
        public RatingCurveType Type { get; set; }

        ///<summary>
        ///Remarks
        ///</summary>
        [ApiMember(Description="Remarks")]
        public string Remarks { get; set; }

        ///<summary>
        ///Input parameter
        ///</summary>
        [ApiMember(Description="Input parameter", DataType="ParameterWithUnit")]
        public ParameterWithUnit InputParameter { get; set; }

        ///<summary>
        ///Output parameter
        ///</summary>
        [ApiMember(Description="Output parameter", DataType="ParameterWithUnit")]
        public ParameterWithUnit OutputParameter { get; set; }

        ///<summary>
        ///Periods of applicability
        ///</summary>
        [ApiMember(Description="Periods of applicability", DataType="Array<PeriodOfApplicability>")]
        public List<PeriodOfApplicability> PeriodsOfApplicability { get; set; }

        ///<summary>
        ///Shifts
        ///</summary>
        [ApiMember(Description="Shifts", DataType="Array<RatingShift>")]
        public List<RatingShift> Shifts { get; set; }

        ///<summary>
        ///Offsets
        ///</summary>
        [ApiMember(Description="Offsets", DataType="Array<OffsetPoint>")]
        public List<OffsetPoint> Offsets { get; set; }

        ///<summary>
        ///Is blended
        ///</summary>
        [ApiMember(Description="Is blended", DataType="boolean")]
        public bool IsBlended { get; set; }

        ///<summary>
        ///Base rating table
        ///</summary>
        [ApiMember(Description="Base rating table", DataType="Array<RatingPoint>")]
        public List<RatingPoint> BaseRatingTable { get; set; }

        ///<summary>
        ///Adjusted rating table
        ///</summary>
        [ApiMember(Description="Adjusted rating table", DataType="Array<RatingPoint>")]
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
        [ApiMember(Description="Value", DataType="object")]
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
        [ApiMember(Description="Start time", DataType="DateTimeOffset")]
        public DateTimeOffset? StartTime { get; set; }

        ///<summary>
        ///End time
        ///</summary>
        [ApiMember(Description="End time", DataType="DateTimeOffset")]
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
        [ApiMember(Description="Is valid", DataType="boolean")]
        public bool IsValid { get; set; }

        ///<summary>
        ///Completed work
        ///</summary>
        [ApiMember(Description="Completed work", DataType="CompletedWork")]
        public CompletedWork CompletedWork { get; set; }

        ///<summary>
        ///Last modified
        ///</summary>
        [ApiMember(Description="Last modified", DataType="DateTimeOffset")]
        public DateTimeOffset LastModified { get; set; }
    }

    public class GapTolerance
        : TimeRange
    {
        ///<summary>
        ///Tolerance in minutes
        ///</summary>
        [ApiMember(Description="Tolerance in minutes", DataType="double")]
        public double? ToleranceInMinutes { get; set; }
    }

    public class GapToleranceOperation
        : GapTolerance
    {
        ///<summary>
        ///Operation type
        ///</summary>
        [ApiMember(Description="Operation type", DataType="MetadataChangeOperationType")]
        public MetadataChangeOperationType OperationType { get; set; }

        ///<summary>
        ///Date applied utc
        ///</summary>
        [ApiMember(Description="Date applied utc", DataType="DateTime")]
        public DateTime DateAppliedUtc { get; set; }

        ///<summary>
        ///User
        ///</summary>
        [ApiMember(Description="User")]
        public string User { get; set; }

        ///<summary>
        ///Stack position
        ///</summary>
        [ApiMember(Description="Stack position", DataType="integer")]
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
        [ApiMember(Description="Date applied utc", DataType="DateTime")]
        public DateTime DateAppliedUtc { get; set; }

        ///<summary>
        ///User
        ///</summary>
        [ApiMember(Description="User")]
        public string User { get; set; }

        ///<summary>
        ///Operation type
        ///</summary>
        [ApiMember(Description="Operation type", DataType="MetadataChangeOperationType")]
        public MetadataChangeOperationType OperationType { get; set; }

        ///<summary>
        ///Stack position
        ///</summary>
        [ApiMember(Description="Stack position", DataType="integer")]
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
        [ApiMember(Description="Date applied utc", DataType="DateTime")]
        public DateTime DateAppliedUtc { get; set; }

        ///<summary>
        ///User
        ///</summary>
        [ApiMember(Description="User")]
        public string User { get; set; }

        ///<summary>
        ///Operation type
        ///</summary>
        [ApiMember(Description="Operation type", DataType="MetadataChangeOperationType")]
        public MetadataChangeOperationType OperationType { get; set; }

        ///<summary>
        ///Stack position
        ///</summary>
        [ApiMember(Description="Stack position", DataType="integer")]
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
        [ApiMember(Description="Reference standard", DataType="LocationReferenceStandard")]
        public LocationReferenceStandard ReferenceStandard { get; set; }

        ///<summary>
        ///Datum periods
        ///</summary>
        [ApiMember(Description="Datum periods", DataType="Array<LocationDatumPeriod>")]
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
        [ApiMember(Description="Time range", DataType="TimeRange")]
        public TimeRange TimeRange { get; set; }

        ///<summary>
        ///Unit identifier
        ///</summary>
        [ApiMember(Description="Unit identifier")]
        public string UnitIdentifier { get; set; }

        ///<summary>
        ///Offset to standard
        ///</summary>
        [ApiMember(Description="Offset to standard", DataType="double")]
        public double OffsetToStandard { get; set; }

        ///<summary>
        ///Measurement direction
        ///</summary>
        [ApiMember(Description="Measurement direction", DataType="MeasurementDirection")]
        public MeasurementDirection MeasurementDirection { get; set; }

        ///<summary>
        ///Comments
        ///</summary>
        [ApiMember(Description="Comments")]
        public string Comments { get; set; }

        ///<summary>
        ///Applied time utc
        ///</summary>
        [ApiMember(Description="Applied time utc", DataType="Instant")]
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
        ///Unique id
        ///</summary>
        [ApiMember(Description="Unique id", DataType="string")]
        public Guid UniqueId { get; set; }

        ///<summary>
        ///Primary folder
        ///</summary>
        [ApiMember(Description="Primary folder")]
        public string PrimaryFolder { get; set; }

        ///<summary>
        ///Secondary folders
        ///</summary>
        [ApiMember(Description="Secondary folders", DataType="Array<string>")]
        public List<string> SecondaryFolders { get; set; }

        ///<summary>
        ///Last modified
        ///</summary>
        [ApiMember(Description="Last modified", DataType="DateTimeOffset")]
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
        [ApiMember(Description="Reference standard offsets", DataType="Array<ReferenceStandardOffset>")]
        public List<ReferenceStandardOffset> ReferenceStandardOffsets { get; set; }
    }

    public class LocationRemark
    {
        ///<summary>
        ///Create time
        ///</summary>
        [ApiMember(Description="Create time", DataType="DateTimeOffset")]
        public DateTimeOffset? CreateTime { get; set; }

        ///<summary>
        ///From time
        ///</summary>
        [ApiMember(Description="From time", DataType="DateTimeOffset")]
        public DateTimeOffset? FromTime { get; set; }

        ///<summary>
        ///To time
        ///</summary>
        [ApiMember(Description="To time", DataType="DateTimeOffset")]
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
        [ApiMember(Description="Applied time", DataType="DateTimeOffset")]
        public DateTimeOffset AppliedTime { get; set; }

        ///<summary>
        ///Applied by user
        ///</summary>
        [ApiMember(Description="Applied by user")]
        public string AppliedByUser { get; set; }

        ///<summary>
        ///Content type
        ///</summary>
        [ApiMember(Description="Content type", DataType="MetadataChangeContentType")]
        public MetadataChangeContentType ContentType { get; set; }

        ///<summary>
        ///Gap tolerance operations
        ///</summary>
        [ApiMember(Description="Gap tolerance operations", DataType="Array<GapToleranceOperation>")]
        public IList<GapToleranceOperation> GapToleranceOperations { get; set; }

        ///<summary>
        ///Grade operations
        ///</summary>
        [ApiMember(Description="Grade operations", DataType="Array<GradeOperation>")]
        public IList<GradeOperation> GradeOperations { get; set; }

        ///<summary>
        ///Interpolation type operations
        ///</summary>
        [ApiMember(Description="Interpolation type operations", DataType="Array<InterpolationTypeOperation>")]
        public IList<InterpolationTypeOperation> InterpolationTypeOperations { get; set; }

        ///<summary>
        ///Method operations
        ///</summary>
        [ApiMember(Description="Method operations", DataType="Array<MethodOperation>")]
        public IList<MethodOperation> MethodOperations { get; set; }

        ///<summary>
        ///Note operations
        ///</summary>
        [ApiMember(Description="Note operations", DataType="Array<NoteOperation>")]
        public IList<NoteOperation> NoteOperations { get; set; }

        ///<summary>
        ///Qualifier operations
        ///</summary>
        [ApiMember(Description="Qualifier operations", DataType="Array<QualifierOperation>")]
        public IList<QualifierOperation> QualifierOperations { get; set; }

        ///<summary>
        ///Correction operations
        ///</summary>
        [ApiMember(Description="Correction operations", DataType="Array<CorrectionOperation>")]
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
        [ApiMember(Description="Date applied utc", DataType="DateTime")]
        public DateTime DateAppliedUtc { get; set; }

        ///<summary>
        ///User
        ///</summary>
        [ApiMember(Description="User")]
        public string User { get; set; }

        ///<summary>
        ///Operation type
        ///</summary>
        [ApiMember(Description="Operation type", DataType="MetadataChangeOperationType")]
        public MetadataChangeOperationType OperationType { get; set; }

        ///<summary>
        ///Stack position
        ///</summary>
        [ApiMember(Description="Stack position", DataType="integer")]
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
        [ApiMember(Description="Date applied utc", DataType="DateTime")]
        public DateTime DateAppliedUtc { get; set; }

        ///<summary>
        ///User
        ///</summary>
        [ApiMember(Description="User")]
        public string User { get; set; }

        ///<summary>
        ///Operation type
        ///</summary>
        [ApiMember(Description="Operation type", DataType="MetadataChangeOperationType")]
        public MetadataChangeOperationType OperationType { get; set; }
    }

    public class OffsetPoint
    {
        ///<summary>
        ///Input value
        ///</summary>
        [ApiMember(Description="Input value", DataType="double")]
        public double? InputValue { get; set; }

        ///<summary>
        ///Offset
        ///</summary>
        [ApiMember(Description="Offset", DataType="double")]
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
        [ApiMember(Description="Start time", DataType="DateTimeOffset")]
        public DateTimeOffset StartTime { get; set; }

        ///<summary>
        ///End time
        ///</summary>
        [ApiMember(Description="End time", DataType="DateTimeOffset")]
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
        [ApiMember(Description="Input time series unique ids", DataType="Array<string>")]
        public List<Guid> InputTimeSeriesUniqueIds { get; set; }

        ///<summary>
        ///Output time series unique id
        ///</summary>
        [ApiMember(Description="Output time series unique id", DataType="string")]
        public Guid OutputTimeSeriesUniqueId { get; set; }

        ///<summary>
        ///Processor period
        ///</summary>
        [ApiMember(Description="Processor period", DataType="TimeRange")]
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
        [ApiMember(Description="Date applied", DataType="DateTime")]
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
        [ApiMember(Description="Operation type", DataType="MetadataChangeOperationType")]
        public MetadataChangeOperationType OperationType { get; set; }

        ///<summary>
        ///Date applied utc
        ///</summary>
        [ApiMember(Description="Date applied utc", DataType="DateTime")]
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
        [ApiMember(Description="Type", DataType="RatingCurveType")]
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
        [ApiMember(Description="Input parameter", DataType="ParameterWithUnit")]
        public ParameterWithUnit InputParameter { get; set; }

        ///<summary>
        ///Output parameter
        ///</summary>
        [ApiMember(Description="Output parameter", DataType="ParameterWithUnit")]
        public ParameterWithUnit OutputParameter { get; set; }

        ///<summary>
        ///Periods of applicability
        ///</summary>
        [ApiMember(Description="Periods of applicability", DataType="Array<PeriodOfApplicability>")]
        public List<PeriodOfApplicability> PeriodsOfApplicability { get; set; }

        ///<summary>
        ///Shifts
        ///</summary>
        [ApiMember(Description="Shifts", DataType="Array<RatingShift>")]
        public List<RatingShift> Shifts { get; set; }

        ///<summary>
        ///Base rating table
        ///</summary>
        [ApiMember(Description="Base rating table", DataType="Array<RatingPoint>")]
        public List<RatingPoint> BaseRatingTable { get; set; }

        ///<summary>
        ///Offsets
        ///</summary>
        [ApiMember(Description="Offsets", DataType="Array<OffsetPoint>")]
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
        [ApiMember(Description="Last modified", DataType="DateTimeOffset")]
        public DateTimeOffset LastModified { get; set; }

        ///<summary>
        ///Publish
        ///</summary>
        [ApiMember(Description="Publish", DataType="boolean")]
        public bool Publish { get; set; }
    }

    public class RatingPoint
    {
        ///<summary>
        ///Input value
        ///</summary>
        [ApiMember(Description="Input value", DataType="double")]
        public double? InputValue { get; set; }

        ///<summary>
        ///Output value
        ///</summary>
        [ApiMember(Description="Output value", DataType="double")]
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
        [ApiMember(Description="Period of applicability", DataType="PeriodOfApplicability")]
        public PeriodOfApplicability PeriodOfApplicability { get; set; }

        ///<summary>
        ///Shift points
        ///</summary>
        [ApiMember(Description="Shift points", DataType="Array<RatingShiftPoint>")]
        public List<RatingShiftPoint> ShiftPoints { get; set; }
    }

    public class RatingShiftPoint
    {
        ///<summary>
        ///Input value
        ///</summary>
        [ApiMember(Description="Input value", DataType="double")]
        public double InputValue { get; set; }

        ///<summary>
        ///Shift
        ///</summary>
        [ApiMember(Description="Shift", DataType="double")]
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
        [ApiMember(Description="Offset to reference standard", DataType="double")]
        public double OffsetToReferenceStandard { get; set; }
    }

    public class StagePoint
    {
        ///<summary>
        ///Input value
        ///</summary>
        [ApiMember(Description="Input value", DataType="double")]
        public double InputValue { get; set; }

        ///<summary>
        ///Correction
        ///</summary>
        [ApiMember(Description="Correction", DataType="double")]
        public double Correction { get; set; }

        ///<summary>
        ///Corrected value
        ///</summary>
        [ApiMember(Description="Corrected value", DataType="double")]
        public double CorrectedValue { get; set; }
    }

    public class StatisticalDateTimeOffset
    {
        ///<summary>
        ///Date time offset
        ///</summary>
        [ApiMember(Description="Date time offset", DataType="DateTimeOffset")]
        public DateTimeOffset DateTimeOffset { get; set; }

        ///<summary>
        ///Represents end of time period
        ///</summary>
        [ApiMember(Description="Represents end of time period", DataType="boolean")]
        public bool RepresentsEndOfTimePeriod { get; set; }
    }

    public class StatisticalTimeRange
    {
        ///<summary>
        ///Start time
        ///</summary>
        [ApiMember(Description="Start time", DataType="StatisticalDateTimeOffset")]
        public StatisticalDateTimeOffset StartTime { get; set; }

        ///<summary>
        ///End time
        ///</summary>
        [ApiMember(Description="End time", DataType="StatisticalDateTimeOffset")]
        public StatisticalDateTimeOffset EndTime { get; set; }
    }

    public class TimeAlignedPoint
    {
        ///<summary>
        ///Timestamp
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        ///<summary>
        ///Numeric value of output time-series 1
        ///</summary>
        [ApiMember(DataType="double", Description="Numeric value of output time-series 1")]
        public double? NumericValue1 { get; set; }

        ///<summary>
        ///Display value of output time-series 1
        ///</summary>
        [ApiMember(Description="Display value of output time-series 1")]
        public string DisplayValue1 { get; set; }

        ///<summary>
        ///Grade code of output time-series 1
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time-series 1")]
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
        [ApiMember(DataType="integer", Description="Approval level of output time-series 1")]
        public long? ApprovalLevel1 { get; set; }

        ///<summary>
        ///Approval name of output time-series 1
        ///</summary>
        [ApiMember(Description="Approval name of output time-series 1")]
        public string ApprovalName1 { get; set; }

        ///<summary>
        ///Numeric value of output time-series 2
        ///</summary>
        [ApiMember(DataType="double", Description="Numeric value of output time-series 2")]
        public double? NumericValue2 { get; set; }

        ///<summary>
        ///Display value of output time-series 2
        ///</summary>
        [ApiMember(Description="Display value of output time-series 2")]
        public string DisplayValue2 { get; set; }

        ///<summary>
        ///Grade code of output time-series 2
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time-series 2")]
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
        [ApiMember(DataType="integer", Description="Approval level of output time-series 2")]
        public long? ApprovalLevel2 { get; set; }

        ///<summary>
        ///Approval name of output time-series 2
        ///</summary>
        [ApiMember(Description="Approval name of output time-series 2")]
        public string ApprovalName2 { get; set; }

        ///<summary>
        ///Numeric value of output time-series 3
        ///</summary>
        [ApiMember(DataType="double", Description="Numeric value of output time-series 3")]
        public double? NumericValue3 { get; set; }

        ///<summary>
        ///Display value of output time-series 3
        ///</summary>
        [ApiMember(Description="Display value of output time-series 3")]
        public string DisplayValue3 { get; set; }

        ///<summary>
        ///Grade code of output time-series 3
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time-series 3")]
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
        [ApiMember(DataType="integer", Description="Approval level of output time-series 3")]
        public long? ApprovalLevel3 { get; set; }

        ///<summary>
        ///Approval name of output time-series 3
        ///</summary>
        [ApiMember(Description="Approval name of output time-series 3")]
        public string ApprovalName3 { get; set; }

        ///<summary>
        ///Numeric value of output time-series 4
        ///</summary>
        [ApiMember(DataType="double", Description="Numeric value of output time-series 4")]
        public double? NumericValue4 { get; set; }

        ///<summary>
        ///Display value of output time-series 4
        ///</summary>
        [ApiMember(Description="Display value of output time-series 4")]
        public string DisplayValue4 { get; set; }

        ///<summary>
        ///Grade code of output time-series 4
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time-series 4")]
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
        [ApiMember(DataType="integer", Description="Approval level of output time-series 4")]
        public long? ApprovalLevel4 { get; set; }

        ///<summary>
        ///Approval name of output time-series 4
        ///</summary>
        [ApiMember(Description="Approval name of output time-series 4")]
        public string ApprovalName4 { get; set; }

        ///<summary>
        ///Numeric value of output time-series 5
        ///</summary>
        [ApiMember(DataType="double", Description="Numeric value of output time-series 5")]
        public double? NumericValue5 { get; set; }

        ///<summary>
        ///Display value of output time-series 5
        ///</summary>
        [ApiMember(Description="Display value of output time-series 5")]
        public string DisplayValue5 { get; set; }

        ///<summary>
        ///Grade code of output time-series 5
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time-series 5")]
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
        [ApiMember(DataType="integer", Description="Approval level of output time-series 5")]
        public long? ApprovalLevel5 { get; set; }

        ///<summary>
        ///Approval name of output time-series 5
        ///</summary>
        [ApiMember(Description="Approval name of output time-series 5")]
        public string ApprovalName5 { get; set; }

        ///<summary>
        ///Numeric value of output time-series 6
        ///</summary>
        [ApiMember(DataType="double", Description="Numeric value of output time-series 6")]
        public double? NumericValue6 { get; set; }

        ///<summary>
        ///Display value of output time-series 6
        ///</summary>
        [ApiMember(Description="Display value of output time-series 6")]
        public string DisplayValue6 { get; set; }

        ///<summary>
        ///Grade code of output time-series 6
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time-series 6")]
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
        [ApiMember(DataType="integer", Description="Approval level of output time-series 6")]
        public long? ApprovalLevel6 { get; set; }

        ///<summary>
        ///Approval name of output time-series 6
        ///</summary>
        [ApiMember(Description="Approval name of output time-series 6")]
        public string ApprovalName6 { get; set; }

        ///<summary>
        ///Numeric value of output time-series 7
        ///</summary>
        [ApiMember(DataType="double", Description="Numeric value of output time-series 7")]
        public double? NumericValue7 { get; set; }

        ///<summary>
        ///Display value of output time-series 7
        ///</summary>
        [ApiMember(Description="Display value of output time-series 7")]
        public string DisplayValue7 { get; set; }

        ///<summary>
        ///Grade code of output time-series 7
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time-series 7")]
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
        [ApiMember(DataType="integer", Description="Approval level of output time-series 7")]
        public long? ApprovalLevel7 { get; set; }

        ///<summary>
        ///Approval name of output time-series 7
        ///</summary>
        [ApiMember(Description="Approval name of output time-series 7")]
        public string ApprovalName7 { get; set; }

        ///<summary>
        ///Numeric value of output time-series 8
        ///</summary>
        [ApiMember(DataType="double", Description="Numeric value of output time-series 8")]
        public double? NumericValue8 { get; set; }

        ///<summary>
        ///Display value of output time-series 8
        ///</summary>
        [ApiMember(Description="Display value of output time-series 8")]
        public string DisplayValue8 { get; set; }

        ///<summary>
        ///Grade code of output time-series 8
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time-series 8")]
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
        [ApiMember(DataType="integer", Description="Approval level of output time-series 8")]
        public long? ApprovalLevel8 { get; set; }

        ///<summary>
        ///Approval name of output time-series 8
        ///</summary>
        [ApiMember(Description="Approval name of output time-series 8")]
        public string ApprovalName8 { get; set; }

        ///<summary>
        ///Numeric value of output time-series 9
        ///</summary>
        [ApiMember(DataType="double", Description="Numeric value of output time-series 9")]
        public double? NumericValue9 { get; set; }

        ///<summary>
        ///Display value of output time-series 9
        ///</summary>
        [ApiMember(Description="Display value of output time-series 9")]
        public string DisplayValue9 { get; set; }

        ///<summary>
        ///Grade code of output time-series 9
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time-series 9")]
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
        [ApiMember(DataType="integer", Description="Approval level of output time-series 9")]
        public long? ApprovalLevel9 { get; set; }

        ///<summary>
        ///Approval name of output time-series 9
        ///</summary>
        [ApiMember(Description="Approval name of output time-series 9")]
        public string ApprovalName9 { get; set; }

        ///<summary>
        ///Numeric value of output time-series 10
        ///</summary>
        [ApiMember(DataType="double", Description="Numeric value of output time-series 10")]
        public double? NumericValue10 { get; set; }

        ///<summary>
        ///Display value of output time-series 10
        ///</summary>
        [ApiMember(Description="Display value of output time-series 10")]
        public string DisplayValue10 { get; set; }

        ///<summary>
        ///Grade code of output time-series 10
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code of output time-series 10")]
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
        [ApiMember(DataType="integer", Description="Approval level of output time-series 10")]
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
        [ApiMember(Description="Unique id", DataType="string")]
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
        [ApiMember(Description="Start time", DataType="DateTimeOffset")]
        public DateTimeOffset StartTime { get; set; }

        ///<summary>
        ///End time
        ///</summary>
        [ApiMember(Description="End time", DataType="DateTimeOffset")]
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
        [ApiMember(Description="Unique id", DataType="string")]
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
        [ApiMember(Description="Utc offset", DataType="double")]
        public double UtcOffset { get; set; }

        ///<summary>
        ///Utc offset iso duration
        ///</summary>
        [ApiMember(Description="Utc offset iso duration", DataType="Offset")]
        public Offset UtcOffsetIsoDuration { get; set; }

        ///<summary>
        ///Last modified
        ///</summary>
        [ApiMember(Description="Last modified", DataType="DateTimeOffset")]
        public DateTimeOffset LastModified { get; set; }

        ///<summary>
        ///Raw start time
        ///</summary>
        [ApiMember(Description="Raw start time", DataType="DateTimeOffset")]
        public DateTimeOffset? RawStartTime { get; set; }

        ///<summary>
        ///Raw end time
        ///</summary>
        [ApiMember(Description="Raw end time", DataType="DateTimeOffset")]
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
        [ApiMember(Description="Publish", DataType="boolean")]
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
        [ApiMember(Description="Extended attributes", DataType="Array<ExtendedAttribute>")]
        public IList<ExtendedAttribute> ExtendedAttributes { get; set; }

        ///<summary>
        ///Thresholds
        ///</summary>
        [ApiMember(Description="Thresholds", DataType="Array<TimeSeriesThreshold>")]
        public IList<TimeSeriesThreshold> Thresholds { get; set; }
    }

    public class TimeSeriesPoint
    {
        ///<summary>
        ///Timestamp
        ///</summary>
        [ApiMember(Description="Timestamp", DataType="StatisticalDateTimeOffset")]
        public StatisticalDateTimeOffset Timestamp { get; set; }

        ///<summary>
        ///Value
        ///</summary>
        [ApiMember(Description="Value", DataType="DoubleWithDisplay")]
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
        [ApiMember(Description="Severity", DataType="integer")]
        public int Severity { get; set; }

        ///<summary>
        ///Type
        ///</summary>
        [ApiMember(Description="Type", DataType="ThresholdType")]
        public ThresholdType Type { get; set; }

        ///<summary>
        ///Display color
        ///</summary>
        [ApiMember(Description="Display color")]
        public string DisplayColor { get; set; }

        ///<summary>
        ///Periods
        ///</summary>
        [ApiMember(Description="Periods", DataType="Array<TimeSeriesThresholdPeriod>")]
        public List<TimeSeriesThresholdPeriod> Periods { get; set; }
    }

    public class TimeSeriesThresholdPeriod
    {
        ///<summary>
        ///Start time
        ///</summary>
        [ApiMember(Description="Start time", DataType="DateTimeOffset")]
        public DateTimeOffset StartTime { get; set; }

        ///<summary>
        ///End time
        ///</summary>
        [ApiMember(Description="End time", DataType="DateTimeOffset")]
        public DateTimeOffset EndTime { get; set; }

        ///<summary>
        ///Applied time
        ///</summary>
        [ApiMember(Description="Applied time", DataType="DateTime")]
        public DateTime AppliedTime { get; set; }

        ///<summary>
        ///Comments
        ///</summary>
        [ApiMember(Description="Comments")]
        public string Comments { get; set; }

        ///<summary>
        ///Reference value
        ///</summary>
        [ApiMember(Description="Reference value", DataType="double")]
        public double ReferenceValue { get; set; }

        ///<summary>
        ///Secondary reference value
        ///</summary>
        [ApiMember(Description="Secondary reference value", DataType="double")]
        public double? SecondaryReferenceValue { get; set; }

        ///<summary>
        ///Suppress data
        ///</summary>
        [ApiMember(Description="Suppress data", DataType="boolean")]
        public bool SuppressData { get; set; }
    }

    public class TimeSeriesUniqueIds
    {
        ///<summary>
        ///Unique id
        ///</summary>
        [ApiMember(Description="Unique id", DataType="string")]
        public Guid UniqueId { get; set; }

        ///<summary>
        ///First point changed
        ///</summary>
        [ApiMember(Description="First point changed", DataType="DateTimeOffset")]
        public DateTimeOffset? FirstPointChanged { get; set; }

        ///<summary>
        ///Has attribute change
        ///</summary>
        [ApiMember(Description="Has attribute change", DataType="boolean")]
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
        [ApiMember(Description="Discharge channel measurement", DataType="DischargeChannelMeasurement")]
        public DischargeChannelMeasurement DischargeChannelMeasurement { get; set; }

        ///<summary>
        ///Is valid
        ///</summary>
        [ApiMember(Description="Is valid", DataType="boolean")]
        public bool IsValid { get; set; }

        ///<summary>
        ///Number of transects
        ///</summary>
        [ApiMember(Description="Number of transects", DataType="integer")]
        public int? NumberOfTransects { get; set; }

        ///<summary>
        ///Magnetic variation
        ///</summary>
        [ApiMember(Description="Magnetic variation", DataType="DoubleWithDisplay")]
        public DoubleWithDisplay MagneticVariation { get; set; }

        ///<summary>
        ///Discharge coefficient variation
        ///</summary>
        [ApiMember(Description="Discharge coefficient variation", DataType="DoubleWithDisplay")]
        public DoubleWithDisplay DischargeCoefficientVariation { get; set; }

        ///<summary>
        ///Percent of discharge measured
        ///</summary>
        [ApiMember(Description="Percent of discharge measured", DataType="DoubleWithDisplay")]
        public DoubleWithDisplay PercentOfDischargeMeasured { get; set; }

        ///<summary>
        ///Top estimate exponent
        ///</summary>
        [ApiMember(Description="Top estimate exponent", DataType="DoubleWithDisplay")]
        public DoubleWithDisplay TopEstimateExponent { get; set; }

        ///<summary>
        ///Bottom estimate exponent
        ///</summary>
        [ApiMember(Description="Bottom estimate exponent", DataType="DoubleWithDisplay")]
        public DoubleWithDisplay BottomEstimateExponent { get; set; }

        ///<summary>
        ///Width
        ///</summary>
        [ApiMember(Description="Width", DataType="QuantityWithDisplay")]
        public QuantityWithDisplay Width { get; set; }

        ///<summary>
        ///Area
        ///</summary>
        [ApiMember(Description="Area", DataType="QuantityWithDisplay")]
        public QuantityWithDisplay Area { get; set; }

        ///<summary>
        ///Velocity average
        ///</summary>
        [ApiMember(Description="Velocity average", DataType="QuantityWithDisplay")]
        public QuantityWithDisplay VelocityAverage { get; set; }

        ///<summary>
        ///Transducer depth
        ///</summary>
        [ApiMember(Description="Transducer depth", DataType="QuantityWithDisplay")]
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
        [ApiMember(Description="Adjustment amount", DataType="double")]
        public double? AdjustmentAmount { get; set; }

        ///<summary>
        ///Adjustment type
        ///</summary>
        [ApiMember(Description="Adjustment type", DataType="AdjustmentType")]
        public AdjustmentType AdjustmentType { get; set; }

        ///<summary>
        ///Reason for adjustment
        ///</summary>
        [ApiMember(Description="Reason for adjustment", DataType="ReasonForAdjustmentType")]
        public ReasonForAdjustmentType ReasonForAdjustment { get; set; }
    }

    public class Attachment
    {
        ///<summary>
        ///Attachment type
        ///</summary>
        [ApiMember(Description="Attachment type", DataType="AttachmentType")]
        public AttachmentType AttachmentType { get; set; }

        ///<summary>
        ///Attachment category
        ///</summary>
        [ApiMember(Description="Attachment category", DataType="AttachmentCategory")]
        public AttachmentCategory AttachmentCategory { get; set; }

        ///<summary>
        ///File name
        ///</summary>
        [ApiMember(Description="File name")]
        public string FileName { get; set; }

        ///<summary>
        ///Date created
        ///</summary>
        [ApiMember(Description="Date created", DataType="DateTimeOffset")]
        public DateTimeOffset DateCreated { get; set; }

        ///<summary>
        ///Date uploaded
        ///</summary>
        [ApiMember(Description="Date uploaded", DataType="DateTimeOffset")]
        public DateTimeOffset DateUploaded { get; set; }

        ///<summary>
        ///Date last accessed
        ///</summary>
        [ApiMember(Description="Date last accessed", DataType="DateTimeOffset")]
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
        [ApiMember(Description="Gps latitude", DataType="double")]
        public double? GpsLatitude { get; set; }

        ///<summary>
        ///Gps longitude
        ///</summary>
        [ApiMember(Description="Gps longitude", DataType="double")]
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
        [ApiMember(Description="Standard", DataType="DoubleWithDisplay")]
        public DoubleWithDisplay Standard { get; set; }

        ///<summary>
        ///Standard details
        ///</summary>
        [ApiMember(Description="Standard details", DataType="StandardDetails")]
        public StandardDetails StandardDetails { get; set; }

        ///<summary>
        ///Monitoring method
        ///</summary>
        [ApiMember(Description="Monitoring method")]
        public string MonitoringMethod { get; set; }

        ///<summary>
        ///Value
        ///</summary>
        [ApiMember(Description="Value", DataType="DoubleWithDisplay")]
        public DoubleWithDisplay Value { get; set; }

        ///<summary>
        ///Difference
        ///</summary>
        [ApiMember(Description="Difference", DataType="DoubleWithDisplay")]
        public DoubleWithDisplay Difference { get; set; }

        ///<summary>
        ///Percent difference
        ///</summary>
        [ApiMember(Description="Percent difference", DataType="DoubleWithDisplay")]
        public DoubleWithDisplay PercentDifference { get; set; }

        ///<summary>
        ///Unit
        ///</summary>
        [ApiMember(Description="Unit")]
        public string Unit { get; set; }

        ///<summary>
        ///Calibration check type
        ///</summary>
        [ApiMember(Description="Calibration check type", DataType="CalibrationCheckType")]
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
        [ApiMember(Description="Time", DataType="DateTimeOffset")]
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
        [ApiMember(Description="Publish", DataType="boolean")]
        public bool Publish { get; set; }

        ///<summary>
        ///Is valid
        ///</summary>
        [ApiMember(Description="Is valid", DataType="boolean")]
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
        [ApiMember(Description="Biological sample taken", DataType="boolean")]
        public bool BiologicalSampleTaken { get; set; }

        ///<summary>
        ///Ground water level performed
        ///</summary>
        [ApiMember(Description="Ground water level performed", DataType="boolean")]
        public bool GroundWaterLevelPerformed { get; set; }

        ///<summary>
        ///Levels performed
        ///</summary>
        [ApiMember(Description="Levels performed", DataType="boolean")]
        public bool LevelsPerformed { get; set; }

        ///<summary>
        ///Other sample taken
        ///</summary>
        [ApiMember(Description="Other sample taken", DataType="boolean")]
        public bool OtherSampleTaken { get; set; }

        ///<summary>
        ///Recorder data collected
        ///</summary>
        [ApiMember(Description="Recorder data collected", DataType="boolean")]
        public bool RecorderDataCollected { get; set; }

        ///<summary>
        ///Sediment sample taken
        ///</summary>
        [ApiMember(Description="Sediment sample taken", DataType="boolean")]
        public bool SedimentSampleTaken { get; set; }

        ///<summary>
        ///Safety inspection performed
        ///</summary>
        [ApiMember(Description="Safety inspection performed", DataType="boolean")]
        public bool SafetyInspectionPerformed { get; set; }

        ///<summary>
        ///Water quality sample taken
        ///</summary>
        [ApiMember(Description="Water quality sample taken", DataType="boolean")]
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
        [ApiMember(Description="Control cleaned", DataType="ControlCleanedType")]
        public ControlCleanedType ControlCleaned { get; set; }

        ///<summary>
        ///Control condition
        ///</summary>
        [ApiMember(Description="Control condition", DataType="ControlConditionType")]
        public ControlConditionType ControlCondition { get; set; }

        ///<summary>
        ///Date cleaned
        ///</summary>
        [ApiMember(Description="Date cleaned", DataType="DateTimeOffset")]
        public DateTimeOffset? DateCleaned { get; set; }

        ///<summary>
        ///Distance to gage
        ///</summary>
        [ApiMember(Description="Distance to gage", DataType="QuantityWithDisplay")]
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
        [ApiMember(Description="Is valid", DataType="boolean")]
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
        [ApiMember(Description="Discharge summary", DataType="DischargeSummary")]
        public DischargeSummary DischargeSummary { get; set; }

        ///<summary>
        ///Volumetric discharge activities
        ///</summary>
        [ApiMember(Description="Volumetric discharge activities", DataType="Array<VolumetricDischargeActivity>")]
        public List<VolumetricDischargeActivity> VolumetricDischargeActivities { get; set; }

        ///<summary>
        ///Engineered structure discharge activities
        ///</summary>
        [ApiMember(Description="Engineered structure discharge activities", DataType="Array<EngineeredStructureDischargeActivity>")]
        public List<EngineeredStructureDischargeActivity> EngineeredStructureDischargeActivities { get; set; }

        ///<summary>
        ///Point velocity discharge activities
        ///</summary>
        [ApiMember(Description="Point velocity discharge activities", DataType="Array<PointVelocityDischargeActivity>")]
        public List<PointVelocityDischargeActivity> PointVelocityDischargeActivities { get; set; }

        ///<summary>
        ///Other method discharge activities
        ///</summary>
        [ApiMember(Description="Other method discharge activities", DataType="Array<OtherMethodDischargeActivity>")]
        public List<OtherMethodDischargeActivity> OtherMethodDischargeActivities { get; set; }

        ///<summary>
        ///Adcp discharge activities
        ///</summary>
        [ApiMember(Description="Adcp discharge activities", DataType="Array<AdcpDischargeActivity>")]
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
        [ApiMember(Description="Start time", DataType="DateTimeOffset")]
        public DateTimeOffset? StartTime { get; set; }

        ///<summary>
        ///End time
        ///</summary>
        [ApiMember(Description="End time", DataType="DateTimeOffset")]
        public DateTimeOffset? EndTime { get; set; }

        ///<summary>
        ///Discharge
        ///</summary>
        [ApiMember(Description="Discharge", DataType="QuantityWithDisplay")]
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
        [ApiMember(Description="Distance to gage", DataType="QuantityWithDisplay")]
        public QuantityWithDisplay DistanceToGage { get; set; }

        ///<summary>
        ///Horizontal flow
        ///</summary>
        [ApiMember(Description="Horizontal flow", DataType="HorizontalFlowType")]
        public HorizontalFlowType HorizontalFlow { get; set; }

        ///<summary>
        ///Channel stability
        ///</summary>
        [ApiMember(Description="Channel stability", DataType="ChannelStabilityType")]
        public ChannelStabilityType ChannelStability { get; set; }

        ///<summary>
        ///Channel material
        ///</summary>
        [ApiMember(Description="Channel material", DataType="ChannelMaterialType")]
        public ChannelMaterialType ChannelMaterial { get; set; }

        ///<summary>
        ///Channel evenness
        ///</summary>
        [ApiMember(Description="Channel evenness", DataType="ChannelEvennessType")]
        public ChannelEvennessType ChannelEvenness { get; set; }

        ///<summary>
        ///Vertical velocity distribution
        ///</summary>
        [ApiMember(Description="Vertical velocity distribution", DataType="VerticalVelocityDistributionType")]
        public VerticalVelocityDistributionType VerticalVelocityDistribution { get; set; }

        ///<summary>
        ///Velocity variation
        ///</summary>
        [ApiMember(Description="Velocity variation", DataType="VelocityVariationType")]
        public VelocityVariationType VelocityVariation { get; set; }

        ///<summary>
        ///Measurement location to gage
        ///</summary>
        [ApiMember(Description="Measurement location to gage", DataType="MeasurementLocationToGageType")]
        public MeasurementLocationToGageType MeasurementLocationToGage { get; set; }

        ///<summary>
        ///Meter suspension
        ///</summary>
        [ApiMember(Description="Meter suspension", DataType="MeterSuspensionType")]
        public MeterSuspensionType MeterSuspension { get; set; }

        ///<summary>
        ///Deployment method
        ///</summary>
        [ApiMember(Description="Deployment method", DataType="DeploymentMethodType")]
        public DeploymentMethodType DeploymentMethod { get; set; }

        ///<summary>
        ///Current meter
        ///</summary>
        [ApiMember(Description="Current meter", DataType="CurrentMeterType")]
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
        [ApiMember(Description="Measurement start time", DataType="DateTimeOffset")]
        public DateTimeOffset? MeasurementStartTime { get; set; }

        ///<summary>
        ///Measurement end time
        ///</summary>
        [ApiMember(Description="Measurement end time", DataType="DateTimeOffset")]
        public DateTimeOffset? MeasurementEndTime { get; set; }

        ///<summary>
        ///Measurement time
        ///</summary>
        [ApiMember(Description="Measurement time", DataType="DateTimeOffset")]
        public DateTimeOffset MeasurementTime { get; set; }

        ///<summary>
        ///Party
        ///</summary>
        [ApiMember(Description="Party")]
        public string Party { get; set; }

        ///<summary>
        ///Base flow
        ///</summary>
        [ApiMember(Description="Base flow", DataType="BaseFlowType")]
        public BaseFlowType BaseFlow { get; set; }

        ///<summary>
        ///Adjustment
        ///</summary>
        [ApiMember(Description="Adjustment", DataType="Adjustment")]
        public Adjustment Adjustment { get; set; }

        ///<summary>
        ///Alternate rating discharge
        ///</summary>
        [ApiMember(Description="Alternate rating discharge", DataType="QuantityWithDisplay")]
        public QuantityWithDisplay AlternateRatingDischarge { get; set; }

        ///<summary>
        ///Discharge
        ///</summary>
        [ApiMember(Description="Discharge", DataType="QuantityWithDisplay")]
        public QuantityWithDisplay Discharge { get; set; }

        ///<summary>
        ///Discharge method
        ///</summary>
        [ApiMember(Description="Discharge method")]
        public string DischargeMethod { get; set; }

        ///<summary>
        ///Mean gage height
        ///</summary>
        [ApiMember(Description="Mean gage height", DataType="QuantityWithDisplay")]
        public QuantityWithDisplay MeanGageHeight { get; set; }

        ///<summary>
        ///Mean gage height method
        ///</summary>
        [ApiMember(Description="Mean gage height method")]
        public string MeanGageHeightMethod { get; set; }

        ///<summary>
        ///Mean index velocity
        ///</summary>
        [ApiMember(Description="Mean index velocity", DataType="QuantityWithDisplay")]
        public QuantityWithDisplay MeanIndexVelocity { get; set; }

        ///<summary>
        ///Discharge measurement reason
        ///</summary>
        [ApiMember(Description="Discharge measurement reason", DataType="DischargeMeasurementReasonType")]
        public DischargeMeasurementReasonType DischargeMeasurementReason { get; set; }

        ///<summary>
        ///Comments
        ///</summary>
        [ApiMember(Description="Comments")]
        public string Comments { get; set; }

        ///<summary>
        ///Gage height calculation
        ///</summary>
        [ApiMember(Description="Gage height calculation", DataType="GageHeightCalculationType")]
        public GageHeightCalculationType GageHeightCalculation { get; set; }

        ///<summary>
        ///Gage height readings
        ///</summary>
        [ApiMember(Description="Gage height readings", DataType="Array<GageHeightReading>")]
        public List<GageHeightReading> GageHeightReadings { get; set; }

        ///<summary>
        ///Difference during visit
        ///</summary>
        [ApiMember(Description="Difference during visit", DataType="DoubleWithDisplay")]
        public DoubleWithDisplay DifferenceDuringVisit { get; set; }

        ///<summary>
        ///Duration in hours
        ///</summary>
        [ApiMember(Description="Duration in hours", DataType="DoubleWithDisplay")]
        public DoubleWithDisplay DurationInHours { get; set; }

        ///<summary>
        ///Measurement grade
        ///</summary>
        [ApiMember(Description="Measurement grade", DataType="MeasurementGradeType")]
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
        [ApiMember(Description="Is valid", DataType="boolean")]
        public bool IsValid { get; set; }

        ///<summary>
        ///Publish
        ///</summary>
        [ApiMember(Description="Publish", DataType="boolean")]
        public bool Publish { get; set; }
    }

    public class EngineeredStructureDischargeActivity
    {
        ///<summary>
        ///Discharge channel measurement
        ///</summary>
        [ApiMember(Description="Discharge channel measurement", DataType="DischargeChannelMeasurement")]
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
        [ApiMember(Description="Mean head", DataType="QuantityWithDisplay")]
        public QuantityWithDisplay MeanHead { get; set; }

        ///<summary>
        ///Is valid
        ///</summary>
        [ApiMember(Description="Is valid", DataType="boolean")]
        public bool IsValid { get; set; }
    }

    public class FieldVisitApproval
    {
        ///<summary>
        ///Approval level
        ///</summary>
        [ApiMember(Description="Approval level", DataType="long integer")]
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
        [ApiMember(Description="Observed date", DataType="DateTimeOffset")]
        public DateTimeOffset? ObservedDate { get; set; }

        ///<summary>
        ///Applicable since
        ///</summary>
        [ApiMember(Description="Applicable since", DataType="DateTimeOffset")]
        public DateTimeOffset? ApplicableSince { get; set; }

        ///<summary>
        ///Zero flow height
        ///</summary>
        [ApiMember(Description="Zero flow height", DataType="DoubleWithDisplay")]
        public DoubleWithDisplay ZeroFlowHeight { get; set; }

        ///<summary>
        ///Is observed
        ///</summary>
        [ApiMember(Description="Is observed", DataType="boolean")]
        public bool IsObserved { get; set; }

        ///<summary>
        ///Calculated details
        ///</summary>
        [ApiMember(Description="Calculated details", DataType="GageHeightAtZeroFlowCalculatedDetails")]
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
        [ApiMember(Description="Is valid", DataType="boolean")]
        public bool IsValid { get; set; }
    }

    public class GageHeightAtZeroFlowCalculatedDetails
    {
        ///<summary>
        ///Stage
        ///</summary>
        [ApiMember(Description="Stage", DataType="DoubleWithDisplay")]
        public DoubleWithDisplay Stage { get; set; }

        ///<summary>
        ///Depth
        ///</summary>
        [ApiMember(Description="Depth", DataType="DoubleWithDisplay")]
        public DoubleWithDisplay Depth { get; set; }

        ///<summary>
        ///Depth certainty
        ///</summary>
        [ApiMember(Description="Depth certainty", DataType="DoubleWithDisplay")]
        public DoubleWithDisplay DepthCertainty { get; set; }
    }

    public class GageHeightReading
    {
        ///<summary>
        ///Is used
        ///</summary>
        [ApiMember(Description="Is used", DataType="boolean")]
        public bool IsUsed { get; set; }

        ///<summary>
        ///Reading time
        ///</summary>
        [ApiMember(Description="Reading time", DataType="DateTimeOffset")]
        public DateTimeOffset? ReadingTime { get; set; }

        ///<summary>
        ///Gage height
        ///</summary>
        [ApiMember(Description="Gage height", DataType="DoubleWithDisplay")]
        public DoubleWithDisplay GageHeight { get; set; }
    }

    public class Inspection
    {
        ///<summary>
        ///Inspection type
        ///</summary>
        [ApiMember(Description="Inspection type", DataType="InspectionType")]
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
        [ApiMember(Description="Time", DataType="DateTimeOffset")]
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
        [ApiMember(Description="Readings", DataType="Array<Reading>")]
        public List<Reading> Readings { get; set; }

        ///<summary>
        ///Calibration checks
        ///</summary>
        [ApiMember(Description="Calibration checks", DataType="Array<CalibrationCheck>")]
        public List<CalibrationCheck> CalibrationChecks { get; set; }

        ///<summary>
        ///Inspections
        ///</summary>
        [ApiMember(Description="Inspections", DataType="Array<Inspection>")]
        public List<Inspection> Inspections { get; set; }

        ///<summary>
        ///Is valid
        ///</summary>
        [ApiMember(Description="Is valid", DataType="boolean")]
        public bool IsValid { get; set; }
    }

    public class OtherMethodDischargeActivity
    {
        ///<summary>
        ///Discharge channel measurement
        ///</summary>
        [ApiMember(Description="Discharge channel measurement", DataType="DischargeChannelMeasurement")]
        public DischargeChannelMeasurement DischargeChannelMeasurement { get; set; }

        ///<summary>
        ///Is valid
        ///</summary>
        [ApiMember(Description="Is valid", DataType="boolean")]
        public bool IsValid { get; set; }
    }

    public class PointVelocityDischargeActivity
    {
        ///<summary>
        ///Discharge channel measurement
        ///</summary>
        [ApiMember(Description="Discharge channel measurement", DataType="DischargeChannelMeasurement")]
        public DischargeChannelMeasurement DischargeChannelMeasurement { get; set; }

        ///<summary>
        ///Distance to meter
        ///</summary>
        [ApiMember(Description="Distance to meter", DataType="QuantityWithDisplay")]
        public QuantityWithDisplay DistanceToMeter { get; set; }

        ///<summary>
        ///Width
        ///</summary>
        [ApiMember(Description="Width", DataType="QuantityWithDisplay")]
        public QuantityWithDisplay Width { get; set; }

        ///<summary>
        ///Area
        ///</summary>
        [ApiMember(Description="Area", DataType="QuantityWithDisplay")]
        public QuantityWithDisplay Area { get; set; }

        ///<summary>
        ///Velocity average
        ///</summary>
        [ApiMember(Description="Velocity average", DataType="QuantityWithDisplay")]
        public QuantityWithDisplay VelocityAverage { get; set; }

        ///<summary>
        ///Mean observation duration in seconds
        ///</summary>
        [ApiMember(Description="Mean observation duration in seconds", DataType="DoubleWithDisplay")]
        public DoubleWithDisplay MeanObservationDurationInSeconds { get; set; }

        ///<summary>
        ///Suspension coefficient used
        ///</summary>
        [ApiMember(Description="Suspension coefficient used", DataType="boolean")]
        public bool SuspensionCoefficientUsed { get; set; }

        ///<summary>
        ///Method coefficient used
        ///</summary>
        [ApiMember(Description="Method coefficient used", DataType="boolean")]
        public bool MethodCoefficientUsed { get; set; }

        ///<summary>
        ///Horizontal coefficient used
        ///</summary>
        [ApiMember(Description="Horizontal coefficient used", DataType="boolean")]
        public bool HorizontalCoefficientUsed { get; set; }

        ///<summary>
        ///Meter inspected before
        ///</summary>
        [ApiMember(Description="Meter inspected before", DataType="boolean")]
        public bool? MeterInspectedBefore { get; set; }

        ///<summary>
        ///Meter inspected after
        ///</summary>
        [ApiMember(Description="Meter inspected after", DataType="boolean")]
        public bool? MeterInspectedAfter { get; set; }

        ///<summary>
        ///Number of panels
        ///</summary>
        [ApiMember(Description="Number of panels", DataType="integer")]
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
        [ApiMember(Description="Discharge method", DataType="DischargeMethodType")]
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
        [ApiMember(Description="Start point", DataType="StartPointType")]
        public StartPointType StartPoint { get; set; }

        ///<summary>
        ///Node details
        ///</summary>
        [ApiMember(Description="Node details")]
        public string NodeDetails { get; set; }

        ///<summary>
        ///Is valid
        ///</summary>
        [ApiMember(Description="Is valid", DataType="boolean")]
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
        [ApiMember(Description="Value", DataType="DoubleWithDisplay")]
        public DoubleWithDisplay Value { get; set; }

        ///<summary>
        ///Unit
        ///</summary>
        [ApiMember(Description="Unit")]
        public string Unit { get; set; }

        ///<summary>
        ///Uncertainty
        ///</summary>
        [ApiMember(Description="Uncertainty", DataType="DoubleWithDisplay")]
        public DoubleWithDisplay Uncertainty { get; set; }

        ///<summary>
        ///Reading type
        ///</summary>
        [ApiMember(Description="Reading type", DataType="ReadingType")]
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
        [ApiMember(Description="Time", DataType="DateTimeOffset")]
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
        [ApiMember(Description="Publish", DataType="boolean")]
        public bool Publish { get; set; }

        ///<summary>
        ///Is valid
        ///</summary>
        [ApiMember(Description="Is valid", DataType="boolean")]
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
        [ApiMember(Description="Temperature", DataType="DoubleWithDisplay")]
        public DoubleWithDisplay Temperature { get; set; }

        ///<summary>
        ///Expiration date
        ///</summary>
        [ApiMember(Description="Expiration date", DataType="DateTimeOffset")]
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
        [ApiMember(Description="Discharge channel measurement", DataType="DischargeChannelMeasurement")]
        public DischargeChannelMeasurement DischargeChannelMeasurement { get; set; }

        ///<summary>
        ///Volumetric discharge readings
        ///</summary>
        [ApiMember(Description="Volumetric discharge readings", DataType="Array<VolumetricDischargeReading>")]
        public List<VolumetricDischargeReading> VolumetricDischargeReadings { get; set; }

        ///<summary>
        ///Measurement container volume
        ///</summary>
        [ApiMember(Description="Measurement container volume", DataType="QuantityWithDisplay")]
        public QuantityWithDisplay MeasurementContainerVolume { get; set; }

        ///<summary>
        ///Is observed
        ///</summary>
        [ApiMember(Description="Is observed", DataType="boolean")]
        public bool IsObserved { get; set; }

        ///<summary>
        ///Is valid
        ///</summary>
        [ApiMember(Description="Is valid", DataType="boolean")]
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
        [ApiMember(Description="Duration in seconds", DataType="DoubleWithDisplay")]
        public DoubleWithDisplay DurationInSeconds { get; set; }

        ///<summary>
        ///Starting volume
        ///</summary>
        [ApiMember(Description="Starting volume", DataType="DoubleWithDisplay")]
        public DoubleWithDisplay StartingVolume { get; set; }

        ///<summary>
        ///Ending volume
        ///</summary>
        [ApiMember(Description="Ending volume", DataType="DoubleWithDisplay")]
        public DoubleWithDisplay EndingVolume { get; set; }

        ///<summary>
        ///Discharge
        ///</summary>
        [ApiMember(Description="Discharge", DataType="DoubleWithDisplay")]
        public DoubleWithDisplay Discharge { get; set; }

        ///<summary>
        ///Is used
        ///</summary>
        [ApiMember(Description="Is used", DataType="boolean")]
        public bool IsUsed { get; set; }

        ///<summary>
        ///Volume change
        ///</summary>
        [ApiMember(Description="Volume change", DataType="DoubleWithDisplay")]
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
        [ApiMember(Description="Visit date", DataType="DateTimeOffset")]
        public DateTimeOffset FirstUsedDate { get; set; }

        ///<summary>
        ///Equations
        ///</summary>
        [ApiMember(Description="Equations", DataType="Array<ActiveMeterCalibrationEquation>")]
        public List<ActiveMeterCalibrationEquation> Equations { get; set; }
    }

    public class ActiveMeterCalibrationEquation
    {
        ///<summary>
        ///Range start
        ///</summary>
        [ApiMember(Description="Range start", DataType="double")]
        public double? RangeStart { get; set; }

        ///<summary>
        ///Range end
        ///</summary>
        [ApiMember(Description="Range end", DataType="double")]
        public double? RangeEnd { get; set; }

        ///<summary>
        ///Slope
        ///</summary>
        [ApiMember(Description="Slope", DataType="double")]
        public double Slope { get; set; }

        ///<summary>
        ///Intercept
        ///</summary>
        [ApiMember(Description="Intercept", DataType="double")]
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
        [ApiMember(Description="Meter type", DataType="MeterType")]
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
        [ApiMember(Description="Meter calibrations", DataType="Array<ActiveMeterCalibration>")]
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
        [ApiMember(IsRequired=true, Description="The unique ID of the time series", DataType="string")]
        public Guid TimeSeriesUniqueId { get; set; }

        ///<summary>
        ///Filter results to items with a StartTime at or after the QueryFrom time
        ///</summary>
        [ApiMember(Description="Filter results to items with a StartTime at or after the QueryFrom time", DataType="DateTimeOffset")]
        public DateTimeOffset? QueryFrom { get; set; }

        ///<summary>
        ///Filter results to items with an EndTime at or before the QueryTo time
        ///</summary>
        [ApiMember(Description="Filter results to items with an EndTime at or before the QueryTo time", DataType="DateTimeOffset")]
        public DateTimeOffset? QueryTo { get; set; }
    }

    [Route("/GetDownchainProcessorListByRatingModel", "GET")]
    public class DownchainProcessorListByRatingModelServiceRequest
        : IReturn<ProcessorListServiceResponse>
    {
        ///<summary>
        ///Rating model identifier
        ///</summary>
        [ApiMember(IsRequired=true, Description="Rating model identifier")]
        public string RatingModelIdentifier { get; set; }

        ///<summary>
        ///Filter results to items with a ProcessorPeriod.StartTime at or after the QueryFrom time
        ///</summary>
        [ApiMember(Description="Filter results to items with a ProcessorPeriod.StartTime at or after the QueryFrom time", DataType="DateTimeOffset")]
        public DateTimeOffset? QueryFrom { get; set; }

        ///<summary>
        ///Filter results to items with a ProcessorPeriod.EndTime at or before the QueryTo time
        ///</summary>
        [ApiMember(Description="Filter results to items with a ProcessorPeriod.EndTime at or before the QueryTo time", DataType="DateTimeOffset")]
        public DateTimeOffset? QueryTo { get; set; }
    }

    [Route("/GetDownchainProcessorListByTimeSeries", "GET")]
    public class DownchainProcessorListByTimeSeriesServiceRequest
        : IReturn<ProcessorListServiceResponse>
    {
        ///<summary>
        ///Unique ID of the time series
        ///</summary>
        [ApiMember(IsRequired=true, Description="Unique ID of the time series", DataType="string")]
        public Guid TimeSeriesUniqueId { get; set; }

        ///<summary>
        ///Filter results to items with a ProcessorPeriod.StartTime at or after the QueryFrom time
        ///</summary>
        [ApiMember(Description="Filter results to items with a ProcessorPeriod.StartTime at or after the QueryFrom time", DataType="DateTimeOffset")]
        public DateTimeOffset? QueryFrom { get; set; }

        ///<summary>
        ///Filter results to items with a ProcessorPeriod.EndTime at or before the QueryTo time
        ///</summary>
        [ApiMember(Description="Filter results to items with a ProcessorPeriod.EndTime at or before the QueryTo time", DataType="DateTimeOffset")]
        public DateTimeOffset? QueryTo { get; set; }
    }

    [Route("/GetEffectiveRatingCurve", "GET")]
    public class EffectiveRatingCurveServiceRequest
        : IReturn<EffectiveRatingCurveServiceResponse>
    {
        ///<summary>
        ///Rating model identifier
        ///</summary>
        [ApiMember(IsRequired=true, Description="Rating model identifier")]
        public string RatingModelIdentifier { get; set; }

        ///<summary>
        ///Table step size increment. Defaults to 0.01
        ///</summary>
        [ApiMember(Description="Table step size increment. Defaults to 0.01", DataType="double")]
        public double? StepSize { get; set; }

        ///<summary>
        ///Forces the response time values to a specific UTC offset. Defaults to the location UTC offset
        ///</summary>
        [ApiMember(Description="Forces the response time values to a specific UTC offset. Defaults to the location UTC offset", DataType="double")]
        public double? UtcOffset { get; set; }

        ///<summary>
        ///Table start value. Required for equation-based ratings. Defaults to minimum table value for table-based ratings
        ///</summary>
        [ApiMember(Description="Table start value. Required for equation-based ratings. Defaults to minimum table value for table-based ratings", DataType="double")]
        public double? StartValue { get; set; }

        ///<summary>
        ///Table end value. Required for equation-based ratings. Defaults to maximum table value for table-based ratings
        ///</summary>
        [ApiMember(Description="Table end value. Required for equation-based ratings. Defaults to maximum table value for table-based ratings", DataType="double")]
        public double? EndValue { get; set; }

        ///<summary>
        ///Effective time of the calculation. Defaults to the current time if not specified
        ///</summary>
        [ApiMember(Description="Effective time of the calculation. Defaults to the current time if not specified", DataType="DateTimeOffset")]
        public DateTimeOffset? EffectiveTime { get; set; }
    }

    [Route("/GetExpandedStageTable", "GET")]
    public class ExpandedStageTableServiceRequest
        : IReturn<ExpandedStageTableServiceResponse>
    {
        ///<summary>
        ///The unique ID of the time series
        ///</summary>
        [ApiMember(IsRequired=true, Description="The unique ID of the time series", DataType="string")]
        public Guid TimeSeriesUniqueId { get; set; }

        ///<summary>
        ///Table step size increment. Defaults to 0.01
        ///</summary>
        [ApiMember(Description="Table step size increment. Defaults to 0.01", DataType="double")]
        public double? StepSize { get; set; }

        ///<summary>
        ///Forces the response time values to a specific UTC offset. Defaults to the time series UTC offset
        ///</summary>
        [ApiMember(Description="Forces the response time values to a specific UTC offset. Defaults to the time series UTC offset", DataType="double")]
        public double? UtcOffset { get; set; }

        ///<summary>
        ///Table starting value
        ///</summary>
        [ApiMember(IsRequired=true, Description="Table starting value", DataType="double")]
        public double? StartValue { get; set; }

        ///<summary>
        ///Table ending value
        ///</summary>
        [ApiMember(IsRequired=true, Description="Table ending value", DataType="double")]
        public double? EndValue { get; set; }
    }

    [Route("/GetFieldVisitData", "GET")]
    public class FieldVisitDataServiceRequest
        : IReturn<FieldVisitDataServiceResponse>
    {
        ///<summary>
        ///Field visit identifier
        ///</summary>
        [ApiMember(IsRequired=true, Description="Field visit identifier")]
        public string FieldVisitIdentifier { get; set; }

        ///<summary>
        ///If set, only report the specific activity type: One of DischargeSummary, DischargeVolumetric, DischargeEngineeredStructure, DischargePointVelocity, DischargeAdcp, GageHeightAtZeroFlow, ControlCondition, DischargeOtherMethod, or Inspection
        ///</summary>
        [ApiMember(Description="If set, only report the specific activity type: One of DischargeSummary, DischargeVolumetric, DischargeEngineeredStructure, DischargePointVelocity, DischargeAdcp, GageHeightAtZeroFlow, ControlCondition, DischargeOtherMethod, or Inspection")]
        public string DiscreteMeasurementActivity { get; set; }

        ///<summary>
        ///True if node details (raw JSON of each specific activity) should be included
        ///</summary>
        [ApiMember(Description="True if node details (raw JSON of each specific activity) should be included", DataType="boolean")]
        public bool? IncludeNodeDetails { get; set; }

        ///<summary>
        ///True if invalid activities (requiring operator intervention) should be included
        ///</summary>
        [ApiMember(Description="True if invalid activities (requiring operator intervention) should be included", DataType="boolean")]
        public bool? IncludeInvalidActivities { get; set; }

        ///<summary>
        ///True if data values should have rounding rules applied
        ///</summary>
        [ApiMember(Description="True if data values should have rounding rules applied", DataType="boolean")]
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
        [ApiMember(Description="Filter results to items with a StartTime at or after the QueryFrom time", DataType="DateTimeOffset")]
        public DateTimeOffset? QueryFrom { get; set; }

        ///<summary>
        ///Filter results to items with an EndTime at or before the QueryTo time
        ///</summary>
        [ApiMember(DataType="DateTimeOffset", Description="Filter results to items with an EndTime at or before the QueryTo time")]
        public DateTimeOffset? QueryTo { get; set; }

        ///<summary>
        ///True if the results should include invalid field visits which require operator attention.
        ///</summary>
        [ApiMember(Description="True if the results should include invalid field visits which require operator attention.", DataType="boolean")]
        public bool? IncludeInvalidFieldVisits { get; set; }

        ///<summary>
        ///Filter results to items modified at or after the ChangesSinceToken time
        ///</summary>
        [ApiMember(Description="Filter results to items modified at or after the ChangesSinceToken time", DataType="DateTime")]
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
        [ApiMember(IsRequired=true, Description="Location identifier")]
        public string LocationIdentifier { get; set; }

        ///<summary>
        ///True if location attachments should be included in the results
        ///</summary>
        [ApiMember(Description="True if location attachments should be included in the results", DataType="boolean")]
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
        [ApiMember(Description="Filter results to items matching the given extended attribute values", DataType="Array<ExtendedAttributeFilter>")]
        public List<ExtendedAttributeFilter> ExtendedFilters { get; set; }

        ///<summary>
        ///Filter results to items modified at or after the ChangesSinceToken time
        ///</summary>
        [ApiMember(Description="Filter results to items modified at or after the ChangesSinceToken time", DataType="DateTime")]
        public DateTime? ChangesSinceToken { get; set; }
    }

    [Route("/GetMetadataChangeTransactionList", "GET")]
    public class MetadataChangeTransactionListServiceRequest
        : IReturn<MetadataChangeTransactionListServiceResponse>
    {
        ///<summary>
        ///The unique ID of the time series
        ///</summary>
        [ApiMember(IsRequired=true, Description="The unique ID of the time series", DataType="string")]
        public Guid TimeSeriesUniqueId { get; set; }

        ///<summary>
        ///Filter results to items with a StartTime at or after the QueryFrom time
        ///</summary>
        [ApiMember(Description="Filter results to items with a StartTime at or after the QueryFrom time", DataType="DateTimeOffset")]
        public DateTimeOffset? QueryFrom { get; set; }

        ///<summary>
        ///Filter results to items with an EndTime at or before the QueryTo time
        ///</summary>
        [ApiMember(Description="Filter results to items with an EndTime at or before the QueryTo time", DataType="DateTimeOffset")]
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
        [ApiMember(IsRequired=true, Description="Rating model identifier")]
        public string RatingModelIdentifier { get; set; }

        ///<summary>
        ///Forces the response time values to a specific UTC offset. Defaults to the location UTC offset
        ///</summary>
        [ApiMember(Description="Forces the response time values to a specific UTC offset. Defaults to the location UTC offset", DataType="double")]
        public double? UtcOffset { get; set; }

        ///<summary>
        ///Filter results to curves with a Period.StartTime at or after the QueryFrom time
        ///</summary>
        [ApiMember(Description="Filter results to curves with a Period.StartTime at or after the QueryFrom time", DataType="DateTimeOffset")]
        public DateTimeOffset? QueryFrom { get; set; }

        ///<summary>
        ///Filter results to curves with a Period.EndTime at or before the QueryTo time
        ///</summary>
        [ApiMember(Description="Filter results to curves with a Period.EndTime at or before the QueryTo time", DataType="DateTimeOffset")]
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
        [ApiMember(Description="Filter results to items matching the Publish value", DataType="boolean")]
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
        [ApiMember(Description="Filter results to items modified at or after the ChangesSinceToken time", DataType="DateTime")]
        public DateTime? ChangesSinceToken { get; set; }
    }

    [Route("/GetRatingModelEffectiveShifts", "GET")]
    public class RatingModelEffectiveShiftsServiceRequest
        : IReturn<RatingModelEffectiveShiftsServiceResponse>
    {
        ///<summary>
        ///Unique ID of the input time series
        ///</summary>
        [ApiMember(IsRequired=true, Description="Unique ID of the input time series", DataType="string")]
        public Guid TimeSeriesUniqueId { get; set; }

        ///<summary>
        ///Rating model identifier
        ///</summary>
        [ApiMember(IsRequired=true, Description="Rating model identifier")]
        public string RatingModelIdentifier { get; set; }

        ///<summary>
        ///Read the input time series starting at the QueryFrom time. Defaults to beginning of record
        ///</summary>
        [ApiMember(Description="Read the input time series starting at the QueryFrom time. Defaults to beginning of record", DataType="DateTimeOffset")]
        public DateTimeOffset? QueryFrom { get; set; }

        ///<summary>
        ///Read the input time series ending at the QueryTo time. Defaults to the end of record.
        ///</summary>
        [ApiMember(Description="Read the input time series ending at the QueryTo time. Defaults to the end of record.", DataType="DateTimeOffset")]
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
        [ApiMember(IsRequired=true, Description="Rating model identifier")]
        public string RatingModelIdentifier { get; set; }

        ///<summary>
        ///Output values
        ///</summary>
        [ApiMember(IsRequired=true, Description="Output values", DataType="Array<double>")]
        public List<double> OutputValues { get; set; }

        ///<summary>
        ///Effective time of the calculation. Defaults to the current time if not specified
        ///</summary>
        [ApiMember(Description="Effective time of the calculation. Defaults to the current time if not specified", DataType="DateTimeOffset")]
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
        [ApiMember(Description="Input values", DataType="Array<double>")]
        public List<double> InputValues { get; set; }

        ///<summary>
        ///Effective time of the calculation. Defaults to the current time if not specified
        ///</summary>
        [ApiMember(Description="Effective time of the calculation. Defaults to the current time if not specified", DataType="DateTimeOffset")]
        public DateTimeOffset? EffectiveTime { get; set; }

        ///<summary>
        ///Set to false to disable rating curve shifts, otherwise true
        ///</summary>
        [ApiMember(Description="Set to false to disable rating curve shifts, otherwise true", DataType="boolean")]
        public bool? ApplyShifts { get; set; }
    }

    [Route("/GetSensorsAndGauges", "GET")]
    public class SensorsAndGaugesServiceRequest
        : IReturn<SensorsAndGaugesServiceResponse>
    {
        ///<summary>
        ///Location identifier
        ///</summary>
        [ApiMember(IsRequired=true, Description="Location identifier")]
        public string LocationIdentifier { get; set; }
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
        [ApiMember(IsRequired=true, Description="The unique IDs of the time-series to retrieve", DataType="Array<string>")]
        public List<Guid> TimeSeriesUniqueIds { get; set; }

        ///<summary>
        ///The unit identifiers for points. Defaults to the time-series unit
        ///</summary>
        [ApiMember(Description="The unit identifiers for points. Defaults to the time-series unit", DataType="Array<string>")]
        public List<string> TimeSeriesOutputUnitIds { get; set; }

        ///<summary>
        ///Filter results to items at or after the QueryFrom time
        ///</summary>
        [ApiMember(Description="Filter results to items at or after the QueryFrom time", DataType="DateTimeOffset")]
        public DateTimeOffset? QueryFrom { get; set; }

        ///<summary>
        ///Filter results to items at or before the QueryTo time
        ///</summary>
        [ApiMember(Description="Filter results to items at or before the QueryTo time", DataType="DateTimeOffset")]
        public DateTimeOffset? QueryTo { get; set; }

        ///<summary>
        ///Forces the response time values to a specific UTC offset. Defaults to the UTC offset of the first time-series
        ///</summary>
        [ApiMember(Description="Forces the response time values to a specific UTC offset. Defaults to the UTC offset of the first time-series", DataType="double")]
        public double? UtcOffset { get; set; }

        ///<summary>
        ///True if data values should have rounding rules applied
        ///</summary>
        [ApiMember(Description="True if data values should have rounding rules applied", DataType="boolean")]
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
        [ApiMember(IsRequired=true, Description="The unique ID of the time series", DataType="string")]
        public Guid TimeSeriesUniqueId { get; set; }

        ///<summary>
        ///Filter results to items with a StartTime at or after the QueryFrom time
        ///</summary>
        [ApiMember(Description="Filter results to items with a StartTime at or after the QueryFrom time", DataType="DateTimeOffset")]
        public DateTimeOffset? QueryFrom { get; set; }

        ///<summary>
        ///Filter results to items with an EndTime at or before the QueryTo time
        ///</summary>
        [ApiMember(Description="Filter results to items with an EndTime at or before the QueryTo time", DataType="DateTimeOffset")]
        public DateTimeOffset? QueryTo { get; set; }
    }

    [Route("/GetTimeSeriesCorrectedData", "GET")]
    public class TimeSeriesDataCorrectedServiceRequest
        : IReturn<TimeSeriesDataServiceResponse>
    {
        ///<summary>
        ///The unique ID of the time series
        ///</summary>
        [ApiMember(IsRequired=true, Description="The unique ID of the time series", DataType="string")]
        public Guid TimeSeriesUniqueId { get; set; }

        ///<summary>
        ///Filter results to items at or after the QueryFrom time
        ///</summary>
        [ApiMember(Description="Filter results to items at or after the QueryFrom time", DataType="DateTimeOffset")]
        public DateTimeOffset? QueryFrom { get; set; }

        ///<summary>
        ///Filter results to items at or before the QueryTo time
        ///</summary>
        [ApiMember(Description="Filter results to items at or before the QueryTo time", DataType="DateTimeOffset")]
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
        [ApiMember(Description="Forces the response time values to a specific UTC offset. Defaults to the time series UTC offset", DataType="double")]
        public double? UtcOffset { get; set; }

        ///<summary>
        ///True if data values should have rounding rules applied
        ///</summary>
        [ApiMember(Description="True if data values should have rounding rules applied", DataType="boolean")]
        public bool? ApplyRounding { get; set; }

        ///<summary>
        ///Defaults to false. See the API reference guide for details
        ///</summary>
        [ApiMember(Description="Defaults to false. See the API reference guide for details", DataType="boolean")]
        public bool? ReturnFullCoverage { get; set; }

        ///<summary>
        ///True if the point results should include gap markers
        ///</summary>
        [ApiMember(Description="True if the point results should include gap markers", DataType="boolean")]
        public bool? IncludeGapMarkers { get; set; }
    }

    [Route("/GetTimeSeriesRawData", "GET")]
    public class TimeSeriesDataRawServiceRequest
        : IReturn<TimeSeriesDataServiceResponse>
    {
        ///<summary>
        ///The unique ID of the time series
        ///</summary>
        [ApiMember(IsRequired=true, Description="The unique ID of the time series", DataType="string")]
        public Guid TimeSeriesUniqueId { get; set; }

        ///<summary>
        ///Filter results to items at or after the QueryFrom time
        ///</summary>
        [ApiMember(Description="Filter results to items at or after the QueryFrom time", DataType="DateTimeOffset")]
        public DateTimeOffset? QueryFrom { get; set; }

        ///<summary>
        ///Filter results to items at or before the QueryTo time
        ///</summary>
        [ApiMember(Description="Filter results to items at or before the QueryTo time", DataType="DateTimeOffset")]
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
        [ApiMember(Description="Forces the response time values to a specific UTC offset. Defaults to the time series UTC offset", DataType="double")]
        public double? UtcOffset { get; set; }

        ///<summary>
        ///True if data values should have rounding rules applied
        ///</summary>
        [ApiMember(Description="True if data values should have rounding rules applied", DataType="boolean")]
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
        [ApiMember(Description="A collection of time series unique IDs to query. Limited to roughly 60 items per request.", DataType="Array<string>")]
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
        [ApiMember(Description="Filter results to items matching the Publish value", DataType="boolean")]
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
        [ApiMember(Description="Filter results to items matching the given extended attribute values", DataType="Array<ExtendedAttributeFilter>")]
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
        [ApiMember(Description="Filter results to items modified at or after the ChangesSinceToken time", DataType="DateTime")]
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
        [ApiMember(Description="Filter results to items matching the Publish value", DataType="boolean")]
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
        [ApiMember(Description="Filter results to items matching the given extended attribute values", DataType="Array<ExtendedAttributeFilter>")]
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
        [ApiMember(IsRequired=true, Description="Unique ID of the time series", DataType="string")]
        public Guid TimeSeriesUniqueId { get; set; }

        ///<summary>
        ///Filter results to items with a ProcessorPeriod.StartTime at or after the QueryFrom time
        ///</summary>
        [ApiMember(Description="Filter results to items with a ProcessorPeriod.StartTime at or after the QueryFrom time", DataType="DateTimeOffset")]
        public DateTimeOffset? QueryFrom { get; set; }

        ///<summary>
        ///Filter results to items with a ProcessorPeriod.EndTime at or before the QueryTo time
        ///</summary>
        [ApiMember(Description="Filter results to items with a ProcessorPeriod.EndTime at or before the QueryTo time", DataType="DateTimeOffset")]
        public DateTimeOffset? QueryTo { get; set; }
    }

    public class ActiveMetersAndCalibrationsServiceResponse
    {
        public ActiveMetersAndCalibrationsServiceResponse()
        {
            ActiveMeterDetails = new List<ActiveMeterDetails>{};
        }

        ///<summary>
        ///Response version
        ///</summary>
        [ApiMember(Description="Response version", DataType="integer")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(Description="Response time", DataType="DateTimeOffset")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Current meter details
        ///</summary>
        [ApiMember(Description="Current meter details", DataType="Array<ActiveMeterDetails>")]
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
        [ApiMember(Description="Response version", DataType="integer")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(Description="Response time", DataType="DateTimeOffset")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Approvals
        ///</summary>
        [ApiMember(Description="Approvals", DataType="Array<ApprovalMetadata>")]
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
        [ApiMember(Description="Response version", DataType="integer")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(Description="Response time", DataType="DateTimeOffset")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Corrections
        ///</summary>
        [ApiMember(Description="Corrections", DataType="Array<Correction>")]
        public List<Correction> Corrections { get; set; }
    }

    public class EffectiveRatingCurveServiceResponse
    {
        ///<summary>
        ///Response version
        ///</summary>
        [ApiMember(Description="Response version", DataType="integer")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(Description="Response time", DataType="DateTimeOffset")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Expanded rating curve
        ///</summary>
        [ApiMember(Description="Expanded rating curve", DataType="ExpandedRatingCurve")]
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
        [ApiMember(Description="Response version", DataType="integer")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(Description="Response time", DataType="DateTimeOffset")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Expanded stage table
        ///</summary>
        [ApiMember(Description="Expanded stage table", DataType="Array<StagePoint>")]
        public List<StagePoint> ExpandedStageTable { get; set; }

        ///<summary>
        ///Corrections
        ///</summary>
        [ApiMember(Description="Corrections", DataType="Array<Correction>")]
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
        [ApiMember(Description="Response version", DataType="integer")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(Description="Response time", DataType="DateTimeOffset")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Attachments
        ///</summary>
        [ApiMember(Description="Attachments", DataType="Array<Attachment>")]
        public List<Attachment> Attachments { get; set; }

        ///<summary>
        ///Discharge activities
        ///</summary>
        [ApiMember(Description="Discharge activities", DataType="Array<DischargeActivity>")]
        public List<DischargeActivity> DischargeActivities { get; set; }

        ///<summary>
        ///Gage height at zero flow activity
        ///</summary>
        [ApiMember(Description="Gage height at zero flow activity", DataType="GageHeightAtZeroFlowActivity")]
        public GageHeightAtZeroFlowActivity GageHeightAtZeroFlowActivity { get; set; }

        ///<summary>
        ///Control condition activity
        ///</summary>
        [ApiMember(Description="Control condition activity", DataType="ControlConditionActivity")]
        public ControlConditionActivity ControlConditionActivity { get; set; }

        ///<summary>
        ///Inspection activity
        ///</summary>
        [ApiMember(Description="Inspection activity", DataType="InspectionActivity")]
        public InspectionActivity InspectionActivity { get; set; }

        ///<summary>
        ///Approval
        ///</summary>
        [ApiMember(Description="Approval", DataType="FieldVisitApproval")]
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
        [ApiMember(Description="Response version", DataType="integer")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(Description="Response time", DataType="DateTimeOffset")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Field visit descriptions
        ///</summary>
        [ApiMember(Description="Field visit descriptions", DataType="Array<FieldVisitDescription>")]
        public List<FieldVisitDescription> FieldVisitDescriptions { get; set; }

        ///<summary>
        ///Next token
        ///</summary>
        [ApiMember(Description="Next token", DataType="DateTime")]
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
        [ApiMember(Description="Response version", DataType="integer")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(Description="Response time", DataType="DateTimeOffset")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Grades
        ///</summary>
        [ApiMember(Description="Grades", DataType="Array<GradeMetadata>")]
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
        [ApiMember(Description="Response version", DataType="integer")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(Description="Response time", DataType="DateTimeOffset")]
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
        ///Unique id
        ///</summary>
        [ApiMember(Description="Unique id", DataType="string")]
        public Guid UniqueId { get; set; }

        ///<summary>
        ///Location type
        ///</summary>
        [ApiMember(Description="Location type")]
        public string LocationType { get; set; }

        ///<summary>
        ///Latitude
        ///</summary>
        [ApiMember(Description="Latitude", DataType="double")]
        public double Latitude { get; set; }

        ///<summary>
        ///Longitude
        ///</summary>
        [ApiMember(Description="Longitude", DataType="double")]
        public double Longitude { get; set; }

        ///<summary>
        ///Srid
        ///</summary>
        [ApiMember(Description="Srid", DataType="double")]
        public double Srid { get; set; }

        ///<summary>
        ///Elevation units
        ///</summary>
        [ApiMember(Description="Elevation units")]
        public string ElevationUnits { get; set; }

        ///<summary>
        ///Elevation
        ///</summary>
        [ApiMember(Description="Elevation", DataType="double")]
        public double Elevation { get; set; }

        ///<summary>
        ///Utc offset
        ///</summary>
        [ApiMember(Description="Utc offset", DataType="double")]
        public double UtcOffset { get; set; }

        ///<summary>
        ///Extended attributes
        ///</summary>
        [ApiMember(Description="Extended attributes", DataType="Array<ExtendedAttribute>")]
        public List<ExtendedAttribute> ExtendedAttributes { get; set; }

        ///<summary>
        ///Location remarks
        ///</summary>
        [ApiMember(Description="Location remarks", DataType="Array<LocationRemark>")]
        public List<LocationRemark> LocationRemarks { get; set; }

        ///<summary>
        ///Attachments
        ///</summary>
        [ApiMember(Description="Attachments", DataType="Array<Attachment>")]
        public List<Attachment> Attachments { get; set; }

        ///<summary>
        ///Location datum
        ///</summary>
        [ApiMember(Description="Location datum", DataType="LocationDatum")]
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
        [ApiMember(Description="Response version", DataType="integer")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(Description="Response time", DataType="DateTimeOffset")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Location descriptions
        ///</summary>
        [ApiMember(Description="Location descriptions", DataType="Array<LocationDescription>")]
        public List<LocationDescription> LocationDescriptions { get; set; }

        ///<summary>
        ///Next token
        ///</summary>
        [ApiMember(Description="Next token", DataType="DateTime")]
        public DateTime? NextToken { get; set; }
    }

    public class MetadataChangeTransactionListServiceResponse
    {
        ///<summary>
        ///Response version
        ///</summary>
        [ApiMember(Description="Response version", DataType="integer")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(Description="Response time", DataType="DateTimeOffset")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Metadata change transactions
        ///</summary>
        [ApiMember(Description="Metadata change transactions", DataType="Array<MetadataChangeTransaction>")]
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
        [ApiMember(Description="Response version", DataType="integer")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(Description="Response time", DataType="DateTime")]
        public DateTime ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Monitoring methods
        ///</summary>
        [ApiMember(Description="Monitoring methods", DataType="Array<MonitoringMethod>")]
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
        [ApiMember(Description="Response version", DataType="integer")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(Description="Response time", DataType="DateTimeOffset")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Parameters
        ///</summary>
        [ApiMember(Description="Parameters", DataType="Array<ParameterMetadata>")]
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
        [ApiMember(Description="Response version", DataType="integer")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(Description="Response time", DataType="DateTimeOffset")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Processors
        ///</summary>
        [ApiMember(Description="Processors", DataType="Array<Processor>")]
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
        [ApiMember(Description="Response version", DataType="integer")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(Description="Response time", DataType="DateTimeOffset")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Qualifiers
        ///</summary>
        [ApiMember(Description="Qualifiers", DataType="Array<QualifierMetadata>")]
        public List<QualifierMetadata> Qualifiers { get; set; }
    }

    public class RatingCurveListServiceResponse
    {
        ///<summary>
        ///Response version
        ///</summary>
        [ApiMember(Description="Response version", DataType="integer")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(Description="Response time", DataType="DateTimeOffset")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Rating curves
        ///</summary>
        [ApiMember(Description="Rating curves", DataType="Array<RatingCurve>")]
        public IList<RatingCurve> RatingCurves { get; set; }

        ///<summary>
        ///Approvals
        ///</summary>
        [ApiMember(Description="Approvals", DataType="Array<Approval>")]
        public IList<Approval> Approvals { get; set; }
    }

    public class RatingModelDescriptionListServiceResponse
    {
        ///<summary>
        ///Response version
        ///</summary>
        [ApiMember(Description="Response version", DataType="integer")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(Description="Response time", DataType="DateTimeOffset")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Rating model descriptions
        ///</summary>
        [ApiMember(Description="Rating model descriptions", DataType="Array<RatingModelDescription>")]
        public IList<RatingModelDescription> RatingModelDescriptions { get; set; }

        ///<summary>
        ///Next token
        ///</summary>
        [ApiMember(Description="Next token", DataType="DateTime")]
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
        [ApiMember(Description="Response version", DataType="integer")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(Description="Response time", DataType="DateTimeOffset")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Effective shifts
        ///</summary>
        [ApiMember(Description="Effective shifts", DataType="Array<EffectiveShift>")]
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
        [ApiMember(Description="Response version", DataType="integer")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(Description="Response time", DataType="DateTimeOffset")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Input values
        ///</summary>
        [ApiMember(Description="Input values", DataType="double")]
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
        [ApiMember(Description="Response version", DataType="integer")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(Description="Response time", DataType="DateTimeOffset")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Output values
        ///</summary>
        [ApiMember(Description="Output values", DataType="double")]
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
        [ApiMember(Description="Response version", DataType="integer")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(Description="Response time", DataType="DateTimeOffset")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Monitoring methods
        ///</summary>
        [ApiMember(Description="Monitoring methods", DataType="Array<LocationMonitoringMethod>")]
        public List<LocationMonitoringMethod> MonitoringMethods { get; set; }
    }

    public class TimeAlignedDataServiceResponse
    {
        public TimeAlignedDataServiceResponse()
        {
            TimeSeries = new List<TimeAlignedTimeSeriesInfo>{};
            Points = new List<TimeAlignedPoint>{};
        }

        ///<summary>
        ///Response version
        ///</summary>
        [ApiMember(Description="Response version", DataType="integer")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(Description="Response time", DataType="DateTimeOffset")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Summary info of the retrieved time-series
        ///</summary>
        [ApiMember(Description="Summary info of the retrieved time-series", DataType="Array<TimeAlignedTimeSeriesInfo>")]
        public List<TimeAlignedTimeSeriesInfo> TimeSeries { get; set; }

        ///<summary>
        ///Time range
        ///</summary>
        [ApiMember(Description="Time range", DataType="TimeRange")]
        public TimeRange TimeRange { get; set; }

        ///<summary>
        ///Number of points
        ///</summary>
        [ApiMember(DataType="integer", Description="Number of points")]
        public int NumPoints { get; set; }

        ///<summary>
        ///Points
        ///</summary>
        [ApiMember(Description="Points", DataType="Array<TimeAlignedPoint>")]
        public List<TimeAlignedPoint> Points { get; set; }
    }

    public class TimeSeriesApprovalsTransactionListServiceResponse
    {
        ///<summary>
        ///Response version
        ///</summary>
        [ApiMember(Description="Response version", DataType="integer")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(Description="Response time", DataType="DateTimeOffset")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Approvals transactions
        ///</summary>
        [ApiMember(Description="Approvals transactions", DataType="Array<ApprovalsTransaction>")]
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
        [ApiMember(Description="Response version", DataType="integer")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(Description="Response time", DataType="DateTimeOffset")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Unique id
        ///</summary>
        [ApiMember(Description="Unique id", DataType="string")]
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
        [ApiMember(Description="Num points", DataType="long integer")]
        public long? NumPoints { get; set; }

        ///<summary>
        ///Unit
        ///</summary>
        [ApiMember(Description="Unit")]
        public string Unit { get; set; }

        ///<summary>
        ///Approvals
        ///</summary>
        [ApiMember(Description="Approvals", DataType="Array<Approval>")]
        public List<Approval> Approvals { get; set; }

        ///<summary>
        ///Qualifiers
        ///</summary>
        [ApiMember(Description="Qualifiers", DataType="Array<Qualifier>")]
        public List<Qualifier> Qualifiers { get; set; }

        ///<summary>
        ///Methods
        ///</summary>
        [ApiMember(Description="Methods", DataType="Array<Method>")]
        public List<Method> Methods { get; set; }

        ///<summary>
        ///Grades
        ///</summary>
        [ApiMember(Description="Grades", DataType="Array<Grade>")]
        public List<Grade> Grades { get; set; }

        ///<summary>
        ///Gap tolerances
        ///</summary>
        [ApiMember(Description="Gap tolerances", DataType="Array<GapTolerance>")]
        public List<GapTolerance> GapTolerances { get; set; }

        ///<summary>
        ///Interpolation types
        ///</summary>
        [ApiMember(Description="Interpolation types", DataType="Array<InterpolationType>")]
        public List<InterpolationType> InterpolationTypes { get; set; }

        ///<summary>
        ///Notes
        ///</summary>
        [ApiMember(Description="Notes", DataType="Array<Note>")]
        public List<Note> Notes { get; set; }

        ///<summary>
        ///Time range
        ///</summary>
        [ApiMember(Description="Time range", DataType="StatisticalTimeRange")]
        public StatisticalTimeRange TimeRange { get; set; }

        ///<summary>
        ///Points
        ///</summary>
        [ApiMember(Description="Points", DataType="Array<TimeSeriesPoint>")]
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
        [ApiMember(Description="Response version", DataType="integer")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(Description="Response time", DataType="DateTimeOffset")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Time series descriptions
        ///</summary>
        [ApiMember(Description="Time series descriptions", DataType="Array<TimeSeriesDescription>")]
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
        [ApiMember(Description="Response version", DataType="integer")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(Description="Response time", DataType="DateTimeOffset")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Time series descriptions
        ///</summary>
        [ApiMember(Description="Time series descriptions", DataType="Array<TimeSeriesDescription>")]
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
        [ApiMember(Description="Response version", DataType="integer")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(Description="Response time", DataType="DateTimeOffset")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Token expired
        ///</summary>
        [ApiMember(Description="Token expired", DataType="boolean")]
        public bool? TokenExpired { get; set; }

        ///<summary>
        ///Next token
        ///</summary>
        [ApiMember(Description="Next token", DataType="DateTime")]
        public DateTime? NextToken { get; set; }

        ///<summary>
        ///Time series unique ids
        ///</summary>
        [ApiMember(Description="Time series unique ids", DataType="Array<TimeSeriesUniqueIds>")]
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
        [ApiMember(Description="Response version", DataType="integer")]
        public int ResponseVersion { get; set; }

        ///<summary>
        ///Response time
        ///</summary>
        [ApiMember(Description="Response time", DataType="DateTimeOffset")]
        public DateTimeOffset ResponseTime { get; set; }

        ///<summary>
        ///Summary
        ///</summary>
        [ApiMember(Description="Summary")]
        public string Summary { get; set; }

        ///<summary>
        ///Units
        ///</summary>
        [ApiMember(Description="Units", DataType="Array<UnitMetadata>")]
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

namespace Aquarius.TimeSeries.Client.ServiceModels.Publish
{
    public static class Current
    {
        public static readonly AquariusServerVersion Version = AquariusServerVersion.Create("17.2.69.0");
    }
}
