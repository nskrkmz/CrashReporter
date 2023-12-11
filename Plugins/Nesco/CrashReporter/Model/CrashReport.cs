using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

namespace Nesco.CrashReporter.Model
{
    public class CrashReport
    {
#nullable enable
        public string? PlayerID { get; set; }
#nullable restore
        public string Message { get; set; }
        public LogType LogType { get; set; }
        public string StackTrace { get; set; }
        public int SceneIndex { get; set; }
        public string DateAndTime { get; set; }
        public RuntimePlatform? Platform { get; set; }
        public string DeviceModel { get; set; }
        public string OS { get; set; }
        public OperatingSystemFamily? OperatingSystemFamily { get; set; }
        public string DeviceName { get; set; }
        public DeviceType? DeviceType { get; set; }
        public string GraphicsDeviceName { get; set; }
        public GraphicsDeviceType? GraphicsDeviceType { get; set; }
        public string GraphicsDeviceVersion { get; set; }
        public int GraphicsMemorySize { get; set; }
        public string ProcessorType { get; set; }
        public int SystemMemorySize { get; set; }
        public int ProcessorCount { get; set; }
        public int ProcessorFrequency { get; set; }
        public bool? SupportsGyroscope { get; set; }
        public bool? SupportsInstancing { get; set; }
        public bool? SupportsLocationService { get; set; }
        public bool? SupportsRayTracing { get; set; }
        public bool? SupportsVibration { get; set; }

        public CrashReport(string message, string stackTrace, LogType type)
        {
            InitializeDatas(message, stackTrace, type);
        }
        public CrashReport(string message, string stackTrace, LogType type, string playerId)
        {
            InitializeDatas(message, stackTrace, type, playerId);
        }

        private void InitializeDatas(string message, string stackTrace, LogType type)
        {
            this.Message = message;
            this.StackTrace = stackTrace;
            this.LogType = type;
            this.PlayerID = null;

            InitializeSceneIndex();
            InitializeDateTime();
            InitializePlatform();
            InitializeDeviceModel();
            InitializeOS();
            InitializeOperatingSystemFamily();
            InitializeDeviceName();
            InitializeDeviceType();
            InitializeGraphicsDeviceName();
            InitializeGraphicsDeviceType();
            InitializeGraphicsDeviceVersion();
            InitializeGraphicsMemorySize();
            InitializeProcessorType();
            InitializeSystemMemorySize();
            InitializeProcessorCount();
            InitializeProcessorFrequency();
            InitializeSupportsGyroscope();
            InitializeSupportsInstancing();
            InitializeSupportsLocationService();
            InitializeSupportsRayTracing();
            InitializeSupportsVibration();
        }

        private void InitializeDatas(string message, string stackTrace, LogType type, string playerID)
        {
            this.Message = message;
            this.StackTrace = stackTrace;
            this.LogType = type;
            this.PlayerID = playerID;

            InitializeSceneIndex();
            InitializeDateTime();
            InitializePlatform();
            InitializeDeviceModel();
            InitializeOS();
            InitializeOperatingSystemFamily();
            InitializeDeviceName();
            InitializeDeviceType();
            InitializeGraphicsDeviceName();
            InitializeGraphicsDeviceType();
            InitializeGraphicsDeviceVersion();
            InitializeGraphicsMemorySize();
            InitializeProcessorType();
            InitializeSystemMemorySize();
            InitializeProcessorCount();
            InitializeProcessorFrequency();
            InitializeSupportsGyroscope();
            InitializeSupportsInstancing();
            InitializeSupportsLocationService();
            InitializeSupportsRayTracing();
            InitializeSupportsVibration();
        }

        private void InitializeSceneIndex()
        {
            try
            {
                this.SceneIndex = SceneManager.GetActiveScene().buildIndex;
            }
            catch
            {
                this.SceneIndex = -1;
            }
        }
        private void InitializeDateTime()
        {
            try
            {
                this.DateAndTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch
            {
                this.DateAndTime = "0000-00-00 00:00:00";
            }
        }
        private void InitializePlatform()
        {
            try
            {
                this.Platform = Application.platform;
            }
            catch
            {
                this.Platform = null;
            }
        }
        private void InitializeDeviceModel()
        {
            try
            {
                this.DeviceModel = SystemInfo.deviceModel;
            }
            catch
            {
                this.DeviceModel = string.Empty;
            }
        }
        private void InitializeOS()
        {
            try
            {
                this.OS = SystemInfo.operatingSystem;
            }
            catch
            {
                this.OS = string.Empty;
            }
        }
        private void InitializeOperatingSystemFamily()
        {
            try
            {
                this.OperatingSystemFamily = SystemInfo.operatingSystemFamily;
            }
            catch
            {
                this.OperatingSystemFamily = null;
            }
        }
        private void InitializeDeviceName()
        {
            try
            {
                this.DeviceName = SystemInfo.deviceName;
            }
            catch
            {
                this.DeviceName = string.Empty;
            }
        }
        private void InitializeDeviceType()
        {
            try
            {
                this.DeviceType = SystemInfo.deviceType;
            }
            catch
            {
                this.DeviceType = null;
            }
        }
        private void InitializeGraphicsDeviceName()
        {
            try
            {
                this.GraphicsDeviceName = SystemInfo.graphicsDeviceName;
            }
            catch
            {
                this.GraphicsDeviceName = string.Empty;
            }
        }
        private void InitializeGraphicsDeviceType()
        {
            try
            {
                this.GraphicsDeviceType = SystemInfo.graphicsDeviceType;
            }
            catch
            {
                this.GraphicsDeviceType = null;
            }
        }
        private void InitializeGraphicsDeviceVersion()
        {
            try
            {
                this.GraphicsDeviceVersion = SystemInfo.graphicsDeviceVersion;
            }
            catch
            {
                this.GraphicsDeviceVersion = string.Empty;
            }
        }
        private void InitializeGraphicsMemorySize()
        {
            try
            {
                this.GraphicsMemorySize = SystemInfo.graphicsMemorySize;
            }
            catch
            {
                this.GraphicsMemorySize = -1;
            }
        }
        private void InitializeProcessorType()
        {
            try
            {
                this.ProcessorType = SystemInfo.processorType;
            }
            catch
            {
                this.ProcessorType = string.Empty;
            }
        }
        private void InitializeSystemMemorySize()
        {
            try
            {
                this.SystemMemorySize = SystemInfo.systemMemorySize;
            }
            catch
            {
                this.SystemMemorySize = -1;
            }
        }
        private void InitializeProcessorCount()
        {
            try
            {
                this.ProcessorCount = SystemInfo.processorCount;
            }
            catch
            {
                this.ProcessorCount = -1;
            }
        }
        private void InitializeProcessorFrequency()
        {
            try
            {
                this.ProcessorFrequency = SystemInfo.processorFrequency;
            }
            catch
            {
                this.ProcessorFrequency = -1;
            }
        }
        private void InitializeSupportsGyroscope()
        {
            try
            {
                this.SupportsGyroscope = SystemInfo.supportsGyroscope;
            }
            catch
            {
                this.SupportsGyroscope = null;
            }
        }
        private void InitializeSupportsInstancing()
        {
            try
            {
                this.SupportsInstancing = SystemInfo.supportsInstancing;
            }
            catch
            {
                this.SupportsInstancing = null;
            }
        }
        private void InitializeSupportsLocationService()
        {
            try
            {
                this.SupportsLocationService = SystemInfo.supportsLocationService;
            }
            catch
            {
                this.SupportsLocationService = null;
            }
        }
        private void InitializeSupportsRayTracing()
        {
            try
            {
                this.SupportsRayTracing = SystemInfo.supportsRayTracing;
            }
            catch
            {
                this.SupportsRayTracing = null;
            }
        }
        private void InitializeSupportsVibration()
        {
            try
            {
                this.SupportsVibration = SystemInfo.supportsVibration;
            }
            catch
            {
                this.SupportsVibration = null;
            }
        }
    }
}