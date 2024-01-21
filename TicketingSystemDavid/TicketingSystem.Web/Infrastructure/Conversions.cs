using TicketingSystem.Services.Models.Message;
using TicketingSystem.Services.Models.Project;
using TicketingSystem.Services.Models.Ticket;
using TicketingSystemDavid.ViewModels.Message;
using TicketingSystemDavid.ViewModels.Project;
using TicketingSystemDavid.ViewModels.Ticket;

namespace TicketingSystem.Web.Infrastructure
{
    public static class Conversions
    {
        //Message Convert Methods

        public static MessageCreate ConvertMessage(MessageCreateView model)
        {
            MessageCreate newModel = new MessageCreate
            {
                Id = model.Id,
                State = (Services.Models.Message.MessageState)Enum.Parse(typeof(Services.Models.Message.MessageState), model.State.ToString()),
                Content = model.Content,
                CreatedOn = model.CreatedOn,
                TicketId = model.TicketId,
                CreatorId = model.CreatorId,
                CreatorName = model.CreatorName,
                File = model.File
            };

            return newModel;
        }

        public static MessageCreateView ConvertMessageViewModel(MessageCreate model)
        {
            MessageCreateView newModel = new MessageCreateView
            {
                Id = model.Id,
                State = (ViewModels.Message.MessageState)Enum.Parse(typeof(ViewModels.Message.MessageState), model.State.ToString()),
                Content = model.Content,
                TicketId = model.TicketId,
                CreatedOn = model.CreatedOn,
                CreatorId = model.CreatorId,
                CreatorName = model.CreatorName,
                File = model.File
            };

            return newModel;
        }

        //Project Convert Methods

        public static ProjectInformationView ConvertProjectAllViewModel(ProjectViewModelServices model)
        {
            ProjectInformationView newModel = new ProjectInformationView
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                TicketCount = model.TicketCount,
                SoftDleted = model.SoftDeleted
            };

            return newModel;
        }

        public static ProjectCreate ConvertProject(ProjectCreateView model)
        {
            ProjectCreate newModel = new ProjectCreate
            {
                Name = model.Name,
                Description = model.Description
            };

            return newModel;
        }

        public static FindProjectsResultView ConvertProjectAllViewModel(FindProjectsResult model)
        {
            FindProjectsResultView newModel = new FindProjectsResultView
            {
                TotalProjectsCount = model.TotalProjectsCount,
                Projects = model.Projects.Select(p => new ProjectInformationView
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

        public static ProjectDetailsView ConvertProjectDetailsViewModel(ProjectDetails model)
        {
            ProjectDetailsView newModel = new ProjectDetailsView
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                SoftDleted = model.IsDeleted,
                Tickets = model.Tickets.Select(t => new TicketDetailsView
                {
                    Id = t.Id,
                    ProjectId = t.ProjectId,
                    CreatedOn = t.CreatedOn,
                    CreatorName = t.CreatorName,
                    Type = t.Type,
                    Heading = t.Heading,
                    State = t.State,
                    Description = t.Description,
                    SoftDleted = t.SoftDeleted,
                    Messages = t.Messages.Select(m => new MessageDetailsView
                    {
                        Id = m.Id,
                        State = (ViewModels.Message.MessageState)Enum.Parse(typeof(ViewModels.Message.MessageState), m.State.ToString()),
                        Content = m.Content,
                        CreatorName = m.CreatorName,
                        TicketId = m.TicketId,
                        IsDeleted = m.SoftDeleted
                    }).ToList(),
                }).ToList()
            };

            return newModel;
        }

        //Ticket Convert Methods

        public static TicketCreate ConvertTicket(TicketCreateView model)
        {
            TicketCreate newModel = new TicketCreate
            {
                Id = model.Id,
                ProjectId = model.ProjectId,
                CreatorName = model.CreatorName,
                CreatorId = model.CreatorId,
                Type = (Services.Models.Ticket.TicketCategory)Enum.Parse(typeof(Services.Models.Ticket.TicketCategory), model.Type.ToString()),
                Heading = model.Heading,
                State = (Services.Models.Ticket.TicketState)Enum.Parse(typeof(Services.Models.Ticket.TicketState), model.State.ToString()),
                Description = model.Description,
                File = model.File
            };

            return newModel;
        }

        public static TicketCreateView ConvertTicketViewModel(TicketCreate model)
        {
            TicketCreateView newModel = new TicketCreateView
            {
                Id = model.Id,
                ProjectId = model.ProjectId,
                CreatorName = model.CreatorName,
                CreatorId = model.CreatorId,
                Type = (ViewModels.Ticket.TicketCategory)Enum.Parse(typeof(ViewModels.Ticket.TicketCategory), model.Type.ToString()),
                Heading = model.Heading,
                State = (ViewModels.Ticket.TicketState)Enum.Parse(typeof(ViewModels.Ticket.TicketState), model.State.ToString()),
                Description = model.Description,
                File = model.File
            };

            return newModel;
        }

        public static TicketDetails ConvertTicketDetails(TicketDetailsView model)
        {
            TicketDetails newModel = new TicketDetails
            {
                Id = model.Id,
                ProjectId = model.ProjectId,
                CreatedOn = model.CreatedOn,
                CreatorName = model.CreatorName,
                CreatorId = model.CreatorId,
                Type = model.Type,
                Heading = model.Heading,
                State = model.State,
                Description = model.Description,
                SoftDeleted = model.SoftDleted,
                File = model.File,
                Messages = model.Messages.Select(m => new MessageDetails
                {
                    Id = m.Id,
                    State = (Services.Models.Message.MessageState)Enum.Parse(typeof(Services.Models.Message.MessageState), model.State.ToString()),
                    Content = m.Content,
                    CreatorName = m.CreatorName,
                    CreatorId = model.CreatorId,
                    TicketId = m.TicketId,
                    File = m.File,
                    SoftDeleted = m.IsDeleted
                }).ToList(),
            };

            return newModel;
        }

        public static TicketDetailsView ConvertTicketDetailsViewModel(TicketDetails model)
        {
            TicketDetailsView newModel = new TicketDetailsView
            {
                Id = model.Id,
                ProjectId = model.ProjectId,
                CreatedOn = model.CreatedOn,
                CreatorName = model.CreatorName,
                CreatorId = model.CreatorId,
                Type = model.Type,
                Heading = model.Heading,
                State = model.State,
                Description = model.Description,
                SoftDleted = model.SoftDeleted,
                File = model.File,
                Messages = model.Messages.Select(m => new MessageDetailsView
                {
                    Id = m.Id,
                    State = (ViewModels.Message.MessageState)Enum.Parse(typeof(ViewModels.Message.MessageState), m.State.ToString()),
                    Content = m.Content,
                    CreatorName = m.CreatorName,
                    CreatorId = model.CreatorId,
                    TicketId = m.TicketId,
                    File = m.File,
                    IsDeleted = m.SoftDeleted
                }).ToList(),
            };

            return newModel;
        }
    }
}
