using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;
using System.Collections.Specialized;

namespace vkapp
{
    class VkApi
    {
        private string _userId;
        private string _accessToken;

        public VkApi(string userId, string accessToken)
        {
            _userId = userId;
            _accessToken = accessToken;
        }

        public string UserId
        {
            get { return _userId; }
        }

        private XmlDocument ExecuteCommand(string command, NameValueCollection parametrs)
        {
            XmlDocument result = new XmlDocument();

            string strParam = String.Empty;

            strParam = String.Join
                (
                "&",
                from item in parametrs.AllKeys select item + "=" + parametrs[item]
                );
            int a = 5;
            result.Load(String.Format("https://api.vkontakte.ru/method/{0}.xml?access_token={1}&{2}", command, _accessToken, strParam));

            return result;
        }

        public XmlDocument AccountGetInfo()
        {
            XmlDocument result;
            string command = "users.get";

            NameValueCollection parametrs = new NameValueCollection();

            parametrs["user_ids"] = _userId;
            parametrs["fields"] = "first_name,last_name,bdate,sex";

            result = ExecuteCommand(command, parametrs);

            return result;
        }

        public XmlDocument FriendsGet(string userId)
        {
            XmlDocument result;
            string command = "friends.get";
            NameValueCollection parametrs = new NameValueCollection();

            parametrs["user_id"] = userId;
            parametrs["fields"] = "uid,first_name,last_name,bdate,sex,online";
            result = ExecuteCommand(command, parametrs);

            return result;
        }

        public bool WallPost(string uid, string message)
        {
            XmlDocument result;
            string command = "wall.post";
            NameValueCollection parametrs = new NameValueCollection();

            parametrs["owner_id"] = uid;
            parametrs["message"] = message;

            result = ExecuteCommand(command, parametrs);

            return result.DocumentElement.Name == "error" ? false : true;
        }

        public bool SendMessage(string uid, string message)
        {
            XmlDocument result;
            string command = "messages.send";
            NameValueCollection parametrs = new NameValueCollection();

            parametrs["user_id"] = uid;
            parametrs["message"] = message;

            result = ExecuteCommand(command, parametrs);

            return result.DocumentElement.Name == "error" ? false : true;
        }
    }
}
