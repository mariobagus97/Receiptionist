﻿using Receiptionist.Core.Models;
using Receiptionist.Core.ModelServices.Infrastructure;
using Receiptionist.Core.ModelServices.Local;

namespace Receiptionist.Core.ModelServices
{
    public class VisitorRepository : RepositoryBaseLocal<Visitor> , IVisitorRepository
    { 
    }
}