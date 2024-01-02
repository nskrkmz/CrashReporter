using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Nesco.CrashReporter.DBCore;
using Newtonsoft.Json;

using static Nesco.CrashReporter.DBCore.DBConfiguration;

namespace Nesco.CrashReporter
{
    [RequireComponent(typeof(DBManager))]
    public class CrashReportManager : MonoBehaviour
    {
        private DBConfig _dBConfig;
        [SerializeField] private bool _runTest;

        private void Awake()
        {
            Application.logMessageReceived += HandleLog;
            Application.SetStackTraceLogType(LogType.Log, StackTraceLogType.Full);

            CheckAndSetUpTheTest();
        }
        private void CheckAndSetUpTheTest()
        {
            if (_runTest)
            {
                if (!gameObject.GetComponent<Test>())
                    gameObject.AddComponent<Test>();
                else
                    gameObject.GetComponent<Test>().enabled = true;
            }
            else
            {
                if (gameObject.GetComponent<Test>())
                    gameObject.GetComponent<Test>().enabled = false;
            }
        }

        private void Start()
        {
            try
            {
                _dBConfig = DBManager.instance.GetDB();
            }
            catch (Exception ex)
            {
                Debug.LogWarning(ex, gameObject);
            }
        }

        public void SendCustomReport(string tableName, string reportId, string reportText) => StartCoroutine(SendCustomReportToServerRoutine(tableName, reportId, reportText));
        public void SendCustomReport(string tableName, string reportText) => StartCoroutine(SendCustomReportToServerRoutine(tableName, reportText));
        public void SendCustomReport(string reportText) => StartCoroutine(SendCustomReportToServerRoutine(reportText));
        public void SendCustomReport(string tableName, string reportId, string reportText, Action<UnityWebRequest.Result> callback) => StartCoroutine(SendCustomReportToServerRoutine(tableName, reportId, reportText, callback));
        public void SendCustomReport(string tableName, string reportText, Action<UnityWebRequest.Result> callback) => StartCoroutine(SendCustomReportToServerRoutine(tableName, reportText, callback));
        public void SendCustomReport(string reportText, Action<UnityWebRequest.Result> callback) => StartCoroutine(SendCustomReportToServerRoutine(reportText, callback));

        private void HandleLog(string logString, string stackTrace, LogType type)
        {
            if (type == LogType.Error || type == LogType.Exception)
            {
                if (DBManager.instance.CheckDB())
                {
                    GenerateAndSendCrashReport(logString, stackTrace, type);
                }
            }
        }

        private void GenerateAndSendCrashReport(string message, string stackTrace, LogType type)
        {
            string playerID = DBManager.instance.GetPlayerID();

            Model.CrashReport crashReport;
            if (playerID != null)
                crashReport = new Model.CrashReport(message, stackTrace, type, playerID);
            else
                crashReport = new Model.CrashReport(message, stackTrace, type);

            string reportText = JsonConvert.SerializeObject(crashReport);
            string reportID = GenerateReportId();

            StartCoroutine(SendCrashReportToServer(reportID, crashReport.LogType, reportText));
        }

        IEnumerator SendCrashReportToServer(string reportId, LogType type, string reportText)
        {
            var typeText = type.ToString();

            using (UnityWebRequest reportSetRequest = UnityWebRequest.Post(_dBConfig.RestURL + $"/hset/{typeText}/{reportId}/", $"{reportText}"))
            {
                reportSetRequest.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(reportText));
                reportSetRequest.SetRequestHeader(_dBConfig.AuthorizationHeaderName, _dBConfig.AuthorizationHeaderValue);
                reportSetRequest.SetRequestHeader("Content-Type", "application/json");

                yield return reportSetRequest.SendWebRequest();

                if (reportSetRequest.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(" reportSetRequest => " + reportSetRequest.error);
                }
            }
        }


        IEnumerator SendCustomReportToServerRoutine(string tableName, string reportId, string reportText)
        {

            using (UnityWebRequest reportSetRequest = UnityWebRequest.Post(_dBConfig.RestURL + $"/hset/{tableName}/{reportId}/", $"{reportText}"))
            {
                reportSetRequest.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(reportText));
                reportSetRequest.SetRequestHeader(_dBConfig.AuthorizationHeaderName, _dBConfig.AuthorizationHeaderValue);
                reportSetRequest.SetRequestHeader("Content-Type", "application/json");

                yield return reportSetRequest.SendWebRequest();

                if (reportSetRequest.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(" reportSetRequest => " + reportSetRequest.error);
                }
            }
        }
        IEnumerator SendCustomReportToServerRoutine(string tableName, string reportText)
        {
            string reportId = GenerateReportId();
            using (UnityWebRequest reportSetRequest = UnityWebRequest.Post(_dBConfig.RestURL + $"/hset/{tableName}/{reportId}/", $"{reportText}"))
            {
                reportSetRequest.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(reportText));
                reportSetRequest.SetRequestHeader(_dBConfig.AuthorizationHeaderName, _dBConfig.AuthorizationHeaderValue);
                reportSetRequest.SetRequestHeader("Content-Type", "application/json");

                yield return reportSetRequest.SendWebRequest();

                if (reportSetRequest.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(" reportSetRequest => " + reportSetRequest.error);
                }
            }
        }
        IEnumerator SendCustomReportToServerRoutine(string reportText)
        {
            string reportId = GenerateReportId();
            string reportKey = "CustomReport";
            using (UnityWebRequest reportSetRequest = UnityWebRequest.Post(_dBConfig.RestURL + $"/hset/{reportKey}/{reportId}/", $"{reportText}"))
            {
                reportSetRequest.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(reportText));
                reportSetRequest.SetRequestHeader(_dBConfig.AuthorizationHeaderName, _dBConfig.AuthorizationHeaderValue);
                reportSetRequest.SetRequestHeader("Content-Type", "application/json");

                yield return reportSetRequest.SendWebRequest();

                if (reportSetRequest.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(" reportSetRequest => " + reportSetRequest.error);
                }
            }
        }
        IEnumerator SendCustomReportToServerRoutine(string tableName, string reportId, string reportText, Action<UnityWebRequest.Result> callback)
        {

            using (UnityWebRequest reportSetRequest = UnityWebRequest.Post(_dBConfig.RestURL + $"/hset/{tableName}/{reportId}/", $"{reportText}"))
            {
                reportSetRequest.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(reportText));
                reportSetRequest.SetRequestHeader(_dBConfig.AuthorizationHeaderName, _dBConfig.AuthorizationHeaderValue);
                reportSetRequest.SetRequestHeader("Content-Type", "application/json");

                yield return reportSetRequest.SendWebRequest();

                callback(reportSetRequest.result);
            }
        }
        IEnumerator SendCustomReportToServerRoutine(string tableName, string reportText, Action<UnityWebRequest.Result> callback)
        {
            string reportId = GenerateReportId();
            using (UnityWebRequest reportSetRequest = UnityWebRequest.Post(_dBConfig.RestURL + $"/hset/{tableName}/{reportId}/", $"{reportText}"))
            {
                reportSetRequest.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(reportText));
                reportSetRequest.SetRequestHeader(_dBConfig.AuthorizationHeaderName, _dBConfig.AuthorizationHeaderValue);
                reportSetRequest.SetRequestHeader("Content-Type", "application/json");

                yield return reportSetRequest.SendWebRequest();

                callback(reportSetRequest.result);
            }
        }
        IEnumerator SendCustomReportToServerRoutine(string reportText, Action<UnityWebRequest.Result> callback)
        {
            string reportId = GenerateReportId();
            string reportKey = "CustomReport";
            using (UnityWebRequest reportSetRequest = UnityWebRequest.Post(_dBConfig.RestURL + $"/hset/{reportKey}/{reportId}/", $"{reportText}"))
            {
                reportSetRequest.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(reportText));
                reportSetRequest.SetRequestHeader(_dBConfig.AuthorizationHeaderName, _dBConfig.AuthorizationHeaderValue);
                reportSetRequest.SetRequestHeader("Content-Type", "application/json");

                yield return reportSetRequest.SendWebRequest();

                callback(reportSetRequest.result);
            }
        }

        private string GenerateReportId()
        {
            string characters = "ABCDEFGHIJKLMNOabcdefghijklmnopqrstuvwxyzPQRSTUVWXYZ0123456789_|@#$-";

            System.Random random = new System.Random();
            char[] idArray = new char[16];

            for (int i = 0; i < 16; i++)
            {
                idArray[i] = characters[random.Next(characters.Length)];
            }

            string reportId = new string(idArray);

            return reportId;
        }
    }
}

