using BusinessLayer.Entities;
using BusinessLayer.EntityModels;
using DataAccessLayer.DBTools;
using DataAccessLayer.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ApiModels
{
    public class DoctorApi : IErrMsg
    {
        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Profession { get; set; }
        public string? HospitalAddress { get; set; }

        [JsonConvertable]
        public List<PatientM>? Patients { get; set; } 

        public uint? RowCount { get; set; }
        public string ErrMsg { get; set; }



        public async Task<DoctorApi> GetByID(int ID)
        {
            try
            {
                List<SPParam> par = new List<SPParam>
                {
                    new SPParam("ID", ID)
                };
                DoctorApi doc = await MySQLDataAccess<DoctorApi>.ExecuteSPItemAsync("GetDocByID", par);
                return doc;
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


        public async Task<List<DoctorApi>> GetListAsync(int startIndex, int viewCount)
        {
            try
            {
                List<SPParam> par = new List<SPParam>
                {
                    new SPParam("startIndex", startIndex),
                    new SPParam("viewCount", viewCount)

                };

                List<DoctorApi> list = new List<DoctorApi>();

                (list, RowCount) = await MySQLDataAccess<DoctorApi>.ExecuteSPListByPagingAsync("GETDoctors", par);
                return list;
            
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Func: Game.GetListAsync, Ex:{ex.Message}");
                return (null);
            }
            finally
            {
            }
        }
    }
}
