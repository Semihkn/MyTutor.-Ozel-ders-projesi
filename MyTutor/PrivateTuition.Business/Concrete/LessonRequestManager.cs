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
    public class LessonRequestManager : ILessonRequestService
    {
        private ILessonRequestRepository _lessonRequestRepository;

        public LessonRequestManager(ILessonRequestRepository lessonRequestRepository)
        {
            _lessonRequestRepository = lessonRequestRepository;
        }

        public async Task CreateAsync(LessonRequest lessonRequest)
        {
           await _lessonRequestRepository.CreateAsync(lessonRequest);
        }

        public void Delete(LessonRequest lessonRequest)
        {
            _lessonRequestRepository.Delete(lessonRequest);
        }

        public async Task<List<LessonRequest>> GetAllAsync(Expression<Func<LessonRequest, bool>> expression)
        {
            return await _lessonRequestRepository.GetAllAsync(expression);
        }

        public async Task<List<LessonRequest>> GetAllLessonRequestsAsync()
        {
            return await _lessonRequestRepository.GetAllLessonRequestsAsync();
        }

        public async Task<LessonRequest> GetByIdAsync(int id)
        {
            return await _lessonRequestRepository.GetByIdAsync(id);
        }

        public async Task<int> GetCountByTeacherAsync(string teacher)
        {
            return await _lessonRequestRepository.GetCountByTeacherAsync(teacher);
        }

        public async Task<List<LessonRequest>> GetLessonRequestByTeacherAsync(string teacher, int page, int pageSize)
        {
            return await _lessonRequestRepository.GetLessonRequestByTeacherAsync(teacher, page, pageSize);
        }

        public async Task<LessonRequest> GetLessonRequestDetailsAsync(string url)
        {
            return await _lessonRequestRepository.GetLessonRequestDetailsAsync(url);
        }

        public void IsActive(LessonRequest lessonRequest)
        {
           _lessonRequestRepository.IsActive(lessonRequest);
        }

        public void Update(LessonRequest lessonRequest)
        {
            _lessonRequestRepository.Update(lessonRequest);
        }
    }
}
