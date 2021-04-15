using Microsoft.EntityFrameworkCore;
using ProjectSchool_API.Models;
using System.Collections.Generic;

namespace ProjectSchool_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Professor>()
                .HasData(
                    new List<Professor>(){
                        new Professor() {
                            Id = 1,
                            Nome = "Vinícius"
                        },
                        new Professor() {
                            Id = 2,
                            Nome = "Paula"
                        },
                        new Professor() {
                            Id = 3,
                            Nome = "Luna"
                        }
                    }
                );

            builder.Entity<Aluno>()
                .HasData(
                    new List<Aluno>(){
                        new Aluno() {
                            Id = 1,
                            Nome = "Maria José",
                            Endereco = "Rua general salvador pinheiro, 725",
                            DataNasc = "01/01/1988",
                            ProfessorId = 1
                        },
                        new Aluno() {
                            Id = 2,
                            Nome = "João Paulo",
                            Endereco = "Rua machado de assis, 23",
                            DataNasc = "02/02/1978",
                            ProfessorId = 2
                        },
                        new Aluno() {
                            Id = 3,
                            Nome = "Alex Ferraz",
                            Endereco = "Rua mostardeiro, 777",
                            DataNasc = "03/03/1968",
                            ProfessorId = 3
                        }
                    }
                );
        }
    }
}