//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.12
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


public class vx_device_t : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal vx_device_t(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(vx_device_t obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~vx_device_t() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          VivoxCoreInstancePINVOKE.delete_vx_device_t(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public string device {
    set {
      VivoxCoreInstancePINVOKE.vx_device_t_device_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_device_t_device_get(swigCPtr);
      return ret;
    } 
  }

  public string display_name {
    set {
      VivoxCoreInstancePINVOKE.vx_device_t_display_name_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_device_t_display_name_get(swigCPtr);
      return ret;
    } 
  }

  public vx_device_type_t device_type {
    set {
      VivoxCoreInstancePINVOKE.vx_device_t_device_type_set(swigCPtr, (int)value);
    } 
    get {
      vx_device_type_t ret = (vx_device_type_t)VivoxCoreInstancePINVOKE.vx_device_t_device_type_get(swigCPtr);
      return ret;
    } 
  }

  public vx_device_t() : this(VivoxCoreInstancePINVOKE.new_vx_device_t(), true) {
  }

}
