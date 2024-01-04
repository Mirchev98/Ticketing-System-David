namespace TicketingSystem.Data.Common
{
    public class DataConstants
    {
        //Seeded users accounts credentials
        public const string AdminEmail = "admin@admin.com";
        public const string Password = "12345a";
        public const string FirstNameAdmin = "Admin";
        public const string LastNameAdmin = "Adminov";

        public const string SupportEmail = "support@support.com";
        public const string FirstNameSupport = "Support";
        public const string LastNameSupport = "Supportov";

        public const string UserEmail = "user@user.com";
        public const string FirstNameUser = "User";
        public const string LastNameUser = "Userov";

        //Application user constants
        public const int UserFirstNameMinLen = 2;
        public const int UserFirstNameMaxLen = 15;

        public const int UserLastNameMinLen = 2;
        public const int UserLastNameMaxLen = 15;

        //Project constants
        public const int ProjectNameMinLen = 3;
        public const int ProjectNameMaxLen = 20;

        public const int ProjectDescriptionMinLen = 10;
        public const int ProjectDescriptionMaxLen = 500;

        //Ticket constants
        public const int TicketHeadingMinLen = 3;
        public const int TicketHeadingMaxLen = 20;

        public const int TicketDescriptionMinLen = 10;
        public const int TicketDescriptionMaxLen = 500;

        //Message constants
        public const int MessageContentMinLen = 3;
        public const int MessageContentMaxLen = 20;

        //Password constants
        public const int PassowordLenMin = 5;
        public const int PasswordLenMax = 15;

        //Roles
        public const string AdminRoleName = "Admin";
        public const string SupportRoleName = "Support";
    }
}
