using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TownGameBot.Models
{
    public class AplicationContext : DbContext
    {
        public DbSet<CityModel> CityModels { get; set; } = null!;

        public AplicationContext(DbContextOptions<AplicationContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CityModel>().HasData(
                new CityModel { Id = 1, City = "Майкоп" },
                new CityModel { Id = 2, City = "Уфа" },
                new CityModel { Id = 3, City = "Горно-Алтайск" },
                new CityModel { Id = 4, City = "Махачкала" },
                new CityModel { Id = 5, City = "Нальчик" },
                new CityModel { Id = 6, City = "Элиста" },
                new CityModel { Id = 7, City = "Черкесск" },
                new CityModel { Id = 8, City = "Петрозаводск" },
                new CityModel { Id = 9, City = "Сыктывкар" },
                new CityModel { Id = 10, City = "Йошкар-Ола" },
                new CityModel { Id = 11, City = "Саранск" },
                new CityModel { Id = 12, City = "Якутск" },
                new CityModel { Id = 13, City = "Владикавказ" },
                new CityModel { Id = 14, City = "Кызыл" },
                new CityModel { Id = 15, City = "Ижевск" },
                new CityModel { Id = 16, City = "Абакан" },
                new CityModel { Id = 17, City = "Барнаул" },
                new CityModel { Id = 18, City = "Краснодар" },
                new CityModel { Id = 19, City = "Красноярск" },
                new CityModel { Id = 20, City = "Владивосток" },
                new CityModel { Id = 21, City = "Ставрополь" },
                new CityModel { Id = 22, City = "Хабаровск" },
                new CityModel { Id = 23, City = "Благовещенск" },
                new CityModel { Id = 24, City = "Архангельск" },
                new CityModel { Id = 25, City = "Белгород" },
                new CityModel { Id = 26, City = "Брянск" },
                new CityModel { Id = 27, City = "Владимир" },
                new CityModel { Id = 28, City = "Волгоград" },
                new CityModel { Id = 29, City = "Вологда" },
                new CityModel { Id = 30, City = "Иваново" },
                new CityModel { Id = 31, City = "Иркутск" },
                new CityModel { Id = 32, City = "Калининград" },
                new CityModel { Id = 33, City = "Калуга" },
                new CityModel { Id = 34, City = "Петропавловск-Камчатский" },
                new CityModel { Id = 35, City = "Кемерово" },
                new CityModel { Id = 36, City = "Киров" },
                new CityModel { Id = 37, City = "Кострома" },
                new CityModel { Id = 38, City = "Курган" },
                new CityModel { Id = 39, City = "Курск" },
                new CityModel { Id = 40, City = "Санкт-Петербург" },
                new CityModel { Id = 41, City = "Липецк" },
                new CityModel { Id = 42, City = "Магадан" },
                new CityModel { Id = 43, City = "Москва", NamedCity = true },
                new CityModel { Id = 44, City = "Мурманск" },
                new CityModel { Id = 45, City = "Нижний Новгород" },
                new CityModel { Id = 46, City = "Новгород" },
                new CityModel { Id = 47, City = "Новосибирск" },
                new CityModel { Id = 48, City = "Омск" },
                new CityModel { Id = 49, City = "Оренбург" },
                new CityModel { Id = 50, City = "Орел" },
                new CityModel { Id = 51, City = "Пенза" },
                new CityModel { Id = 52, City = "Псков" },
                new CityModel { Id = 53, City = "Ростов-на-Дону" },
                new CityModel { Id = 54, City = "Самара" },
                new CityModel { Id = 55, City = "Саратов" },
                new CityModel { Id = 56, City = "Южно-Сахалинск" },
                new CityModel { Id = 57, City = "Екатеринбург" },
                new CityModel { Id = 58, City = "Смоленск" },
                new CityModel { Id = 59, City = "Тамбов" },
                new CityModel { Id = 60, City = "Томск" },
                new CityModel { Id = 61, City = "Тула" },
                new CityModel { Id = 62, City = "Ульяновск" },
                new CityModel { Id = 63, City = "Челябинск" },
                new CityModel { Id = 64, City = "Чита" },
                new CityModel { Id = 65, City = "Биробиджан" },
                new CityModel { Id = 66, City = "Агинское" },
                new CityModel { Id = 67, City = "Кудымкар" },
                new CityModel { Id = 68, City = "Палана" },
                new CityModel { Id = 69, City = "Нарьян-Мар" },
                new CityModel { Id = 70, City = "Астрахань" },
                new CityModel { Id = 71, City = "Дудинка" },
                new CityModel { Id = 72, City = "Усть-Ордынский" },
                new CityModel { Id = 73, City = "Ханты-Мансийск" },
                new CityModel { Id = 74, City = "Тура" },
                new CityModel { Id = 75, City = "Салехард" },
                new CityModel { Id = 76, City = "Грозный" }
                );
        }
    }
}
