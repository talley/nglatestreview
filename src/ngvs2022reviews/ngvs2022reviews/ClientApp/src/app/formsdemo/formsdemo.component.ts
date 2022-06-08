import { Component, OnInit } from '@angular/core';

import {
  AbstractControl,
  FormBuilder,
  FormControl,
  FormGroup,
  Validators
} from '@angular/forms';
import { CastPipe } from '../../exts/CastPipe';
@Component({
  selector: 'app-formsdemo',
  templateUrl: './formsdemo.component.html',
  styleUrls: ['./formsdemo.component.css']
})
export class FormsdemoComponent implements OnInit {
  myForm: FormGroup;

  sku: AbstractControl;;
  product: AbstractControl;

  cast: CastPipe | undefined

  constructor(fb: FormBuilder) {
    this.myForm = fb.group({
      'product': ['', Validators.required],
      'sku': ['', Validators.required]//Validators.required, skuValidator])]
    })

    this.sku = this.myForm.controls['sku'] as AbstractControl;
    this.product = this.myForm.controls['product'] as AbstractControl;

    //listen for changes
    this.myForm.valueChanges.subscribe((form: any) => {
      console.log('form changed to:', form);
    });

    this.sku.valueChanges.subscribe((val: string) => {
      console.log('sku changed to:', val);
    });

    this.product.valueChanges.subscribe((val: string) => {
      console.log('product changed to:', val);
    })
  }

  ngOnInit(): void {
  }
  onSubmit0(form: any): void {
    console.log(form)
    console.log(JSON.stringify(form));

  }
  onSubmit(value: string): void {
    console.log('you submitted value: ', value);
  }
  /*
  skuValidator(control: FormControl): { [s: string]: boolean } {
   if (!control.value.match(/^123/)) {
     return { invalidSku: true };

  }
  }
  */

}
