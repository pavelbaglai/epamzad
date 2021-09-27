using quizApp.BLL.Infrastructure;
using quizApp.BLL.Interfaces;
using quizApp.WEB.App_Start;
using quizApp.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace quizApp.WEB.Controllers
{
    public class CardGroupsController : ApiController
    {
        private readonly ICardService cardService;

        public CardGroupsController(ICardService cardService)
        {
            this.cardService = cardService;
        }

        // GET api/<controller>
        public HttpResponseMessage GetAllGroups()
        {
            var group = cardService.GetAllGroup().ToView().ToList();
            return Request.CreateResponse(HttpStatusCode.OK, group);
        }

        // GET api/<controller>/5
        public HttpResponseMessage GetGroup(int id)
        {
            try
            {
                var groupDto = cardService.GetGroup(id);
                return Request.CreateResponse(HttpStatusCode.OK, groupDto.ToView());
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
                return new HttpResponseMessage(ex.StatusCode);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public HttpResponseMessage CreateGroup([FromBody]CardGroupView group)
        {
            try
            {
                cardService.CreateGroup(group.ToDTO());
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
                return new HttpResponseMessage(ex.StatusCode);
            }
        }

        // PUT api/<controller>/5
        [HttpPut]
        public HttpResponseMessage EditGroup(int id, [FromBody]CardGroupView group)
        {
            try
            {
                cardService.UpdateGroup(id, group.ToDTO());
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
                return new HttpResponseMessage(ex.StatusCode);
            }
        }

        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                cardService.DeleteGroup(id);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
                return new HttpResponseMessage(ex.StatusCode);
            }
        }
    }
}