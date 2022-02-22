using MODEL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepository
{
    public interface IStudent
    {
      
        public Task<int> AddorUpdate(Student student);
        public Task<int> DeleteStudent(int? id);
        public  Task<List<Student>> GetStudent(int? userId);
        Task<Student> GetStudentId(int id);


    }
}
