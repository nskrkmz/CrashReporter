using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Nesco.CrashReporter.Editor
{
    public class CreateDatabaseManager : EditorWindow
    {
        [MenuItem("Tools/Nesco/Create CrashReporter")]
        public static void ShowWindow()
        {
            GameObject reporterObj = new GameObject();
            reporterObj.name = "CrashReportManager";
            reporterObj.AddComponent<CrashReportManager>();
        }
    }
}
