using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace quizApp.WEB.Models
{
    public class CardView
    {
        private int Id { get; set; }
        public string TranslatedWord { get; set; }
        public string DirectWord { get; set; }
        public int? GroupId { get; set; }

        public override bool Equals(object obj)
        {
            var view = obj as CardView;
            return view != null &&
                   Id == view.Id;
        }

        public override int GetHashCode()
        {
            return 37 * Id.GetHashCode();
        }
    }
}