import { FormGroup, Validators } from "@angular/forms";

export class SignInUpValidator {
    public static getNameValidator(a:number, b:number){
        return [SignInUpValidator.getRequiredValidator(),Validators.pattern(`[A-Za-z]{${a},${b}}`)];
    }

    public static getUserNameValidator(a:number, b:number){
        return [SignInUpValidator.getRequiredValidator(),Validators.pattern(`[A-Za-z0-9-_]{${a},${b}}`)];
    }

    public static getEmailValidator(){
        return [SignInUpValidator.getRequiredValidator(),Validators.email];
    }

    public static getPasswordValidator(a:number, b:number){
        return [SignInUpValidator.getRequiredValidator(),Validators.pattern(`^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[""!@$%^&*(){}:;<>,.?/+_=|'~\\-]).{${a},${b}}$`)];
    }

    public static getRequiredValidator()
    {
        return Validators.required;
    }
}