using System;
using ManagementSystemWPFApp;
using LoadImages;

namespace LoadImagesConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i = 1;
            string dirPath = "";

            try
            {
                foreach (var m in KingITEntities.GetContext().Malls)
                {
                    dirPath = $"C:\\Users\\Тимофей\\Desktop\\KingIT Management System\\ImagesMalls\\Picture ({i}).jpg";
                    m.MallPicture = ImageLoader.LoadImage(dirPath);
                    i++;
                }

                i = 1;
                foreach (var e in KingITEntities.GetContext().Employees)
                {
                    dirPath = $"C:\\Users\\Тимофей\\Desktop\\KingIT Management System\\ImagesEmp\\emp ({i}).jpg";
                    e.EmployeePhoto = ImageLoader.LoadImage(dirPath);
                    i++;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

            try
            {
                KingITEntities.GetContext().SaveChanges();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
