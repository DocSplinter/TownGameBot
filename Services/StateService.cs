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
        public UserState UserState { get; }

        public static string CityListId { get; } = $"{nameof(StateService)}.CityList";
        public static string UserProfileId { get; } = $"{nameof(StateService)}.UserProfile";
        public static string ConversationDataId { get; } = $"{nameof(StateService)}.ConversationData";

        public IStatePropertyAccessor<CityList> CityListAccessor { get; set; }
        public IStatePropertyAccessor<UserProfile> UserProfileAccessor { get; set; }
        public IStatePropertyAccessor<ConversationData> ConversationDataAccessor { get; set; }

        public StateService(ConversationState conversationState, UserState userState)
        {
            ConversationState = conversationState ?? throw new ArgumentNullException(nameof(conversationState));
            UserState = userState ?? throw new ArgumentNullException(nameof(userState));

            InitializeAccessor();
        }

        private void InitializeAccessor()
        {
            CityListAccessor = ConversationState.CreateProperty<CityList>(CityListId);
            UserProfileAccessor = UserState.CreateProperty<UserProfile>(UserProfileId);
            ConversationDataAccessor = ConversationState.CreateProperty<ConversationData>(ConversationDataId);
        }
    }
}
