using Microsoft.AspNetCore.Mvc;
using TicketingSystem.Services.Models.Message;
using TicketingSystem.Services.Models.Project;
using TicketingSystem.Services.Models.Ticket;
using TicketingSystem.Web.ViewModels.Message;
using TicketingSystem.Web.ViewModels.Project;
using TicketingSystem.Web.ViewModels.Ticket;
using TicketingSystemDavid.ViewModels.Message;
using TicketingSystemDavid.ViewModels.Project;
using TicketingSystemDavid.ViewModels.Ticket;

namespace TicketingSystemDavid.Controllers
{

    public class BaseController : Controller
    {
        //Message Convert Methods

        public CreateMessageModelService ConvertMessage(CreateMessageViewModel model)
        {
            CreateMessageModelService newModel = new CreateMessageModelService
            {
                Id = model.Id,
                State = (MessageStateService)Enum.Parse(typeof(MessageStateService), model.State.ToString()),
                Content = model.Content,
                CreatedOn = model.CreatedOn,
                TicketId = model.TicketId,
                FileContent = model.FileContent,
                ContentType = model.ContentType,
                FileName = model.FileName,
                IsDeleted = model.IsDeleted
            };

            return newModel;
        }

        public CreateMessageViewModel ConvertMessageViewModel(CreateMessageModelService model)
        {
            CreateMessageViewModel newModel = new CreateMessageViewModel
            {
                Id = model.Id,
                State = (MessageState)Enum.Parse(typeof(MessageState), model.State.ToString()),
                Content = model.Content,
                TicketId = model.TicketId,
                CreatedOn = model.CreatedOn,
                FileContent = model.FileContent,
                ContentType = model.ContentType,
                FileName = model.FileName,
                IsDeleted = model.IsDeleted
            };

            return newModel;
        }

        //Project Convert Methods

        public CreateProjectViewModelServices ConvertProject(CreateProjectViewModel model)
        {
            CreateProjectViewModelServices newModel = new CreateProjectViewModelServices 
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description
            };

            return newModel;
        }

        public ProjectAllQueryModelServices ConvertQuery(ProjectAllQueryModel query)
        {
            ProjectAllQueryModelServices newModel = new ProjectAllQueryModelServices
            {
                SearchString = query.SearchString,
                ProjectSorting = (ProjectSortServices)Enum.Parse(typeof(ProjectSortServices), query.ProjectSorting.ToString()),
                CurrentPage = query.CurrentPage,
                ProjectsPerPage = query.ProjectsPerPage,
                TotalProjects = query.TotalProjects,
                Projects = query.Projects.Select(p => new ProjectAllViewModelServices
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    IsDeleted = p.IsDeleted,
                    TicketCount = p.TicketCount
                })
            };

            return newModel;
        }

        public ProjectAllQueryModel ConvertQueryForViewModel(ProjectAllQueryModelServices query)
        {
            ProjectAllQueryModel newModel = new ProjectAllQueryModel
            {
                SearchString = query.SearchString,
                ProjectSorting = (ProjectSort)Enum.Parse(typeof(ProjectSort), query.ProjectSorting.ToString()),
                CurrentPage = query.CurrentPage,
                ProjectsPerPage = query.ProjectsPerPage,
                TotalProjects = query.TotalProjects,
                Projects = query.Projects.Select(p => new ProjectAllViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    IsDeleted = p.IsDeleted,
                    TicketCount = p.TicketCount
                })
            };

            return newModel;
        }

        public AllProjectsFilteredAndOrdered ConvertProjectAllViewModel(AllProjectsFilteredAndOrderedServices model)
        {
            AllProjectsFilteredAndOrdered newModel = new AllProjectsFilteredAndOrdered
            {
                TotalProjectsCount = model.TotalProjectsCount,
                Projects = model.Projects.Select(p => new ProjectAllViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    IsDeleted = p.IsDeleted,
                    TicketCount = p.TicketCount
                })
            };

            return newModel;
        }

        public ProjectDetailsViewModel ConvertProjectDetailsViewModel(ProjectDetailsViewModelServices model) 
        {
            ProjectDetailsViewModel newModel = new ProjectDetailsViewModel 
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                IsDeleted = model.IsDeleted,
                Tickets = model.Tickets.Select(t => new TicketDetailsViewModel
                {
                    Id = t.Id,
                    ProjectId = t.ProjectId,
                    CreatedOn = t.CreatedOn,
                    CreatorEmail = t.Creator,
                    Type = t.Type,
                    Heading = t.Heading,
                    State = t.State,
                    Description = t.Description,
                    IsDeleted = t.IsDeleted,
                    Messages = t.Messages.Select(m => new MessageDetailsViewModel
                    {
                        Id = m.Id,
                        State = (MessageState)Enum.Parse(typeof(MessageState), m.State.ToString()),
                        Content = m.Content,
                        CreatorEmail = m.Creator,
                        TicketId = m.TicketId,
                        IsDeleted = m.IsDeleted
                    }).ToList(),
                }).ToList()
            };

            return newModel;
        }

        //Ticket Convert Methods

        public CreateTicketViewModelServices ConvertTicket(CreateTicketViewModel model)
        {
            CreateTicketViewModelServices newModel = new CreateTicketViewModelServices
            {
                Id = model.Id,
                ProjectId = model.ProjectId,
                Creator = model.Creator,
                Type = (TicketCategoryServices)Enum.Parse(typeof(TicketCategoryServices), model.Type.ToString()),
                Heading = model.Heading,
                State = (TicketStateServices)Enum.Parse(typeof(TicketStateServices), model.State.ToString()),
                Description = model.Description,
                FileName = model.FileName,
                FileContent = model.FileContent,
                ContentType = model.ContentType
            };

            return newModel;
        }

        public CreateTicketViewModel ConvertTicketViewModel(CreateTicketViewModelServices model)
        {
            CreateTicketViewModel newModel = new CreateTicketViewModel
            {
                Id = model.Id,
                ProjectId = model.ProjectId,
                Creator = model.Creator,
                Type = (TicketCategory)Enum.Parse(typeof(TicketCategory), model.Type.ToString()),
                Heading = model.Heading,
                State = (TicketState)Enum.Parse(typeof(TicketState), model.State.ToString()),
                Description = model.Description,
                FileName = model.FileName,
                FileContent = model.FileContent,
                ContentType = model.ContentType
            };

            return newModel;
        }

        public TicketDetailsViewModelServices ConvertTicketDetails(TicketDetailsViewModel model)
        {
            TicketDetailsViewModelServices newModel = new TicketDetailsViewModelServices
            {
                Id = model.Id,
                ProjectId = model.ProjectId,
                CreatedOn = model.CreatedOn,
                Creator = model.CreatorEmail,
                Type = model.Type,
                Heading = model.Heading,
                State = model.State,
                Description = model.Description,
                IsDeleted = model.IsDeleted,
                FileContent = model.FileContent,
                FileName = model.FileName,
                Messages = model.Messages.Select(m => new MessageDetailsViewModelService
                {
                    Id = m.Id,
                    State = (MessageStateService)Enum.Parse(typeof(MessageStateService), model.State.ToString()),
                    Content = m.Content,
                    Creator = m.CreatorEmail,
                    TicketId = m.TicketId,
                    FileContent = m.FileContent,
                    FileName = m.FileName,
                    IsDeleted = m.IsDeleted
                }).ToList(),
            };

            return newModel;
        }

        public TicketDetailsViewModel ConvertTicketDetailsViewModel(TicketDetailsViewModelServices model)
        {
            TicketDetailsViewModel newModel = new TicketDetailsViewModel
            {
                Id = model.Id,
                ProjectId = model.ProjectId,
                CreatedOn = model.CreatedOn,
                CreatorEmail = model.Creator,
                Type = model.Type,
                Heading = model.Heading,
                State = model.State,
                Description = model.Description,
                IsDeleted = model.IsDeleted,
                FileContent = model.FileContent,
                FileName = model.FileName,
                Messages = model.Messages.Select(m => new MessageDetailsViewModel
                {
                    Id = m.Id,
                    State = (MessageState)Enum.Parse(typeof(MessageState), model.State.ToString()),
                    Content = m.Content,
                    CreatorEmail = m.Creator,
                    TicketId = m.TicketId,
                    FileContent = m.FileContent,
                    FileName = m.FileName,
                    IsDeleted = m.IsDeleted
                }).ToList(),
            };

            return newModel;
        }
    }
}
