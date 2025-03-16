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

// Data Access Katmanı
namespace DataAccess
{
    using Entities;
    using System.Collections.Generic;
    using System.Linq;

    public interface IRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        List<T> GetAll();
        T GetById(int id);
    }

    public class InMemoryProgrammingLanguageRepository : IRepository<ProgrammingLanguage>
    {
        private List<ProgrammingLanguage> _languages = new List<ProgrammingLanguage>();

        public void Add(ProgrammingLanguage entity) => _languages.Add(entity);
        public void Update(ProgrammingLanguage entity)
        {
            var lang = _languages.FirstOrDefault(l => l.Id == entity.Id);
            if (lang != null) lang.Name = entity.Name;
        }
        public void Delete(int id) => _languages.RemoveAll(l => l.Id == id);
        public List<ProgrammingLanguage> GetAll() => _languages;
        public ProgrammingLanguage GetById(int id) => _languages.FirstOrDefault(l => l.Id == id);
    }

    public class InMemoryTechnologyRepository : IRepository<Technology>
    {
        private List<Technology> _technologies = new List<Technology>();

        public void Add(Technology entity) => _technologies.Add(entity);
        public void Update(Technology entity)
        {
            var tech = _technologies.FirstOrDefault(t => t.Id == entity.Id);
            if (tech != null) { tech.Name = entity.Name; tech.ProgrammingLanguage = entity.ProgrammingLanguage; }
        }
        public void Delete(int id) => _technologies.RemoveAll(t => t.Id == id);
        public List<Technology> GetAll() => _technologies;
        public Technology GetById(int id) => _technologies.FirstOrDefault(t => t.Id == id);
    }
}

// Business Katmanı
namespace Business
{
    using DataAccess;
    using Entities;
    using System.Collections.Generic;

    public class ProgrammingLanguageManager
    {
        private readonly IRepository<ProgrammingLanguage> _repository;
        public ProgrammingLanguageManager(IRepository<ProgrammingLanguage> repository) => _repository = repository;

        public void AddLanguage(ProgrammingLanguage language) => _repository.Add(language);
        public void UpdateLanguage(ProgrammingLanguage language) => _repository.Update(language);
        public void DeleteLanguage(int id) => _repository.Delete(id);
        public List<ProgrammingLanguage> GetLanguages() => _repository.GetAll();
    }

    public class TechnologyManager
    {
        private readonly IRepository<Technology> _repository;
        public TechnologyManager(IRepository<Technology> repository) => _repository = repository;

        public void AddTechnology(Technology tech) => _repository.Add(tech);
        public void UpdateTechnology(Technology tech) => _repository.Update(tech);
        public void DeleteTechnology(int id) => _repository.Delete(id);
        public List<Technology> GetTechnologies() => _repository.GetAll();
    }
}

// Presentation Katmanı (Main Program)
using System;
using Business;
using DataAccess;
using Entities;

class Program
{
    static void Main()
    {
        var languageRepo = new InMemoryProgrammingLanguageRepository();
        var techRepo = new InMemoryTechnologyRepository();

        var languageManager = new ProgrammingLanguageManager(languageRepo);
        var techManager = new TechnologyManager(techRepo);

        while (true)
        {
            Console.WriteLine("1. Programlama Dili Ekle");
            Console.WriteLine("2. Teknoloji Ekle");
            Console.WriteLine("3. Programlama Dillerini Listele");
            Console.WriteLine("4. Teknolojileri Listele");
            Console.WriteLine("5. Çıkış");
            Console.Write("Seçiminiz: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Dil Adı: ");
                    languageManager.AddLanguage(new ProgrammingLanguage { Id = new Random().Next(1, 1000), Name = Console.ReadLine() });
                    break;
                case "2":
                    Console.Write("Teknoloji Adı: ");
                    string techName = Console.ReadLine();
                    Console.Write("Bağlı Olduğu Dil: ");
                    string lang = Console.ReadLine();
                    techManager.AddTechnology(new Technology { Id = new Random().Next(1, 1000), Name = techName, ProgrammingLanguage = lang });
                    break;
                case "3":
                    foreach (var langItem in languageManager.GetLanguages())
                        Console.WriteLine($"{langItem.Id} - {langItem.Name}");
                    break;
                case "4":
                    foreach (var techItem in techManager.GetTechnologies())
                        Console.WriteLine($"{techItem.Id} - {techItem.Name} ({techItem.ProgrammingLanguage})");
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Geçersiz seçim!");
                    break;
            }
        }
    }
}
