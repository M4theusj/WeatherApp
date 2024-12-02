using Microsoft.Maui.Handlers;

#if ANDROID
using Android.Content.Res;
using AColor = Android.Graphics.Color;
#endif

namespace WeatherApp.Handlers
{
    public static class FormHandler
    {
        public static void RemoveBorders()
        {
            EntryHandler.Mapper.AppendToMapping("CustomBackground", (handler, view) =>
            {
#if ANDROID

                handler.PlatformView.SetBackgroundDrawable(null);
                handler.PlatformView.SetPadding(0, 0, 0, 0);

                handler.PlatformView.BackgroundTintList = ColorStateList.ValueOf(AColor.Rgb(48, 48, 48));
#elif IOS
                handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;

                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
            });
        }
    }
}
