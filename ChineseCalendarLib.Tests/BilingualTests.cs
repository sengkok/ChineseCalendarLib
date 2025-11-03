
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

namespace ChineseCalendarLib.Tests;

public class BilingualTests
{
    [Fact]
    public void Zodiac_Translation_CN_to_EN_and_back()
    {
        string zh = "龙";
        string en = ChineseCalendar.TranslateZodiacToEN(zh);
        Assert.Equal("Dragon", en);
        Assert.Equal(zh, ChineseCalendar.TranslateZodiacToCN(en));
    }

    [Fact]
    public void Direction_Translation_Bidirectional()
    {
        string zh = "东南";
        string en = ChineseCalendar.TranslateDirectionToEN(zh);
        Assert.Equal("Southeast", en);
        Assert.Equal(zh, ChineseCalendar.TranslateDirectionToCN(en));
    }

    [Fact]
    public void Action_Translation_Bidirectional()
    {
        string zh = "祈福";
        string en = ChineseCalendar.TranslateActionToEN(zh);
        Assert.Equal("Prayer", en);
        Assert.Equal(zh, ChineseCalendar.TranslateActionToCN(en));
    }

    [Fact]
    public void SolarTerm_Translation_Bidirectional()
    {
        string zh = "立春";
        string en = ChineseCalendar.SolarTermEN(zh);
        Assert.Equal("Beginning of Spring", en);
        Assert.Equal(zh, ChineseCalendar.TranslateSolarTermToCN(en));
    }

    [Fact]
    public void Lunar_Translation_To_English()
    {
        string lunar = "九月十三";
        string result = ChineseCalendar.TranslateLunarToEN(lunar);
        Assert.Contains("Month", result);
        Assert.Contains("Day", result);
    }

    [Fact]
    public void GetToday_Returns_Valid_Info()
    {
        var today = ChineseCalendar.GetToday("Asia/Kuala_Lumpur");
        Assert.NotNull(today.LunarText);
        Assert.NotNull(today.Zodiac);
        Assert.NotNull(today.ZodiacEN);
    }

    [Fact]
    public void GetDailyFortune_Returns_Valid_Result()
    {
        var date = new DateTime(1990, 5, 17);
        var f = ChineseCalendar.GetDailyFortune(date);
        Assert.InRange(f.LuckIndex, 1, 5);
        Assert.False(string.IsNullOrWhiteSpace(f.ZodiacEN));
        Assert.False(string.IsNullOrWhiteSpace(f.OverallFortuneEnglish));
    }
}
