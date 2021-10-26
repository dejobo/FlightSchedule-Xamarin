package mono.android.app;

public class ApplicationRegistration {

	public static void registerApplications ()
	{
				// Application and Instrumentation ACWs must be registered first.
		mono.android.Runtime.register ("FlightSchedule.UI.Droid.MainApplication, FlightSchedule.UI.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", crc64eaf2043f5f6acb9e.MainApplication.class, crc64eaf2043f5f6acb9e.MainApplication.__md_methods);
		mono.android.Runtime.register ("MvvmCross.Platforms.Android.Views.MvxAndroidApplication, MvvmCross, Version=8.0.1.0, Culture=neutral, PublicKeyToken=null", crc6466d8e86b1ec8bfa8.MvxAndroidApplication.class, crc6466d8e86b1ec8bfa8.MvxAndroidApplication.__md_methods);
		mono.android.Runtime.register ("MvvmCross.Platforms.Android.Views.MvxAndroidApplication`2, MvvmCross, Version=8.0.1.0, Culture=neutral, PublicKeyToken=null", crc6466d8e86b1ec8bfa8.MvxAndroidApplication_2.class, crc6466d8e86b1ec8bfa8.MvxAndroidApplication_2.__md_methods);
		
	}
}
