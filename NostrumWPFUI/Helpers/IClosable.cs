using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NostrumWPFUI.Helpers
{
    //Interface to close PopUp Windows. 
    //Added for maintain MVVM pattern inplace of sending view to vm and close it in code.
    //Popup windows should implement this I/F for Closecommand.
    public interface IClosable
    {
        void ClosePopupWindow();
        void HidePopupWindow();
    }
}
