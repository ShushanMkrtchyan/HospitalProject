using BusinessLayer.Entities;
using DataAccessLayer.DBTools;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ApiModels
{
    public class PatientApi : IErrMsg
    {
        public int? ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        //public int? RoomID {  get; set; }

        [JsonConvertable]
        public RoomApi? Room { get; set; }

        //public int? DoctorID { get; set; }

        [JsonConvertable]
        public DoctorApi? Doctor { get; set; }

        public DateTime? TreatStartDate { get; set; }
        public DateTime? TreatEndDate { get; set; }
        public string? ErrMsg { get; set; }

        public uint? RowCount;

        public async Task<PatientApi> GetAsyncID(int ID)
        {
            try
            {
                List<SPParam> par = new List<SPParam>
                {
                     new SPParam("ID",ID)
                };

                PatientApi pat = await MySQLDataAccess<PatientApi>.ExecuteSPItemAsync("GetPatByID", par);
                return pat;
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

        public async Task<(List<PatientApi>,uint?)> GetListAsync(int startIndex, int viewCount)
        {
            try
            {
                List<SPParam> par = new List<SPParam>
                {
                    new SPParam("startIndex",startIndex),
                    new SPParam("viewCount",viewCount)

                };
                List<PatientApi> list = new List<PatientApi>();


                (list, RowCount) = await MySQLDataAccess<PatientApi>.ExecuteSPListByPagingAsync("GetPatients",par);
                return (list,RowCount);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Func: Game.GetListAsync, Ex:{ex.Message}");
                return (null,null);
            }
            finally
            {
            }
        }

    }
}
