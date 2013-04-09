using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel.Activation;
using System.ServiceModel;

namespace RESTFulDemo
{
    /// <summary>
    /// Basically this code is developed for HTTP GET, PUT, POST & DELETE operation.
    /// </summary>
    /// 
    //estas dos lineas nos sirven para la compatibilidad de asp.net
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]

    //implementamps la interface, los dos puntos es como el implements de java
    // para rellenar con los metdos de la interface , simpleente damos a rellenar con los metodos cuando la I del IRESTSERVICE sea desplegable
    public class RESTSerivce : IRestSerivce
    {
        //ponemos las variables a usar por la clase
        List<Student> objStudent = new List<Student>();
        int studentCount = 0;

        public Student CreateStudent(Student createStudent)
        {
            //desarrollamos el metodo de creacion de perosna
            createStudent.ID = (++studentCount).ToString();
            objStudent.Add(createStudent);
            return createStudent;
        }

        public List<Student> GetAllStudent()
        {   
            //quitamos el trown y ponemos el return toda la lista
            return objStudent.ToList();
        }

        public Student GetAStudent(string id)
        {
            //desarrollamos el buscar perosna con id tal
            return objStudent.FirstOrDefault(e => e.ID.Equals(id));
        }

        public Student UpdateStudent(string id, Student updateStudent)
        {
            //desarrollamos el actualizar perosna mandamos el id y losdatos de la persona a actualizar
            Student s = objStudent.FirstOrDefault(e => e.ID.Equals(id));
            s.Name = updateStudent.Name;
            s.Name = updateStudent.Lastname;
            s.Age = updateStudent.Age;
            return s;
        }

        public void DeleteStudent(string id)
        {
            //desarollamos el delete
            objStudent.RemoveAll(e => e.ID.Equals(id));
        }

      
    }
}