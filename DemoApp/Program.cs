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
using System.Text;
using ChineseCalendarLib;
using ChineseCalendarLib.Models;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("=== Chinese Calendar & Fortune Demo (Bilingual, plain) ===\n");

        // ---------------- Today Info ----------------
        var today = ChineseCalendar.GetToday("Asia/Kuala_Lumpur");
        Console.WriteLine("【今日信息 / Today Info】");
        Console.WriteLine($"公历日期 / Gregorian : {today.Now:yyyy-MM-dd dddd}");
        Console.WriteLine($"农历日期 / Lunar      : {today.LunarText}  |  {today.LunarTextEN}");
        Console.WriteLine($"生肖 / Zodiac         : {today.Zodiac}  |  {today.ZodiacEN}");
        Console.WriteLine($"干支年 / Ganzhi Year  : {today.GanzhiYear}  |  {TranslateGanzhiYearToEN(today.GanzhiYear, today.Zodiac)}");
        Console.WriteLine($"节气 / Solar Term     : {(today.SolarTerm ?? "无")}  |  {(today.SolarTermEN ?? "None")}");
        Console.WriteLine();

        // ---------------- Daily Fortune ----------------
        var f = ChineseCalendar.GetDailyFortune(today.Now, "Asia/Kuala_Lumpur");
        Console.WriteLine("【每日运势 / Daily Fortune - 中文】");
        PrintDailyCN(f);
        Console.WriteLine();
        Console.WriteLine("【Daily Fortune - English】");
        PrintDailyEN(f);
        Console.WriteLine();

        // ---------------- Monthly Fortune ----------------
        var mf = new MonthlyFortune
        {
            Year = today.Now.Year,
            Month = today.Now.Month,
            LunarMonthName = "戌",
            LunarMonthNameEN = "Xu",
            DominantElement = "火",
            DominantElementEN = "Fire",
            LuckIndex = 3,
            WealthFortune = "支出增加，理财需谨慎。",
            WealthFortuneEN = "Spending may increase — manage budgets carefully.",
            LoveFortune = "感情活跃，情绪易起伏。",
            LoveFortuneEN = "Romantic opportunities increase, emotions run high.",
            CareerFortune = "工作变动多，避免冲动决策。",
            CareerFortuneEN = "Dynamic changes — avoid impulsive career moves.",
            HealthFortune = "注意压力与休息不足。",
            HealthFortuneEN = "Watch for stress and lack of rest.",
            SummaryCN = "本月主元素为「火」，象征激情与能量。整体运势中等偏上。",
            SummaryEN = "Dominant element: Fire (Passion and energy). Overall luck moderate to good."
        };

        Console.WriteLine("【月运势 / Monthly Fortune - 中文】");
        PrintMonthlyCN(mf);
        Console.WriteLine();
        Console.WriteLine("【Monthly Fortune - English】");
        PrintMonthlyEN(mf);
        Console.WriteLine();

        // ---------------- Yearly Fortune ----------------
        var yf = new YearlyFortune
        {
            Year = today.Now.Year,
            Zodiac = "蛇",
            ZodiacEN = "Snake",
            Element = "木",
            ElementEN = "Wood",
            LuckIndex = 4,
            WealthFortune = "稳健增长，适合长期理财。",
            WealthFortuneEN = "Steady growth; focus on long-term wealth planning.",
            CareerFortune = "进展缓慢，坚持终能成功。",
            CareerFortuneEN = "Opportunities grow slowly; patience will bring results.",
            LoveFortune = "感情稳定，注意沟通。",
            LoveFortuneEN = "Stable relationships; avoid emotional overreactions.",
            HealthFortune = "整体良好，注意筋骨。",
            HealthFortuneEN = "Overall well-being, but joints may feel strained.",
            LuckyDirection = "东南",
            LuckyDirectionEN = "East / Southeast",
            UnluckyDirection = "西",
            UnluckyDirectionEN = "West",
            BestMonthsEN = "Goat, Monkey, Rooster",
            CautionMonthsEN = "Pig",
            SummaryCN = "生肖蛇，五行主木，整体运势旺盛，宜稳中求进。",
            SummaryEN = "Year of the Snake, Element Wood — prosperous and active year.",
            LuckCycleEN = "Positive upward cycle, favoring consistency and balance."
        };

        Console.WriteLine("【年运势 / Yearly Fortune - 中文】");
        PrintYearlyCN(yf);
        Console.WriteLine();
        Console.WriteLine("【Yearly Fortune - English】");
        PrintYearlyEN(yf);
        Console.WriteLine();

        // ---------------- Custom Date Fortune Example ----------------
        Console.WriteLine("【指定日期运势 / Custom Date Fortune】");

        var birthday = new DateTime(1990, 5, 17);
        var customFortune = ChineseCalendar.GetDailyFortune(birthday, "Asia/Kuala_Lumpur");

        Console.WriteLine($"输入日期 / Input Date: {birthday:yyyy-MM-dd}");
        Console.WriteLine($"生肖 / Zodiac: {customFortune.Zodiac} ({customFortune.ZodiacEN})");
        Console.WriteLine($"农历 / Lunar: {customFortune.LunarText} ({customFortune.LunarTextEN})");
        Console.WriteLine($"运势指数 / Luck Index: {customFortune.LuckIndex}/5");
        Console.WriteLine($"综合运势 / Overall: {customFortune.OverallFortune}");
        Console.WriteLine($"Overall Fortune: {customFortune.OverallFortuneEnglish}");
        Console.WriteLine();

        Console.WriteLine("=== End of Demo ===");
    }

    // ---------- Daily Fortune ----------
    static void PrintDailyCN(DailyFortune f)
    {
        Console.WriteLine($"日期：{f.Date:yyyy-MM-dd}");
        Console.WriteLine($"农历：{f.LunarText}");
        Console.WriteLine($"生肖：{f.Zodiac}");
        Console.WriteLine($"宜：{string.Join("、", f.Good)}");
        Console.WriteLine($"忌：{string.Join("、", f.Bad)}");
        Console.WriteLine($"吉方：{f.GoodDirection}");
        Console.WriteLine($"喜神：{f.GodOfHappiness}");
        Console.WriteLine($"财神：{f.GodOfWealth}");
        Console.WriteLine($"福神：{f.GodOfBlessing}");
        Console.WriteLine($"冲：{f.ClashZodiac}");
        Console.WriteLine($"运势指数：{f.LuckIndex}/5");
        Console.WriteLine();
        Console.WriteLine($"综合运势：{f.OverallFortune}");
    }

    static void PrintDailyEN(DailyFortune f)
    {
        Console.WriteLine($"Date: {f.Date:yyyy-MM-dd}");
        Console.WriteLine($"Lunar: {f.LunarTextEN}");
        Console.WriteLine($"Zodiac: {f.ZodiacEN}");
        Console.WriteLine($"Good: {string.Join(", ", f.GoodEN)}");
        Console.WriteLine($"Bad: {string.Join(", ", f.BadEN)}");
        Console.WriteLine($"Lucky Direction: {f.GoodDirectionEN}");
        Console.WriteLine($"God of Happiness: {f.GodOfHappinessEN}");
        Console.WriteLine($"God of Wealth: {f.GodOfWealthEN}");
        Console.WriteLine($"God of Blessing: {f.GodOfBlessingEN}");
        Console.WriteLine($"Clash Zodiac: {f.ClashZodiacEN}");
        Console.WriteLine($"Luck Index: {f.LuckIndex}/5");
        Console.WriteLine();
        Console.WriteLine($"Overall Fortune: {f.OverallFortuneEnglish}");
    }

    // ---------- Monthly Fortune ----------
    static void PrintMonthlyCN(MonthlyFortune mf)
    {
        Console.WriteLine($"年份：{mf.Year}");
        Console.WriteLine($"月份：{mf.Month}");
        Console.WriteLine($"农历月：{mf.LunarMonthName}");
        Console.WriteLine($"主元素（五行）：{mf.DominantElement}");
        Console.WriteLine($"运势指数：{mf.LuckIndex}/5");
        Console.WriteLine($"财运：{mf.WealthFortune}");
        Console.WriteLine($"感情：{mf.LoveFortune}");
        Console.WriteLine($"事业：{mf.CareerFortune}");
        Console.WriteLine($"健康：{mf.HealthFortune}");
        Console.WriteLine();
        Console.WriteLine("【本月概述】");
        Console.WriteLine(mf.SummaryCN);
    }

    static void PrintMonthlyEN(MonthlyFortune mf)
    {
        Console.WriteLine($"Year: {mf.Year}");
        Console.WriteLine($"Month: {mf.Month}");
        Console.WriteLine($"Lunar Month: {mf.LunarMonthNameEN}");
        Console.WriteLine($"Dominant Element: {mf.DominantElementEN}");
        Console.WriteLine($"Luck Index: {mf.LuckIndex}/5");
        Console.WriteLine($"Wealth: {mf.WealthFortuneEN}");
        Console.WriteLine($"Love: {mf.LoveFortuneEN}");
        Console.WriteLine($"Career: {mf.CareerFortuneEN}");
        Console.WriteLine($"Health: {mf.HealthFortuneEN}");
        Console.WriteLine();
        Console.WriteLine("【Monthly Summary】");
        Console.WriteLine(mf.SummaryEN);
    }

    // ---------- Yearly Fortune ----------
    static void PrintYearlyCN(YearlyFortune yf)
    {
        Console.WriteLine($"年份：{yf.Year}");
        Console.WriteLine($"生肖：{yf.Zodiac}");
        Console.WriteLine($"五行：{yf.Element}");
        Console.WriteLine($"吉方：{yf.LuckyDirection}");
        Console.WriteLine($"凶方：{yf.UnluckyDirection}");
        Console.WriteLine($"运势指数：{yf.LuckIndex}/5");
        Console.WriteLine($"财运：{yf.WealthFortune}");
        Console.WriteLine($"事业：{yf.CareerFortune}");
        Console.WriteLine($"感情：{yf.LoveFortune}");
        Console.WriteLine($"健康：{yf.HealthFortune}");
        Console.WriteLine();
        Console.WriteLine("【年度概述】");
        Console.WriteLine(yf.SummaryCN);
    }

    static void PrintYearlyEN(YearlyFortune yf)
    {
        Console.WriteLine($"Year: {yf.Year}");
        Console.WriteLine($"Zodiac: {yf.ZodiacEN}");
        Console.WriteLine($"Element: {yf.ElementEN}");
        Console.WriteLine($"Lucky Direction: {yf.LuckyDirectionEN}");
        Console.WriteLine($"Unlucky Direction: {yf.UnluckyDirectionEN}");
        Console.WriteLine($"Luck Index: {yf.LuckIndex}/5");
        Console.WriteLine($"Wealth: {yf.WealthFortuneEN}");
        Console.WriteLine($"Career: {yf.CareerFortuneEN}");
        Console.WriteLine($"Love: {yf.LoveFortuneEN}");
        Console.WriteLine($"Health: {yf.HealthFortuneEN}");
        Console.WriteLine($"Best Months: {yf.BestMonthsEN}");
        Console.WriteLine($"Caution Months: {yf.CautionMonthsEN}");
        Console.WriteLine();
        Console.WriteLine("【Yearly Summary】");
        Console.WriteLine(yf.SummaryEN);
        Console.WriteLine($"Luck Cycle: {yf.LuckCycleEN}");
    }

    // ---------- Ganzhi Translator ----------
    static string TranslateGanzhiYearToEN(string ganzhi, string zodiacCN)
    {
        var stemMap = new System.Collections.Generic.Dictionary<string, string>
        {
            ["甲"] = "Jia (Wood Yang)",
            ["乙"] = "Yi (Wood Yin)",
            ["丙"] = "Bing (Fire Yang)",
            ["丁"] = "Ding (Fire Yin)",
            ["戊"] = "Wu (Earth Yang)",
            ["己"] = "Ji (Earth Yin)",
            ["庚"] = "Geng (Metal Yang)",
            ["辛"] = "Xin (Metal Yin)",
            ["壬"] = "Ren (Water Yang)",
            ["癸"] = "Gui (Water Yin)"
        };
        var branchMap = new System.Collections.Generic.Dictionary<string, string>
        {
            ["子"] = "Zi (Rat)",
            ["丑"] = "Chou (Ox)",
            ["寅"] = "Yin (Tiger)",
            ["卯"] = "Mao (Rabbit)",
            ["辰"] = "Chen (Dragon)",
            ["巳"] = "Si (Snake)",
            ["午"] = "Wu (Horse)",
            ["未"] = "Wei (Goat)",
            ["申"] = "Shen (Monkey)",
            ["酉"] = "You (Rooster)",
            ["戌"] = "Xu (Dog)",
            ["亥"] = "Hai (Pig)"
        };
        if (ganzhi.Length >= 2)
        {
            string s = ganzhi.Substring(0, 1);
            string b = ganzhi.Substring(1, 1);
            string sEN = stemMap.ContainsKey(s) ? stemMap[s] : s;
            string bEN = branchMap.ContainsKey(b) ? branchMap[b] : b;
            string zEN = ChineseCalendar.TranslateZodiacToEN(zodiacCN);
            return $"{sEN}–{bEN} Year ({zEN})";
        }
        return ganzhi;
    }
}
