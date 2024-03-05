using System.Data.Common;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using static System.Net.WebRequestMethods;

public class MessageGetAll
{
  public static string Route => "/";
  public static string[] Methods => new string[] { Http.Get };
  public static Action<ApplicationDbContext> Handler => HandlerAction;
  private static void HandlerAction(ApplicationDbContext db)
  {
    Console.WriteLine("Hello world");
    //db.Messages.Find();
  }
}