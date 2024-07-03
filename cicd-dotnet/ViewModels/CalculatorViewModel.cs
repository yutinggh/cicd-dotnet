namespace cicd_dotnet.ViewModels
{
    public class CalculatorViewModel
    {
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public string Operation { get; set; } = "Add"; 
        public string Result { get; set; } = string.Empty;
    }
}
