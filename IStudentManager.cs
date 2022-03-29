using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApplication
{
    interface IStudentManager
    {

        public Student GetStudent(string regNo);

        public Student RegisterStudent(string firstName, string lastName, string email, string phoneNumber, DateTime dateOfBirth, int gender, string selectedSchool, string selectedCourse);

        public bool GetAdmissionStatus(string regNo);

        public string AdmitStudentByRegNo(string regNo);

        public Student[] GetStudentsByCourse(string course);

        public string AdmitStudentsByCourse(string course);


    }
}
