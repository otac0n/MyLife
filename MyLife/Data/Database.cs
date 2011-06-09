// <copyright file="Database.cs" company="(none)">
//  Copyright © 2010 John Gietzen. All rights reserved.
// </copyright>
// <author>John Gietzen</author>

namespace MyLife.Data
{
    using System;
    using System.IO;
    using System.IO.IsolatedStorage;
    using System.Runtime.Serialization;

    public partial class Database
    {
        private const string DatabaseFileName = "Database.v1.xml";

        private static readonly DataContractSerializer serializer = new DataContractSerializer(typeof(Database));

        public Database()
        {
        }

        public static void Save(Database db)
        {
            using (var storage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (var file = storage.OpenFile(DatabaseFileName, FileMode.Create))
                {
                    serializer.WriteObject(file, db);
                }
            }
        }

        public static Database Load()
        {
            using (var storage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (!storage.FileExists(DatabaseFileName))
                {
                    return new Database();
                }

#if DEBUG
                using (var file = storage.OpenFile(DatabaseFileName, FileMode.Open))
                {
                    using (var reader = new StreamReader(file))
                    {
                        System.Diagnostics.Debug.WriteLine(reader.ReadToEnd());
                    }
                }
#endif

                using (var file = storage.OpenFile(DatabaseFileName, FileMode.Open))
                {
                    return (Database)serializer.ReadObject(file);
                }
            }
        }
    }
}
