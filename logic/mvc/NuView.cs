using System.Collections.Generic;

namespace Rsobies.NuBuilder
{
    public interface INuView
    {
        void SetController(NuController controller);
        void Start();

        void ShowMsgBox(string msg);

        void SetError(string msgErr, LibTarget misTarget);
        void ClearError();

        void FillDirs(List<CheckedElement> elements);
        void FillHeaders(List<CheckedElement> elements);
        void Fill(NuSpec spec);
    }

    
}
