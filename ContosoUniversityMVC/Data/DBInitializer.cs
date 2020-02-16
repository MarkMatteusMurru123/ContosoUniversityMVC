using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ContosoUniversityMVC.Models;

namespace ContosoUniversityMVC.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            //context.Database.EnsureCreated();

            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
                new Student { FirstMidName = "Hugo",   LastName = "Valk",
                    EnrollmentDate = DateTime.Parse("2010-09-01") },
                new Student { FirstMidName = "Madli", LastName = "Kaevats",
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstMidName = "Johannes Olaf",   LastName = "Kurss",
                    EnrollmentDate = DateTime.Parse("2013-09-01") },
                new Student { FirstMidName = "Mark Matteus",    LastName = "Murru",
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstMidName = "Johann",      LastName = "Kuldmäe",
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstMidName = "Nipi",    LastName = "Tiri",
                    EnrollmentDate = DateTime.Parse("2011-09-01") },
                new Student { FirstMidName = "Sammal",    LastName = "Habe",
                    EnrollmentDate = DateTime.Parse("2013-09-01") },
                new Student { FirstMidName = "Anna",     LastName = "Minna",
                    EnrollmentDate = DateTime.Parse("2005-09-01") }
            };

            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var instructors = new Instructor[]
            {
                new Instructor { FirstMidName = "Viljam",     LastName = "Puusep",
                    HireDate = DateTime.Parse("1995-03-11") },
                new Instructor { FirstMidName = "Gunnar",    LastName = "Piho",
                    HireDate = DateTime.Parse("2002-07-06") },
                new Instructor { FirstMidName = "Margus",   LastName = "Kruus",
                    HireDate = DateTime.Parse("1998-07-01") },
                new Instructor { FirstMidName = "Liisa", LastName = "Jõgiste",
                    HireDate = DateTime.Parse("2001-01-15") },
                new Instructor { FirstMidName = "Inna",   LastName = "Švartsman",
                    HireDate = DateTime.Parse("2004-02-12") }
            };

            foreach (Instructor i in instructors)
            {
                context.Instructors.Add(i);
            }
            context.SaveChanges();

            var departments = new Department[]
            {
                new Department { Name = "Information Technology",     Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Puusep").ID },
                new Department { Name = "Mathematics", Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Kruus").ID },
                new Department { Name = "Engineering", Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Piho").ID },
                new Department { Name = "Economics",   Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Švartsman").ID }
            };

            foreach (Department d in departments)
            {
                context.Departments.Add(d);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
                new Course {CourseID = 1050, Title = "Physics",      Credits = 6,
                    DepartmentID = departments.Single( s => s.Name == "Engineering").DepartmentID
                },
                new Course {CourseID = 4022, Title = "Economics", Credits = 6,
                    DepartmentID = departments.Single( s => s.Name == "Economics").DepartmentID
                },
                new Course {CourseID = 4041, Title = "IT Fundamentals", Credits = 12,
                    DepartmentID = departments.Single( s => s.Name == "Information Technology").DepartmentID
                },
                new Course {CourseID = 1045, Title = "Calculus",       Credits = 6,
                    DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID
                },
                new Course {CourseID = 3141, Title = "Discrete Mathematics",   Credits = 6,
                    DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID
                },
                new Course {CourseID = 1702, Title = "Web Applications",    Credits = 12,
                    DepartmentID = departments.Single( s => s.Name == "Information Technology").DepartmentID
                },
                new Course {CourseID = 2042, Title = "IT Operations",     Credits = 6,
                    DepartmentID = departments.Single( s => s.Name == "Information Technology").DepartmentID
                },
            };

            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            var officeAssignments = new OfficeAssignment[]
            {
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "Kruus").ID,
                    Location = "Smith 17" },
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "Puusep").ID,
                    Location = "Gowan 27" },
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "Piho").ID,
                    Location = "Thompson 304" },
            };

            foreach (OfficeAssignment o in officeAssignments)
            {
                context.OfficeAssignments.Add(o);
            }
            context.SaveChanges();

            var courseInstructors = new CourseAssignment[]
            {
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Physics" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Piho").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "IT Fundamentals" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Piho").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "IT Fundamentals" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Jõgiste").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Economics" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Švartsman").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Calculus" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Kruus").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Discrete Mathematics" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Kruus").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Web Applications" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Puusep").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "IT Operations" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Piho").ID
                    },
            };

            foreach (CourseAssignment ci in courseInstructors)
            {
                context.CourseAssignments.Add(ci);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Valk").ID,
                    CourseID = courses.Single(c => c.Title == "IT Fundamentals" ).CourseID,
                    Grade = Grade.A
                },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Kaevats").ID,
                    CourseID = courses.Single(c => c.Title == "Economics" ).CourseID,
                    Grade = Grade.C
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Murru").ID,
                    CourseID = courses.Single(c => c.Title == "Economics" ).CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                        StudentID = students.Single(s => s.LastName == "Habe").ID,
                    CourseID = courses.Single(c => c.Title == "Calculus" ).CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                        StudentID = students.Single(s => s.LastName == "Tiri").ID,
                    CourseID = courses.Single(c => c.Title == "Discrete Mathematics" ).CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Tiri").ID,
                    CourseID = courses.Single(c => c.Title == "IT Operations" ).CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Kuldmäe").ID,
                    CourseID = courses.Single(c => c.Title == "Physics" ).CourseID
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Minna").ID,
                    CourseID = courses.Single(c => c.Title == "Economics").CourseID,
                    Grade = Grade.B
                    },
                new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Murru").ID,
                    CourseID = courses.Single(c => c.Title == "Web Applications").CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Kaevats").ID,
                    CourseID = courses.Single(c => c.Title == "Calculus").CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Valk").ID,
                    CourseID = courses.Single(c => c.Title == "Web Applications").CourseID,
                    Grade = Grade.B
                    }
            };

            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments.Where(
                    s =>
                            s.Student.ID == e.StudentID &&
                            s.Course.CourseID == e.CourseID).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Enrollments.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}