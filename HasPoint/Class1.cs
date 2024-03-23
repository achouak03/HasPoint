
using netDxf;
using netDxf.Entities;
using System;
using System.Data.SQLite;
/**  
namespace HasPoint
{
   internal class Class1
   {
           static void Main(string[] args)
           {
             try
               {
                   // Create a new DXF document
                   DxfDocument document = new DxfDocument();

               // Connection string to SQLite database
               string databaseName = "C:\\Users\\hp\\Desktop\\Nouveau dossier\\D.db";
               string connectionString = $"Data Source={databaseName};Version=3;";
               using (SQLiteConnection connection = new SQLiteConnection(connectionString))
               {
                   connection.Open();
                   // Execute a query to retrieve points from the database
                   using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM Dp", connection))
                   {

                       using (SQLiteDataReader reader = command.ExecuteReader())
                       {



                           while (reader.Read())
                           {
                               double x = Convert.ToDouble(reader["X"]);
                               double y = Convert.ToDouble(reader["Y"]);
                               

                                   // Create a point entity
                                   Point point = new Point(new Vector2(x, y));

                               // Add the point entity to the document
                                document.Entities.Add(point);
                              // var points = new Vector2[7];
                              // points.Append(new(x,y));
                           }
                           }
                       }
                   }

                   // Save the DXF file
                   document.Save("points.dxf");

                   // Open the DXF file in LibreCAD
                   System.Diagnostics.Process.Start(@"C:\Program Files (x86)\LibreCAD\LibreCAD.exe", "points.dxf");
               }
               catch (Exception ex)
               {
                   Console.WriteLine($"Erreur: {ex.Message}");
               }
           }
       }
   
}
**/
