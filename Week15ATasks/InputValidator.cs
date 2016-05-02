using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Week15ATasks
{
    public partial class InputValidator : Form
    {
        private string notValidNameMsg = "The name is invalid (only alphabetical characters are allowed)";
        private string notValidPhoneMsg = "The phone number is not a valid US phone number";
        private string notValidEmailMsg = "The e-mail address is not valid";

        private string nameRegexPattern = @"^([A-Za-z]*\s*)*$";
        private string phoneRegexPattern = @"^\(?(\d{3})\)?[\s\-]?(\d{3})\-?(\d{4})$";
        private string emailRegexPattern = @"^([a-zA-Z0-9_\-" + @"\.]+)@((\[[0-9]{1,3}" +
                                           @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                           @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        public InputValidator()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtName.Text, nameRegexPattern)) MessageBox.Show(notValidNameMsg);
            if (!Regex.IsMatch(txtPhone.Text, phoneRegexPattern)) MessageBox.Show(notValidPhoneMsg);
            if (!Regex.IsMatch(txtEmail.Text, emailRegexPattern)) MessageBox.Show(notValidEmailMsg);

            txtPhone.Text = ReformatPhone(txtPhone.Text);
        }

        private string ReformatPhone(string s)
        {
            Match m = Regex.Match(s, phoneRegexPattern);
            return $"({m.Groups[1]}) {m.Groups[2]}-{m.Groups[3]}";
        }
    }
}
