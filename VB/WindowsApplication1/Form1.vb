Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraScheduler

Namespace WindowsApplication1
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			Dim unique As New AppointmentCustomFieldMapping("UniqueID", "UniqueID")
			Me.schedulerStorage1.Appointments.CustomFieldMappings.Add(unique)
			Dim apt As Appointment
			For i As Integer = 0 To 49
				apt = Me.schedulerStorage1.CreateAppointment(AppointmentType.Normal)
				apt.Start = DateTime.Today.Date.AddDays(i)
				apt.Subject = "test appointment " & i.ToString()
				apt.CustomFields("UniqueID") = i
				Me.schedulerStorage1.Appointments.Add(apt)
			Next i
		End Sub

		Private Sub simpleButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton1.Click
			Dim aptToSelect As New AppointmentBaseCollection()
            Dim found As Appointment = Me.schedulerStorage1.Appointments.Items.Find(AddressOf FindAppointment)
			If found IsNot Nothing Then
				MessageBox.Show("Appointment found!")
				Me.schedulerControl1.SelectedAppointments.Clear()
				Me.schedulerControl1.ActiveView.SelectAppointment(found)
			End If

		End Sub

        Private Function FindAppointment(ByVal apt As Appointment) As Boolean
            Return Convert.ToInt32(apt.CustomFields("UniqueID")) = 5
        End Function
	End Class
End Namespace