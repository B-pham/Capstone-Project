//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.12
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


public class vx_req_account_set_presence_t : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal vx_req_account_set_presence_t(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(vx_req_account_set_presence_t obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~vx_req_account_set_presence_t() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          VivoxCoreInstancePINVOKE.delete_vx_req_account_set_presence_t(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

        public static implicit operator vx_req_base_t(vx_req_account_set_presence_t t) {
            return t.base_;
        }
        
  public vx_req_base_t base_ {
    set {
      VivoxCoreInstancePINVOKE.vx_req_account_set_presence_t_base__set(swigCPtr, vx_req_base_t.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = VivoxCoreInstancePINVOKE.vx_req_account_set_presence_t_base__get(swigCPtr);
      vx_req_base_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new vx_req_base_t(cPtr, false);
      return ret;
    } 
  }

  public string account_handle {
    set {
      VivoxCoreInstancePINVOKE.vx_req_account_set_presence_t_account_handle_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_req_account_set_presence_t_account_handle_get(swigCPtr);
      return ret;
    } 
  }

  public vx_buddy_presence_state presence {
    set {
      VivoxCoreInstancePINVOKE.vx_req_account_set_presence_t_presence_set(swigCPtr, (int)value);
    } 
    get {
      vx_buddy_presence_state ret = (vx_buddy_presence_state)VivoxCoreInstancePINVOKE.vx_req_account_set_presence_t_presence_get(swigCPtr);
      return ret;
    } 
  }

  public string custom_message {
    set {
      VivoxCoreInstancePINVOKE.vx_req_account_set_presence_t_custom_message_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_req_account_set_presence_t_custom_message_get(swigCPtr);
      return ret;
    } 
  }

  public string alias_username {
    set {
      VivoxCoreInstancePINVOKE.vx_req_account_set_presence_t_alias_username_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_req_account_set_presence_t_alias_username_get(swigCPtr);
      return ret;
    } 
  }

  public vx_req_account_set_presence_t() : this(VivoxCoreInstancePINVOKE.new_vx_req_account_set_presence_t(), true) {
  }

}
