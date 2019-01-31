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
        HBox _typesBox;
        Label _typesLabel;
        ComboBox _generatorTypesComboBox;
        HBox _optionsBox;
        Label _optionsLabel;
        ComboBox _generatorOptionsComboBox;       
        HBox _numberBox;
        Label _numberLabel;
        TextEntry _numberEntry;
        HBox _buttonBox;
        Button _generateButton;

        ITextGeneratorService _textGeneratorService;
        Lazy<JeffsumGeneratorService> _jeffsumGeneratorService = new Lazy<JeffsumGeneratorService>();
        Lazy<LipsumGeneratorService> _lipsumGeneratorService = new Lazy<LipsumGeneratorService>();

        public GenerateTextDialog()
        {
            Init();
            BuildGui();
            AttachEvents();
        }

        void Init()
        {
            Title = "Text Generator";

            _textGeneratorService = _lipsumGeneratorService.Value;

            _mainBox = new VBox
            {
                HeightRequest = 130,
                WidthRequest = 255
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

            _typesBox = new HBox();
            _typesLabel = new Label("Generator type:");

            _generatorTypesComboBox = new ComboBox
            {
                WidthRequest = 150
            };

            _generatorTypesComboBox.Items.Add("Lorem Ipsum");
            _generatorTypesComboBox.Items.Add("Jeffsum");
            _generatorTypesComboBox.SelectedIndex = 0;

            _optionsBox = new HBox();
            _optionsLabel = new Label("Generator option:");

            _generatorOptionsComboBox = new ComboBox
            {
                WidthRequest = 150
            };

            _generatorOptionsComboBox.Items.Add("Characters");
            _generatorOptionsComboBox.Items.Add("Words");
            _generatorOptionsComboBox.Items.Add("Sentences");
            _generatorOptionsComboBox.SelectedIndex = 1;
        }

        void BuildGui()
        {
            _typesBox.PackStart(_typesLabel);
            _typesBox.PackEnd(_generatorTypesComboBox);

            _optionsBox.PackStart(_optionsLabel);
            _optionsBox.PackEnd(_generatorOptionsComboBox);

            _numberBox.PackStart(_numberLabel, true);
            _numberBox.PackEnd(_numberEntry, false);
            _buttonBox.PackEnd(_generateButton);

            _mainBox.PackStart(_typesBox);
            _mainBox.PackStart(_optionsBox);
            _mainBox.PackStart(_numberBox);
            _mainBox.PackEnd(_buttonBox);

            _numberEntry.SetFocus();

            Content = _mainBox;
            Resizable = false;
        }

        void AttachEvents()
        {
            _numberEntry.Changed += OnNumberEntryChanged;
            _generateButton.Clicked += OnGenerateClicked;
            _generatorOptionsComboBox.SelectionChanged += OnGeneratorOptionsChanged;
            _generatorTypesComboBox.SelectionChanged += OnTypeOptionsChanged;
        }

        void OnGeneratorOptionsChanged(object sender, EventArgs e)
        {
            _numberLabel.Text = $"Introduce number of {_generatorOptionsComboBox.SelectedItem.ToString().ToLower()}:";
        }

        void OnTypeOptionsChanged(object sender, EventArgs e)
        {
            if(_generatorTypesComboBox.SelectedIndex == 0)
                _textGeneratorService = _lipsumGeneratorService.Value;
            else if (_generatorTypesComboBox.SelectedIndex == 1)
                _textGeneratorService = _jeffsumGeneratorService.Value;
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
                int.TryParse(_numberEntry.Text, out int numberOfElements);
                string[] words = null;

                switch (_generatorOptionsComboBox.SelectedIndex)
                {
                    case 0:
                        words = _textGeneratorService.GenerateCharacters(numberOfElements);
                        break;
                    case 1:
                        words = _textGeneratorService.GenerateWords(numberOfElements);
                        break;
                    case 2:
                        words = _textGeneratorService.GenerateSentences(numberOfElements);
                        break;
                }

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