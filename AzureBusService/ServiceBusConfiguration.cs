using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureBusService
{
    public class ServiceBusConfiguration
    {
        public string ConnString { get; set; } = "Endpoint=sb://push-pull-message.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=6/uLkotWcEfdfjEGgYygJBkdgv5rf3579+ASbORIefs=";
        public string QueueName { get; set; } = "MessageQueue";
    }
}
