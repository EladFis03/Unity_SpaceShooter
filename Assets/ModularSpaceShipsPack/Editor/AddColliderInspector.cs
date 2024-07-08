using UnityEngine;
using System.Collections;
using UnityEditor;


namespace ModularSpaceshipPack
{
    [CustomEditor(typeof(AddColliders))]
    public class AddColliderInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            AddColliders myScript = (AddColliders)target;
            if (GUILayout.Button("Add Colliders"))
            {
                myScript.Add();
            }
            if (GUILayout.Button("Remove Colliders"))
            {
                myScript.Remove();
            }
        }
    }
}