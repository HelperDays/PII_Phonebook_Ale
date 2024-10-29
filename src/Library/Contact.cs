namespace Library
{
    public class Contact
    {
        // Constructor para inicializar las propiedades del contacto
        public Contact(string name, string phone, string email)
        {
            this.Name = name;
            this.Phone = phone;
            this.Email = email;
        }

        // Propiedad para el nombre del contacto
        public string Name { get; set; }

        // Propiedad para el teléfono del contacto
        public string Phone { get; set; }

        // Propiedad para el email del contacto
        public string Email { get; set; }
    }
}