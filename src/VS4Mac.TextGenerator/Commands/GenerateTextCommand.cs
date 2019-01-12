using MonoDevelop.Components.Commands;
using MonoDevelop.Ide;
using VS4Mac.TextGenerator.Views;

namespace VS4Mac.TextGenerator.Commands
{
    public class GenerateTextCommand : CommandHandler
    {
        protected override void Run()
        {
            using (var generateTextDialog = new GenerateTextDialog())
            {
                generateTextDialog.Run(Xwt.MessageDialog.RootWindow);
            }
        }

        protected override void Update(CommandInfo info)
        {
            info.Enabled = IdeApp.Workbench.ActiveDocument?.Editor != null;
        }
    }
}