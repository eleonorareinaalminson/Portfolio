# Portfolio Solution

A modern portfolio application built with ASP.NET Core, featuring a clean web interface and RESTful API architecture deployed on Microsoft Azure.

## 🌐 Live Demo

**Portfolio Website:** [https://portfolio-web-eleonora-d3fdafg5fsgwa3g3.swedencentral-01.azurewebsites.net/](https://portfolio-web-eleonora-d3fdafg5fsgwa3g3.swedencentral-01.azurewebsites.net/)

**API Endpoint:** [https://portfolio-api-eleonora-cue0gva6fjbpb7cs.swedencentral-01.azurewebsites.net/api/projects](https://portfolio-api-eleonora-cue0gva6fjbpb7cs.swedencentral-01.azurewebsites.net/api/projects)

## 🏗️ Architecture

The solution follows a clean architecture pattern with three main projects:

```
Portfolio Solution
├── Portfolio.Web (Frontend)
├── ProjectsAPI (Backend API)
└── Portfolio.DataAccessLayer (Data Access)
```

## 🚀 Features

### Portfolio.Web
- **Modern Responsive Design** - Mobile-first approach with Bootstrap
- **Project Showcase** - Dynamic display of portfolio projects via API consumption
- **Contact System** - Email functionality with SMTP integration
- **Weather Widget** - Real-time weather data for Stockholm
- **Clean UI/UX** - Professional design with smooth navigation

### ProjectsAPI
- **RESTful API** - Full CRUD operations for project management
- **Entity Framework Core** - Code-first database approach
- **CORS Configuration** - Secure cross-origin resource sharing
- **Production Ready** - Optimized for Azure deployment

### Features Include:
- ✅ Project portfolio display
- ✅ Contact form with email notifications
- ✅ Weather information integration
- ✅ Responsive design for all devices
- ✅ RESTful API for project data
- ✅ Database persistence with migrations

## 🛠️ Technology Stack

### Frontend (Portfolio.Web)
- **ASP.NET Core 9** - Web framework
- **Razor Pages** - Server-side rendering
- **Bootstrap 5** - CSS framework
- **Entity Framework Core** - ORM
- **HttpClient** - API consumption

### Backend (ProjectsAPI)
- **ASP.NET Core 9** - Web API framework
- **Entity Framework Core** - Database ORM
- **SQL Server** - Database engine
- **Repository Pattern** - Data access abstraction

### Infrastructure
- **Azure App Service** - Web hosting (2 instances)
- **Azure SQL Database** - Data persistence
- **Azure Portal** - Configuration management

## 🗄️ Database Schema

### Projects Table
- Id (Primary Key)
- Name
- Description
- ImageUrl
- ProjectUrl
- GithubUrl
- TechStack
- Date

## 🚀 Deployment

The application is deployed using a microservices approach on Microsoft Azure:

### Azure Resources:
1. **portfolio-web-eleonora** - Main web application
2. **portfolio-api-eleonora** - RESTful API service
3. **portfolio-db-server** - SQL Database server
4. **portfoliodb** - Application database

### Environment Configuration:
- Production connection strings via Azure App Settings
- CORS policies configured for cross-service communication
- Automatic database migrations on startup

## 📊 API Endpoints

### Projects API
- `GET /api/projects` - Retrieve all projects
- `GET /api/projects/{id}` - Retrieve specific project
- `POST /api/projects` - Create new project
- `PUT /api/projects/{id}` - Update existing project
- `DELETE /api/projects/{id}` - Delete project

## 🔧 Configuration

### Required Settings (appsettings.json):
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "[Azure SQL Connection String]"
  },
  "ApiSettings": {
    "BaseUrl": "[ProjectsAPI URL]"
  },
  "WeatherApi": {
    "ApiKey": "[OpenWeather API Key]",
    "City": "Stockholm"
  },
  "Email": {
    "SmtpHost": "smtp.gmail.com",
    "SmtpPort": 587,
    "SmtpUsername": "[Email]",
    "SmtpPassword": "[App Password]"
  }
}
```

## 🌟 Key Features Demonstrated

- **Separation of Concerns** - Clean architecture with distinct layers
- **API Design** - RESTful endpoints following HTTP conventions  
- **Cloud Deployment** - Production-ready Azure deployment
- **Database Integration** - Code-first approach with migrations
- **Configuration Management** - Environment-specific settings
- **Error Handling** - Graceful error management and logging
- **Responsive Design** - Mobile-first responsive layout
- **Service Integration** - External API consumption (Weather)

## 🔗 External Integrations

- **OpenWeather API** - Real-time weather data
- **Gmail SMTP** - Email notifications
- **Azure Services** - Cloud hosting and database

## 📈 Performance Features

- **Async/Await** - Non-blocking operations
- **HttpClient** - Efficient API calls
- **Entity Framework Optimization** - Efficient database queries
- **Azure Scaling** - Auto-scaling capabilities

## 👨‍💻 Development

Built by **Eleonora Alminson** as part of a comprehensive web development project demonstrating:
- Full-stack development skills
- Cloud deployment expertise  
- API design and consumption
- Modern web development practices
- Professional project structure

---

*This portfolio showcases modern web development practices with clean architecture, cloud deployment, and professional-grade code quality.*
