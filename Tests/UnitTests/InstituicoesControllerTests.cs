using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Moq;
using ProgramasMobilidadeESW2017.Data;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class InstituicoesControllerTests
    {

        public InstituicoesControllerTests()
        {
            InitContext();
        }

        private ApplicationDbContext _context;

        [Fact]
        public async Task Index_ReturnsAViewResult_WithAListOfInstituicoes()
        {
            // Arrange
            var mockContext = new Mock<I>
        }

        internal void InitContext()
        {
            var builder = new DbContextOptionsBuilder<IdentityDbContext>()
                .UseInMemoryDatabase();

            var context = new ApplicationDbContext(builder.Options);
            var Instituicoes = 
        }
    }
}
