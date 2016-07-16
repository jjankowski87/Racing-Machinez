using System;
using System.ComponentModel.Composition;
using System.IO;
using RacingMachinez.Contracts;
using RacingMachinez.Contracts.Plugins;

namespace RacingMachinez.Plugins.TestSample
{
    [Export(typeof (IGamePlugin))]
    public class TestSample : IGamePlugin
    {
        private StreamReader reader;

        public string GameName => "Test Sample";

        public TestSample()
        {
            try
            {
                reader = new StreamReader("Sample.txt");
            }
            catch (Exception ex)
            {
                reader = null;
            }
        }

        public bool IsRunning()
        {
            return reader != null;
        }

        public GameData GetGameData()
        {
            if (reader == null)
            {
                return null;
            }

            try
            {
                if (reader.EndOfStream)
                {
                    reader.BaseStream.Position = 0;
                }

                var line = reader.ReadLine();
                var parts = line.Split(';');

                var gameData = new GameData();
                if (parts.Length > 0)
                {
                    gameData.Speed = short.Parse(parts[0]);
                }

                if (parts.Length > 1)
                {
                    gameData.Revs = short.Parse(parts[1]);
                }

                if (parts.Length > 2)
                {
                    gameData.Gear = parts[2][0];
                }

                return gameData;
            }
            catch(Exception ex)
            {
                reader = null;
                return null;
            }
        }
    }
}