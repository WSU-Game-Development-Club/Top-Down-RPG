using System.Linq;
using UnityEngine;

namespace Udar.SceneManager
{
    [CreateAssetMenu(fileName = "Scene Composite", menuName = "Udar/Scene Manager/Scene Composite", order = 0)]
    public class SceneCompositeSO : ScriptableObject
    {
        [SerializeField] private SceneField[] _sceneFields;

        public string[] Names => _sceneFields.Select(s => s.Name).ToArray();
    }
}