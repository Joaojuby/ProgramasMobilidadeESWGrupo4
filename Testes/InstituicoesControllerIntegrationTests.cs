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
    public class InstituicoesControllerIntegrationTests
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
            var result = await controller.Index(null);

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task DetailsReturnsErrorIfNoID()
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase("testdb");
            var _dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var controller = new InstituicoesController(_dbContext);
            
            // Act
            var result = await controller.Details(null);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Create()
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase("testdb");
            var _dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var controller = new InstituicoesController(_dbContext);

            // Act
            var result = controller.Create();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task EditReturnsErrorIfNoID()
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase("testdb");
            var _dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var controller = new InstituicoesController(_dbContext);

            // Act
            var result = await controller.Edit(null);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task DeleteReturnsErrorIfNoID()
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase("testdb");
            var _dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var controller = new InstituicoesController(_dbContext);

            // Act
            var result = await controller.Delete(null);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
