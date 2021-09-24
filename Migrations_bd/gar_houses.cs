using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrations_bd
{
    public class gar_houses
    {
        public long id {get; set;}

        public long oBJECTID {get; set;}

        public string oBJECTGUID {get; set;}

        public long cHANGEID {get; set;}

        public string hOUSENUM {get; set;}

        public string aDDNUM1 {get; set;}

        public string aDDNUM2 {get; set;}

        public string hOUSETYPE {get; set;}

        public string aDDTYPE1 {get; set;}

        public string aDDTYPE2 {get; set;}

        public string oPERTYPEID {get; set;}

        public long pREVID {get; set;}

        public long nEXTID {get; set;}

        public System.DateTime uPDATEDATE {get; set;}

        public System.DateTime sTARTDATE {get; set;}

        public System.DateTime eNDDATE {get; set;}

        public HOUSESHOUSEISACTUAL iSACTUAL {get; set;}

        public HOUSESHOUSEISACTIVE iSACTIVE {get; set;}
    }
}
