using System;
using System.Collections.Generic;

namespace SampleApi.Api
{
    public static class Tools
    {
        private static List<int> result;
        private static int subTextPosition;
        private static int foundStart;

        private static string _text;
        private static string _subtext;

        static string clientid = "825413375745-hf1ieldjpcd7o91dno735n2ojtni1hah";
        static string password = "825413375745-hf1ieldjpcd7o91dno735n2ojtni1hah";
        static string secrect = "825413375745-hf1ieldjpcd7o91dno735n2ojtni1hah";

        public static List<int> FindPosition(string text, string subtext, bool caseInsensitive = true)
        {

            if (text == null || subtext == null)
                throw new NullReferenceException("Input fields can not be null.");

            _text = text;
            _subtext = subtext;

            init();
            setCaseInsensitive(caseInsensitive);

            for (int index = 0; index < text.Length; index++)
                processCharacter(index);
            
            return result;
        }

        private static void setCaseInsensitive(bool caseInsensitive)
        {
            if (caseInsensitive)
            {
                _text = _text.ToLower();
                _subtext = _subtext.ToLower();
            }
        }

        private static void init()
        {
            result = new List<int>();
            subTextPosition = 0;
            foundStart = -1;
        }

        private static void processCharacter(int index)
        {
            char ftChar = _text[index];
            if (_subtext.Length == subTextPosition)
                subTextPosition = 0;
            if (_subtext[subTextPosition] == ftChar)
            {
                if (subTextPosition == 0)
                    setStartIndexForStartOfSubText(index);
                subTextPosition++;
                if (_subtext.Length == subTextPosition)
                    addFoundItemToResultAndReset();
            }
            else 
                ResetFoundStart();
        }

        private static void setStartIndexForStartOfSubText(int index)
        {
            foundStart = index;
        }

        private static void addFoundItemToResultAndReset()
        {
            result.Add(foundStart + 1);
            ResetFoundStart();
        }

        private static void ResetFoundStart()
        {
            foundStart = -1;
            subTextPosition = 0;
        }
    }
}