﻿using DomainLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLibrary.Interfaces
{
    public interface IClientRepository:IGenericRepository<Client>
    {

        public void PostClientIfNotExist(Client client);

        public Guid GetCLientIdByNameDto(Client client);



    }


}
