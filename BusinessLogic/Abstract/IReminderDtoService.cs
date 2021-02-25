using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Dtos;

namespace BusinessLogic.Abstract
{
    public interface IReminderDtoService
    {
        List<ReminderDto> GetAllReminderDtosByDay(int dayInfo);
        List<ReminderDto> GetAllReminderDtosByDebt();
        List<ReminderDto> SortReminderDtosByDayByName(int dayInfo);
        List<ReminderDto> SortReminderDtosByDebtByName();
    }
}
