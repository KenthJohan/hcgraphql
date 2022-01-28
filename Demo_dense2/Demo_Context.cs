using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.IO;

using System;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System.Text.Json;
using System.Text;
using System.Collections.Generic;
using System.Security.Claims;
using System.Net;
using System.Net.WebSockets;
using System.Net.Http;
using System.Net.Http.Headers;


using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using Serilog;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


#nullable disable

namespace Demo
{
	public class Demo_Context : DbContext
	{
		public DbSet<Edge> edges { get; set; }
		public DbSet<User> users { get; set; }
		public DbSet<Book> books { get; set; }
		public DbSet<Product> products { get; set; }
		public DbSet<Building> buildings { get; set; }

		public Demo_Context(DbContextOptions<Demo_Context> options)
			: base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			string s = "Host=localhost:5432;Database=demo;Username=postgres;Password=secret";
			options.UseNpgsql(s);
			Log.Information("Connection string {s}", s);
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<User>().HasIndex(u => u.email).IsUnique();

			/*
			builder.Entity<User>().HasOne(t => t.entity).WithOne().HasForeignKey<Entity>(x => x.id);
			builder.Entity<Edge>().HasOne(t => t.entity).WithOne().HasForeignKey<Entity>(x => x.id);
			builder.Entity<Book>().HasOne(t => t.entity).WithOne().HasForeignKey<Entity>(x => x.id);
			builder.Entity<Product>().HasOne(t => t.entity).WithOne().HasForeignKey<Entity>(x => x.id);
			builder.Entity<Building>().HasOne(t => t.entity).WithOne().HasForeignKey<Entity>(x => x.id);

			builder.Entity<Entity>().HasOne(t => t.book).WithOne().HasForeignKey<Book>(x => x.entity_id);
			builder.Entity<Entity>().HasOne(t => t.user).WithOne().HasForeignKey<User>(x => x.entity_id);
			builder.Entity<Entity>().HasOne(t => t.product).WithOne().HasForeignKey<Product>(x => x.entity_id);
			builder.Entity<Entity>().HasOne(t => t.building).WithOne().HasForeignKey<Building>(x => x.entity_id);
			builder.Entity<Entity>().HasMany(t => t.edges).WithOne(x => x.relation);
			builder.Entity<Entity>().HasMany(t => t.edges1).WithOne(x => x.a);
			builder.Entity<Entity>().HasMany(t => t.edges2).WithOne(x => x.b);
			builder.Entity<Edge>().HasIndex(x => new {x.relation_id, x.a_id, x.b_id}).IsUnique();
			builder.Entity<Edge>().HasKey(x => new {x.relation_id, x.a_id, x.b_id});
			*/

			//builder.Entity<Edge>().HasOne(t => t.relation).WithMany(x => x.edges);
			//builder.Entity<Edge>().HasOne(t => t.a).WithMany(x => x.edges);
			//builder.Entity<Edge>().HasOne(t => t.b).WithMany(x => x.edges);
			

			//builder.Entity<Edge>().HasOne(t => t.a).WithMany(x => x.edges);
			//builder.Entity<Edge>().HasOne(t => t.b).WithMany(x => x.edges);

			//builder.Entity<Entity>().HasOne(t => t.edges).WithOne().HasForeignKey<Edge>(x => x.a_id);
			//builder.Entity<Entity>().HasOne(t => t.edges).WithOne().HasForeignKey<Edge>(x => x.b_id);
		}
	}
}