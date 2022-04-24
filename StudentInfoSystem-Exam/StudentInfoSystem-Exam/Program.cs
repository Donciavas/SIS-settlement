namespace StudentInfoSystem_Exam
{
    public class Program
    {
        public static readonly StudentInfoRepository _studentInfoSystem = new();
        public static void Main()
        {
            var exitSystem = false;
            while (!exitSystem)
            {
                exitSystem = _studentInfoSystem.MainWindow();
            }
        }
    }
}
