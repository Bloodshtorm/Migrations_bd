using System;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Collections.Generic;
using System.IO;
using static Migrations_bd.PereKid;
using System.Data;
using System.Linq;
using Npgsql;
using System.Threading;

namespace Migrations_bd
{
    class Program
    {
        static void Main(string[] args)
        {
         
            Console.Read();


            XmlDocument xDocADDR = new XmlDocument();

            xDocADDR.Load(@"C:\Users\v\Desktop\1\AS_ADDR_OBJ.XML");
            // получим корневой элемент
            XElement rootElement = XElement.Parse(xDocADDR.InnerXml);
            xDocADDR = new XmlDocument();
            // обход всех узлов в корневом элементе

            ADDRESSOBJECTS addresobjs = DeserializeAddrObjs(rootElement);
            rootElement = null;
            using (ApplicationContext db = new ApplicationContext())
            {
                foreach (var obj in addresobjs.OBJECT.Where(x=> x.ISACTUAL == ADDRESSOBJECTSOBJECTISACTUAL.Item1))
                {
                    gar_address_objects user1 = new gar_address_objects 
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
                    db.gar_AddObjCon.Add(user1);
                }
                // создаем два объекта User
              
                // добавляем их в бд
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");

                // получаем объекты из бд и выводим на консоль
                var users = db.gar_AddObjCon.ToList();
                Console.WriteLine("Список объектов:");
                foreach (gar_address_objects u in users)
                {
                    Console.WriteLine($"{u.ID}.{u.NAME} - {u.ISACTIVE}");
                }
            }
         
            
            //xDocADDR = new XmlDocument();
            //xDocADDR.Load(@"C:\Users\v\Desktop\1\AS_HOUSEs.XML");
            //// получим корневой элемент
            ////XElement rootElementHouse = XElement.Parse(xDocADDR.InnerXml);
            //XElement rootElementHouse = XElement.Parse("HOUSES");
            //// обход всех узлов в корневом элементе
            //DataTable tableHOUSES = new DataTable();
            //tableHOUSES.Columns.Add("HousesID", typeof(String));
            //tableHOUSES.Columns.Add("HousesGUI", typeof(String));
            //tableHOUSES.Columns.Add("HousesNum", typeof(String));
            //tableHOUSES.Columns.Add("HousesISActiv", typeof(String));
            //tableHOUSES.Columns.Add("HousesISActual", typeof(String));
            //HOUSES Houseobj = DeserializeHouses(rootElementHouse);
            
            //NpgsqlConnection con = new NpgsqlConnection(conn_param);
            ////con.Open();
            //NpgsqlCommand cmd = new NpgsqlCommand();
            //foreach (var obj in Houseobj.HOUSE)
            //{
            //    var data = obj.PREVID;

            //    DataRow dr2 = tableHOUSES.NewRow();
            //    dr2["HousesID"] = long.Parse(obj.OBJECTID.ToString());
            //    dr2["HousesGUI"] = Guid.Parse(obj.OBJECTGUID.ToString());
            //    dr2["HousesNum"] = obj.HOUSENUM.ToString();
            //    dr2["HousesISActiv"] = obj.ISACTIVE.ToString();
            //    dr2["HousesISActual"] = obj.ISACTUAL.ToString();
            //    tableHOUSES.Rows.Add(dr2);

            //    cmd = new NpgsqlCommand("Insert into public.testtable(house_guid, house_num) value(" + obj.ADDNUM1.ToString() + ", " + obj.HOUSENUM.ToString() + ") ;",con);
            //    /*
            //    HousesID.Add(long.Parse(obj.OBJECTID.ToString()));
            //    HousesGUID.Add(Guid.Parse(obj.OBJECTGUID.ToString()));
            //    HousesISACTIVE.Add(obj.ISACTIVE.ToString());
            //    HousesISACTUAL.Add(obj.ISACTUAL.ToString());
            //    HousesNum.Add((obj.ISACTUAL.ToString()));
            //    */
            //}
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
            //var xmlSerial = xmlSerializer;
            //var xmlSeia765l = (ADDRESSOBJECTS)xmlSerializer.Deserialize(reader);
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
