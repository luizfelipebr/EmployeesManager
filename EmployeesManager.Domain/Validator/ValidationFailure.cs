namespace EmployeesManager.Domain.Validator
{
    public class ValidationFailure
    {
        public string Codigo { get; set; }
        public string Field { get; set; }
        public string Message { get; set; }
    }
}
