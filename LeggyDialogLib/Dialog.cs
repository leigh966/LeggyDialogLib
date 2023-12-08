using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeggyDialogLib
{
    public class Dialog
    {
        public string PlayerDialog;
        public string Response;
        public bool Said;
        public Dialog(string playerDialog, string response)
        {
            PlayerDialog = playerDialog;
            Response = response;
            Said = false;
        }
    }
}
