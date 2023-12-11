using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.EditorTools;

public class ReportConfigurationManager : MonoBehaviour
{
    [SerializeField] private bool useDefaultReportingConfiguration;
    public ReportableLogTypes selectedLogTypes = new ReportableLogTypes();
}

[System.Serializable]
public class ReportableLogTypes
{
    [field: SerializeField] public bool Error { get; set; } = true;
    [field: SerializeField] public bool Assert { get; set; }
    [field: SerializeField] public bool Warning { get; set; }
    [field: SerializeField] public bool Log { get; set; }
    [field: SerializeField] public bool Exception { get; set; } = true;
}
