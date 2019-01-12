using System;
using MonoDevelop.Core;
using MonoDevelop.Ide;
using MonoDevelop.Ide.Gui;
using VS4Mac.TextGenerator.Services;
using Xwt;

namespace VS4Mac.TextGenerator.Views
{
    public class GenerateTextDialog : Dialog
    {
        VBox _mainBox;
        HBox _numberBox;
        Label _numberLabel;
        TextEntry _numberEntry;
        HBox _buttonBox;
        Button _generateButton;

        TextGeneratorService _textGeneratorService;

        public GenerateTextDialog()
        {
            Init();
            BuildGui();
            AttachEvents();
        }

        void Init()
        {
            Title = "Text Generator";

            _textGeneratorService = new TextGeneratorService();

            _mainBox = new VBox
            {
                HeightRequest = 50,
                WidthRequest = 200
            };

            _numberBox = new HBox();
            _numberLabel = new Label("Introduce number of words:");

            _numberEntry = new TextEntry
            {
                WidthRequest = 48
            };

            _buttonBox = new HBox();
            _generateButton = new Button("Add")
            {
                BackgroundColor = Styles.BaseSelectionBackgroundColor,
                LabelColor = Styles.BaseSelectionTextColor,
                WidthRequest = 48
            };
        }

        void BuildGui()
        {
            _numberBox.PackStart(_numberLabel, true);
            _numberBox.PackEnd(_numberEntry, false);
            _buttonBox.PackEnd(_generateButton);

            _mainBox.PackStart(_numberBox);
            _mainBox.PackEnd(_buttonBox);

            Content = _mainBox;
            Resizable = false;
        }

        void AttachEvents()
        {
            _numberEntry.Changed += OnNumberEntryChanged;
            _generateButton.Clicked += OnGenerateClicked;
        }

        void OnNumberEntryChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(_numberEntry.Text, "[^0-9]"))
            {
                _numberEntry.Text = _numberEntry.Text.Remove(_numberEntry.Text.Length - 1);
            }
        }

        void OnGenerateClicked(object sender, EventArgs args)
        {
            try
            {
                var editor = IdeApp.Workbench.ActiveDocument.Editor;
                int.TryParse(_numberEntry.Text, out int numberOfWords);
                var words = _textGeneratorService.GenerateWords(numberOfWords);
                var result = string.Join(" ", words);
                editor.InsertAtCaret(result);

                Respond(Command.Ok);
            }
            catch (Exception ex)
            {
                LoggingService.LogError(ex.Message, ex);
            }
        }
    }
}