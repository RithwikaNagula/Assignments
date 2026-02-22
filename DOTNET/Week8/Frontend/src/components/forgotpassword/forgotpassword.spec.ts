import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ForgotPassword } from './forgotpassword';

describe('ForgotPassword', () => {
    let component: ForgotPassword;
    let fixture: ComponentFixture<ForgotPassword>;

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            imports: [ForgotPassword]
        }).compileComponents();

        fixture = TestBed.createComponent(ForgotPassword);
        component = fixture.componentInstance;
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
