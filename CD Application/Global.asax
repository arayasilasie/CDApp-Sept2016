<%@ Application Language="C#" %>

<script RunAt="server">
    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown
    }
    void Application_BeginRequest(object sender, EventArgs e)
    {
        
    }
    void Application_Error(object sender, EventArgs e)
    { 
        // Code that runs when an unhandled error occurs        
        Exception exc = Server.GetLastError();

        int errorCode = ECX.CD.Security.ErrorHandler.WriteLogEntry(exc, "unhandled exception");
        ECX.CD.Security.ErrorHandler.RedirectToErrorPage(errorCode);

        // Clear the error from the server
        Server.ClearError();
    }

    void Session_Start(object sender, EventArgs e)
    {
        //save the current user's Guid
        Guid? userGuid = ECX.CD.Security.SecurityHelper.GetUserGuid();

        //
        // TODO: remove the following line when the application goes live. Eyob's Guid is used in the development env't
        //
        //userGuid = new Guid("def592d3-e1ca-47d7-8272-00c24a6dbbef");        
        //userGuid = new Guid("f1474b42-9fe2-4fb3-afd9-5ca6d01dbf00");        

        
        if (userGuid == null)
        {
            FormsAuthentication.SignOut();
            //ErrorHandler.RedirectToErrorPage("Your user credential cannot be verified.");            
        }
        else
        {
            ECX.CD.Security.SecurityHelper.CurrentUserGuid = userGuid.Value;
        }

        Session["UserRights"] = ECX.CD.Security.SecurityHelper.GetUserRights(ECX.CD.Security.SecurityHelper.CurrentUserGuid.Value);
    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.
    }
       
</script>

