using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quizApp.Data.Entities
{
    public class CardGroup
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<Card> CardSet { get; set; }
        public CardGroup()
        {
            CardSet = new List<Card>();
        }

        public override bool Equals(object obj)
        {
            var group = obj as CardGroup;
            return group != null &&
                   Id == group.Id;
        }

        public override int GetHashCode()
        {
            return 37 * Id.GetHashCode();
        }
    }
}
