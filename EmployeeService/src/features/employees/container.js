/**
 * Container - Centralized dependency injection container
 * Manages instantiation and resolution of dependencies
 */

const Logger = require('../../shared/logger');
const EmployeeController = require('./controller');
const EmployeeService = require('./service');
const InMemoryEmployeeRepository = require('./repository');

class Container {
  constructor() {
    this.services = new Map();
    this.logger = new Logger('DependencyContainer');
    this.logger.info('Container initialized');
  }

  /**
   * Register a singleton service with a factory function
   * @param {string} name - Service name
   * @param {Function} factory - Factory function that returns service instance
   */
  register(name, factory) {
    this.logger.debug(`Registering singleton service: ${name}`);
    this.services.set(name, { factory, instance: null, singleton: true });
  }

  /**
   * Resolve a service
   * @param {string} name - Service name
   * @returns {*} Service instance
   */
  resolve(name) {
    this.logger.methodEntry('resolve', { serviceName: name });
    const service = this.services.get(name);
    if (!service) {
      const error = `Service '${name}' not registered`;
      this.logger.error(error);
      throw new Error(error);
    }

    if (service.singleton) {
      if (!service.instance) {
        this.logger.info(`Creating singleton instance for: ${name}`);
        // If factory is a class, instantiate it; if it's a function, call it
        service.instance = typeof service.factory === 'function' && service.factory.prototype 
          ? new service.factory() 
          : service.factory();
        this.logger.info(`Singleton instance created for: ${name}`);
      } else {
        this.logger.debug(`Reusing singleton instance for: ${name}`);
      }
      return service.instance;
    }

    this.logger.debug(`Creating transient instance for: ${name}`);
    return new service.factory();
  }
}

// Setup and export container
const container = new Container();

// Register repository as singleton
container.register('employeeRepository', InMemoryEmployeeRepository);

// Register service as singleton (depends on repository)
container.register('employeeService', () => {
  const repo = container.resolve('employeeRepository');
  return new EmployeeService(repo);
});

// Register controller as singleton (depends on service)
container.register('employeeController', () => {
  const service = container.resolve('employeeService');
  return new EmployeeController(service);
});

module.exports = container;
