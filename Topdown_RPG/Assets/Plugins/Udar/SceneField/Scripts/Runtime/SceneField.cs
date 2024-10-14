using UnityEngine;
using UnityEngine.SceneManagement;

namespace Udar.SceneManager
{
    [System.Serializable]
    public class SceneField : ISerializationCallbackReceiver
    {
        [SerializeField] private Object _sceneOB;


        [SerializeField] private string _name;
        [SerializeField] private string _path;
        [SerializeField] private int _buildIndex;
        public bool HasScene => !string.IsNullOrEmpty(_name);
        /// <summary>
        /// This returns a string equals to the Scene name
        /// </summary>
        public string Name => _name;
        /// <summary>
        /// This returns a int (the index of the scene in the build settings) if it won't find - it will return -1
        /// </summary>
        public int BuildIndex => _buildIndex;
        /// <summary>
        /// This returns a string represent the scene path in Unity project folders.
        /// If scene is not found in build settings -> it returns ""
        /// </summary>
        public string Path => _path;



        private int GetBuildIndexFromName(string name)
        {
            for (int i = 0; i < UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings; i++)
            {
                string buildIndexName = GetNameFromIndex(i);
                if (buildIndexName == name)
                    return i;
            }
            return -1;
        }
        private string GetNameFromIndex(int BuildIndex)
        {
            string path = SceneUtility.GetScenePathByBuildIndex(BuildIndex);
            int slash = path.LastIndexOf('/');
            string name = path.Substring(slash + 1);
            int dot = name.LastIndexOf('.');
            return name.Substring(0, dot);
        }

        public void OnAfterDeserialize()
        {
        }

        public void OnBeforeSerialize()
        {
            if (_sceneOB != null)
            {
                _name = _sceneOB.name;
                _buildIndex = GetBuildIndexFromName(_name);
                _path = SceneUtility.GetScenePathByBuildIndex(_buildIndex);
            }
            else
                _name = null;

        }
    }

}
