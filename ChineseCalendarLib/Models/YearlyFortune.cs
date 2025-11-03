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
namespace ChineseCalendarLib.Models;

public class YearlyFortune
{
    // ---------- Basic Info ----------
    public int Year { get; set; }
    public string Zodiac { get; set; } = "";
    public string ZodiacEN { get; set; } = "";
    public string Element { get; set; } = "";
    public string ElementEN { get; set; } = "";
    public int LuckIndex { get; set; } = 4;

    // ---------- CN fortune ----------
    public string WealthFortune { get; set; } = "";
    public string CareerFortune { get; set; } = "";
    public string LoveFortune { get; set; } = "";
    public string HealthFortune { get; set; } = "";
    public string LuckyDirection { get; set; } = "";
    public string UnluckyDirection { get; set; } = "";
    public string BestMonths { get; set; } = "";
    public string CautionMonths { get; set; } = "";
    public string SummaryCN { get; set; } = "";

    // ---------- EN fortune ----------
    public string WealthFortuneEN { get; set; } = "";
    public string CareerFortuneEN { get; set; } = "";
    public string LoveFortuneEN { get; set; } = "";
    public string HealthFortuneEN { get; set; } = "";
    public string LuckyDirectionEN { get; set; } = "";
    public string UnluckyDirectionEN { get; set; } = "";
    public string BestMonthsEN { get; set; } = "";
    public string CautionMonthsEN { get; set; } = "";
    public string SummaryEN { get; set; } = "";
    public string LuckCycleEN { get; set; } = "";
}
