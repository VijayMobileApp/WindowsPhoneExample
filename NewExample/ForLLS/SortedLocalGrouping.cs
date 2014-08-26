using System.Globalization;
using System.Collections.Generic;

namespace NewExample.ForLLS
{
    public class SortedLocalGrouping
    {
        public const string GlobeGroupKey = "\uD83C\uDF10";
        const string defaultGrouping = "#abcdefghijklmnopqrstuvwxyz";
        Dictionary<string, string> groupings = new Dictionary<string, string>() {
                 {"sq-AL","#abcdefghijklmnopqrstuvwxyz.."},
                 {"ar-SA","ابتثجحخدذرزسشصضطظعغفقكلمنهوي…#abcdefghijklmnopqrstuvwxyz"},
                 {"Az-Latn-AZ","#abcdefghijklmnopqrstuvwxyz.."},
                 {"be-BY","абвгѓґдђеёєжзѕиїјкќлљмнњопрстћуўфхцччџшщъыьэюя…#abcdefghijklmnopqrstuvwxyz"},
                 {"bg-BG","абвгѓґдђеёєжзѕиїјкќлљмнњопрстћуўфхцччџшщъыьэюя…#abcdefghijklmnopqrstuvwxyz"},
                 {"ca-ES","#abcdefghijklmnopqrstuvwxyz.."},
                 {"zh-CN","#ABCDEFGHIJKLMNOPQRSTUVWXYZ.."},
                 {"zh-TW","ㄅㄆㄇㄈㄉㄊㄋㄌㄍㄎㄏㄐㄑㄒㄓㄔㄕㄖㄗㄘㄙㄚㄛㄜㄝㄞㄟㄠㄡㄢㄣㄤㄥㄦㄧㄨㄩ…#abcdefghijklmnopqrstuvwxyz"},
                 {"hr-HR","#abcdefghijklmnopqrstuvwxyz.."},
                 {"cs-CZ","#abcdefghijklmnopqrstuvwxyz.."},
                 {"da-DK","#abcdefghijklmnopqrstuvwxyzæøå.."},
                 {"nl-NL","#abcdefghijklmnopqrstuvwxyz.."},
                 {"en-US","#abcdefghijklmnopqrstuvwxyz.."},
                 {"en-GB","#abcdefghijklmnopqrstuvwxyz.."},
                 {"et-EE","#abcdefghijklmnopqrsšzžtuvwõäöũxyz.."},
                 {"fil-PH","#abcdefghijklmnopqrstuvwxyz.."},
                 {"fi-FI","#abcdefghijklmnopqrstuvwxyzåäö.."},
                 {"fr-FR","#abcdefghijklmnopqrstuvwxyz.."},
                 {"de-DE","#abcdefghijklmnopqrstuvwxyz.."},
                 {"el-GR","αβγδεζηθικλμνξοπρστυφχψω…#abcdefghijklmnopqrstuvwxyz"},
                 {"he-IL","אבגדהוזחטיכלמנסעפצקרשת…#abcdefghijklmnopqrstuvwxyz"},
                 {"hi-IN","अआइईउऊऋएऐऑओऔकखगघचछजझटठडढणतथदधनपफबभमयरलवशषसह…#abcdefghijklmnopqrstuvwxyz"},
                 {"hu-HU","#abcdefghijklmnopqrstuvwxyz.."},
                 {"id-ID","#abcdefghijklmnopqrstuvwxyz.."},
                 {"it-IT","#abcdefghijklmnopqrstuvwxyz.."},
                 {"ja-JP","アカサタナハマヤラワ…#abcdefghijklmnopqrstuvwxyz"},
                 {"kk-KZ","абвгѓґдђеёєжзѕиїјкќлљмнњопрстћуўфхцччџшщъыьэюя…#abcdefghijklmnopqrstuvwxyz"},
                 {"ko-KR","ㄱㄴㄷㄹㅁㅂㅅㅇㅈㅊㅋㅌㅍㅎ#abcdefghijklmnopqrstuvwxyz.."},
                 {"lv-LV","#abcdefghijklmnopqrstuvwxyz.."},
                 {"lt-LT","#abcdefghijklmnopqrstuvwxyz.."},
                 {"mk-MK","абвгѓґдђеёєжзѕиїјкќлљмнњопрстћуўфхцччџшщъыьэюя…#abcdefghijklmnopqrstuvwxyz"},
                 {"ms-MY","#abcdefghijklmnopqrstuvwxyz.."},
                 {"nb-NO","#abcdefghijklmnopqrstuvwxyzæøå.."},
                 {"fa-IR","ابپتثجچحخدذرزژسشصضطظعغفقکگلمنوهی…#abcdefghijklmnopqrstuvwxyz"},
                 {"pl-PL","#abcdefghijklmnopqrstuvwxyz.."},
                 {"pt-BR","#abcdefghijklmnopqrstuvwxyz.."},
                 {"pt-PT","#abcdefghijklmnopqrstuvwxyz.."},
                 {"ro-RO","#abcdefghijklmnopqrstuvwxyz.."},
                 {"ru-RU","абвгдеёжзийклмнопрстуфхцчшщъыьэюя…#abcdefghijklmnopqrstuvwxyz"},
                 {"sr-Latn-CS","#abcdefghijklmnopqrstuvwxyz.."},
                 {"sk-SK","#abcdefghijklmnopqrstuvwxyz.."},
                 {"es-ES","#abcdefghijklmnopqrstuvwxyz.."},
                 {"es-MX","#abcdefghijklmnopqrstuvwxyz.."},
                 {"sv-SE","#abcdefghijklmnopqrstuvwxyzåäö.."},
                 {"th-TH","กขฃคฅฆงจฉชซฌญฎฏฐฑฒณดตถทธนบปผฝพฟภมยรลวศษสหฬอฮ…#abcdefghijklmnopqrstuvwxyz"},
                 {"tr-TR","#abcçdefgğhıijklmnoöprsştuüvyz.."},
                 {"uk-UA","абвгѓґдђеёєжзѕиїјкќлљмнњопрстћуўфхцччџшщъыьэюя…#abcdefghijklmnopqrstuvwxyz"},
                 {"uz-Latn-UZ","#abcdefghijklmnopqrstuvwxyz.."},
                 {"vi-VN","#abcdefghijklmnopqrstuvwxyz.."}
                    };


        private string selectedGroupings;
        private CultureInfo ci;
        public SortedLocalGrouping(CultureInfo culture)
        {
            if (groupings.ContainsKey(culture.Name))
            {
                selectedGroupings = groupings[culture.Name];
            }
            else
            {
                selectedGroupings = defaultGrouping;
            }
            selectedGroupings = selectedGroupings.Replace("..", "*").Replace("…", "*");
            this.ci = culture;
        }

        internal int IndexOf(string match)
        {
            int number;
            if (int.TryParse(match, out number))
            {
                match = "#";
            }
            else
            {
                if (cultureSupportsPhonetics())
                {
                    // match = JapanesePhoneticSupport.GetGroupChar(match).ToString();
                }
            }
            var compareinfo = CultureInfo.CurrentCulture.CompareInfo;
            int index = ci.CompareInfo.IndexOf(this.selectedGroupings, match, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase);
            if (index == -1)
            {
                index = this.selectedGroupings.IndexOf("*");
            }
            return index;
        }

        private bool cultureSupportsPhonetics()
        {
            if (this.ci.Name == "ja-JP")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string Headings
        {
            get
            {
                return this.selectedGroupings;
            }
        }
    }
}
