using System;
using System.Text;

namespace Appium.Flutter.Finder
{
    public abstract class FlutterBy
    {
        protected abstract string ToJson();

        public virtual string ToBase64()
        {
            var asJson = ToJson();

            byte[] asBytes = Encoding.UTF8.GetBytes(asJson);
            var asBase64InAppiumFlutterDriverNodeJs = Convert.ToBase64String(asBytes)
                .Replace("=", "")
                .Replace("+", "-")
                .Replace("/", "_");

            return asBase64InAppiumFlutterDriverNodeJs;
        }

        public static FlutterBy ValueKey(string valueKey)
        {
            return new FlutterByValueKey(valueKey);
        }

        public static FlutterBy ValueKey(int valueKey)
        {
            return new FlutterByValueKey(valueKey);
        }

        public static FlutterBy PageBack()
        {
            return new FlutterByPageBack();
        }

        public static FlutterBy Text(string text)
        {
            return new FlutterByText(text);
        }
    }
}
