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
    public class StudentManager : IStudentService
    {
        private IStudentRepository _studentRepository;

        public StudentManager(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task CreateAsync(Student student)
        {
            await _studentRepository.CreateAsync(student);
        }

        public void Delete(Student student)
        {
            _studentRepository.Delete(student);
        }

        public async Task<Student> FindStudentByMailAsync(string mail)
        {
            return await _studentRepository.FindStudentByMailAsync(mail);
        }

        public async Task<List<Student>> GetAllAsync(Expression<Func<Student, bool>> expression)
        {
            return await _studentRepository.GetAllAsync(expression);
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _studentRepository.GetByIdAsync(id);
        }

        public async Task<Student> GetStudentDetailsAsync(string url)
        {
           return await _studentRepository.GetStudentDetailsAsync(url);
        }

        public void Update(Student student)
        {
            _studentRepository.Update(student);
        }
    }
}
