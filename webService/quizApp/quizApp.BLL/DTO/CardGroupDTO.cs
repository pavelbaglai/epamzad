using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quizApp.BLL.DTO
{
    public class CardGroupDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<CardDTO> CardDtoSet { get; set; }

        public CardGroupDTO()
        {
            CardDtoSet = new List<CardDTO>();
        }

        public override bool Equals(object obj)
        {
            var dTO = obj as CardGroupDTO;
            return dTO != null &&
                   Id == dTO.Id;
        }

        public override int GetHashCode()
        {
            return 37 * Id.GetHashCode();
        }
    }
}
