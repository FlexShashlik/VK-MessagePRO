using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace vkapp
{
    public partial class FormAuth : Form
    {
        string appId = "5470119";

        [Flags]
        enum VKScopeList
        {   
            notify = 1,
            friends = 2,
            photos = 4,
            audio = 8,
            video = 16,
            offers = 32,
            questions = 64,
            pages = 128,
            link = 256,
            notes = 2048,
            messages = 4096,
            wall = 8192,
            docs = 131072
        }

        int appScope = (int)(VKScopeList.audio|VKScopeList.docs|VKScopeList.friends|VKScopeList.link|VKScopeList.messages|VKScopeList.notes|VKScopeList.notify|VKScopeList.offers|VKScopeList.pages|VKScopeList.photos|VKScopeList.questions|VKScopeList.video|VKScopeList.wall);

        string GetAccessToken(string url)
        {
            string accessToken;

            int fi = url.IndexOf('=')+1;
            int li = url.IndexOf('&');
            int len = li - fi;

            accessToken = url.Substring(fi, len);

            return accessToken;
        }

        string GetUserId(string url)
        {
            string userId;

            int fi = url.LastIndexOf('=')+1;

            userId = url.Substring(fi);

            return userId;
        }

        public FormAuth()
        {
            InitializeComponent();
        }

        private void FormAuth_Load(object sender, EventArgs e)
        {
            webBrowserVK.ScriptErrorsSuppressed = true;
            webBrowserVK.Navigate(String.Format("http://api.vkontakte.ru/oauth/authorize?client_id={0}&scope={1}&display=popup&response_type=token",appId,appScope));
        }

        private void webBrowserVK_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            textBoxAddress.Text = e.Url.ToString();

            if (textBoxAddress.Text.Contains("access_token") == true)
            {
               
                Program.api = new VkApi(GetUserId(e.Url.ToString()),
                                    GetAccessToken(e.Url.ToString()));

                this.Hide();

                Form fw = new FormWork();
                fw.Show();
            }
        }
    }
}
