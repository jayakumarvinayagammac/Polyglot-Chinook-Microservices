const Logger = require('../../shared/logger');

/**
 * EmployeeController - HTTP request handlers with dependency injection
 */
class EmployeeController {
  constructor(service) {
    if (!service) throw new Error('Service is required for EmployeeController');
    this.service = service;
    this.logger = new Logger('EmployeeController');
    this.logger.info('Controller initialized');
  }

  createEmployee = (req, res, next) => {
    this.logger.methodEntry('createEmployee', { ip: req.ip });
    try {
      const data = req.body;
      const created = this.service.createEmployee(data);
      this.logger.info(`HTTP 201 Created: Employee ${created.id}`, { id: created.id });
      this.logger.methodExit('createEmployee');
      res.status(201).json(created);
    } catch (err) {
      this.logger.error('Error in createEmployee', err);
      next(err);
    }
  };

  getAllEmployees = (req, res, next) => {
    this.logger.methodEntry('getAllEmployees', { ip: req.ip });
    try {
      const list = this.service.getAllEmployees();
      this.logger.info(`HTTP 200 OK: Returned ${list.length} employees`);
      this.logger.methodExit('getAllEmployees', { count: list.length });
      res.json(list);
    } catch (err) {
      this.logger.error('Error in getAllEmployees', err);
      next(err);
    }
  };

  getEmployeeById = (req, res, next) => {
    this.logger.methodEntry('getEmployeeById', { id: req.params.id, ip: req.ip });
    try {
      const id = req.params.id;
      const e = this.service.getEmployeeById(id);
      if (!e) {
        this.logger.warn(`HTTP 404 Not Found: Employee ${id} not found`);
        this.logger.methodExit('getEmployeeById');
        return res.status(404).json({ error: 'Employee not found' });
      }
      this.logger.info(`HTTP 200 OK: Employee ${id} retrieved`);
      this.logger.methodExit('getEmployeeById', e);
      res.json(e);
    } catch (err) {
      this.logger.error('Error in getEmployeeById', err);
      next(err);
    }
  };

  updateEmployee = (req, res, next) => {
    this.logger.methodEntry('updateEmployee', { id: req.params.id, ip: req.ip });
    try {
      const id = req.params.id;
      const data = req.body;
      const updated = this.service.updateEmployee(id, data);
      if (!updated) {
        this.logger.warn(`HTTP 404 Not Found: Employee ${id} not found for update`);
        this.logger.methodExit('updateEmployee');
        return res.status(404).json({ error: 'Employee not found' });
      }
      this.logger.info(`HTTP 200 OK: Employee ${id} updated`);
      this.logger.methodExit('updateEmployee', updated);
      res.json(updated);
    } catch (err) {
      this.logger.error('Error in updateEmployee', err);
      next(err);
    }
  };

  deleteEmployee = (req, res, next) => {
    this.logger.methodEntry('deleteEmployee', { id: req.params.id, ip: req.ip });
    try {
      const id = req.params.id;
      const ok = this.service.deleteEmployee(id);
      if (!ok) {
        this.logger.warn(`HTTP 404 Not Found: Employee ${id} not found for deletion`);
        this.logger.methodExit('deleteEmployee');
        return res.status(404).json({ error: 'Employee not found' });
      }
      this.logger.info(`HTTP 204 No Content: Employee ${id} deleted`);
      this.logger.methodExit('deleteEmployee');
      res.status(204).end();
    } catch (err) {
      this.logger.error('Error in deleteEmployee', err);
      next(err);
    }
  };
}

module.exports = EmployeeController;
