﻿namespace Blog.Application.Contracts
{
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    public interface IPersistenceContract
    {
        DbSet<Person> People { get; set; }

        DbSet<Article> Articles { get; set; }

        DbSet<Comment> Comments { get; set; }

        Task<int> SaveChanges(CancellationToken cancellationToken);
    }
}
