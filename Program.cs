using System;
using Manatee.Trello.ManateeJson;
using Manatee.Trello;
using Manatee.Trello.RestSharp;
using System.Linq;
using System.Collections.Generic;

namespace MonoGSoCIdeasPage
{
	class MainClass
	{
		// 
		// to get your user token
		// 
		public static void Main (string[] args)
		{
			var serializer = new ManateeSerializer();
			TrelloConfiguration.Serializer = serializer;
			TrelloConfiguration.Deserializer = serializer;
			TrelloConfiguration.JsonFactory = new ManateeFactory();
			TrelloConfiguration.RestClientProvider = new RestSharpClientProvider();
			TrelloAuthorization.Default.AppKey = Auth.AppKey;
			TrelloAuthorization.Default.UserToken = Auth.UserToken;


			var board = new Board("tj9zKDV4");
			var list = board.Lists.Single (l => l.Name == "Ready");
			var readyCards = list.Cards;

			var page = new Page ();

			page.Ideas = readyCards.Select (c => new Idea {
				Area = c.Labels.First (l => l.Color != LabelColor.Orange).Name,
				Difficulty = c.Labels.First (l => l.Color == LabelColor.Orange).Name.Split (' ').Last (),
				Title = c.Name,
				Mentors = string.Join (", ", c.Members.Select (m => m.FullName)),
				Description = c.Description
			}).GroupBy (i => i.Area).ToDictionary (g => g.Key, g => (IEnumerable<Idea>)g);

			Console.WriteLine (page.TransformText ());
		}
	}

	partial class Page
	{
		public IDictionary<string,IEnumerable<Idea>> Ideas;

		void WriteIdeas (string area)
		{
			IEnumerable<Idea> areaIdeas;
			if (Ideas.TryGetValue (area, out areaIdeas)) {
				bool isFirst = false;
				foreach (var idea in areaIdeas) {
					if (!isFirst) {
						isFirst = true;
						WriteLine ("");
					}
					WriteLine (idea.TransformText ());
				}
			} else {
				WriteLine ("**We don't have any ideas in this area right now, but feel free to propose your own!**");
			}
		}

		const string MonoDotNetIntegration = "Mono .NET Integration";
		const string MonoRuntime = "Mono Runtime";
		const string CompilersAndTools = "Compilers and Tools";
		const string MonoDevelop = "MonoDevelop";
		const string GtkSharpAndBindings = "Gtk# and Bindings";
	}

	partial class Idea
	{
		public string Title;
		public string Area;
		public string Difficulty;
		public string Mentors;
		public string Description;
	}
}
