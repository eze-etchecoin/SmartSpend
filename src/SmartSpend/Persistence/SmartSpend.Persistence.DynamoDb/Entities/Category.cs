namespace SmartSpend.Persistence.DynamoDb.Entities
{
    public class Category : DynamoBaseEntity
    {
        public string Description { get; set; }
        protected override string EntityName 
        { 
            get => nameof(Category); 
            set => throw new NotImplementedException();
        }
    }
}
