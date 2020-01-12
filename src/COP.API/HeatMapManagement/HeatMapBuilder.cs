using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;
using System.IO;
using System.Drawing;

namespace COP.API.HeatMapManagement
{
    public class HeatMapBuilder
    {
        public void CreateMapFile(XmlDocument xDoc, string filename)
        {
            ////Calculate image size
            //XmlNode xRow = xDoc.SelectSingleNode("//nrow");
            //int noOfRows = int.Parse(xRow.InnerText);
            //XmlNode xCol = xDoc.SelectSingleNode("//ncols");
            //int noOfCols = int.Parse(xCol.InnerText);
            //int sizeFactor = 100;


            //Bitmap bitmap = new Bitmap(sizeFactor * noOfCols, sizeFactor * noOfRows, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            //using (Graphics graphics = Graphics.FromImage(bitmap))
            //{
            //    XmlNodeList xRows = xDoc.SelectNodes("/Root/data");
            //    int rowNo = 0;
            //    foreach (XmlNode row in xRows)
            //    {
            //        int ColNo = 0;
            //        XmlNodeList xCols = row.SelectNodes(".//data");
            //        foreach (XmlNode col in xCols)
            //        {
            //            double val = double.Parse(col.InnerText, System.Globalization.CultureInfo.InvariantCulture);
            //            val -= 30;
            //            val *= (255 / 90);
            //            int bright = (int)Math.Round(Math.Min(val, 255.0));
            //            using (System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(Color.FromArgb(255, 255 - bright, 255 - bright)))
            //            {
            //                graphics.FillRectangle(myBrush, new Rectangle(ColNo * sizeFactor, rowNo * sizeFactor, sizeFactor, sizeFactor));

            //            }
            //            ColNo++;
            //        }
            //        // bitmap.Save("C:\\Test\\Test2.png");
            //        rowNo++;
            //    }


            //}

            XmlNodeList xRow = xDoc.SelectNodes("//density_map[density_map]");
            int noOfRows = xRow.Count;
            XmlNodeList xCol = xDoc.SelectNodes("//density_map[1]/density_map");
            int noOfCols = xCol.Count;
            int sizeFactor = 100;


            Bitmap bitmap = new Bitmap(sizeFactor * noOfCols, sizeFactor * noOfRows, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                XmlNodeList xRows = xDoc.SelectNodes("//density_map[density_map]");
                int rowNo = 0;
                foreach (XmlNode row in xRows)
                {
                    int ColNo = 0;
                    XmlNodeList xCols = row.SelectNodes(".//density_map");
                    foreach (XmlNode col in xCols)
                    {
                        double val = double.Parse(col.InnerText, System.Globalization.CultureInfo.InvariantCulture);
                        //val -= 30;
                        val *= (255 / 3);
                        int bright = (int)Math.Round(Math.Min(val, 255.0));
                        using (System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(Color.FromArgb(255, 255 - bright, 255 - bright)))
                        {
                            graphics.FillRectangle(myBrush, new Rectangle(ColNo * sizeFactor, rowNo * sizeFactor, sizeFactor, sizeFactor));

                        }
                        ColNo++;
                    }
                    // bitmap.Save("C:\\Test\\Test2.png");
                    rowNo++;
                }


            }
            bitmap.Save(filename);
        }
    }
}
