import { ComponentFixture, TestBed } from '@angular/core/testing';
import { EmployeeListComponent } from './employee-list';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { AuthService } from '../../services/authservice';
import { EmployeeService } from '../../services/employeeservice';

describe('EmployeeListComponent', () => {
    let component: EmployeeListComponent;
    let fixture: ComponentFixture<EmployeeListComponent>;

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            imports: [EmployeeListComponent, HttpClientTestingModule],
            providers: [AuthService, EmployeeService]
        })
            .compileComponents();

        fixture = TestBed.createComponent(EmployeeListComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
