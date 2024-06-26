namespace ASP.NET_CORE_WEB_API_CRUD_OPERATION.DTOs.Category
{
    public class UpdateCategoryDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int CategoryDiscount { get; set; }
    }
}
