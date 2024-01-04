using Microsoft.AspNetCore.Mvc;
using TicketingSystem.Services.Models.Message;
using TicketingSystem.Services.Models.Message.Enums;
using TicketingSystem.Services.Models.Project;
using TicketingSystem.Services.Models.Project.Enums;
using TicketingSystem.Services.Models.Ticket;
using TicketingSystem.Services.Models.Ticket.Enums;
using TicketingSystemDavid.ViewModels.Message;
using TicketingSystemDavid.ViewModels.Message.Enums;
using TicketingSystemDavid.ViewModels.Project;
using TicketingSystemDavid.ViewModels.Project.Enums;
using TicketingSystemDavid.ViewModels.Ticket;
using TicketingSystemDavid.ViewModels.Ticket.Enums;

namespace TicketingSystemDavid.Controllers
{

    public class BaseController : Controller
    {
        //Message Convert Methods

        public CreateMessageModelServices ConvertMessage(CreateMessageViewModel model)
        {
            CreateMessageModelServices newModel = new CreateMessageModelServices
            {
                Id = model.Id,
                State = (MessageStateServices)Enum.Parse(typeof(MessageStateServices), model.State.ToString()),
                Content = model.Content,
                Creator = model.Creator,
                CreatedOn = model.CreatedOn,
                TicketId = model.TicketId,
                FileContent = model.FileContent,
                ContentType = model.ContentType,
                FileName = model.FileName,
                IsDeleted = model.IsDeleted
            };

            return newModel;
        }

        public CreateMessageViewModel ConvertMessageViewModel(CreateMessageModelServices model)
        {
            CreateMessageViewModel newModel = new CreateMessageViewModel
            {
                Id = model.Id,
                State = (MessageState)Enum.Parse(typeof(MessageState), model.State.ToString()),
                Content = model.Content,
                Creator = model.Creator,
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
                ProjectSorting = (ProjectSortEnumServices)Enum.Parse(typeof(ProjectSortEnumServices), query.ProjectSorting.ToString()),
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
                ProjectSorting = (ProjectSortEnum)Enum.Parse(typeof(ProjectSortEnum), query.ProjectSorting.ToString()),
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
                    Creator = t.Creator,
                    Type = t.Type,
                    Heading = t.Heading,
                    State = t.State,
                    Description = t.Description,
                    IsDeleted = t.IsDeleted,
                    Messages = t.Messages.Select(m => new MessageDetailsViewModelMessage
                    {
                        Id = m.Id,
                        State = m.State,
                        Content = m.Content,
                        Creator = m.Creator,
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
                File = model.File,
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
                File = model.File,
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
                Creator = model.Creator,
                Type = model.Type,
                Heading = model.Heading,
                State = model.State,
                Description = model.Description,
                IsDeleted = model.IsDeleted,
                File = model.File,
                Messages = model.Messages.Select(m => new MessageDetailsViewModelServices
                {
                    Id = m.Id,
                    State = m.State,
                    Content = m.Content,
                    Creator = m.Creator,
                    TicketId = m.TicketId,
                    FileContent = m.FileContent,
                    FileName = m.FileName,
                    File = m.File,
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
                Creator = model.Creator,
                Type = model.Type,
                Heading = model.Heading,
                State = model.State,
                Description = model.Description,
                IsDeleted = model.IsDeleted,
                File = model.File,
                FileContent = model.FileContent,
                FileName = model.FileName,
                Messages = model.Messages.Select(m => new MessageDetailsViewModelMessage
                {
                    Id = m.Id,
                    State = m.State,
                    Content = m.Content,
                    Creator = m.Creator,
                    TicketId = m.TicketId,
                    FileContent = m.FileContent,
                    FileName = m.FileName,
                    File = m.File,
                    IsDeleted = m.IsDeleted
                }).ToList(),
            };

            return newModel;
        }
    }
}
