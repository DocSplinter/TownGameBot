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

        public static string CityModelId { get; } = $"{nameof(StateService)}.CityModel";

        public IStatePropertyAccessor<CityModel> CityModelAccessor { get; set; }

        public StateService(ConversationState conversationState)
        {
            ConversationState = conversationState ?? throw new ArgumentNullException(nameof(conversationState));

            InitializeAccessor();
        }

        private void InitializeAccessor()
        {
            CityModelAccessor = ConversationState.CreateProperty<CityModel>(CityModelId);
        }
    }
}
