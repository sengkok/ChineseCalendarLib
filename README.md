# 🧧 ChineseCalendar

[![License: GPL v3](https://img.shields.io/badge/license-GPLv3-blue.svg?style=flat-square)](https://www.gnu.org/licenses/gpl-3.0)
[![Build](https://img.shields.io/badge/build-passing-brightgreen.svg?style=flat-square)](#)
[![.NET](https://img.shields.io/badge/.NET-8.0-blue?style=flat-square)](https://dotnet.microsoft.com/)

---

## 🧩 Overview

**ChineseCalendar** is a bilingual Chinese lunar calendar and fortune library for **.NET 8**, developed by **skai**.

It provides accurate Chinese lunar–solar date conversion, zodiac (生肖), heavenly stems & earthly branches (干支),  
solar terms (节气), and BaZi (八字) fortune calculations — all available in both **Chinese** and **English**.

Ideal for use in cultural, educational, or astrology-related applications.

---

## 🌙 Features

- 🔢 **Lunar ↔ Gregorian date conversion** (农历与公历互转)
- 🐉 **Zodiac & GanZhi (干支)** calculation
- ☯️ **BaZi (八字)** chart generation and explanation
- 🗓️ **Solar Terms (二十四节气)** recognition
- 💫 **Daily, Monthly, and Yearly fortune** summaries with good/bad activities (宜/忌)
- 🌐 **Full bilingual output** (Chinese + English)
- ⚙️ **Compatible with .NET 8**, UTF-8 consoles, and multi-platform projects

---

## 🧠 Usage Example

```csharp
using ChineseCalendarLib;

// Get today's information
var today = ChineseCalendar.GetToday("Asia/Kuala_Lumpur");
Console.WriteLine($"Lunar: {today.LunarTextEN} | Zodiac: {today.ZodiacEN}");

// Get daily fortune for a specific date
var fortune = ChineseCalendar.GetDailyFortune(new DateTime(1990, 5, 17));
Console.WriteLine($"Date: {fortune.Date:yyyy-MM-dd}");
Console.WriteLine($"Zodiac: {fortune.ZodiacEN}");
Console.WriteLine($"Luck Index: {fortune.LuckIndex}/5");
Console.WriteLine($"Overall Fortune: {fortune.OverallFortuneEnglish}");
