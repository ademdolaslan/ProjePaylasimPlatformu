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
    }
}
