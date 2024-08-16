using jp.ootr.common;
using UnityEditor;

namespace jp.ootr.ImageDeviceControllerVisualizer.Editor
{
    [CustomEditor(typeof(ImageDeviceControllerVisualizer))]
    public class ImageDeviceControllerVisualizerEditor : UnityEditor.Editor
    {
        private bool _debug;

        private SerializedProperty _imageDeviceController;
        
        public virtual void OnEnable()
        {
            _imageDeviceController = serializedObject.FindProperty("imageDeviceController");
        }
        
        public override void OnInspectorGUI()
        {
            _debug = EditorGUILayout.ToggleLeft("Debug", _debug);
            if (_debug)
            {
                base.OnInspectorGUI();
                return;
            }
            
            EditorGUILayout.LabelField("ImageDeviceControllerVisualizer", EditorStyle.UiTitle);
            
            EditorGUILayout.Space();
            
            serializedObject.Update();
            EditorGUILayout.PropertyField(_imageDeviceController);
            serializedObject.ApplyModifiedProperties();
        }
    }
}