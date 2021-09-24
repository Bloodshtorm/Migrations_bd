using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrations_bd
{
    public class gar_adm_hier
    {
        public long id {get; set;}

        public long oBJECTID {get; set;}

        public long pARENTOBJID {get; set;}

        public long cHANGEID {get; set;}

        public string rEGIONCODE {get; set;}

        public string aREACODE {get; set;}

        public string cITYCODE {get; set;}

        public string pLACECODE {get; set;}

        public string pLANCODE {get; set;}

        public string sTREETCODE {get; set;}

        public long pREVID {get; set;}


        public long nEXTID {get; set;}

        public System.DateTime uPDATEDATE {get; set;}

        public System.DateTime sTARTDATE {get; set;}

        public System.DateTime eNDDATE {get; set;}

        public ITEMSITEMISACTIVE iSACTIVE {get; set;}
    }
}
