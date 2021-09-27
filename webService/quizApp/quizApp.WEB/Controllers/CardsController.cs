using quizApp.BLL.Interfaces;
using quizApp.BLL.Infrastructure;
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
    public class CardsController : ApiController
    {
        private readonly ICardService _cardService;

        public CardsController(ICardService cardService)
        {
            this._cardService = cardService;
        }

        // GET api/<controller>
        public HttpResponseMessage GetAllCards()
        {
            var value = _cardService.GetAllCards().ToView();
            return Request.CreateResponse(HttpStatusCode.OK, value);
        }

        // GET api/<controller>/5
        public HttpResponseMessage GetCard(int id)
        {
            try
            {
                var cardDto = _cardService.GetCard(id);
                return Request.CreateResponse(HttpStatusCode.OK, cardDto.ToView());
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
                return new HttpResponseMessage(ex.StatusCode);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public HttpResponseMessage CreateCard([FromBody]CardView card)
        {
            try
            {
                _cardService.CreateCard(card.ToDTO());
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
        public HttpResponseMessage EditCard(int id, [FromBody]CardView card)
        {
            try
            {
                _cardService.UpdateCard(id, card.ToDTO());
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
                _cardService.DeleteCard(id);
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