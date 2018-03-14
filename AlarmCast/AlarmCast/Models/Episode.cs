using System;
using System.Xml.Linq;
using SQLite;
using SQLite.Net;
using SQLite.Net.Attributes;

namespace AlarmCast {
	public class Episode {
		public static readonly XNamespace feedburner = "http://rssnamespace.org/feedburner/ext/1.0";
		public static readonly XNamespace itunes = "http://www.itunes.com/dtds/podcast-1.0.dtd";

		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public int PodcastId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string Link { get; set; }
		public string Url { get; set; }
		public string Author { get; set; }
		public string Category { get; set; }
		public DateTime PubDate { get; set; }
		public bool ItunesExplicit { get; set; }
		public string ItunesDuration { get; set; }
		public string ItunesAuthor { get; set; }
		public string ItunesSubtitle { get; set; }
		public string ItunesSummary { get; set; }
		public string FeedburnerOrigEnclosureLink { get; set; }
		public bool Played { get; set; }
		//public string[] ItunesKeywords { get; set; }

		public Episode ()
		{
		}

		public Episode (XElement item)
		{
			Title = item.Element ("title").Value;
			PubDate = DateTime.Parse (item.Element ("pubDate").Value);
			Url = item.Element ("enclosure").Attribute ("url").Value;
		}
	}
}

