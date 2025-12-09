// Configuration management for Employee Service
const config = {
  // Server
  port: process.env.PORT || 3001,
  env: process.env.NODE_ENV || 'development',
  
  // Logging
  logLevel: process.env.LOG_LEVEL || 'info',
  
  // CORS
  corsOrigin: process.env.CORS_ORIGIN || '*',
  
  // API
  apiVersion: '0.1.0',
  apiTitle: 'Employee Service API',
  
  // Database (placeholder for future integration)
  database: {
    type: process.env.DB_TYPE || 'memory',
    host: process.env.DB_HOST || 'localhost',
    port: process.env.DB_PORT || 5432,
    name: process.env.DB_NAME || 'employees_db'
  },
  
  // Swagger/Docs
  swagger: {
    enabled: process.env.SWAGGER_ENABLED !== 'false',
    path: '/api/docs'
  }
};

module.exports = config;
