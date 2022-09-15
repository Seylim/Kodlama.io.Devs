﻿using Core.Persistence.Repositories;
using KodlamaIoDevs.Application.Services.Repositories;
using KodlamaIoDevs.Domain.Entities;
using KodlamaIoDevs.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Persistence.Repositories
{
    public class ProgrammingLangueageRepository : EfRepositoryBase<ProgrammingLanguage, BaseDbContext>, IProgrammingLanguageRepository
    {
        public ProgrammingLangueageRepository(BaseDbContext context) : base(context)
        {

        }
    }
}
