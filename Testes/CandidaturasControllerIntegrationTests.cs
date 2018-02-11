using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgramasMobilidadeESW2017.Controllers;
using ProgramasMobilidadeESW2017.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Testes
{
    public class CandidaturasControllerIntegrationTests
    {
        [Fact]
        public async Task Index()
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase("testdb");
            var _dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var controller = new CandidaturasController(_dbContext);

            // Act
            var result = await controller.Index();

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

            var controller = new CandidaturasController(_dbContext);

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

            var controller = new CandidaturasController(_dbContext);

            var id = 1;
            // Act
            var result = controller.Create(id);

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

            var controller = new CandidaturasController(_dbContext);

            // Act
            var result = await controller.Edit(null);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task CancelReturnsErrorIfNoID()
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase("testdb");
            var _dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var controller = new CandidaturasController(_dbContext);

            // Act
            var result = await controller.Cancel(null);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
