using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApplication
{
    class Student
    {

        private string _regNo;
        private string _firstName;
        private string _lastName;   
        private string _email;
        private string _phoneNumber;
        private Gender _gender;
        private DateTime _dateOfBirth;
        private string _selectedCourse;
        private string _selectedSchool;
        private bool _isAdmitted;
        private DateTime? _admittedDate;

        public string Address { get; }

        public Student(string regNo, string firstName, string lastName, string email, string phoneNumber, Gender gender, DateTime dateOfBirth, string selectedCourse, string selectedSchool)
        {
            _regNo = regNo;
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _phoneNumber = phoneNumber;
            _gender = gender;
            _dateOfBirth = dateOfBirth;
            _selectedCourse = selectedCourse;
            _selectedSchool = selectedSchool;
            _isAdmitted = false;
            _admittedDate = null;
        }


        public string GetRegNo()
        { 
            return _regNo; 
        }

        public bool GetIsAdmitted()
        {
            return _isAdmitted;
        }

        public void SetIsAdmitted(bool isAdmitted)
        {
            _isAdmitted = isAdmitted;
        }


        public void SetFirstName(string firstName)
        {
            _firstName = firstName;
        }

        public string GetFullName()
        {
            return _firstName + " " + _lastName;
        }

        public string GetSelectedSchool()
        {
            return _selectedSchool;
        }

        public string GetSelectedCourse()
        {
            return _selectedCourse;
        }

       

    }
}
