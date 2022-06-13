<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Site.Master" AutoEventWireup="true" CodeBehind="ApoyoBotargas.aspx.cs" Inherits="EstadisticaAdministrativa.Vista.Justicia.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div style="width: 250px">
        <asp:TreeView ID="treeView" runat="server" Height="100%" >
            <Nodes>
                <asp:TreeNode Expanded="True" Text="ASP.NET MVC Team">
                        <asp:TreeNode Text="Smith"></asp:TreeNode>
                        <asp:TreeNode Text="Johnson"></asp:TreeNode>
                        <asp:TreeNode Text="Anderson"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="Windows Team">
                        <asp:TreeNode Text="Clark"></asp:TreeNode>
                        <asp:TreeNode Text="Wright"></asp:TreeNode>
                        <asp:TreeNode Text="Lopez"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="Web Team">
                        <asp:TreeNode Text="Joshua"></asp:TreeNode>
                        <asp:TreeNode Text="Matthew"></asp:TreeNode>
                        <asp:TreeNode Text="David"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="Build Team">
                        <asp:TreeNode Text="Ryan"></asp:TreeNode>
                        <asp:TreeNode Text="Justin"></asp:TreeNode>
                        <asp:TreeNode Text="Robert"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="WPF Team">
                        <asp:TreeNode Text="Brown"></asp:TreeNode>
                        <asp:TreeNode Text="Johnson"></asp:TreeNode>
                        <asp:TreeNode Text="Miller"></asp:TreeNode>
                </asp:TreeNode>
            </Nodes>
        </asp:TreeView>
    </div>
    <div>
        <asp:Menu ID="treeviewMenu" MenuType="ContextMenu" ClientSideOnClick="menuclick" ClientSideOnBeforeContextOpen="beforeOpen" 
                 OpenOnClick="false" runat="server" ContextMenuTarget="#LayoutSection_ControlsSection_treeView">
            <Items>
                <asp:MenuItem Text="Add New Item"></asp:MenuItem>
            </Items>
            <Items>
                <asp:MenuItem Text="Remove Item"></asp:MenuItem>
            </Items>
            <Items>
                <asp:MenuItem Text="Disable Item"></asp:MenuItem>
            </Items>
            <Items>
                <asp:MenuItem Text="Enable Item"></asp:MenuItem>
            </Items>
        </asp:Menu>
    </div>
    <script type="text/javascript" class="jsScript">
        var tabIndex = 1, treeviewObj, contextMenuObj, childMenu, selectedNode;
        $(function () {
            treeviewObj = $("#<%=treeView.ClientID%>").data("ejTreeView");
            contextMenuObj = $("#<%=treeviewMenu.ClientID%>").data("ejMenu");
        });
        function beforeOpen(args) {
            childMenu = contextMenuObj.element.children();
            if ($(args.target).hasClass('e-node-hover')) {
                $(childMenu).removeClass('e-disable-item');
                $(childMenu[3]).addClass('e-disable-item');
            }
            else if ($(args.target).hasClass('e-node-disable')) {
                $(childMenu).addClass('e-disable-item');
                $(childMenu[3]).removeClass('e-disable-item');
            }
            if (!$(args.target).hasClass("e-text"))
                args.cancel = true;
            else {
                selectedNode = $(args.target).closest('.e-item');
                if (!$(args.target).hasClass('e-node-disable'))
                    treeviewObj.selectNode(selectedNode);
            }
        }
        function menuclick(args) {
            if (args.events.text == "Add New Item") {
                treeviewObj.addNode("Item" + tabIndex, selectedNode);
                tabIndex++;
            }
            else if (args.events.text == "Remove Item") {
                treeviewObj.removeNode(selectedNode);
            }
            else if (args.events.text == "Disable Item") {
                treeviewObj.disableNode(selectedNode);
            }
            else if (args.events.text == "Enable Item") {
                treeviewObj.enableNode(selectedNode);
            }
        }
    </script>


      <h2>Modal Example</h2>
  <!-- Trigger the modal with a button -->
  <button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal">Open Modal</button>

  <!-- Modal -->
  <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog">
    
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Modal Header</h4>
        </div>
        <div class="modal-body">
          <p>Some text in the modal.</p>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
      </div>
      
    </div>
  </div>
</asp:Content>
