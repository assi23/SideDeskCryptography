namespace Cryptography.WindosForm
{
    public partial class ErrorPopUp : Form
    {
        public ErrorPopUp()
        {
            InitializeComponent();
        }

        public void ShowErrorMessage(string message)
        {
            this.lbError.Text = message;
        }
    }
}
