namespace TodoApp.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TodoApp.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TodoApp.Models.TodoesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true; //データが消える変更を許可するかどうか
            ContextKey = "TodoApp.Models.TodoesContext";
        }

        //マイグレーション後に自動的に実行される処理
        protected override void Seed(TodoApp.Models.TodoesContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            User admin = new User()
            {
                Id = 1,
                UserName = "administrator",
                Password = "password",
                Roles = new List<Role>()
            };


            Role administrators = new Role()
            {
                Id = 1,
                RoleName = "Administrators",
                Users = new List<User>()
            };


            admin.Roles.Add(administrators);
            administrators.Users.Add(admin);

            //AddOrUpdate 複数のユーザーをまとめて登録
            //追加する要素がなければ追加、登録されていたら更新　第一引数に渡すID
            context.Users.AddOrUpdate(user => user.Id, new User[] { admin });
            context.Roles.AddOrUpdate(role => role.Id, new Role[] { administrators });
        }
    }
}
