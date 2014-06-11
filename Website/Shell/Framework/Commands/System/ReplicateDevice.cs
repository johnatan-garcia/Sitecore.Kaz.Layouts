using System;
using System.Linq;
using Sitecore.Shell.Framework.Commands;

namespace Sitecore.Kaz.Shell.Framework.Commands.System {

    [Serializable]
    public class ReplicateControl : Command {

        public override void Execute(CommandContext context) {
            Sitecore.Diagnostics.Assert.IsNotNull(context, "context");
        }

        public override CommandState QueryState(CommandContext context) {
            Sitecore.Diagnostics.Assert.IsNotNull(context, "context");
            return CommandState.Enabled;
        }
    }

}