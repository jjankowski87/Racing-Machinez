using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RacingMachinez.Contracts.DataStore;
using RacingMachinez.Core.Interfaces.DataStore;

namespace RacingMachinez.Core.DataStore
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        private const string ConfigurationFileName = "config.ini";

        private Configuration _configuration;

        public async Task<Configuration> LoadConfigurationAsync()
        {
            try
            {
                if (_configuration == null)
                {
                    string fileContent;
                    using (var streamReader = File.OpenText(ConfigurationFileName))
                    {
                        fileContent = await streamReader.ReadToEndAsync();
                    }

                    _configuration = JsonConvert.DeserializeObject<Configuration>(fileContent);
                }

                return _configuration;
            }
            catch
            {
                return Configuration.Default();
            }
        }

        public async Task<bool> SaveConfigurationAsync(Configuration configuration)
        {
            try
            {
                var configurationJson = JsonConvert.SerializeObject(configuration);
                using (var streamWriter = new StreamWriter(ConfigurationFileName))
                {
                    await streamWriter.WriteAsync(configurationJson);
                }

                _configuration = configuration;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
