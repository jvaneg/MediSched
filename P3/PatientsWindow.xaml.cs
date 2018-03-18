﻿using System;
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
using System.Windows.Shapes;
using System.Collections.ObjectModel;
namespace P3
{
    /// <summary>
    /// Interaction logic for PatientInfo.xaml
    /// </summary>
    public partial class PatientsWindow : Window
    {
        public PatientsWindow()
        {
            InitializeComponent();
        }


        ObservableCollection<Patient> lstPatient = new ObservableCollection<Patient>();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            lstPatient.Add(new Patient() { PatientNo = 1001, PatientName = "Mahesh" });
            lstPatient.Add(new Patient() { PatientNo = 1002, PatientName = "Amit" });
            lstPatient.Add(new Patient() { PatientNo = 1003, PatientName = "Vaibhav" });
            lstPatient.Add(new Patient() { PatientNo = 1004, PatientName = "Ashwin" });
            lstPatient.Add(new Patient() { PatientNo = 1005, PatientName = "Prashant" });
            lstPatient.Add(new Patient() { PatientNo = 1006, PatientName = "Vinit" });
            lstPatient.Add(new Patient() { PatientNo = 1007, PatientName = "Abhijit" });
            lstPatient.Add(new Patient() { PatientNo = 1008, PatientName = "Pankaj" });
            lstPatient.Add(new Patient() { PatientNo = 1009, PatientName = "Kaustubh" });
            lstPatient.Add(new Patient() { PatientNo = 1010, PatientName = "Mohan" });


            lstPatientData.ItemsSource = lstPatient;

        }

        private void txtNameToSearch_TextChanged(object sender,TextChangedEventArgs e)
        {
            /*
             *    string txtOrig = txtNameToSearch.Text;
               string upper = txtOrig.ToUpper();
               string lower = txtOrig.ToLower();

               var patientFiltered = from Patient in lstPatient let ename = Patient.PatientName
                                 where ename.StartsWith(lower) || ename.StartsWith(upper) || ename.Contains(txtOrig)
                                 select Patient;

               lstPatientData.ItemsSource = patientFiltered;

           */
            string txtOrig = txtNameToSearch.Text;
            string upper = txtOrig.ToUpper();
            string lower = txtOrig.ToLower();
            

            var patientFiltered = from Patient in lstPatient
                                  let pname = Patient.PatientName
                                  where
                                  pname.StartsWith(lower)
                                  || pname.StartsWith(upper)
                                  || pname.Contains(txtOrig)
                                  select Patient;

            lstPatientData.ItemsSource = patientFiltered;

        }
    }
}
