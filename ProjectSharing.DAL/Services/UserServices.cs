using ProjectSharing.DAL.DataContext;
using ProjectSharing.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectSharing.DAL.Services
{
    public class UserServices
    {
        private readonly ProjectSharingDbContext db = new ProjectSharingDbContext(ProjectSharingDbContext.ops.dbOptions);
        public List<User> GetAllUsers()
        {
            return db.Users.Where(x => x.IsBanned == false).ToList();
        }
        public User GetUserByID(string _userId)
        {
            return db.Users.FirstOrDefault(x => x.UserID == _userId);
        }
        public User GetUserByNameAndPwd(string _userName,string _password)
        {
            return db.Users.FirstOrDefault(x => x.UserName == _userName&&x.Password==_password);
        }
        public User GetUserByEmail(string _email)
        {
            return db.Users.FirstOrDefault(x => x.Email==_email);
        }
        public int AddNewUser(User _user)
        {
            try
            {
                var addedUser = db.Users.Add(_user);
                var affectedRows=db.SaveChanges();
                return affectedRows;
            }
            catch (Exception)
            {
                return -1;                
            }           
        }
        public int UpdateUser(User _user)
        {
            try
            {
                var updatedUser = db.Users.FirstOrDefault(x => x.UserID == _user.UserID);
                updatedUser.UserName = _user.UserName;
                updatedUser.Password = _user.Password;
                updatedUser.FirstName = _user.FirstName;
                updatedUser.LastName = _user.LastName;
                updatedUser.Email = _user.Email;
                updatedUser.Picture = _user.Picture;
                updatedUser.Tel = _user.Tel;
                updatedUser.Country = _user.Country;
                updatedUser.City = _user.City;
                updatedUser.Region = _user.Region;
                updatedUser.Address = _user.Address;                
                updatedUser.UserType = _user.UserType;
                var affectedRows = db.SaveChanges();
                return affectedRows;
            }
            catch (Exception)
            {
                return -1;
            }
            
        }
        public int DeleteUser(User _user)
        {
            try
            {
                var deletedUser = db.Users.FirstOrDefault(x => x.UserID == _user.UserID);
                deletedUser.IsBanned = true;
                var affectedRows = db.SaveChanges();
                return affectedRows;
            }
            catch (Exception)
            {
                return -1;
            }            
        }
    }
}
