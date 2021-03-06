﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Folding;
using ICSharpCode.AvalonEdit.Highlighting;
using Microsoft.Win32;
using System.Resources;
using System.Windows.Controls.WpfPropertyGrid;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;

namespace IronPythonConsole
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ConsoleOptions consoleOptionsProvider;
        
        public MainWindow()
		{
            Initialized += new EventHandler(MainWindow_Initialized);
            // Load our custom highlighting definition:
            IHighlightingDefinition pythonHighlighting;
            using (Stream s = typeof(MainWindow).Assembly.GetManifestResourceStream("IronPythonConsole.Resources.Python.xshd"))
            {
                if (s == null)
                    throw new InvalidOperationException("Could not find embedded resource");
                using (XmlReader reader = new XmlTextReader(s))
                {
                    pythonHighlighting = ICSharpCode.AvalonEdit.Highlighting.Xshd.
                        HighlightingLoader.Load(reader, HighlightingManager.Instance);
                }
            }
            // and register it in the HighlightingManager
            HighlightingManager.Instance.RegisterHighlighting("Python Highlighting", new string[] { ".cool" }, pythonHighlighting);
            	
			InitializeComponent();

            textEditor.SyntaxHighlighting = pythonHighlighting;

            textEditor.PreviewKeyDown += new KeyEventHandler(textEditor_PreviewKeyDown);

            consoleOptionsProvider = new ConsoleOptions(console.Pad);

            propertyGridComboBox.SelectedIndex = 0;

            expander.Expanded += new RoutedEventHandler(expander_Expanded);

            console.Pad.Host.ConsoleCreated +=new PythonConsoleControl.ConsoleCreatedEventHandler(Host_ConsoleCreated);
		}

		string currentFileName;

        void Host_ConsoleCreated(object sender, EventArgs e)
        {
            console.Pad.Console.ConsoleInitialized += new PythonConsoleControl.ConsoleInitializedEventHandler(Console_ConsoleInitialized);
        }

        void Console_ConsoleInitialized(object sender, EventArgs e)
        {
            string startupScipt = "import Extra";
            ScriptSource scriptSource = console.Pad.Console.ScriptScope.Engine.CreateScriptSourceFromString(startupScipt, SourceCodeKind.Statements);
            try
            {
                scriptSource.Execute();
                // adds all local modules
                //var paths = pyEngine.GetSearchPaths();
                //paths.Add(@"C:\Python27\Lib");
                //paths.Add(@"C:\Python27\Lib\site-packages");
            }
            catch {}
            //string intro = "You are now connected to the server...";
            //console.Pad.Console.ScriptScope.SetVariable("init", intro);
        }

        void MainWindow_Initialized(object sender, EventArgs e)
        {
            //propertyGridComboBox.SelectedIndex = 1;
        }
		
		void openFileClick(object sender, RoutedEventArgs e)
		{   
            OpenFileDialog dlg = new OpenFileDialog();
			dlg.CheckFileExists = true;
			if (dlg.ShowDialog() ?? false) {
				currentFileName = dlg.FileName;
				textEditor.Load(currentFileName);
				//textEditor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(Path.GetExtension(currentFileName));
			}
		}
		
		void saveFileClick(object sender, EventArgs e)
		{
			if (currentFileName == null) {
				SaveFileDialog dlg = new SaveFileDialog();
				dlg.DefaultExt = ".txt";
				if (dlg.ShowDialog() ?? false) {
					currentFileName = dlg.FileName;
				} else {
					return;
				}
			}
			textEditor.Save(currentFileName);
		}

        void runClick(object sender, EventArgs e)
        {
            RunStatements();
        }

        void textEditor_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5) RunStatements();
        }

        void RunStatements()
        {
            string statementsToRun = "";
            if (textEditor.TextArea.Selection.Length > 0)
                statementsToRun = textEditor.TextArea.Selection.GetText(textEditor.TextArea.Document);
            else
                statementsToRun = textEditor.TextArea.Document.Text;
            console.Pad.Console.RunStatements(statementsToRun);
        }
		
		void propertyGridComboBoxSelectionChanged(object sender, RoutedEventArgs e)
		{
            if (propertyGrid == null)
				return;
			switch (propertyGridComboBox.SelectedIndex) {
				case 0:
                    propertyGrid.SelectedObject = consoleOptionsProvider; // not .Instance
					break;
				case 1:
					//propertyGrid.SelectedObject = textEditor.Options; (for WPF native control)
                    propertyGrid.SelectedObject = textEditor.Options;
					break;
			}
		}

        void expander_Expanded(object sender, RoutedEventArgs e)
        {
            propertyGridComboBoxSelectionChanged(sender, e);
        }

        //-----------------------------------------------------------------------------------
        private void APIHelp_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"..\XradiApps\bin\x64\API Docs\XradiaAPIDocumentation v11.0\html\XrmApp_V11.0API Documentation.html");
            // MessageBox.Show("Run: \"sys.path.append(r\"c:\\python27\\lib\")\"\nTo access more modules");
        }
		
    }
}
