using System;

namespace Chronos.Domain.Entities.Products
{
    public class Product
    {
        public Guid Uid { get; set; }
        public string Name { get; set; }
        public Guid ProjectUid { get; set; }
        public string ProjectName { get; set; }
        public string ProjectAdoName { get; set; }
        public bool Enabled { get; set; }
    }
}
