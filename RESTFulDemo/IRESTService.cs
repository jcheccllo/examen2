using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace RESTFulDemo
{

    #region IRESTService Interface

    [ServiceContract]
    public interface IRestSerivce
    {
        //2) aqui colocamos los metodos de la clase
        //POST operation
        //web invoke sirve para, un create siempre es invoke
        [OperationContract]
        [WebInvoke(UriTemplate = "", Method = "POST")]
        Student CreateStudent(Student createStudent);


        //Get Operation
        //web get sirve para el url base, si no te pasa nada te manda todos
        [OperationContract]
        [WebGet(UriTemplate = "")]
        List<Student> GetAllStudent();
        //si te manda id, solo muestra la persona con ese id
        [OperationContract]
        [WebGet(UriTemplate = "{id}")]
        Student GetAStudent(string id);

        //PUT Operation
        // el operation contract indica que es metodo, el web invoke  es despues
        //par ael put si se le manda el id y el metodo es put obviamente
        [OperationContract]
        [WebInvoke(UriTemplate = "{id}", Method = "PUT")]
        Student UpdateStudent(string id, Student updateStudent);

        //DELETE Operation
        // se manda id pero solamente delete
        [OperationContract]
        [WebInvoke(UriTemplate = "{id}", Method = "DELETE")]
        void DeleteStudent(string id);


       }
    
    #endregion


    // 1) lo primer q hacemos es esta parte la clase person
    #region Student Entity

    //Para definir entidad data conctract
    [DataContract]
    public class Student
    {
        [DataMember]
        public string ID;
        [DataMember]
        public string Name;
        [DataMember]
        public string Lastname;
        [DataMember]
        public string Age;
        

    } 
    #endregion

}
