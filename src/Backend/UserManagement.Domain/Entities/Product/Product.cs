
using UserManagement.Domain.Exceptions;

namespace UserManagement.Domain.Entities.Product
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }


        public Product() { }


        public Product(string name, decimal price, int stock)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            Stock = stock;
        }


        private void UpdateInfo(string name, decimal price, int stock)
        {
            Name = name;
            Price = price;
            Stock = stock;
            Validate();
        }

        private void UpdatePrice(decimal price)
        {
            if (Price < 0)
                throw new DomainException("Preço inválido");

            Price = price;
        }


        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new DomainException("Nome do produto é obrigatório");

            if (Price < 0)
                throw new DomainException("Preço inválido");

            if (Stock < 0)
                throw new DomainException("Estoque invalido");
        }

        
    }
}