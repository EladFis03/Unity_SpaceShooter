using UnityEngine;
using System.Collections;
using UnityEditor;


namespace ModularSpaceshipPack
{
    [CustomEditor(typeof(SlotFiller))]
    public class SlotFillerInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            SlotFiller myScript = (SlotFiller)target;
            if (GUILayout.Button("Clear Slots"))
            {
                myScript.ClearSlots();
            }
            if (GUILayout.Button("Apply Configuration"))
            {
                myScript.MountSlots();
            }
        }
    }
}