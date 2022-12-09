using PrivateTuition.Business.Abstract;
using PrivateTuition.Data.Abstract;
using PrivateTuition.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PrivateTuition.Business.Concrete
{
    public class SubjectManager : ISubjectService
    {
        private ISubjectRepository _subjectRepository;

        public SubjectManager(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public async Task CreateAsync(Subject subject)
        {
           await _subjectRepository.CreateAsync(subject);
        }

        public async Task CreateAsync(Subject subject, int[] categoryIds)
        {
            await _subjectRepository.CreateAsync(subject, categoryIds);
        }

        public void Delete(Subject subject)
        {
           _subjectRepository.Delete(subject);
        }

        public async Task<List<Subject>> GetAllAsync(Expression<Func<Subject, bool>> expression)
        {
            return await _subjectRepository.GetAllAsync(expression);
        }

        public async Task<List<Category>> GetAllSubjectsAsync(bool isDeleted)
        {
           return await _subjectRepository.GetAllSubjectsAsync(isDeleted);
        }

        public async Task<Subject> GetByIdAsync(int id)
        {
            return await _subjectRepository.GetByIdAsync(id);
        }   

        public async Task<Subject> GetSubejctWithCategoryAsync(int id)
        {
            return await _subjectRepository.GetSubejctWithCategoryAsync(id);    
        }

        public async Task<List<Subject>> GetSubjectsByCategory(int id)
        {
            return await _subjectRepository.GetSubjectsByCategoryAsync(id);
        }

        public async Task<List<Subject>> GetSubjectsByCategoryInPageAsync(string category, int page, int pageSize)
        {
           return await _subjectRepository.GetSubjectsByCategoryInPageAsync(category, page, pageSize);
        }

        public async Task<List<Category>> GetSubjectWithShowCardsAsync(int id)
        {
            return await _subjectRepository.GetSubjectWithShowCardsAsync(id);
        }

        public void IsDelete(Subject subject)
        {
            _subjectRepository.IsDelete(subject);
        }

        public void Update(Subject subject)
        {
           _subjectRepository.Update(subject);
        }

        public async Task UpdateAsync(Subject subject, int[] categoryIds)
        {
             await _subjectRepository.UpdateAsync(subject, categoryIds);
        }
    }
}
