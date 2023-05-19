namespace SmartSpend.Persistence.DynamoDb.Entities
{
    public class Category : DynamoBaseEntity
    {
        protected override string EntityName => nameof(Category);
        public string Description { get; set; }
    }
}
