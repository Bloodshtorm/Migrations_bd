using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Migrations_bd
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Diagnostics.Stopwatch.StartNew();
            XmlDocument xDocADDR = new XmlDocument();
            xDocADDR.Load(@"C:\Users\v\Desktop\1\AS_ADDR_OBJ.XML");
            // получим корневой элемент
            XElement rootElement = XElement.Parse(xDocADDR.InnerXml);
            xDocADDR = new XmlDocument();
            // обход всех узлов в корневом элементе
            ADDRESSOBJECTS addresobjs = DeserializeAddrObjs(rootElement);
            rootElement = null;
            //using (ApplicationContext db = new ApplicationContext())
            ApplicationContext db = new ApplicationContext();
            //{
            foreach (var obj in addresobjs.OBJECT.Where(x => x.ISACTUAL == ADDRESSOBJECTSOBJECTISACTUAL.Item1).Where(x => x.ISACTIVE == ADDRESSOBJECTSOBJECTISACTIVE.Item1))
            {
                gar_address_objects gar_addr_obj = new gar_address_objects
                {
                    ISACTIVE = obj.ISACTIVE,
                    ID = obj.ID,
                    NAME = obj.NAME,
                    CHANGEID = obj.CHANGEID,
                    ENDDATE = obj.ENDDATE,
                    ISACTUAL = obj.ISACTUAL,
                    LEVEL = obj.LEVEL,
                    NEXTID = obj.NEXTID,
                    OBJECTGUID = obj.OBJECTGUID,
                    OBJECTID = obj.OBJECTID,
                    OPERTYPEID = obj.OPERTYPEID,
                    PREVID = obj.PREVID,
                    STARTDATE = obj.STARTDATE,
                    TYPENAME = obj.TYPENAME,
                    UPDATEDATE = obj.UPDATEDATE
                };
                db.gar_AddObjCon.Add(gar_addr_obj);
            }
            addresobjs = null;

            xDocADDR = null;
            xDocADDR = new XmlDocument();
            xDocADDR.Load(@"C:\Users\v\Desktop\1\AS_HOUSEs.XML");

            rootElement = XElement.Parse(xDocADDR.InnerXml);
            HOUSES Houseobj = DeserializeHouses(rootElement);
            rootElement = null;

            foreach (var house in Houseobj.HOUSE.Where(x => x.ISACTIVE == HOUSESHOUSEISACTIVE.Item1))
            {
                gar_houses gar_house = new gar_houses
                {
                    id = house.ID,
                    OBJECTID = house.OBJECTID,
                    HOUSETYPE = house.HOUSETYPE,
                    CHANGEID = house.CHANGEID,
                    HOUSENUM = house.HOUSENUM,
                    ADDNUM1 = house.ADDNUM1,
                    ADDNUM2 = house.ADDNUM2,
                    ADDTYPE1 = house.ADDTYPE1,
                    ADDTYPE2 = house.ADDTYPE2,
                    PREVID = house.PREVID,
                    NEXTID = house.NEXTID,
                    ENDDATE = house.ENDDATE,
                    ISACTUAL = house.ISACTUAL,
                    ISACTIVE = house.ISACTIVE,
                    OBJECTGUID = house.OBJECTGUID,
                    OPERTYPEID = house.OPERTYPEID,
                    STARTDATE = house.STARTDATE,
                    UPDATEDATE = house.UPDATEDATE
                };
                db.gar_HousesCon.Add(gar_house);
            }
            xDocADDR = null;
            xDocADDR = new XmlDocument();
            xDocADDR.Load(@"C:\Users\v\Desktop\1\AS_HOUSEs.XML");

            rootElement = XElement.Parse(xDocADDR.InnerXml);
            ITEMS Adm_Delobj = DeserializeITEM(rootElement);
            rootElement = null;
            foreach (var adm_item in Adm_Delobj.ITEM)
            {
                gar_adm_hier gar_item = new gar_adm_hier
                {
                    id = adm_item.ID,
                    OBJECTID = adm_item.OBJECTID,
                    PARENTOBJID = adm_item.PARENTOBJID,
                    CHANGEID = adm_item.CHANGEID,
                    REGIONCODE = adm_item.REGIONCODE,
                    AREACODE = adm_item.AREACODE,
                    CITYCODE = adm_item.CITYCODE,
                    PLACECODE = adm_item.PLACECODE,
                    PLANCODE = adm_item.PLANCODE,
                    STREETCODE = adm_item.STREETCODE,
                    PREVID = adm_item.PREVID,
                    NEXTID = adm_item.NEXTID,
                    UPDATEDATE = adm_item.UPDATEDATE,
                    STARTDATE = adm_item.STARTDATE,
                    ENDDATE = adm_item.ENDDATE,
                    ISACTIVE = adm_item.ISACTIVE
                };
                db.gar_AdmHierCon.Add(gar_item);
            }

            db.SaveChanges();
            //xDocADDR = new XmlDocument();
            //xDocADDR.Load("C:/Users/Dmitry/Desktop/AS_ADM_HIER.XML");
            //// получим корневой элемент
            //XElement rootElementAdmin_Hier = XElement.Parse(xDocADDR.InnerXml);
            //// обход всех узлов в корневом элементе
            //DataTable tableITEMS = new DataTable();
            //tableITEMS.Columns.Add("AdmObjID", typeof(String));
            //tableITEMS.Columns.Add("AdmParID", typeof(String));
            //tableITEMS.Columns.Add("AdmISACTIVE", typeof(String));
            //ITEMS item = DeserializeITEM(rootElementAdmin_Hier);
            //foreach (var obj in item.ITEM)
            //{
            //    DataRow dr3 = tableITEMS.NewRow();
            //    dr3["HousesISA"] = long.Parse(obj.OBJECTID.ToString());
            //    dr3["HousesISA"] = long.Parse(obj.PARENTOBJID.ToString());
            //    dr3["HousesNum"] = obj.ISACTIVE.ToString();
            //     tableHOUSES.Rows.Add(dr3);
            //    /*AdmObjID.Add(long.Parse(obj.OBJECTID.ToString()));
            //    AdmParID.Add(long.Parse(obj.PARENTOBJID.ToString()));
            //    AdmISACTIVE.Add(obj.ISACTIVE.ToString());*/

            //}
        }

        private static ADDRESSOBJECTS DeserializeAddrObjs(XElement element)
        {
            StringReader reader = new StringReader(element.ToString());
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ADDRESSOBJECTS));
            return ((ADDRESSOBJECTS)xmlSerializer.Deserialize(reader));
        }
        private static HOUSES DeserializeHouses(XElement element)
        {
            StringReader reader = new StringReader(element.ToString());
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(HOUSES));
            return ((HOUSES)xmlSerializer.Deserialize(reader));
        }
        private static ITEMS DeserializeITEM(XElement element)
        {
            StringReader reader = new StringReader(element.ToString());
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ITEMS));
            return ((ITEMS)xmlSerializer.Deserialize(reader));
        }



    }
}
