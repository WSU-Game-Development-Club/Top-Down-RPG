using System;
using System.Linq;
using UnityEngine;

namespace Udar.SceneManager
{
    [Serializable]
    public class SceneFieldComposite
    {
        [SerializeField] private SceneField[] _sceneFields;

        public string[] Names => _sceneFields.Select(s => s.Name).ToArray();


    }
}