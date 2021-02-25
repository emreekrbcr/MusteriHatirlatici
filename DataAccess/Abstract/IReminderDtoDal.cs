using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.Abstract;
using Entities.Dtos;

namespace DataAccess.Abstract
{
    public interface IReminderDtoDal:IEntityRepository<ReminderDto>
    {
        List<ReminderDto> GetAllReminderDtosByDay(int dayInfo);
        List<ReminderDto> GetAllReminderDtosByDebt();
        List<ReminderDto> SortReminderDtosByDayByName(int dayInfo);
        List<ReminderDto> SortReminderDtosByDebtByName();
    }
}
