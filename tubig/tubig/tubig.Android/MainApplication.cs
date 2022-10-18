#if DEBUG
using Android.App;
using Android.Runtime;
using Plugin.CurrentActivity;
using System;
using tubig.Constants;

[Application(Debuggable = true)]
#else
	[Application(Debuggable = false)]
#endif
//[MetaData("com.google.android.maps.v2.API_KEY",
//			  Value = GoogleMap_APIkey.GoogleMapKey)]

public class MainApplication : Application
{
	public MainApplication(IntPtr handle, JniHandleOwnership transer)
	  : base(handle, transer)
	{
	}

	public override void OnCreate()
	{
		base.OnCreate();
		CrossCurrentActivity.Current.Init(this);
	}
}