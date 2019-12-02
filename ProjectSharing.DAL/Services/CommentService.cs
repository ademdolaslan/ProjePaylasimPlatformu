using ProjectSharing.DAL.DataContext;
using ProjectSharing.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectSharing.DAL.Services
{
    public class CommentService
    {
        private readonly ProjectSharingDbContext db = new ProjectSharingDbContext(ProjectSharingDbContext.ops.dbOptions);
        public List<Comment> CommentsByPageID(int pageId)
        {
            return db.Comments.Where(x => x.PageID == pageId&&x.CommentParentID==null).ToList();
        }
        public List<Comment> SubCommentByCommentID(int commentId)
        {
            return db.Comments.Where(x => x.CommentParentID == commentId).ToList();
        }
        public int AddComment(Comment comment)
        {
            try
            {
                db.Comments.Add(comment);
                var affectedRows = db.SaveChanges();
                return affectedRows;
            }
            catch (Exception)
            {
                return -1;               
            }
        }
        public int UpdateComment(Comment _comment)
        {
            try
            {
                var updatedComment = db.Comments.FirstOrDefault(x => x.CommentID == _comment.CommentID);
                updatedComment.CommentTitle = _comment.CommentTitle;
                updatedComment.CommentText = _comment.CommentText;
                var affectedRows = db.SaveChanges();
                return affectedRows;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        public int DeleteComment(int commentID)
        {
            try
            {
                var deletedComment = db.Comments.FirstOrDefault(x => x.CommentID == commentID);
                var deletedSubComments = db.Comments.Where(x => x.CommentParentID == commentID).ToList();
                foreach (var item in deletedSubComments)
                {
                    db.Comments.Remove(item);
                }
                db.Comments.Remove(deletedComment);                
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
