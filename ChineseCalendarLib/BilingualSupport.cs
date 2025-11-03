// SPDX-License-Identifier: GPL-3.0-or-later
//
// ChineseCalendar Library
// Copyright (C) 2025 skai
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.

namespace ChineseCalendarLib;

public static partial class ChineseCalendar
{
    // ---------------- CN → EN Dictionaries ----------------

    internal static readonly Dictionary<string, string> ZodiacEN = new()
    {
        ["鼠"] = "Rat",
        ["牛"] = "Ox",
        ["虎"] = "Tiger",
        ["兔"] = "Rabbit",
        ["龙"] = "Dragon",
        ["蛇"] = "Snake",
        ["马"] = "Horse",
        ["羊"] = "Goat",
        ["猴"] = "Monkey",
        ["鸡"] = "Rooster",
        ["狗"] = "Dog",
        ["猪"] = "Pig"
    };

    internal static readonly Dictionary<string, string> DirectionEN = new()
    {
        ["北"] = "North",
        ["正北"] = "North",
        ["东北"] = "Northeast",
        ["东"] = "East",
        ["正东"] = "East",
        ["东南"] = "Southeast",
        ["南"] = "South",
        ["正南"] = "South",
        ["西南"] = "Southwest",
        ["西"] = "West",
        ["正西"] = "West",
        ["西北"] = "Northwest",
        ["北偏西"] = "North-Northwest",
        ["中宫"] = "Center"
    };

    internal static readonly Dictionary<string, string> ActionEN = new()
    {
        ["出行"] = "Travel",
        ["祈福"] = "Prayer",
        ["祭拜"] = "Worship",
        ["理发"] = "Haircut",
        ["纳财"] = "Receive wealth",
        ["谈判"] = "Negotiation",
        ["签约"] = "Sign contract",
        ["诉讼"] = "Lawsuit",
        ["砍伐"] = "Tree cutting",
        ["入宅"] = "Move into house",
        ["搬家"] = "Move house",
        ["安床"] = "Set up bed",
        ["安葬"] = "Funeral",
        ["开仓"] = "Open storage"
    };

    internal static readonly Dictionary<string, string> SolarTermDict = new()
    {
        ["小寒"] = "Minor Cold",
        ["大寒"] = "Major Cold",
        ["立春"] = "Beginning of Spring",
        ["雨水"] = "Rain Water",
        ["惊蛰"] = "Awakening of Insects",
        ["春分"] = "Spring Equinox",
        ["清明"] = "Pure Brightness (Qingming)",
        ["谷雨"] = "Grain Rain",
        ["立夏"] = "Beginning of Summer",
        ["小满"] = "Lesser Fullness of Grain",
        ["芒种"] = "Grain in Ear",
        ["夏至"] = "Summer Solstice",
        ["小暑"] = "Minor Heat",
        ["大暑"] = "Major Heat",
        ["立秋"] = "Beginning of Autumn",
        ["处暑"] = "End of Heat",
        ["白露"] = "White Dew",
        ["秋分"] = "Autumn Equinox",
        ["寒露"] = "Cold Dew",
        ["霜降"] = "Frost Descent",
        ["立冬"] = "Beginning of Winter",
        ["小雪"] = "Minor Snow",
        ["大雪"] = "Major Snow",
        ["冬至"] = "Winter Solstice"
    };

    // ---------------- CN → EN Translators ----------------

    public static string TranslateZodiacToEN(string zh)
        => ZodiacEN.TryGetValue(zh, out var en) ? en : zh;

    public static string TranslateDirectionToEN(string zh)
        => DirectionEN.TryGetValue(zh, out var en) ? en : zh;

    public static string TranslateActionToEN(string zh)
        => ActionEN.TryGetValue(zh, out var en) ? en : zh;

    public static string SolarTermEN(string termZh)
        => SolarTermDict.TryGetValue(termZh, out var en) ? en : termZh;

    // ---------------- Extra Helpers ----------------

    public static List<string> TranslateActionsToEN(IEnumerable<string> list)
        => list.Select(TranslateActionToEN).ToList();

    public static string TranslateLunarToEN(string lunarZh)
    {
        var monthMap = new Dictionary<string, string>
        {
            ["正月"] = "First Month",
            ["二月"] = "Second Month",
            ["三月"] = "Third Month",
            ["四月"] = "Fourth Month",
            ["五月"] = "Fifth Month",
            ["六月"] = "Sixth Month",
            ["七月"] = "Seventh Month",
            ["八月"] = "Eighth Month",
            ["九月"] = "Ninth Month",
            ["十月"] = "Tenth Month",
            ["冬月"] = "Eleventh Month",
            ["腊月"] = "Twelfth Month"
        };
        var dayMap = new Dictionary<string, string>
        {
            ["初一"] = "Day 1",
            ["初二"] = "Day 2",
            ["初三"] = "Day 3",
            ["初四"] = "Day 4",
            ["初五"] = "Day 5",
            ["初六"] = "Day 6",
            ["初七"] = "Day 7",
            ["初八"] = "Day 8",
            ["初九"] = "Day 9",
            ["初十"] = "Day 10",
            ["十一"] = "Day 11",
            ["十二"] = "Day 12",
            ["十三"] = "Day 13",
            ["十四"] = "Day 14",
            ["十五"] = "Day 15",
            ["十六"] = "Day 16",
            ["十七"] = "Day 17",
            ["十八"] = "Day 18",
            ["十九"] = "Day 19",
            ["二十"] = "Day 20",
            ["廿一"] = "Day 21",
            ["廿二"] = "Day 22",
            ["廿三"] = "Day 23",
            ["廿四"] = "Day 24",
            ["廿五"] = "Day 25",
            ["廿六"] = "Day 26",
            ["廿七"] = "Day 27",
            ["廿八"] = "Day 28",
            ["廿九"] = "Day 29",
            ["三十"] = "Day 30"
        };

        foreach (var (mKey, mVal) in monthMap)
            foreach (var (dKey, dVal) in dayMap)
                if (lunarZh.Contains(mKey) && lunarZh.Contains(dKey))
                    return $"{mVal}, {dVal}";

        return lunarZh;
    }
}
