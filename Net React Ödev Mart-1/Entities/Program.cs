// Entities Katmanı
namespace Entities
{
    public class ProgrammingLanguage
    {
        public int Id { get; set; }
        public string Name { get; set; }  // Örn: C#, Java, Python
    }

    public class Technology
    {
        public int Id { get; set; }
        public string Name { get; set; }  // Örn: ASP.NET Core
        public string ProgrammingLanguage { get; set; }  // Örn: C#
    }
}
