const swaggerJsdoc = require('swagger-jsdoc');

const options = {
    definition: {
        openapi: '3.0.0',
        info: {
            title: 'Employee Service API',
            version: '0.1.0',
            description: 'In-memory Employee Service API (vertical-slice)'
        },
        servers: [
            { url: 'http://localhost:3001', description: 'Local server' }
        ],
        components: {
            schemas: {
                Employee: {
                    type: 'object',
                    properties: {
                        id: { type: 'string', example: '1' },
                        firstName: { type: 'string', example: 'Ada' },
                        lastName: { type: 'string', example: 'Lovelace' },
                        title: { type: 'string', example: 'Engineer' },
                        email: { type: 'string', example: 'ada@example.com' },
                        phone: { type: 'string', example: '+1-555-0100' },
                        createdAt: { type: 'string', format: 'date-time' },
                        updatedAt: { type: 'string', format: 'date-time' }
                    },
                    required: ['id','firstName','lastName','createdAt','updatedAt']
                },
                CreateEmployee: {
                    type: 'object',
                    properties: {
                        firstName: { type: 'string' },
                        lastName: { type: 'string' },
                        title: { type: 'string' },
                        email: { type: 'string' },
                        phone: { type: 'string' }
                    },
                    required: ['firstName','lastName']
                }
            }
        },
        paths: {
            '/employees': {
                get: {
                    summary: 'List all employees',
                    tags: ['Employees'],
                    responses: {
                        '200': {
                            description: 'List of employees',
                            content: {
                                'application/json': {
                                    schema: { type: 'array', items: { $ref: '#/components/schemas/Employee' } }
                                }
                            }
                        }
                    }
                },
                post: {
                    summary: 'Create an employee',
                    tags: ['Employees'],
                    requestBody: {
                        required: true,
                        content: { 'application/json': { schema: { $ref: '#/components/schemas/CreateEmployee' } } }
                    },
                    responses: {
                        '201': { description: 'Employee created', content: { 'application/json': { schema: { $ref: '#/components/schemas/Employee' } } } }
                    }
                }
            },
            '/employees/{id}': {
                get: {
                    summary: 'Get employee by ID',
                    tags: ['Employees'],
                    parameters: [{ name: 'id', in: 'path', required: true, schema: { type: 'string' } }],
                    responses: {
                        '200': { description: 'Employee found', content: { 'application/json': { schema: { $ref: '#/components/schemas/Employee' } } } },
                        '404': { description: 'Employee not found' }
                    }
                },
                put: {
                    summary: 'Update an employee',
                    tags: ['Employees'],
                    parameters: [{ name: 'id', in: 'path', required: true, schema: { type: 'string' } }],
                    requestBody: {
                        required: true,
                        content: { 'application/json': { schema: { $ref: '#/components/schemas/CreateEmployee' } } }
                    },
                    responses: {
                        '200': { description: 'Employee updated', content: { 'application/json': { schema: { $ref: '#/components/schemas/Employee' } } } },
                        '404': { description: 'Employee not found' }
                    }
                },
                delete: {
                    summary: 'Delete an employee',
                    tags: ['Employees'],
                    parameters: [{ name: 'id', in: 'path', required: true, schema: { type: 'string' } }],
                    responses: {
                        '204': { description: 'Employee deleted' },
                        '404': { description: 'Employee not found' }
                    }
                }
            }
        }
    },
    apis: []
};

const swaggerSpec = swaggerJsdoc(options);

module.exports = swaggerSpec;
