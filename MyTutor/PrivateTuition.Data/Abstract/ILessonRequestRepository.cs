using PrivateTuition.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PrivateTuition.Data.Abstract
{
    public interface ILessonRequestRepository : IRepository<LessonRequest>
    {
        Task<List<LessonRequest>> GetAllLessonRequestsAsync();
        Task<LessonRequest> GetLessonRequestDetailsAsync(string url);
        Task<int> GetCountByTeacherAsync(string teacher);
        Task<List<LessonRequest>> GetLessonRequestByTeacherAsync(string teacher, int page, int pageSize);
        void IsActive(LessonRequest lessonRequest);

    }
}
