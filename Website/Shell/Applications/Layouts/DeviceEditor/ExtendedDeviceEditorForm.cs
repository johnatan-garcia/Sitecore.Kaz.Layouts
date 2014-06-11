using Sitecore.Diagnostics;
using Sitecore.Layouts;
using Sitecore.Shell.Applications.Layouts.DeviceEditor;
using Sitecore.Web;
using Sitecore.Web.UI.Sheer;
using System.Collections;
using System.Linq;

namespace Sitecore.Kaz.Shell.Applications.Layouts.DeviceEditor {
    
    [UsedImplicitly]
    public class ExtendedDeviceEditorForm : DeviceEditorForm {

        [HandleMessage("device:replicatecontrol", true), UsedImplicitly]
        protected void ReplicateControl(ClientPipelineArgs args) {
            Assert.ArgumentNotNull(args, "args");
            if (this.SelectedIndex >= 0) {
                // The current layout definition. This holds information for all devices
                var layoutDefinition = GetLayoutDefinition();
                // THe current device
                var device = layoutDefinition.GetDevice(this.DeviceID);
                if (device.Renderings != null && device.Renderings.Count > this.SelectedIndex) {
                    // The selected rendering, that will be copied to all devices
                    var renderingToReplicate = device.Renderings[this.SelectedIndex] as RenderingDefinition;
                    // Other devices within the same layout definition
                    var otherDevices = layoutDefinition.Devices.Cast<DeviceDefinition>().Where(x => x.ID != this.DeviceID).ToList();
                    for (var i = 0; i < otherDevices.Count(); i++) {
                        var targetDevice = layoutDefinition.GetDevice(otherDevices[i].ID);
                        var existingRendering = targetDevice.Renderings.Cast<RenderingDefinition>().SingleOrDefault(x => x.ItemID == renderingToReplicate.ItemID);
                        // Remove the same rendering
                        if (existingRendering != null) {
                            targetDevice.Renderings.Remove(existingRendering);
                        }
                        // Add current rendering. It will inherint any multivariate test
                        targetDevice.AddRendering(renderingToReplicate);
                    }
                    SaveLayoutDefinition(layoutDefinition);
                }
            }
        }

        private static LayoutDefinition GetLayoutDefinition() {
            string sessionString = WebUtil.GetSessionString(GetSessionHandle());
            Assert.IsNotNull(sessionString, "layout definition");
            return LayoutDefinition.Parse(sessionString);
        }

        private static void SaveLayoutDefinition(LayoutDefinition definition) {
            Assert.ArgumentNotNull(definition, "layout");
            WebUtil.SetSessionValue(GetSessionHandle(), definition.ToXml());
        }

        private static string GetSessionHandle() {
            return Assert.ResultNotNull<string>("SC_DEVICEEDITOR");
        }

    }

}
