namespace SimpleCRUD.UI.Models
{
    public class TableViewModel
    {
        public string Title { get; set; } = string.Empty;
        public List<string> Headers { get; set; } = new();
        public List<List<string>> Rows { get; set; } = new();
    }
}
