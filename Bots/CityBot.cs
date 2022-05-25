using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using TownGameBot.Models;
using TownGameBot.Services;

namespace TownGameBot.Bots
{
    public class CityBot : ActivityHandler
    {
        private readonly StateService _stateService;
        public string messageText = "";
        public string responseText = "";

        public CityBot(StateService stateService)
        {
            _stateService = stateService ?? throw new ArgumentNullException(nameof(stateService));
        }

        

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    await turnContext.SendActivityAsync(MessageFactory.Text("Привет! Как тебя зовут"), cancellationToken);
                }
            }
        }

        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            CityList cityList =  await _stateService.CityListAccessor.GetAsync(turnContext, () => new CityList());
            UserProfile userProfile = await _stateService.UserProfileAccessor.GetAsync(turnContext, () => new UserProfile());
            ConversationData conversationData = await _stateService.ConversationDataAccessor.GetAsync(turnContext, () => new ConversationData());

            messageText = turnContext.Activity.Text;
            responseText = "не пойдет, тебе надо назвать город на";


            if (!conversationData.OnGame)
            {
                if (!string.IsNullOrEmpty(userProfile.Name))
                {
                    if (messageText.ToLower() == "да")
                    {
                        conversationData.OnGame = true;

                        await _stateService.ConversationDataAccessor.SetAsync(turnContext, conversationData);
                        await _stateService.ConversationState.SaveChangesAsync(turnContext);

                        await turnContext.SendActivityAsync(MessageFactory.Text("Играем играем!!!! Москва, тебе на 'А'"), cancellationToken);
                    }
                    else
                    {
                        await turnContext.SendActivityAsync(MessageFactory.Text("Ну не хочешь, как хочешь... Если захочешь поиграть, просто скажи 'да' "), cancellationToken);
                    }
                }
                else
                {
                    userProfile.Name = messageText.Trim();

                    await _stateService.UserProfileAccessor.SetAsync(turnContext, userProfile);
                    await _stateService.UserState.SaveChangesAsync(turnContext);

                    await turnContext.SendActivityAsync(MessageFactory.Text(String.Format("{0}, давай поиграем в города. Скажи: 'да', если согласен поиграть", userProfile.Name)), cancellationToken);
                }
            }
            else
            {
                if(conversationData.FirstLetter != GetFirstLetter(messageText))
                {
                    await turnContext.SendActivityAsync(MessageFactory.Text($"{messageText} {responseText} '{conversationData.FirstLetter.ToUpper()}'"), cancellationToken);
                }
                else
                {
                    string text = Game(messageText, cityList, conversationData);
                    responseText = text switch
                    {
                        "0" => "Я не нашёл такого города в моём списке",
                        "1" => $"{messageText} уже был",
                        _ => await Task<string>.Run(() => 
                        {
                            _stateService.ConversationDataAccessor.SetAsync(turnContext, conversationData);
                            _stateService.CityListAccessor.SetAsync(turnContext, cityList);
                            _stateService.ConversationState.SaveChangesAsync(turnContext);
                            return text;
                        })
                    };
                    await turnContext.SendActivityAsync(MessageFactory.Text(responseText), cancellationToken);


                }
                
            }

            //.....
        }

        public string Game(string city, CityList cityList, ConversationData conversationData)
        {
            int citiesCount = cityList.CityModels.Length;
            int startIndex = new Random().Next(1, citiesCount - 2);
            string searchCity = "0";
            string lastLetter = GetLastLetter(city);
            string firstLetter, newCity = "";
            int s = startIndex;
            int f = citiesCount - 1;

            for(int i = 0; i < 2; i++)
            {
                for(int k = s; k < f; k++)
                {
                    if(city.ToLower() == cityList.CityModels[k].City.ToLower())
                    {
                        if(cityList.CityModels[k].NamedCity == false)
                        {
                            cityList.CityModels[k].NamedCity = true;
                            searchCity = "2";
                        }
                        else
                        {
                            searchCity = "1";
                        }
                    }

                    firstLetter = GetFirstLetter(cityList.CityModels[k].City);
                    if(lastLetter.ToLower() == firstLetter.ToLower())
                    {
                        newCity = cityList.CityModels[k].City;
                    }
                }
                s = 0;
                f = startIndex;
            }

            if(searchCity == "2")
            {
                if(string.IsNullOrEmpty(newCity))
                {
                    conversationData.OnGame = false;
                    return "Тарааамм!! Ты выиграл!!! Поздравляю с победой!!!!";
                }
                else
                {
                    conversationData.OnGame = true;
                    return newCity;
                }
            }
            else
            {
                return searchCity;
            }

            

        }

        public string GetFirstLetter(string word)
        {
            return word.ToLower().Substring(1, 1);
        }

        public string GetLastLetter(string word)
        {
            return word.ToLower().Substring(word.Length - 1);
        }

    }
}
