using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraScheduler;

namespace WindowsApplication1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            AppointmentCustomFieldMapping unique = new AppointmentCustomFieldMapping("UniqueID", "UniqueID");
            this.schedulerStorage1.Appointments.CustomFieldMappings.Add(unique);
            Appointment apt;
            for (int i = 0; i <  50; i++) {
                apt = this.schedulerStorage1.CreateAppointment(AppointmentType.Normal);
                apt.Start = DateTime.Today.Date.AddDays(i);
                apt.Subject = "test appointment " + i.ToString();
                apt.CustomFields["UniqueID"] = i;
                this.schedulerStorage1.Appointments.Add(apt);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e) {
            AppointmentBaseCollection aptToSelect = new AppointmentBaseCollection();
            Appointment found = this.schedulerStorage1.Appointments.Items.Find(delegate(Appointment apt) {return Convert.ToInt32(apt.CustomFields["UniqueID"]) == 5;});
            if (found != null) {
                MessageBox.Show("Appointment found!");
                this.schedulerControl1.SelectedAppointments.Clear();
                this.schedulerControl1.ActiveView.SelectAppointment(found);
            }

        }
    }
}