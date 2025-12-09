# Employee Service

Vertical-slice Node/Express microservice providing in-memory CRUD for Employee entities.

Quick start

1. Install dependencies

```bash
cd EmployeeService
npm install
```

2. Run

```bash
npm start
# or for development (requires nodemon):
npm run dev
```

API Endpoints

- `GET /health` - health check
- `GET /employees` - list employees
- `GET /employees/:id` - get employee by id
- `POST /employees` - create employee (json body: `firstName`, `lastName`, optional `title`, `email`, `phone`)
- `PUT /employees/:id` - update employee (partial allowed)
- `DELETE /employees/:id` - delete employee

API Documentation

- Swagger UI: `GET /docs` (when service running locally at `http://localhost:3001/docs`)

Example create

```bash
curl -sS -X POST http://localhost:3001/employees -H 'Content-Type: application/json' -d '{"firstName":"Ada","lastName":"Lovelace","title":"Engineer"}'
```
