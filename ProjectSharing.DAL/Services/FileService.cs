using Microsoft.EntityFrameworkCore;
using ProjectSharing.DAL.DataContext;
using ProjectSharing.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectSharing.DAL.Services
{
    public class FileService
    {
        private readonly ProjectSharingDbContext db = new ProjectSharingDbContext(ProjectSharingDbContext.ops.dbOptions);
        public File GetFileByFileID(int _id)
        {
            return db.Files.FirstOrDefault(x => x.FileID == _id);
        }
        public List<File> GetUserFiles(string userId)
        {
            var files = db.Files.Where(x => x.UserID == userId).ToList();
            return files;
        }
        public int AddNewFile(File _file)
        {
            try
            {
                db.Files.Add(_file);
                var affectedRows = db.SaveChanges();
                return affectedRows;
            }
            catch (Exception)
            {
                return -1;                
            }
        }
        public int UpdateFile(File _file)
        {
            try
            {
                var updatedFile = db.Files.FirstOrDefault(x => x.FileID == _file.FileID);
                updatedFile.FileName = _file.FileName;
                updatedFile.FileVersion = _file.FileVersion;
                updatedFile.FilePath = _file.FilePath;
                updatedFile.FileType = _file.FileType;
                updatedFile.FileSize = _file.FileSize;
                var affectedRows = db.SaveChanges();
                return affectedRows;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        public int DeleteFile(int _fileId)
        {
            try
            {
                var deletedFile = db.Files.FirstOrDefault(x => x.FileID == _fileId);
                db.Files.Remove(deletedFile);
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
