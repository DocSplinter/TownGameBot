using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using Microsoft.Extensions.Configuration;
using TownGameBot.Models;
using TownGameBot.Services;

namespace TownGameBot.Bots
{
    public class CityBot : ActivityHandler
    {
        private readonly StateService _stateService;
        protected readonly int expireAfterSeconds;
        public string messageText = "";
        public string responseText = "";
        readonly AplicationContext db;

        public CityBot(IConfiguration configuration, StateService stateService, AplicationContext context)
        {
            _stateService = stateService ?? throw new ArgumentNullException(nameof(stateService));
            expireAfterSeconds = configuration.GetValue<int>("ExpireAfterSeconds");
            db = context;

            if(!db.CityModels.Any())
            {
                db.CityModels.Add(new CityModel { City = "Майкоп" });
                db.CityModels.Add(new CityModel { City = "Уфа" });
                db.CityModels.Add(new CityModel { City = "Горно-Алтайск" });
                db.CityModels.Add(new CityModel { City = "Махачкала" });
                db.CityModels.Add(new CityModel { City = "Нальчик" });
                db.CityModels.Add(new CityModel { City = "Элиста" });
                db.CityModels.Add(new CityModel { City = "Черкесск" });
                db.CityModels.Add(new CityModel { City = "Петрозаводск" });
                db.CityModels.Add(new CityModel { City = "Сыктывкар" });
                db.CityModels.Add(new CityModel { City = "Йошкар-Ола" });
                db.CityModels.Add(new CityModel { City = "Саранск" });
                db.CityModels.Add(new CityModel { City = "Якутск" });
                db.CityModels.Add(new CityModel { City = "Владикавказ" });
                db.CityModels.Add(new CityModel { City = "Кызыл" });
                db.CityModels.Add(new CityModel { City = "Ижевск" });
                db.CityModels.Add(new CityModel { City = "Абакан" });
                db.CityModels.Add(new CityModel { City = "Барнаул" });
                db.CityModels.Add(new CityModel { City = "Краснодар" });
                db.CityModels.Add(new CityModel { City = "Красноярск" });
                db.CityModels.Add(new CityModel { City = "Владивосток" });
                db.CityModels.Add(new CityModel { City = "Ставрополь" });
                db.CityModels.Add(new CityModel { City = "Хабаровск" });
                db.CityModels.Add(new CityModel { City = "Благовещенск" });
                db.CityModels.Add(new CityModel { City = "Архангельск" });
                db.CityModels.Add(new CityModel { City = "Белгород" });
                db.CityModels.Add(new CityModel { City = "Брянск" });
                db.CityModels.Add(new CityModel { City = "Владимир" });
                db.CityModels.Add(new CityModel { City = "Волгоград" });
                db.CityModels.Add(new CityModel { City = "Вологда" });
                db.CityModels.Add(new CityModel { City = "Иваново" });
                db.CityModels.Add(new CityModel { City = "Иркутск" });
                db.CityModels.Add(new CityModel { City = "Калининград" });
                db.CityModels.Add(new CityModel { City = "Калуга" });
                db.CityModels.Add(new CityModel { City = "Петропавловск-Камчатский" });
                db.CityModels.Add(new CityModel { City = "Кемерово" });
                db.CityModels.Add(new CityModel { City = "Киров" });
                db.CityModels.Add(new CityModel { City = "Кострома" });
                db.CityModels.Add(new CityModel { City = "Курган" });
                db.CityModels.Add(new CityModel { City = "Курск" });
                db.CityModels.Add(new CityModel { City = "Санкт-Петербург" });
                db.CityModels.Add(new CityModel { City = "Липецк" });
                db.CityModels.Add(new CityModel { City = "Магадан" });
                db.CityModels.Add(new CityModel { City = "Москва", NamedCity = true });
                db.CityModels.Add(new CityModel { City = "Мурманск" });
                db.CityModels.Add(new CityModel { City = "Нижний Новгород" });
                db.CityModels.Add(new CityModel { City = "Новгород" });
                db.CityModels.Add(new CityModel { City = "Новосибирск" });
                db.CityModels.Add(new CityModel { City = "Омск" });
                db.CityModels.Add(new CityModel { City = "Оренбург" });
                db.CityModels.Add(new CityModel { City = "Орел" });
                db.CityModels.Add(new CityModel { City = "Пенза" });
                db.CityModels.Add(new CityModel { City = "Псков" });
                db.CityModels.Add(new CityModel { City = "Ростов-на-Дону" });
                db.CityModels.Add(new CityModel { City = "Самара" });
                db.CityModels.Add(new CityModel { City = "Саратов" });
                db.CityModels.Add(new CityModel { City = "Южно-Сахалинск" });
                db.CityModels.Add(new CityModel { City = "Екатеринбург" });
                db.CityModels.Add(new CityModel { City = "Смоленск" });
                db.CityModels.Add(new CityModel { City = "Тамбов" });
                db.CityModels.Add(new CityModel { City = "Томск" });
                db.CityModels.Add(new CityModel { City = "Тула" });
                db.CityModels.Add(new CityModel { City = "Ульяновск" });
                db.CityModels.Add(new CityModel { City = "Челябинск" });
                db.CityModels.Add(new CityModel { City = "Чита" });
                db.CityModels.Add(new CityModel { City = "Биробиджан" });
                db.CityModels.Add(new CityModel { City = "Агинское" });
                db.CityModels.Add(new CityModel { City = "Кудымкар" });
                db.CityModels.Add(new CityModel { City = "Палана" });
                db.CityModels.Add(new CityModel { City = "Нарьян-Мар" });
                db.CityModels.Add(new CityModel { City = "Астрахань" });
                db.CityModels.Add(new CityModel { City = "Дудинка" });
                db.CityModels.Add(new CityModel { City = "Усть-Ордынский" });
                db.CityModels.Add(new CityModel { City = "Ханты-Мансийск" });
                db.CityModels.Add(new CityModel { City = "Тура" });
                db.CityModels.Add(new CityModel { City = "Салехард" });
                db.CityModels.Add(new CityModel { City = "Грозный" });
                db.SaveChanges();
            }
        }

         public override async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default)
        {
            // Retrieve the property value, and compare it to the current time.
            var lastAcces = await _stateService.TimeAccessor.GetAsync(turnContext, () => DateTime.UtcNow, cancellationToken).ConfigureAwait(false);
            if(DateTime.UtcNow - lastAcces >= TimeSpan.FromSeconds(expireAfterSeconds))
            {
                // Notify the user that the conversation is being restarted.
                await turnContext.SendActivityAsync("Я скучал по тебе...").ConfigureAwait(false);

                // Clear state.
                await _stateService.ConversationState.ClearStateAsync(turnContext, cancellationToken).ConfigureAwait(false);

            }

            await base.OnTurnAsync(turnContext, cancellationToken).ConfigureAwait(false);

            // Set LastAccessedTime to the current time.
            await _stateService.TimeAccessor.SetAsync(turnContext, DateTime.UtcNow, cancellationToken).ConfigureAwait(false);

            // Save any state changes that might have occurred during the turn.
            await _stateService.ConversationState.SaveChangesAsync(turnContext, false, cancellationToken).ConfigureAwait(false);
            await _stateService.UserState.SaveChangesAsync(turnContext, false, cancellationToken).ConfigureAwait(false);
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
            CityList cityList =  await _stateService.CityListAccessor.GetAsync(turnContext, () => new CityList { CityModels = db.CityModels.ToArray() } );
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
                        await turnContext.SendActivityAsync(MessageFactory.Text(string.Format
                            ("{0}, если захочешь поиграть, просто скажи 'да'. Дольше {1} минут не тупи, а то я буду скучать", userProfile.Name, Math.Ceiling((double)expireAfterSeconds / 60))), cancellationToken);
                    }
                }
                else
                {
                    userProfile.Name = messageText.Trim();

                    await _stateService.UserProfileAccessor.SetAsync(turnContext, userProfile);
                    await _stateService.UserState.SaveChangesAsync(turnContext);
                                                                                                                                           
                    await turnContext.SendActivityAsync(MessageFactory.Text(String.Format("{0}, давай поиграем в города. Скажи: 'да', если будешь играть", userProfile.Name)), cancellationToken);
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
            string gameState = "0";
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
                            gameState = "2";
                        }
                        else
                        {
                            gameState = "1";
                        }
                    }

                    firstLetter = GetFirstLetter(cityList.CityModels[k].City);
                    if(lastLetter.ToLower() == firstLetter.ToLower())
                    {
                        if(!cityList.CityModels[k].NamedCity)
                        {
                            newCity = cityList.CityModels[k].City;
                        }
                    }
                }
                s = 0;
                f = startIndex;
            }

            if(gameState == "2")
            {
                if(string.IsNullOrEmpty(newCity))
                {
                    conversationData.OnGame = false;
                    return "Тарааамм!! Ты выиграл!!! Поздравляю с победой!!!!";
                }
                else
                {
                    conversationData.OnGame = true;
                    conversationData.FirstLetter = GetLastLetter(newCity);
                    foreach(var cityModel in cityList.CityModels)
                    {
                        if(cityModel.City.ToLower() == newCity.ToLower())
                        {
                            cityModel.NamedCity = true;
                            break;
                        }
                    }
                    return newCity;
                }
            }
            else
            {
                return gameState;
            }

            

        }

        public string GetFirstLetter(string word)
        {
            return word.ToLower().Substring(0, 1);
        }

        public string GetLastLetter(string word)
        {
            string[] offSideLetters = { "й", "ь", "ъ", "ы" };
            string letter;
            int i = 1;
            do
            {
                letter = word.ToLower().Substring(word.Length - i, 1);
                i++;
            }
            while (offSideLetters.Contains<string>(letter));

            return letter;
        }

       
    }
}
