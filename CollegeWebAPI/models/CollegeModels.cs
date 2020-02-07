using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeWebAPI.models
{ 
    public class College
    {
        public int Id { get; set; }
        public string Name  { get; set; }
        public string Address { get; set; }
        public List<Student> Students { get; set; }
        public List<Department> Departments { get; set; }
    }


    public class Student
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime Dob { get; set; }
        public Department Department { get; set; }
        public List<MarkModule> MarkModules { get; set; }
    }

    public class MarkModule
    {
        public int Id { get; set; }
        public Module Module { get; set; }
        public List<AchievedMark> AchievedMarks { get; set; }
    }

    public class Department
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Location { get; set; }
    }

    public class Module
    { 
        public int Id { get; set; }
        public String Name { get; set; }
        public Department Department { get; set; }
        public String AssignedTutor { get; set; }
        public ModuleType ModuleType { get; set; }
    }

    public class AchievedMark
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Mark { get; set; }

    }

    public enum ModuleType
    {
      INVALID,  MANDATORY, OPTIONAL, SPECIAL, 
    }


    public class CollegeDbContent : DbContext
    {
         
        private readonly string s1 = "Server =localhost; Database =college; Integrated Security=SSPI;Persist Security Info=False;";
         
        public DbSet<College> Colleges { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<MarkModule> MarkModules { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<AchievedMark> AchievedMarks { get; set; }

        public DbSet<Module> Modules { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(s1);
        }

    }



}
