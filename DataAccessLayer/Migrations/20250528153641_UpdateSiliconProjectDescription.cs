using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSiliconProjectDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name", "TechStack" },
                values: new object[] { "A comprehensive banking application showcasing modern React development. Features include dark/light theme switching, responsive design across all devices, secure money transfer functionality, international payment processing, and dynamic FAQ system. Integrates with external APIs for testimonials and newsletter subscription. Built with React 19, Vite, and modern CSS practices including CSS Grid and Flexbox for optimal performance and user experience.", "Silicon Banking App", "React 19, Vite 6, React Router 7, CSS3 Variables, Bootstrap Icons, API Integration, Responsive Grid" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name", "TechStack" },
                values: new object[] { "A modern applikation built with React.", "Silicon React App", "React 19, React Router 7, CSS, Bootstrap Icons, Responsive Design" });
        }
    }
}
