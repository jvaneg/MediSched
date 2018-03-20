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

namespace P3
{
    /// <summary>
    /// Interaction logic for MonthDayBoxControl.xaml
    /// </summary>
    public partial class MonthDayBoxControl : UserControl
    {
        public MonthDayBoxControl()
        {
            InitializeComponent();
        }

        public MonthDayBoxControl(int day, int slots, string boxText)
        {
            InitializeComponent();

            this.dayNumber.Text = day.ToString();
            this.FreeSlotNum.Text = slots.ToString();
            this.SlotsTxt.Text = boxText;
            if(slots != 1)
            {
                this.SlotsTxt.Text += "s";
            }
        }

        private void OnMouseEnter(object sender, MouseEventArgs e)
        {
            VisualStateManager.GoToState(this, "MouseOver", true);
        }

        private void OnMouseLeave(object sender, MouseEventArgs e)
        {
            VisualStateManager.GoToState(this, "Normal", true);
        }
    }
}
