using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSpend.Persistence.DynamoDb.Entities
{
    public class Expense : DynamoBaseEntity
    {
        private string _entityName;
        private string _parentEntityName;

        protected override string EntityName 
        { 
            get => nameof(Expense); 
            set => _entityName = value;
        }

        protected override string ParentEntityName 
        { 
            get => nameof(Expense); 
            set => _parentEntityName = value; 
        }

        public string Description { get; set; }
        public decimal Total { get; set; }
        public string CategoryId { get; set; }
    }
}
