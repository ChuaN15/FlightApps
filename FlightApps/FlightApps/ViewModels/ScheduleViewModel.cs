using FlightApps.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FlightApps.ViewModels
{
    public class ScheduleViewModel : BaseViewModel
    {
        private ObservableCollection<Schedule> scheduleList;
        public ObservableCollection<Schedule> ScheduleList
        {
            get => scheduleList;
            set => SetProperty(ref scheduleList, value);
        }

        public ScheduleViewModel()
        {

        }
    }
}
