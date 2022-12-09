using Microsoft.EntityFrameworkCore;
using PrivateTuition.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateTuition.Data.Concrete.EFCore
{
    public class PrivateTuitionContext : DbContext
    {
        public PrivateTuitionContext(DbContextOptions options) : base(options)
        {

        }      
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Teacher> Teachers { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
        public DbSet<LessonRequest> LessonRequests { get; set; } = null!;
        public DbSet<ShowCard> ShowCards { get; set; } = null!;
        public DbSet<Subject> Subjects { get; set; } = null!;
        public DbSet<SubjectCategory> SubjectCategories { get; set; } = null!;
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<SubjectCategory>()
                .HasKey(pc => new
                {
                    pc.SubjectId,
                    pc.CategoryId
                });

            modelBuilder
            .Entity<Category>()
            .HasData(
                new Category() { Id = 1, Name = "Lise", Url = "lise" },
                new Category() { Id = 2, Name = "İlköğretim", Url = "ilkogretim" },
                new Category() { Id = 3, Name = "Bilgisayar", Url = "bilgisayar" },
                new Category() { Id = 4, Name = "Sınava Hazırlık", Url = "sınava-hazırlık" }
            );

            modelBuilder
                .Entity<Subject>()
                .HasData(
                    new Subject() { Id = 1, Name = "Matematik", Url = "matematik", },

                    new Subject() { Id = 2, Name = "Fizik", Url = "fizik" },

                    new Subject() { Id = 3, Name = "Kimya", Url = "kimya" },

                    new Subject() { Id = 4, Name = "C#", Url = "c#" },

                    new Subject() { Id = 5, Name = "Javascript", Url = "javascript" },

                    new Subject() { Id = 6, Name = "KPSS", Url = "kpss" },

                    new Subject() { Id = 7, Name = "YGS-LYS", Url = "ygs-lys" },

                    new Subject() { Id = 8, Name = "Hayat Bilgisi", Url = "hayat-bilgisi" },

                    new Subject() { Id = 9, Name = "İngilizce", Url = "ingilizce" },

                    new Subject() { Id = 10, Name = "IELTS-TOEFL", Url = "ielts-toefl" }

                );

            modelBuilder
                .Entity<SubjectCategory>()
                .HasData(
                    new SubjectCategory() { SubjectId = 1, CategoryId = 1 },
                    new SubjectCategory() { SubjectId = 2, CategoryId = 1 },
                    new SubjectCategory() { SubjectId = 3, CategoryId = 1 },
                    new SubjectCategory() { SubjectId = 9, CategoryId = 1 },
                    new SubjectCategory() { SubjectId = 1, CategoryId = 2 },
                    new SubjectCategory() { SubjectId = 2, CategoryId = 2 },
                    new SubjectCategory() { SubjectId = 3, CategoryId = 2 },
                    new SubjectCategory() { SubjectId = 9, CategoryId = 2 },
                    new SubjectCategory() { SubjectId = 8, CategoryId = 2 },
                    new SubjectCategory() { SubjectId = 6, CategoryId = 4 },
                    new SubjectCategory() { SubjectId = 7, CategoryId = 4 },
                    new SubjectCategory() { SubjectId = 10, CategoryId = 4 },
                    new SubjectCategory() { SubjectId = 4, CategoryId = 3 },
                    new SubjectCategory() { SubjectId = 5, CategoryId = 3 }
                    );
                  


            modelBuilder
               .Entity<Teacher>()
               .HasData(
                    new Teacher() { Id = 1, City = "İstanbul", District = "Avcılar", Name = "Semih Karaoğlan", TeacherInfo = "5 Yıl deneyimli uzman öğretmen.", TeacherStatue =Entity.Enum.TeacherStatue.Leader, Url = "5-yil-deneyimli-uzman", Mail = "hsnkra@gmail.com" },
                    new Teacher() { Id = 2, City = "İstanbul", District = "Küçükçekmece", Name = "Yasin Güney", TeacherInfo = "6 Yıl deneyimli uzman öğretmen ve eğitim koçu.", TeacherStatue =Entity.Enum.TeacherStatue.Super, Url = "5-yil-deneyimli-uzman-ogretmen", Mail = "hsnkra@gmail.com" }

                );
            modelBuilder
               .Entity<Student>()
               .HasData(
                    new Student() { Id = 1, City = "İstanbul", District = "Florya", Name = "Hasan Karaoğlan", Url = "hasan-karaoglan", Mail = "hsnkra@gmail.com" },
                    new Student() { Id = 2, City = "İstanbul", District = "Avcılar", Name = "Yunus Güney", Url = "yunus", Mail = "ynsgny@gmail.com" }

                );

            modelBuilder
          .Entity<Comment>()
          .HasData(
              new Comment() { Id = 1, TeacherId = 1, StudentId = 1, Title = "Çok iyii", StdComment = "Gerçekten alanında çok başarılı ve anlaşılır bir hoca", Url="123" }
              );

          //  modelBuilder
          //.Entity<ShowCard>()

          //.HasData(
          //         new ShowCard() { Id = 1,TeacherId=1,LessonPrice=200, Title = "Uzmanından matematik dersleri", Description = "Uzun yıllardır eğitim vermekteyim,dersler dışarıda veya online olabilir.", SubjectId=1, Url="1"},
          //         new ShowCard() { Id = 2,TeacherId=2,LessonPrice=350, Title = "Dersler ersler dışarıda veya online olabilir.", Description = "İlkokuldan üniversiteye kadar ... ", SubjectId = 3, Url = "2" }

          //     );

            modelBuilder
         .Entity<LessonRequest>()
         .HasData(
               new LessonRequest() { Id = 1, ShowCardId = 1, StudentId = 2, Expectations = "Haftada 4 saat matematik dersi", ContactNumber = "0545-719-73-78" }
               );

           

        }
    }
}
