using ProjectSharing.DAL.Entities;
using ProjectSharing.DAL.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectSharing.BLL
{
   public class CommentBLL
    {
        public List<Comment> GetAllComments(int pageId)
        {
            return new CommentService().CommentsByPageID(pageId);
        }
        public int AddSubComment(int pageID,int commentID,string title,string text,string userId)
        {
            Comment c = new Comment() { 
            CommentParentID=commentID,
            CommentText=text,
            CommentTitle=title,
            PageID=pageID,
            Rating=0,
            UserID=userId,
            IsVerified=false            
            };
            return new CommentService().AddComment(c);
        }
        public int AddComment(int pageID, string title, string text, string userId)
        {
            Comment c = new Comment()
            {
                CommentParentID = null,
                CommentText = text,
                CommentTitle = title,
                PageID = pageID,
                Rating = 0,
                UserID = userId,
                IsVerified = false
            };
            return new CommentService().AddComment(c);
        }
    }
}
