using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.AccessAdonet;
using Entities.Dtos;

namespace BusinessLogic.Concrete
{
    public class ReminderDtoManager:IReminderDtoService
    {
        private IReminderDtoDal _reminderDtoDal;

        //public ReminderDtoManager(IReminderDtoDal reminderDtoDal)
        //{
        //    _reminderDtoDal = reminderDtoDal;
        //}

        public ReminderDtoManager()
        {
            _reminderDtoDal=new AccessReminderDtoDal();
        }
        public List<ReminderDto> GetAllReminderDtosByDay(int dayInfo)
        {
            return _reminderDtoDal.GetAllReminderDtosByDay(dayInfo);
        }

        public List<ReminderDto> GetAllReminderDtosByDebt()
        {
            return _reminderDtoDal.GetAllReminderDtosByDebt();
        }

        public List<ReminderDto> SortReminderDtosByDayByName(int dayInfo)
        {
            return _reminderDtoDal.SortReminderDtosByDayByName(dayInfo);
        }

        public List<ReminderDto> SortReminderDtosByDebtByName()
        {
            return _reminderDtoDal.SortReminderDtosByDebtByName();
        }
    }
}
