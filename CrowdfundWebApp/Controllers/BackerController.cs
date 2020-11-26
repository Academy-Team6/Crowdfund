using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Crowdfund.API;
using Crowdfund.Options;
using CrowdfundWebApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static CrowdfundWebApp.Models.BackerModel;

namespace CrowdfundWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BackerController : ControllerBase
    {
        private readonly IBackerService backerService;
        public BackerController(IBackerService backerService)
        {
            this.backerService = backerService;
        }

        [HttpPost]
        public BackerOption AddBacker([FromForm] BackerWithFileModel backerOptWithFileModel)
        {

            if (backerOptWithFileModel == null) return null;
            BackerOption backerOpt = new BackerOption
            {
                FirstName = backerOptWithFileModel.FirstName,
                LastName=backerOptWithFileModel.LastName,
                Email = backerOptWithFileModel.Email,
                Id = backerOptWithFileModel.Id
            };


            BackerOption backerOptions = backerService.CreateBacker(backerOpt);
            return backerOptions;
        }



        [HttpPut("{id}")]
        public BackerOption UpdateBacker(int id, BackerOption backerOpt)
        {
            return backerService.UpdateBacker(id, backerOpt);

        }
        [HttpDelete("{id}")]
        public bool DeleteBacker(int id)
        {
            return backerService.DeleteBacker(id);
        }


    }
}
