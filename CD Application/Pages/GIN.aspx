<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GIN.aspx.cs" Inherits="Pages_GIN" %>

<%@ Register src="../Controls/GINLoadingDetail.ascx" tagname="GINLoadingDetail" tagprefix="uc1" %>
<%@ Register src="../Controls/GINScalingDetail.ascx" tagname="GINScalingDetail" tagprefix="uc2" %>
<%@ Register src="../Controls/GINDetail.ascx" tagname="GINDetail" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>GIN Detail</title>
    <link href="../Styles/MainStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
	    <fieldset>
	        <legend>GIN</legend>
	        <uc3:GINDetail ID="ginDetail" runat="server" />
	    </fieldset>
	    <fieldset>
	        <legend>Loading Detail</legend>
            <uc1:GINLoadingDetail ID="loadingDetail" runat="server" />
	    </fieldset>
	    <fieldset>
	        <legend>Scaling Detail</legend>
            <uc2:GINScalingDetail ID="scalingDetail" runat="server" />
        </fieldset>
    </form>
</body>
</html>
