using UnityEngine;

namespace Nesco.CrashReporter.DBCore
{
    [CreateAssetMenu(fileName = "Nesco/DBConfigurations", menuName = "Nesco/CrashReporter/New DBConfiguration")]
    public class DBConfiguration : ScriptableObject
    {
        [SerializeField] private DBConfig _dbConfig;

        public DBConfig GetData()
        {
            ValidateNecessaryDatas();
            SetDefaultDatas();
            
            return _dbConfig;
        }

        /// <summary>
        /// Validates that essential data fields in the DBConfig structure are properly set.
        /// </summary>
        private void ValidateNecessaryDatas()
        {
            if (string.IsNullOrEmpty(_dbConfig.RestURL))
                throw new MissingReferenceException($"{this.name} => RestURL field is not set. Please assign a RestURL.");

            if (string.IsNullOrEmpty(_dbConfig.RestToken))
                throw new MissingReferenceException($"{this.name} => RestToken field is not set. Please assign a RestToken.");
        }

        private void SetDefaultDatas()
        {
            _dbConfig.DBName = this.name;
            _dbConfig.AuthorizationHeaderName = "Authorization";
            _dbConfig.AuthorizationHeaderValue = " Bearer " + _dbConfig.RestToken;
        }

        [System.Serializable]
        public struct DBConfig
        {
            [HideInInspector] public string DBName;

            //Used to configure the request's header when sending a request to Upstash/Redis.
            [HideInInspector] public string AuthorizationHeaderName;
            [HideInInspector] public string AuthorizationHeaderValue;

            public string RestURL;
            public string RestToken;
        }
    }
}
