using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CrashReportConfiguration : MonoBehaviour
{
    [Header("If a Log with the selected Target LogType value is handled, \nthe report to be sent will be prepared with the configuration\nappropriate for this selections.\n\n")]
    public List<ReportDetail> reportDetail;
}

[System.Serializable]
public class ReportDetail
{
    [field: SerializeField] public LogType TargetLogType { get; set; }
    [field: SerializeField] public bool PlayerID { get; set; }
    [field: SerializeField] public bool Message { get; set; }
    [field: SerializeField] public bool LogType { get; set; }
    [field: SerializeField] public bool StackTrace { get; set; }
    [field: SerializeField] public bool SceneIndex { get; set; }
    [field: SerializeField] public bool DateAndTime { get; set; }
    [field: SerializeField] public bool Platform { get; set; }
    [field: SerializeField] public bool DeviceModel { get; set; }
    [field: SerializeField] public bool OS { get; set; }
    [field: SerializeField] public bool OperatingSystemFamily { get; set; }
    [field: SerializeField] public bool DeviceName { get; set; }
    [field: SerializeField] public bool DeviceType { get; set; }
    [field: SerializeField] public bool GraphicsDeviceName { get; set; }
    [field: SerializeField] public bool GraphicsDeviceType { get; set; }
    [field: SerializeField] public bool GraphicsDeviceVersion { get; set; }
    [field: SerializeField] public bool GraphicsMemorySize { get; set; }
    [field: SerializeField] public bool ProcessorType { get; set; }
    [field: SerializeField] public bool SystemMemorySize { get; set; }
    [field: SerializeField] public bool ProcessorCount { get; set; }
    [field: SerializeField] public bool ProcessorFrequency { get; set; }
    [field: SerializeField] public bool SupportsGyroscope { get; set; }
    [field: SerializeField] public bool SupportsInstancing { get; set; }
    [field: SerializeField] public bool SupportsLocationService { get; set; }
    [field: SerializeField] public bool SupportsRayTracing { get; set; }
    [field: SerializeField] public bool SupportsVibration { get; set; }
}