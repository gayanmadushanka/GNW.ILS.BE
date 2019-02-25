namespace GNW.ILS.DAL.Entity
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserRoleId { get; set; }
        public string Address { get; set; }
        public string HomeNumber { get; set; }
        public string OfficeNumber { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }
        public virtual UserRoleEntity UserRole { get; set; }
    }
}
