import { AbstractControl, ValidatorFn } from '@angular/forms';

export function numberValidator(): ValidatorFn {
  return (control: AbstractControl): { [key: string]: any } | null => {
    const numberRegex = /^\d{10}$/;

    const valid = numberRegex.test(control.value);
    return valid ? null : { number: true };
  };
}
