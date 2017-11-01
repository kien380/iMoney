using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using SegmentedControl.FormsPlugin.iOS;

namespace XFFinanceManager.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            SegmentedControlRenderer.Init();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
