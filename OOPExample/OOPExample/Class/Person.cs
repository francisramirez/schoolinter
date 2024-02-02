
namespace OOPExample.Class
{
    public abstract class Person
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        public abstract void Save();

        public virtual void Update() 
        { 
            // X Logica ///
        }
        
    }
}
