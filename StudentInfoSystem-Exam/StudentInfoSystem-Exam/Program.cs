namespace StudentInfoSystem_Exam
{
    public class Program
    {
        public static readonly StudentInfoRepository _studInfoSystem = new();
        public static void Main()
        {
            var exitSystem = false;
            while (!exitSystem)
            {
                exitSystem = _studInfoSystem.MainWindow();
            }
        }
    }
}
