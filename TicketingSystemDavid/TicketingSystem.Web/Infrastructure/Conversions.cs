using TicketingSystem.Services.Models.Message;
using TicketingSystem.Services.Models.Project;
using TicketingSystem.Services.Models.Ticket;
using TicketingSystem.Web.ViewModels.Message;
using TicketingSystem.Web.ViewModels.Ticket;
using TicketingSystemDavid.ViewModels.Message;
using TicketingSystemDavid.ViewModels.Project;
using TicketingSystemDavid.ViewModels.Ticket;

namespace TicketingSystem.Web.Infrastructure
{
    public class Conversions
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
            };

            return newModel;
        }

        //Project Convert Methods

        public ProjectAllViewModel ConvertProjectAllViewModel(ProjectViewModelServices model)
        {
            ProjectAllViewModel newModel = new ProjectAllViewModel
            {
                Id = model.Id,
                Description = model.Description,
                TicketCount = model.TicketCount,
                SoftDleted = model.SoftDeleted
            };

            return newModel;
        }

        public ProjectCreateModelServices ConvertProject(ProjectCreateViewModel model)
        {
            ProjectCreateModelServices newModel = new ProjectCreateModelServices
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description
            };

            return newModel;
        }

        public FindProjectsResultViewModel ConvertProjectAllViewModel(FindProjectsResultModelServices model)
        {
            FindProjectsResultViewModel newModel = new FindProjectsResultViewModel
            {
                TotalProjectsCount = model.TotalProjectsCount,
                Projects = model.Projects.Select(p => new ProjectAllViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    SoftDleted = p.SoftDeleted,
                    TicketCount = p.TicketCount
                })
            };

            return newModel;
        }

        public ProjectDetailsViewModel ConvertProjectDetailsViewModel(ProjectDetailsModelServices model)
        {
            ProjectDetailsViewModel newModel = new ProjectDetailsViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                SoftDleted = model.IsDeleted,
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
                    SoftDleted = t.IsDeleted,
                    Messages = t.Messages.Select(m => new MessageDetailsViewModel
                    {
                        Id = m.Id,
                        State = (MessageState)Enum.Parse(typeof(MessageState), m.State.ToString()),
                        Content = m.Content,
                        CreatorEmail = m.Creator,
                        TicketId = m.TicketId,
                        IsDeleted = m.SoftDeleted
                    }).ToList(),
                }).ToList()
            };

            return newModel;
        }

        //Ticket Convert Methods

        public TicketCreateModelServices ConvertTicket(TicketCreateViewModel model)
        {
            TicketCreateModelServices newModel = new TicketCreateModelServices
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

        public TicketCreateViewModel ConvertTicketViewModel(TicketCreateModelServices model)
        {
            TicketCreateViewModel newModel = new TicketCreateViewModel
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

        public TicketDetailsModelServices ConvertTicketDetails(TicketDetailsViewModel model)
        {
            TicketDetailsModelServices newModel = new TicketDetailsModelServices
            {
                Id = model.Id,
                ProjectId = model.ProjectId,
                CreatedOn = model.CreatedOn,
                Creator = model.CreatorEmail,
                Type = model.Type,
                Heading = model.Heading,
                State = model.State,
                Description = model.Description,
                IsDeleted = model.SoftDleted,
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
                    SoftDeleted = m.IsDeleted
                }).ToList(),
            };

            return newModel;
        }

        public TicketDetailsViewModel ConvertTicketDetailsViewModel(TicketDetailsModelServices model)
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
                SoftDleted = model.IsDeleted,
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
                    IsDeleted = m.SoftDeleted
                }).ToList(),
            };

            return newModel;
        }
    }
}
