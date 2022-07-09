using System.Collections.Generic;
namespace InstaPrep.Data
{
    public class Measurements
    {
        private static List<string> measurements = new List<string>()
        {
            "cup", "cups",
            "can", "cans",
            "box", "boxes",
            "stick", "sticks",
            "sleeve", "sleeves",
            "tube", "tubes",
            "tbsp", "tbsps", "tbsp.", "tbsps.",
            "tablespoon", "tablespoons",
            "tsp", "tsps", "tsp.", "tsps.",
            "teaspoon", "teaspoons",
            "ounce", "oz.", "oz", "ounces",
            "gram", "grams",
            "lb", "lbs",
            "lb.", "lbs.",
            "pound", "pounds"
        };

        private static Dictionary<string, float> Amounts = new Dictionary<string, float>()
        {
            {"1", 1.0f },
            { "2", 2.0f }, {"3", 3.0f }, {"4", 4.0f}, { "5", 5.0f }, {"6", 6.0f }, {"7", 7.0f }, {"8", 8.0f }, {"9", 9.0f },
            { "one", 1.0f }, {"two", 2.0f }, {"three", 3.0f }, {"four", 4.0f }, {"five",5.0f },
            { "six", 6.0f }, {"seven", 7.0f }, {"eight", 8.0f }, {"nine", 9.0f }, {"ten", 10.0f },
            {"eleven", 11.0f }, {"twelve", 12.0f },
            { "dozen", 12.0f },
            { "quarter", 0.25f }, { "eighth", 0.16666f },
            { "half", 0.5f }, {"halfs", 0.5f },
            { "whole", 1.0f },
            { "7/8",  0.16666f*7 }, {"3/4", 0.75f }, {"5/8",  0.16666f * 5 }, {"1/2", 0.5f }, {"3/8",  0.16666f*3 }, {"1/4", 0.25f }, {"1/8",  0.16666f },
            { "½", 0.5f }, {"⅓", 0.33333f }, {"¼", 0.25f }, {"⅕", 0.2f}, {"⅙", 0.16666f}, {"⅛", .125f}, {"⅔", 0.66666f*2 }, { "⅖",0.4f },  {"¾", 0.75f },  {"⅗", 0.6f }, {"⅜", .375f },  {"⅘", 0.8f }, {"⅚", 0.16666f}, {"⅞", .875f }

        };

        private List<string> Methods = new List<string>()
        {
            "chopped", "diced", "cubed", "sliced", "minced",
            "boiled", "sauted", "fried", "grilled"
        };

        public static List<string> GetAmounts()
        {
            return Amounts.Keys.ToList();
        }

        public static List<string> GetMeasurements()
        {
            return measurements;
        }
    }
}
