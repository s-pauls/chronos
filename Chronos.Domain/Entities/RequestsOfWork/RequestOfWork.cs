using System;
using Chronos.Domain.Entities.Products;
using Chronos.Domain.Enums;

namespace Chronos.Domain.Entities.RequestsOfWork
{
    public class RequestOfWork
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public string NumberPrefix { get; set; }
        public string NumberSuffix { get; set; }
        public string FullNumber => $"{NumberPrefix}{Number}{NumberSuffix}";

        public Guid? DesiredReleaseId { get; set; }

        public int AdoId { get; set; }
        public int? Priority { get; set; }
        public RequestOfWorkStatus Status { get; set; }
        public string StatusName { get; set; }
        public string ProductId { get; set; }
        public DateTime? CSIEstimateETA { get; set; }
        public DateTime? WEXEstimateETA { get; set; }
        public string SkypeGroupUrl { get; set; }
        public string DocumentUrl { get; set; }

        public Release Release { get; set; }

        public Product Product { get; set; }
    }
}
