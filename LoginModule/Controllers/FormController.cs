using LoginModule.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClosedXML.Excel;
using System.IO;
using System.Data;

namespace LoginModule.Controllers
{
    public class FormController : Controller
    {
        private readonly ApplicationUser _auc;
        public FormController(ApplicationUser auc)
        {
            _auc = auc;
        }
        public IActionResult Index()
        {
            List<Form> Forms = (from Form in _auc.Forms.Take(10) select Form).ToList();
            return View(Forms);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Form fr)
        {
            _auc.Add(fr);
            _auc.SaveChanges();
            ViewBag.message = "Successfully Saved";
            return View();
;
        }

        public IActionResult Export()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[] { new DataColumn("EmpId"),
                                                new DataColumn("Name"),
                                                new DataColumn("Date of Birth"),
                                                new DataColumn("FathersName"),
                                                new DataColumn("MothersName"),
                                                new DataColumn("Address"),
                                                new DataColumn("Salary"),
                                                new DataColumn("Fresher"),
                                                new DataColumn("Role"),
                                                new DataColumn("Note")});
            var forms = (from Form in _auc.Forms.Take(10) select Form).ToList();
            foreach (var Form in forms)
            {
                dt.Rows.Add(Form.EmpId, Form.Name, Form.DateOfBirth, Form.FathersName, Form.MothersName, Form.address, Form.salary, Form.Fresher, Form.Role, Form.Notes);

            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Grid.xlsx");
                }

            }
        }





        }
    }

