using AutoMapper;
using quizApp.BLL.DTO;
using quizApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quizApp.BLL.Models
{
    public static class Mapper
    {
        private static readonly IMapper CardToDto  = new MapperConfiguration(cfg => cfg.CreateMap<Card, CardDTO>()).CreateMapper();
        private static readonly IMapper GroupToDto = new MapperConfiguration(cfg => cfg.CreateMap<CardGroup, CardGroupDTO>()).CreateMapper();
        private static readonly IMapper DtoToCard  = new MapperConfiguration(cfg => cfg.CreateMap<CardDTO, Card>()).CreateMapper();
        private static readonly IMapper DtoToGroup = new MapperConfiguration(cfg => cfg.CreateMap<CardGroupDTO, CardGroup>()).CreateMapper();

        public static CardDTO ToDTO(this Card card)
        {
            return CardToDto.Map<Card, CardDTO>(card);
        }

        public static CardGroupDTO ToDTO(this CardGroup cardGroup)
        {
            var groupDto = GroupToDto.Map<CardGroup, CardGroupDTO>(cardGroup);
            foreach (var card in cardGroup.CardSet)
            {
                groupDto.CardDtoSet.Add(ToDTO(card));
            }
            return groupDto;
        }

        public static Card ToModel(this CardDTO cardDto)
        {
            return DtoToCard.Map<CardDTO, Card>(cardDto);
        }

        public static CardGroup ToModel(this CardGroupDTO groupDto)
        {
            var cardGroup = DtoToGroup.Map<CardGroupDTO, CardGroup>(groupDto);
            foreach (var cardDto in groupDto.CardDtoSet)
            {
                cardGroup.CardSet.Add(ToModel(cardDto));
            }
            return cardGroup;
        }
    }
}
