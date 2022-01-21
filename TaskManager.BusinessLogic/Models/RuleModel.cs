using Newtonsoft.Json;

namespace TaskManager.BusinessLogic.Models
{
    public class RuleModel
    {
        [JsonProperty("process")]
        public string Process { get; set; }

        [JsonProperty("resource")]
        public string Ressource { get; set; }

        [JsonProperty("threshold")]
        public double Threshold { get; set; }

        [JsonProperty("notification")]
        public string Notification { get; set; }

    }
}
