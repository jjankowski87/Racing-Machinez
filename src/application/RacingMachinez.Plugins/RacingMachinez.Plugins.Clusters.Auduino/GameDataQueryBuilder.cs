using System;
using System.Collections.Generic;
using System.Text;
using RacingMachinez.Contracts;

namespace RacingMachinez.Plugins.Clusters.Auduino
{
    public class GameDataQueryBuilder
    {
        private readonly IDictionary<string, Func<GameData, string>> _dataBuilders = new Dictionary<string, Func<GameData, string>>
            {
                { "s", gameData => gameData.Speed.ToString() },
                { "r", gameData => gameData.Revs.ToString() },
                { "g", gameData => gameData.Gear.ToString() }
            };

        public string Build(GameData currentGameData, GameData previousGameData)
        {
            var stringBuilder = new StringBuilder();

            foreach (var builder in _dataBuilders)
            {
                var currentValue = builder.Value(currentGameData);
                var previousValue = builder.Value(previousGameData);

                if (currentGameData != previousGameData)
                {
                    stringBuilder.AppendFormat("{0}={1};", builder.Key, currentValue);
                }
            }

            return stringBuilder.ToString();
        }
    }
}
