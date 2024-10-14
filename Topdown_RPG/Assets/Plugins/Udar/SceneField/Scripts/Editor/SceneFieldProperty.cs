
using UnityEditor;
using UnityEngine;

namespace Udar.SceneManager.Editor
{
    [CustomPropertyDrawer(typeof(SceneField))]
    public class SceneFieldProperty : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            var sceneFieldSP = property.FindPropertyRelative("_sceneOB");
            SceneAsset sceneAsset = null;

            if (sceneFieldSP.objectReferenceValue != null)
            {
                sceneAsset = sceneFieldSP.objectReferenceValue as SceneAsset;
            }

            EditorGUI.BeginChangeCheck();
            sceneAsset = EditorGUI.ObjectField(position, property.displayName, sceneAsset, typeof(SceneAsset), false) as SceneAsset;


            if (EditorGUI.EndChangeCheck())
            {
                sceneFieldSP.objectReferenceValue = sceneAsset;
                property.serializedObject.ApplyModifiedProperties();
            }

            EditorGUI.EndProperty();
        }
    }
}

