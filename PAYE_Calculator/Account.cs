#pragma warning disable CS8604, CS8600, CS0168, CS8601

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System.Threading;
using System.Text;

namespace UserAccounts
{
    public class UserAccount
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Dictionary<string, Dictionary<string, string>> History {get; set;}

        public UserAccount(string firstname, string lastname, string username, string password)
        {
            FirstName = firstname;
            LastName = lastname;
            UserName = username;
            Password = password;
            History = new Dictionary<string, Dictionary<string, string>>();
        }
        static bool IsEmpty(string input)
        {
            input = input.Trim();
            if (string.IsNullOrEmpty(input))
            {
                return true;
            }
            return false;
        }
        static void InitializeStorage()
        {
            string path = "storage.json";
            if (!(File.Exists(path)))
            {
                File.Create(path).Close();
                File.WriteAllText(path, "{}");
            }
        }
        public static string filePath = "storage.json";
        public static string json = File.ReadAllText(filePath);
        public static Dictionary<string, UserAccount> users = JsonSerializer.Deserialize<Dictionary<string, UserAccount>>(json);
        public static void RegisterUser()
        {
            InitializeStorage();
            Console.Write("First Name: ");
            string firstname = Console.ReadLine();
            while (IsEmpty(firstname))
            {
                Console.Write("First name cannot be empty\n\t> ");
                firstname = Console.ReadLine();
            }
            Console.Write("Last Name: ");
            string lastname = Console.ReadLine();
            while (IsEmpty(lastname))
            {
                Console.Write("Last name cannot be empty\n\t> ");
                lastname = Console.ReadLine();
            }
            //To be reviewed - Check if username is valid
            Console.Write("Preferred Unique Username: ");
            string username = Console.ReadLine();
            while (true)
            {
                if (users.ContainsKey(username))
                {
                    Console.Write("Username is taken try another one\n\t> ");
                    username = Console.ReadLine();
                    continue;
                }
                while (IsEmpty(username))
                {
                    Console.Write("Username cannot be empty\n\t>");
                    firstname = Console.ReadLine();
                }
                break;
            }
            
            string password = "1234";
            while (true)
            {
                Console.Write("Password: ");
                string tempPass = Console.ReadLine();
                Console.Write("Confirm Password: ");
                string tempPass2 = Console.ReadLine();
                if (tempPass == tempPass2)
                {
                    password = tempPass;
                    Console.WriteLine($"Password set to {password}");
                    break;
                }
                else
                {
                    Console.WriteLine("Passwords do not match");
                }
            }
            UserAccount user = new UserAccount(firstname, lastname, username, password);
            users[$"{user.UserName}"] = user;
            string data = JsonSerializer.Serialize(users);

            File.WriteAllText(filePath, data);
            Console.WriteLine($"User: '{user.UserName}' created successfully");
        }
        public static bool LoginUser(string username)
        {
            //To be reviewed - check if user is present in database
            if (users.ContainsKey(username))
            {
                Console.Write("Enter Password: ");
                string pass = Console.ReadLine();
                int count = 0;
                while (pass != users[username].Password)
                {
                    if (count >= 3)
                    {
                        Console.WriteLine("Too many retries");
                        return false;
                    }
                    Console.Write("Wrong Password\nRetry: ");
                    pass = Console.ReadLine();
                    count++;
                }
                return true;
            }
            Console.WriteLine("User not found");
            return false;
        }
        public static void UpdateHistory(UserAccount user)
        {
            /*DateTime current_time = DateTime.Now;
            users[user.History] = {
                current_time.ToString(), history
            };*/
            users[user.UserName] = user;
            Console.WriteLine($"{user.History}");
            string data = JsonSerializer.Serialize(users);
            File.WriteAllText(filePath, data);
        }
    }
}