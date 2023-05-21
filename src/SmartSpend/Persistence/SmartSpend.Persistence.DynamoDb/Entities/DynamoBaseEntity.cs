using Amazon.DynamoDBv2.DataModel;

namespace SmartSpend.Persistence.DynamoDb.Entities
{
    [DynamoDBTable("SmartSpend_Data")]
    public abstract class DynamoBaseEntity
    {
        private string _globalIdentifier;
        private string _id;

        public DynamoBaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedOn = DateTimeOffset.Now.ToString("u");
        }

        protected abstract string EntityName { get; }

        [DynamoDBHashKey]
        public string GlobalIdentifier 
        { 
            get => _globalIdentifier;
            set => _globalIdentifier = $"{EntityName}#{Id}";
        }

        public string CreatedOn { get; internal set; }

        public Guid Id 
        { 
            get => Guid.Parse(_id); 
            set => _id = value.ToString(); 
        }
        
    }
}