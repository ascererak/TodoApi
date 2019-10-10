using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TodoApi.Domain.Entities;

namespace TodoApi.Domain.Interfaces
{
    internal interface ITodoContext
    {
        DbSet<TodoItem> TodoItems { get; set; }

        DatabaseFacade Database { get; }

        int SaveChanges();
    }
}
