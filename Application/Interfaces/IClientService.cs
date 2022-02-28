﻿using Application.Dto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    internal interface IClientService // tu podmieniasz na dto bo pracujesz na dto
    {
        IEnumerable<ClientDto> GetAll();

        ClientDto GetById(int id);


    }
}
