﻿using ConsoleApp3.Entyties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class AirplaneDbContext: DbContext
    {
        public AirplaneDbContext()
        {
            //this.Database.EnsureDeleted();
            //this.Database.EnsureCreated();
        }
        //Collections
        public DbSet<Client> Clients { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Airplane> Airplanes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Data Source=Med_center.mssql.somee.com;
                                         Initial Catalog = Med_center;
                                         User ID=Wiles_SQLLogin_1;
                                         Password=9tdk5ikk9r;Connect Timeout=30;
                                         Encrypt=False;TrustServerCertificate=False;
                                         ApplicationIntent=ReadWrite;
                                         MultiSubnetFailover=False"
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Initializator - Seeder
            modelBuilder.Entity<Airplane>().HasData(new Airplane[]
            {
                new Airplane()
                {
                    Id = 1,
                    Model = "Boing747",
                    MaxPassanger = 300
                },
                new Airplane()
                {
                    Id = 2,
                    Model = "AN914",
                    MaxPassanger = 200
                },
                new Airplane()
                {
                    Id = 3,
                    Model = "Mria",
                    MaxPassanger = 150
                }
            });
            modelBuilder.Entity<Flight>().HasData(new Flight[] {
                new Flight()
                {
                     Number = 1,
                     DepartureCity = "Kyiv",
                     ArrivalCity = "Lviv",
                     DepartureTime = new DateTime(2024,2,17),
                     ArrivalTime = new DateTime(2024,2,17),
                     AirplaneId = 1
                },
                new Flight()
                {
                     Number = 2,
                     DepartureCity = "Varshava",
                     ArrivalCity = "Lviv",
                     DepartureTime = new DateTime(2024,2,18),
                     ArrivalTime = new DateTime(2024,2,18),
                     AirplaneId = 2
                },
                new Flight()
                {
                     Number = 3,
                     DepartureCity = "Kyiv",
                     ArrivalCity = "Lviv",
                     DepartureTime = new DateTime(2024,2,22),
                     ArrivalTime = new DateTime(2024,2,22),
                     AirplaneId = 3
                }
            });
        }

    }
}

