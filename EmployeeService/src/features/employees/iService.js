/**
 * IEmployeeService - Interface/Contract for Employee business logic
 * Defines the contract that any service implementation must follow
 */

class IEmployeeService {
  /**
   * Create a new employee
   * @param {Object} data - Employee data
   * @returns {Object} Created employee
   */
  createEmployee(data) {
    throw new Error('createEmployee() method must be implemented');
  }

  /**
   * Get all employees
   * @returns {Array} List of employees
   */
  getAllEmployees() {
    throw new Error('getAllEmployees() method must be implemented');
  }

  /**
   * Get employee by ID
   * @param {string} id - Employee ID
   * @returns {Object|null} Employee or null if not found
   */
  getEmployeeById(id) {
    throw new Error('getEmployeeById() method must be implemented');
  }

  /**
   * Update an employee
   * @param {string} id - Employee ID
   * @param {Object} data - Update data
   * @returns {Object|null} Updated employee or null if not found
   */
  updateEmployee(id, data) {
    throw new Error('updateEmployee() method must be implemented');
  }

  /**
   * Delete an employee
   * @param {string} id - Employee ID
   * @returns {boolean} True if deleted, false if not found
   */
  deleteEmployee(id) {
    throw new Error('deleteEmployee() method must be implemented');
  }
}

module.exports = IEmployeeService;
