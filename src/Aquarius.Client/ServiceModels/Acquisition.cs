/* Options:
Date: 2017-02-14 12:11:22
Version: 4.50
Tip: To override a DTO option, remove "//" prefix before updating
BaseUrl: http://autoserver12/AQUARIUS/Acquisition/v2

GlobalNamespace: Aquarius.Client.ServiceModels.Acquisition
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
using Aquarius.Client.ServiceModels.Acquisition;


namespace Aquarius.Client.ServiceModels.Acquisition
{

    public enum AppendStatusCode
    {
        Pending,
        Completed,
        Failed,
    }

    public class TimeSeriesAppendStatus
    {
        ///<summary>
        ///Internal ID of the time series
        ///</summary>
        [ApiMember(Description="Internal ID of the time series")]
        public long TimeSeriesId { get; set; }

        public AppendStatusCode AppendStatus { get; set; }
        ///<summary>
        ///When AppendStatus=Completed: Version of the time series containing the appended points
        ///</summary>
        [ApiMember(Description="When AppendStatus=Completed: Version of the time series containing the appended points")]
        public long AppendedVersion { get; set; }

        ///<summary>
        ///When AppendStatus=Completed: Number of points successfully appended
        ///</summary>
        [ApiMember(Description="When AppendStatus=Completed: Number of points successfully appended")]
        public int NumberOfPointsAppended { get; set; }

        ///<summary>
        ///When AppendStatus=Completed: Number of points successfully deleted
        ///</summary>
        [ApiMember(Description="When AppendStatus=Completed: Number of points successfully deleted")]
        public int NumberOfPointsDeleted { get; set; }
    }

    [Route("/timeseries/appendstatus/{AppendRequestIdentifier}", "GET")]
    public class GetTimeSeriesAppendStatus
        : IReturn<TimeSeriesAppendStatus>
    {
        ///<summary>
        ///Identifier returned from a previous append request
        ///</summary>
        [ApiMember(Description="Identifier returned from a previous append request", ParameterType="path", IsRequired=true)]
        public string AppendRequestIdentifier { get; set; }
    }

    [Route("/timeseries/{UniqueId}/reflected", "POST")]
    public class PostReflectedTimeSeries
        : IReturn<AppendResponse>
    {
        public PostReflectedTimeSeries()
        {
            Points = new List<ReflectedTimeSeriesPoint>{};
        }

        ///<summary>
        ///The unique ID (from Publish API) of the reflected time series to receive points
        ///</summary>
        [ApiMember(Description="The unique ID (from Publish API) of the reflected time series to receive points", ParameterType="path", DataType="string", IsRequired=true)]
        public Guid UniqueId { get; set; }

        ///<summary>
        ///Points to append (can be empty). All points must lie within the time range
        ///</summary>
        [ApiMember(Description="Points to append (can be empty). All points must lie within the time range", DataType="Array<ReflectedTimeSeriesPoint>")]
        public List<ReflectedTimeSeriesPoint> Points { get; set; }

        ///<summary>
        ///Time range to update. Any existing points in the time range will be overwritten
        ///</summary>
        [ApiMember(Description="Time range to update. Any existing points in the time range will be overwritten", DataType="Interval", IsRequired=true)]
        public Interval TimeRange { get; set; }
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
        ///The unique ID (from Publish API) of the time series to receive points
        ///</summary>
        [ApiMember(Description="The unique ID (from Publish API) of the time series to receive points", ParameterType="path", DataType="string", IsRequired=true)]
        public Guid UniqueId { get; set; }

        ///<summary>
        ///Points to append (can be empty)
        ///</summary>
        [ApiMember(Description="Points to append (can be empty)", DataType="Array<TimeSeriesPoint>")]
        public List<TimeSeriesPoint> Points { get; set; }
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
        ///The unique ID (from Publish API) of the time series to receive points
        ///</summary>
        [ApiMember(Description="The unique ID (from Publish API) of the time series to receive points", ParameterType="path", DataType="string", IsRequired=true)]
        public Guid UniqueId { get; set; }

        ///<summary>
        ///Points to append (can be empty). All points must lie within the time range
        ///</summary>
        [ApiMember(Description="Points to append (can be empty). All points must lie within the time range", DataType="Array<TimeSeriesPoint>")]
        public List<TimeSeriesPoint> Points { get; set; }

        ///<summary>
        ///Time range to delete before appending points
        ///</summary>
        [ApiMember(Description="Time range to delete before appending points", DataType="Interval")]
        public Interval TimeRange { get; set; }
    }

    public class ReflectedTimeSeriesPoint
        : TimeSeriesPoint
    {
        public ReflectedTimeSeriesPoint()
        {
            Qualifiers = new List<string>{};
        }

        ///<summary>
        ///Grade code
        ///</summary>
        [ApiMember(Description="Grade code", DataType="integer")]
        public int? GradeCode { get; set; }

        ///<summary>
        ///Qualifier codes
        ///</summary>
        [ApiMember(Description="Qualifier codes", DataType="Array<string>")]
        public List<string> Qualifiers { get; set; }
    }

    public class TimeSeriesPoint
    {
        ///<summary>
        ///ISO 8601 timestamp
        ///</summary>
        [ApiMember(Description="ISO 8601 timestamp", DataType="Instant", IsRequired=true)]
        public Instant? Time { get; set; }

        ///<summary>
        ///The value of the point. Null or empty to represent a NaN
        ///</summary>
        [ApiMember(Description="The value of the point. Null or empty to represent a NaN", DataType="double")]
        public double? Value { get; set; }
    }

    public class AppendResponse
    {
        ///<summary>
        ///A token to use in subsequent GetTimeSeriesAppendStatus calls
        ///</summary>
        [ApiMember(Description="A token to use in subsequent GetTimeSeriesAppendStatus calls")]
        public string AppendRequestIdentifier { get; set; }
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
        [ApiMember(Description="RSA key size in bits", DataType="integer")]
        public int KeySize { get; set; }

        ///<summary>
        ///XML blob containing the RSA public key components
        ///</summary>
        [ApiMember(Description="XML blob containing the RSA public key components")]
        public string Xml { get; set; }
    }
}

namespace Aquarius.Client.ServiceModels.Acquisition
{
    public static class Current
    {
        public static readonly AquariusServerVersion Version = AquariusServerVersion.Create("17.1.78.0");
    }
}
