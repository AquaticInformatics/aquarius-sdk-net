/* Options:
Date: 2020-10-16 12:37:09
Version: 5.80
Tip: To override a DTO option, remove "//" prefix before updating
BaseUrl: http://autoserver1/AQUARIUS/Acquisition/v2

GlobalNamespace: Aquarius.TimeSeries.Client.ServiceModels.Acquisition
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
using Aquarius.TimeSeries.Client.ServiceModels.Acquisition;


namespace Aquarius.TimeSeries.Client.ServiceModels.Acquisition
{

    public enum AppendStatusCode
    {
        Pending,
        Completed,
        Failed,
    }

    public enum AttachmentCategory
    {
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

    public enum PointType
    {
        Unknown,
        Point,
        Gap,
    }

    [Route("/attachments/reports/{ReportUniqueId}", "DELETE")]
    public class DeleteReportAttachment
        : IReturnVoid
    {
        ///<summary>
        ///Unique ID of report
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of report", IsRequired=true, ParameterType="path")]
        public Guid ReportUniqueId { get; set; }
    }

    [Route("/timeseries/{UniqueId}/metadata/notes", "DELETE")]
    public class DeleteTimeSeriesNotes
        : IReturn<DeleteTimeSeriesNotesResponse>
    {
        ///<summary>
        ///The unique ID (from Publish API) of the time-series
        ///</summary>
        [ApiMember(DataType="string", Description="The unique ID (from Publish API) of the time-series", IsRequired=true, ParameterType="path")]
        public Guid UniqueId { get; set; }

        ///<summary>
        ///Time range. Only appended notes that are fully contained within the time range will be deleted.
        ///</summary>
        [ApiMember(DataType="Interval", Description="Time range. Only appended notes that are fully contained within the time range will be deleted.", IsRequired=true)]
        public Interval? TimeRange { get; set; }
    }

    [Route("/visits/{VisitIdentifier}", "DELETE")]
    public class DeleteVisit
        : IReturnVoid
    {
        ///<summary>
        ///Identifier of the existing visit to delete
        ///</summary>
        [ApiMember(Description="Identifier of the existing visit to delete", IsRequired=true, ParameterType="path")]
        public string VisitIdentifier { get; set; }
    }

    [Route("/timeseries/appendstatus/{AppendRequestIdentifier}", "GET")]
    public class GetTimeSeriesAppendStatus
        : IReturn<TimeSeriesAppendStatus>
    {
        ///<summary>
        ///Identifier returned from a previous append request
        ///</summary>
        [ApiMember(Description="Identifier returned from a previous append request", IsRequired=true, ParameterType="path")]
        public string AppendRequestIdentifier { get; set; }
    }

    public interface IFileUploadRequest
    {
        IHttpFile File { get; set; }
    }

    [Route("/locations/{LocationUniqueId}/attachments", "POST")]
    public class PostLocationAttachment
        : IReturn<PostLocationAttachmentResponse>, IFileUploadRequest
    {
        ///<summary>
        ///Unique ID of the location to add the attachment to
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the location to add the attachment to", IsRequired=true, ParameterType="path")]
        public Guid LocationUniqueId { get; set; }

        ///<summary>
        ///If not specified, defaults to None
        ///</summary>
        [ApiMember(DataType="AttachmentCategory", Description="If not specified, defaults to None")]
        public AttachmentCategory AttachmentCategory { get; set; }

        ///<summary>
        ///Comment
        ///</summary>
        [ApiMember(Description="Comment")]
        public string Comments { get; set; }

        ///<summary>
        ///File
        ///</summary>
        [Ignore]
        [ApiMember(DataType="file", Description="File", IsRequired=true, ParameterType="form")]
        public IHttpFile File { get; set; }
    }

    [Route("/timeseries/{UniqueId}/reflected", "POST")]
    public class PostReflectedTimeSeries
        : IReturn<AppendResponse>
    {
        public PostReflectedTimeSeries()
        {
            Points = new List<TimeSeriesPoint>{};
        }

        ///<summary>
        ///The unique ID (from Publish API) of the reflected time-series to receive points
        ///</summary>
        [ApiMember(DataType="string", Description="The unique ID (from Publish API) of the reflected time-series to receive points", IsRequired=true, ParameterType="path")]
        public Guid UniqueId { get; set; }

        ///<summary>
        ///Points to append (can be empty). All points must lie within the time range
        ///</summary>
        [ApiMember(DataType="Array<TimeSeriesPoint>", Description="Points to append (can be empty). All points must lie within the time range")]
        public List<TimeSeriesPoint> Points { get; set; }

        ///<summary>
        ///Time range to update. Any existing points in the time range will be overwritten
        ///</summary>
        [ApiMember(DataType="Interval", Description="Time range to update. Any existing points in the time range will be overwritten", IsRequired=true)]
        public Interval TimeRange { get; set; }
    }

    [Route("/locations/{LocationUniqueId}/attachments/reports", "POST")]
    public class PostReportAttachment
        : IReturn<PostReportResponse>, IFileUploadRequest
    {
        public PostReportAttachment()
        {
            SourceTimeSeriesUniqueIds = new List<Guid>{};
        }

        ///<summary>
        ///Title of the report
        ///</summary>
        [ApiMember(Description="Title of the report", IsRequired=true)]
        public string Title { get; set; }

        ///<summary>
        ///Description of the report
        ///</summary>
        [ApiMember(Description="Description of the report")]
        public string Description { get; set; }

        ///<summary>
        ///Comments about the report
        ///</summary>
        [ApiMember(Description="Comments about the report")]
        public string Comments { get; set; }

        ///<summary>
        ///Unique ID of the location to add the report to
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the location to add the report to", IsRequired=true, ParameterType="path")]
        public Guid LocationUniqueId { get; set; }

        ///<summary>
        ///Unique IDs of source time-series displayed in report
        ///</summary>
        [ApiMember(DataType="Array<string>", Description="Unique IDs of source time-series displayed in report")]
        public List<Guid> SourceTimeSeriesUniqueIds { get; set; }

        ///<summary>
        ///Time range of source data displayed in report
        ///</summary>
        [ApiMember(DataType="Interval", Description="Time range of source data displayed in report")]
        public Interval? SourceTimeRange { get; set; }

        ///<summary>
        ///Time report was created
        ///</summary>
        [ApiMember(DataType="Instant", Description="Time report was created")]
        public Instant? CreatedTime { get; set; }

        ///<summary>
        ///File
        ///</summary>
        [Ignore]
        [ApiMember(DataType="file", Description="File", IsRequired=true, ParameterType="form")]
        public IHttpFile File { get; set; }
    }

    [Route("/timeseries/{UniqueId}/append", "POST")]
    public class PostTimeSeriesAppend
        : IReturn<AppendResponse>
    {
        public PostTimeSeriesAppend()
        {
            Points = new List<TimeSeriesPoint>{};
        }

        ///<summary>
        ///The unique ID (from Publish API) of the time-series to receive points
        ///</summary>
        [ApiMember(DataType="string", Description="The unique ID (from Publish API) of the time-series to receive points", IsRequired=true, ParameterType="path")]
        public Guid UniqueId { get; set; }

        ///<summary>
        ///Points to append (can be empty)
        ///</summary>
        [ApiMember(DataType="Array<TimeSeriesPoint>", Description="Points to append (can be empty)")]
        public List<TimeSeriesPoint> Points { get; set; }
    }

    [Route("/timeseries/{UniqueId}/metadata", "POST")]
    public class PostTimeSeriesMetadata
        : IReturn<PostTimeSeriesMetadataResponse>
    {
        public PostTimeSeriesMetadata()
        {
            Notes = new List<TimeSeriesNote>{};
        }

        ///<summary>
        ///The unique ID (from Publish API) of the time-series
        ///</summary>
        [ApiMember(DataType="string", Description="The unique ID (from Publish API) of the time-series", IsRequired=true, ParameterType="path")]
        public Guid UniqueId { get; set; }

        ///<summary>
        ///Notes to append
        ///</summary>
        [ApiMember(DataType="Array<TimeSeriesNote>", Description="Notes to append", IsRequired=true)]
        public List<TimeSeriesNote> Notes { get; set; }
    }

    [Route("/timeseries/{UniqueId}/overwriteappend", "POST")]
    public class PostTimeSeriesOverwriteAppend
        : IReturn<AppendResponse>
    {
        public PostTimeSeriesOverwriteAppend()
        {
            Points = new List<TimeSeriesPoint>{};
        }

        ///<summary>
        ///The unique ID (from Publish API) of the time-series to receive points
        ///</summary>
        [ApiMember(DataType="string", Description="The unique ID (from Publish API) of the time-series to receive points", IsRequired=true, ParameterType="path")]
        public Guid UniqueId { get; set; }

        ///<summary>
        ///Points to append (can be empty). All points must lie within the time range
        ///</summary>
        [ApiMember(DataType="Array<TimeSeriesPoint>", Description="Points to append (can be empty). All points must lie within the time range")]
        public List<TimeSeriesPoint> Points { get; set; }

        ///<summary>
        ///Time range to delete before appending points
        ///</summary>
        [ApiMember(DataType="Interval", Description="Time range to delete before appending points", IsRequired=true)]
        public Interval TimeRange { get; set; }
    }

    [Route("/visits/upload/plugins", "POST")]
    public class PostVisitFile
        : PostVisitFileBase, IReturn<PostVisitFileResponse>, IFileUploadRequest
    {
    }

    public class PostVisitFileBase
        : IFileUploadRequest
    {
        ///<summary>
        ///File
        ///</summary>
        [Ignore]
        [ApiMember(DataType="file", Description="File", IsRequired=true, ParameterType="form")]
        public IHttpFile File { get; set; }
    }

    [Route("/locations/{LocationUniqueId}/visits/upload/plugins", "POST")]
    public class PostVisitFileToLocation
        : PostVisitFileBase, IReturn<PostVisitFileResponse>, IFileUploadRequest
    {
        ///<summary>
        ///Unique ID of the location of visits in the file
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the location of visits in the file", IsRequired=true, ParameterType="path")]
        public Guid LocationUniqueId { get; set; }
    }

    [Route("/visits/{VisitIdentifier}/upload/plugins", "POST")]
    public class PostVisitFileToVisit
        : PostVisitFileBase, IReturn<PostVisitFileResponse>, IFileUploadRequest
    {
        ///<summary>
        ///Identifier of the existing visit to add the file's content to
        ///</summary>
        [ApiMember(Description="Identifier of the existing visit to add the file\'s content to", IsRequired=true, ParameterType="path")]
        public string VisitIdentifier { get; set; }
    }

    public class TimeSeriesNote
    {
        ///<summary>
        ///Time range of the note
        ///</summary>
        [ApiMember(DataType="Interval", Description="Time range of the note", IsRequired=true)]
        public Interval? TimeRange { get; set; }

        ///<summary>
        ///Content of the note
        ///</summary>
        [ApiMember(Description="Content of the note", IsRequired=true)]
        public string NoteText { get; set; }
    }

    public class TimeSeriesPoint
    {
        public TimeSeriesPoint()
        {
            Qualifiers = new List<string>{};
        }

        ///<summary>
        ///ISO 8601 timestamp. Must not be specified if Type is 'Gap'.
        ///</summary>
        [ApiMember(DataType="Instant", Description="ISO 8601 timestamp. Must not be specified if Type is \'Gap\'.")]
        public Instant? Time { get; set; }

        ///<summary>
        ///The value of the point. Null or empty to represent a NaN. Must not be specified if Type is 'Gap'.
        ///</summary>
        [ApiMember(DataType="double", Description="The value of the point. Null or empty to represent a NaN. Must not be specified if Type is \'Gap\'.")]
        public double? Value { get; set; }

        ///<summary>
        ///The type of the point: 'Point' or 'Gap'. Defaults to 'Point' if null or empty.
        ///</summary>
        [ApiMember(DataType="PointType", Description="The type of the point: \'Point\' or \'Gap\'. Defaults to \'Point\' if null or empty.")]
        public PointType? Type { get; set; }

        ///<summary>
        ///Grade code
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code")]
        public int? GradeCode { get; set; }

        ///<summary>
        ///Qualifier codes
        ///</summary>
        [ApiMember(DataType="Array<string>", Description="Qualifier codes")]
        public List<string> Qualifiers { get; set; }
    }

    public class AppendResponse
    {
        ///<summary>
        ///A token to use in subsequent GetTimeSeriesAppendStatus calls
        ///</summary>
        [ApiMember(Description="A token to use in subsequent GetTimeSeriesAppendStatus calls")]
        public string AppendRequestIdentifier { get; set; }
    }

    public class DeleteTimeSeriesNotesResponse
    {
        ///<summary>
        ///Notes deleted
        ///</summary>
        [ApiMember(DataType="integer", Description="Notes deleted")]
        public int NotesDeleted { get; set; }
    }

    public class FieldDataPlugin
    {
        ///<summary>
        ///Name
        ///</summary>
        [ApiMember(Description="Name")]
        public string Name { get; set; }

        ///<summary>
        ///Unique id
        ///</summary>
        [ApiMember(DataType="string", Description="Unique id")]
        public Guid UniqueId { get; set; }
    }

    public class PostLocationAttachmentResponse
    {
        ///<summary>
        ///Attachment URL
        ///</summary>
        [ApiMember(Description="Attachment URL")]
        public string Url { get; set; }

        ///<summary>
        ///Unique ID of the location
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the location")]
        public Guid LocationUniqueId { get; set; }

        ///<summary>
        ///File name
        ///</summary>
        [ApiMember(Description="File name")]
        public string FileName { get; set; }

        ///<summary>
        ///Attachment category
        ///</summary>
        [ApiMember(DataType="AttachmentCategory", Description="Attachment category")]
        public AttachmentCategory AttachmentCategory { get; set; }

        ///<summary>
        ///Comment
        ///</summary>
        [ApiMember(Description="Comment")]
        public string Comments { get; set; }

        public AttachmentType AttachmentType { get; set; }
    }

    public class PostReportResponse
    {
        ///<summary>
        ///Unique ID of the created report
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the created report")]
        public Guid ReportUniqueId { get; set; }
    }

    public class PostTimeSeriesMetadataResponse
    {
        ///<summary>
        ///Notes created
        ///</summary>
        [ApiMember(DataType="integer", Description="Notes created")]
        public int NotesCreated { get; set; }
    }

    public class PostVisitFileResponse
    {
        public PostVisitFileResponse()
        {
            VisitUris = new List<string>{};
            VisitIdentifiers = new List<string>{};
        }

        ///<summary>
        ///Relative URIs of created or modified visits
        ///</summary>
        [ApiMember(DataType="Array<string>", Description="Relative URIs of created or modified visits")]
        public List<string> VisitUris { get; set; }

        ///<summary>
        ///Identifiers of created or modified visits
        ///</summary>
        [ApiMember(DataType="Array<string>", Description="Identifiers of created or modified visits")]
        public List<string> VisitIdentifiers { get; set; }

        ///<summary>
        ///Registered field data plug-in that processed the file
        ///</summary>
        [ApiMember(DataType="FieldDataPlugin", Description="Registered field data plug-in that processed the file")]
        public FieldDataPlugin HandledByPlugin { get; set; }
    }

    public class TimeSeriesAppendStatus
    {
        ///<summary>
        ///Unique ID of the time series
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the time series")]
        public Guid TimeSeriesUniqueId { get; set; }

        public AppendStatusCode AppendStatus { get; set; }
        ///<summary>
        ///When AppendStatus=Completed: Version of the time series containing the appended points
        ///</summary>
        [ApiMember(DataType="Int64", Description="When AppendStatus=Completed: Version of the time series containing the appended points")]
        public long AppendedVersion { get; set; }

        ///<summary>
        ///When AppendStatus=Completed: Number of points successfully appended
        ///</summary>
        [ApiMember(DataType="integer", Description="When AppendStatus=Completed: Number of points successfully appended")]
        public int NumberOfPointsAppended { get; set; }

        ///<summary>
        ///When AppendStatus=Completed: Number of points successfully deleted
        ///</summary>
        [ApiMember(DataType="integer", Description="When AppendStatus=Completed: Number of points successfully deleted")]
        public int NumberOfPointsDeleted { get; set; }
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
        [ApiMember(DataType="integer", Description="RSA key size in bits")]
        public int KeySize { get; set; }

        ///<summary>
        ///XML blob containing the RSA public key components
        ///</summary>
        [ApiMember(Description="XML blob containing the RSA public key components")]
        public string Xml { get; set; }
    }
}

namespace Aquarius.TimeSeries.Client.ServiceModels.Acquisition
{
    public static class Current
    {
        public static readonly AquariusServerVersion Version = AquariusServerVersion.Create("20.3.84.0");
    }
}
