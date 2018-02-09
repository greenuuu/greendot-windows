using ShadowSocks.Controller;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowSocks.Controller.Strategy
{
    class StrategyManager
    {
        List<IStrategy> _strategies;
        public StrategyManager(ShadowSocksController controller)
        {
            _strategies = new List<IStrategy>();
            _strategies.Add(new BalancingStrategy(controller));
            _strategies.Add(new HighAvailabilityStrategy(controller));
            _strategies.Add(new StatisticsStrategy(controller));
            // TODO: load DLL plugins
        }
        public IList<IStrategy> GetStrategies()
        {
            return _strategies;
        }
    }
}
