//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.12
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


public class vx_voice_font_t : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal vx_voice_font_t(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(vx_voice_font_t obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~vx_voice_font_t() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          VivoxCoreInstancePINVOKE.delete_vx_voice_font_t(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public int id {
    set {
      VivoxCoreInstancePINVOKE.vx_voice_font_t_id_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_voice_font_t_id_get(swigCPtr);
      return ret;
    } 
  }

  public int parent_id {
    set {
      VivoxCoreInstancePINVOKE.vx_voice_font_t_parent_id_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_voice_font_t_parent_id_get(swigCPtr);
      return ret;
    } 
  }

  public vx_font_type type {
    set {
      VivoxCoreInstancePINVOKE.vx_voice_font_t_type_set(swigCPtr, (int)value);
    } 
    get {
      vx_font_type ret = (vx_font_type)VivoxCoreInstancePINVOKE.vx_voice_font_t_type_get(swigCPtr);
      return ret;
    } 
  }

  public string name {
    set {
      VivoxCoreInstancePINVOKE.vx_voice_font_t_name_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_voice_font_t_name_get(swigCPtr);
      return ret;
    } 
  }

  public string description {
    set {
      VivoxCoreInstancePINVOKE.vx_voice_font_t_description_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_voice_font_t_description_get(swigCPtr);
      return ret;
    } 
  }

  public string expiration_date {
    set {
      VivoxCoreInstancePINVOKE.vx_voice_font_t_expiration_date_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_voice_font_t_expiration_date_get(swigCPtr);
      return ret;
    } 
  }

  public int expired {
    set {
      VivoxCoreInstancePINVOKE.vx_voice_font_t_expired_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_voice_font_t_expired_get(swigCPtr);
      return ret;
    } 
  }

  public string font_delta {
    set {
      VivoxCoreInstancePINVOKE.vx_voice_font_t_font_delta_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_voice_font_t_font_delta_get(swigCPtr);
      return ret;
    } 
  }

  public string font_rules {
    set {
      VivoxCoreInstancePINVOKE.vx_voice_font_t_font_rules_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_voice_font_t_font_rules_get(swigCPtr);
      return ret;
    } 
  }

  public vx_font_status status {
    set {
      VivoxCoreInstancePINVOKE.vx_voice_font_t_status_set(swigCPtr, (int)value);
    } 
    get {
      vx_font_status ret = (vx_font_status)VivoxCoreInstancePINVOKE.vx_voice_font_t_status_get(swigCPtr);
      return ret;
    } 
  }

  public vx_voice_font_t() : this(VivoxCoreInstancePINVOKE.new_vx_voice_font_t(), true) {
  }

}
