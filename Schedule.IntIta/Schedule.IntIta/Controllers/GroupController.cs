using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Schedule.IntIta.DataAccess;
using Schedule.IntIta.DataAccess.Migrations;
using Schedule.IntIta.Integration;

namespace Schedule.IntIta.Controllers
{
    public class GroupController : Controller
    {
        private readonly IGroupIntegrationHandler _groupIntegrationHandler;
        private readonly IGroupRepository _repository;
        public GroupController(IGroupIntegrationHandler groupIntegrationHandler, IGroupRepository repository)
        {
            _groupIntegrationHandler = groupIntegrationHandler;
            _repository = repository;
        }
        public ActionResult Sync()
        {
            var intitaGroups = _groupIntegrationHandler.GetGroupList();
            var groups = _repository.GetAll();

            foreach (var intitaGroup in intitaGroups)
            {
                if (intitaGroup != null)
                {
                    if(!groups.Any(x => x.Name == intitaGroup.Name))
                    {
                        _repository.Insert(intitaGroup);                        
                    }
                }
            }

            return RedirectToAction("Index", "Admin");
        }

    }
}