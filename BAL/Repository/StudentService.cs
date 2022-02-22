using BAL.IRepository;
using DAL.IRepository;
using DAL.Repository;
using MODEL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Repository
{
    public class StudentService : IStudentService
    {
        private readonly IStudent _student;

        public StudentService(IStudent student) 
        {
            _student = student;
        }

        public async Task<int> AddorUpdate(Student student)
        {
            return await _student.AddorUpdate(student);
        }
        public  async Task<int> DeleteStudent(int? id)
        {
           return await _student.DeleteStudent(id);
        }

        public async Task<List<Student>> GetStudent(int? userId)
        {
            return await _student.GetStudent(userId);
        }

        public async Task<Student> GetStudentId(int id)
        {
            return await _student.GetStudentId(id);
        }
    }
}
