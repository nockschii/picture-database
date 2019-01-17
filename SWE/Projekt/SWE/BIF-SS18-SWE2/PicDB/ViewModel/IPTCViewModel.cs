using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces.ViewModels;
using PicDB.Model;

namespace PicDB.ViewModel
{
    class IPTCViewModel : IIPTCViewModel
    {
        private IPTCModel _iptcMdl = new IPTCModel();
        private List<string> _copyRightNotices = new List<string>();
      
        public IPTCViewModel() { }
        public IPTCViewModel(IPTCModel mdl)
        {
            _iptcMdl = mdl;
            _copyRightNotices.Add("All rights reserved, CC-BY");
            _copyRightNotices.Add("All rights reserved, CC-BY-SA");
            _copyRightNotices.Add("All rights reserved, CC-BY-ND");
            _copyRightNotices.Add("All rights reserved, CC-BY-NC");
            _copyRightNotices.Add("All rights reserved, CC-BY-NC-SA");
            _copyRightNotices.Add("All rights reserved, CC-BY-NC-ND");
        }

        /// <summary>
        /// A list of keywords
        /// </summary>
        public string Keywords{ get => _iptcMdl.Keywords; set => _iptcMdl.Keywords = value; }

        /// <summary>
        /// Name of the photographer
        /// </summary>
        public string ByLine{ get  => _iptcMdl.ByLine;  set => _iptcMdl.ByLine = value; }

        /// <summary>
        /// copyright noties. 
        /// </summary>
        public string CopyrightNotice { get => _iptcMdl.CopyrightNotice; set => _iptcMdl.CopyrightNotice = value; }

        /// <summary>
        /// A list of common copyright noties. e.g. All rights reserved, CC-BY, CC-BY-SA, CC-BY-ND, CC-BY-NC, CC-BY-NC-SA, CC-BY-NC-ND
        /// </summary>
        public IEnumerable<string> CopyrightNotices => _copyRightNotices;

        /// <summary>
        /// Summary/Headline of the picture
        /// </summary>
        public string Headline { get => _iptcMdl.Headline; set => _iptcMdl.Headline = value; }

        /// <summary>
        /// Caption/Abstract, a description of the picture
        /// </summary>
        public string Caption { get => _iptcMdl.Caption; set => _iptcMdl.Caption = value; }
    }
}
