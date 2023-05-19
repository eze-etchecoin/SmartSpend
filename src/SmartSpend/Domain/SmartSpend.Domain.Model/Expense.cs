using SmartSpend.Domain.Core.Entities;

namespace SmartSpend.Domain.Model
{
    public class Expense : BaseEntity
    {
        public string Description { get; set; }
        public decimal Total { get; set; }
        public Category Category { get; set; }
    }
}