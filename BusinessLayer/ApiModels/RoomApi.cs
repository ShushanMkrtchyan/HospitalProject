using BusinessLayer.Entities;
using BusinessLayer.EntityModels;
using DataAccessLayer.DBTools;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ApiModels
{
    public class RoomApi:IErrMsg
    {
        public int ID { get; set; }
        public int? RoomNumber { get; set; }
        public int? PatientCount { get; set; }

        [JsonConvertable]
        public List<PatientM>? Patients { get; set; }

        public string ErrMsg { get; set; }

        public uint? RowCount;


        public async Task<RoomApi> GetByID(int ID)
        {
            try
            {
                List<SPParam> par = new List<SPParam>
                {
                    new SPParam("ID",ID)
                };
                RoomApi room = await MySQLDataAccess<RoomApi>.ExecuteSPItemAsync("GetRoomByID", par);
                return room;
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

        public async Task<(List<RoomApi>,uint?)> GetListAsync(int startIndex, int viewCount)
        {
            try
            {
                List<SPParam> par = new List<SPParam>
                {
                    new SPParam("startIndex",startIndex),
                    new SPParam("viewCount",viewCount)

                };
                List<RoomApi> list = new List<RoomApi>();

                (list, RowCount) = await MySQLDataAccess<RoomApi>.ExecuteSPListByPagingAsync("GetRooms",par);
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
