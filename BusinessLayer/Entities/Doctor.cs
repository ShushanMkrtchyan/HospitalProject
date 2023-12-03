using BusinessLayer.ApiModels;
using BusinessLayer.EntityModels;
using DataAccessLayer.DBTools;
using DataAccessLayer.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusinessLayer.Entities
{
    public class Doctor : IErrMsg
    {
        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Profession { get; set; }
        public string? HospitalAddress { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }

        [JsonConvertable]
        public List<PatientM>? Patients { get; set; } 
        public string ErrMsg { get; set; }
        public long? StatusCode { get; set; }
        public int Status { get; set; }

        public uint? RowCount {  get; set; }

        
        public async Task<Doctor> AddAsync()
        {
            try
            {
                List<SPParam> par = new List<SPParam>
                {
                    new SPParam("FirstName",this.FirstName),
                    new SPParam("LastName",this.LastName),
                    new SPParam("Profession",this.Profession),
                    new SPParam("HospitalAddress",this.HospitalAddress),
                    new SPParam("Login",this.Login),
                    new SPParam("Password",this.Password)

                };
                Doctor item = await MySQLDataAccess<Doctor>.ExecuteSPItemAsync("AddDoctor", par);
                return item;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Func: Game.GetAsync, Ex:{ex.Message}");
                return null;
            }
            finally
            {
            }
        }
        public async Task<List<Doctor>> AddMultipleAsync(string json)
        {
            try
            {
                List<SPParam> par = new List<SPParam>
                {
                    new SPParam("jsitem",json)

                };
                List<Doctor> item = await MySQLDataAccess<Doctor>.ExecuteSPListAsync("AddMultipleDoctors",par);
                return item;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Func: Game.GetAsync, Ex:{ex.Message}");
                return null;
            }
            finally
            {
            }
        }

        public async Task<Doctor>AddDocsXpats()
        {
            try
            {
                List<SPParam> par = new List<SPParam>
                {
                    new SPParam("FirstName",this.FirstName),
                    new SPParam("LastName",this.LastName),
                    new SPParam("Profession",this.Profession),
                    new SPParam("HospitalAddress",this.HospitalAddress),
                    new SPParam("Login",this.Login),
                    new SPParam("Password",this.Password),
                    new SPParam("jsitem",Patients is not null? JsonConvert.SerializeObject(Patients): null)
                };
                Doctor item = await MySQLDataAccess<Doctor>.ExecuteSPItemAsync("ADDDocsPats", par);
                return item;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Func: Game.GetAsync, Ex:{ex.Message}");
                return null;
            }
            finally
            {
            }
        
        }

        public async Task<Doctor> GetLoginAsync()
        {
            try
            {
                List<SPParam> par = new List<SPParam>
                {
                    new SPParam("Login",this.Login),
                    new SPParam("Password",this.Password)

                };
                Doctor item = await MySQLDataAccess<Doctor>.ExecuteSPItemAsync("Login", par);
                return item;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Func: Game.GetListAsync, Ex:{ex.Message}");
                return null;
            }
            finally
            {
            }
        }

        public async Task<Doctor> UpdateAsync()
        {
            try
            {
                List<SPParam> list = new List<SPParam>
                {
                    new SPParam("ID",this.ID),
                    new SPParam("FirstName",this.FirstName),
                    new SPParam("LastName",this.LastName),
                    new SPParam("Profession",this.Profession),
                    new SPParam("HospitalAddress",this.HospitalAddress),
                    new SPParam("Login",this.Login),
                    new SPParam("Password",this.Password)
                };
                Doctor item = await MySQLDataAccess<Doctor>.ExecuteSPItemAsync("UpdateDoctor", list);
                return item;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Func: Game.GetAsync, Ex:{ex.Message}");
                return null;
            }
            finally
            {
            }
        }

        public async Task<Doctor> DeleteDoctorAsync()
        {
            try
            {
                List<SPParam> list = new List<SPParam>
                {
                    new SPParam("ID",this.ID),

                };
                Doctor item = await MySQLDataAccess<Doctor>.ExecuteSPItemAsync("DeleteDoctor", list);
                return item;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Func: Game.GetAsync, Ex:{ex.Message}");
                return null;
            }
            finally
            {
            }
        }



    }

}


