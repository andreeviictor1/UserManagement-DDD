using UserManagement.Domain.Exceptions;

namespace UserManagement.Domain.Entities.User
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        private User() { } // EF Core

        public User(string nome, string email, string password)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Email = email;
            Password = password;
            CreatedAt = DateTime.UtcNow;

            Validate();
        }

        public void UpdateInfo(string nome, string email)
        {
            Nome = nome;
            Email = email;
            UpdatedAt = DateTime.UtcNow;
            Validate();
        }


        public void UpdatePassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new DomainException("Senha não pode ser vazia.");

            Password = password;
            UpdatedAt = DateTime.UtcNow;
        }


        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(Nome))
                throw new DomainException("Nome é obrigatório");

            if (string.IsNullOrWhiteSpace(Email) || !Email.Contains("@"))
                throw new DomainException("Email inválido");

            if (string.IsNullOrWhiteSpace(Password))
                throw new DomainException("Password é obrigatório");
        }



    }
}
