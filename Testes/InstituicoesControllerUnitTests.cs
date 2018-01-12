using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using ProgramasMobilidadeESW2017;
using ProgramasMobilidadeESW2017.Data;
using ProgramasMobilidadeESW2017.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Testes
{
    public class InstituicoesControllerUnitTests
    {
        [Fact]
        public async Task Index()
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase("testdb");
            var _dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var controller = new InstituicoesController(_dbContext);

            // Act
            var result = await controller.Index();

            // Assert
            Assert.IsType<ViewResult>(result);
        }
    }
}
