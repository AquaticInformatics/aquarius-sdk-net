// Generated from: {"ApiVersion":"16.1.101.0"}
/* Options:
Date: 2016-06-06 17:45:20
Version: 4.054
Tip: To override a DTO option, remove "//" prefix before updating
BaseUrl: http://doug-vm2012r2/AQUARIUS/Acquisition/v2

GlobalNamespace: Aquarius.Client.Acquisition
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
using Aquarius.Client.Acquisition;


namespace Aquarius.Client.Acquisition
{

    public enum AppendStatusCode
    {
        Pending,
        Completed,
        Failed,
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

    public class TimeSeriesPoint
    {
        [ApiMember(IsRequired=true, Description="ISO 8601 timestamp")]
        public Instant Time { get; set; }

        [ApiMember(Description="The value of the point. Null or empty to represent a NaN")]
        public double? Value { get; set; }
    }

    [Route("/timeseries/appendstatus/{AppendRequestIdentifier}", "GET")]
    public class GetTimeSeriesAppendStatus
        : IReturn<TimeSeriesAppendStatus>
    {
        [ApiMember(Description="Identifier returned from a previous append request", IsRequired=true)]
        public string AppendRequestIdentifier { get; set; }
    }

    [Route("/timeseries/{UniqueId}/append", "POST")]
    public class PostTimeSeriesAppend
        : IReturn<AppendResponse>
    {
        public PostTimeSeriesAppend()
        {
            Points = new List<TimeSeriesPoint>{};
        }

        [ApiMember(IsRequired=true, Description="The unique ID (from Publish API) of the time series to receive points")]
        public Guid UniqueId { get; set; }

        [ApiMember(Description="Points to append (can be empty)")]
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

        [ApiMember(IsRequired=true, Description="The unique ID (from Publish API) of the time series to receive points")]
        public Guid UniqueId { get; set; }

        [ApiMember(Description="Points to append (can be empty). All points must lie within the time range")]
        public List<TimeSeriesPoint> Points { get; set; }

        [ApiMember(IsRequired=true, Description="Time range to delete before appending points")]
        public Interval TimeRange { get; set; }
    }

    public class AppendResponse
    {
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
        public string Username { get; set; }
        public string EncryptedPassword { get; set; }
        public string Locale { get; set; }
    }

    public class PublicKey
    {
        public int KeySize { get; set; }
        public string Xml { get; set; }
    }
}

