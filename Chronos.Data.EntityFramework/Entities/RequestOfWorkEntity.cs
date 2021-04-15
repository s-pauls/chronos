using System;
using Chronos.Domain.Enums;

namespace Chronos.Data.EntityFramework.Entities
{
    public abstract class RequestOfWorkEntity
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public string NumberPrefix { get; set; }
        public string NumberSuffix { get; set; }
        public int? Priority { get; set; }
        public RequestOfWorkStatus Status { get; set; }
        public int AdoId { get; set; }
        public Guid? DesiredReleaseId { get; set; }
        public DateTime? CSIEstimateETA { get; set; }
        public DateTime? WEXEstimateETA { get; set; }
        public string SkypeGroupUrl { get; set; }
        public string DocumentUrl { get; set; }
        public FeatureBlankEntity FeatureBlank { get; set; }
    }
}
