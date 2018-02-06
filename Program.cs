using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Manatee.Trello.ManateeJson;
using Manatee.Trello;
using Manatee.Trello.WebApi;

namespace MonoGSoCIdeasPage
{
	class Program
	{
		// 
		// to get your user token
		// 
		public static void Main (string[] args)
		{
			var serializer = new ManateeSerializer ();
			TrelloConfiguration.Serializer = serializer;
			TrelloConfiguration.Deserializer = serializer;
			TrelloConfiguration.JsonFactory = new ManateeFactory ();
			TrelloConfiguration.RestClientProvider = new WebApiClientProvider ();
			TrelloAuthorization.Default.AppKey = Auth.AppKey;
			TrelloAuthorization.Default.UserToken = Auth.UserToken;

			var board = new Board ("tj9zKDV4");
			var list = board.Lists.Single (l => l.Name == "Ready");
			var readyCards = list.Cards;

			var page = new Page {
				Ideas = readyCards.Select (CardToIdea)
					.GroupBy (i => i.Area)
					.ToDictionary (g => g.Key, g => ((IEnumerable<Idea>)g).OrderBy (i => i.Title).ToList ())
			};

			var text = page.TransformText ();
			Console.WriteLine (text);

			var file = Path.Combine (Path.GetDirectoryName (typeof (Program).Assembly.Location), "page.md");
			File.WriteAllText (file, text);
		}

		internal static Section[] Sections = {
			new Section (
				"MonoDevelop",
				"MonoDevelop / Xamarin Studio IDE",
				"Help developers build applications by improving the cross-platform MonoDevelop / Xamarin Studio IDE"),
			new Section (
				"Compilers and Tools",
				"Compilers and Tools",
				"Work on Mono's tools and compilers"),
			new Section (
				"Mono Runtime",
				"Mono Runtime",
				"Improve the core Mono runtime and JIT"),
			new Section (
				"Mono .NET Integration",
				"Microsoft .NET and Mono integration",
				"Work on blending the worlds of open source .NET and Mono projects together",
@"Microsoft open sourced large chunks of code the past couple of years:

* ReferenceSource: the source code for the class libraries of .NET as it ships on Windows
* CoreFX: a fresh take on the distribution of the class libraries for a new, slimmer, smaller runtime
* CoreCLR: their C/C++ based runtime, JIT, GC for running on Mac, Linux and Windows
* Roslyn: Microsoft's C# and VB compiler as a service
* CodeContracts: the tools needed to instrument your code

We are tracking various ideas in the [.NET Integration in Mono](https://trello.com/b/vRPTMfdz/net-framework-integration-into-mono) trello board."),
			new Section (
				"Platforms and Bindings",
				"Platforms and Bindings",
				"Bindings to native toolkits and libraries, including GTK#, Xamarin.Android, Xamarin.iOS, Xamarin.Mac and UrhoSharp"),
		};

		static Idea CardToIdea (Card c)
		{
			var difficultyLabel = c.Labels.FirstOrDefault (l => l.Color == LabelColor.Orange);
			if (difficultyLabel == null) {
				throw new Exception ($"Idea '{c.Name}' has no difficulty label");
			}
			var areaLabel = c.Labels.FirstOrDefault (l => l.Color != LabelColor.Orange);
			if (areaLabel == null) {
				throw new Exception ($"Idea '{c.Name}' has no area label");
			}
			if (!c.Members.Any ()) {
				throw new Exception ($"Idea '{c.Name}' has no mentors");
			}
			return new Idea {
				Area = areaLabel.Name,
				Difficulty = difficultyLabel.Name.Split (' ').Last (),
				Title = c.Name,
				Mentors = string.Join (", ", c.Members.Select (m => m.FullName)),
				Description = c.Description
			};
		}
	}

	partial class Page
	{
		void WriteToc ()
		{
			bool first = true;
			foreach (var s in Program.Sections) {
				List<Idea> areaIdeas;
				if (!Ideas.TryGetValue (s.Key, out areaIdeas)) {
					continue;
				}

				if (first) {
					first = false;
				} else {
					WriteLine ("");
				}

				WriteLine ($"**[{s.Title}](#{Linkify (s.Title)})**");
				WriteLine ("");
				WriteLine (s.Description.TrimEnd ());
				WriteLine ("");

				foreach (var idea in areaIdeas) {
					WriteLine ($"* [{idea.Title}](#{Linkify (idea.Title)})");
				}
			}
		}

		string Linkify (string title)
		{
			var sb = new StringBuilder ();
			foreach (var c in title) {
				if (c == ' ' || c == '-') {
					sb.Append ('-');
				} else if (char.IsLetterOrDigit (c)) {
					sb.Append (char.ToLower (c));
				}
			}
			return sb.ToString ();
		}

		public IDictionary<string, List<Idea>> Ideas;

		void WriteIdeas ()
		{
			bool firstSection = true;
			foreach (var s in Program.Sections) {
				List<Idea> areaIdeas;
				if (!Ideas.TryGetValue (s.Key, out areaIdeas)) {
					continue;
				}

				if (firstSection) {
					firstSection = false;
				} else {
					WriteLine ("");
				}

				WriteLine ($"## {s.Title}");
				WriteLine ("");
				if (s.SectionHeader != null) {
					WriteLine (s.SectionHeader);
					WriteLine ("");
				}

				bool isFirst = true;
				foreach (var idea in areaIdeas) {
					if (isFirst) {
						isFirst = false;
					} else {
						WriteLine ("");
					}
					WriteLine (idea.TransformText ().Trim ());
				}
			}
		}
	}

	partial class Idea
	{
		public string Title;
		public string Area;
		public string Difficulty;
		public string Mentors;
		public string Description;
	}

	class Section
	{
		public string Key { get; private set; }
		public string Title { get; private set; }
		public string Description { get; private set; }
		public string SectionHeader { get; private set; }

		public Section (string key, string title, string description, string sectionHeader = null)
		{
			Key = key;
			Title = title;
			Description = description;
			SectionHeader = sectionHeader;
		}
	}
}
