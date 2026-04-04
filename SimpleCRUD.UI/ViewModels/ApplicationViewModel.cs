namespace SimpleCRUD.UI.ViewModels
{
    public class ApplicationViewModel
    {
        public Guid ApplicationId { get; set; }
        public string ApplicationName { get; set; } = null!;
        public string ApplicationDescription { get; set; } = null!;
    }
}
