using quizApp.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quizApp.BLL.Interfaces
{
    public interface ICardService
    {
        IEnumerable<CardDTO> GetAllCards();
        IEnumerable<CardGroupDTO> GetAllGroup();
        void CreateCard(CardDTO cardDto);
        void CreateGroup(CardGroupDTO cardGroupDto);
        CardDTO GetCard(int? id);
        CardGroupDTO GetGroup(int? id);
        void UpdateCard(int? id, CardDTO cardDto);
        void UpdateGroup(int? id, CardGroupDTO cardGroupDto);
        void DeleteCard(int? id);
        void DeleteGroup(int? id);
        void Dispose();
    }
}
