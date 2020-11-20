﻿using Microsoft.EntityFrameworkCore;
using razorHramBabynino.Data;
using razorHramBabynino.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace razorHramBabynino.Services
{
    public interface ILikesService
    {
        Task<List<like>> likes(int postId);
        Task add(like like);
        Task delete(int likeID);
    }

    public class LikesService : ILikesService
    {
        DbContextOptions<ApplicationDbContext> options;
        public LikesService(DbContextOptions<ApplicationDbContext> options)
        {
            this.options = options;
        }
        
        public async Task<List<like>> likes(int postId)
        {
            using (var context=new ApplicationDbContext(options))
            {
                return await context.likes.Where(l => l.postID == postId).ToListAsync();
            }                
        }

        public async Task add(like like)
        {
            using (var context = new ApplicationDbContext(options))
            {
                if (like != null)
                {
                    context.likes.Add(like);
                    await context.SaveChangesAsync();
                }
            }                       
        }
        public async Task delete(int likeID)
        {
            using (var context = new ApplicationDbContext(options))
            {
                context.likes.Remove(context.likes.FirstOrDefault(like=>like.ID==likeID));
                await context.SaveChangesAsync();                
            }            
        }

        
    }
}
