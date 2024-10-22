using UnityEngine;

namespace Udar.SceneManager
{
    public class SceneFieldExample : MonoBehaviour
    {
        [SerializeField] private SceneField _sceneField;

        private void OnValidate()
        {
            if (Application.isPlaying)
            {
                Debug.Log("The scene name is: " + _sceneField.Name);
                Debug.Log("The scene index is: " + _sceneField.BuildIndex);
                Debug.Log("The scene path is: " + _sceneField.Path);
            }
        }

        public void PrintSceneField_Button(SceneFieldRef sceneFieldRef)
        {
            Debug.Log("-------------------------------------------");
            Debug.Log("Scene Field Name= " + sceneFieldRef.SceneField.Name);
        }
    }
}

