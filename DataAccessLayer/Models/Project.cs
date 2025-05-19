// Portfolio.DataAccessLayer/Models/Project.cs
namespace Portfolio.DataAccessLayer.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string ProjectUrl { get; set; } = string.Empty;
        public string GithubUrl { get; set; } = string.Empty;
        public string TechStack { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}