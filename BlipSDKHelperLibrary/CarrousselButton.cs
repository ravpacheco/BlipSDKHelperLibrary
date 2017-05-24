using Lime.Protocol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlipSDKHelperLibrary
{
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class CarrousselButton
    {

        //From which container this button belongs.
        public int Container { get; set; }

        //In which order it will appears.
        public int Order { get; set; }

        //What is the value of the button (hidden message that will be sent to us when the user click on it).
        public string Value { get; set; }


        //What is the Doc of the button? (WebLink? MediaLink? PlainText?)
        public Document DocumentType { get; set; }

        public ButtonType Type { get; set; }

    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum ButtonType
    {
        Default,
        Share,
        Location
    }
}
