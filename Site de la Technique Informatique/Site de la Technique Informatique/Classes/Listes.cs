using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site_de_la_Technique_Informatique.Classes
{
    public class Listes : Dictionary<int, string>
    {
        //Pour créer une liste dans un dropDownList
    }

    public class listeHeure : Dictionary<short, string>
    {
        public listeHeure()
        {
            this.Add(0, "0h");
            this.Add(1, "1h");
            this.Add(2, "2h");
            this.Add(3, "3h");
            this.Add(4, "4h");
            this.Add(5, "5h");
            this.Add(6, "6h");
            this.Add(7, "7h");
            this.Add(8, "8h");
            this.Add(9, "9h");
            this.Add(10, "10h");
            this.Add(11, "11h");
            this.Add(12, "12h");
            this.Add(13, "13h");
            this.Add(14, "14h");
            this.Add(15, "15h");
            this.Add(16, "16h");
            this.Add(17, "17h");
            this.Add(18, "18h");
            this.Add(19, "19h");
            this.Add(20, "20h");
            this.Add(21, "21h");
            this.Add(22, "22h");
            this.Add(23, "23h");
        }
    }

    public class listeMinute : Dictionary<short, string>
    {
        public listeMinute()
        {
            this.Add(00, "00");
            this.Add(05, "05");
            this.Add(10, "10");
            this.Add(15, "15");
            this.Add(20, "20");
            this.Add(25, "25");
            this.Add(30, "30");
            this.Add(35, "35");
            this.Add(40, "40");
            this.Add(45, "45");
            this.Add(50, "50");
            this.Add(55, "55");
        }
    }

    public class listeMois : Dictionary<short, string>
    {
        public listeMois()
        {
            this.Add(0, "");
            this.Add(1, "01");
            this.Add(1, "01");
            this.Add(2, "02");
            this.Add(3, "03");
            this.Add(4, "04");
            this.Add(5, "05");
            this.Add(6, "06");
            this.Add(7, "07");
            this.Add(8, "08");
            this.Add(9, "09");
            this.Add(10, "10");
            this.Add(11, "11");
            this.Add(12, "12");
        }
    }

    public class listeAnnees : Dictionary<short, string>
    {
        public listeAnnees()
        {
            this.Add(Convert.ToInt16(DateTime.Now.Year), DateTime.Now.Year.ToString());
            this.Add(Convert.ToInt16(DateTime.Now.Year + 1), (DateTime.Now.Year + 1).ToString());
            this.Add(Convert.ToInt16(DateTime.Now.Year + 2), (DateTime.Now.Year + 2).ToString());
            this.Add(Convert.ToInt16(DateTime.Now.Year + 3), (DateTime.Now.Year + 3).ToString());
            this.Add(Convert.ToInt16(DateTime.Now.Year + 4), (DateTime.Now.Year + 4).ToString());
            this.Add(Convert.ToInt16(DateTime.Now.Year + 5), (DateTime.Now.Year + 5).ToString());
            this.Add(Convert.ToInt16(DateTime.Now.Year + 6), (DateTime.Now.Year + 6).ToString());
            this.Add(Convert.ToInt16(DateTime.Now.Year + 7), (DateTime.Now.Year + 7).ToString());
        }
    }

}