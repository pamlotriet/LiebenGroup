﻿using LiebenGroupServer.Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiebenGroupServer.Application.Commands.Product
{
    public class UpdateProductCommand: IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; }
        public decimal Price { get; }

        public UpdateProductCommand(string name, decimal price, Guid id)
        {
            Name = name;
            Price = price;
            Id = id;
        }
    }
}
