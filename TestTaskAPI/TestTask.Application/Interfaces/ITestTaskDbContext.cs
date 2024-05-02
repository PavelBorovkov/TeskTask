using Microsoft.EntityFrameworkCore;
using TestTask.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Application.Interfaces
{
    public interface ITestTaskDbContext
    {
        DbSet<Product> Products { get; set; }

        //отвечает за сохранение данных в базе
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
