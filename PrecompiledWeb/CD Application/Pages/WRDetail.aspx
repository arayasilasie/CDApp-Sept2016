<%@ page language="C#" autoeventwireup="true" inherits="Pages_WRDetail, App_Web_15pmpb44" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register src="~/Controls/WRDetail.ascx" tagname="WRDetail" tagprefix="uc7" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Warehouse Receipt Detail</title>
    <link href="../Styles/MainStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<%--    <p>
        <asp:Button ID="btnSave" runat="server" CssClass="button" OnCommand="btnSave_Click" Text="Save" />
    </p>--%>
    <uc7:WRDetail ID="wRDetail" runat="server" />
    </form>
</body>
</html>
