// Generated from: {"ApiVersion":"16.1.101.0"}
/* Options:
Date: 2016-06-06 17:45:20
Version: 4.054
Tip: To override a DTO option, remove "//" prefix before updating
BaseUrl: http://doug-vm2012r2/AQUARIUS/Provisioning/v1

GlobalNamespace: Aquarius.Client.ServiceModels.Provisioning
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


namespace Aquarius.Client.ServiceModels.Provisioning
{

    public enum InterpolationType
    {
        InstantaneousValues = 1,
        PrecedingConstant = 2,
        PrecedingTotals = 5,
        InstantaneousTotals = 6,
        DiscreteValues = 7,
        SucceedingConstant = 8,
    }

    public enum TimeSeriesType
    {
        Unknown,
        ProcessorBasic,
        ProcessorDerived,
        External,
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

    public enum NewValueLocationType
    {
        Unknown,
        Start,
        End,
    }

    [Route("/monitoringmethods/{MethodCode}", "DELETE")]
    public class DeleteMonitoringMethod
        : IReturn<ResponseStatus>
    {
        public string MethodCode { get; set; }
    }

    [Route("/parameters/{UniqueId}", "DELETE")]
    public class DeleteParameter
        : IReturn<ResponseStatus>
    {
        public Guid UniqueId { get; set; }
    }

    [Route("/location/{LocationUniqueId}", "GET")]
    public class GetLocation
        : IReturn<Location>
    {
        [ApiMember(IsRequired=true)]
        public Guid LocationUniqueId { get; set; }
    }

    [Route("/locations", "GET")]
    public class GetLocations
        : IReturn<List<Location>>
    {
    }

    [Route("/monitoringmethods/{MethodCode}", "GET")]
    public class GetMonitoringMethod
        : IReturn<MonitoringMethod>
    {
        public string MethodCode { get; set; }
    }

    [Route("/monitoringmethods", "GET")]
    public class GetMonitoringMethods
        : IReturn<List<MonitoringMethod>>
    {
    }

    [Route("/parameters/{UniqueId}", "GET")]
    public class GetParameter
        : IReturn<Parameter>
    {
        public Guid UniqueId { get; set; }
    }

    [Route("/parameters", "GET")]
    public class GetParameters
        : IReturn<List<Parameter>>
    {
    }

    [Route("/timeseries/{TimeSeriesUniqueId}", "GET")]
    public class GetTimeSeries
        : IReturn<TimeSeries>
    {
        [ApiMember(IsRequired=true)]
        public Guid TimeSeriesUniqueId { get; set; }
    }

    public class MonitoringMethodWriteBase
    {
        [ApiMember(IsRequired=true)]
        public string MethodCode { get; set; }

        [ApiMember(IsRequired=true)]
        public string DisplayName { get; set; }

        public string Description { get; set; }
        [ApiMember(IsRequired=true)]
        public Guid ParameterUniqueId { get; set; }

        public string RoundingSpec { get; set; }
    }

    public class ParameterBase
    {
        [ApiMember(IsRequired=true)]
        public string ParameterId { get; set; }

        [ApiMember(IsRequired=true)]
        public string Identifier { get; set; }

        [ApiMember(IsRequired=true)]
        public string DisplayName { get; set; }

        [ApiMember(IsRequired=true)]
        public string UnitGroupIdentifier { get; set; }

        [ApiMember(IsRequired=true)]
        public string UnitIdentifier { get; set; }

        public double? MinValue { get; set; }
        public double? MaxValue { get; set; }
        [ApiMember(IsRequired=true)]
        public string InterpolationType { get; set; }

        public string RoundingSpec { get; set; }
    }

    [Route("/location/{LocationUniqueId}/timeseries/basic", "POST")]
    public class PostBasicTimeSeries
        : TimeSeriesBase, IReturn<TimeSeries>
    {
        public Duration GapTolerance { get; set; }
    }

    [Route("/location/{LocationUniqueId}/timeseries/calculated", "POST")]
    public class PostCalculatedDerivedTimeSeries
        : TimeSeriesBase, IReturn<TimeSeries>
    {
        public PostCalculatedDerivedTimeSeries()
        {
            TimeSeriesUniqueIds = new List<Guid>{};
        }

        [ApiMember(IsRequired=true)]
        public List<Guid> TimeSeriesUniqueIds { get; set; }

        [ApiMember(IsRequired=true)]
        public string Formula { get; set; }
    }

    [Route("/location", "POST")]
    public class PostLocation
        : IReturn<Location>
    {
        [ApiMember(IsRequired=true)]
        public string LocationIdentifier { get; set; }

        [ApiMember(IsRequired=true)]
        public string LocationName { get; set; }

        [ApiMember(IsRequired=true)]
        public string LocationPath { get; set; }

        [ApiMember(IsRequired=true)]
        public string LocationType { get; set; }

        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        public Offset UtcOffset { get; set; }
    }

    [Route("/monitoringmethods", "POST")]
    public class PostMonitoringMethod
        : MonitoringMethodWriteBase
    {
    }

    [Route("/parameters", "POST")]
    public class PostParameter
        : ParameterBase, IReturn<Parameter>
    {
    }

    [Route("/location/{LocationUniqueId}/timeseries/statistical", "POST")]
    public class PostStatisticalDerivedTimeSeries
        : TimeSeriesBase, IReturn<TimeSeries>
    {
        [ApiMember(IsRequired=true)]
        public Guid TimeSeriesUniqueId { get; set; }

        [ApiMember(IsRequired=true)]
        public string ComputationIdentifier { get; set; }

        [ApiMember(IsRequired=true)]
        public NewValueLocationType NewValueLocation { get; set; }

        public bool? RequireMinimumCoverage { get; set; }
        public double? CoverageMinimumPercentage { get; set; }
        public int? PartialCoverageGrade { get; set; }
        public int? ObservationOffsetInMinutes { get; set; }
    }

    [Route("/monitoringmethods/{MethodCode}", "PUT")]
    public class PutMonitoringMethod
        : MonitoringMethodWriteBase, IReturn<MonitoringMethod>
    {
    }

    [Route("/parameters/{UniqueId}", "PUT")]
    public class PutParameter
        : ParameterBase, IReturn<Parameter>
    {
        public Guid UniqueId { get; set; }
    }

    public class TimeSeriesBase
    {
        [ApiMember(IsRequired=true, Description="The unique ID of the location for which a basic time series is to be created")]
        public Guid LocationUniqueId { get; set; }

        [ApiMember(IsRequired=true)]
        public string Label { get; set; }

        [ApiMember(IsRequired=true)]
        public string Parameter { get; set; }

        [ApiMember(IsRequired=true)]
        public string Unit { get; set; }

        [ApiMember(IsRequired=true)]
        public InterpolationType InterpolationType { get; set; }

        public string SubLocationIdentifier { get; set; }
        public Offset UtcOffset { get; set; }
        public bool Publish { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
        public string Method { get; set; }
        public string ComputationIdentifier { get; set; }
        public string ComputationPeriodIdentifier { get; set; }
    }

    public class Location
    {
        public Guid UniqueId { get; set; }
        public string Identifier { get; set; }
        public string LocationName { get; set; }
        public string LocationPath { get; set; }
        public string LocationType { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        public Offset UtcOffset { get; set; }
        public Instant LastModified { get; set; }
        public string ElevationUnits { get; set; }
        public double? Elevation { get; set; }
        public string Description { get; set; }
    }

    public class MonitoringMethod
    {
        public string MethodCode { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string ParameterId { get; set; }
        public Guid ParameterUniqueId { get; set; }
        public string ParameterIdentifier { get; set; }
        public string RoundingSpec { get; set; }
        public bool System { get; set; }
    }

    public class Parameter
    {
        public Guid UniqueId { get; set; }
        public string ParameterId { get; set; }
        public string Identifier { get; set; }
        public string DisplayName { get; set; }
        public string UnitGroupIdentifier { get; set; }
        public string UnitIdentifier { get; set; }
        public double? MinValue { get; set; }
        public double? MaxValue { get; set; }
        public string InterpolationType { get; set; }
        public string RoundingSpec { get; set; }
        public bool System { get; set; }
    }

    public class TimeSeries
    {
        public string Identifier { get; set; }
        public Guid UniqueId { get; set; }
        public string Label { get; set; }
        public string Comment { get; set; }
        public string Description { get; set; }
        public bool Publish { get; set; }
        public string LocationName { get; set; }
        public string LocationIdentifier { get; set; }
        public Guid LocationUniqueId { get; set; }
        public string SubLocationIdentifier { get; set; }
        public TimeSeriesType TimeSeriesType { get; set; }
        public string Parameter { get; set; }
        public string Unit { get; set; }
        public Offset UtcOffset { get; set; }
        public string ComputationIdentifier { get; set; }
        public string ComputationPeriodIdentifier { get; set; }
        public Instant LastModifiedTime { get; set; }
    }
}

