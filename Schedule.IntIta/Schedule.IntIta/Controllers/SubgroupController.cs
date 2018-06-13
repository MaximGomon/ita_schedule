using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Schedule.IntIta.DataAccess;
using Schedule.IntIta.Integration;

namespace Schedule.IntIta.Controllers
{
    public class SubgroupController : Controller
    {
        private readonly IGroupIntegrationHandler _groupIntegrationHandler;
        private readonly IGroupRepository _groupRepository;
        private readonly ISubGroupRepository _subGroupRepository;

        public SubgroupController(IGroupIntegrationHandler groupIntegrationHandler, IGroupRepository groupRepository, ISubGroupRepository subGroupRepository)
        {
            _groupIntegrationHandler = groupIntegrationHandler;
            _groupRepository = groupRepository;
            _subGroupRepository = subGroupRepository;
        }
        public ActionResult Sync()
        {
            var groups = _groupRepository.GetAll();
            var subGroups = _subGroupRepository.GetAll();

            foreach (var group in groups)
            {
                var sg = _groupIntegrationHandler.GetSubGroupsByGroupId(group.Id);

                foreach (var subGroup in sg)
                {
                    if (!subGroups.Any(x => x.Id == subGroup.Id))
                    {
                        _subGroupRepository.Insert(subGroup);
                    }
                }
            }

            return RedirectToAction("Index", "Admin");
        }
    }
}