using Procesiranje_posiljaka_skladiste.DAL;
using Procesiranje_posiljaka_skladiste.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using System.Windows;
using System.Data.SqlClient;
using System.Data;

namespace Procesiranje_posiljaka_skladiste.Global
{
    static class CRUD
    {



        public static void spremi(ShipmentItem d)
        {
            int povrat = spremi_pom(d);
            if (povrat == 0)
            {
                string messageBoxText = "Pošiljka sa prijamnim brojem:'" + d.Barcode + "' već postoji. Želite li snimiti preko njega?";
                string caption = "Programčić";
                MessageBoxButton button = MessageBoxButton.YesNo;
                MessageBoxImage icon = MessageBoxImage.Warning;
                // Display message box
                // MessageBox.Show(messageBoxText, caption, button, icon);
                // Display message box
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);



                // Process message box results
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        {
                            try
                            {

                                povrat = CRUD.spremi_preko(d);


                            }
                            catch
                            {
                                MessageBox.Show("Neuspjeh");
                            }

                            if (povrat == -1)
                                MessageBox.Show("Neuspjeh");
                            break;
                        }
                    case MessageBoxResult.No:
                        {
                            break;
                        }

                }

            }
            else if (povrat == -1)
                MessageBox.Show("Nešto ne valja!");
            else if (povrat == 1)
                MessageBox.Show("Uspješno spremljeno!");

        }


        public static int spremi_pom(ShipmentItem d)
        {
            try
            {
                using (var db = new PodaciContext())
                {

                    ShipmentItem temp = db.ShipmentItems.FirstOrDefault(x => x.Barcode == d.Barcode);

                    if (temp != null)
                    {
                        //MessageBox.Show("Vec postoji!");
                        return 0;
                    }

                    db.ShipmentItems.Add(d);
                    spremi_dodatno(db);
                }
                return 1;
            }
            catch
            {
                return -1;
            }

        }

        public static int spremi_preko(ShipmentItem d)
        {
            try
            {
                using (var db = new PodaciContext())
                {

                    ShipmentItem temp = db.ShipmentItems.Include("Shipment").FirstOrDefault(x => x.Barcode == d.Barcode);

                    if (temp != null)
                    {
                        d.Id = temp.Id;
                        d.ShipmentId = temp.ShipmentId;
                        d.Shipment.Id = temp.Shipment.Id;
                        db.Set<ShipmentItem>().AddOrUpdate(d);
                        db.Set<Shipment>().AddOrUpdate(d.Shipment);
                        //db.Entry(d).State = EntityState.Modified;
                        spremi_dodatno(db);
                        return 1;
                    }



                }
                return -1;
            }
            catch (Exception ee)
            {
                return -1;
            }

        }

        private static void spremi_dodatno(PodaciContext db)
        {
            ZP.IsChanged = false;
            db.SaveChanges();

        }


        public static void otvori(string reception_number, ShipmentItem d, List<bool> povrat)
        {
            try
            {
                using (var db = new PodaciContext())
                {

                    ShipmentItem temp = db.ShipmentItems.Include("Shipment").FirstOrDefault(x => x.Barcode == reception_number);

                    if (temp != null)  // ovo dole se radi jer funkcija CRUD.otvori briše referencu na ShipmentItem(d) 
                    {
                        var props = temp.GetType().GetProperties();

                        foreach (var prop in props)
                        {
                            string s = prop.PropertyType.Name;
                            if (prop.PropertyType.Name != "ObservableCollection`1")
                            {
                                prop.SetValue(d, prop.GetValue(temp, null));


                            }
                        }
                  
                        povrat.Add(true);

                    }


                }

            }
            catch
            {
                MessageBox.Show("Greška kod otvaranja");
            }

        }



        public static bool spremiDANE(ShipmentItem d)
        {

            if (!ZP.IsChanged) // nema promjene, ne treba snimat
                return true;


            string messageBoxText = "Želite li spremiti pošiljku prije učitavanja nove?";
            string caption = "Programčić";
            MessageBoxButton button = MessageBoxButton.YesNoCancel;
            MessageBoxImage icon = MessageBoxImage.Warning;
            // Display message box
            // MessageBox.Show(messageBoxText, caption, button, icon);
            // Display message box
            MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);



            // Process message box results
            switch (result)
            {
                case MessageBoxResult.Yes:
                    {
                        try
                        {

                            CRUD.spremi(d);
                        }
                        catch
                        {
                            MessageBox.Show("Neuspjeh");
                        }

                        return true;

                    }
                case MessageBoxResult.No:
                    {
                        return true;

                    }
                case MessageBoxResult.Cancel:
                    {
                        return false;

                    }

            }
            return false;


        }






        //--------------------------         WEB BAZA         -----------------------------------------------------


        public static void open_web_db(ShipmentItem d)
        {

            using (SqlConnection conn = sql_conn())
            {
                try
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("SELECT * FROM [ShipmentItems] INNER JOIN [Shipments] ON [ShipmentItems].[ShipmentId] = [Shipments].[Id] where Barcode='" + d.Barcode + "'", conn);


                    SqlDataReader myReader = null;

                    myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                    {

                        popuni_sve_varijable_u_klasi(d, myReader);

                        //d.pickup_name = (myReader["pickup_name"].ToString());
                        //d.pickup_street = (myReader["pickup_street"].ToString());
                        //d.pickup_house_number = (myReader["pickup_house_number"].ToString());
                        //d.pickup_house_number_suffix = (myReader["pickup_house_number_suffix"].ToString());
                        //d.pickup_zip = (myReader["pickup_zip"].ToString());
                        //d.pickup_city = (myReader["pickup_city"].ToString());
                        //d.damage = Convert.ToInt32(pretvori(myReader["damage"].ToString()));
                        //d.weight = pretvori(myReader["weight"].ToString());
                    }
                    if (!myReader.HasRows)  // ne postoje podaci o pošiljci, provjerava se ID kupca
                    {
                        myReader.Close();
                        myCommand = new SqlCommand("SELECT * FROM [customers] where reception_number='" + d.Barcode + "'", conn);
                        myReader = null;

                        myReader = myCommand.ExecuteReader();

                        while (myReader.Read())
                        {
                            prazni_sve_varijable_u_klasi(d);
                            d.Shipment.RecipientName = (myReader["RecipientName"].ToString()) ;
                        }
                        if (!myReader.HasRows)
                        {
                            prazni_sve_varijable_u_klasi(d);
                            MessageBox.Show("Ne postoji prijamni broj u bazi!!");
                        }
                    }

                }
                catch (Exception ee)
                {
                    prazni_sve_varijable_u_klasi(d);
                    //Console.WriteLine(ee.ToString());
                    MessageBox.Show("Neuspjelo spajanje na web bazu!!", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                }



            }


        }


        public static bool save_web_db(ShipmentItem d)
        {

            using (SqlConnection conn = sql_conn())
            {
                try
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand();
                    myCommand.Connection = conn;
                    myCommand.CommandText = "UPDATE [ShipmentItems] SET RealWeightNet = @wt, Heigth = @he, Width = @wi Where Length = @le ";

                    myCommand.Parameters.AddWithValue("@wt", Funkcije.pretvori(d.RealWeightNet));

                    myCommand.Parameters.AddWithValue("@he", Funkcije.pretvori(d.Heigth));
                    myCommand.Parameters.AddWithValue("@wi", Funkcije.pretvori(d.Width));
                    myCommand.Parameters.AddWithValue("@le", Funkcije.pretvori(d.Length));

                   


                    

                     myCommand.ExecuteNonQuery();

             

                }
                catch (Exception ee)
                {

                    MessageBox.Show("Neuspjelo spajanje na web bazu!!", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }



            }
            return true;

        }

        private static void prazni_sve_varijable_u_klasi(ShipmentItem d)
        {
            var props = d.GetType().GetProperties();

            foreach (var prop in props)
            {
                string s = prop.PropertyType.Name;
                if (prop.Name == "Barcode") continue;
                if (s == "Int32"  || s == "Double")
                    prop.SetValue(d, 0);
                if (s == "Int16")
                    prop.SetValue(d.Shipment, new Int16());
                if (s == "Boolean")
                    prop.SetValue(d, false);
                else if (s == "String")
                    prop.SetValue(d, "");
                else if (s == "Nullable`1" || s == "DateTime")
                    prop.SetValue(d, null);


            }

             props = d.Shipment.GetType().GetProperties();

            foreach (var prop in props)
            {
                string s = prop.PropertyType.Name;

                if (s == "Int32" || s == "Double" )
                    prop.SetValue(d.Shipment, 0);
                if ( s == "Int16" )
                    prop.SetValue(d.Shipment, new Int16());
                if (s == "Boolean")
                    prop.SetValue(d.Shipment, false);
                else if (s == "String")
                    prop.SetValue(d.Shipment, "");
                else if (s == "Nullable`1" || s == "DateTime")
                    prop.SetValue(d.Shipment, null);

            }

        }

        private static void popuni_sve_varijable_u_klasi(ShipmentItem d, SqlDataReader myReader)
        {
            var props = d.GetType().GetProperties();

            foreach (var prop in props)
            {
                string s = prop.PropertyType.FullName;
                if (prop.Name == "Barcode" || s.Contains("ObservableCollection")) continue;

                if (s.Contains("Nullable") && myReader[prop.Name].ToString() == "")
                {
                    prop.SetValue(d, null);
                }
                else if (s.Contains("Int32"))
                    prop.SetValue(d, Convert.ToInt32(Funkcije.pretvori((myReader[prop.Name]))));
                else if (s.Contains("Int16"))
                    prop.SetValue(d, Convert.ToInt16(Funkcije.pretvori((myReader[prop.Name]))));
                else if (s.Contains("Double"))
                    prop.SetValue(d, Funkcije.pretvori((myReader[prop.Name])));
                else if (s.Contains("Decimal"))
                    prop.SetValue(d, (decimal)Funkcije.pretvori((myReader[prop.Name])));
                else if (s.Contains("Boolean") || s.Contains("DateTime") || s.Contains("Byte"))
                    prop.SetValue(d, (myReader[prop.Name]));
                else if (s.Contains("String"))
                    prop.SetValue(d, (myReader[prop.Name]).ToString());

            }

             props = d.Shipment.GetType().GetProperties();

            foreach (var prop in props)
            {
                string s = prop.PropertyType.FullName;
                if (prop.Name == "Barcode" || s.Contains("ObservableCollection")) continue;
                if ((s.Contains("Nullable") || s.Contains("Byte")) && myReader[prop.Name].ToString() == "")
                {
                    prop.SetValue(d.Shipment, null);
                }
                else if (s.Contains("Int32"))
                    prop.SetValue(d.Shipment, Convert.ToInt32(Funkcije.pretvori((myReader[prop.Name]))));
                else if (s.Contains("Int16"))
                    prop.SetValue(d.Shipment, Convert.ToInt16(Funkcije.pretvori((myReader[prop.Name]))));
                else if (s.Contains("Double"))
                    prop.SetValue(d.Shipment, Funkcije.pretvori((myReader[prop.Name])));
                else if (s.Contains("Decimal"))
                    prop.SetValue(d.Shipment, (decimal)Funkcije.pretvori((myReader[prop.Name])));
                else if (s.Contains("Boolean") || s.Contains("DateTime") || s.Contains("Byte"))
                    prop.SetValue(d.Shipment, (myReader[prop.Name]));
                else if (s.Contains("String"))
                    prop.SetValue(d.Shipment, (myReader[prop.Name]).ToString());

            }

        }

        private static string HasColumn(this IDataRecord dr, string columnName)
        {
            for (int i = 0; i < dr.FieldCount; i++)
            {
                if (dr.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                    return dr[columnName].ToString();
            }
            return "";
        }

        private static SqlConnection sql_conn()
        {
            //SqlConnection myConnection = new SqlConnection("user id=sa;" +
            //                         "password=mips!123;server=10.7.185.26;" +
            //                         "Trusted_Connection=true;" +
            //                         "database=paketskaDEV; " +
            //                         "Integrated Security = false; " +
            //                         "connection timeout=30");



            SqlConnection myConnection = new SqlConnection(
                               @"server=(localdb)\MSSQLLocalDB;" +
                               "Trusted_Connection=true;" +
                               "database=Procesiranje_web_baza; " +
                               "Integrated Security = true; " +
                               "connection timeout=3");


            return myConnection;
        }

        //--------------------------         WEB BAZA         -----------------------------------------------------










    }
}
