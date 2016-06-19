<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctrLoading.ascx.vb" Inherits="wSoftCentroErgonomia.ctrLoading" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<style type="text/css">
  .modalBackground 
  {     
      background-color: White;     
      filter: alpha(opacity=50);     
      opacity: 0.50; 
   }  
   .updateProgress 
   {     
       border-width: 1px;     
       border-style: solid;     
       background-color: #FFFFFF;     
       position: absolute;     
       width: 160px;     
       height: 100px; 
   } 
 </style>

  <script type="text/javascript">
      //Código JavaScript incluido en un archivo denominado jsUpdateProgress.js 
      Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(beginReq);
      Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endReq);
      var ModalProgress = '<%= ModalProgress.ClientID %>';

      function beginReq(sender, args) {
          // muestra el popup     
          $find(ModalProgress).show();
      }

      function endReq(sender, args) {
          //  esconde el popup     
          $find(ModalProgress).hide();
      }
    </script>
<asp:Panel ID="panelUpdateProgress" runat="server">     
    <asp:UpdateProgress ID="UpdateProgress1" DisplayAfter="0" runat="server">       
        <ProgressTemplate>         
            <table style="text-align: left; background-color: #FFFFFF;">
            <tr>
                <td> 
                    <table style="margin:auto;">
                        <tr>
                            <td>
                                <img src="../../Images/General/imLoading.gif" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            </table>
        </ProgressTemplate>     
    </asp:UpdateProgress>   
</asp:Panel> 
<asp:ModalPopupExtender ID="ModalProgress" runat="server" TargetControlID="panelUpdateProgress" BackgroundCssClass="modalBackground" PopupControlID="panelUpdateProgress">
                     </asp:ModalPopupExtender>