import { ComponentFixture, TestBed } from '@angular/core/testing';
import { EmployeeDashboard } from './employee';

describe('EmployeeDashboard', () => {
    let component: EmployeeDashboard;
    let fixture: ComponentFixture<EmployeeDashboard>;

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            imports: [EmployeeDashboard]
        }).compileComponents();

        fixture = TestBed.createComponent(EmployeeDashboard);
        component = fixture.componentInstance;
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
