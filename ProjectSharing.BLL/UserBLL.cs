using System;
using System.Collections.Generic;
using System.Text;
using ProjectSharing.DAL.Entities;
using ProjectSharing.DAL.Services;
using System.Drawing;
using System.IO;
using Microsoft.AspNetCore.Http;


namespace ProjectSharing.BLL
{
    public class UserBLL
    {
        readonly UserServices services = new UserServices();
        public List<User> GetAllUsers()
        {
            return services.GetAllUsers();
        }
        public User GetUser(string mail)
        {
            return services.GetUserByEmail(mail);
        }
        public User GetUser(string uname, string pwd)
        {
            return services.GetUserByNameAndPwd(uname, pwd);
        }
        public User GetUserByID(string id)
        {
            return services.GetUserByID(id);
        }
        public int AddUser(User user)
        {
            if (user is null)
            {
                return 404;
            }
            else
            {
                user.UserID = user.FirstName.Substring(0, 3).ToUpper() + user.LastName.Substring(0, 3).ToUpper();
                user.Picture = user.Picture;
                user.IsBanned = false;
                user.UserType = "User";
                return services.AddNewUser(user);
            }
        }
        public int UpdateUser(User user)
        {
            if (user is null)
            {
                return 404;
            }
            else
            {
                return services.UpdateUser(user);
            }
        }
        public int DeleteUser(User user)
        {
            if (user is null)
            {
                return 404;
            }
            else
            {
                return services.DeleteUser(user);
            }
        }
        public byte[] ImageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }
        public Image ByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

    }
}
