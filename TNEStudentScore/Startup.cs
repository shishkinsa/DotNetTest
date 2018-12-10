using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSwag.AspNetCore;
using System.Linq;
using TNEStudentScore.Models;
using TNEStudentScoreModels;
using TNEStudentScoreModels.ViewModels;

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
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Student, StudentViewModel>()
                    .ForMember(d => d.GroupName, opt => opt.MapFrom(s => s.Group.Name))
                    .ForMember(d => d.UniversityName, opt => opt.MapFrom(s => s.Group.University.Name))
                    .ForMember(d => d.AvgScore, opt => opt.MapFrom(s => s.Marks.Average(t => t.Score)));
                cfg.CreateMap<IGrouping<Student, Mark>, StudentViewModel>()
                    .ForMember(d => d.AvgScore, opt => opt.MapFrom(s => s.Average(z => z.Score)));
            });

            services.AddMvc();
            services.AddDbContext<StudentScoreContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("StudentScoreDB")));
            services.AddAutoMapper();
            services.AddSwaggerDocument();
            //services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
            app.UseSwagger(t=> t.DocumentName = "asa");
            app.UseSwaggerUi3();

        }
    }
}
