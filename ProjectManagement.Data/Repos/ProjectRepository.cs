using AutoMapper;
using ProjectManagement.Data.Entities;
using ProjectManagement.Shared.Dtos;
using ProjectManagement.Shared.Repos.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Shared.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace ProjectManagement.Data.Repos
{
    [AutoBind]
    public class ProjectRepository : BaseRepository<Project, ProjectDto>, IProjectRepository
    {
        public ProjectRepository(ProjectManagementDbContext context, IMapper mapper) : base(context, mapper)
        {

        }
        public async Task<IEnumerable<ProjectDto>> GetAllActiveAsync()
        {
            return MapToEnumerableOfModel(await _dbSet.Where(p => !p.IsCompleted).ToListAsync());
        }
        public async System.Threading.Tasks.Task CompleteProjectAsync(int projectId)
        {
            var project = await GetByIdAsync(projectId);
            project.IsCompleted = true;
            await SaveAsync(project);
        }
        public async System.Threading.Tasks.Task FilterProjectAsync(bool? isCompleted, DateTime? endDate, ProjectDto project)
        {
            project.IsCompleted = true;
            project.EndDate = endDate;

            await SaveAsync(project);
        }


        ////UpdateAsync ??
        //public async System.Threading.Tasks.Task UpdateAsync(Project project)
        //{
        //    if (project == null)
        //        throw new ArgumentNullException(nameof(project));

        //    try
        //    {
        //        var entity = await _dbSet.FindAsync(project.Id);

        //        if (entity == null)
        //            throw new ArgumentNullException(nameof(entity));

        //        _context.Entry(entity).CurrentValues.SetValues(project);
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (SqlException ex)
        //    {
        //        await Console.Out.WriteLineAsync($"The system threw an SQL exception trying to update project: {ex.Message}");
        //    }
        //    catch (Exception ex)
        //    {
        //        await Console.Out.WriteLineAsync($"The system threw a non-SQL exception trying to update project: {ex.Message}");
        //    }
        //}
        ////end UpdateAsync

        ////MapToEntity
        //public virtual ProjectRepository MapToEntity(Project project)
        //{
        //    return mapper.Map<ProjectRepository>(project);
        //}
        ////end MapToEntity

        ////CreateAsync
        //public async System.Threading.Tasks.Task CreateAsync(Project project)
        //{
        //    if (project == null)
        //        throw new ArgumentNullException(nameof(project));

        //    try
        //    {
        //        var entity = this.MapToEntity(project);
        //        await _dbSet.AddAsync(entity);
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (SqlException ex)
        //    {
        //        // Here we can save these errors in some logs or telemetery
        //        await Console.Out.WriteLineAsync($"The system threw an sql exception trying to create {nameof(project)}: {ex.Message}");

        //    }
        //    catch (Exception ex)
        //    {
        //        // Here we can save these errors in some logs or telemetery
        //        await Console.Out.WriteLineAsync($"The system threw an non-sql exception trying to create {nameof(project)}: {ex.Message}");

        //    }
        //}
        ////end CreateAsync
        ////SaveAsync??
        //public async System.Threading.Tasks.Task SaveAsync(Project project)
        //{
        //    if (project == null)
        //        throw new ArgumentNullException(nameof(project));

        //    if (project.Id != 0)
        //        await UpdateAsync(project);
        //    else
        //        await CreateAsync(project);
        //}
        ////end SaveAsync


        //public async System.Threading.Tasks.Task FilterProjectAsync(bool? isCompleted, DateTime? endDate)
        //{
        //    var project = await _dbSet.Where(p => !p.IsCompleted).FirstOrDefaultAsync();
        //    if (project != null)
        //    {
        //        project.IsCompleted = true;
        //        project.EndDate = endDate;
        //        await SaveAsync(project);
        //    }
        //}


    }
}
