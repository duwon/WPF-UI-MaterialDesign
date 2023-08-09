using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ui_Compact.Message
{
    // Create a message
    public class IsRightDrawerChangeMessage : ValueChangedMessage<bool>
    {
        public IsRightDrawerChangeMessage(bool isRightDrawer) : base(isRightDrawer)
        {
        }
    }
}
