// <copyright file="Database.cs" company="(none)">
//  Copyright © 2010 John Gietzen. All rights reserved.
// </copyright>
// <author>John Gietzen</author>

namespace MyLife
{
    using System;
    using System.IO;
    using System.IO.IsolatedStorage;
    using System.Net;
    using System.Runtime.Serialization;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Ink;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Animation;
    using System.Windows.Shapes;

    public class Database
    {
        private static readonly DataContractSerializer serializer = new DataContractSerializer(typeof(Database));

        private Database()
        {
        }

        public static void Save(Database db)
        {
            using (var storage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (var file = storage.OpenFile("Database.xml", FileMode.Create))
                {
                    serializer.WriteObject(file, db);
                }
            }
        }

        public static Database Load()
        {
            using (var storage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                IsolatedStorageFileStream file = null;
                try
                {
                    file = storage.OpenFile("Database.xml", FileMode.Open);
                    return (Database)serializer.ReadObject(file);
                }
                catch (FileNotFoundException)
                {
                    return new Database();
                }
                finally
                {
                    if (file != null)
                    {
                        file.Dispose();
                        file = null;
                    }
                }
            }
        }
    }
}
