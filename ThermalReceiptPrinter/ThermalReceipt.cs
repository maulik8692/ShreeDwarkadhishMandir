using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ThermalReceiptPrinter
{
    public class ThermalReceipt
    {
        private PrintDocument PrintDocument;
        private Graphics graphics;

        public ThermalReceipt()
        {
            PrintDocument = new PrintDocument();
            PrintDocument.PrinterSettings.PrinterName = "doPDF 11";

            PrintDocument.PrintPage += new PrintPageEventHandler(FormatPage);
            PrintDocument.Print();
        }

        private void FormatPage(object sender, PrintPageEventArgs e)
        {
            graphics = e.Graphics;
            Font minifont = new Font("Arial", 5);
            Font itemfont = new Font("Arial", 5);
            Font smallfont = new Font("Arial", 8);
            Font mediumfont = new Font("Arial", 10);
            Font largefont = new Font("Arial", 12);
            int Offset = 10;
            int smallinc = 10, mediuminc = 12, largeinc = 15, iteminc = 8;

            Offset = Offset + largeinc + 10;

            WebClient wc = new WebClient();
            byte[] bytes = wc.DownloadData("https://drive.google.com/uc?id=1bzVwrzkUSE-FvIOAYpC7O2yq49tPaYOj");
            MemoryStream ms = new MemoryStream(bytes);
            System.Drawing.Image img = System.Drawing.Image.FromStream(ms);

            e.Graphics.DrawImage(img, 10, 5, 50, 52);

            graphics.DrawString("श्री द्वारकेशो जयती", itemfont,
                    new SolidBrush(System.Drawing.Color.Black), 10 + 50, 5);
            Offset = 5 + iteminc + 5;

            graphics.DrawString("ગોસ્વામી શ્રી વ્રજેશકુમારેજી મહારાજશ્રી (કાંકરોલી)", itemfont,
                    new SolidBrush(System.Drawing.Color.Black), 10 + 50, Offset);
            Offset = Offset + iteminc + 5;

            graphics.DrawString("Shree Dwarkadhish Mandir", itemfont,
                    new SolidBrush(System.Drawing.Color.Black), 10 + 50, Offset);
            Offset = Offset + iteminc + 5;

            graphics.DrawString("Registration No: A 1954", itemfont,
                    new SolidBrush(System.Drawing.Color.Black), 10 + 50, Offset);
            Offset = Offset + iteminc + 5;

            graphics.DrawString("Bahuva Ni Pole, Raipur Chakla, Raipur", itemfont,
                    new SolidBrush(System.Drawing.Color.Black), 10 + 50, Offset);
            Offset = Offset + iteminc + 5;

            graphics.DrawString("Ahmedabad 380001", itemfont,
                    new SolidBrush(System.Drawing.Color.Black), 10 + 50, Offset);
            Offset = Offset + iteminc + 5;

            graphics.DrawString("_______________________________________________", itemfont, new SolidBrush(System.Drawing.Color.Black), 10, Offset);
            Offset = Offset + iteminc + 5;

            graphics.DrawString("Receipt No: 1732                                     Date: 30-Nov-2021", itemfont, new SolidBrush(System.Drawing.Color.Black), 10, Offset);
            Offset = Offset + iteminc + 5;

            graphics.DrawString("Shree Vaishnav", itemfont, new SolidBrush(System.Drawing.Color.Black), 10, Offset);
            Offset = Offset + iteminc + 5;

            graphics.DrawString("Dan Bhet", itemfont, new SolidBrush(System.Drawing.Color.Black), 10, Offset);
            Offset = Offset + iteminc + 5;

            graphics.DrawString("30-Nov-2021                                                       ₹ 20000.00", itemfont, new SolidBrush(System.Drawing.Color.Black), 10, Offset);
            Offset = Offset + iteminc + 5;

            graphics.DrawString("_______________________________________________", itemfont, new SolidBrush(System.Drawing.Color.Black), 10, Offset);
            Offset = Offset + iteminc + 5;

            graphics.DrawString("Total                                                                    ₹ 20000.00", itemfont, new SolidBrush(System.Drawing.Color.Black), 10, Offset);
            Offset = Offset + iteminc + 5;


            //// Cut Paper for Next Bill
            string gS = Convert.ToString((char)29);
            string esc = Convert.ToString((char)27);

            string command = string.Empty;
            command = esc + "@";
            command += gS + "V" + (char)1;
            graphics.DrawString(command, itemfont, 
                new SolidBrush(System.Drawing.Color.Black), 0, Offset);
        }
    }
}
