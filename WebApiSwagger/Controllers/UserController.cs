using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiSwagger.Models;

namespace WebApiSwagger.Controllers
{
  public class UserController : ApiController
  {

     private static List<User> UsersList;

     public UserController()
        {
          if (UsersList == null)
            {
              UsersList = UsersData.CreateUsers();
            }

        }

     /// <summary>
     /// Get all users
     /// </summary>
     /// <remarks>Get an array of all users</remarks>
     //[Route("")]
     [ResponseType(typeof(List<User>))]
     public IHttpActionResult Get()
    {
//      var product = products.FirstOrDefault((p) => p.Id == id);
//      if (product == null)
//      {
//        return NotFound();
//      }
      return Ok(UsersList);
    }


    /// <summary>
    /// Get User
    /// </summary>
    /// <param name="Id">user id</param>
    /// <remarks>Get signle User by providing user id</remarks>
    /// <response code="404">Not found</response>
    /// <response code="500">Internal Server Error</response>
    [ResponseType(typeof(User))]
     public IHttpActionResult Get(int id)
    {
      var user = UsersList.FirstOrDefault((p) => p.ID == id);
      if (user == null)
      {
        return NotFound();
      }
      return Ok(user);
    }






    public class UsersData
    {
      public static List<User> CreateUsers()
      {

        List<User> UsersList = new List<User>();

        for (int i = 0; i < usersList.Length; i++)
        {
          var nameGenderMail = SplitValue(usersList[i]);
          var User = new User()
          {
            ID = i,
            Email = String.Format("{0}.{1}@{2}", nameGenderMail[0], nameGenderMail[1], nameGenderMail[3]),
            UserName = String.Format("{0}{1}", nameGenderMail[0], nameGenderMail[1]),
            FirstName = nameGenderMail[0],
            LastName = nameGenderMail[1],
            DateOfBirth = DateTime.UtcNow.AddDays(-new Random().Next(7000, 8000)),
          };

          UsersList.Add(User);
        }

        return UsersList;
      }


      static string[] usersList =
      {
        "Rema,Husein,Male,hotmail.com",
        "Hasan,Ahmad,Male,mymail.com",
        "Moatasem,Ahmad,Male,outlook.com",
        "Salma,Tamer,Female,outlook.com",
        "Ahmad,Radi,Male,gmail.com",
        "Malek,Gates,Male,yahoo.com",
        "Shareef,Khaled,Male,gmail.com",
        "Aram,Malek,Male,gmail.com",
        "Malek,Ibrahim,Female,mymail.com",
        "Rema,Oday,Female,hotmail.com",
        "Fikri,Malek,Male,gmail.com",
        "Zakari,Malek,Male,outlook.com",
        "Taher,Waleed,Male,mymail.com",
        "Tamer,Jana,Male,yahoo.com",
        "Khaled,Hasaan,Male,gmail.com",
        "Jana,Ibrahim,Male,hotmail.com",
        "Tareq,Nassar,Male,outlook.com",
        "Diana,Jana,Female,outlook.com",
        "Tamara,Malek,Female,gmail.com",
        "Arwa,Kamal,Female,yahoo.com",
        "Jana,Ahmad,Female,yahoo.com",
        "Nisreen,Malek,Female,gmail.com",
        "Malek,Jana,Female,outlook.com"
      };

      private static string[] SplitValue(string val)
      {
        return val.Split(',');
      }

    }
  }
}
