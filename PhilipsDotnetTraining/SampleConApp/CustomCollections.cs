using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * A Custom Collection is an object whose class implements IEnumerable Interface. U could have other interfaces also implemented with it.
 * IEnumerable has only one method called GetEnumerator. This function returns IEnumerator object which is the iterator for UR collection. 
 * With iterator U can iterate thro the collection using MoveNext() method and access the Element using Current Property.
 * yeild keyword is used to get the iterator for an object. U could also use GetEnumerator function of UR data Collection to get the Iterator of the object. 
 * Then U can use the object within a foreach statement. 
 */
namespace SampleConApp
{
    class Student
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public long ContactNo { get; set; }
    }
    class Hostel : IEnumerable<Student>
    {
        List<Student> _students = new List<Student>();
        public void AddStudent(Student student)
        {
            _students.Add(student);
        }

        public Student this[int id]
        {
            get
            {
                foreach(var s in _students)
                {
                    if (s.StudentID == id)
                        return s;
                }
                return null;
            }
        }

        public Student this[string name] => _students.Find(s=>s.Name == name);
        

        //Read only Property as it only has get option....
        public int StudentCount => _students.Count;

        public void RemoveStudent(int id)
        {
            foreach(var student in _students)
            {
                if(student.StudentID == id)
                {
                    _students.Remove(student);
                    return;//foreach is forwardonly and readonly..
                }
            }
        }

        public IEnumerator<Student> GetEnumerator()
        {
            return _students.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var student in _students)
                yield return student;
            //yeild is a keyword to get the IEnumerator object associated with the student in this case...
        }
    }
    class CustomCollections
    {
        static void Main(string[] args)
        {
            Hostel hostel = new Hostel();
            hostel.AddStudent(new Student { StudentID = 111,  Name="Phaniraj" });
            hostel.AddStudent(new Student { StudentID = 112, Name = "Gopal" });
            hostel.AddStudent(new Student { StudentID = 113, Name = "Mahesh" });
            hostel.AddStudent(new Student { StudentID = 114, Name = "Venkat" });
            hostel.AddStudent(new Student { StudentID = 115, Name = "Bnil" });

            //for (int i = 0; i < hostel.StudentCount; i++)
            //{
            //    Console.WriteLine(hostel[i].Name);
            //}
            Console.WriteLine(hostel[115].Name);
            Console.WriteLine( "The id of student Mahesh is " + hostel["Mahesh"].StudentID);
            foreach(var student in hostel)
                Console.WriteLine(student.Name);

        }
    }
}
