﻿using Sce.Atf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using Sce.Atf.Applications;
using Sce.Atf.Dom;
using WorldsmithATF.UI;
using WorldsmithATF.Commands;

namespace WorldsmithATF
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // important to call these before creating application host
            Application.EnableVisualStyles();
            Application.DoEvents(); // see http://www.codeproject.com/buglist/EnableVisualStylesBug.asp?df=100&forumid=25268&exp=0&select=984714

            // Set up localization support early on, so that user-readable strings will be localized
            //  during the initialization phase below. Use XML files that are embedded resources.
            Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.CurrentCulture;
            Localizer.SetStringLocalizer(new EmbeddedResourceStringLocalizer());

            var catalog = new TypeCatalog(
                typeof(SettingsService),                // persistent settings and user preferences dialog
                typeof(StatusService),                  // status bar at bottom of main Form
                typeof(CommandService),                 // handles commands in menus and toolbars
                typeof(ControlHostService),             // docking control host
                typeof(AtfUsageLogger),                 // logs computer info to an ATF server
#if !DEBUG
                typeof(CrashLogger),                    // logs unhandled exceptions to an ATF server
                typeof(UnhandledExceptionService),      // catches unhandled exceptions, displays info, and gives user a chance to save
                
#endif
                typeof(DomExplorer),                    //Debug view the DOM
                typeof(FileDialogService),              // standard Windows file dialogs

                typeof(DocumentRegistry),               // central document registry with change notification
                typeof(RecentDocumentCommands),         // standard recent document commands in File menu
                typeof(StandardFileCommands),           // standard File menu commands for New, Open, Save, SaveAs, Close
                typeof(MainWindowTitleService),         // tracks document changes and updates main form title
                typeof(TabbedControlSelector),          // enable Ctrl+tab selection of documents and controls within the app
             
                typeof(ContextRegistry),                // central context registry with change notification
                typeof(StandardFileExitCommand),        // standard File exit menu command
                typeof(StandardEditCommands),           // standard Edit menu commands for copy/paste
                typeof(StandardEditHistoryCommands),    // standard Edit menu commands for undo/redo
                typeof(StandardSelectionCommands),      // standard Edit menu selection commands
                typeof(HelpAboutCommand),               // Help -> About command

           
                typeof(PropertyEditor),                 // property grid for editing selected objects
                typeof(PropertyEditingCommands),        // commands for PropertyEditor and GridPropertyEditor

                typeof(Outputs),                        // passes messages to all log writers
                typeof(ErrorDialogService),             // displays errors to the user a in message box

                typeof(HelpAboutCommand),               // custom command component to display Help/About dialog
                typeof(DefaultTabCommands),             // provides the default commands related to document tab Controls
                typeof(PythonService),                  // scripting service for automated tests
                typeof(ScriptConsole),                  // provides a dockable command console for entering Python commands
                typeof(AtfScriptVariables),             // exposes common ATF services as script variables
                typeof(AutomationService),               // provides facilities to run an automated script using the .NET remoting service

               

                //Worldsmith stuff
                typeof(SchemaLoader),                   //Loads the schema
                typeof(Project.DotaVPKService),         //Handles the VPK stuff, including reading from the VPK and building the DOM node

                //UI Elements
                typeof(ProjectTreeLister),
                typeof(UnitTreeLister),
                typeof(TextEditing.TextEditor),
                typeof(DotaVPKTreeLister),
                typeof(KeyValueEditor),
               // typeof(UnitPropertyEditor),

                //Commands
                typeof(ProjectCommands),
                typeof(TreeListCommands),
                typeof(KeyValueCommands)
                );

            // Set up the MEF container with these components
            var container = new CompositionContainer(catalog);

            // Configure the main Form
            var batch = new CompositionBatch();
            var toolStripContainer = new ToolStripContainer();
            var mainForm = new MainForm(toolStripContainer)
            {
                Text = "Worldsmith".Localize(),
                Icon = GdiUtil.CreateIcon(WorldsmithATF.Properties.Resources.WSIcon32)
            };

            // Add the main Form instance to the container
            batch.AddPart(mainForm);
            batch.AddPart(new WebHelpCommands("http://www.worldsmith.net".Localize()));
            container.Compose(batch);

            // Initialize components that require it. Initialization often can't be done in the constructor,
            //  or even after imports have been satisfied by MEF, since we allow circular dependencies between
            //  components, via the System.Lazy class. IInitializable allows components to defer some operations
            //  until all MEF composition has been completed.
            container.InitializeAll();

            // Show the main form and start message handling. The main Form Load event provides a final chance
            //  for components to perform initialization and configuration.
            Application.Run(mainForm);

            // Give components a chance to clean up.
            container.Dispose();
        }
    }
}
