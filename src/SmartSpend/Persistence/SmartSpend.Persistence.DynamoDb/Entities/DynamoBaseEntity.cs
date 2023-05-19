using Amazon.DynamoDBv2.DataModel;

namespace SmartSpend.Persistence.DynamoDb.Entities
{
    public abstract class DynamoBaseEntity
    {
        private string _globalIdentifier;
        //private string _createdOn;

        public DynamoBaseEntity()
        {
            CreatedOn = DateTimeOffset.Now;
        }

        protected abstract string EntityName { get; }

        [DynamoDBHashKey]
        public string GlobalIdentifier 
        { 
            get => _globalIdentifier;
            set => _globalIdentifier = $"{EntityName}#{Id}";
        }

        public int Id { get; set; }

        [DynamoDBRangeKey]
        public DateTimeOffset CreatedOn { get; set; }
        //{ 
        //    get => DateTimeOffset.Parse(_createdOn); 
        //    set => _createdOn = value.ToString("u"); 
        //}
    }
}