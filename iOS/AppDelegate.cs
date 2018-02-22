using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace XControlsTest.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            XControls.Renderers.XEntryRenderer.Init();

            // Code for starting up the Xamarin Test Cloud Agent
#if DEBUG
			Xamarin.Calabash.Start();
            /*LoadApplication(UXDivers.Gorilla.iOS.Player.CreateApplication(
            new UXDivers.Gorilla.Config("Good Gorilla")
                .RegisterAssembly(typeof(XControls.Forms.XViewCell).Assembly)
            ));*/
            LoadApplication(new App());
#else
            LoadApplication(new App());
#endif


            return base.FinishedLaunching(app, options);
        }
    }
}
