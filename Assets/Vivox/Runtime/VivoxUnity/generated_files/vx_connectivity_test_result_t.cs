//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.12
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


public class vx_connectivity_test_result_t : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal vx_connectivity_test_result_t(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(vx_connectivity_test_result_t obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~vx_connectivity_test_result_t() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          VivoxCoreInstancePINVOKE.delete_vx_connectivity_test_result_t(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public ND_TEST_TYPE test_type {
    set {
      VivoxCoreInstancePINVOKE.vx_connectivity_test_result_t_test_type_set(swigCPtr, (int)value);
    } 
    get {
      ND_TEST_TYPE ret = (ND_TEST_TYPE)VivoxCoreInstancePINVOKE.vx_connectivity_test_result_t_test_type_get(swigCPtr);
      return ret;
    } 
  }

  public ND_ERROR test_error_code {
    set {
      VivoxCoreInstancePINVOKE.vx_connectivity_test_result_t_test_error_code_set(swigCPtr, (int)value);
    } 
    get {
      ND_ERROR ret = (ND_ERROR)VivoxCoreInstancePINVOKE.vx_connectivity_test_result_t_test_error_code_get(swigCPtr);
      return ret;
    } 
  }

  public string test_additional_info {
    set {
      VivoxCoreInstancePINVOKE.vx_connectivity_test_result_t_test_additional_info_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_connectivity_test_result_t_test_additional_info_get(swigCPtr);
      return ret;
    } 
  }

  public vx_connectivity_test_result_t() : this(VivoxCoreInstancePINVOKE.new_vx_connectivity_test_result_t(), true) {
  }

}
