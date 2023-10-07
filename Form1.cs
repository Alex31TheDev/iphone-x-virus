using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;

namespace iPhone_X_Virus
{
    public partial class iPhoneX : Form
    {
        public iPhoneX()
        {
            InitializeComponent();
        }

        private void TriggerVirus_Click(object sender, EventArgs e)
        {
            new MainCode().IPhoneXify();
        }

        private void ChangeWallpaper_CheckedChanged(object sender, EventArgs e)
        {
            MainCode.changeWallpaper = ChangeWallpaper.Checked;
        }

        private void CreateIcons_CheckedChanged(object sender, EventArgs e)
        {
            MainCode.createIcons = CreateIcons.Checked;
        }

        private void PlayVideo_CheckedChanged(object sender, EventArgs e)
        {
            MainCode.playVideo = PlayVideo.Checked;
        }

        private void SayIPhoneX_CheckedChanged(object sender, EventArgs e)
        {
            MainCode.sayIPhoneX = SayIPhoneX.Checked;
        }

        private void OpenPhotos_CheckedChanged(object sender, EventArgs e)
        {
            MainCode.startPhotos = OpenPhotos.Checked;
        }

        private void IconAmmount_ValueChanged(object sender, EventArgs e)
        {
            MainCode.ammountOfPhotos = IconAmmount.Value;
        }

        private void FixIcons_Click(object sender, EventArgs e)
        {
            new MainCode().FixIcons();
        }

        private void SetDefaultWallpaper_Click(object sender, EventArgs e)
        {
            new MainCode().SetDefaultWallpaper();
        }

        private void AdvancedButton_Click(object sender, EventArgs e)
        {

        }

        private void PhotoAmmount_ValueChanged(object sender, EventArgs e)
        {
            MainCode.ammountOfPhotos = PhotoAmmount.Value;
        }

        private void BrowserSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
           
           
        }

        private void ChangeHomepage_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}
