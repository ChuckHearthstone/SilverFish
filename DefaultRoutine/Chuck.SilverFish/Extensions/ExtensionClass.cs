using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthDb.CardDefs;

namespace Chuck.SilverFish.Extensions
{
    public static class ExtensionClass
    {
        public static List<PlayRequirement> GetPlayRequirements(this Entity entity)
        {
            var power = entity?.Powers.FirstOrDefault(x => x?.PlayRequirements.Count >= 1);
            var playRequirements = power?.PlayRequirements;
            return playRequirements;
        }
    }
}
