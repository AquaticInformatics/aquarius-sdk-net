// Date: 2021-02-16T09:38:54.5964724-08:00
// Base URL: https://demo.aqsamples.com/api/swagger.json
// Source: AQUARIUS Samples API (2020.06.4163)

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ServiceStack;
using NodaTime;
using Aquarius.TimeSeries.Client;
// ReSharper disable InconsistentNaming

// ReSharper disable once CheckNamespace
namespace Aquarius.Samples.Client.ServiceModel
{
    public static class Current
    {
        public static readonly AquariusServerVersion Version = AquariusServerVersion.Create("2020.06.4163");
    }

    [Route("/v1/accessgroups", "GET")]
    public class GetAccessGroups : IReturn<SearchResultAccessGroup>
    {
        
    }

    [Route("/v1/accessgroups", "POST")]
    public class PostAccessGroup : IReturn<AccessGroup>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? CanEditAllData { get; set; }
        public List<SamplingLocationGroup> SamplingLocationGroups { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/accessgroups/{id}", "GET")]
    public class GetAccessGroup : IReturn<AccessGroup>
    {
        public string Id { get; set; }
    }

    [Route("/v1/accessgroups/{id}", "PUT")]
    public class PutAccessGroup : IReturn<AccessGroup>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? CanEditAllData { get; set; }
        public List<SamplingLocationGroup> SamplingLocationGroups { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/accessgroups/{id}", "DELETE")]
    public class DeleteAccessGroup : IReturnVoid
    {
        public string Id { get; set; }
    }

    [Route("/v1/accessgroups/{id}/history", "GET")]
    public class GetAccessGroupHistory : IReturn<SearchResultAuditHistory>
    {
        public string Id { get; set; }
    }

    [Route("/v1/activities", "GET")]
    public class GetActivities : IReturn<SearchResultActivity>, IPaginatedRequest
    {
        public List<string> ActivityTemplateId { get; set; }
        public List<string> ActivityTypes { get; set; }
        public List<string> CollectionMethodIds { get; set; }
        public string Cursor { get; set; }
        public string CustomId { get; set; }
        public string FieldVisitId { get; set; }
        public Instant? FromStartTime { get; set; }
        public List<string> Ids { get; set; }
        public int? Limit { get; set; }
        public List<string> Media { get; set; }
        public List<string> ProjectIds { get; set; }
        public List<string> SamplingLocationIds { get; set; }
        public string Sort { get; set; }
        public Instant? ToStartTime { get; set; }
    }

    [Route("/v1/activities", "POST")]
    public class PostActivity : IReturn<Activity>
    {
        public ActivityType? Type { get; set; }
        public string Id { get; set; }
        public string CustomId { get; set; }
        public string ReplicateSourceActivityId { get; set; }
        public string SourceActivityId { get; set; }
        public Instant? StartTime { get; set; }
        public Instant? EndTime { get; set; }
        public string Comment { get; set; }
        public string LoggerFileName { get; set; }
        public Device Device { get; set; }
        public CollectionMethod CollectionMethod { get; set; }
        public Medium Medium { get; set; }
        public PlannedActivity PlannedActivity { get; set; }
        public Quantity Depth { get; set; }
        public SamplingLocation SamplingLocation { get; set; }
        public FieldVisit FieldVisit { get; set; }
        public List<SamplingContextTag> SamplingContextTags { get; set; }
        public List<ExtendedAttribute> ExtendedAttributes { get; set; }
        public bool? Refreshed { get; set; }
        public bool? Blank { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/activities", "DELETE")]
    public class DeleteActivities : IReturnVoid
    {
        public List<string> ActivityTemplateId { get; set; }
        public List<string> ActivityTypes { get; set; }
        public List<string> CollectionMethodIds { get; set; }
        public string Cursor { get; set; }
        public string CustomId { get; set; }
        public string FieldVisitId { get; set; }
        public Instant? FromStartTime { get; set; }
        public List<string> Ids { get; set; }
        public int? Limit { get; set; }
        public List<string> Media { get; set; }
        public List<string> ProjectIds { get; set; }
        public List<string> SamplingLocationIds { get; set; }
        public string Sort { get; set; }
        public Instant? ToStartTime { get; set; }
    }

    [Route("/v1/activities/{id}", "GET")]
    public class GetActivity : IReturn<ActivityWithDetails>
    {
        public string Id { get; set; }
        public bool? Detail { get; set; }
    }

    [Route("/v1/activities/{id}", "PUT")]
    public class PutActivity : IReturn<ActivityWithDetails>
    {
        public string Id { get; set; }
        public bool? Detail { get; set; }
        public ActivityWithDetailsType? Type { get; set; }
        public string CustomId { get; set; }
        public string ReplicateSourceActivityId { get; set; }
        public string SourceActivityId { get; set; }
        public Instant? StartTime { get; set; }
        public Instant? EndTime { get; set; }
        public string Comment { get; set; }
        public string LoggerFileName { get; set; }
        public Device Device { get; set; }
        public CollectionMethod CollectionMethod { get; set; }
        public Medium Medium { get; set; }
        public PlannedActivity PlannedActivity { get; set; }
        public Quantity Depth { get; set; }
        public SamplingLocation SamplingLocation { get; set; }
        public FieldVisit FieldVisit { get; set; }
        public List<SamplingContextTag> SamplingContextTags { get; set; }
        public List<ExtendedAttribute> ExtendedAttributes { get; set; }
        public IndexConfiguration IndexConfiguration { get; set; }
        public List<MetricResult> MetricResults { get; set; }
        public List<SpecimenNestedInActivity> Specimens { get; set; }
        public List<ObservationMinimal> Observations { get; set; }
        public bool? Refreshed { get; set; }
        public bool? Blank { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/activities/{id}", "DELETE")]
    public class DeleteActivity : IReturnVoid
    {
        public string Id { get; set; }
    }

    [Route("/v1/activities/{id}/history", "GET")]
    public class GetActivityHistory : IReturn<SearchResultAuditHistory>
    {
        public string Id { get; set; }
    }

    [Route("/v1/activities/{id}/replicate", "POST")]
    public class PostActivityReplicate : IReturn<Activity>
    {
        public string Id { get; set; }
    }

    [Route("/v1/activitytemplates", "GET")]
    public class GetActivityTemplates : IReturn<SearchResultActivityTemplate>
    {
        public List<string> Type { get; set; }
    }

    [Route("/v1/activitytemplates", "POST")]
    public class PostActivityTemplate : IReturn<ActivityTemplate>
    {
        public string Id { get; set; }
        public List<SpecimenTemplate> SpecimenTemplates { get; set; }
        public string CustomId { get; set; }
        public ActivityTemplateType? Type { get; set; }
        public string Comment { get; set; }
        public MediumType? Medium { get; set; }
        public Quantity Depth { get; set; }
        public CollectionMethod CollectionMethod { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/activitytemplates/{id}", "GET")]
    public class GetActivityTemplate : IReturn<ActivityTemplate>
    {
        public string Id { get; set; }
    }

    [Route("/v1/activitytemplates/{id}", "PUT")]
    public class PutActivityTemplate : IReturn<ActivityTemplate>
    {
        public string Id { get; set; }
        public List<SpecimenTemplate> SpecimenTemplates { get; set; }
        public string CustomId { get; set; }
        public ActivityTemplateType? Type { get; set; }
        public string Comment { get; set; }
        public MediumType? Medium { get; set; }
        public Quantity Depth { get; set; }
        public CollectionMethod CollectionMethod { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/activitytemplates/{id}", "DELETE")]
    public class DeleteActivityTemplate : IReturnVoid
    {
        public string Id { get; set; }
    }

    [Route("/v1/activitytemplates/{id}/history", "GET")]
    public class GetActivityTemplateHistory : IReturn<SearchResultAuditHistory>
    {
        public string Id { get; set; }
    }

    [Route("/v1/analysismethods", "GET")]
    public class GetAnalysisMethods : IReturn<SearchResultAnalysisMethod>
    {
        public string Context { get; set; }
        public List<string> ObservedPropertyIds { get; set; }
    }

    [Route("/v1/analysismethods", "POST")]
    public class PostAnalysisMethod : IReturn<AnalysisMethod>
    {
        public string Id { get; set; }
        public string MethodId { get; set; }
        public string Name { get; set; }
        public string Context { get; set; }
        public string Description { get; set; }
        public List<ObservedProperty> ObservedProperties { get; set; }
        public List<ImportHistoryEventSimple> ImportHistoryEventSimples { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/analysismethods/{id}", "GET")]
    public class GetAnalysisMethod : IReturn<AnalysisMethod>
    {
        public string Id { get; set; }
    }

    [Route("/v1/analysismethods/{id}", "PUT")]
    public class PutAnalysisMethod : IReturn<AnalysisMethod>
    {
        public string Id { get; set; }
        public string MethodId { get; set; }
        public string Name { get; set; }
        public string Context { get; set; }
        public string Description { get; set; }
        public List<ObservedProperty> ObservedProperties { get; set; }
        public List<ImportHistoryEventSimple> ImportHistoryEventSimples { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/analysismethods/{id}", "DELETE")]
    public class DeleteAnalysisMethod : IReturnVoid
    {
        public string Id { get; set; }
    }

    [Route("/v1/analysismethods/{id}/history", "GET")]
    public class GetAnalysisMethodHistory : IReturn<SearchResultAuditHistory>
    {
        public string Id { get; set; }
    }

    [Route("/v1/analyticalgroups", "GET")]
    public class GetAnalyticalGroups : IReturn<SearchResultAnalyticalGroup>
    {
        public List<string> AnalyticalGroupTypes { get; set; }
        public List<string> ObservedPropertyIds { get; set; }
    }

    [Route("/v1/analyticalgroups", "POST")]
    public class PostAnalyticalGroup : IReturn<AnalyticalGroup>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public AnalyticalGroupType? Type { get; set; }
        public int? NumberOfObservedPropertiesInGroupItems { get; set; }
        public int? NumberOfAnalysisMethodsInGroupItems { get; set; }
        public List<AnalyticalGroupItem> AnalyticalGroupItems { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/analyticalgroups/{id}", "GET")]
    public class GetAnalyticalGroup : IReturn<AnalyticalGroup>
    {
        public string Id { get; set; }
    }

    [Route("/v1/analyticalgroups/{id}", "PUT")]
    public class PutAnalyticalGroup : IReturn<AnalyticalGroup>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public AnalyticalGroupType? Type { get; set; }
        public int? NumberOfObservedPropertiesInGroupItems { get; set; }
        public int? NumberOfAnalysisMethodsInGroupItems { get; set; }
        public List<AnalyticalGroupItem> AnalyticalGroupItems { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/analyticalgroups/{id}", "DELETE")]
    public class DeleteAnalyticalGroup : IReturnVoid
    {
        public string Id { get; set; }
    }

    [Route("/v1/analyticalgroups/{id}/history", "GET")]
    public class GetAnalyticalGroupHistory : IReturn<SearchResultAuditHistory>
    {
        public string Id { get; set; }
    }

    [Route("/v1/attachments/{id}", "GET")]
    public class GetAttachment : IReturn<Attachment>
    {
        public string Id { get; set; }
    }

    [Route("/v1/attachments/{id}", "PUT")]
    public class PutAttachment : IReturn<Attachment>
    {
        public string Id { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public string Comment { get; set; }
        public long? FileSize { get; set; }
        public Instant? DateTaken { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Resolution { get; set; }
        public AuditAttributesFull AuditAttributes { get; set; }
    }

    [Route("/v1/attachments/{id}", "DELETE")]
    public class DeleteAttachment : IReturnVoid
    {
        public string Id { get; set; }
    }

    [Route("/v1/attachments/{id}/contents", "GET")]
    public class GetAttachmentContents : IReturnVoid
    {
        public string Id { get; set; }
    }

    [Route("/v1/attachments/upload", "POST")]
    public class PostUploadAttachment : IReturn<AttachmentRepresentation>
    {
        
    }

    [Route("/v1/collectionmethods", "GET")]
    public class GetCollectionMethods : IReturn<SearchResultCollectionMethod>
    {
        
    }

    [Route("/v1/collectionmethods", "POST")]
    public class PostCollectionMethod : IReturn<CollectionMethod>
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public string IdentifierOrganization { get; set; }
        public string Name { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/collectionmethods/{id}", "GET")]
    public class GetCollectionMethod : IReturn<CollectionMethod>
    {
        public string Id { get; set; }
    }

    [Route("/v1/collectionmethods/{id}", "PUT")]
    public class PutCollectionMethod : IReturn<CollectionMethod>
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public string IdentifierOrganization { get; set; }
        public string Name { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/collectionmethods/{id}", "DELETE")]
    public class DeleteCollectionMethod : IReturnVoid
    {
        public string Id { get; set; }
    }

    [Route("/v1/collectionmethods/{id}/history", "GET")]
    public class GetCollectionMethodHistory : IReturn<SearchResultAuditHistory>
    {
        public string Id { get; set; }
    }

    [Route("/v1/detectionconditions", "GET")]
    public class GetDetectionconditions : IReturn<SearchResultResultDetectionCondition>
    {
        
    }

    [Route("/v1/detectionconditions", "POST")]
    public class PostDetectioncondition : IReturn<ResultDetectionCondition>
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SystemCode { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/detectionconditions/{id}", "GET")]
    public class GetDetectioncondition : IReturn<ResultDetectionCondition>
    {
        public string Id { get; set; }
    }

    [Route("/v1/detectionconditions/{id}", "PUT")]
    public class PutDetectioncondition : IReturn<ResultDetectionCondition>
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SystemCode { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/detectionconditions/{id}", "DELETE")]
    public class DeleteDetectioncondition : IReturnVoid
    {
        public string Id { get; set; }
    }

    [Route("/v1/detectionconditions/{id}/history", "GET")]
    public class GetDetectionconditionHistory : IReturn<SearchResultAuditHistory>
    {
        public string Id { get; set; }
    }

    [Route("/v1/extendedattributes", "GET")]
    public class GetExtendedAttributes : IReturn<SearchResultExtendedAttributeDefinition>
    {
        
    }

    [Route("/v1/extendedattributes", "POST")]
    public class PostExtendedAttribute : IReturn<ExtendedAttributeDefinition>
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public string Description { get; set; }
        public DataType? DataType { get; set; }
        public AppliesToType? AppliesToType { get; set; }
        public string DefaultValue { get; set; }
        public List<ExtendedAttributeListItem> DropDownListItems { get; set; }
        public bool? Mandatory { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/extendedattributes/{id}", "GET")]
    public class GetExtendedAttribute : IReturn<ExtendedAttributeDefinition>
    {
        public string Id { get; set; }
        public bool? Detail { get; set; }
    }

    [Route("/v1/extendedattributes/{id}", "PUT")]
    public class PutExtendedAttribute : IReturn<ExtendedAttributeDefinition>
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public string Description { get; set; }
        public DataType? DataType { get; set; }
        public AppliesToType? AppliesToType { get; set; }
        public string DefaultValue { get; set; }
        public List<ExtendedAttributeListItem> DropDownListItems { get; set; }
        public bool? Mandatory { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/extendedattributes/{id}", "DELETE")]
    public class DeleteExtendedAttribute : IReturnVoid
    {
        public string Id { get; set; }
    }

    [Route("/v1/extendedattributes/{id}/dropdownlistitems", "GET")]
    public class GetExtendedAttributeDropdownlistitems : IReturn<SearchResultExtendedAttributeListItem>
    {
        public string Id { get; set; }
    }

    [Route("/v1/extendedattributes/{id}/dropdownlistitems/{dropDownListItemId}", "GET")]
    public class GetExtendedAttributeDropdownlistitemListItem : IReturn<ExtendedAttributeListItem>
    {
        public string Id { get; set; }
        public string DropDownListItemId { get; set; }
    }

    [Route("/v1/extendedattributes/{id}/history", "GET")]
    public class GetExtendedAttributeHistory : IReturn<SearchResultAuditHistory>
    {
        public string Id { get; set; }
    }

    [Route("/v1/fieldtrips", "GET")]
    public class GetFieldTrips : IReturn<SearchResultFieldTripBasic>
    {
        public int? Limit { get; set; }
        public List<string> Search { get; set; }
    }

    [Route("/v1/fieldtrips", "POST")]
    public class PostFieldTrip : IReturn<FieldTrip>
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public Instant? StartTime { get; set; }
        public Instant? EndTime { get; set; }
        public string Participants { get; set; }
        public string Notes { get; set; }
        public List<DomainObjectAttachment> Attachments { get; set; }
        public List<FieldVisit> FieldVisits { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/fieldtrips/{id}", "GET")]
    public class GetFieldTrip : IReturn<FieldTrip>
    {
        public string Id { get; set; }
    }

    [Route("/v1/fieldtrips/{id}", "PUT")]
    public class PutFieldTrip : IReturn<FieldTrip>
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public Instant? StartTime { get; set; }
        public Instant? EndTime { get; set; }
        public string Participants { get; set; }
        public string Notes { get; set; }
        public List<DomainObjectAttachment> Attachments { get; set; }
        public List<FieldVisit> FieldVisits { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/fieldtrips/{id}", "DELETE")]
    public class DeleteFieldTrip : IReturnVoid
    {
        public string Id { get; set; }
    }

    [Route("/v1/fieldtrips/{id}/history", "GET")]
    public class GetFieldTripHistory : IReturn<SearchResultAuditHistory>
    {
        public string Id { get; set; }
    }

    [DataContract]
    [Route("/v1/fieldvisits", "GET")]
    public class GetFieldVisits : IReturn<SearchResultFieldVisitSimple>, IPaginatedRequest
    {
        [DataMember(Name = "cursor")]
        public string Cursor { get; set; }
        [DataMember(Name = "end-startTime")]
        public Instant? EndStartTime { get; set; }
        [DataMember(Name = "fieldTripIds")]
        public List<string> FieldTripIds { get; set; }
        [DataMember(Name = "ids")]
        public List<string> Ids { get; set; }
        [DataMember(Name = "limit")]
        public int? Limit { get; set; }
        [DataMember(Name = "planningStatuses")]
        public List<string> PlanningStatuses { get; set; }
        [DataMember(Name = "projectIds")]
        public List<string> ProjectIds { get; set; }
        [DataMember(Name = "samplingLocationIds")]
        public List<string> SamplingLocationIds { get; set; }
        [DataMember(Name = "scheduleIds")]
        public List<string> ScheduleIds { get; set; }
        [DataMember(Name = "search")]
        public List<string> Search { get; set; }
        [DataMember(Name = "sort")]
        public string Sort { get; set; }
        [DataMember(Name = "start-startTime")]
        public Instant? StartStartTime { get; set; }
    }

    [Route("/v1/fieldvisits", "POST")]
    public class PostFieldVisit : IReturn<FieldVisit>
    {
        public string Id { get; set; }
        public Instant? StartTime { get; set; }
        public Instant? EndTime { get; set; }
        public string Participants { get; set; }
        public string Notes { get; set; }
        public FieldTripSimple FieldTrip { get; set; }
        public ProjectSimple Project { get; set; }
        public PlanningStatusType? PlanningStatus { get; set; }
        public SamplingLocation SamplingLocation { get; set; }
        public List<PlannedFieldResult> PlannedFieldResults { get; set; }
        public List<PlannedActivity> PlannedActivities { get; set; }
        public List<DomainObjectAttachment> Attachments { get; set; }
        public List<ExtendedAttribute> ExtendedAttributes { get; set; }
        public Schedule Schedule { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [DataContract]
    [Route("/v1/fieldvisits", "DELETE")]
    public class DeleteFieldVisits : IReturnVoid
    {
        [DataMember(Name = "cursor")]
        public string Cursor { get; set; }
        [DataMember(Name = "end-startTime")]
        public Instant? EndStartTime { get; set; }
        [DataMember(Name = "fieldTripIds")]
        public List<string> FieldTripIds { get; set; }
        [DataMember(Name = "ids")]
        public List<string> Ids { get; set; }
        [DataMember(Name = "limit")]
        public int? Limit { get; set; }
        [DataMember(Name = "planningStatuses")]
        public List<string> PlanningStatuses { get; set; }
        [DataMember(Name = "projectIds")]
        public List<string> ProjectIds { get; set; }
        [DataMember(Name = "samplingLocationIds")]
        public List<string> SamplingLocationIds { get; set; }
        [DataMember(Name = "scheduleIds")]
        public List<string> ScheduleIds { get; set; }
        [DataMember(Name = "search")]
        public List<string> Search { get; set; }
        [DataMember(Name = "sort")]
        public string Sort { get; set; }
        [DataMember(Name = "start-startTime")]
        public Instant? StartStartTime { get; set; }
    }

    [Route("/v1/fieldvisits/{fieldVisitId}/addorupdateindex", "PUT")]
    public class PutAddOrUpdateIndex : IReturn<ActivityWithDetails>
    {
        public string FieldVisitId { get; set; }
        public string IndexConfigId { get; set; }
    }

    [Route("/v1/fieldvisits/{id}", "GET")]
    public class GetFieldVisit : IReturn<FieldVisit>
    {
        public string Id { get; set; }
    }

    [Route("/v1/fieldvisits/{id}", "PUT")]
    public class PutFieldVisit : IReturn<FieldVisit>
    {
        public string Id { get; set; }
        public Instant? StartTime { get; set; }
        public Instant? EndTime { get; set; }
        public string Participants { get; set; }
        public string Notes { get; set; }
        public FieldTripSimple FieldTrip { get; set; }
        public ProjectSimple Project { get; set; }
        public PlanningStatusType? PlanningStatus { get; set; }
        public SamplingLocation SamplingLocation { get; set; }
        public List<PlannedFieldResult> PlannedFieldResults { get; set; }
        public List<PlannedActivity> PlannedActivities { get; set; }
        public List<DomainObjectAttachment> Attachments { get; set; }
        public List<ExtendedAttribute> ExtendedAttributes { get; set; }
        public Schedule Schedule { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/fieldvisits/{id}", "DELETE")]
    public class DeleteFieldVisit : IReturnVoid
    {
        public string Id { get; set; }
    }

    [Route("/v1/fieldvisits/{id}/activityfromplannedactivity", "POST")]
    public class PostFieldVisitActivityFromPlannedActivity : IReturn<Activity>
    {
        public string Id { get; set; }
        public ActivityTemplate ActivityTemplate { get; set; }
        public string Instruction { get; set; }
        public PlannedActivityActivityType? ActivityType { get; set; }
        public MediumType? Medium { get; set; }
        public CollectionMethod CollectionMethod { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/fieldvisits/{id}/activitywithtemplate", "POST")]
    public class PostFieldVisitActivityWithTemplate : IReturn<Activity>
    {
        public string Id { get; set; }
        public List<SpecimenTemplate> SpecimenTemplates { get; set; }
        public string CustomId { get; set; }
        public ActivityTemplateType? Type { get; set; }
        public string Comment { get; set; }
        public MediumType? Medium { get; set; }
        public Quantity Depth { get; set; }
        public CollectionMethod CollectionMethod { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/fieldvisits/{id}/attachments", "GET")]
    public class GetFieldVisitAttachments : IReturn<SearchResultAttachment>
    {
        public string Id { get; set; }
    }

    [Route("/v1/fieldvisits/{id}/history", "GET")]
    public class GetFieldVisitHistory : IReturn<SearchResultAuditHistory>
    {
        public string Id { get; set; }
    }

    [Route("/v1/fieldvisits/{id}/statistics", "GET")]
    public class GetFieldVisitStatistics : IReturn<FieldVisitStatistics>
    {
        public string Id { get; set; }
    }

    [Route("/v1/filters", "GET")]
    public class GetFilters : IReturn<SearchResultFilter>
    {
        
    }

    [Route("/v1/filters", "POST")]
    public class PostFilter : IReturn<Filter>
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public Instant? StartTime { get; set; }
        public Instant? EndTime { get; set; }
        public List<ObservedProperty> ObservedProperties { get; set; }
        public List<SamplingLocation> SamplingLocations { get; set; }
        public string Description { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/filters/{id}", "GET")]
    public class GetFilter : IReturn<Filter>
    {
        public string Id { get; set; }
    }

    [Route("/v1/filters/{id}", "PUT")]
    public class PutFilter : IReturn<Filter>
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public Instant? StartTime { get; set; }
        public Instant? EndTime { get; set; }
        public List<ObservedProperty> ObservedProperties { get; set; }
        public List<SamplingLocation> SamplingLocations { get; set; }
        public string Description { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/filters/{id}", "DELETE")]
    public class DeleteFilter : IReturnVoid
    {
        public string Id { get; set; }
    }

    [Route("/v1/filters/{id}/history", "GET")]
    public class GetFilterHistory : IReturn<SearchResultAuditHistory>
    {
        public string Id { get; set; }
    }

    [Route("/v1/labanalysismethods", "GET")]
    public class GetLabAnalysisMethods : IReturn<SearchResultAnalysisMethod>
    {
        public string Context { get; set; }
        public List<string> ObservedPropertyIds { get; set; }
    }

    [Route("/v1/labanalysismethods", "POST")]
    public class PostLabAnalysisMethod : IReturn<AnalysisMethod>
    {
        public string Id { get; set; }
        public string MethodId { get; set; }
        public string Name { get; set; }
        public string Context { get; set; }
        public string Description { get; set; }
        public List<ObservedProperty> ObservedProperties { get; set; }
        public List<ImportHistoryEventSimple> ImportHistoryEventSimples { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/labanalysismethods/{id}", "GET")]
    public class GetLabAnalysisMethod : IReturn<AnalysisMethod>
    {
        public string Id { get; set; }
    }

    [Route("/v1/labanalysismethods/{id}", "PUT")]
    public class PutLabAnalysisMethod : IReturn<AnalysisMethod>
    {
        public string Id { get; set; }
        public string MethodId { get; set; }
        public string Name { get; set; }
        public string Context { get; set; }
        public string Description { get; set; }
        public List<ObservedProperty> ObservedProperties { get; set; }
        public List<ImportHistoryEventSimple> ImportHistoryEventSimples { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/labanalysismethods/{id}", "DELETE")]
    public class DeleteLabAnalysisMethod : IReturnVoid
    {
        public string Id { get; set; }
    }

    [Route("/v1/labanalysismethods/{id}/history", "GET")]
    public class GetLabAnalysisMethodHistory : IReturn<SearchResultAuditHistory>
    {
        public string Id { get; set; }
    }

    [Route("/v1/laboratories", "GET")]
    public class GetLaboratories : IReturn<SearchResultLaboratory>
    {
        
    }

    [Route("/v1/laboratories", "POST")]
    public class PostLaboratory : IReturn<Laboratory>
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string PointOfContact { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/laboratories/{id}", "GET")]
    public class GetLaboratory : IReturn<Laboratory>
    {
        public string Id { get; set; }
    }

    [Route("/v1/laboratories/{id}", "PUT")]
    public class PutLaboratory : IReturn<Laboratory>
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string PointOfContact { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/laboratories/{id}", "DELETE")]
    public class DeleteLaboratory : IReturnVoid
    {
        public string Id { get; set; }
    }

    [Route("/v1/laboratories/{id}/history", "GET")]
    public class GetLaboratoryHistory : IReturn<SearchResultAuditHistory>
    {
        public string Id { get; set; }
    }

    [Route("/v1/labreportimporthistoryevents", "GET")]
    public class GetLabReportImportHistoryEvents : IReturn<SearchResultLabReportImportHistoryEvent>, IPaginatedRequest
    {
        public string Cursor { get; set; }
        public List<string> LabReportIds { get; set; }
        public int? Limit { get; set; }
        public string Sort { get; set; }
    }

    [Route("/v1/labreports", "GET")]
    public class GetLabReports : IReturn<SearchResultLabReport>
    {
        public string CustomId { get; set; }
        public List<string> LaboratoryIds { get; set; }
        public int? Limit { get; set; }
        public List<string> Search { get; set; }
    }

    [Route("/v1/labreports", "POST")]
    public class PostLabReport : IReturn<LabReport>
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public Instant? DateReceived { get; set; }
        public string CaseNarrative { get; set; }
        public string QcSummary { get; set; }
        public Laboratory Laboratory { get; set; }
        public List<ImportHistoryEventSimple> ImportHistoryEventSimples { get; set; }
        public List<DomainObjectAttachment> Attachments { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/labreports/{id}", "GET")]
    public class GetLabReport : IReturn<LabReport>
    {
        public string Id { get; set; }
    }

    [Route("/v1/labreports/{id}", "PUT")]
    public class PutLabReport : IReturn<LabReport>
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public Instant? DateReceived { get; set; }
        public string CaseNarrative { get; set; }
        public string QcSummary { get; set; }
        public Laboratory Laboratory { get; set; }
        public List<ImportHistoryEventSimple> ImportHistoryEventSimples { get; set; }
        public List<DomainObjectAttachment> Attachments { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/labreports/{id}", "DELETE")]
    public class DeleteLabReport : IReturnVoid
    {
        public string Id { get; set; }
    }

    [Route("/v1/labreports/{id}/history", "GET")]
    public class GetLabReportHistory : IReturn<SearchResultAuditHistory>
    {
        public string Id { get; set; }
    }

    [Route("/v1/mediums", "GET")]
    public class GetMediums : IReturn<SearchResultMedium>
    {
        
    }

    [Route("/v1/mediums", "PUT")]
    public class PutMediums : IReturn<List<Medium>>
    {
        
    }

    [Route("/v1/mediums/{id}/history", "GET")]
    public class GetMediumHistory : IReturn<SearchResultAuditHistory>
    {
        public string Id { get; set; }
    }

    [Route("/v1/nullmeasurequalifiers", "GET")]
    public class GetNullMeasureQualifiers : IReturn<SearchResultNullMeasureQualifier>
    {
        
    }

    [Route("/v1/nullmeasurequalifiers", "POST")]
    public class PostNullMeasureQualifier : IReturn<NullMeasureQualifier>
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/nullmeasurequalifiers/{id}", "GET")]
    public class GetNullMeasureQualifier : IReturn<NullMeasureQualifier>
    {
        public string Id { get; set; }
    }

    [Route("/v1/nullmeasurequalifiers/{id}", "PUT")]
    public class PutNullMeasureQualifier : IReturn<NullMeasureQualifier>
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/nullmeasurequalifiers/{id}", "DELETE")]
    public class DeleteNullMeasureQualifier : IReturnVoid
    {
        public string Id { get; set; }
    }

    [Route("/v1/nullmeasurequalifiers/{id}/history", "GET")]
    public class GetNullMeasureQualifierHistory : IReturn<SearchResultAuditHistory>
    {
        public string Id { get; set; }
    }

    [DataContract]
    [Route("/v1/observations", "GET")]
    public class GetObservations : IReturn<SearchResultObservation>, IPaginatedRequest
    {
        [DataMember(Name = "activityCustomId")]
        public string ActivityCustomId { get; set; }
        [DataMember(Name = "activityIds")]
        public List<string> ActivityIds { get; set; }
        [DataMember(Name = "activityTypes")]
        public List<string> ActivityTypes { get; set; }
        [DataMember(Name = "analysisMethodIds")]
        public List<string> AnalysisMethodIds { get; set; }
        [DataMember(Name = "analyticalGroupIds")]
        public List<string> AnalyticalGroupIds { get; set; }
        [DataMember(Name = "collectionMethodIds")]
        public List<string> CollectionMethodIds { get; set; }
        [DataMember(Name = "cursor")]
        public string Cursor { get; set; }
        [DataMember(Name = "customId")]
        public string CustomId { get; set; }
        [DataMember(Name = "dataClassifications")]
        public List<string> DataClassifications { get; set; }
        [DataMember(Name = "depthUnitCustomId")]
        public string DepthUnitCustomId { get; set; }
        [DataMember(Name = "depthUnitId")]
        public string DepthUnitId { get; set; }
        [DataMember(Name = "depthValue")]
        public double? DepthValue { get; set; }
        [DataMember(Name = "detectionCondition")]
        public string DetectionCondition { get; set; }
        [DataMember(Name = "end-observedTime")]
        public Instant? EndObservedTime { get; set; }
        [DataMember(Name = "end-resultTime")]
        public Instant? EndResultTime { get; set; }
        [DataMember(Name = "endModificationTime")]
        public Instant? EndModificationTime { get; set; }
        [DataMember(Name = "fieldResultType")]
        public FieldResultType? FieldResultType { get; set; }
        [DataMember(Name = "fieldVisitId")]
        public string FieldVisitId { get; set; }
        [DataMember(Name = "filterId")]
        public string FilterId { get; set; }
        [DataMember(Name = "ids")]
        public List<string> Ids { get; set; }
        [DataMember(Name = "importHistoryEventId")]
        public string ImportHistoryEventId { get; set; }
        [DataMember(Name = "labReportIds")]
        public List<string> LabReportIds { get; set; }
        [DataMember(Name = "labResultLabAnalysisMethodIds")]
        public List<string> LabResultLabAnalysisMethodIds { get; set; }
        [DataMember(Name = "labResultLaboratoryIds")]
        public List<string> LabResultLaboratoryIds { get; set; }
        [DataMember(Name = "limit")]
        public int? Limit { get; set; }
        [DataMember(Name = "max-numericResultValue")]
        public double? MaxNumericResultValue { get; set; }
        [DataMember(Name = "media")]
        public List<string> Media { get; set; }
        [DataMember(Name = "min-numericResultValue")]
        public double? MinNumericResultValue { get; set; }
        [DataMember(Name = "numericResultValue")]
        public double? NumericResultValue { get; set; }
        [DataMember(Name = "observedPropertyIds")]
        public List<string> ObservedPropertyIds { get; set; }
        [DataMember(Name = "projectIds")]
        public List<string> ProjectIds { get; set; }
        [DataMember(Name = "qualityControlTypes")]
        public List<string> QualityControlTypes { get; set; }
        [DataMember(Name = "resultGrades")]
        public List<string> ResultGrades { get; set; }
        [DataMember(Name = "resultStatuses")]
        public List<string> ResultStatuses { get; set; }
        [DataMember(Name = "sampleFraction")]
        public SampleFractionType? SampleFraction { get; set; }
        [DataMember(Name = "samplingContextTagIds")]
        public List<string> SamplingContextTagIds { get; set; }
        [DataMember(Name = "samplingLocationGroupIds")]
        public List<string> SamplingLocationGroupIds { get; set; }
        [DataMember(Name = "samplingLocationIds")]
        public List<string> SamplingLocationIds { get; set; }
        [DataMember(Name = "search")]
        public List<string> Search { get; set; }
        [DataMember(Name = "sort")]
        public string Sort { get; set; }
        [DataMember(Name = "specimenIds")]
        public List<string> SpecimenIds { get; set; }
        [DataMember(Name = "specimenName")]
        public string SpecimenName { get; set; }
        [DataMember(Name = "start-observedTime")]
        public Instant? StartObservedTime { get; set; }
        [DataMember(Name = "start-resultTime")]
        public Instant? StartResultTime { get; set; }
        [DataMember(Name = "startModificationTime")]
        public Instant? StartModificationTime { get; set; }
        [DataMember(Name = "taxonIds")]
        public List<string> TaxonIds { get; set; }
    }

    [Route("/v1/observations", "POST")]
    public class PostObservation : IReturn<Observation>
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public Activity Activity { get; set; }
        public CollectionMethod CollectionMethod { get; set; }
        public ObservedProperty ObservedProperty { get; set; }
        public Specimen Specimen { get; set; }
        public SamplingLocation SamplingLocation { get; set; }
        public NumericResult NumericResult { get; set; }
        public CategoricalResult CategoricalResult { get; set; }
        public TaxonomicResult TaxonomicResult { get; set; }
        public QualityControlType? QualityControlType { get; set; }
        public DataClassificationType? DataClassification { get; set; }
        public Medium Medium { get; set; }
        public string MediumSubdivision { get; set; }
        public Instant? ObservedTime { get; set; }
        public Instant? ResultTime { get; set; }
        public Quantity Depth { get; set; }
        public LabInstruction LabInstruction { get; set; }
        public LabResultDetails LabResultDetails { get; set; }
        public AnalysisMethodSimple AnalysisMethod { get; set; }
        public string Comment { get; set; }
        public FieldVisit FieldVisit { get; set; }
        public Device Device { get; set; }
        public List<ImportHistoryEventSimple> ImportHistoryEventSimples { get; set; }
        public List<RuleValidationDetails> ValidationWarnings { get; set; }
        public ResultGrade ResultGrade { get; set; }
        public ResultStatus ResultStatus { get; set; }
        public PlannedFieldResult PlannedFieldResult { get; set; }
        public ObservationStatistics Statistics { get; set; }
        public Taxon RelatedTaxon { get; set; }
        public List<ExtendedAttribute> ExtendedAttributes { get; set; }
        public NullMeasureQualifier NullMeasureQualifier { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [DataContract]
    [Route("/v1/observations", "DELETE")]
    public class DeleteObservations : IReturnVoid
    {
        [DataMember(Name = "activityCustomId")]
        public string ActivityCustomId { get; set; }
        [DataMember(Name = "activityIds")]
        public List<string> ActivityIds { get; set; }
        [DataMember(Name = "activityTypes")]
        public List<string> ActivityTypes { get; set; }
        [DataMember(Name = "analysisMethodIds")]
        public List<string> AnalysisMethodIds { get; set; }
        [DataMember(Name = "analyticalGroupIds")]
        public List<string> AnalyticalGroupIds { get; set; }
        [DataMember(Name = "collectionMethodIds")]
        public List<string> CollectionMethodIds { get; set; }
        [DataMember(Name = "cursor")]
        public string Cursor { get; set; }
        [DataMember(Name = "customId")]
        public string CustomId { get; set; }
        [DataMember(Name = "dataClassifications")]
        public List<string> DataClassifications { get; set; }
        [DataMember(Name = "depthUnitCustomId")]
        public string DepthUnitCustomId { get; set; }
        [DataMember(Name = "depthUnitId")]
        public string DepthUnitId { get; set; }
        [DataMember(Name = "depthValue")]
        public double? DepthValue { get; set; }
        [DataMember(Name = "detectionCondition")]
        public string DetectionCondition { get; set; }
        [DataMember(Name = "end-observedTime")]
        public Instant? EndObservedTime { get; set; }
        [DataMember(Name = "end-resultTime")]
        public Instant? EndResultTime { get; set; }
        [DataMember(Name = "endModificationTime")]
        public Instant? EndModificationTime { get; set; }
        [DataMember(Name = "fieldResultType")]
        public FieldResultType? FieldResultType { get; set; }
        [DataMember(Name = "fieldVisitId")]
        public string FieldVisitId { get; set; }
        [DataMember(Name = "filterId")]
        public string FilterId { get; set; }
        [DataMember(Name = "ids")]
        public List<string> Ids { get; set; }
        [DataMember(Name = "importHistoryEventId")]
        public string ImportHistoryEventId { get; set; }
        [DataMember(Name = "labReportIds")]
        public List<string> LabReportIds { get; set; }
        [DataMember(Name = "labResultLabAnalysisMethodIds")]
        public List<string> LabResultLabAnalysisMethodIds { get; set; }
        [DataMember(Name = "labResultLaboratoryIds")]
        public List<string> LabResultLaboratoryIds { get; set; }
        [DataMember(Name = "limit")]
        public int? Limit { get; set; }
        [DataMember(Name = "max-numericResultValue")]
        public double? MaxNumericResultValue { get; set; }
        [DataMember(Name = "media")]
        public List<string> Media { get; set; }
        [DataMember(Name = "min-numericResultValue")]
        public double? MinNumericResultValue { get; set; }
        [DataMember(Name = "numericResultValue")]
        public double? NumericResultValue { get; set; }
        [DataMember(Name = "observedPropertyIds")]
        public List<string> ObservedPropertyIds { get; set; }
        [DataMember(Name = "projectIds")]
        public List<string> ProjectIds { get; set; }
        [DataMember(Name = "qualityControlTypes")]
        public List<string> QualityControlTypes { get; set; }
        [DataMember(Name = "resultGrades")]
        public List<string> ResultGrades { get; set; }
        [DataMember(Name = "resultStatuses")]
        public List<string> ResultStatuses { get; set; }
        [DataMember(Name = "sampleFraction")]
        public SampleFractionType? SampleFraction { get; set; }
        [DataMember(Name = "samplingContextTagIds")]
        public List<string> SamplingContextTagIds { get; set; }
        [DataMember(Name = "samplingLocationGroupIds")]
        public List<string> SamplingLocationGroupIds { get; set; }
        [DataMember(Name = "samplingLocationIds")]
        public List<string> SamplingLocationIds { get; set; }
        [DataMember(Name = "search")]
        public List<string> Search { get; set; }
        [DataMember(Name = "sort")]
        public string Sort { get; set; }
        [DataMember(Name = "specimenIds")]
        public List<string> SpecimenIds { get; set; }
        [DataMember(Name = "specimenName")]
        public string SpecimenName { get; set; }
        [DataMember(Name = "start-observedTime")]
        public Instant? StartObservedTime { get; set; }
        [DataMember(Name = "start-resultTime")]
        public Instant? StartResultTime { get; set; }
        [DataMember(Name = "startModificationTime")]
        public Instant? StartModificationTime { get; set; }
        [DataMember(Name = "taxonIds")]
        public List<string> TaxonIds { get; set; }
    }

    [Route("/v1/observations/{id}", "GET")]
    public class GetObservation : IReturn<Observation>
    {
        public string Id { get; set; }
    }

    [Route("/v1/observations/{id}", "PUT")]
    public class PutObservation : IReturn<Observation>
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public Activity Activity { get; set; }
        public CollectionMethod CollectionMethod { get; set; }
        public ObservedProperty ObservedProperty { get; set; }
        public Specimen Specimen { get; set; }
        public SamplingLocation SamplingLocation { get; set; }
        public NumericResult NumericResult { get; set; }
        public CategoricalResult CategoricalResult { get; set; }
        public TaxonomicResult TaxonomicResult { get; set; }
        public QualityControlType? QualityControlType { get; set; }
        public DataClassificationType? DataClassification { get; set; }
        public Medium Medium { get; set; }
        public string MediumSubdivision { get; set; }
        public Instant? ObservedTime { get; set; }
        public Instant? ResultTime { get; set; }
        public Quantity Depth { get; set; }
        public LabInstruction LabInstruction { get; set; }
        public LabResultDetails LabResultDetails { get; set; }
        public AnalysisMethodSimple AnalysisMethod { get; set; }
        public string Comment { get; set; }
        public FieldVisit FieldVisit { get; set; }
        public Device Device { get; set; }
        public List<ImportHistoryEventSimple> ImportHistoryEventSimples { get; set; }
        public List<RuleValidationDetails> ValidationWarnings { get; set; }
        public ResultGrade ResultGrade { get; set; }
        public ResultStatus ResultStatus { get; set; }
        public PlannedFieldResult PlannedFieldResult { get; set; }
        public ObservationStatistics Statistics { get; set; }
        public Taxon RelatedTaxon { get; set; }
        public List<ExtendedAttribute> ExtendedAttributes { get; set; }
        public NullMeasureQualifier NullMeasureQualifier { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/observations/{id}", "DELETE")]
    public class DeleteObservation : IReturnVoid
    {
        public string Id { get; set; }
    }

    [Route("/v1/observations/{id}/history", "GET")]
    public class GetObservationHistory : IReturn<SearchResultAuditHistory>
    {
        public string Id { get; set; }
    }

    [DataContract]
    [Route("/v1/observations/charts", "GET")]
    public class GetChartData : IReturn<MultiChartData>
    {
        [DataMember(Name = "activityCustomId")]
        public string ActivityCustomId { get; set; }
        [DataMember(Name = "activityIds")]
        public List<string> ActivityIds { get; set; }
        [DataMember(Name = "activityTypes")]
        public List<string> ActivityTypes { get; set; }
        [DataMember(Name = "analysisMethodIds")]
        public List<string> AnalysisMethodIds { get; set; }
        [DataMember(Name = "analyticalGroupIds")]
        public List<string> AnalyticalGroupIds { get; set; }
        [DataMember(Name = "collectionMethodIds")]
        public List<string> CollectionMethodIds { get; set; }
        [DataMember(Name = "cursor")]
        public string Cursor { get; set; }
        [DataMember(Name = "customId")]
        public string CustomId { get; set; }
        [DataMember(Name = "dataClassifications")]
        public List<string> DataClassifications { get; set; }
        [DataMember(Name = "depthUnitCustomId")]
        public string DepthUnitCustomId { get; set; }
        [DataMember(Name = "depthUnitId")]
        public string DepthUnitId { get; set; }
        [DataMember(Name = "depthValue")]
        public double? DepthValue { get; set; }
        [DataMember(Name = "detectionCondition")]
        public string DetectionCondition { get; set; }
        [DataMember(Name = "end-observedTime")]
        public Instant? EndObservedTime { get; set; }
        [DataMember(Name = "end-resultTime")]
        public Instant? EndResultTime { get; set; }
        [DataMember(Name = "endModificationTime")]
        public Instant? EndModificationTime { get; set; }
        [DataMember(Name = "fieldResultType")]
        public FieldResultType? FieldResultType { get; set; }
        [DataMember(Name = "fieldVisitId")]
        public string FieldVisitId { get; set; }
        [DataMember(Name = "filterId")]
        public string FilterId { get; set; }
        [DataMember(Name = "ids")]
        public List<string> Ids { get; set; }
        [DataMember(Name = "importHistoryEventId")]
        public string ImportHistoryEventId { get; set; }
        [DataMember(Name = "labReportIds")]
        public List<string> LabReportIds { get; set; }
        [DataMember(Name = "labResultLabAnalysisMethodIds")]
        public List<string> LabResultLabAnalysisMethodIds { get; set; }
        [DataMember(Name = "labResultLaboratoryIds")]
        public List<string> LabResultLaboratoryIds { get; set; }
        [DataMember(Name = "limit")]
        public int? Limit { get; set; }
        [DataMember(Name = "max-numericResultValue")]
        public double? MaxNumericResultValue { get; set; }
        [DataMember(Name = "media")]
        public List<string> Media { get; set; }
        [DataMember(Name = "min-numericResultValue")]
        public double? MinNumericResultValue { get; set; }
        [DataMember(Name = "numericResultValue")]
        public double? NumericResultValue { get; set; }
        [DataMember(Name = "observedPropertyIds")]
        public List<string> ObservedPropertyIds { get; set; }
        [DataMember(Name = "projectIds")]
        public List<string> ProjectIds { get; set; }
        [DataMember(Name = "qualityControlTypes")]
        public List<string> QualityControlTypes { get; set; }
        [DataMember(Name = "resultGrades")]
        public List<string> ResultGrades { get; set; }
        [DataMember(Name = "resultStatuses")]
        public List<string> ResultStatuses { get; set; }
        [DataMember(Name = "sampleFraction")]
        public SampleFractionType? SampleFraction { get; set; }
        [DataMember(Name = "samplingContextTagIds")]
        public List<string> SamplingContextTagIds { get; set; }
        [DataMember(Name = "samplingLocationGroupIds")]
        public List<string> SamplingLocationGroupIds { get; set; }
        [DataMember(Name = "samplingLocationIds")]
        public List<string> SamplingLocationIds { get; set; }
        [DataMember(Name = "search")]
        public List<string> Search { get; set; }
        [DataMember(Name = "sort")]
        public string Sort { get; set; }
        [DataMember(Name = "specimenIds")]
        public List<string> SpecimenIds { get; set; }
        [DataMember(Name = "specimenName")]
        public string SpecimenName { get; set; }
        [DataMember(Name = "start-observedTime")]
        public Instant? StartObservedTime { get; set; }
        [DataMember(Name = "start-resultTime")]
        public Instant? StartResultTime { get; set; }
        [DataMember(Name = "startModificationTime")]
        public Instant? StartModificationTime { get; set; }
        [DataMember(Name = "taxonIds")]
        public List<string> TaxonIds { get; set; }
    }

    [DataContract]
    [Route("/v1/observations/geographic", "GET")]
    public class GetGroupedObservations : IReturn<SearchResultLocationObservationsGroup>, IPaginatedRequest
    {
        [DataMember(Name = "activityCustomId")]
        public string ActivityCustomId { get; set; }
        [DataMember(Name = "activityIds")]
        public List<string> ActivityIds { get; set; }
        [DataMember(Name = "activityTypes")]
        public List<string> ActivityTypes { get; set; }
        [DataMember(Name = "analysisMethodIds")]
        public List<string> AnalysisMethodIds { get; set; }
        [DataMember(Name = "analyticalGroupIds")]
        public List<string> AnalyticalGroupIds { get; set; }
        [DataMember(Name = "collectionMethodIds")]
        public List<string> CollectionMethodIds { get; set; }
        [DataMember(Name = "cursor")]
        public string Cursor { get; set; }
        [DataMember(Name = "customId")]
        public string CustomId { get; set; }
        [DataMember(Name = "dataClassifications")]
        public List<string> DataClassifications { get; set; }
        [DataMember(Name = "depthUnitCustomId")]
        public string DepthUnitCustomId { get; set; }
        [DataMember(Name = "depthUnitId")]
        public string DepthUnitId { get; set; }
        [DataMember(Name = "depthValue")]
        public double? DepthValue { get; set; }
        [DataMember(Name = "detectionCondition")]
        public string DetectionCondition { get; set; }
        [DataMember(Name = "end-observedTime")]
        public Instant? EndObservedTime { get; set; }
        [DataMember(Name = "end-resultTime")]
        public Instant? EndResultTime { get; set; }
        [DataMember(Name = "endModificationTime")]
        public Instant? EndModificationTime { get; set; }
        [DataMember(Name = "fieldResultType")]
        public FieldResultType? FieldResultType { get; set; }
        [DataMember(Name = "fieldVisitId")]
        public string FieldVisitId { get; set; }
        [DataMember(Name = "filterId")]
        public string FilterId { get; set; }
        [DataMember(Name = "ids")]
        public List<string> Ids { get; set; }
        [DataMember(Name = "importHistoryEventId")]
        public string ImportHistoryEventId { get; set; }
        [DataMember(Name = "labReportIds")]
        public List<string> LabReportIds { get; set; }
        [DataMember(Name = "labResultLabAnalysisMethodIds")]
        public List<string> LabResultLabAnalysisMethodIds { get; set; }
        [DataMember(Name = "labResultLaboratoryIds")]
        public List<string> LabResultLaboratoryIds { get; set; }
        [DataMember(Name = "limit")]
        public int? Limit { get; set; }
        [DataMember(Name = "max-numericResultValue")]
        public double? MaxNumericResultValue { get; set; }
        [DataMember(Name = "media")]
        public List<string> Media { get; set; }
        [DataMember(Name = "min-numericResultValue")]
        public double? MinNumericResultValue { get; set; }
        [DataMember(Name = "numericResultValue")]
        public double? NumericResultValue { get; set; }
        [DataMember(Name = "observedPropertyIds")]
        public List<string> ObservedPropertyIds { get; set; }
        [DataMember(Name = "projectIds")]
        public List<string> ProjectIds { get; set; }
        [DataMember(Name = "qualityControlTypes")]
        public List<string> QualityControlTypes { get; set; }
        [DataMember(Name = "resultGrades")]
        public List<string> ResultGrades { get; set; }
        [DataMember(Name = "resultStatuses")]
        public List<string> ResultStatuses { get; set; }
        [DataMember(Name = "sampleFraction")]
        public SampleFractionType? SampleFraction { get; set; }
        [DataMember(Name = "samplingContextTagIds")]
        public List<string> SamplingContextTagIds { get; set; }
        [DataMember(Name = "samplingLocationGroupIds")]
        public List<string> SamplingLocationGroupIds { get; set; }
        [DataMember(Name = "samplingLocationIds")]
        public List<string> SamplingLocationIds { get; set; }
        [DataMember(Name = "search")]
        public List<string> Search { get; set; }
        [DataMember(Name = "sort")]
        public string Sort { get; set; }
        [DataMember(Name = "specimenIds")]
        public List<string> SpecimenIds { get; set; }
        [DataMember(Name = "specimenName")]
        public string SpecimenName { get; set; }
        [DataMember(Name = "start-observedTime")]
        public Instant? StartObservedTime { get; set; }
        [DataMember(Name = "start-resultTime")]
        public Instant? StartResultTime { get; set; }
        [DataMember(Name = "startModificationTime")]
        public Instant? StartModificationTime { get; set; }
        [DataMember(Name = "taxonIds")]
        public List<string> TaxonIds { get; set; }
    }

    [DataContract]
    [Route("/v1/observations/resultgrades", "PUT")]
    public class PutBulkEditResultGrades : IReturnVoid
    {
        [DataMember(Name = "targetResultGrade")]
        public string TargetResultGrade { get; set; }
        [DataMember(Name = "activityCustomId")]
        public string ActivityCustomId { get; set; }
        [DataMember(Name = "activityIds")]
        public List<string> ActivityIds { get; set; }
        [DataMember(Name = "activityTypes")]
        public List<string> ActivityTypes { get; set; }
        [DataMember(Name = "analysisMethodIds")]
        public List<string> AnalysisMethodIds { get; set; }
        [DataMember(Name = "analyticalGroupIds")]
        public List<string> AnalyticalGroupIds { get; set; }
        [DataMember(Name = "collectionMethodIds")]
        public List<string> CollectionMethodIds { get; set; }
        [DataMember(Name = "cursor")]
        public string Cursor { get; set; }
        [DataMember(Name = "customId")]
        public string CustomId { get; set; }
        [DataMember(Name = "dataClassifications")]
        public List<string> DataClassifications { get; set; }
        [DataMember(Name = "depthUnitCustomId")]
        public string DepthUnitCustomId { get; set; }
        [DataMember(Name = "depthUnitId")]
        public string DepthUnitId { get; set; }
        [DataMember(Name = "depthValue")]
        public double? DepthValue { get; set; }
        [DataMember(Name = "detectionCondition")]
        public string DetectionCondition { get; set; }
        [DataMember(Name = "end-observedTime")]
        public Instant? EndObservedTime { get; set; }
        [DataMember(Name = "end-resultTime")]
        public Instant? EndResultTime { get; set; }
        [DataMember(Name = "endModificationTime")]
        public Instant? EndModificationTime { get; set; }
        [DataMember(Name = "fieldResultType")]
        public FieldResultType? FieldResultType { get; set; }
        [DataMember(Name = "fieldVisitId")]
        public string FieldVisitId { get; set; }
        [DataMember(Name = "filterId")]
        public string FilterId { get; set; }
        [DataMember(Name = "ids")]
        public List<string> Ids { get; set; }
        [DataMember(Name = "importHistoryEventId")]
        public string ImportHistoryEventId { get; set; }
        [DataMember(Name = "labReportIds")]
        public List<string> LabReportIds { get; set; }
        [DataMember(Name = "labResultLabAnalysisMethodIds")]
        public List<string> LabResultLabAnalysisMethodIds { get; set; }
        [DataMember(Name = "labResultLaboratoryIds")]
        public List<string> LabResultLaboratoryIds { get; set; }
        [DataMember(Name = "limit")]
        public int? Limit { get; set; }
        [DataMember(Name = "max-numericResultValue")]
        public double? MaxNumericResultValue { get; set; }
        [DataMember(Name = "media")]
        public List<string> Media { get; set; }
        [DataMember(Name = "min-numericResultValue")]
        public double? MinNumericResultValue { get; set; }
        [DataMember(Name = "numericResultValue")]
        public double? NumericResultValue { get; set; }
        [DataMember(Name = "observedPropertyIds")]
        public List<string> ObservedPropertyIds { get; set; }
        [DataMember(Name = "projectIds")]
        public List<string> ProjectIds { get; set; }
        [DataMember(Name = "qualityControlTypes")]
        public List<string> QualityControlTypes { get; set; }
        [DataMember(Name = "resultGrades")]
        public List<string> ResultGrades { get; set; }
        [DataMember(Name = "resultStatuses")]
        public List<string> ResultStatuses { get; set; }
        [DataMember(Name = "sampleFraction")]
        public SampleFractionType? SampleFraction { get; set; }
        [DataMember(Name = "samplingContextTagIds")]
        public List<string> SamplingContextTagIds { get; set; }
        [DataMember(Name = "samplingLocationGroupIds")]
        public List<string> SamplingLocationGroupIds { get; set; }
        [DataMember(Name = "samplingLocationIds")]
        public List<string> SamplingLocationIds { get; set; }
        [DataMember(Name = "search")]
        public List<string> Search { get; set; }
        [DataMember(Name = "sort")]
        public string Sort { get; set; }
        [DataMember(Name = "specimenIds")]
        public List<string> SpecimenIds { get; set; }
        [DataMember(Name = "specimenName")]
        public string SpecimenName { get; set; }
        [DataMember(Name = "start-observedTime")]
        public Instant? StartObservedTime { get; set; }
        [DataMember(Name = "start-resultTime")]
        public Instant? StartResultTime { get; set; }
        [DataMember(Name = "startModificationTime")]
        public Instant? StartModificationTime { get; set; }
        [DataMember(Name = "taxonIds")]
        public List<string> TaxonIds { get; set; }
    }

    [Route("/v1/observedproperties", "GET")]
    public class GetObservedProperties : IReturn<SearchResultObservedProperty>
    {
        public List<string> AnalysisTypes { get; set; }
        public string CustomId { get; set; }
        public int? Limit { get; set; }
        public List<string> ResultTypes { get; set; }
        public List<string> Search { get; set; }
    }

    [Route("/v1/observedproperties", "POST")]
    public class PostObservedProperty : IReturn<ObservedProperty>
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ResultType? ResultType { get; set; }
        public AnalysisType? AnalysisType { get; set; }
        public UnitGroup UnitGroup { get; set; }
        public Unit DefaultUnit { get; set; }
        public List<ImportHistoryEventSimple> ImportHistoryEventSimples { get; set; }
        public string CasNumber { get; set; }
        public Quantity LowerLimit { get; set; }
        public Quantity UpperLimit { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/observedproperties/{id}", "GET")]
    public class GetObservedProperty : IReturn<ObservedProperty>
    {
        public string Id { get; set; }
    }

    [Route("/v1/observedproperties/{id}", "PUT")]
    public class PutObservedProperty : IReturn<ObservedProperty>
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ResultType? ResultType { get; set; }
        public AnalysisType? AnalysisType { get; set; }
        public UnitGroup UnitGroup { get; set; }
        public Unit DefaultUnit { get; set; }
        public List<ImportHistoryEventSimple> ImportHistoryEventSimples { get; set; }
        public string CasNumber { get; set; }
        public Quantity LowerLimit { get; set; }
        public Quantity UpperLimit { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/observedproperties/{id}", "DELETE")]
    public class DeleteObservedProperty : IReturnVoid
    {
        public string Id { get; set; }
    }

    [Route("/v1/observedproperties/{id}/categoricalvalues", "GET")]
    public class GetObservedPropertyCategoricalValues : IReturn<SearchResultCategoricalValue>
    {
        public string Id { get; set; }
    }

    [Route("/v1/observedproperties/{id}/categoricalvalues", "POST")]
    public class PostObservedPropertyCategoricalValue : IReturn<List<CategoricalValue>>
    {
        public string Id { get; set; }
    }

    [Route("/v1/observedproperties/{id}/categoricalvalues", "PUT")]
    public class PutObservedPropertyCategoricalValues : IReturn<List<CategoricalValue>>
    {
        public string Id { get; set; }
    }

    [Route("/v1/observedproperties/{id}/categoricalvalues", "DELETE")]
    public class DeleteObservedPropertyCategoricalValues : IReturnVoid
    {
        public string Id { get; set; }
    }

    [Route("/v1/observedproperties/{id}/history", "GET")]
    public class GetObservedPropertyHistory : IReturn<SearchResultAuditHistory>
    {
        public string Id { get; set; }
    }

    [Route("/v1/projects", "GET")]
    public class GetProjects : IReturn<SearchResultProject>
    {
        
    }

    [Route("/v1/projects", "POST")]
    public class PostProject : IReturn<Project>
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public string Name { get; set; }
        public ProjectType? Type { get; set; }
        public string Description { get; set; }
        public string ScopeStatement { get; set; }
        public bool? Approved { get; set; }
        public string ApprovalAgency { get; set; }
        public Instant? StartTime { get; set; }
        public Instant? EndTime { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/projects/{id}", "GET")]
    public class GetProject : IReturn<Project>
    {
        public string Id { get; set; }
    }

    [Route("/v1/projects/{id}", "PUT")]
    public class PutProject : IReturn<Project>
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public string Name { get; set; }
        public ProjectType? Type { get; set; }
        public string Description { get; set; }
        public string ScopeStatement { get; set; }
        public bool? Approved { get; set; }
        public string ApprovalAgency { get; set; }
        public Instant? StartTime { get; set; }
        public Instant? EndTime { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/projects/{id}", "DELETE")]
    public class DeleteProject : IReturnVoid
    {
        public string Id { get; set; }
    }

    [Route("/v1/projects/{id}/history", "GET")]
    public class GetProjectHistory : IReturn<SearchResultAuditHistory>
    {
        public string Id { get; set; }
    }

    [Route("/v1/resultgrades", "GET")]
    public class GetResultGrades : IReturn<SearchResultResultGrade>
    {
        
    }

    [Route("/v1/resultgrades", "PUT")]
    public class PutResultGrades : IReturn<List<ResultGrade>>
    {
        
    }

    [Route("/v1/resultgrades/{id}/history", "GET")]
    public class GetResultGradeHistory : IReturn<SearchResultAuditHistory>
    {
        public string Id { get; set; }
    }

    [Route("/v1/resultstatuses", "GET")]
    public class GetResultStatuses : IReturn<SearchResultResultStatus>
    {
        
    }

    [Route("/v1/resultstatuses", "PUT")]
    public class PutResultStatuses : IReturn<List<ResultStatus>>
    {
        
    }

    [Route("/v1/resultstatuses/{id}/history", "GET")]
    public class GetResultStatuseHistory : IReturn<SearchResultAuditHistory>
    {
        public string Id { get; set; }
    }

    [Route("/v1/samplinglocationgroups", "GET")]
    public class GetSamplingLocationGroups : IReturn<SearchResultSamplingLocationGroup>
    {
        
    }

    [Route("/v1/samplinglocationgroups", "POST")]
    public class PostSamplingLocationGroup : IReturn<SamplingLocationGroup>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public LocationGroupType LocationGroupType { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/samplinglocationgroups/{id}", "GET")]
    public class GetSamplingLocationGroup : IReturn<SamplingLocationGroup>
    {
        public string Id { get; set; }
    }

    [Route("/v1/samplinglocationgroups/{id}", "PUT")]
    public class PutSamplingLocationGroup : IReturn<SamplingLocationGroup>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public LocationGroupType LocationGroupType { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/samplinglocationgroups/{id}", "DELETE")]
    public class DeleteSamplingLocationGroup : IReturnVoid
    {
        public string Id { get; set; }
    }

    [Route("/v1/samplinglocationgroups/{id}/history", "GET")]
    public class GetSamplingLocationGroupHistory : IReturn<SearchResultAuditHistory>
    {
        public string Id { get; set; }
    }

    [Route("/v1/samplinglocationgrouptypes", "GET")]
    public class GetSamplinglocationgrouptypes : IReturn<SearchResultLocationGroupType>
    {
        
    }

    [Route("/v1/samplinglocationgrouptypes", "PUT")]
    public class PutSamplinglocationgrouptypes : IReturn<List<LocationGroupType>>
    {
        
    }

    [Route("/v1/samplinglocationgrouptypes/{id}/history", "GET")]
    public class GetSamplinglocationgrouptypeHistory : IReturn<SearchResultAuditHistory>
    {
        public string Id { get; set; }
    }

    [Route("/v1/samplinglocations", "GET")]
    public class GetSamplingLocations : IReturn<SearchResultSamplingLocation>, IPaginatedRequest
    {
        public string Cursor { get; set; }
        public string CustomId { get; set; }
        public Instant? EndModificationTime { get; set; }
        public int? Limit { get; set; }
        public List<string> LocationGroupTypeIds { get; set; }
        public List<string> LocationTypeIds { get; set; }
        public List<string> SamplingLocationGroupIds { get; set; }
        public List<string> Search { get; set; }
        public string Sort { get; set; }
        public Instant? StartModificationTime { get; set; }
    }

    [Route("/v1/samplinglocations", "POST")]
    public class PostSamplingLocation : IReturn<SamplingLocation>
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public string Name { get; set; }
        public LocationType Type { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string HorizontalDatum { get; set; }
        public string VerticalDatum { get; set; }
        public string HorizontalCollectionMethod { get; set; }
        public string VerticalCollectionMethod { get; set; }
        public string Description { get; set; }
        public Address Address { get; set; }
        public Quantity Elevation { get; set; }
        public TimeZone TimeZone { get; set; }
        public List<ImportHistoryEventSimple> ImportHistoryEventSimples { get; set; }
        public List<StandardSimple> Standards { get; set; }
        public List<DomainObjectAttachment> Attachments { get; set; }
        public List<SamplingLocationGroup> SamplingLocationGroups { get; set; }
        public List<ExtendedAttribute> ExtendedAttributes { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/samplinglocations/{id}", "GET")]
    public class GetSamplingLocation : IReturn<SamplingLocation>
    {
        public string Id { get; set; }
    }

    [Route("/v1/samplinglocations/{id}", "PUT")]
    public class PutSamplingLocation : IReturn<SamplingLocation>
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public string Name { get; set; }
        public LocationType Type { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string HorizontalDatum { get; set; }
        public string VerticalDatum { get; set; }
        public string HorizontalCollectionMethod { get; set; }
        public string VerticalCollectionMethod { get; set; }
        public string Description { get; set; }
        public Address Address { get; set; }
        public Quantity Elevation { get; set; }
        public TimeZone TimeZone { get; set; }
        public List<ImportHistoryEventSimple> ImportHistoryEventSimples { get; set; }
        public List<StandardSimple> Standards { get; set; }
        public List<DomainObjectAttachment> Attachments { get; set; }
        public List<SamplingLocationGroup> SamplingLocationGroups { get; set; }
        public List<ExtendedAttribute> ExtendedAttributes { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/samplinglocations/{id}", "DELETE")]
    public class DeleteSamplingLocation : IReturnVoid
    {
        public string Id { get; set; }
    }

    [Route("/v1/samplinglocations/{id}/attachments", "GET")]
    public class GetSamplingLocationAttachments : IReturn<SearchResultAttachment>
    {
        public string Id { get; set; }
    }

    [Route("/v1/samplinglocations/{id}/canedit", "GET")]
    public class GetSamplingLocationCanEdit : IReturn<bool>
    {
        public string Id { get; set; }
    }

    [Route("/v1/samplinglocations/{id}/history", "GET")]
    public class GetSamplingLocationHistory : IReturn<SearchResultAuditHistory>
    {
        public string Id { get; set; }
    }

    [Route("/v1/samplinglocations/{id}/summary", "GET")]
    public class GetSamplingLocationSummary : IReturn<SamplingLocationSummary>
    {
        public string Id { get; set; }
    }

    [Route("/v1/samplinglocationtypes", "GET")]
    public class GetSamplingLocationTypes : IReturn<SearchResultLocationType>
    {
        
    }

    [Route("/v1/samplinglocationtypes", "PUT")]
    public class PutSamplingLocationTypes : IReturn<List<LocationType>>
    {
        
    }

    [Route("/v1/samplinglocationtypes/{id}/history", "GET")]
    public class GetSamplingLocationTypeHistory : IReturn<SearchResultAuditHistory>
    {
        public string Id { get; set; }
    }

    [Route("/v1/schedules", "GET")]
    public class GetSchedules : IReturn<SearchResultSchedule>
    {
        
    }

    [Route("/v1/schedules", "POST")]
    public class PostSchedule : IReturn<Schedule>
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public Instant? StartDate { get; set; }
        public Instant? EndDate { get; set; }
        public RecurrenceType? RecurrenceType { get; set; }
        public RecurrenceDayWeeklyType? RecurrenceDayWeekly { get; set; }
        public RecurrenceDayMonthlyType? RecurrenceDayMonthly { get; set; }
        public SamplingLocationGroup SamplingLocationGroup { get; set; }
        public SamplingLocationGroupSelectionType? SamplingLocationGroupSelectionType { get; set; }
        public int? SamplingLocationGroupSelectionTypeRandomCount { get; set; }
        public Instant? LastGenerationDate { get; set; }
        public List<SchedulePlannedActivity> SchedulePlannedActivities { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/schedules/{id}", "GET")]
    public class GetSchedule : IReturn<Schedule>
    {
        public string Id { get; set; }
    }

    [Route("/v1/schedules/{id}", "PUT")]
    public class PutSchedule : IReturn<Schedule>
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public Instant? StartDate { get; set; }
        public Instant? EndDate { get; set; }
        public RecurrenceType? RecurrenceType { get; set; }
        public RecurrenceDayWeeklyType? RecurrenceDayWeekly { get; set; }
        public RecurrenceDayMonthlyType? RecurrenceDayMonthly { get; set; }
        public SamplingLocationGroup SamplingLocationGroup { get; set; }
        public SamplingLocationGroupSelectionType? SamplingLocationGroupSelectionType { get; set; }
        public int? SamplingLocationGroupSelectionTypeRandomCount { get; set; }
        public Instant? LastGenerationDate { get; set; }
        public List<SchedulePlannedActivity> SchedulePlannedActivities { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/schedules/{id}", "DELETE")]
    public class DeleteSchedule : IReturnVoid
    {
        public string Id { get; set; }
    }

    [Route("/v1/schedules/{id}/generateFieldVisit", "POST")]
    public class PostGenerateFieldVisits : IReturn<List<FieldVisit>>
    {
        public string Id { get; set; }
    }

    [Route("/v1/schedules/{id}/history", "GET")]
    public class GetScheduleHistory : IReturn<SearchResultAuditHistory>
    {
        public string Id { get; set; }
    }

    [Route("/v1/services/export/fieldsheets/{fieldVisitId}", "GET")]
    public class GetExportFieldSheet : IReturnVoid
    {
        public string FieldVisitId { get; set; }
    }

    [DataContract]
    [Route("/v1/services/export/observations", "GET")]
    public class GetExportObservations : IReturnVoid
    {
        [DataMember(Name = "format")]
        public FormatType? Format { get; set; }
        [DataMember(Name = "activityCustomId")]
        public string ActivityCustomId { get; set; }
        [DataMember(Name = "activityIds")]
        public List<string> ActivityIds { get; set; }
        [DataMember(Name = "activityTypes")]
        public List<string> ActivityTypes { get; set; }
        [DataMember(Name = "analysisMethodIds")]
        public List<string> AnalysisMethodIds { get; set; }
        [DataMember(Name = "analyticalGroupIds")]
        public List<string> AnalyticalGroupIds { get; set; }
        [DataMember(Name = "collectionMethodIds")]
        public List<string> CollectionMethodIds { get; set; }
        [DataMember(Name = "cursor")]
        public string Cursor { get; set; }
        [DataMember(Name = "customId")]
        public string CustomId { get; set; }
        [DataMember(Name = "dataClassifications")]
        public List<string> DataClassifications { get; set; }
        [DataMember(Name = "depthUnitCustomId")]
        public string DepthUnitCustomId { get; set; }
        [DataMember(Name = "depthUnitId")]
        public string DepthUnitId { get; set; }
        [DataMember(Name = "depthValue")]
        public double? DepthValue { get; set; }
        [DataMember(Name = "detectionCondition")]
        public string DetectionCondition { get; set; }
        [DataMember(Name = "end-observedTime")]
        public Instant? EndObservedTime { get; set; }
        [DataMember(Name = "end-resultTime")]
        public Instant? EndResultTime { get; set; }
        [DataMember(Name = "endModificationTime")]
        public Instant? EndModificationTime { get; set; }
        [DataMember(Name = "fieldResultType")]
        public FieldResultType? FieldResultType { get; set; }
        [DataMember(Name = "fieldVisitId")]
        public string FieldVisitId { get; set; }
        [DataMember(Name = "filterId")]
        public string FilterId { get; set; }
        [DataMember(Name = "ids")]
        public List<string> Ids { get; set; }
        [DataMember(Name = "importHistoryEventId")]
        public string ImportHistoryEventId { get; set; }
        [DataMember(Name = "labReportIds")]
        public List<string> LabReportIds { get; set; }
        [DataMember(Name = "labResultLabAnalysisMethodIds")]
        public List<string> LabResultLabAnalysisMethodIds { get; set; }
        [DataMember(Name = "labResultLaboratoryIds")]
        public List<string> LabResultLaboratoryIds { get; set; }
        [DataMember(Name = "limit")]
        public int? Limit { get; set; }
        [DataMember(Name = "max-numericResultValue")]
        public double? MaxNumericResultValue { get; set; }
        [DataMember(Name = "media")]
        public List<string> Media { get; set; }
        [DataMember(Name = "min-numericResultValue")]
        public double? MinNumericResultValue { get; set; }
        [DataMember(Name = "numericResultValue")]
        public double? NumericResultValue { get; set; }
        [DataMember(Name = "observedPropertyIds")]
        public List<string> ObservedPropertyIds { get; set; }
        [DataMember(Name = "projectIds")]
        public List<string> ProjectIds { get; set; }
        [DataMember(Name = "qualityControlTypes")]
        public List<string> QualityControlTypes { get; set; }
        [DataMember(Name = "resultGrades")]
        public List<string> ResultGrades { get; set; }
        [DataMember(Name = "resultStatuses")]
        public List<string> ResultStatuses { get; set; }
        [DataMember(Name = "sampleFraction")]
        public SampleFractionType? SampleFraction { get; set; }
        [DataMember(Name = "samplingContextTagIds")]
        public List<string> SamplingContextTagIds { get; set; }
        [DataMember(Name = "samplingLocationGroupIds")]
        public List<string> SamplingLocationGroupIds { get; set; }
        [DataMember(Name = "samplingLocationIds")]
        public List<string> SamplingLocationIds { get; set; }
        [DataMember(Name = "search")]
        public List<string> Search { get; set; }
        [DataMember(Name = "sort")]
        public string Sort { get; set; }
        [DataMember(Name = "specimenIds")]
        public List<string> SpecimenIds { get; set; }
        [DataMember(Name = "specimenName")]
        public string SpecimenName { get; set; }
        [DataMember(Name = "start-observedTime")]
        public Instant? StartObservedTime { get; set; }
        [DataMember(Name = "start-resultTime")]
        public Instant? StartResultTime { get; set; }
        [DataMember(Name = "startModificationTime")]
        public Instant? StartModificationTime { get; set; }
        [DataMember(Name = "taxonIds")]
        public List<string> TaxonIds { get; set; }
    }

    [Route("/v1/services/export/samplinglocations", "GET")]
    public class GetExportSamplingLocations : IReturnVoid
    {
        public string Cursor { get; set; }
        public string CustomId { get; set; }
        public Instant? EndModificationTime { get; set; }
        public int? Limit { get; set; }
        public List<string> LocationGroupTypeIds { get; set; }
        public List<string> LocationTypeIds { get; set; }
        public List<string> SamplingLocationGroupIds { get; set; }
        public List<string> Search { get; set; }
        public string Sort { get; set; }
        public Instant? StartModificationTime { get; set; }
    }

    [Route("/v1/services/export/specimens", "GET")]
    public class GetExportSpecimens : IReturnVoid
    {
        public List<string> ActivityIds { get; set; }
        public List<string> ActivityTypes { get; set; }
        public Instant? After { get; set; }
        public List<string> AnalyticalGroupIds { get; set; }
        public Instant? Before { get; set; }
        public string Cursor { get; set; }
        public Instant? EndModificationTime { get; set; }
        public List<string> FieldTripIds { get; set; }
        public string FieldVisitId { get; set; }
        public List<string> LaboratoryIds { get; set; }
        public int? Limit { get; set; }
        public List<string> ProjectIds { get; set; }
        public List<string> SamplingLocationGroupIds { get; set; }
        public List<string> SamplingLocationIds { get; set; }
        public List<string> Search { get; set; }
        public string Sort { get; set; }
        public List<string> SpecimenStatuses { get; set; }
        public Instant? StartModificationTime { get; set; }
    }

    [Route("/v1/services/import/analysismethods", "POST")]
    public class PostImportAnalysisMethods : IReturn<AnalysisMethodImportSummary>
    {
        
    }

    [Route("/v1/services/import/analysismethods/dryrun", "POST")]
    public class PostImportAnalysisMethodsDryRun : IReturn<AnalysisMethodImportSummary>
    {
        
    }

    [Route("/v1/services/import/fieldsheets", "POST")]
    public class PostImportFieldSheet : IReturn<FieldSheetImportSummary>
    {
        public string TimeZoneOffset { get; set; }
    }

    [Route("/v1/services/import/fieldsheets/dryrun", "POST")]
    public class PostImportFieldSheetDryRun : IReturn<FieldSheetImportSummary>
    {
        public string TimeZoneOffset { get; set; }
    }

    [Route("/v1/services/import/labanalysismethods", "POST")]
    public class PostImportLabAnalysisMethods : IReturn<AnalysisMethodImportSummary>
    {
        
    }

    [Route("/v1/services/import/labanalysismethods/dryrun", "POST")]
    public class PostImportLabAnalysisMethodsDryRun : IReturn<AnalysisMethodImportSummary>
    {
        
    }

    [Route("/v1/services/import/labreportdata", "POST")]
    public class PostImportLabReportData : IReturn<ObservationImportSummary>
    {
        public string FileType { get; set; }
        public string TimeZoneOffset { get; set; }
        public bool? CreateMissingObjects { get; set; }
        public bool? UpdateExistingResults { get; set; }
    }

    [Route("/v1/services/import/labreportdata/dryrun", "POST")]
    public class PostImportLabReportDataDryRun : IReturn<ObservationImportSummary>
    {
        public string FileType { get; set; }
        public string TimeZoneOffset { get; set; }
        public bool? CreateMissingObjects { get; set; }
        public bool? UpdateExistingResults { get; set; }
    }

    [Route("/v1/services/import/observations", "POST")]
    public class PostImportObservations : IReturn<ObservationImportSummary>
    {
        public string FileType { get; set; }
        public string TimeZoneOffset { get; set; }
        public bool? LinkFieldVisitsForNewObservations { get; set; }
    }

    [Route("/v1/services/import/observations/dryrun", "POST")]
    public class PostImportObservationsDryRun : IReturn<ObservationImportSummary>
    {
        public string FileType { get; set; }
        public string TimeZoneOffset { get; set; }
        public bool? LinkFieldVisitsForNewObservations { get; set; }
    }

    [Route("/v1/services/import/observedproperties", "POST")]
    public class PostImportObservedProperties : IReturn<ObservedPropertyImportSummary>
    {
        
    }

    [Route("/v1/services/import/observedproperties/dryrun", "POST")]
    public class PostImportObservedPropertiesDryRun : IReturn<ObservedPropertyImportSummary>
    {
        
    }

    [Route("/v1/services/import/samplinglocations", "POST")]
    public class PostImportSamplingLocations : IReturn<SamplingLocationImportSummary>
    {
        public string FileType { get; set; }
    }

    [Route("/v1/services/import/samplinglocations/dryrun", "POST")]
    public class PostImportSamplingLocationsDryRun : IReturn<SamplingLocationImportSummary>
    {
        public string FileType { get; set; }
    }

    [Route("/v1/services/import/samplingplan", "POST")]
    public class PostImportSamplingPlan : IReturn<FieldSheetImportSummary>
    {
        public string TimeZoneOffset { get; set; }
    }

    [Route("/v1/services/import/samplingplan/dryrun", "POST")]
    public class PostImportSamplingPlanDryRun : IReturn<FieldSheetImportSummary>
    {
        public string TimeZoneOffset { get; set; }
    }

    [Route("/v1/services/import/taxons", "POST")]
    public class PostImportTaxons : IReturn<TaxonImportSummary>
    {
        
    }

    [Route("/v1/services/import/taxons/dryrun", "POST")]
    public class PostImportTaxonsDryRun : IReturn<TaxonImportSummary>
    {
        
    }

    [Route("/v1/services/import/verticalprofiledata", "POST")]
    public class PostImportVerticalProfileData : IReturnVoid
    {
        public string ActivityId { get; set; }
        public string SamplingLocationIds { get; set; }
        public string TimeZoneOffset { get; set; }
    }

    [Route("/v1/shippingcontainers", "GET")]
    public class GetShippingContainers : IReturn<SearchResultShippingContainer>
    {
        public int? Limit { get; set; }
        public List<string> Search { get; set; }
    }

    [Route("/v1/shippingcontainers", "POST")]
    public class PostShippingContainer : IReturn<ShippingContainer>
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public string TrackingId { get; set; }
        public string Comment { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/shippingcontainers/{id}", "GET")]
    public class GetShippingContainer : IReturn<ShippingContainer>
    {
        public string Id { get; set; }
    }

    [Route("/v1/shippingcontainers/{id}", "PUT")]
    public class PutShippingContainer : IReturn<ShippingContainer>
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public string TrackingId { get; set; }
        public string Comment { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/shippingcontainers/{id}", "DELETE")]
    public class DeleteShippingContainer : IReturnVoid
    {
        public string Id { get; set; }
    }

    [Route("/v1/specimens", "GET")]
    public class GetSpecimens : IReturn<SearchResultSpecimen>, IPaginatedRequest
    {
        public List<string> ActivityIds { get; set; }
        public List<string> ActivityTypes { get; set; }
        public Instant? After { get; set; }
        public List<string> AnalyticalGroupIds { get; set; }
        public Instant? Before { get; set; }
        public string Cursor { get; set; }
        public Instant? EndModificationTime { get; set; }
        public List<string> FieldTripIds { get; set; }
        public string FieldVisitId { get; set; }
        public List<string> LaboratoryIds { get; set; }
        public int? Limit { get; set; }
        public List<string> ProjectIds { get; set; }
        public List<string> SamplingLocationGroupIds { get; set; }
        public List<string> SamplingLocationIds { get; set; }
        public List<string> Search { get; set; }
        public string Sort { get; set; }
        public List<string> SpecimenStatuses { get; set; }
        public Instant? StartModificationTime { get; set; }
    }

    [Route("/v1/specimens", "POST")]
    public class PostSpecimen : IReturn<SpecimenWithObservations>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public PreservativeType? Preservative { get; set; }
        public bool? Filtered { get; set; }
        public string FiltrationComment { get; set; }
        public Laboratory Laboratory { get; set; }
        public ShippingContainer ShippingContainer { get; set; }
        public AnalyticalGroup AnalyticalGroup { get; set; }
        public Activity Activity { get; set; }
        public SpecimenTemplate TemplateCreatedFrom { get; set; }
        public List<ExtendedAttribute> ExtendedAttributes { get; set; }
        public SpecimenViewStatusType? Status { get; set; }
        public int? NumberOfRequestedObservations { get; set; }
        public int? NumberOfReceivedObservations { get; set; }
        public List<Observation> Observations { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/specimens/{id}", "GET")]
    public class GetSpecimen : IReturn<SpecimenWithObservations>
    {
        public string Id { get; set; }
        public bool? Detail { get; set; }
    }

    [Route("/v1/specimens/{id}", "PUT")]
    public class PutSpecimen : IReturn<SpecimenWithObservations>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public PreservativeType? Preservative { get; set; }
        public bool? Filtered { get; set; }
        public string FiltrationComment { get; set; }
        public Laboratory Laboratory { get; set; }
        public ShippingContainer ShippingContainer { get; set; }
        public AnalyticalGroup AnalyticalGroup { get; set; }
        public Activity Activity { get; set; }
        public SpecimenTemplate TemplateCreatedFrom { get; set; }
        public List<ExtendedAttribute> ExtendedAttributes { get; set; }
        public SpecimenViewStatusType? Status { get; set; }
        public int? NumberOfRequestedObservations { get; set; }
        public int? NumberOfReceivedObservations { get; set; }
        public List<Observation> Observations { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/specimens/{id}", "DELETE")]
    public class DeleteSpecimen : IReturnVoid
    {
        public string Id { get; set; }
    }

    [Route("/v1/specimens/{id}/history", "GET")]
    public class GetSpecimenHistory : IReturn<SearchResultAuditHistory>
    {
        public string Id { get; set; }
    }

    [Route("/v1/specimens/{id}/observations", "GET")]
    public class GetSpecimenObservations : IReturn<SearchResultObservationNestedInSpecimen>
    {
        public string Id { get; set; }
    }

    [Route("/v1/spreadsheettemplates", "GET")]
    public class GetSpreadsheetTemplates : IReturn<SearchResultSpreadsheetTemplate>
    {
        
    }

    [Route("/v1/spreadsheettemplates", "POST")]
    public class PostSpreadsheetTemplate : IReturn<SpreadsheetTemplate>
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public SpreadsheetTemplateType? Type { get; set; }
        public string Description { get; set; }
        public List<DomainObjectAttachment> Attachments { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/spreadsheettemplates/{id}", "GET")]
    public class GetSpreadsheetTemplate : IReturn<SpreadsheetTemplate>
    {
        public string Id { get; set; }
    }

    [Route("/v1/spreadsheettemplates/{id}", "PUT")]
    public class PutSpreadsheetTemplate : IReturn<SpreadsheetTemplate>
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public SpreadsheetTemplateType? Type { get; set; }
        public string Description { get; set; }
        public List<DomainObjectAttachment> Attachments { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/spreadsheettemplates/{id}", "DELETE")]
    public class DeleteSpreadsheetTemplate : IReturnVoid
    {
        public string Id { get; set; }
    }

    [Route("/v1/spreadsheettemplates/{id}/history", "GET")]
    public class GetSpreadsheetTemplateHistory : IReturn<SearchResultAuditHistory>
    {
        public string Id { get; set; }
    }

    [Route("/v1/standards", "GET")]
    public class GetStandards : IReturn<SearchResultStandardSimple>
    {
        
    }

    [Route("/v1/standards", "POST")]
    public class PostStandard : IReturn<StandardDefinition>
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string IssuingOrganization { get; set; }
        public TimeRange ApplicabilityRange { get; set; }
        public bool? Active { get; set; }
        public List<SamplingLocationSimple> SamplingLocations { get; set; }
        public List<ObservationStandard> ObservationStandards { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/standards/{id}", "GET")]
    public class GetStandard : IReturn<StandardDefinition>
    {
        public string Id { get; set; }
    }

    [Route("/v1/standards/{id}", "PUT")]
    public class PutStandard : IReturn<StandardDefinition>
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string IssuingOrganization { get; set; }
        public TimeRange ApplicabilityRange { get; set; }
        public bool? Active { get; set; }
        public List<SamplingLocationSimple> SamplingLocations { get; set; }
        public List<ObservationStandard> ObservationStandards { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/standards/{id}", "DELETE")]
    public class DeleteStandard : IReturnVoid
    {
        public string Id { get; set; }
    }

    [Route("/v1/standards/{id}/history", "GET")]
    public class GetStandardHistory : IReturn<SearchResultAuditHistory>
    {
        public string Id { get; set; }
    }

    [Route("/v1/status", "GET")]
    public class GetStatus : IReturn<Status>
    {
        
    }

    [Route("/v1/tags", "GET")]
    public class GetTags : IReturn<SearchResultSamplingContextTag>
    {
        
    }

    [Route("/v1/tags", "POST")]
    public class PostTag : IReturn<SamplingContextTag>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/tags/{id}", "GET")]
    public class GetTag : IReturn<SamplingContextTag>
    {
        public string Id { get; set; }
    }

    [Route("/v1/tags/{id}", "PUT")]
    public class PutTag : IReturn<SamplingContextTag>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/tags/{id}", "DELETE")]
    public class DeleteTag : IReturnVoid
    {
        public string Id { get; set; }
    }

    [Route("/v1/tags/{id}/history", "GET")]
    public class GetTagHistory : IReturn<SearchResultAuditHistory>
    {
        public string Id { get; set; }
    }

    [Route("/v1/taxonomylevels", "GET")]
    public class GetTaxonomyLevels : IReturn<SearchResultTaxonomyLevel>
    {
        
    }

    [Route("/v1/taxonomylevels", "PUT")]
    public class PutTaxonomyLevels : IReturn<List<TaxonomyLevel>>
    {
        
    }

    [Route("/v1/taxonomylevels/{id}/history", "GET")]
    public class GetTaxonomyLevelHistory : IReturn<SearchResultAuditHistory>
    {
        public string Id { get; set; }
    }

    [Route("/v1/taxons", "GET")]
    public class GetTaxons : IReturn<SearchResultTaxon>
    {
        public string ScientificName { get; set; }
    }

    [Route("/v1/taxons", "POST")]
    public class PostTaxon : IReturn<Taxon>
    {
        public List<ImportHistoryEventSimple> ImportHistoryEventSimples { get; set; }
        public string Id { get; set; }
        public string ScientificName { get; set; }
        public string CommonName { get; set; }
        public TaxonomyLevel TaxonomyLevel { get; set; }
        public string Source { get; set; }
        public string Comment { get; set; }
        public string ItisTsn { get; set; }
        public string ItisComment { get; set; }
        public string ItisUrl { get; set; }
        public string ParentId { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/taxons/{id}", "GET")]
    public class GetTaxon : IReturn<Taxon>
    {
        public string Id { get; set; }
    }

    [Route("/v1/taxons/{id}", "PUT")]
    public class PutTaxon : IReturn<Taxon>
    {
        public string Id { get; set; }
        public List<ImportHistoryEventSimple> ImportHistoryEventSimples { get; set; }
        public string ScientificName { get; set; }
        public string CommonName { get; set; }
        public TaxonomyLevel TaxonomyLevel { get; set; }
        public string Source { get; set; }
        public string Comment { get; set; }
        public string ItisTsn { get; set; }
        public string ItisComment { get; set; }
        public string ItisUrl { get; set; }
        public string ParentId { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/taxons/{id}", "DELETE")]
    public class DeleteTaxon : IReturnVoid
    {
        public string Id { get; set; }
    }

    [Route("/v1/taxons/{id}/history", "GET")]
    public class GetTaxonHistory : IReturn<SearchResultAuditHistory>
    {
        public string Id { get; set; }
    }

    [Route("/v1/timezones", "GET")]
    public class GetTimeZones : IReturn<SearchResultTimeZone>
    {
        
    }

    [Route("/v1/unitgroups", "GET")]
    public class GetUnitGroups : IReturn<SearchResultUnitGroup>
    {
        public string CustomId { get; set; }
        public GetUnitGroupsSystemCodeType? SystemCode { get; set; }
    }

    [Route("/v1/unitgroups", "POST")]
    public class PostUnitGroup : IReturn<UnitGroup>
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public bool? SupportsConversion { get; set; }
        public UnitGroupSystemCodeType? SystemCode { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/unitgroups/{id}", "GET")]
    public class GetUnitGroup : IReturn<UnitGroup>
    {
        public string Id { get; set; }
    }

    [Route("/v1/unitgroups/{id}", "PUT")]
    public class PutUnitGroup : IReturn<UnitGroup>
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public bool? SupportsConversion { get; set; }
        public UnitGroupSystemCodeType? SystemCode { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/unitgroups/{id}", "DELETE")]
    public class DeleteUnitGroup : IReturnVoid
    {
        public string Id { get; set; }
    }

    [Route("/v1/unitgroups/{id}/history", "GET")]
    public class GetUnitGroupHistory : IReturn<SearchResultAuditHistory>
    {
        public string Id { get; set; }
    }

    [Route("/v1/unitgroupwithunits", "GET")]
    public class GetUnitGroupWithUnits : IReturn<SearchResultUnitGroupWithUnits>
    {
        public string CustomId { get; set; }
        public GetUnitGroupWithUnitsSystemCodeType? SystemCode { get; set; }
    }

    [Route("/v1/unitgroupwithunits", "POST")]
    public class PostUnitGroupWithUnit : IReturn<UnitGroupWithUnits>
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public bool? SupportsConversion { get; set; }
        public UnitGroupWithUnitsSystemCodeType? SystemCode { get; set; }
        public List<Unit> Units { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/unitgroupwithunits/{id}", "GET")]
    public class GetUnitGroupWithUnit : IReturn<UnitGroupWithUnits>
    {
        public string Id { get; set; }
    }

    [Route("/v1/unitgroupwithunits/{id}", "PUT")]
    public class PutUnitGroupWithUnit : IReturn<UnitGroup>
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public bool? SupportsConversion { get; set; }
        public UnitGroupSystemCodeType? SystemCode { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/unitgroupwithunits/{id}", "DELETE")]
    public class DeleteUnitGroupWithUnit : IReturnVoid
    {
        public string Id { get; set; }
    }

    [Route("/v1/unitgroupwithunits/{id}/history", "GET")]
    public class GetUnitGroupWithUnitHistory : IReturn<SearchResultAuditHistory>
    {
        public string Id { get; set; }
    }

    [Route("/v1/units", "GET")]
    public class GetUnits : IReturn<SearchResultUnit>
    {
        public string CustomId { get; set; }
        public string Unitgroup { get; set; }
    }

    [Route("/v1/units", "POST")]
    public class PostUnit : IReturn<Unit>
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public string Name { get; set; }
        public double? BaseMultiplier { get; set; }
        public double? BaseOffset { get; set; }
        public UnitGroup UnitGroup { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/units/{id}", "GET")]
    public class GetUnit : IReturn<Unit>
    {
        public string Id { get; set; }
    }

    [Route("/v1/units/{id}", "PUT")]
    public class PutUnit : IReturn<Unit>
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public string Name { get; set; }
        public double? BaseMultiplier { get; set; }
        public double? BaseOffset { get; set; }
        public UnitGroup UnitGroup { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/units/{id}", "DELETE")]
    public class DeleteUnit : IReturnVoid
    {
        public string Id { get; set; }
    }

    [Route("/v1/units/{id}/history", "GET")]
    public class GetUnitHistory : IReturn<SearchResultAuditHistory>
    {
        public string Id { get; set; }
    }

    [Route("/v1/users", "GET")]
    public class GetUsers : IReturn<SearchResultUser>
    {
        
    }

    [Route("/v1/users", "POST")]
    public class PostUser : IReturn<User>
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public UserProfile UserProfile { get; set; }
        public string ProviderId { get; set; }
        public string Email { get; set; }
        public UserType? UserType { get; set; }
        public List<string> Roles { get; set; }
        public List<string> AccessGroups { get; set; }
    }

    [Route("/v1/users/{id}", "GET")]
    public class GetUser : IReturn<User>
    {
        public string Id { get; set; }
    }

    [Route("/v1/users/{id}", "PUT")]
    public class PutUser : IReturn<User>
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public UserProfile UserProfile { get; set; }
        public string ProviderId { get; set; }
        public string Email { get; set; }
        public UserType? UserType { get; set; }
        public List<string> Roles { get; set; }
        public List<string> AccessGroups { get; set; }
    }

    [Route("/v1/users/{id}", "DELETE")]
    public class DeleteUser : IReturnVoid
    {
        public string Id { get; set; }
    }

    [Route("/v2/observationimports", "POST")]
    public class PostObservationImportV2 : IReturnVoid
    {
        public string FileType { get; set; }
        public string TimeZoneOffset { get; set; }
        public bool? LinkFieldVisitsForNewObservations { get; set; }
    }

    [Route("/v2/observationimports/{id}/result", "GET")]
    public class GetObservationImportResultV2 : IReturn<ObservationImportSummary>
    {
        public string Id { get; set; }
    }

    [Route("/v2/observationimports/{id}/status", "GET")]
    public class GetObservationImportStatusV2 : IReturn<ImportProcessorTransactionStatusResponse>
    {
        public string Id { get; set; }
    }

    [Route("/v2/observationimports/dryrun", "POST")]
    public class PostObservationsDryRunV2 : IReturnVoid
    {
        public string FileType { get; set; }
        public string TimeZoneOffset { get; set; }
        public bool? LinkFieldVisitsForNewObservations { get; set; }
    }

    [DataContract]
    [Route("/v2/observations", "GET")]
    public class GetObservationsV2 : IReturn<SearchResultObservation>, IPaginatedRequest
    {
        [DataMember(Name = "activityCustomId")]
        public string ActivityCustomId { get; set; }
        [DataMember(Name = "activityIds")]
        public List<string> ActivityIds { get; set; }
        [DataMember(Name = "activityTypes")]
        public List<string> ActivityTypes { get; set; }
        [DataMember(Name = "analysisMethodIds")]
        public List<string> AnalysisMethodIds { get; set; }
        [DataMember(Name = "analyticalGroupIds")]
        public List<string> AnalyticalGroupIds { get; set; }
        [DataMember(Name = "collectionMethodIds")]
        public List<string> CollectionMethodIds { get; set; }
        [DataMember(Name = "cursor")]
        public string Cursor { get; set; }
        [DataMember(Name = "customId")]
        public string CustomId { get; set; }
        [DataMember(Name = "dataClassifications")]
        public List<string> DataClassifications { get; set; }
        [DataMember(Name = "depthUnitCustomId")]
        public string DepthUnitCustomId { get; set; }
        [DataMember(Name = "depthUnitId")]
        public string DepthUnitId { get; set; }
        [DataMember(Name = "depthValue")]
        public double? DepthValue { get; set; }
        [DataMember(Name = "detectionCondition")]
        public string DetectionCondition { get; set; }
        [DataMember(Name = "end-observedTime")]
        public Instant? EndObservedTime { get; set; }
        [DataMember(Name = "end-resultTime")]
        public Instant? EndResultTime { get; set; }
        [DataMember(Name = "endModificationTime")]
        public Instant? EndModificationTime { get; set; }
        [DataMember(Name = "fieldResultType")]
        public FieldResultType? FieldResultType { get; set; }
        [DataMember(Name = "fieldVisitId")]
        public string FieldVisitId { get; set; }
        [DataMember(Name = "filterId")]
        public string FilterId { get; set; }
        [DataMember(Name = "ids")]
        public List<string> Ids { get; set; }
        [DataMember(Name = "importHistoryEventId")]
        public string ImportHistoryEventId { get; set; }
        [DataMember(Name = "labReportIds")]
        public List<string> LabReportIds { get; set; }
        [DataMember(Name = "labResultLabAnalysisMethodIds")]
        public List<string> LabResultLabAnalysisMethodIds { get; set; }
        [DataMember(Name = "labResultLaboratoryIds")]
        public List<string> LabResultLaboratoryIds { get; set; }
        [DataMember(Name = "limit")]
        public int? Limit { get; set; }
        [DataMember(Name = "max-numericResultValue")]
        public double? MaxNumericResultValue { get; set; }
        [DataMember(Name = "media")]
        public List<string> Media { get; set; }
        [DataMember(Name = "min-numericResultValue")]
        public double? MinNumericResultValue { get; set; }
        [DataMember(Name = "numericResultValue")]
        public double? NumericResultValue { get; set; }
        [DataMember(Name = "observedPropertyIds")]
        public List<string> ObservedPropertyIds { get; set; }
        [DataMember(Name = "projectIds")]
        public List<string> ProjectIds { get; set; }
        [DataMember(Name = "qualityControlTypes")]
        public List<string> QualityControlTypes { get; set; }
        [DataMember(Name = "resultGrades")]
        public List<string> ResultGrades { get; set; }
        [DataMember(Name = "resultStatuses")]
        public List<string> ResultStatuses { get; set; }
        [DataMember(Name = "sampleFraction")]
        public SampleFractionType? SampleFraction { get; set; }
        [DataMember(Name = "samplingContextTagIds")]
        public List<string> SamplingContextTagIds { get; set; }
        [DataMember(Name = "samplingLocationGroupIds")]
        public List<string> SamplingLocationGroupIds { get; set; }
        [DataMember(Name = "samplingLocationIds")]
        public List<string> SamplingLocationIds { get; set; }
        [DataMember(Name = "search")]
        public List<string> Search { get; set; }
        [DataMember(Name = "sort")]
        public string Sort { get; set; }
        [DataMember(Name = "specimenIds")]
        public List<string> SpecimenIds { get; set; }
        [DataMember(Name = "specimenName")]
        public string SpecimenName { get; set; }
        [DataMember(Name = "start-observedTime")]
        public Instant? StartObservedTime { get; set; }
        [DataMember(Name = "start-resultTime")]
        public Instant? StartResultTime { get; set; }
        [DataMember(Name = "startModificationTime")]
        public Instant? StartModificationTime { get; set; }
        [DataMember(Name = "taxonIds")]
        public List<string> TaxonIds { get; set; }
    }

    [Route("/v2/observations", "POST")]
    public class PostObservationV2 : IReturn<Observation>
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public Activity Activity { get; set; }
        public CollectionMethod CollectionMethod { get; set; }
        public ObservedProperty ObservedProperty { get; set; }
        public Specimen Specimen { get; set; }
        public SamplingLocation SamplingLocation { get; set; }
        public NumericResult NumericResult { get; set; }
        public CategoricalResult CategoricalResult { get; set; }
        public TaxonomicResult TaxonomicResult { get; set; }
        public QualityControlType? QualityControlType { get; set; }
        public DataClassificationType? DataClassification { get; set; }
        public Medium Medium { get; set; }
        public string MediumSubdivision { get; set; }
        public Instant? ObservedTime { get; set; }
        public Instant? ResultTime { get; set; }
        public Quantity Depth { get; set; }
        public LabInstruction LabInstruction { get; set; }
        public LabResultDetails LabResultDetails { get; set; }
        public AnalysisMethodSimple AnalysisMethod { get; set; }
        public string Comment { get; set; }
        public FieldVisit FieldVisit { get; set; }
        public Device Device { get; set; }
        public List<ImportHistoryEventSimple> ImportHistoryEventSimples { get; set; }
        public List<RuleValidationDetails> ValidationWarnings { get; set; }
        public ResultGrade ResultGrade { get; set; }
        public ResultStatus ResultStatus { get; set; }
        public PlannedFieldResult PlannedFieldResult { get; set; }
        public ObservationStatistics Statistics { get; set; }
        public Taxon RelatedTaxon { get; set; }
        public List<ExtendedAttribute> ExtendedAttributes { get; set; }
        public NullMeasureQualifier NullMeasureQualifier { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [DataContract]
    [Route("/v2/observations", "DELETE")]
    public class DeleteObservationsV2 : IReturnVoid
    {
        [DataMember(Name = "activityCustomId")]
        public string ActivityCustomId { get; set; }
        [DataMember(Name = "activityIds")]
        public List<string> ActivityIds { get; set; }
        [DataMember(Name = "activityTypes")]
        public List<string> ActivityTypes { get; set; }
        [DataMember(Name = "analysisMethodIds")]
        public List<string> AnalysisMethodIds { get; set; }
        [DataMember(Name = "analyticalGroupIds")]
        public List<string> AnalyticalGroupIds { get; set; }
        [DataMember(Name = "collectionMethodIds")]
        public List<string> CollectionMethodIds { get; set; }
        [DataMember(Name = "cursor")]
        public string Cursor { get; set; }
        [DataMember(Name = "customId")]
        public string CustomId { get; set; }
        [DataMember(Name = "dataClassifications")]
        public List<string> DataClassifications { get; set; }
        [DataMember(Name = "depthUnitCustomId")]
        public string DepthUnitCustomId { get; set; }
        [DataMember(Name = "depthUnitId")]
        public string DepthUnitId { get; set; }
        [DataMember(Name = "depthValue")]
        public double? DepthValue { get; set; }
        [DataMember(Name = "detectionCondition")]
        public string DetectionCondition { get; set; }
        [DataMember(Name = "end-observedTime")]
        public Instant? EndObservedTime { get; set; }
        [DataMember(Name = "end-resultTime")]
        public Instant? EndResultTime { get; set; }
        [DataMember(Name = "endModificationTime")]
        public Instant? EndModificationTime { get; set; }
        [DataMember(Name = "fieldResultType")]
        public FieldResultType? FieldResultType { get; set; }
        [DataMember(Name = "fieldVisitId")]
        public string FieldVisitId { get; set; }
        [DataMember(Name = "filterId")]
        public string FilterId { get; set; }
        [DataMember(Name = "ids")]
        public List<string> Ids { get; set; }
        [DataMember(Name = "importHistoryEventId")]
        public string ImportHistoryEventId { get; set; }
        [DataMember(Name = "labReportIds")]
        public List<string> LabReportIds { get; set; }
        [DataMember(Name = "labResultLabAnalysisMethodIds")]
        public List<string> LabResultLabAnalysisMethodIds { get; set; }
        [DataMember(Name = "labResultLaboratoryIds")]
        public List<string> LabResultLaboratoryIds { get; set; }
        [DataMember(Name = "limit")]
        public int? Limit { get; set; }
        [DataMember(Name = "max-numericResultValue")]
        public double? MaxNumericResultValue { get; set; }
        [DataMember(Name = "media")]
        public List<string> Media { get; set; }
        [DataMember(Name = "min-numericResultValue")]
        public double? MinNumericResultValue { get; set; }
        [DataMember(Name = "numericResultValue")]
        public double? NumericResultValue { get; set; }
        [DataMember(Name = "observedPropertyIds")]
        public List<string> ObservedPropertyIds { get; set; }
        [DataMember(Name = "projectIds")]
        public List<string> ProjectIds { get; set; }
        [DataMember(Name = "qualityControlTypes")]
        public List<string> QualityControlTypes { get; set; }
        [DataMember(Name = "resultGrades")]
        public List<string> ResultGrades { get; set; }
        [DataMember(Name = "resultStatuses")]
        public List<string> ResultStatuses { get; set; }
        [DataMember(Name = "sampleFraction")]
        public SampleFractionType? SampleFraction { get; set; }
        [DataMember(Name = "samplingContextTagIds")]
        public List<string> SamplingContextTagIds { get; set; }
        [DataMember(Name = "samplingLocationGroupIds")]
        public List<string> SamplingLocationGroupIds { get; set; }
        [DataMember(Name = "samplingLocationIds")]
        public List<string> SamplingLocationIds { get; set; }
        [DataMember(Name = "search")]
        public List<string> Search { get; set; }
        [DataMember(Name = "sort")]
        public string Sort { get; set; }
        [DataMember(Name = "specimenIds")]
        public List<string> SpecimenIds { get; set; }
        [DataMember(Name = "specimenName")]
        public string SpecimenName { get; set; }
        [DataMember(Name = "start-observedTime")]
        public Instant? StartObservedTime { get; set; }
        [DataMember(Name = "start-resultTime")]
        public Instant? StartResultTime { get; set; }
        [DataMember(Name = "startModificationTime")]
        public Instant? StartModificationTime { get; set; }
        [DataMember(Name = "taxonIds")]
        public List<string> TaxonIds { get; set; }
    }

    [Route("/v2/observations/{id}", "GET")]
    public class GetObservationV2 : IReturn<Observation>
    {
        public string Id { get; set; }
    }

    [Route("/v2/observations/{id}", "PUT")]
    public class PutObservationV2 : IReturn<Observation>
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public Activity Activity { get; set; }
        public CollectionMethod CollectionMethod { get; set; }
        public ObservedProperty ObservedProperty { get; set; }
        public Specimen Specimen { get; set; }
        public SamplingLocation SamplingLocation { get; set; }
        public NumericResult NumericResult { get; set; }
        public CategoricalResult CategoricalResult { get; set; }
        public TaxonomicResult TaxonomicResult { get; set; }
        public QualityControlType? QualityControlType { get; set; }
        public DataClassificationType? DataClassification { get; set; }
        public Medium Medium { get; set; }
        public string MediumSubdivision { get; set; }
        public Instant? ObservedTime { get; set; }
        public Instant? ResultTime { get; set; }
        public Quantity Depth { get; set; }
        public LabInstruction LabInstruction { get; set; }
        public LabResultDetails LabResultDetails { get; set; }
        public AnalysisMethodSimple AnalysisMethod { get; set; }
        public string Comment { get; set; }
        public FieldVisit FieldVisit { get; set; }
        public Device Device { get; set; }
        public List<ImportHistoryEventSimple> ImportHistoryEventSimples { get; set; }
        public List<RuleValidationDetails> ValidationWarnings { get; set; }
        public ResultGrade ResultGrade { get; set; }
        public ResultStatus ResultStatus { get; set; }
        public PlannedFieldResult PlannedFieldResult { get; set; }
        public ObservationStatistics Statistics { get; set; }
        public Taxon RelatedTaxon { get; set; }
        public List<ExtendedAttribute> ExtendedAttributes { get; set; }
        public NullMeasureQualifier NullMeasureQualifier { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v2/observations/{id}", "DELETE")]
    public class DeleteObservationV2 : IReturnVoid
    {
        public string Id { get; set; }
    }

    [Route("/v2/observations/{id}/history", "GET")]
    public class GetObservationHistoryV2 : IReturn<SearchResultAuditHistory>
    {
        public string Id { get; set; }
    }

    [DataContract]
    [Route("/v2/observations/charts", "GET")]
    public class GetChartDataV2 : IReturn<MultiChartData>
    {
        [DataMember(Name = "activityCustomId")]
        public string ActivityCustomId { get; set; }
        [DataMember(Name = "activityIds")]
        public List<string> ActivityIds { get; set; }
        [DataMember(Name = "activityTypes")]
        public List<string> ActivityTypes { get; set; }
        [DataMember(Name = "analysisMethodIds")]
        public List<string> AnalysisMethodIds { get; set; }
        [DataMember(Name = "analyticalGroupIds")]
        public List<string> AnalyticalGroupIds { get; set; }
        [DataMember(Name = "collectionMethodIds")]
        public List<string> CollectionMethodIds { get; set; }
        [DataMember(Name = "cursor")]
        public string Cursor { get; set; }
        [DataMember(Name = "customId")]
        public string CustomId { get; set; }
        [DataMember(Name = "dataClassifications")]
        public List<string> DataClassifications { get; set; }
        [DataMember(Name = "depthUnitCustomId")]
        public string DepthUnitCustomId { get; set; }
        [DataMember(Name = "depthUnitId")]
        public string DepthUnitId { get; set; }
        [DataMember(Name = "depthValue")]
        public double? DepthValue { get; set; }
        [DataMember(Name = "detectionCondition")]
        public string DetectionCondition { get; set; }
        [DataMember(Name = "end-observedTime")]
        public Instant? EndObservedTime { get; set; }
        [DataMember(Name = "end-resultTime")]
        public Instant? EndResultTime { get; set; }
        [DataMember(Name = "endModificationTime")]
        public Instant? EndModificationTime { get; set; }
        [DataMember(Name = "fieldResultType")]
        public FieldResultType? FieldResultType { get; set; }
        [DataMember(Name = "fieldVisitId")]
        public string FieldVisitId { get; set; }
        [DataMember(Name = "filterId")]
        public string FilterId { get; set; }
        [DataMember(Name = "ids")]
        public List<string> Ids { get; set; }
        [DataMember(Name = "importHistoryEventId")]
        public string ImportHistoryEventId { get; set; }
        [DataMember(Name = "labReportIds")]
        public List<string> LabReportIds { get; set; }
        [DataMember(Name = "labResultLabAnalysisMethodIds")]
        public List<string> LabResultLabAnalysisMethodIds { get; set; }
        [DataMember(Name = "labResultLaboratoryIds")]
        public List<string> LabResultLaboratoryIds { get; set; }
        [DataMember(Name = "limit")]
        public int? Limit { get; set; }
        [DataMember(Name = "max-numericResultValue")]
        public double? MaxNumericResultValue { get; set; }
        [DataMember(Name = "media")]
        public List<string> Media { get; set; }
        [DataMember(Name = "min-numericResultValue")]
        public double? MinNumericResultValue { get; set; }
        [DataMember(Name = "numericResultValue")]
        public double? NumericResultValue { get; set; }
        [DataMember(Name = "observedPropertyIds")]
        public List<string> ObservedPropertyIds { get; set; }
        [DataMember(Name = "projectIds")]
        public List<string> ProjectIds { get; set; }
        [DataMember(Name = "qualityControlTypes")]
        public List<string> QualityControlTypes { get; set; }
        [DataMember(Name = "resultGrades")]
        public List<string> ResultGrades { get; set; }
        [DataMember(Name = "resultStatuses")]
        public List<string> ResultStatuses { get; set; }
        [DataMember(Name = "sampleFraction")]
        public SampleFractionType? SampleFraction { get; set; }
        [DataMember(Name = "samplingContextTagIds")]
        public List<string> SamplingContextTagIds { get; set; }
        [DataMember(Name = "samplingLocationGroupIds")]
        public List<string> SamplingLocationGroupIds { get; set; }
        [DataMember(Name = "samplingLocationIds")]
        public List<string> SamplingLocationIds { get; set; }
        [DataMember(Name = "search")]
        public List<string> Search { get; set; }
        [DataMember(Name = "sort")]
        public string Sort { get; set; }
        [DataMember(Name = "specimenIds")]
        public List<string> SpecimenIds { get; set; }
        [DataMember(Name = "specimenName")]
        public string SpecimenName { get; set; }
        [DataMember(Name = "start-observedTime")]
        public Instant? StartObservedTime { get; set; }
        [DataMember(Name = "start-resultTime")]
        public Instant? StartResultTime { get; set; }
        [DataMember(Name = "startModificationTime")]
        public Instant? StartModificationTime { get; set; }
        [DataMember(Name = "taxonIds")]
        public List<string> TaxonIds { get; set; }
    }

    [DataContract]
    [Route("/v2/observations/geographic", "GET")]
    public class GetGroupedObservationsV2 : IReturn<SearchResultLocationObservationsGroup>, IPaginatedRequest
    {
        [DataMember(Name = "activityCustomId")]
        public string ActivityCustomId { get; set; }
        [DataMember(Name = "activityIds")]
        public List<string> ActivityIds { get; set; }
        [DataMember(Name = "activityTypes")]
        public List<string> ActivityTypes { get; set; }
        [DataMember(Name = "analysisMethodIds")]
        public List<string> AnalysisMethodIds { get; set; }
        [DataMember(Name = "analyticalGroupIds")]
        public List<string> AnalyticalGroupIds { get; set; }
        [DataMember(Name = "collectionMethodIds")]
        public List<string> CollectionMethodIds { get; set; }
        [DataMember(Name = "cursor")]
        public string Cursor { get; set; }
        [DataMember(Name = "customId")]
        public string CustomId { get; set; }
        [DataMember(Name = "dataClassifications")]
        public List<string> DataClassifications { get; set; }
        [DataMember(Name = "depthUnitCustomId")]
        public string DepthUnitCustomId { get; set; }
        [DataMember(Name = "depthUnitId")]
        public string DepthUnitId { get; set; }
        [DataMember(Name = "depthValue")]
        public double? DepthValue { get; set; }
        [DataMember(Name = "detectionCondition")]
        public string DetectionCondition { get; set; }
        [DataMember(Name = "end-observedTime")]
        public Instant? EndObservedTime { get; set; }
        [DataMember(Name = "end-resultTime")]
        public Instant? EndResultTime { get; set; }
        [DataMember(Name = "endModificationTime")]
        public Instant? EndModificationTime { get; set; }
        [DataMember(Name = "fieldResultType")]
        public FieldResultType? FieldResultType { get; set; }
        [DataMember(Name = "fieldVisitId")]
        public string FieldVisitId { get; set; }
        [DataMember(Name = "filterId")]
        public string FilterId { get; set; }
        [DataMember(Name = "ids")]
        public List<string> Ids { get; set; }
        [DataMember(Name = "importHistoryEventId")]
        public string ImportHistoryEventId { get; set; }
        [DataMember(Name = "labReportIds")]
        public List<string> LabReportIds { get; set; }
        [DataMember(Name = "labResultLabAnalysisMethodIds")]
        public List<string> LabResultLabAnalysisMethodIds { get; set; }
        [DataMember(Name = "labResultLaboratoryIds")]
        public List<string> LabResultLaboratoryIds { get; set; }
        [DataMember(Name = "limit")]
        public int? Limit { get; set; }
        [DataMember(Name = "max-numericResultValue")]
        public double? MaxNumericResultValue { get; set; }
        [DataMember(Name = "media")]
        public List<string> Media { get; set; }
        [DataMember(Name = "min-numericResultValue")]
        public double? MinNumericResultValue { get; set; }
        [DataMember(Name = "numericResultValue")]
        public double? NumericResultValue { get; set; }
        [DataMember(Name = "observedPropertyIds")]
        public List<string> ObservedPropertyIds { get; set; }
        [DataMember(Name = "projectIds")]
        public List<string> ProjectIds { get; set; }
        [DataMember(Name = "qualityControlTypes")]
        public List<string> QualityControlTypes { get; set; }
        [DataMember(Name = "resultGrades")]
        public List<string> ResultGrades { get; set; }
        [DataMember(Name = "resultStatuses")]
        public List<string> ResultStatuses { get; set; }
        [DataMember(Name = "sampleFraction")]
        public SampleFractionType? SampleFraction { get; set; }
        [DataMember(Name = "samplingContextTagIds")]
        public List<string> SamplingContextTagIds { get; set; }
        [DataMember(Name = "samplingLocationGroupIds")]
        public List<string> SamplingLocationGroupIds { get; set; }
        [DataMember(Name = "samplingLocationIds")]
        public List<string> SamplingLocationIds { get; set; }
        [DataMember(Name = "search")]
        public List<string> Search { get; set; }
        [DataMember(Name = "sort")]
        public string Sort { get; set; }
        [DataMember(Name = "specimenIds")]
        public List<string> SpecimenIds { get; set; }
        [DataMember(Name = "specimenName")]
        public string SpecimenName { get; set; }
        [DataMember(Name = "start-observedTime")]
        public Instant? StartObservedTime { get; set; }
        [DataMember(Name = "start-resultTime")]
        public Instant? StartResultTime { get; set; }
        [DataMember(Name = "startModificationTime")]
        public Instant? StartModificationTime { get; set; }
        [DataMember(Name = "taxonIds")]
        public List<string> TaxonIds { get; set; }
    }

    [DataContract]
    [Route("/v2/observations/resultgrades", "PUT")]
    public class PutBulkEditResultGradesV2 : IReturnVoid
    {
        [DataMember(Name = "targetResultGrade")]
        public string TargetResultGrade { get; set; }
        [DataMember(Name = "activityCustomId")]
        public string ActivityCustomId { get; set; }
        [DataMember(Name = "activityIds")]
        public List<string> ActivityIds { get; set; }
        [DataMember(Name = "activityTypes")]
        public List<string> ActivityTypes { get; set; }
        [DataMember(Name = "analysisMethodIds")]
        public List<string> AnalysisMethodIds { get; set; }
        [DataMember(Name = "analyticalGroupIds")]
        public List<string> AnalyticalGroupIds { get; set; }
        [DataMember(Name = "collectionMethodIds")]
        public List<string> CollectionMethodIds { get; set; }
        [DataMember(Name = "cursor")]
        public string Cursor { get; set; }
        [DataMember(Name = "customId")]
        public string CustomId { get; set; }
        [DataMember(Name = "dataClassifications")]
        public List<string> DataClassifications { get; set; }
        [DataMember(Name = "depthUnitCustomId")]
        public string DepthUnitCustomId { get; set; }
        [DataMember(Name = "depthUnitId")]
        public string DepthUnitId { get; set; }
        [DataMember(Name = "depthValue")]
        public double? DepthValue { get; set; }
        [DataMember(Name = "detectionCondition")]
        public string DetectionCondition { get; set; }
        [DataMember(Name = "end-observedTime")]
        public Instant? EndObservedTime { get; set; }
        [DataMember(Name = "end-resultTime")]
        public Instant? EndResultTime { get; set; }
        [DataMember(Name = "endModificationTime")]
        public Instant? EndModificationTime { get; set; }
        [DataMember(Name = "fieldResultType")]
        public FieldResultType? FieldResultType { get; set; }
        [DataMember(Name = "fieldVisitId")]
        public string FieldVisitId { get; set; }
        [DataMember(Name = "filterId")]
        public string FilterId { get; set; }
        [DataMember(Name = "ids")]
        public List<string> Ids { get; set; }
        [DataMember(Name = "importHistoryEventId")]
        public string ImportHistoryEventId { get; set; }
        [DataMember(Name = "labReportIds")]
        public List<string> LabReportIds { get; set; }
        [DataMember(Name = "labResultLabAnalysisMethodIds")]
        public List<string> LabResultLabAnalysisMethodIds { get; set; }
        [DataMember(Name = "labResultLaboratoryIds")]
        public List<string> LabResultLaboratoryIds { get; set; }
        [DataMember(Name = "limit")]
        public int? Limit { get; set; }
        [DataMember(Name = "max-numericResultValue")]
        public double? MaxNumericResultValue { get; set; }
        [DataMember(Name = "media")]
        public List<string> Media { get; set; }
        [DataMember(Name = "min-numericResultValue")]
        public double? MinNumericResultValue { get; set; }
        [DataMember(Name = "numericResultValue")]
        public double? NumericResultValue { get; set; }
        [DataMember(Name = "observedPropertyIds")]
        public List<string> ObservedPropertyIds { get; set; }
        [DataMember(Name = "projectIds")]
        public List<string> ProjectIds { get; set; }
        [DataMember(Name = "qualityControlTypes")]
        public List<string> QualityControlTypes { get; set; }
        [DataMember(Name = "resultGrades")]
        public List<string> ResultGrades { get; set; }
        [DataMember(Name = "resultStatuses")]
        public List<string> ResultStatuses { get; set; }
        [DataMember(Name = "sampleFraction")]
        public SampleFractionType? SampleFraction { get; set; }
        [DataMember(Name = "samplingContextTagIds")]
        public List<string> SamplingContextTagIds { get; set; }
        [DataMember(Name = "samplingLocationGroupIds")]
        public List<string> SamplingLocationGroupIds { get; set; }
        [DataMember(Name = "samplingLocationIds")]
        public List<string> SamplingLocationIds { get; set; }
        [DataMember(Name = "search")]
        public List<string> Search { get; set; }
        [DataMember(Name = "sort")]
        public string Sort { get; set; }
        [DataMember(Name = "specimenIds")]
        public List<string> SpecimenIds { get; set; }
        [DataMember(Name = "specimenName")]
        public string SpecimenName { get; set; }
        [DataMember(Name = "start-observedTime")]
        public Instant? StartObservedTime { get; set; }
        [DataMember(Name = "start-resultTime")]
        public Instant? StartResultTime { get; set; }
        [DataMember(Name = "startModificationTime")]
        public Instant? StartModificationTime { get; set; }
        [DataMember(Name = "taxonIds")]
        public List<string> TaxonIds { get; set; }
    }

    [DataContract]
    [Route("/v2/services/export/observations", "GET")]
    public class GetObservationExportIIV2 : IReturnVoid
    {
        [DataMember(Name = "format")]
        public FormatType? Format { get; set; }
        [DataMember(Name = "activityCustomId")]
        public string ActivityCustomId { get; set; }
        [DataMember(Name = "activityIds")]
        public List<string> ActivityIds { get; set; }
        [DataMember(Name = "activityTypes")]
        public List<string> ActivityTypes { get; set; }
        [DataMember(Name = "analysisMethodIds")]
        public List<string> AnalysisMethodIds { get; set; }
        [DataMember(Name = "analyticalGroupIds")]
        public List<string> AnalyticalGroupIds { get; set; }
        [DataMember(Name = "collectionMethodIds")]
        public List<string> CollectionMethodIds { get; set; }
        [DataMember(Name = "cursor")]
        public string Cursor { get; set; }
        [DataMember(Name = "customId")]
        public string CustomId { get; set; }
        [DataMember(Name = "dataClassifications")]
        public List<string> DataClassifications { get; set; }
        [DataMember(Name = "depthUnitCustomId")]
        public string DepthUnitCustomId { get; set; }
        [DataMember(Name = "depthUnitId")]
        public string DepthUnitId { get; set; }
        [DataMember(Name = "depthValue")]
        public double? DepthValue { get; set; }
        [DataMember(Name = "detectionCondition")]
        public string DetectionCondition { get; set; }
        [DataMember(Name = "end-observedTime")]
        public Instant? EndObservedTime { get; set; }
        [DataMember(Name = "end-resultTime")]
        public Instant? EndResultTime { get; set; }
        [DataMember(Name = "endModificationTime")]
        public Instant? EndModificationTime { get; set; }
        [DataMember(Name = "fieldResultType")]
        public FieldResultType? FieldResultType { get; set; }
        [DataMember(Name = "fieldVisitId")]
        public string FieldVisitId { get; set; }
        [DataMember(Name = "filterId")]
        public string FilterId { get; set; }
        [DataMember(Name = "ids")]
        public List<string> Ids { get; set; }
        [DataMember(Name = "importHistoryEventId")]
        public string ImportHistoryEventId { get; set; }
        [DataMember(Name = "labReportIds")]
        public List<string> LabReportIds { get; set; }
        [DataMember(Name = "labResultLabAnalysisMethodIds")]
        public List<string> LabResultLabAnalysisMethodIds { get; set; }
        [DataMember(Name = "labResultLaboratoryIds")]
        public List<string> LabResultLaboratoryIds { get; set; }
        [DataMember(Name = "limit")]
        public int? Limit { get; set; }
        [DataMember(Name = "max-numericResultValue")]
        public double? MaxNumericResultValue { get; set; }
        [DataMember(Name = "media")]
        public List<string> Media { get; set; }
        [DataMember(Name = "min-numericResultValue")]
        public double? MinNumericResultValue { get; set; }
        [DataMember(Name = "numericResultValue")]
        public double? NumericResultValue { get; set; }
        [DataMember(Name = "observedPropertyIds")]
        public List<string> ObservedPropertyIds { get; set; }
        [DataMember(Name = "projectIds")]
        public List<string> ProjectIds { get; set; }
        [DataMember(Name = "qualityControlTypes")]
        public List<string> QualityControlTypes { get; set; }
        [DataMember(Name = "resultGrades")]
        public List<string> ResultGrades { get; set; }
        [DataMember(Name = "resultStatuses")]
        public List<string> ResultStatuses { get; set; }
        [DataMember(Name = "sampleFraction")]
        public SampleFractionType? SampleFraction { get; set; }
        [DataMember(Name = "samplingContextTagIds")]
        public List<string> SamplingContextTagIds { get; set; }
        [DataMember(Name = "samplingLocationGroupIds")]
        public List<string> SamplingLocationGroupIds { get; set; }
        [DataMember(Name = "samplingLocationIds")]
        public List<string> SamplingLocationIds { get; set; }
        [DataMember(Name = "search")]
        public List<string> Search { get; set; }
        [DataMember(Name = "sort")]
        public string Sort { get; set; }
        [DataMember(Name = "specimenIds")]
        public List<string> SpecimenIds { get; set; }
        [DataMember(Name = "specimenName")]
        public string SpecimenName { get; set; }
        [DataMember(Name = "start-observedTime")]
        public Instant? StartObservedTime { get; set; }
        [DataMember(Name = "start-resultTime")]
        public Instant? StartResultTime { get; set; }
        [DataMember(Name = "startModificationTime")]
        public Instant? StartModificationTime { get; set; }
        [DataMember(Name = "taxonIds")]
        public List<string> TaxonIds { get; set; }
    }

    [Obsolete("Prefer the PostFieldVisitActivityFromPlannedActivity class instead")] public class PostActivityFromPlannedActivity : PostFieldVisitActivityFromPlannedActivity {}
    [Obsolete("Prefer the PostFieldVisitActivityWithTemplate class instead")] public class PostActivityWithTemplate : PostFieldVisitActivityWithTemplate {}
    [Obsolete("Prefer the GetSamplingLocationCanEdit class instead")] public class GetCanUserEditSamplingLocationData : GetSamplingLocationCanEdit {}
    [Obsolete("Prefer the PostImportSamplingLocationsDryRun class instead")] public class PostImportSamplingLocationsDryrun : PostImportSamplingLocationsDryRun {}
    [Obsolete("Prefer the PostImportObservedPropertiesDryRun class instead")] public class PostImportObservedPropertiesDryrun : PostImportObservedPropertiesDryRun {}
    [Obsolete("Prefer the PostImportAnalysisMethodsDryRun class instead")] public class PostImportLabAnalysisMethodsDryrun : PostImportAnalysisMethodsDryRun {}
    [Obsolete("Prefer the PostImportObservationsDryRun class instead")] public class PostImportObservationsDryrun : PostImportObservationsDryRun {}
    [Obsolete("Prefer the PutAddOrUpdateIndex class instead")] public class PutAddOrUpdateBioIndex : PutAddOrUpdateIndex {}
    [Obsolete("Prefer the PutAccessGroup class instead")] public class PutSparseAccessGroup : PutAccessGroup {}
    [Obsolete("Prefer the DeleteAccessGroup class instead")] public class DeleteAccessGroupById : DeleteAccessGroup {}
    [Obsolete("Prefer the PutActivity class instead")] public class PutSparseActivity : PutActivity {}
    [Obsolete("Prefer the DeleteActivity class instead")] public class DeleteActivityById : DeleteActivity {}
    [Obsolete("Prefer the PostActivityReplicate class instead")] public class PostReplicateActivity : PostActivityReplicate {}
    [Obsolete("Prefer the PutActivityTemplate class instead")] public class PutSparseActivityTemplate : PutActivityTemplate {}
    [Obsolete("Prefer the DeleteActivityTemplate class instead")] public class DeleteActivityTemplateById : DeleteActivityTemplate {}
    [Obsolete("Prefer the PutAnalyticalGroup class instead")] public class PutSparseAnalyticalGroup : PutAnalyticalGroup {}
    [Obsolete("Prefer the DeleteAnalyticalGroup class instead")] public class DeleteAnalyticalGroupById : DeleteAnalyticalGroup {}
    [Obsolete("Prefer the GetAttachmentContents class instead")] public class GetAttachmentContent : GetAttachmentContents {}
    [Obsolete("Prefer the PutCollectionMethod class instead")] public class PutSparseCollectionMethod : PutCollectionMethod {}
    [Obsolete("Prefer the DeleteCollectionMethod class instead")] public class DeleteCollectionMethodById : DeleteCollectionMethod {}
    [Obsolete("Prefer the PutFieldTrip class instead")] public class PutSparseFieldTrip : PutFieldTrip {}
    [Obsolete("Prefer the DeleteFieldTrip class instead")] public class DeleteFieldTripById : DeleteFieldTrip {}
    [Obsolete("Prefer the PutFieldVisit class instead")] public class PutSparseFieldVisit : PutFieldVisit {}
    [Obsolete("Prefer the DeleteFieldVisit class instead")] public class DeleteFieldVisitById : DeleteFieldVisit {}
    [Obsolete("Prefer the PutAnalysisMethod class instead")] public class PutSparseLabAnalysisMethod : PutAnalysisMethod {}
    [Obsolete("Prefer the DeleteAnalysisMethod class instead")] public class DeleteLabAnalysisMethodById : DeleteAnalysisMethod {}
    [Obsolete("Prefer the PutLaboratory class instead")] public class PutSparseLaboratory : PutLaboratory {}
    [Obsolete("Prefer the DeleteLaboratory class instead")] public class DeleteLaboratoryById : DeleteLaboratory {}
    [Obsolete("Prefer the PutLabReport class instead")] public class PutSparseLabReport : PutLabReport {}
    [Obsolete("Prefer the DeleteLabReport class instead")] public class DeleteLabReportById : DeleteLabReport {}
    [Obsolete("Prefer the PutObservation class instead")] public class PutSparseObservation : PutObservation {}
    [Obsolete("Prefer the DeleteObservation class instead")] public class DeleteObservationById : DeleteObservation {}
    [Obsolete("Prefer the PutObservedProperty class instead")] public class PutSparseObservedProperty : PutObservedProperty {}
    [Obsolete("Prefer the DeleteObservedProperty class instead")] public class DeleteObservedPropertyById : DeleteObservedProperty {}
    [Obsolete("Prefer the PutProject class instead")] public class PutSparseProject : PutProject {}
    [Obsolete("Prefer the DeleteProject class instead")] public class DeleteProjectById : DeleteProject {}
    [Obsolete("Prefer the PutSamplingLocationGroup class instead")] public class PutSparseSamplingLocationGroup : PutSamplingLocationGroup {}
    [Obsolete("Prefer the DeleteSamplingLocationGroup class instead")] public class DeleteSamplingLocationGroupById : DeleteSamplingLocationGroup {}
    [Obsolete("Prefer the PutSamplingLocation class instead")] public class PutSparseSamplingLocation : PutSamplingLocation {}
    [Obsolete("Prefer the DeleteSamplingLocation class instead")] public class DeleteSamplingLocationById : DeleteSamplingLocation {}
    [Obsolete("Prefer the GetSamplingLocationSummary class instead")] public class GetSummary : GetSamplingLocationSummary {}
    [Obsolete("Prefer the PutShippingContainer class instead")] public class PutSparseShippingContainer : PutShippingContainer {}
    [Obsolete("Prefer the DeleteShippingContainer class instead")] public class DeleteShippingContainerById : DeleteShippingContainer {}
    [Obsolete("Prefer the PutSpecimen class instead")] public class PutSparseSpecimen : PutSpecimen {}
    [Obsolete("Prefer the DeleteSpecimen class instead")] public class DeleteSpecimenById : DeleteSpecimen {}
    [Obsolete("Prefer the PutSpreadsheetTemplate class instead")] public class PutSparseSpreadsheetTemplate : PutSpreadsheetTemplate {}
    [Obsolete("Prefer the DeleteSpreadsheetTemplate class instead")] public class DeleteSpreadsheetTemplateById : DeleteSpreadsheetTemplate {}
    [Obsolete("Prefer the PutStandard class instead")] public class PutSparseStandard : PutStandard {}
    [Obsolete("Prefer the PutTag class instead")] public class PutSparseTag : PutTag {}
    [Obsolete("Prefer the DeleteTag class instead")] public class DeleteTagById : DeleteTag {}
    [Obsolete("Prefer the PutTaxon class instead")] public class PutSparseTaxon : PutTaxon {}
    [Obsolete("Prefer the DeleteTaxon class instead")] public class DeleteTaxonById : DeleteTaxon {}
    [Obsolete("Prefer the PutUnitGroup class instead")] public class PutSparseUnitGroup : PutUnitGroup {}
    [Obsolete("Prefer the DeleteUnitGroup class instead")] public class DeleteUnitGroupById : DeleteUnitGroup {}
    [Obsolete("Prefer the GetUnitGroupWithUnit class instead")] public class GetUnitGroupsWithUnits : GetUnitGroupWithUnit {}
    [Obsolete("Prefer the PutUnitGroupWithUnit class instead")] public class PutSparseUnitGroupWithUnits : PutUnitGroupWithUnit {}
    [Obsolete("Prefer the DeleteUnitGroupWithUnit class instead")] public class DeleteUnitGroupWithUnitsById : DeleteUnitGroupWithUnit {}
    [Obsolete("Prefer the PutUnit class instead")] public class PutSparseUnit : PutUnit {}
    [Obsolete("Prefer the DeleteUnit class instead")] public class DeleteUnitById : DeleteUnit {}
    [Obsolete("Prefer the PutUser class instead")] public class Put : PutUser {}
    [Obsolete("Prefer the DeleteUser class instead")] public class DeleteUserById : DeleteUser {}

    public class AccessGroup
    {
        public AccessGroup()
        {
            SamplingLocationGroups = new List<SamplingLocationGroup>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool CanEditAllData { get; set; }
        public List<SamplingLocationGroup> SamplingLocationGroups { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class Activity
    {
        public Activity()
        {
            SamplingContextTags = new List<SamplingContextTag>();
            ExtendedAttributes = new List<ExtendedAttribute>();
        }

        public ActivityType Type { get; set; }
        public string Id { get; set; }
        public string CustomId { get; set; }
        public string ReplicateSourceActivityId { get; set; }
        public string SourceActivityId { get; set; }
        public Instant? StartTime { get; set; }
        public Instant? EndTime { get; set; }
        public string Comment { get; set; }
        public string LoggerFileName { get; set; }
        public Device Device { get; set; }
        public CollectionMethod CollectionMethod { get; set; }
        public Medium Medium { get; set; }
        public PlannedActivity PlannedActivity { get; set; }
        public Quantity Depth { get; set; }
        public SamplingLocation SamplingLocation { get; set; }
        public FieldVisit FieldVisit { get; set; }
        public List<SamplingContextTag> SamplingContextTags { get; set; }
        public List<ExtendedAttribute> ExtendedAttributes { get; set; }
        public bool Refreshed { get; set; }
        public bool Blank { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class ActivityTemplate
    {
        public ActivityTemplate()
        {
            SpecimenTemplates = new List<SpecimenTemplate>();
        }

        public string Id { get; set; }
        public List<SpecimenTemplate> SpecimenTemplates { get; set; }
        public string CustomId { get; set; }
        public ActivityTemplateType Type { get; set; }
        public string Comment { get; set; }
        public MediumType Medium { get; set; }
        public Quantity Depth { get; set; }
        public CollectionMethod CollectionMethod { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class ActivityWithDetails
    {
        public ActivityWithDetails()
        {
            SamplingContextTags = new List<SamplingContextTag>();
            ExtendedAttributes = new List<ExtendedAttribute>();
            MetricResults = new List<MetricResult>();
            Specimens = new List<SpecimenNestedInActivity>();
            Observations = new List<ObservationMinimal>();
        }

        public ActivityWithDetailsType Type { get; set; }
        public string Id { get; set; }
        public string CustomId { get; set; }
        public string ReplicateSourceActivityId { get; set; }
        public string SourceActivityId { get; set; }
        public Instant? StartTime { get; set; }
        public Instant? EndTime { get; set; }
        public string Comment { get; set; }
        public string LoggerFileName { get; set; }
        public Device Device { get; set; }
        public CollectionMethod CollectionMethod { get; set; }
        public Medium Medium { get; set; }
        public PlannedActivity PlannedActivity { get; set; }
        public Quantity Depth { get; set; }
        public SamplingLocation SamplingLocation { get; set; }
        public FieldVisit FieldVisit { get; set; }
        public List<SamplingContextTag> SamplingContextTags { get; set; }
        public List<ExtendedAttribute> ExtendedAttributes { get; set; }
        public IndexConfiguration IndexConfiguration { get; set; }
        public List<MetricResult> MetricResults { get; set; }
        public List<SpecimenNestedInActivity> Specimens { get; set; }
        public List<ObservationMinimal> Observations { get; set; }
        public bool Refreshed { get; set; }
        public bool Blank { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class Address
    {
        public string StreetName { get; set; }
        public string CityName { get; set; }
        public string StateProvinceCode { get; set; }
        public string PostalCode { get; set; }
        public string CountryCode { get; set; }
        public string CountyCode { get; set; }
        public AddressType AddressType { get; set; }
    }

    public class AnalysisMethod
    {
        public AnalysisMethod()
        {
            ObservedProperties = new List<ObservedProperty>();
            ImportHistoryEventSimples = new List<ImportHistoryEventSimple>();
        }

        public string Id { get; set; }
        public string MethodId { get; set; }
        public string Name { get; set; }
        public string Context { get; set; }
        public string Description { get; set; }
        public List<ObservedProperty> ObservedProperties { get; set; }
        public List<ImportHistoryEventSimple> ImportHistoryEventSimples { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class AnalysisMethodImportSummary
    {
        public AnalysisMethodImportSummary()
        {
            ImportItems = new List<ImportItemAnalysisMethod>();
            ImportJobErrors = new List<ImportError>();
            NonErrorImportItems = new List<ImportItemAnalysisMethod>();
            ErrorImportItems = new List<ImportItemAnalysisMethod>();
        }

        public ImportHistoryEventSimple ImportHistoryEventSimple { get; set; }
        public int SuccessCount { get; set; }
        public int SkippedCount { get; set; }
        public int ErrorCount { get; set; }
        public int NewCount { get; set; }
        public int UpdateCount { get; set; }
        public int ExpectedCount { get; set; }
        public List<ImportItemAnalysisMethod> ImportItems { get; set; }
        public List<ImportError> ImportJobErrors { get; set; }
        public string InvalidRowsCsvUrl { get; set; }
        public List<ImportItemAnalysisMethod> NonErrorImportItems { get; set; }
        public List<ImportItemAnalysisMethod> ErrorImportItems { get; set; }
        public string SummaryReportText { get; set; }
    }

    public class AnalysisMethodMinimal
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class AnalysisMethodSimple
    {
        public string Id { get; set; }
        public string MethodId { get; set; }
        public string Name { get; set; }
        public string Context { get; set; }
        public string Description { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class AnalyticalGroup
    {
        public AnalyticalGroup()
        {
            AnalyticalGroupItems = new List<AnalyticalGroupItem>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public AnalyticalGroupType Type { get; set; }
        public int NumberOfObservedPropertiesInGroupItems { get; set; }
        public int NumberOfAnalysisMethodsInGroupItems { get; set; }
        public List<AnalyticalGroupItem> AnalyticalGroupItems { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class AnalyticalGroupItem
    {
        public ObservedProperty ObservedProperty { get; set; }
        public string HoldingTime { get; set; }
        public AnalysisMethod AnalysisMethod { get; set; }
    }

    public class AnalyticalGroupSimple
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public AnalyticalGroupSimpleType Type { get; set; }
        public int NumberOfObservedPropertiesInGroupItems { get; set; }
        public int NumberOfAnalysisMethodsInGroupItems { get; set; }
    }

    public class Attachment
    {
        public string Id { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public string Comment { get; set; }
        public long FileSize { get; set; }
        public Instant? DateTaken { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Resolution { get; set; }
        public AuditAttributesFull AuditAttributes { get; set; }
    }

    public class AttachmentRepresentation
    {
        public string Id { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public string Comment { get; set; }
        public long FileSize { get; set; }
        public Instant? DateTaken { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Resolution { get; set; }
        public bool Success { get; set; }
        public AuditAttributesFull AuditAttributes { get; set; }
    }

    public class AuditAttributes
    {
        public string CreationUserProfileId { get; set; }
        public Instant? CreationTime { get; set; }
        public string ModificationUserProfileId { get; set; }
        public Instant? ModificationTime { get; set; }
    }

    public class AuditAttributesFull
    {
        public string CreationUserProfileId { get; set; }
        public Instant? CreationTime { get; set; }
        public string ModificationUserProfileId { get; set; }
        public Instant? ModificationTime { get; set; }
        public UserProfile CreationUserProfile { get; set; }
        public UserProfile ModificationUserProfile { get; set; }
    }

    public class AuditChange
    {
        public string Key { get; set; }
        public string FromValue { get; set; }
        public string FromId { get; set; }
        public string ToValue { get; set; }
        public string ToId { get; set; }
    }

    public class AuditHistory
    {
        public AuditHistory()
        {
            AuditChanges = new List<AuditChange>();
        }

        public Instant? ModificationTime { get; set; }
        public UserProfile UserProfile { get; set; }
        public OperationType Operation { get; set; }
        public List<AuditChange> AuditChanges { get; set; }
    }

    public class CategoricalResult
    {
        public NullMeasureQualifier NullMeasureQualifier { get; set; }
        public CategoricalValue FixedValue { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
    }

    public class CategoricalValue
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class ChartData
    {
        public ChartData()
        {
            DataPoints = new List<ChartDataPoint>();
        }

        public ObservedProperty ObservedProperty { get; set; }
        public SamplingLocation SamplingLocation { get; set; }
        public UnitGroupWithUnits UnitGroupWithUnits { get; set; }
        public UnitGroupWithUnits DepthUnitGroupWithUnits { get; set; }
        public List<ChartDataPoint> DataPoints { get; set; }
    }

    public class ChartDataPoint
    {
        public double Value { get; set; }
        public string ObservationId { get; set; }
        public Instant? ObservedTime { get; set; }
        public string NumericResultUnitCustomId { get; set; }
        public double MdlValue { get; set; }
        public string MdlValueUnitCustomId { get; set; }
        public double DepthValue { get; set; }
        public string DepthUnitCustomId { get; set; }
        public ResultDetectionCondition ResultDetectionCondition { get; set; }
    }

    public class CollectionMethod
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public string IdentifierOrganization { get; set; }
        public string Name { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class Device
    {
        public string CustomId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }



    public class DomainObjectAttachment
    {
        public string Id { get; set; }
        public Attachment Attachment { get; set; }
    }

    public class ErrorInfo
    {
        public ErrorInfo()
        {
            LocalizationParameters = new List<string>();
        }

        public string Message { get; set; }
        public string LocalizationKey { get; set; }
        public List<string> LocalizationParameters { get; set; }
        public string RequestId { get; set; }
    }

    public class ExtendedAttribute
    {
        public string Id { get; set; }
        public string AttributeId { get; set; }
        public string Text { get; set; }
        public double Number { get; set; }
        public ExtendedAttributeListItem DropDownListItem { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class ExtendedAttributeDefinition
    {
        public ExtendedAttributeDefinition()
        {
            DropDownListItems = new List<ExtendedAttributeListItem>();
        }

        public string Id { get; set; }
        public string CustomId { get; set; }
        public string Description { get; set; }
        public DataType DataType { get; set; }
        public AppliesToType AppliesToType { get; set; }
        public string DefaultValue { get; set; }
        public List<ExtendedAttributeListItem> DropDownListItems { get; set; }
        public bool Mandatory { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class ExtendedAttributeListItem
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
    }

    public class FieldSheetImportSummary
    {
        public ImportSummaryObservation FieldResultSummary { get; set; }
        public ImportSummarySpecimen SpecimenSummary { get; set; }
    }

    public class FieldTrip
    {
        public FieldTrip()
        {
            Attachments = new List<DomainObjectAttachment>();
            FieldVisits = new List<FieldVisit>();
        }

        public string Id { get; set; }
        public string CustomId { get; set; }
        public Instant? StartTime { get; set; }
        public Instant? EndTime { get; set; }
        public string Participants { get; set; }
        public string Notes { get; set; }
        public List<DomainObjectAttachment> Attachments { get; set; }
        public List<FieldVisit> FieldVisits { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class FieldTripBasic
    {
        public FieldTripBasic()
        {
            Attachments = new List<DomainObjectAttachment>();
        }

        public string Id { get; set; }
        public string CustomId { get; set; }
        public Instant? StartTime { get; set; }
        public Instant? EndTime { get; set; }
        public string Participants { get; set; }
        public string Notes { get; set; }
        public List<DomainObjectAttachment> Attachments { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class FieldTripSimple
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
    }

    public class FieldVisit
    {
        public FieldVisit()
        {
            PlannedFieldResults = new List<PlannedFieldResult>();
            PlannedActivities = new List<PlannedActivity>();
            Attachments = new List<DomainObjectAttachment>();
            ExtendedAttributes = new List<ExtendedAttribute>();
        }

        public string Id { get; set; }
        public Instant? StartTime { get; set; }
        public Instant? EndTime { get; set; }
        public string Participants { get; set; }
        public string Notes { get; set; }
        public FieldTripSimple FieldTrip { get; set; }
        public ProjectSimple Project { get; set; }
        public PlanningStatusType PlanningStatus { get; set; }
        public SamplingLocation SamplingLocation { get; set; }
        public List<PlannedFieldResult> PlannedFieldResults { get; set; }
        public List<PlannedActivity> PlannedActivities { get; set; }
        public List<DomainObjectAttachment> Attachments { get; set; }
        public List<ExtendedAttribute> ExtendedAttributes { get; set; }
        public Schedule Schedule { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class FieldVisitSimple
    {
        public string Id { get; set; }
        public Instant? StartTime { get; set; }
        public Instant? EndTime { get; set; }
        public string Participants { get; set; }
        public string Notes { get; set; }
        public FieldTripSimple FieldTrip { get; set; }
        public ProjectSimple Project { get; set; }
        public PlanningStatusType PlanningStatus { get; set; }
        public SamplingLocationSimple SamplingLocation { get; set; }
    }

    public class FieldVisitStatistics
    {
        public long RoutineSampleCount { get; set; }
        public long QcSampleCount { get; set; }
        public long VerticalProfileCount { get; set; }
        public long FieldResultCount { get; set; }
        public long FieldSurveyCount { get; set; }
    }

    public class FieldVisitSummaryRepresentation
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public Instant? StartTime { get; set; }
    }

    public class Filter
    {
        public Filter()
        {
            ObservedProperties = new List<ObservedProperty>();
            SamplingLocations = new List<SamplingLocation>();
        }

        public string Id { get; set; }
        public string CustomId { get; set; }
        public Instant? StartTime { get; set; }
        public Instant? EndTime { get; set; }
        public List<ObservedProperty> ObservedProperties { get; set; }
        public List<SamplingLocation> SamplingLocations { get; set; }
        public string Description { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class FixedValueCategoricalResult
    {
    }

    public class ImportChangeItem
    {
        public string PropertyName { get; set; }
        public object Left { get; set; }
        public object Right { get; set; }
    }

    public class ImportError
    {
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorFieldValue { get; set; }
    }

    public class ImportHistoryEvent
    {
        public ImportHistoryEvent()
        {
            DomainObjectIds = new List<string>();
        }

        public string Id { get; set; }
        public ImportType ImportType { get; set; }
        public Instant? ImportTime { get; set; }
        public string FileName { get; set; }
        public string TimeZoneOffset { get; set; }
        public UserProfile ImportedBy { get; set; }
        public List<string> DomainObjectIds { get; set; }
    }

    public class ImportHistoryEventSimple
    {
        public string Id { get; set; }
        public ImportType ImportType { get; set; }
        public Instant? ImportTime { get; set; }
        public string FileName { get; set; }
        public string TimeZoneOffset { get; set; }
        public UserProfile ImportedBy { get; set; }
    }

    public class ImportItem
    {
        public ImportItem()
        {
            Fields = new List<string>();
            ItemComparison = new List<ImportChangeItem>();
            WarningMessages = new List<string>();
        }

        public List<string> Fields { get; set; }
        public object Errors { get; set; }
        public string RowId { get; set; }
        public string Input { get; set; }
        public ImportItemStatusType Status { get; set; }
        public object Item { get; set; }
        public object ExistingItem { get; set; }
        public List<ImportChangeItem> ItemComparison { get; set; }
        public List<string> WarningMessages { get; set; }
    }

    public class ImportItemAnalysisMethod
    {
        public ImportItemAnalysisMethod()
        {
            Fields = new List<string>();
            ItemComparison = new List<ImportChangeItem>();
            WarningMessages = new List<string>();
        }

        public List<string> Fields { get; set; }
        public object Errors { get; set; }
        public string RowId { get; set; }
        public string Input { get; set; }
        public ImportItemStatusType Status { get; set; }
        public AnalysisMethod Item { get; set; }
        public AnalysisMethod ExistingItem { get; set; }
        public List<ImportChangeItem> ItemComparison { get; set; }
        public List<string> WarningMessages { get; set; }
    }

    public class ImportItemObject
    {
        public ImportItemObject()
        {
            Fields = new List<string>();
            ItemComparison = new List<ImportChangeItem>();
            WarningMessages = new List<string>();
        }

        public List<string> Fields { get; set; }
        public object Errors { get; set; }
        public string RowId { get; set; }
        public string Input { get; set; }
        public ImportItemStatusType Status { get; set; }
        public object Item { get; set; }
        public object ExistingItem { get; set; }
        public List<ImportChangeItem> ItemComparison { get; set; }
        public List<string> WarningMessages { get; set; }
    }

    public class ImportItemObservation
    {
        public ImportItemObservation()
        {
            Fields = new List<string>();
            ItemComparison = new List<ImportChangeItem>();
            WarningMessages = new List<string>();
        }

        public List<string> Fields { get; set; }
        public object Errors { get; set; }
        public string RowId { get; set; }
        public string Input { get; set; }
        public ImportItemStatusType Status { get; set; }
        public Observation Item { get; set; }
        public Observation ExistingItem { get; set; }
        public List<ImportChangeItem> ItemComparison { get; set; }
        public List<string> WarningMessages { get; set; }
    }

    public class ImportItemObservedProperty
    {
        public ImportItemObservedProperty()
        {
            Fields = new List<string>();
            ItemComparison = new List<ImportChangeItem>();
            WarningMessages = new List<string>();
        }

        public List<string> Fields { get; set; }
        public object Errors { get; set; }
        public string RowId { get; set; }
        public string Input { get; set; }
        public ImportItemStatusType Status { get; set; }
        public ObservedProperty Item { get; set; }
        public ObservedProperty ExistingItem { get; set; }
        public List<ImportChangeItem> ItemComparison { get; set; }
        public List<string> WarningMessages { get; set; }
    }

    public class ImportItemSamplingLocation
    {
        public ImportItemSamplingLocation()
        {
            Fields = new List<string>();
            ItemComparison = new List<ImportChangeItem>();
            WarningMessages = new List<string>();
        }

        public List<string> Fields { get; set; }
        public object Errors { get; set; }
        public string RowId { get; set; }
        public string Input { get; set; }
        public ImportItemStatusType Status { get; set; }
        public SamplingLocation Item { get; set; }
        public SamplingLocation ExistingItem { get; set; }
        public List<ImportChangeItem> ItemComparison { get; set; }
        public List<string> WarningMessages { get; set; }
    }

    public class ImportItemSpecimen
    {
        public ImportItemSpecimen()
        {
            Fields = new List<string>();
            ItemComparison = new List<ImportChangeItem>();
            WarningMessages = new List<string>();
        }

        public List<string> Fields { get; set; }
        public object Errors { get; set; }
        public string RowId { get; set; }
        public string Input { get; set; }
        public ImportItemStatusType Status { get; set; }
        public Specimen Item { get; set; }
        public Specimen ExistingItem { get; set; }
        public List<ImportChangeItem> ItemComparison { get; set; }
        public List<string> WarningMessages { get; set; }
    }

    public class ImportItemTaxon
    {
        public ImportItemTaxon()
        {
            Fields = new List<string>();
            ItemComparison = new List<ImportChangeItem>();
            WarningMessages = new List<string>();
        }

        public List<string> Fields { get; set; }
        public object Errors { get; set; }
        public string RowId { get; set; }
        public string Input { get; set; }
        public ImportItemStatusType Status { get; set; }
        public Taxon Item { get; set; }
        public Taxon ExistingItem { get; set; }
        public List<ImportChangeItem> ItemComparison { get; set; }
        public List<string> WarningMessages { get; set; }
    }

    public class ImportProcessorTransactionStatusResponse
    {
        public string Id { get; set; }
        public ImportProcessorTransactionStatusType ImportProcessorTransactionStatus { get; set; }
    }

    public class ImportSummary
    {
        public ImportSummary()
        {
            ImportItems = new List<ImportItemObject>();
            ImportJobErrors = new List<ImportError>();
            NonErrorImportItems = new List<ImportItemObject>();
            ErrorImportItems = new List<ImportItemObject>();
        }

        public ImportHistoryEventSimple ImportHistoryEventSimple { get; set; }
        public int SuccessCount { get; set; }
        public int SkippedCount { get; set; }
        public int ErrorCount { get; set; }
        public int NewCount { get; set; }
        public int UpdateCount { get; set; }
        public int ExpectedCount { get; set; }
        public List<ImportItemObject> ImportItems { get; set; }
        public List<ImportError> ImportJobErrors { get; set; }
        public string InvalidRowsCsvUrl { get; set; }
        public List<ImportItemObject> NonErrorImportItems { get; set; }
        public List<ImportItemObject> ErrorImportItems { get; set; }
        public string SummaryReportText { get; set; }
    }

    public class ImportSummaryObservation
    {
        public ImportSummaryObservation()
        {
            ImportItems = new List<ImportItemObservation>();
            ImportJobErrors = new List<ImportError>();
            NonErrorImportItems = new List<ImportItemObservation>();
            ErrorImportItems = new List<ImportItemObservation>();
        }

        public ImportHistoryEventSimple ImportHistoryEventSimple { get; set; }
        public int SuccessCount { get; set; }
        public int SkippedCount { get; set; }
        public int ErrorCount { get; set; }
        public int NewCount { get; set; }
        public int UpdateCount { get; set; }
        public int ExpectedCount { get; set; }
        public List<ImportItemObservation> ImportItems { get; set; }
        public List<ImportError> ImportJobErrors { get; set; }
        public string InvalidRowsCsvUrl { get; set; }
        public List<ImportItemObservation> NonErrorImportItems { get; set; }
        public List<ImportItemObservation> ErrorImportItems { get; set; }
        public string SummaryReportText { get; set; }
    }

    public class ImportSummarySpecimen
    {
        public ImportSummarySpecimen()
        {
            ImportItems = new List<ImportItemSpecimen>();
            ImportJobErrors = new List<ImportError>();
            NonErrorImportItems = new List<ImportItemSpecimen>();
            ErrorImportItems = new List<ImportItemSpecimen>();
        }

        public ImportHistoryEventSimple ImportHistoryEventSimple { get; set; }
        public int SuccessCount { get; set; }
        public int SkippedCount { get; set; }
        public int ErrorCount { get; set; }
        public int NewCount { get; set; }
        public int UpdateCount { get; set; }
        public int ExpectedCount { get; set; }
        public List<ImportItemSpecimen> ImportItems { get; set; }
        public List<ImportError> ImportJobErrors { get; set; }
        public string InvalidRowsCsvUrl { get; set; }
        public List<ImportItemSpecimen> NonErrorImportItems { get; set; }
        public List<ImportItemSpecimen> ErrorImportItems { get; set; }
        public string SummaryReportText { get; set; }
    }

    public class IndexConfiguration
    {
        public IndexConfiguration()
        {
            IndexRanges = new List<IndexRange>();
            MetricConfigurations = new List<MetricConfiguration>();
        }

        public string Id { get; set; }
        public string CustomId { get; set; }
        public string IssuingOrganization { get; set; }
        public string Description { get; set; }
        public bool UseScoreRanges { get; set; }
        public ObservedProperty ObservedProperty { get; set; }
        public Unit Unit { get; set; }
        public List<IndexRange> IndexRanges { get; set; }
        public List<MetricConfiguration> MetricConfigurations { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class IndexRange
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
        public int ResultingScore { get; set; }
        public int LowerLimitValue { get; set; }
        public int UpperLimitValue { get; set; }
    }

    public class IndexRequestDto
    {
        public string IndexConfigId { get; set; }
    }

    public class InputPart
    {
        public object Headers { get; set; }
        public MediaType MediaType { get; set; }
        public string BodyAsString { get; set; }
        public bool ContentTypeFromMessage { get; set; }
    }

    public class LabInstruction
    {
        public AnalysisMethod AnalysisMethod { get; set; }
        public string PreparationMethod { get; set; }
        public string AnalysisComment { get; set; }
        public string HoldingTime { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class LabInstructionMinimal
    {
        public AnalysisMethodMinimal AnalysisMethod { get; set; }
        public string PreparationMethod { get; set; }
        public string AnalysisComment { get; set; }
        public string HoldingTime { get; set; }
    }

    public class LabInstructionTemplate
    {
        public string Id { get; set; }
        public AnalysisMethod AnalysisMethod { get; set; }
        public ObservedProperty ObservedProperty { get; set; }
        public string PreparationMethod { get; set; }
        public string AnalysisComment { get; set; }
        public string HoldingTime { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class Laboratory
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string PointOfContact { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class LabReport
    {
        public LabReport()
        {
            ImportHistoryEventSimples = new List<ImportHistoryEventSimple>();
            Attachments = new List<DomainObjectAttachment>();
        }

        public string Id { get; set; }
        public string CustomId { get; set; }
        public Instant? DateReceived { get; set; }
        public string CaseNarrative { get; set; }
        public string QcSummary { get; set; }
        public Laboratory Laboratory { get; set; }
        public List<ImportHistoryEventSimple> ImportHistoryEventSimples { get; set; }
        public List<DomainObjectAttachment> Attachments { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class LabReportImportHistoryEvent
    {
        public ImportHistoryEvent ImportHistoryEvent { get; set; }
        public LabReport LabReport { get; set; }
    }

    public class LabResultDetails
    {
        public string LabSampleId { get; set; }
        public Laboratory Laboratory { get; set; }
        public string PreparationMethod { get; set; }
        public string DilutionFactor { get; set; }
        public Instant? DateReceived { get; set; }
        public string AnalysisComment { get; set; }
        public string QualityFlag { get; set; }
        public Instant? DatePrepared { get; set; }
        public LabReport LabReport { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class LocationGroupType
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class LocationObservationsGroup
    {
        public LocationObservationsGroup()
        {
            Observations = new List<Observation>();
        }

        public List<Observation> Observations { get; set; }
        public SamplingLocation SamplingLocation { get; set; }
        public long TotalCount { get; set; }
    }

    public class LocationType
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class MediaType
    {
        public string Type { get; set; }
        public string Subtype { get; set; }
        public object Parameters { get; set; }
        public bool WildcardType { get; set; }
        public bool WildcardSubtype { get; set; }
    }

    public class Medium
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public MediumSystemCodeType SystemCode { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class MetricConfiguration
    {
        public MetricConfiguration()
        {
            MetricRanges = new List<MetricRange>();
            Taxons = new List<Taxon>();
        }

        public string Id { get; set; }
        public string CustomId { get; set; }
        public string Description { get; set; }
        public AggregationType AggregationType { get; set; }
        public bool IncludeChildren { get; set; }
        public bool UseScoreRanges { get; set; }
        public ObservedProperty ObservedProperty { get; set; }
        public Unit Unit { get; set; }
        public List<MetricRange> MetricRanges { get; set; }
        public List<Taxon> Taxons { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class MetricRange
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
        public int ResultingScore { get; set; }
        public int LowerLimitValue { get; set; }
        public int UpperLimitValue { get; set; }
    }

    public class MetricResult
    {
        public MetricResult()
        {
            MatchedObservations = new List<string>();
        }

        public string Id { get; set; }
        public MetricConfiguration MetricConfiguration { get; set; }
        public double AggregationResult { get; set; }
        public double Score { get; set; }
        public bool OverriddenByUser { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
        public List<string> MatchedObservations { get; set; }
    }

    public class MultiChartData
    {
        public MultiChartData()
        {
            Charts = new List<ChartData>();
        }

        public List<ChartData> Charts { get; set; }
    }

    public class MultipartFormDataInput
    {
    }

    public class NullMeasureQualifier
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class NumericResult
    {
        public Quantity Quantity { get; set; }
        public SampleFractionType SampleFraction { get; set; }
        public DeterminationType DeterminationType { get; set; }
        public ResultDetectionCondition DetectionCondition { get; set; }
        public Quantity MethodDetectionLevel { get; set; }
        public Quantity LowerMethodReportingLimit { get; set; }
        public NullMeasureQualifier NullMeasureQualifier { get; set; }
        public string RoundedValue { get; set; }
        public SourceRoundedValueType SourceRoundedValue { get; set; }
        public string RoundingSpecification { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class Observation
    {
        public Observation()
        {
            ImportHistoryEventSimples = new List<ImportHistoryEventSimple>();
            ValidationWarnings = new List<RuleValidationDetails>();
            ExtendedAttributes = new List<ExtendedAttribute>();
        }

        public string Id { get; set; }
        public string CustomId { get; set; }
        public Activity Activity { get; set; }
        public CollectionMethod CollectionMethod { get; set; }
        public ObservedProperty ObservedProperty { get; set; }
        public Specimen Specimen { get; set; }
        public SamplingLocation SamplingLocation { get; set; }
        public NumericResult NumericResult { get; set; }
        public CategoricalResult CategoricalResult { get; set; }
        public TaxonomicResult TaxonomicResult { get; set; }
        public QualityControlType QualityControlType { get; set; }
        public DataClassificationType DataClassification { get; set; }
        public Medium Medium { get; set; }
        public string MediumSubdivision { get; set; }
        public Instant? ObservedTime { get; set; }
        public Instant? ResultTime { get; set; }
        public Quantity Depth { get; set; }
        public LabInstruction LabInstruction { get; set; }
        public LabResultDetails LabResultDetails { get; set; }
        public AnalysisMethodSimple AnalysisMethod { get; set; }
        public string Comment { get; set; }
        public FieldVisit FieldVisit { get; set; }
        public Device Device { get; set; }
        public List<ImportHistoryEventSimple> ImportHistoryEventSimples { get; set; }
        public List<RuleValidationDetails> ValidationWarnings { get; set; }
        public ResultGrade ResultGrade { get; set; }
        public ResultStatus ResultStatus { get; set; }
        public PlannedFieldResult PlannedFieldResult { get; set; }
        public ObservationStatistics Statistics { get; set; }
        public Taxon RelatedTaxon { get; set; }
        public List<ExtendedAttribute> ExtendedAttributes { get; set; }
        public NullMeasureQualifier NullMeasureQualifier { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class ObservationImportSummary
    {
        public ObservationImportSummary()
        {
            ImportItems = new List<ImportItemObservation>();
            ImportJobErrors = new List<ImportError>();
            NonErrorImportItems = new List<ImportItemObservation>();
            ErrorImportItems = new List<ImportItemObservation>();
        }

        public ImportHistoryEventSimple ImportHistoryEventSimple { get; set; }
        public int SuccessCount { get; set; }
        public int SkippedCount { get; set; }
        public int ErrorCount { get; set; }
        public int NewCount { get; set; }
        public int UpdateCount { get; set; }
        public int ExpectedCount { get; set; }
        public List<ImportItemObservation> ImportItems { get; set; }
        public List<ImportError> ImportJobErrors { get; set; }
        public string InvalidRowsCsvUrl { get; set; }
        public List<ImportItemObservation> NonErrorImportItems { get; set; }
        public List<ImportItemObservation> ErrorImportItems { get; set; }
        public string SummaryReportText { get; set; }
    }

    public class ObservationMinimal
    {
        public string Id { get; set; }
        public ObservedProperty ObservedProperty { get; set; }
        public Instant? ObservedTime { get; set; }
        public Instant? ResultTime { get; set; }
        public SpecimenNestedInActivity Specimen { get; set; }
        public NumericResult NumericResult { get; set; }
        public CategoricalResult CategoricalResult { get; set; }
        public TaxonomicResult TaxonomicResult { get; set; }
        public ResultStatus ResultStatus { get; set; }
        public LabInstructionMinimal LabInstruction { get; set; }
        public DataClassificationType DataClassification { get; set; }
        public string Comment { get; set; }
    }

    public class ObservationNestedInSpecimen
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public ObservedProperty ObservedProperty { get; set; }
        public LabInstruction LabInstruction { get; set; }
        public NumericResult NumericResult { get; set; }
        public DataClassificationType DataClassification { get; set; }
        public Instant? ObservedTime { get; set; }
        public ResultStatus ResultStatus { get; set; }
        public CategoricalResult CategoricalResult { get; set; }
        public TaxonomicResult TaxonomicResult { get; set; }
    }

    public class ObservationStandard
    {
        public ObservedProperty ObservedProperty { get; set; }
        public Quantity ResultLowerLimit { get; set; }
        public Quantity ResultUpperLimit { get; set; }
        public string RuleText { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class ObservationStatistics
    {
        public string SamplingLocationId { get; set; }
        public string ObservedPropertyId { get; set; }
        public int Count { get; set; }
        public double Min { get; set; }
        public double P25 { get; set; }
        public double P5 { get; set; }
        public double P50 { get; set; }
        public double P75 { get; set; }
        public double P95 { get; set; }
        public double Max { get; set; }
    }

    public class ObservedProperty
    {
        public ObservedProperty()
        {
            ImportHistoryEventSimples = new List<ImportHistoryEventSimple>();
        }

        public string Id { get; set; }
        public string CustomId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ResultType ResultType { get; set; }
        public AnalysisType AnalysisType { get; set; }
        public UnitGroup UnitGroup { get; set; }
        public Unit DefaultUnit { get; set; }
        public List<ImportHistoryEventSimple> ImportHistoryEventSimples { get; set; }
        public string CasNumber { get; set; }
        public Quantity LowerLimit { get; set; }
        public Quantity UpperLimit { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class ObservedPropertyImportSummary
    {
        public ObservedPropertyImportSummary()
        {
            ImportItems = new List<ImportItemObservedProperty>();
            ImportJobErrors = new List<ImportError>();
            NonErrorImportItems = new List<ImportItemObservedProperty>();
            ErrorImportItems = new List<ImportItemObservedProperty>();
        }

        public ImportHistoryEventSimple ImportHistoryEventSimple { get; set; }
        public int SuccessCount { get; set; }
        public int SkippedCount { get; set; }
        public int ErrorCount { get; set; }
        public int NewCount { get; set; }
        public int UpdateCount { get; set; }
        public int ExpectedCount { get; set; }
        public List<ImportItemObservedProperty> ImportItems { get; set; }
        public List<ImportError> ImportJobErrors { get; set; }
        public string InvalidRowsCsvUrl { get; set; }
        public List<ImportItemObservedProperty> NonErrorImportItems { get; set; }
        public List<ImportItemObservedProperty> ErrorImportItems { get; set; }
        public string SummaryReportText { get; set; }
    }

    public class PlannedActivity
    {
        public string Id { get; set; }
        public ActivityTemplate ActivityTemplate { get; set; }
        public string Instruction { get; set; }
        public PlannedActivityActivityType ActivityType { get; set; }
        public MediumType Medium { get; set; }
        public CollectionMethod CollectionMethod { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class PlannedFieldResult
    {
        public string Id { get; set; }
        public ObservedProperty ObservedProperty { get; set; }
        public MediumType Medium { get; set; }
        public string DeviceType { get; set; }
        public string Comment { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class Project
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public string Name { get; set; }
        public ProjectType Type { get; set; }
        public string Description { get; set; }
        public string ScopeStatement { get; set; }
        public bool Approved { get; set; }
        public string ApprovalAgency { get; set; }
        public Instant? StartTime { get; set; }
        public Instant? EndTime { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class ProjectSimple
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public string Name { get; set; }
    }

    public class Quantity
    {
        public double Value { get; set; }
        public Unit Unit { get; set; }
    }

    public class ResultDetectionCondition
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SystemCode { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class ResultGrade
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public ResultGradeSystemCodeType SystemCode { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class ResultGradeChange
    {
        public string TargetResultGrade { get; set; }
    }

    public class ResultStatus
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public ResultStatusSystemCodeType SystemCode { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class RuleValidationDetails
    {
        public string Type { get; set; }
        public string Description { get; set; }
        public object Properties { get; set; }
    }

    public class SamplingContextTag
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class SamplingLocation
    {
        public SamplingLocation()
        {
            ImportHistoryEventSimples = new List<ImportHistoryEventSimple>();
            Standards = new List<StandardSimple>();
            Attachments = new List<DomainObjectAttachment>();
            SamplingLocationGroups = new List<SamplingLocationGroup>();
            ExtendedAttributes = new List<ExtendedAttribute>();
        }

        public string Id { get; set; }
        public string CustomId { get; set; }
        public string Name { get; set; }
        public LocationType Type { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string HorizontalDatum { get; set; }
        public string VerticalDatum { get; set; }
        public string HorizontalCollectionMethod { get; set; }
        public string VerticalCollectionMethod { get; set; }
        public string Description { get; set; }
        public Address Address { get; set; }
        public Quantity Elevation { get; set; }
        public TimeZone TimeZone { get; set; }
        public List<ImportHistoryEventSimple> ImportHistoryEventSimples { get; set; }
        public List<StandardSimple> Standards { get; set; }
        public List<DomainObjectAttachment> Attachments { get; set; }
        public List<SamplingLocationGroup> SamplingLocationGroups { get; set; }
        public List<ExtendedAttribute> ExtendedAttributes { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class SamplingLocationGroup
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public LocationGroupType LocationGroupType { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class SamplingLocationImportSummary
    {
        public SamplingLocationImportSummary()
        {
            ImportItems = new List<ImportItemSamplingLocation>();
            ImportJobErrors = new List<ImportError>();
            NonErrorImportItems = new List<ImportItemSamplingLocation>();
            ErrorImportItems = new List<ImportItemSamplingLocation>();
        }

        public ImportHistoryEventSimple ImportHistoryEventSimple { get; set; }
        public int SuccessCount { get; set; }
        public int SkippedCount { get; set; }
        public int ErrorCount { get; set; }
        public int NewCount { get; set; }
        public int UpdateCount { get; set; }
        public int ExpectedCount { get; set; }
        public List<ImportItemSamplingLocation> ImportItems { get; set; }
        public List<ImportError> ImportJobErrors { get; set; }
        public string InvalidRowsCsvUrl { get; set; }
        public List<ImportItemSamplingLocation> NonErrorImportItems { get; set; }
        public List<ImportItemSamplingLocation> ErrorImportItems { get; set; }
        public string SummaryReportText { get; set; }
    }

    public class SamplingLocationSimple
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public string Name { get; set; }
    }

    public class SamplingLocationSummary
    {
        public long ObservationCount { get; set; }
        public long FieldVisitCount { get; set; }
        public FieldVisitSummaryRepresentation LatestFieldVisit { get; set; }
    }

    public class Schedule
    {
        public Schedule()
        {
            SchedulePlannedActivities = new List<SchedulePlannedActivity>();
        }

        public string Id { get; set; }
        public string CustomId { get; set; }
        public Instant? StartDate { get; set; }
        public Instant? EndDate { get; set; }
        public RecurrenceType RecurrenceType { get; set; }
        public RecurrenceDayWeeklyType RecurrenceDayWeekly { get; set; }
        public RecurrenceDayMonthlyType RecurrenceDayMonthly { get; set; }
        public SamplingLocationGroup SamplingLocationGroup { get; set; }
        public SamplingLocationGroupSelectionType SamplingLocationGroupSelectionType { get; set; }
        public int SamplingLocationGroupSelectionTypeRandomCount { get; set; }
        public Instant? LastGenerationDate { get; set; }
        public List<SchedulePlannedActivity> SchedulePlannedActivities { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class SchedulePlannedActivity
    {
        public string Id { get; set; }
        public ActivityTemplate ActivityTemplate { get; set; }
        public string Instruction { get; set; }
        public ActivityType ActivityType { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class SearchResult : IPaginatedResponse<object>
    {
        public SearchResult()
        {
            DomainObjects = new List<object>();
        }

        public int TotalCount { get; set; }
        public string Cursor { get; set; }
        public List<object> DomainObjects { get; set; }
    }

    public class SearchResultAccessGroup : IPaginatedResponse<AccessGroup>
    {
        public SearchResultAccessGroup()
        {
            DomainObjects = new List<AccessGroup>();
        }

        public int TotalCount { get; set; }
        public string Cursor { get; set; }
        public List<AccessGroup> DomainObjects { get; set; }
    }

    public class SearchResultActivity : IPaginatedResponse<Activity>
    {
        public SearchResultActivity()
        {
            DomainObjects = new List<Activity>();
        }

        public int TotalCount { get; set; }
        public string Cursor { get; set; }
        public List<Activity> DomainObjects { get; set; }
    }

    public class SearchResultActivityTemplate : IPaginatedResponse<ActivityTemplate>
    {
        public SearchResultActivityTemplate()
        {
            DomainObjects = new List<ActivityTemplate>();
        }

        public int TotalCount { get; set; }
        public string Cursor { get; set; }
        public List<ActivityTemplate> DomainObjects { get; set; }
    }

    public class SearchResultAnalysisMethod : IPaginatedResponse<AnalysisMethod>
    {
        public SearchResultAnalysisMethod()
        {
            DomainObjects = new List<AnalysisMethod>();
        }

        public int TotalCount { get; set; }
        public string Cursor { get; set; }
        public List<AnalysisMethod> DomainObjects { get; set; }
    }

    public class SearchResultAnalyticalGroup : IPaginatedResponse<AnalyticalGroup>
    {
        public SearchResultAnalyticalGroup()
        {
            DomainObjects = new List<AnalyticalGroup>();
        }

        public int TotalCount { get; set; }
        public string Cursor { get; set; }
        public List<AnalyticalGroup> DomainObjects { get; set; }
    }

    public class SearchResultAttachment : IPaginatedResponse<Attachment>
    {
        public SearchResultAttachment()
        {
            DomainObjects = new List<Attachment>();
        }

        public int TotalCount { get; set; }
        public string Cursor { get; set; }
        public List<Attachment> DomainObjects { get; set; }
    }

    public class SearchResultAuditHistory : IPaginatedResponse<AuditHistory>
    {
        public SearchResultAuditHistory()
        {
            DomainObjects = new List<AuditHistory>();
        }

        public int TotalCount { get; set; }
        public string Cursor { get; set; }
        public List<AuditHistory> DomainObjects { get; set; }
    }

    public class SearchResultCategoricalValue : IPaginatedResponse<CategoricalValue>
    {
        public SearchResultCategoricalValue()
        {
            DomainObjects = new List<CategoricalValue>();
        }

        public int TotalCount { get; set; }
        public string Cursor { get; set; }
        public List<CategoricalValue> DomainObjects { get; set; }
    }

    public class SearchResultCollectionMethod : IPaginatedResponse<CollectionMethod>
    {
        public SearchResultCollectionMethod()
        {
            DomainObjects = new List<CollectionMethod>();
        }

        public int TotalCount { get; set; }
        public string Cursor { get; set; }
        public List<CollectionMethod> DomainObjects { get; set; }
    }

    public class SearchResultExtendedAttributeDefinition : IPaginatedResponse<ExtendedAttributeDefinition>
    {
        public SearchResultExtendedAttributeDefinition()
        {
            DomainObjects = new List<ExtendedAttributeDefinition>();
        }

        public int TotalCount { get; set; }
        public string Cursor { get; set; }
        public List<ExtendedAttributeDefinition> DomainObjects { get; set; }
    }

    public class SearchResultExtendedAttributeListItem : IPaginatedResponse<ExtendedAttributeListItem>
    {
        public SearchResultExtendedAttributeListItem()
        {
            DomainObjects = new List<ExtendedAttributeListItem>();
        }

        public int TotalCount { get; set; }
        public string Cursor { get; set; }
        public List<ExtendedAttributeListItem> DomainObjects { get; set; }
    }

    public class SearchResultFieldTripBasic : IPaginatedResponse<FieldTripBasic>
    {
        public SearchResultFieldTripBasic()
        {
            DomainObjects = new List<FieldTripBasic>();
        }

        public int TotalCount { get; set; }
        public string Cursor { get; set; }
        public List<FieldTripBasic> DomainObjects { get; set; }
    }

    public class SearchResultFieldVisitSimple : IPaginatedResponse<FieldVisitSimple>
    {
        public SearchResultFieldVisitSimple()
        {
            DomainObjects = new List<FieldVisitSimple>();
        }

        public int TotalCount { get; set; }
        public string Cursor { get; set; }
        public List<FieldVisitSimple> DomainObjects { get; set; }
    }

    public class SearchResultFilter : IPaginatedResponse<Filter>
    {
        public SearchResultFilter()
        {
            DomainObjects = new List<Filter>();
        }

        public int TotalCount { get; set; }
        public string Cursor { get; set; }
        public List<Filter> DomainObjects { get; set; }
    }

    public class SearchResultLaboratory : IPaginatedResponse<Laboratory>
    {
        public SearchResultLaboratory()
        {
            DomainObjects = new List<Laboratory>();
        }

        public int TotalCount { get; set; }
        public string Cursor { get; set; }
        public List<Laboratory> DomainObjects { get; set; }
    }

    public class SearchResultLabReport : IPaginatedResponse<LabReport>
    {
        public SearchResultLabReport()
        {
            DomainObjects = new List<LabReport>();
        }

        public int TotalCount { get; set; }
        public string Cursor { get; set; }
        public List<LabReport> DomainObjects { get; set; }
    }

    public class SearchResultLabReportImportHistoryEvent : IPaginatedResponse<LabReportImportHistoryEvent>
    {
        public SearchResultLabReportImportHistoryEvent()
        {
            DomainObjects = new List<LabReportImportHistoryEvent>();
        }

        public int TotalCount { get; set; }
        public string Cursor { get; set; }
        public List<LabReportImportHistoryEvent> DomainObjects { get; set; }
    }

    public class SearchResultLocationGroupType : IPaginatedResponse<LocationGroupType>
    {
        public SearchResultLocationGroupType()
        {
            DomainObjects = new List<LocationGroupType>();
        }

        public int TotalCount { get; set; }
        public string Cursor { get; set; }
        public List<LocationGroupType> DomainObjects { get; set; }
    }

    public class SearchResultLocationObservationsGroup : IPaginatedResponse<LocationObservationsGroup>
    {
        public SearchResultLocationObservationsGroup()
        {
            DomainObjects = new List<LocationObservationsGroup>();
        }

        public int TotalCount { get; set; }
        public string Cursor { get; set; }
        public List<LocationObservationsGroup> DomainObjects { get; set; }
    }

    public class SearchResultLocationType : IPaginatedResponse<LocationType>
    {
        public SearchResultLocationType()
        {
            DomainObjects = new List<LocationType>();
        }

        public int TotalCount { get; set; }
        public string Cursor { get; set; }
        public List<LocationType> DomainObjects { get; set; }
    }

    public class SearchResultMedium : IPaginatedResponse<Medium>
    {
        public SearchResultMedium()
        {
            DomainObjects = new List<Medium>();
        }

        public int TotalCount { get; set; }
        public string Cursor { get; set; }
        public List<Medium> DomainObjects { get; set; }
    }

    public class SearchResultNullMeasureQualifier : IPaginatedResponse<NullMeasureQualifier>
    {
        public SearchResultNullMeasureQualifier()
        {
            DomainObjects = new List<NullMeasureQualifier>();
        }

        public int TotalCount { get; set; }
        public string Cursor { get; set; }
        public List<NullMeasureQualifier> DomainObjects { get; set; }
    }

    public class SearchResultObservation : IPaginatedResponse<Observation>
    {
        public SearchResultObservation()
        {
            DomainObjects = new List<Observation>();
        }

        public int TotalCount { get; set; }
        public string Cursor { get; set; }
        public List<Observation> DomainObjects { get; set; }
    }

    public class SearchResultObservationNestedInSpecimen : IPaginatedResponse<ObservationNestedInSpecimen>
    {
        public SearchResultObservationNestedInSpecimen()
        {
            DomainObjects = new List<ObservationNestedInSpecimen>();
        }

        public int TotalCount { get; set; }
        public string Cursor { get; set; }
        public List<ObservationNestedInSpecimen> DomainObjects { get; set; }
    }

    public class SearchResultObservedProperty : IPaginatedResponse<ObservedProperty>
    {
        public SearchResultObservedProperty()
        {
            DomainObjects = new List<ObservedProperty>();
        }

        public int TotalCount { get; set; }
        public string Cursor { get; set; }
        public List<ObservedProperty> DomainObjects { get; set; }
    }

    public class SearchResultProject : IPaginatedResponse<Project>
    {
        public SearchResultProject()
        {
            DomainObjects = new List<Project>();
        }

        public int TotalCount { get; set; }
        public string Cursor { get; set; }
        public List<Project> DomainObjects { get; set; }
    }

    public class SearchResultResultDetectionCondition : IPaginatedResponse<ResultDetectionCondition>
    {
        public SearchResultResultDetectionCondition()
        {
            DomainObjects = new List<ResultDetectionCondition>();
        }

        public int TotalCount { get; set; }
        public string Cursor { get; set; }
        public List<ResultDetectionCondition> DomainObjects { get; set; }
    }

    public class SearchResultResultGrade : IPaginatedResponse<ResultGrade>
    {
        public SearchResultResultGrade()
        {
            DomainObjects = new List<ResultGrade>();
        }

        public int TotalCount { get; set; }
        public string Cursor { get; set; }
        public List<ResultGrade> DomainObjects { get; set; }
    }

    public class SearchResultResultStatus : IPaginatedResponse<ResultStatus>
    {
        public SearchResultResultStatus()
        {
            DomainObjects = new List<ResultStatus>();
        }

        public int TotalCount { get; set; }
        public string Cursor { get; set; }
        public List<ResultStatus> DomainObjects { get; set; }
    }

    public class SearchResultSamplingContextTag : IPaginatedResponse<SamplingContextTag>
    {
        public SearchResultSamplingContextTag()
        {
            DomainObjects = new List<SamplingContextTag>();
        }

        public int TotalCount { get; set; }
        public string Cursor { get; set; }
        public List<SamplingContextTag> DomainObjects { get; set; }
    }

    public class SearchResultSamplingLocation : IPaginatedResponse<SamplingLocation>
    {
        public SearchResultSamplingLocation()
        {
            DomainObjects = new List<SamplingLocation>();
        }

        public int TotalCount { get; set; }
        public string Cursor { get; set; }
        public List<SamplingLocation> DomainObjects { get; set; }
    }

    public class SearchResultSamplingLocationGroup : IPaginatedResponse<SamplingLocationGroup>
    {
        public SearchResultSamplingLocationGroup()
        {
            DomainObjects = new List<SamplingLocationGroup>();
        }

        public int TotalCount { get; set; }
        public string Cursor { get; set; }
        public List<SamplingLocationGroup> DomainObjects { get; set; }
    }

    public class SearchResultSchedule : IPaginatedResponse<Schedule>
    {
        public SearchResultSchedule()
        {
            DomainObjects = new List<Schedule>();
        }

        public int TotalCount { get; set; }
        public string Cursor { get; set; }
        public List<Schedule> DomainObjects { get; set; }
    }

    public class SearchResultShippingContainer : IPaginatedResponse<ShippingContainer>
    {
        public SearchResultShippingContainer()
        {
            DomainObjects = new List<ShippingContainer>();
        }

        public int TotalCount { get; set; }
        public string Cursor { get; set; }
        public List<ShippingContainer> DomainObjects { get; set; }
    }

    public class SearchResultSpecimen : IPaginatedResponse<Specimen>
    {
        public SearchResultSpecimen()
        {
            DomainObjects = new List<Specimen>();
        }

        public int TotalCount { get; set; }
        public string Cursor { get; set; }
        public List<Specimen> DomainObjects { get; set; }
    }

    public class SearchResultSpreadsheetTemplate : IPaginatedResponse<SpreadsheetTemplate>
    {
        public SearchResultSpreadsheetTemplate()
        {
            DomainObjects = new List<SpreadsheetTemplate>();
        }

        public int TotalCount { get; set; }
        public string Cursor { get; set; }
        public List<SpreadsheetTemplate> DomainObjects { get; set; }
    }

    public class SearchResultStandardSimple : IPaginatedResponse<StandardSimple>
    {
        public SearchResultStandardSimple()
        {
            DomainObjects = new List<StandardSimple>();
        }

        public int TotalCount { get; set; }
        public string Cursor { get; set; }
        public List<StandardSimple> DomainObjects { get; set; }
    }

    public class SearchResultTaxon : IPaginatedResponse<Taxon>
    {
        public SearchResultTaxon()
        {
            DomainObjects = new List<Taxon>();
        }

        public int TotalCount { get; set; }
        public string Cursor { get; set; }
        public List<Taxon> DomainObjects { get; set; }
    }

    public class SearchResultTaxonomyLevel : IPaginatedResponse<TaxonomyLevel>
    {
        public SearchResultTaxonomyLevel()
        {
            DomainObjects = new List<TaxonomyLevel>();
        }

        public int TotalCount { get; set; }
        public string Cursor { get; set; }
        public List<TaxonomyLevel> DomainObjects { get; set; }
    }

    public class SearchResultTimeZone : IPaginatedResponse<TimeZone>
    {
        public SearchResultTimeZone()
        {
            DomainObjects = new List<TimeZone>();
        }

        public int TotalCount { get; set; }
        public string Cursor { get; set; }
        public List<TimeZone> DomainObjects { get; set; }
    }

    public class SearchResultUnit : IPaginatedResponse<Unit>
    {
        public SearchResultUnit()
        {
            DomainObjects = new List<Unit>();
        }

        public int TotalCount { get; set; }
        public string Cursor { get; set; }
        public List<Unit> DomainObjects { get; set; }
    }

    public class SearchResultUnitGroup : IPaginatedResponse<UnitGroup>
    {
        public SearchResultUnitGroup()
        {
            DomainObjects = new List<UnitGroup>();
        }

        public int TotalCount { get; set; }
        public string Cursor { get; set; }
        public List<UnitGroup> DomainObjects { get; set; }
    }

    public class SearchResultUnitGroupWithUnits : IPaginatedResponse<UnitGroupWithUnits>
    {
        public SearchResultUnitGroupWithUnits()
        {
            DomainObjects = new List<UnitGroupWithUnits>();
        }

        public int TotalCount { get; set; }
        public string Cursor { get; set; }
        public List<UnitGroupWithUnits> DomainObjects { get; set; }
    }

    public class SearchResultUser : IPaginatedResponse<User>
    {
        public SearchResultUser()
        {
            DomainObjects = new List<User>();
        }

        public int TotalCount { get; set; }
        public string Cursor { get; set; }
        public List<User> DomainObjects { get; set; }
    }

    public class ShippingContainer
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public string TrackingId { get; set; }
        public string Comment { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class Specimen
    {
        public Specimen()
        {
            ExtendedAttributes = new List<ExtendedAttribute>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public PreservativeType Preservative { get; set; }
        public bool Filtered { get; set; }
        public string FiltrationComment { get; set; }
        public Laboratory Laboratory { get; set; }
        public ShippingContainer ShippingContainer { get; set; }
        public AnalyticalGroup AnalyticalGroup { get; set; }
        public Activity Activity { get; set; }
        public SpecimenTemplate TemplateCreatedFrom { get; set; }
        public List<ExtendedAttribute> ExtendedAttributes { get; set; }
        public SpecimenViewStatusType Status { get; set; }
        public int NumberOfRequestedObservations { get; set; }
        public int NumberOfReceivedObservations { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class SpecimenNestedInActivity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public PreservativeType Preservative { get; set; }
        public bool Filtered { get; set; }
        public string FiltrationComment { get; set; }
        public AnalyticalGroupSimple AnalyticalGroup { get; set; }
    }

    public class SpecimenTemplate
    {
        public SpecimenTemplate()
        {
            LabInstructionTemplates = new List<LabInstructionTemplate>();
        }

        public List<LabInstructionTemplate> LabInstructionTemplates { get; set; }
        public string Id { get; set; }
        public string CustomId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public AnalyticalGroup AnalyticalGroup { get; set; }
        public PreservativeType Preservative { get; set; }
        public bool Filtered { get; set; }
        public string FiltrationComment { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class SpecimenWithObservations
    {
        public SpecimenWithObservations()
        {
            ExtendedAttributes = new List<ExtendedAttribute>();
            Observations = new List<Observation>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public PreservativeType Preservative { get; set; }
        public bool Filtered { get; set; }
        public string FiltrationComment { get; set; }
        public Laboratory Laboratory { get; set; }
        public ShippingContainer ShippingContainer { get; set; }
        public AnalyticalGroup AnalyticalGroup { get; set; }
        public Activity Activity { get; set; }
        public SpecimenTemplate TemplateCreatedFrom { get; set; }
        public List<ExtendedAttribute> ExtendedAttributes { get; set; }
        public SpecimenViewStatusType Status { get; set; }
        public int NumberOfRequestedObservations { get; set; }
        public int NumberOfReceivedObservations { get; set; }
        public List<Observation> Observations { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class SpreadsheetTemplate
    {
        public SpreadsheetTemplate()
        {
            Attachments = new List<DomainObjectAttachment>();
        }

        public string Id { get; set; }
        public string CustomId { get; set; }
        public SpreadsheetTemplateType Type { get; set; }
        public string Description { get; set; }
        public List<DomainObjectAttachment> Attachments { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class StandardDefinition
    {
        public StandardDefinition()
        {
            SamplingLocations = new List<SamplingLocationSimple>();
            ObservationStandards = new List<ObservationStandard>();
        }

        public string Id { get; set; }
        public string CustomId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string IssuingOrganization { get; set; }
        public TimeRange ApplicabilityRange { get; set; }
        public bool Active { get; set; }
        public List<SamplingLocationSimple> SamplingLocations { get; set; }
        public List<ObservationStandard> ObservationStandards { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class StandardSimple
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string IssuingOrganization { get; set; }
        public TimeRange ApplicabilityRange { get; set; }
        public bool Active { get; set; }
    }

    public class Status
    {
        public string ReleaseName { get; set; }
    }

    public class StringCategoricalResult
    {
    }

    public class Taxon
    {
        public Taxon()
        {
            ImportHistoryEventSimples = new List<ImportHistoryEventSimple>();
        }

        public List<ImportHistoryEventSimple> ImportHistoryEventSimples { get; set; }
        public string Id { get; set; }
        public string ScientificName { get; set; }
        public string CommonName { get; set; }
        public TaxonomyLevel TaxonomyLevel { get; set; }
        public string Source { get; set; }
        public string Comment { get; set; }
        public string ItisTsn { get; set; }
        public string ItisComment { get; set; }
        public string ItisUrl { get; set; }
        public string ParentId { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class TaxonImportSummary
    {
        public TaxonImportSummary()
        {
            ImportItems = new List<ImportItemTaxon>();
            ImportJobErrors = new List<ImportError>();
            NonErrorImportItems = new List<ImportItemTaxon>();
            ErrorImportItems = new List<ImportItemTaxon>();
        }

        public ImportHistoryEventSimple ImportHistoryEventSimple { get; set; }
        public int SuccessCount { get; set; }
        public int SkippedCount { get; set; }
        public int ErrorCount { get; set; }
        public int NewCount { get; set; }
        public int UpdateCount { get; set; }
        public int ExpectedCount { get; set; }
        public List<ImportItemTaxon> ImportItems { get; set; }
        public List<ImportError> ImportJobErrors { get; set; }
        public string InvalidRowsCsvUrl { get; set; }
        public List<ImportItemTaxon> NonErrorImportItems { get; set; }
        public List<ImportItemTaxon> ErrorImportItems { get; set; }
        public string SummaryReportText { get; set; }
    }

    public class TaxonomicResult
    {
        public string Id { get; set; }
        public Taxon Taxon { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class TaxonomyLevel
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class TimeZone
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
    }

    public class Unit
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public string Name { get; set; }
        public double BaseMultiplier { get; set; }
        public double BaseOffset { get; set; }
        public UnitGroup UnitGroup { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class UnitGroup
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public bool SupportsConversion { get; set; }
        public UnitGroupSystemCodeType SystemCode { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class UnitGroupWithUnits
    {
        public UnitGroupWithUnits()
        {
            Units = new List<Unit>();
        }

        public string Id { get; set; }
        public string CustomId { get; set; }
        public bool SupportsConversion { get; set; }
        public UnitGroupWithUnitsSystemCodeType SystemCode { get; set; }
        public List<Unit> Units { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class User
    {
        public User()
        {
            Roles = new List<string>();
            AccessGroups = new List<string>();
        }

        public string Id { get; set; }
        public string CustomId { get; set; }
        public UserProfile UserProfile { get; set; }
        public string ProviderId { get; set; }
        public string Email { get; set; }
        public UserType UserType { get; set; }
        public List<string> Roles { get; set; }
        public List<string> AccessGroups { get; set; }
    }

    public class UserProfile
    {
        public string Id { get; set; }
        public string ProviderId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public string ProfileImageUrl { get; set; }
    }

    public enum ActivityTemplateType
    {
        SAMPLE_INTEGRATED_VERTICAL_PROFILE,
        SAMPLE_ROUTINE,
        REPLICATE,
        BLANK,
        SPIKE,
        FIELD_SURVEY,
        INDEX_CALCULATION,
        NONE
    }

    public enum ActivityType
    {
        SAMPLE_INTEGRATED_VERTICAL_PROFILE,
        SAMPLE_ROUTINE,
        REPLICATE,
        BLANK,
        SPIKE,
        FIELD_SURVEY,
        INDEX_CALCULATION,
        NONE
    }

    public enum ActivityWithDetailsType
    {
        SAMPLE_INTEGRATED_VERTICAL_PROFILE,
        SAMPLE_ROUTINE,
        REPLICATE,
        BLANK,
        SPIKE,
        FIELD_SURVEY,
        INDEX_CALCULATION,
        NONE
    }

    public enum AddressType
    {
        LOCATION,
        MAILING,
        SHIPPING
    }

    public enum AggregationType
    {
        SUM
    }

    public enum AnalysisType
    {
        BIOLOGICAL,
        CHEMICAL,
        PHYSICAL
    }

    public enum AnalyticalGroupSimpleType
    {
        KNOWN,
        UNKNOWN,
        FIELD_SURVEY
    }

    public enum AnalyticalGroupType
    {
        KNOWN,
        UNKNOWN,
        FIELD_SURVEY
    }

    public enum AppliesToType
    {
        SAMPLING_LOCATION,
        OBSERVATION,
        ACTIVITY,
        FIELD_VISIT,
        SPECIMEN
    }

    public enum DataClassificationType
    {
        LAB,
        FIELD_RESULT,
        FIELD_SURVEY,
        VERTICAL_PROFILE,
        ACTIVITY_RESULT,
        SURROGATE_RESULT
    }

    public enum DataType
    {
        TEXT,
        NUMBER,
        DROP_DOWN_LIST
    }

    public enum DeterminationType
    {
        ACTUAL,
        BLANK_CORRECTED_CALCULATED,
        CALCULATED,
        CONTROL_ADJUSTED,
        ESTIMATED
    }

    public enum FieldResultType
    {
        ANALYSIS,
        MEASUREMENT
    }

    public enum FormatType
    {
        CSV,
        WQX,
        CROSSTAB_CSV,
        XSLX
    }

    public enum GetUnitGroupsSystemCodeType
    {
        LENGTH
    }

    public enum GetUnitGroupWithUnitsSystemCodeType
    {
        LENGTH
    }

    public enum ImportItemStatusType
    {
        ERROR,
        NEW,
        UPDATE,
        EXPECTED,
        SKIPPED
    }

    public enum ImportProcessorTransactionStatusType
    {
        PENDING,
        IN_PROGRESS,
        COMPLETED,
        COMPLETED_WITH_ERRORS,
        BAD_REQUEST,
        SYSTEM_ERROR
    }

    public enum ImportType
    {
        OBSERVATION_CSV,
        OBSERVATION_LABREPORT,
        SAMPLINGLOCATION_CSV,
        OBSERVED_PROPERTIES_CSV,
        ANALYSIS_METHODS_CSV,
        TAXON_CSV,
        SAMPLING_PLAN
    }

    public enum MediumSystemCodeType
    {
        WATER,
        SOIL,
        AIR,
        BIOLOGICAL,
        HABITAT,
        SEDIMENT,
        TISSUE,
        OTHER,
        GROUNDWATER,
        RAINWATER,
        SURFACE_WATER,
        WASTE_WATER
    }

    public enum MediumType
    {
        WATER,
        SOIL,
        AIR,
        BIOLOGICAL,
        HABITAT,
        SEDIMENT,
        TISSUE,
        OTHER,
        GROUNDWATER,
        RAINWATER,
        SURFACE_WATER,
        WASTE_WATER
    }

    public enum OperationType
    {
        INSERT,
        UPDATE,
        DELETE
    }

    public enum PlannedActivityActivityType
    {
        SAMPLE_INTEGRATED_VERTICAL_PROFILE,
        SAMPLE_ROUTINE,
        REPLICATE,
        BLANK,
        SPIKE,
        FIELD_SURVEY,
        INDEX_CALCULATION,
        NONE
    }

    public enum PlanningStatusType
    {
        PLANNED,
        IN_PROGRESS,
        CANCELLED,
        DONE
    }

    public enum PreservativeType
    {
        SULFURIC_ACID,
        NITRIC_ACID,
        HYDROCHLORIC_ACID,
        SODIUM_HYDROXIDE,
        ICE,
        ISOPROPYL_ALCOHOL,
        MERCURIC_CHLORIDE,
        LIQUID_NITROGEN,
        FORMALIN,
        SODIUM_AZIDE,
        FIELD_FREEZE,
        KEEP_DARK
    }

    public enum ProjectType
    {
        ROUTINE_MONITORING,
        EVENT_BASED_MONITORING,
        RESTORATION_PROJECT,
        STUDY
    }

    public enum QualityControlType
    {
        NORMAL,
        REPLICATE,
        BLANK,
        SPIKE
    }

    public enum RecurrenceDayMonthlyType
    {
        FIRST_DAY_OF_MONTH,
        LAST_DAY_OF_MONTH
    }

    public enum RecurrenceDayWeeklyType
    {
        MONDAY,
        TUESDAY,
        WEDNESDAY,
        THURSDAY,
        FRIDAY,
        SATURDAY,
        SUNDAY
    }

    public enum RecurrenceType
    {
        WEEKLY,
        MONTHLY
    }

    public enum ResultGradeSystemCodeType
    {
        UNKNOWN
    }

    public enum ResultStatusSystemCodeType
    {
        REQUESTED,
        PRELIMINARY
    }

    public enum ResultType
    {
        NUMERIC,
        CATEGORICAL,
        TAXON,
        CATEGORICAL_FIXED_VALUES
    }

    public enum SampleFractionType
    {
        DISSOLVED,
        TOTAL
    }

    public enum SamplingLocationGroupSelectionType
    {
        ALL,
        RANDOM
    }

    public enum SourceRoundedValueType
    {
        PROVIDED_BY_USER,
        ROUNDING_SPECIFICATION,
        SYSTEM_DEFAULT
    }

    public enum SpecimenViewStatusType
    {
        REQUESTED,
        RECEIVED_SOME,
        RECEIVED_ALL
    }

    public enum SpreadsheetTemplateType
    {
        CUSTODY_LOG,
        OBSERVATION_EXPORT
    }

    public enum UnitGroupSystemCodeType
    {
        LENGTH
    }

    public enum UnitGroupWithUnitsSystemCodeType
    {
        LENGTH
    }

    public enum UserType
    {
        INTERNAL,
        EXTERNAL
    }
}
