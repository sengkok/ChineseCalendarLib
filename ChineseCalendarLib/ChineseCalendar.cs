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

using System.Globalization;


namespace ChineseCalendarLib;

public static partial class ChineseCalendar
{
    // ---------------- Models for "Today Info" ----------------

    public class TodayInfo
    {
        public DateTime Now { get; set; }
        public string LunarText { get; set; } = "";
        public string LunarTextEN { get; set; } = "";
        public string Zodiac { get; set; } = "";
        public string ZodiacEN { get; set; } = "";
        public string GanzhiYear { get; set; } = "";
        public string SolarTerm { get; set; } = "";
        public string SolarTermEN { get; set; } = "";
    }

    // ---------------- Public API ----------------

    public static TodayInfo GetToday(string? timeZoneId = "Asia/Kuala_Lumpur")
    {
        var tz = SafeTimeZone(timeZoneId);
        var now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, tz);
        return BuildLunarInfo(now, timeZoneId);
    }

    public static TodayInfo GetLunarInfo(DateTime dateTime, string? timeZoneId = "Asia/Kuala_Lumpur")
        => BuildLunarInfo(dateTime, timeZoneId);

    // ---------------- Core Builders ----------------

    private static TodayInfo BuildLunarInfo(DateTime dt, string? timeZoneId)
    {
        // Simplified lunar & zodiac generation (approximation)
        ChineseLunisolarCalendar cal = new();
        int lunarYear = cal.GetYear(dt);
        int lunarMonth = cal.GetMonth(dt);
        int lunarDay = cal.GetDayOfMonth(dt);
        int zodiacIndex = (lunarYear - 4) % 12;
        string zodiac = ZodiacNames[zodiacIndex];
        string lunarText = $"{LunarMonths[(lunarMonth - 1) % 12]}{LunarDays[(lunarDay - 1) % 30]}";

        string ganzhiYear = GetGanzhiYear(lunarYear);
        string? term = GetSolarTerm(dt);

        return new TodayInfo
        {
            Now = dt,
            LunarText = lunarText,
            LunarTextEN = TranslateLunarToEN(lunarText),
            Zodiac = zodiac,
            ZodiacEN = TranslateZodiacToEN(zodiac),
            GanzhiYear = ganzhiYear,
            SolarTerm = term,
            SolarTermEN = term != null ? SolarTermEN(term) : null
        };
    }

    // ---------------- Daily Fortune Generator ----------------

    public static Models.DailyFortune GetDailyFortune(DateTime date, string? timeZoneId = "Asia/Kuala_Lumpur")
    {
        var info = GetLunarInfo(date, timeZoneId);
        var zodiac = info.Zodiac;
        var zodiacEN = info.ZodiacEN;

        // Basic fortune randomizer (you can expand later with real logic)
        int luck = (zodiac.GetHashCode() + date.Day) % 5 + 1;

        var goodActions = new List<string> { "祈福", "祭拜", "出行", "理发", "纳财" };
        var badActions = new List<string> { "诉讼", "搬家", "入宅", "开仓" };

        var goodEN = goodActions.Select(TranslateActionToEN).ToList();
        var badEN = badActions.Select(TranslateActionToEN).ToList();

        var goodDirection = "东南";
        var badDirection = "西北";

        return new Models.DailyFortune
        {
            Date = date,
            LunarText = info.LunarText,
            LunarTextEN = info.LunarTextEN,
            Zodiac = zodiac,
            ZodiacEN = zodiacEN,
            LuckIndex = luck,
            Good = goodActions,
            Bad = badActions,
            GoodEN = goodEN,
            BadEN = badEN,
            GoodDirection = goodDirection,
            GoodDirectionEN = TranslateDirectionToEN(goodDirection),
            GodOfHappiness = "南",
            GodOfHappinessEN = "South",
            GodOfWealth = "东南",
            GodOfWealthEN = "Southeast",
            GodOfBlessing = "东北",
            GodOfBlessingEN = "Northeast",
            ClashZodiac = zodiac,
            ClashZodiacEN = zodiacEN,
            OverallFortune = $"今日（{date:yyyy-MM-dd}）整体运势：{LuckSummaryCN(luck)}。",
            OverallFortuneEnglish = $"Overall fortune for {date:yyyy-MM-dd}: {LuckSummaryEN(luck)}"
        };
    }

    private static string LuckSummaryCN(int luck) => luck switch
    {
        5 => "大吉，诸事顺利。",
        4 => "吉祥如意，适合行动。",
        3 => "平稳中带机遇，保持耐心。",
        2 => "需谨慎行事，避免冲动。",
        _ => "运势偏弱，宜静不宜动。"
    };

    private static string LuckSummaryEN(int luck) => luck switch
    {
        5 => "Excellent luck — everything goes smoothly.",
        4 => "Good luck — suitable for actions and progress.",
        3 => "Average luck — stay patient, opportunities arise.",
        2 => "Be cautious — avoid impulsive decisions.",
        _ => "Low energy day — rest and plan ahead."
    };
    // ---------------- Helpers ----------------

    private static readonly string[] ZodiacNames =
    { "鼠", "牛", "虎", "兔", "龙", "蛇", "马", "羊", "猴", "鸡", "狗", "猪" };

    private static readonly string[] LunarMonths =
    { "正月", "二月", "三月", "四月", "五月", "六月", "七月", "八月", "九月", "十月", "冬月", "腊月" };

    private static readonly string[] LunarDays =
    {
        "初一","初二","初三","初四","初五","初六","初七","初八","初九","初十",
        "十一","十二","十三","十四","十五","十六","十七","十八","十九","二十",
        "廿一","廿二","廿三","廿四","廿五","廿六","廿七","廿八","廿九","三十"
    };

    private static TimeZoneInfo SafeTimeZone(string? id)
    {
        try { return TimeZoneInfo.FindSystemTimeZoneById(id ?? "Asia/Kuala_Lumpur"); }
        catch { return TimeZoneInfo.Local; }
    }

    private static string GetGanzhiYear(int year)
    {
        string[] stems = { "甲", "乙", "丙", "丁", "戊", "己", "庚", "辛", "壬", "癸" };
        string[] branches = { "子", "丑", "寅", "卯", "辰", "巳", "午", "未", "申", "酉", "戌", "亥" };
        return $"{stems[(year - 4) % 10]}{branches[(year - 4) % 12]}年";
    }

    private static string? GetSolarTerm(DateTime dt)
    {
        // Simplified placeholder: you can replace with precise astronomical algorithm later.
        string[] terms = { "小寒", "大寒", "立春", "雨水", "惊蛰", "春分", "清明", "谷雨",
                           "立夏", "小满", "芒种", "夏至", "小暑", "大暑",
                           "立秋", "处暑", "白露", "秋分", "寒露", "霜降",
                           "立冬", "小雪", "大雪", "冬至" };
        // Dummy approximate: pick one per half month
        int index = (dt.Month - 1) * 2 + (dt.Day >= 15 ? 1 : 0);
        return terms[index % 24];
    }
}
