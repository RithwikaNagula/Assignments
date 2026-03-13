// Employee Model
// Matches the backend EmployeeDto
export interface Employee {
    id: number;
    name: string;
    email: string;
    department: string;
    salary: number;
    role: string;         // Admin / Manager / Employee
    managerId: number | null;
    managerName: string | null;
}

