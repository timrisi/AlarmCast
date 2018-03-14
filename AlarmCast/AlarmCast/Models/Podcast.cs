using SQLite;
using System;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
using Newtonsoft.Json;

namespace AlarmCast {
	public class Podcast {
		public static readonly XNamespace
			feedburner = "http://rssnamespace.org/feedburner/ext/1.0";
		public static readonly XNamespace
			itunes = "http://www.itunes.com/dtds/podcast-1.0.dtd";

		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string Url { get; set; }
		public string Link { get; set; }
		public string Categories { get; set; }
		public string Copyright { get; set; }
		public string Language { get; set; }
		public string ImageUrl { get; set; }

		[Ignore]
		public List<Episode> Episodes { get; set; }

		public Podcast ()
		{
		}

		public Podcast (XElement element, string url)
		{
			this.Url = url;
			Title = element.Element ("title").Value;
			Link = element.Element ("link").Value;
			Description = element.Element ("description").Value;
			Language = element.Element ("language").Value;
			Copyright = element.Element ("copyright").Value;
			Categories = string.Join (", ", (from category in element.Descendants ("category")
			              					 select category.Value).Distinct ().ToArray ());
			ImageUrl = element.Element("image")?.Element("url")?.Value;
			Episodes = retrieveEpisodes (element).Result;
		}

		async Task<List<Episode>> retrieveEpisodes (XElement element)
		{
			var episodes = (from item in element.Descendants ("item")
			            select new Episode (item)).OrderByDescending (e => e.PubDate).ToList ();

			return episodes;
		}
	}
}

