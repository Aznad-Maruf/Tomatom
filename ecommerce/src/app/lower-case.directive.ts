import { Directive, HostListener, ElementRef } from '@angular/core';

@Directive({
  selector: '[appLowerCase]'
})
export class LowerCaseDirective {

  constructor(private el: ElementRef) { }

  @HostListener('focus') onFocus(){
    console.log('on focus');
  }

  @HostListener('blur') onBlur(){
    let value: string = this.el.nativeElement.value;
    this.el.nativeElement.value = value.toLowerCase();
    console.log(this.el.nativeElement.valid);
  }

}
