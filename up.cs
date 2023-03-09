using System;
using System.Collections;
using System.Threading;

namespace UP
{
    class UP
    {
        private static bool processing = false;

        private static int day = 0;
        private static string name = "";

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

        private static List<string> video = new List<string> { };
        private static List<int> video_spread = new List<int> { };
        private static List<int> video_play = new List<int> { };
        private static List<string> video_release_time = new List<string> { };
        private static int advice1 = 0;

        private static List<string> tags = new List<string> {"我的世界","游戏","iPhone 14","疫情","科技","猫和老鼠","何同学","籽岷","布洛芬","网课","蔡徐坤","原神","Minecraft","世界杯",
                "阿根廷","鬼畜","社交","知识","纪录片","核酸","抗原","华强","人类高质量","俄乌局势","PlayStation","XBox","苹果","微软","华为",
                "二十大","2023","英伟达","4090","4090 ti","腾讯","体育","阳康"};
        private static List<string> tag = new List<string> { };

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
                    Thread.Sleep(random.Next(1, 40) * 1000);
                    if (processing == false)
                    {
                        if (video.Count < 5)
                        {
                            for (int list_num = 0; list_num < video.Count; list_num++)
                            {
                                int new_play = random.Next(0, (int)video_spread[list_num]!);
                                if (new_play == 0)
                                { }
                                else
                                {
                                    video_play[list_num] = (int)video_play[list_num]! + new_play;
                                    printt("恭喜你，你的视频 " + video[list_num] + " 新增了 " + new_play + " 次播放！");
                                }
                            }
                        }
                        else
                        {
                            for (int list_num = 0; list_num < video.Count; list_num++)
                            {
                                int new_play = random.Next((int)video_spread[list_num]! - 5, (int)video_spread[list_num]!);
                                if (new_play == 0)
                                { }
                                else
                                {
                                    video_play[list_num] = (int)video_play[list_num]! + new_play;
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
                            Thread.Sleep(random.Next(1, 20) * 1000);
                            int new_follower = random.Next(0, num / 5 + 1);
                            if (new_follower == 0)
                            { }
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
            play_all = video_play.Sum();

            if (day == 1 && hour_tick == 20 && minute_tick == 0)
            {
                advice("该睡觉啦~ 明天元气满满地继续努力！", "睡觉");
                Thread.Sleep(2 * 1000);
            }
        }

        private static void e_up(int eup)
        {
            int e_up_dif = energy + eup;
            if (e_up_dif > 100)
            {
                int e_up_rest = 100 - energy;
                printt("精力 + " + e_up_rest);
                energy = 100;
            }
            else
            {
                printt("精力 + " + eup);
                energy += eup;
            }
        }

        private static void h_up(int hup)
        {
            int h_up_dif = hunger + hup;
            if (h_up_dif > 100)
            {
                int h_up_rest = 100 - hunger;
                printt("饱食度 + " + h_up_rest);
                hunger = 100;
            }
            else
            {
                printt("饱食度 + " + hup);
                hunger += hup;
            }
        }

        public static void e_down(int edown)
        {
            int e_down_dif = energy - edown;
            if (e_down_dif < 0)
            {
                printt("精力 - " + energy);
                energy = 0;
            }
            else
            {
                printt("精力 - " + edown);
                energy -= edown;
            }
            if (energy <= 20)
            {
                printt("你觉得有些累了。");
                if (advice1 == 0)
                {
                    advice("吃点东西，回复精力和饱食度！", "恰饭");
                    advice1 = 1;
                }
            }
        }

        public static void h_down(int hdown)
        {
            int h_down_dif = hunger - hdown;
            if (h_down_dif < 0)
            {
                printt("精力 - " + hunger);
                hunger = 0;
            }
            else
            {
                printt("精力 - " + hdown);
                hunger -= hdown;
            }
            if (hunger <= 20)
            {
                printt("你觉得有些饿了。");
                if (advice1 == 0)
                {
                    advice("吃点东西，回复精力和饱食度！", "恰饭");
                    advice1 = 1;
                }
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
                advice("你的金币已用尽。快去投稿视频获得金币吧~", "投稿");
            }
            else
            {
                printt("金币 - " + moneydown);
                money -= moneydown;
            }
        }

        public static void hello()
        {
            if (day == 1)
            {
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine(">>> 这是你在UP镇生活的第 " + day + " 天");
                Thread.Sleep(1 * 1000);
                Console.WriteLine(">>> 加油吧，" + name + "！");
                Console.WriteLine("--------------------------------------------------");
                Thread.Sleep(1 * 1000);
                advice("up镇上还没有人知道你，快投稿你的第一个视频吧~", "投稿");
            }
            else
            {
                Console.WriteLine("zzZ....");
                Thread.Sleep(3 * 1000);
                int energyup = 100 - energy;
                e_up(energyup);
                Thread.Sleep(1 * 1000);
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine(">>> 这是你在UP镇生活的第 " + day + " 天");
                Thread.Sleep((int)(0.5 * 1000));
                Console.WriteLine(">>> 你一共投稿了 " + num + " 个作品");
                Thread.Sleep((int)(0.5 * 1000));
                Console.WriteLine(">>> 你现在的粉丝量为 " + follower);
                Thread.Sleep((int)(0.5 * 1000));
                Console.WriteLine(">>> 你现在的总播放量为 " + play_all);
                Thread.Sleep((int)(0.5 * 1000));
                Console.WriteLine(">>> 继续加油吧，" + name + "！");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("  结算昨日收益...");
                int spread_width = 0;
                for (int key = 0; key < video.Count; key++)
                {
                    string video_release_time_string = (string)video_release_time[key]!;
                    string[] video_release_time_split = video_release_time_string.Split("|");
                    if (video_release_time_split[0] == Convert.ToString(day - 1))
                    {
                        spread_width += (int)video_play[key]!;
                    }
                }
                Console.WriteLine("  昨日总播放量：" + spread_width + " 获得收益：");
                int add_money = random.Next(spread_width / 10, spread_width / 5);
                money += add_money;
                Console.WriteLine("  金币 + " + add_money);
                Console.WriteLine("--------------------------------------------------");
                for (int i = 0; i < 6; i++)
                {
                    tag.Add((string)tags[random.Next(0, tags.Count)]!);
                }
                for (int l = 0; l < tag.Count; l++)
                {
                    for (int j = tag.Count - 1; j > l; j--)
                    {
                        if (tag[l] == tag[j])
                        {
                            tag.RemoveAt(j);
                        }
                    }
                }
                Console.WriteLine("  今日热点：" + tag[0] + "，" + tag[1] + "，" + tag[2] + "，" + tag[3] + "，" + tag[4]);
                Console.WriteLine("--------------------------------------------------");
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

            Console.Write("欢迎来到UP镇！请设置你的名字：");
            string? name = Console.ReadLine();

            while (true)
            {
                processing = true;
                day += 1;
                hello();
                reset_time();
                processing = false;

                while (true)
                {
                    Console.Write("[ {0}:{1} ] ", hour_display, minute_display);
                    string? cmd = Console.ReadLine();
                    
                    if (cmd == "睡觉")
                    {
                        break;
                    }
                }
            }
        }
    }
}
