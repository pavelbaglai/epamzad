using System.Collections.Generic;

using quizApp.BLL.Interfaces;
using quizApp.BLL.DTO;
using quizApp.BLL.Infrastructure;

using quizApp.Data.Interfaces;
using quizApp.Data.Entities;
using System.Net;
using quizApp.BLL.Models;

namespace quizApp.BLL.Services
{
    public class CardService : ICardService
    {
        IUnitOfWork Database { get;}
        public CardService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }

        public IEnumerable<CardDTO> GetAllCards()
        {
            foreach (var card in Database.CardSet.GetAll())
            {
                yield return card.ToDTO();
            }
        }

        public IEnumerable<CardGroupDTO> GetAllGroup()
        {
            var groupSet = Database.GroupSet.GetAll();
            foreach (var cardGroup in groupSet)
            {
                yield return cardGroup.ToDTO();
            }
        }

        public CardDTO GetCard(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Nonexistent ID", HttpStatusCode.BadRequest, "");
            }
            var card = Database.CardSet.Get(id.Value);
            return card.ToDTO();
        }

        public CardGroupDTO GetGroup(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Nonexistent ID", HttpStatusCode.BadRequest, "");
            }
            var cardGroup = Database.GroupSet.Get(id.Value);
            return cardGroup.ToDTO();
        }

        public void CreateCard(CardDTO cardDto)
        {
            Card card = cardDto.ToModel();
            if (cardDto.CardGroupId != null)
            {
                var cardGroup = Database.GroupSet.Get((cardDto.CardGroupId.Value));
                if (cardGroup != null)
                {
                    card.GroupSet.Add(cardGroup);
                }
            }

            Database.CardSet.Create(card);
            Database.Save();
        }

        public void CreateGroup(CardGroupDTO cardGroupDto)
        {
            Database.GroupSet.Create(cardGroupDto.ToModel());
            Database.Save();
        }
        public void UpdateCard(int? id, CardDTO cardDto)
        {
            if (id == null)
            {
                throw new ValidationException("Nonexistent ID", HttpStatusCode.BadRequest, "");
            }
            var card = cardDto.ToModel();
            card.Id = id.Value;
            Database.CardSet.Update(card);
            Database.Save();
        }

        public void UpdateGroup(int? id, CardGroupDTO cardGroupDto)
        {
            if (id == null)
            {
                throw new ValidationException("Nonexistent ID", HttpStatusCode.BadRequest, "");
            }
            var cardGroup = cardGroupDto.ToModel();
            cardGroup.Id = id.Value;
            Database.GroupSet.Update(cardGroup);
            Database.Save();
        }

        public void DeleteCard(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Nonexistent ID", HttpStatusCode.BadRequest, "");
            }
            Database.CardSet.Delete(id.Value);
            Database.Save();
        }

        public void DeleteGroup(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Nonexistent ID", HttpStatusCode.BadRequest, "");
            }
            Database.GroupSet.Delete(id.Value);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
            Database.Save();
        }
    }
}
