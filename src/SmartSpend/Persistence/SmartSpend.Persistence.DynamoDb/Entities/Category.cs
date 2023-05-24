namespace SmartSpend.Persistence.DynamoDb.Entities
{
    public class Category : DynamoBaseEntity
    {
        private string _entityName;
        
        public string Description { get; set; }
        protected override string EntityName 
        { 
            get => nameof(Category); 
            set => _entityName = value;
        }
    }
}
