using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Domain.Exceptions;

namespace UserManagement.Domain.Entities.Car
{
    public class Car
    {
        public Guid Id { get; private set; }
        public string Model { get; private set; }
        public string Brand { get; private set; }
        public string Type { get; private set; }
        public string Color { get; private set; }

        public Car()
        {

        }


        public Car(string model, string brand, string type, string color)
        {
            Id = Guid.NewGuid();
            Model = model;
            Brand = brand;
            Type = type;
            Color = color;
        }


        public void UpdateInfo(string model, string brand, string type, string color)
        {
            Model = model;
            Brand = brand;
            Type = type;
            Color = color;

            Validate();
        }

        public void UpdateColor(string color)
        {
            if (string.IsNullOrWhiteSpace(Color))
            {
                throw new DomainException("Cor do carro é obrigatorio");
            }

            Color = color;
        }

        public void UpdateType(string type)
        {
            if (string.IsNullOrWhiteSpace(Type))
            {
                throw new DomainException("Tipo do carro é obrigatorio");
            }

            Type = type;
        }



        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(Model))
            {
                throw new DomainException("Modelo do carro é obrigatorio");
            }

            if (string.IsNullOrWhiteSpace(Brand))
            {
                throw new DomainException("Marca do carro é obrigatorio");
            }

            if (string.IsNullOrWhiteSpace(Type))
            {
                throw new DomainException("Tipo do carro é obrigatorio");
            }
            if (string.IsNullOrWhiteSpace(Color))
            {
                throw new DomainException("Cor do carro é obrigatorio");
            }

        }

    }
}