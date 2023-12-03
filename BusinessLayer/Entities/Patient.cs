using DataAccessLayer.DBTools;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Entities
{
    public class Patient : IErrMsg
    {
        public int ID { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int? RoomID { get; set; }

        public int DoctorID { get; set; }

        public DateTime? TreatStartDate { get; set; }

        public DateTime? TreatEndDate { get; set; }
      
        public string? ErrMsg { get; set; }

        public long? StatusCode {  get; set; }

        public int Status { get; set; }

        public uint? RowCount { get; set; } 


        public async Task<Patient> AddAsync()
        {
            try
            {
                List<SPParam> par = new List<SPParam>
                {
                    new SPParam("FirstName",this.FirstName),
                    new SPParam("LastName",this.LastName),
                    new SPParam("RoomID",this.RoomID),
                    new SPParam("DoctorID",this.DoctorID),
                    new SPParam("TreatStartDate",this.TreatStartDate),
                    new SPParam("TreatEndDate",this.TreatEndDate)

                };
                Patient item = await MySQLDataAccess<Patient>.ExecuteSPItemAsync("AddPatient", par);
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

        public async Task<Patient> UpdateAsync()
        {
            try
            {
                List<SPParam> list = new List<SPParam>
                {
                    new SPParam("ID",this.ID),
                    new SPParam("FirstName",this.FirstName),
                    new SPParam("LastName",this.LastName),
                    new SPParam("RoomID",this.RoomID),
                    new SPParam("DoctorID",this.DoctorID),
                    new SPParam("TreatStartDate",this.TreatStartDate),
                    new SPParam("TreatEndDate",this.TreatEndDate)
                };
                Patient item = await MySQLDataAccess<Patient>.ExecuteSPItemAsync("UpdatePatient", list);
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

        public async Task<Patient> DeleteAsync()
        {
            try
            {
                List<SPParam> list = new List<SPParam>
                {
                    new SPParam("ID",this.ID)

                };

                Patient item = await MySQLDataAccess<Patient>.ExecuteSPItemAsync("DeletePatient", list);
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
