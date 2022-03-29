using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApplication
{
     class StudentManager : IStudentManager
    {
        Random random = new Random();
        private Student[] _students = new Student[100];
        private int _noOfStudents = 0;

        public StudentManager()
        {
            Student student = new Student(GenerateRegNo(), "Roqeeb", "Rauf", "12", "", Gender.Male, DateTime.Now, "physics", "FUNAAB");
            Console.WriteLine("Roqeeb reg number is:" + student.GetRegNo());
            _students[_noOfStudents] = student;
            _noOfStudents++;

            student = new Student(GenerateRegNo(), "Shefiq", "Adeleye", "12", "", Gender.Male, DateTime.Now, "physics", "OAU");
            Console.WriteLine("Shefiq reg number is:" + student.GetRegNo());
            _students[_noOfStudents] = student;
            _noOfStudents++;

            student = new Student(GenerateRegNo(), "Kemi", "Idris", "12", "", Gender.Male, DateTime.Now, "chemistry", "OAU");
            Console.WriteLine("Kemi reg number is:" + student.GetRegNo());
            _students[_noOfStudents] = student;
            _noOfStudents++;

        }

        public string AdmitStudentByRegNo(string regNo)
        {
            Student student = GetStudent(regNo);

            if(student.GetIsAdmitted() == true)
            {
                return "Student is already admitted";
            }

            student.SetIsAdmitted(true);

            return $"{student.GetFullName()} is admitted succesfully to {student.GetSelectedSchool()}";
        }

        public string AdmitStudentsByCourse(string course)
        {
            string response = "";
            Student[] students = GetStudentsByCourse(course);

            if(students.Length == 0)
            {
                return "No student has chosen this course";
            }

            for(int i = 0; i < students.Length; i++)
            {
                if(students[i].GetIsAdmitted() == true)
                {
                    response += $"{i + 1}. {students[i].GetFullName()} Has already been admitted\n";
                }
                else
                {
                    students[i].SetIsAdmitted(true);
                    response += $"{i + 1}. {students[i].GetFullName()} Has been admitted successfully to {students[i].GetSelectedSchool()}\n";
                }
            }

            return response;


        }

        public string GenerateRegNo()
        {
            char c1 = (char)('A' + random.Next(0, 26));
            char c2 = (char)('A' + random.Next(0, 26));

            string number = random.Next(1, 10000).ToString("0000");

            return $"{c1}{c2}{number}";
        }

        public bool GetAdmissionStatus(string regNo)
        {
            Student student = GetStudent(regNo);

            if (student == null)
            {
                return false;
            }
            else
            {
                return student.GetIsAdmitted();
            }
        }

        public Student GetStudent(string regNo)
        {

            for(int i =0; i< _noOfStudents; i++)
            {
                if(_students[i].GetRegNo() == regNo)
                {
                    return _students[i];
                }
            }

            return null;
        }

        public Student[] GetStudentsByCourse(string course)
        {
            int count = 0;
            for(int i = 0; i < _noOfStudents; i++)
            {
                if(_students[i].GetSelectedCourse() == course)
                {
                    count++;
                }
            }

            Student[] courseStudents = new Student[count];

            for(int i = 0;i < _noOfStudents;i++)
            {
                if (_students[i].GetSelectedCourse() == course)
                {
                    courseStudents[count-1] = _students[i];
                    count--;
                }
            }

            return courseStudents;
        }

        public Student RegisterStudent(string firstName, string lastName, string email, string phoneNumber, DateTime dateOfBirth, int genderValue, string selectedSchool, string selectedCourse)
        {
            string regNo = GenerateRegNo();
            Gender gender = (Gender)genderValue;

            Student student = new Student(regNo, firstName, lastName, email, phoneNumber, gender, dateOfBirth, selectedCourse, selectedSchool);

            _students[_noOfStudents] = student;
            _noOfStudents++;

            return student;
        }
    }
}
