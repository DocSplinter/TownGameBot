﻿using System;
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
        public string allCityString = "";

        public CityBot(StateService stateService)
        {
            _stateService = stateService ?? throw new ArgumentNullException(nameof(stateService));
        }

        

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            //return base.OnMembersAddedAsync(membersAdded, turnContext, cancellationToken);
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
            //return base.OnMessageActivityAsync(turnContext, cancellationToken);
            CityList cityList =  await _stateService.CityListAccessor.GetAsync(turnContext, () => new CityList());

            //string allCityString = "";

            foreach (var CityModel in cityList.CityModels)
            {
                allCityString += CityModel.City + "; ";
            }

            await turnContext.SendActivityAsync(MessageFactory.Text(allCityString), cancellationToken);
        }
    }
}