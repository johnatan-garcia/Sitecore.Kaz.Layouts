using System;
using System.Linq;
using Sitecore.Shell.Framework.Commands;

namespace Sitecore.Kaz.Shell.Framework.Commands.System {

    [Serializable]
    public class ReplicateControl : Command {

        public override void Execute(CommandContext context) {

            Sitecore.Diagnostics.Assert.IsNotNull(context, "context");
            //Sitecore.Text.UrlString webSiteUrl = new Sitecore.Text.UrlString("/");
            //webSiteUrl.Add("sc_debug", "1");
            //webSiteUrl.Add("sc_prof", "1");
            //webSiteUrl.Add("sc_trace", "1");
            //webSiteUrl.Add("sc_ri", "1");
            //Sitecore.Data.Database db = Sitecore.Context.ContentDatabase;
            //Sitecore.Globalization.Language lang = Sitecore.Context.ContentLanguage;

            //// if the context for invoking the command specifies exactly one item
            //if (context.Items != null
            //  && context.Items.Length == 1
            //  && context.Items[0] != null) {
            //    // ensure the user has saved the selected item
            //    Sitecore.Context.ClientPage.ClientResponse.CheckModified(false);
            //    Sitecore.Data.Items.Item item = context.Items[0];
            //    db = item.Database;
            //    lang = item.Language;
            //    webSiteUrl.Add("sc_itemid", item.ID.ToString());
            //}

            //if (db != null) {
            //    webSiteUrl.Add("sc_database", db.Name);
            //}

            //if (lang != null) {
            //    webSiteUrl.Add("sc_lang", lang.ToString());
            //}

            //// without this, I didn't see the ribbon
            //Sitecore.Publishing.PreviewManager.RestoreUser();
            //Sitecore.Context.ClientPage.ClientResponse.Eval(
            //  "window.open('" + webSiteUrl + "', '_blank')");
        }

        public override CommandState QueryState(CommandContext context) {

            Sitecore.Diagnostics.Assert.IsNotNull(context, "context");

            return CommandState.Enabled;

            //// if the context does not indicate exactly one item
            //// then this must be the Debug command on the Sitecore menu
            //// in which case permissions alone control access
            //if (context.Items == null
            //  || context.Items.Length != 1
            //  || context.Items[0] == null) {
            //    return base.QueryState(context);
            //}

            //Sitecore.Data.Items.Item item = context.Items[0];

            //if (item.Paths.IsContentItem
            //  && (item.Database.Resources.Devices.GetAll().Where(compare => compare.ID != Sitecore.Syndication.FeedUtil.FeedDeviceId
            //  || !Sitecore.Syndication.FeedUtil.IsFeed(item)).Any(compare => item.Visualization.GetLayout(compare) != null))) {
            //    // the selected item has a URL
            //    return CommandState.Enabled;
            //}

            //// the selected item does not have a URL
            //return CommandState.Disabled;
        }
    }

}