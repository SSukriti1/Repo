using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using CRUD.Models;

namespace CRUD.Controllers
{
   
    static class a
    {
        static void doSomething() { }

        static int PaCa = 5;


        }
    class B
    {
      
        class my_class {}
        class SOMEName42 {}
      
    }
  

    public class EmployeeController : Controller
    {
        string connectionString = @"Data Source = (localdb)\projects; Initial Catalog = CrudDB; Integrated Security=True";
        [HttpGet]



        public void XM()
        {
            Console.WriteLine("hello");
        }

        public void Xyz(int WrongPara)
        {

        }

        public ActionResult Index()
        {
            ;
            DataTable dtblEmployee = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Employee", sqlCon);
                sqlDa.Fill(dtblEmployee);
            }
            return View(dtblEmployee);
        }

        public void doSomething() {}

        [HttpGet]
        public ActionResult create()
        {
            return View(new EmployeeModel());
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(EmployeeModel employeeModel)
        {
            //declaring object of class sqlconnection//
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                //initiallizing sqlcon object using sql function


                /*sqlCon.Open();
                string query = "INSERT INTO Employee VALUES (@DeptName,@EmployeeName,@Salary)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@DeptName", employeeModel.DeptName);
                sqlCmd.Parameters.AddWithValue("@EmployeeName", employeeModel.EmployeeName);
                sqlCmd.Parameters.AddWithValue("@Salary", employeeModel.Salary);
                sqlCmd.ExecuteNonQuery(); */

                //closing sqlCon
               
                sqlCon.Open();
                string query = "INSERT INTO Employee VALUES (@DeptName,@EmployeeName,@Salary)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@DeptName", employeeModel.DeptName);
                sqlCmd.Parameters.AddWithValue("@EmployeeName", employeeModel.EmployeeName);
                sqlCmd.Parameters.AddWithValue("@Salary", employeeModel.Salary);
                sqlCmd.ExecuteNonQuery();


            }
            // redirecting to edit 

            return RedirectToAction("Index");
        }


        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            EmployeeModel employeeModel = new EmployeeModel();
            DataTable dtblEmployee = new DataTable();
            using (SqlConnection SqlCon = new SqlConnection(connectionString))
            {
                //
                SqlCon.Open();
                string query = "SELECT * FROM Employee Where EmpID=@EmpID";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, SqlCon);
                sqlDa.SelectCommand.Parameters.AddWithValue("@EmpID", id);
                sqlDa.Fill(dtblEmployee);
            }
            if (dtblEmployee.Rows.Count == 1)
            {
                employeeModel.EmpID = Convert.ToInt32(dtblEmployee.Rows[0][0].ToString());
                employeeModel.DeptName = dtblEmployee.Rows[0][1].ToString();
                employeeModel.EmployeeName = dtblEmployee.Rows[0][2].ToString();
                employeeModel.Salary = Convert.ToDecimal(dtblEmployee.Rows[0][3].ToString());
                return View(employeeModel);
            }
            else
                return RedirectToAction("Index");
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Edit(EmployeeModel employeeModel)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {    
                //
                sqlCon.Open();
                string query = "UPDATE Employee SET DeptName=@DeptName ,EmployeeName=@EmployeeName, Salary=@Salary Where EmpID= @EmpID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@EmpID", employeeModel.EmpID);
                sqlCmd.Parameters.AddWithValue("@DeptName", employeeModel.DeptName);
                sqlCmd.Parameters.AddWithValue("@EmployeeName", employeeModel.EmployeeName);
                sqlCmd.Parameters.AddWithValue("@Salary", employeeModel.Salary);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
        sqlCon.Open();
        string query = "DELETE FROM Employee Where EmpID= @EmpID";
        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
        sqlCmd.Parameters.AddWithValue("@EmpID", id);
        sqlCmd.ExecuteNonQuery();
        }
        return RedirectToAction("Index");
        }
    }
}

