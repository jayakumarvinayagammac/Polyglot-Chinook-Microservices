const IEmployeeRepository = require('./iRepository');
const Logger = require('../../shared/logger');

/**
 * InMemoryEmployeeRepository - implements IEmployeeRepository
 * Simple in-memory repository for Employee entities
 */
class InMemoryEmployeeRepository extends IEmployeeRepository {
  constructor() {
    super();
    this.logger = new Logger('InMemoryEmployeeRepository');
    this.employees = [];
    this.nextId = 1;
    this.logger.info('Repository initialized');
  }

  create(data) {
    this.logger.methodEntry('create', { firstName: data.firstName, lastName: data.lastName });
    const now = new Date().toISOString();
    const emp = {
      id: String(this.nextId++),
      firstName: data.firstName,
      lastName: data.lastName,
      title: data.title || null,
      email: data.email || null,
      phone: data.phone || null,
      createdAt: now,
      updatedAt: now
    };
    this.employees.push(emp);
    this.logger.info(`Employee created with ID: ${emp.id}`);
    this.logger.methodExit('create', emp);
    return emp;
  }

  findAll() {
    this.logger.methodEntry('findAll');
    const result = this.employees.slice();
    this.logger.info(`Retrieved ${result.length} employees`);
    this.logger.methodExit('findAll', { count: result.length });
    return result;
  }

  findById(id) {
    this.logger.methodEntry('findById', { id });
    const result = this.employees.find(e => e.id === String(id)) || null;
    this.logger.info(`Employee lookup by ID ${id}: ${result ? 'found' : 'not found'}`);
    this.logger.methodExit('findById', result);
    return result;
  }

  update(id, data) {
    this.logger.methodEntry('update', { id, changes: Object.keys(data) });
    const idx = this.employees.findIndex(e => e.id === String(id));
    if (idx === -1) {
      this.logger.warn(`Update failed: Employee with ID ${id} not found`);
      return null;
    }
    const existing = this.employees[idx];
    const updated = Object.assign({}, existing, {
      firstName: data.firstName !== undefined ? data.firstName : existing.firstName,
      lastName: data.lastName !== undefined ? data.lastName : existing.lastName,
      title: data.title !== undefined ? data.title : existing.title,
      email: data.email !== undefined ? data.email : existing.email,
      phone: data.phone !== undefined ? data.phone : existing.phone,
      updatedAt: new Date().toISOString()
    });
    this.employees[idx] = updated;
    this.logger.info(`Employee ${id} updated`);
    this.logger.methodExit('update', updated);
    return updated;
  }

  remove(id) {
    this.logger.methodEntry('remove', { id });
    const idx = this.employees.findIndex(e => e.id === String(id));
    if (idx === -1) {
      this.logger.warn(`Delete failed: Employee with ID ${id} not found`);
      this.logger.methodExit('remove', false);
      return false;
    }
    this.employees.splice(idx, 1);
    this.logger.info(`Employee ${id} deleted`);
    this.logger.methodExit('remove', true);
    return true;
  }
}

module.exports = InMemoryEmployeeRepository;

