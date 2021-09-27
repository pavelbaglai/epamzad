using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quizApp.Data.Entities
{
    public class Card
    {
        public int Id { get; set; }
        public string DirectWord { get; set; }
        public string TranslatedWord { get; set; }

        public ICollection<CardGroup> GroupSet { get; set; }
        public Card()
        {
            GroupSet = new List<CardGroup>();
        }

        public override bool Equals(object obj)
        {
            var card = obj as Card;
            return card != null &&
                   Id == card.Id;
        }

        public override int GetHashCode()
        {
            return 37 * Id.GetHashCode();
        }
    }
}
