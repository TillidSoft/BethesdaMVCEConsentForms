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
            ResetIndexView();
            var patientConsentMain = new PatientConsentMain();
            patientConsentMain.PatientsList = new SelectList(new string[0]);
            patientConsentMain.ConsentFormList = new SelectList(new string[0]);
            return View(patientConsentMain);
        }

        [HttpPost]
        public ActionResult PatientConsent(PatientConsentMain patientConsentMain)
        {
            ResetIndexView();
            LoadPatients(Request.Form["RdoLocation"]);
            if (!string.IsNullOrEmpty(patientConsentMain.EmployeeId))
            {
                var consentFormSvcClient = new ConsentFormSvcClient();
                if (consentFormSvcClient.IsValidEmployee(patientConsentMain.EmployeeId))
                    ViewBag.Loggedin = true;
                else
                    ViewBag.error = "Invalid employee id entered!";
            }
            return View("Index");
        }

        private void LoadPatients(string patientLocation)
        {
            if (!string.IsNullOrEmpty(patientLocation))
            {
                var consentFormSvcClient = new ConsentFormSvcClient();
                ViewBag.Patients = consentFormSvcClient.GetPatientfromLocation(patientLocation).Rows;
            }
        }

        private void ResetIndexView()
        {
            ViewBag.Loggedin = false;
            ViewBag.Patients = new DataTable().Rows;
            ViewBag.error = string.Empty;
            ViewBag.EmployeeID = string.Empty;
            ViewBag.PatientName = string.Empty;
            ViewBag.PatientHash = string.Empty;
            ViewBag.PatientAge = string.Empty;
            ViewBag.PatientGender = string.Empty;
            ViewBag.PatientMRHash = string.Empty;
            ViewBag.PatientAttendingPhysician = string.Empty;
            ViewBag.PatientAdmissionDate = string.Empty;
        }
    }
}