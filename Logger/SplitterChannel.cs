using System;
using System.Collections.Generic;
using System.Text;

namespace Uva.Log
{
    class SplitterChannel : Channel
    {
        private List<Channel> _channels = new List<Channel>();

        public SplitterChannel()
        {
        }

        public SplitterChannel(Channel channel)
        {
            _channels.Add(channel);
        }

        public SplitterChannel(params Channel[] list)
        {
            foreach (var item in list)
            {
                _channels.Add(item);
            }
        }

        public void ClearChannels()
        {
            _channels.Clear();
        }

        public void AddChannels(Channel channel)
        {
            _channels.Add(channel);
        }

        public override void HandleMessage(Message message)
        {
            foreach (var item in _channels)
            {
                item.HandleMessage(message);
            }
        }
    }
}
