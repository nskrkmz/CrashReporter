using UnityEngine;
using UnityEngine.Diagnostics;
using Nesco.CrashReporter.DBCore;

namespace Nesco.CrashReporter
{
    /// <summary>
    /// An intentional Exception is thrown
    /// </summary>
    public class Test : MonoBehaviour
    {
        [HideInInspector] public GameObject obj;
        private void Start()
        {
            obj.GetComponent<Rigidbody>();
            //Utils.ForceCrash(ForcedCrashCategory.FatalError);
        }
    }
}