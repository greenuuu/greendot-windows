using ShadowSocks.Controller;
using ShadowSocks.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ShadowSocks.Controller.Strategy
{
    class BalancingStrategy : IStrategy
    {
        ShadowSocksController _controller;
        Random _random;

        public BalancingStrategy(ShadowSocksController controller)
        {
            _controller = controller;
            _random = new Random();
        }

        public string Name
        {
            get { return I18N.GetString("Load Balance"); }
        }

        public string ID
        {
            get { return "com.greendot.strategy.balancing"; }
        }

        public void ReloadServers()
        {
            // do nothing
        }

        public Server GetAServer(IStrategyCallerType type, IPEndPoint localIPEndPoint, EndPoint destEndPoint)
        {
            var configs = _controller.GetCurrentConfiguration().configs;
            int index;
            if (type == IStrategyCallerType.TCP)
            {
                index = _random.Next();
            }
            else
            {
                index = localIPEndPoint.GetHashCode();
            }
            return configs[index % configs.Count];
        }

        public void UpdateLatency(Model.Server server, TimeSpan latency)
        {
            // do nothing
        }

        public void UpdateLastRead(Model.Server server)
        {
            // do nothing
        }

        public void UpdateLastWrite(Model.Server server)
        {
            // do nothing
        }

        public void SetFailure(Model.Server server)
        {
            // do nothing
        }
    }
}
