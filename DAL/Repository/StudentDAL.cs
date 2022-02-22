using DAL.IRepository;
using Microsoft.EntityFrameworkCore;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class StudentDAL : IStudent
    {
        public readonly DatabaseContext Context;

        public StudentDAL(DatabaseContext _Context)
        {
            Context = _Context;
        }

        public async Task<int> AddorUpdate(Student student)
        {
            int result = 0;
            try
            {
                
                    if (student.Id == 0)
                    {
                    Student st = Context.tbl_Student.Where(x => x.Email == student.Email).FirstOrDefault();

                    if (st == null)
                    {
                        //student.Status = true;
                        Context.Add(student);
                        await Context.SaveChangesAsync();
                        result = 1;
                    }
                    else
                        result = 3;
                    }
                    else
                     {
                        var data =  Context.tbl_Student.Where(x => x.Id == student.Id).FirstOrDefault();
                        if (data != null)
                        {
                            data.Name = student.Name;
                            data.Address = student.Address;
                            data.Age = student.Age;
                            data.Collegename = student.Collegename;
                            data.Email = student.Email;
                            data.Role = student.Role;
                            data.Password = student.Password;
                        student.Status = student.Status;
                        Context.Entry(data).State = EntityState.Modified;
                           

                            await Context.SaveChangesAsync();
                            result = 2;
                        }else 
                            result = 4;
                    }

               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public async Task<int> DeleteStudent(int? id)
        {
            int result = 0;
            if (id > 0)
            {
                var studentbyid = Context.tbl_Student.Where(x => x.Id == id).FirstOrDefault();
                if (studentbyid != null)
                {
                    //Context.Entry(studentbyid).State = EntityState.Deleted;
                    //result = await Context.SaveChangesAsync();
                    studentbyid.Status = false;
                    Context.Update(studentbyid);
                    result = await Context.SaveChangesAsync();
                }
            }
            return result;


        }

        public async Task<Student> GetStudentId(int id)
        {
            var data = await Context.tbl_Student.Where(x => x.Id == id).FirstOrDefaultAsync();
            return data;
        }


        public async Task<List<Student>> GetStudent(int? userId)
        {
            List<Student> lst = new List<Student>();
            if (userId == null)
            {
                lst = await Context.tbl_Student.Where(s =>s.Status==true).ToListAsync();
            }
            else
            {
                //var studentList = await Context.tbl_Student.Where(s => s.Status == true).ToListAsync();
                ////    return View(studentList);
                ////}

                lst = await Context.tbl_Student.Where(x => x.Id == userId).ToListAsync();

            }

            return lst;
        }
    }
}
