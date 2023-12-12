using System;
using UnityEngine;

using static Nesco.CrashReporter.DBCore.DBConfiguration;

namespace Nesco.CrashReporter.DBCore
{
    public class DBManager : MonoBehaviour
    {
        public static DBManager instance;

        [SerializeField] private DBConfiguration _testDB;
        [SerializeField] private DBConfiguration _mainDB;

        private string IDKey = "PlayerID";
        private string _playerID;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                instance = this;
            }
        }

        public bool CheckDB()
        {
            if (_testDB == null || _mainDB == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public DBConfig GetDB()
        {
#if UNITY_EDITOR

            return _testDB.GetData();
#endif

#if !UNITY_EDITOR
                return _mainDB.GetData();
#endif
        }

        #region _playerID getter/setter
        public void SetPlayerID<T>(T value)
        {
            try
            {
                this._playerID = value.ToString();
                PlayerPrefs.SetString(IDKey, value.ToString());
            }
            catch
            {
                throw new ArgumentException("Invalid 'value' format or type. Cannot convert to string.");
            }
        }

        public string GetPlayerID()
        {
            return this._playerID;
        }
        #endregion
    }
}
