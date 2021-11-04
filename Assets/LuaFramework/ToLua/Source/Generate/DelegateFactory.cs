﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using System.Collections.Generic;
using LuaInterface;

public static class DelegateFactory
{
	public delegate Delegate DelegateValue(LuaFunction func, LuaTable self, bool flag);
	public static Dictionary<Type, DelegateValue> dict = new Dictionary<Type, DelegateValue>();

	static DelegateFactory()
	{
		Register();
	}

	[NoToLuaAttribute]
	public static void Register()
	{
		dict.Clear();
		dict.Add(typeof(System.Action), System_Action);
		dict.Add(typeof(UnityEngine.Events.UnityAction), UnityEngine_Events_UnityAction);
		dict.Add(typeof(System.Predicate<int>), System_Predicate_int);
		dict.Add(typeof(System.Action<int>), System_Action_int);
		dict.Add(typeof(System.Comparison<int>), System_Comparison_int);
		dict.Add(typeof(UnityEngine.Camera.CameraCallback), UnityEngine_Camera_CameraCallback);
		dict.Add(typeof(Holoville.HOTween.Core.TweenDelegate.TweenCallback), Holoville_HOTween_Core_TweenDelegate_TweenCallback);
		dict.Add(typeof(Holoville.HOTween.Core.TweenDelegate.TweenCallbackWParms), Holoville_HOTween_Core_TweenDelegate_TweenCallbackWParms);
		dict.Add(typeof(UnityEngine.Application.AdvertisingIdentifierCallback), UnityEngine_Application_AdvertisingIdentifierCallback);
		dict.Add(typeof(UnityEngine.Application.LowMemoryCallback), UnityEngine_Application_LowMemoryCallback);
		dict.Add(typeof(UnityEngine.Application.LogCallback), UnityEngine_Application_LogCallback);
		dict.Add(typeof(System.Action<bool>), System_Action_bool);
		dict.Add(typeof(System.Action<string>), System_Action_string);
		dict.Add(typeof(System.Func<bool>), System_Func_bool);
		dict.Add(typeof(UnityEngine.AudioClip.PCMReaderCallback), UnityEngine_AudioClip_PCMReaderCallback);
		dict.Add(typeof(UnityEngine.AudioClip.PCMSetPositionCallback), UnityEngine_AudioClip_PCMSetPositionCallback);
		dict.Add(typeof(System.Action<UnityEngine.AsyncOperation>), System_Action_UnityEngine_AsyncOperation);
		dict.Add(typeof(UnityEngine.RectTransform.ReapplyDrivenProperties), UnityEngine_RectTransform_ReapplyDrivenProperties);
		dict.Add(typeof(UnityEngine.UI.InputField.OnValidateInput), UnityEngine_UI_InputField_OnValidateInput);
		dict.Add(typeof(MyEventHandler), MyEventHandler);
		dict.Add(typeof(System.Action<UnityEngine.GameObject>), System_Action_UnityEngine_GameObject);
	}

    [NoToLuaAttribute]
    public static Delegate CreateDelegate(Type t, LuaFunction func = null)
    {
        DelegateValue Create = null;

        if (!dict.TryGetValue(t, out Create))
        {
            throw new LuaException(string.Format("Delegate {0} not register", LuaMisc.GetTypeName(t)));            
        }

        if (func != null)
        {
            LuaState state = func.GetLuaState();
            LuaDelegate target = state.GetLuaDelegate(func);
            
            if (target != null)
            {
                return Delegate.CreateDelegate(t, target, target.method);
            }  
            else
            {
                Delegate d = Create(func, null, false);
                target = d.Target as LuaDelegate;
                state.AddLuaDelegate(target, func);
                return d;
            }       
        }

        return Create(func, null, false);        
    }

    [NoToLuaAttribute]
    public static Delegate CreateDelegate(Type t, LuaFunction func, LuaTable self)
    {
        DelegateValue Create = null;

        if (!dict.TryGetValue(t, out Create))
        {
            throw new LuaException(string.Format("Delegate {0} not register", LuaMisc.GetTypeName(t)));
        }

        if (func != null)
        {
            LuaState state = func.GetLuaState();
            LuaDelegate target = state.GetLuaDelegate(func, self);

            if (target != null)
            {
                return Delegate.CreateDelegate(t, target, target.method);
            }
            else
            {
                Delegate d = Create(func, self, true);
                target = d.Target as LuaDelegate;
                state.AddLuaDelegate(target, func, self);
                return d;
            }
        }

        return Create(func, self, true);
    }

    [NoToLuaAttribute]
    public static Delegate RemoveDelegate(Delegate obj, LuaFunction func)
    {
        LuaState state = func.GetLuaState();
        Delegate[] ds = obj.GetInvocationList();

        for (int i = 0; i < ds.Length; i++)
        {
            LuaDelegate ld = ds[i].Target as LuaDelegate;

            if (ld != null && ld.func == func)
            {
                obj = Delegate.Remove(obj, ds[i]);
                state.DelayDispose(ld.func);
                break;
            }
        }

        return obj;
    }

    [NoToLuaAttribute]
    public static Delegate RemoveDelegate(Delegate obj, Delegate dg)
    {
        LuaDelegate remove = dg.Target as LuaDelegate;

        if (remove == null)
        {
            obj = Delegate.Remove(obj, dg);
            return obj;
        }

        LuaState state = remove.func.GetLuaState();
        Delegate[] ds = obj.GetInvocationList();        

        for (int i = 0; i < ds.Length; i++)
        {
            LuaDelegate ld = ds[i].Target as LuaDelegate;

            if (ld != null && ld == remove)
            {
                obj = Delegate.Remove(obj, ds[i]);
                state.DelayDispose(ld.func);
                state.DelayDispose(ld.self);
                break;
            }
        }

        return obj;
    }

	class System_Action_Event : LuaDelegate
	{
		public System_Action_Event(LuaFunction func) : base(func) { }
		public System_Action_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public void Call()
		{
			func.Call();
		}

		public void CallWithSelf()
		{
			func.BeginPCall();
			func.Push(self);
			func.PCall();
			func.EndPCall();
		}
	}

	public static Delegate System_Action(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			System.Action fn = delegate() { };
			return fn;
		}

		if(!flag)
		{
			System_Action_Event target = new System_Action_Event(func);
			System.Action d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			System_Action_Event target = new System_Action_Event(func, self);
			System.Action d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	class UnityEngine_Events_UnityAction_Event : LuaDelegate
	{
		public UnityEngine_Events_UnityAction_Event(LuaFunction func) : base(func) { }
		public UnityEngine_Events_UnityAction_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public void Call()
		{
			func.Call();
		}

		public void CallWithSelf()
		{
			func.BeginPCall();
			func.Push(self);
			func.PCall();
			func.EndPCall();
		}
	}

	public static Delegate UnityEngine_Events_UnityAction(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			UnityEngine.Events.UnityAction fn = delegate() { };
			return fn;
		}

		if(!flag)
		{
			UnityEngine_Events_UnityAction_Event target = new UnityEngine_Events_UnityAction_Event(func);
			UnityEngine.Events.UnityAction d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			UnityEngine_Events_UnityAction_Event target = new UnityEngine_Events_UnityAction_Event(func, self);
			UnityEngine.Events.UnityAction d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	class System_Predicate_int_Event : LuaDelegate
	{
		public System_Predicate_int_Event(LuaFunction func) : base(func) { }
		public System_Predicate_int_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public bool Call(int param0)
		{
			func.BeginPCall();
			func.Push(param0);
			func.PCall();
			bool ret = func.CheckBoolean();
			func.EndPCall();
			return ret;
		}

		public bool CallWithSelf(int param0)
		{
			func.BeginPCall();
			func.Push(self);
			func.Push(param0);
			func.PCall();
			bool ret = func.CheckBoolean();
			func.EndPCall();
			return ret;
		}
	}

	public static Delegate System_Predicate_int(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			System.Predicate<int> fn = delegate(int param0) { return false; };
			return fn;
		}

		if(!flag)
		{
			System_Predicate_int_Event target = new System_Predicate_int_Event(func);
			System.Predicate<int> d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			System_Predicate_int_Event target = new System_Predicate_int_Event(func, self);
			System.Predicate<int> d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	class System_Action_int_Event : LuaDelegate
	{
		public System_Action_int_Event(LuaFunction func) : base(func) { }
		public System_Action_int_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public void Call(int param0)
		{
			func.BeginPCall();
			func.Push(param0);
			func.PCall();
			func.EndPCall();
		}

		public void CallWithSelf(int param0)
		{
			func.BeginPCall();
			func.Push(self);
			func.Push(param0);
			func.PCall();
			func.EndPCall();
		}
	}

	public static Delegate System_Action_int(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			System.Action<int> fn = delegate(int param0) { };
			return fn;
		}

		if(!flag)
		{
			System_Action_int_Event target = new System_Action_int_Event(func);
			System.Action<int> d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			System_Action_int_Event target = new System_Action_int_Event(func, self);
			System.Action<int> d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	class System_Comparison_int_Event : LuaDelegate
	{
		public System_Comparison_int_Event(LuaFunction func) : base(func) { }
		public System_Comparison_int_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public int Call(int param0, int param1)
		{
			func.BeginPCall();
			func.Push(param0);
			func.Push(param1);
			func.PCall();
			int ret = (int)func.CheckNumber();
			func.EndPCall();
			return ret;
		}

		public int CallWithSelf(int param0, int param1)
		{
			func.BeginPCall();
			func.Push(self);
			func.Push(param0);
			func.Push(param1);
			func.PCall();
			int ret = (int)func.CheckNumber();
			func.EndPCall();
			return ret;
		}
	}

	public static Delegate System_Comparison_int(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			System.Comparison<int> fn = delegate(int param0, int param1) { return 0; };
			return fn;
		}

		if(!flag)
		{
			System_Comparison_int_Event target = new System_Comparison_int_Event(func);
			System.Comparison<int> d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			System_Comparison_int_Event target = new System_Comparison_int_Event(func, self);
			System.Comparison<int> d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	class UnityEngine_Camera_CameraCallback_Event : LuaDelegate
	{
		public UnityEngine_Camera_CameraCallback_Event(LuaFunction func) : base(func) { }
		public UnityEngine_Camera_CameraCallback_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public void Call(UnityEngine.Camera param0)
		{
			func.BeginPCall();
			func.Push(param0);
			func.PCall();
			func.EndPCall();
		}

		public void CallWithSelf(UnityEngine.Camera param0)
		{
			func.BeginPCall();
			func.Push(self);
			func.Push(param0);
			func.PCall();
			func.EndPCall();
		}
	}

	public static Delegate UnityEngine_Camera_CameraCallback(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			UnityEngine.Camera.CameraCallback fn = delegate(UnityEngine.Camera param0) { };
			return fn;
		}

		if(!flag)
		{
			UnityEngine_Camera_CameraCallback_Event target = new UnityEngine_Camera_CameraCallback_Event(func);
			UnityEngine.Camera.CameraCallback d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			UnityEngine_Camera_CameraCallback_Event target = new UnityEngine_Camera_CameraCallback_Event(func, self);
			UnityEngine.Camera.CameraCallback d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	class Holoville_HOTween_Core_TweenDelegate_TweenCallback_Event : LuaDelegate
	{
		public Holoville_HOTween_Core_TweenDelegate_TweenCallback_Event(LuaFunction func) : base(func) { }
		public Holoville_HOTween_Core_TweenDelegate_TweenCallback_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public void Call()
		{
			func.Call();
		}

		public void CallWithSelf()
		{
			func.BeginPCall();
			func.Push(self);
			func.PCall();
			func.EndPCall();
		}
	}

	public static Delegate Holoville_HOTween_Core_TweenDelegate_TweenCallback(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			Holoville.HOTween.Core.TweenDelegate.TweenCallback fn = delegate() { };
			return fn;
		}

		if(!flag)
		{
			Holoville_HOTween_Core_TweenDelegate_TweenCallback_Event target = new Holoville_HOTween_Core_TweenDelegate_TweenCallback_Event(func);
			Holoville.HOTween.Core.TweenDelegate.TweenCallback d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			Holoville_HOTween_Core_TweenDelegate_TweenCallback_Event target = new Holoville_HOTween_Core_TweenDelegate_TweenCallback_Event(func, self);
			Holoville.HOTween.Core.TweenDelegate.TweenCallback d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	class Holoville_HOTween_Core_TweenDelegate_TweenCallbackWParms_Event : LuaDelegate
	{
		public Holoville_HOTween_Core_TweenDelegate_TweenCallbackWParms_Event(LuaFunction func) : base(func) { }
		public Holoville_HOTween_Core_TweenDelegate_TweenCallbackWParms_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public void Call(Holoville.HOTween.TweenEvent param0)
		{
			func.BeginPCall();
			func.PushObject(param0);
			func.PCall();
			func.EndPCall();
		}

		public void CallWithSelf(Holoville.HOTween.TweenEvent param0)
		{
			func.BeginPCall();
			func.Push(self);
			func.PushObject(param0);
			func.PCall();
			func.EndPCall();
		}
	}

	public static Delegate Holoville_HOTween_Core_TweenDelegate_TweenCallbackWParms(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			Holoville.HOTween.Core.TweenDelegate.TweenCallbackWParms fn = delegate(Holoville.HOTween.TweenEvent param0) { };
			return fn;
		}

		if(!flag)
		{
			Holoville_HOTween_Core_TweenDelegate_TweenCallbackWParms_Event target = new Holoville_HOTween_Core_TweenDelegate_TweenCallbackWParms_Event(func);
			Holoville.HOTween.Core.TweenDelegate.TweenCallbackWParms d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			Holoville_HOTween_Core_TweenDelegate_TweenCallbackWParms_Event target = new Holoville_HOTween_Core_TweenDelegate_TweenCallbackWParms_Event(func, self);
			Holoville.HOTween.Core.TweenDelegate.TweenCallbackWParms d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	class UnityEngine_Application_AdvertisingIdentifierCallback_Event : LuaDelegate
	{
		public UnityEngine_Application_AdvertisingIdentifierCallback_Event(LuaFunction func) : base(func) { }
		public UnityEngine_Application_AdvertisingIdentifierCallback_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public void Call(string param0, bool param1, string param2)
		{
			func.BeginPCall();
			func.Push(param0);
			func.Push(param1);
			func.Push(param2);
			func.PCall();
			func.EndPCall();
		}

		public void CallWithSelf(string param0, bool param1, string param2)
		{
			func.BeginPCall();
			func.Push(self);
			func.Push(param0);
			func.Push(param1);
			func.Push(param2);
			func.PCall();
			func.EndPCall();
		}
	}

	public static Delegate UnityEngine_Application_AdvertisingIdentifierCallback(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			UnityEngine.Application.AdvertisingIdentifierCallback fn = delegate(string param0, bool param1, string param2) { };
			return fn;
		}

		if(!flag)
		{
			UnityEngine_Application_AdvertisingIdentifierCallback_Event target = new UnityEngine_Application_AdvertisingIdentifierCallback_Event(func);
			UnityEngine.Application.AdvertisingIdentifierCallback d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			UnityEngine_Application_AdvertisingIdentifierCallback_Event target = new UnityEngine_Application_AdvertisingIdentifierCallback_Event(func, self);
			UnityEngine.Application.AdvertisingIdentifierCallback d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	class UnityEngine_Application_LowMemoryCallback_Event : LuaDelegate
	{
		public UnityEngine_Application_LowMemoryCallback_Event(LuaFunction func) : base(func) { }
		public UnityEngine_Application_LowMemoryCallback_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public void Call()
		{
			func.Call();
		}

		public void CallWithSelf()
		{
			func.BeginPCall();
			func.Push(self);
			func.PCall();
			func.EndPCall();
		}
	}

	public static Delegate UnityEngine_Application_LowMemoryCallback(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			UnityEngine.Application.LowMemoryCallback fn = delegate() { };
			return fn;
		}

		if(!flag)
		{
			UnityEngine_Application_LowMemoryCallback_Event target = new UnityEngine_Application_LowMemoryCallback_Event(func);
			UnityEngine.Application.LowMemoryCallback d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			UnityEngine_Application_LowMemoryCallback_Event target = new UnityEngine_Application_LowMemoryCallback_Event(func, self);
			UnityEngine.Application.LowMemoryCallback d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	class UnityEngine_Application_LogCallback_Event : LuaDelegate
	{
		public UnityEngine_Application_LogCallback_Event(LuaFunction func) : base(func) { }
		public UnityEngine_Application_LogCallback_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public void Call(string param0, string param1, UnityEngine.LogType param2)
		{
			func.BeginPCall();
			func.Push(param0);
			func.Push(param1);
			func.Push(param2);
			func.PCall();
			func.EndPCall();
		}

		public void CallWithSelf(string param0, string param1, UnityEngine.LogType param2)
		{
			func.BeginPCall();
			func.Push(self);
			func.Push(param0);
			func.Push(param1);
			func.Push(param2);
			func.PCall();
			func.EndPCall();
		}
	}

	public static Delegate UnityEngine_Application_LogCallback(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			UnityEngine.Application.LogCallback fn = delegate(string param0, string param1, UnityEngine.LogType param2) { };
			return fn;
		}

		if(!flag)
		{
			UnityEngine_Application_LogCallback_Event target = new UnityEngine_Application_LogCallback_Event(func);
			UnityEngine.Application.LogCallback d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			UnityEngine_Application_LogCallback_Event target = new UnityEngine_Application_LogCallback_Event(func, self);
			UnityEngine.Application.LogCallback d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	class System_Action_bool_Event : LuaDelegate
	{
		public System_Action_bool_Event(LuaFunction func) : base(func) { }
		public System_Action_bool_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public void Call(bool param0)
		{
			func.BeginPCall();
			func.Push(param0);
			func.PCall();
			func.EndPCall();
		}

		public void CallWithSelf(bool param0)
		{
			func.BeginPCall();
			func.Push(self);
			func.Push(param0);
			func.PCall();
			func.EndPCall();
		}
	}

	public static Delegate System_Action_bool(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			System.Action<bool> fn = delegate(bool param0) { };
			return fn;
		}

		if(!flag)
		{
			System_Action_bool_Event target = new System_Action_bool_Event(func);
			System.Action<bool> d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			System_Action_bool_Event target = new System_Action_bool_Event(func, self);
			System.Action<bool> d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	class System_Action_string_Event : LuaDelegate
	{
		public System_Action_string_Event(LuaFunction func) : base(func) { }
		public System_Action_string_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public void Call(string param0)
		{
			func.BeginPCall();
			func.Push(param0);
			func.PCall();
			func.EndPCall();
		}

		public void CallWithSelf(string param0)
		{
			func.BeginPCall();
			func.Push(self);
			func.Push(param0);
			func.PCall();
			func.EndPCall();
		}
	}

	public static Delegate System_Action_string(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			System.Action<string> fn = delegate(string param0) { };
			return fn;
		}

		if(!flag)
		{
			System_Action_string_Event target = new System_Action_string_Event(func);
			System.Action<string> d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			System_Action_string_Event target = new System_Action_string_Event(func, self);
			System.Action<string> d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	class System_Func_bool_Event : LuaDelegate
	{
		public System_Func_bool_Event(LuaFunction func) : base(func) { }
		public System_Func_bool_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public bool Call()
		{
			func.BeginPCall();
			func.PCall();
			bool ret = func.CheckBoolean();
			func.EndPCall();
			return ret;
		}

		public bool CallWithSelf()
		{
			func.BeginPCall();
			func.Push(self);
			func.PCall();
			bool ret = func.CheckBoolean();
			func.EndPCall();
			return ret;
		}
	}

	public static Delegate System_Func_bool(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			System.Func<bool> fn = delegate() { return false; };
			return fn;
		}

		if(!flag)
		{
			System_Func_bool_Event target = new System_Func_bool_Event(func);
			System.Func<bool> d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			System_Func_bool_Event target = new System_Func_bool_Event(func, self);
			System.Func<bool> d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	class UnityEngine_AudioClip_PCMReaderCallback_Event : LuaDelegate
	{
		public UnityEngine_AudioClip_PCMReaderCallback_Event(LuaFunction func) : base(func) { }
		public UnityEngine_AudioClip_PCMReaderCallback_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public void Call(float[] param0)
		{
			func.BeginPCall();
			func.Push(param0);
			func.PCall();
			func.EndPCall();
		}

		public void CallWithSelf(float[] param0)
		{
			func.BeginPCall();
			func.Push(self);
			func.Push(param0);
			func.PCall();
			func.EndPCall();
		}
	}

	public static Delegate UnityEngine_AudioClip_PCMReaderCallback(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			UnityEngine.AudioClip.PCMReaderCallback fn = delegate(float[] param0) { };
			return fn;
		}

		if(!flag)
		{
			UnityEngine_AudioClip_PCMReaderCallback_Event target = new UnityEngine_AudioClip_PCMReaderCallback_Event(func);
			UnityEngine.AudioClip.PCMReaderCallback d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			UnityEngine_AudioClip_PCMReaderCallback_Event target = new UnityEngine_AudioClip_PCMReaderCallback_Event(func, self);
			UnityEngine.AudioClip.PCMReaderCallback d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	class UnityEngine_AudioClip_PCMSetPositionCallback_Event : LuaDelegate
	{
		public UnityEngine_AudioClip_PCMSetPositionCallback_Event(LuaFunction func) : base(func) { }
		public UnityEngine_AudioClip_PCMSetPositionCallback_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public void Call(int param0)
		{
			func.BeginPCall();
			func.Push(param0);
			func.PCall();
			func.EndPCall();
		}

		public void CallWithSelf(int param0)
		{
			func.BeginPCall();
			func.Push(self);
			func.Push(param0);
			func.PCall();
			func.EndPCall();
		}
	}

	public static Delegate UnityEngine_AudioClip_PCMSetPositionCallback(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			UnityEngine.AudioClip.PCMSetPositionCallback fn = delegate(int param0) { };
			return fn;
		}

		if(!flag)
		{
			UnityEngine_AudioClip_PCMSetPositionCallback_Event target = new UnityEngine_AudioClip_PCMSetPositionCallback_Event(func);
			UnityEngine.AudioClip.PCMSetPositionCallback d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			UnityEngine_AudioClip_PCMSetPositionCallback_Event target = new UnityEngine_AudioClip_PCMSetPositionCallback_Event(func, self);
			UnityEngine.AudioClip.PCMSetPositionCallback d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	class System_Action_UnityEngine_AsyncOperation_Event : LuaDelegate
	{
		public System_Action_UnityEngine_AsyncOperation_Event(LuaFunction func) : base(func) { }
		public System_Action_UnityEngine_AsyncOperation_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public void Call(UnityEngine.AsyncOperation param0)
		{
			func.BeginPCall();
			func.PushObject(param0);
			func.PCall();
			func.EndPCall();
		}

		public void CallWithSelf(UnityEngine.AsyncOperation param0)
		{
			func.BeginPCall();
			func.Push(self);
			func.PushObject(param0);
			func.PCall();
			func.EndPCall();
		}
	}

	public static Delegate System_Action_UnityEngine_AsyncOperation(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			System.Action<UnityEngine.AsyncOperation> fn = delegate(UnityEngine.AsyncOperation param0) { };
			return fn;
		}

		if(!flag)
		{
			System_Action_UnityEngine_AsyncOperation_Event target = new System_Action_UnityEngine_AsyncOperation_Event(func);
			System.Action<UnityEngine.AsyncOperation> d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			System_Action_UnityEngine_AsyncOperation_Event target = new System_Action_UnityEngine_AsyncOperation_Event(func, self);
			System.Action<UnityEngine.AsyncOperation> d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	class UnityEngine_RectTransform_ReapplyDrivenProperties_Event : LuaDelegate
	{
		public UnityEngine_RectTransform_ReapplyDrivenProperties_Event(LuaFunction func) : base(func) { }
		public UnityEngine_RectTransform_ReapplyDrivenProperties_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public void Call(UnityEngine.RectTransform param0)
		{
			func.BeginPCall();
			func.Push(param0);
			func.PCall();
			func.EndPCall();
		}

		public void CallWithSelf(UnityEngine.RectTransform param0)
		{
			func.BeginPCall();
			func.Push(self);
			func.Push(param0);
			func.PCall();
			func.EndPCall();
		}
	}

	public static Delegate UnityEngine_RectTransform_ReapplyDrivenProperties(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			UnityEngine.RectTransform.ReapplyDrivenProperties fn = delegate(UnityEngine.RectTransform param0) { };
			return fn;
		}

		if(!flag)
		{
			UnityEngine_RectTransform_ReapplyDrivenProperties_Event target = new UnityEngine_RectTransform_ReapplyDrivenProperties_Event(func);
			UnityEngine.RectTransform.ReapplyDrivenProperties d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			UnityEngine_RectTransform_ReapplyDrivenProperties_Event target = new UnityEngine_RectTransform_ReapplyDrivenProperties_Event(func, self);
			UnityEngine.RectTransform.ReapplyDrivenProperties d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	class UnityEngine_UI_InputField_OnValidateInput_Event : LuaDelegate
	{
		public UnityEngine_UI_InputField_OnValidateInput_Event(LuaFunction func) : base(func) { }
		public UnityEngine_UI_InputField_OnValidateInput_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public char Call(string param0, int param1, char param2)
		{
			func.BeginPCall();
			func.Push(param0);
			func.Push(param1);
			func.Push(param2);
			func.PCall();
			char ret = (char)func.CheckNumber();
			func.EndPCall();
			return ret;
		}

		public char CallWithSelf(string param0, int param1, char param2)
		{
			func.BeginPCall();
			func.Push(self);
			func.Push(param0);
			func.Push(param1);
			func.Push(param2);
			func.PCall();
			char ret = (char)func.CheckNumber();
			func.EndPCall();
			return ret;
		}
	}

	public static Delegate UnityEngine_UI_InputField_OnValidateInput(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			UnityEngine.UI.InputField.OnValidateInput fn = delegate(string param0, int param1, char param2) { return '\0'; };
			return fn;
		}

		if(!flag)
		{
			UnityEngine_UI_InputField_OnValidateInput_Event target = new UnityEngine_UI_InputField_OnValidateInput_Event(func);
			UnityEngine.UI.InputField.OnValidateInput d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			UnityEngine_UI_InputField_OnValidateInput_Event target = new UnityEngine_UI_InputField_OnValidateInput_Event(func, self);
			UnityEngine.UI.InputField.OnValidateInput d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	class MyEventHandler_Event : LuaDelegate
	{
		public MyEventHandler_Event(LuaFunction func) : base(func) { }
		public MyEventHandler_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public object Call(object[] param0)
		{
			func.BeginPCall();

			if(param0 != null)
			{
				for (int i = 0; i < param0.Length; i++)
				{
					func.Push(param0[i]);
				}

			}

			func.PCall();
			object ret = func.CheckVariant();
			func.EndPCall();
			return ret;
		}

		public object CallWithSelf(object[] param0)
		{
			func.BeginPCall();
			func.Push(self);

			if(param0 != null)
			{
				for (int i = 0; i < param0.Length; i++)
				{
					func.Push(param0[i]);
				}

			}

			func.PCall();
			object ret = func.CheckVariant();
			func.EndPCall();
			return ret;
		}
	}

	public static Delegate MyEventHandler(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			MyEventHandler fn = delegate(object[] param0) { return null; };
			return fn;
		}

		if(!flag)
		{
			MyEventHandler_Event target = new MyEventHandler_Event(func);
			MyEventHandler d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			MyEventHandler_Event target = new MyEventHandler_Event(func, self);
			MyEventHandler d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	class System_Action_UnityEngine_GameObject_Event : LuaDelegate
	{
		public System_Action_UnityEngine_GameObject_Event(LuaFunction func) : base(func) { }
		public System_Action_UnityEngine_GameObject_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public void Call(UnityEngine.GameObject param0)
		{
			func.BeginPCall();
			func.Push(param0);
			func.PCall();
			func.EndPCall();
		}

		public void CallWithSelf(UnityEngine.GameObject param0)
		{
			func.BeginPCall();
			func.Push(self);
			func.Push(param0);
			func.PCall();
			func.EndPCall();
		}
	}

	public static Delegate System_Action_UnityEngine_GameObject(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			System.Action<UnityEngine.GameObject> fn = delegate(UnityEngine.GameObject param0) { };
			return fn;
		}

		if(!flag)
		{
			System_Action_UnityEngine_GameObject_Event target = new System_Action_UnityEngine_GameObject_Event(func);
			System.Action<UnityEngine.GameObject> d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			System_Action_UnityEngine_GameObject_Event target = new System_Action_UnityEngine_GameObject_Event(func, self);
			System.Action<UnityEngine.GameObject> d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

}

