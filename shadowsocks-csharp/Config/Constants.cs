using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowSocks.Config
{
    class Constants
    {
        public static string DES_KEY = "";

        //网站根目录
        public static string DEFAULT_SEVER_ROOT = "";

        //用户注册链接
        public static string USER_REGISTER_URI = "";

        //用户找回密码链接
        public static string USER_FINDPWD_URI = "";

        //用户个人中心链接
        public static string USER_CENTER_URI = "";

        //用户充值链接
        public static string RECHARGE_URI = "";

        //用户登录接口
        public static string USER_LOGIN_API = "";

        //用户注销接口
        public static string USER_LOGOUT_API = "";

        //用户信息接口
        public static string USER_INFO_API = "";

        //服务列表接口
        public static string SERVER_LIST_API = "";

        //服务器连接接口
        public static string SERVER_CONNECT_API = "";
        
        //服务器断开连接接口
        public static string SERVER_DISCONNECT_API = "";

        //更新检测接口
        public static string UPDATE_CHECK_API = "";

        //应用配置接口
        public static string APP_CONFIG_API = "";

        //PAC更新链接
        public static string PAC_UPDATE_URI = "";
    }
}
