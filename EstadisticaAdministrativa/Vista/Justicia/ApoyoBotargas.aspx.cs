using System;

namespace EstadisticaAdministrativa.Vista.Justicia
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*ContextMenu custommenu = new ContextMenu();
            custommenu.Items.Add("&Table");
            custommenu.Items.Add("&Color", new EventHandler(ContextMenu_Color));
            fpSpread1.ContextMenu = custommenu;
            */

        }

        private void ContextMenu_Color(object sender, System.EventArgs e)
        {
            //MessageBox.Show("You chose color.");
            //lalo
        }

        public void TreeView_SelectNode()
        {

        }
    }
}