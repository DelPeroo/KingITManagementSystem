using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.Entity;

namespace RentPavilionUnitTest
{
    [TestClass]
    public class RentPavilionTest
    {
        [TestMethod]
        public void RentPavilionSuccess()
        {
            int TenantId = 1;
            int EmployeeId = 2;
            int PavilionId = 12;
            DateTime LeaseStart = DateTime.Now;
            DateTime LeaseEnd = DateTime.Now.AddYears(1);
            bool isTestPassed = true;

            using (var dbContext = new PavilionsDbEntities())
            {
                try
                {
                    System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@TenantId", TenantId);
                    System.Data.SqlClient.SqlParameter param1 = new System.Data.SqlClient.SqlParameter("@EmpId", EmployeeId);
                    System.Data.SqlClient.SqlParameter param2 = new System.Data.SqlClient.SqlParameter("@PavilionId", PavilionId);
                    System.Data.SqlClient.SqlParameter param3 = new System.Data.SqlClient.SqlParameter("@LeaseStart", LeaseStart);
                    System.Data.SqlClient.SqlParameter param4 = new System.Data.SqlClient.SqlParameter("@LeaseEnd", LeaseEnd);

                    System.Data.SqlClient.SqlParameter[] sqlParameters = { param2, param3, param4, param, param1 };

                    dbContext.Database.ExecuteSqlCommand("EXEC RentPavilion @PavilionId, @LeaseStart, @LeaseEnd, @TenantId, @EmpId", sqlParameters);
                }
                catch(Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    isTestPassed = false;
                }

                Assert.IsTrue(isTestPassed);
            }
        }

        [TestMethod]
        public void RentPavilionFail()
        {
            int TenantId = 1;
            int EmployeeId = 2;
            int PavilionId = 1;
            DateTime LeaseStart = DateTime.Now;
            DateTime LeaseEnd = DateTime.Now.AddYears(1);
            bool isTestPassed = true;

            using (var dbContext = new PavilionsDbEntities())
            {
                try
                {
                    System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@TenantId", TenantId);
                    System.Data.SqlClient.SqlParameter param1 = new System.Data.SqlClient.SqlParameter("@EmpId", EmployeeId);
                    System.Data.SqlClient.SqlParameter param2 = new System.Data.SqlClient.SqlParameter("@PavilionId", PavilionId);
                    System.Data.SqlClient.SqlParameter param3 = new System.Data.SqlClient.SqlParameter("@LeaseStart", LeaseStart);
                    System.Data.SqlClient.SqlParameter param4 = new System.Data.SqlClient.SqlParameter("@LeaseEnd", LeaseEnd);

                    System.Data.SqlClient.SqlParameter[] sqlParameters = { param2, param3, param4, param, param1 };

                    dbContext.Database.ExecuteSqlCommand("EXEC RentPavilion @PavilionId, @LeaseStart, @LeaseEnd, @TenantId, @EmpId", sqlParameters);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    isTestPassed = false;
                }

                Assert.IsFalse(isTestPassed);
            }
        }
    }
}
