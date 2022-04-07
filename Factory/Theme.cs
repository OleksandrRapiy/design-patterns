using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{
    public interface ITheme
    {
        string TextColor { get; }
        string BgrColor { get; }
    }

    public class LightTheme : ITheme
    {
        public string TextColor => "black";

        public string BgrColor => "white";
    }

    public class DarkTheme : ITheme
    {
        public string TextColor => "white";

        public string BgrColor => "black";
    }

    public class TrackingThemeFactory
    {
        private List<WeakReference<ITheme>> themes = new();

        public ITheme Create(bool isDark)
        {
            ITheme theme = isDark ? new DarkTheme() : new LightTheme();
            themes.Add(new WeakReference<ITheme>(theme));
            return theme;
        }

        public string Info
        {
            get
            {
                var sb = new StringBuilder();
                foreach (var reference in themes)
                {
                    if (reference.TryGetTarget(out var theme))
                    {
                        var isDark = theme is DarkTheme;
                        sb.Append(isDark ? "Dark " : "Light ").AppendLine("theme");
                    }
                }

                return sb.ToString();
            }
        }
    }



    // Example of advantages of Factory, it's ability to replace all created object
    public class ReplacebleThemeFactory
    {
        private List<WeakReference<Reference<ITheme>>> themes = new();

        public Reference<ITheme> Create(bool isDark)
        {
            var theme = new Reference<ITheme>(isDark ? new DarkTheme() : new LightTheme());
            themes.Add(new WeakReference<Reference<ITheme>>(theme));
            return theme;
        }

        private ITheme CreateImp(bool isDark)
        {
            return isDark ? new DarkTheme() : new LightTheme();
        }

        public void ReplaceTheme(bool isDark)
        {
            foreach (var weakReference in themes)
            {
                if (weakReference.TryGetTarget(out var reference))
                {
                    reference.Value = CreateImp(isDark);
                }
            }
        }
    }

    public class Reference<T> where T: class
    {
        public Reference(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
    }
}
