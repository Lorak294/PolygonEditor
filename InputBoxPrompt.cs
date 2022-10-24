using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektNaGK
{
    internal static class InputBoxPrompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 250,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 20, Top = 20, Width = 250, Text = text};
            TextBox textBox = new TextBox() { Left = 20, Top = 40, Width = 175 };
            Button confirmation = new Button() { Text = "Ok", Left = 20, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}
