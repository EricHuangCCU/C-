using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        
        private Dictionary<string, List<string>> totalEvents= new Dictionary<string, List<string>>() { };
            
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show("Please enter a valid event.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime selectedDate = monthCalendar1.SelectionStart.Date;
            string selectedDateString = $"{selectedDate:yyyy-MM-dd}";

            if (!totalEvents.TryGetValue(selectedDateString, out List<string> events))
            {
                events = new List<string>();
                totalEvents[selectedDateString] = events;
            }

            events.Add(text);

            checkedListBox1.Items.Add(text);
            textBox1.Clear();


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            UpdateEventList();

            DateTime selectedDate = monthCalendar1.SelectionStart.Date;
            string selectedDateString = $"{selectedDate:yyyy-MM-dd}";

            textBox2.Text = "目前選取日期: " + selectedDateString;

        }

        private void UpdateEventList()
        {
            DateTime selectedDate = monthCalendar1.SelectionStart.Date;
            string selectedDateString = $"{selectedDate:yyyy-MM-dd}";

            if (totalEvents.TryGetValue(selectedDateString, out List<string> events))
            {
                checkedListBox1.Items.Clear();
                foreach (var item in events)
                {
                    checkedListBox1.Items.Add(item);
                }
            }
            else
            {
                checkedListBox1.Items.Clear();
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
