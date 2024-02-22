using System;
using Newtonsoft.Json;

namespace GP2_LeaderboardsApi.Contracts
{
    [JsonObject, Serializable]
    public class Player
    {
        public string Name { get; set; }
        public float Score { get; set; }
    }
}