using Microsoft.Bot.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TownGameBot.Models;

namespace TownGameBot.Services
{
    public class StateService
    {
        public ConversationState ConversationState { get; }

        public static string CityListId { get; } = $"{nameof(StateService)}.CityList";

        public IStatePropertyAccessor<CityList> CityListAccessor { get; set; }

        public StateService(ConversationState conversationState)
        {
            ConversationState = conversationState ?? throw new ArgumentNullException(nameof(conversationState));

            InitializeAccessor();
        }

        private void InitializeAccessor()
        {
            CityListAccessor = ConversationState.CreateProperty<CityList>(CityListId);
        }
    }
}
