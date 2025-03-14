namespace CozyHouse.Core.Domain.Entities
{
    public struct Contacts
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
