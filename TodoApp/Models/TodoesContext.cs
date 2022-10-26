using System;
using System.Collections.Generic;
using System.Data.Entity; //Add
using System.Linq;
using System.Web;

namespace TodoApp.Models
{
    //TodoClassとDBを繋げる DbContextを継承する必要がある
    public class TodoesContext : DbContext
    {
        //DBから取得したTodoを格納するDbSet　このプロパティを通じてデータの取得を行う
        public DbSet<Todo> Todoes { get; set; }
        public DbSet<User>  Users  { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}