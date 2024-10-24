using Golestan.DataBase;
using Golestan.Entities;
using Golestan.Enums;
using Golestan.Services;
using Microsoft.VisualBasic;
using System.Diagnostics;

SeedData.Seed();
MainMenu();

void MainMenu()
{
    Console.WriteLine("1- Login 2- Register");
    if (!int.TryParse(Console.ReadLine(), out int option))
    {
        Console.WriteLine("Invalid Oprion.");
        Console.WriteLine("Press Any Key");
        Console.ReadKey();
        MainMenu();
    }

    switch (option)
    {
        case 1:
            Login();
            break;
        case 2:
            Register();
            break;
        default:
            MainMenu();
            break;
    }

}

void Login()
{
    Console.WriteLine("*************************");
    Console.WriteLine("          Login          ");
    Console.WriteLine("*************************");
    Console.WriteLine("Login As: 1- Operator 2- Student 3- Teacher");

    if (!int.TryParse (Console.ReadLine(), out int roleId))
    {
        Console.WriteLine("Invalid Role ID");
        Console.WriteLine("Press Any Key");
        Console.ReadKey();
        Login();
    }

    Console.Write("User name: ");
    string userName = Console.ReadLine();
    Console.Write("Password: ");
    string passWord = Console.ReadLine();

    // Login Through UserService Object
    UserServices userServices = new UserServices();
    var result = userServices.Login(userName, passWord);
    if (!result.IsSuccess)
    {
        Console.WriteLine(result.Message);
        Console.WriteLine("press Any Key");
        Console.ReadKey();
        Login();
    }
    else
    {
        Console.WriteLine(result.Message);
    }
    // Based On RoleId Redirect To Different Menu
    RollsEnum role = (RollsEnum)roleId;
    switch (role) {
        case RollsEnum.Operator:
            OperatorMenu();    ;
            break;
        case RollsEnum.Student:
            StudentMenu();
            break;
        case RollsEnum.Teacher:
            TeacherMenu();
            break;
    }
}

void Register()
{
    Console.WriteLine("*************************");
    Console.WriteLine("         Register        ");
    Console.WriteLine("*************************");
    Console.WriteLine("Register As: 1- Operator 2-Student 3-Teacher ");
    if (!int.TryParse(Console.ReadLine(), out int roleId))
    {
        Console.WriteLine("Invalid Role");
        Console.WriteLine("Press Any Key");
        Console.ReadKey();
        Register();
    }

    Console.Write("First Name: ");
    string firstName = Console.ReadLine();
    Console.Write("Last Name: ");
    string lastName = Console.ReadLine();
    Console.Write("Email: ");
    string email = Console.ReadLine();
    Console.Write("Password: ");
    string passWord = Console.ReadLine();

    RollsEnum role = (RollsEnum)roleId;
    UserServices userService = new UserServices();

    User newUser;
    switch (role)
    {
        case RollsEnum.Operator:
            Operator @operator = new Operator(firstName,lastName,email);
            var res1 = @operator.SetPassword(passWord);
            if (res1.IsSuccess)
            {
                Console.WriteLine(res1.Message);
                newUser = @operator;
                userService.Register(newUser);
            }
            else
            {
                Console.WriteLine(res1.Message);
                Register();
            }
            break;
        case RollsEnum.Teacher:
            Teacher teacher = new Teacher(firstName,lastName,email);
            var res2 = teacher.SetPassword(passWord);
            if (res2.IsSuccess)
            {
                Console.WriteLine(res2.Message);
                newUser = teacher;
                userService.Register(newUser);
            }
            else
            {
                Console.WriteLine(res2.Message);
                Register();
            }
            break;
        case RollsEnum.Student:
            Student student = new Student(firstName,lastName,email);
            var res3 = student.SetPassword(passWord);
            if ( res3.IsSuccess)
            {
                Console.WriteLine(res3.Message);
                newUser = student;
                userService.Register(newUser);
            }
            else
            {
                Console.WriteLine(res3.Message);
                Register();
            }
            break;
    }

    Login();
}

void OperatorMenu()
{
    Console.WriteLine("*********************");
    Console.WriteLine("     Operator Menu   ");
    Console.WriteLine("*********************");
    Console.WriteLine("Options: 1-Change Password 2-Activate User 3-DeActivate User 4-Logout");

    if (!int.TryParse(Console.ReadLine(), out int option))
    {
        Console.WriteLine("Invalid Choice");
        Console.WriteLine("Press Any Key");
        Console.ReadKey();
        StudentMenu();
    }
    UserServices userServices = new UserServices();
    Operator currentUser = (Operator)userServices.GetCurrentUser();
    OperatorService operatorService = new OperatorService();
    switch (option)
    {
        case 1:
            Console.WriteLine("Current Pasword: ");
            string currentPassword = Console.ReadLine();
            Console.WriteLine("New Password: ");
            string newPassword = Console.ReadLine();
            var result = currentUser.ChangePassword(newPassword,currentPassword);
            if (result.IsSuccess)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            OperatorMenu();
            break;
        case 2:
            Console.WriteLine("All Users Pending Activation");
            foreach (var user in userServices.GetUsers())
            {
                if (user.Active == false)
                {
                    Console.WriteLine(user.ToString());
                }
            }
            Console.WriteLine("Choose Id To Activate: ");
            if(!Int32.TryParse(Console.ReadLine(),out int Id))
            {
                Console.WriteLine("Invalid Id");
                Console.WriteLine("Press Any Key: ");
                Console.ReadKey();
                OperatorMenu();
            }
            var result2 = operatorService.Activate(Id);
            if (result2.IsSuccess)
            {
                Console.WriteLine(result2.Message);
            }
            else
            {
                Console.WriteLine(result2.Message);
            }
            break;
        case 3:
            Console.WriteLine("All The Active Users: ");
            foreach (var user in userServices.GetUsers())
            {
                if (user.Active == true)
                {
                    Console.WriteLine(user.ToString());
                }
            }
            Console.WriteLine("Choose The User Id To DeActivate: ");
            if (!Int32.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid Id");
                Console.WriteLine("Press Any Key: ");
                Console.ReadKey();
                OperatorMenu();
            }
            var result3 = operatorService.DeActivate(id);
            if (result3.IsSuccess)
            {
                Console.WriteLine(result3.Message); 
            }
            else
            {
                Console.WriteLine(result3.Message);
            }
            break;
        case 4:
            userServices.Logout();
            break;
    }

}

void StudentMenu()
{
    Console.WriteLine("*********************");
    Console.WriteLine("     Student Menu   ");
    Console.WriteLine("*********************");
    Console.WriteLine("Options: 1- Change Password 2- Select Course 3- View Schedule 4- Logout");
    if (!int.TryParse(Console.ReadLine(),out int option))
    {
        Console.WriteLine("Invalid Choice");
        Console.WriteLine("Press Any Key");
        Console.ReadKey();
        StudentMenu();
    }

    UserServices userServices = new UserServices();
    Student student = (Student)userServices.GetCurrentUser();
    StudentService studentService = new StudentService();
    CourseService courseService = new CourseService();
    switch (option)
    {
        case 1:
            Console.WriteLine("Current Password: ");
            string currentPassword = Console.ReadLine();
            Console.WriteLine("New Password: ");
            string newPassword = Console.ReadLine();
            var result = student.ChangePassword(newPassword,currentPassword);
            if (!result.IsSuccess)
            {
                Console.WriteLine(result.Message);
                Console.WriteLine("Press Any Key");
                Console.ReadKey();
                StudentMenu();
            }
            Console.WriteLine(result.Message);
            break;
        case 2:
            Console.WriteLine("All Active Courses: ");
            courseService.GetCourses().ForEach(c => Console.WriteLine(c.ToString()));
            while (true)
            {
                Console.WriteLine("Select Course By ID: ");
                if (!Int32.TryParse(Console.ReadLine(),out int id))
                {
                    Console.WriteLine("Invalid Course ID");
                    Console.WriteLine("press Any Key");
                    Console.ReadKey();
                    continue;
                }
                var result2 = studentService.SelectCourse(id);
                if (result2.IsSuccess)
                {
                    Console.WriteLine(result2.Message);
                    Console.WriteLine("Continue? Y or N");
                    string answer = Console.ReadLine();
                    if (answer == "Y") continue;
                    if (answer == "N") break;
                }
                else if (result2.Message == "You Have Reached The Limit")
                {
                    StudentMenu();
                }
                else
                {
                    Console.WriteLine(result2.Message);
                }
            }
            StudentMenu();
            break;
        case 3:
            Console.WriteLine(student.DisplaySchedule());
            break;
        case 4:
            userServices.Logout();
            break;
    }
}

void TeacherMenu()
{
    Console.WriteLine("*********************");
    Console.WriteLine("     Teacher Menu   ");
    Console.WriteLine("*********************");
    Console.WriteLine("Options: 1- Change Password 2- Define New Course 3- View Students 4- Logout");
    if (!int.TryParse(Console.ReadLine(), out int option))
    {
        Console.WriteLine("Invalid Choice");
        Console.WriteLine("Press Any Key");
        Console.ReadKey();
        TeacherMenu();
    }

    UserServices userServices = new UserServices();
    TeacherService teacherService = new TeacherService();
    Teacher teacher = (Teacher)userServices.GetCurrentUser();
    switch (option)
    {
        case 1:
            Console.WriteLine("Current Password: ");
            string currentPassword = Console.ReadLine();
            Console.WriteLine("New Password: ");
            string newPassword = Console.ReadLine();
            var res = teacher.ChangePassword(currentPassword, newPassword);
            if (res.IsSuccess)
                Console.WriteLine(res.Message);
            else
            {
                Console.WriteLine(res.Message);
                TeacherMenu();
            }
            break;
        case 2:
            Console.WriteLine("Enter Course Specifications: ");
            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Title: ");
            string title = Console.ReadLine();
            Console.WriteLine("Unit Count: ");
            int unit = int.Parse(Console.ReadLine());
            Console.WriteLine("Day1: e.g. Monday, Sunday");
            string day1 = Console.ReadLine();
            Console.WriteLine("Day2: e.g. Monday, Sunday");
            string day2 = Console.ReadLine();
            Console.WriteLine("Start time: (hh:mm)");
            string starttime = Console.ReadLine();
            Console.WriteLine("End Time: (hh:mm)");
            string endtime = Console.ReadLine();
            Console.WriteLine("Capacity: ");
            int cap = int.Parse(Console.ReadLine());
            var result = teacherService.DefineNewCourse(id, title, unit, day1, day2,starttime, endtime,teacher,cap);
            if (result.IsSuccess)
            {
                Console.WriteLine(result.Message);
                TeacherMenu();
            }
            break;
        case 3:
            // view All Students in her selected course
            // first Display All Her Courses
            foreach (var course in teacher.courses)
            {
                Console.WriteLine(course.ToString());
            }
            Console.WriteLine("Choose The Course ID: ");
            int id3 = int.Parse(Console.ReadLine());
            foreach (var st in teacherService.GetStudents(id3))
            {
                Console.WriteLine(st.ToString());
            };
            TeacherMenu();
            break;
        case 4:
            userServices.Logout();
            MainMenu();
            break;
    }

}


