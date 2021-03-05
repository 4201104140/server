using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grand.Framework.UI
{
    public partial interface IPageHeadBuilder
    {
        void AddTitleParts(string part);
        void AppendTitleParts(string part);
        string GenerateTitle(bool addDefaultTitle);

        void AddMetaDescriptionParts(string part);
        void AppendMetaDescriptionParts(string part);
        string GenerateMetaDescription();
    }
}
