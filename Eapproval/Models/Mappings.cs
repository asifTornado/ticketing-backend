namespace Eapproval.Models;

    public class Mappings
    {
        public static Dictionary<string, TimeSpan> PriorityResponseMap = new Dictionary<string, TimeSpan>
        {
            { "Priority 1", TimeSpan.FromMinutes(15) },
            { "Priority 2", TimeSpan.FromHours(1) },
            { "Priority 3", TimeSpan.FromHours(4) },
            { "Priority 4", TimeSpan.FromHours(9) },

        };

    public static Dictionary<string, TimeSpan> PriorityResolutionMap = new Dictionary<string, TimeSpan>
    {
        {"Priority 1", TimeSpan.FromHours(4) },
        {"Priority 2", TimeSpan.FromHours(9) },
        {"Priority 3", TimeSpan.FromHours(18) },
        {"Priority 4", TimeSpan.FromHours(45) },
    };

    
   }

