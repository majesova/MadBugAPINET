using MadBug.WebAPI.Helpers;
using MadBug.WebAPI.Models.api;
using MadBug.Data;
using MadBug.Data.Repositories;
using MagBug.Domain;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using System.Net.Http;
using System.Net;
using System.Data.Entity.Infrastructure;

namespace MadBug.API.Controllers
{
    /// <summary>
    /// Bug resources
    /// </summary>
    [Authorize]
    public class BugController : BaseApiController
    {


        /// <summary>
        /// This resource returns the registered bugs in te application
        /// /// </summary>
        /// <returns>List of bugs</returns>
        [ResponseType(typeof(List<BugApi>))]
        public IHttpActionResult Get()
        {
            using (DataContext context = new DataContext()) {
                BugRepository bugRepository = new BugRepository(context);
                var bugs = bugRepository.GetAll();
                var models = MapperHelper.Map<ICollection<BugApi>>(bugs);
                return Ok(models);
            }
        }

        /// <summary>
        /// This resource returns a single Bug resource
        /// </summary>
        /// <param name="id">Bug Identifier</param>
        /// <returns>Single bug</returns>
        [ResponseType(typeof(BugApi))]
        public IHttpActionResult Get(int id)
        {
            using (DataContext context = new DataContext())
            {
                BugRepository bugRepository = new BugRepository(context);
                var bug = bugRepository.Find(id);
                if (bug == null)
                    return NotFound();

                var model = MapperHelper.Map<BugApi>(bug);
                return Ok(model);
            }
        }
        /// <summary>
        /// This resource add a bug
        /// </summary>
        /// <param name="model">Bug</param>
        /// <returns>Inserted bug</returns>
        [ResponseType(typeof(BugApi))]
        public IHttpActionResult Post([FromBody]BugApi model)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);
            
            using (DataContext context = new DataContext())
            {
                BugRepository bugRepository = new BugRepository(context);
                var bug = MapperHelper.Map<Bug>(model);
                bug.CreatedAt = DateTime.Now;
                bug.CreatedById = CurrentUserId;
                bugRepository.Insert(bug);
                context.SaveChanges();
                var bugApi = MapperHelper.Map<BugApi>(bug);
                return Ok(bugApi);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Bug Identifier</param>
        /// <param name="model">Bug</param>
        /// <returns>Updated bug</returns>
        [ResponseType(typeof(BugApi))]
        public IHttpActionResult Put(int id, [FromBody]BugApi model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                using (DataContext context = new DataContext())
                {
                    BugRepository bugRepository = new BugRepository(context);
                    var bug = MapperHelper.Map<Bug>(model);
                    bug.ModifiedAt = DateTime.Now;
                    bug.CreatedById = CurrentUserId;
                    bugRepository.Update(bug);
                    context.SaveChanges();
                    var bugApi = MapperHelper.Map<BugApi>(bug);
                    return Ok(bugApi);
                }
            }
            catch (DbUpdateConcurrencyException) {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.Conflict, new { Message = "El registro ha sido modificado" }));
            }

        }

    }
}
