using System;
using HREngine.Bots;
using Triton.Common.LogUtilities;

namespace SilverFish.Helpers
{
    public class CardHelper
    {
        public static SimTemplate GetCardSimulation(CardDB.cardIDEnum tempCardIdEnum)
        {
            SimTemplate result = new SimTemplate();

            var className = $"HREngine.Bots.Sim_{tempCardIdEnum}";
            Type type = Type.GetType(className);
            if (type == null)
            {
                //write a log here
            }
            else
            {
                var simTemplateInstance = Activator.CreateInstance(type);
                if (simTemplateInstance is SimTemplate temp)
                {
                    result = temp;
                }
                else
                {
                    throw new Exception($"class {className} should inherit from {typeof(SimTemplate)}");
                }
            }
            if (tempCardIdEnum == CardDB.cardIDEnum.GIL_530)
            {
                Logger.GetLoggerInstanceForType().InfoFormat($"className = {className}, type of result is {type}");
            }
            return result;
        }

        public static bool IsCardSimulationImplemented(SimTemplate cardSimulation)
        {
            var type = cardSimulation.GetType();
            var baseType = typeof(SimTemplate);
            bool implemented = type.IsSubclassOf(baseType);
            return implemented;
        }
    }
}
