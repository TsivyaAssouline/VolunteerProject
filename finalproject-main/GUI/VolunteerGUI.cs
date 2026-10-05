using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;


namespace GUI
{
    public partial class Volunteer : Form
    {
        VolunteerBLL volunteerBLL = new VolunteerBLL();
        ServicBLL servicBLL = new ServicBLL();
        ServiceVolunteerBLL serviceVolunteerBLL = new ServiceVolunteerBLL();
        ArrangedRequestsBLL arrangedRequestsBLL = new ArrangedRequestsBLL();
        public Volunteer()
        {
            InitializeComponent();
          
        }
    
        //1
        public void ChechHoursBtn_Click(object sender, EventArgs e)
        {
            string id = txtIdEx1.Text.Trim();


            try
            {
                if (id.Length != 9) { throw new Exception("id must have 9 numbers"); }
                int resteHours = servicBLL.MonthlyHoursRemaining(id);
                MessageBox.Show($"שעות שנותרו החודש:{resteHours}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


        }
        //2
        public void mostHoursBtn_Click(object sender, EventArgs e)
        {
            ex7.Visible = !ex7.Visible;

            try
            {


                int id = int.Parse(txtId2.Text.Trim());
                List<VolunteerDTO> l = serviceVolunteerBLL.VolunteersHaveMostHoursToDonateLeft(id);
                if (l.Count == 0)
                {
                    MessageBox.Show("אין מתנדבים שנותרו להם שעות לתרום.");
                    return;
                }
                ex7.DataSource = l.Select(f => new { f.FullName, f.IdVolunteer, f.Phone }).ToList();
           

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


        }
        //3
        public void ex3Btn_Click(object sender, EventArgs e)
        {


            try
            {
                int id = int.Parse(txtIdServiceEx3.Text.Trim());

                int v, a;
                servicBLL.NumVolunteersForThisServiceAndApproved(id, out v, out a);
                MessageBox.Show($"בשרות זה יש {v} מתנדבים ו-{a} בקשות מאושרות השנה.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        //4
        public void Ex4Btn_Click(object sender, EventArgs e)
        {


            try
            {
                int idService = int.Parse(txtIdServiceEx4.Text.Trim());
                bool enoughHours = servicBLL.EnoughHoursDonated(idService);

                if (enoughHours)
                {
                    MessageBox.Show("יש מספיק שעות שנתרמו החודש לשירות זה.", "הצלחה");
                }
                else
                {
                    MessageBox.Show("אין מספיק שעות שנתרמו החודש לשירות זה.", "אזהרה");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה: " + ex.Message);
            }


        }
        //5
        public void ex5btn_Click(object sender, EventArgs e)
        {
            string id = txtEx5.Text.Trim();
            if ( id.Length != 9 || !id.All(char.IsDigit))
            {
                MessageBox.Show("שגיאה", "אנא הזיני תעודת זהות תקינה - 9 ספרות");
                return;
            }
            try
            {
                int numIdSVolunteerGive = servicBLL.howManyUniqueHelpDoVolunteerGive(id);
                MessageBox.Show($"המתנדב נותן {numIdSVolunteerGive} שירותים שאין מתנדבים אחרים שנותנים אותם.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה" + ex.Message);
            }
        }


        //6
        public void ex6btn_Click(object sender, EventArgs e)
        {
            string id = txtEx6.Text.Trim();

            if (id.Length != 9 || !id.All(char.IsDigit))
            {
                MessageBox.Show("אנא הזן תעודת זהות תקינה בת 9 ספרות.");
                return;
            }

            try
            {
                // Appel à la couche BLL
                List<NextVolunteeringDetailsDTO> results = arrangedRequestsBLL.getNextVolunteeringDetails(id);

                if (results.Count == 0)
                {
                    MessageBox.Show("אין בקשות עתידיות למתנדב זה.");
                }
                else
                {
                    // Construction du mssage
                    ex7.DataSource = results.Select(f => new { f.FullName, f.Address,f.NameService, f.Phone , f.RequestContent,f.DateRequest}).ToList();
                    ex7.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה: " + ex.Message);
            }
        }



        private void btn_getVolunteersHoursInfo_Click(object sender, EventArgs e)
        {
            string id = txtIdEx7.Text.Trim();
            if (id.Length != 9 || !id.All(char.IsDigit))
            {
                MessageBox.Show("אנא הזן תעודת זהות תקינה בת 9 ספרות.");
                return;
            }
            try
            {
                int hoursThisMonth;
                double averageLastMonth;
                volunteerBLL.GetVolunteerHoursInfo(id, out hoursThisMonth, out averageLastMonth);
                MessageBox.Show($"שעות החודש: {hoursThisMonth}, ממוצע לחודש שעבר: {averageLastMonth}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה: " + ex.Message);
            }


        }

        private void Volunteer_Load(object sender, EventArgs e)
        {

        }

        private void ex7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
