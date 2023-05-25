namespace SmartSpend.Persistence.DynamoDb.Entities
{
    public class Category : DynamoBaseEntity
    {
        private string _entityName;
        private string _parentEntityName;
        
        public string Description { get; set; }
        protected override string EntityName 
        { 
            get => nameof(Category); 
            set => _entityName = value;
        }
        protected override string ParentEntityName 
        { 
            get => nameof(Category); 
            set => _parentEntityName = value;
        }
    }
}
