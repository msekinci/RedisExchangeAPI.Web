using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedisExchangeAPI.Web.Services
{
    public class RedisService
    {
        private readonly IConfiguration _configuration;
        private readonly string _redisHost;
        private readonly string _redisPort;
        private ConnectionMultiplexer _redis;
        public IDatabase db { get; set; }

        public RedisService(IConfiguration configuration)
        {
            
            _redisHost = configuration["Redis:Host"];
            _redisPort = configuration["Redis:Port"];

            _configuration = configuration;
        }

        public void Connect()
        {
            var conflictString = $"{_redisHost}:{_redisPort}";
            _redis = ConnectionMultiplexer.Connect(conflictString);
        }

        public IDatabase GetDB(int dbNumber)
        {
            return _redis.GetDatabase(dbNumber);
        }
    }
}
