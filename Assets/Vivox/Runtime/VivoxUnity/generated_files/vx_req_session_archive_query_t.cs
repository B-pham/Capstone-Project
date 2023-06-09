//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.12
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


public class vx_req_session_archive_query_t : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal vx_req_session_archive_query_t(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(vx_req_session_archive_query_t obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~vx_req_session_archive_query_t() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          VivoxCoreInstancePINVOKE.delete_vx_req_session_archive_query_t(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

        public static implicit operator vx_req_base_t(vx_req_session_archive_query_t t) {
            return t.base_;
        }
        
  public vx_req_base_t base_ {
    set {
      VivoxCoreInstancePINVOKE.vx_req_session_archive_query_t_base__set(swigCPtr, vx_req_base_t.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = VivoxCoreInstancePINVOKE.vx_req_session_archive_query_t_base__get(swigCPtr);
      vx_req_base_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new vx_req_base_t(cPtr, false);
      return ret;
    } 
  }

  public string session_handle {
    set {
      VivoxCoreInstancePINVOKE.vx_req_session_archive_query_t_session_handle_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_req_session_archive_query_t_session_handle_get(swigCPtr);
      return ret;
    } 
  }

  public string time_start {
    set {
      VivoxCoreInstancePINVOKE.vx_req_session_archive_query_t_time_start_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_req_session_archive_query_t_time_start_get(swigCPtr);
      return ret;
    } 
  }

  public string time_end {
    set {
      VivoxCoreInstancePINVOKE.vx_req_session_archive_query_t_time_end_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_req_session_archive_query_t_time_end_get(swigCPtr);
      return ret;
    } 
  }

  public string search_text {
    set {
      VivoxCoreInstancePINVOKE.vx_req_session_archive_query_t_search_text_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_req_session_archive_query_t_search_text_get(swigCPtr);
      return ret;
    } 
  }

  public string participant_uri {
    set {
      VivoxCoreInstancePINVOKE.vx_req_session_archive_query_t_participant_uri_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_req_session_archive_query_t_participant_uri_get(swigCPtr);
      return ret;
    } 
  }

  public uint max {
    set {
      VivoxCoreInstancePINVOKE.vx_req_session_archive_query_t_max_set(swigCPtr, value);
    } 
    get {
      uint ret = VivoxCoreInstancePINVOKE.vx_req_session_archive_query_t_max_get(swigCPtr);
      return ret;
    } 
  }

  public string before_id {
    set {
      VivoxCoreInstancePINVOKE.vx_req_session_archive_query_t_before_id_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_req_session_archive_query_t_before_id_get(swigCPtr);
      return ret;
    } 
  }

  public string after_id {
    set {
      VivoxCoreInstancePINVOKE.vx_req_session_archive_query_t_after_id_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_req_session_archive_query_t_after_id_get(swigCPtr);
      return ret;
    } 
  }

  public int first_message_index {
    set {
      VivoxCoreInstancePINVOKE.vx_req_session_archive_query_t_first_message_index_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_req_session_archive_query_t_first_message_index_get(swigCPtr);
      return ret;
    } 
  }

  public string application_stanza_namespace {
    set {
      VivoxCoreInstancePINVOKE.vx_req_session_archive_query_t_application_stanza_namespace_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_req_session_archive_query_t_application_stanza_namespace_get(swigCPtr);
      return ret;
    } 
  }

  public string application_stanza_body {
    set {
      VivoxCoreInstancePINVOKE.vx_req_session_archive_query_t_application_stanza_body_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_req_session_archive_query_t_application_stanza_body_get(swigCPtr);
      return ret;
    } 
  }

  public vx_req_session_archive_query_t() : this(VivoxCoreInstancePINVOKE.new_vx_req_session_archive_query_t(), true) {
  }

}
