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

        private static Random random = new Random();

        private static void printt(string args)
        {
            Console.WriteLine("[ {0}:{1} ] {2}", hour_display, minute_display, args);
        }

        private static void advice(string word, string insert)
        {
            Console.WriteLine(">>> {0} [ 输入 {1} ]", word, insert);
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
                }
            }
        }
        
        private static void reset_time()
        {
            hour_tick = 8;
            minute_tick = 0;
            hour_display = "08";
            minute_display = "00";
        }

        private static void spread_logic()
        {
            while (true)
            {
                if (minute_tick == 0)
                {
                    Thread.Sleep(random.Next(1,40) * 1000);
                    if (processing == false)
                    {
                        if (video.Count < 5)
                        {
                            for (int list_num = 0; list_num < video.Count; list_num ++)
                            {
                                int new_play = random.Next(0, (int) video_spread[list_num]!);
                                if (new_play == 0)
                                {}
                                else
                                {
                                    video_play[list_num] = (int) video_play[list_num]! + new_play;
                                    printt("恭喜你，你的视频 " + video[list_num] + " 新增了 " + new_play + " 次播放！");
                                }
                            }
                        }
                        else
                        {
                            for (int list_num = 0; list_num < video.Count; list_num ++)
                            {
                                int new_play = random.Next((int) video_spread[list_num]! - 5 , (int) video_spread[list_num]!);
                                if (new_play == 0)
                                {}
                                else
                                {
                                    video_play[list_num] = (int) video_play[list_num]! + new_play;
                                    printt("恭喜你，你的视频 " + video[list_num] + " 新增了 " + new_play + " 次播放！");
                                }
                            }
                        }
                        Thread.Sleep(15 * 1000);
                    }
                }
            }
        }

        private static void follower_logic()
        {
            while (true)
            {
                if (processing == false)
                {
                    if (num > 1 && day > 1 && play_all > 20)
                    {
                        if (hour_tick == 10 || hour_tick == 12 || hour_tick == 16 || hour_tick == 19)
                        {
                            Thread.Sleep(random.Next(1,20) * 1000);
                            int new_follower = random.Next(0, num / 5 + 1);
                            if (new_follower == 0)
                            {}
                            else
                            {
                                follower += new_follower;
                                printt("恭喜你，你新增了 " + new_follower + " 个粉丝！");
                            }
                            Thread.Sleep(40 * 1000);
                        }
                    }
                }
            }
        }

        private static void enghgr_logic()
        {
            while (true)
            {
                energy -= 1;
                hunger -= 2;
                Thread.Sleep(30 * 1000);
            }
        }
        
        private static void info_logic()
        {
            List<int> video_play_list = new List<int> ((int[])video_play.ToArray(typeof(int)));
            play_all = video_play_list.Sum();

            if (day == 1 && hour_tick == 20 && minute_tick == 0)
            {
                advice("该睡觉啦~ 明天元气满满地继续努力！", "睡觉");
                Thread.Sleep(2 * 1000);
            }
        }

        private static void money_up(int moneyup)
        {
            money += moneyup;
            printt("金币 + " + moneyup);
        }

        private static void money_down(int moneydown)
        {
            int money_dif = money - moneydown;
            if (money_dif < 0)
            {
                printt("金币 - " + money);
                advice("你的金币已用尽。快去投稿视频获得金币吧~","投稿");
            }
            else
            {
                printt("金币 - " + moneydown);
                money -= moneydown;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("我要当up主！2");
            Console.WriteLine("--------------------------------------------------");

            Thread time_thread = new Thread(time_logic);
            time_thread.Start();

            Thread spread_thread = new Thread(spread_logic);
            spread_thread.Start();

            Thread follower_thread = new Thread(follower_logic);
            follower_thread.Start();

            Thread enghgr_thread = new Thread(enghgr_logic);
            enghgr_thread.Start();

            Thread info_thread = new Thread(info_logic);
            info_thread.Start();
            
            while (true)
            {
                printt("测试");
                Thread.Sleep(1000);
            }
        }
    }
}
