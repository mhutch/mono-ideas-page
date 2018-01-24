﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace MonoGSoCIdeasPage
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Users\Mikayla\code\mono-ideas-page\Page.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class Page : PageBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write(@"---
title: Projects
redirect_from:
  - /StudentProjects/
  - /GSoC/
---

This is the Mono Project's project ideas page. For general information and rules about participating in
[Google Summer of Code (GSoC)](http://code.google.com/soc/) for the Mono Project, please see our
[overview page](/community/google-summer-of-code/).

This page lists some ideas for Mono GSoC projects that students can apply for. Additionally, we encourage students
to submit their own interesting Mono-related project proposals. In past years, roughly 20% of the accepted
proposals were original ideas from students instead of from our suggestions. You can submit more than one proposal,
so you can submit your own ideas as well as apply for one from this list - but only one can be chosen, of course!

You can use the following links to jump to sections that you're interested in:

");
            
            #line 24 "C:\Users\Mikayla\code\mono-ideas-page\Page.tt"
 WriteToc (); 
            
            #line default
            #line hidden
            this.Write("\r\n**[Other Ideas](#other-ideas)**\r\n\r\nSuggest your own ideas for a project\r\n\r\n**[C" +
                    "ontacting the Mono Team](#contacting-the-mono-team)**\r\n\r\nHow to get in touch wit" +
                    "h us and ask questions\r\n\r\n");
            
            #line 34 "C:\Users\Mikayla\code\mono-ideas-page\Page.tt"
 WriteIdeas (); 
            
            #line default
            #line hidden
            this.Write("\r\n## Other Ideas\r\n\r\nIf a project is not listed here, but you think you have a gre" +
                    "at idea, feel free to\r\n[contact the Mono team, mentors and org admins](#contacti" +
                    "ng-the-mono-team) to discuss or suggest your own project ideas.\r\n\r\nOver the past" +
                    " years we have picked projects that were not listed here because they were great" +
                    " ideas, and we had students\r\nthat were passionate about those projects. In the e" +
                    "nd, most of these projects were a success.\r\n\r\nDo not be afraid to pick up a proj" +
                    "ect that would be interesting and also help the Mono universe.\r\n\r\nYou can find s" +
                    "ome additional ideas on the\r\n[Gnome ideas page](https://wiki.gnome.org/Outreach/" +
                    "SummerOfCode/2017/Ideas) (Mono-based projects in Gnome: Banshee, Blam, Tasque,\r\n" +
                    "Tomboy, GBrainy, Mistelix, F-Spot, ChronoJump, SparkleShare, LongoMatch).\r\n\r\n## " +
                    "Contacting the Mono Team\r\n\r\nIf you have questions or suggestions that you want t" +
                    "o make in real-time and talk to a member of the team, please join us\r\non IRC on " +
                    "the server \"irc.gnome.org\" in channel \"#monosoc\", \"#monodev\" or the \"#mono\" chan" +
                    "nel. Various mentors and\r\nstudents from past years are usually there and can ans" +
                    "wer some quick questions about the program and about Mono.\r\n\r\nThe mailing lists " +
                    "are a very important communication channel, students should use them to get more" +
                    " information and\r\nfeedback about ideas and proposals. Community engagement is es" +
                    "sential for a successful summer of code, so get involved!\r\n\r\nFor any questions y" +
                    "ou may have about the program itself and to talk to the Mono GSoC admin, you can" +
                    " use\r\n[soc@xamarin.com](mailto:soc@xamarin.com).\r\n\r\n### Mailing Lists\r\n\r\n[http:/" +
                    "/lists.ximian.com/mailman/listinfo/mono-devel-list](http://lists.ximian.com/mail" +
                    "man/listinfo/mono-devel-list)\r\nA mailing list dedicated to discussions about dev" +
                    "eloping Mono itself, such as development of the runtime, class libraries, and re" +
                    "lated Mono projects.\r\n\r\n[http://lists.ximian.com/mailman/listinfo/monodevelop-de" +
                    "vel-list](http://lists.ximian.com/mailman/listinfo/monodevelop-devel-list)\r\nDisc" +
                    "ussion on the development/implementation of MonoDevelop.\r\n\r\nA complete breakdown" +
                    " of all Mono mailing lists is available at [Mailing Lists](/community/help/maili" +
                    "ng-lists/).");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public class PageBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
