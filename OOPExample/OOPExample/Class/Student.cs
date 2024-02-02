

using OOPExample.DbClass;

namespace OOPExample.Class
{
    public class Student : Person
    {
        private readonly IStudentDb studentDb;

        public Student()
        {
            this.studentDb = new StudentDb();
        }
        public override void Save()
        {

            // Guardar la informacion en la tabla de estudiantes //
            this.studentDb.Save(new Student() { });
        }
        public override void Update()
        {
            // Aqui se aplica el update para estudiante//
            this.studentDb.Save(new Student() { });
        }
    }
}
