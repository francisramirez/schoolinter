

namespace OOPExample.Class
{
    public interface IStudentDb
    {
        void Save(Person person);
        void Remove(Person person);
        bool Exits(Person person);

    }
}
