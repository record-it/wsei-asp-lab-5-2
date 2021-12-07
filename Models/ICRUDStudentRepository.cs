using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_5_2.Models
{
    public interface ICRUDStudentRepository
    {
        Student Add(Student student);

        Student Update(Student student);

        void Delete(Student student);

        Student FindById(int id);

        IList<Student> FindPage(int page, int size);
    }

    public class EFCRUDStudentRepository : ICRUDStudentRepository
    {
        private ApplicationDbContext context;

        public EFCRUDStudentRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Student Add(Student student)
        {
            EntityEntry<Student> entityEntry = context.Students.Add(student);
            context.SaveChanges();
            return entityEntry.Entity;

        }

        public void Delete(Student student)
        {
            context.Students.Remove(student);
            context.SaveChanges();
        }

        public Student FindById(int id)
        {
            return context.Students.Find(id);

        }

        public IList<Student> FindPage(int page, int size)
        {
            return (from student in context.Students orderby student.LastName select student)
                .Skip(page * size)
                .Take(size)
                .ToList();
        }

        public Student Update(Student student)
        {
            EntityEntry<Student> entityEntry = context.Students.Update(student);
            context.SaveChanges();
            return entityEntry.Entity;
        }
    }
}
