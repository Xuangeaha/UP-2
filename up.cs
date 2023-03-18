using NullLib.ConsoleTable;

namespace UP
{
    class UP
    {
        private static int day;
        private static string name = "";

        private static int hour_tick = 8;
        private static int minute_tick;
        private static string hour_display = "08";
        private static string minute_display = "00";

        private static int num;
        private static int money = 100;
        private static int follower;
        private static int play_all;
        private static int energy = 100;
        private static int hunger = 100;

        private static List<string> video = new List<string>();
        private static List<int> video_spread = new List<int>();
        private static List<int> video_play = new List<int>();
        private static List<string> video_release_time = new List<string>();

        private static int advice1;

        private static List<string> tags = new List<string> {"我的世界","游戏","iPhone 14","疫情","科技","猫和老鼠",
            "何同学","籽岷","网课","蔡徐坤","原神","Minecraft","世界杯","阿根廷","鬼畜","社交","知识","纪录片","核酸","抗原",
            "华强","人类高质量","PlayStation","XBox","苹果","微软","华为","2023","英伟达","4090","4090 ti","腾讯","体育","阳康"};

        private static List<string> tag = new List<string>();

        private static Random random = new Random();

        private static bool _processing;
        private static bool _break;

        private static void printt(string args)
        {
            Console.WriteLine("[ {0}:{1} ] {2}", hour_display, minute_display, args);
        }

        private static void advice(string word, string insert)
        {
            Console.WriteLine(">>> {0} [ 输入 {1} ]", word, insert);
        }

        private static void reset_time()
        {
            hour_tick = 8;
            minute_tick = 0;
            hour_display = "08";
            minute_display = "00";
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

        private static void e_down(int edown)
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

        private static void h_down(int hdown)
        {
            int h_down_dif = hunger - hdown;
            if (h_down_dif < 0)
            {
                printt("饱食度 - " + hunger);
                hunger = 0;
            }
            else
            {
                printt("饱食度 - " + hdown);
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

        private static void m_up(int mup)
        {
            money += mup;
            printt("金币 + " + mup);
        }

        private static void m_down(int mdown)
        {
            int m_dif = money - mdown;
            if (m_dif < 0)
            {
                printt("金币 - " + money);
                advice("你的金币已用尽。快去投稿视频获得金币吧~", "投稿");
            }
            else
            {
                printt("金币 - " + mdown);
                money -= mdown;
            }
        }

        private static void time_logic()
        {
            while (true)
            {
                Thread.Sleep((int)(0.75 * 1000));
                minute_tick += 1;
                if (minute_tick == 60)
                {
                    minute_tick = 0;
                    hour_tick += 1;
                }
                if (hour_tick == 24)
                {
                    hour_tick = 0;
                    minute_tick = 0;
                }
                if (Convert.ToString(hour_tick).Length == 1)
                {
                    hour_display = "0" + Convert.ToString(hour_tick);
                }
                else
                {
                    hour_display = Convert.ToString(hour_tick);
                }
                if (Convert.ToString(minute_tick).Length == 1)
                {
                    minute_display = "0" + Convert.ToString(minute_tick);
                }
                else
                {
                    minute_display = Convert.ToString(minute_tick);
                }
                if (day == 1 && hour_tick == 20 && minute_tick == 0)
                {
                    advice("该睡觉啦~ 明天元气满满地继续努力！", "睡觉");
                    Thread.Sleep(2 * 1000);
                }
            }
        }

        private static void spread_logic()
        {
            while (true)
            {
                if (minute_tick != 0) continue;
                Thread.Sleep(random.Next(1, 30) * 1000);
                if (_processing) continue;
                for (int key_list = 0; key_list < video.Count; key_list++)
                {
                    int new_play;
                    if (video.Count < 6)
                    {
                        new_play = random.Next(0, video_spread[key_list] + 1);
                    }
                    else
                    {
                        new_play = random.Next(video_spread[key_list] - 5, video_spread[key_list] + 1);
                    }

                    if (new_play == 0) continue;
                    video_play[key_list] = video_play[key_list] + new_play;
                    printt("恭喜你，你的视频 " + video[key_list] + " 新增了 " + new_play + " 次播放！");
                }
                Thread.Sleep(15 * 1000);
            }
        }

        private static void follower_logic()
        {
            while (true)
            {
                if (num <= 1 & day <= 1 & play_all <= 20) continue;
                if (hour_tick != 10 & hour_tick != 12 & hour_tick != 16 & hour_tick != 19) continue;
                Thread.Sleep(random.Next(1, 20) * 1000);
                if (_processing) continue;
                int new_follower = random.Next(0, num / 5 + 1);
                if (new_follower != 0)
                {
                    follower += new_follower;
                    printt("恭喜你，你新增了 " + new_follower + " 个粉丝！");
                }
                Thread.Sleep(20 * 1000);
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
            while (true)
            {
                play_all = video_play.Sum();
            }
        }

        public static void good_morning()
        {
            _break = false;
            if (day == 1)
            {
                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine(">>> 这是你在UP镇生活的第 " + day + " 天");
                Thread.Sleep((int)(0.5 * 1000));
                Console.WriteLine(">>> 加油吧，" + name + "！");
                Console.WriteLine("------------------------------------------------------------");
                advice("up镇上还没有人知道你，快投稿你的第一个视频吧~", "投稿");
            }
            else
            {
                Console.WriteLine("zzZ....");
                Thread.Sleep(3 * 1000);
                int energyup = 100 - energy;
                e_up(energyup);
                Thread.Sleep(1 * 1000);
                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine(">>> 这是你在UP镇生活的第 " + day + " 天");
                Thread.Sleep((int)(0.5 * 1000));
                Console.WriteLine(">>> 你一共投稿了 " + num + " 个作品");
                Thread.Sleep((int)(0.5 * 1000));
                Console.WriteLine(">>> 你现在的粉丝量为 " + follower);
                Thread.Sleep((int)(0.5 * 1000));
                Console.WriteLine(">>> 你现在的总播放量为 " + play_all);
                Thread.Sleep((int)(0.5 * 1000));
                Console.WriteLine(">>> 继续加油吧，" + name + "！");
                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine("  结算昨日收益...");
                int spread_width = 0;
                for (int key = 0; key < video.Count; key++)
                {
                    string video_release_time_string = video_release_time[key];
                    string[] video_release_time_split = video_release_time_string.Split("|");
                    if (video_release_time_split[0] == Convert.ToString(day - 1))
                    {
                        spread_width += video_play[key];
                    }
                }
                Console.WriteLine("  昨日总播放量：" + spread_width + " 获得收益：");
                int add_money = random.Next(spread_width / 10, spread_width / 5);
                reset_time();
                m_up(add_money);
                Console.WriteLine("------------------------------------------------------------");
                tag.Clear();
                while (tag.Count < 6)
                {
                    tag.Add(tags[random.Next(0, tags.Count)]);
                    for (int i = 0; i < tag.Count; i++)
                    {
                        for (int j = tag.Count - 1; j > i; j--)
                        {
                            if (tag[i] == tag[j])
                            {
                                tag.RemoveAt(j);
                            }
                        }
                    }
                }
                Console.WriteLine("  今日热点：" + tag[0] + "，" + tag[1] + "，" + tag[2] + "，" + tag[3] + "，" + tag[4]);
                Console.WriteLine("------------------------------------------------------------");
                reset_time();
            }
        }

        public static void publish_a_video()
        {
            if (energy < 40)
            {
                advice("你的精力不足，快去吃点东西吧~", "恰饭");
            }
            else if (hunger < 30)
            {
                advice("你的饱食度不足，快去吃点东西吧~", "恰饭");
            }
            else
            {
                printt("制作你的第 " + (num + 1) + " 个作品！");
                Console.Write("[ {0}:{1} ] {2}", hour_display, minute_display, "设置作品标题：");
                string? title = Console.ReadLine();
                printt("视频投稿成功！推广加载中...");
                video.Add(title!);
                string release_time = day + "|" + hour_tick + "|" + minute_tick;
                video_release_time.Add(release_time);
                int spread_num = (day + num + follower) / 4 + 1;
                if (spread_num <= 3)
                {
                    spread_num += 2;
                }
                if (day > 1)
                {
                    if (title!.IndexOf(tag[0], StringComparison.Ordinal) != -1 || 
                        title.IndexOf(tag[1], StringComparison.Ordinal) != -1 || 
                        title.IndexOf(tag[2], StringComparison.Ordinal) != -1 || 
                        title.IndexOf(tag[3], StringComparison.Ordinal) != -1 || 
                        title.IndexOf(tag[4], StringComparison.Ordinal) != -1)
                    {
                        spread_num += 6;
                        printt("视频中含有时事热点内容，推广力度加大！");
                    }
                }
                Thread.Sleep((int)(0.5 * 1000));
                video_spread.Add(spread_num);
                video_play.Add(0);
                num += 1;
                printt("推广已开始！");
                Thread.Sleep((int)(0.5 * 1000));
                e_down(40);
                Thread.Sleep((int)(0.5 * 1000));
                h_down(40);
                if (num == 1)
                {
                    advice("视频发布成功啦！快去你的空间看看吧~", "空间");
                }
            }
        }

        public static void print_information()
        {
            ConsoleTable consoletable = new ConsoleTable("信息", "值");
            consoletable
                .AddRow("总播放量", play_all)
                .AddRow("粉丝数", follower)
                .AddRow("精力", energy)
                .AddRow("饱食度", hunger)
                .AddRow("金币", money);
            Console.WriteLine(consoletable.ToAlternativeString());
        }

        public static void my_space()
        {
            printt("欢迎来到你的个人空间！");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine(" " + name + " 的 个人空间" + "   " + "粉丝数 " + follower + " 播放数 " + play_all + "\n");
            if (num == 0)
            {
                advice("你的空间里还没有视频，快去投稿吧~", "投稿");
            }
            else
            {
                ConsoleTable consoletable = new ConsoleTable("序号", "视频标题", "发布时间", "播放量", "展现量");
                for (int key_space = 0; key_space < num; key_space++)
                {
                    consoletable.AddRow(
                        key_space + 1,
                        video[key_space],
                        "Day " + video_release_time[key_space].Split("|")[0] + "  " + video_release_time[key_space].Split("|")[1] + ": " + video_release_time[key_space].Split("|")[2],
                        video_play[key_space],
                        video_spread[key_space]
                    );
                }
                Console.Write(consoletable.ToMarkdownString());
            }
            Console.WriteLine("------------------------------------------------------------");
        }

        public static void have_food()
        {
            if (energy == 100 && hunger == 100)
            {
                printt("你的饱食度和精力都已满，快去投稿作品吧~");
            }
            if (money >= 5)
            {
                m_down(5);
                Thread.Sleep((int)(0.5 * 1000));
                e_up(20);
                Thread.Sleep((int)(0.5 * 1000));
                h_up(40);
            }
            else
            {
                advice("金币不足，快去投稿视频赚钱吧~", "投稿");
            }
        }

        public static void go_to_sleep()
        {
            if (hour_tick is > 8 and < 20)
            {
                printt("大白天的，睡不着~");
            }
            else
            {
                _break = true;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("我要当up主！2");
            Console.WriteLine("------------------------------------------------------------");

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
            name = Console.ReadLine()!;

            while (true)
            {
                _processing = true;

                day += 1;
                good_morning();

                _processing = false;

                while (true)
                {
                    _processing = false;
                    
                    Console.Write("[ {0}:{1} ] ", hour_display, minute_display);
                    string? cmd = Console.ReadLine();

                    _processing = true;

                    switch (cmd)
                    {
                        case "投稿":
                            publish_a_video();
                            break;
                        
                        case "信息":
                            print_information();
                            break;
                        
                        case "空间":
                            my_space();
                            break;
                        
                        case "恰饭":
                            have_food();
                            break;
                        
                        case "睡觉":
                            go_to_sleep();
                            break;
                    }

                    if (_break) break;
                }
            }
        }
    }
}
