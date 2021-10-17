using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Model
{
    // Employee model (just for better communication with front end)
    public class EmployeeFRONTEND
    {
        public int Id_Employee { get; set; }                    // Id of the employee
        public string First_Name_Employee { get; set; }         // First name of the employee
        public string Second_Name_Employee { get; set; }        // Second name of the emlpoyee
        public string First_Last_Name_Employee { get; set; }    // First last name of the employee
        public string Second_Last_Name_Employee { get; set; }   // Second last name of the employee
        public string Phone_Employee { get; set; }              // Phone number of the employee
        [DataType(DataType.Date)]
        public DateTime Birth_Date_Employee { get; set; }       // Birth date of the employee
        [DataType(DataType.Date)]
        public DateTime Admission_Date_Employee { get; set; }   // Admission date of the employee
        public string Password_Employee { get; set; }           // Password of the employee
        public string User_Employee { get; set; }               // User of the employee
        public string Id_Branch_Employee { get; set; }          // Name of the branch
        public string Id_Rol_Employee { get; set; }             // Name of the rol
    }
}