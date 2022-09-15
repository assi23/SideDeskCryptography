using Cryptography.Domain.Interfaces;

namespace Cryptography.WindosForm
{
    public partial class SideDeskCryptographyForm : Form
    {
        private readonly IEncryptService _encryptService;
        private readonly IDecryptService _decryptService;

        public SideDeskCryptographyForm(IEncryptService encryptService, IDecryptService decryptService)
        {
            _encryptService = encryptService;
            _decryptService = decryptService;
            InitializeComponent();
        }

        private void Encrypt(object sender, EventArgs e)
        {
            try
            {
                var encrypted = _encryptService.Encrypt(tbInput.Text);
                tbOutput.Text = encrypted;
            }
            catch (Exception ex)
            {
                var errorPopUp = new ErrorPopUp();
                errorPopUp.ShowErrorMessage(ex.Message);
                errorPopUp.ShowDialog();
            }
            
        }

        private void Decrypt(object sender, EventArgs e)
        {
            try
            {
                var decrypted = _decryptService.Decrypt(tbInput.Text);
                tbOutput.Text = decrypted;
            }
            catch (Exception ex)
            {
                var errorPopUp = new ErrorPopUp();
                errorPopUp.ShowErrorMessage(ex.Message);
                errorPopUp.ShowDialog();
            }
          
        }

        private void CopyFromOutput(object sender, EventArgs e)
        {
            Clipboard.SetText(this.tbOutput.Text);
        }
    }
}