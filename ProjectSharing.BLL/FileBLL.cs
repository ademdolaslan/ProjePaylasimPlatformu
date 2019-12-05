using ProjectSharing.DAL.Entities;
using ProjectSharing.DAL.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectSharing.BLL
{
    public class FileBLL
    {
        public File GetFileByID(int fileId)
        {
            return new FileService().GetFileByFileID(fileId);
        }
        public List<File> GetFilesByUserID(string userId)
        {
            return new FileService().GetUserFiles(userId);
        }
        public List<File> GetFilesbyPageID(int pageId)
        {
            return new FileService().GetPageFiles(pageId);
        }
        public int AddNewFile(File file)
        {
            FileService service = new FileService();
            return service.AddNewFile(file);
        }
        public void UpdateFile(File file)
        {

        }
        public void DeleteFile(File file)
        {

        }
    }
}
