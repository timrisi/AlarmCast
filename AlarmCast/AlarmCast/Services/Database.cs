using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Interop;
#if __IOS__
using SQLite.Net.Platform.XamarinIOS;
#endif

namespace AlarmCast.Services {
	public class Database : SQLiteAsyncConnection {
#if IOS
		static string baseDir = Directory.GetParent (
			Environment.GetFolderPath (Environment.SpecialFolder.Personal)).ToString () + "/Documents";
#else
		static string baseDir = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
#endif
		//		public static string DatabaseFile = baseDir + "/Documents/AlarmCast.db";
		public static string DatabaseFile = Path.Combine(baseDir, "AlarmCast.db");

		public static Database Main { get; private set; }

		internal Database(Func<SQLiteConnectionWithLock> connection) : base(connection)
		{
			CreateTableAsync<Episode> ();
			CreateTableAsync<Podcast> ();
		}

		static Database ()
		{
			//if (File.Exists (Util.DatabaseFile))
			//	File.Delete (Util.DatabaseFile);
			var platform = new SQLitePlatformIOS();
			var param = new SQLiteConnectionString(DatabaseFile, false);
			if (Main == null)
				Main = new Database (() => new SQLiteConnectionWithLock(platform, param));
		}
	}
}

