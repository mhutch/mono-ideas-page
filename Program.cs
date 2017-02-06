﻿using System;
using Manatee.Trello.ManateeJson;
using Manatee.Trello;
using Manatee.Trello.RestSharp;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MonoGSoCIdeasPage
{
	class MainClass
	{
		// 
		// to get your user token
		// 
		public static void Main (string [] args)
		{
			var serializer = new ManateeSerializer ();
			TrelloConfiguration.Serializer = serializer;
			TrelloConfiguration.Deserializer = serializer;
			TrelloConfiguration.JsonFactory = new ManateeFactory ();
			TrelloConfiguration.RestClientProvider = new RestSharpClientProvider ();
			TrelloAuthorization.Default.AppKey = Auth.AppKey;
			TrelloAuthorization.Default.UserToken = Auth.UserToken;


			var board = new Board ("tj9zKDV4");
			var list = board.Lists.Single (l => l.Name == "Ready");
			var readyCards = list.Cards;

			var page = new Page ();

			page.Ideas = readyCards.Select (c => new Idea {
				Area = c.Labels.First (l => l.Color != LabelColor.Orange).Name,
				Difficulty = c.Labels.First (l => l.Color == LabelColor.Orange).Name.Split (' ').Last (),
				Title = c.Name,
				Mentors = string.Join (", ", c.Members.Select (m => m.FullName)),
				Description = c.Description
			}).GroupBy (i => i.Area).ToDictionary (g => g.Key, g => ((IEnumerable<Idea>)g).ToList ());

			Console.WriteLine (page.TransformText ());
		}

		internal static Section [] Sections = {
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

- ReferenceSource: the source code for the class libraries of .NET as it ships on Windows
- CoreFX: a fresh take on the distribution of the class libraries for a new, slimmer, smaller runtime
- CoreCLR: their C/C++ based runtime, JIT, GC for running on Mac, Linux and Windows
- Roslyn: Microsoft's C# and VB compiler as a service
- CodeContracts: the tools needed to instrument your code

We are tracking various ideas in the [.NET Integration in Mono](https://trello.com/b/vRPTMfdz/net-framework-integration-into-mono) trello board."),
			new Section (
				"Gtk# and Bindings",
				"GTK# and Bindings",
				"GTK# Core, Bindings and Applications"),
		};
	}

	partial class Page
	{
		void WriteToc ()
		{
			foreach (var s in MainClass.Sections) {
				List<Idea> areaIdeas;
				if (!Ideas.TryGetValue (s.Key, out areaIdeas)) {
					continue;
				}

				WriteLine ($"**[{s.Title}](#{Linkify (s.Title)})**<br/>");
				WriteLine (s.Description);
				WriteLine ("");

				foreach (var idea in areaIdeas) {
					WriteLine ($"* [{idea.Title}](#{Linkify (idea.Title)})");
				}

				WriteLine ("");
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
			foreach (var s in MainClass.Sections) {
				List<Idea> areaIdeas;
				if (!Ideas.TryGetValue (s.Key, out areaIdeas)) {
					continue;
				}

				WriteLine ("");
				WriteLine ($"## {s.Title}");
				WriteLine ("");
				if (s.SectionHeader != null) {
					WriteLine (s.SectionHeader);
					WriteLine ("");
				}

				bool isFirst = true;
				foreach (var idea in areaIdeas) {
					if (!isFirst) {
						isFirst = false;
						WriteLine ("");
					}
					WriteLine (idea.TransformText ());
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
