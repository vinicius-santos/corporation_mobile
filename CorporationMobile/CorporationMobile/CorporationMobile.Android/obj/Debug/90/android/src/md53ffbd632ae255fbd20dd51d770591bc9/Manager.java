package md53ffbd632ae255fbd20dd51d770591bc9;


public class Manager
	extends android.os.Handler
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_handleMessage:(Landroid/os/Message;)V:GetHandleMessage_Landroid_os_Message_Handler\n" +
			"";
		mono.android.Runtime.register ("Plugin.Toasts.Manager, Toasts.Forms.Plugin.Droid", Manager.class, __md_methods);
	}


	public Manager ()
	{
		super ();
		if (getClass () == Manager.class)
			mono.android.TypeManager.Activate ("Plugin.Toasts.Manager, Toasts.Forms.Plugin.Droid", "", this, new java.lang.Object[] {  });
	}


	public Manager (android.os.Handler.Callback p0)
	{
		super (p0);
		if (getClass () == Manager.class)
			mono.android.TypeManager.Activate ("Plugin.Toasts.Manager, Toasts.Forms.Plugin.Droid", "Android.OS.Handler+ICallback, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public Manager (android.os.Looper p0)
	{
		super (p0);
		if (getClass () == Manager.class)
			mono.android.TypeManager.Activate ("Plugin.Toasts.Manager, Toasts.Forms.Plugin.Droid", "Android.OS.Looper, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public Manager (android.os.Looper p0, android.os.Handler.Callback p1)
	{
		super (p0, p1);
		if (getClass () == Manager.class)
			mono.android.TypeManager.Activate ("Plugin.Toasts.Manager, Toasts.Forms.Plugin.Droid", "Android.OS.Looper, Mono.Android:Android.OS.Handler+ICallback, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public void handleMessage (android.os.Message p0)
	{
		n_handleMessage (p0);
	}

	private native void n_handleMessage (android.os.Message p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
