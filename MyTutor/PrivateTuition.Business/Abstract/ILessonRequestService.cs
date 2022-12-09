using PrivateTuition.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PrivateTuition.Business.Abstract
{
    public interface ILessonRequestService
    {
        #region Generics
        Task<LessonRequest> GetByIdAsync(int id);
        Task<List<LessonRequest>> GetAllAsync(Expression<Func<LessonRequest, bool>> expression);
        Task CreateAsync(LessonRequest lessonRequest);
        void Update(LessonRequest lessonRequest);
        void Delete(LessonRequest lessonRequest);
        #endregion

        #region LessonRequest
        Task<List<LessonRequest>> GetAllLessonRequestsAsync();
        Task<LessonRequest> GetLessonRequestDetailsAsync(string url);
        Task<int> GetCountByTeacherAsync(string teacher);
        Task<List<LessonRequest>> GetLessonRequestByTeacherAsync(string teacher, int page, int pageSize);
        void IsActive(LessonRequest lessonRequest);
        #endregion

    }
}
