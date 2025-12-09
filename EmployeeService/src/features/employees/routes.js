const express = require('express');
const router = express.Router();
const container = require('./container');

// Resolve controller from container
const controller = container.resolve('employeeController');

// Routes
router.post('/', controller.createEmployee);
router.get('/', controller.getAllEmployees);
router.get('/:id', controller.getEmployeeById);
router.put('/:id', controller.updateEmployee);
router.delete('/:id', controller.deleteEmployee);

module.exports = router;
