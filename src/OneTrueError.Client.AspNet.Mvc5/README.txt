﻿OneTrueError - ASP.NET MVC5 integration
=======================================

Congratulations on taking the first step toward a more efficient exception handling.

Now you need to either download and install the open source server: https://github.com/gauffininteractive/OneTrueError.Server/
.. or create an account at https://onetrueerror.com.

Once done, log into the server and find the configuration instructions.
(Or read the articles in our documentation: https://onetrueerror.com/documentation)


Reporting exceptions
===========================

All unhandled exceptions are reported by default. 

However, you might want to report exceptions manually.
If you want MVC5 specific information to be included, you need to use an controller exception method:

public ActionResult YourMethod(int userId, int postId)
{
  try
  {
     // [...some code...]
  }
  catch (Exception ex)
  {
    //userId and postId will automatically be
    //attached as routeData values.
    this.ReportException(ex);
  }
}
