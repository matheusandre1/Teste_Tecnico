﻿using Microsoft.EntityFrameworkCore;
using testeTecnico.Models;

namespace testeTecnico.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
            
        }

        public DbSet<Aluno> Alunos { get; set; }
    }
}
