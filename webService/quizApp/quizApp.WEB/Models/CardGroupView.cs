using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace quizApp.WEB.Models
{
    public class CardGroupView
    {
        public int Id { get; private set; }
        public string Title { get; set; }

        public virtual ICollection<CardView> CardViewSet { get; set; }

        public CardGroupView()
        {
            CardViewSet = new List<CardView>();
        }

        public override bool Equals(object obj)
        {
            var dTO = obj as CardGroupView;
            return dTO != null &&
                   Id == dTO.Id;
        }

        public override int GetHashCode()
        {
            return 37 * Id.GetHashCode();
        }
    }

}