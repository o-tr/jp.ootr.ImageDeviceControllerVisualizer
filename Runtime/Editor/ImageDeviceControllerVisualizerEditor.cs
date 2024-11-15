#if UNITY_EDITOR
using jp.ootr.common.Editor;
using jp.ootr.ImageDeviceController.Editor;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace jp.ootr.ImageDeviceControllerVisualizer.Editor
{
    [CustomEditor(typeof(ImageDeviceControllerVisualizer))]
    public class ImageDeviceControllerVisualizerEditor : BaseEditor
    {
        protected override string GetScriptName()
        {
            return "Image Device Controller Visualizer";
        }
        
        protected override VisualElement GetLayout()
        {
            var root = new VisualElement();
            var error = new HelpBox("Image Device Controller の参照を設定してください\nImage Device Controller is not set", HelpBoxMessageType.Error);
            var isError = serializedObject.FindProperty("imageDeviceController").objectReferenceValue == null;
            var controller = new ObjectField("Image Device Controller")
            {
                objectType = typeof(ImageDeviceController.ImageDeviceController),
                bindingPath = "imageDeviceController"
            };
            root.Add(controller);
            
            if (isError)
            {
                InfoBlock.Add(error);
            }
            
            controller.RegisterValueChangedCallback(evt =>
            {
                if (evt.newValue == null && !InfoBlock.Contains(error))
                {
                    InfoBlock.Add(error);
                }
                else if (evt.newValue != null && InfoBlock.Contains(error))
                {
                    InfoBlock.Remove(error);
                }
            });

            return root;
        }
    }
}
#endif
