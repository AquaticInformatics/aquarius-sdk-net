/* Options:
Date: 2016-11-21 17:27:04
Version: 4.50
Tip: To override a DTO option, remove "//" prefix before updating
BaseUrl: http://doug-vm2012r2/AQUARIUS/Provisioning/v1

GlobalNamespace: Aquarius.Client.ServiceModels.Provisioning
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
using Aquarius.Client.ServiceModels.Provisioning;


namespace Aquarius.Client.ServiceModels.Provisioning
{

    public class ExtendedAttributeFieldValue
    {
        public string ColumnIdentifier { get; set; }
        public string Value { get; set; }
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

    public enum TimeSeriesType
    {
        Unknown,
        ProcessorBasic,
        ProcessorDerived,
        External,
        Reflected,
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

    public enum NewValueLocationType
    {
        Unknown,
        Start,
        End,
    }

    [Route("/interpolationtypes", "GET")]
    public class GetInterpolationTypes
        : IReturn<InterpolationTypesResponse>
    {
    }

    [Route("/locationfolders/{LocationFolderUniqueId}", "DELETE")]
    public class DeleteLocationFolder
        : IReturnVoid
    {
        ///<summary>
        ///Unique ID of the location folder
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the location folder", ParameterType="path", IsRequired=true)]
        public Guid LocationFolderUniqueId { get; set; }
    }

    [Route("/locationtypes/{UniqueId}", "DELETE")]
    public class DeleteLocationType
        : IReturnVoid
    {
        ///<summary>
        ///Unique ID of the location type
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the location type", ParameterType="path", IsRequired=true)]
        public Guid UniqueId { get; set; }
    }

    [Route("/location/{LocationUniqueId}", "GET")]
    [Route("/locations/{LocationUniqueId}", "GET")]
    public class GetLocation
        : IReturn<Location>
    {
        ///<summary>
        ///Unique ID of the location
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the location", ParameterType="path", IsRequired=true)]
        public Guid LocationUniqueId { get; set; }
    }

    [Route("/locationfolders/{LocationFolderUniqueId}", "GET")]
    public class GetLocationFolder
        : IReturn<LocationFolder>
    {
        ///<summary>
        ///Unique ID of the location folder
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the location folder", ParameterType="path", IsRequired=true)]
        public Guid LocationFolderUniqueId { get; set; }
    }

    [Route("/locationfolders", "GET")]
    public class GetLocationFolders
        : IReturn<LocationFoldersResponse>
    {
    }

    [Route("/locations", "GET")]
    public class GetLocations
        : IReturn<LocationsResponse>
    {
    }

    [Route("/locationtypes/{UniqueId}", "GET")]
    public class GetLocationType
        : IReturn<LocationType>
    {
        ///<summary>
        ///Unique ID of the location type
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the location type", ParameterType="path", IsRequired=true)]
        public Guid UniqueId { get; set; }
    }

    [Route("/locationtypes", "GET")]
    public class GetLocationTypes
        : IReturn<LocationTypesResponse>
    {
    }

    public class LocationBase
    {
        ///<summary>
        ///Location identifier
        ///</summary>
        [ApiMember(Description="Location identifier", IsRequired=true)]
        public string LocationIdentifier { get; set; }

        ///<summary>
        ///Location name
        ///</summary>
        [ApiMember(Description="Location name", IsRequired=true)]
        public string LocationName { get; set; }

        ///<summary>
        ///Location path
        ///</summary>
        [ApiMember(Description="Location path", IsRequired=true)]
        public string LocationPath { get; set; }

        ///<summary>
        ///Location type
        ///</summary>
        [ApiMember(Description="Location type", IsRequired=true)]
        public string LocationType { get; set; }

        ///<summary>
        ///Description
        ///</summary>
        [ApiMember(Description="Description")]
        public string Description { get; set; }

        ///<summary>
        ///Longitude
        ///</summary>
        [ApiMember(DataType="double", Description="Longitude")]
        public double? Longitude { get; set; }

        ///<summary>
        ///Latitude
        ///</summary>
        [ApiMember(DataType="double", Description="Latitude")]
        public double? Latitude { get; set; }

        ///<summary>
        ///Elevation units
        ///</summary>
        [ApiMember(Description="Elevation units")]
        public string ElevationUnits { get; set; }

        ///<summary>
        ///Elevation
        ///</summary>
        [ApiMember(DataType="double", Description="Elevation")]
        public double? Elevation { get; set; }

        ///<summary>
        ///Extended attribute values
        ///</summary>
        [ApiMember(DataType="Array<ExtendedAttributeFieldValue>", Description="Extended attribute values")]
        public IList<ExtendedAttributeFieldValue> ExtendedAttributeValues { get; set; }
    }

    public class LocationFolderWriteBase
    {
        ///<summary>
        ///Location folder name
        ///</summary>
        [ApiMember(Description="Location folder name", IsRequired=true)]
        public string LocationFolderName { get; set; }

        ///<summary>
        ///Location folder description
        ///</summary>
        [ApiMember(Description="Location folder description")]
        public string LocationFolderDescription { get; set; }
    }

    public class LocationTypeBase
    {
        ///<summary>
        ///Type name
        ///</summary>
        [ApiMember(Description="Type name", IsRequired=true)]
        public string TypeName { get; set; }

        ///<summary>
        ///Description
        ///</summary>
        [ApiMember(Description="Description")]
        public string Description { get; set; }

        ///<summary>
        ///Name of database table used for extended attributes, omit if none
        ///</summary>
        [ApiMember(Description="Name of database table used for extended attributes, omit if none")]
        public string AttributeTableName { get; set; }
    }

    [Route("/locations", "POST")]
    [Route("/location", "POST")]
    public class PostLocation
        : LocationBase, IReturn<Location>
    {
        ///<summary>
        ///ISO 8601 Duration Format
        ///</summary>
        [ApiMember(DataType="Offset", Description="ISO 8601 Duration Format")]
        public Offset UtcOffset { get; set; }
    }

    [Route("/locationfolders", "POST")]
    public class PostLocationFolder
        : LocationFolderWriteBase, IReturn<LocationFolder>
    {
        ///<summary>
        ///Parent location folder path
        ///</summary>
        [ApiMember(Description="Parent location folder path", IsRequired=true)]
        public string ParentLocationFolderPath { get; set; }
    }

    [Route("/locationtypes", "POST")]
    public class PostLocationType
        : LocationTypeBase, IReturn<LocationType>
    {
    }

    [Route("/locations/{LocationUniqueId}", "PUT")]
    public class PutLocation
        : LocationBase, IReturn<Location>
    {
        ///<summary>
        ///Unique ID of the location
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the location", ParameterType="path", IsRequired=true)]
        public Guid LocationUniqueId { get; set; }
    }

    [Route("/locationfolders/{LocationFolderUniqueId}", "PUT")]
    public class PutLocationFolder
        : LocationFolderWriteBase, IReturn<LocationFolder>
    {
        ///<summary>
        ///Unique ID of the location folder
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the location folder", ParameterType="path", IsRequired=true)]
        public Guid LocationFolderUniqueId { get; set; }
    }

    [Route("/locationtypes/{UniqueId}", "PUT")]
    public class PutLocationType
        : LocationTypeBase, IReturn<LocationType>
    {
        ///<summary>
        ///Unique ID of the location type
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the location type", ParameterType="path", IsRequired=true)]
        public Guid UniqueId { get; set; }
    }

    [Route("/monitoringmethods/{MethodCode}", "DELETE")]
    public class DeleteMonitoringMethod
        : IReturnVoid
    {
        ///<summary>
        ///Method code
        ///</summary>
        [ApiMember(Description="Method code", ParameterType="path", IsRequired=true)]
        public string MethodCode { get; set; }
    }

    [Route("/monitoringmethods/{MethodCode}", "GET")]
    public class GetMonitoringMethod
        : IReturn<MonitoringMethod>
    {
        ///<summary>
        ///Method code
        ///</summary>
        [ApiMember(Description="Method code", ParameterType="path", IsRequired=true)]
        public string MethodCode { get; set; }
    }

    [Route("/monitoringmethods", "GET")]
    public class GetMonitoringMethods
        : IReturn<MonitoringMethodsResponse>
    {
    }

    public class MonitoringMethodWriteBase
    {
        ///<summary>
        ///Method code
        ///</summary>
        [ApiMember(Description="Method code", IsRequired=true)]
        public string MethodCode { get; set; }

        ///<summary>
        ///Display name
        ///</summary>
        [ApiMember(Description="Display name", IsRequired=true)]
        public string DisplayName { get; set; }

        ///<summary>
        ///Description
        ///</summary>
        [ApiMember(Description="Description")]
        public string Description { get; set; }

        ///<summary>
        ///Unique ID of the method's parameter
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the method's parameter", IsRequired=true)]
        public Guid ParameterUniqueId { get; set; }

        ///<summary>
        ///Rounding spec
        ///</summary>
        [ApiMember(Description="Rounding spec")]
        public string RoundingSpec { get; set; }
    }

    [Route("/monitoringmethods", "POST")]
    public class PostMonitoringMethod
        : MonitoringMethodWriteBase, IReturn<MonitoringMethod>
    {
    }

    [Route("/monitoringmethods/{MethodCode}", "PUT")]
    public class PutMonitoringMethod
        : MonitoringMethodWriteBase, IReturn<MonitoringMethod>
    {
    }

    [Route("/openidconnect/relyingpartyconfiguration", "DELETE")]
    public class DeleteOpenIdConnectRelyingPartyConfiguration
        : IReturnVoid
    {
    }

    [Route("/openidconnect/relyingpartyconfiguration", "GET")]
    public class GetOpenIdConnectRelyingPartyConfiguration
        : IReturn<OpenIdConnectRelyingPartyConfiguration>
    {
    }

    public class OpenIdConnectRelyingPartyConfigurationBase
    {
        ///<summary>
        ///The Relying Party client identifier
        ///</summary>
        [ApiMember(Description="The Relying Party client identifier", IsRequired=true)]
        public string ClientIdentifier { get; set; }

        ///<summary>
        ///The Relying Party client secret
        ///</summary>
        [ApiMember(Description="The Relying Party client secret", IsRequired=true)]
        public string ClientSecret { get; set; }

        ///<summary>
        ///The redirection URI for the authorization response; e.g. http://my-domain/AQUARIUS/apps/v1/auth/openidconnect
        ///</summary>
        [ApiMember(Description="The redirection URI for the authorization response; e.g. http://my-domain/AQUARIUS/apps/v1/auth/openidconnect", IsRequired=true)]
        public string RedirectUri { get; set; }

        ///<summary>
        ///If not specified, defaults to openid
        ///</summary>
        [ApiMember(DataType="IList", Description="If not specified, defaults to openid")]
        public IList<string> Scopes { get; set; }

        ///<summary>
        ///Hosted domains
        ///</summary>
        [ApiMember(DataType="Array<string>", Description="Hosted domains")]
        public IList<string> HostedDomains { get; set; }
    }

    [Route("/openidconnect/relyingpartyconfiguration", "POST")]
    public class PostOpenIdConnectRelyingPartyConfiguration
        : OpenIdConnectRelyingPartyConfigurationBase, IReturn<OpenIdConnectRelyingPartyConfiguration>
    {
        ///<summary>
        ///An https URI specifying the fully qualified host name of the issuer
        ///</summary>
        [ApiMember(Description="An https URI specifying the fully qualified host name of the issuer", IsRequired=true)]
        public string IssuerIdentifier { get; set; }
    }

    [Route("/openidconnect/relyingpartyconfiguration", "PUT")]
    public class PutOpenIdConnectRelyingPartyConfiguration
        : OpenIdConnectRelyingPartyConfigurationBase, IReturn<OpenIdConnectRelyingPartyConfiguration>
    {
    }

    [Route("/parameters/{UniqueId}", "DELETE")]
    public class DeleteParameter
        : IReturnVoid
    {
        ///<summary>
        ///Unique ID of the parameter
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the parameter", ParameterType="path", IsRequired=true)]
        public Guid UniqueId { get; set; }
    }

    [Route("/parameters/{UniqueId}", "GET")]
    public class GetParameter
        : IReturn<Parameter>
    {
        ///<summary>
        ///Unique ID of the parameter
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the parameter", ParameterType="path", IsRequired=true)]
        public Guid UniqueId { get; set; }
    }

    [Route("/parameters", "GET")]
    public class GetParameters
        : IReturn<ParametersResponse>
    {
    }

    public class ParameterBase
    {
        ///<summary>
        ///Parameter id
        ///</summary>
        [ApiMember(Description="Parameter id", IsRequired=true)]
        public string ParameterId { get; set; }

        ///<summary>
        ///The display ID of the parameter
        ///</summary>
        [ApiMember(Description="The display ID of the parameter", IsRequired=true)]
        public string Identifier { get; set; }

        ///<summary>
        ///Display name
        ///</summary>
        [ApiMember(Description="Display name", IsRequired=true)]
        public string DisplayName { get; set; }

        ///<summary>
        ///Unit group identifier
        ///</summary>
        [ApiMember(Description="Unit group identifier", IsRequired=true)]
        public string UnitGroupIdentifier { get; set; }

        ///<summary>
        ///Unit identifier
        ///</summary>
        [ApiMember(Description="Unit identifier", IsRequired=true)]
        public string UnitIdentifier { get; set; }

        ///<summary>
        ///Min value
        ///</summary>
        [ApiMember(DataType="double", Description="Min value")]
        public double? MinValue { get; set; }

        ///<summary>
        ///Max value
        ///</summary>
        [ApiMember(DataType="double", Description="Max value")]
        public double? MaxValue { get; set; }

        ///<summary>
        ///Interpolation type
        ///</summary>
        [ApiMember(DataType="integer", Description="Interpolation type", IsRequired=true)]
        public int? InterpolationType { get; set; }

        ///<summary>
        ///Rounding spec
        ///</summary>
        [ApiMember(Description="Rounding spec")]
        public string RoundingSpec { get; set; }
    }

    [Route("/parameters", "POST")]
    public class PostParameter
        : ParameterBase, IReturn<Parameter>
    {
    }

    [Route("/parameters/{UniqueId}", "PUT")]
    public class PutParameter
        : ParameterBase, IReturn<Parameter>
    {
        ///<summary>
        ///Unique ID of the parameter
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the parameter", ParameterType="path", IsRequired=true)]
        public Guid UniqueId { get; set; }
    }

    [Route("/grades/{GradeCode}", "DELETE")]
    public class DeleteQualityCode
        : IReturnVoid
    {
        ///<summary>
        ///Grade code
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code", ParameterType="path", IsRequired=true)]
        public int GradeCode { get; set; }
    }

    [Route("/grades/{GradeCode}", "GET")]
    public class GetQualityCode
        : IReturn<Grade>
    {
        ///<summary>
        ///Grade code
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code", ParameterType="path", IsRequired=true)]
        public int GradeCode { get; set; }
    }

    [Route("/grades", "GET")]
    public class GetQualityCodes
        : IReturn<GradesResponse>
    {
    }

    [Route("/grades", "POST")]
    public class PostQualityCode
        : QualityCodeBase, IReturn<Grade>
    {
    }

    [Route("/grades/{GradeCode}", "PUT")]
    public class PutQualityCode
        : QualityCodeBase, IReturn<Grade>
    {
        ///<summary>
        ///Grade code
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code", ParameterType="path", IsRequired=true)]
        public int? GradeCode { get; set; }
    }

    public class QualityCodeBase
    {
        ///<summary>
        ///Grade code
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code", IsRequired=true)]
        public int? GradeCode { get; set; }

        ///<summary>
        ///\#RRGGBB value in hexadecimal
        ///</summary>
        [ApiMember(Description="\#RRGGBB value in hexadecimal", IsRequired=true)]
        public string Color { get; set; }

        ///<summary>
        ///Localized short display name
        ///</summary>
        [ApiMember(Description="Localized short display name", IsRequired=true)]
        public string DisplayName { get; set; }

        ///<summary>
        ///Localized description
        ///</summary>
        [ApiMember(Description="Localized description")]
        public string Description { get; set; }
    }

    [Route("/standarddatums/{Identifier}", "DELETE")]
    public class DeleteStandardDatum
        : IReturnVoid
    {
        ///<summary>
        ///Identifier of the standard daturm
        ///</summary>
        [ApiMember(Description="Identifier of the standard daturm", ParameterType="path", IsRequired=true)]
        public string Identifier { get; set; }
    }

    [Route("/standarddatums", "GET")]
    public class GetStandardDatums
        : IReturn<StandardDatumsResponse>
    {
    }

    [Route("/standarddatums", "POST")]
    public class PostStandardDatum
        : StandardDatumBase, IReturn<StandardDatum>
    {
    }

    public class StandardDatumBase
    {
        ///<summary>
        ///Identifier of the standard datum
        ///</summary>
        [ApiMember(Description="Identifier of the standard datum", IsRequired=true)]
        public string Identifier { get; set; }
    }

    [Route("/timeseries/{TimeSeriesUniqueId}", "DELETE")]
    public class DeleteTimeSeries
        : IReturnVoid
    {
        ///<summary>
        ///Unique ID of the time series
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the time series", ParameterType="path", IsRequired=true)]
        public Guid TimeSeriesUniqueId { get; set; }
    }

    [Route("/locations/{LocationUniqueId}/timeseries", "GET")]
    [Route("/location/{LocationUniqueId}/timeseries", "GET")]
    public class GetLocationTimeSeries
        : IReturn<TimeSeriesResponse>
    {
        ///<summary>
        ///Unique ID of the location
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the location", ParameterType="path", IsRequired=true)]
        public Guid LocationUniqueId { get; set; }
    }

    [Route("/timeseries/{TimeSeriesUniqueId}", "GET")]
    public class GetTimeSeries
        : IReturn<TimeSeries>
    {
        ///<summary>
        ///Unique ID of the time series
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the time series", ParameterType="path", IsRequired=true)]
        public Guid TimeSeriesUniqueId { get; set; }
    }

    [Route("/locations/{LocationUniqueId}/timeseries/basic", "POST")]
    [Route("/location/{LocationUniqueId}/timeseries/basic", "POST")]
    public class PostBasicTimeSeries
        : TimeSeriesBase, IReturn<TimeSeries>
    {
        ///<summary>
        ///ISO 8601 Duration Format
        ///</summary>
        [ApiMember(DataType="Duration", Description="ISO 8601 Duration Format", IsRequired=true)]
        public Duration GapTolerance { get; set; }
    }

    [Route("/locations/{LocationUniqueId}/timeseries/calculated", "POST")]
    [Route("/location/{LocationUniqueId}/timeseries/calculated", "POST")]
    public class PostCalculatedDerivedTimeSeries
        : TimeSeriesBase, IReturn<TimeSeries>
    {
        public PostCalculatedDerivedTimeSeries()
        {
            TimeSeriesUniqueIds = new List<Guid>{};
        }

        ///<summary>
        ///List of time series unique IDs of which the order translates to x1, x2… xN with x1 being the Master
        ///</summary>
        [ApiMember(DataType="Array<string>", Description="List of time series unique IDs of which the order translates to x1, x2… xN with x1 being the Master", IsRequired=true)]
        public List<Guid> TimeSeriesUniqueIds { get; set; }

        ///<summary>
        ///Formula
        ///</summary>
        [ApiMember(Description="Formula", IsRequired=true)]
        public string Formula { get; set; }
    }

    [Route("/locations/{LocationUniqueId}/timeseries/reflected", "POST")]
    [Route("/location/{LocationUniqueId}/timeseries/reflected", "POST")]
    public class PostReflectedTimeSeries
        : TimeSeriesBase, IReturn<TimeSeries>
    {
        ///<summary>
        ///ISO 8601 Duration Format
        ///</summary>
        [ApiMember(DataType="Duration", Description="ISO 8601 Duration Format", IsRequired=true)]
        public Duration GapTolerance { get; set; }
    }

    [Route("/locations/{LocationUniqueId}/timeseries/statistical", "POST")]
    [Route("/location/{LocationUniqueId}/timeseries/statistical", "POST")]
    public class PostStatisticalDerivedTimeSeries
        : TimeSeriesBase, IReturn<TimeSeries>
    {
        ///<summary>
        ///Unique ID of the time series
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the time series", IsRequired=true)]
        public Guid TimeSeriesUniqueId { get; set; }

        [ApiMember(IsRequired=true)]
        public string ComputationIdentifier { get; set; }

        ///<summary>
        ///New value location
        ///</summary>
        [ApiMember(DataType="NewValueLocationType", Description="New value location", IsRequired=true)]
        public NewValueLocationType NewValueLocation { get; set; }

        ///<summary>
        ///Require minimum coverage
        ///</summary>
        [ApiMember(DataType="boolean", Description="Require minimum coverage")]
        public bool? RequireMinimumCoverage { get; set; }

        ///<summary>
        ///Coverage minimum percentage
        ///</summary>
        [ApiMember(DataType="double", Description="Coverage minimum percentage")]
        public double? CoverageMinimumPercentage { get; set; }

        ///<summary>
        ///Partial coverage grade
        ///</summary>
        [ApiMember(DataType="integer", Description="Partial coverage grade")]
        public int? PartialCoverageGrade { get; set; }

        ///<summary>
        ///Observation offset in minutes
        ///</summary>
        [ApiMember(DataType="integer", Description="Observation offset in minutes")]
        public int? ObservationOffsetInMinutes { get; set; }
    }

    public class TimeSeriesBase
    {
        ///<summary>
        ///Unique ID of the location for which a time series is to be created
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the location for which a time series is to be created", IsRequired=true)]
        public Guid LocationUniqueId { get; set; }

        ///<summary>
        ///Label
        ///</summary>
        [ApiMember(Description="Label", IsRequired=true)]
        public string Label { get; set; }

        ///<summary>
        ///The ID of the parameter
        ///</summary>
        [ApiMember(Description="The ID of the parameter", IsRequired=true)]
        public string Parameter { get; set; }

        ///<summary>
        ///The ID of the unit
        ///</summary>
        [ApiMember(Description="The ID of the unit", IsRequired=true)]
        public string Unit { get; set; }

        ///<summary>
        ///Interpolation type
        ///</summary>
        [ApiMember(DataType="InterpolationType", Description="Interpolation type", IsRequired=true)]
        public InterpolationType InterpolationType { get; set; }

        ///<summary>
        ///Sub location identifier
        ///</summary>
        [ApiMember(Description="Sub location identifier")]
        public string SubLocationIdentifier { get; set; }

        ///<summary>
        ///ISO 8601 Duration Format
        ///</summary>
        [ApiMember(DataType="Offset", Description="ISO 8601 Duration Format")]
        public Offset UtcOffset { get; set; }

        ///<summary>
        ///Publish
        ///</summary>
        [ApiMember(DataType="boolean", Description="Publish")]
        public bool Publish { get; set; }

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
        ///Method
        ///</summary>
        [ApiMember(Description="Method", IsRequired=true)]
        public string Method { get; set; }

        [ApiMember]
        public string ComputationIdentifier { get; set; }

        ///<summary>
        ///Computation period identifier
        ///</summary>
        [ApiMember(Description="Computation period identifier")]
        public string ComputationPeriodIdentifier { get; set; }

        ///<summary>
        ///Extended attribute values
        ///</summary>
        [ApiMember(DataType="Array<ExtendedAttributeFieldValue>", Description="Extended attribute values")]
        public IList<ExtendedAttributeFieldValue> ExtendedAttributeValues { get; set; }
    }

    [Route("/units/{UniqueId}", "DELETE")]
    public class DeleteUnit
        : IReturnVoid
    {
        ///<summary>
        ///Unique ID of the unit
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the unit", ParameterType="path", IsRequired=true)]
        public Guid UniqueId { get; set; }
    }

    [Route("/unitgroups/{UniqueId}", "DELETE")]
    public class DeleteUnitGroup
        : IReturnVoid
    {
        ///<summary>
        ///Unique ID of the unit group
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the unit group", ParameterType="path", IsRequired=true)]
        public Guid UniqueId { get; set; }
    }

    [Route("/unitgroups/{UniqueId}/units", "DELETE")]
    public class DeleteUnits
        : IReturnVoid
    {
        ///<summary>
        ///Unique ID of the unit group
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the unit group", ParameterType="path", IsRequired=true)]
        public Guid UniqueId { get; set; }
    }

    [Route("/units/{UniqueId}", "GET")]
    public class GetUnit
        : IReturn<Unit>
    {
        ///<summary>
        ///Unique ID of the unit
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the unit", ParameterType="path", IsRequired=true)]
        public Guid UniqueId { get; set; }
    }

    [Route("/unitgroups/{UniqueId}", "GET")]
    public class GetUnitGroup
        : IReturn<UnitGroup>
    {
        ///<summary>
        ///Unique ID of the unit group
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the unit group", ParameterType="path", IsRequired=true)]
        public Guid UniqueId { get; set; }
    }

    [Route("/unitgroups", "GET")]
    public class GetUnitGroups
        : IReturn<UnitGroupsResponse>
    {
    }

    [Route("/units", "GET")]
    public class GetUnits
        : IReturn<PopulatedUnitGroupsResponse>
    {
    }

    [Route("/unitgroups/{UniqueId}/units", "GET")]
    public class GetUnitsInGroup
        : IReturn<UnitsResponse>
    {
        ///<summary>
        ///Unique ID of the unit group
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the unit group", ParameterType="path", IsRequired=true)]
        public Guid UniqueId { get; set; }
    }

    [Route("/units", "POST")]
    public class PostUnit
        : UnitBase, IReturn<Unit>
    {
        ///<summary>
        ///Group identifier
        ///</summary>
        [ApiMember(Description="Group identifier", IsRequired=true)]
        public string GroupIdentifier { get; set; }

        ///<summary>
        ///Unit identifier
        ///</summary>
        [ApiMember(Description="Unit identifier", IsRequired=true)]
        public string UnitIdentifier { get; set; }
    }

    [Route("/unitgroups", "POST")]
    public class PostUnitGroup
        : UnitGroupBase, IReturn<UnitGroup>
    {
        ///<summary>
        ///Group identifier, typically English name
        ///</summary>
        [ApiMember(Description="Group identifier, typically English name", IsRequired=true)]
        public string GroupIdentifier { get; set; }

        ///<summary>
        ///Localized name
        ///</summary>
        [ApiMember(Description="Localized name", IsRequired=true)]
        public string DisplayName { get; set; }

        ///<summary>
        ///Base unit identifier
        ///</summary>
        [ApiMember(Description="Base unit identifier", IsRequired=true)]
        public string BaseUnitIdentifier { get; set; }

        ///<summary>
        ///Localized short name or symbol
        ///</summary>
        [ApiMember(Description="Localized short name or symbol", IsRequired=true)]
        public string BaseUnitSymbol { get; set; }

        ///<summary>
        ///Localized singular name
        ///</summary>
        [ApiMember(Description="Localized singular name", IsRequired=true)]
        public string BaseUnitSingularName { get; set; }

        ///<summary>
        ///Localized plural name
        ///</summary>
        [ApiMember(Description="Localized plural name", IsRequired=true)]
        public string BaseUnitPluralName { get; set; }
    }

    [Route("/units/{UniqueId}", "PUT")]
    public class PutUnit
        : UnitBase, IReturn<Unit>
    {
        ///<summary>
        ///Unique ID of the unit
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the unit", ParameterType="path", IsRequired=true)]
        public Guid UniqueId { get; set; }
    }

    [Route("/unitgroups/{UniqueId}", "PUT")]
    public class PutUnitGroup
        : UnitGroupBase, IReturn<UnitGroup>
    {
        ///<summary>
        ///Unique ID of the unit group
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the unit group", ParameterType="path", IsRequired=true)]
        public Guid UniqueId { get; set; }

        ///<summary>
        ///Localized name
        ///</summary>
        [ApiMember(Description="Localized name")]
        public string DisplayName { get; set; }
    }

    public class UnitBase
    {
        ///<summary>
        ///Base multiplier
        ///</summary>
        [ApiMember(DataType="double", Description="Base multiplier", IsRequired=true)]
        public double? BaseMultiplier { get; set; }

        ///<summary>
        ///Base offset
        ///</summary>
        [ApiMember(DataType="double", Description="Base offset", IsRequired=true)]
        public double? BaseOffset { get; set; }

        ///<summary>
        ///Localized short name or symbol
        ///</summary>
        [ApiMember(Description="Localized short name or symbol", IsRequired=true)]
        public string Symbol { get; set; }

        ///<summary>
        ///Localized singular name
        ///</summary>
        [ApiMember(Description="Localized singular name", IsRequired=true)]
        public string SingularName { get; set; }

        ///<summary>
        ///Localized plural name
        ///</summary>
        [ApiMember(Description="Localized plural name", IsRequired=true)]
        public string PluralName { get; set; }
    }

    public class UnitGroupBase
    {
        ///<summary>
        ///Current dimension
        ///</summary>
        [ApiMember(DataType="integer", Description="Current dimension")]
        public int? CurrentDimension { get; set; }

        ///<summary>
        ///Intensity dimension
        ///</summary>
        [ApiMember(DataType="integer", Description="Intensity dimension")]
        public int? IntensityDimension { get; set; }

        ///<summary>
        ///Length dimension
        ///</summary>
        [ApiMember(DataType="integer", Description="Length dimension")]
        public int? LengthDimension { get; set; }

        ///<summary>
        ///Mass dimension
        ///</summary>
        [ApiMember(DataType="integer", Description="Mass dimension")]
        public int? MassDimension { get; set; }

        ///<summary>
        ///Substance dimension
        ///</summary>
        [ApiMember(DataType="integer", Description="Substance dimension")]
        public int? SubstanceDimension { get; set; }

        ///<summary>
        ///Temperature dimension
        ///</summary>
        [ApiMember(DataType="integer", Description="Temperature dimension")]
        public int? TemperatureDimension { get; set; }

        ///<summary>
        ///Time dimension
        ///</summary>
        [ApiMember(DataType="integer", Description="Time dimension")]
        public int? TimeDimension { get; set; }
    }

    [Route("/users/{UniqueId}", "DELETE")]
    public class DeleteUser
        : IReturnVoid
    {
        ///<summary>
        ///Unique ID of the user
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the user", ParameterType="path", IsRequired=true)]
        public Guid UniqueId { get; set; }
    }

    [Route("/users/{UniqueId}", "GET")]
    public class GetUser
        : IReturn<User>
    {
        ///<summary>
        ///Unique ID of the user
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the user", ParameterType="path", IsRequired=true)]
        public Guid UniqueId { get; set; }
    }

    [Route("/users", "GET")]
    public class GetUsers
        : IReturn<UsersResponse>
    {
    }

    [Route("/users/activedirectory", "POST")]
    public class PostActiveDirectoryUser
        : UserBase, IReturn<User>
    {
        ///<summary>
        ///The user's domain credentials specified in User Principal Name format
        ///</summary>
        [ApiMember(Description="The user's domain credentials specified in User Principal Name format", IsRequired=true)]
        public string UserPrincipalName { get; set; }
    }

    [Route("/users/credentials", "POST")]
    public class PostCredentialsUser
        : UserBase, IReturn<User>
    {
        ///<summary>
        ///Password
        ///</summary>
        [ApiMember(Description="Password", IsRequired=true)]
        public string Password { get; set; }
    }

    [Route("/users/openidconnect", "POST")]
    public class PostOpenIdConnectUser
        : UserBase, IReturn<User>
    {
        ///<summary>
        ///Unique identifier within the issuer for the end-user
        ///</summary>
        [ApiMember(Description="Unique identifier within the issuer for the end-user", IsRequired=true)]
        public string SubjectIdentifier { get; set; }
    }

    [Route("/users/{UniqueId}/activedirectory", "PUT")]
    public class PutActiveDirectoryAuth
        : PutUserAuthBase, IReturn<User>
    {
        ///<summary>
        ///The user's domain credentials specified in User Principal Name format
        ///</summary>
        [ApiMember(Description="The user's domain credentials specified in User Principal Name format", IsRequired=true)]
        public string UserPrincipalName { get; set; }
    }

    [Route("/users/activedirectory/{UniqueId}", "PUT")]
    public class PutActiveDirectoryUser
        : PutUserBase, IReturn<User>
    {
        ///<summary>
        ///The user's domain credentials specified in User Principal Name format
        ///</summary>
        [ApiMember(Description="The user's domain credentials specified in User Principal Name format", IsRequired=true)]
        public string UserPrincipalName { get; set; }
    }

    [Route("/users/{UniqueId}/credentials", "PUT")]
    public class PutCredentialsAuth
        : PutUserAuthBase, IReturn<User>
    {
        ///<summary>
        ///Password
        ///</summary>
        [ApiMember(Description="Password", IsRequired=true)]
        public string Password { get; set; }
    }

    [Route("/users/credentials/{UniqueId}", "PUT")]
    public class PutCredentialsUser
        : PutUserBase, IReturn<User>
    {
        ///<summary>
        ///Password
        ///</summary>
        [ApiMember(Description="Password", IsRequired=true)]
        public string Password { get; set; }
    }

    [Route("/users/{UniqueId}/openidconnect", "PUT")]
    public class PutOpenIdConnectAuth
        : PutUserAuthBase, IReturn<User>
    {
        ///<summary>
        ///Unique identifier within the issuer for the end-user
        ///</summary>
        [ApiMember(Description="Unique identifier within the issuer for the end-user", IsRequired=true)]
        public string SubjectIdentifier { get; set; }
    }

    [Route("/users/openidconnect/{UniqueId}", "PUT")]
    public class PutOpenIdConnectUser
        : PutUserBase, IReturn<User>
    {
        ///<summary>
        ///Unique identifier within the issuer for the end-user
        ///</summary>
        [ApiMember(Description="Unique identifier within the issuer for the end-user", IsRequired=true)]
        public string SubjectIdentifier { get; set; }
    }

    public class PutUserAuthBase
    {
        ///<summary>
        ///Unique ID of the user
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the user", ParameterType="path", IsRequired=true)]
        public Guid UniqueId { get; set; }
    }

    public class PutUserBase
        : UserBase
    {
        ///<summary>
        ///Unique ID of the user
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the user", ParameterType="path", IsRequired=true)]
        public Guid UniqueId { get; set; }
    }

    public class UserBase
    {
        ///<summary>
        ///Login name
        ///</summary>
        [ApiMember(Description="Login name", IsRequired=true)]
        public string LoginName { get; set; }

        ///<summary>
        ///Inactive users cannot log in and are not counted in licensing
        ///</summary>
        [ApiMember(DataType="boolean", Description="Inactive users cannot log in and are not counted in licensing", IsRequired=true)]
        public bool Active { get; set; }

        ///<summary>
        ///Allow user to run AQUARIUS Manager and edit system settings
        ///</summary>
        [ApiMember(DataType="boolean", Description="Allow user to run AQUARIUS Manager and edit system settings", IsRequired=true)]
        public bool CanConfigureSystem { get; set; }

        ///<summary>
        ///Allow user to launch the Rating Development Toolbox
        ///</summary>
        [ApiMember(DataType="boolean", Description="Allow user to launch the Rating Development Toolbox", IsRequired=true)]
        public bool CanLaunchRatingDevelopmentToolbox { get; set; }

        ///<summary>
        ///First name
        ///</summary>
        [ApiMember(Description="First name")]
        public string FirstName { get; set; }

        ///<summary>
        ///Last name
        ///</summary>
        [ApiMember(Description="Last name")]
        public string LastName { get; set; }

        ///<summary>
        ///Email
        ///</summary>
        [ApiMember(Description="Email")]
        public string Email { get; set; }
    }

    public class Grade
    {
        ///<summary>
        ///Grade code
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code")]
        public int GradeCode { get; set; }

        ///<summary>
        ///Color
        ///</summary>
        [ApiMember(Description="Color")]
        public string Color { get; set; }

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
        ///True if the grade is required by the system
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if the grade is required by the system")]
        public bool IsSystem { get; set; }
    }

    public class GradesResponse
    {
        public GradesResponse()
        {
            Results = new List<Grade>{};
        }

        ///<summary>
        ///The list of grades
        ///</summary>
        [ApiMember(DataType="Array<Grade>", Description="The list of grades")]
        public List<Grade> Results { get; set; }
    }

    public class InterpolationTypeEntry
    {
        ///<summary>
        ///Interpolation type
        ///</summary>
        [ApiMember(Description="Interpolation type")]
        public string InterpolationType { get; set; }

        ///<summary>
        ///Display name
        ///</summary>
        [ApiMember(Description="Display name")]
        public string DisplayName { get; set; }

        ///<summary>
        ///Value
        ///</summary>
        [ApiMember(DataType="integer", Description="Value")]
        public int Value { get; set; }
    }

    public class InterpolationTypesResponse
    {
        public InterpolationTypesResponse()
        {
            Results = new List<InterpolationTypeEntry>{};
        }

        ///<summary>
        ///The list of interpolation types
        ///</summary>
        [ApiMember(DataType="Array<InterpolationTypeEntry>", Description="The list of interpolation types")]
        public List<InterpolationTypeEntry> Results { get; set; }
    }

    public class Location
    {
        ///<summary>
        ///Unique ID of the location
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the location")]
        public Guid UniqueId { get; set; }

        ///<summary>
        ///Identifier
        ///</summary>
        [ApiMember(Description="Identifier")]
        public string Identifier { get; set; }

        ///<summary>
        ///Location name
        ///</summary>
        [ApiMember(Description="Location name")]
        public string LocationName { get; set; }

        ///<summary>
        ///Location path
        ///</summary>
        [ApiMember(Description="Location path")]
        public string LocationPath { get; set; }

        ///<summary>
        ///Location type
        ///</summary>
        [ApiMember(Description="Location type")]
        public string LocationType { get; set; }

        ///<summary>
        ///Longitude
        ///</summary>
        [ApiMember(DataType="double", Description="Longitude")]
        public double? Longitude { get; set; }

        ///<summary>
        ///Latitude
        ///</summary>
        [ApiMember(DataType="double", Description="Latitude")]
        public double? Latitude { get; set; }

        ///<summary>
        ///UTC offset
        ///</summary>
        [ApiMember(DataType="Offset", Description="UTC offset")]
        public Offset UtcOffset { get; set; }

        ///<summary>
        ///Last modified
        ///</summary>
        [ApiMember(DataType="Instant", Description="Last modified")]
        public Instant LastModified { get; set; }

        ///<summary>
        ///Elevation units
        ///</summary>
        [ApiMember(Description="Elevation units")]
        public string ElevationUnits { get; set; }

        ///<summary>
        ///Elevation
        ///</summary>
        [ApiMember(DataType="double", Description="Elevation")]
        public double? Elevation { get; set; }

        ///<summary>
        ///Description
        ///</summary>
        [ApiMember(Description="Description")]
        public string Description { get; set; }

        ///<summary>
        ///Extended attribute values
        ///</summary>
        [ApiMember(DataType="Array<ExtendedAttributeFieldValue>", Description="Extended attribute values")]
        public IList<ExtendedAttributeFieldValue> ExtendedAttributeValues { get; set; }
    }

    public class LocationFolder
    {
        ///<summary>
        ///Unique ID of the location folder
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the location folder")]
        public Guid UniqueId { get; set; }

        ///<summary>
        ///Location folder name
        ///</summary>
        [ApiMember(Description="Location folder name")]
        public string LocationFolderName { get; set; }

        ///<summary>
        ///Location folder description
        ///</summary>
        [ApiMember(Description="Location folder description")]
        public string LocationFolderDescription { get; set; }

        ///<summary>
        ///Location folder path
        ///</summary>
        [ApiMember(Description="Location folder path")]
        public string LocationFolderPath { get; set; }

        ///<summary>
        ///Unique ID of the parent location folder
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the parent location folder")]
        public Guid? ParentLocationFolderUniqueId { get; set; }

        ///<summary>
        ///Parent location folder path
        ///</summary>
        [ApiMember(Description="Parent location folder path")]
        public string ParentLocationFolderPath { get; set; }
    }

    public class LocationFoldersResponse
    {
        public LocationFoldersResponse()
        {
            Results = new List<LocationFolder>{};
        }

        ///<summary>
        ///The list of location folders
        ///</summary>
        [ApiMember(DataType="Array<LocationFolder>", Description="The list of location folders")]
        public List<LocationFolder> Results { get; set; }
    }

    public class LocationsResponse
    {
        public LocationsResponse()
        {
            Results = new List<Location>{};
        }

        ///<summary>
        ///The list of locations
        ///</summary>
        [ApiMember(DataType="Array<Location>", Description="The list of locations")]
        public List<Location> Results { get; set; }
    }

    public class LocationType
    {
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
        ///Attribute table name
        ///</summary>
        [ApiMember(Description="Attribute table name")]
        public string AttributeTableName { get; set; }

        ///<summary>
        ///Unique ID of the location type
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the location type")]
        public Guid UniqueId { get; set; }
    }

    public class LocationTypesResponse
    {
        public LocationTypesResponse()
        {
            Results = new List<LocationType>{};
        }

        ///<summary>
        ///The list of location types
        ///</summary>
        [ApiMember(DataType="Array<LocationType>", Description="The list of location types")]
        public List<LocationType> Results { get; set; }
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
        ///Parameter id
        ///</summary>
        [ApiMember(Description="Parameter id")]
        public string ParameterId { get; set; }

        ///<summary>
        ///Unique ID of the parameter
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the parameter")]
        public Guid ParameterUniqueId { get; set; }

        ///<summary>
        ///Parameter identifier
        ///</summary>
        [ApiMember(Description="Parameter identifier")]
        public string ParameterIdentifier { get; set; }

        ///<summary>
        ///Rounding spec
        ///</summary>
        [ApiMember(Description="Rounding spec")]
        public string RoundingSpec { get; set; }

        ///<summary>
        ///True if the monitoring method is required by system
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if the monitoring method is required by system")]
        public bool System { get; set; }
    }

    public class MonitoringMethodsResponse
    {
        public MonitoringMethodsResponse()
        {
            Results = new List<MonitoringMethod>{};
        }

        ///<summary>
        ///The list of monitoring methods
        ///</summary>
        [ApiMember(DataType="Array<MonitoringMethod>", Description="The list of monitoring methods")]
        public List<MonitoringMethod> Results { get; set; }
    }

    public class OpenIdConnectRelyingPartyConfiguration
    {
        public OpenIdConnectRelyingPartyConfiguration()
        {
            Scopes = new List<string>{};
            HostedDomains = new List<string>{};
        }

        ///<summary>
        ///Issuer identifier
        ///</summary>
        [ApiMember(Description="Issuer identifier")]
        public string IssuerIdentifier { get; set; }

        ///<summary>
        ///Client identifier
        ///</summary>
        [ApiMember(Description="Client identifier")]
        public string ClientIdentifier { get; set; }

        ///<summary>
        ///Redirect uri
        ///</summary>
        [ApiMember(Description="Redirect uri")]
        public string RedirectUri { get; set; }

        ///<summary>
        ///Scopes
        ///</summary>
        [ApiMember(DataType="Array<string>", Description="Scopes")]
        public List<string> Scopes { get; set; }

        ///<summary>
        ///Hosted domains
        ///</summary>
        [ApiMember(DataType="Array<string>", Description="Hosted domains")]
        public List<string> HostedDomains { get; set; }
    }

    public class Parameter
    {
        ///<summary>
        ///Unique ID of the parameter
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the parameter")]
        public Guid UniqueId { get; set; }

        ///<summary>
        ///Parameter id
        ///</summary>
        [ApiMember(Description="Parameter id")]
        public string ParameterId { get; set; }

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
        ///Min value
        ///</summary>
        [ApiMember(DataType="double", Description="Min value")]
        public double? MinValue { get; set; }

        ///<summary>
        ///Max value
        ///</summary>
        [ApiMember(DataType="double", Description="Max value")]
        public double? MaxValue { get; set; }

        ///<summary>
        ///Interpolation type
        ///</summary>
        [ApiMember(DataType="integer", Description="Interpolation type")]
        public int InterpolationType { get; set; }

        ///<summary>
        ///Rounding spec
        ///</summary>
        [ApiMember(Description="Rounding spec")]
        public string RoundingSpec { get; set; }

        ///<summary>
        ///True if the parameter is required by the system
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if the parameter is required by the system")]
        public bool System { get; set; }
    }

    public class ParametersResponse
    {
        public ParametersResponse()
        {
            Results = new List<Parameter>{};
        }

        ///<summary>
        ///The list of parameters
        ///</summary>
        [ApiMember(DataType="Array<Parameter>", Description="The list of parameters")]
        public List<Parameter> Results { get; set; }
    }

    public class PopulatedUnitGroup
        : UnitGroup
    {
        ///<summary>
        ///The list of units within the group
        ///</summary>
        [ApiMember(DataType="Array<Unit>", Description="The list of units within the group")]
        public IReadOnlyList<Unit> Units { get; set; }
    }

    public class PopulatedUnitGroupsResponse
    {
        public PopulatedUnitGroupsResponse()
        {
            Results = new List<PopulatedUnitGroup>{};
        }

        ///<summary>
        ///The list of unit groups
        ///</summary>
        [ApiMember(DataType="Array<PopulatedUnitGroup>", Description="The list of unit groups")]
        public List<PopulatedUnitGroup> Results { get; set; }
    }

    public class StandardDatum
    {
        ///<summary>
        ///Identifier
        ///</summary>
        [ApiMember(Description="Identifier")]
        public string Identifier { get; set; }
    }

    public class StandardDatumsResponse
    {
        public StandardDatumsResponse()
        {
            Results = new List<StandardDatum>{};
        }

        ///<summary>
        ///The list of standard datums
        ///</summary>
        [ApiMember(DataType="Array<StandardDatum>", Description="The list of standard datums")]
        public List<StandardDatum> Results { get; set; }
    }

    public class TimeSeries
    {
        ///<summary>
        ///Identifier
        ///</summary>
        [ApiMember(Description="Identifier")]
        public string Identifier { get; set; }

        ///<summary>
        ///Unique ID of the time series
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the time series")]
        public Guid UniqueId { get; set; }

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
        ///Unique ID of the location
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the location")]
        public Guid LocationUniqueId { get; set; }

        ///<summary>
        ///Sub location identifier
        ///</summary>
        [ApiMember(Description="Sub location identifier")]
        public string SubLocationIdentifier { get; set; }

        ///<summary>
        ///Time series type
        ///</summary>
        [ApiMember(DataType="TimeSeriesType", Description="Time series type")]
        public TimeSeriesType TimeSeriesType { get; set; }

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
        ///UTC offset
        ///</summary>
        [ApiMember(DataType="Offset", Description="UTC offset")]
        public Offset UtcOffset { get; set; }

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
        ///Last modified time
        ///</summary>
        [ApiMember(DataType="Instant", Description="Last modified time")]
        public Instant LastModifiedTime { get; set; }

        ///<summary>
        ///Extended attribute values
        ///</summary>
        [ApiMember(DataType="Array<ExtendedAttributeFieldValue>", Description="Extended attribute values")]
        public IList<ExtendedAttributeFieldValue> ExtendedAttributeValues { get; set; }
    }

    public class TimeSeriesResponse
    {
        public TimeSeriesResponse()
        {
            Results = new List<TimeSeries>{};
        }

        ///<summary>
        ///The lsit of time series
        ///</summary>
        [ApiMember(DataType="Array<TimeSeries>", Description="The lsit of time series")]
        public List<TimeSeries> Results { get; set; }
    }

    public class Unit
    {
        ///<summary>
        ///Unit identifier
        ///</summary>
        [ApiMember(Description="Unit identifier")]
        public string UnitIdentifier { get; set; }

        ///<summary>
        ///Group identifier
        ///</summary>
        [ApiMember(Description="Group identifier")]
        public string GroupIdentifier { get; set; }

        ///<summary>
        ///Base multiplier
        ///</summary>
        [ApiMember(DataType="double", Description="Base multiplier")]
        public double BaseMultiplier { get; set; }

        ///<summary>
        ///Base offset
        ///</summary>
        [ApiMember(DataType="double", Description="Base offset")]
        public double BaseOffset { get; set; }

        ///<summary>
        ///True if the unit is required by the system
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if the unit is required by the system")]
        public bool IsSystem { get; set; }

        ///<summary>
        ///Unique ID of the unit
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the unit")]
        public Guid UniqueId { get; set; }

        ///<summary>
        ///Symbol
        ///</summary>
        [ApiMember(Description="Symbol")]
        public string Symbol { get; set; }

        ///<summary>
        ///Singular name
        ///</summary>
        [ApiMember(Description="Singular name")]
        public string SingularName { get; set; }

        ///<summary>
        ///Plural name
        ///</summary>
        [ApiMember(Description="Plural name")]
        public string PluralName { get; set; }
    }

    public class UnitGroup
    {
        ///<summary>
        ///Group identifier
        ///</summary>
        [ApiMember(Description="Group identifier")]
        public string GroupIdentifier { get; set; }

        ///<summary>
        ///Base unit identifier
        ///</summary>
        [ApiMember(Description="Base unit identifier")]
        public string BaseUnitIdentifier { get; set; }

        ///<summary>
        ///True if the unit group is required by the system
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if the unit group is required by the system")]
        public bool IsSystem { get; set; }

        ///<summary>
        ///Current dimension
        ///</summary>
        [ApiMember(DataType="integer", Description="Current dimension")]
        public int CurrentDimension { get; set; }

        ///<summary>
        ///Intensity dimension
        ///</summary>
        [ApiMember(DataType="integer", Description="Intensity dimension")]
        public int IntensityDimension { get; set; }

        ///<summary>
        ///Length dimension
        ///</summary>
        [ApiMember(DataType="integer", Description="Length dimension")]
        public int LengthDimension { get; set; }

        ///<summary>
        ///Mass dimension
        ///</summary>
        [ApiMember(DataType="integer", Description="Mass dimension")]
        public int MassDimension { get; set; }

        ///<summary>
        ///Substance dimension
        ///</summary>
        [ApiMember(DataType="integer", Description="Substance dimension")]
        public int SubstanceDimension { get; set; }

        ///<summary>
        ///Temperature dimension
        ///</summary>
        [ApiMember(DataType="integer", Description="Temperature dimension")]
        public int TemperatureDimension { get; set; }

        ///<summary>
        ///Time dimension
        ///</summary>
        [ApiMember(DataType="integer", Description="Time dimension")]
        public int TimeDimension { get; set; }

        ///<summary>
        ///Unique ID of the unit group
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the unit group")]
        public Guid UniqueId { get; set; }

        ///<summary>
        ///Display name
        ///</summary>
        [ApiMember(Description="Display name")]
        public string DisplayName { get; set; }
    }

    public class UnitGroupsResponse
    {
        public UnitGroupsResponse()
        {
            Results = new List<UnitGroup>{};
        }

        ///<summary>
        ///The list of unit groups
        ///</summary>
        [ApiMember(DataType="Array<UnitGroup>", Description="The list of unit groups")]
        public List<UnitGroup> Results { get; set; }
    }

    public class UnitsResponse
    {
        public UnitsResponse()
        {
            Results = new List<Unit>{};
        }

        ///<summary>
        ///The list of units
        ///</summary>
        [ApiMember(DataType="Array<Unit>", Description="The list of units")]
        public List<Unit> Results { get; set; }
    }

    public class User
    {
        ///<summary>
        ///Login name
        ///</summary>
        [ApiMember(Description="Login name")]
        public string LoginName { get; set; }

        ///<summary>
        ///First name
        ///</summary>
        [ApiMember(Description="First name")]
        public string FirstName { get; set; }

        ///<summary>
        ///Last name
        ///</summary>
        [ApiMember(Description="Last name")]
        public string LastName { get; set; }

        ///<summary>
        ///Email
        ///</summary>
        [ApiMember(Description="Email")]
        public string Email { get; set; }

        ///<summary>
        ///Authentication type
        ///</summary>
        [ApiMember(Description="Authentication type")]
        public string AuthenticationType { get; set; }

        ///<summary>
        ///True if the user is allowed to log into the system
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if the user is allowed to log into the system")]
        public bool Active { get; set; }

        ///<summary>
        ///True if the user is required to exist in the system
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if the user is required to exist in the system")]
        public bool System { get; set; }

        ///<summary>
        ///True if the user has the 'Can Configure System' right
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if the user has the 'Can Configure System' right")]
        public bool CanConfigureSystem { get; set; }

        ///<summary>
        ///True if the user is licenced to launch the Rating Development toolbox
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if the user is licenced to launch the Rating Development toolbox")]
        public bool CanLaunchRatingDevelopmentToolbox { get; set; }

        ///<summary>
        ///Unique ID of the user
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the user")]
        public Guid UniqueId { get; set; }
    }

    public class UsersResponse
    {
        public UsersResponse()
        {
            Results = new List<User>{};
        }

        ///<summary>
        ///The list of users
        ///</summary>
        [ApiMember(DataType="Array<User>", Description="The list of users")]
        public List<User> Results { get; set; }
    }
}

namespace Aquarius.Client.ServiceModels.Provisioning
{
    public static class Current
    {
        public static readonly AquariusServerVersion Version = AquariusServerVersion.Create("16.3.89.0");
    }
}
