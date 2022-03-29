using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApplication
{
    class Menu
    {

        IStudentManager studentManager = new StudentManager();


        public void ShowMainMenu()
        {
            bool continueApp = true;

            do
            {
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Check Admission Status");
                Console.WriteLine("3. List Students");
                Console.WriteLine("4. Admit Students");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        ShowRegisterMenu();
                        break;
                    case 2:
                        ShowAdmissionStatusMenu();
                        break;
                    case 3:
                        ShowAdmitStudentMenu();
                        break;  
                    case 4:
                        ShowAdmitStudentMenu();
                        break;

                }
            } while (continueApp);

        }

        private void ShowAdmitStudentMenu()
        {
            Console.WriteLine("1. By Reg No");
            Console.WriteLine("2. By Course");
            Console.WriteLine("3. By School");
            int option = Convert.ToInt32(Console.ReadLine());

            if(option == 1)
            {
                Console.WriteLine("Enter Student RegNumber");
                string regNo = Console.ReadLine();

                if(studentManager.GetStudent(regNo) == null)
                {
                    Console.WriteLine("Student not found");
                }

                else
                {
                    Console.WriteLine(studentManager.AdmitStudentByRegNo(regNo));
                }
            }
            else if(option == 2)
            {
                Console.WriteLine("Enter Course Name: ");
                string course = Console.ReadLine();
                string response = studentManager.AdmitStudentsByCourse(course);
                Console.WriteLine(response);

            }
        }

        private void ShowAdmissionStatusMenu()
        {
            Console.Write("Enter your registration number: ");
            string regNo = Console.ReadLine();

            if(studentManager.GetStudent(regNo) == null)
            {
                Console.WriteLine("Student Not Found");
            }
            else
            {
                if(studentManager.GetAdmissionStatus(regNo) == true)
                {
                    Console.WriteLine("Congratulations! You have been admitted");
                }
                else
                {
                    Console.WriteLine("You have not been admitted yet. Please check back later");
                }
            }
        }

        private void ShowRegisterMenu()
        {
            Console.Write("Enter first name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter last name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter Phone Number: ");
            string phone = Console.ReadLine();

            Console.Write("Enter date of birth: ");
            DateTime dateOfBirth = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Enter School Of Choice: ");
            string selectedSchool = Console.ReadLine();

            Console.Write("Enter Course Of Choice: ");
            string selectedCourse = Console.ReadLine();

            Console.WriteLine("Select Gender: ");
            Console.WriteLine("\t1. Male");
            Console.WriteLine("\t2. Female");
            int gender = Convert.ToInt32(Console.ReadLine());

            Student newStudent = studentManager.RegisterStudent(firstName, lastName, email, phone, dateOfBirth, gender, selectedSchool, selectedCourse);

            Console.WriteLine($"Dear {newStudent.GetFullName()}, your registration is successful. Your Registaration number is {newStudent.GetRegNo()}");
        }
    }
}
