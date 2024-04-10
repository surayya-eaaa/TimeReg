using EmployeeTimeTracker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TimeReg
{
    /// <summary>
    /// Interaction logic for MainTimeRegWindow.xaml
    /// </summary>
    public partial class MainTimeRegWindow : Window
    {
        private readonly string PATH = "TimeRegistrations.csv";
        public MainTimeRegWindow()
        {
            InitializeComponent();
            List<TimeRegistrationModel> timeRegistrationModels = TimeRegistrationParser.CSVtoModel(PATH);
            TimeRegGridOverview.DataContext = timeRegistrationModels.ToList();
            TimeRegGridSummary.DataContext = summaryView(timeRegistrationModels);
        }

        private object summaryView(List<TimeRegistrationModel> timeRegistrationModels)
        {
           var query = (from t in timeRegistrationModels
                        group t by new { t.Name, t.Date }
                        into grp
                        select new
                        {
                             grp.Key.Name,
                             grp.Key.Date,
                             Hours = grp.Sum(t => t.Hours)
                        }).ToList();

            Console.WriteLine(query);
            return query;

        }
    }
}
