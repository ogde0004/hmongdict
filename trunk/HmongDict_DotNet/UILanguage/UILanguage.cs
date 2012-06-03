using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;

namespace UILanguage
{
    public class UILanguage
    {
        /*
        private void ApplyResource()
        {
            ApplyResource(this);
        }
        */
        public static string GetCurrentUILanguage(System.Threading.Thread CurrentThread)
        {

            CultureInfo ci = CurrentThread.CurrentUICulture;
            if (ci.Name == "")
            {
                return "Hmong";
            }
            else
            {
                return ci.Name;
            }
        }

        public static void ApplyResource(System.Windows.Forms.Form form)
        {
            ComponentResourceManager res = new ComponentResourceManager(form.GetType());
            res.ApplyResources(form, form.Name);
            ApplyResource(form.Controls, ref res);

            foreach (System.Windows.Forms.Form f in form.OwnedForms)
            {
                ApplyResource(f);
            }

            ContextMenuStrip cms = form.ContextMenuStrip;
            if (null != cms)
            {
                foreach (System.Windows.Forms.ToolStripMenuItem tsmi in cms.Items)
                {
                    res.ApplyResources(tsmi, tsmi.Name);
                    ApplyResource(tsmi, ref res);
                }
            }

            res.ApplyResources(form, "$this");
        }

        private static void ApplyResource(System.Windows.Forms.Control.ControlCollection controlCellection, ref ComponentResourceManager res)
        {
            foreach (System.Windows.Forms.Control ctl in controlCellection)
            {
                res.ApplyResources(ctl, ctl.Name);

                if (ctl.GetType() == typeof(System.Windows.Forms.MenuStrip))
                    ApplyResource((System.Windows.Forms.MenuStrip)ctl, ref res);

                else if (ctl.GetType() == typeof(System.Windows.Forms.StatusStrip))
                    ApplyResource((System.Windows.Forms.StatusStrip)ctl, ref res);

                else if (ctl.Controls.Count > 0)
                    ApplyResource(ctl.Controls, ref res);
            }
        }

        private static void ApplyResource(System.Windows.Forms.StatusStrip menuStrip, ref ComponentResourceManager res)
        {
            foreach (ToolStripItem toolStripItem in menuStrip.Items)
            {
                res.ApplyResources(toolStripItem, toolStripItem.Name);
            }
        }

        private static void ApplyResource(System.Windows.Forms.MenuStrip menuStrip, ref ComponentResourceManager res)
        {
            foreach (ToolStripMenuItem toolStripMenuItem in menuStrip.Items)
            {
                res.ApplyResources(toolStripMenuItem, toolStripMenuItem.Name);

                if (toolStripMenuItem.HasDropDownItems)
                    ApplyResource(toolStripMenuItem, ref res);
            }
        }

        private static void ApplyResource(ToolStripMenuItem toolStripMenuItem, ref ComponentResourceManager res)
        {
            foreach (ToolStripMenuItem toolStripMenuSubItem in toolStripMenuItem.DropDownItems)
            {
                res.ApplyResources(toolStripMenuSubItem, toolStripMenuSubItem.Name);

                if (toolStripMenuSubItem.HasDropDownItems)
                    ApplyResource(toolStripMenuSubItem, ref res);
            }
        }

        private static void ApplyResource(System.Windows.Forms.ContextMenuStrip contextMenuStrip, ref ComponentResourceManager res)
        {
            foreach (ToolStripMenuItem toolStripMenuItem in contextMenuStrip.Items)
            {
                res.ApplyResources(toolStripMenuItem, toolStripMenuItem.Name);

                if (toolStripMenuItem.HasDropDownItems)
                    ApplyResource(toolStripMenuItem, ref res);
            }
        }
    }
}
