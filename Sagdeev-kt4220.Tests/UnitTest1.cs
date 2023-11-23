using Sagdeev_kt4220.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sagdeev_kt4220.Models;

namespace Sagdeev_kt4220.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void IsValidMail_True()
        {
            var MailTest = new Prepod
            {
                Mail = "mm@mail.ru"
            };

            var result = MailTest.IsValidMail();

            Assert.False(result);

        }
    }
}
