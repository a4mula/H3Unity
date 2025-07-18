using UnityEditor;
using UnityEngine;
using H3Unity.Components;

namespace H3Unity.Editor
{
    [CustomEditor(typeof(H3Cell))]
    public class H3CellEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            var cell = (H3Cell)target;

            EditorGUILayout.LabelField("Hex Index", cell.Index.ToString("X"));
            EditorGUILayout.Space();

            EditorGUI.BeginChangeCheck();
            var lat = EditorGUILayout.DoubleField("Latitude", cell.Position.lat);
            var lng = EditorGUILayout.DoubleField("Longitude", cell.Position.lng);
            var res = EditorGUILayout.IntField("Resolution", H3.GetResolution(cell.Index));
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(cell, "Set Cell Index");
                cell.SetFromLatLng(lat, lng, res);
                EditorUtility.SetDirty(cell);
            }

            EditorGUILayout.Space();
            if (GUILayout.Button("Log Cell Info"))
            {
                Debug.Log($"[H3Cell] Index: {cell.Index}");
                Debug.Log($"[H3Cell] LatLng: {lat:F6}, {lng:F6}, Resolution: {res}");
            }
        }
    }
}
