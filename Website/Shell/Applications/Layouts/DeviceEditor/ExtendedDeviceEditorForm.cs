using Sitecore.Diagnostics;
using Sitecore.Layouts;
using Sitecore.Shell.Applications.Layouts.DeviceEditor;
using Sitecore.Web;
using Sitecore.Web.UI.Sheer;
using System.Collections;

namespace Sitecore.Kaz.Shell.Applications.Layouts.DeviceEditor {
    
    [UsedImplicitly]
    public class ExtendedDeviceEditorForm : DeviceEditorForm {

        [HandleMessage("device:replicatecontrol", true), UsedImplicitly]
        protected void ReplicateControl(ClientPipelineArgs args) {
            Assert.ArgumentNotNull(args, "args");
            if (this.SelectedIndex >= 0) {
                var layoutDefinition = GetLayoutDefinition();
                var device = layoutDefinition.GetDevice(this.DeviceID);
                if (device.Renderings != null && device.Renderings.Count > this.SelectedIndex) {
                    var renderingToReplicate = device.Renderings[this.SelectedIndex] as RenderingDefinition;
                    
                }
            }
        }

        private static LayoutDefinition GetLayoutDefinition() {
            string sessionString = WebUtil.GetSessionString(GetSessionHandle());
            Assert.IsNotNull(sessionString, "layout definition");
            return LayoutDefinition.Parse(sessionString);
        }

        private static string GetSessionHandle() {
            return Assert.ResultNotNull<string>("SC_DEVICEEDITOR");
        }

    }

}
