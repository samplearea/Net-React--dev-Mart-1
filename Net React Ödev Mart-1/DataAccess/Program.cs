// DataAccess Katmanı
using Entities;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
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
            if (tech != null)
            {
                tech.Name = entity.Name;
                tech.ProgrammingLanguage = entity.ProgrammingLanguage;
            }
        }
        public void Delete(int id) => _technologies.RemoveAll(t => t.Id == id);
        public List<Technology> GetAll() => _technologies;
        public Technology GetById(int id) => _technologies.FirstOrDefault(t => t.Id == id);
    }
}
