using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Eduman.Data;
using Eduman.Models;
using Eduman.Services;
using Eduman.Services.Contracts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Eduman.Tests.Eduman.Services.Tests.Base
{
    public class BaseServiceTest
    {
        protected IServiceProvider Provider { get; set; }

        protected EdumanDbContext Context { get; set; }

        [SetUp]
        public void SetUp()
        {
            var services = SetServices();
            this.Provider = services.BuildServiceProvider();
            this.Context = this.Provider.GetRequiredService<EdumanDbContext>();
            SetScoppedServiceProvider();
        }

        [TearDown]
        public void TearDown()
        {
            this.Context.Database.EnsureDeleted();
        }

        private void SetScoppedServiceProvider()
        {
            var httpContext = this.Provider.GetService<IHttpContextAccessor>();
            httpContext.HttpContext.RequestServices = this.Provider.CreateScope().ServiceProvider;
        }

        private ServiceCollection SetServices()
        {
            var services = new ServiceCollection();

            services.AddDbContext<EdumanDbContext>(opt => 
                opt.UseInMemoryDatabase(Guid.NewGuid().ToString()));

            services.AddIdentity<EdumanUser, IdentityRole>(opt =>
                {
                    opt.SignIn.RequireConfirmedEmail = false;
                    opt.Password.RequireLowercase = false;
                    opt.Password.RequireDigit = false;
                    opt.Password.RequireNonAlphanumeric = false;
                    opt.Password.RequireUppercase = false;
                    opt.Password.RequiredUniqueChars = 0;
                    opt.Password.RequiredLength = 5;
                })
                .AddEntityFrameworkStores<EdumanDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IAbsenceService, AbsenceService>();
            services.AddTransient<IEventService, EventService>();
            services.AddTransient<IFeeService, FeeService>();
            services.AddTransient<IGradeService, GradeService>();
            services.AddTransient<IReflectionService, ReflectionService>();

            var context = new DefaultHttpContext();

            services.AddSingleton<IHttpContextAccessor>(
                new HttpContextAccessor()
                {
                    HttpContext = context,
                });
            return services;
        }
    }
}
