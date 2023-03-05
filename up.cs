using System;
using System.Collections;
using System.Threading;

namespace UP
{
    class UP
    {
        private static bool processing = false;

        private static int day = 0;
        private static int hour_tick = 8;
        private static int minute_tick = 0;
        private static string hour_display = "08";
        private static string minute_display = "00";

        private static int num = 0;

        private static int money = 100;

        private static int follower = 0;
        private static int play_all = 0;

        private static int energy = 100;
        private static int hunger = 100;

        private static ArrayList video = new ArrayList();
        private static ArrayList video_spread = new ArrayList();
        private static ArrayList video_play = new ArrayList();
        private static ArrayList video_release_time = new ArrayList();

        private static int advice1 = 0;

        private static ArrayList tags = new ArrayList() {"我的世界","游戏","iPhone 14","疫情","科技","猫和老鼠","何同学","籽岷","布洛芬","网课","蔡徐坤","原神","Minecraft","世界杯",
                "阿根廷","鬼畜","社交","知识","纪录片","核酸","抗原","华强","人类高质量","俄乌局势","PlayStation","XBox","苹果","微软","华为",
                "二十大","2023","英伟达","4090","4090 ti","腾讯","体育","阳康"};

        private static void printt(params string[] args)
        {
            Console.WriteLine("[", hour_display + ":" + minute_display, "]", args);
        }

        private static void time_logic()
        {
            while (true)
            {
                Thread.Sleep(500);
                minute_tick += 1;
                if (minute_tick == 60)
                {
                    minute_tick = 0;
                    hour_tick += 1;
                };
                if (hour_tick == 24)
                {
                    hour_tick = 0;
                    minute_tick = 0;
                };
                if (Convert.ToString(hour_tick).Length == 1)
                {
                    hour_display = "0" + Convert.ToString(hour_tick);
                }
                else
                {
                    hour_display = Convert.ToString(hour_tick);
                };
                if (Convert.ToString(minute_tick).Length == 1)
                {
                    minute_display = "0" + Convert.ToString(minute_tick);
                }
                else
                {
                    minute_display = Convert.ToString(minute_tick);
                };
            };
        
        }
        static void Main(string[] args)
        {
            Console.WriteLine("我要当up主！2023.0.1");
            Console.WriteLine("--------------------------------------------------");

            Thread time_thread = new Thread(time_logic);
            time_thread.Start();

            while (true)
            {
                printt("测试");
            }
        }
    }
}
