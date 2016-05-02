using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Week15ATasks
{
    public partial class InputValidator : Form
    {
        private string notValidNameMsg = "The name is invalid (only alphabetical characters are allowed)";
        private string notValidPhoneMsg = "The phone number is not a valid US phone number";
        private string notValidEmailMsg = "The e-mail address is not valid.";

        public InputValidator()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (!Regex.IsMatch(txtName.Text, @"^([A-Za-z]*\s*)*$"))
            {
                MessageBox.Show(notValidNameMsg);
            }


            if (!Regex.IsMatch(txtPhone.Text, @"^((\(\d{3}\)?)|(\d{3}-))?\d{3}-\d{4}$"))
            {
                MessageBox.Show(notValidPhoneMsg);
            }

            if (!Regex.IsMatch(txtEmail.Text, @"^([a-zA-Z0-9_\-” + @”\.]+)@((\[[0-9]{1,3}" +
                                              @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                              @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
            {
                MessageBox.Show(notValidEmailMsg);
            }
            txtPhone.Text = ReformatPhone(txtPhone.Text);
        }

        static string ReformatPhone(string s)
        {
            Match m = Regex.Match(s, @"^\(?(\d{3})\)?[\s\-]?(\d{3})\-?(\d{4})$");

            return String.Format("({0}) {1}-{2}",
                                m.Groups[1],
                                m.Groups[2],
                                m.Groups[3]);
        }
    }
}
