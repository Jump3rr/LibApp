﻿using System;
using System.Linq;
using AutoMapper.Internal;
using LibApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibApp.Models
{
    public static class SeedData
    {
        public static async void Initialize(IServiceProvider serviceProvider)
        {
            await using var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            using var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (!roleManager.Roles.Any())
            {
                var roles = new[]
                {
                    RolesConstants.Owner,
                    RolesConstants.StoreManager,
                    RolesConstants.User
                };

                foreach (var role in roles)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            if (context.MembershipTypes.Any())
            {
                Console.WriteLine("Database already seeded");
                return;
            }

            context.MembershipTypes.AddRange(
                new MembershipType
                {
                    Id = 1,
                    Name = "Membership type 1",
                    SignUpFee = 0,
                    DurationInMonths = 0,
                    DiscountRate = 0
                },
                new MembershipType
                {
                    Id = 2,
                    Name = "Membership type 2",
                    SignUpFee = 30,
                    DurationInMonths = 1,
                    DiscountRate = 10
                },
                new MembershipType
                {
                    Id = 3,
                    Name = "Membership type 3",
                    SignUpFee = 90,
                    DurationInMonths = 3,
                    DiscountRate = 15
                },
                new MembershipType
                {
                    Id = 4,
                    Name = "Membership type 4",
                    SignUpFee = 300,
                    DurationInMonths = 12,
                    DiscountRate = 20
                });

            context.Rentals.AddRange(
                new Rental
                {
                    Customer = new Customer
                    {
                        Birthdate = DateTime.Now.AddYears(-10),
                        HasNewsletterSubscribed = true,
                        MembershipTypeId = 1,
                        Name = "ExampleName1"
                    },
                    Book = new Book
                    {
                        AuthorName = "ExampleAuthor1",
                        DateAdded = DateTime.Now.AddDays(-1),
                        GenreId = 1,
                        Name = "Name1",
                        NumberAvailable = 10,
                        NumberInStock = 10,
                        ReleaseDate = DateTime.Now.AddDays(-2)
                    },
                    DateRented = DateTime.Now.AddDays(-1)
                },
                new Rental
                {
                    Customer = new Customer
                    {
                        Birthdate = DateTime.Now.AddYears(-10),
                        HasNewsletterSubscribed = true,
                        MembershipTypeId = 1,
                        Name = "ExampleName2"
                    },
                    Book = new Book
                    {
                        AuthorName = "ExampleAuthor2",
                        DateAdded = DateTime.Now.AddDays(-1),
                        GenreId = 2,
                        Name = "Name2",
                        NumberAvailable = 10,
                        NumberInStock = 10,
                        ReleaseDate = DateTime.Now.AddDays(-2)
                    },
                    DateRented = DateTime.Now.AddDays(-1)
                },
                new Rental
                {
                    Customer = new Customer
                    {
                        Birthdate = DateTime.Now.AddYears(-10),
                        HasNewsletterSubscribed = true,
                        MembershipTypeId = 3,
                        Name = "ExampleName3"
                    },
                    Book = new Book
                    {
                        AuthorName = "ExampleAuthor3",
                        DateAdded = DateTime.Now.AddDays(-1),
                        GenreId = 3,
                        Name = "Name3",
                        NumberAvailable = 10,
                        NumberInStock = 10,
                        ReleaseDate = DateTime.Now.AddDays(-2)
                    },
                    DateRented = DateTime.Now.AddDays(-1)
                }
                );

            await context.SaveChangesAsync();
        }

    }
}