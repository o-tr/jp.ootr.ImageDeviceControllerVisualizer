using jp.ootr.common;
using TMPro;
using UnityEngine;

namespace jp.ootr.ImageDeviceControllerVisualizer
{
    public class LogicSerialize : BaseClass
    {
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private ImageDeviceController.ImageDeviceController imageDeviceController;

        public void Start()
        {
            SendCustomEventDelayedSeconds(nameof(OnDumpCache), 1);
        }

        public void OnDumpCache()
        {
            var data = imageDeviceController.DumpCache();
            text.text = data;
            SendCustomEventDelayedSeconds(nameof(OnDumpCache), 1);
        }
    }
}
