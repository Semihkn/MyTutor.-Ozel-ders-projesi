using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using PrivateTuition.Business.Abstract;
using PrivateTuition.Data.Abstract;
using PrivateTuition.Data.Migrations;
using PrivateTuition.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PrivateTuition.Business.Concrete
{
    public class TeacherManager : ITeacherService
    {
        private ITeacherRepository _teacherRepository;

        public TeacherManager(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task CreateAsync(Teacher teacher)
        {
            await _teacherRepository.CreateAsync(teacher);

        }

        public void Delete(Teacher teacher)
        {
             _teacherRepository.Delete(teacher);
        }

        public async Task<List<Teacher>> GetAllAsync(Expression<Func<Teacher, bool>> expression)
        {
           return await _teacherRepository.GetAllAsync(expression);

        }

        public async Task<List<Teacher>> GetAllTeachersAsync()
        {
            return await _teacherRepository.GetAllTeachersAsync();
        }

        public async Task<Teacher> GetByIdAsync(int id)
        {
            return await _teacherRepository.GetByIdAsync(id);
        }

        public async Task<int> GetTeachersCountByCategoryAsync(string category)
        {
            return await _teacherRepository.GetTeachersCountByCategoryAsync(category);
        }

        public async Task<Teacher> GetTeacherDetailsAsync(string url)
        {
            return await _teacherRepository.GetTeacherDetailsAsync(url);
        }

        public async Task<List<Teacher>> GetTeachersByCategoryAsync(string category, int page, int pageSize)
        {
           return await _teacherRepository.GetTeachersByCategoryAsync(category, page, pageSize);
        }

        public void Update(Teacher teacher)
        {
            _teacherRepository.Update(teacher);
        }

        public async Task<Teacher> FindTeacherByMailAsync(string mail)
        {
            return await _teacherRepository.FindTeacherByMailAsync(mail);
        }
    }
}
