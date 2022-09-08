
using AdvMasterDetails.DtoModels;
using MVC_Project.DtoModels;
using MVC_Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Project.Controllers
{
    public class HomeController : Controller
    {
        DataContext _dataContext = new DataContext();
        public HomeController()
        {
        }

        public ActionResult Index()
        {
            List<Team> teams = _dataContext.Teams.ToList();
            return View(teams);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ApproveStatusUpdate(ApproveStatus model)
        {

            Team team = _dataContext.Teams.Find(model.TeamId);
            if (team != null)
            {
                if (model.IsManager == true)
                {
                    team.IsApprovedByManager = model.IsApprovedByManager;
                    _dataContext.SaveChanges();
                    return new JsonResult { Data = new { status = true } };
                }
                team.IsApprovedByDirector = model.IsApprovedByDirector;
                _dataContext.SaveChanges();
                return new JsonResult { Data = new { status = true } };

            }
            return new JsonResult { Data = new { status = false } };
        }
        [HttpPost]
        public ActionResult Save(TeamViewModel model)
        {

            Team team = new Team()
            {
                Name = model.TeamName,
                Description = model.Description,
                TeamMembers = model.TeamMembers
            };
            _dataContext.Teams.Add(team);
            int saveCount = _dataContext.SaveChanges();
            long teamId = team.TeamId;

            return new JsonResult { Data = new { status = saveCount > 0 ? true : false } };
        }

        [HttpGet]
        public ActionResult Edit(long teamId)
        {
            Team teams = _dataContext.Teams.Where(x=>x.TeamId==teamId).Include("TeamMembers").FirstOrDefault();
            return View(teams);
        }
        [HttpPost]
        public ActionResult Edit(TeamViewModel model)
        {

            var teamMember = _dataContext.TeamMembers.Where(m => m.TeamId == model.TeamId);

            foreach (TeamMember tm in teamMember)
                _dataContext.TeamMembers.Remove(tm);

            foreach (TeamMember tm in model.TeamMembers)
                _dataContext.TeamMembers.Add(tm);

            Team team = new Team()
            {
                TeamId = model.TeamId,
                Name = model.TeamName,
                Description = model.Description,
                TeamMembers = null
            };
            _dataContext.Entry(team).State = EntityState.Modified;
            int saveCount = _dataContext.SaveChanges();

            return new JsonResult { Data = new { status = saveCount > 0 ? true : false } };
        }
        public JsonResult DeleteTeam(long teamId)
        {
            Team teams = _dataContext.Teams.Where(x => x.TeamId == teamId).Include("TeamMembers").FirstOrDefault();
            if (teams == null)
            return new JsonResult { Data = new { status = false } };
            _dataContext.TeamMembers.RemoveRange(teams.TeamMembers);
            _dataContext.Teams.Remove(teams);
            int saveCount = _dataContext.SaveChanges();
            return new JsonResult { Data = new { status = saveCount > 0 ? true : false } };
        }
    }
}