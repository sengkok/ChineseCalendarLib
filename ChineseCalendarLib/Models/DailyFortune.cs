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

public class DailyFortune
{
    // ---------- Base Info ----------
    public DateTime Date { get; set; }
    public string LunarText { get; set; } = "";
    public string LunarTextEN { get; set; } = "";
    public string Zodiac { get; set; } = "";
    public string ZodiacEN { get; set; } = "";
    public int LuckIndex { get; set; } = 3;

    // ---------- CN fields ----------
    public List<string> Good { get; set; } = new();
    public List<string> Bad { get; set; } = new();
    public string GoodDirection { get; set; } = "";
    public string GodOfHappiness { get; set; } = "";
    public string GodOfWealth { get; set; } = "";
    public string GodOfBlessing { get; set; } = "";
    public string ClashZodiac { get; set; } = "";
    public List<string> PengZuTaboo { get; set; } = new();
    public List<string> AuspiciousStars { get; set; } = new();
    public List<string> InauspiciousStars { get; set; } = new();
    public string OverallFortune { get; set; } = "";

    // ---------- EN fields ----------
    public List<string> GoodEN { get; set; } = new();
    public List<string> BadEN { get; set; } = new();
    public string GoodDirectionEN { get; set; } = "";
    public string GodOfHappinessEN { get; set; } = "";
    public string GodOfWealthEN { get; set; } = "";
    public string GodOfBlessingEN { get; set; } = "";
    public string ClashZodiacEN { get; set; } = "";
    public List<string> PengZuTabooEN { get; set; } = new();
    public List<string> AuspiciousStarsEN { get; set; } = new();
    public List<string> InauspiciousStarsEN { get; set; } = new();
    public string OverallFortuneEnglish { get; set; } = "";
}
