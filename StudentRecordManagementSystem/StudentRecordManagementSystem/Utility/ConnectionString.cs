namespace StudentRecordManagementSystem.Utility
{
    public class ConnectionString
    {
        private static string cName = "Data Source=KAMLESH\\SQLEXPRESS; Initial Catalog=StudentManagement;User ID=sa;Password=12345678";
        public static string CName
        {
            get => cName;
        }
    }
}
