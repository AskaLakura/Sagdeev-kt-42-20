using Microsoft.EntityFrameworkCore;
using Sagdeev_kt4220.Database;
using Sagdeev_kt4220.Filters;
using Sagdeev_kt4220.Interfaces;
using Sagdeev_kt4220.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagdeev_kt4220.Tests
{
    public class PrepodIntegrationTests
    {
        public readonly DbContextOptions<PrepodDbcontext> _dbContextOptions;

        public PrepodIntegrationTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<PrepodDbcontext>()
            .UseInMemoryDatabase(databaseName: "prepod_db1")
            .Options;
        }

        [Fact]
        public async Task GetPrepodsByKafedraAsync_KT4220_OneObjects()
        {
            // Arrange
            var ctx = new PrepodDbcontext(_dbContextOptions);
            var prepodService = new PrepodService(ctx);
            var kafedra = new List<Kafedra>
            {
                new Kafedra
                {
                    KafedraId =1,
                    KafedraName = "КТ"
                },
                new Kafedra
                {
                    KafedraId =2,
                    KafedraName = "ИВТ"
                }
            };
            await ctx.Set<Kafedra>().AddRangeAsync(kafedra);

            await ctx.SaveChangesAsync();

            var stepen = new List<Stepen>
            {
                new Stepen
                {
                    StepenId =1,
                    StepenName = "Доктор наук"
                },
                new Stepen
                {
                    StepenId =2,
                    StepenName = "Кандидат наук"
                }
            };
            await ctx.Set<Stepen>().AddRangeAsync(stepen);

            await ctx.SaveChangesAsync();

            var prepods = new List<Prepod>
            {
                new Prepod
                {
                    FirstName = "Человек_1",
                    LastName = "Человек_1",
                    MiddleName = "Человек_1",
                    Mail = "1111@mail.ru",
                    KafedraId = 1,
                    StepenId = 2
                },
                new Prepod
                {
                    FirstName = "Человек_2",
                    LastName = "Человек_2",
                    MiddleName = "Человек_2",
                    Mail = "2222@mail.ru",
                    KafedraId = 1,
                    StepenId = 2
                },
                new Prepod
                {
                    FirstName = "Человек_3",
                    LastName = "Человек_3",
                    MiddleName = "Человек_3",
                    Mail = "3333@mail.ru",
                    KafedraId = 2,
                    StepenId = 2
                }
            };
            await ctx.Set<Prepod>().AddRangeAsync(prepods);

            await ctx.SaveChangesAsync();

            // Act
            var filter = new PrepodKafedraFilter
            {
                KafedraName = "ИВТ"
            };
            var prepodsResult = await prepodService.GetPrepodsByKafedraAsync(filter, CancellationToken.None);

            Assert.Equal(1, prepodsResult.Length);
        }
    }
}
