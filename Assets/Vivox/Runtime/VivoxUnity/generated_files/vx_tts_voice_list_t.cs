//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.12
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


public class vx_tts_voice_list_t : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal vx_tts_voice_list_t(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(vx_tts_voice_list_t obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~vx_tts_voice_list_t() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          VivoxCoreInstancePINVOKE.delete_vx_tts_voice_list_t(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

    
    public static implicit operator vx_tts_voice_t[](vx_tts_voice_list_t list) {
        var voices = new System.Collections.Generic.List<vx_tts_voice_t>();
        for( int i = 0; i < list.Length; ++i) {
            voices.Add(list.Get(i));
        }
        return voices.ToArray();
    }
    
    
  public vx_tts_voice_t Get(int i) {
    global::System.IntPtr cPtr = VivoxCoreInstancePINVOKE.vx_tts_voice_list_t_Get(swigCPtr, i);
    vx_tts_voice_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new vx_tts_voice_t(cPtr, false);
    return ret;
  }

  public vx_tts_voice_t Voices {
    set {
      VivoxCoreInstancePINVOKE.vx_tts_voice_list_t_Voices_set(swigCPtr, vx_tts_voice_t.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = VivoxCoreInstancePINVOKE.vx_tts_voice_list_t_Voices_get(swigCPtr);
      vx_tts_voice_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new vx_tts_voice_t(cPtr, false);
      return ret;
    } 
  }

  public int Length {
    set {
      VivoxCoreInstancePINVOKE.vx_tts_voice_list_t_Length_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_tts_voice_list_t_Length_get(swigCPtr);
      return ret;
    } 
  }

  public vx_tts_voice_list_t() : this(VivoxCoreInstancePINVOKE.new_vx_tts_voice_list_t(), true) {
  }

}
