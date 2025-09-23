namespace PizzaProject.Models
{
    public class Chef : BaseEntity
    {
        public string FullName { get; set; }   
        public string Position { get; set; }   
        public string ImageUrl { get; set; }   
        public string Description { get; set; } 
    }
}
