using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using quizApp.WEB.Models;
using quizApp.BLL.DTO;
using quizApp.BLL.Models;

namespace quizApp.WEB.App_Start
{
    public static class MapperDto
    {
        private static readonly IMapper CardToDto = new MapperConfiguration(cfg => cfg.CreateMap<CardView, CardDTO>()).CreateMapper();
        private static readonly IMapper GroupToDto = new MapperConfiguration(cfg => cfg.CreateMap<CardGroupView, CardGroupDTO>()).CreateMapper();
        private static readonly IMapper DtoToCard = new MapperConfiguration(cfg => cfg.CreateMap<CardDTO, CardView>()).CreateMapper();
        private static readonly IMapper DtoToGroup = new MapperConfiguration(cfg => cfg.CreateMap<CardGroupDTO, CardGroupView>()).CreateMapper();

        public static CardDTO ToDTO(this CardView card)
        {
            return CardToDto.Map<CardView, CardDTO>(card);
        }

        public static IEnumerable<CardDTO> ToDTO(this IEnumerable<CardView> cardSet)
        {
            foreach (var card in cardSet)
            {
                yield return card.ToDTO();
            }
        }

        public static CardGroupDTO ToDTO(this CardGroupView group)
        {
            var groupDto = GroupToDto.Map<CardGroupView, CardGroupDTO>(group);
            foreach (var card in group.CardViewSet)
            {
                groupDto.CardDtoSet.Add(ToDTO(card));
            }
            return groupDto;
        }

        public static IEnumerable<CardGroupDTO> ToDTO(this IEnumerable<CardGroupView> groupSet)
        {
            foreach (var group in groupSet)
            {
                yield return group.ToDTO();
            }
        }

        public static CardView ToView(this CardDTO cardDto)
        {
            return DtoToCard.Map<CardDTO, CardView>(cardDto);
        }

        public static IEnumerable<CardView> ToView(this IEnumerable<CardDTO> cardDtoSet)
        {
            foreach (var card in cardDtoSet)
            {
                yield return card.ToView();
            }
        }

        public static CardGroupView ToView(this CardGroupDTO cardGroupDto)
        {
            var group = DtoToGroup.Map<CardGroupDTO, CardGroupView>(cardGroupDto);
            foreach (var cardDto in cardGroupDto.CardDtoSet)
            {
                group.CardViewSet.Add(ToView(cardDto));
            }
            return group;
        }

        public static IEnumerable<CardGroupView> ToView(this IEnumerable<CardGroupDTO> groupDtoSet)
        {
            foreach (var group in groupDtoSet.ToList())
            {
                yield return group.ToView();
            }
        }

    }
}