/**
 * IEmployeeRepository - Interface/Contract for Employee data access
 * Defines the contract that any repository implementation must follow
 */

class IEmployeeRepository {
  /**
   * Create a new employee
   * @param {Object} data - Employee data
   * @returns {Object} Created employee
   */
  create(data) {
    throw new Error('create() method must be implemented');
  }

  /**
   * Find all employees
   * @returns {Array} List of employees
   */
  findAll() {
    throw new Error('findAll() method must be implemented');
  }

  /**
   * Find employee by ID
   * @param {string} id - Employee ID
   * @returns {Object|null} Employee or null if not found
   */
  findById(id) {
    throw new Error('findById() method must be implemented');
  }

  /**
   * Update an employee
   * @param {string} id - Employee ID
   * @param {Object} data - Update data
   * @returns {Object|null} Updated employee or null if not found
   */
  update(id, data) {
    throw new Error('update() method must be implemented');
  }

  /**
   * Delete an employee
   * @param {string} id - Employee ID
   * @returns {boolean} True if deleted, false if not found
   */
  remove(id) {
    throw new Error('remove() method must be implemented');
  }
}

module.exports = IEmployeeRepository;
