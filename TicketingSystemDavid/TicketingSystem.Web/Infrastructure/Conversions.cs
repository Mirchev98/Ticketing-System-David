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

        public CreateMessage ConvertMessage(MessageCreateViewModel model)
        {
            CreateMessage newModel = new CreateMessage
            {
                Id = model.Id,
                State = (Services.Models.Message.MessageState)Enum.Parse(typeof(Services.Models.Message.MessageState), model.State.ToString()),
                Content = model.Content,
                CreatedOn = model.CreatedOn,
                TicketId = model.TicketId,
                FileContent = model.FileContent,
                ContentType = model.ContentType,
                FileName = model.FileName,
            };

            return newModel;
        }

        public MessageCreateViewModel ConvertMessageViewModel(CreateMessage model)
        {
            MessageCreateViewModel newModel = new MessageCreateViewModel
            {
                Id = model.Id,
                State = (ViewModels.Message.MessageState)Enum.Parse(typeof(ViewModels.Message.MessageState), model.State.ToString()),
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

        public ProjectViewModel ConvertProjectAllViewModel(ProjectViewModelServices model)
        {
            ProjectViewModel newModel = new ProjectViewModel
            {
                Id = model.Id,
                Description = model.Description,
                TicketCount = model.TicketCount,
                SoftDleted = model.SoftDeleted
            };

            return newModel;
        }

        public ProjectCreate ConvertProject(ProjectCreateViewModel model)
        {
            ProjectCreate newModel = new ProjectCreate
            {
                Name = model.Name,
                Description = model.Description
            };

            return newModel;
        }

        public FindProjectsResultViewModel ConvertProjectAllViewModel(FindProjectsResult model)
        {
            FindProjectsResultViewModel newModel = new FindProjectsResultViewModel
            {
                TotalProjectsCount = model.TotalProjectsCount,
                Projects = model.Projects.Select(p => new ProjectViewModel
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

        public ProjectDetailsViewModel ConvertProjectDetailsViewModel(ProjectDetails model)
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
                        State = (ViewModels.Message.MessageState)Enum.Parse(typeof(ViewModels.Message.MessageState), m.State.ToString()),
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

        public TicketCreate ConvertTicket(TicketCreateViewModel model)
        {
            TicketCreate newModel = new TicketCreate
            {
                Id = model.Id,
                ProjectId = model.ProjectId,
                Creator = model.Creator,
                Type = (Services.Models.Ticket.TicketCategory)Enum.Parse(typeof(Services.Models.Ticket.TicketCategory), model.Type.ToString()),
                Heading = model.Heading,
                State = (Services.Models.Ticket.TicketState)Enum.Parse(typeof(Services.Models.Ticket.TicketState), model.State.ToString()),
                Description = model.Description,
                FileName = model.FileName,
                FileContent = model.FileContent,
                ContentType = model.ContentType
            };

            return newModel;
        }

        public TicketCreateViewModel ConvertTicketViewModel(TicketCreate model)
        {
            TicketCreateViewModel newModel = new TicketCreateViewModel
            {
                Id = model.Id,
                ProjectId = model.ProjectId,
                Creator = model.Creator,
                Type = (ViewModels.Ticket.TicketCategory)Enum.Parse(typeof(ViewModels.Ticket.TicketCategory), model.Type.ToString()),
                Heading = model.Heading,
                State = (ViewModels.Ticket.TicketState)Enum.Parse(typeof(ViewModels.Ticket.TicketState), model.State.ToString()),
                Description = model.Description,
                FileName = model.FileName,
                FileContent = model.FileContent,
                ContentType = model.ContentType
            };

            return newModel;
        }

        public TicketDetails ConvertTicketDetails(TicketDetailsViewModel model)
        {
            TicketDetails newModel = new TicketDetails
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
                Messages = model.Messages.Select(m => new MessageDetails
                {
                    Id = m.Id,
                    State = (Services.Models.Message.MessageState)Enum.Parse(typeof(Services.Models.Message.MessageState), model.State.ToString()),
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

        public TicketDetailsViewModel ConvertTicketDetailsViewModel(TicketDetails model)
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
                    State = (ViewModels.Message.MessageState)Enum.Parse(typeof(ViewModels.Message.MessageState), model.State.ToString()),
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
