﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BethesdaMVCEConsentForms.Models
{
    public class PatientConsentMain
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Employee ID")]
        public string EmployeeId { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Error")]
        public string ErrorInfo { get; set; }

        [Display(Name = "Patients List")]
        public SelectList PatientsList { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "SelectedPatientID")]
        public string SelectedPatientID { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Patient Name")]
        public string PatientName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Patient#")]
        public string PatientHash { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Patient Age")]
        public string PatientAge { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "PatientMR#")]
        public string PatientMRHash { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Attending Physician")]
        public string AttendingPhysician { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Admission Date")]
        public string AdmissionDate { get; set; }

        [Display(Name = "Consent Form List")]
        public SelectList ConsentFormList { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "ConsentForm Selected ID")]
        public string ConsentFormSelectedID { get; set; }
    }
}