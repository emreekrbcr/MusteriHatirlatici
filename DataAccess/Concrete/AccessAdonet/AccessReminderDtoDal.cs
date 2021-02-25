using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.Concrete.AccessAdonet;
using DataAccess.Abstract;
using Entities.Dtos;

namespace DataAccess.Concrete.AccessAdonet
{
    public class AccessReminderDtoDal : AccessEntityRepositoryBase<ReminderDto>, IReminderDtoDal
    {
        public List<ReminderDto> GetAllReminderDtosByDay(int dayInfo)
        {
            OleDbCommand command = dbConnection.GetCommandAfterConCont(@"select Isim,Telefon,Adres,Aciklama,Islem,Borc,(HatirlatmaTarihi-Date()) as KalanGun from Musteriler inner join Islemler on Musteriler.MusteriID=Islemler.MusteriID where (HatirlatmaTarihi-Date())<=@p and (HatirlatmaTarihi-Date())>=0 order by (HatirlatmaTarihi-Date()),Borc desc");
            command.Parameters.AddWithValue("@p0", dayInfo);
            List<ReminderDto> reminderDtos=new List<ReminderDto>();
            ReminderDtosFiller(command,reminderDtos);
            command.Connection.Close();
            return reminderDtos;
        }
        public List<ReminderDto> GetAllReminderDtosByDebt()
        {
            OleDbCommand command = dbConnection.GetCommandAfterConCont(
                "select Isim,Telefon,Adres,Aciklama,Islem,Borc,(HatirlatmaTarihi-Date()) as KalanGun from Musteriler " +
                "inner join Islemler on Musteriler.MusteriID=Islemler.MusteriID where Borc>0 order by Borc desc,(HatirlatmaTarihi-Date())");
            List<ReminderDto> reminderDtos=new List<ReminderDto>();
            ReminderDtosFiller(command,reminderDtos);
            command.Connection.Close();
            return reminderDtos;
        }

        public List<ReminderDto> SortReminderDtosByDayByName(int dayInfo)
        {
            return GetAllReminderDtosByDay(dayInfo).OrderBy(r => r.Isim).ThenBy(r => r.KalanGun).ToList();
            //önce ada göre sıralasın sonra kalan güne göre sıralasın
        }

        public List<ReminderDto> SortReminderDtosByDebtByName()
        {
            return GetAllReminderDtosByDebt().OrderBy(r => r.Isim).ThenByDescending(r => r.Borc).ToList();
            //önce ada göre sıralasın sonra borca göre sıralasın
        }

        private static void ReminderDtosFiller(OleDbCommand command, List<ReminderDto> reminderDtos)
        {
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReminderDto reminderDto = new ReminderDto()
                {
                    Isim = Convert.ToString(reader["Isim"]),
                    Telefon = Convert.ToString(reader["Telefon"]),
                    Adres = Convert.ToString(reader["Adres"]),
                    Aciklama = Convert.ToString(reader["Aciklama"]),
                    Islem = Convert.ToString(reader["Islem"]),
                    Borc = Convert.ToDouble(reader["Borc"]),
                    KalanGun = Convert.ToInt32(reader["KalanGun"])
                };
                reminderDtos.Add(reminderDto);
            }
            reader.Close();
        }
    }
}