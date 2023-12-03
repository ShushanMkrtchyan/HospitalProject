using BusinessLayer.ApiModels;
using BusinessLayer.EntityModels;
using DataAccessLayer.DBTools;
using DataAccessLayer.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Entities
{
    public class Room : IErrMsg
    {
        public int ID { get; set; }
        public int? RoomNumber { get; set; }
        public int? PatientCount { get; set; }

        [JsonConvertable]
        public List<PatientM> Patients { get; set; }
        public string ErrMsg { get; set; }

        public long? StatusCode { get; set; }

        public int Status { get; set; }


        
        public async Task<Room> AddAsync()
        {
            try
            {
                List<SPParam> par = new List<SPParam>
                {
                    new SPParam("RoomNumber",this.RoomNumber),
                    new SPParam("PatientCount",this.PatientCount)
                };
                Room item = await MySQLDataAccess<Room>.ExecuteSPItemAsync("AddRoom", par);
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

        public async Task<Room> AddRoomXpats()
        {
            try
            {
                List<SPParam> par = new List<SPParam>
                {
                    new SPParam("RoomNumber",this.RoomNumber),
                    new SPParam("PatientCount",this.PatientCount),
                    new SPParam("jsitem",Patients is not null? JsonConvert.SerializeObject(Patients): null)
                };
                Room item = await MySQLDataAccess<Room>.ExecuteSPItemAsync("AddRoomPats", par);
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
        public async Task<Room> UpdateAsync()
        {
            try
            {
                List<SPParam> par = new List<SPParam>
                {
                    new SPParam("ID",this.ID),
                    new SPParam("RoomNumber",this.RoomNumber),
                    new SPParam("PatientCount",this.PatientCount)
                };
                Room item = await MySQLDataAccess<Room>.ExecuteSPItemAsync("UpdateRoom", par);
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
        public async Task<Room> DeleteAsync()
        {
            try
            {
                List<SPParam> par = new List<SPParam>
                {
                    new SPParam ("ID",this.ID)

                };
                Room item = await MySQLDataAccess<Room>.ExecuteSPItemAsync("DeleteRoom", par);
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
