namespace SmartSpend.Shared
{
    public class CategoryDTO
    {
        public CategoryDTO()
        {
            Description = "";
        }

        public Guid? Id { get; set; }
        public string Description { get; set; }
    }
}
