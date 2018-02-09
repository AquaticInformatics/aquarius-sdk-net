// Date: 2018-02-08T18:25:53.3009591-08:00
// Base URL: https://demo.aqsamples.com/api/swagger.json
// Source: AQUARIUS Samples API (2018.02.2791)

using System.Collections.Generic;
using ServiceStack;
using NodaTime;
using Aquarius.TimeSeries.Client;
// ReSharper disable InconsistentNaming

// ReSharper disable once CheckNamespace
namespace Aquarius.Samples.Client.ServiceModel
{
    public static class Current
    {
        public static readonly AquariusServerVersion Version = AquariusServerVersion.Create("2018.02.2791");
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
        public List<SamplingLocationGroupSimple> SamplingLocationGroups { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/accessgroups/{id}", "GET")]
    public class GetAccessGroup : IReturn<AccessGroup>
    {
        public string Id { get; set; }
    }

    [Route("/v1/accessgroups/{id}", "PUT")]
    public class PutSparseAccessGroup : IReturn<AccessGroup>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? CanEditAllData { get; set; }
        public List<SamplingLocationGroupSimple> SamplingLocationGroups { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/accessgroups/{id}", "DELETE")]
    public class DeleteAccessGroupById : IReturnVoid
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
        public List<string> SamplingLocationIds { get; set; }
        public string Sort { get; set; }
        public Instant? ToStartTime { get; set; }
    }

    [Route("/v1/activities", "POST")]
    public class PostActivity : IReturn<Activity>
    {
        public Quantity Depth { get; set; }
        public SamplingLocation SamplingLocation { get; set; }
        public FieldVisit FieldVisit { get; set; }
        public List<SamplingContextTag> SamplingContextTags { get; set; }
        public string Id { get; set; }
        public string CustomId { get; set; }
        public ActivityType? Type { get; set; }
        public string ReplicateSourceActivityId { get; set; }
        public Instant? StartTime { get; set; }
        public Instant? EndTime { get; set; }
        public string Comment { get; set; }
        public string LoggerFileName { get; set; }
        public Device Device { get; set; }
        public CollectionMethod CollectionMethod { get; set; }
        public MediumType? Medium { get; set; }
        public PlannedActivity PlannedActivity { get; set; }
        public ActivityTemplate ActivityTemplate { get; set; }
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
        public List<string> SamplingLocationIds { get; set; }
        public string Sort { get; set; }
        public Instant? ToStartTime { get; set; }
    }

    [Route("/v1/activities/{id}", "GET")]
    public class GetActivity : IReturn<ActivityRepresentation>
    {
        public string Id { get; set; }
        public bool? Detail { get; set; }
    }

    [Route("/v1/activities/{id}", "PUT")]
    public class PutSparseActivity : IReturn<Activity>
    {
        public string Id { get; set; }
        public Quantity Depth { get; set; }
        public SamplingLocation SamplingLocation { get; set; }
        public FieldVisit FieldVisit { get; set; }
        public List<SamplingContextTag> SamplingContextTags { get; set; }
        public string CustomId { get; set; }
        public ActivityType? Type { get; set; }
        public string ReplicateSourceActivityId { get; set; }
        public Instant? StartTime { get; set; }
        public Instant? EndTime { get; set; }
        public string Comment { get; set; }
        public string LoggerFileName { get; set; }
        public Device Device { get; set; }
        public CollectionMethod CollectionMethod { get; set; }
        public MediumType? Medium { get; set; }
        public PlannedActivity PlannedActivity { get; set; }
        public ActivityTemplate ActivityTemplate { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/activities/{id}", "DELETE")]
    public class DeleteActivityById : IReturnVoid
    {
        public string Id { get; set; }
    }

    [Route("/v1/activities/{id}/replicate", "POST")]
    public class PostReplicateActivity : IReturn<Activity>
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
        public ActivityType? Type { get; set; }
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
    public class PutSparseActivityTemplate : IReturn<ActivityTemplate>
    {
        public string Id { get; set; }
        public List<SpecimenTemplate> SpecimenTemplates { get; set; }
        public string CustomId { get; set; }
        public ActivityType? Type { get; set; }
        public string Comment { get; set; }
        public MediumType? Medium { get; set; }
        public Quantity Depth { get; set; }
        public CollectionMethod CollectionMethod { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/activitytemplates/{id}", "DELETE")]
    public class DeleteActivityTemplateById : IReturnVoid
    {
        public string Id { get; set; }
    }

    [Route("/v1/analyticalgroups", "GET")]
    public class GetAnalyticalGroups : IReturn<SearchResultAnalyticalGroup>
    {
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
    public class PutSparseAnalyticalGroup : IReturn<AnalyticalGroup>
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
    public class DeleteAnalyticalGroupById : IReturnVoid
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
    public class GetAttachmentContent : IReturnVoid
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
    public class PutSparseCollectionMethod : IReturn<CollectionMethod>
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public string IdentifierOrganization { get; set; }
        public string Name { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/collectionmethods/{id}", "DELETE")]
    public class DeleteCollectionMethodById : IReturnVoid
    {
        public string Id { get; set; }
    }

    [Route("/v1/fieldtrips", "GET")]
    public class GetFieldTrips : IReturn<SearchResultFieldTrip>
    {
        public int? Limit { get; set; }
        public List<string> Search { get; set; }
    }

    [Route("/v1/fieldtrips", "POST")]
    public class PostFieldTrip : IReturn<FieldTrip>
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public List<FieldVisit> FieldVisits { get; set; }
        public Instant? StartTime { get; set; }
        public Instant? EndTime { get; set; }
        public string Participants { get; set; }
        public string Notes { get; set; }
        public List<DomainObjectAttachment> Attachments { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/fieldtrips/{id}", "GET")]
    public class GetFieldTrip : IReturn<FieldTrip>
    {
        public string Id { get; set; }
    }

    [Route("/v1/fieldtrips/{id}", "PUT")]
    public class PutSparseFieldTrip : IReturn<FieldTrip>
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public List<FieldVisit> FieldVisits { get; set; }
        public Instant? StartTime { get; set; }
        public Instant? EndTime { get; set; }
        public string Participants { get; set; }
        public string Notes { get; set; }
        public List<DomainObjectAttachment> Attachments { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/fieldtrips/{id}", "DELETE")]
    public class DeleteFieldTripById : IReturnVoid
    {
        public string Id { get; set; }
    }

    [Route("/v1/fieldvisits", "GET")]
    public class GetFieldVisits : IReturn<SearchResultFieldVisitSimple>
    {
        public Instant? EndStartTime { get; set; }
        public List<string> FieldTripIds { get; set; }
        public List<string> Ids { get; set; }
        public int? Limit { get; set; }
        public List<string> PlanningStatuses { get; set; }
        public List<string> SamplingLocationIds { get; set; }
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
        public PlanningStatusType? PlanningStatus { get; set; }
        public SamplingLocation SamplingLocation { get; set; }
        public List<PlannedFieldResult> PlannedFieldResults { get; set; }
        public List<PlannedActivity> PlannedActivities { get; set; }
        public List<DomainObjectAttachment> Attachments { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/fieldvisits", "DELETE")]
    public class DeleteFieldVisits : IReturnVoid
    {
        public Instant? EndStartTime { get; set; }
        public List<string> FieldTripIds { get; set; }
        public List<string> Ids { get; set; }
        public int? Limit { get; set; }
        public List<string> PlanningStatuses { get; set; }
        public List<string> SamplingLocationIds { get; set; }
        public Instant? StartStartTime { get; set; }
    }

    [Route("/v1/fieldvisits/{id}", "GET")]
    public class GetFieldVisit : IReturn<FieldVisit>
    {
        public string Id { get; set; }
    }

    [Route("/v1/fieldvisits/{id}", "PUT")]
    public class PutSparseFieldVisit : IReturn<FieldVisit>
    {
        public string Id { get; set; }
        public Instant? StartTime { get; set; }
        public Instant? EndTime { get; set; }
        public string Participants { get; set; }
        public string Notes { get; set; }
        public FieldTripSimple FieldTrip { get; set; }
        public PlanningStatusType? PlanningStatus { get; set; }
        public SamplingLocation SamplingLocation { get; set; }
        public List<PlannedFieldResult> PlannedFieldResults { get; set; }
        public List<PlannedActivity> PlannedActivities { get; set; }
        public List<DomainObjectAttachment> Attachments { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/fieldvisits/{id}", "DELETE")]
    public class DeleteFieldVisitById : IReturnVoid
    {
        public string Id { get; set; }
    }

    [Route("/v1/fieldvisits/{id}/activityfromplannedactivity", "POST")]
    public class PostActivityFromPlannedActivity : IReturn<Activity>
    {
        public string Id { get; set; }
        public ActivityTemplate ActivityTemplate { get; set; }
        public string Instruction { get; set; }
        public ActivityType? ActivityType { get; set; }
        public MediumType? Medium { get; set; }
        public CollectionMethod CollectionMethod { get; set; }
        public string HashForFieldsThatRequireUniqueness { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/fieldvisits/{id}/activitywithtemplate", "POST")]
    public class PostActivityWithTemplate : IReturn<Activity>
    {
        public string Id { get; set; }
        public List<SpecimenTemplate> SpecimenTemplates { get; set; }
        public string CustomId { get; set; }
        public ActivityType? Type { get; set; }
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

    [Route("/v1/fieldvisits/{id}/statistics", "GET")]
    public class GetFieldVisitStatistics : IReturn<FieldVisitStatistics>
    {
        public string Id { get; set; }
    }

    [Route("/v1/labanalysismethods", "GET")]
    public class GetLabAnalysisMethods : IReturn<SearchResultLabAnalysisMethod>
    {
        public string Context { get; set; }
        public List<string> ObservedPropertyIds { get; set; }
    }

    [Route("/v1/labanalysismethods", "POST")]
    public class PostLabAnalysisMethod : IReturn<LabAnalysisMethod>
    {
        public List<ObservedProperty> ObservedProperties { get; set; }
        public string Id { get; set; }
        public string MethodId { get; set; }
        public string Name { get; set; }
        public string Context { get; set; }
        public string Description { get; set; }
        public List<ImportHistoryEventSimple> ImportHistoryEventSimples { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/labanalysismethods/{id}", "GET")]
    public class GetLabAnalysisMethod : IReturn<LabAnalysisMethod>
    {
        public string Id { get; set; }
    }

    [Route("/v1/labanalysismethods/{id}", "PUT")]
    public class PutSparseLabAnalysisMethod : IReturn<LabAnalysisMethod>
    {
        public string Id { get; set; }
        public List<ObservedProperty> ObservedProperties { get; set; }
        public string MethodId { get; set; }
        public string Name { get; set; }
        public string Context { get; set; }
        public string Description { get; set; }
        public List<ImportHistoryEventSimple> ImportHistoryEventSimples { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/labanalysismethods/{id}", "DELETE")]
    public class DeleteLabAnalysisMethodById : IReturnVoid
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
    public class PutSparseLaboratory : IReturn<Laboratory>
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
    public class DeleteLaboratoryById : IReturnVoid
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
    public class PutSparseLabReport : IReturn<LabReport>
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
    public class DeleteLabReportById : IReturnVoid
    {
        public string Id { get; set; }
    }

    [Route("/v1/observations", "GET")]
    public class GetObservations : IReturn<SearchResultObservation>, IPaginatedRequest
    {
        public string ActivityCustomId { get; set; }
        public List<string> ActivityIds { get; set; }
        public List<string> AnalyticalGroupIds { get; set; }
        public List<string> CollectionMethodIds { get; set; }
        public string Cursor { get; set; }
        public string CustomId { get; set; }
        public List<string> DataClassifications { get; set; }
        public string DepthUnitCustomId { get; set; }
        public string DepthUnitId { get; set; }
        public double? DepthValue { get; set; }
        public DetectionConditionType? DetectionCondition { get; set; }
        public Instant? EndObservedTime { get; set; }
        public Instant? EndResultTime { get; set; }
        public Instant? EndModificationTime { get; set; }
        public string FieldVisitId { get; set; }
        public string ImportHistoryEventId { get; set; }
        public List<string> LabReportIds { get; set; }
        public List<string> LabResultLabAnalysisMethodIds { get; set; }
        public List<string> LabResultLaboratoryIds { get; set; }
        public int? Limit { get; set; }
        public List<string> Media { get; set; }
        public List<string> ObservedPropertyIds { get; set; }
        public string ProjectId { get; set; }
        public List<string> QualityControlTypes { get; set; }
        public List<string> ResultGrades { get; set; }
        public List<string> ResultStatuses { get; set; }
        public SampleFractionType? SampleFraction { get; set; }
        public List<string> SamplingContextTagIds { get; set; }
        public List<string> SamplingLocationGroupIds { get; set; }
        public List<string> SamplingLocationIds { get; set; }
        public List<string> Search { get; set; }
        public string Sort { get; set; }
        public string SpecimenName { get; set; }
        public Instant? StartObservedTime { get; set; }
        public Instant? StartResultTime { get; set; }
        public Instant? StartModificationTime { get; set; }
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
        public MediumType? Medium { get; set; }
        public string MediumSubdivision { get; set; }
        public Instant? ObservedTime { get; set; }
        public Instant? ResultTime { get; set; }
        public Quantity Depth { get; set; }
        public LabInstruction LabInstruction { get; set; }
        public LabResultDetails LabResultDetails { get; set; }
        public string Comment { get; set; }
        public FieldVisit FieldVisit { get; set; }
        public Device Device { get; set; }
        public List<ImportHistoryEventSimple> ImportHistoryEventSimples { get; set; }
        public List<RuleValidationDetails> ValidationWarnings { get; set; }
        public ResultGrade ResultGrade { get; set; }
        public ResultStatus ResultStatus { get; set; }
        public PlannedFieldResult PlannedFieldResult { get; set; }
        public Taxon RelatedTaxon { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/observations", "DELETE")]
    public class DeleteObservations : IReturnVoid
    {
        public string ActivityCustomId { get; set; }
        public List<string> ActivityIds { get; set; }
        public List<string> AnalyticalGroupIds { get; set; }
        public List<string> CollectionMethodIds { get; set; }
        public string Cursor { get; set; }
        public string CustomId { get; set; }
        public List<string> DataClassifications { get; set; }
        public string DepthUnitCustomId { get; set; }
        public string DepthUnitId { get; set; }
        public double? DepthValue { get; set; }
        public DetectionConditionType? DetectionCondition { get; set; }
        public Instant? EndObservedTime { get; set; }
        public Instant? EndResultTime { get; set; }
        public Instant? EndModificationTime { get; set; }
        public string FieldVisitId { get; set; }
        public string ImportHistoryEventId { get; set; }
        public List<string> LabReportIds { get; set; }
        public List<string> LabResultLabAnalysisMethodIds { get; set; }
        public List<string> LabResultLaboratoryIds { get; set; }
        public int? Limit { get; set; }
        public List<string> Media { get; set; }
        public List<string> ObservedPropertyIds { get; set; }
        public string ProjectId { get; set; }
        public List<string> QualityControlTypes { get; set; }
        public List<string> ResultGrades { get; set; }
        public List<string> ResultStatuses { get; set; }
        public SampleFractionType? SampleFraction { get; set; }
        public List<string> SamplingContextTagIds { get; set; }
        public List<string> SamplingLocationGroupIds { get; set; }
        public List<string> SamplingLocationIds { get; set; }
        public List<string> Search { get; set; }
        public string Sort { get; set; }
        public string SpecimenName { get; set; }
        public Instant? StartObservedTime { get; set; }
        public Instant? StartResultTime { get; set; }
        public Instant? StartModificationTime { get; set; }
        public List<string> TaxonIds { get; set; }
    }

    [Route("/v1/observations/{id}", "GET")]
    public class GetObservation : IReturn<Observation>
    {
        public string Id { get; set; }
    }

    [Route("/v1/observations/{id}", "PUT")]
    public class PutSparseObservation : IReturn<Observation>
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
        public MediumType? Medium { get; set; }
        public string MediumSubdivision { get; set; }
        public Instant? ObservedTime { get; set; }
        public Instant? ResultTime { get; set; }
        public Quantity Depth { get; set; }
        public LabInstruction LabInstruction { get; set; }
        public LabResultDetails LabResultDetails { get; set; }
        public string Comment { get; set; }
        public FieldVisit FieldVisit { get; set; }
        public Device Device { get; set; }
        public List<ImportHistoryEventSimple> ImportHistoryEventSimples { get; set; }
        public List<RuleValidationDetails> ValidationWarnings { get; set; }
        public ResultGrade ResultGrade { get; set; }
        public ResultStatus ResultStatus { get; set; }
        public PlannedFieldResult PlannedFieldResult { get; set; }
        public Taxon RelatedTaxon { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/observations/{id}", "DELETE")]
    public class DeleteObservationById : IReturnVoid
    {
        public string Id { get; set; }
    }

    [Route("/v1/observations/charts", "GET")]
    public class GetChartData : IReturn<MultiChartData>
    {
        public string ActivityCustomId { get; set; }
        public List<string> ActivityIds { get; set; }
        public List<string> AnalyticalGroupIds { get; set; }
        public List<string> CollectionMethodIds { get; set; }
        public string Cursor { get; set; }
        public string CustomId { get; set; }
        public List<string> DataClassifications { get; set; }
        public string DepthUnitCustomId { get; set; }
        public string DepthUnitId { get; set; }
        public double? DepthValue { get; set; }
        public DetectionConditionType? DetectionCondition { get; set; }
        public Instant? EndObservedTime { get; set; }
        public Instant? EndResultTime { get; set; }
        public Instant? EndModificationTime { get; set; }
        public string FieldVisitId { get; set; }
        public string ImportHistoryEventId { get; set; }
        public List<string> LabReportIds { get; set; }
        public List<string> LabResultLabAnalysisMethodIds { get; set; }
        public List<string> LabResultLaboratoryIds { get; set; }
        public int? Limit { get; set; }
        public List<string> Media { get; set; }
        public List<string> ObservedPropertyIds { get; set; }
        public string ProjectId { get; set; }
        public List<string> QualityControlTypes { get; set; }
        public List<string> ResultGrades { get; set; }
        public List<string> ResultStatuses { get; set; }
        public SampleFractionType? SampleFraction { get; set; }
        public List<string> SamplingContextTagIds { get; set; }
        public List<string> SamplingLocationGroupIds { get; set; }
        public List<string> SamplingLocationIds { get; set; }
        public List<string> Search { get; set; }
        public string Sort { get; set; }
        public string SpecimenName { get; set; }
        public Instant? StartObservedTime { get; set; }
        public Instant? StartResultTime { get; set; }
        public Instant? StartModificationTime { get; set; }
        public List<string> TaxonIds { get; set; }
    }

    [Route("/v1/observations/geographic", "GET")]
    public class GetGroupedObservations : IReturn<SearchResultLocationObservationsGroup>, IPaginatedRequest
    {
        public string ActivityCustomId { get; set; }
        public List<string> ActivityIds { get; set; }
        public List<string> AnalyticalGroupIds { get; set; }
        public List<string> CollectionMethodIds { get; set; }
        public string Cursor { get; set; }
        public string CustomId { get; set; }
        public List<string> DataClassifications { get; set; }
        public string DepthUnitCustomId { get; set; }
        public string DepthUnitId { get; set; }
        public double? DepthValue { get; set; }
        public DetectionConditionType? DetectionCondition { get; set; }
        public Instant? EndObservedTime { get; set; }
        public Instant? EndResultTime { get; set; }
        public Instant? EndModificationTime { get; set; }
        public string FieldVisitId { get; set; }
        public string ImportHistoryEventId { get; set; }
        public List<string> LabReportIds { get; set; }
        public List<string> LabResultLabAnalysisMethodIds { get; set; }
        public List<string> LabResultLaboratoryIds { get; set; }
        public int? Limit { get; set; }
        public List<string> Media { get; set; }
        public List<string> ObservedPropertyIds { get; set; }
        public string ProjectId { get; set; }
        public List<string> QualityControlTypes { get; set; }
        public List<string> ResultGrades { get; set; }
        public List<string> ResultStatuses { get; set; }
        public SampleFractionType? SampleFraction { get; set; }
        public List<string> SamplingContextTagIds { get; set; }
        public List<string> SamplingLocationGroupIds { get; set; }
        public List<string> SamplingLocationIds { get; set; }
        public List<string> Search { get; set; }
        public string Sort { get; set; }
        public string SpecimenName { get; set; }
        public Instant? StartObservedTime { get; set; }
        public Instant? StartResultTime { get; set; }
        public Instant? StartModificationTime { get; set; }
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
    public class PutSparseObservedProperty : IReturn<ObservedProperty>
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
    public class DeleteObservedPropertyById : IReturnVoid
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
        public ProjectType? Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ScopeStatement { get; set; }
        public bool? Approved { get; set; }
        public string ApprovalAgency { get; set; }
        public Instant? StartTime { get; set; }
        public Instant? EndTime { get; set; }
        public Filter Filter { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/projects/{id}", "GET")]
    public class GetProject : IReturn<Project>
    {
        public string Id { get; set; }
    }

    [Route("/v1/projects/{id}", "PUT")]
    public class PutSparseProject : IReturn<Project>
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public ProjectType? Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ScopeStatement { get; set; }
        public bool? Approved { get; set; }
        public string ApprovalAgency { get; set; }
        public Instant? StartTime { get; set; }
        public Instant? EndTime { get; set; }
        public Filter Filter { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/projects/{id}", "DELETE")]
    public class DeleteProjectById : IReturnVoid
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

    [Route("/v1/resultstatuses", "GET")]
    public class GetResultStatuses : IReturn<SearchResultResultStatus>
    {
        
    }

    [Route("/v1/resultstatuses", "PUT")]
    public class PutResultStatuses : IReturn<List<ResultStatus>>
    {
        
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
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/samplinglocationgroups/{id}", "GET")]
    public class GetSamplingLocationGroup : IReturn<SamplingLocationGroup>
    {
        public string Id { get; set; }
    }

    [Route("/v1/samplinglocationgroups/{id}", "PUT")]
    public class PutSparseSamplingLocationGroup : IReturn<SamplingLocationGroup>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/samplinglocationgroups/{id}", "DELETE")]
    public class DeleteSamplingLocationGroupById : IReturnVoid
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
        public List<string> SamplingLocationGroupIds { get; set; }
        public List<string> Search { get; set; }
        public string Sort { get; set; }
        public Instant? StartModificationTime { get; set; }
    }

    [Route("/v1/samplinglocations", "POST")]
    public class PostSamplingLocation : IReturn<SamplingLocation>
    {
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
        public List<ImportHistoryEventSimple> ImportHistoryEventSimples { get; set; }
        public List<StandardSimple> Standards { get; set; }
        public List<DomainObjectAttachment> Attachments { get; set; }
        public List<SamplingLocationGroupSimple> SamplingLocationGroups { get; set; }
        public string Id { get; set; }
        public string CustomId { get; set; }
        public string Name { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/samplinglocations/{id}", "GET")]
    public class GetSamplingLocation : IReturn<SamplingLocation>
    {
        public string Id { get; set; }
    }

    [Route("/v1/samplinglocations/{id}", "PUT")]
    public class PutSparseSamplingLocation : IReturn<SamplingLocation>
    {
        public string Id { get; set; }
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
        public List<ImportHistoryEventSimple> ImportHistoryEventSimples { get; set; }
        public List<StandardSimple> Standards { get; set; }
        public List<DomainObjectAttachment> Attachments { get; set; }
        public List<SamplingLocationGroupSimple> SamplingLocationGroups { get; set; }
        public string CustomId { get; set; }
        public string Name { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/samplinglocations/{id}", "DELETE")]
    public class DeleteSamplingLocationById : IReturnVoid
    {
        public string Id { get; set; }
    }

    [Route("/v1/samplinglocations/{id}/attachments", "GET")]
    public class GetSamplingLocationAttachments : IReturn<SearchResultAttachment>
    {
        public string Id { get; set; }
    }

    [Route("/v1/samplinglocations/{id}/canedit", "GET")]
    public class GetCanUserEditSamplingLocationData : IReturn<bool>
    {
        public string Id { get; set; }
    }

    [Route("/v1/samplinglocations/{id}/summary", "GET")]
    public class GetSummary : IReturn<SamplingLocationSummary>
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

    [Route("/v1/services/export/fieldsheets/{fieldVisitId}", "GET")]
    public class GetExportFieldSheet : IReturnVoid
    {
        public string FieldVisitId { get; set; }
    }

    [Route("/v1/services/export/observations", "GET")]
    public class GetExportObservations : IReturnVoid
    {
        public FormatType? Format { get; set; }
        public string ActivityCustomId { get; set; }
        public List<string> ActivityIds { get; set; }
        public List<string> AnalyticalGroupIds { get; set; }
        public List<string> CollectionMethodIds { get; set; }
        public string Cursor { get; set; }
        public string CustomId { get; set; }
        public List<string> DataClassifications { get; set; }
        public string DepthUnitCustomId { get; set; }
        public string DepthUnitId { get; set; }
        public double? DepthValue { get; set; }
        public DetectionConditionType? DetectionCondition { get; set; }
        public Instant? EndObservedTime { get; set; }
        public Instant? EndResultTime { get; set; }
        public Instant? EndModificationTime { get; set; }
        public string FieldVisitId { get; set; }
        public string ImportHistoryEventId { get; set; }
        public List<string> LabReportIds { get; set; }
        public List<string> LabResultLabAnalysisMethodIds { get; set; }
        public List<string> LabResultLaboratoryIds { get; set; }
        public int? Limit { get; set; }
        public List<string> Media { get; set; }
        public List<string> ObservedPropertyIds { get; set; }
        public string ProjectId { get; set; }
        public List<string> QualityControlTypes { get; set; }
        public List<string> ResultGrades { get; set; }
        public List<string> ResultStatuses { get; set; }
        public SampleFractionType? SampleFraction { get; set; }
        public List<string> SamplingContextTagIds { get; set; }
        public List<string> SamplingLocationGroupIds { get; set; }
        public List<string> SamplingLocationIds { get; set; }
        public List<string> Search { get; set; }
        public string Sort { get; set; }
        public string SpecimenName { get; set; }
        public Instant? StartObservedTime { get; set; }
        public Instant? StartResultTime { get; set; }
        public Instant? StartModificationTime { get; set; }
        public List<string> TaxonIds { get; set; }
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
        public List<string> LaboratoryIds { get; set; }
        public int? Limit { get; set; }
        public List<string> SamplingLocationIds { get; set; }
        public List<string> Search { get; set; }
        public string Sort { get; set; }
        public List<string> SpecimenStatuses { get; set; }
        public Instant? StartModificationTime { get; set; }
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
    public class PostImportAnalysisMethods : IReturn<LabAnalysisMethodImportSummary>
    {
        
    }

    [Route("/v1/services/import/labanalysismethods/dryrun", "POST")]
    public class PostImportAnalysisMethodsDryrun : IReturn<LabAnalysisMethodImportSummary>
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
    public class PostImportObservationsDryrun : IReturn<ObservationImportSummary>
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
    public class PostImportObservedPropertiesDryrun : IReturn<ObservedPropertyImportSummary>
    {
        
    }

    [Route("/v1/services/import/samplinglocations", "POST")]
    public class PostImportSamplingLocations : IReturn<SamplingLocationImportSummary>
    {
        public string FileType { get; set; }
    }

    [Route("/v1/services/import/samplinglocations/dryrun", "POST")]
    public class PostImportSamplingLocationsDryrun : IReturn<SamplingLocationImportSummary>
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
    public class PutSparseShippingContainer : IReturn<ShippingContainer>
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public string TrackingId { get; set; }
        public string Comment { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/shippingcontainers/{id}", "DELETE")]
    public class DeleteShippingContainerById : IReturnVoid
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
        public List<string> LaboratoryIds { get; set; }
        public int? Limit { get; set; }
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
        public List<Surrogate> Surrogates { get; set; }
        public AnalyticalGroup AnalyticalGroup { get; set; }
        public Activity Activity { get; set; }
        public SpecimenTemplate TemplateCreatedFrom { get; set; }
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
    public class PutSparseSpecimen : IReturn<SpecimenWithObservations>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public PreservativeType? Preservative { get; set; }
        public bool? Filtered { get; set; }
        public string FiltrationComment { get; set; }
        public Laboratory Laboratory { get; set; }
        public ShippingContainer ShippingContainer { get; set; }
        public List<Surrogate> Surrogates { get; set; }
        public AnalyticalGroup AnalyticalGroup { get; set; }
        public Activity Activity { get; set; }
        public SpecimenTemplate TemplateCreatedFrom { get; set; }
        public List<Observation> Observations { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/specimens/{id}", "DELETE")]
    public class DeleteSpecimenById : IReturnVoid
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
    public class PutSparseSpreadsheetTemplate : IReturn<SpreadsheetTemplate>
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public string Description { get; set; }
        public List<DomainObjectAttachment> Attachments { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/spreadsheettemplates/{id}", "DELETE")]
    public class DeleteSpreadsheetTemplateById : IReturnVoid
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
    public class PutSparseStandard : IReturn<StandardDefinition>
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
    public class PutSparseTag : IReturn<SamplingContextTag>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/tags/{id}", "DELETE")]
    public class DeleteTagById : IReturnVoid
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
        public string Id { get; set; }
        public string ScientificName { get; set; }
        public string CommonName { get; set; }
        public string Level { get; set; }
        public string Source { get; set; }
        public string Comment { get; set; }
        public string ItisTsn { get; set; }
        public string ItisComment { get; set; }
        public string ItisUrl { get; set; }
        public List<ImportHistoryEventSimple> ImportHistoryEventSimples { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/taxons/{id}", "GET")]
    public class GetTaxon : IReturn<Taxon>
    {
        public string Id { get; set; }
    }

    [Route("/v1/taxons/{id}", "PUT")]
    public class PutSparseTaxon : IReturn<Taxon>
    {
        public string Id { get; set; }
        public string ScientificName { get; set; }
        public string CommonName { get; set; }
        public string Level { get; set; }
        public string Source { get; set; }
        public string Comment { get; set; }
        public string ItisTsn { get; set; }
        public string ItisComment { get; set; }
        public string ItisUrl { get; set; }
        public List<ImportHistoryEventSimple> ImportHistoryEventSimples { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/taxons/{id}", "DELETE")]
    public class DeleteTaxonById : IReturnVoid
    {
        public string Id { get; set; }
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
    public class PutSparseUnitGroup : IReturn<UnitGroup>
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public bool? SupportsConversion { get; set; }
        public UnitGroupSystemCodeType? SystemCode { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/unitgroups/{id}", "DELETE")]
    public class DeleteUnitGroupById : IReturnVoid
    {
        public string Id { get; set; }
    }

    [Route("/v1/unitgroupwithunits", "GET")]
    public class GetUnitGroupsWithUnits : IReturn<SearchResultUnitGroupWithUnits>
    {
        public string CustomId { get; set; }
        public GetUnitsSystemCodeType? SystemCode { get; set; }
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
    public class GetUnitGroupWithUnits : IReturn<UnitGroupWithUnits>
    {
        public string Id { get; set; }
    }

    [Route("/v1/unitgroupwithunits/{id}", "PUT")]
    public class PutSparseUnitGroupWithUnits : IReturn<UnitGroup>
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public bool? SupportsConversion { get; set; }
        public UnitGroupSystemCodeType? SystemCode { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    [Route("/v1/unitgroupwithunits/{id}", "DELETE")]
    public class DeleteUnitGroupWithUnitsById : IReturnVoid
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
    public class PutSparseUnit : IReturn<Unit>
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
    public class DeleteUnitById : IReturnVoid
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
        public List<Role> Roles { get; set; }
        public List<AccessGroup> AccessGroups { get; set; }
        public string Id { get; set; }
        public string CustomId { get; set; }
        public string TenantId { get; set; }
        public UserProfile UserProfile { get; set; }
        public string ProviderId { get; set; }
        public string Email { get; set; }
    }

    [Route("/v1/users/{id}", "GET")]
    public class GetUser : IReturn<User>
    {
        public string Id { get; set; }
    }

    [Route("/v1/users/{id}", "PUT")]
    public class Put : IReturn<User>
    {
        public string Id { get; set; }
        public List<Role> Roles { get; set; }
        public List<AccessGroup> AccessGroups { get; set; }
        public string CustomId { get; set; }
        public string TenantId { get; set; }
        public UserProfile UserProfile { get; set; }
        public string ProviderId { get; set; }
        public string Email { get; set; }
    }

    [Route("/v1/users/{id}", "DELETE")]
    public class DeleteUserById : IReturnVoid
    {
        public string Id { get; set; }
    }

    public class AccessGroup
    {
        public AccessGroup()
        {
            SamplingLocationGroups = new List<SamplingLocationGroupSimple>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool CanEditAllData { get; set; }
        public List<SamplingLocationGroupSimple> SamplingLocationGroups { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class Activity
    {
        public Activity()
        {
            SamplingContextTags = new List<SamplingContextTag>();
        }

        public Quantity Depth { get; set; }
        public SamplingLocation SamplingLocation { get; set; }
        public FieldVisit FieldVisit { get; set; }
        public List<SamplingContextTag> SamplingContextTags { get; set; }
        public string Id { get; set; }
        public string CustomId { get; set; }
        public ActivityType Type { get; set; }
        public string ReplicateSourceActivityId { get; set; }
        public Instant? StartTime { get; set; }
        public Instant? EndTime { get; set; }
        public string Comment { get; set; }
        public string LoggerFileName { get; set; }
        public Device Device { get; set; }
        public CollectionMethod CollectionMethod { get; set; }
        public MediumType Medium { get; set; }
        public PlannedActivity PlannedActivity { get; set; }
        public ActivityTemplate ActivityTemplate { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class ActivityRepresentation
    {
        public ActivityRepresentation()
        {
            SamplingContextTags = new List<SamplingContextTag>();
            Specimens = new List<SpecimenNestedInActivity>();
            Observations = new List<ObservationMinimal>();
        }

        public string Id { get; set; }
        public string CustomId { get; set; }
        public ActivityType Type { get; set; }
        public string ReplicateSourceActivityId { get; set; }
        public Instant? StartTime { get; set; }
        public Instant? EndTime { get; set; }
        public string Comment { get; set; }
        public string LoggerFileName { get; set; }
        public Device Device { get; set; }
        public CollectionMethod CollectionMethod { get; set; }
        public MediumType Medium { get; set; }
        public PlannedActivity PlannedActivity { get; set; }
        public Quantity Depth { get; set; }
        public SamplingLocation SamplingLocation { get; set; }
        public FieldVisit FieldVisit { get; set; }
        public List<SamplingContextTag> SamplingContextTags { get; set; }
        public List<SpecimenNestedInActivity> Specimens { get; set; }
        public List<ObservationMinimal> Observations { get; set; }
        public ActivityTemplate ActivityTemplate { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class ActivitySimple
    {
        public ActivitySimple()
        {
            SamplingContextTags = new List<SamplingContextTagSimple>();
        }

        public string Id { get; set; }
        public string CustomId { get; set; }
        public ActivityType Type { get; set; }
        public string ReplicateSourceActivityId { get; set; }
        public Instant? StartTime { get; set; }
        public Instant? EndTime { get; set; }
        public string Comment { get; set; }
        public string LoggerFileName { get; set; }
        public Device Device { get; set; }
        public CollectionMethod CollectionMethod { get; set; }
        public MediumType Medium { get; set; }
        public PlannedActivity PlannedActivity { get; set; }
        public ActivityTemplate ActivityTemplate { get; set; }
        public QuantitySimple Depth { get; set; }
        public SamplingLocationSimple SamplingLocation { get; set; }
        public List<SamplingContextTagSimple> SamplingContextTags { get; set; }
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
        public ActivityType Type { get; set; }
        public string Comment { get; set; }
        public MediumType Medium { get; set; }
        public Quantity Depth { get; set; }
        public CollectionMethod CollectionMethod { get; set; }
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
        public LabAnalysisMethod LabAnalysisMethod { get; set; }
    }

    public class AnalyticalGroupSimple
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public AnalyticalGroupType Type { get; set; }
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
        public AuditChangeType Type { get; set; }
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

        public string Id { get; set; }
        public Instant? ModificationTime { get; set; }
        public UserProfile UserProfile { get; set; }
        public OperationType Operation { get; set; }
        public List<AuditChange> AuditChanges { get; set; }
    }

    public class AuditItem
    {
        public string Id { get; set; }
        public UserProfile UserProfile { get; set; }
        public OperationType Operation { get; set; }
        public Instant? ModificationTime { get; set; }
        public object OriginalData { get; set; }
        public object NewData { get; set; }
    }

    public class CategoricalResult
    {
        public string Value { get; set; }
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
        public DetectionConditionType DetectionCondition { get; set; }
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

    public class FieldSheetImportSummary
    {
        public ImportSummaryObservation FieldResultSummary { get; set; }
        public ImportSummarySpecimen SpecimenSummary { get; set; }
    }

    public class FieldTrip
    {
        public FieldTrip()
        {
            FieldVisits = new List<FieldVisit>();
            Attachments = new List<DomainObjectAttachment>();
        }

        public string Id { get; set; }
        public string CustomId { get; set; }
        public List<FieldVisit> FieldVisits { get; set; }
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
        }

        public string Id { get; set; }
        public Instant? StartTime { get; set; }
        public Instant? EndTime { get; set; }
        public string Participants { get; set; }
        public string Notes { get; set; }
        public FieldTripSimple FieldTrip { get; set; }
        public PlanningStatusType PlanningStatus { get; set; }
        public SamplingLocation SamplingLocation { get; set; }
        public List<PlannedFieldResult> PlannedFieldResults { get; set; }
        public List<PlannedActivity> PlannedActivities { get; set; }
        public List<DomainObjectAttachment> Attachments { get; set; }
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

        public Instant? StartTime { get; set; }
        public Instant? EndTime { get; set; }
        public List<ObservedProperty> ObservedProperties { get; set; }
        public List<SamplingLocation> SamplingLocations { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
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

        public List<string> DomainObjectIds { get; set; }
        public string Id { get; set; }
        public ImportType ImportType { get; set; }
        public Instant? ImportTime { get; set; }
        public string FileName { get; set; }
        public string TimeZoneOffset { get; set; }
        public UserProfile ImportedBy { get; set; }
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
        }

        public List<string> Fields { get; set; }
        public object Errors { get; set; }
        public string RowId { get; set; }
        public string Input { get; set; }
        public ImportItemStatusType Status { get; set; }
        public object Item { get; set; }
        public object ExistingItem { get; set; }
        public List<ImportChangeItem> ItemComparison { get; set; }
    }

    public class ImportItemLabAnalysisMethod
    {
        public ImportItemLabAnalysisMethod()
        {
            Fields = new List<string>();
            ItemComparison = new List<ImportChangeItem>();
        }

        public List<string> Fields { get; set; }
        public object Errors { get; set; }
        public string RowId { get; set; }
        public string Input { get; set; }
        public ImportItemStatusType Status { get; set; }
        public LabAnalysisMethod Item { get; set; }
        public LabAnalysisMethod ExistingItem { get; set; }
        public List<ImportChangeItem> ItemComparison { get; set; }
    }

    public class ImportItemObject
    {
        public ImportItemObject()
        {
            Fields = new List<string>();
            ItemComparison = new List<ImportChangeItem>();
        }

        public List<string> Fields { get; set; }
        public object Errors { get; set; }
        public string RowId { get; set; }
        public string Input { get; set; }
        public ImportItemStatusType Status { get; set; }
        public object Item { get; set; }
        public object ExistingItem { get; set; }
        public List<ImportChangeItem> ItemComparison { get; set; }
    }

    public class ImportItemObservation
    {
        public ImportItemObservation()
        {
            Fields = new List<string>();
            ItemComparison = new List<ImportChangeItem>();
        }

        public List<string> Fields { get; set; }
        public object Errors { get; set; }
        public string RowId { get; set; }
        public string Input { get; set; }
        public ImportItemStatusType Status { get; set; }
        public Observation Item { get; set; }
        public Observation ExistingItem { get; set; }
        public List<ImportChangeItem> ItemComparison { get; set; }
    }

    public class ImportItemObservedProperty
    {
        public ImportItemObservedProperty()
        {
            Fields = new List<string>();
            ItemComparison = new List<ImportChangeItem>();
        }

        public List<string> Fields { get; set; }
        public object Errors { get; set; }
        public string RowId { get; set; }
        public string Input { get; set; }
        public ImportItemStatusType Status { get; set; }
        public ObservedProperty Item { get; set; }
        public ObservedProperty ExistingItem { get; set; }
        public List<ImportChangeItem> ItemComparison { get; set; }
    }

    public class ImportItemSamplingLocation
    {
        public ImportItemSamplingLocation()
        {
            Fields = new List<string>();
            ItemComparison = new List<ImportChangeItem>();
        }

        public List<string> Fields { get; set; }
        public object Errors { get; set; }
        public string RowId { get; set; }
        public string Input { get; set; }
        public ImportItemStatusType Status { get; set; }
        public SamplingLocation Item { get; set; }
        public SamplingLocation ExistingItem { get; set; }
        public List<ImportChangeItem> ItemComparison { get; set; }
    }

    public class ImportItemSpecimen
    {
        public ImportItemSpecimen()
        {
            Fields = new List<string>();
            ItemComparison = new List<ImportChangeItem>();
        }

        public List<string> Fields { get; set; }
        public object Errors { get; set; }
        public string RowId { get; set; }
        public string Input { get; set; }
        public ImportItemStatusType Status { get; set; }
        public Specimen Item { get; set; }
        public Specimen ExistingItem { get; set; }
        public List<ImportChangeItem> ItemComparison { get; set; }
    }

    public class ImportItemTaxon
    {
        public ImportItemTaxon()
        {
            Fields = new List<string>();
            ItemComparison = new List<ImportChangeItem>();
        }

        public List<string> Fields { get; set; }
        public object Errors { get; set; }
        public string RowId { get; set; }
        public string Input { get; set; }
        public ImportItemStatusType Status { get; set; }
        public Taxon Item { get; set; }
        public Taxon ExistingItem { get; set; }
        public List<ImportChangeItem> ItemComparison { get; set; }
    }

    public class ImportSummary
    {
        public ImportSummary()
        {
            ImportItems = new List<ImportItemObject>();
            ImportJobErrors = new List<ImportError>();
            ErrorImportItems = new List<ImportItemObject>();
            NonErrorImportItems = new List<ImportItemObject>();
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
        public List<ImportItemObject> ErrorImportItems { get; set; }
        public List<ImportItemObject> NonErrorImportItems { get; set; }
    }

    public class ImportSummaryObservation
    {
        public ImportSummaryObservation()
        {
            ImportItems = new List<ImportItemObservation>();
            ImportJobErrors = new List<ImportError>();
            ErrorImportItems = new List<ImportItemObservation>();
            NonErrorImportItems = new List<ImportItemObservation>();
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
        public List<ImportItemObservation> ErrorImportItems { get; set; }
        public List<ImportItemObservation> NonErrorImportItems { get; set; }
    }

    public class ImportSummarySpecimen
    {
        public ImportSummarySpecimen()
        {
            ImportItems = new List<ImportItemSpecimen>();
            ImportJobErrors = new List<ImportError>();
            ErrorImportItems = new List<ImportItemSpecimen>();
            NonErrorImportItems = new List<ImportItemSpecimen>();
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
        public List<ImportItemSpecimen> ErrorImportItems { get; set; }
        public List<ImportItemSpecimen> NonErrorImportItems { get; set; }
    }

    public class InputPart
    {
        public object Headers { get; set; }
        public MediaType MediaType { get; set; }
        public string BodyAsString { get; set; }
        public bool ContentTypeFromMessage { get; set; }
    }

    public class LabAnalysisMethod
    {
        public LabAnalysisMethod()
        {
            ObservedProperties = new List<ObservedProperty>();
            ImportHistoryEventSimples = new List<ImportHistoryEventSimple>();
        }

        public List<ObservedProperty> ObservedProperties { get; set; }
        public string Id { get; set; }
        public string MethodId { get; set; }
        public string Name { get; set; }
        public string Context { get; set; }
        public string Description { get; set; }
        public List<ImportHistoryEventSimple> ImportHistoryEventSimples { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class LabAnalysisMethodImportSummary
    {
        public LabAnalysisMethodImportSummary()
        {
            ImportItems = new List<ImportItemLabAnalysisMethod>();
            ImportJobErrors = new List<ImportError>();
            ErrorImportItems = new List<ImportItemLabAnalysisMethod>();
            NonErrorImportItems = new List<ImportItemLabAnalysisMethod>();
        }

        public ImportHistoryEventSimple ImportHistoryEventSimple { get; set; }
        public int SuccessCount { get; set; }
        public int SkippedCount { get; set; }
        public int ErrorCount { get; set; }
        public int NewCount { get; set; }
        public int UpdateCount { get; set; }
        public int ExpectedCount { get; set; }
        public List<ImportItemLabAnalysisMethod> ImportItems { get; set; }
        public List<ImportError> ImportJobErrors { get; set; }
        public string InvalidRowsCsvUrl { get; set; }
        public List<ImportItemLabAnalysisMethod> ErrorImportItems { get; set; }
        public List<ImportItemLabAnalysisMethod> NonErrorImportItems { get; set; }
    }

    public class LabAnalysisMethodMinimal
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class LabInstruction
    {
        public LabAnalysisMethod AnalysisMethod { get; set; }
        public string PreparationMethod { get; set; }
        public string AnalysisComment { get; set; }
        public string HoldingTime { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class LabInstructionMinimal
    {
        public LabAnalysisMethodMinimal AnalysisMethod { get; set; }
        public string PreparationMethod { get; set; }
        public string AnalysisComment { get; set; }
        public string HoldingTime { get; set; }
    }

    public class LabInstructionTemplate
    {
        public string Id { get; set; }
        public LabAnalysisMethod AnalysisMethod { get; set; }
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
        public LabAnalysisMethod AnalysisMethod { get; set; }
        public string PreparationMethod { get; set; }
        public string DilutionFactor { get; set; }
        public Instant? DateReceived { get; set; }
        public string AnalysisComment { get; set; }
        public string QualityFlag { get; set; }
        public Instant? DatePrepared { get; set; }
        public LabReport LabReport { get; set; }
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

    public class NumericResult
    {
        public Quantity Quantity { get; set; }
        public SampleFractionType SampleFraction { get; set; }
        public DeterminationType DeterminationType { get; set; }
        public DetectionConditionType DetectionCondition { get; set; }
        public Quantity MethodDetectionLevel { get; set; }
        public Quantity LowerMethodReportingLimit { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class Observation
    {
        public Observation()
        {
            ImportHistoryEventSimples = new List<ImportHistoryEventSimple>();
            ValidationWarnings = new List<RuleValidationDetails>();
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
        public MediumType Medium { get; set; }
        public string MediumSubdivision { get; set; }
        public Instant? ObservedTime { get; set; }
        public Instant? ResultTime { get; set; }
        public Quantity Depth { get; set; }
        public LabInstruction LabInstruction { get; set; }
        public LabResultDetails LabResultDetails { get; set; }
        public string Comment { get; set; }
        public FieldVisit FieldVisit { get; set; }
        public Device Device { get; set; }
        public List<ImportHistoryEventSimple> ImportHistoryEventSimples { get; set; }
        public List<RuleValidationDetails> ValidationWarnings { get; set; }
        public ResultGrade ResultGrade { get; set; }
        public ResultStatus ResultStatus { get; set; }
        public PlannedFieldResult PlannedFieldResult { get; set; }
        public Taxon RelatedTaxon { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class ObservationImportSummary
    {
        public ObservationImportSummary()
        {
            ImportItems = new List<ImportItemObservation>();
            ImportJobErrors = new List<ImportError>();
            ErrorImportItems = new List<ImportItemObservation>();
            NonErrorImportItems = new List<ImportItemObservation>();
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
        public List<ImportItemObservation> ErrorImportItems { get; set; }
        public List<ImportItemObservation> NonErrorImportItems { get; set; }
    }

    public class ObservationMinimal
    {
        public string Id { get; set; }
        public ObservedProperty ObservedProperty { get; set; }
        public SpecimenNestedInActivity Specimen { get; set; }
        public NumericResult NumericResult { get; set; }
        public CategoricalResult CategoricalResult { get; set; }
        public TaxonomicResult TaxonomicResult { get; set; }
        public ResultStatus ResultStatus { get; set; }
        public LabInstructionMinimal LabInstruction { get; set; }
        public DataClassificationType DataClassification { get; set; }
        public string Comment { get; set; }
    }

    public class ObservationStandard
    {
        public ObservedProperty ObservedProperty { get; set; }
        public Quantity ResultLowerLimit { get; set; }
        public Quantity ResultUpperLimit { get; set; }
        public string RuleText { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
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
            ErrorImportItems = new List<ImportItemObservedProperty>();
            NonErrorImportItems = new List<ImportItemObservedProperty>();
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
        public List<ImportItemObservedProperty> ErrorImportItems { get; set; }
        public List<ImportItemObservedProperty> NonErrorImportItems { get; set; }
    }

    public class Permission
    {
        public Permission()
        {
            Actions = new List<string>();
        }

        public List<string> Actions { get; set; }
        public string Id { get; set; }
        public string CustomId { get; set; }
        public string Resource { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class PlannedActivity
    {
        public string Id { get; set; }
        public ActivityTemplate ActivityTemplate { get; set; }
        public string Instruction { get; set; }
        public ActivityType ActivityType { get; set; }
        public MediumType Medium { get; set; }
        public CollectionMethod CollectionMethod { get; set; }
        public string HashForFieldsThatRequireUniqueness { get; set; }
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
        public ProjectType Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ScopeStatement { get; set; }
        public bool Approved { get; set; }
        public string ApprovalAgency { get; set; }
        public Instant? StartTime { get; set; }
        public Instant? EndTime { get; set; }
        public Filter Filter { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class Quantity
    {
        public double Value { get; set; }
        public Unit Unit { get; set; }
    }

    public class QuantitySimple
    {
        public double Value { get; set; }
        public UnitSimple Unit { get; set; }
    }

    public class ResultGrade
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public ResultGradeSystemCodeType SystemCode { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class ResultStatus
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public ResultStatusSystemCodeType SystemCode { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class Role
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public string Name { get; set; }
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

    public class SamplingContextTagSimple
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class SamplingLocation
    {
        public SamplingLocation()
        {
            ImportHistoryEventSimples = new List<ImportHistoryEventSimple>();
            Standards = new List<StandardSimple>();
            Attachments = new List<DomainObjectAttachment>();
            SamplingLocationGroups = new List<SamplingLocationGroupSimple>();
        }

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
        public List<ImportHistoryEventSimple> ImportHistoryEventSimples { get; set; }
        public List<StandardSimple> Standards { get; set; }
        public List<DomainObjectAttachment> Attachments { get; set; }
        public List<SamplingLocationGroupSimple> SamplingLocationGroups { get; set; }
        public string Id { get; set; }
        public string CustomId { get; set; }
        public string Name { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class SamplingLocationGroup
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class SamplingLocationGroupSimple
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class SamplingLocationImportSummary
    {
        public SamplingLocationImportSummary()
        {
            ImportItems = new List<ImportItemSamplingLocation>();
            ImportJobErrors = new List<ImportError>();
            ErrorImportItems = new List<ImportItemSamplingLocation>();
            NonErrorImportItems = new List<ImportItemSamplingLocation>();
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
        public List<ImportItemSamplingLocation> ErrorImportItems { get; set; }
        public List<ImportItemSamplingLocation> NonErrorImportItems { get; set; }
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

    public class SearchResultAuditItem : IPaginatedResponse<AuditItem>
    {
        public SearchResultAuditItem()
        {
            DomainObjects = new List<AuditItem>();
        }

        public int TotalCount { get; set; }
        public string Cursor { get; set; }
        public List<AuditItem> DomainObjects { get; set; }
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

    public class SearchResultFieldTrip : IPaginatedResponse<FieldTrip>
    {
        public SearchResultFieldTrip()
        {
            DomainObjects = new List<FieldTrip>();
        }

        public int TotalCount { get; set; }
        public string Cursor { get; set; }
        public List<FieldTrip> DomainObjects { get; set; }
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

    public class SearchResultLabAnalysisMethod : IPaginatedResponse<LabAnalysisMethod>
    {
        public SearchResultLabAnalysisMethod()
        {
            DomainObjects = new List<LabAnalysisMethod>();
        }

        public int TotalCount { get; set; }
        public string Cursor { get; set; }
        public List<LabAnalysisMethod> DomainObjects { get; set; }
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
            Surrogates = new List<Surrogate>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public PreservativeType Preservative { get; set; }
        public bool Filtered { get; set; }
        public string FiltrationComment { get; set; }
        public Laboratory Laboratory { get; set; }
        public ShippingContainer ShippingContainer { get; set; }
        public List<Surrogate> Surrogates { get; set; }
        public AnalyticalGroup AnalyticalGroup { get; set; }
        public Activity Activity { get; set; }
        public SpecimenTemplate TemplateCreatedFrom { get; set; }
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
            Surrogates = new List<Surrogate>();
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
        public List<Surrogate> Surrogates { get; set; }
        public AnalyticalGroup AnalyticalGroup { get; set; }
        public Activity Activity { get; set; }
        public SpecimenTemplate TemplateCreatedFrom { get; set; }
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

    public class Surrogate
    {
        public string Id { get; set; }
        public double PercentRecovered { get; set; }
        public string Comment { get; set; }
        public string ControlLimit { get; set; }
        public ObservedProperty ObservedProperty { get; set; }
        public Instant? DateAnalyzed { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class Taxon
    {
        public Taxon()
        {
            ImportHistoryEventSimples = new List<ImportHistoryEventSimple>();
        }

        public string Id { get; set; }
        public string ScientificName { get; set; }
        public string CommonName { get; set; }
        public string Level { get; set; }
        public string Source { get; set; }
        public string Comment { get; set; }
        public string ItisTsn { get; set; }
        public string ItisComment { get; set; }
        public string ItisUrl { get; set; }
        public List<ImportHistoryEventSimple> ImportHistoryEventSimples { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
    }

    public class TaxonImportSummary
    {
        public TaxonImportSummary()
        {
            ImportItems = new List<ImportItemTaxon>();
            ImportJobErrors = new List<ImportError>();
            ErrorImportItems = new List<ImportItemTaxon>();
            NonErrorImportItems = new List<ImportItemTaxon>();
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
        public List<ImportItemTaxon> ErrorImportItems { get; set; }
        public List<ImportItemTaxon> NonErrorImportItems { get; set; }
    }

    public class TaxonomicResult
    {
        public string Id { get; set; }
        public Taxon Taxon { get; set; }
        public AuditAttributes AuditAttributes { get; set; }
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

    public class UnitSimple
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public string Name { get; set; }
        public double BaseMultiplier { get; set; }
        public double BaseOffset { get; set; }
    }

    public class User
    {
        public User()
        {
            Roles = new List<Role>();
            AccessGroups = new List<AccessGroup>();
        }

        public List<Role> Roles { get; set; }
        public List<AccessGroup> AccessGroups { get; set; }
        public string Id { get; set; }
        public string CustomId { get; set; }
        public string TenantId { get; set; }
        public UserProfile UserProfile { get; set; }
        public string ProviderId { get; set; }
        public string Email { get; set; }
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

    public enum ActivityType
    {
        SAMPLE_INTEGRATED_VERTICAL_PROFILE,
        SAMPLE_ROUTINE,
        QC_SAMPLE_REPLICATE,
        QC_TRIP_BLANK,
        FIELD_SURVEY,
        NONE
    }

    public enum AddressType
    {
        LOCATION,
        MAILING,
        SHIPPING
    }

    public enum AnalysisType
    {
        BIOLOGICAL,
        CHEMICAL,
        PHYSICAL
    }

    public enum AnalyticalGroupType
    {
        KNOWN,
        UNKNOWN
    }

    public enum AuditChangeType
    {
        Observation,
        SamplingLocation,
        FieldVisit,
        Activity,
        Specimen,
        Laboratory,
        LabReport,
        LabAnalysisMethod,
        CollectionMethod,
        ObservedProperty,
        Taxon,
        Unit,
        LabInstruction,
        LabResultDetail,
        NumericResult,
        CategoricalResult,
        TaxonomicResult,
        ResultGrade,
        LocationType,
        DomainDateTime,
        ResultStatus,
        None
    }

    public enum DataClassificationType
    {
        LAB,
        FIELD_RESULT,
        FIELD_SURVEY,
        VERTICAL_PROFILE,
        CALCULATED
    }

    public enum DetectionConditionType
    {
        NOT_REPORTED,
        NOT_DETECTED
    }

    public enum DeterminationType
    {
        ACTUAL,
        BLANK_CORRECTED_CALCULATED,
        CALCULATED,
        CONTROL_ADJUSTED,
        ESTIMATED
    }

    public enum FormatType
    {
        CSV,
        WQX,
        CROSSTAB_CSV
    }

    public enum GetUnitGroupsSystemCodeType
    {
        LENGTH
    }

    public enum GetUnitsSystemCodeType
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

    public enum ImportType
    {
        OBSERVATION_CSV,
        OBSERVATION_LABREPORT,
        SAMPLINGLOCATION_CSV,
        OBSERVED_PROPERTIES_CSV,
        LAB_ANALYSIS_METHODS_CSV,
        TAXON_CSV,
        SAMPLING_PLAN
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
        SAMPLE_REPLICATE,
        TRIP_BLANK
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
        TAXON
    }

    public enum SampleFractionType
    {
        DISSOLVED,
        TOTAL
    }

    public enum UnitGroupSystemCodeType
    {
        LENGTH
    }

    public enum UnitGroupWithUnitsSystemCodeType
    {
        LENGTH
    }
}
