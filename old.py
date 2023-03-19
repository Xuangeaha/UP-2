import time
import random
import threading
import prettytable


print("我要当up主！2023.0.1")
print("--------------------------------------------------")

processing = False

day = 0
hour_tick = 8
minute_tick = 0
hour_display = "08"
minute_display = "00"

num = 0

money = 100

follower = 0
play_all = 0

energy = 100
hunger = 100

video = []
video_spread = []
video_play = []
video_release_time = []

advice1 = 0

tags = ['我的世界','游戏','iPhone 14','疫情','科技','猫和老鼠','何同学','籽岷','布洛芬','网课','蔡徐坤','原神','Minecraft','世界杯',
        '阿根廷','鬼畜','社交','知识','纪录片','核酸','抗原','华强','人类高质量','俄乌局势','PlayStation','XBox','苹果','微软','华为',
        '二十大','2023','英伟达','4090','4090 ti','腾讯','体育','阳康']

def printt(*args):
    print("[",hour_display+":"+minute_display,"]",*args)

def inputt(*args):
    return input("[ "+hour_display+":"+minute_display+" ]"+str(*args))

def advice(word:str,insert:str):
    print(">>>",word,"[ 输入",insert,"]")

def time_logic():
    while True:
        time.sleep(0.5)
        global hour_tick, minute_tick, hour_display, minute_display
        minute_tick += 1
        if minute_tick == 60:
            minute_tick = 0
            hour_tick += 1
        if hour_tick == 24:
            hour_tick = 0
            minute_tick = 0
        if len(str(hour_tick)) == 1:
            hour_display = "0" + str(hour_tick)
        else:
            hour_display = str(hour_tick)
        if len(str(minute_tick)) == 1:
            minute_display = "0" + str(minute_tick)
        else:
            minute_display = str(minute_tick)

def time_reset():
    global hour_tick, minute_tick, hour_display, minute_display
    hour_tick = 8
    minute_tick = 0
    hour_display = "08"
    minute_display = "00"

def spread():
    while True:
        if minute_tick == 0:
            time.sleep(random.randint(1,40))
            if processing == False:
                if len(video) < 5:
                    for list_num in range(0,len(video)):
                        new_play = random.randint(0,int(video_spread[list_num]))
                        if new_play == 0:
                            pass
                        else:
                            video_play[list_num] += new_play
                            printt("恭喜你，你的视频",video[list_num],"新增了",new_play,"次播放！")
                else:
                    for list_num in range(len(video)-5,len(video)):
                        new_play = random.randint(0,int(video_spread[list_num]))
                        if new_play == 0:
                            pass
                        else:
                            video_play[list_num] += new_play
                            printt("恭喜你，你的视频",video[list_num],"新增了",new_play,"次播放！")
                time.sleep(15)

def flwer():
    global follower
    while True:
        if processing == False:
            if num > 1 and day > 1 and play_all > 20:
                if hour_tick == 10 or hour_tick == 12 or hour_tick == 16 or hour_tick == 19:
                    time.sleep(random.randint(1,20))
                    new_follower = random.randint(0,int(num/5)+1)
                    if new_follower == 0:
                        pass
                    else:
                        follower += new_follower
                        printt("恭喜你，你新增了",new_follower,"个粉丝！")
                    time.sleep(40)


def enghgr():
    global energy, hunger
    while True:
        energy -= 1
        hunger -= 1
        time.sleep(30)

def info():
    global play_all
    while True:
        play_all = sum(video_play)

        if day == 1 and hour_tick == 20 and minute_tick == 0:
            advice("该睡觉啦~ 明天元气满满地继续努力！","睡觉")
            time.sleep(2)

def eng_use(engamount):
    global energy, advice1
    endo = energy - engamount
    if endo < 0:
        printt("精力 -",energy)
        energy = 0
    else:
        printt("精力 -",engamount)
        energy -= engamount
    if energy <= 20:
        printt("你觉得有些累了。")
        if advice1 == 0:
            advice("吃点东西，回复精力和饱食度！","恰饭")
            advice1 = 1

def hgr_use(hgramount):
    global hunger, advice1
    hgdo = hunger - hgramount
    if hgdo < 0:
        printt("饱食度 -",hunger)
        hunger = 0
    else:
        printt("饱食度 -",hgramount)
        hunger -= hgramount
    if hunger <= 20:
        printt("你觉得有些饿了。")
        if advice1 == 0:
            advice("吃点东西，回复精力和饱食度！","恰饭")
            advice1 = 1

def eng_up(enguamount):
    global energy
    tnup = energy + enguamount
    if tnup > 100:
        printt("精力 +",100-energy)
        energy = 100
    else:
        printt("精力 +",enguamount)
        energy += enguamount

def hgr_up(hgruamount):
    global hunger
    hgup = hunger + hgruamount
    if hgup > 100:
        printt("饱食度 +",100-hunger)
        hunger = 100
    else:
        printt("饱食度 +",hgruamount)
        hunger += hgruamount

def money_down(moneymount):
    global money
    mondo = money - moneymount
    if mondo < 0:
        printt("金币 -",money)
        advice("你的金币已用尽。快去投稿视频获得金币吧~","投稿")
    else:
        printt("金币 -",moneymount)
        money -= moneymount

def money_up(moneyuamount):
    global money
    printt("金币 +",moneyuamount)
    money += moneyuamount

time_logic_thread = threading.Thread(target=time_logic)
time_logic_thread.start()

logic_thread = threading.Thread(target=spread)
logic_thread.start()

follower_thread = threading.Thread(target=flwer)
follower_thread.start()

enghgr_thread = threading.Thread(target=enghgr)
enghgr_thread.start()

info_thread = threading.Thread(target=info)
info_thread.start()

name = input("欢迎来到UP镇！请设置你的名字：")

while True:
    processing = True
    day += 1
    if day == 1:
        print("--------------------------------------------------")
        print(">>> 这是你在UP镇生活的第",day,"天")
        time.sleep(1)
        print(">>> 加油吧，",name,"！")
        print("--------------------------------------------------")
        advice("up镇上还没有人知道你，快投稿你的第一个视频吧~","投稿")
    else:
        printt("zzZ....")
        time.sleep(3)
        energyup = 100 - energy
        eng_up(energyup)
        print("--------------------------------------------------")
        print(">>> 这是你在UP镇生活的第",day,"天")
        time.sleep(0.5)
        print(">>> 你一共投稿了",num,"个作品")
        time.sleep(0.5)
        print(">>> 你现在的粉丝量为",follower)
        time.sleep(0.5)
        print(">>> 你现在的总播放量为",play_all)
        time.sleep(0.5)
        print(">>> 继续加油吧，",name,"！")
        print("--------------------------------------------------")
        print("  结算昨日收益...")
        spread_width = 0
        for key in range(0,len(video)):
            if video_release_time[key].split("|")[0] == str(day - 1):
                spread_width += int(video_play[key])
        print("  昨日总播放量：",spread_width,"获得收益：")
        add_money = random.randint(int(spread_width/10),int(spread_width/5))
        money += add_money
        print("  金币 +",add_money)
        print("--------------------------------------------------")
        tag = random.sample(tags,5)
        print("  今日热点："+tag[0]+"，"+tag[1]+"，"+tag[2]+"，"+tag[3]+"，"+tag[4])
        print("--------------------------------------------------")
    time_reset()
    processing = False
    while True:
        cmd = inputt()
        processing = True
        if cmd == "投稿":
            if energy < 40:
                advice("你的精力不足，快去吃点东西吧~","恰饭")
            elif hunger < 30:
                advice("你的饱食度不足，快去吃点东西吧~","恰饭")
            else:
                printt("制作你的第",num + 1,"个作品！")
                title = inputt(" 设置作品标题：")
                printt("视频投稿成功！推广加载中...")
                video.append(title)
                release_time = str(day) + "|" + str(hour_tick) + "|" + str(minute_tick)
                video_release_time.append(release_time)
                spread_num = int((num + follower)/4 + 1)
                if spread_num <= 3:
                    spread_num += 2
                if day > 1:
                    if tag[0] in title or tag[1] in title or tag[2] in title or tag[3] in title or tag[4] in title:
                        spread_num += 8
                        printt("视频中含有时事热点内容，推广力度加大！")
                video_spread.append(spread_num)
                video_play.append(0)
                num += 1
                time.sleep(0.5)
                printt("推广已开始！")
                eng_use(40)
                hgr_use(40)
                if num == 1:
                    advice("视频发布成功啦！快去你的空间看看吧~","空间")

        if cmd == "信息":
            information_table = prettytable.PrettyTable()
            information_table.field_names = ['信息','值']
            information_table.add_rows([
                ['总播放量',play_all],
                ['粉丝数',follower],
                ['精力',energy],
                ['饱食度',hunger],
                ['金币',money]
            ])
            print(information_table)

        if cmd == "空间":
            printt("欢迎来到你的个人空间！")

            print("--------------------------------------------------")
            print("",name,"的 个人空间","   ","粉丝数",follower,"播放数",play_all)
            if num == 0:
                advice("你的空间里还没有视频，快去投稿吧~","投稿")
                print("--------------------------------------------------")
            else:
                space_video_table = prettytable.PrettyTable()
                space_video_table.field_names = ['序号','视频标题','发布时间','播放量','展现量']
                for key_space in range(0,num):
                    space_video_table.add_row([
                        key_space+1,
                        video[key_space],
                        "Day "+video_release_time[key_space].split("|")[0]+"  "+video_release_time[key_space].split("|")[1]+": "+video_release_time[key_space].split("|")[2],
                        video_play[key_space],
                        video_spread[key_space]
                    ])
                print(space_video_table)
                print("--------------------------------------------------")

        if cmd == "恰饭":
            if money >= 5:
                money_down(5)
                eng_up(20)
                hgr_up(40)
            else:
                advice("金币不足，快去投稿视频赚钱吧~","投稿")

        if cmd == "睡觉":
            if 8 < hour_tick < 20:
                printt("大白天的，睡不着~")
            else:
                break

        processing = False
