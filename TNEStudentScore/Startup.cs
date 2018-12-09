using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TNEStudentScore.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using TNEStudentScoreModels;
using TNEStudentScore.Models.ViewModels;

namespace TNEStudentScore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Student, StudentViewModel>()
                    .ForMember(d => d.GroupName, opt => opt.MapFrom(s => s.Group.Name))
                    .ForMember(d => d.UniversityName, opt => opt.MapFrom(s => s.Group.University.Name))
                    .ForMember(d => d.AvgScore, opt => opt.MapFrom(s => s.Marks.Average(t => t.Score)));
            });

            services.AddMvc();
            services.AddDbContext<StudentScoreContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("StudentScoreDB")));
            services.AddAutoMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();

        }
    }
}
