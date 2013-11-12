using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dESCO.MvvmCross.Plugins.DocumentDisplayer
{
    public interface IMvxDocumentDisplayerTask
    {
        void DisplayDocument(string extension, byte[] document, Action complete, Action failed);
    }
}
