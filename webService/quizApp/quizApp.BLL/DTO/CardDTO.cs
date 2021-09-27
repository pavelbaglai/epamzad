using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quizApp.BLL.DTO
{
    public class CardDTO
    {
        public int Id { get; set; }
        public string DirectWord { get; set; }
        public string TranslatedWord { get; set; }
        public int? CardGroupId { get; set; }

        public override bool Equals(object obj)
        {
            var dto = obj as CardDTO;
            return dto != null &&
                   Id == dto.Id;
        }

        public override int GetHashCode()
        {
            return 37 * Id.GetHashCode();
        }
    }
}
