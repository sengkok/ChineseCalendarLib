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
    // ---------------- EN → CN Dictionaries ----------------

    internal static readonly Dictionary<string, string> ZodiacCN = new()
    {
        ["Rat"] = "鼠",
        ["Ox"] = "牛",
        ["Tiger"] = "虎",
        ["Rabbit"] = "兔",
        ["Dragon"] = "龙",
        ["Snake"] = "蛇",
        ["Horse"] = "马",
        ["Goat"] = "羊",
        ["Monkey"] = "猴",
        ["Rooster"] = "鸡",
        ["Dog"] = "狗",
        ["Pig"] = "猪"
    };

    internal static readonly Dictionary<string, string> DirectionCN = new()
    {
        ["North"] = "北",
        ["Northeast"] = "东北",
        ["East"] = "东",
        ["Southeast"] = "东南",
        ["South"] = "南",
        ["Southwest"] = "西南",
        ["West"] = "西",
        ["Northwest"] = "西北",
        ["North-Northwest"] = "北偏西",
        ["Center"] = "中宫"
    };

    internal static readonly Dictionary<string, string> ActionCN = new()
    {
        ["Travel"] = "出行",
        ["Prayer"] = "祈福",
        ["Worship"] = "祭拜",
        ["Haircut"] = "理发",
        ["Receive wealth"] = "纳财",
        ["Negotiation"] = "谈判",
        ["Sign contract"] = "签约",
        ["Lawsuit"] = "诉讼",
        ["Tree cutting"] = "砍伐",
        ["Move into house"] = "入宅",
        ["Move house"] = "搬家",
        ["Set up bed"] = "安床",
        ["Funeral"] = "安葬",
        ["Open storage"] = "开仓"
    };

    internal static readonly Dictionary<string, string> SolarTermCN = new()
    {
        ["Minor Cold"] = "小寒",
        ["Major Cold"] = "大寒",
        ["Beginning of Spring"] = "立春",
        ["Rain Water"] = "雨水",
        ["Awakening of Insects"] = "惊蛰",
        ["Spring Equinox"] = "春分",
        ["Pure Brightness (Qingming)"] = "清明",
        ["Grain Rain"] = "谷雨",
        ["Beginning of Summer"] = "立夏",
        ["Lesser Fullness of Grain"] = "小满",
        ["Grain in Ear"] = "芒种",
        ["Summer Solstice"] = "夏至",
        ["Minor Heat"] = "小暑",
        ["Major Heat"] = "大暑",
        ["Beginning of Autumn"] = "立秋",
        ["End of Heat"] = "处暑",
        ["White Dew"] = "白露",
        ["Autumn Equinox"] = "秋分",
        ["Cold Dew"] = "寒露",
        ["Frost Descent"] = "霜降",
        ["Beginning of Winter"] = "立冬",
        ["Minor Snow"] = "小雪",
        ["Major Snow"] = "大雪",
        ["Winter Solstice"] = "冬至"
    };

    // ---------------- EN → CN Translators ----------------

    public static string TranslateZodiacToCN(string en)
        => ZodiacCN.TryGetValue(en, out var zh) ? zh : en;

    public static string TranslateDirectionToCN(string en)
        => DirectionCN.TryGetValue(en, out var zh) ? zh : en;

    public static string TranslateActionToCN(string en)
        => ActionCN.TryGetValue(en, out var zh) ? zh : en;

    public static string TranslateSolarTermToCN(string en)
        => SolarTermCN.TryGetValue(en, out var zh) ? zh : en;

    // ---------------- Extra Helpers ----------------

    public static List<string> TranslateActionsToCN(IEnumerable<string> list)
        => list.Select(TranslateActionToCN).ToList();

    public static string TranslateCompositeDirToCN(string en)
    {
        if (string.IsNullOrWhiteSpace(en)) return en;
        var parts = en.Split('/', ',', '、', ' ');
        var translated = parts
            .Where(p => !string.IsNullOrWhiteSpace(p))
            .Select(p => TranslateDirectionToCN(p.Trim()))
            .ToList();
        return string.Join("、", translated);
    }
}
