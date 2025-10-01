namespace PizzaProject.ViewModels.UI.Register
{
    public class RegisterVM
    {
        public string FullName { get; set; }
        public string UserName { get; set; }   // Identity üçün vacibdir
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
