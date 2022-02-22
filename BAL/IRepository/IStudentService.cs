using MODEL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IRepository
{
    public   interface IStudentService
    {

        public Task<List<Student>> GetStudent(int? userId);
        public Task<int> AddorUpdate(Student student);
        public Task<int> DeleteStudent(int? id);
        Task<Student> GetStudentId(int id);

    }
}
