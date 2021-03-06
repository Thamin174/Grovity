﻿using Grovity.Database;
using Grovity.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grovity.Services
{
    public class CategoriesService
    {

        public Category GetCategory(int ID)
        {
            using(var context = new GrovityContext())
            {
                return context.Categories.Find(ID);
            }      
        }
        public List<Category> GetCategories()
        {
            using (var context = new GrovityContext())
            {
                return context.Categories.ToList();
            }           
        }


        public void SaveCategory(Category category)
        {
            using (var context = new GrovityContext())
            {
                context.Categories.Add(category);

                context.SaveChanges();
            }            
        }
        public void UpdateCategory(Category category)
        {
            using (var context = new GrovityContext())
            {
                context.Entry(category).State = EntityState.Modified;

                context.SaveChanges();
            }           
        }
        public void DeleteCategory(int ID)
        {
            using (var context = new GrovityContext())
            {
                 var category = context.Categories.Find(ID);

                 context.Categories.Remove(category);

                 context.SaveChanges();
            }
        }
    }
}
