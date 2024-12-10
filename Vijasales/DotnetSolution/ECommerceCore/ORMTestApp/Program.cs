// See https://aka.ms/new-console-template for more information
using CRM.Repositories;
using CRM.Repositories.ORM;
using CRM.Entities;

IUserDataRepository _reposvc = new UserRepository();


//List<User> users = _reposvc.GetAll();
//foreach (User user in users)
//{
//    Console.WriteLine(user.Id + " " + user.FirstName + " " + user.LastName + " " + user.Password);
//}
//Console.ReadLine();
