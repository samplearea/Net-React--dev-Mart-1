// Business Katmanı
using DataAccess;
using Entities;
using System.Collections.Generic;

namespace Business
{
    public class ProgrammingLanguageManager
    {
        private readonly IRepository<ProgrammingLanguage> _repository;

        public ProgrammingLanguageManager(IRepository<ProgrammingLanguage> repository)
        {
            _repository = repository;
        }

        public void AddLanguage(ProgrammingLanguage language) => _repository.Add(language);
        public void UpdateLanguage(ProgrammingLanguage language) => _repository.Update(language);
        public void DeleteLanguage(int id) => _repository.Delete(id);
        public List<ProgrammingLanguage> GetLanguages() => _repository.GetAll();
    }

    public class TechnologyManager
    {
        private readonly IRepository<Technology> _repository;

        public TechnologyManager(IRepository<Technology> repository)
        {
            _repository = repository;
        }

        public void AddTechnology(Technology tech) => _repository.Add(tech);
        public void UpdateTechnology(Technology tech) => _repository.Update(tech);
        public void DeleteTechnology(int id) => _repository.Delete(id);
        public List<Technology> GetTechnologies() => _repository.GetAll();
    }
}
