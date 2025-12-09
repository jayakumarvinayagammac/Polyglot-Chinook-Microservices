const express = require('express');
const morgan = require('morgan');
const cors = require('cors');

const config = require('./config/config');
const Logger = require('./shared/logger');
const employeesRouter = require('./features/employees/routes');
const swaggerUi = require('swagger-ui-express');
const swaggerSpec = require('./shared/swagger');

const logger = new Logger('App');
const app = express();

logger.info('Initializing Express application', { env: config.env, port: config.port });

app.use(morgan(config.logLevel));
app.use(cors({ origin: config.corsOrigin }));
app.use(express.json());

logger.debug('Middleware configured');

app.get('/health', (req, res) => {
  logger.info('Health check endpoint called');
  res.json({ status: 'ok', timestamp: new Date().toISOString() });
});

// API routes
logger.info('Registering API routes');
app.use('/employees', employeesRouter);

// Swagger UI
if (config.swagger.enabled) {
  logger.info(`Swagger UI enabled at ${config.swagger.path}`);
  app.use(config.swagger.path, swaggerUi.serve, swaggerUi.setup(swaggerSpec));
} else {
  logger.info('Swagger UI disabled');
}

// Error handler
app.use((err, req, res, next) => {
  logger.error(`Unhandled error: ${err.message}`, err);
  res.status(err.status || 500).json({ error: err.message || 'Internal Server Error' });
});

const port = config.port;
const env = config.env;
if (require.main === module) {
  logger.info(`Starting Employee Service [${env}] on port ${port}`);
  app.listen(port, () => {
    logger.info(`Employee Service is listening on port ${port}`);
  });
}

module.exports = app;
