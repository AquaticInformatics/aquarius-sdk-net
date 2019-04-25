/* Options:
Date: 2019-04-25 08:42:02
Version: 4.512
Tip: To override a DTO option, remove "//" prefix before updating
BaseUrl: http://autoserver1/AQUARIUS/Provisioning/v1

GlobalNamespace: Aquarius.TimeSeries.Client.ServiceModels.Provisioning
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
using Aquarius.TimeSeries.Client.ServiceModels.Provisioning;


namespace Aquarius.TimeSeries.Client.ServiceModels.Provisioning
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

    public enum MeasurementDirection
    {
        Unknown,
        FromTopToBottom,
        FromBottomToTop,
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

    public class ApprovalLevelBase
    {
        ///<summary>
        ///Approval Level. Values &gt;=1000 are locking levels
        ///</summary>
        [ApiMember(DataType="long integer", Description="Approval Level. Values &gt;=1000 are locking levels", IsRequired=true)]
        public long? ApprovalLevel { get; set; }

        ///<summary>
        ///Color value in #RRGGBB hexadecimal
        ///</summary>
        [ApiMember(Description="Color value in #RRGGBB hexadecimal", IsRequired=true)]
        public string Color { get; set; }

        ///<summary>
        ///Description
        ///</summary>
        [ApiMember(Description="Description", IsRequired=true)]
        public string Description { get; set; }
    }

    [Route("/approvallevels/{ApprovalLevel}", "DELETE")]
    public class DeleteApprovalLevel
        : IReturnVoid
    {
        ///<summary>
        ///Approval level
        ///</summary>
        [ApiMember(DataType="long integer", Description="Approval level", IsRequired=true, ParameterType="path")]
        public long? ApprovalLevel { get; set; }
    }

    [Route("/approvallevels/{ApprovalLevel}", "GET")]
    public class GetApprovalLevel
        : IReturn<ApprovalLevel>
    {
        ///<summary>
        ///Approval level
        ///</summary>
        [ApiMember(DataType="long integer", Description="Approval level", IsRequired=true, ParameterType="path")]
        public long ApprovalLevel { get; set; }
    }

    [Route("/approvallevels", "GET")]
    public class GetApprovalLevels
        : IReturn<ApprovalLevelsResponse>
    {
    }

    [Route("/approvallevels", "POST")]
    public class PostApprovalLevel
        : ApprovalLevelBase, IReturn<ApprovalLevel>
    {
    }

    [Route("/approvallevels/{ApprovalLevel}", "PUT")]
    public class PutApprovalLevel
        : ApprovalLevelBase, IReturn<ApprovalLevel>
    {
    }

    [Route("/fielddataplugins/{UniqueId}", "DELETE")]
    public class DeleteFieldDataPlugin
        : IReturnVoid
    {
        ///<summary>
        ///Unique ID of the field data plug-in
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the field data plug-in", IsRequired=true, ParameterType="path")]
        public Guid UniqueId { get; set; }
    }

    [Route("/fielddataplugins", "GET")]
    public class GetFieldDataPlugins
        : IReturn<FieldDataPluginsResponse>
    {
    }

    [Route("/fielddataplugins", "POST")]
    public class PostFieldDataPluginFile
        : IReturn<FieldDataPlugin>
    {
        ///<summary>
        ///File
        ///</summary>
        [Ignore]
        [ApiMember(DataType="file", Description="File", IsRequired=true, ParameterType="form")]
        public IHttpFile File { get; set; }

        ///<summary>
        ///Plug-in priority; 1 has highest priority; omitted or 0 means use package priority; default is to make this plug-in the highest priority
        ///</summary>
        [ApiMember(DataType="integer", Description="Plug-in priority; 1 has highest priority; omitted or 0 means use package priority; default is to make this plug-in the highest priority")]
        public int PluginPriority { get; set; }
    }

    [Route("/locations/{LocationUniqueId}/datumperiods", "DELETE")]
    public class DeleteLocationDatum
        : IReturnVoid
    {
        ///<summary>
        ///Unique ID of the location
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the location", IsRequired=true, ParameterType="path")]
        public Guid LocationUniqueId { get; set; }
    }

    [Route("/locations/{LocationUniqueId}/datumperiods", "GET")]
    public class GetLocationDatum
        : IReturn<LocationDatumResponse>
    {
        ///<summary>
        ///Unique ID of the location
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the location", IsRequired=true, ParameterType="path")]
        public Guid LocationUniqueId { get; set; }
    }

    [Route("/locations/{LocationUniqueId}/datumperiods", "POST")]
    public class PostLocationDatumPeriod
        : LocationDatumPeriodBase, IReturn<LocationDatumResponse>
    {
        ///<summary>
        ///Unique ID of the location
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the location", IsRequired=true, ParameterType="path")]
        public Guid LocationUniqueId { get; set; }

        ///<summary>
        ///Reference standard this period is related to, which must be a standard reference datum for the location
        ///</summary>
        [ApiMember(Description="Reference standard this period is related to, which must be a standard reference datum for the location", IsRequired=true)]
        public string StandardIdentifier { get; set; }
    }

    [Route("/locationfolders/{LocationFolderUniqueId}", "DELETE")]
    public class DeleteLocationFolder
        : IReturnVoid
    {
        ///<summary>
        ///Unique ID of the location folder
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the location folder", IsRequired=true, ParameterType="path")]
        public Guid LocationFolderUniqueId { get; set; }
    }

    [Route("/locationfolders/{LocationFolderUniqueId}/userroles/{UserUniqueId}", "DELETE")]
    public class DeleteLocationFolderUserRole
        : IReturnVoid
    {
        ///<summary>
        ///Unique Id of the location folder
        ///</summary>
        [ApiMember(DataType="string", Description="Unique Id of the location folder", IsRequired=true, ParameterType="path")]
        public Guid LocationFolderUniqueId { get; set; }

        ///<summary>
        ///Unique Id of the user the role will be removed for
        ///</summary>
        [ApiMember(DataType="string", Description="Unique Id of the user the role will be removed for", IsRequired=true, ParameterType="path")]
        public Guid UserUniqueId { get; set; }
    }

    [Route("/locationtypes/{UniqueId}", "DELETE")]
    public class DeleteLocationType
        : IReturnVoid
    {
        ///<summary>
        ///Unique ID of the location type
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the location type", IsRequired=true, ParameterType="path")]
        public Guid UniqueId { get; set; }
    }

    [Route("/locations/{LocationUniqueId}/userroles/{UserUniqueId}", "DELETE")]
    public class DeleteLocationUserRole
        : IReturnVoid
    {
        ///<summary>
        ///Unique Id of the location
        ///</summary>
        [ApiMember(DataType="string", Description="Unique Id of the location", IsRequired=true, ParameterType="path")]
        public Guid LocationUniqueId { get; set; }

        ///<summary>
        ///Unique Id of the user the role will be removed for
        ///</summary>
        [ApiMember(DataType="string", Description="Unique Id of the user the role will be removed for", IsRequired=true, ParameterType="path")]
        public Guid UserUniqueId { get; set; }
    }

    [Route("/locations/{LocationUniqueId}/referencepoints/{ReferencePointUniqueId}", "DELETE")]
    public class DeleteReferencePoint
        : IReturnVoid
    {
        ///<summary>
        ///Unique ID of the location
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the location", IsRequired=true, ParameterType="path")]
        public Guid LocationUniqueId { get; set; }

        ///<summary>
        ///Unique ID of the reference point
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the reference point", IsRequired=true, ParameterType="path")]
        public Guid ReferencePointUniqueId { get; set; }
    }

    [Route("/locations/{LocationUniqueId}", "GET")]
    public class GetLocation
        : IReturn<Location>
    {
        ///<summary>
        ///Unique ID of the location
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the location", IsRequired=true, ParameterType="path")]
        public Guid LocationUniqueId { get; set; }
    }

    [Route("/locationfolders/{LocationFolderUniqueId}", "GET")]
    public class GetLocationFolder
        : IReturn<LocationFolder>
    {
        ///<summary>
        ///Unique ID of the location folder
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the location folder", IsRequired=true, ParameterType="path")]
        public Guid LocationFolderUniqueId { get; set; }
    }

    [Route("/locationfolders", "GET")]
    public class GetLocationFolders
        : IReturn<LocationFoldersResponse>
    {
    }

    [Route("/locationfolders/{LocationFolderUniqueId}/userroles", "GET")]
    public class GetLocationFolderUserRoles
        : IReturn<LocationFolderUserRoles>
    {
        ///<summary>
        ///Unique ID of the location folder
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the location folder", IsRequired=true, ParameterType="path")]
        public Guid LocationFolderUniqueId { get; set; }
    }

    [Route("/locations/{LocationUniqueId}/referencepoints/", "GET")]
    public class GetLocationReferencePoints
        : IReturn<ReferencePointResponse>
    {
        ///<summary>
        ///Unique ID of the location
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the location", IsRequired=true, ParameterType="path")]
        public Guid LocationUniqueId { get; set; }
    }

    [Route("/locationtypes/{UniqueId}", "GET")]
    public class GetLocationType
        : IReturn<LocationType>
    {
        ///<summary>
        ///Unique ID of the location type
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the location type", IsRequired=true, ParameterType="path")]
        public Guid UniqueId { get; set; }
    }

    [Route("/locationtypes", "GET")]
    public class GetLocationTypes
        : IReturn<LocationTypesResponse>
    {
    }

    [Route("/locations/{LocationUniqueId}/userroles", "GET")]
    public class GetLocationUserRoles
        : IReturn<LocationUserRoles>
    {
        ///<summary>
        ///Unique ID of the location
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the location", IsRequired=true, ParameterType="path")]
        public Guid LocationUniqueId { get; set; }
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
        ///Longitude (WGS 84)
        ///</summary>
        [ApiMember(DataType="double", Description="Longitude (WGS 84)")]
        public double? Longitude { get; set; }

        ///<summary>
        ///Latitude (WGS 84)
        ///</summary>
        [ApiMember(DataType="double", Description="Latitude (WGS 84)")]
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
        [ApiMember(DataType="Array<ExtendedAttributeValue>", Description="Extended attribute values")]
        public IList<ExtendedAttributeValue> ExtendedAttributeValues { get; set; }
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
    public class PostLocation
        : LocationBase, IReturn<Location>
    {
        ///<summary>
        ///ISO 8601 duration format
        ///</summary>
        [ApiMember(DataType="Offset", Description="ISO 8601 duration format")]
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

    [Route("/locations/{LocationUniqueId}/referencepoints", "POST")]
    public class PostReferencePoint
        : ReferencePointBase, IReturn<ReferencePoint>
    {
        public PostReferencePoint()
        {
            ReferencePointPeriods = new List<PostReferencePointPeriod>{};
        }

        ///<summary>
        ///Periods of applicablity for this reference point. Must have at least one period
        ///</summary>
        [ApiMember(DataType="Array<PostReferencePointPeriod>", Description="Periods of applicablity for this reference point. Must have at least one period", IsRequired=true)]
        public List<PostReferencePointPeriod> ReferencePointPeriods { get; set; }
    }

    public class PostReferencePointPeriod
        : ReferencePointPeriodBase
    {
    }

    [Route("/locations/{LocationUniqueId}", "PUT")]
    public class PutLocation
        : LocationBase, IReturn<Location>
    {
        ///<summary>
        ///Unique ID of the location
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the location", IsRequired=true, ParameterType="path")]
        public Guid LocationUniqueId { get; set; }
    }

    [Route("/locationfolders/{LocationFolderUniqueId}", "PUT")]
    public class PutLocationFolder
        : LocationFolderWriteBase, IReturn<LocationFolder>
    {
        ///<summary>
        ///Unique ID of the location folder
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the location folder", IsRequired=true, ParameterType="path")]
        public Guid LocationFolderUniqueId { get; set; }
    }

    [Route("/locationfolders/{LocationFolderUniqueId}/userroles/{UserUniqueId}", "PUT")]
    public class PutLocationFolderUserRole
        : PutUserRoleBase, IReturn<LocationFolderUserRole>
    {
        ///<summary>
        ///Unique Id of the location folder
        ///</summary>
        [ApiMember(DataType="string", Description="Unique Id of the location folder", IsRequired=true, ParameterType="path")]
        public Guid LocationFolderUniqueId { get; set; }
    }

    [Route("/locations/{LocationUniqueId}/tags", "PUT")]
    public class PutLocationTags
        : IReturn<Location>
    {
        public PutLocationTags()
        {
            TagUniqueIds = new List<Guid>{};
        }

        ///<summary>
        ///Unique ID of the location
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the location", IsRequired=true, ParameterType="path")]
        public Guid LocationUniqueId { get; set; }

        ///<summary>
        ///UniqueId of each tag to be assigned to the location; an empty list means the location will have no tags assigned to it
        ///</summary>
        [ApiMember(DataType="Array<string>", Description="UniqueId of each tag to be assigned to the location; an empty list means the location will have no tags assigned to it", IsRequired=true)]
        public List<Guid> TagUniqueIds { get; set; }
    }

    [Route("/locationtypes/{UniqueId}", "PUT")]
    public class PutLocationType
        : LocationTypeBase, IReturn<LocationType>
    {
        ///<summary>
        ///Unique ID of the location type
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the location type", IsRequired=true, ParameterType="path")]
        public Guid UniqueId { get; set; }
    }

    [Route("/locations/{LocationUniqueId}/userroles/{UserUniqueId}", "PUT")]
    public class PutLocationUserRole
        : PutUserRoleBase, IReturn<LocationUserRole>
    {
        ///<summary>
        ///Unique Id of the location
        ///</summary>
        [ApiMember(DataType="string", Description="Unique Id of the location", IsRequired=true, ParameterType="path")]
        public Guid LocationUniqueId { get; set; }
    }

    public class PutUserRoleBase
    {
        ///<summary>
        ///Unique Id of the user the role will apply to
        ///</summary>
        [ApiMember(DataType="string", Description="Unique Id of the user the role will apply to", IsRequired=true, ParameterType="path")]
        public Guid UserUniqueId { get; set; }

        ///<summary>
        ///Unique id of role to set
        ///</summary>
        [ApiMember(DataType="string", Description="Unique id of role to set", IsRequired=true)]
        public Guid? RoleUniqueId { get; set; }
    }

    public class ReferencePointBase
    {
        ///<summary>
        ///Unique ID of the location
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the location", IsRequired=true, ParameterType="path")]
        public Guid LocationUniqueId { get; set; }

        ///<summary>
        ///Name
        ///</summary>
        [ApiMember(Description="Name", IsRequired=true)]
        public string Name { get; set; }

        ///<summary>
        ///Description
        ///</summary>
        [ApiMember(Description="Description")]
        public string Description { get; set; }

        ///<summary>
        ///Decommissioned date
        ///</summary>
        [ApiMember(DataType="Instant", Description="Decommissioned date")]
        public Instant? DecommissionedDate { get; set; }

        ///<summary>
        ///Decommissioned reason
        ///</summary>
        [ApiMember(Description="Decommissioned reason")]
        public string DecommissionedReason { get; set; }

        ///<summary>
        ///Indicates this reference point has been the primary since the date herein; if null, the point is a regular reference point.
        ///</summary>
        [ApiMember(DataType="Instant", Description="Indicates this reference point has been the primary since the date herein; if null, the point is a regular reference point.")]
        public Instant? PrimarySinceDate { get; set; }

        ///<summary>
        ///Longitude (WGS 84)
        ///</summary>
        [ApiMember(DataType="double", Description="Longitude (WGS 84)")]
        public double? Longitude { get; set; }

        ///<summary>
        ///Latitude (WGS 84)
        ///</summary>
        [ApiMember(DataType="double", Description="Latitude (WGS 84)")]
        public double? Latitude { get; set; }
    }

    [Route("/monitoringmethods/{MethodCode}", "DELETE")]
    public class DeleteMonitoringMethod
        : IReturnVoid
    {
        ///<summary>
        ///Method code
        ///</summary>
        [ApiMember(Description="Method code", IsRequired=true, ParameterType="path")]
        public string MethodCode { get; set; }
    }

    [Route("/monitoringmethods/{MethodCode}", "GET")]
    public class GetMonitoringMethod
        : IReturn<MonitoringMethod>
    {
        ///<summary>
        ///Method code
        ///</summary>
        [ApiMember(Description="Method code", IsRequired=true, ParameterType="path")]
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
        [ApiMember(DataType="string", Description="Unique ID of the parameter", IsRequired=true, ParameterType="path")]
        public Guid UniqueId { get; set; }
    }

    [Route("/parameters/{UniqueId}", "GET")]
    public class GetParameter
        : IReturn<Parameter>
    {
        ///<summary>
        ///Unique ID of the parameter
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the parameter", IsRequired=true, ParameterType="path")]
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
        [ApiMember(DataType="InterpolationType", Description="Interpolation type", IsRequired=true)]
        public InterpolationType InterpolationType { get; set; }

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
        [ApiMember(DataType="string", Description="Unique ID of the parameter", IsRequired=true, ParameterType="path")]
        public Guid UniqueId { get; set; }
    }

    [Route("/qualifiers/{UniqueId}", "DELETE")]
    public class DeleteQualifier
        : IReturnVoid
    {
        ///<summary>
        ///Unique ID of the qualifier 
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the qualifier ", IsRequired=true, ParameterType="path")]
        public Guid UniqueId { get; set; }
    }

    [Route("/qualifiergroups/{UniqueId}", "DELETE")]
    public class DeleteQualifierGroup
        : IReturnVoid
    {
        ///<summary>
        ///Unique ID of the qualifier group
        ///</summary>
        [ApiMember(Description="Unique ID of the qualifier group", IsRequired=true, ParameterType="path")]
        public string UniqueId { get; set; }
    }

    [Route("/qualifiers/{UniqueId}", "GET")]
    public class GetQualifier
        : IReturn<QualifierResponse>
    {
        ///<summary>
        ///Unique ID of the qualifier 
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the qualifier ", IsRequired=true, ParameterType="path")]
        public Guid UniqueId { get; set; }
    }

    [Route("/qualifiergroups", "GET")]
    public class GetQualifierGroups
        : IReturn<QualifierGroupsResponse>
    {
    }

    [Route("/qualifiers", "GET")]
    public class GetQualifiers
        : IReturn<QualifiersResponse>
    {
    }

    [Route("/qualifiers", "POST")]
    public class PostQualifier
        : QualifierBase, IReturn<QualifierResponse>
    {
    }

    [Route("/qualifiergroups", "POST")]
    public class PostQualifierGroup
        : IReturn<QualifierGroupResponse>
    {
        ///<summary>
        ///Qualifier group identifier
        ///</summary>
        [ApiMember(Description="Qualifier group identifier", IsRequired=true)]
        public string Identifier { get; set; }
    }

    [Route("/qualifiers/{UniqueId}", "PUT")]
    public class PutQualifier
        : IReturn<QualifierResponse>
    {
        public PutQualifier()
        {
            GroupIdentifiers = new List<string>{};
        }

        ///<summary>
        ///Unique ID of the qualifier 
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the qualifier ", IsRequired=true, ParameterType="path")]
        public Guid UniqueId { get; set; }

        ///<summary>
        ///Public identifier
        ///</summary>
        [ApiMember(Description="Public identifier", IsRequired=true)]
        public string PublicIdentifier { get; set; }

        ///<summary>
        ///Display name
        ///</summary>
        [ApiMember(Description="Display name")]
        public string DisplayName { get; set; }

        ///<summary>
        ///Qualifier group identifiers - if no groups (an empty list is []) are specified, the qualifier will be removed from all groups and re-assigned to the 'Default' qualifier group
        ///</summary>
        [ApiMember(DataType="Array<string>", Description="Qualifier group identifiers - if no groups (an empty list is []) are specified, the qualifier will be removed from all groups and re-assigned to the 'Default' qualifier group", IsRequired=true)]
        public List<string> GroupIdentifiers { get; set; }
    }

    [Route("/qualifiergroups/{UniqueId}", "PUT")]
    public class PutQualifierGroup
        : IReturn<QualifierGroupResponse>
    {
        public PutQualifierGroup()
        {
            QualifierCodeList = new List<string>{};
        }

        ///<summary>
        ///Unique ID of the qualifier group
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the qualifier group", IsRequired=true, ParameterType="path")]
        public Guid UniqueId { get; set; }

        ///<summary>
        ///Identifier
        ///</summary>
        [ApiMember(Description="Identifier", IsRequired=true)]
        public string Identifier { get; set; }

        ///<summary>
        ///Qualifier codes contained in this group 
        ///</summary>
        [ApiMember(DataType="Array<string>", Description="Qualifier codes contained in this group ", IsRequired=true)]
        public List<string> QualifierCodeList { get; set; }
    }

    public class QualifierBase
    {
        public QualifierBase()
        {
            GroupIdentifiers = new List<string>{};
        }

        ///<summary>
        ///Public identifier
        ///</summary>
        [ApiMember(Description="Public identifier", IsRequired=true)]
        public string PublicIdentifier { get; set; }

        ///<summary>
        ///Qualifier code
        ///</summary>
        [ApiMember(Description="Qualifier code", IsRequired=true)]
        public string QualifierCode { get; set; }

        ///<summary>
        ///Display name
        ///</summary>
        [ApiMember(Description="Display name")]
        public string DisplayName { get; set; }

        ///<summary>
        ///Qualifier group identifiers - if no groups are specified, the qualifier will be assigned to the 'Default' qualifier group
        ///</summary>
        [ApiMember(DataType="Array<string>", Description="Qualifier group identifiers - if no groups are specified, the qualifier will be assigned to the 'Default' qualifier group")]
        public List<string> GroupIdentifiers { get; set; }
    }

    [Route("/grades/{GradeCode}", "DELETE")]
    public class DeleteQualityCode
        : IReturnVoid
    {
        ///<summary>
        ///Grade code
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code", IsRequired=true, ParameterType="path")]
        public int GradeCode { get; set; }
    }

    [Route("/grades/{GradeCode}", "GET")]
    public class GetQualityCode
        : IReturn<Grade>
    {
        ///<summary>
        ///Grade code
        ///</summary>
        [ApiMember(DataType="integer", Description="Grade code", IsRequired=true, ParameterType="path")]
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
        [ApiMember(DataType="integer", Description="Grade code", IsRequired=true, ParameterType="path")]
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
        ///Color value in #RRGGBB hexadecimal
        ///</summary>
        [ApiMember(Description="Color value in #RRGGBB hexadecimal", IsRequired=true)]
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

    [Route("/reportplugins/{UniqueId}", "DELETE")]
    public class DeleteReportPlugin
        : IReturnVoid
    {
        ///<summary>
        ///Unique ID of the report plug-in
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the report plug-in", IsRequired=true, ParameterType="path")]
        public Guid UniqueId { get; set; }
    }

    [Route("/reportplugins", "GET")]
    public class GetReportPlugins
        : IReturn<ReportPluginResponse>
    {
    }

    [Route("/reportplugins", "POST")]
    public class PostReportPlugin
        : ReportPluginBase, IReturn<ReportPlugin>
    {
    }

    public class ReportPluginBase
    {
        ///<summary>
        ///Assembly name
        ///</summary>
        [ApiMember(Description="Assembly name", IsRequired=true)]
        public string AssemblyName { get; set; }

        ///<summary>
        ///Plug-in folder name
        ///</summary>
        [ApiMember(Description="Plug-in folder name", IsRequired=true)]
        public string FolderName { get; set; }
    }

    [Route("/roles/{UniqueId}", "DELETE")]
    public class DeleteRole
    {
        ///<summary>
        ///Unique Id of the role
        ///</summary>
        [ApiMember(DataType="string", Description="Unique Id of the role", IsRequired=true, ParameterType="path")]
        public Guid UniqueId { get; set; }
    }

    [Route("/roles/{UniqueId}", "GET")]
    public class GetRole
        : IReturn<Role>
    {
        ///<summary>
        ///Unique Id of the role
        ///</summary>
        [ApiMember(DataType="string", Description="Unique Id of the role", IsRequired=true, ParameterType="path")]
        public Guid UniqueId { get; set; }
    }

    [Route("/roles/{UniqueId}/flattened", "GET")]
    public class GetRoleFlattened
        : IReturn<RoleFlattened>
    {
        ///<summary>
        ///Unique Id of the role
        ///</summary>
        [ApiMember(DataType="string", Description="Unique Id of the role", IsRequired=true, ParameterType="path")]
        public Guid UniqueId { get; set; }
    }

    [Route("/roles", "GET")]
    public class GetRoles
        : IReturn<RolesResponse>
    {
    }

    [Route("/roles", "POST")]
    public class PostRole
        : RoleBase, IReturn<Role>
    {
    }

    [Route("/roles/flattened", "POST")]
    public class PostRoleFlattened
        : RoleFlattenedBase, IReturn<RoleFlattened>
    {
    }

    [Route("/roles/{UniqueId}", "PUT")]
    public class PutRole
        : RoleBase, IReturn<Role>
    {
        ///<summary>
        ///Unique Id of the role
        ///</summary>
        [ApiMember(DataType="string", Description="Unique Id of the role", IsRequired=true, ParameterType="path")]
        public Guid UniqueId { get; set; }
    }

    [Route("/roles/{UniqueId}/flattened", "PUT")]
    public class PutRoleFlattened
        : RoleFlattenedBase, IReturn<RoleFlattened>
    {
        ///<summary>
        ///Unique Id of the role
        ///</summary>
        [ApiMember(DataType="string", Description="Unique Id of the role", IsRequired=true, ParameterType="path")]
        public Guid UniqueId { get; set; }
    }

    public class RoleBase
    {
        public RoleBase()
        {
            RoleApprovalTransitions = new List<RoleApprovalTransition>{};
        }

        ///<summary>
        ///Name
        ///</summary>
        [ApiMember(Description="Name", IsRequired=true)]
        public string Name { get; set; }

        ///<summary>
        ///List of approval transitions this role grants permission to perform.
        ///</summary>
        [ApiMember(DataType="Array<RoleApprovalTransition>", Description="List of approval transitions this role grants permission to perform.")]
        public List<RoleApprovalTransition> RoleApprovalTransitions { get; set; }

        ///<summary>
        ///True if role grants permission to: Read data and generate reports.
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if role grants permission to: Read data and generate reports.")]
        public bool CanReadData { get; set; }

        ///<summary>
        ///True if role grants permission to: Add data. Includes appending logger data, creating/editing field visits, and uploading attachments.
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if role grants permission to: Add data. Includes appending logger data, creating/editing field visits, and uploading attachments.")]
        public bool CanAddData { get; set; }

        ///<summary>
        ///True if role grants permission to: Edit data. Includes making corrections to time series; editing curves and shifts within a rating model.
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if role grants permission to: Edit data. Includes making corrections to time series; editing curves and shifts within a rating model.")]
        public bool CanEditData { get; set; }

        ///<summary>
        ///True if role grants permission to: Edit location properties and derivations. Includes creating and editing time series, rating models, process settings.
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if role grants permission to: Edit location properties and derivations. Includes creating and editing time series, rating models, process settings.")]
        public bool CanEditLocationDetails { get; set; }

        ///<summary>
        ///True if role grants permission to: Add and remove locations.
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if role grants permission to: Add and remove locations.")]
        public bool CanAddOrRemoveLocations { get; set; }

        ///<summary>
        ///True if role grants permission to: Assign user roles for folders and locations.
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if role grants permission to: Assign user roles for folders and locations.")]
        public bool CanAssignUserRoles { get; set; }

        ///<summary>
        ///True if role grants permission to: Remove field visits.
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if role grants permission to: Remove field visits.")]
        public bool CanRemoveFieldVisits { get; set; }
    }

    public class RoleFlattenedBase
    {
        public RoleFlattenedBase()
        {
            RoleApprovalTransitions = new List<string>{};
        }

        ///<summary>
        ///Name
        ///</summary>
        [ApiMember(Description="Name", IsRequired=true)]
        public string Name { get; set; }

        ///<summary>
        ///List of approval transitions this role grants permission to perform. Format: '&lt;FromLevel&gt; &lt;ToLevel&gt;'. Example: '900 1200'
        ///</summary>
        [ApiMember(DataType="Array<string>", Description="List of approval transitions this role grants permission to perform. Format: '&lt;FromLevel&gt; &lt;ToLevel&gt;'. Example: '900 1200'")]
        public List<string> RoleApprovalTransitions { get; set; }

        ///<summary>
        ///True if role grants permission to: Read data and generate reports.
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if role grants permission to: Read data and generate reports.")]
        public bool CanReadData { get; set; }

        ///<summary>
        ///True if role grants permission to: Add data. Includes appending logger data, creating/editing field visits, and uploading attachments.
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if role grants permission to: Add data. Includes appending logger data, creating/editing field visits, and uploading attachments.")]
        public bool CanAddData { get; set; }

        ///<summary>
        ///True if role grants permission to: Edit data. Includes making corrections to time series; editing curves and shifts within a rating model.
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if role grants permission to: Edit data. Includes making corrections to time series; editing curves and shifts within a rating model.")]
        public bool CanEditData { get; set; }

        ///<summary>
        ///True if role grants permission to: Edit location properties and derivations. Includes creating and editing time series, rating models, process settings.
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if role grants permission to: Edit location properties and derivations. Includes creating and editing time series, rating models, process settings.")]
        public bool CanEditLocationDetails { get; set; }

        ///<summary>
        ///True if role grants permission to: Add and remove locations.
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if role grants permission to: Add and remove locations.")]
        public bool CanAddOrRemoveLocations { get; set; }

        ///<summary>
        ///True if role grants permission to: Assign user roles for folders and locations.
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if role grants permission to: Assign user roles for folders and locations.")]
        public bool CanAssignUserRoles { get; set; }

        ///<summary>
        ///True if role grants permission to: Remove field visits.
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if role grants permission to: Remove field visits.")]
        public bool CanRemoveFieldVisits { get; set; }
    }

    [Route("/settings/{Group}/{Key}", "DELETE")]
    public class DeleteSetting
        : IReturnVoid
    {
        ///<summary>
        ///Setting group
        ///</summary>
        [ApiMember(Description="Setting group", IsRequired=true, ParameterType="path")]
        public string Group { get; set; }

        ///<summary>
        ///Setting key
        ///</summary>
        [ApiMember(Description="Setting key", IsRequired=true, ParameterType="path")]
        public string Key { get; set; }
    }

    [Route("/settings/{Group}/{Key}", "GET")]
    public class GetSetting
        : IReturn<Setting>
    {
        ///<summary>
        ///Setting group
        ///</summary>
        [ApiMember(Description="Setting group", IsRequired=true, ParameterType="path")]
        public string Group { get; set; }

        ///<summary>
        ///Setting key
        ///</summary>
        [ApiMember(Description="Setting key", IsRequired=true, ParameterType="path")]
        public string Key { get; set; }
    }

    [Route("/settings/{Group}", "GET")]
    public class GetSettingGroup
        : IReturn<SettingsResponse>
    {
        ///<summary>
        ///Setting group
        ///</summary>
        [ApiMember(Description="Setting group", IsRequired=true, ParameterType="path")]
        public string Group { get; set; }
    }

    [Route("/settings", "GET")]
    public class GetSettings
        : IReturn<SettingsResponse>
    {
    }

    [Route("/settings", "POST")]
    public class PostSetting
        : IReturn<Setting>
    {
        ///<summary>
        ///Setting group
        ///</summary>
        [ApiMember(Description="Setting group", IsRequired=true)]
        public string Group { get; set; }

        ///<summary>
        ///Setting key
        ///</summary>
        [ApiMember(Description="Setting key", IsRequired=true)]
        public string Key { get; set; }

        ///<summary>
        ///Setting value
        ///</summary>
        [ApiMember(Description="Setting value")]
        public string Value { get; set; }

        ///<summary>
        ///Setting description
        ///</summary>
        [ApiMember(Description="Setting description")]
        public string Description { get; set; }
    }

    [Route("/settings/{Group}/{Key}", "PUT")]
    public class PutSetting
        : IReturn<Setting>
    {
        ///<summary>
        ///Setting group
        ///</summary>
        [ApiMember(Description="Setting group", IsRequired=true, ParameterType="path")]
        public string Group { get; set; }

        ///<summary>
        ///Setting key
        ///</summary>
        [ApiMember(Description="Setting key", IsRequired=true, ParameterType="path")]
        public string Key { get; set; }

        ///<summary>
        ///Setting value
        ///</summary>
        [ApiMember(Description="Setting value")]
        public string Value { get; set; }

        ///<summary>
        ///Setting description
        ///</summary>
        [ApiMember(Description="Setting description")]
        public string Description { get; set; }
    }

    [Route("/standarddatums/{Identifier}", "DELETE")]
    public class DeleteStandardDatum
        : IReturnVoid
    {
        ///<summary>
        ///Identifier of the standard daturm
        ///</summary>
        [ApiMember(Description="Identifier of the standard daturm", IsRequired=true, ParameterType="path")]
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

    [Route("/locations/{LocationUniqueId}/standardreferencedatums/{StandardIdentifier}", "DELETE")]
    public class DeleteStandardReferenceDatum
        : StandardReferenceDatumRequestBase, IReturnVoid
    {
    }

    [Route("/locations/{LocationUniqueId}/standardreferencedatums", "GET")]
    public class GetStandardReferenceDatums
        : IReturn<StandardReferenceDatumsResponse>
    {
        ///<summary>
        ///Unique ID of the location
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the location", IsRequired=true, ParameterType="path")]
        public Guid LocationUniqueId { get; set; }
    }

    [Route("/locations/{LocationUniqueId}/standardreferencedatums/basereference", "POST")]
    public class PostBaseStandardReferenceDatum
        : StandardReferenceDatumRequestBase, IReturn<StandardReferenceDatum>
    {
    }

    [Route("/locations/{LocationUniqueId}/standardreferencedatums/basereferenceoffset", "POST")]
    public class PostBaseStandardReferenceDatumOffset
        : StandardReferenceDatumRequestBase, IReturn<StandardReferenceDatum>
    {
        ///<summary>
        ///Offset in relation to the base reference.
        ///</summary>
        [ApiMember(DataType="double", Description="Offset in relation to the base reference.", IsRequired=true)]
        public double OffsetToBaseReference { get; set; }
    }

    [Route("/locations/{LocationUniqueId}/standardreferencedatums/basereferenceoffset/{StandardIdentifier}", "PUT")]
    public class PutBaseStandardReferenceDatumOffset
        : IReturn<StandardReferenceDatum>
    {
        ///<summary>
        ///Unique ID of the location
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the location", IsRequired=true, ParameterType="path")]
        public Guid LocationUniqueId { get; set; }

        ///<summary>
        ///Standard identifier
        ///</summary>
        [ApiMember(Description="Standard identifier", IsRequired=true, ParameterType="path")]
        public string StandardIdentifier { get; set; }

        ///<summary>
        ///Offset in relation to the base reference.
        ///</summary>
        [ApiMember(DataType="double", Description="Offset in relation to the base reference.", IsRequired=true)]
        public double OffsetToBaseReference { get; set; }
    }

    public class StandardReferenceDatumRequestBase
    {
        ///<summary>
        ///Unique ID of the location
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the location", IsRequired=true, ParameterType="path")]
        public Guid LocationUniqueId { get; set; }

        ///<summary>
        ///StandardIdentifier
        ///</summary>
        [ApiMember(Description="StandardIdentifier", IsRequired=true)]
        public string StandardIdentifier { get; set; }
    }

    public class DeleteTagBase
    {
        ///<summary>
        ///Unique ID of the tag
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the tag", IsRequired=true, ParameterType="path")]
        public Guid UniqueId { get; set; }
    }

    public class GetTagsBase
    {
    }

    public class PostTagBase
    {
        ///<summary>
        ///Tag name
        ///</summary>
        [ApiMember(Description="Tag name", IsRequired=true)]
        public string Name { get; set; }
    }

    public class PutTagBase
    {
        ///<summary>
        ///Unique ID of the tag
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the tag", IsRequired=true, ParameterType="path")]
        public Guid UniqueId { get; set; }

        ///<summary>
        ///Tag name
        ///</summary>
        [ApiMember(Description="Tag name", IsRequired=true)]
        public string Name { get; set; }
    }

    [Route("/tags/location/{UniqueId}", "DELETE")]
    public class DeleteLocationTag
        : DeleteTagBase, IReturnVoid
    {
    }

    [Route("/tags/location", "GET")]
    public class GetLocationTags
        : GetTagsBase, IReturn<TagsResponse>
    {
    }

    [Route("/tags/location", "POST")]
    public class PostLocationTag
        : PostTagBase, IReturn<Tag>
    {
    }

    [Route("/tags/location/{UniqueId}", "PUT")]
    public class PutLocationTag
        : PutTagBase, IReturn<Tag>
    {
    }

    [Route("/tags/note/{UniqueId}", "DELETE")]
    public class DeleteNoteTag
        : DeleteTagBase, IReturnVoid
    {
    }

    [Route("/tags/note", "GET")]
    public class GetNoteTags
        : GetTagsBase, IReturn<TagsResponse>
    {
    }

    [Route("/tags/note", "POST")]
    public class PostNoteTag
        : PostTagBase, IReturn<Tag>
    {
    }

    [Route("/tags/note/{UniqueId}", "PUT")]
    public class PutNoteTag
        : PutTagBase, IReturn<Tag>
    {
    }

    [Route("/timeseries/{TimeSeriesUniqueId}", "DELETE")]
    public class DeleteTimeSeries
        : IReturnVoid
    {
        ///<summary>
        ///Unique ID of the time series
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the time series", IsRequired=true, ParameterType="path")]
        public Guid TimeSeriesUniqueId { get; set; }
    }

    [Route("/locations/{LocationUniqueId}/timeseries", "GET")]
    public class GetLocationTimeSeries
        : IReturn<TimeSeriesResponse>
    {
        ///<summary>
        ///Unique ID of the location
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the location", IsRequired=true, ParameterType="path")]
        public Guid LocationUniqueId { get; set; }
    }

    [Route("/timeseries/{TimeSeriesUniqueId}", "GET")]
    public class GetTimeSeries
        : IReturn<TimeSeries>
    {
        ///<summary>
        ///Unique ID of the time series
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the time series", IsRequired=true, ParameterType="path")]
        public Guid TimeSeriesUniqueId { get; set; }
    }

    [Route("/timeseries/extendedattributes", "GET")]
    public class GetTimeSeriesExtendedAttributes
        : IReturn<ExtendedAttributeFieldsResponse>
    {
    }

    [Route("/locations/{LocationUniqueId}/timeseries/basic", "POST")]
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
        [ApiMember(DataType="NewValueLocationType", Description="New value location")]
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

        ///<summary>
        ///Time Step Count. Must be included for 'Statistic' derived time-series.
        ///</summary>
        [ApiMember(DataType="integer", Description="Time Step Count. Must be included for 'Statistic' derived time-series.")]
        public int? TimeStepCount { get; set; }
    }

    [Route("/timeseries/{TimeSeriesUniqueId}", "PUT")]
    public class PutTimeSeries
        : IReturn<TimeSeries>
    {
        ///<summary>
        ///Unique ID of the time series
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the time series", IsRequired=true, ParameterType="path")]
        public Guid TimeSeriesUniqueId { get; set; }

        ///<summary>
        ///Label
        ///</summary>
        [ApiMember(Description="Label", IsRequired=true)]
        public string Label { get; set; }

        ///<summary>
        ///Sub location identifier
        ///</summary>
        [ApiMember(Description="Sub location identifier")]
        public string SubLocationIdentifier { get; set; }

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
        ///Extended attribute values
        ///</summary>
        [ApiMember(DataType="Array<ExtendedAttributeValue>", Description="Extended attribute values")]
        public IList<ExtendedAttributeValue> ExtendedAttributeValues { get; set; }
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
        ///Monitoring method code
        ///</summary>
        [ApiMember(Description="Monitoring method code", IsRequired=true)]
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
        [ApiMember(DataType="Array<ExtendedAttributeValue>", Description="Extended attribute values")]
        public IList<ExtendedAttributeValue> ExtendedAttributeValues { get; set; }
    }

    [Route("/units/{UniqueId}", "DELETE")]
    public class DeleteUnit
        : IReturnVoid
    {
        ///<summary>
        ///Unique ID of the unit
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the unit", IsRequired=true, ParameterType="path")]
        public Guid UniqueId { get; set; }
    }

    [Route("/unitgroups/{UniqueId}", "DELETE")]
    public class DeleteUnitGroup
        : IReturnVoid
    {
        ///<summary>
        ///Unique ID of the unit group
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the unit group", IsRequired=true, ParameterType="path")]
        public Guid UniqueId { get; set; }
    }

    [Route("/unitgroups/{UniqueId}/units", "DELETE")]
    public class DeleteUnits
        : IReturnVoid
    {
        ///<summary>
        ///Unique ID of the unit group
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the unit group", IsRequired=true, ParameterType="path")]
        public Guid UniqueId { get; set; }
    }

    [Route("/units/{UniqueId}", "GET")]
    public class GetUnit
        : IReturn<Unit>
    {
        ///<summary>
        ///Unique ID of the unit
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the unit", IsRequired=true, ParameterType="path")]
        public Guid UniqueId { get; set; }
    }

    [Route("/unitgroups/{UniqueId}", "GET")]
    public class GetUnitGroup
        : IReturn<UnitGroup>
    {
        ///<summary>
        ///Unique ID of the unit group
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the unit group", IsRequired=true, ParameterType="path")]
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
        [ApiMember(DataType="string", Description="Unique ID of the unit group", IsRequired=true, ParameterType="path")]
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
        [ApiMember(DataType="string", Description="Unique ID of the unit", IsRequired=true, ParameterType="path")]
        public Guid UniqueId { get; set; }
    }

    [Route("/unitgroups/{UniqueId}", "PUT")]
    public class PutUnitGroup
        : UnitGroupBase, IReturn<UnitGroup>
    {
        ///<summary>
        ///Unique ID of the unit group
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the unit group", IsRequired=true, ParameterType="path")]
        public Guid UniqueId { get; set; }

        ///<summary>
        ///Localized name
        ///</summary>
        [ApiMember(Description="Localized name", IsRequired=true)]
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
        [ApiMember(DataType="string", Description="Unique ID of the user", IsRequired=true, ParameterType="path")]
        public Guid UniqueId { get; set; }
    }

    [Route("/users/{UniqueId}", "GET")]
    public class GetUser
        : IReturn<User>
    {
        ///<summary>
        ///Unique ID of the user
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the user", IsRequired=true, ParameterType="path")]
        public Guid UniqueId { get; set; }
    }

    [Route("/users", "GET")]
    public class GetUsers
        : IReturn<UsersResponse>
    {
        ///<summary>
        ///If specified, only users with a matching Authentication Type will be returned
        ///</summary>
        [ApiMember(Description="If specified, only users with a matching Authentication Type will be returned")]
        public string AuthenticationType { get; set; }
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
        ///If provided, will override password for user
        ///</summary>
        [ApiMember(Description="If provided, will override password for user")]
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
        [ApiMember(DataType="string", Description="Unique ID of the user", IsRequired=true, ParameterType="path")]
        public Guid UniqueId { get; set; }
    }

    public class PutUserBase
        : UserBase
    {
        ///<summary>
        ///Unique ID of the user
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the user", IsRequired=true, ParameterType="path")]
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

    public class ApprovalLevel
    {
        ///<summary>
        ///Approval Level. Values &gt;=1000 are locking levels
        ///</summary>
        [ApiMember(DataType="long integer", Description="Approval Level. Values &gt;=1000 are locking levels", IsRequired=true)]
        public long Level { get; set; }

        ///<summary>
        ///Color in #RRGGBB hexadecimal
        ///</summary>
        [ApiMember(Description="Color in #RRGGBB hexadecimal", IsRequired=true)]
        public string Color { get; set; }

        ///<summary>
        ///Description
        ///</summary>
        [ApiMember(Description="Description", IsRequired=true)]
        public string Description { get; set; }
    }

    public class ApprovalLevelsResponse
    {
        public ApprovalLevelsResponse()
        {
            Results = new List<ApprovalLevel>{};
        }

        ///<summary>
        ///The list of approval levels
        ///</summary>
        [ApiMember(DataType="Array<ApprovalLevel>", Description="The list of approval levels")]
        public List<ApprovalLevel> Results { get; set; }
    }

    public class ExtendedAttributeField
    {
        ///<summary>
        ///Column identifier
        ///</summary>
        [ApiMember(Description="Column identifier")]
        public string ColumnIdentifier { get; set; }

        ///<summary>
        ///Display name
        ///</summary>
        [ApiMember(Description="Display name")]
        public string DisplayName { get; set; }

        ///<summary>
        ///Field type
        ///</summary>
        [ApiMember(DataType="ExtendedAttributeFieldType", Description="Field type")]
        public ExtendedAttributeFieldType FieldType { get; set; }

        ///<summary>
        ///Can be empty
        ///</summary>
        [ApiMember(DataType="boolean", Description="Can be empty")]
        public bool CanBeEmpty { get; set; }

        ///<summary>
        ///Is read only
        ///</summary>
        [ApiMember(DataType="boolean", Description="Is read only")]
        public bool IsReadOnly { get; set; }

        ///<summary>
        ///Numeric precision
        ///</summary>
        [ApiMember(DataType="integer", Description="Numeric precision")]
        public int? NumericPrecision { get; set; }

        ///<summary>
        ///Numeric scale
        ///</summary>
        [ApiMember(DataType="integer", Description="Numeric scale")]
        public int? NumericScale { get; set; }

        ///<summary>
        ///Column size
        ///</summary>
        [ApiMember(DataType="integer", Description="Column size")]
        public int? ColumnSize { get; set; }

        ///<summary>
        ///Value options
        ///</summary>
        [ApiMember(DataType="Array<string>", Description="Value options")]
        public IReadOnlyList<string> ValueOptions { get; set; }
    }

    public class ExtendedAttributeFieldsResponse
    {
        ///<summary>
        ///Results
        ///</summary>
        [ApiMember(DataType="Array<ExtendedAttributeField>", Description="Results")]
        public IList<ExtendedAttributeField> Results { get; set; }
    }

    public enum ExtendedAttributeFieldType
    {
        Boolean,
        DateTime,
        Number,
        String,
        StringOption,
    }

    public class ExtendedAttributeValue
    {
        ///<summary>
        ///Column identifier
        ///</summary>
        [ApiMember(Description="Column identifier")]
        public string ColumnIdentifier { get; set; }

        ///<summary>
        ///Value
        ///</summary>
        [ApiMember(Description="Value")]
        public string Value { get; set; }
    }

    public class FieldDataPlugin
    {
        ///<summary>
        ///Unique ID of the field data plug-in
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the field data plug-in")]
        public Guid UniqueId { get; set; }

        ///<summary>
        ///Plug-in folder name
        ///</summary>
        [ApiMember(Description="Plug-in folder name")]
        public string PluginFolderName { get; set; }

        ///<summary>
        ///Assembly qualified type name
        ///</summary>
        [ApiMember(Description="Assembly qualified type name")]
        public string AssemblyQualifiedTypeName { get; set; }

        ///<summary>
        ///Plug-in priority; 1 has highest priority
        ///</summary>
        [ApiMember(DataType="integer", Description="Plug-in priority; 1 has highest priority")]
        public int PluginPriority { get; set; }

        ///<summary>
        ///Description
        ///</summary>
        [ApiMember(Description="Description")]
        public string Description { get; set; }
    }

    public class FieldDataPluginsResponse
    {
        public FieldDataPluginsResponse()
        {
            Results = new List<FieldDataPlugin>{};
        }

        ///<summary>
        ///The list of registered field data plug-ins
        ///</summary>
        [ApiMember(DataType="Array<FieldDataPlugin>", Description="The list of registered field data plug-ins")]
        public List<FieldDataPlugin> Results { get; set; }
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
        public Location()
        {
            Tags = new List<Tag>{};
        }

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
        ///External locations are created by data connectors.  Only extended attributes can be modified on an external location.
        ///</summary>
        [ApiMember(DataType="boolean", Description="External locations are created by data connectors.  Only extended attributes can be modified on an external location.")]
        public bool IsExternalLocation { get; set; }

        ///<summary>
        ///Longitude (WGS 84)
        ///</summary>
        [ApiMember(DataType="double", Description="Longitude (WGS 84)")]
        public double? Longitude { get; set; }

        ///<summary>
        ///Latitude (WGS 84)
        ///</summary>
        [ApiMember(DataType="double", Description="Latitude (WGS 84)")]
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
        ///Tags applied to this location
        ///</summary>
        [ApiMember(DataType="Array<Tag>", Description="Tags applied to this location")]
        public List<Tag> Tags { get; set; }

        ///<summary>
        ///Extended attribute values
        ///</summary>
        [ApiMember(DataType="Array<ExtendedAttributeValue>", Description="Extended attribute values")]
        public IList<ExtendedAttributeValue> ExtendedAttributeValues { get; set; }
    }

    public class LocationDatumPeriod
        : LocationDatumPeriodBase
    {
        ///<summary>
        ///Applied date
        ///</summary>
        [ApiMember(DataType="Instant", Description="Applied date")]
        public Instant AppliedTimeUtc { get; set; }

        ///<summary>
        ///Applied by user
        ///</summary>
        [ApiMember(Description="Applied by user")]
        public string AppliedByUser { get; set; }

        ///<summary>
        ///Reference standard this period is related to
        ///</summary>
        [ApiMember(DataType="StandardReferenceDatum", Description="Reference standard this period is related to")]
        public StandardReferenceDatum ReferenceStandard { get; set; }
    }

    public class LocationDatumPeriodBase
    {
        ///<summary>
        ///Time this period is valid from
        ///</summary>
        [ApiMember(DataType="Instant", Description="Time this period is valid from", IsRequired=true)]
        public Instant ValidFrom { get; set; }

        ///<summary>
        ///Elevation difference from the reference standard
        ///</summary>
        [ApiMember(DataType="double", Description="Elevation difference from the reference standard", IsRequired=true)]
        public double Elevation { get; set; }

        ///<summary>
        ///Direction of positive elevations in relation to the reference standard
        ///</summary>
        [ApiMember(DataType="MeasurementDirection", Description="Direction of positive elevations in relation to the reference standard", IsRequired=true)]
        public MeasurementDirection MeasurementDirection { get; set; }

        ///<summary>
        ///Comment
        ///</summary>
        [ApiMember(Description="Comment")]
        public string Comment { get; set; }
    }

    public class LocationDatumResponse
    {
        public LocationDatumResponse()
        {
            Results = new List<LocationDatumPeriod>{};
        }

        ///<summary>
        ///The list of assumed local datums for the location
        ///</summary>
        [ApiMember(DataType="Array<LocationDatumPeriod>", Description="The list of assumed local datums for the location")]
        public List<LocationDatumPeriod> Results { get; set; }
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

    public class LocationFolderUserRole
    {
        ///<summary>
        ///Unique id of the location folder this role is applied to
        ///</summary>
        [ApiMember(DataType="string", Description="Unique id of the location folder this role is applied to")]
        public Guid? AppliedToLocationFolderUniqueId { get; set; }

        ///<summary>
        ///Name of the location folder this role is applied to
        ///</summary>
        [ApiMember(Description="Name of the location folder this role is applied to")]
        public string AppliedToLocationFolderName { get; set; }

        ///<summary>
        ///True if role is inherited from a parent location folder
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if role is inherited from a parent location folder")]
        public bool InheritedFromParentLocationFolder { get; set; }

        ///<summary>
        ///Unique id of user with this role
        ///</summary>
        [ApiMember(DataType="string", Description="Unique id of user with this role")]
        public Guid UserUniqueId { get; set; }

        ///<summary>
        ///Login name of user with this role
        ///</summary>
        [ApiMember(Description="Login name of user with this role")]
        public string UserLoginName { get; set; }

        ///<summary>
        ///Unique id of the role this user has
        ///</summary>
        [ApiMember(DataType="string", Description="Unique id of the role this user has")]
        public Guid RoleUniqueId { get; set; }

        ///<summary>
        ///Name of the role this user has
        ///</summary>
        [ApiMember(Description="Name of the role this user has")]
        public string RoleName { get; set; }
    }

    public class LocationFolderUserRoles
    {
        public LocationFolderUserRoles()
        {
            Roles = new List<LocationFolderUserRole>{};
        }

        ///<summary>
        ///Unique Id of the location folder
        ///</summary>
        [ApiMember(DataType="string", Description="Unique Id of the location folder")]
        public Guid LocationFolderUniqueId { get; set; }

        ///<summary>
        ///List of user roles applicable to this location folder
        ///</summary>
        [ApiMember(DataType="Array<LocationFolderUserRole>", Description="List of user roles applicable to this location folder")]
        public List<LocationFolderUserRole> Roles { get; set; }
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

        ///<summary>
        ///Extended attribute field definitions for this location type
        ///</summary>
        [ApiMember(DataType="Array<ExtendedAttributeField>", Description="Extended attribute field definitions for this location type")]
        public IList<ExtendedAttributeField> ExtendedAttributeFields { get; set; }
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

    public class LocationUserRole
        : LocationFolderUserRole
    {
        ///<summary>
        ///Unique id of the location this role is applied to
        ///</summary>
        [ApiMember(DataType="string", Description="Unique id of the location this role is applied to")]
        public Guid? AppliedToLocationUniqueId { get; set; }
    }

    public class LocationUserRoles
    {
        public LocationUserRoles()
        {
            Roles = new List<LocationUserRole>{};
        }

        ///<summary>
        ///Unique Id of the location
        ///</summary>
        [ApiMember(DataType="string", Description="Unique Id of the location")]
        public Guid LocationUniqueId { get; set; }

        ///<summary>
        ///List of user roles applicable to this location
        ///</summary>
        [ApiMember(DataType="Array<LocationUserRole>", Description="List of user roles applicable to this location")]
        public List<LocationUserRole> Roles { get; set; }
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
        [ApiMember(DataType="InterpolationType", Description="Interpolation type")]
        public InterpolationType InterpolationType { get; set; }

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

    public class QualifierGroupResponse
    {
        public QualifierGroupResponse()
        {
            QualifierCodeList = new List<string>{};
        }

        ///<summary>
        ///Unique ID of the qualifier group
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the qualifier group")]
        public Guid UniqueId { get; set; }

        ///<summary>
        ///Identifier
        ///</summary>
        [ApiMember(Description="Identifier")]
        public string Identifier { get; set; }

        ///<summary>
        ///Qualifier codes in group
        ///</summary>
        [ApiMember(DataType="Array<string>", Description="Qualifier codes in group")]
        public List<string> QualifierCodeList { get; set; }
    }

    public class QualifierGroupsResponse
    {
        public QualifierGroupsResponse()
        {
            Results = new List<QualifierGroupResponse>{};
        }

        ///<summary>
        ///The list of qualifier groups
        ///</summary>
        [ApiMember(DataType="Array<QualifierGroupResponse>", Description="The list of qualifier groups")]
        public List<QualifierGroupResponse> Results { get; set; }
    }

    public class QualifierResponse
        : QualifierBase
    {
        ///<summary>
        ///Unique ID of the qualifier 
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the qualifier ")]
        public Guid UniqueId { get; set; }

        ///<summary>
        ///True if the qualifier is required by the system
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if the qualifier is required by the system")]
        public bool IsSystem { get; set; }
    }

    public class QualifiersResponse
    {
        public QualifiersResponse()
        {
            Results = new List<QualifierResponse>{};
        }

        ///<summary>
        ///The list of qualifiers
        ///</summary>
        [ApiMember(DataType="Array<QualifierResponse>", Description="The list of qualifiers")]
        public List<QualifierResponse> Results { get; set; }
    }

    public class ReferencePoint
        : ReferencePointBase
    {
        public ReferencePoint()
        {
            ReferencePointPeriods = new List<ReferencePointPeriod>{};
        }

        ///<summary>
        ///Unique ID of the reference point
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the reference point")]
        public Guid UniqueId { get; set; }

        ///<summary>
        ///Periods of applicablity for this reference point
        ///</summary>
        [ApiMember(DataType="Array<ReferencePointPeriod>", Description="Periods of applicablity for this reference point")]
        public List<ReferencePointPeriod> ReferencePointPeriods { get; set; }
    }

    public class ReferencePointPeriod
        : ReferencePointPeriodBase
    {
        ///<summary>
        ///Unique ID of the reference point
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the reference point")]
        public Guid ReferencePointUniqueId { get; set; }

        ///<summary>
        ///Applied date
        ///</summary>
        [ApiMember(DataType="Instant", Description="Applied date")]
        public Instant AppliedTimeUtc { get; set; }

        ///<summary>
        ///Applied by user
        ///</summary>
        [ApiMember(Description="Applied by user")]
        public string AppliedByUser { get; set; }
    }

    public class ReferencePointPeriodBase
    {
        ///<summary>
        ///Time this period is valid from
        ///</summary>
        [ApiMember(DataType="Instant", Description="Time this period is valid from", IsRequired=true)]
        public Instant ValidFrom { get; set; }

        ///<summary>
        ///Standard identifier. Standard reference datum must already be defined in this location
        ///</summary>
        [ApiMember(Description="Standard identifier. Standard reference datum must already be defined in this location")]
        public string StandardIdentifier { get; set; }

        ///<summary>
        ///True if this period is measured against the location's local assumed datum instead of a standard datum
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if this period is measured against the location's local assumed datum instead of a standard datum", IsRequired=true)]
        public bool IsMeasuredAgainstLocalAssumedDatum { get; set; }

        ///<summary>
        ///Elevation of the reference point relative to the standard or local assumed datum
        ///</summary>
        [ApiMember(DataType="double", Description="Elevation of the reference point relative to the standard or local assumed datum", IsRequired=true)]
        public double Elevation { get; set; }

        ///<summary>
        ///Direction of positive elevations in relation to the reference point
        ///</summary>
        [ApiMember(DataType="MeasurementDirection", Description="Direction of positive elevations in relation to the reference point", IsRequired=true)]
        public MeasurementDirection MeasurementDirection { get; set; }

        ///<summary>
        ///Comment
        ///</summary>
        [ApiMember(Description="Comment")]
        public string Comment { get; set; }
    }

    public class ReferencePointResponse
    {
        public ReferencePointResponse()
        {
            Results = new List<ReferencePoint>{};
        }

        ///<summary>
        ///The list of reference points
        ///</summary>
        [ApiMember(DataType="Array<ReferencePoint>", Description="The list of reference points")]
        public List<ReferencePoint> Results { get; set; }
    }

    public class ReportPlugin
    {
        ///<summary>
        ///Unique ID of the registered report plug-in
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the registered report plug-in")]
        public Guid UniqueId { get; set; }

        ///<summary>
        ///Name of the assembly of the report plug-in
        ///</summary>
        [ApiMember(Description="Name of the assembly of the report plug-in")]
        public string AssemblyName { get; set; }

        ///<summary>
        ///Plug-in folder name
        ///</summary>
        [ApiMember(Description="Plug-in folder name")]
        public string FolderName { get; set; }
    }

    public class ReportPluginResponse
    {
        public ReportPluginResponse()
        {
            Results = new List<ReportPlugin>{};
        }

        ///<summary>
        ///The list of registered reports
        ///</summary>
        [ApiMember(DataType="Array<ReportPlugin>", Description="The list of registered reports")]
        public List<ReportPlugin> Results { get; set; }
    }

    public class Role
    {
        public Role()
        {
            RoleApprovalTransitions = new List<RoleApprovalTransition>{};
        }

        ///<summary>
        ///Unique Id of the role
        ///</summary>
        [ApiMember(DataType="string", Description="Unique Id of the role")]
        public Guid UniqueId { get; set; }

        ///<summary>
        ///Name
        ///</summary>
        [ApiMember(Description="Name")]
        public string Name { get; set; }

        ///<summary>
        ///List of approval transitions this role grants permission to perform.
        ///</summary>
        [ApiMember(DataType="Array<RoleApprovalTransition>", Description="List of approval transitions this role grants permission to perform.")]
        public List<RoleApprovalTransition> RoleApprovalTransitions { get; set; }

        ///<summary>
        ///True if role grants permission to: Read data and generate reports.
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if role grants permission to: Read data and generate reports.")]
        public bool CanReadData { get; set; }

        ///<summary>
        ///True if role grants permission to: Add data. Includes appending logger data, creating/editing field visits, and uploading attachments.
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if role grants permission to: Add data. Includes appending logger data, creating/editing field visits, and uploading attachments.")]
        public bool CanAddData { get; set; }

        ///<summary>
        ///True if role grants permission to: Edit data. Includes making corrections to time series; editing curves and shifts within a rating model.
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if role grants permission to: Edit data. Includes making corrections to time series; editing curves and shifts within a rating model.")]
        public bool CanEditData { get; set; }

        ///<summary>
        ///True if role grants permission to: Edit location properties and derivations. Includes creating and editing time series, rating models, process settings.
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if role grants permission to: Edit location properties and derivations. Includes creating and editing time series, rating models, process settings.")]
        public bool CanEditLocationDetails { get; set; }

        ///<summary>
        ///True if role grants permission to: Add and remove locations.
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if role grants permission to: Add and remove locations.")]
        public bool CanAddOrRemoveLocations { get; set; }

        ///<summary>
        ///True if role grants permission to: Assign user roles for folders and locations.
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if role grants permission to: Assign user roles for folders and locations.")]
        public bool CanAssignUserRoles { get; set; }

        ///<summary>
        ///True if role grants permission to: Remove field visits.
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if role grants permission to: Remove field visits.")]
        public bool CanRemoveFieldVisits { get; set; }
    }

    public class RoleApprovalTransition
    {
        ///<summary>
        ///Approval level of data before permitted transition.
        ///</summary>
        [ApiMember(DataType="long integer", Description="Approval level of data before permitted transition.", IsRequired=true)]
        public long? FromApprovalLevel { get; set; }

        ///<summary>
        ///Approval level of data after permitted transition.
        ///</summary>
        [ApiMember(DataType="long integer", Description="Approval level of data after permitted transition.", IsRequired=true)]
        public long? ToApprovalLevel { get; set; }
    }

    public class RoleFlattened
        : RoleFlattenedBase
    {
        ///<summary>
        ///Unique Id of the role
        ///</summary>
        [ApiMember(DataType="string", Description="Unique Id of the role")]
        public Guid UniqueId { get; set; }
    }

    public class RolesResponse
    {
        public RolesResponse()
        {
            Results = new List<Role>{};
        }

        ///<summary>
        ///The list of roles
        ///</summary>
        [ApiMember(DataType="Array<Role>", Description="The list of roles")]
        public List<Role> Results { get; set; }
    }

    public class Setting
    {
        ///<summary>
        ///Setting group
        ///</summary>
        [ApiMember(Description="Setting group")]
        public string Group { get; set; }

        ///<summary>
        ///Setting key
        ///</summary>
        [ApiMember(Description="Setting key")]
        public string Key { get; set; }

        ///<summary>
        ///Setting value
        ///</summary>
        [ApiMember(Description="Setting value")]
        public string Value { get; set; }

        ///<summary>
        ///Setting description
        ///</summary>
        [ApiMember(Description="Setting description")]
        public string Description { get; set; }

        ///<summary>
        ///True if the unit is required by the system
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if the unit is required by the system")]
        public bool IsSystem { get; set; }

        ///<summary>
        ///Last modified time
        ///</summary>
        [ApiMember(DataType="Instant", Description="Last modified time")]
        public Instant LastModifiedTime { get; set; }
    }

    public class SettingsResponse
    {
        public SettingsResponse()
        {
            Results = new List<Setting>{};
        }

        ///<summary>
        ///The list of settings
        ///</summary>
        [ApiMember(DataType="Array<Setting>", Description="The list of settings")]
        public List<Setting> Results { get; set; }
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

    public class StandardReferenceDatum
    {
        ///<summary>
        ///Unique ID of the Location
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the Location")]
        public Guid LocationUniqueId { get; set; }

        ///<summary>
        ///StandardIdentifier
        ///</summary>
        [ApiMember(Description="StandardIdentifier")]
        public string StandardIdentifier { get; set; }

        ///<summary>
        ///True if the Standard Reference Datum is the Base Reference
        ///</summary>
        [ApiMember(DataType="boolean", Description="True if the Standard Reference Datum is the Base Reference")]
        public bool IsBaseReference { get; set; }

        ///<summary>
        ///Offset in relation to the Base Reference. Not used if IsBaseReference is set to true
        ///</summary>
        [ApiMember(DataType="double", Description="Offset in relation to the Base Reference. Not used if IsBaseReference is set to true")]
        public double? OffsetToBaseReference { get; set; }
    }

    public class StandardReferenceDatumsResponse
    {
        public StandardReferenceDatumsResponse()
        {
            Results = new List<StandardReferenceDatum>{};
        }

        ///<summary>
        ///The list of Standard Reference Datums
        ///</summary>
        [ApiMember(DataType="Array<StandardReferenceDatum>", Description="The list of Standard Reference Datums")]
        public List<StandardReferenceDatum> Results { get; set; }
    }

    public class Tag
    {
        ///<summary>
        ///Unique ID of the tag
        ///</summary>
        [ApiMember(DataType="string", Description="Unique ID of the tag")]
        public Guid UniqueId { get; set; }

        ///<summary>
        ///Name
        ///</summary>
        [ApiMember(Description="Name")]
        public string Name { get; set; }
    }

    public class TagsResponse
    {
        public TagsResponse()
        {
            Results = new List<Tag>{};
        }

        ///<summary>
        ///The list of tags
        ///</summary>
        [ApiMember(DataType="Array<Tag>", Description="The list of tags")]
        public List<Tag> Results { get; set; }
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
        [ApiMember(DataType="Array<ExtendedAttributeValue>", Description="Extended attribute values")]
        public IList<ExtendedAttributeValue> ExtendedAttributeValues { get; set; }
    }

    public class TimeSeriesResponse
    {
        public TimeSeriesResponse()
        {
            Results = new List<TimeSeries>{};
        }

        ///<summary>
        ///The list of time series
        ///</summary>
        [ApiMember(DataType="Array<TimeSeries>", Description="The list of time series")]
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

namespace Aquarius.TimeSeries.Client.ServiceModels.Provisioning
{
    public static class Current
    {
        public static readonly AquariusServerVersion Version = AquariusServerVersion.Create("19.1.110.0");
    }
}
