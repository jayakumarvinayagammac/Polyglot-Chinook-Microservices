const IEmployeeService = require('./iService');
const Logger = require('../../shared/logger');

/**
 * EmployeeService - implements IEmployeeService
 * Business logic layer with dependency injection
 */
class EmployeeService extends IEmployeeService {
  constructor(repository) {
    super();
    if (!repository) throw new Error('Repository is required for EmployeeService');
    this.repository = repository;
    this.logger = new Logger('EmployeeService');
    this.logger.info('Service initialized');
  }

  validateEmployee(data) {
    this.logger.debug('Validating employee data', { hasData: !!data });
    if (!data || typeof data !== 'object') {
      this.logger.warn('Validation failed: Employee data is required');
      throw Object.assign(new Error('Employee data is required'), { status: 400 });
    }
    if (!data.firstName || !data.lastName) {
      this.logger.warn('Validation failed: firstName and lastName are required');
      throw Object.assign(new Error('firstName and lastName are required'), { status: 400 });
    }
    this.logger.debug('Employee data validation passed');
  }

  createEmployee(data) {
    this.logger.methodEntry('createEmployee', { firstName: data?.firstName });
    try {
      this.validateEmployee(data);
      const result = this.repository.create(data);
      this.logger.info(`Employee created: ${result.id}`, { id: result.id });
      this.logger.methodExit('createEmployee', result);
      return result;
    } catch (err) {
      this.logger.error('Error creating employee', err);
      throw err;
    }
  }

  getAllEmployees() {
    this.logger.methodEntry('getAllEmployees');
    try {
      const result = this.repository.findAll();
      this.logger.info(`Retrieved ${result.length} employees`);
      this.logger.methodExit('getAllEmployees', { count: result.length });
      return result;
    } catch (err) {
      this.logger.error('Error retrieving employees', err);
      throw err;
    }
  }

  getEmployeeById(id) {
    this.logger.methodEntry('getEmployeeById', { id });
    try {
      const result = this.repository.findById(id);
      this.logger.info(`Employee lookup: ${result ? 'found' : 'not found'}`, { id });
      this.logger.methodExit('getEmployeeById', result);
      return result;
    } catch (err) {
      this.logger.error('Error retrieving employee by ID', err);
      throw err;
    }
  }

  updateEmployee(id, data) {
    this.logger.methodEntry('updateEmployee', { id, changes: Object.keys(data || {}) });
    try {
      if (!data || typeof data !== 'object') {
        this.logger.warn('Update validation failed: Employee data is required');
        throw Object.assign(new Error('Employee data is required'), { status: 400 });
      }
      const result = this.repository.update(id, data);
      if (result) {
        this.logger.info(`Employee ${id} updated successfully`);
      } else {
        this.logger.warn(`Update failed: Employee ${id} not found`);
      }
      this.logger.methodExit('updateEmployee', result);
      return result;
    } catch (err) {
      this.logger.error('Error updating employee', err);
      throw err;
    }
  }

  deleteEmployee(id) {
    this.logger.methodEntry('deleteEmployee', { id });
    try {
      const result = this.repository.remove(id);
      if (result) {
        this.logger.info(`Employee ${id} deleted successfully`);
      } else {
        this.logger.warn(`Delete failed: Employee ${id} not found`);
      }
      this.logger.methodExit('deleteEmployee', result);
      return result;
    } catch (err) {
      this.logger.error('Error deleting employee', err);
      throw err;
    }
  }
}

module.exports = EmployeeService;

