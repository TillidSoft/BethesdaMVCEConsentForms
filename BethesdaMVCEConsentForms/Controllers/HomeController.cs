using System.Data;
using System.Web.Mvc;
using BethesdaMVCEConsentForms.EConsentServices;
using BethesdaMVCEConsentForms.Models;

namespace BethesdaMVCEConsentForms.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var patientConsentMain = new PatientConsentMain();
            patientConsentMain.PatientsList = new SelectList(new string[0]);
            patientConsentMain.ConsentFormList = new SelectList(new string[0]);
            return View(patientConsentMain);
        }

        [HttpPost]
        public ActionResult PatientConsent(PatientConsentMain patientConsentMain)
        {
            LoadPatients(Request.Form["RdoLocation"]);
            if (!string.IsNullOrEmpty(patientConsentMain.EmployeeId))
            {
                var consentFormSvcClient = new ConsentFormSvcClient();
                if (consentFormSvcClient.IsValidEmployee(patientConsentMain.EmployeeId))
                {
                    ViewBag.Loggedin = true;
                    var patientDetails = consentFormSvcClient.GetPatientfromLocation(patientConsentMain.BHELocation ? "BHE" : "BHW");
                    foreach (DataRow patientDetail in patientDetails.Rows)
                    {
                    }
                    if (string.IsNullOrEmpty(patientConsentMain.SelectedPatientID))
                    {
                    }
                }
                else
                {
                    patientConsentMain.ErrorInfo = "Invalid employee id entered!";
                    ResetIndexView(patientConsentMain);
                }
            }
            patientConsentMain.PatientsList = new SelectList(new string[0]);
            patientConsentMain.ConsentFormList = new SelectList(new string[0]);
            return View("Index", patientConsentMain);
        }

        private void LoadPatients(string patientLocation)
        {
            if (!string.IsNullOrEmpty(patientLocation))
            {
                var consentFormSvcClient = new ConsentFormSvcClient();
                ViewBag.Patients = consentFormSvcClient.GetPatientfromLocation(patientLocation).Rows;
            }
        }

        private void ResetIndexView(PatientConsentMain patientConsentMain)
        {
            patientConsentMain.AdmissionDate = string.Empty;
            patientConsentMain.AttendingPhysician = string.Empty;
            patientConsentMain.BloodConsent = false;
            patientConsentMain.CardioVascularConsent = false;
            patientConsentMain.EmployeeId = string.Empty;
            patientConsentMain.EndoscopyConsent = false;
            patientConsentMain.Gender = string.Empty;
            patientConsentMain.OORConsent = false;
            patientConsentMain.PICCConsent = false;
            patientConsentMain.PatientAge = string.Empty;
            patientConsentMain.PatientHash = string.Empty;
            patientConsentMain.PatientMRHash = string.Empty;
            patientConsentMain.PatientName = string.Empty;
            patientConsentMain.SurgicalConsent = false;
        }
    }
}