using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingSystem.Common
{
    public class DataConstants
    {
        //Application user constants
        public const int UserFirstNameMinLen = 2;
        public const int UserFirstNameMaxLen = 15;

        public const int UserLastNameMinLen = 2;
        public const int UserLastNameMaxLen = 15;

        //Project constants
        public const int ProjectNameMinLen = 3;
        public const int ProjectNameMaxLen = 20;

        public const int ProjectDescriptionMinLen = 10;
        public const int ProjectDescriptionMaxLen = 100;

        //Ticket constants
        public const int TicketHeadingMinLen = 3;
        public const int TicketHeadingMaxLen = 20;

        public const int TicketDescriptionMinLen = 10;
        public const int TicketDescriptionMaxLen = 100;

        //Message constants
        public const int MessageContentMinLen = 3;
        public const int MessageContentMaxLen = 20;
    }
}
